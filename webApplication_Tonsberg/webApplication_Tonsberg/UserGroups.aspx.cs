using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class UserGroups : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_UserGroups("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                          , gvUserGroupsList);

                    MainButton(true, false);

                    mvUserGroup.SetActiveView(vwViewUserGroups);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserGroup", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }


        protected void btnUserGroup_Create_Click(object sender, EventArgs e)
        {
            mvUserGroup.SetActiveView(vwDetailsUserGroup);
            MainButton(false, true);
            Clear();
        }

        protected void btnUserGroup_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_UserGroups("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvUserGroupsList);

            MainButton(true, false);
            Clear();

            mvUserGroup.SetActiveView(vwViewUserGroups);
        }


        protected void btnUGDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtUGDetails_GroupName.Text != "")
            {
                NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
            }
            else { lblUGDetails_Alert.Text = "Group Name is a required field."; }
        }

        protected void btnUGDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", true, false);
        }


        protected void btnUGDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save User Group
                wcfService.Save_UserGroups(_gc.ToInt32(hfUserGroupID.Value), txtUGDetails_GroupName.Text, txtUGDetails_Description.Text, chkUGDetails_Active.Checked
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save User Trails
                string _TransType = "";
                _TransType = "Save User Group - Group Name: " + txtUGDetails_GroupName.Text + "; Description: " + txtUGDetails_Description.Text + "; Active: " + chkUGDetails_Active.Checked.ToString();

                //Save Transaction Logs
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserGroups", "btnUGDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblUGDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserGroups", "btnUGDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_UserGroups("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvUserGroupsList);

                MainButton(true, false);
                Clear();

                mvUserGroup.SetActiveView(vwViewUserGroups);
            }

            #endregion
        }

        protected void btnUGDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_UserGroups("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvUserGroupsList);

            MainButton(true, false);
            Clear();

            mvUserGroup.SetActiveView(vwViewUserGroups);
        }

        protected void btnUGDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void lnkUserGroup_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_UserGroups(txtUserGroup_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvUserGroupsList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserGroup", "lnkUserGroup_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void gvUserGroupsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvUserGroupsList.PageSize;
                GridViewRow row = gvUserGroupsList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfUserGroupID.Value = row.Cells[0].Text;
                    txtUGDetails_GroupName.Text = row.Cells[1].Text;
                    txtUGDetails_Description.Text = row.Cells[2].Text;
                    chkUGDetails_Active.Checked = _gc.Load_CheckBox(row.Cells[3].Text);

                    mvUserGroup.SetActiveView(vwDetailsUserGroup);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserGroup", "gvUserGroupsList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvUserGroupsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUserGroupsList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_UserGroups(txtUserGroup_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvUserGroupsList);
        }

        protected void gvUserGroupsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnUserGroup_Create.Visible = _btnCreate;
            btnUserGroup_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblUGDetails_NotifHeader.Text = _HeaderText;
            lblUGDetails_NotifBody.Text = _BodyText;

            btnUGDetails_SaveYes.Visible = _Save;
            btnUGDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfUserGroupID.Value = "0";
            txtUGDetails_GroupName.Text = "";
            txtUGDetails_Description.Text = "";
            chkUGDetails_Active.Checked = true;

            lblUGDetails_Alert.Text = "";
        }

        #endregion
    }
}