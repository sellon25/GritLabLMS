Public Class TestsAndAssignments
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Fetch and display the tests for the course
            BindTests()
        End If
    End Sub

    Private Sub BindTests()
        ' Retrieve course ID from query string
        Dim courseId As Integer = Convert.ToInt32(Request.QueryString("courseId"))

        ' Fetch tests for the course
        Dim filter As String = "where course_id='" & courseId & "'"
        Dim tests As List(Of Test) = Test.listall(filter)

        ' Generate the HTML for each test
        For Each test As Test In tests
            TestsContainer.Controls.Add(CreateTestHtml(test))
        Next
    End Sub

    'Private Function CreateTestHtml(test As Test) As HtmlGenericControl
    '    Dim container As New HtmlGenericControl("a")
    '    container.Attributes("class") = "col-md-12 text-black"
    '    container.Attributes("href") = "AssessmentStudentList.aspx?testId=" & test.id

    '    Dim box As New HtmlGenericControl("div")
    '    box.Attributes("class") = "white-box boxShadow d-flex justify-content-between align-items-center"

    '    Dim title As New HtmlGenericControl("h3")
    '    title.Attributes("class") = "box-title"
    '    title.InnerText = test.title

    '    Dim status As New HtmlGenericControl("span")
    '    status.Attributes("style") = If(test.end_date > DateTime.Now, "color: green;", "color: red;")
    '    status.InnerText = If(test.end_date > DateTime.Now, "Open", "Closed")

    '    box.Controls.Add(title)
    '    box.Controls.Add(status)
    '    container.Controls.Add(box)

    '    Return container
    'End Function

    Private Function CreateTestHtml(test As Test) As HtmlGenericControl
        Dim container As New HtmlGenericControl("a")
        container.Attributes("class") = "col-md-12 text-black"

        Dim box As New HtmlGenericControl("div")
        box.Attributes("class") = "white-box boxShadow d-flex justify-content-between align-items-center"

        Dim title As New HtmlGenericControl("h3")
        title.Attributes("class") = "box-title"
        title.InnerText = test.title

        Dim status As New HtmlGenericControl("span")

        If DateTime.Now < test.date_started Then
            status.Attributes("style") = "color: orange;"
            status.InnerText = "Not Open"
            container.Attributes("href") = "EditAssessment.aspx?testId=" & test.id
        ElseIf DateTime.Now <= test.end_date Then
            status.Attributes("style") = "color: green;"
            status.InnerText = "Open"
            container.Attributes("href") = "AssessmentStudentList.aspx?testId=" & test.id
        Else
            status.Attributes("style") = "color: red;"
            status.InnerText = "Closed"
            container.Attributes("href") = "AssessmentStudentList.aspx?testId=" & test.id
        End If

        box.Controls.Add(title)
        box.Controls.Add(status)
        container.Controls.Add(box)

        Return container
    End Function

End Class