<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="UserAccounts.aspx.cs" Inherits="webApplication_Tonsberg.UserAccounts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Accounts - TITCI System
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
                <li>Account Management</li>
                <li>User Account</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnUserAccount_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnUserAccount_Create_Click" />
            <asp:Button ID="btnUserAccount_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnUserAccount_Back_Click" />
        </div>
    </div>
    <asp:MultiView ID="mvUserAccounts" runat="server">
        <asp:View ID="vwViewUserAccounts" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View User Account</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtUserAccount_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkUserAccount_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkUserAccount_Search_Click">
                                        <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvUserAccountsList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" PageSize="10"
                                HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvUserAccountsList_RowCommand" OnPageIndexChanging="gvUserAccountsList_PageIndexChanging"
                                OnSelectedIndexChanged="gvUserAccountsList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="UserID" HeaderText="User ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="UserName" HeaderText="Username" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Password" HeaderText="Password" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="GroupID" HeaderText="Group ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="GroupName" HeaderText="Group Name" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="EmailAddress" HeaderText="Email Address" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Office" HeaderText="Office" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" ItemStyle-HorizontalAlign="Center" />
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
        <asp:View ID="vwDetailsUserAccounts" runat="server">
            <asp:HiddenField ID="hfUserID" runat="server" Visible="false" />
            <h4>User Account Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblUADetails_UserName" runat="server" Text="Username" class="rField" />
                    <asp:TextBox ID="txtUADetails_UserName" runat="server" CssClass="form-control" placeholder="Username" />
                </div>
                <div class="col-md-4 chkPaddingTop">
                    <asp:CheckBox ID="chkUADetails_Active" runat="server" />
                    <asp:Label ID="lblUADetails_Active" runat="server" Text="Active" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblUADetails_Password1" runat="server" Text="Password" class="rField" />
                    <asp:TextBox ID="txtUADetails_Password1" runat="server" CssClass="form-control" placeholder="Password" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblUADetails_Password2" runat="server" Text="Password" class="rField" />
                    <asp:TextBox ID="txtUADetails_Password2" runat="server" CssClass="form-control" placeholder="Verify Password" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblUADetails_FirstName" runat="server" Text="First Name" />
                    <asp:TextBox ID="txtUADetails_FirstName" runat="server" CssClass="form-control" placeholder="First Name" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblUADetails_LastName" runat="server" Text="Last Name" />
                    <asp:TextBox ID="txtUADetails_LastName" runat="server" CssClass="form-control" placeholder="Last Name" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblUADetails_EmailAddress" runat="server" Text="Email Address" />
                    <asp:TextBox ID="txtUADetails_EmailAddress" runat="server" CssClass="form-control" placeholder="Email Address" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group input-group">
                        <asp:Label ID="lblUADetails_UserGroup" runat="server" Text="User Group" class="rField" />
                        <asp:DropDownList ID="ddlUADetails_UserGroup" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <a href="UserGroups" class="btn btn-default btnTop10"><i class="fa fa-ellipsis-h"></i></a>
                        </span>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group input-group">
                        <asp:Label ID="lblUADetails_Department" runat="server" Text="Department" class="rField" />
                        <asp:DropDownList ID="ddlUADetails_Department" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <a href="Department" class="btn btn-default btnTop10"><i class="fa fa-ellipsis-h"></i></a>
                        </span>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group input-group">
                        <asp:Label ID="lblUADetails_Office" runat="server" Text="Office" class="rField" />
                        <asp:DropDownList ID="ddlUADetails_Office" runat="server" CssClass="form-control" />
                        <span class="input-group-btn">
                            <a href="Office" class="btn btn-default btnTop10"><i class="fa fa-ellipsis-h"></i></a>
                        </span>
                    </div>
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblUADetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnUADetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnUADetails_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnUADetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnUADetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblUADetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblUADetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnUADetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnUADetails_SaveYes_Click" />
                            <asp:Button ID="btnUADetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnUADetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnUADetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnUADetails_No_Click" />
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
