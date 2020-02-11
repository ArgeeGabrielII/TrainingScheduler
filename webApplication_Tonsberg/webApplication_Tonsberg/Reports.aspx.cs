using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class Reports : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();
        private int _rIndex;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDropDownList(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "CourseName", "CourseID", ddlReport_Course);

                    _rIndex = 0;
                    divCourse.Visible = false;
                }
            }
            catch (Exception ex) { }
        }

        #region Override

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        #endregion

        #region Event(s)

        protected void ddlReport_Selection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlReport_Selection.SelectedValue)
            {
                case "2":
                    divCourse.Visible = true;
                    break;
                case "4":
                    divCourse.Visible = true;
                    break;
                default:
                    divCourse.Visible = false;
                    break;
            }
        }

        protected void btnReport_GenerateReport_Click(object sender, EventArgs e)
        {
            gvTitleHeader.Text = ddlReport_Selection.SelectedItem.ToString();

            switch (ddlReport_Selection.SelectedValue)
            {
                case "1":
                    _gc.DeserializeDataTable(wcfService.Report_AccountsReceivable_All(txtReport_DateFrom.Text, txtReport_DateTo.Text
                        , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]), gvReport);
                    break;
                case "2":
                    _gc.DeserializeDataTable(wcfService.Report_AccountsReceivable_Course(txtReport_DateFrom.Text, txtReport_DateTo.Text
                        , _gc.ToInt32(ddlReport_Course.SelectedValue), _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvReport);
                    break;
                case "3":
                    _gc.DeserializeDataTable(wcfService.Report_Sales_All(txtReport_DateFrom.Text, txtReport_DateTo.Text
                        , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]), gvReport);
                    break;
                case "4":
                    _gc.DeserializeDataTable(wcfService.Report_Sales_Course(txtReport_DateFrom.Text, txtReport_DateTo.Text
                        , _gc.ToInt32(ddlReport_Course.SelectedValue), _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvReport);
                    break;
                default:
                    _gc.DeserializeDataTable("", gvReport);
                    break;
            }
        }

        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowIndex == 0)
                    {
                        e.Row.BackColor = System.Drawing.Color.Gray;
                        e.Row.ForeColor = System.Drawing.Color.White;
                        e.Row.Font.Bold = true;
                    }

                    _rIndex += 1;
                }
            }
            catch { /*do nothing*/ }
        }

        protected void gvReport_DataBound(object sender, EventArgs e)
        {
            try
            {
                gvReport.Rows[_rIndex - 1].BackColor = System.Drawing.Color.Green;
                gvReport.Rows[_rIndex - 1].ForeColor = System.Drawing.Color.White;
                gvReport.Rows[_rIndex - 1].Font.Bold = true;
            }
            catch { /*do nothing*/ }
        }

        protected void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            string _rTitle = "";

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    gvReport.AllowPaging = false;

                    //Set Report Title
                    _rTitle = ddlReport_Selection.SelectedItem.ToString();

                    //Get GV Control
                    gvReport.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.LETTER, 10f, 10f, 10f, 10f);
                    pdfDoc.SetPageSize(iTextSharp.text.PageSize.LETTER.Rotate());
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();

                    //Add Report Title to PDF
                    Font _ft14 = new Font(Font.HELVETICA, 14f);
                    pdfDoc.Add(new Paragraph("TONSBERG SYSTEM: " + _rTitle + "\n\n", _ft14));

                    //Add Report Date Range to PDF
                    //---->

                    //GridView Parse to PDF
                    htmlparser.Parse(sr);

                    //DateTimeStamp
                    BaseFont _bfDateTimeStamp = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1252, false);
                    Font _ftDateTimeStamp = new Font(_bfDateTimeStamp, 8, Font.ITALIC, Color.GRAY);
                    pdfDoc.Add(new Paragraph("DateGenerated: " + DateTime.Now.ToString("yyyyMMddHHmmss") + "; GeneratedBy: "
                        + _Cypher.Decrypt(Session["UserName"].ToString(), _Cypher._PassPhrase), _ftDateTimeStamp));

                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddHHmmss") + _rTitle + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }

        #endregion
    }
}