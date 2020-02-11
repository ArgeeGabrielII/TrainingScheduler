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
    public partial class AccountsReceivable : System.Web.UI.Page
    {
        #region Declaration(s)

        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvCourseList);

                    mvAccountsReceivable.SetActiveView(vwViewCourseList);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "AccountsReceivable", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        #region Course List

        protected void lnkCourseListView_Search_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses(txtCourseListView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCourseList);
        }

        protected void btnTraineeListView_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCourseList);

            ClearHiddenField();

            mvAccountsReceivable.SetActiveView(vwViewCourseList);
        }
        
        protected void gvCourseList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvCourseList.PageSize;
                GridViewRow row = gvCourseList.Rows[index];

                if (e.CommandName == "Select")
                {
                    hfCourseID.Value = row.Cells[0].Text;

                    lblTraineeListView_CourseCode_Value.Text = row.Cells[1].Text;
                    lblTraineeListView_CourseName_Value.Text = row.Cells[2].Text;
                    lblTraineeListView_TrainerName_Value.Text = row.Cells[3].Text;
                    lblTraineeListView_TrainingStartDate_Value.Text = row.Cells[8].Text;
                    lblTraineeListView_TrainingFee_Value.Text = row.Cells[10].Text;

                    _gc.DeserializeDataTable(wcfService.Get_EnrolledTrainee(row.Cells[0].Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvTraineeList);

                    mvAccountsReceivable.SetActiveView(vwViewTraineeList);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "ViewCourseList", "gvCourseList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvCourseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        #endregion

        #region Trainee List

        protected void gvTraineeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvTraineeList.PageSize;
                GridViewRow row = gvTraineeList.Rows[index];

                if (e.CommandName == "Select")
                {
                    hfRegistrationID.Value = row.Cells[0].Text;
                    hfTraineeID.Value = row.Cells[1].Text;
                    hfTransaction_AccountBalance.Value = "0";

                    lblAccountsPayableList_CourseCode_Value.Text = lblTraineeListView_CourseCode_Value.Text;
                    lblAccountsPayableList_CourseName_Value.Text = lblTraineeListView_CourseName_Value.Text;
                    lblAccountsPayableList_TrainerName_Value.Text = lblTraineeListView_TrainerName_Value.Text;
                    lblAccountsPayableList_TrainingStartDate_Value.Text = lblTraineeListView_TrainingStartDate_Value.Text;
                    lblAccountsPayableList_TrainingFee_Value.Text = lblTraineeListView_TrainingFee_Value.Text;

                    lblAccountsPayableList_TraineeID_Value.Text = row.Cells[1].Text;
                    lblAccountsPayableList_TraineeName_Value.Text = row.Cells[4].Text + ", " + row.Cells[2].Text;
                    lblAccountsPayableList_ContactNo_Value.Text = row.Cells[7].Text;
                    lblAccountsPayableList_BirthDate_Value.Text = row.Cells[8].Text + " (" + row.Cells[9].Text + ")";
                    lblAccountsPayableList_PlaceOfBirth_Value.Text = row.Cells[10].Text;
                    
                    //Set Initialization
                    txtTransaction_Date.Text = DateTime.Today.ToString("yyyy-MM-dd"); //Get Date Today
                    divDiscountReferral.Visible = false; //Set Discount Hidden (Select - 0)

                    //Get Balance from DB
                    string _jResponse = wcfService.Get_TotalAmountPaid(_gc.ToInt32(hfCourseID.Value), hfTraineeID.Value, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]);

                    if (_jResponse != "")
                    {
                        dynamic _jData = JsonConvert.DeserializeObject<dynamic>(_jResponse);
                        txtTransaction_AccountBalance.Text = (_gc.ToDecimal(lblTraineeListView_TrainingFee_Value.Text) - (decimal)_jData[0].TotalAmountPaid).ToString();
                        ddlTransactionType.SelectedValue = "SucceedingPayment";
                    }
                    else {
                        txtTransaction_AccountBalance.Text = lblTraineeListView_TrainingFee_Value.Text;
                        ddlTransactionType.SelectedValue = "0";
                    }

                    _gc.DeserializeDataTable(wcfService.Get_AccountsReceivableHistory(_gc.ToInt32(hfCourseID.Value), hfTraineeID.Value, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                        , (string)Session["tID"]), gvAccountReceivableHistory);

                    lblTransaction_Alert.Text = "";
                    NotificationModal(false, "", "", false, false);
                    mvAccountsReceivable.SetActiveView(vwAccountsPayableDetails);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "AccountsPayableList", "gvTraineeList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvTraineeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvTraineeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvTraineeList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string _AmountPaid = e.Row.Cells[20].Text.Replace("&nbsp;", "0");

                if (_gc.ToDecimal(_AmountPaid) == _gc.ToDecimal(lblTraineeListView_TrainingFee_Value.Text))
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                }
                else if ((_gc.ToDecimal(_AmountPaid) < _gc.ToDecimal(lblTraineeListView_TrainingFee_Value.Text))
                    && (_gc.ToDecimal(_AmountPaid) > _gc.ToDecimal("0")))
                {
                    e.Row.BackColor = System.Drawing.Color.Gold;
                }
                else if (_gc.ToDecimal(_AmountPaid) <= _gc.ToDecimal("0"))
                {
                    e.Row.BackColor = System.Drawing.Color.Bisque;
                }
            }
        }

        #endregion

        #region Accounts Receivable Transactions

        protected void btnAccountsPayableListView_Back_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Return", "Are you sure you want to cancel this transaction?", true, false);
        }

        protected void ddlTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTransactionType.SelectedIndex == 1) { divDiscountReferral.Visible = true; }
            else { divDiscountReferral.Visible = false; txtTransaction_Discount.Text = "0"; }
        }

        protected void txtTransaction_Discount_TextChanged(object sender, EventArgs e)
        {
            decimal _netBalance = 0;

            if (hfTransaction_AccountBalance.Value == "0") { hfTransaction_AccountBalance.Value = txtTransaction_AccountBalance.Text; }
            
            _netBalance = _gc.ToDecimal(hfTransaction_AccountBalance.Value) - _gc.ToDecimal(txtTransaction_Discount.Text);

            if (_netBalance <= _gc.ToDecimal("0")) { lblTransaction_Alert.Text = "Discount CANNOT be greater than Training Fee."; }
            else { txtTransaction_AccountBalance.Text = _netBalance.ToString(); lblTransaction_Alert.Text = ""; }
        }

        protected void gvAccountReceivableHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvAccountReceivableHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAccountReceivableHistory.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_AccountsReceivableHistory(_gc.ToInt32(hfCourseID.Value), hfTraineeID.Value, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase))
                , (string)Session["tID"]), gvAccountReceivableHistory);
        }

        protected void btnTransaction_Submit_Click(object sender, EventArgs e)
        {
            if (ddlTransactionType.SelectedValue != "0")
            {
                if (txtTransaction_AmountPaid.Text != "")
                {
                    NotificationModal(true, "Confirmation to Save", "Are you sure you want to save this transaction?", false, true);
                }
                else { lblTransaction_Alert.Text = "Please input the AMOUNT PAID by the trainee."; }
            }
            else { lblTransaction_Alert.Text = "Please select a Transaction Type."; }
        }

        protected void btnTransaction_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModal(true, "Confirmation to Return", "Are you sure you want to cancel this transaction?", true, false);
        }

        protected void btnNotification_BackYes_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCourseList);

            ClearHiddenField();
            mvAccountsReceivable.SetActiveView(vwViewCourseList);
        }

        protected void btnNotification_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModal(false, "", "", false, false);

                if (txtTransaction_Discount.Text != "0" && txtTransaction_Discount.Text != "")
                {
                    wcfService.Save_Payments(_gc.ToInt32(hfRegistrationID.Value), _gc.ToDecimal(txtTransaction_Discount.Text), "Discount / Referral"
                        , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);
                }

                wcfService.Save_Payments(_gc.ToInt32(hfRegistrationID.Value), _gc.ToDecimal(txtTransaction_AmountPaid.Text), ddlTransactionType.SelectedItem.Text
                        , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                int _UID = 0;
                string _TransType = "Save DropTrainee - TraineeID: ";
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "DropTrainee", "btnViewForDroppingList_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblTransaction_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "AccountsReceivable", "btnNotification_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_TrainingCourses("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCourseList);

                ClearHiddenField();
                mvAccountsReceivable.SetActiveView(vwViewCourseList);
            }

            #endregion
        }

        protected void btnNotification_No_Click(object sender, EventArgs e)
        {
            NotificationModal(false, "", "", false, false);
        }

        #endregion

        #region Property(ies)

        private void ClearHiddenField()
        {
            hfRegistrationID.Value = "0";
            hfCourseID.Value = "0";
            hfTraineeID.Value = "0";
            hfTransaction_AccountBalance.Value = "0";

            txtTransaction_Discount.Text = "0";
            txtTransaction_AmountPaid.Text = "";
        }

        private void NotificationModal(bool _ShowHide, string _HeaderText, string _BodyText, bool _BackYes, bool _SaveYes)
        {
            if (_ShowHide) { modalNotification.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification.Attributes.Add("class", "modal displayHide"); }

            lblNotification_NotifHeader.Text = _HeaderText;
            lblNotification_NotifBody.Text = _BodyText;

            btnNotification_BackYes.Visible = _BackYes;
            btnNotification_SaveYes.Visible = _SaveYes;
        }

        #endregion
    }
}