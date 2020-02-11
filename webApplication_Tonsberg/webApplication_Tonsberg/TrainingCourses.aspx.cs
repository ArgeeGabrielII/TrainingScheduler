using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class TrainingCourses : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvTrainingList);

                    MainButton(true, false);

                    mvCourses.SetActiveView(vwViewCourses);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TrainingCourses", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        #region Event(s)

        protected void btnTrainingCourses_Create_Click(object sender, EventArgs e)
        {
            mvCourses.SetActiveView(vwDetailsTraining);
            MainButton(false, true);
            Clear();
        }

        protected void btnTrainingCourses_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvTrainingList);

            MainButton(true, false);
            Clear();

            mvCourses.SetActiveView(vwViewCourses);
        }

        protected void lnkCoursesView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTrainingList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TrainingCourses", "lnkCoursesView_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnTrainingDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtTrainingDetails_CourseCode.Text != "")
            {
                if (txtTrainingDetails_CourseName.Text != "")
                {
                    if (txtTrainingDetails_NameOfTrainor.Text != "")
                    {
                        if (txtTrainingDetails_NoOfTrainees.Text != "")
                        {
                            if (txtTrainingDetails_TrainingDuration.Text != "")
                            {
                                if (txtTrainingDetails_TrainingStartDate.Text != "")
                                {
                                    if (txtTrainingDetails_TrainingFee.Text != "")
                                    {
                                        NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
                                    }
                                    else { lblTrainingDetails_Alert.Text = "Training Fee is a required field."; }
                                }
                                else { lblTrainingDetails_Alert.Text = "Start Date is a required field."; }
                            }
                            else { lblTrainingDetails_Alert.Text = "Training Duration is a required field."; }
                        }
                        else { lblTrainingDetails_Alert.Text = "No of Trainees is a required field."; }
                    }
                    else { lblTrainingDetails_Alert.Text = "Name of Trainor is a required field."; }
                }
                else { lblTrainingDetails_Alert.Text = "Course Name is a required field."; }
            }
            else { lblTrainingDetails_Alert.Text = "Course Code is a required field."; }
        }

        protected void btnTrainingDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }

        protected void btnTrainingDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                //Save Training Courses
                wcfService.Save_TrainingCourses(_gc.ToInt32(hfTrainingID.Value), txtTrainingDetails_CourseCode.Text, txtTrainingDetails_CourseName.Text, txtTrainingDetails_NameOfTrainor.Text
                    , _gc.ToInt32(txtTrainingDetails_NoOfTrainees.Text), _gc.ToInt32(txtTrainingDetails_TrainingDuration.Text), txtTrainingDetails_TrainingStartDate.Text, chkTrainingDetails_Active.Checked
                    , _gc.ToDecimal(txtTrainingDetails_TrainingFee.Text), txtTrainingDetails_Assessor.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save TrainingCourses - Course ID: " + hfTrainingID.Value + "; CourseCode: " + txtTrainingDetails_CourseCode.Text + "; CourseName: "
                    + txtTrainingDetails_CourseName.Text + "; NameOfTrainor: " + txtTrainingDetails_NameOfTrainor.Text + "; NoOfTrainees: " + txtTrainingDetails_NoOfTrainees.Text
                    + "; TrainingDuration: " + txtTrainingDetails_TrainingDuration.Text + "; StartDate: " + txtTrainingDetails_TrainingStartDate.Text + "; Active: "
                    + chkTrainingDetails_Active.Checked.ToString() + "; TrainingFee: " + txtTrainingDetails_TrainingFee.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TrainingCourses", "btnTrainingDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblTrainingDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TrainingCourses", "btnTrainingDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvTrainingList);

                MainButton(true, false);
                Clear();

                mvCourses.SetActiveView(vwViewCourses);
            }

            #endregion
        }

        protected void btnTrainingDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvTrainingList);

            MainButton(true, false);
            Clear();

            mvCourses.SetActiveView(vwViewCourses);
        }

        protected void btnTrainingDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }


        protected void lnkRegisteredTrainees_Search_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region GridView Event(s)

        protected void gvTrainingList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvTrainingList.PageSize;
                GridViewRow row = gvTrainingList.Rows[index];

                if (e.CommandName == "Select")
                {
                    hfTrainingID.Value = row.Cells[0].Text;
                    txtTrainingDetails_CourseCode.Text = row.Cells[1].Text;
                    txtTrainingDetails_CourseName.Text = row.Cells[2].Text;
                    txtTrainingDetails_NameOfTrainor.Text = row.Cells[3].Text;
                    txtTrainingDetails_NoOfTrainees.Text = row.Cells[4].Text;
                    txtTrainingDetails_TrainingDuration.Text = row.Cells[6].Text;
                    txtTrainingDetails_TrainingStartDate.Text = (Convert.ToDateTime(row.Cells[7].Text)).ToString("yyyy-MM-dd");
                    chkTrainingDetails_Active.Checked = _gc.ToBoolean(row.Cells[8].Text);
                    txtTrainingDetails_TrainingFee.Text = row.Cells[9].Text;
                    txtTrainingDetails_Assessor.Text = row.Cells[10].Text;

                    lblRegisteredTrainees_TotalEnrollees.Text = "View Enrolled Trainees: " + row.Cells[5].Text + "/" + row.Cells[4].Text;

                    _gc.DeserializeDataTable(wcfService.Get_EnrolledTrainee(row.Cells[0].Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvRegisteredTrainees);

                    mvCourses.SetActiveView(vwDetailsTraining);
                    MainButton(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "TrainingCourse", "gvTrainingList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvTrainingList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTrainingList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvTrainingList);
        }

        protected void gvTrainingList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void gvRegisteredTrainees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRegisteredTrainees.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_EnrolledTrainee(hfTrainingID.Value, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvRegisteredTrainees);
        }

        protected void gvRegisteredTrainees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Property(ies)

        private void MainButton(bool _btnCreate, bool _btnBack)
        {
            btnTrainingCourses_Create.Visible = _btnCreate;
            btnTrainingCourses_Back.Visible = _btnBack;
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblTrainingDetails_NotifHeader.Text = _HeaderText;
            lblTrainingDetails_NotifBody.Text = _BodyText;

            btnTrainingDetails_SaveYes.Visible = _Save;
            btnTrainingDetails_CancelYes.Visible = _Cancel;
        }

        private void Clear()
        {
            hfTrainingID.Value = "0";
            txtTrainingDetails_CourseCode.Text = "";
            txtTrainingDetails_CourseName.Text = "";
            chkTrainingDetails_Active.Checked = true;

            txtTrainingDetails_NameOfTrainor.Text = "";
            txtTrainingDetails_NoOfTrainees.Text = "0";
            txtTrainingDetails_TrainingDuration.Text = "1";

            txtTrainingDetails_TrainingStartDate.Text = "";

            lblRegisteredTrainees_TotalEnrollees.Text = "View Enrolled Trainees: 0/0";

            lblTrainingDetails_Alert.Text = "";
        }

        #endregion


    }
}