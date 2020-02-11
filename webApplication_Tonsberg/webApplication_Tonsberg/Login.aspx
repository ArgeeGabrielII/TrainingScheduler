<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="webApplication_Tonsberg.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - TITCI System</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="Rosalito Gabriel II" />

    <!-- The fav icon -->
    <link rel="shortcut icon tonsberg icon" href="assets/img/tonsberg_icon.ico" />
    <!-- Bootstrap Core CSS -->
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="assets/vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="assets/dist/css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="assets/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style>
        .fSize8{ font-size:8px; }
        .fSize10{ font-size:10px; }
    </style>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <center>
                            <asp:Image runat="Server" ID="imgLogo" ImageUrl="assets/img/TITCI%20Logo..png" AlternateText="TITCI Logo" Width="40%" />
                            <h3>TITCI System</h3>
                        </center>
                    </div>
                    <div class="panel-body">
                        <form id="Form1" role="form" runat="server">
                            <div class="row">
                                <div class="col-md-12">
                                    <center><asp:Label ID="lblLogin_Alert" runat="server" CssClass="text-danger" /></center>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtLogin_Username" runat="server" CssClass="form-control" placeholder="Username" />
                                </div>
                                <br /><br />                               
                                <div class="col-md-12">
                                    <asp:TextBox ID="txtLogin_Password" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />
                                </div>
                                <br /><br /><br />
                                <div class="col-md-12">
                                    <asp:Button ID="btnLogin_Submit" runat="server" CssClass="btn btn-lg btn-success btn-block" Text="Login" OnClick="btnLogin_Submit_Click" />
                                </div>
                            </div>
                            <hr />
                            <div class="footer">
                                <center>
                                    <p class="fSize8">
                                        Property and Copyright <i class="glyphicon glyphicon-copyright-mark"></i> Tonsberg Internationl Training Center, Inc. All Rights Reserved <%=DateTime.Now.Year%>
                                        <br />Developed by Argee Gabriel II
                                    </p>
                                    <br />
                                    <p class="fSize8">
                                        Ver. 1.0
                                    </p>
                                </center>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
