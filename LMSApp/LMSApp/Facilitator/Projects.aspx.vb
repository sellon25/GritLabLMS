Public Class Projects1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Type") IsNot Nothing AndAlso Session("Type").ToString() = "2" Then
                BindProjects()
            Else
                ' Redirect to an appropriate page if the user is not a facilitator
                Response.Redirect("~/Unauthorized.aspx")
            End If
        End If
    End Sub


    Private Sub BindProjects()
        Dim facilitatorId As String = Session("ID").ToString()

        ' Fetch   projects
        Dim projects As List(Of Project) = GetProjectsByFacilitator(facilitatorId)

        ' Bind projects
        For Each project As Project In projects
            ProjectsContainer.Controls.Add(CreateProjectHtml(project))
        Next
    End Sub

    Private Function CreateProjectHtml(project As Project) As HtmlAnchor
        Dim link As New HtmlAnchor()
        link.HRef = "ProjectPage.aspx?projectId=" & project.id
        link.Attributes("class") = "col-md-3"

        Dim projectBox As New HtmlGenericControl("div")
        projectBox.Attributes("class") = "white-box boxShadow coursebox"
        'projectBox.Style("background-image") = "url(" & GetProjectImageUrl(project.thumbnail) & ")"



        Dim nameLabel As New HtmlGenericControl("label")
        nameLabel.Attributes("class") = "box-title"
        nameLabel.InnerText = project.name

        Dim descriptionLabel As New HtmlGenericControl("p")
        descriptionLabel.Attributes("class") = "text-muted"
        descriptionLabel.InnerText = project.description

        projectBox.Controls.Add(nameLabel)
        projectBox.Controls.Add(descriptionLabel)
        link.Controls.Add(projectBox)

        Return link
    End Function

    Private Function GetProjectsByFacilitator(facilitatorId As String) As List(Of Project)
        Dim filter As String = "WHERE userId = '" & facilitatorId & "'"
        Dim projectEnrollments As List(Of Project_Enrollment) = New Project_Enrollment().listall(filter)
        Dim facilitatorProjects As New List(Of Project)

        For Each enrollment As Project_Enrollment In projectEnrollments
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
        Return "../plugins/images/Squid-Game-1.jpg" ' Default image URL for projects
    End Function
End Class