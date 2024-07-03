Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Manager
    Public Class CoursePage1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                ' Check if CourseName is provided in query string
                If Not String.IsNullOrEmpty(Request.QueryString("CourseName")) Then
                    Dim courseName As String = Request.QueryString("CourseName")
                    lblCourseName.InnerText = courseName
                Else
                    ' Handle case where CourseName is not provided
                    lblCourseName.InnerText = "Course Details"
                End If
            End If
        End Sub

        Protected Sub AcceptReject_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Handle course approval/rejection logic here
            Try
                Dim CourseName As String = lblCourseName.InnerText ' or use the course ID if available

                If String.IsNullOrEmpty(CourseName) Then
                    Throw New Exception("Course Name Is Required.")
                End If

                ' Find the course by name
                Dim courses As List(Of Course) = Course.listall($"WHERE name = '{CourseName}'")
                If courses.Count = 0 Then
                    Throw New Exception("Course Not Found.")
                End If

                ' Take the first course found with the given name
                Dim selectedCourse As Course = courses(0)

                ' Determine the action (approve/reject)
                Dim approverejectstr As String = Request.Form("bulkActions")
                Dim approvereject As Integer = GetTypeValue(approverejectstr)

                ' Update the status in memory
                selectedCourse.status = approvereject

                ' Log the current status for debugging
                System.Diagnostics.Debug.WriteLine($"Current status of course '{selectedCourse.name}' before update: {selectedCourse.status}")

                ' Update the course status in the database
                selectedCourse.update()

                ' Log confirmation of status update
                System.Diagnostics.Debug.WriteLine($"Status of course '{selectedCourse.name}' after update: {selectedCourse.status}")

                ' Optionally, provide a success message to the user
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Course has been approved/rejected.');", True)

            Catch ex As Exception
                ' Handle exceptions (e.g., log them, display an error message)
                System.Diagnostics.Debug.WriteLine($"Error accepting/rejecting course: {ex.Message}")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Error: {ex.Message}');", True)
            End Try

            Response.Redirect("ApproveCourses.aspx")

        End Sub

        Private Function GetTypeValue(ByVal bulk As String) As Integer
            Select Case bulk
                Case "Reject"
                    Return 0
                Case "Approve"
                    Return 1
                Case Else
                    Throw New Exception("Invalid Action Selected.")
            End Select
        End Function

        ' Other methods and functions specific to CoursePage.aspx.vb can be placed here
    End Class
End Namespace
