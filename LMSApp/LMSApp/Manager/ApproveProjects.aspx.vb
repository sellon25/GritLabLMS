Public Class ApproveProjects
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindCourses()
        End If
    End Sub

    Private Sub BindCourses()
        Try
            ' Load approved courses (status = 1)
            Dim approvedProjects As List(Of Project) = Project.listall("WHERE status = 1")
            ' Load not approved courses (status = 0)
            Dim notApprovedProjects As List(Of Project) = Project.listall("WHERE status = 0")
            Dim courseHtml As New System.Text.StringBuilder()

            ' Display approved courses
            If approvedProjects IsNot Nothing AndAlso approvedProjects.Count > 0 Then
                courseHtml.Append("<h3 class='box-title'>Approved Projects</h3>")
                For Each Projects As Project In approvedProjects
                    courseHtml.Append("<div class='col-md-3'>")
                    courseHtml.AppendFormat("<a href='ProjectsPage.aspx?ProjectID={0}'>", HttpUtility.UrlEncode(Projects.id))
                    courseHtml.Append("<div class='white-box boxShadow coursebox'>")
                    courseHtml.Append("<div class='description'>")
                    courseHtml.AppendFormat("<label class='box-title'>{0}</label>", Projects.name)
                    courseHtml.Append("</div>")
                    courseHtml.Append("</div>")
                    courseHtml.Append("</a>")
                    courseHtml.Append("</div>")
                Next
            Else
                courseHtml.Append("<p>No approved courses available.</p>")
            End If

            ' Display not approved courses
            If notApprovedProjects IsNot Nothing AndAlso notApprovedProjects.Count > 0 Then
                courseHtml.Append("<h3 class='box-title'>Not Approved Courses</h3>")
                For Each Projects As Project In notApprovedProjects
                    courseHtml.Append("<div class='col-md-3'>")
                    courseHtml.AppendFormat("<a href='ProjectsPage.aspx?ProjectID={0}'>", HttpUtility.UrlEncode(Projects.id))
                    courseHtml.Append("<div class='white-box boxShadow coursebox'>")
                    courseHtml.Append("<div class='description'>")
                    courseHtml.AppendFormat("<label class='box-title'>{0}</label>", Projects.name)
                    courseHtml.AppendFormat("<p class='text-muted'>{0}</p>", "")
                    courseHtml.Append("</div>")
                    courseHtml.Append("</div>")
                    courseHtml.Append("</a>")
                    courseHtml.Append("</div>")
                Next
            Else
                courseHtml.Append("<p>No not approved project available.</p>")
            End If

            ProjectsContainer.InnerHtml = courseHtml.ToString()
        Catch ex As Exception
            ' Handle exceptions (e.g., log them)
            ProjectsContainer.InnerHtml = "<p>Error loading projects.</p>"
            System.Diagnostics.Debug.WriteLine($"Error loading projects: {ex.Message}")
        End Try
    End Sub

    Private Function GetCourseById(projectId As String) As Course
        Try
            Return Course.load(projectId)
        Catch ex As Exception
            ' Handle exception or log error
            System.Diagnostics.Debug.WriteLine($"Error loading project with ID {projectId}: {ex.Message}")
            Return Nothing
        End Try
    End Function

    ' JavaScript function to show course details in modal
    '<System.Web.Services.WebMethod()>
    'Public Shared Function GetCourseDetails(courseId As String) As Course
    '    Dim approveCourses As New ApproveCourses()
    '    Return approveCourses.GetCourseById(courseId)
    'End Function

    '' Accept/Reject button click handler
    'Protected Sub AcceptReject_Click(sender As Object, e As EventArgs)
    '    BindCourses()
    'End Sub

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

    Public Function GetContentImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso Not Convert.IsDBNull(thumbnail) Then
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        Return "../plugins/images/default-content.jpg" ' Default image URL for content
    End Function


End Class