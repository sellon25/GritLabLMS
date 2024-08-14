Imports System.Web.Services

Namespace Admin


    Public Class Announcements1
        Inherits System.Web.UI.Page

        'Private courseId As String
        'Private projectId As String
        'Private adminId As String

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                If Request.QueryString("cId") IsNot Nothing Then
                    courseId.Value = Request.QueryString("cId").ToString()
                    adminId.Value = Session("ID").ToString()
                ElseIf Request.QueryString("pId") IsNot Nothing Then
                    projectId.Value = Request.QueryString("pId").ToString()
                    adminId.Value = Session("ID").ToString()
                Else
                    courseId.Value = ""

                    'Response.Redirect("~/ErrorPage.aspx")
                End If
                'BindAnnouncements()
            End If

            BindAnnouncements()
        End Sub

        Private Sub BindAnnouncements()
            Try
                Dim filter1 As String = "WHERE [type]=100 "
                Dim filter As String = "WHERE course_id = '" & Request.QueryString("cId") & "'"
                Dim allAnnouncements As List(Of Course_Announcement) = New Course_Announcement().listall(filter)

                If allAnnouncements IsNot Nothing AndAlso allAnnouncements.Count > 0 Then
                    Dim announcements As List(Of Announcement) = New List(Of Announcement)
                    'get announcement from announcement table
                    For Each a As Course_Announcement In allAnnouncements
                        Dim ann As Announcement = Announcement.load(a.announcement_id)
                        announcements.Add(ann)
                    Next


                    ' Sort announcements by datetime in descending order
                    announcements = announcements.OrderByDescending(Function(a) a.datetime).ToList()

                    AnnouncementsContainer.Controls.Clear()

                    For Each announcement As Announcement In announcements
                        Dim newAnnouncementDiv As New HtmlGenericControl("div")
                        newAnnouncementDiv.ID = $"div{announcement.id}" ' Set unique ID for each announcement div
                        newAnnouncementDiv.Attributes("class") = "d-flex flex-row comment-row p-3 mt-0"

                        Dim iconDiv As New HtmlGenericControl("div")
                        iconDiv.Attributes("class") = "p-2"
                        iconDiv.InnerHtml = $"<i class='fa {GetIcon(announcement.type)}' style='font-size: 26px;'></i>"
                        newAnnouncementDiv.Controls.Add(iconDiv)

                        Dim textDiv As New HtmlGenericControl("div")
                        textDiv.Attributes("class") = "comment-text ps-2 ps-md-3 w-100"
                        textDiv.InnerHtml = $"<h5 class='font-medium'>{Server.HtmlEncode(announcement.title)}</h5>" &
                                            $"<span class='mb-3 d-block'>{Server.HtmlEncode(announcement.text)}</span>" &
                                            $"<div class='text-muted fs-2 ms-auto mt-2 mt-md-0'>{announcement.datetime:MMMM dd, yyyy h:mm tt}</div>" &
                                            $"<div class='text-muted fs-2 ms-auto mt-2 mt-md-0'>Sent by: {announcement.sentby}</div>" &
                                            $"<div class='text-muted fs-2  mt-2 mt-md-0' style='text-align: right;'><span class='me-1'>Link:</span><a href='{Server.HtmlEncode(announcement.link)}'>{Server.HtmlEncode(announcement.link)}</a></div>"

                        newAnnouncementDiv.Controls.Add(textDiv)

                        Dim dropdownDiv As New HtmlGenericControl("div")
                        dropdownDiv.Attributes("class") = "dropdown ml-auto"

                        Dim buttonDropdown As New HtmlGenericControl("button")
                        buttonDropdown.Attributes("class") = "btn"
                        buttonDropdown.Attributes("type") = "button"
                        buttonDropdown.Attributes("id") = $"dropdownMenuButton{announcement.id}"
                        buttonDropdown.Attributes("data-toggle") = "dropdown"
                        buttonDropdown.Attributes("aria-haspopup") = "true"
                        buttonDropdown.Attributes("aria-expanded") = "false"
                        buttonDropdown.InnerHtml = "<span class='fas fa-ellipsis-v'></span>"
                        dropdownDiv.Controls.Add(buttonDropdown)

                        Dim menuDiv As New HtmlGenericControl("div")
                        menuDiv.Attributes("class") = "dropdown-menu"
                        menuDiv.Attributes("aria-labelledby") = $"dropdownMenuButton{announcement.id}"

                        ' Create the delete button
                        Dim btnDelete As New Button()
                        btnDelete.ID = String.Format("DeleteAnnouncement_{0}", announcement.id)
                        btnDelete.Text = "Delete"
                        btnDelete.CssClass = "dropdown-item"
                        btnDelete.Attributes("data-announcement-id") = announcement.id.ToString()
                        AddHandler btnDelete.Click, AddressOf DeleteAnnouncement
                        menuDiv.Controls.Add(btnDelete)

                        ' Create the delete button
                        Dim btnEdit As New Button()
                        btnEdit.ID = String.Format("EditAnnouncement_{0}", announcement.id)
                        btnEdit.Text = "Edit"
                        btnEdit.CssClass = "dropdown-item"
                        btnEdit.Attributes("data-announcement-id") = announcement.id.ToString()
                        AddHandler btnEdit.Click, AddressOf EditAnnouncement
                        menuDiv.Controls.Add(btnEdit)

                        dropdownDiv.Controls.Add(menuDiv)
                        newAnnouncementDiv.Controls.Add(dropdownDiv)

                        AnnouncementsContainer.Controls.Add(newAnnouncementDiv)
                    Next
                Else
                    Dim noAnnouncementsDiv As New HtmlGenericControl("p")
                    noAnnouncementsDiv.InnerHtml = "No announcements yet."
                    AnnouncementsContainer.Controls.Add(noAnnouncementsDiv)
                End If
            Catch ex As Exception
                ' Log the exception or display a generic error message
                Dim errorDiv As New HtmlGenericControl("p")
                errorDiv.InnerHtml = "Error loading announcements."
                AnnouncementsContainer.Controls.Add(errorDiv)
            End Try
        End Sub

        Protected Sub EditAnnouncement(sender As Object, e As EventArgs)
            ' Retrieve the announcement ID from the button's CommandArgument
            Dim btn As Button = DirectCast(sender, Button)
            Dim announcementId As Integer = Convert.ToInt32(btn.ID.Replace("EditAnnouncement_", ""))

            Try

                Dim announcementToEdit As New Announcement()
                announcementToEdit = Announcement.load(announcementId)

                Dim divToDelete As HtmlGenericControl = FindAnnouncementDiv(announcementId)
                If divToDelete IsNot Nothing Then
                    'AnnouncementsContainer.Controls.Remove(divToDelete)
                End If

                ' Retrieve the announcement details based on the ID 
                announcementTitle.Value = announcementToEdit.title
                'announcementType.SelectedValue = announcement.type.ToString() ' Assuming ddlType is a DropDownList
                ' Get selected type from form
                ' Map type string to integer
                announcementLink.Value = announcementToEdit.link
                announcementText.Value = announcementToEdit.text
                announcementSentBy.Value = announcementToEdit.sentby

                ' Store the ID of the announcement being edited (you may store it in a hidden field or session)
                Session("EditingAnnouncementID") = announcementId



            Catch ex As Exception

                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Announcement not found.');", True)

            End Try

        End Sub


        Protected Sub DeleteAnnouncement(sender As Object, e As EventArgs)
            Dim btn As Button = DirectCast(sender, Button)
            Dim announcementId As Integer = Convert.ToInt32(btn.ID.Replace("DeleteAnnouncement_", ""))

            Try
                ' Perform deletion logic here
                Dim announcementToDelete As New Announcement()
                announcementToDelete = Announcement.load(announcementId)

                Dim filter As String = "WHERE announcement_id = '" & announcementId & "'"
                Dim courseAnnouncement As List(Of Course_Announcement) = New Course_Announcement().listall(filter)

                For Each c As Course_Announcement In courseAnnouncement
                    c.delete()
                Next
                announcementToDelete.delete()

                ' Inform the user
                ClientScript.RegisterStartupScript(Me.GetType(), "deleted", "alert('Announcement deleted.');", True)

                ' Remove the deleted announcement from the UI
                Dim divToDelete As HtmlGenericControl = FindAnnouncementDiv(announcementId)
                If divToDelete IsNot Nothing Then
                    AnnouncementsContainer.Controls.Remove(divToDelete)
                End If


            Catch ex As Exception
                ClientScript.RegisterStartupScript(Me.GetType(), "error", $"alert('Error deleting announcement: {ex.Message}');", True)
            End Try
        End Sub

        Public Shared Function GetNextAnnouncementId() As Integer
            Dim nextId As Integer = 1

            Try
                ' Retrieve all existing IDs
                Dim ids As List(Of Announcement) = Announcement.listallPKOnly(Nothing, Nothing)

                ' Find the maximum ID
                If ids IsNot Nothing AndAlso ids.Count > 0 Then
                    nextId = ids.Max(Function(a) a.id.GetValueOrDefault()) + 1
                End If
            Catch ex As Exception
                ' Handle exceptions if needed
                Throw New Exception("Error getting next announcement ID: " & ex.Message)
            End Try

            Return nextId
        End Function

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

                'Dim typeStr As String = Request.Form("announcementType") ' Get selected type from form
                'Dim type As Integer = GetTypeValue(typeStr) ' Map type string to integer

                Dim link As String = announcementLink.Value


                Dim text As String = announcementText.Value
                If String.IsNullOrEmpty(text) Then
                    Throw New Exception("Announcement text is required.")
                End If

                Dim datetime As DateTime = DateTime.Now

                ' Create an instance of Announcement
                Dim announce As New Announcement()
                Dim courseAnnounce As New Course_Announcement()

                ' Determine if it's an insert or update
                If Session("EditingAnnouncementID") IsNot Nothing Then
                    Dim announcementId As Integer = Convert.ToInt32(Session("EditingAnnouncementID"))

                    'announce.id = announcementId 
                    announce = Announcement.load(announcementId)
                    ' Set properties for the announcement
                    announce.title = title
                    announce.type = 100
                    announce.link = link
                    'announce.datetime = datetime
                    announce.text = text
                    announce.status = Status
                    announce.sentby = sentBy

                    announce.update()
                Else
                    announce.id = New database_operations().GetNewPrimaryKey("id", "Announcement", HttpContext.Current.Session("conn")) ' Replace with your logic for generating a new ID

                    ' Set properties for the announcement
                    announce.title = title
                    announce.type = 100 ' Set the mapped type integer
                    announce.link = link
                    announce.datetime = datetime
                    announce.text = text
                    announce.status = Status
                    announce.sentby = sentBy

                    announce.update()

                    courseAnnounce.id = New database_operations().GetNewPrimaryKey("id", "Course_Announcement", HttpContext.Current.Session("conn"))
                    courseAnnounce.announcement_id = announce.id
                    courseAnnounce.course_id = courseId.Value

                    courseAnnounce.update()
                End If

                ' Clear session variable once done with editing or insertion
                Session.Remove("EditingAnnouncementID")

                BindAnnouncements() ' Rebind announcements after insertion or update

                Return "Success"
            Catch ex As Exception
                Return "Error: " & ex.Message
            End Try
        End Function


        Private Function GetTypeValue(ByVal typeStr As String) As Integer
            Return 0
        End Function

        Protected Sub addAnnouncement_Click(sender As Object, e As EventArgs)
            Dim result As String = InsertAnnouncement()

            If result = "Success" Then
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Announcement added successfully!');", True)
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Failed to add announcement: {result}');", True)
            End If

            announcementTitle.Value = ""
            announcementLink.Value = ""
            announcementText.Value = ""
            announcementSentBy.Value = ""
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

        Private Function FindAnnouncementDiv(announcementId As Integer) As HtmlGenericControl
            For Each ctrl As Control In AnnouncementsContainer.Controls
                If TypeOf ctrl Is HtmlGenericControl AndAlso ctrl.ID = $"div{announcementId}" Then
                    Return DirectCast(ctrl, HtmlGenericControl)
                End If
            Next
            Return Nothing
        End Function
    End Class
End Namespace