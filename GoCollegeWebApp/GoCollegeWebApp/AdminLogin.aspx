<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="GoCollegeWebApp.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GoCollege</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="GoCollege, Collge" />
    <script type="application/x-javascript"> 
    addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); }
    </script>
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom Css files -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <script src="js/jquery.min.js"> </script>
</head>
<body>
    <div class="login">
        <h1><a href="Index.aspx"></a></h1>
        <div class="login-bottom">

            <h2 class="text-center" style="color: #d95459">Welcome to MyCampuz</h2>
            <h2 class="text-center">Login</h2>
            <form id="adminLogin" runat="server">

                <div class="col-md-2 ">
                </div>

                <div class="col-md-8">
                    <div class="text-center">
                        <asp:Label ID="errMsg" CssClass="errMsg" Text="" runat="server"> </asp:Label>
                    </div>

                    <div class="login-mail">
                        <asp:TextBox ID="adminUserName" runat="server" placeholder="User Name/ USN / FacultyCode" required=""></asp:TextBox>
                        <i class="fa fa-user"></i>
                    </div>
                    <div class="login-mail">
                        <asp:TextBox TextMode="Password" ID="adminPassword" runat="server" placeholder="Password" required=""></asp:TextBox>
                        <i class="fa fa-lock"></i>
                    </div>

                    <div class="login-do">
                        <label class="hvr-shutter-in-horizontal login-sub">
                            <asp:Button ID="adminLoginbtn" runat="server" Text="Login" OnClick="adminLoginbtn_Click" />
                        </label>
                    </div>

                    <a class="news-letter " href="#">
                        <label class="checkbox1">
                            <asp:CheckBox ID="adminForgotPasswordChkBox" runat="server" />
                            <i></i>Forget Password</label>
                    </a>

                </div>
                <div class="col-md-2 ">
                </div>

                <div class="clearfix"></div>
            </form>
        </div>
    </div>

    <%--// JS--%>
    <script src="js/jquery.nicescroll.js"></script>
    <script src="js/scripts.js"></script>

</body>
</html>
