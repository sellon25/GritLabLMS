Imports System.Data.SqlClient
Imports System.Web.Script.Serialization

Public Class AnnouncementsPage
    Inherits System.Web.UI.Page

    Private courseId As String
    Private projectId As String
    Private facilitatorId As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("courseId") IsNot Nothing Then
                courseId = Request.QueryString("courseId").ToString()
                facilitatorId = Session("ID").ToString()
            ElseIf Request.QueryString("projectId") IsNot Nothing Then
                projectId = Request.QueryString("projectId").ToString()
                facilitatorId = Session("ID").ToString()
            Else
                Response.Redirect("~/ErrorPage.aspx")
            End If
            LoadAnnouncements()
        End If
    End Sub

    Protected Sub AddAnnouncement_Click(sender As Object, e As EventArgs)
        Dim title As String = announcementTitle.Value
        Dim type As Integer = Convert.ToInt32(announcementType)
        Dim body As String = announcementBody.Value

        Dim newAnnouncement As New Announcement()
        With newAnnouncement
            .id = Nothing
            .title = title
            .type = type
            .text = body
            .datetime = DateTime.Now
            .sentby = facilitatorId
        End With

        If Not String.IsNullOrEmpty(courseId) Then
            newAnnouncement.id = courseId
        ElseIf Not String.IsNullOrEmpty(projectId) Then
            newAnnouncement.id = projectId
        End If

        newAnnouncement.update()
        LoadAnnouncements()
    End Sub

    Private Sub LoadAnnouncements()
        Dim filterStr As String = ""
        If Not String.IsNullOrEmpty(courseId) Then
            filterStr = $"WHERE id = '{courseId}' ORDER BY datetime DESC"
        ElseIf Not String.IsNullOrEmpty(projectId) Then
            filterStr = $"WHERE id = '{projectId}' ORDER BY datetime DESC"
        End If

        Dim announcements As List(Of Announcement) = Announcement.listall(filterStr, "")
        CreatedAnnouncements.Controls.Clear()

        For Each announcement In announcements
            CreatedAnnouncements.Controls.Add(AddAnnouncementHtml(announcement))
        Next
    End Sub

    Protected Function AddAnnouncementHtml(announcement As Announcement) As HtmlGenericControl
        Dim newAnnouncementDiv As New HtmlGenericControl("div")
        newAnnouncementDiv.Attributes("class") = "form-group mb-4"

        Dim btnDelete As New Button()
        btnDelete.ID = String.Format("btnDelete_{0}", announcement.id)
        btnDelete.Text = "Delete"
        btnDelete.CssClass = "btn-0 border-0 text-danger bg-none float-end"
        AddHandler btnDelete.Click, AddressOf DeleteAnnouncement
        btnDelete.EnableViewState = True

        Dim lblTitle As New Label()
        lblTitle.CssClass = "col-md-12 p-0"
        lblTitle.Text = announcement.title

        Dim lblBody As New Label()
        lblBody.CssClass = "col-md-12 p-0"
        lblBody.Text = announcement.text

        newAnnouncementDiv.Controls.Add(btnDelete)
        newAnnouncementDiv.Controls.Add(lblTitle)
        newAnnouncementDiv.Controls.Add(lblBody)

        Return newAnnouncementDiv
    End Function

    Protected Sub DeleteAnnouncement(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim announcementId = btn.ID.Replace("btnDelete_", "")
        Dim announcement As New Announcement()
        announcement = Announcement.load(announcementId)
        announcement.delete()
        LoadAnnouncements()
    End Sub
End Class
