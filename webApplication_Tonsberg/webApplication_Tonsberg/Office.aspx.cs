using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class Office : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_Office("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                            , gvOfficeList);

                    MainButton(true, false);

                    mvOffice.SetActiveView(vwViewOffice);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Office", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnOffice_Create_Click(object sender, EventArgs e)
        {
            mvOffice.SetActiveView(vwDetailsOffice);
            MainButton(false, true);
            Clear();
        }

        protected void btnOffice_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_Office("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvOfficeList);

            MainButton(true, false);
            Clear();

            mvOffice.SetActiveView(vwViewOffice);
        }

        protected void lnkOfficeView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_Office(txtOfficeView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvOfficeList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Office", "lnkOfficeView_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnOfficeDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtOfficeDetails_Code.Text != "")
            {
                if (txtOfficeDetails_Name.Text != "")
                {
                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                }
                else { lblOfficeDetails_Alert.Text = "Office Name is a required field."; }
            }
            else { lblOfficeDetails_Alert.Text = "Office Code is a required field."; }
        }

        protected void btnOfficeDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }

        protected void btnOfficeDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Office
                wcfService.Save_Office(_gc.ToInt32(hfOfficeID.Value), txtOfficeDetails_Code.Text, txtOfficeDetails_Name.Text, txtOfficeDetails_OfficeAddress.Text
                    , txtOfficeDetails_ContactNo.Text, chkOfficeDetails_Active.Checked, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save Office - Office ID: " + hfOfficeID.Value + "; Office Code: " + txtOfficeDetails_Code.Text + "; Office Name: " + txtOfficeDetails_Name.Text 
                    + "; Office Address: " + txtOfficeDetails_OfficeAddress.Text + "; ContactNo(s): " + txtOfficeDetails_ContactNo.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Office", "btnOfficeDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblOfficeDetails_Active.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Office", "btnOfficeDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_Office("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvOfficeList);

                MainButton(true, false);
                Clear();

                mvOffice.SetActiveView(vwViewOffice);
            }

            #endregion
        }

        protected void btnOfficeDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_Office("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvOfficeList);

            MainButton(true, false);
            Clear();

            mvOffice.SetActiveView(vwViewOffice);
        }

        protected void btnOfficeDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #region GridView Events

        protected void gvOfficeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvOfficeList.Rows[index];

                if (e.CommandName == "Select")
                {
                    hfOfficeID.Value = row.Cells[0].Text;
                    txtOfficeDetails_Code.Text = row.Cells[1].Text.Replace("&nbsp;", "");
                    txtOfficeDetails_Name.Text = row.Cells[2].Text.Replace("&nbsp;", "");
                    txtOfficeDetails_OfficeAddress.Text = row.Cells[3].Text.Replace("&nbsp;", "");
                    txtOfficeDetails_ContactNo.Text = row.Cells[4].Text.Replace("&nbsp;", "");
                    chkOfficeDetails_Active.Checked = _gc.Load_CheckBox(row.Cells[5].Text);

                    mvOffice.SetActiveView(vwDetailsOffice);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Office", "gvOfficeList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvOfficeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOfficeList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_Office(txtOfficeView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvOfficeList);
        }

        protected void gvOfficeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnOffice_Create.Visible = _btnCreate;
            btnOffice_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblOfficeDetails_NotifHeader.Text = _HeaderText;
            lblOfficeDetails_NotifBody.Text = _BodyText;

            btnOfficeDetails_SaveYes.Visible = _Save;
            btnOfficeDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfOfficeID.Value = "0";
            txtOfficeDetails_Code.Text = "";
            txtOfficeDetails_Name.Text = "";
            txtOfficeDetails_OfficeAddress.Text = "";
            txtOfficeDetails_ContactNo.Text = "";
            chkOfficeDetails_Active.Checked = true;

            lblOfficeDetails_Alert.Text = "";
        }

        #endregion
    }
}