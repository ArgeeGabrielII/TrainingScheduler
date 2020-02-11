using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class SystemModules : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_SystemModules("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                      , gvPageModulesList);

                    MainButton(true, false);

                    mvPageModules.SetActiveView(vwViewPageModules);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "PageModules", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }


        protected void btnPageModules_Create_Click(object sender, EventArgs e)
        {
            mvPageModules.SetActiveView(vwDetailsPageModules);
            MainButton(false, true);
            Clear();
        }

        protected void btnPageModules_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_SystemModules("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPageModulesList);

            MainButton(true, false);
            Clear();

            mvPageModules.SetActiveView(vwViewPageModules);
        }


        protected void lnkPageModulesView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_SystemModules(txtPageModulesView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvPageModulesList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "PageModules", "lnkPageModulesView_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }


        protected void btnPageModulesDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtPageModulesDetails_Name.Text != "")
            {
                if (txtPageModulesDetails_URL.Text != "")
                {
                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                }
                else { lblPageModulesDetails_Alert.Text = "Page Name is a required field."; }
            }
            else { lblPageModulesDetails_Alert.Text = "Page URL is a required field."; }
        }

        protected void btnPageModulesDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }


        protected void btnPageModulesDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Page Modules
                wcfService.Save_SystemModules(_gc.ToInt32(hfPageModulesID.Value), txtPageModulesDetails_Name.Text, txtPageModulesDetails_Description.Text, txtPageModulesDetails_URL.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save Page Modules - Module ID: " + hfPageModulesID.Value + "; Module Name: " + txtPageModulesDetails_Name.Text + "; Description: "
                    + txtPageModulesDetails_Description.Text + "; Module URL: " + txtPageModulesDetails_URL.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "PageModules", "btnPageModulesDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblPageModulesDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "PageModules", "btnPageModulesDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_SystemModules("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvPageModulesList);

                MainButton(true, false);
                Clear();

                mvPageModules.SetActiveView(vwViewPageModules);
            }

            #endregion
        }

        protected void btnPageModulesDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_SystemModules("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPageModulesList);

            MainButton(true, false);
            Clear();

            mvPageModules.SetActiveView(vwViewPageModules);
        }

        protected void btnPageModulesDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void gvPageModulesList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int rowindex = Convert.ToInt32(e.CommandArgument) % gvPageModulesList.PageSize;
                GridViewRow row = gvPageModulesList.Rows[rowindex];

                if (e.CommandName == "Select")
                {
                    hfPageModulesID.Value = row.Cells[0].Text;
                    txtPageModulesDetails_Name.Text = row.Cells[1].Text.Replace("&nbsp;", "");
                    txtPageModulesDetails_Description.Text = row.Cells[2].Text.Replace("&nbsp;", "");
                    txtPageModulesDetails_URL.Text = row.Cells[2].Text.Replace("&nbsp;", "");

                    mvPageModules.SetActiveView(vwDetailsPageModules);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "PageModules", "gvPageModulesList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvPageModulesList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPageModulesList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_SystemModules(txtPageModulesView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvPageModulesList);
        }

        protected void gvPageModulesList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnPageModules_Create.Visible = _btnCreate;
            btnPageModules_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblPageModulesDetails_NotifHeader.Text = _HeaderText;
            lblPageModulesDetails_NotifBody.Text = _BodyText;

            btnPageModulesDetails_SaveYes.Visible = _Save;
            btnPageModulesDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfPageModulesID.Value = "0";
            txtPageModulesDetails_Name.Text = "";
            txtPageModulesDetails_Description.Text = "";
            txtPageModulesDetails_URL.Text = "";

            lblPageModulesDetails_Alert.Text = "";
        }

        #endregion
    }
}