Public Class Tests
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadtest(Request.QueryString("courseId"))
        End If
    End Sub

    Private Sub loadtest(courseid As String)
        Dim Test_ As List(Of Test) = GetTestsForCourse(courseid)

        'Load Tests for the course

        For Each test As Test In Test_
            If test.end_date >= Date.Now Then
                TestContainer.Controls.Add(CreateTestHtml(test))
            End If

        Next test
    End Sub
    Private Function GetTestsForCourse(course_id As String) As List(Of Test)
        Dim filter As String = "WHERE course_id = '" & course_id & "'"

        Dim test_list As New List(Of Test)
        test_list = New Test().listall(filter)
        Dim course_tests As New List(Of Test)

        For Each _test_ As Test In test_list
            Dim _test As Test = Test.load(_test_.id)
            course_tests.Add(_test)
        Next
        Return course_tests
    End Function
    Private Function CreateTestHtml(test As Test) As HtmlAnchor
        Dim link As New HtmlAnchor()

        link.HRef = "TestContent.aspx?testid=" & test.id
        link.Attributes("class") = "d-flex flex-row comment-row p-3 mt-0 white-box boxShado white-box boxShadow3"

        Dim icon As New HtmlGenericControl("i")
        icon.Attributes("class") = "far fa-file-alt text-black"
        icon.Attributes("style") = "font-size: 26px;"

        Dim iconBox As New HtmlGenericControl("div")
        iconBox.Attributes("class") = "p-2"
        iconBox.Controls.Add(icon)

        Dim title As New HtmlGenericControl("h5")
        title.Attributes("class") = "font-medium"
        title.InnerText = test.title

        Dim description As New HtmlGenericControl("span")
        description.Attributes("class") = "mb-3 d-block"
        description.InnerText = "Description"

        Dim due_ As New HtmlGenericControl("span")
        due_.InnerText = "Due:"

        Dim due_date_Box As New HtmlGenericControl("div")
        due_date_Box.Attributes("class") = "text-muted fs-2 ms-auto mt-2 mt-md-0"
        due_date_Box.Controls.Add(due_)
        due_date_Box.InnerText = test.end_date

        Dim testbox As New HtmlGenericControl("div")
        testbox.Attributes("class") = "comment-text ps-2 ps-md-3 w-100 text-black"
        testbox.Controls.Add(title)
        testbox.Controls.Add(description)
        testbox.Controls.Add(due_date_Box)

        link.Controls.Add(iconBox)
        link.Controls.Add(testbox)
        Return link
    End Function


End Class