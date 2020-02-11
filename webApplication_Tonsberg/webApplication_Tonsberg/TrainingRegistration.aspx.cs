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
    public partial class Training_Registration : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_AvailableCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvAvailableCourses);
                    _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvAllCourses);

                    _gc.DeserializeDropDownList(wcfService.Get_TraineeList(_gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , "TraineeName", "TraineeID", ddlRegistrationDetails_TraineeName);

                    ClearTraineeRegistration();

                    mvTrainingRegistration.SetActiveView(vwViewTrainingRegistrationList);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TrainingRegistration", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        #region GridView Available Courses

        protected void lnkAvailableCourses_Search_Click(object sender, EventArgs e)
        {

        }


        protected void gvAvailableCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvAvailableCourses.PageSize;
                GridViewRow row = gvAvailableCourses.Rows[index];

                if (e.CommandName == "Enroll")
                {
                    txtRegistrationDetails_DateRegistered.Text = DateTime.Today.ToString("yyyy-MM-dd");

                    hfCourseID.Value = row.Cells[0].Text;
                    lblRegistrationDetails_RegistrationID.Text = "0";
                    txtRegistrationDetails_CourseCode.Text = row.Cells[1].Text;
                    txtRegistrationDetails_CourseName.Text = row.Cells[2].Text;
                    txtRegistrationDetails_TrainingStartDate.Text = (Convert.ToDateTime(row.Cells[8].Text)).ToString("yyyy-MM-dd");
                    txtRegistrationDetails_AvailableSlot.Text = row.Cells[6].Text;
                    txtRegistrationDetails_TrainingFee.Text = row.Cells[10].Text;

                    _gc.DeserializeDataTable(wcfService.Get_EnrolledTrainee(row.Cells[0].Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvEnrolleeList);

                    mvTrainingRegistration.SetActiveView(vwDetailTrainingRegistration);
                }
                else if (e.CommandName == "Drop")
                {
                    hfDropCourseID.Value = row.Cells[0].Text;

                    _gc.DeserializeDataTable(wcfService.Get_EnrolledTrainee(row.Cells[0].Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvForDroppingList);

                    mvTrainingRegistration.SetActiveView(vwDetailDropTraining);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TrainingRegistration", "gvAvailableCourses_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvAvailableCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAvailableCourses.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_AvailableCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvAvailableCourses);
        }

        protected void gvAvailableCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvAvailableCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int _AvailSlot = ((Convert.ToInt32(e.Row.Cells[4].Text) / 4) * 3);

                if (Convert.ToInt32(e.Row.Cells[5].Text) >= _AvailSlot)
                {
                    e.Row.BackColor = System.Drawing.Color.Yellow;
                }
            }
        }

        #endregion

        #region GridView All Courses

        protected void lnkAllCourses_Search_Click(object sender, EventArgs e)
        {

        }


        protected void gvAllCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvAllCourses.PageSize;
                GridViewRow row = gvAllCourses.Rows[index];

                if (e.CommandName == "View")
                {
                    _gc.DeserializeDataTable(wcfService.Get_EnrolledTrainee(row.Cells[0].Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvViewTraineeList);

                    Notification_Modal_ViewTrainees(true, "View Enrolled Trainees");
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "AllCourses", "gvAllCourses_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvAllCourses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAllCourses.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvAllCourses);
        }

        protected void gvAllCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvAllCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == e.Row.Cells[5].Text)
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                else if (Convert.ToDateTime(e.Row.Cells[8].Text) < DateTime.Today.Date)
                {
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                }
                else if (Convert.ToDateTime(e.Row.Cells[8].Text) == DateTime.Today.Date)
                {
                    e.Row.BackColor = System.Drawing.Color.Gold;
                }
            }
        }


        //protected void lnkViewTraineeList_Search_Click(object sender, EventArgs e)
        //{

        //}

        protected void gvViewTraineeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvViewTraineeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnViewCourseList_Close_Click(object sender, EventArgs e)
        {
            Notification_Modal_ViewTrainees(false, "");
        }

        #endregion

        #region View Course Detail
        
        
        
        #endregion

        #region Trainee Registration

        protected void btnTraineeRegistration_Back_Click(object sender, EventArgs e)
        {
            NotificationModal_Registration(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", true, false);
        }

        protected void lnkEnrolleeList_Search_Click(object sender, EventArgs e)
        {

        }


        protected void ddlRegistrationDetails_TraineeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRegistrationDetails_TraineeName.SelectedIndex != 0)
            {
                string _jsonResponseUserAccount = wcfService.Get_TraineeProfile(ddlRegistrationDetails_TraineeName.SelectedValue, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                    , (string)Session["tID"]);

                if (_jsonResponseUserAccount != "")
                {
                    dynamic _jData = JsonConvert.DeserializeObject<dynamic>(_jsonResponseUserAccount);

                    hfTraineeID.Value = ddlRegistrationDetails_TraineeName.SelectedValue;
                    txtRegistrationDetails_ContactNo.Text = (string)_jData[0].ContactNo;
                    txtRegistrationDetails_DateOfBirth.Text = ((DateTime)_jData[0].DateOfBirth).ToString("yyyy-MM-dd");
                    txtRegistrationDetails_PlaceOfBirth.Text = (string)_jData[0].PlaceOfBirth;
                }
            }
            else
            {
                hfTraineeID.Value = "0";
                txtRegistrationDetails_ContactNo.Text = "";
                txtRegistrationDetails_DateOfBirth.Text = "";
            }
        }

        protected void btnRegistrationDetails_Submit_Click(object sender, EventArgs e)
        {
            if (ddlRegistrationDetails_TraineeName.SelectedIndex != 0)
            {
                NotificationModal_Registration(true, "Confirmation to Save", "Are you sure you want to register: " + ddlRegistrationDetails_TraineeName.SelectedItem.Text, false, true);
            }
            else { lblRegistrationDetails_Alert.Text = "Trainee Name is a required field."; }
        }

        protected void btnRegistrationDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal_Registration(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", true, false);
        }


        protected void btnTraineeRegistrationDetails_BackYes_Click(object sender, EventArgs e)
        {
            NotificationModal_Registration(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_AvailableCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvAvailableCourses);
            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvAllCourses);

            ClearTraineeRegistration();

            mvTrainingRegistration.SetActiveView(vwViewTrainingRegistrationList);
        }

        protected void btnTraineeRegistrationDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal_Registration(false, "", "", false, false);

                //Save Department
                wcfService.Save_TraineeRegistration(_gc.ToInt32(lblRegistrationDetails_RegistrationID.Text), txtRegistrationDetails_DateRegistered.Text, hfTraineeID.Value, _gc.ToInt32(hfCourseID.Value)
                    , txtRegistrationDetails_CourseCode.Text, false, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save TrainingRegistration - RegistrationID: " + lblRegistrationDetails_RegistrationID.Text + "; DateRegistered: " + txtRegistrationDetails_DateRegistered.Text
                    + "; CourseID: " + hfCourseID.Value + "; CourseCode: " + txtRegistrationDetails_CourseCode.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TraineeRegistration", "btnTraineeRegistrationDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblRegistrationDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TraineeRegistration", "btnTraineeRegistrationDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_AvailableCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvAvailableCourses);
                _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvAllCourses);

                ClearTraineeRegistration();

                mvTrainingRegistration.SetActiveView(vwViewTrainingRegistrationList);
            }

            #endregion
        }

        protected void btnTraineeRegistrationDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal_Registration(false, "", "", false, false);
        }

        #endregion

        #region Drop Trainee

        protected void btnDropTrainee_Back_Click(object sender, EventArgs e)
        {
            NotificationModal_Dropping(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", true, false);
        }

        protected void lnkDropTrainee_Search_Click(object sender, EventArgs e)
        {

        }


        protected void btnDropTrainee_Submit_Click(object sender, EventArgs e)
        {
            int _chkd = 0;

            foreach (GridViewRow row in gvForDroppingList.Rows)
            {
                CheckBox chk = row.Cells[0].FindControl("chkSelectLine") as CheckBox;
                
                if (chk != null && chk.Checked)
                {
                    _chkd += 1;
                }
            }

            if (_chkd > 0) { NotificationModal_Dropping(true, "Confirmation to Drop Trainee", "Are you sure you want to continue?", false, true); }
            else { lblDropTrainee_Alert.Text = "Please select a trainee to be dropped."; }
        }

        protected void btnDropTrainee_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal_Dropping(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", true, false);
        }


        protected void btnViewForDroppingList_BackYes_Click(object sender, EventArgs e)
        {
            NotificationModal_Dropping(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_AvailableCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvAvailableCourses);
            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvAllCourses);

            ClearTraineeDropping();

            mvTrainingRegistration.SetActiveView(vwViewTrainingRegistrationList);
        }

        protected void btnViewForDroppingList_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal_Registration(false, "", "", false, false);

                foreach (GridViewRow row in gvForDroppingList.Rows)
                {
                    CheckBox chk = row.Cells[0].FindControl("chkSelectLine") as CheckBox;

                    if (chk != null && chk.Checked)
                    {
                        wcfService.Save_DropTrainee(row.Cells[1].Text, _gc.ToInt32(hfDropCourseID.Value), _gc.ToInt32(row.Cells[12].Text), _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                        //Save Transaction History
                        string _TransType = "";
                        int _UID = 0;

                        _TransType = "Save DropTrainee - TraineeID: " + row.Cells[1].Text + "; CourseID: " + hfDropCourseID.Value;

                        if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                        wcfService.Save_TransactionHistory(_UID, "DropTrainee", "btnViewForDroppingList_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());
                    }
                }

                lblRegistrationDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "DropTrainee", "btnViewForDroppingList_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                _gc.DeserializeDataTable(wcfService.Get_AvailableCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvAvailableCourses);
                _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvAllCourses);

                ClearTraineeDropping();
                NotificationModal_Dropping(false, "", "", false, false);

                mvTrainingRegistration.SetActiveView(vwViewTrainingRegistrationList);
            }

            #endregion
        }

        protected void btnViewForDroppingList_No_Click(object sender, EventArgs e)
        {
            NotificationModal_Dropping(false, "", "", false, false);
        }
        
        #endregion

        #region Property(ies)

        private void ClearTraineeRegistration()
        {
            hfCourseID.Value = "0";
            hfTraineeID.Value = "0";
            txtRegistrationDetails_CourseCode.Text = "";
            txtRegistrationDetails_CourseName.Text = "";
            txtRegistrationDetails_TrainingStartDate.Text = "";
            txtRegistrationDetails_AvailableSlot.Text = "";

            ddlRegistrationDetails_TraineeName.SelectedIndex = 0;
            txtRegistrationDetails_ContactNo.Text = "";
            txtRegistrationDetails_DateOfBirth.Text = "";

            lblRegistrationDetails_Alert.Text = "";
        }

        private void ClearTraineeDropping()
        {
            foreach (GridViewRow row in gvForDroppingList.Rows)
            {
                CheckBox chk = row.Cells[0].FindControl("chkSelectLine") as CheckBox;

                if (chk != null && chk.Checked)
                {
                    chk.Checked = false;
                }
            }

            lblDropTrainee_Alert.Text = "";
        }

        private void NotificationModal_Registration(bool _ShowHide, string _HeaderText, string _BodyText, bool _BackYes, bool _SaveYes)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblTraineeRegistrationDetails_NotifHeader.Text = _HeaderText;
            lblTraineeRegistrationDetails_NotifBody.Text = _BodyText;

            btnTraineeRegistrationDetails_BackYes.Visible = _BackYes;
            btnTraineeRegistrationDetails_SaveYes.Visible = _SaveYes;
        }

        private void NotificationModal_Dropping(bool _ShowHide, string _HeaderText, string _BodyText, bool _BackYes, bool _SaveYes)
        {
            if (_ShowHide) { modalViewForDroppingList.Attributes.Add("class", "modal displayShow"); }
            else { modalViewForDroppingList.Attributes.Add("class", "modal displayHide"); }

            lblViewForDroppingList_NotifHeader.Text = _HeaderText;
            lblViewForDroppingList_NotifBody.Text = _BodyText;

            btnViewForDroppingList_BackYes.Visible = _BackYes;
            btnViewForDroppingList_SaveYes.Visible = _SaveYes;
        }

        private void Notification_Modal_ViewTrainees(bool _ShowHide, string _HeaderText)
        {
            if (_ShowHide) { modalViewTraineeList.Attributes.Add("class", "modal displayShow"); }
            else { modalViewTraineeList.Attributes.Add("class", "modal displayHide"); }

            lblViewTraineeList_NotifHeader.Text = _HeaderText;
        }
        
        #endregion
    }
}