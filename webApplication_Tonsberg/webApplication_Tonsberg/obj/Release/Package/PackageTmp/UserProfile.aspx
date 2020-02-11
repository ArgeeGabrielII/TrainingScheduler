<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="webApplication_Tonsberg.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    User Profile - TITCI System
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
                <li>Account Management</li>
                <li>User Profile</li>
            </ul>
        </div>
    </div>

    <asp:HiddenField ID="hfUserID" runat="server" Visible="false" />
    <h4>User Profile Details: Change Password</h4>
    <br />
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="lblUADetails_UserName" runat="server" Text="Username" />
            <asp:TextBox ID="txtUADetails_UserName" runat="server" CssClass="form-control" placeholder="Username" Enabled="false" />
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
            <asp:TextBox ID="txtUADetails_FirstName" runat="server" CssClass="form-control" placeholder="First Name" Enabled="false" />
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblUADetails_LastName" runat="server" Text="Last Name" />
            <asp:TextBox ID="txtUADetails_LastName" runat="server" CssClass="form-control" placeholder="Last Name" Enabled="false" />
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblUADetails_EmailAddress" runat="server" Text="Email Address" />
            <asp:TextBox ID="txtUADetails_EmailAddress" runat="server" CssClass="form-control" placeholder="Email Address" Enabled="false" />
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
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
