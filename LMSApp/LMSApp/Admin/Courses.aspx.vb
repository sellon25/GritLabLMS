Imports System.IO

Public Class Courses1
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AddCourseForm.Visible = False
        PopulateCourses()
        If Not IsPostBack Then
            PopulateFacilitators()

        End If
    End Sub

    Private Sub PopulateCourses()
        Dim courses As List(Of Course) = Course.listall()
        Dim htmlContent As New StringBuilder()
        CoursesContainer.InnerHtml = htmlContent.ToString()
        For Each course As Course In courses
            ' Convert the byte array to a base64 string
            Dim thumbnailBase64 As String = If(course.thumbnail IsNot Nothing, Convert.ToBase64String(course.thumbnail), String.Empty)

            htmlContent.Append("<a class='col-md-3' href='CourseOptions.aspx?cId=" & course.id & "'>")
            htmlContent.Append("<div class='white-box boxShadow coursebox' style='background-image: url(data:image/jpg;base64," & thumbnailBase64 & ")'>")
            htmlContent.Append("<div class='description'>")
            htmlContent.Append("<label class='box-title'>" & course.name & "</label>")
            htmlContent.Append("<p class='text-muted'>" & course.id & "</p>")
            htmlContent.Append("</div>")
            htmlContent.Append("</div>")
            htmlContent.Append("</a>")
        Next

        CoursesContainer.InnerHtml = htmlContent.ToString()
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

    Protected Sub CreateCourse_Click(sender As Object, e As EventArgs) Handles CreateCourse.Click
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
        AddCourseForm.Visible = True
        AddNewCourse.Visible = False
        CoursesContainer.Visible = False
    End Sub

    Protected Sub CancelBtn_Click(sender As Object, e As EventArgs)
        ClearFormFields()
        AddNewCourse.Visible = True
        Response.Redirect("Courses.aspx")

    End Sub
End Class
