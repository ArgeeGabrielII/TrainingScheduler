<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="TrainingRegistration.aspx.cs" Inherits="webApplication_Tonsberg.Training_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Training Registration - TITCI System
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
    <asp:MultiView ID="mvTrainingRegistration" runat="server">
        <asp:View ID="vwViewTrainingRegistrationList" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home">Home</a></li>
                        <li>Training Registration</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel-body">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                            <li id="liAvailableCourses" runat="server" class="active"><a href="#AvailableCourses" data-toggle="tab"><center>Available Courses</center></a></li>
                            <li id="liAllCourses" runat="server"><a href="#AllCourses" data-toggle="tab"><center>All Courses</center></a></li>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div class="tab-pane fade active in" id="AvailableCourses">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <h4>View Available Courses</h4>
                                                    </div>
                                                    <div class="col-md-4 col-md-offset-4">
                                                        <div class="form-group input-group mTop3-form-group">
                                                            <asp:TextBox ID="txtAvailableCourses_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                                            <span class="input-group-btn">
                                                                <asp:LinkButton ID="lnkAvailableCourses_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                                    OnClick="lnkAvailableCourses_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body" style="overflow-x: scroll">
                                                <asp:GridView runat="server" ID="gvAvailableCourses" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                                    PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvAvailableCourses_RowCommand" OnPageIndexChanging="gvAvailableCourses_PageIndexChanging"
                                                    OnSelectedIndexChanged="gvAvailableCourses_SelectedIndexChanged" OnRowDataBound="gvAvailableCourses_RowDataBound">
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

                                                        <asp:TemplateField ItemStyle-Width="10%" ShowHeader="False" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="lnkEnroll" CausesValidation="false" CommandName="Enroll" CssClass="btn btn-success" title="Enroll Trainee"
                                                                    CommandArgument='<%# Container.DataItemIndex %>' data-rel="tooltip"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                                                                <asp:LinkButton runat="server" ID="lnkDrop" CausesValidation="false" CommandName="Drop" CssClass="btn btn-warning" title="Drop Trainee"
                                                                    CommandArgument='<%# Container.DataItemIndex %>' data-rel="tooltip"><i class="glyphicon glyphicon-share"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No data found.
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="AllCourses">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <h4>All Courses</h4>
                                                    </div>
                                                    <div class="col-md-4 col-md-offset-4">
                                                        <div class="form-group input-group mTop3-form-group">
                                                            <asp:TextBox ID="txtAllCourses_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                                            <span class="input-group-btn">
                                                                <asp:LinkButton ID="lnkAllCourses_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                                    OnClick="lnkAllCourses_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body" style="overflow-x: scroll">
                                                <asp:GridView runat="server" ID="gvAllCourses" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                                    PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvAllCourses_RowCommand" OnPageIndexChanging="gvAllCourses_PageIndexChanging"
                                                    OnSelectedIndexChanged="gvAllCourses_SelectedIndexChanged" OnRowDataBound="gvAllCourses_RowDataBound">
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

                                                        <asp:TemplateField ItemStyle-Width="10%" ShowHeader="False" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="lnkView" CausesValidation="false" CommandName="View" CssClass="btn btn-success" title="View Course"
                                                                    CommandArgument='<%# Container.DataItemIndex %>' data-rel="tooltip"><i class="glyphicon glyphicon-eye-open"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        No data found.
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- modalNotification -->
                            <div id="modalViewTraineeList" runat="server" class="modal">
                                <div class="modal-content">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <center><h3><asp:Label ID="lblViewTraineeList_NotifHeader" runat="server" /></h3></center>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-offset-1 col-md-10">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <h4>Enrolled Trainee List</h4>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-body" style="overflow-x: scroll">
                                                    <asp:GridView runat="server" ID="gvViewTraineeList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                                        PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnPageIndexChanging="gvViewTraineeList_PageIndexChanging" 
                                                        OnSelectedIndexChanged="gvViewTraineeList_SelectedIndexChanged">
                                                        <Columns>
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
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            There are no enrolled trainees.
                                                        </EmptyDataTemplate>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <br /><br /><br />
                                    <div class="row">
                                        <div class="col-md-9"></div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnViewCourseList_Close" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Close" OnClick="btnViewCourseList_Close_Click" />
                                        </div>
                                    </div>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="vwDetailTrainingRegistration" runat="server">
            <div class="row">
                <div class="col-md-10">
                    <ul class="breadcrumb">
                        <li><a href="Home">Home</a></li>
                        <li>Training Registration</li>
                    </ul>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnTraineeRegistration_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnTraineeRegistration_Back_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel-body">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs">
                            <li id="liTraineeRegistration" runat="server" class="active"><a href="#TraineeRegistration" data-toggle="tab"><center>Trainee Registration</center></a></li>
                            <li id="liEnrolledTrainee" runat="server"><a href="#EnrolledTrainee" data-toggle="tab"><center>Enrolled Trainee</center></a></li>
                        </ul>
                        <br />
                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div class="tab-pane fade active in" id="TraineeRegistration">
                                <asp:HiddenField ID="hfCourseID" runat="server" Visible="false" />
                                <asp:HiddenField ID="hfTraineeID" runat="server" Visible="false" />
                                
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <b>Trainee Details [Registration]: <asp:Label ID="lblRegistrationDetails_RegistrationID" runat="server" Text="Registration ID" /></b>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_DateRegistered" runat="server" Text="Date Registered [MMDDYYYY]" />
                                                        <asp:TextBox ID="txtRegistrationDetails_DateRegistered" runat="server" CssClass="form-control" TextMode="Date" Enabled="false" placeholder="mm/dd/yyyy"  />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group input-group">
                                                            <asp:Label ID="lblRegistrationDetails_TraineeName" runat="server" Text="Trainee Name" class="rField" />
                                                            <asp:DropDownList ID="ddlRegistrationDetails_TraineeName" runat="server" CssClass="form-control" 
                                                            OnSelectedIndexChanged="ddlRegistrationDetails_TraineeName_SelectedIndexChanged" AutoPostBack="true" />
                                                            <span class="input-group-btn">
                                                                <a href="TraineeProfile" class="btn btn-default btnTop10"><i class="fa fa-ellipsis-h"></i></a>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_ContactNo" runat="server" Text="Contact No" />
                                                        <div class="form-group input-group">
                                                            <span class="input-group-addon">+63</span>
                                                            <asp:TextBox ID="txtRegistrationDetails_ContactNo" runat="server" CssClass="form-control" Enabled="false" placeholder="9## ### ####" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_DateOfBirth" runat="server" Text="Date of Birth [MMDDYYYY]" />
                                                        <asp:TextBox ID="txtRegistrationDetails_DateOfBirth" runat="server" CssClass="form-control" Enabled="false" placeholder="mm/dd/yyyy" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_PlaceOfBirth" runat="server" Text="Place of Birth" />
                                                        <asp:TextBox ID="txtRegistrationDetails_PlaceOfBirth" runat="server" CssClass="form-control" Enabled="false" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <b>Course Detail</b>
                                            </div>
                                            <div class="panel-body">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_CourseCode" runat="server" Text="Course Code" />
                                                        <asp:TextBox ID="txtRegistrationDetails_CourseCode" runat="server" CssClass="form-control" placeholder="Course Code" Enabled="false" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_CourseName" runat="server" Text="Course Name" />
                                                        <asp:TextBox ID="txtRegistrationDetails_CourseName" runat="server" CssClass="form-control" placeholder="Course Name" Enabled="false" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_TrainingStartDate" runat="server" Text="Training Start Date [MMDDYYYY]" />
                                                        <asp:TextBox ID="txtRegistrationDetails_TrainingStartDate" runat="server" CssClass="form-control" TextMode="Date" Enabled="false" placeholder="mm/dd/yyyy" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_AvailableSlot" runat="server" Text="Available Slot" />
                                                        <asp:TextBox ID="txtRegistrationDetails_AvailableSlot" runat="server" CssClass="form-control" Enabled="false" placeholder="*/*" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblRegistrationDetails_TrainingFee" runat="server" Text="Training Fee (Php)" />
                                                        <asp:TextBox ID="txtRegistrationDetails_TrainingFee" runat="server" CssClass="form-control" Enabled="false" placeholder="Php #,###.##" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
            
                                <asp:Label ID="lblRegistrationDetails_Alert" runat="server" CssClass="AlertRed" />
                                <br /><br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Button ID="btnRegistrationDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnRegistrationDetails_Submit_Click" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnRegistrationDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnRegistrationDetails_Cancel_Click" />
                                    </div>
                                </div>

                                <!-- modalNotification -->
                                <div id="modalNotification" runat="server" class="modal">
                                    <div class="modal-content">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><h3><asp:Label ID="lblTraineeRegistrationDetails_NotifHeader" runat="server" /></h3></center>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><asp:Label ID="lblTraineeRegistrationDetails_NotifBody" runat="server" /></center>
                                            </div>
                                        </div>
                                        <br /><br /><br />
                                        <div class="row">
                                            <div class="col-md-7"></div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnTraineeRegistrationDetails_BackYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnTraineeRegistrationDetails_BackYes_Click" />
                                                <asp:Button ID="btnTraineeRegistrationDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnTraineeRegistrationDetails_SaveYes_Click" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnTraineeRegistrationDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnTraineeRegistrationDetails_No_Click" />
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane fade" id="EnrolledTrainee">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <h4>Enrolled Trainee(s)</h4>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body" style="overflow-x: scroll">
                                                <asp:GridView runat="server" ID="gvEnrolleeList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                                    PageSize="100" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" >
                                                    <Columns>
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
                                                        <asp:BoundField DataField="RegistrationID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        There are no enrolled trainees.
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
        <asp:View ID="vwDetailDropTraining" runat="server">
            <asp:HiddenField ID="hfDropCourseID" runat="server" Visible="false" />
            <asp:HiddenField ID="hfDropTraineeID" runat="server" Visible="false" />
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb">
                        <li><a href="Home">Home</a></li>
                        <li>Training Registration</li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10"><h4>Trainee Details: Dropping</h4></div>
                <div class="col-md-2">
                    <asp:Button ID="btnDropTrainee_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnDropTrainee_Back_Click" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-12">
                                    <h4>Select trainee(s) for dropping</h4>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvForDroppingList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                PageSize="100" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" >
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkSelectLine" AutoPostBack="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
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
                                    <asp:BoundField DataField="RegistrationID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                </Columns>
                                <EmptyDataTemplate>
                                    There are no enrolled trainees.
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblDropTrainee_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnDropTrainee_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnDropTrainee_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnDropTrainee_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnDropTrainee_Cancel_Click" />
                </div>
            </div>

            <!-- modalNotification -->
            <div id="modalViewForDroppingList" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblViewForDroppingList_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblViewForDroppingList_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnViewForDroppingList_BackYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnViewForDroppingList_BackYes_Click" />
                            <asp:Button ID="btnViewForDroppingList_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnViewForDroppingList_SaveYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnViewForDroppingList_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnViewForDroppingList_No_Click" />
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
