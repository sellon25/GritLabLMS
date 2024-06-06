<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SignUp.aspx.vb" Inherits="LMSApp.SignUp" %>

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
    </style>
</head>
<body style="" >
    <form id="form1" style="width: 85%;" runat="server">
        <h3 class="fw-bold">Sign Up</h3>
       <div class="card">
        <div class="card-body">
            <form class="form-horizontal form-material">
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">First Name</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="text" placeholder="Type here..." class="form-control p-0 border-0"> </div>
                </div>
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">Last Name</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="text" placeholder="Type here..." class="form-control p-0 border-0"> </div>
                </div>
                
               
                <div class="form-group mb-4">
                    <label class="col-sm-12">Title</label>

                    <div class="col-sm-12 border-bottom">
                        <select class="form-select shadow-none p-0 border-0 form-control-line">
                            <option>Dr</option>
                            <option>Mr</option>
                            <option>Mrs</option>
                            <option>Mx</option>
                            <option>Prof</option>
                        </select>
                    </div>
                </div>
                
                <div class="form-group mb-4">
                    <label for="example-email" class="col-md-12 p-0">Email</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="email" required placeholder="Type here..." class="form-control p-0 border-0" name="example-email" id="example-email">
                    </div>
                </div>
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">Create a Password</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="password" required placeholder="Type here..." class="form-control p-0 border-0"> </div>
                </div>
                 <div class="form-group mb-4">
                    <label class="col-md-12 p-0">Confirm Password</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="password" required placeholder="Type here..." class="form-control p-0 border-0"> </div>
                </div>
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">WhatsApp number</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="number" required placeholder="Type here..." class="form-control p-0 border-0"> </div>
                </div>

                <div class="form-group mb-4">
                    <div class="col-sm-12">
                        <button type="submit" class="btn btn-orange">Submit</button>
                    </div>
                </div>

                
            </form>
           </div>
       </div>
    </form>
</body>
</html>
