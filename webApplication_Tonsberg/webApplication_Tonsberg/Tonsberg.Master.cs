using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class Tonsberg : System.Web.UI.MasterPage
    {
        string _ClientName;
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Get UserAccount FullName
                if (!string.IsNullOrEmpty(Session["tID"] as string) && !string.IsNullOrEmpty(Session["ClientName"] as string))
                {
                    _ClientName = _Cypher.Decrypt(Session["ClientName"].ToString(), _Cypher._PassPhrase);
                    lblUserAccount_Name.Text = "Hello! " + _ClientName;

                    //User Access Rights
                    ViewRights(Session["CV_TraineeProfile"].ToString(), liTraineeProfile);
                    ViewRights(Session["CV_TrainingRegistration"].ToString(), liTrainingRegistration);
                    ViewRights(Session["CV_AccountsReceivable"].ToString(), liAccountsReceivable);
                    ViewRights(Session["CV_UserAccounts"].ToString(), liAdministrator);
                    ViewRights(Session["CV_UserAccounts"].ToString(), liHistoryLogs);
                }
                else { Response.Redirect("Login.aspx"); }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "FMS.Master", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void ViewRights(string _Session, HtmlGenericControl _control)
        {
            if ((string)_Session == "True") { _control.Visible = true; } else { _control.Visible = false; }
        }
    }
}