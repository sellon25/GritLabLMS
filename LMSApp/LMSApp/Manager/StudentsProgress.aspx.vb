Imports System.Net.Mail

Public Class StudentsProgress
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSendEmail_Click(ByVal sender As Object, ByVal e As EventArgs)

        Dim email As String = SendToEmail.Value
        Dim subject As String = Subjects.Value
        Dim body As String = EmailBody.Value

        SendGenericEmail(email, subject, body)
    End Sub

    Public Sub SendGenericEmail(Email As String, Subject As String, Body As String)
        Dim Smtp_Server As New SmtpClient
        Dim e_mail As New MailMessage()
        Smtp_Server.UseDefaultCredentials = False
        Smtp_Server.Credentials = New Net.NetworkCredential("your-email@gmail.com", "your-email-password")
        Smtp_Server.Port = 587
        Smtp_Server.EnableSsl = True
        Smtp_Server.Host = "smtp.gmail.com"

        e_mail = New MailMessage()
        e_mail.From = New MailAddress("your-email@gmail.com")
        e_mail.To.Add(Email)
        e_mail.Subject = Subject
        e_mail.IsBodyHtml = False
        e_mail.Body = Body

        Smtp_Server.Send(e_mail)
    End Sub

End Class

