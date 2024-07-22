Public Class SubmissionLinks
    Inherits System.Web.UI.Page

    Dim courseId As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        courseId = Request.QueryString("courseId")

        LoadSubmissions()

    End Sub

    Private Sub LoadSubmissions()
        Dim filter As String = "WHERE course_id = '" & Request.QueryString("courseId") & "'"
        Dim submissions As List(Of Submission) = New Submission().listall(filter)

        If submissions IsNot Nothing AndAlso submissions.Count > 0 Then
            Dim sb As New StringBuilder()

            For Each submission As Submission In submissions
                sb.Append("<a class='col-md-12 text-decoration-underline' href='SubmitForm.aspx?submissionId=" & submission.id & "'>")
                sb.Append("<div class='white-box boxShadow'>")
                sb.Append("<h3 class='box-title'>" & submission.title & "</h3>")
                sb.Append("</div>")
                sb.Append("</a>")
            Next

            submissionsContainer.InnerHtml = sb.ToString()
        End If
    End Sub


End Class