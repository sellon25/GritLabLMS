Imports System.Net.Mail

Partial Public Class Kingsman
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        MsgBox("Hello World")

        ' Retrieve input values from the form
        Dim recipientEmail As String = email.Text.Trim()
        Dim emailType As String = type.Text.Trim()
        Dim emailBody As String = body.Text.Trim()

        ' Validate input (you can add more validation as per your requirements)
        If String.IsNullOrEmpty(recipientEmail) OrElse String.IsNullOrEmpty(emailType) OrElse String.IsNullOrEmpty(emailBody) Then
            ' Handle validation failure (e.g., show error message)
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Please fill in all fields.');", True)
            Return
        End If

        ' Prepare to send email
        Dim sendEmailHelper As New SendEmail()

        Try
            ' Determine which email type to send
            Select Case emailType.ToLower()
                Case "forgotpassword"
                    Dim otp As String = GenerateOTP() ' Generate OTP here (if needed)
                    sendEmailHelper.SendForgotPassword(recipientEmail, otp)
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Forgot Password email sent successfully.');", True)
                Case "resetnotification"
                    sendEmailHelper.SendOTP(recipientEmail)
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Reset Notification email sent successfully.');", True)
                Case Else
                    ' Handle unsupported email type
                    ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Unsupported email type.');", True)
            End Select
        Catch ex As Exception
            ' Handle exceptions (e.g., log error, show error message)
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Failed to send email: " & ex.Message & "');", True)
        End Try
    End Sub

    Private Function GenerateOTP() As String
        ' Generate OTP logic here (if required)
        ' Example: Dim otp As String = "123456"
        Return "123456"

    End Function

End Class
