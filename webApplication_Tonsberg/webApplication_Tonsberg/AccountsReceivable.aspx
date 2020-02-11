<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="AccountsReceivable.aspx.cs" Inherits="webApplication_Tonsberg.AccountsReceivable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Accounts Receivable - TITCI System
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
    <!-- DataTables CSS -->
    <link href="assets/vendor/datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />
    <!-- DataTables Responsive CSS -->
    <link href="assets/vendor/datatables-responsive/dataTables.responsive.css" rel="stylesheet" />
    <!-- Personal CSS -->
    <link href="assets/extra.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BodyContent" runat="server">
    <br />
    <asp:MultiView ID="mvAccountsReceivable" runat="server">
        <asp:View ID="vwViewCourseList" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home">Home</a></li>
                        <li>Accounts Receivable</li>
                    </ul>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Courses</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtCourseListView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkCourseListView_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                OnClick="lnkCourseListView_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvCourseList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                PageSize="20" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvCourseList_RowCommand" OnSelectedIndexChanged="gvCourseList_SelectedIndexChanged"
                                OnPageIndexChanging="gvCourseList_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="CourseID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                                    <asp:BoundField DataField="TrainorName" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="NoOfTrainees" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="EnrolledTrainees" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="AvailableSlot" HeaderText="Available Slot" />
                                    <asp:BoundField DataField="TrainingDuration" HeaderText="Training Duration (Day)" />
                                    <asp:BoundField DataField="TrainingStartDate" HeaderText="Training Start Date" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />
                                    <asp:BoundField DataField="TrainingFee" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />

                                    <asp:TemplateField ItemStyle-Width="5%" ShowHeader="False" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CausesValidation="false" CommandName="Select" CssClass="btn btn-primary" title="Select"
                                                CommandArgument='<%# Container.DataItemIndex %>' data-rel="tooltip"><i class="glyphicon glyphicon-th-list"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no inputted courses.
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vwViewTraineeList" runat="server">
            <div class="row">
                <div class="col-md-10">
                    <ul class="breadcrumb">
                        <li><a href="Home">Home</a></li>
                        <li>Accounts Receivable</li>
                    </ul>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnTraineeListView_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnTraineeListView_Back_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <h3>
                        <asp:Label ID="Label1" runat="server" Text="Course Detail" /></h3>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblTraineeListView_CourseCode" runat="server" Text="Course Code:" />
                </div>
                <div class="col-md-4">
                    <b>
                        <asp:Label ID="lblTraineeListView_CourseCode_Value" runat="server" /></b>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lblTraineeListView_CourseName" runat="server" Text="Course Name:" />
                </div>
                <div class="col-md-4">
                    <b>
                        <asp:Label ID="lblTraineeListView_CourseName_Value" runat="server" /></b>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblTraineeListView_TrainerName" runat="server" Text="Trainer Name:" />
                </div>
                <div class="col-md-4">
                    <b>
                        <asp:Label ID="lblTraineeListView_TrainerName_Value" runat="server" /></b>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lblTraineeListView_TrainingStartDate" runat="server" Text="Training Start Date:" />
                </div>
                <div class="col-md-4">
                    <b>
                        <asp:Label ID="lblTraineeListView_TrainingStartDate_Value" runat="server" /></b>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblTraineeListView_TrainingFee" runat="server" Text="Training Fee (Php):" />
                </div>
                <div class="col-md-4">
                    <b>
                        <asp:Label ID="lblTraineeListView_TrainingFee_Value" runat="server" /></b>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-12">
                                    <h4>View Trainees</h4>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvTraineeList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                PageSize="50" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvTraineeList_RowCommand" OnSelectedIndexChanged="gvTraineeList_SelectedIndexChanged"
                                OnPageIndexChanging="gvTraineeList_PageIndexChanging" OnRowDataBound="gvTraineeList_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="RegistrationID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="TraineeID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                    <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="GenderID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="CivilStatusID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                    <asp:BoundField DataField="DateOfBirth" HeaderText="Date of Birth" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="Age" HeaderText="Age" />
                                    <asp:BoundField DataField="PlaceOfBirth" HeaderText="Place of Birth" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />
                                    <asp:BoundField DataField="PositionRank" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="YearsOfSeaExperience" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="MarinaLicense" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="PRCLicense" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="SIRBNo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="PassportNo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="SRCNo" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="Others" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <%--<asp:BoundField DataField="EnrollmentDate" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />--%>
                                    <asp:BoundField DataField="TotalPayment" HeaderText="Total Payment" />

                                    <asp:TemplateField ItemStyle-Width="5%" ShowHeader="False" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CausesValidation="false" CommandName="Select" CssClass="btn btn-primary" title="Select"
                                                CommandArgument='<%# Container.DataItemIndex %>' data-rel="tooltip"><i class="glyphicon glyphicon-th-list"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no enrolled trainees.
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vwAccountsPayableDetails" runat="server">
            <asp:HiddenField ID="hfRegistrationID" runat="server" />
            <asp:HiddenField ID="hfCourseID" runat="server" />
            <asp:HiddenField ID="hfTraineeID" runat="server" />
            <div class="row">
                <div class="col-md-10">
                    <ul class="breadcrumb">
                        <li><a href="Home">Home</a></li>
                        <li>Accounts Receivable</li>
                    </ul>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnAccountsPayableListView_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnAccountsPayableListView_Back_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <b>Course Detail</b>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_CourseCode" runat="server" Text="Course Code:" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_CourseCode_Value" runat="server" /></b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_CourseName" runat="server" Text="Course Name:" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_CourseName_Value" runat="server" /></b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_TrainerName" runat="server" Text="Trainer Name:" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_TrainerName_Value" runat="server" /></b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_TrainingStartDate" runat="server" Text="Training Start Date:" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_TrainingStartDate_Value" runat="server" /></b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_TrainingFee" runat="server" Text="Training Fee (Php):" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_TrainingFee_Value" runat="server" CssClass="AlertRed" /></b>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <b>Trainee Detail</b>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_TraineeID" runat="server" Text="TraineeID:" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_TraineeID_Value" runat="server" /></b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_TraineeName" runat="server" Text="Trainee Name:" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_TraineeName_Value" runat="server" /></b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_ContactNo" runat="server" Text="ContactNo:" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_ContactNo_Value" runat="server" /></b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_BirthDate" runat="server" Text="Date Of Birth (Age):" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_BirthDate_Value" runat="server" /></b>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblAccountsPayableList_PlaceOfBirth" runat="server" Text="Place Of Birth:" />
                                </div>
                                <div class="col-md-8">
                                    <b>
                                        <asp:Label ID="lblAccountsPayableList_PlaceOfBirth_Value" runat="server" /></b>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <b>Transaction Payments</b>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:Label ID="lblTransactionType" Text="Transaction Type" runat="server" CssClass="rField" />
                                    <asp:DropDownList ID="ddlTransactionType" runat="server" CssClass="form-control" 
                                        OnSelectedIndexChanged="ddlTransactionType_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="0" Text="Select" />
                                        <asp:ListItem Value="InitialPayment" Text="Initial Payment" />
                                        <asp:ListItem Value="SucceedingPayment" Text="Succeeding Payment" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lblTransaction_Date" Text="Transaction Date" runat="server" />
                                    <asp:TextBox ID="txtTransaction_Date" runat="server" CssClass="form-control" Enabled="false" TextMode="Date" placeholder="mm/dd/yyyy" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-md-4" id="divDiscountReferral" runat="server">
                                    <asp:Label ID="lblTransaction_Discount" Text="Discount/Referral" runat="server" />
                                    <asp:TextBox ID="txtTransaction_Discount" runat="server" CssClass="form-control" placeholder="Php #,###.##" 
                                        OnTextChanged="txtTransaction_Discount_TextChanged" AutoPostBack="true" />
                                </div>
                                <div class="col-md-4">
                                    <asp:HiddenField ID="hfTransaction_AccountBalance" runat="server" Visible="false" />
                                    <asp:Label ID="lblTransaction_AccountBalance" Text="Account Balance" runat="server" />
                                    <asp:TextBox ID="txtTransaction_AccountBalance" runat="server" CssClass="form-control" Enabled="false" placeholder="Php #,###.##" />
                                </div>
                                <div class="col-md-4">
                                    <asp:Label ID="lblTransaction_AmountPaid" Text="Amount Paid" runat="server" CssClass="rField" />
                                    <asp:TextBox ID="txtTransaction_AmountPaid" runat="server" CssClass="form-control" TextMode="Number" step="0.01" placeholder="Php #,###.##" />
                                </div>
                            </div>

                            <br /><br />
                            <asp:Label ID="lblTransaction_Alert" runat="server" CssClass="AlertRed" />
                            <br /><br />
                            <div class="row">
                                <div class="col-md-2">
                                    <asp:Button ID="btnTransaction_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnTransaction_Submit_Click" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnTransaction_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnTransaction_Cancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <b>Transaction History</b>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvAccountReceivableHistory" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                PageSize="20" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnSelectedIndexChanged="gvAccountReceivableHistory_SelectedIndexChanged"
                                OnPageIndexChanging="gvAccountReceivableHistory_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="RegistrationID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="TraineeID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="CourseID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                                    <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:d}"  />
                                    <asp:BoundField DataField="AmountPaid" HeaderText="Amount Paid" />
                                    <asp:BoundField DataField="PaymentDetails" HeaderText="Payment Details" />
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no payments made.
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <!-- modalNotification -->
            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblNotification_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblNotification_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnNotification_BackYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnNotification_BackYes_Click" />
                            <asp:Button ID="btnNotification_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnNotification_SaveYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnNotification_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnNotification_No_Click" />
                        </div>
                    </div>
                    <br />
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
