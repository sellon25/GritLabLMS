Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class ApproveCourses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindCourses()
        End If
    End Sub

    Private Sub BindCourses()
        Try
            ' Load approved courses (status = 1)
            Dim approvedCourses As List(Of Course) = Course.listall("WHERE status = 1")
            ' Load not approved courses (status = 0)
            Dim notApprovedCourses As List(Of Course) = Course.listall("WHERE status = 0")
            Dim courseHtml As New System.Text.StringBuilder()

            ' Display approved courses
            If approvedCourses IsNot Nothing AndAlso approvedCourses.Count > 0 Then
                courseHtml.Append("<h3 class='box-title'>Approved Courses</h3>")
                For Each course As Course In approvedCourses
                    courseHtml.Append("<div class='col-md-3'>")
                    courseHtml.AppendFormat("<a href='CoursePage.aspx?CourseName={0}'>", HttpUtility.UrlEncode(course.name))
                    courseHtml.Append("<div class='white-box boxShadow coursebox'>")
                    courseHtml.Append("<div class='description'>")
                    courseHtml.AppendFormat("<label class='box-title'>{0}</label>", course.name)
                    courseHtml.AppendFormat("<p class='text-muted'>{0}</p>", course.id)
                    courseHtml.Append("</div>")
                    courseHtml.Append("</div>")
                    courseHtml.Append("</a>")
                    courseHtml.Append("</div>")
                Next
            Else
                courseHtml.Append("<p>No approved courses available.</p>")
            End If

            ' Display not approved courses
            If notApprovedCourses IsNot Nothing AndAlso notApprovedCourses.Count > 0 Then
                courseHtml.Append("<h3 class='box-title'>Not Approved Courses</h3>")
                For Each course As Course In notApprovedCourses
                    courseHtml.Append("<div class='col-md-3'>")
                    ' Add onclick event to set the search input value
                    courseHtml.AppendFormat("<a href='#' onclick=""setSearchInput('{0}')"">", HttpUtility.UrlEncode(course.name))
                    courseHtml.Append("<div class='white-box boxShadow coursebox'>")
                    courseHtml.Append("<div class='description'>")
                    courseHtml.AppendFormat("<label class='box-title'>{0}</label>", course.name)
                    courseHtml.AppendFormat("<p class='text-muted'>{0}</p>", course.id)
                    courseHtml.Append("</div>")
                    courseHtml.Append("</div>")
                    courseHtml.Append("</a>")
                    courseHtml.Append("</div>")
                Next
            Else
                courseHtml.Append("<p>No not approved courses available.</p>")
            End If

            CoursesContainer.InnerHtml = courseHtml.ToString()
        Catch ex As Exception
            ' Handle exceptions (e.g., log them)
            CoursesContainer.InnerHtml = "<p>Error loading courses.</p>"
            System.Diagnostics.Debug.WriteLine($"Error loading courses: {ex.Message}")
        End Try
    End Sub

    Private Function GetCourseById(courseId As String) As Course
        Try
            Return Course.load(courseId)
        Catch ex As Exception
            ' Handle exception or log error
            System.Diagnostics.Debug.WriteLine($"Error loading course with ID {courseId}: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ' JavaScript function to show course details in modal
    <System.Web.Services.WebMethod()>
    Public Shared Function GetCourseDetails(courseId As String) As Course
        Dim approveCourses As New ApproveCourses()
        Return approveCourses.GetCourseById(courseId)
    End Function

    ' Accept/Reject button click handler
    Protected Sub AcceptReject_Click(sender As Object, e As EventArgs)
        AcceptRejectCourses()
        BindCourses()
    End Sub

    ' Accept/Reject action handler
    Public Sub AcceptRejectCourses()
        Try
            If Session("LoggedIn") Is Nothing OrElse Not CType(Session("LoggedIn"), Boolean) Then
                Throw New Exception("User Not Logged In.")
            End If

            Dim CourseName As String = searchInput.Value.Trim()

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
            Response.Write("<script>alert('Course has been approved/rejected.');</script>")

            ' Refresh the course list after action
            BindCourses()

        Catch ex As Exception
            ' Handle exceptions (e.g., log them, display an error message)
            System.Diagnostics.Debug.WriteLine($"Error accepting/rejecting course: {ex.Message}")
            Response.Write($"<script>alert('Error: {ex.Message}');</script>")
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

End Class
