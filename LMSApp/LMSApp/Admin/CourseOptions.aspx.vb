Imports System.IO

Public Class CourseOptions
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        CourseForm.Visible = False
        Dim courseId As String = Request.QueryString("cId")
        If Not String.IsNullOrEmpty(courseId) Then
            'linkOverview.HRef = "CourseOverview.aspx?cId=" & courseId
            linkSubmission.HRef = "../Admin/CourseSubmissions.aspx?cId=" & courseId
            linkManageUsers.HRef = "../Admin/ManageUsers.aspx?cId=" & courseId
            linkAnnouncements.HRef = "../Admin/Announcements.aspx?cId=" & courseId
            linkResults.HRef = "../Admin/Announcements.aspx?cId=" & courseId
        End If
        'End If

        PopulateFacilitators()
    End Sub

    Private Sub PopulateFacilitators()
        Dim users As New List(Of User)
        users = New User().listall("WHERE role = 4")

        Selectfactilitators.Items.Clear()
        For Each user As User In users
            Dim listItem As New ListItem(user.FName & " " & user.LName, user.emailID)
            Selectfactilitators.Items.Add(listItem)
        Next
    End Sub

    Protected Sub UpdateCourse_Click(sender As Object, e As EventArgs) Handles CreateCourse.Click
        'If Not IsPostBack Then Return

        Dim newCourse As New Course()

        newCourse.id = coureID.Value.ToUpper()
        newCourse.name = New ENTITY().ToTitleCase(coureName.Value)
        newCourse.description = coureDesription.Value
        newCourse.overview = coureOverview.Value
        newCourse.status = Convert.ToInt32(CourseStatus.SelectedValue)
        newCourse.date_started = Convert.ToDateTime(coureStartDate.Value)
        newCourse.end_date = Convert.ToDateTime(coureEndDate.Value)

        If FileUpload1.HasFile Then
            Using br As New BinaryReader(FileUpload1.PostedFile.InputStream)
                newCourse.thumbnail = br.ReadBytes(FileUpload1.PostedFile.ContentLength)
            End Using
        End If

        newCourse.update()

        ' Handle facilitators (if any additional handling is required)
        For Each item As ListItem In Selectfactilitators.Items
            If item.Selected Then
                ' Add logic to handle selected facilitators
                ' For example, create a CourseFacilitator record linking the course with the facilitator
            End If
        Next

        ' Optionally, clear the form fields after insertion
        ClearFormFields()
        Response.Redirect("Courses.aspx")

    End Sub

    Private Sub ClearFormFields()
        coureID.Value = ""
        coureName.Value = ""
        coureDesription.Value = ""
        coureOverview.Value = ""
        coureStartDate.Value = ""
        coureEndDate.Value = ""
        CourseStatus.SelectedIndex = 0
        Selectfactilitators.ClearSelection()
    End Sub

    Protected Sub AddNewCourse_ServerClick(sender As Object, e As EventArgs)
        CourseForm.Visible = True
        EditCourseInfo.Visible = False
        ActionContainer.Visible = False
    End Sub

    Protected Sub CancelBtn_Click(sender As Object, e As EventArgs)
        ClearFormFields()
        ActionContainer.Visible = True
        Response.Redirect(Request.Url.AbsoluteUri)

    End Sub

End Class