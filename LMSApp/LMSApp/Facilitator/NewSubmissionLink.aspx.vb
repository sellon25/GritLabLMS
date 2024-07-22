Public Class NewSubmissionLink
    Inherits System.Web.UI.Page


    Dim courseId As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        courseId = Request.QueryString("courseId")
    End Sub

    Protected Sub AddNewSubmissionLink(ByVal sender As Object, ByVal e As EventArgs)

        Dim submission As New Submission
        If newSubmissionFile.HasFile Then
            submission.file_data = newSubmissionFile.FileBytes
        End If
        submission.id = New database_operations().GetNewPrimaryKey("id", "Submission", HttpContext.Current.Session("conn"))
        submission.title = submissionTitle.Value
        submission.text = submissionText.Value
        submission.datetime = openDateTime.Value
        submission.enddate = closeDateTime.Value
        submission.course_id = Request.QueryString("courseId")
        submission.update()

        submissionTitle.Value = ""
        submissionText.Value = ""
        openDateTime.Value = Nothing
        closeDateTime.Value = Nothing
    End Sub
End Class