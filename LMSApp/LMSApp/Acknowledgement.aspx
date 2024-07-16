<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Acknowledgement.aspx.vb" Inherits="LMSApp.Acknowledgement" %>

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
        body{
           background-image: linear-gradient(to bottom, #93761e 60%, black);
           display: flex;
            height: 100vh;
            justify-content: center;
            align-items: center;
        }
        #AcknowledgementDiv {
            /*min-height: 60vh;*/
            max-width: 65vh;
            /*overflow-y: scroll;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div id="AcknowledgementDiv"  class="card" >
            <div class="card-body">
                
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <div class="form-horizontal form-material">
                    <div id="Div2"  runat="server" class="mb-4 border-bottom">
                        <h4 class="mb-4 fw-bold ">Thank you for applying to Grits Lab Africa</h4>
                
                        <p>We are still reviewing your application, we will communicate with you as soon as a decision regarding your application then you will be able to access our learning system with your login details.</p>
                    </div> 
                </div>
            
              <div class="form-group mb-4">
                    <div class="col-sm-12">
                        <a href="Login.aspx" id="n" runat="server" class="m-2 mb-0 btn btn-primary" >Back to Login</a>                        
                    </div>                   
                </div>
                <asp:Label ID="lblApplError" runat="server" CssClass=" text-center text-danger" Text="" Visible="false"></asp:Label>

            </div>
        </div>
        </div>
    </form>
</body>
</html>
