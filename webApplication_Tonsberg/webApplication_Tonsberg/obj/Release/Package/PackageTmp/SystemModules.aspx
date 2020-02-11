<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="SystemModules.aspx.cs" Inherits="webApplication_Tonsberg.SystemModules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    System Modules - TITCI System
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
                <li>System Modules</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnPageModules_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnPageModules_Create_Click" />
            <asp:Button ID="btnPageModules_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnPageModules_Back_Click" />
        </div>
    </div>

    <asp:MultiView ID="mvPageModules" runat="server">
        <asp:View ID="vwViewPageModules" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View System Modules</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtPageModulesView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkPageModulesView_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkPageModulesView_Search_Click" >
                                                <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvPageModulesList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvPageModulesList_RowCommand" OnPageIndexChanging="gvPageModulesList_PageIndexChanging"
                                OnSelectedIndexChanged="gvPageModulesList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="ModuleID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="ModuleName" HeaderText="ModuleName" />
                                    <asp:BoundField DataField="ModuleDescription" HeaderText="ModuleDescription" />
                                    <asp:BoundField DataField="ModuleURL" HeaderText="ModuleURL" />

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
        <asp:View ID="vwDetailsPageModules" runat="server">
            <asp:HiddenField ID="hfPageModulesID" runat="server" Visible="false" />
            <h4>Page Modules Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblPageModulesDetails_Name" runat="server" Text="Name" class="rField" />
                    <asp:TextBox ID="txtPageModulesDetails_Name" runat="server" CssClass="form-control" placeholder="Name" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblPageModulesDetails_Description" runat="server" Text="Description" class="rField" />
                    <asp:TextBox ID="txtPageModulesDetails_Description" runat="server" CssClass="form-control" placeholder="Description" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblPageModulesDetails_URL" runat="server" Text="URL" class="rField" />
                    <asp:TextBox ID="txtPageModulesDetails_URL" runat="server" CssClass="form-control" placeholder="URL" />
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblPageModulesDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnPageModulesDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnPageModulesDetails_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnPageModulesDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnPageModulesDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblPageModulesDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblPageModulesDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnPageModulesDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnPageModulesDetails_SaveYes_Click" />
                            <asp:Button ID="btnPageModulesDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnPageModulesDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnPageModulesDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnPageModulesDetails_No_Click" />
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
