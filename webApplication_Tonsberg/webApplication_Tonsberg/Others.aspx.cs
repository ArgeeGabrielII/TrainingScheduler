using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webApplication_Tonsberg.wcfService;

namespace webApplication_Tonsberg
{
    public partial class Others : System.Web.UI.Page
    {
        itWebServiceClient wcfService = new itWebServiceClient();
        _gControls _gc = new _gControls();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _gc.DeserializeDataTable(wcfService.Get_Gender("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvGenderList);

                    _gc.DeserializeDataTable(wcfService.Get_CivilStatus("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                        , gvCivilStatusList);

                    //_gc.DeserializeDataTable(wcfService.Get_IdentificationList("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    //    , gvIdentificationListList);

                    MainButtonGender(true, false);
                    MainButtonCivilStatus(true, false);
                    //MainButtonIdentificationList(true, false);

                    mvGender.SetActiveView(vwViewGender);
                    mvCivilStatus.SetActiveView(vwViewCivilStatus);
                    //mvIdentificationList.SetActiveView(vwViewIdentificationList);
                }
                else { }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Others", "Page_Load", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        #region Event(s)

        #region Gender

        protected void btnGender_Create_Click(object sender, EventArgs e)
        {
            mvGender.SetActiveView(vwDetailsGender);
            MainButtonGender(false, true);
            ClearGender();
        }

        protected void btnGender_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_Gender("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvGenderList);

            MainButtonGender(true, false);
            ClearGender();

            mvGender.SetActiveView(vwViewGender);
        }

        protected void lnkGenderView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_Gender(txtGenderView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvGenderList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Gender", "lnkGenderView_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void gvGenderList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvGenderList.PageSize;
                GridViewRow row = gvGenderList.Rows[index];

                if (e.CommandName == "Select")
                {
                    hfGenderID.Value = row.Cells[0].Text;
                    txtGenderDetails_Name.Text = row.Cells[1].Text.Replace("&nbsp;", "");

                    mvGender.SetActiveView(vwDetailsGender);
                    MainButtonGender(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Gender", "gvGenderList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvGenderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGenderList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_Gender("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvGenderList);
        }

        protected void gvGenderList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnGenderDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtGenderDetails_Name.Text != "")
            {
                NotificationModalGender(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
            }
            else { lblGenderDetails_Alert.Text = "Gender is a required field."; }
        }

        protected void btnGenderDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModalGender(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }

        protected void btnGenderDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModalGender(false, "", "", false, false);

                //Save Gender
                wcfService.Save_Gender(_gc.ToInt32(hfGenderID.Value), txtGenderDetails_Name.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save Gender - Gender ID: " + hfGenderID.Value + "; Gender: " + txtGenderDetails_Name.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Gender", "btnGenderDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblGenderDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "Gender", "btnGenderDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_Gender("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvGenderList);

                MainButtonGender(true, false);
                ClearGender();

                mvGender.SetActiveView(vwViewGender);
            }

            #endregion
        }

        protected void btnGenderDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModalGender(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_Gender("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvGenderList);

            MainButtonGender(true, false);
            ClearGender();

            mvGender.SetActiveView(vwViewGender);
        }

        protected void btnGenderDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModalGender(false, "", "", false, false);
        }

        #endregion

        #region CivilStatus

        protected void btnCivilStatus_Create_Click(object sender, EventArgs e)
        {
            mvCivilStatus.SetActiveView(vwDetailsCivilStatus);
            MainButtonCivilStatus(false, true);
            ClearCivilStatus();
        }

        protected void btnCivilStatus_Back_Click(object sender, EventArgs e)
        {
            _gc.DeserializeDataTable(wcfService.Get_CivilStatus("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCivilStatusList);

            MainButtonCivilStatus(true, false);
            ClearCivilStatus();

            mvCivilStatus.SetActiveView(vwViewCivilStatus);
        }

        protected void lnkCivilStatusView_Search_Click(object sender, EventArgs e)
        {
            try
            {
                _gc.DeserializeDataTable(wcfService.Get_CivilStatus(txtCivilStatusView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvCivilStatusList);
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "CivilStatus", "lnkCivilStatusView_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
                Response.Redirect("Login.aspx");
            }
        }

        protected void gvCivilStatusList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument) % gvCivilStatusList.PageSize;
                GridViewRow row = gvCivilStatusList.Rows[index];

                if (e.CommandName == "Select")
                {
                    hfCivilStatusID.Value = row.Cells[0].Text;
                    txtCivilStatusDetails_Name.Text = row.Cells[1].Text.Replace("&nbsp;", "");

                    mvCivilStatus.SetActiveView(vwDetailsCivilStatus);
                    MainButtonCivilStatus(false, true);
                }
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "CivilStatus", "gvCivilStatusList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
        }

        protected void gvCivilStatusList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCivilStatusList.PageIndex = e.NewPageIndex;
            _gc.DeserializeDataTable(wcfService.Get_CivilStatus("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCivilStatusList);
        }

        protected void gvCivilStatusList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnCivilStatusDetails_Submit_Click(object sender, EventArgs e)
        {
            if (txtCivilStatusDetails_Name.Text != "")
            {
                NotificationModalCivilStatus(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
            }
            else { lblCivilStatusDetails_Alert.Text = "CivilStatus is a required field."; }
        }

        protected void btnCivilStatusDetails_Cancel_Click(object sender, EventArgs e)
        {
            NotificationModalCivilStatus(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        }

        protected void btnCivilStatusDetails_SaveYes_Click(object sender, EventArgs e)
        {
            #region Save

            try
            {
                NotificationModalCivilStatus(false, "", "", false, false);

                //Save CivilStatus
                wcfService.Save_CivilStatus(_gc.ToInt32(hfCivilStatusID.Value), txtCivilStatusDetails_Name.Text
                    , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

                //Save Transaction History
                string _TransType = "";
                int _UID = 0;

                _TransType = "Save CivilStatus - CivilStatus ID: " + hfCivilStatusID.Value + "; CivilStatus: " + txtCivilStatusDetails_Name.Text;

                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "CivilStatus", "btnCivilStatusDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

                lblCivilStatusDetails_Alert.Text = "";
            }
            catch (Exception ex)
            {
                int _UID = 0;
                if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

                wcfService.Save_TransactionHistory(_UID, "CivilStatus", "btnCivilStatusDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Successfully Saved!');", true);

                _gc.DeserializeDataTable(wcfService.Get_CivilStatus("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                    , gvCivilStatusList);

                MainButtonCivilStatus(true, false);
                ClearCivilStatus();

                mvCivilStatus.SetActiveView(vwViewCivilStatus);
            }

            #endregion
        }

        protected void btnCivilStatusDetails_CancelYes_Click(object sender, EventArgs e)
        {
            NotificationModalCivilStatus(false, "", "", false, false);

            _gc.DeserializeDataTable(wcfService.Get_CivilStatus("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
                , gvCivilStatusList);

            MainButtonCivilStatus(true, false);
            ClearCivilStatus();

            mvCivilStatus.SetActiveView(vwViewCivilStatus);
        }

        protected void btnCivilStatusDetails_No_Click(object sender, EventArgs e)
        {
            NotificationModalCivilStatus(false, "", "", false, false);
        }
        
        #endregion

        //#region IdentificationList

        //protected void btnIdentificationList_Create_Click(object sender, EventArgs e)
        //{
        //    mvIdentificationList.SetActiveView(vwDetailsIdentificationList);
        //    MainButtonIdentificationList(false, true);
        //    ClearIdentificationList();
        //}

        //protected void btnIdentificationList_Back_Click(object sender, EventArgs e)
        //{
        //    _gc.DeserializeDataTable(wcfService.Get_IdentificationList("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
        //        , gvIdentificationListList);

        //    MainButtonIdentificationList(true, false);
        //    ClearIdentificationList();

        //    mvIdentificationList.SetActiveView(vwViewIdentificationList);
        //}

        //protected void lnkIdentificationListView_Search_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        _gc.DeserializeDataTable(wcfService.Get_IdentificationList(txtIdentificationListView_Search.Text, _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
        //            , gvIdentificationListList);
        //    }
        //    catch (Exception ex)
        //    {
        //        int _UID = 0;
        //        if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

        //        wcfService.Save_TransactionHistory(_UID, "IdentificationList", "lnkIdentificationListView_Search_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
        //        Response.Redirect("Login.aspx");
        //    }
        //}

        //protected void gvIdentificationListList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        int index = Convert.ToInt32(e.CommandArgument) % gvIdentificationListList.PageSize;
        //        GridViewRow row = gvIdentificationListList.Rows[index];

        //        if (e.CommandName == "Select")
        //        {
        //            hfIdentificationListID.Value = row.Cells[0].Text;
        //            txtIdentificationListDetails_Name.Text = row.Cells[1].Text.Replace("&nbsp;", "");

        //            mvIdentificationList.SetActiveView(vwDetailsIdentificationList);
        //            MainButtonIdentificationList(false, true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        int _UID = 0;
        //        if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

        //        wcfService.Save_TransactionHistory(_UID, "IdentificationList", "gvIdentificationListList_RowCommand", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
        //    }
        //}

        //protected void gvIdentificationListList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvIdentificationListList.PageIndex = e.NewPageIndex;
        //    _gc.DeserializeDataTable(wcfService.Get_IdentificationList("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
        //        , gvIdentificationListList);
        //}

        //protected void gvIdentificationListList_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //protected void btnIdentificationListDetails_Submit_Click(object sender, EventArgs e)
        //{
        //    if (txtIdentificationListDetails_Name.Text != "")
        //    {
        //        NotificationModalIdentificationList(true, "Confirmation to Save", "Are you sure you want to save this transaction?", true, false);
        //    }
        //    else { lblIdentificationListDetails_Alert.Text = "IdentificationList is a required field."; }
        //}

        //protected void btnIdentificationListDetails_Cancel_Click(object sender, EventArgs e)
        //{
        //    NotificationModalIdentificationList(true, "Confirmation to Cancel", "Are you sure you want to cancel this transaction?", false, true);
        //}

        //protected void btnIdentificationListDetails_SaveYes_Click(object sender, EventArgs e)
        //{
        //    #region Save

        //    try
        //    {
        //        NotificationModalIdentificationList(false, "", "", false, false);

        //        //Save IdentificationList
        //        wcfService.Save_IdentificationList(_gc.ToInt32(hfIdentificationListID.Value), txtIdentificationListDetails_Name.Text
        //            , _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"]);

        //        //Save Transaction History
        //        string _TransType = "";
        //        int _UID = 0;

        //        _TransType = "Save IdentificationList - IdentificationList ID: " + hfIdentificationListID.Value + "; IdentificationList: " + txtIdentificationListDetails_Name.Text;

        //        if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

        //        wcfService.Save_TransactionHistory(_UID, "IdentificationList", "btnIdentificationListDetails_SaveYes_Click", "", _TransType, _gc.localComputerName, _gc.GetIPAddress());

        //        lblIdentificationListDetails_Alert.Text = "";
        //    }
        //    catch (Exception ex)
        //    {
        //        int _UID = 0;
        //        if (!string.IsNullOrEmpty(Session["UserID"] as string)) { _UID = _gc.ToInt32(_Cypher.Decrypt(Session["UserID"].ToString(), _Cypher._PassPhrase)); }

        //        wcfService.Save_TransactionHistory(_UID, "IdentificationList", "btnIdentificationListDetails_SaveYes_Click", ex.ToString(), "", _gc.localComputerName, _gc.GetIPAddress());
        //    }
        //    finally
        //    {
        //        _gc.DeserializeDataTable(wcfService.Get_IdentificationList("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
        //            , gvIdentificationListList);

        //        MainButtonIdentificationList(true, false);
        //        ClearIdentificationList();

        //        mvIdentificationList.SetActiveView(vwViewIdentificationList);
        //    }

        //    #endregion
        //}

        //protected void btnIdentificationListDetails_CancelYes_Click(object sender, EventArgs e)
        //{
        //    NotificationModalIdentificationList(false, "", "", false, false);

        //    _gc.DeserializeDataTable(wcfService.Get_IdentificationList("", _gc.ToInt32(_Cypher.Decrypt((string)Session["UserID"], _Cypher._PassPhrase)), (string)Session["tID"])
        //        , gvIdentificationListList);

        //    MainButtonIdentificationList(true, false);
        //    ClearIdentificationList();

        //    mvIdentificationList.SetActiveView(vwViewIdentificationList);
        //}

        //protected void btnIdentificationListDetails_No_Click(object sender, EventArgs e)
        //{
        //    NotificationModalIdentificationList(false, "", "", false, false);
        //}

        //#endregion

        #endregion

        #region Property(ies)

        #region Gender

        private void MainButtonGender(bool _btnCreate, bool _btnBack)
        {
            btnGender_Create.Visible = _btnCreate;
            btnGender_Back.Visible = _btnBack;
        }

        private void NotificationModalGender(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification_Gender.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification_Gender.Attributes.Add("class", "modal displayHide"); }

            lblGenderDetails_NotifHeader.Text = _HeaderText;
            lblGenderDetails_NotifBody.Text = _BodyText;

            btnGenderDetails_SaveYes.Visible = _Save;
            btnGenderDetails_CancelYes.Visible = _Cancel;
        }

        private void ClearGender()
        {
            hfGenderID.Value = "0";
            txtGenderDetails_Name.Text = "";

            lblGenderDetails_Alert.Text = "";
        }

        #endregion

        #region CivilStatus

        private void MainButtonCivilStatus(bool _btnCreate, bool _btnBack)
        {
            btnCivilStatus_Create.Visible = _btnCreate;
            btnCivilStatus_Back.Visible = _btnBack;
        }

        private void NotificationModalCivilStatus(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        {
            if (_ShowHide) { modalNotification_CivilStatus.Attributes.Add("class", "modal displayShow"); }
            else { modalNotification_CivilStatus.Attributes.Add("class", "modal displayHide"); }

            lblCivilStatusDetails_NotifHeader.Text = _HeaderText;
            lblCivilStatusDetails_NotifBody.Text = _BodyText;

            btnCivilStatusDetails_SaveYes.Visible = _Save;
            btnCivilStatusDetails_CancelYes.Visible = _Cancel;
        }

        private void ClearCivilStatus()
        {
            hfCivilStatusID.Value = "0";
            txtCivilStatusDetails_Name.Text = "";

            lblCivilStatusDetails_Alert.Text = "";
        }

        #endregion

        //#region IdentificationList

        //private void MainButtonIdentificationList(bool _btnCreate, bool _btnBack)
        //{
        //    btnIdentificationList_Create.Visible = _btnCreate;
        //    btnIdentificationList_Back.Visible = _btnBack;
        //}

        //private void NotificationModalIdentificationList(bool _ShowHide, string _HeaderText, string _BodyText, bool _Save, bool _Cancel)
        //{
        //    if (_ShowHide) { modalNotification_IdentificationList.Attributes.Add("class", "modal displayShow"); }
        //    else { modalNotification_IdentificationList.Attributes.Add("class", "modal displayHide"); }

        //    lblIdentificationListDetails_NotifHeader.Text = _HeaderText;
        //    lblIdentificationListDetails_NotifBody.Text = _BodyText;

        //    btnIdentificationListDetails_SaveYes.Visible = _Save;
        //    btnIdentificationListDetails_CancelYes.Visible = _Cancel;
        //}

        //private void ClearIdentificationList()
        //{
        //    hfIdentificationListID.Value = "0";
        //    txtIdentificationListDetails_Name.Text = "";

        //    lblIdentificationListDetails_Alert.Text = "";
        //}

        //#endregion

        #endregion
    }
}