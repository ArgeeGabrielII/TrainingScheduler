<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="webApplication_Tonsberg.Department" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Department - TITCI System
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
                <li>Administator Data Management</li>
                <li>Department</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnDepartment_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnDepartment_Create_Click"/>
            <asp:Button ID="btnDepartment_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnDepartment_Back_Click"/>
        </div>
    </div>

    <asp:MultiView ID="mvDepartment" runat="server">
        <asp:View ID="vwViewDepartment" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Department</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtDepartmentView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkDepartmentView_Search" runat="server" CssClass="btn btn-default btn-padding" 
                                                OnClick="lnkDepartmentView_Search_Click"><i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvDepartmentList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvDepartmentList_RowCommand" OnPageIndexChanging="gvDepartmentList_PageIndexChanging"
                                OnSelectedIndexChanged="gvDepartmentList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="DepartmentID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" />
                                    <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />

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
        <asp:View ID="vwDetailsDepartment" runat="server">
            <asp:HiddenField ID="hfDepartmentID" runat="server" Visible="false" />
            <h4>Department Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblDepartmentDetails_Code" runat="server" Text="Department Code" class="rField"  />
                    <asp:TextBox ID="txtDepartmentDetails_Code" runat="server" CssClass="form-control" placeholder="Code" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblDepartmentDetails_Name" runat="server" Text="Department Name" class="rField" />
                    <asp:TextBox ID="txtDepartmentDetails_Name" runat="server" CssClass="form-control" placeholder="Name" />
                </div>
                <div class="col-md-4 chkPaddingTop">
                    <asp:CheckBox ID="chkDepartmentDetails_Active" runat="server" />
                    <asp:Label ID="lblDepartmentDetails_Active" runat="server" Text="Active" />
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblDepartmentDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnDepartmentDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnDepartmentDetails_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnDepartmentDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnDepartmentDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblDepartmentDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblDepartmentDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnDepartmentDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnDepartmentDetails_SaveYes_Click" />
                            <asp:Button ID="btnDepartmentDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnDepartmentDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnDepartmentDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnDepartmentDetails_No_Click" />
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
