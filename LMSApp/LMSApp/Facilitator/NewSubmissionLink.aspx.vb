Public Class NewSubmissionLink
    Inherits System.Web.UI.Page


    Dim courseId As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        courseId = Request.QueryString("courseId")
    End Sub

    Protected Sub AddNewSubmissionLink(ByVal sender As Object, ByVal e As EventArgs)
        Console.Write("WW")

    End Sub
End Class