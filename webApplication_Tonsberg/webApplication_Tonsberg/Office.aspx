<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="Office.aspx.cs" Inherits="webApplication_Tonsberg.Office" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Office - TITCI System
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
                <li>Office</li>
            </ul>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnOffice_Create" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Create" OnClick="btnOffice_Create_Click" />
            <asp:Button ID="btnOffice_Back" runat="server" CssClass="btn btn-md btn-warning btn-block" Text="Back" OnClick="btnOffice_Back_Click" />
        </div>
    </div>

    <asp:MultiView ID="mvOffice" runat="server">
        <asp:View ID="vwViewOffice" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>View Office</h4>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group input-group mTop3-form-group">
                                        <asp:TextBox ID="txtOfficeView_Search" runat="server" CssClass="form-control" placeholder="Search" />
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkOfficeView_Search" runat="server" CssClass="btn btn-default btn-padding" OnClick="lnkOfficeView_Search_Click" >
                                                <i class="fa fa-search"></i></asp:LinkButton>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-body" style="overflow-x: scroll">
                            <asp:GridView runat="server" ID="gvOfficeList" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" 
                                PageSize="10" HeaderStyle-HorizontalAlign="Center" PagerStyle-CssClass="pagination" OnRowCommand="gvOfficeList_RowCommand" OnPageIndexChanging="gvOfficeList_PageIndexChanging"
                                OnSelectedIndexChanged="gvOfficeList_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="OfficeID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField DataField="OfficeCode" HeaderText="Office Code" />
                                    <asp:BoundField DataField="OfficeName" HeaderText="Office Name" />
                                    <asp:BoundField DataField="OfficeAddress" HeaderText="Office Address" />
                                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No(s)" />
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
        <asp:View ID="vwDetailsOffice" runat="server">
            <asp:HiddenField ID="hfOfficeID" runat="server" Visible="false" />
            <h4>Office Details</h4>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblOfficeDetails_Code" runat="server" Text="Office Code" class="rField" />
                    <asp:TextBox ID="txtOfficeDetails_Code" runat="server" CssClass="form-control" placeholder="Code" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblOfficeDetails_Name" runat="server" Text="Office Name" class="rField" />
                    <asp:TextBox ID="txtOfficeDetails_Name" runat="server" CssClass="form-control" placeholder="Name" />
                </div>
                <div class="col-md-4 chkPaddingTop">
                    <asp:CheckBox ID="chkOfficeDetails_Active" runat="server" />
                    <asp:Label ID="lblOfficeDetails_Active" runat="server" Text="Active" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblOfficeDetails_OfficeAddress" runat="server" Text="Office Address" />
                    <asp:TextBox ID="txtOfficeDetails_OfficeAddress" runat="server" CssClass="form-control" placeholder="Office Address" TextMode="MultiLine" />
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblOfficeDetails_ContactNo" runat="server" Text="Contact No(s)" />
                    <asp:TextBox ID="txtOfficeDetails_ContactNo" runat="server" CssClass="form-control" placeholder="Contact No(s)" TextMode="MultiLine" />
                </div>
            </div>
            <br /><br />
            <asp:Label ID="lblOfficeDetails_Alert" runat="server" CssClass="AlertRed" />
            <br /><br />
            <div class="row">
                <div class="col-md-2">
                    <asp:Button ID="btnOfficeDetails_Submit" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Submit" OnClick="btnOfficeDetails_Submit_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnOfficeDetails_Cancel" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="Cancel" OnClick="btnOfficeDetails_Cancel_Click" />
                </div>
            </div>

            <div id="modalNotification" runat="server" class="modal">
                <div class="modal-content">
                    <div class="row">
                        <div class="col-md-12">
                            <center><h3><asp:Label ID="lblOfficeDetails_NotifHeader" runat="server" /></h3></center>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <center><asp:Label ID="lblOfficeDetails_NotifBody" runat="server" /></center>
                        </div>
                    </div>
                    <br /><br /><br />
                    <div class="row">
                        <div class="col-md-7"></div>
                        <div class="col-md-2">
                            <asp:Button ID="btnOfficeDetails_SaveYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnOfficeDetails_SaveYes_Click" />
                            <asp:Button ID="btnOfficeDetails_CancelYes" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Yes" OnClick="btnOfficeDetails_CancelYes_Click" />
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnOfficeDetails_No" runat="server" CssClass="btn btn-md btn-danger btn-block" Text="No" OnClick="btnOfficeDetails_No_Click" />
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
