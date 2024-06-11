Imports System.Data.SqlClient

Public Class AnnouncementsPage
    Inherits System.Web.UI.Page

    Private courseId As String
    Private facilitatorId As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Check if the courseId query string parameter exists
            If Request.QueryString("courseId") IsNot Nothing Then
                courseId = Request.QueryString("courseId").ToString()
                facilitatorId = Session("ID").ToString()
            Else
                ' Redirect to an appropriate page if the courseId parameter is missing
                Response.Redirect("~/ErrorPage.aspx")
            End If
            BindAnnouncements()
        End If
    End Sub

    Private Sub BindAnnouncements()
        ' Fetch announcements from the database
        Dim announcements As DataTable = GetAnnouncements()
        ' Bind the announcements to the Repeater control
        AnnouncementsRepeater.DataSource = announcements
        AnnouncementsRepeater.DataBind()
    End Sub

    Private Function GetAnnouncements() As DataTable
        ' Retrieve announcements from the database
        Dim dt As New DataTable()
        courseId = Request.QueryString("courseId").ToString()
        facilitatorId = Session("ID").ToString()
        Dim conn As SqlConnection = DirectCast(HttpContext.Current.Session("conn"), SqlConnection)
        Dim query As String = "SELECT * FROM Announcement WHERE courseId = @courseId AND sentby = @facilitatorId ORDER BY datetime DESC"
        Using cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@courseId", courseId)
            cmd.Parameters.AddWithValue("@facilitatorId", facilitatorId)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        End Using
        ' Trim column names
        For Each column As DataColumn In dt.Columns
            column.ColumnName = column.ColumnName.Trim()
        Next
        Return dt
    End Function

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

    Protected Sub AddAnnouncement_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get values from the form
        Dim title As String = announcementTitle.Value
        Dim type As Integer = Convert.ToInt32(announcementType.Value)
        Dim body As String = announcementBody.Value

        ' Insert the announcement into the database
        AddAnnouncementToDatabase(title, type, body)

        ' Rebind the announcements
        BindAnnouncements()
    End Sub

    Private Sub AddAnnouncementToDatabase(ByVal title As String, ByVal type As Integer, ByVal body As String)
        ' Retrieve the SQL connection from the session
        courseId = Request.QueryString("courseId").ToString()
        facilitatorId = Session("ID").ToString()
        Dim conn As SqlConnection = DirectCast(HttpContext.Current.Session("conn"), SqlConnection)
        conn.Close()
        ' SQL query to insert an announcement
        Dim query As String = "INSERT INTO Announcement (title, type, text, datetime, sentby, courseId, status) VALUES (@title, @type, @text, @datetime, @sentby, @courseId, @status)"

        ' Current timestamp
        Dim dateTime As DateTime = DateTime.Now

        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, conn)
            ' Add parameters to the SQL query to prevent SQL injection
            command.Parameters.AddWithValue("@title", title)
            command.Parameters.AddWithValue("@type", type)
            command.Parameters.AddWithValue("@text", body)
            command.Parameters.AddWithValue("@datetime", dateTime)
            command.Parameters.AddWithValue("@sentby", facilitatorId)
            command.Parameters.AddWithValue("@courseId", courseId)
            command.Parameters.AddWithValue("@status", 1) ' Assuming 1 means active

            Try
                ' Open the connection if it's not already open
                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If
                ' Execute the query
                command.ExecuteNonQuery()
            Catch ex As Exception
                ' Handle any exceptions (e.g., display an error message)
            End Try
        End Using
    End Sub

    Protected Sub EditButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim editButton As Button = DirectCast(sender, Button)
        Dim announcementId As Integer = Convert.ToInt32(editButton.CommandArgument)

        ' Retrieve announcement details by ID and populate the input fields for editing
        Dim announcement As Announcement = GetAnnouncementById(announcementId)

        ' Populate the input fields
        announcementTitle.Value = announcement.title
        announcementType.Value = announcement.type.ToString()
        announcementBody.Value = announcement.text

        ' Store the announcement ID in a hidden field or session variable for later use
        ' (e.g., to identify the announcement being edited when saving changes)
        ViewState("EditAnnouncementId") = announcementId
    End Sub

    Protected Sub SaveChangesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Get the edited announcement details from the input fields
        Dim editedTitle As String = announcementTitle.Value
        Dim editedType As Integer = Convert.ToInt32(announcementType.Value)
        Dim editedBody As String = announcementBody.Value

        ' Get the ID of the announcement being edited
        Dim announcementId As Integer = Convert.ToInt32(ViewState("EditAnnouncementId"))

        ' Update the announcement in the database with the edited details
        UpdateAnnouncement(announcementId, editedTitle, editedType, editedBody)

        ' Clear the ViewState or Session variable storing the announcement ID
        ViewState.Remove("EditAnnouncementId")

        ' Rebind the announcements
        BindAnnouncements()
    End Sub

    Private Sub UpdateAnnouncement(ByVal announcementId As Integer, ByVal title As String, ByVal type As Integer, ByVal text As String)
        ' Retrieve the SQL connection from the session
        Dim conn As SqlConnection = DirectCast(HttpContext.Current.Session("conn"), SqlConnection)
        conn.Close()

        ' SQL query to update an announcement
        Dim query As String = "UPDATE Announcement SET title = @title, type = @type, text = @text WHERE id = @id"

        ' Create a SqlCommand object with the query and connection
        Using command As New SqlCommand(query, conn)
            ' Add parameters to the SQL query to prevent SQL injection
            command.Parameters.AddWithValue("@title", title)
            command.Parameters.AddWithValue("@type", type)
            command.Parameters.AddWithValue("@text", text)
            command.Parameters.AddWithValue("@id", announcementId)

            Try
                ' Open the connection if it's not already open
                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If
                ' Execute the query
                command.ExecuteNonQuery()
            Catch ex As Exception
                ' Handle any exceptions (e.g., display an error message)
            End Try
        End Using
    End Sub

    Private Function GetAnnouncementById(ByVal announcementId As Integer) As Announcement
        ' Initialize an empty Announcement object
        Dim announcement As New Announcement()

        ' Retrieve the SQL connection from the session
        Dim conn As SqlConnection = DirectCast(HttpContext.Current.Session("conn"), SqlConnection)

        ' SQL query to select an announcement by its ID
        Dim query As String = "SELECT id AS announcement_id, title AS announcement_title, type AS announcement_type, text AS announcement_text FROM Announcement WHERE id = @id"

        ' Create a SqlCommand object with the query and connection
        Using cmd As New SqlCommand(query, conn)
            ' Add the announcement ID as a parameter to the query
            cmd.Parameters.AddWithValue("@id", announcementId)

            Try
                ' Open the connection if it's not already open
                If conn.State <> ConnectionState.Open Then
                    conn.Open()
                End If

                ' Execute the query and retrieve the result
                Dim reader As SqlDataReader = cmd.ExecuteReader()

                ' Check if the query returned any rows
                If reader.Read() Then
                    ' Populate the Announcement object with data from the database
                    announcement.id = Convert.ToInt32(reader("announcement_id"))
                    announcement.title = Convert.ToString(reader("announcement_title"))
                    announcement.type = Convert.ToInt32(reader("announcement_type"))
                    announcement.text = Convert.ToString(reader("announcement_text"))
                    ' Add more properties if needed
                End If

                ' Close the SqlDataReader
                reader.Close()
            Catch ex As Exception
                ' Handle any exceptions (e.g., log error, display error message)
            End Try
        End Using

        ' Return the populated Announcement object
        Return announcement
    End Function

    ' Define the Announcement class (if not already defined elsewhere)
    Private Class Announcement
        Public Property id As Integer
        Public Property title As String
        Public Property type As Integer
        Public Property text As String
    End Class

End Class
