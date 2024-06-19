Imports System.Data.SqlClient
Imports System.Web.Script.Serialization

Public Class AnnouncementsPage
    Inherits System.Web.UI.Page

    Private courseId As String
    Private projectId As String
    Private facilitatorId As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if the courseId or projectId query string parameter exists
            If Request.QueryString("courseId") IsNot Nothing Then
                courseId = Request.QueryString("courseId").ToString()
                facilitatorId = Session("ID").ToString()
            ElseIf Request.QueryString("projectId") IsNot Nothing Then
                projectId = Request.QueryString("projectId").ToString()
                facilitatorId = Session("ID").ToString()
            Else
                ' Redirect to an appropriate page if the courseId or projectId parameter is missing
                Response.Redirect("~/ErrorPage.aspx")
            End If
            BindAnnouncements()
        End If
    End Sub

    Private Sub BindAnnouncements()
        Dim filterStr As String = ""
        If Not String.IsNullOrEmpty(courseId) Then
            filterStr = $"WHERE id = '{courseId}' ORDER BY datetime DESC"
        ElseIf Not String.IsNullOrEmpty(projectId) Then
            filterStr = $"WHERE id = '{projectId}' ORDER BY datetime DESC"
        End If

        ' Fetch announcements using Announcement class
        Dim announcements As List(Of Announcement) = Announcement.listall(filterStr, "")

        ' Bind the announcements to the Repeater control
        AnnouncementsRepeater.DataSource = announcements
        AnnouncementsRepeater.DataBind()
    End Sub

    Protected Sub AddAnnouncement_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get values from the form
        Dim title As String = announcementTitle.Value
        Dim type As Integer = Convert.ToInt32(announcementType.Value)
        Dim body As String = announcementBody.Value

        ' Create a new Announcement object
        Dim newAnnouncement As New Announcement()
        newAnnouncement.id = Nothing ' Assuming this is auto-generated
        newAnnouncement.title = title
        newAnnouncement.type = type
        newAnnouncement.text = body
        newAnnouncement.datetime = DateTime.Now
        newAnnouncement.sentby = facilitatorId

        ' Set specific fields based on whether it's a course or project announcement
        If Not String.IsNullOrEmpty(courseId) Then
            newAnnouncement.id = courseId
        ElseIf Not String.IsNullOrEmpty(projectId) Then
            newAnnouncement.id = projectId
        End If

        ' Save the announcement to the database
        newAnnouncement.update()

        ' Rebind the announcements
        BindAnnouncements()
    End Sub

    Protected Sub EditButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim editButton As Button = DirectCast(sender, Button)
        Dim announcementId As Integer = Convert.ToInt32(editButton.CommandArgument)

        ' Store the announcement ID in a hidden field or session variable for later use
        ViewState("EditAnnouncementId") = announcementId

        ' Manually trigger the modal display using JavaScript
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "showModal", "openEditModal(" & announcementId & ");", True)
    End Sub

    Protected Sub SaveChangesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the edited announcement details from the input fields
        Dim editedTitle As String = editAnnouncementTitle.Value
        Dim editedType As Integer = Convert.ToInt32(editAnnouncementType.Value)
        Dim editedBody As String = editAnnouncementBody.Value

        ' Get the ID of the announcement being edited
        Dim announcementId As Integer = Convert.ToInt32(ViewState("EditAnnouncementId"))

        ' Load the existing announcement
        Dim existingAnnouncement As Announcement = Announcement.load(announcementId)
        existingAnnouncement.title = editedTitle
        existingAnnouncement.type = editedType
        existingAnnouncement.text = editedBody

        ' Update the announcement in the database
        existingAnnouncement.update()

        ' Clear the ViewState variable storing the announcement ID
        ViewState.Remove("EditAnnouncementId")

        ' Rebind the announcements
        BindAnnouncements()
    End Sub

    ' Method to get the icon based on announcement type
    Public Function GetIcon(ByVal type As Object) As String
        Dim icon As String = ""
        Select Case Convert.ToInt32(type)
            Case 0
                icon = "<i class='far fa-file-alt' style='font-size: 26px;'></i>"
            Case 1
                icon = "<i class='far fa-question-circle' style='font-size: 26px;'></i>"
            Case 2
                icon = "<i class='far fa-bell' style='font-size: 26px;'></i>"
        End Select
        Return icon
    End Function

    ' JSON endpoint to fetch announcement content
    <System.Web.Services.WebMethod()>
    Public Shared Function GetAnnouncementContent(ByVal id As Integer) As String
        Dim announcement As Announcement = Announcement.load(id)
        If announcement IsNot Nothing Then
            Dim serializer As New JavaScriptSerializer()
            Return serializer.Serialize(New With {
                .title = announcement.title,
                .type = announcement.type,
                .body = announcement.text
            })
        End If
        Return "{}"
    End Function

End Class
