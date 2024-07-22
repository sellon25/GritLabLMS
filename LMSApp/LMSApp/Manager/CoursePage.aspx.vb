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
                Dim courseId As String = Request.QueryString("CourseID")
                Dim course As Course = Course.load(courseId)

                If course IsNot Nothing Then
                    lblCourseName.InnerText = course.name
                    BindTestsAndAssignments(courseId)
                    LoadCourseOverview(courseId)
                    LoadCourseResources(courseId)
                Else
                    lblCourseName.InnerText = "Course Details"
                End If
            End If
        End Sub

        Protected Sub AcceptReject_Click(ByVal sender As Object, ByVal e As EventArgs)
            Try
                Dim courseId As String = Request.QueryString("CourseID")
                Dim course As Course = Course.load(courseId)

                If course Is Nothing Then
                    Throw New Exception("Course Not Found.")
                End If

                Dim approverejectstr As String = Request.Form("bulkActions")
                Dim approvereject As Integer = GetTypeValue(approverejectstr)

                course.status = approvereject
                course.update()

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Course has been approved/rejected.');", True)
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine($"Error accepting/rejecting course: {ex.Message}")
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Error: {ex.Message}');", True)
            End Try

            Response.Redirect("ApproveCourses.aspx")
        End Sub

        Private Sub BindTestsAndAssignments(ByVal courseId As String)
            Try
                Dim TestAssignments As List(Of Test) = Test.listall($"WHERE course_id = '{courseId}' ORDER BY date_started DESC")

                If TestAssignments IsNot Nothing AndAlso TestAssignments.Count > 0 Then
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
                Dim errorDiv As New HtmlGenericControl("p")
                errorDiv.InnerHtml = "Error loading assignments and tasks."
                AssignmentsContainer.Controls.Add(errorDiv)
            End Try
        End Sub

        Private Sub LoadCourseOverview(ByVal courseId As String)
            Try
                Dim selectedCourse As Course = Course.load(courseId)
                Dim courseOverviewHtml As New System.Text.StringBuilder()

                If selectedCourse IsNot Nothing Then
                    courseOverviewHtml.AppendLine("<h3 class='box-title' style='font-weight: bold;'>Course Overview</h3>")
                    courseOverviewHtml.AppendLine("<p><strong>Description: </strong>" & Server.HtmlEncode(selectedCourse.description) & "</p>")
                    courseOverviewHtml.AppendLine("<p><strong>Overview: </strong>" & Server.HtmlEncode(selectedCourse.overview) & "</p>")
                    courseOverviewHtml.AppendLine("<p><strong>End Date: </strong>" & Server.HtmlEncode(selectedCourse.end_date) & "</p>")

                Else
                    CourseOverviewContainer.Controls.Add(New LiteralControl("<p>Course overview not available.</p>"))
                End If

                CourseOverviewContainer.Controls.Add(New LiteralControl(courseOverviewHtml.ToString()))

            Catch ex As Exception
                Dim errorDiv As New HtmlGenericControl("p")
                errorDiv.InnerHtml = "Error loading course overview."
                CourseOverviewContainer.Controls.Add(errorDiv)
            End Try
        End Sub

        Private Sub LoadCourseResources(ByVal courseId As String)
            Dim selectedCourse As Course = Course.load(courseId)
            Dim resourcesHtml As New StringBuilder()
            resourcesHtml.AppendLine("<h3 class='box-title' style='font-weight: bold;'>Course Resources</h3>")
            resourcesHtml.AppendLine("<ul style='list-style-type: none; padding-left: 0;'>")
            resourcesHtml.AppendFormat("<li><a href='ContentPage.aspx?CourseID={0}'>Course Content</a></li>", HttpUtility.UrlEncode(selectedCourse.id))
            resourcesHtml.AppendLine("<li><a href='CourseFacilitators.aspx'>Course Facilitators</a></li>")
            resourcesHtml.AppendLine("</ul>")

            CourseResourcesContainer.Controls.Add(New LiteralControl(resourcesHtml.ToString()))
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
End Namespace
