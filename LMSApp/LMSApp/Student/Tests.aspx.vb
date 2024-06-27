Public Class Tests
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub
    'Private Function CreateTestHtml(test As Tests) As HtmlAnchor
    '    Dim link As New HtmlAnchor()
    '    link.HRef = "Tests.aspx?courseid=" & test.ID
    '    link.Attributes("class") = "col-md-3"

    '    Dim courseBox As New HtmlGenericControl("div")
    '    courseBox.Attributes("class") = "white-box boxShadow coursebox"
    '    courseBox.Style("background-image") = "url(" & GetImageUrl(Course.thumbnail) & ")"

    '    Dim nameLabel As New HtmlGenericControl("label")
    '    nameLabel.Attributes("class") = "box-title"
    '    nameLabel.InnerText = Course.name

    '    Dim descriptionLabel As New HtmlGenericControl("p")
    '    descriptionLabel.Attributes("class") = "text-muted"
    '    descriptionLabel.InnerText = Course.description


    '    Dim descriptionBox As New HtmlGenericControl("div")
    '    descriptionBox.Attributes("class") = "description"
    '    descriptionBox.Controls.Add(nameLabel)
    '    descriptionBox.Controls.Add(descriptionLabel)

    '    courseBox.Controls.Add(descriptionBox)
    '    link.Controls.Add(courseBox)

    '    'CoursesRepeater.Controls.Add(link)

    '    'courseBox.Controls.Add(nameLabel)
    '    'courseBox.Controls.Add(descriptionBox)
    '    'link.Controls.Add(courseBox)

    '    Return link
    'End Function
End Class