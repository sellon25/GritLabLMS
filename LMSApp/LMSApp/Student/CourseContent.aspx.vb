Imports Microsoft.VisualBasic.Devices

Public Class CourseContent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadcourses("student@g.com")
        End If
    End Sub
    'Protected Sub loadcoursecontent(courseId As String)
    '    ' Assuming the model StudentResults has a method listall to fetch all records and supports filtering
    '    Dim filter As String = "WHERE course_Id = '" & Request.QueryString("courseId") & "content_id = '" &
    '    Dim results As List(Of Content) = Content.listall(filter)

    'End Sub
    Private Sub loadcourses(student_id As String)
        'Dim student_id As String = Session("ID").ToString()

        ' Fetch courses 
        Dim contents As List(Of Content) = GetContentForStudent()

        For Each content As Content In contents
            CourseContent.Controls.Add(CreateContentHtml(content))
        Next content

    End Sub
    Private Function GetContentForStudent() As List(Of Content)
        Dim filter As String = "WHERE course_Id = '" & Request.QueryString("courseId") & "'"
        Dim contents As List(Of Content) = Content.listall(filter)

        Return contents
    End Function
    Private Function CreateContentHtml(content As Content) As HtmlAnchor
        Dim link As New HtmlAnchor()
        If content.link = Nothing Then
            content.link = "#"
        End If
        link.HRef = content.link.ToString()
        link.Attributes("class") = "d-md-flex white-box boxShadow"

        Dim contentBox As New HtmlGenericControl("div")
        contentBox.Attributes("class") = "textboookarea"

        Dim title As New HtmlGenericControl("h3")
        title.Attributes("class") = "text-black"
        title.InnerText = content.title

        Dim image As New HtmlGenericControl("img")
        image.Attributes("class") = "textbook"
        image.Attributes("src") = GetImageUrl(content.thumbnail)

        Dim description As New HtmlGenericControl("p")
        description.Attributes("class") = "text-dark"
        description.InnerText = content.description


        Dim descriptionBox As New HtmlGenericControl("div")
        descriptionBox.Controls.Add(title)
        descriptionBox.Controls.Add(description)

        contentBox.Controls.Add(image)
        contentBox.Controls.Add(descriptionBox)

        link.Controls.Add(contentBox)

        Return link
    End Function

    'Private Function GetContentForStudent(course_id As String) As List(Of Content)
    '    Dim filter As String = "WHERE course_id = '" & course_id & "'"

    '    Dim course_list_enrolled As New List(Of Content)
    '    course_list_enrolled = New Content().listall(filter)
    '    Dim course_contents As New List(Of Content)

    '    For Each content As Content In course_list_enrolled
    '        Dim course_content As Content = course_content.load(content.content_id)
    '        course_contents.Add(course_content)
    '    Next
    '    Return course_contents
    'End Function

    Public Function GetImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso thumbnail IsNot DBNull.Value Then
            ' Convert the thumbnail to a base64 string
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        ' Return a default image URL if no thumbnail is available
        Return "../plugins/images/chemtextbook.jpg"
    End Function

End Class