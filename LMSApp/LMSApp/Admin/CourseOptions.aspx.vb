Public Class CourseOptions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        Dim courseId As String = Request.QueryString("cId")
        If Not String.IsNullOrEmpty(courseId) Then
            linkOverview.HRef = "CourseOverview.aspx?cId=" & courseId
            linkSubmission.HRef = "../Admin/CourseSubmissions.aspx?cId=" & courseId
            linkManageUsers.HRef = "../Admin/ManageUsers.aspx?cId=" & courseId
            linkAnnouncements.HRef = "../Admin/Announcements.aspx?cId=" & courseId
            linkResults.HRef = "../Admin/Announcements.aspx?cId=" & courseId
        End If
        'End If
    End Sub

End Class