using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class UserProfile : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string _jsonResponse = wcfService.Get_UserAccount(_Cypher.Decrypt((string)Session["UserName"], _Cypher._PassPhrase)
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                if (_jsonResponse != "")
                {
                    dynamic _jData = JsonConvert.DeserializeObject<dynamic>(_jsonResponse);

                    hfUserID.Value = (string)_jData[0].UserID;
                    txtUADetails_UserName.Text = (string)_jData[0].UserName;
                    txtUADetails_FirstName.Text = (string)_jData[0].FirstName;
                    txtUADetails_LastName.Text = (string)_jData[0].LastName;
                    txtUADetails_EmailAddress.Text = (string)_jData[0].EmailAddress;
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserProfile", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void btnUADetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtUADetails_Password1.Text == txtUADetails_Password2.Text)
            {
                NotificationModal(true, "Confirmation to Save", "Are you sure you want to update your password?", true, false);
            }
            else { lblUADetails_Alert.Text = "Your password does not match."; }
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

                //Save User Profile
                wcfService.Save_UserProfile(_gc.ToInt32(hfUserID.Value), txtUADetails_Password1.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction Logs
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save User Profile - Username: " + txtUADetails_UserName.Text + "; Name: " + txtUADetails_FirstName.Text + " " + txtUADetails_LastName.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserProfile", "btnUADetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblUADetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "UserProfile", "btnUADetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);
                Response.Redirect("Home.aspx"); }

            #endregion
        }

        protected void btnUADetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
            Response.Redirect("Home.aspx");
        }

        protected void btnUADetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
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
    }
}