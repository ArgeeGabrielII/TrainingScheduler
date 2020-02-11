<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="UserGroups.aspx.cs" Inherits="webApplication_Tonsberg.UserGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Groups - TITCI System
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
                <li>User Groups</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnUserGroup_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnUserGroup_Create_Click" />
            <asp:Button ID="btnUserGroup_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnUserGroup_Back_Click" />
        </div>
    </div>
    <asp:MultiView ID="mvUserGroup" runat="server">
        <asp:View ID="vwViewUserGroups" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View User Group</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtUserGroup_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkUserGroup_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkUserGroup_Search_Click">
                                        <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvUserGroupsList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" PageSize="50"
                                HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvUserGroupsList_RowCommand" OnPageIndexChanging="gvUserGroupsList_PageIndexChanging"
                                OnSelectedIndexChanged="gvUserGroupsList_SelectedIndexChanged" >
                                <Columns>
                                    <asp:BoundField DataField="GroupID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="GroupName" HeaderText="Group Name" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="GroupDescription" HeaderText="Description" ItemStyle-HorizontalAlign="Center" />
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
        <asp:View ID="vwDetailsUserGroup" runat="server">
            <asp:HiddenField ID="hfUserGroupID" runat="server" Visible="false" />
            <h4>User Group Details</h4><br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblUGDetails_GroupName" runat="server" Text="Group Name" class="rField" />
                    <asp:TextBox ID="txtUGDetails_GroupName" runat="server" CssClass="form-control" placeholder="Group Name" />
                </div>
                <div class="col-md-4 chkPaddingTop">
                    <asp:CheckBox ID="chkUGDetails_Active" runat="server" />
                    <asp:Label ID="lblUGDetails_Active" runat="server" Text="Active" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblUGDetails_Description" runat="server" Text="Description" />
                    <asp:TextBox ID="txtUGDetails_Description" runat="server" CssClass="form-control" placeholder="Description" TextMode="MultiLine" />
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblUGDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnUGDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnUGDetails_Submit_Click"/>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnUGDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnUGDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblUGDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblUGDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnUGDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnUGDetails_SaveYes_Click" />
                            <asp:Button ID="btnUGDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnUGDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnUGDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnUGDetails_No_Click" />
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
