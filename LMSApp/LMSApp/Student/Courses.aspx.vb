Public Class Courses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then
            Session("Type") = "3"
            If Session("Type").ToString() = "3" Then
                ' loadcourses(Session("Id").ToString())
                loadcourses("student@g.com")
            Else
                ' Redirect to an appropriate page if the user is not a student
                Response.Redirect("~/Unauthorized.aspx")
            End If

        End If
    End Sub

    Private Sub loadcourses(student_id As String)
        'Dim student_id As String = Session("ID").ToString()

        ' Fetch courses 
        Dim courses As List(Of Course) = GetCoursesForStudent(student_id)

        ' Bind courses
        For Each course As Course In courses
            CoursesContainer.Controls.Add(CreateCourseHtml(course))
        Next course
        ' Bind courses
        'For Each course As Course In courses
        '    Dim link As New HtmlAnchor()
        '    link.HRef = "CoursePage.aspx?courseId=" & course.id
        '    link.Attributes("class") = "col-md-3"

        '    Dim courseBox As New HtmlGenericControl("div")
        '    courseBox.Attributes("class") = "white-box boxShadow coursebox"
        '    courseBox.Style("background-image") = "url(" & GetImageUrl(course.thumbnail) & ")"

        '    Dim nameLabel As New HtmlGenericControl("label")
        '    nameLabel.Attributes("class") = "box-title"
        '    nameLabel.InnerText = course.name

        '    Dim descriptionLabel As New HtmlGenericControl("p")
        '    descriptionLabel.Attributes("class") = "text-muted"
        '    descriptionLabel.InnerText = course.description

        '    courseBox.Controls.Add(nameLabel)
        '    courseBox.Controls.Add(descriptionLabel)
        '    link.Controls.Add(courseBox)

        '    'CoursesRepeater.Controls.Add(link)

        '    'Creating Session 
        '    Session("CourseID") = course.id
        'Next course
    End Sub
    Private Function CreateCourseHtml(course As Course) As HtmlAnchor
        Dim link As New HtmlAnchor()
        link.HRef = "CoursePage.aspx?cId=" & course.id
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

        courseBox.Controls.Add(descriptionBox)
        link.Controls.Add(courseBox)

        'CoursesRepeater.Controls.Add(link)

        'courseBox.Controls.Add(nameLabel)
        'courseBox.Controls.Add(descriptionBox)
        'link.Controls.Add(courseBox)

        Return link
    End Function

    Private Function GetCoursesForStudent(student_id As String) As List(Of Course)
        Dim filter As String = "WHERE userId = '" & student_id & "'"

        Dim course_list_enrolled As New List(Of Course_Enrollment)
        course_list_enrolled = New Course_Enrollment().listall(filter)
        Dim Student_courses As New List(Of Course)

        For Each enroll As Course_Enrollment In course_list_enrolled
            Dim course_ As Course = Course.load(enroll.course_id)
            Student_courses.Add(course_)
        Next
        Return Student_courses
    End Function

    Private Function GetImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso thumbnail IsNot DBNull.Value Then
            ' Convert the thumbnail to a base64 string
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        ' Return a default image URL if no thumbnail is available
        Return "../plugins/images/miniBanking.jpg"
    End Function

    'Private Sub loadcourses(student_id)
    '    ' Fetch courses 
    '    Dim courses As List(Of Course) = GetCoursesForStudent(student_id)
    '    '' Bind courses
    '    'CoursesRepeater.DataSource = courses
    '    'CoursesRepeater.DataBind()
    'End Sub

End Class