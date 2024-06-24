Public Class Results
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If (Not IsPostBack) Then
        '    Session("Type") = "3"
        '    If Session("Type").ToString() = "3" Then
        '        ' loadcourses(Session("Id").ToString())
        '        loadresults("student@g.com")
        '    Else
        '        ' Redirect to an appropriate page if the user is not a student
        '        Response.Redirect("~/Unauthorized.aspx")
        '    End If

        'End If
    End Sub
    Private Sub loadresults(student_id As String)
        Dim courses As List(Of Course) = GetCoursesForStudent(student_id)

        ' Bind courses
        For Each course As Course In courses
            CoursesContainer.Controls.Add(CreateCourseHtml(course))
        Next course
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
    End Function
    Private Function CreateCourseHtml(course As Course) As HtmlAnchor
        Dim link As New HtmlAnchor()
        'link.HRef = "Results.aspx?courseId=" & course.id
        link.HRef = "CourseResults.aspx?courseid=" & course.id
        link.Attributes("class") = "col-md-12 text-black"

        Dim Coursename As New HtmlGenericControl("h3")
        Coursename.Attributes("class") = "box-title"
        Coursename.InnerText = course.name

        Dim resultBox As New HtmlGenericControl("div")
        resultBox.Attributes("class") = "box-flex white-box boxShadow"
        resultBox.Controls.Add(Coursename)
        'courseBox.Style("background-image") = "url(" & GetImageUrl(course.thumbnail) & ")"

        Dim results As New HtmlGenericControl("span")
        results.Attributes("class") = "box-result results-good"
        results.InnerText = "82/100"


        Dim descriptionBox As New HtmlGenericControl("div")
        descriptionBox.Attributes("class") = "description"
        descriptionBox.Controls.Add(results)
        'descriptionBox.Controls.Add(results)

        resultBox.Controls.Add(descriptionBox)
        link.Controls.Add(resultBox)

        'CoursesRepeater.Controls.Add(link)

        'courseBox.Controls.Add(nameLabel)
        'courseBox.Controls.Add(descriptionBox)
        'link.Controls.Add(courseBox)

        Return link
    End Function

    Private Function GetResultsForStudent(courseid As String, student_id As String, testid As String) As List(Of StudentResults)
        Dim filter As String = "WHERE student_id = '" & student_id & "',courseid = '" & courseid & "' and testid='" & testid & "'"

        Dim result_list_enrolled As New List(Of StudentResults)
        result_list_enrolled = New StudentResults().listall(filter)
        Dim Student_results As New List(Of StudentResults)

        For Each results_ As StudentResults In result_list_enrolled
            Dim result As StudentResults = StudentResults.load(results_.id)
            Student_results.Add(result)
        Next
        Return Student_results
    End Function

End Class