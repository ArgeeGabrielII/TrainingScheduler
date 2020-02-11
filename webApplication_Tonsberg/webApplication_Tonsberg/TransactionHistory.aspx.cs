using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class TransactionHistory : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_TransactionHistory("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTransactionHistory);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TransactionHistory", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void lnkTransactionHistory_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_TransactionHistory(txtTransactionHistory_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTransactionHistory);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TransactionHistory", "lnkTransactionHistory_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvTransactionHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text.ToString().Length > 100)
                {
                    e.Row.Cells[5].ToolTip = e.Row.Cells[5].Text;
                    e.Row.Cells[5].Text = e.Row.Cells[5].Text.ToString().Substring(0, 100) + " ... ";
                }
                if (e.Row.Cells[6].Text.ToString().Length > 100)
                {
                    e.Row.Cells[6].ToolTip = e.Row.Cells[6].Text;
                    e.Row.Cells[6].Text = e.Row.Cells[6].Text.ToString().Substring(0, 100) + " ... ";
                }
            }
        }

        protected void gvTransactionHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTransactionHistory.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_TransactionHistory(txtTransactionHistory_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTransactionHistory);
        }
    }
}