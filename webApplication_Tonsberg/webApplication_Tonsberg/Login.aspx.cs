using System;
using System.Web.UI;
using Newtonsoft.Json;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class Login : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtLogin_Username.Text = "";
                txtLogin_Password.Text = "";

                Session.Clear();
                txtLogin_Username.Focus();
                lblLogin_Alert.Text = "";
            }
        }

        protected void btnLogin_Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string _jsonResponseUserAccount = wcfService.GetUserPass(txtLogin_Username.Text, txtLogin_Password.Text);

                if (_jsonResponseUserAccount != "")
                {
                    dynamic _jData = JsonConvert.DeserializeObject<dynamic>(_jsonResponseUserAccount);

                    if ((bool)_jData[0].Active == true)
                    {
                        lblLogin_Alert.Text = "Login Successful!";

                        //Sessions and Token
                        Session["UserID"] = _Cypher.Encrypt((string)_jData[0].UserID, _Cypher._PassPhrase);
                        Session["UserName"] = _Cypher.Encrypt((string)_jData[0].UserName, _Cypher._PassPhrase);
                        Session["ClientName"] = _Cypher.Encrypt((string)_jData[0].FirstName + " " + (string)_jData[0].LastName, _Cypher._PassPhrase);
                        Session["GroupID"] = _Cypher.Encrypt((string)_jData[0].GroupID, _Cypher._PassPhrase);
                        Session["DepartmentID"] = _Cypher.Encrypt((string)_jData[0].DepartmentID, _Cypher._PassPhrase);
                        Session["Office"] = _Cypher.Encrypt((string)_jData[0].Office, _Cypher._PassPhrase);
                        Session["tID"] = (string)_jData[0].Token;


                        //Save Transaction Logs
                        string _TransType = "";

                        _TransType = "Login Success: UserID: " + (string)_jData[0].UserID + "; UserName: " + txtLogin_Username.Text + "; Name: " + (string)_jData[0].FirstName + " " + (string)_jData[0].LastName + "; GroupID: "
                            + (string)_jData[0].GroupID + "; DepartmentID: " + (string)_jData[0].DepartmentID + "; Office: " + (string)_jData[0].Office;

                        wcfService.Save_TransactionHistory((int)_jData[0].UserID, "Login", "btnLogin_Submit_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                        //User Access Rights
                        UserAccessRights(_gc.ToInt32((string)_jData[0].GroupID));

                        //Page Redirect to Home
                        Response.AddHeader("REFRESH", "0.2;URL=Home.aspx");
                    }
                    else { lblLogin_Alert.Text = "Account is Inactive!<br />Please contact your System Administrator"; }
                }
                else { lblLogin_Alert.Text = "Invalid Username or Password"; }
            }
            catch (Exception ex)
            {
                wcfService.Save_TransactionHistory(0, "Login", "btnLogin_Submit_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void UserAccessRights(int _gID)
        {
            //User Access Rights
            string _jsonResponseUserAccessRights = wcfService.Get_UserAccessRights(_gID);

            if (_jsonResponseUserAccessRights != "")
            {
                dynamic _jData = JsonConvert.DeserializeObject<dynamic>(_jsonResponseUserAccessRights);

                foreach (var _data in _jData)
                {
                    Session["CV_" + (string)_data.ModuleName] = (string)_data.CanView;
                    Session["CE_" + (string)_data.ModuleName] = (string)_data.CanEdit;
                    Session["CD_" + (string)_data.ModuleName] = (string)_data.CanDelete;
                }
            }
        }
    }
}