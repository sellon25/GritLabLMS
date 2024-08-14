Public Class coursepage
    Inherits System.Web.UI.Page

    Public coursename As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim loadcourse As New Course
        Dim cid As String = Request.QueryString("cId")
        loadcourse = loadcourse.load(cid)
        If loadcourse IsNot Nothing Then
            coursename = loadcourse.name
        End If

    End Sub

End Class