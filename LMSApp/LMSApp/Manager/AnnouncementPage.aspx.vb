Imports System.Web.Services
Imports System.Text
Imports System.IO

Public Class AnnouncementPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindAnnouncements()
        Else
            BindAnnouncements()
        End If

    End Sub

    Private Sub BindAnnouncements()
        Try
            Dim announcements As List(Of Announcement) = New Announcement().listall("", "order by datetime desc ")

            If announcements IsNot Nothing AndAlso announcements.Count > 0 Then
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
                    $"<div class='d-flex justify-content-between align-items-center'>" &
                    $"<div class='text-muted fs-2 mt-2 mt-md-0'>{announcement.datetime:MMMM dd, yyyy h:mm tt}</div>" &
                    $"<div class=text-muted fs-2 mt-2 mt-md-0'><span class='me-1'>Link:</span><a href='{Server.HtmlEncode(announcement.link)}'>{Server.HtmlEncode(announcement.link)}</a></div>" &
                    $"</div>"




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

                    ' Create the view button
                    Dim btnView As New HtmlGenericControl("button")
                    btnView.Attributes("class") = "dropdown-item"
                    btnView.Attributes("type") = "button"
                    btnView.Attributes("onclick") = $"ViewAnnouncement({announcement.id})"
                    btnView.InnerHtml = "View"
                    menuDiv.Controls.Add(btnView)


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
                noAnnouncementsDiv.InnerHtml = "No announcements available."
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
        Dim btn As Button = DirectCast(sender, Button)
        Dim announcementId As Integer = Convert.ToInt32(btn.ID.Replace("EditAnnouncement_", ""))

        Try
            Dim announcementToEdit As New Announcement()
            announcementToEdit = Announcement.load(announcementId)

            ' Populate form fields
            announcementTitle.Value = announcementToEdit.title
            announcementLink.Value = announcementToEdit.link
            announcementText.Value = announcementToEdit.text
            announcementSentBy.Value = announcementToEdit.sentby

            ' Store the ID of the announcement being edited
            Session("EditingAnnouncementID") = announcementId
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Announcement not found.');", True)
        End Try
    End Sub
    Private Sub UpdateSendToDropdown()
        Try
            chkListCoursesProjects.Visible = False ' Hide checkbox list by default

            Dim selectedForm As String = sendTo.SelectedValue.Trim()

            Select Case selectedForm
                Case "Course"
                    LoadCourses()
                Case "Project"
                    LoadProjects()
                Case Else
                    chkListCoursesProjects.Visible = False
            End Select
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "error", $"alert('Error updating SendTo dropdown: {ex.Message}');", True)
        End Try
    End Sub

    Private Sub LoadCourses()
        Dim courses As List(Of Course) = Course.listall("", "order by id desc ")
        chkListCoursesProjects.Items.Clear()

        For Each course As Course In courses
            chkListCoursesProjects.Items.Add(New ListItem(course.name, course.id))
        Next

        chkListCoursesProjects.Visible = True
    End Sub

    Private Sub LoadProjects()
        Dim projects As List(Of Project) = Project.listall("", "order by id desc ")
        chkListCoursesProjects.Items.Clear()

        For Each project As Project In projects
            chkListCoursesProjects.Items.Add(New ListItem(project.name, project.id))
        Next

        chkListCoursesProjects.Visible = True
    End Sub


    Protected Sub announcementsForm_SelectedIndexChanged(sender As Object, e As EventArgs)
        UpdateSendToDropdown()
    End Sub


    Protected Sub DeleteAnnouncement(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim announcementId As Integer = Convert.ToInt32(btn.ID.Replace("DeleteAnnouncement_", ""))

        Try
            ' Delete related records in Course_Announcement
            Dim courseAnnounce As New Course_Announcement()
            Dim relatedCourseAnnouncements As List(Of Course_Announcement) = courseAnnounce.listall($"WHERE announcement_id = {announcementId}", "")

            For Each relatedCourseAnnouncement In relatedCourseAnnouncements
                relatedCourseAnnouncement.delete()
            Next

            ' Delete related records in Project_Announcement
            Dim projectAnnounce As New Project_Announcement()
            Dim relatedProjectAnnouncements As List(Of Project_Announcement) = projectAnnounce.listall($"WHERE announcement_id = {announcementId}", "")

            For Each relatedProjectAnnouncement In relatedProjectAnnouncements
                relatedProjectAnnouncement.delete()
            Next

            ' Delete the announcement itself
            Dim announcementToDelete As Announcement = Announcement.load(announcementId)
            announcementToDelete.delete()

            ' Inform the user
            ClientScript.RegisterStartupScript(Me.GetType(), "deleted", "alert('Announcement deleted.');", True)

            ' Remove the deleted announcement from the UI
            Dim divToDelete As HtmlGenericControl = FindAnnouncementDiv(announcementId)
            If divToDelete IsNot Nothing Then
                AnnouncementsContainer.Controls.Remove(divToDelete)
            End If

            Response.Redirect("AnnouncementPage.aspx")
        Catch ex As Exception
            ' Handle exceptions (e.g., log them)
            ClientScript.RegisterStartupScript(Me.GetType(), "error", $"alert('Error deleting announcement: {ex.Message}');", True)
        End Try
    End Sub

    Public Shared Function GetNextAnnouncementId() As Integer
        Dim nextId As Integer = 1 ' Default starting ID

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


    '<WebMethod()>
    'Public Function InsertAnnouncement2() As String
    '    Try
    '        ' Check if the user is logged in
    '        If Session("LoggedIn") Is Nothing OrElse Not CType(Session("LoggedIn"), Boolean) Then
    '            Throw New Exception("User is not logged in.")
    '        End If

    '        Dim sentBy As String = If(Session("ID")?.ToString(), String.Empty)
    '        If String.IsNullOrEmpty(sentBy) Then
    '            Throw New Exception("Logged in user ID is not found.")
    '        End If

    '        Dim Status As Integer = 1

    '        Dim title As String = announcementTitle.Value
    '        If String.IsNullOrEmpty(title) Then
    '            Throw New Exception("Announcement title is required.")
    '        End If

    '        Dim typeStr As String = Request.Form("announcementType") ' Get selected type from form
    '        Dim type As Integer = GetTypeValue(typeStr) ' Map type string to integer

    '        Dim link As String = announcementLink.Value


    '        Dim text As String = announcementText.Value
    '        If String.IsNullOrEmpty(text) Then
    '            Throw New Exception("Announcement text is required.")
    '        End If

    '        Dim datetime As DateTime = DateTime.Now

    '        ' Create an instance of Announcement
    '        Dim announce As New Announcement()
    '        Dim courseAnnounce As New Course_Announcement()

    '        ' Determine if it's an insert or update
    '        If Session("EditingAnnouncementID") IsNot Nothing Then
    '            Dim announcementId As Integer = Convert.ToInt32(Session("EditingAnnouncementID"))

    '            'announce.id = announcementId 
    '            announce = Announcement.load(announcementId)
    '            ' Set properties for the announcement
    '            announce.title = title
    '            announce.type = type
    '            announce.link = link
    '            announce.datetime = datetime
    '            announce.text = text
    '            announce.status = Status
    '            announce.sentby = sentBy

    '            announce.update()
    '        Else
    '            announce.id = New database_operations().GetNewPrimaryKey("id", "Announcement", HttpContext.Current.Session("conn")) ' Replace with your logic for generating a new ID
    '            ' Set properties for the announcement
    '            announce.title = title
    '            announce.type = type ' Set the mapped type integer
    '            announce.link = link
    '            announce.datetime = datetime
    '            announce.text = text
    '            announce.status = Status
    '            announce.sentby = sentBy

    '            announce.update()

    '            'courseAnnounce.id = New database_operations().GetNewPrimaryKey("id", "Announcement", HttpContext.Current.Session("conn"))
    '            courseAnnounce.announcement_id = announce.id
    '            'courseAnnounce.course_id = Request.QueryString("courseId")

    '            'courseAnnounce.update()
    '        End If

    '        ' Clear session variable once done with editing or insertion
    '        Session.Remove("EditingAnnouncementID")

    '        BindAnnouncements() ' Rebind announcements after insertion or update

    '        Return "Success"
    '    Catch ex As Exception
    '        Return "Error: " & ex.Message
    '    End Try
    'End Function

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

            Dim typeStr As String = Request.Form("announcementType")
            Dim type As Integer = GetTypeValue(typeStr)
            Dim link As String = announcementLink.Value
            Dim text As String = announcementText.Value
            If String.IsNullOrEmpty(text) Then
                Throw New Exception("Announcement text is required.")
            End If

            Dim datetime As DateTime = DateTime.Now
            Dim announce As New Announcement()

            Dim announcementId As Integer

            If Session("EditingAnnouncementID") IsNot Nothing Then
                announcementId = Convert.ToInt32(Session("EditingAnnouncementID"))
                announce = Announcement.load(announcementId)
                announce.title = title
                announce.type = type
                announce.link = link
                announce.datetime = datetime
                announce.text = text
                announce.status = Status
                announce.sentby = sentBy
                announce.update()
                Session.Remove("EditingAnnouncementID")
            Else
                announcementId = GetNextAnnouncementId()
                announce.id = announcementId
                announce.title = title
                announce.type = type
                announce.link = link
                announce.datetime = datetime
                announce.text = text
                announce.status = Status
                announce.sentby = sentBy
                announce.update() ' Use insert method for new record
            End If

            ' Handle course association
            For Each item As ListItem In chkListCoursesProjects.Items
                If item.Selected Then
                    Dim courseAnnounce As New Course_Announcement() With {
                    .announcement_id = announcementId,
                    .course_id = item.Value
                }
                    courseAnnounce.update() ' Use insert method provided by your ORM
                End If
            Next

            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Announcement added successfully!');", True)
            BindAnnouncements()
            Return "Success"
        Catch ex As Exception
            ' Log the exception or display an error message
            Return "Error: " & ex.Message
        End Try
    End Function


    Protected Sub UpdateSendToDropdown(sender As Object, e As EventArgs)

        UpdateSendToDropdown()

    End Sub

    Private Function GetTypeValue(ByVal typeStr As String) As Integer
        Select Case typeStr
            Case "Information"
                Return 0
            Case "Query"
                Return 1
            Case "Alert"
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
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", $"alert('Failed to add announcement: {result}');", True)
        End If

        ' Clear form fields
        announcementTitle.Value = ""
        announcementLink.Value = ""
        announcementText.Value = ""
        announcementSentBy.Value = ""
        BindAnnouncements()

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