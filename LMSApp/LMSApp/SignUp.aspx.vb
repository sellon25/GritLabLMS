Imports System.Drawing

Public Class SignUp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LblError.Visible = False
    End Sub

    Protected Sub Register_Click(sender As Object, e As EventArgs)
        Dim NewUser As New User
        If (userpassword.Value.Trim() = userconfirmp.Value.Trim()) Then
            Dim encrytptedpass As String = CipherGate.EncryptString("inovalabs09", userpassword.Value)

            With NewUser
                .emailID = useremail.Value
                .FName = userfname.Value
                .LName = userlname.Value
                .password = encrytptedpass
                .role = 3
                .status = "New Applicant"
                .update()
            End With
        Else
            LblError.Text = "Passwords do not match!"
            LblError.ForeColor = Color.Red
            LblError.Visible = True
        End If
    End Sub
End Class