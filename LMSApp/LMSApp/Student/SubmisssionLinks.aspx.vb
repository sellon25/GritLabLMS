Public Class SubmisssionLinks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadsubmissionlinks()
    End Sub
    Private Sub loadsubmissionlinks()
        Dim courseId As String = Request.QueryString("courseId")
        Dim submissionlinks_ As List(Of Course_Submission) = GetSubmissionlinks(courseId)
        For Each link As Course_Submission In submissionlinks_
            Dim submissionlink As Submission = GetSubmissionlink(link.submission_id)
            SubmissionLinks.Controls.Add(CreateCourseHtml(submissionlink))
        Next link
    End Sub
    Private Function GetSubmissionlink(submission_id) As Submission
        Dim submissionlink As Submission = submissionlink.load(submission_id)
        Return submissionlink
    End Function
    Private Function GetSubmissionlinks(courseId As String) As List(Of Course_Submission)
        Dim Filter As String = "WHERE course_id = '" & courseId & "'"
        Dim links As List(Of Course_Submission) = Course_Submission.listall(Filter)

        Return links
    End Function

    Private Function CreateCourseHtml(submissionlink As Submission) As HtmlAnchor
        Dim link As New HtmlAnchor
        link.HRef = "SubmitForm.aspx?courseId=" & Request.QueryString("courseId")
        link.Attributes("class") = "col-md-12 text-decoration-underline"

        Dim title As New HtmlGenericControl("h3")
        title.Attributes("class") = "box-title"
        title.InnerText = submissionlink.title

        Dim linkbox As New HtmlGenericControl("div")
        linkbox.Attributes("class") = "white-box boxShadow"
        linkbox.Controls.Add(title)

        link.Controls.Add(linkbox)
        Return link
    End Function
End Class