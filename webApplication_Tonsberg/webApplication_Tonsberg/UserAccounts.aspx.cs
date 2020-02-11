using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class UserAccounts : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_UserAccount("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvUserAccountsList);

                    _gc.DeserializeDropDownList(wcfService.Get_UserGroups("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "GroupName", "GroupID", ddlUADetails_UserGroup);
                    _gc.DeserializeDropDownList(wcfService.Get_Office("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "OfficeName", "OfficeID", ddlUADetails_Office);
                    _gc.DeserializeDropDownList(wcfService.Get_Department("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "DepartmentName", "DepartmentID", ddlUADetails_Department);

                    MainButton(true, false);

                    mvUserAccounts.SetActiveView(vwViewUserAccounts);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserAccounts", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }


        protected void btnUserAccount_Create_Click(object sender, EventArgs e)
        {
            mvUserAccounts.SetActiveView(vwDetailsUserAccounts);
            MainButton(false, true);
            Clear();
        }

        protected void btnUserAccount_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_UserAccount("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvUserAccountsList);

            MainButton(true, false);
            Clear();

            mvUserAccounts.SetActiveView(vwViewUserAccounts);
        }


        protected void btnUADetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtUADetails_UserName.Text != "" && txtUADetails_UserName.Text != "0")
            {
                if (txtUADetails_Password1.Text != "" && txtUADetails_Password2.Text != "")
                {
                    if (txtUADetails_Password1.Text == txtUADetails_Password2.Text)
                    {
                        if (ddlUADetails_UserGroup.SelectedValue != "0")
                        {
                            if (ddlUADetails_Department.SelectedValue != "0")
                            {
                                if (ddlUADetails_Office.SelectedValue != "0")
                                {
                                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                                }
                                else { lblUADetails_Alert.Text = "Please select a Office."; }
                            }
                            else { lblUADetails_Alert.Text = "Please select a Department."; }
                        }
                        else { lblUADetails_Alert.Text = "Please select a User Group."; }
                    }
                    else { lblUADetails_Alert.Text = "Password does not match."; }
                }
                else { lblUADetails_Alert.Text = "Please input a password."; }
            }
            else { lblUADetails_Alert.Text = "Username cannot be empty."; }
        }

        protected void btnUADetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnUADetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save User Account
                wcfService.Save_UserAccounts(_gc.ToInt32(hfUserID.Value), txtUADetails_UserName.Text, txtUADetails_Password1.Text, txtUADetails_FirstName.Text
                    , txtUADetails_LastName.Text, _gc.ToInt32(ddlUADetails_UserGroup.SelectedValue), txtUADetails_EmailAddress.Text, ddlUADetails_Office.SelectedValue
                    , _gc.ToInt32(ddlUADetails_Department.SelectedValue), chkUADetails_Active.Checked, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction Logs
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save User Account - Username: " + txtUADetails_UserName.Text + "; Name: " + txtUADetails_FirstName.Text + " " + txtUADetails_LastName.Text
                    + "; UserGroup: " + ddlUADetails_UserGroup.SelectedValue + "; Department: " + ddlUADetails_Department.SelectedValue + "; Office: " + ddlUADetails_Office.SelectedValue
                    + "; Email: " + txtUADetails_EmailAddress.Text + "; Active: " + chkUADetails_Active.Checked.ToString();

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserAccounts", "btnUADetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblUADetails_Active.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserAccounts", "btnUADetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_UserAccount("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvUserAccountsList);

                MainButton(true, false);
                Clear();

                mvUserAccounts.SetActiveView(vwViewUserAccounts);
            }

            #endregion
        }

        protected void btnUADetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_UserAccount("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvUserAccountsList);

            MainButton(true, false);
            Clear();

            mvUserAccounts.SetActiveView(vwViewUserAccounts);
        }

        protected void btnUADetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void lnkUserAccount_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_UserAccount(txtUserAccount_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvUserAccountsList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserAccounts", "lnkUserAccount_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void gvUserAccountsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvUserAccountsList.PageSize;
                GridViewRow row = gvUserAccountsList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfUserID.Value = row.Cells[0].Text;
                    txtUADetails_UserName.Text = row.Cells[1].Text;
                    txtUADetails_Password1.Text = "";
                    txtUADetails_Password2.Text = "";
                    txtUADetails_FirstName.Text = row.Cells[3].Text;
                    txtUADetails_LastName.Text = row.Cells[4].Text;
                    ddlUADetails_UserGroup.SelectedValue = row.Cells[5].Text;
                    txtUADetails_EmailAddress.Text = row.Cells[7].Text.Replace("&nbsp;", "");
                    ddlUADetails_Department.SelectedValue = row.Cells[8].Text;
                    ddlUADetails_Office.SelectedValue = row.Cells[10].Text;
                    chkUADetails_Active.Checked = _gc.Load_CheckBox(row.Cells[11].Text);

                    mvUserAccounts.SetActiveView(vwDetailsUserAccounts);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserAccounts", "gvUserAccountsList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvUserAccountsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUserAccountsList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_UserAccount("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvUserAccountsList);
        }

        protected void gvUserAccountsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnUserAccount_Create.Visible = _btnCreate;
            btnUserAccount_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblUADetails_NotifHeader.Text = _HeaderText;
            lblUADetails_NotifBody.Text = _BodyText;

            btnUADetails_SaveYes.Visible = _Save;
            btnUADetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfUserID.Value = "0";
            txtUADetails_UserName.Text = "";
            txtUADetails_Password1.Text = "";
            txtUADetails_Password2.Text = "";
            txtUADetails_FirstName.Text = "";
            txtUADetails_LastName.Text = "";
            txtUADetails_EmailAddress.Text = "";
            ddlUADetails_UserGroup.SelectedValue = "0";
            ddlUADetails_Department.SelectedValue = "0";
            ddlUADetails_Office.SelectedValue = "0";
            chkUADetails_Active.Checked = true;

            lblUADetails_Active.Text = "";
        }

        #endregion
    }
}