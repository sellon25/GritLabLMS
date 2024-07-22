Imports System.Net.Mail
Imports System.Web.Services.Description

Public Class SendEmail
    Public Sub SendForgotPassword(Email, OTP)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("chietawebapp@gmail.com", "madfhywjgtqhwuqd")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress("chietawebapp@gmail.com")
        'e_mail.To.Add("dsaujapp@gmail.com")
        e_mail.To.Add(Email)
        e_mail.Subject = "Reset Password Notification"

        e_mail.IsBodyHtml = False
        e_mail.Body = "You have requested to change the password to your  Account: " + Email + Environment.NewLine + "Your OTP:" + OTP.ToString() + Environment.NewLine + Environment.NewLine + "Kind regards" + Environment.NewLine + "Grits Lab Team"
        'Goto OTP Page
        Smtp_Server.Send(e_mail)
    End Sub

    Public Sub SendOTP(Email)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("gritslabapp@gmail.com", "ygigfqjsqysumxvh")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress("chietawebapp@gmail.com")
        e_mail.To.Add(Email)
        e_mail.Subject = "Password Reset"
        e_mail.IsBodyHtml = False
        e_mail.Body = "Your password for Account: " + Email + " has been reset successfully" + Environment.NewLine + Environment.NewLine + "Kind regards" + Environment.NewLine + "Grits Lab Team"
        'Goto OTP Page
        Smtp_Server.Send(e_mail)
    End Sub

    Public Sub SendNotification(userId As String, message As String)



        Dim User As User = New User().load(userId)

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Dim sb As New StringBuilder
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("chietawebapp@gmail.com", "madfhywjgtqhwuqd")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress("chietawebapp@gmail.com")
        e_mail.To.Add("russellmasimba8@gmail.com")

        e_mail.Subject = "Grits Lab App Notification"

        e_mail.IsBodyHtml = True
        Dim link = "https://ulink.uj.ac.za/Default"
        Dim logoPath As String = "https://gritlabafrica.org/wp-content/uploads/2023/12/screenshot-2023-12-05-064309.png"
        Dim Body1 As String = "<html>" & vbCrLf &
            "<body style=""font-family: Arial, sans-serif; text-align: center; background-color: #f4f4f4; padding: 20px;"">" & vbCrLf &
            "    <div style=""background-color: #fff; padding: 20px; border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);"">" & vbCrLf &
            "        <img src=""" & logoPath & """ alt=""Logo"" style=""width: 200px; height: auto; margin-bottom: 20px;""><br>" & vbCrLf &
            $"        <h4 style=""color: #333; margin-bottom: 20px;"">Notification from Grits Lab Africa</h2>" & vbCrLf &
            $"        <p>Dear {User.FName} {User.LName},</p>" & vbCrLf &
            "        <p>We trust this email finds you well.</p>" & vbCrLf &
            $"        <p>You have received a new notification on the Grits Lab app. To read it, please log in through Ulink:</p>" & vbCrLf &
            $"        <div style=""background-color: #93761e; color: #fff; padding: 15px; border-radius: 5px; margin: 15px 0; display: inline-block;"">{message}</div>" & vbCrLf &
            "    <p><a href=""" & link & """style=""background-color: #93761e; color: #fff; padding: 10px 20px; text-decoration: none; border-radius: 5px; margin-top: 10px; margin-bottom: 10px;"">Read</a></p>" & vbCrLf &
            "        <p>If you have any questions or concerns, please don't hesitate to contact us.</p>" & vbCrLf &
            "        <p>Thank you for your participation.</p>" & vbCrLf &
            "        <p>Sincerely,<br>Grits Lab App</p>" & vbCrLf &
            "    </div>" & vbCrLf &
            "</body>" & vbCrLf &
        "</html>"



        e_mail.Body = Body1
        Smtp_Server.Send(e_mail)
    End Sub


    Public Sub SendNotification(userId As String, subject As String, message As String)



        Dim User As User = New User().load(userId)

        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Dim sb As New StringBuilder
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("chietawebapp@gmail.com", "madfhywjgtqhwuqd")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress("chietawebapp@gmail.com")
        e_mail.To.Add("russellmasimba8@gmail.com")

        e_mail.Subject = subject

        e_mail.IsBodyHtml = True
        Dim link = "https://ulink.uj.ac.za/Default"
        Dim logoPath As String = "https://gritlabafrica.org/wp-content/uploads/2023/12/screenshot-2023-12-05-064309.png"
        Dim Body1 As String = "<html>" & vbCrLf &
            "<body style=""font-family: Arial, sans-serif; text-align: center; background-color: #f4f4f4; padding: 20px;"">" & vbCrLf &
            "    <div style=""background-color: #fff; padding: 20px; border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);"">" & vbCrLf &
            "        <img src=""" & logoPath & """ alt=""Logo"" style=""width: 200px; height: auto; margin-bottom: 20px;""><br>" & vbCrLf &
            $"        <h4 style=""color: #333; margin-bottom: 20px;"">Notification from Grits Lab Africa</h2>" & vbCrLf &
            $"        <p>Dear {User.FName} {User.LName},</p>" & vbCrLf &
            "        <p>We trust this email finds you well.</p>" & vbCrLf &
            $"        <p>You have received a new notification on the Grits Lab app. To read it, please log in through Ulink:</p>" & vbCrLf &
            $"        <div style=""background-color: #93761e; color: #fff; padding: 15px; border-radius: 5px; margin: 15px 0; display: inline-block;"">{message}</div>" & vbCrLf &
            "    <p><a href=""" & link & """style=""background-color: #93761e; color: #fff; padding: 10px 20px; text-decoration: none; border-radius: 5px; margin-top: 10px; margin-bottom: 10px;"">Read</a></p>" & vbCrLf &
            "        <p>If you have any questions or concerns, please don't hesitate to contact us.</p>" & vbCrLf &
            "        <p>Thank you for your participation.</p>" & vbCrLf &
            "        <p>Sincerely,<br>Grits Lab App</p>" & vbCrLf &
            "    </div>" & vbCrLf &
            "</body>" & vbCrLf &
        "</html>"



        e_mail.Body = Body1
        Smtp_Server.Send(e_mail)
    End Sub
End Class
