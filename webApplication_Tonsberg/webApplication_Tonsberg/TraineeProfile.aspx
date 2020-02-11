<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="TraineeProfile.aspx.cs" Inherits="webApplication_Tonsberg.TraineeProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Trainee Profile - TITCI System
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
    <div class="row">
        <div class="col-md-10">
            <ul class="breadcrumb">
                <li><a href="Home">Home</a></li>
                <li>Trainee Profile</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnTraineeProfile_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnTraineeProfile_Create_Click" />
            <asp:Button ID="btnTraineeProfile_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnTraineeProfile_Back_Click" />
        </div>
    </div>

    <asp:MultiView ID="mvTraineeProfile" runat="server">
        <asp:View ID="vwViewTraineeProfile" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Trainee Profile</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtTraineeProfileView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkTraineeProfileView_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                OnClick="lnkTraineeProfileView_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvTraineeProfileList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvTraineeProfileList_RowCommand" OnPageIndexChanging="gvTraineeProfileList_PageIndexChanging"
                                OnSelectedIndexChanged="gvTraineeProfileList_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="10%" ShowHeader="False" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CausesValidation="false" CommandName="Select" CssClass="btn btn-primary" title="View Trainee"
                                                CommandArgument='<%# Container.DataItemIndex %>' data-rel="tooltip"><i class="glyphicon glyphicon-th-list"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TraineeID" HeaderText="Trainee ID" />
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
                                    <asp:BoundField DataField="EnrollmentDate" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                </Columns>
                                <EmptyDataTemplate>
                                    No data found.
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vwDetailsTraineeProfile" runat="server">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel-body">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                            <li id="liTraineeProfile" runat="server" class="active"><a href="#TraineeProfile" data-toggle="tab"><center>Trainee Profile</center></a></li>
                            <li id="liTrainingHistory" runat="server"><a href="#TrainingRecord" data-toggle="tab"><center>Training Record</center></a></li>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div class="tab-pane fade active in" id="TraineeProfile">
                                <asp:HiddenField ID="hfTraineeProfileID" runat="server" Visible="false" />
                                <h2>Personal Information</h2>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTraineeProfileDetails_TraineeID" runat="server" Text="Trainee ID" />
                                        <asp:TextBox ID="txtTraineeProfileDetails_TraineeID" runat="server" CssClass="form-control" placeholder="Trainee ID [YYYYMM######]" Enabled="false" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTraineeProfileDetails_EnrollmentDate" runat="server" Text="Enrollment Date" />
                                        <asp:TextBox ID="txtTraineeProfileDetails_EnrollmentDate" runat="server" CssClass="form-control" Enabled="false" TextMode="Date" />
                                    </div>
                                    <div class="col-md-4 chkPaddingTop">
                                        <asp:CheckBox ID="chkTraineeProfileDetails_Active" runat="server" Checked="true" />
                                        <asp:Label ID="lblTraineeProfileDetails_Active" runat="server" Text="Active" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_FirstName" runat="server" Text="First Name" class="rField" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_FirstName" runat="server" CssClass="form-control" placeholder="First Name" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_MiddleName" runat="server" Text="Middle Name" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_MiddleName" runat="server" CssClass="form-control" placeholder="Middle Name" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_LastName" runat="server" Text="Last Name" class="rField" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_LastName" runat="server" CssClass="form-control" placeholder="Last Name" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_Gender" runat="server" Text="Gender" class="rField" />
                                        <asp:DropDownList ID="ddlTrainerProfileDetails_Gender" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_CivilStatus" runat="server" Text="Civil Status" class="rField" />
                                        <asp:DropDownList ID="ddlTrainerProfileDetails_CivilStatus" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_ContactNo" runat="server" Text="Contact No" class="rField" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_ContactNo" runat="server" CssClass="form-control" placeholder="Mobile/Telephone No." />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_DateOfBirth" runat="server" Text="Date Of Birth" class="rField" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_DateOfBirth" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="true" 
                                            OnTextChanged="txtTrainerProfileDetails_DateOfBirth_TextChanged" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_Age" runat="server" Text="Age" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_Age" runat="server" CssClass="form-control" placeholder="Age" Enabled="false" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_PlaceOfBirth" runat="server" Text="Place of Birth" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_PlaceOfBirth" runat="server" CssClass="form-control" placeholder="Place of Birth" />
                                    </div>
                                </div>
                                <br /><hr />
                                <h2>Employment Information</h2>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_PositionRank" runat="server" Text="Position / Rank" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_PositionRank" runat="server" CssClass="form-control" placeholder="Position/Rank" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_SeaExperience" runat="server" Text="Year(s) of Sea Experience" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_SeaExperience" runat="server" CssClass="form-control" TextMode="Number" placeholder="0" />
                                    </div>
                                </div>
                                <br />
                                <h4>Valid ID Presented</h4>
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_MarinaLicense" runat="server" Text="Marina License" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_MarinaLicense" runat="server" CssClass="form-control" placeholder="Marina License" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_PRCLicense" runat="server" Text="PRC License" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_PRCLicense" runat="server" CssClass="form-control" placeholder="PRC License" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_SIRBNo" runat="server" Text="SIRB No." />
                                        <asp:TextBox ID="txtTrainerProfileDetails_SIRBNo" runat="server" CssClass="form-control" placeholder="SIRB No." />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_PassportNo" runat="server" Text="Passport No." />
                                        <asp:TextBox ID="txtTrainerProfileDetails_PassportNo" runat="server" CssClass="form-control" placeholder="Passport No." />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_SRCNo" runat="server" Text="SRC No." />
                                        <asp:TextBox ID="txtTrainerProfileDetails_SRCNo" runat="server" CssClass="form-control" placeholder="SRC No." />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTrainerProfileDetails_Others" runat="server" Text="Others" />
                                        <asp:TextBox ID="txtTrainerProfileDetails_Others" runat="server" CssClass="form-control" placeholder="Others" TextMode="MultiLine" />
                                    </div>
                                </div>

                                <br /><br />
                                <asp:Label ID="lblTraineeProfileDetails_Alert" runat="server" CssClass="AlertRed" />
                                <br /><br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Button ID="btnTraineeProfileDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnTraineeProfileDetails_Submit_Click" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnTraineeProfileDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnTraineeProfileDetails_Cancel_Click" />
                                    </div>
                                </div>

                                <div id="modalNotification" runat="server" class="modal">
                                    <div class="modal-content">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><h3><asp:Label ID="lblTraineeProfileDetails_NotifHeader" runat="server" /></h3></center>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><asp:Label ID="lblTraineeProfileDetails_NotifBody" runat="server" /></center>
                                            </div>
                                        </div>
                                        <br /><br /><br />
                                        <div class="row">
                                            <div class="col-md-7"></div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnTraineeProfileDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnTraineeProfileDetails_SaveYes_Click" />
                                                <asp:Button ID="btnTraineeProfileDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnTraineeProfileDetails_CancelYes_Click" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnTraineeProfileDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnTraineeProfileDetails_No_Click" />
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="TrainingRecord">
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <b>Training History</b>
                                            </div>
                                            <div class="panel-body" style="overflow-x: scroll">
                                                <asp:GridView runat="server" ID="gvTrainingHistory" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                    PageSize="20" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnSelectedIndexChanged="gvTrainingHistory_SelectedIndexChanged"
                                                    OnPageIndexChanging="gvTrainingHistory_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="CourseID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                        <asp:BoundField DataField="CourseCode" HeaderText="Course Code" />
                                                        <asp:BoundField DataField="CourseName" HeaderText="Course Name" />
                                                        <asp:BoundField DataField="TrainorName" HeaderText="Trainor Name"  />
                                                        <asp:BoundField DataField="TrainingStartDate" HeaderText="Training Start Date" />
                                                        <asp:BoundField DataField="TrainingDuration" HeaderText="Training Duration" />
                                                        <asp:BoundField DataField="TrainingFee" HeaderText="Training Fee" />
                                                        <asp:BoundField DataField="TotalPayment" HeaderText="Total Payment" />
                                                        <asp:BoundField DataField="DropTrainee" HeaderText="Drop Trainee" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        There are no enrolled trainings.
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>