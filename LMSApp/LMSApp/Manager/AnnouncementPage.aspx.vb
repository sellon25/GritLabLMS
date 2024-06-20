Imports System.Web.Services
Imports System.Text

Public Class AnnouncementPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindAnnouncements()
        End If
    End Sub

    Private Sub BindAnnouncements()
        Try
            Dim announcements As List(Of Announcement) = Announcement.listall()

            If announcements IsNot Nothing AndAlso announcements.Count > 0 Then
                ' Sort announcements by datetime in descending order
                announcements = announcements.OrderByDescending(Function(a) a.datetime).ToList()

                Dim announcementHtml As New StringBuilder()

                For Each announcement As Announcement In announcements
                    announcementHtml.Append("<div class='d-flex flex-row comment-row p-3 mt-0'>")
                    announcementHtml.Append("<div class='p-2'>")
                    ' Use the icon class returned by GetIcon function
                    announcementHtml.AppendFormat("<i class='fa {0}' style='font-size: 26px;'></i>", GetIcon(announcement.type))
                    announcementHtml.Append("</div>")
                    announcementHtml.Append("<div class='comment-text ps-2 ps-md-3 w-100'>")
                    announcementHtml.AppendFormat("<h5 class='font-medium'>{0}</h5>", Server.HtmlEncode(announcement.title))
                    announcementHtml.AppendFormat("<span class='mb-3 d-block'>{0}</span>", Server.HtmlEncode(announcement.text))
                    announcementHtml.AppendFormat("<div class='text-muted fs-2 ms-auto mt-2 mt-md-0'>{0:MMMM dd, yyyy h:mm tt}</div>", announcement.datetime)
                    announcementHtml.Append("</div>")
                    announcementHtml.Append("<div class='dropdown ml-auto'>")
                    announcementHtml.Append("<div class='dropdown'>")
                    announcementHtml.AppendFormat("<button class='btn' type='button' id='dropdownMenuButton{0}' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>", announcement.id)
                    announcementHtml.Append("<span class='fas fa-ellipsis-v'></span>")
                    announcementHtml.Append("</button>")
                    announcementHtml.AppendFormat("<div class='dropdown-menu' aria-labelledby='dropdownMenuButton{0}'>", announcement.id)
                    ' ASP.NET server-side buttons must be added in ASPX markup
                    ' Replace ASP.NET Buttons with HTML buttons
                    announcementHtml.AppendFormat("<button id='btnEdit{0}' type='button' class='dropdown-item' onclick='EditAnnouncement({0})'>Edit</button>", announcement.id)
                    announcementHtml.AppendFormat("<button id='btnDelete{0}' type='button' class='dropdown-item' onclick='DeleteAnnouncement({0})'>Delete</button>", announcement.id)
                    announcementHtml.AppendFormat("<button id='btnView{0}' type='button' class='dropdown-item' onclick='ViewAnnouncement({0})'>View</button>", announcement.id)
                    announcementHtml.Append("</div>")
                    announcementHtml.Append("</div>")
                    announcementHtml.Append("</div>")
                    announcementHtml.Append("</div>")
                Next

                AnnouncementsContainer.InnerHtml = announcementHtml.ToString()
            Else
                AnnouncementsContainer.InnerHtml = "<p>No announcements available.</p>"
            End If
        Catch ex As Exception
            ' Log the exception or display a generic error message
            AnnouncementsContainer.InnerHtml = "<p>Error loading announcements.</p>"
        End Try
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

            Dim typeStr As String = Request.Form("announcementType") ' Get selected type from form
            Dim type As Integer = GetTypeValue(typeStr) ' Map type string to integer

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
            announce.id = 4 ' Replace with your logic for announcement ID generation
            announce.title = title
            announce.type = type ' Set the mapped type integer
            announce.link = link
            announce.datetime = datetime
            announce.text = text
            announce.status = Status
            announce.sentby = sentBy

            announce.update()

            BindAnnouncements() ' Rebind announcements after insertion

            Return "Success"
        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function

    Private Function GetTypeValue(ByVal typeStr As String) As Integer
        Select Case typeStr
            Case "Alert"
                Return 0
            Case "Alert1"
                Return 1
            Case "Alert2"
                Return 2
            Case Else
                Throw New Exception("Invalid announcement type.")
        End Select
    End Function

    Protected Sub addAnnouncement_Click(sender As Object, e As EventArgs)
        Dim result As String = InsertAnnouncement()

        If result = "Success" Then
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Announcement added successfully!');", True)
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Failed to add announcement: " & result & "');", True)
        End If
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs)

    End Sub


    Public Function GetIcon(ByVal type As Object) As String
        Dim iconClass As String = ""
        Select Case Convert.ToInt32(type)
            Case 0
                iconClass = "far fa-file-alt"
            Case 1
                iconClass = "far fa-question-circle"
            Case 2
                iconClass = "far fa-bell"
        End Select
        Return iconClass
    End Function

    Protected Sub AnnouncementsContainer_ItemCommand(source As Object, e As RepeaterCommandEventArgs)

        If e.CommandName = "Delete" Then
            Try
                Dim announcementId As Integer = Convert.ToInt32(e.CommandArgument)
                Dim announcementToDelete As Announcement = Announcement.load(announcementId)
                announcementToDelete.delete()

                ' Rebind the announcements after deletion
                BindAnnouncements()
            Catch ex As Exception
                ' Handle exceptions (e.g., log them)
            End Try
        End If
    End Sub

End Class
