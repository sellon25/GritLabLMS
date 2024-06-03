Imports System.Net.Mail
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
        e_mail.Body = "You have requested to change the password to your  Account: " + Email + Environment.NewLine + "Your OTP:" + OTP.ToString() + Environment.NewLine + Environment.NewLine + "Kind regards" + Environment.NewLine + "Chieta Team"
        'Goto OTP Page
        Smtp_Server.Send(e_mail)
    End Sub

    Public Sub SendOTP(Email)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("chietawebapp@gmail.com", "ygigfqjsqysumxvh")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress("chietawebapp@gmail.com")
        e_mail.To.Add(Email)
        e_mail.Subject = "Password Reset"
        e_mail.IsBodyHtml = False
        e_mail.Body = "Your password for Account: " + Email + " has been reset successfully" + Environment.NewLine + Environment.NewLine + "Kind regards" + Environment.NewLine + "Chieta Team"
        'Goto OTP Page
        Smtp_Server.Send(e_mail)
    End Sub
End Class
