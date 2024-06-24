Public Class Courses2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Type") IsNot Nothing AndAlso Session("Type").ToString() = "2" Then
                BindCourses()
            Else
                ' Redirect to an appropriate page if the user is not a facilitator
                Response.Redirect("~/Unauthorized.aspx")
            End If
        End If
    End Sub

    Private Sub BindCourses()
        Dim facilitatorId As String = Session("ID").ToString()

        ' Fetch courses and projects
        Dim courses As List(Of Course) = GetCoursesByFacilitator(facilitatorId)

        ' Bind courses
        For Each course As Course In courses
            CoursesContainer.Controls.Add(CreateCourseHtml(course))
        Next
    End Sub

    Private Function CreateCourseHtml(course As Course) As HtmlAnchor
        Dim link As New HtmlAnchor()
        link.HRef = "CoursePage.aspx?courseId=" & course.id
        link.Attributes("class") = "col-md-3"

        Dim courseBox As New HtmlGenericControl("div")
        courseBox.Attributes("class") = "white-box boxShadow coursebox"
        courseBox.Style("background-image") = "url(" & GetImageUrl(course.thumbnail) & ")"

        Dim nameLabel As New HtmlGenericControl("label")
        nameLabel.Attributes("class") = "box-title"
        nameLabel.InnerText = course.name

        Dim descriptionLabel As New HtmlGenericControl("p")
        descriptionLabel.Attributes("class") = "text-muted"
        descriptionLabel.InnerText = course.description

        Dim descriptionBox As New HtmlGenericControl("div")
        descriptionBox.Attributes("class") = "description"
        descriptionBox.Controls.Add(nameLabel)
        descriptionBox.Controls.Add(descriptionLabel)

        'courseBox.Controls.Add(nameLabel)
        courseBox.Controls.Add(descriptionBox)
        link.Controls.Add(courseBox)

        Return link
    End Function

    Private Function GetCoursesByFacilitator(facilitatorId As String) As List(Of Course)
        Dim filter As String = "WHERE userId = '" & facilitatorId & "'"
        Dim courseEnrollments As List(Of Course_Enrollment) = New Course_Enrollment().listall(filter)
        Dim facilitatorCourses As New List(Of Course)

        For Each enrollment As Course_Enrollment In courseEnrollments
            Dim course As Course = Course.load(enrollment.course_id)
            If course IsNot Nothing Then
                course.name = Trim(course.name)
                facilitatorCourses.Add(course)
            End If
        Next

        Return facilitatorCourses
    End Function

    Public Function GetImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso Not Convert.IsDBNull(thumbnail) Then
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        Return "../plugins/images/sldr.jpg" ' Default image URL for courses
    End Function

End Class