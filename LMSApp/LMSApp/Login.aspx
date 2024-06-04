<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="LMSApp.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords" content="wrappixel, admin dashboard, html css dashboard, web dashboard, bootstrap 5 admin, bootstrap 5, css3 dashboard, bootstrap 5 dashboard, Ample lite admin bootstrap 5 dashboard, frontend, responsive bootstrap 5 admin template, Ample admin lite dashboard bootstrap 5 dashboard template">
    <meta name="description" content="Ample Admin Lite is powerful and clean admin dashboard template, inpired from Bootstrap Framework">
    <meta name="robots" content="noindex,nofollow">    
    <link rel="canonical" href="https://www.wrappixel.com/templates/ample-admin-lite/" />
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="plugins/images/glogo.png">
    <!-- Custom CSS -->
    <link href="plugins/bower_components/chartist/dist/chartist.min.css" rel="stylesheet">
    <link rel="stylesheet" href="plugins/bower_components/chartist-plugin-tooltips/dist/chartist-plugin-tooltip.css">
    <!-- Custom CSS -->
    <link href="css/style.min.css" rel="stylesheet">
    <!--link href="http://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.3.0/css/font-awesome.css" rel="stylesheet" type='text/css'--->
    <style>
        .login-form {
            max-width: 450px;
           

        }

        .login-form input[type="text"],
        .login-form input[type="password"] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
            background-color: #f8f8f8;
            color: #333;
        }

        .login-btn  {
            width: 100%;
            background-color: #8a2be2;
            color: #fff;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
        }

        .login-form input[type="submit"]:hover {
            background-color: #7a25d4;
        }
    </style>
</head>
<body style="display: flex;" >
    <form id="form1" style="margin: 25vh auto;" runat="server">
        <div class="text-center col-lg-4 col-md-12">
            <img style="" src="plugins/images/glogo.png" />
        </div>
        
        <div class="login-form">

                               

            <asp:TextBox ID="txtUsername" runat="server" required="required" placeholder="Email"></asp:TextBox>

            <%--<input type="text" id="txtUsername" runat="server" required="required" placeholder="Student/Staff ID" />--%>

            <asp:TextBox ID="txtPwd" runat="server" required="required" placeholder="Password"></asp:TextBox>
            <%--<input type="password" id="txtPwd" runat="server" required="required" placeholder="Password" />--%>

            <asp:Button ID="loginBtn" class="login-btn" runat="server" Text="Log In" OnClick="loginBtn_Click" />
        </div>
        <asp:Label ID="lblError" runat="server" Text="Error..."></asp:Label>
    </form>
</body>
</html>
