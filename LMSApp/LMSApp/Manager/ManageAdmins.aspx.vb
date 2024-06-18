Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Windows


Public Class ManageAdmins
    Inherits System.Web.UI.Page


    Private strcon As String = ConfigurationManager.ConnectionStrings("lmsDBconstring").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Create a DataTable to hold the data
            Dim dt As New DataTable()
            Dim row1 As DataRow = dt.NewRow()

            ' Add columns to the DataTable
            dt.Columns.Add("admin_id")
            dt.Columns.Add("first_name")
            dt.Columns.Add("surname")
            dt.Columns.Add("date_of_birth")
            dt.Columns.Add("email_id")
            dt.Columns.Add("country")
            dt.Columns.Add("contact_no")
            dt.Columns.Add("gender")

            ' Add a hardcoded row to the DataTable
            Dim row As DataRow = dt.NewRow()
            row("admin_id") = "0504322345786"
            row("first_name") = "John"
            row("surname") = "Doe"
            row("date_of_birth") = "2002/07/17"
            row("email_id") = "JohnDoe@gmail.com"
            row("country") = "South Africa" ' Add this line to set the country value
            row("contact_no") = "0761435678" ' Add this line to set the country value
            row("gender") = "male" ' Add this line to set the country value

            row1("admin_id") = "04565655786"
            row1("first_name") = "Hulia"
            row1("surname") = "Hnn"
            row1("date_of_birth") = "2002/07/17"
            row1("email_id") = "JohnDoe@gmail.com"
            row1("country") = "South Africa" ' Add this line to set the country value
            row1("contact_no") = "0761435678" ' Add this line to set the country value
            row1("gender") = "male" ' Add this line to set the country value

            dt.Rows.Add(row)
            dt.Rows.Add(row1)

            ' Bind the DataTable to the GridView
            'GridView1.DataSource = dt
            'GridView1.DataBind()

        End If
    End Sub


    Private Sub DeleteAdmin()

        Try

            Using lmsDBconstring As New SqlConnection(strcon)

                lmsDBconstring.Open()

                Dim cmd As New SqlCommand("Delete From [Admin_SignUp] Where ID Number=@ID Number")

                cmd.Parameters.AddWithValue("@ID Number", TextBox1.Text.Trim())

                cmd.ExecuteNonQuery()

                Response.Write("<script>alert('Admin Deletes Successfully.');</script>")

            End Using

        Catch ex As Exception

            Response.Write("<script>alert('" & ex.Message & "');</script>")

        End Try


    End Sub

    Protected Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)

        DeleteAdmin()

    End Sub

    Protected Sub DeleteButton_Click1(sender As Object, e As EventArgs)

    End Sub
End Class