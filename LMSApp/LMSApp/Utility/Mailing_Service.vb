'Imports Microsoft.VisualBasic
''Imports System.Net.Mail
'Imports System.Web
'Imports System.Xml
'Imports System.Xml.Schema
'Imports System.Data
''----------------
'Imports System.IO
'Imports GemBox.Email
'Imports GemBox.Email.Smtp
''imagecompression
'Imports System
'Imports System.Drawing
'Imports System.Drawing.Imaging
''tree view

'Imports Microsoft.VisualBasic.FileIO
'Imports System.Guid

'Public Class Mailing
'    Public Shared dtsettings As New DataSet

'    'Shared Sub SendEmail(ByVal mailto As String, ByVal subject As String, ByVal body As String)
'    '    Dim smtpservername As String = dtsettings.Tables("mailsettings").Rows(0)("smtpserverip")
'    '    Dim smtpserverport As String = dtsettings.Tables("mailsettings").Rows(0)("smtpserverport")
'    '    Dim smtpfrom As String = dtsettings.Tables("mailsettings").Rows(0)("smtpfrom")
'    '    Dim smail As New SmtpClient
'    '    smail.Port = smtpserverport
'    '    smail.Host = smtpservername
'    '    smail.Send(smtpfrom, mailto, subject, body)
'    'End Sub

'    'Shared Sub SendEmailWithAttachment(ByVal mailto As String, ByVal cc As String, ByVal bcc As String, ByVal subject As String, ByVal body As String, ByVal attachments As Generic.List(Of String))
'    '    Dim smail As New SmtpClient, i As Integer
'    '    Dim smessage As New MailMessage
'    '    For i = 0 To attachments.Count - 1
'    '        smessage.Attachments.Add(New Attachment(attachments(i)))
'    '    Next
'    '    smail.Port = dtsettings.Tables("mailsettings").Rows(0)("smtpserverport")
'    '    smail.Host = dtsettings.Tables("mailsettings").Rows(0)("smtpserverip")
'    '    smail.DeliveryMethod = SmtpDeliveryMethod.Network
'    '    smail.Credentials = New System.Net.NetworkCredential("igottoomany", "toom9")
'    '    smessage.Body = body
'    '    smessage.To.Add(mailto)
'    '    If Not (ENTITY.checkNull(bcc) Is Nothing) Then
'    '        smessage.Bcc.Add(bcc)
'    '    End If
'    '    If Not (ENTITY.checkNull(bcc) Is Nothing) Then
'    '        smessage.CC.Add(cc)
'    '    End If
'    '    smessage.From = New System.Net.Mail.MailAddress(dtsettings.Tables("mailsettings").Rows(0)("replyto"), dtsettings.Tables("mailsettings").Rows(0)("smtpfrom"))
'    '    smessage.IsBodyHtml = False
'    '    smessage.Subject = subject
'    '    smail.Send(smessage)

'    'End Sub

'    'Automated welcome email //needs welcome text file
'    Public Shared Function Create_Welcome_Email(username As String, password As String) As String

'        Dim template As String = ""
'        Try
'            template = File.ReadAllText("welcome_message.txt")
'        Catch ex As Exception

'        End Try

'        template = template.Replace("<username>", username)
'        template = template.Replace("<password>", password)

'        Return template

'    End Function

'    Public Shared Sub Send_Email_To_Welcome_The_New_User(email As String, username As String)

'        ' If using Professional version, put your serial key below.
'        ComponentInfo.SetLicense("FREE-LIMITED-KEY")

'        ' Create new email message.
'        Dim message As New MailMessage(New MailAddress("keenanmoodley98p@gmail.com", "keenan"))

'        ' Add receivers.
'        message.Cc.Add(New MailAddress(email, username))

'        ' Add subject.
'        message.Subject = "Abeced"

'        'Calling Body method 
'        message.BodyText = Create_Welcome_Email("keenan", "anything123")


'        ' Create new SMTP client and send an email message.
'        Using smtp As New SmtpClient("smtp.gmail.com", 465)
'            smtp.Connect()

'            smtp.Authenticate("keenanmoodley98@gmail.com", "@KeenanM1998")
'            smtp.SendMessage(message)
'        End Using
'    End Sub
'    'Automated forgot password email
'    'Public Class Forgot_password
'    Public Shared rnd As New System.Random

'    Public Shared Function Create_Forgot_password_Email(username As String) As String
'        'Creates a random password 
'        Dim bank As String = "abcdefghijklmnpqrstuvwxyz0123456789ABCDEFGHJKLMNPQRSTUVWXYZ"

'        Dim pwd As String = ""

'        Do
'            Dim pickindex As Integer = rnd.Next(1, bank.Length)
'            pwd &= bank.Substring(pickindex, 1)
'        Loop Until (Len(pwd) = 8)

'        Dim template As String = ""
'        Try
'            template = File.ReadAllText("forgot_password_message.txt")
'        Catch ex As Exception

'        End Try

'        template = template.Replace("<username>", username)
'        template = template.Replace("<password>", pwd)
'        Return template
'    End Function

'    Public Shared Sub Send_Email_To_Change_User_Password(email As String, username As String)

'            ' If using Professional version, put your serial key below.
'            ComponentInfo.SetLicense("FREE-LIMITED-KEY")

'            ' Create new email message.
'            Dim message As New MailMessage(New MailAddress("keenanmoodley98p@gmail.com", "keenan"))

'            ' Add receivers.
'            message.Cc.Add(New MailAddress(email, username))

'            ' Add subject.
'            message.Subject = "Abeced"

'        'Calling Body method 
'        message.BodyText = Create_Forgot_password_Email("keenan")
'        ' Create new SMTP client and send an email message.
'        Using smtp As New SmtpClient("smtp.gmail.com", 465)
'                smtp.Connect()

'                smtp.Authenticate("keenanmoodley98@gmail.com", "@KeenanM1998")
'                smtp.SendMessage(message)
'            End Using
'        End Sub



'    End Class

