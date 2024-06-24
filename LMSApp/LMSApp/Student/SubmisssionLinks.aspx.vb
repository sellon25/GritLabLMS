Public Class SubmisssionLinks
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'loadsubmissionlinks()
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
        Dim filter As String = "WHERE id = '" & submission_id & "'"
        Dim submissionlink As Submission = submissionlink.load(filter)
        Return submissionlink
    End Function
    Private Function GetSubmissionlinks(courseId As String) As List(Of Course_Submission)
        Dim Filter As String = "WHERE course_id = '" & courseId & "' and userId = '" & Session("userId").ToString() & "'"

        Dim links As List(Of Course_Submission)


        Return links
    End Function

    Private Function CreateCourseHtml(course As Submission) As HtmlAnchor
        Dim link As New HtmlAnchor
        link.HRef = "SubmitForm.aspx?courseId=" & course.id


        Return link
    End Function
End Class