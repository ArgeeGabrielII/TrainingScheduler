<%@ Page Title="" Language="C#" MasterPageFile="~/Tonsberg.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Reports.aspx.cs" Inherits="webApplication_Tonsberg.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Reports - TITCI System
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
                <li>Data Management</li>
                <li>Reports</li>
            </ul>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="lblReport_Selection" runat="server" Text="Report Selection" class="rField" />
            <asp:DropDownList ID="ddlReport_Selection" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlReport_Selection_SelectedIndexChanged" >
                <asp:ListItem Value="0" Text="Select" />
                <asp:ListItem Value="1" Text="AR All Courses" />
                <asp:ListItem Value="2" Text="AR per Course" />
                <asp:ListItem Value="3" Text="Sales All Course" />
                <asp:ListItem Value="4" Text="Sales per Course" />
            </asp:DropDownList>
        </div>
        <div class="col-md-2" style="margin-top: 20px;">
            <asp:Button ID="btnReport_GenerateReport" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Generate Report" OnClick="btnReport_GenerateReport_Click"/>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
            <asp:Label ID="lblReport_DateFrom" runat="server" Text="Date From" class="rField" />
            <asp:TextBox ID="txtReport_DateFrom" runat="server" CssClass="form-control" TextMode="Date" />
        </div>
        <div class="col-md-4">
            <asp:Label ID="lblReport_DateTo" runat="server" Text="Date To" class="rField" />
            <asp:TextBox ID="txtReport_DateTo" runat="server" CssClass="form-control" TextMode="Date" />
        </div>
        <div class="col-md-4" id="divCourse" runat="server">
            <asp:Label ID="lblReport_Course" runat="server" Text="Course" class="rField" />
            <asp:DropDownList ID="ddlReport_Course" runat="server" CssClass="form-control" />
        </div>
    </div>
    <br /><br />

    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-md-12">
                            <h4><asp:Label ID="gvTitleHeader" runat="server" Text="Please select a report." /></h4>
                        </div>
                    </div>
                </div>
                <div class="panel-body" style="overflow-x: scroll">
                    <asp:GridView runat="server" ID="gvReport" AutoGenerateColumns="true" CssClass="table table-striped table-bordered table-hover" AllowPaging="false" 
                        HeaderStyle-HorizontalAlign="Center" ShowHeader="false" OnRowDataBound="gvReport_RowDataBound" OnDataBound="gvReport_DataBound" >
                        <EmptyDataTemplate>
                            The report you are trying to generate has no data.
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-2 col-md-offset-10">
            <asp:Button ID="btnGeneratePDF" runat="server" CssClass="btn btn-md btn-success btn-block" Text="Generate PDF"  OnClick="btnGeneratePDF_Click" />
        </div>
    </div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>