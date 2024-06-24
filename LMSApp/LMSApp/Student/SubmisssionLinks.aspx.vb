Public Class SubmisssionLinks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'loadsubmissionlinks()
    End Sub
    'Private Function getLinks(student_id As String)
    '    Dim filter As String = "WHERE userId = '" & student_id & "'"
    '    Dim submissionlink As List(Of Course_Submission) = New Course_Submission().listall(filter)
    '    Dim studentlinks As New Course_Submission()

    '    'For Each enrollment As Question_Bank In projectEnrollments
    '    '    Dim project As Project = project.load(enrollment.project_id)
    '    '    If project IsNot Nothing Then
    '    '        project.name = Trim(project.name)
    '    '        facilitatorProjects.Add(project)
    '    '    End If
    '    'Next

    '    Return facilitatorProjects
    'End Function
    'Protected Sub loadsubmissionlinks()
    '    Dim student_id As String = Session("ID").ToString()

    '    Dim submissionlinks As Question_Bank
    '    submissionlinks = New Question_Bank
    '    Dim links As List(Of Question_Bank) = listall(student_id)
    '    ' Fetch submission links 
    '    ' Dim submissionlinks As List(Of Question_Bank) = GetSubmissionlinks(student_id)
    '    'Dim projects As List(Of Project) = GetProjectsByFacilitator(student_id)

    '    ' Bind links
    '    'For Each submissionlink As Question_Bank In Courses
    '    '    Dim link As New HtmlAnchor()
    '    '    link.HRef = "CoursePage.aspx?courseId=" & Course.id
    '    '    link.Attributes("class") = "col-md-3"

    '    '    Dim courseBox As New HtmlGenericControl("div")
    '    '    courseBox.Attributes("class") = "white-box boxShadow coursebox"
    '    '    courseBox.Style("background-image") = "url(" & GetImageUrl(Course.thumbnail) & ")"

    '    '    Dim nameLabel As New Label()
    '    '    nameLabel.Attributes("class") = "box-title"
    '    '    nameLabel.Text = Course.name

    '    '    Dim descriptionLabel As New Label()
    '    '    descriptionLabel.Attributes("class") = "text-muted"
    '    '    descriptionLabel.Text = Course.description

    '    '    courseBox.Controls.Add(nameLabel)
    '    '    courseBox.Controls.Add(descriptionLabel)
    '    '    link.Controls.Add(courseBox)

    '    '    CoursesRepeater.Controls.Add(link)
    '    'Next
    'End Sub
End Class