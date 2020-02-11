using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class Department : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_Department("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvDepartmentList);

                    MainButton(true, false);

                    mvDepartment.SetActiveView(vwViewDepartment);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Department", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        #region Event(s)

        protected void btnDepartment_Create_Click(object sender, EventArgs e)
        {
            mvDepartment.SetActiveView(vwDetailsDepartment);
            MainButton(false, true);
            Clear();
        }

        protected void btnDepartment_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_Department("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvDepartmentList);

            MainButton(true, false);
            Clear();

            mvDepartment.SetActiveView(vwViewDepartment);
        }

        protected void lnkDepartmentView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_Department(txtDepartmentView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvDepartmentList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Department", "lnkDepartmentView_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnDepartmentDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtDepartmentDetails_Code.Text != "")
            {
                if (txtDepartmentDetails_Name.Text != "")
                {
                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                }
                else { lblDepartmentDetails_Alert.Text = "Department Name is a required field."; }
            }
            else { lblDepartmentDetails_Alert.Text = "Department Code is a required field."; }
        }

        protected void btnDepartmentDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }

        protected void btnDepartmentDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Department
                wcfService.Save_Department(_gc.ToInt32(hfDepartmentID.Value), txtDepartmentDetails_Code.Text, txtDepartmentDetails_Name.Text, chkDepartmentDetails_Active.Checked
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save Department - Department ID: " + hfDepartmentID.Value + "; Department Code: " + txtDepartmentDetails_Code.Text + "; Department Name: "
                    + txtDepartmentDetails_Name.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Department", "btnDepartmentDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblDepartmentDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Department", "btnDepartmentDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_Department("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvDepartmentList);

                MainButton(true, false);
                Clear();

                mvDepartment.SetActiveView(vwViewDepartment);
            }

            #endregion
        }

        protected void btnDepartmentDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_Department("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvDepartmentList);

            MainButton(true, false);
            Clear();

            mvDepartment.SetActiveView(vwViewDepartment);
        }

        protected void btnDepartmentDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #endregion

        #region GridView Events

        protected void gvDepartmentList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvDepartmentList.PageSize;
                GridViewRow row = gvDepartmentList.Rows[index];

                if (e.CommandName == "Select")
                {
                    hfDepartmentID.Value = row.Cells[0].Text;
                    txtDepartmentDetails_Code.Text = row.Cells[1].Text.Replace("&nbsp;", "");
                    txtDepartmentDetails_Name.Text = row.Cells[2].Text.Replace("&nbsp;", "");
                    chkDepartmentDetails_Active.Checked = _gc.Load_CheckBox(row.Cells[3].Text);

                    mvDepartment.SetActiveView(vwDetailsDepartment);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Department", "gvDepartmentList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvDepartmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartmentList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_Department(txtDepartmentView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvDepartmentList);
        }

        protected void gvDepartmentList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnDepartment_Create.Visible = _btnCreate;
            btnDepartment_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblDepartmentDetails_NotifHeader.Text = _HeaderText;
            lblDepartmentDetails_NotifBody.Text = _BodyText;

            btnDepartmentDetails_SaveYes.Visible = _Save;
            btnDepartmentDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfDepartmentID.Value = "0";
            txtDepartmentDetails_Code.Text = "";
            txtDepartmentDetails_Name.Text = "";
            chkDepartmentDetails_Active.Checked = true;

            lblDepartmentDetails_Alert.Text = "";
        }

        #endregion
    }
}