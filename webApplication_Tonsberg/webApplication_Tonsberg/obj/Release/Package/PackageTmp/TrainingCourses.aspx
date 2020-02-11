<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="TrainingCourses.aspx.cs" Inherits="webApplication_Tonsberg.TrainingCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Training Courses - TITCI System
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
                <li>Administator</li>
                <li>Data Management</li>
                <li>Training Courses</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnTrainingCourses_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnTrainingCourses_Create_Click" />
            <asp:Button ID="btnTrainingCourses_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnTrainingCourses_Back_Click" />
        </div>
    </div>
    <br />
    <asp:MultiView ID="mvCourses" runat="server">
        <asp:View ID="vwViewCourses" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Training(s)</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtCoursesView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkCoursesView_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                OnClick="lnkCoursesView_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvTrainingList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvTrainingList_RowCommand" OnPageIndexChanging="gvTrainingList_PageIndexChanging"
                                OnSelectedIndexChanged="gvTrainingList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="CourseID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="CourseCode" HeaderText="CourseCode" />
                                    <asp:BoundField DataField="CourseName" HeaderText="CourseName" />
                                    <asp:BoundField DataField="TrainorName" HeaderText="TrainorName" />
                                    <asp:BoundField DataField="NoOfTrainees" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="EnrolledTrainees" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="TrainingDuration" HeaderText="TrainingDuration" />
                                    <asp:BoundField DataField="TrainingStartDate" HeaderText="TrainingStartDate" DataFormatString="{0:d}" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />
                                    <asp:BoundField DataField="TrainingFee" HeaderText="TrainingFee" />
                                    <asp:BoundField DataField="AssessorName" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />

                                    <asp:TemplateField ItemStyle-Width="5%" ShowHeader="False" HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkSelect" CausesValidation="false" CommandName="Select" CssClass="btn btn-primary" title="Select"
                                                CommandArgument='<%# Container.DataItemIndex %>' data-rel="tooltip"><i class="glyphicon glyphicon-th-list"></i></asp:LinkButton>
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
        </asp:View>
        <asp:View ID="vwDetailsTraining" runat="server">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#TrainingDetails" data-toggle="tab">Training Details</a></li>
                                <li><a href="#RegisteredTrainees" data-toggle="tab">Registered Trainees</a></li>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div class="tab-pane fade in active" id="TrainingDetails">
                                    <asp:HiddenField ID="hfTrainingID" runat="server" Visible="false" />
                                    <h3>Training Details</h3>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTrainingDetails_CourseCode" runat="server" Text="Course Code" class="rField" />
                                            <asp:TextBox ID="txtTrainingDetails_CourseCode" runat="server" CssClass="form-control" placeholder="Course Code" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTrainingDetails_CourseName" runat="server" Text="Course Name" class="rField" />
                                            <asp:TextBox ID="txtTrainingDetails_CourseName" runat="server" CssClass="form-control" placeholder="Course Name" />
                                        </div>
                                        <div class="col-md-4 chkPaddingTop">
                                            <asp:CheckBox ID="chkTrainingDetails_Active" runat="server" Checked="true" />
                                            <asp:Label ID="lblTrainingDetails_Active" runat="server" Text="Active" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTrainingDetails_NameOfTrainor" runat="server" Text="Name of Trainor" class="rField" />
                                            <asp:TextBox ID="txtTrainingDetails_NameOfTrainor" runat="server" CssClass="form-control" placeholder="Name of Trainor" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTrainingDetails_NoOfTrainees" runat="server" Text="No of Trainees" class="rField" />
                                            <asp:TextBox ID="txtTrainingDetails_NoOfTrainees" runat="server" CssClass="form-control" TextMode="Number" placeholder="0" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTrainingDetails_TrainingDuration" runat="server" Text="Training Duration (Days)" class="rField" />
                                            <asp:TextBox ID="txtTrainingDetails_TrainingDuration" runat="server" CssClass="form-control" TextMode="Number" placeholder="0" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTrainingDetails_TrainingStartDate" runat="server" Text="Training Start Date" class="rField" />
                                            <asp:TextBox ID="txtTrainingDetails_TrainingStartDate" runat="server" CssClass="form-control" TextMode="Date" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTrainingDetails_TrainingFee" runat="server" Text="Training Fee (Php)" class="rField" />
                                            <asp:TextBox ID="txtTrainingDetails_TrainingFee" runat="server" CssClass="form-control" TextMode="Number" />
                                        </div>
                                        <div class="col-md-4">
                                            <asp:Label ID="lblTrainingDetails_Assessor" runat="server" Text="Assessor" />
                                            <asp:TextBox ID="txtTrainingDetails_Assessor" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <br /><br />
                                    <asp:Label ID="lblTrainingDetails_Alert" runat="server" CssClass="AlertRed" />
                                    <br /><br />
                                    <div class="row">
                                        <div class="col-md-2">
                                            <asp:Button ID="btnTrainingDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnTrainingDetails_Submit_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnTrainingDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnTrainingDetails_Cancel_Click" />
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="RegisteredTrainees">
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <h4><asp:Label ID="lblRegisteredTrainees_TotalEnrollees" runat="server" /></h4>
                                                        </div>
                                                        <div class="col-md-4 col-md-offset-4">
                                                            <div class="form-group input-group mTop3-form-group">
                                                                <asp:TextBox ID="txtRegisteredTrainees_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                                                <span class="input-group-btn">
                                                                    <asp:LinkButton ID="lnkRegisteredTrainees_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                                        OnClick="lnkRegisteredTrainees_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="panel-body" style="overflow-x: scroll">
                                                    <asp:GridView runat="server" ID="gvRegisteredTrainees" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                                        PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnPageIndexChanging="gvRegisteredTrainees_PageIndexChanging" 
                                                        OnSelectedIndexChanged="gvRegisteredTrainees_SelectedIndexChanged">
                                                        <Columns>
                                                            <asp:BoundField DataField="TraineeID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                                                            <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" />
                                                            <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                                            <asp:BoundField DataField="GenderID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                            <asp:BoundField DataField="CivilStatusID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                                            <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                                                            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" DataFormatString="{0:d}" />
                                                            <asp:BoundField DataField="Age" HeaderText="Age" />
                                                            <asp:BoundField DataField="PlaceOfBirth" HeaderText="PlaceOfBirth" />
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
                                </div>
                            </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-6 -->
            </div>
            

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblTrainingDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblTrainingDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-2 col-md-offset-7">
                            <asp:Button ID="btnTrainingDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnTrainingDetails_SaveYes_Click" />
                            <asp:Button ID="btnTrainingDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnTrainingDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnTrainingDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnTrainingDetails_No_Click" />
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
