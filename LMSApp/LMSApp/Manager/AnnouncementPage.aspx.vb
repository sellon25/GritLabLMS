Imports System.Web.Services

Public Class AnnouncementPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <WebMethod()>
    Public Function InsertAnnouncement() As String

        Try
            Dim title As String = announcementTitle.Value
            Dim type As String = announcementType.Value
            Dim link As String = announcementLink.Value
            Dim datetime As DateTime = DateTime.Now
            Dim text As String = announcementText.Value
            Dim sentBy As String = announcementSentBy.Value

            ' Convert datetime from string to Date
            Dim dateValue As Date = Date.Parse(datetime)

            ' Create an instance of Announcement
            Dim announce As New Announcement()

            ' Set properties for the announcement
            announce.title = title
            announce.type = type
            announce.link = link
            announce.datetime = dateValue ' Assign the parsed datetime
            announce.text = text
            announce.sentby = sentBy

            ' Call the update method of the Announcement class
            announce.update()

            Return "Success"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try

    End Function

    Protected Sub addAnnouncement_Click(sender As Object, e As EventArgs)

        Dim result As String = InsertAnnouncement()

        If result = "Success" Then
            ' Optionally, you can redirect or show a success message
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Announcement added successfully!');", True)
        Else
            ' Handle error case, e.g., log error, show error message
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Failed to add announcement: " & result & "');", True)
        End If

    End Sub

End Class
