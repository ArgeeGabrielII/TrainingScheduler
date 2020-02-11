<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="GroupRights.aspx.cs" Inherits="webApplication_Tonsberg.GroupRights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Group Rights - TITCI System
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
                <li>Group Rights</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnGroupRights_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnGroupRights_Submit_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-md-4">
                            <h4>View Group Rights</h4>
                        </div>
                        <div class="col-md-4 col-md-offset-4">
                            <asp:DropDownList ID="ddlGroupRights_Selection" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupRights_Selection_SelectedIndexChanged" />
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="overflow-x: scroll">
                    <asp:GridView runat="server" ID="gvGroupRights" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                        HeaderStyle-HorizontalAlign="Center" OnSelectedIndexChanged="gvGroupRights_SelectedIndexChanged" OnRowCancelingEdit="gvGroupRights_RowCancelingEdit" OnRowUpdating="gvGroupRights_RowUpdating"
                        OnRowEditing="gvGroupRights_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="Group Right ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblGroupRightID" Text='<%# Bind("GroupRightID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Group ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblGroupID" Text='<%# Bind("GroupID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblModuleID" Text='<%# Bind("ModuleID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Module Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblModuleName" Text='<%# Bind("ModuleName") %>' Enabled="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Can View" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkCanView" Enabled="true" Checked='<%# Bind("CanView") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Can Add/Edit" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkCanEdit" Enabled="true" Checked='<%# Bind("CanEdit") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Can Delete" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkCanDelete" Enabled="true" Checked='<%# Bind("CanDelete") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            System cannot load data, without selecting a specific User Group.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div id="modalNotification" runat="server" class="modal">
        <div class="modal-content">
            <div class="row">
                <div class="col-md-12">
                    <center><h3><asp:Label ID="lblGroupRights_NotifHeader" runat="server" /></h3></center>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <center><asp:Label ID="lblGroupRights_NotifBody" runat="server" /></center>
                </div>
            </div>
            <br /><br /><br />
            <div class="row">
                <div class="col-md-7"></div>
                <div class="col-md-2">
                    <asp:Button ID="btnGroupRights_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnGroupRights_SaveYes_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnGroupRights_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnGroupRights_No_Click" />
                </div>
            </div>
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
