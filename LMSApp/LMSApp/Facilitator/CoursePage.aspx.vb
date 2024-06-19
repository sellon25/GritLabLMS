Imports System.Data.SqlClient

Namespace Facilitator



    Public Class CoursePage1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                ' Check if the courseId query string parameter exists
                If Request.QueryString("courseId") IsNot Nothing Then
                    Dim courseId As String = Request.QueryString("courseId").ToString()
                    Dim courseName As String = GetCourseName(courseId)
                    ' Set the page title to the course name
                    If Not String.IsNullOrEmpty(courseName) Then
                        Dim pageTitle As ContentPlaceHolder = TryCast(Me.Master.FindControl("Change_Breadcrumb_PageTitle"), ContentPlaceHolder)
                        If pageTitle IsNot Nothing Then
                            Dim title As New LiteralControl(courseName)
                            pageTitle.Controls.Add(title)
                        End If
                    End If

                Else
                    ' Redirect to an appropriate page if the courseId parameter is missing
                    Response.Redirect("~/ErrorPage.aspx")
                End If
            End If
        End Sub

        Private Function GetCourseName(courseId As String) As String
            Dim conn As SqlConnection = DirectCast(HttpContext.Current.Session("conn"), SqlConnection)
            conn.Close()
            Dim courseName As String = ""

            Dim query As String = "SELECT name FROM Course WHERE id = @courseId"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@courseId", courseId)
                conn.Open()
                Dim result As Object = cmd.ExecuteScalar()
                If result IsNot Nothing AndAlso result IsNot DBNull.Value Then
                    courseName = result.ToString()
                End If
            End Using

            Return courseName
        End Function

    End Class

End Namespace