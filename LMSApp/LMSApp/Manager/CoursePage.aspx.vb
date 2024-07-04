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
                ' Check if CourseName and CourseId are provided in query string
                Dim courseName As String = Request.QueryString("CourseName")
                Dim courseId As String = Request.QueryString("CourseId")

                If Not String.IsNullOrEmpty(courseName) Then
                    lblCourseName.InnerText = courseName
                Else
                    lblCourseName.InnerText = "Course Details"
                End If

                If Not String.IsNullOrEmpty(courseId) Then
                    ' Bind dynamic content based on the course ID
                    BindTestsAndAssignments(courseId)
                Else
                    ' Handle case where CourseId is not provided
                    ' Optionally, display a message or take another action
                End If
            End If
        End Sub

        Protected Sub AcceptReject_Click(ByVal sender As Object, ByVal e As EventArgs)
            ' Handle course approval/rejection logic here
            Try
                Dim CourseName As String = lblCourseName.InnerText ' or use the course ID if available
                Dim courseId As String = Request.QueryString("CourseId")

                If String.IsNullOrEmpty(CourseName) OrElse String.IsNullOrEmpty(courseId) Then
                    Throw New Exception("Course Name and Course ID are Required.")
                End If

                ' Find the course by ID
                Dim courses As List(Of Course) = Course.listall($"WHERE id = '{courseId}'")

                If courses.Count = 0 Then
                    Throw New Exception("Course Not Found.")
                End If

                ' Take the first course found with the given ID
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

        Private Sub BindTestsAndAssignments(ByVal courseId As String)
            Try
                ' Assuming Test is a class and listall is a method that returns a List(Of Test)
                Dim TestAssignments As List(Of Test) = Test.listall($"WHERE course_id = '{courseId}' ORDER BY date_started DESC")

                If TestAssignments IsNot Nothing AndAlso TestAssignments.Count > 0 Then
                    ' Sort assignments and tasks by datetime in descending order
                    AssignmentsContainer.Controls.Clear()

                    For Each assignment As Test In TestAssignments
                        Dim newAssignmentDiv As New HtmlGenericControl("div")
                        newAssignmentDiv.Attributes("class") = "d-flex flex-row comment-row p-3 mt-0 white-box boxShadow"

                        Dim iconDiv As New HtmlGenericControl("div")
                        iconDiv.Attributes("class") = "p-2"
                        iconDiv.InnerHtml = $"<i class='far fa-file-alt text-black' style='font-size: 26px;'></i>"
                        newAssignmentDiv.Controls.Add(iconDiv)

                        Dim textDiv As New HtmlGenericControl("div")
                        textDiv.Attributes("class") = "comment-text ps-2 ps-md-3 w-100 text-black"
                        textDiv.InnerHtml = $"<h5 class='font-medium'>{Server.HtmlEncode(assignment.title)}</h5>" &
                                            $"<span class='mb-3 d-block'>{Server.HtmlEncode(assignment.date_started)}</span>" &
                                            $"<div class='text-muted fs-2 ms-auto mt-2 mt-md-0'><span>Due:</span> {assignment.end_date:MMMM dd, yyyy}</div>"
                        newAssignmentDiv.Controls.Add(textDiv)

                        AssignmentsContainer.Controls.Add(newAssignmentDiv)
                    Next
                Else
                    Dim noAssignmentsDiv As New HtmlGenericControl("p")
                    noAssignmentsDiv.InnerHtml = "No assignments and tasks available."
                    AssignmentsContainer.Controls.Add(noAssignmentsDiv)
                End If
            Catch ex As Exception
                ' Handle exceptions
                Dim errorDiv As New HtmlGenericControl("p")
                errorDiv.InnerHtml = "Error loading assignments and tasks."
                AssignmentsContainer.Controls.Add(errorDiv)
            End Try
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
