<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="Others.aspx.cs" Inherits="webApplication_Tonsberg.Others" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Others - TITCI System
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
        <div class="col-md-12">
            <ul class="breadcrumb">
                <li><a href="Home">Home</a></li>
                <li>Administator</li>
                <li>Administator Data Management</li>
                <li>Others</li>
            </ul>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel-body">
                <!-- Nav tabs -->
                <ul class="nav nav-tabs">
                    <li id="liGender" runat="server" class="active"><a href="#Gender" data-toggle="tab">
                        <center>Gender</center>
                    </a></li>
                    <li id="liCivilStatus" runat="server"><a href="#CivilStatus" data-toggle="tab">
                        <center>Civil Status</center>
                    </a></li>
                    <%--<li id="liIdentificationList" runat="server"><a href="#IdentificationList" data-toggle="tab">
                        <center>Identification List</center>
                    </a></li>--%>
                </ul>

                <!-- Tab panes -->
                <div class="tab-content">
                    <!-- Start Gender -->
                    <div class="tab-pane fade active in" id="Gender">
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-md-offset-10">
                                <asp:Button ID="btnGender_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnGender_Create_Click" />
                                <asp:Button ID="btnGender_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnGender_Back_Click" />
                            </div>
                        </div>
                        <br />
                        <asp:MultiView ID="mvGender" runat="server">
                            <asp:View ID="vwViewGender" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <h4>View Gender List</h4>
                                                    </div>
                                                    <div class="col-md-4 col-md-offset-4">
                                                        <div class="form-group input-group mTop3-form-group">
                                                            <asp:TextBox ID="txtGenderView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                                            <span class="input-group-btn">
                                                                <asp:LinkButton ID="lnkGenderView_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                                    OnClick="lnkGenderView_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body" style="overflow-x: scroll">
                                                <asp:GridView runat="server" ID="gvGenderList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                    PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvGenderList_RowCommand" OnPageIndexChanging="gvGenderList_PageIndexChanging"
                                                    OnSelectedIndexChanged="gvGenderList_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="GenderID" HeaderText="GenderID" />
                                                        <asp:BoundField DataField="GenderName" HeaderText="GenderName" />

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
                            <asp:View ID="vwDetailsGender" runat="server">
                                <asp:HiddenField ID="hfGenderID" runat="server" Visible="false" />
                                <h4>Gender Details</h4>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblGenderDetails_Name" runat="server" Text="Gender" class="rField" />
                                        <asp:TextBox ID="txtGenderDetails_Name" runat="server" CssClass="form-control" placeholder="Gender" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <asp:Label ID="lblGenderDetails_Alert" runat="server" CssClass="AlertRed" />
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Button ID="btnGenderDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnGenderDetails_Submit_Click" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnGenderDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnGenderDetails_Cancel_Click" />
                                    </div>
                                </div>

                                <div id="modalNotification_Gender" runat="server" class="modal">
                                    <div class="modal-content">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><h3><asp:Label ID="lblGenderDetails_NotifHeader" runat="server" /></h3></center>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><asp:Label ID="lblGenderDetails_NotifBody" runat="server" /></center>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-md-7"></div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnGenderDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnGenderDetails_SaveYes_Click" />
                                                <asp:Button ID="btnGenderDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnGenderDetails_CancelYes_Click" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnGenderDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnGenderDetails_No_Click" />
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                    <!-- End Gender -->

                    <!-- Start CivilStatus -->
                    <div class="tab-pane fade in" id="CivilStatus">
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-md-offset-10">
                                <asp:Button ID="btnCivilStatus_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnCivilStatus_Create_Click" />
                                <asp:Button ID="btnCivilStatus_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnCivilStatus_Back_Click" />
                            </div>
                        </div>
                        <br />
                        <asp:MultiView ID="mvCivilStatus" runat="server">
                            <asp:View ID="vwViewCivilStatus" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <h4>View CivilStatus List</h4>
                                                    </div>
                                                    <div class="col-md-4 col-md-offset-4">
                                                        <div class="form-group input-group mTop3-form-group">
                                                            <asp:TextBox ID="txtCivilStatusView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                                            <span class="input-group-btn">
                                                                <asp:LinkButton ID="lnkCivilStatusView_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                                    OnClick="lnkCivilStatusView_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body" style="overflow-x: scroll">
                                                <asp:GridView runat="server" ID="gvCivilStatusList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                    PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvCivilStatusList_RowCommand" OnPageIndexChanging="gvCivilStatusList_PageIndexChanging"
                                                    OnSelectedIndexChanged="gvCivilStatusList_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="CivilStatusID" HeaderText="CivilStatusID" />
                                                        <asp:BoundField DataField="CivilStatusName" HeaderText="CivilStatusName" />

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
                            <asp:View ID="vwDetailsCivilStatus" runat="server">
                                <asp:HiddenField ID="hfCivilStatusID" runat="server" Visible="false" />
                                <h4>CivilStatus Details</h4>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblCivilStatusDetails_Name" runat="server" Text="CivilStatus" class="rField" />
                                        <asp:TextBox ID="txtCivilStatusDetails_Name" runat="server" CssClass="form-control" placeholder="CivilStatus" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <asp:Label ID="lblCivilStatusDetails_Alert" runat="server" CssClass="AlertRed" />
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Button ID="btnCivilStatusDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnCivilStatusDetails_Submit_Click" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnCivilStatusDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnCivilStatusDetails_Cancel_Click" />
                                    </div>
                                </div>

                                <div id="modalNotification_CivilStatus" runat="server" class="modal">
                                    <div class="modal-content">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><h3><asp:Label ID="lblCivilStatusDetails_NotifHeader" runat="server" /></h3></center>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><asp:Label ID="lblCivilStatusDetails_NotifBody" runat="server" /></center>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-md-7"></div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnCivilStatusDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnCivilStatusDetails_SaveYes_Click" />
                                                <asp:Button ID="btnCivilStatusDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnCivilStatusDetails_CancelYes_Click" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnCivilStatusDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnCivilStatusDetails_No_Click" />
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                    <!-- End CivilStatus -->

                    <%--<!-- Start IdentificationList -->
                    <div class="tab-pane fade in" id="IdentificationList">
                        <br />
                        <div class="row">
                            <div class="col-md-2 col-md-offset-10">
                                <asp:Button ID="btnIdentificationList_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnIdentificationList_Create_Click" />
                                <asp:Button ID="btnIdentificationList_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnIdentificationList_Back_Click" />
                            </div>
                        </div>
                        <br />
                        <asp:MultiView ID="mvIdentificationList" runat="server">
                            <asp:View ID="vwViewIdentificationList" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <h4>View Identification List</h4>
                                                    </div>
                                                    <div class="col-md-4 col-md-offset-4">
                                                        <div class="form-group input-group mTop3-form-group">
                                                            <asp:TextBox ID="txtIdentificationListView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                                            <span class="input-group-btn">
                                                                <asp:LinkButton ID="lnkIdentificationListView_Search" runat="server" CssClass="btn btn-default btn-padding"
                                                                    OnClick="lnkIdentificationListView_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel-body" style="overflow-x: scroll">
                                                <asp:GridView runat="server" ID="gvIdentificationListList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                    PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvIdentificationListList_RowCommand" OnPageIndexChanging="gvIdentificationListList_PageIndexChanging"
                                                    OnSelectedIndexChanged="gvIdentificationListList_SelectedIndexChanged">
                                                    <Columns>
                                                        <asp:BoundField DataField="IdentificationListID" HeaderText="IdentificationListID" />
                                                        <asp:BoundField DataField="IdentificationListName" HeaderText="IdentificationListName" />

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
                            <asp:View ID="vwDetailsIdentificationList" runat="server">
                                <asp:HiddenField ID="hfIdentificationListID" runat="server" Visible="false" />
                                <h4>IdentificationList Details</h4>
                                <br />
                                <div class="row">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblIdentificationListDetails_Name" runat="server" Text="IdentificationList **" />
                                        <asp:TextBox ID="txtIdentificationListDetails_Name" runat="server" CssClass="form-control" placeholder="IdentificationList" />
                                    </div>
                                </div>
                                <br />
                                <br />
                                <asp:Label ID="lblIdentificationListDetails_Alert" runat="server" CssClass="AlertRed" />
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Button ID="btnIdentificationListDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnIdentificationListDetails_Submit_Click" />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnIdentificationListDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnIdentificationListDetails_Cancel_Click" />
                                    </div>
                                </div>

                                <div id="modalNotification_IdentificationList" runat="server" class="modal">
                                    <div class="modal-content">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><h3><asp:Label ID="lblIdentificationListDetails_NotifHeader" runat="server" /></h3></center>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <center><asp:Label ID="lblIdentificationListDetails_NotifBody" runat="server" /></center>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-md-7"></div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnIdentificationListDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnIdentificationListDetails_SaveYes_Click" />
                                                <asp:Button ID="btnIdentificationListDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnIdentificationListDetails_CancelYes_Click" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:Button ID="btnIdentificationListDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnIdentificationListDetails_No_Click" />
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                    <!-- End IdentificationList -->--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
