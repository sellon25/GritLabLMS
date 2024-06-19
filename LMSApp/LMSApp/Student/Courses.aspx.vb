Public Class Courses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            If Session("Type").ToString() = "3" Then
                loadcourses(Session("Id").ToString())
            Else
                ' Redirect to an appropriate page if the user is not a facilitator
                Response.Redirect("~/Unauthorized.aspx")
            End If

        End If
    End Sub
    Private Sub loadcourses(student_id)
        ' Fetch courses and projects
        Dim courses As List(Of Course) = GetCoursesForStudent(student_id)
        ' Bind courses
        CoursesRepeater.DataSource = courses
        CoursesRepeater.DataBind()
    End Sub

    Private Function GetCoursesForStudent(student_id As String) As List(Of Course)
        Dim filter As String = "WHERE userId = '" & student_id & "'"
        Dim course_list_enrolled As New List(Of Course_Enrollment)
        course_list_enrolled = New Course_Enrollment().listall(filter)
        Dim Student_courses As New List(Of Course)
        For Each enroll As Course_Enrollment In course_list_enrolled
            Dim course_ As Course = Course.load(enroll.course_id)
            Student_courses.Add(course_)
        Next
        Return Student_courses
        '' Return Course.listall(filter, "")
    End Function

    Public Function GetImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso thumbnail IsNot DBNull.Value Then
            ' Convert the thumbnail to a base64 string
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        ' Return a default image URL if no thumbnail is available
        Return "../plugins/images/sldr.jpg"
    End Function

End Class