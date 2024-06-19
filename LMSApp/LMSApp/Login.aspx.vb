Imports System.Drawing
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblError.Visible = False
        DBInterface.SetUpConnection()
    End Sub

    Protected Sub loginBtn_Click(sender As Object, e As EventArgs)

        Session("LoggedIn") = False
        Dim user_ID As String = txtUsername.Text.Trim
        Dim user_password As String = txtPwd.Text.Trim
        'Dim user_category As String = txtRole.SelectedIndex

        '--Admin backend code--
        Dim this_user As User = this_user.load(user_ID)
        If this_user IsNot Nothing Then
            If this_user.role = 0 Then
                CheckUserAndGotoPage("Admin/Dashboard.aspx", this_user, user_ID, user_password)

            ElseIf this_user.role = 1 Then
                '--Student backend code--
                CheckUserAndGotoPage("Manager/Dashboard.aspx", this_user, user_ID, user_password)

            ElseIf this_user.role = 2 Then
                '--Marker backend code--
                CheckUserAndGotoPage("Facilitator/Dashboard.aspx", this_user, user_ID, user_password)

            ElseIf this_user.role = 3 Then
                '--Moderator backend code--
                CheckUserAndGotoPage("Student/Dashboard.aspx", this_user, user_ID, user_password)
            Else
                lblError.ForeColor = Color.Red
                lblError.Text = "Unknown User type. Please contact IT support or admin!"
                lblError.Visible = True
            End If
        Else
            lblError.ForeColor = Color.Red
            lblError.Text = "Student/Staff ID does not exist!"
            lblError.Visible = True
        End If

    End Sub

    Sub CheckUserAndGotoPage(pageurl As String, obj As User, userID As String, pwd As String)

        With obj
            Dim encrptedPassword As String = CipherGate.EncryptString(pwd, "toom9")

            If ((obj.emailID = userID) And (encrptedPassword = obj.password)) Then
                Session("User_name") = obj.FName + " " + obj.LName
                Session("Type") = obj.role
                Session("ID") = userID
                Session("LoggedIn") = True

                If Session("LoggedIn") = True Then
                    Response.Redirect(pageurl)
                End If

            Else
                lblError.ForeColor = Color.Red
                lblError.Text = "Incorrect Student/Staff ID or Password!"
                lblError.Visible = True
            End If
        End With

    End Sub

End Class