﻿Public Class SubmissionLinks
    Inherits System.Web.UI.Page

    Dim courseId As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        courseId = Request.QueryString("courseId")
    End Sub

End Class