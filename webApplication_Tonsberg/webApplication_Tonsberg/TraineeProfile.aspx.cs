using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class TraineeProfile : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_TraineeProfile("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvTraineeProfileList);

                    _gc.DeserializeDropDownList(wcfService.Get_Gender("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "GenderName", "GenderID", ddlTrainerProfileDetails_Gender);
                    _gc.DeserializeDropDownList(wcfService.Get_CivilStatus("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "CivilStatusName", "CivilStatusID", ddlTrainerProfileDetails_CivilStatus);

                    MainButton(true, false);
                    mvTraineeProfile.SetActiveView(vwViewTraineeProfile);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TraineeProfile", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        #region Event(s)

        protected void btnTraineeProfile_Create_Click(object sender, EventArgs e)
        {
            MainButton(false, true);
            Clear();

            mvTraineeProfile.SetActiveView(vwDetailsTraineeProfile);
        }

        protected void btnTraineeProfile_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_TraineeProfile("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvTraineeProfileList);

            MainButton(true, false);
            Clear();

            mvTraineeProfile.SetActiveView(vwViewTraineeProfile);
        }

        protected void lnkTraineeProfileView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_TraineeProfile(txtTraineeProfileView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvTraineeProfileList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TraineeProfileView", "lnkTraineeProfileView_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void txtTrainerProfileDetails_DateOfBirth_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dob = Convert.ToDateTime(txtTrainerProfileDetails_DateOfBirth.Text);
                DateTime today = DateTime.Now;

                txtTrainerProfileDetails_Age.Text = AgeInYears(dob, today);
            }
            catch { txtTrainerProfileDetails_Age.Text = "0"; }
        }

        protected void btnTraineeProfileDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtTrainerProfileDetails_FirstName.Text != "")
            {
                if (txtTrainerProfileDetails_LastName.Text != "")
                {
                    if (ddlTrainerProfileDetails_Gender.SelectedValue != "0")
                    {
                        if (ddlTrainerProfileDetails_CivilStatus.SelectedValue != "0")
                        {
                            if (txtTrainerProfileDetails_ContactNo.Text != "")
                            {
                                if (txtTrainerProfileDetails_DateOfBirth.Text != "")
                                {
                                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                                }
                                else { lblTraineeProfileDetails_Alert.Text = "Date of Birth is a required field."; }
                            }
                            else { lblTraineeProfileDetails_Alert.Text = "ContactNo is a required field."; }
                        }
                        else { lblTraineeProfileDetails_Alert.Text = "Please select a Civil Status"; }
                    }
                    else { lblTraineeProfileDetails_Alert.Text = "Please select a Gender"; }
                }
                else { lblTraineeProfileDetails_Alert.Text = "First Name is a required field."; }
            }
            else { lblTraineeProfileDetails_Alert.Text = "Last Code is a required field."; }
        }

        protected void btnTraineeProfileDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }

        protected void btnTraineeProfileDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save TraineeProfile
                wcfService.Save_TraineeProfile(hfTraineeProfileID.Value, txtTrainerProfileDetails_FirstName.Text, txtTrainerProfileDetails_MiddleName.Text
                    , txtTrainerProfileDetails_LastName.Text, _gc.ToInt32(ddlTrainerProfileDetails_Gender.SelectedValue), _gc.ToInt32(ddlTrainerProfileDetails_CivilStatus.SelectedValue)
                    , txtTrainerProfileDetails_ContactNo.Text, txtTrainerProfileDetails_DateOfBirth.Text, _gc.ToInt32(txtTrainerProfileDetails_Age.Text), txtTrainerProfileDetails_PlaceOfBirth.Text
                    , chkTraineeProfileDetails_Active.Checked, txtTrainerProfileDetails_PositionRank.Text, _gc.ToInt32(txtTrainerProfileDetails_SeaExperience.Text), txtTrainerProfileDetails_MarinaLicense.Text
                    , txtTrainerProfileDetails_PRCLicense.Text, txtTrainerProfileDetails_SIRBNo.Text, txtTrainerProfileDetails_PassportNo.Text, txtTrainerProfileDetails_SRCNo.Text
                    , txtTrainerProfileDetails_Others.Text, txtTraineeProfileDetails_EnrollmentDate.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save Trainee Profile - Name: " + txtTrainerProfileDetails_FirstName.Text + " " + txtTrainerProfileDetails_MiddleName.Text + " "
                    + txtTrainerProfileDetails_LastName.Text + "; Gender: " + ddlTrainerProfileDetails_Gender.SelectedItem.Text + "; CivilStatus: " + ddlTrainerProfileDetails_CivilStatus.SelectedItem.Text
                    + "; ContactNo: " + txtTrainerProfileDetails_ContactNo.Text + "; DateOfBirth: " + txtTrainerProfileDetails_DateOfBirth.Text + "; PlaceOfBirth: " + txtTrainerProfileDetails_PlaceOfBirth.Text
                    + "; Position/Rank: " + txtTrainerProfileDetails_PositionRank.Text + "; YearOfSeaExperience: " + txtTrainerProfileDetails_SeaExperience.Text + "; MarinaLicense: "
                    + txtTrainerProfileDetails_MarinaLicense.Text + "; PRCLicense: " + txtTrainerProfileDetails_PRCLicense.Text + "; SIRBNo: " + txtTrainerProfileDetails_SIRBNo.Text
                    + "; PassportNo: " + txtTrainerProfileDetails_PassportNo.Text + "; SRCNo.: " + txtTrainerProfileDetails_SRCNo.Text + "; Others: " + txtTrainerProfileDetails_Others.Text
                    + "EnrollmentDate: " + txtTraineeProfileDetails_EnrollmentDate.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TraineeProfile", "btnTraineeProfileDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblTraineeProfileDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TraineeProfile", "btnTraineeProfileDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_TraineeProfile("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTraineeProfileList);

                MainButton(true, false);
                Clear();

                mvTraineeProfile.SetActiveView(vwViewTraineeProfile);
            }

            #endregion
        }

        protected void btnTraineeProfileDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_TraineeProfile("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvTraineeProfileList);

            MainButton(true, false);
            Clear();

            mvTraineeProfile.SetActiveView(vwViewTraineeProfile);
        }

        protected void btnTraineeProfileDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #endregion

        #region GridView Event(s)

        protected void gvTraineeProfileList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvTraineeProfileList.PageSize;
                GridViewRow row = gvTraineeProfileList.Rows[index];

                if (e.CommandName == "Select")
                {
                    #region Select

                    hfTraineeProfileID.Value = row.Cells[1].Text;
                    txtTraineeProfileDetails_TraineeID.Text = row.Cells[1].Text;
                    txtTrainerProfileDetails_FirstName.Text = row.Cells[2].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_MiddleName.Text = row.Cells[3].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_LastName.Text = row.Cells[4].Text.Replace("&nbsp;", "");
                    ddlTrainerProfileDetails_Gender.SelectedValue = row.Cells[5].Text.Replace("&nbsp;", "");
                    ddlTrainerProfileDetails_CivilStatus.SelectedValue = row.Cells[6].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_ContactNo.Text = row.Cells[7].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_DateOfBirth.Text = (Convert.ToDateTime(row.Cells[8].Text.Replace("&nbsp;", ""))).ToString("yyyy-MM-dd");
                    txtTrainerProfileDetails_Age.Text = row.Cells[9].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_PlaceOfBirth.Text = row.Cells[10].Text.Replace("&nbsp;", "");
                    chkTraineeProfileDetails_Active.Checked = _gc.Load_CheckBox(row.Cells[11].Text);
                    txtTrainerProfileDetails_PositionRank.Text = row.Cells[12].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_SeaExperience.Text = row.Cells[13].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_MarinaLicense.Text = row.Cells[14].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_PRCLicense.Text = row.Cells[15].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_SIRBNo.Text = row.Cells[16].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_PassportNo.Text = row.Cells[17].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_SRCNo.Text = row.Cells[18].Text.Replace("&nbsp;", "");
                    txtTrainerProfileDetails_Others.Text = row.Cells[19].Text.Replace("&nbsp;", "");
                    txtTraineeProfileDetails_EnrollmentDate.Text = (Convert.ToDateTime(row.Cells[20].Text.Replace("&nbsp;", ""))).ToString("yyyy-MM-dd");

                    _gc.DeserializeDataTable(wcfService.Get_TraineeAccountsReceivable(row.Cells[1].Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvTrainingHistory);

                    mvTraineeProfile.SetActiveView(vwDetailsTraineeProfile);
                    MainButton(false, true);

                    #endregion
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TraineeProfile", "gvTraineeProfileList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvTraineeProfileList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTraineeProfileList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_TraineeProfile(txtTraineeProfileView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvTraineeProfileList);
        }

        protected void gvTraineeProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvTrainingHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvTrainingHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnTraineeProfile_Create.Visible = _btnCreate;
            btnTraineeProfile_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblTraineeProfileDetails_NotifHeader.Text = _HeaderText;
            lblTraineeProfileDetails_NotifBody.Text = _BodyText;

            btnTraineeProfileDetails_SaveYes.Visible = _Save;
            btnTraineeProfileDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfTraineeProfileID.Value = "0";

            txtTraineeProfileDetails_TraineeID.Text = "";
            chkTraineeProfileDetails_Active.Checked = true;
            txtTraineeProfileDetails_EnrollmentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtTrainerProfileDetails_FirstName.Text = "";
            txtTrainerProfileDetails_MiddleName.Text = "";
            txtTrainerProfileDetails_LastName.Text = ""; 
            ddlTrainerProfileDetails_Gender.SelectedIndex = 0;
            ddlTrainerProfileDetails_CivilStatus.SelectedIndex = 0;
            txtTrainerProfileDetails_ContactNo.Text = "";
            txtTrainerProfileDetails_DateOfBirth.Text = "";
            txtTrainerProfileDetails_Age.Text = "0";
            txtTrainerProfileDetails_PlaceOfBirth.Text = "";

            txtTrainerProfileDetails_PositionRank.Text = "";
            txtTrainerProfileDetails_SeaExperience.Text = "";
            txtTrainerProfileDetails_MarinaLicense.Text = "";
            txtTrainerProfileDetails_PRCLicense.Text = "";
            txtTrainerProfileDetails_SIRBNo.Text = "";
            txtTrainerProfileDetails_PassportNo.Text = "";
            txtTrainerProfileDetails_SRCNo.Text = "";
            txtTrainerProfileDetails_Others.Text = "";
        }

        static string AgeInYears(DateTime birthday, DateTime today)
        {
            try
            {
                return (((today.Year - birthday.Year) * 372 + (today.Month - birthday.Month) * 31 + (today.Day - birthday.Day)) / 372).ToString();
            }
            catch (Exception) { return "0"; }
        }

        #endregion
    }
}