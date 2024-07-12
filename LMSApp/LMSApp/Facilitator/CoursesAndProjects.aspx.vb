Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class CoursesAndProjects
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Type") IsNot Nothing AndAlso Session("Type").ToString() = "2" Then
                BindCoursesAndProjects()
            Else
                ' Redirect to an appropriate page if the user is not a facilitator
                Response.Redirect("~/Unauthorized.aspx")
            End If
        End If
    End Sub

    Private Sub BindCoursesAndProjects()
        Dim facilitatorId As String = Session("ID").ToString()

        ' Fetch courses and projects
        Dim courses As List(Of Course) = GetCoursesByFacilitator(facilitatorId)
        Dim projects As List(Of Project) = GetProjectsByFacilitator(facilitatorId)

        ' Bind courses
        For Each course As Course In courses
            Dim link As New HtmlAnchor()
            link.HRef = "CoursePage.aspx?courseId=" & course.id
            link.Attributes("class") = "col-md-3"

            Dim courseBox As New HtmlGenericControl("div")
            courseBox.Attributes("class") = "white-box boxShadow coursebox"
            courseBox.Style("background-image") = "url(" & GetImageUrl(course.thumbnail) & ")"

            Dim nameLabel As New Label()
            nameLabel.Attributes("class") = "box-title"
            nameLabel.Text = course.name

            Dim descriptionLabel As New Label()
            descriptionLabel.Attributes("class") = "text-muted"
            descriptionLabel.Text = course.description

            courseBox.Controls.Add(nameLabel)
            courseBox.Controls.Add(descriptionLabel)
            link.Controls.Add(courseBox)

            CoursesRepeater.Controls.Add(link)
        Next

        ' Bind projects
        For Each project As Project In projects
            Dim link As New HtmlAnchor()
            link.HRef = "ProjectPage.aspx?projectId=" & project.id
            link.Attributes("class") = "col-md-3"

            Dim projectBox As New HtmlGenericControl("div")
            projectBox.Attributes("class") = "white-box boxShadow coursebox"
            'projectBox.Style("background-image") = "url(" & GetProjectImageUrl(project.thumbnail) & ")"

            Dim nameLabel As New Label()
            nameLabel.Attributes("class") = "box-title"
            nameLabel.Text = project.name

            Dim descriptionLabel As New Label()
            descriptionLabel.Attributes("class") = "text-muted"
            descriptionLabel.Text = project.description

            projectBox.Controls.Add(nameLabel)
            projectBox.Controls.Add(descriptionLabel)
            link.Controls.Add(projectBox)

            ProjectsRepeater.Controls.Add(link)
        Next
    End Sub

    Private Function GetCoursesByFacilitator(facilitatorId As String) As List(Of Course)
        Dim filter As String = "WHERE userId = '" & facilitatorId & "'"
        Dim Course_Enrollments As List(Of Course_Enrollment) = New Course_Enrollment().listall(filter)
        Dim facilitatorCourses As New List(Of Course)

        For Each enrollment As Course_Enrollment In Course_Enrollments
            Dim course As Course = Course.load(enrollment.course_id)
            If course IsNot Nothing Then
                course.name = Trim(course.name)
                facilitatorCourses.Add(course)
            End If
        Next

        Return facilitatorCourses
    End Function

    Private Function GetProjectsByFacilitator(facilitatorId As String) As List(Of Project)
        Dim filter As String = "WHERE userId = '" & facilitatorId & "'"
        Dim Project_Enrollments As List(Of Project_Enrollment) = New Project_Enrollment().listall(filter)
        Dim facilitatorProjects As New List(Of Project)

        For Each enrollment As Project_Enrollment In Project_Enrollments
            Dim project As Project = Project.load(enrollment.project_id)
            If project IsNot Nothing Then
                project.name = Trim(project.name)
                facilitatorProjects.Add(project)
            End If
        Next

        Return facilitatorProjects
    End Function

    Public Function GetImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso Not Convert.IsDBNull(thumbnail) Then
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        Return "../plugins/images/sldr.jpg" ' Default image URL for courses
    End Function

    Public Function GetProjectImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso Not Convert.IsDBNull(thumbnail) Then
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        Return "../plugins/images/Squid-Game-1.jpg" ' Default image URL for projects
    End Function
End Class
