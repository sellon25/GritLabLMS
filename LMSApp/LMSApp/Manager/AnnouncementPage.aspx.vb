Imports System.Web.Services

Public Class AnnouncementPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <WebMethod()>
    Public Function InsertAnnouncement() As String
        Try
            ' Check if the user is logged in
            If Session("LoggedIn") Is Nothing OrElse Not CType(Session("LoggedIn"), Boolean) Then
                Throw New Exception("User is not logged in.")
            End If

            Dim sentBy As String = If(Session("ID")?.ToString(), String.Empty)
            If String.IsNullOrEmpty(sentBy) Then
                Throw New Exception("Logged in user ID is not found.")
            End If

            Dim Status As Integer = 1

            Dim title As String = announcementTitle.Value
            If String.IsNullOrEmpty(title) Then
                Throw New Exception("Announcement title is required.")
            End If

            Dim typeStr As String = announcementType.Value
            Dim type As Integer
            If Not Integer.TryParse(typeStr, type) Then
                Throw New Exception("Invalid announcement type.")
            End If

            Dim link As String = announcementLink.Value
            If String.IsNullOrEmpty(link) Then
                Throw New Exception("Announcement link is required.")
            End If

            Dim text As String = announcementText.Value
            If String.IsNullOrEmpty(text) Then
                Throw New Exception("Announcement text is required.")
            End If

            Dim datetime As DateTime = DateTime.Now

            ' Create an instance of Announcement
            Dim announce As New Announcement()

            ' Set properties for the announcement
            announce.id = 124
            announce.title = title
            announce.type = type
            announce.link = link
            announce.datetime = datetime
            announce.text = text
            announce.status = Status
            announce.sentby = sentBy

            announce.update()

            Return "Success"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    Protected Sub addAnnouncement_Click(sender As Object, e As EventArgs)
        MsgBox("Hello World")

        Dim result As String = InsertAnnouncement()

        If result = "Success" Then

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Announcement added successfully!');", True)
        Else

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Failed to add announcement: " & result & "');", True)
        End If
    End Sub


End Class
