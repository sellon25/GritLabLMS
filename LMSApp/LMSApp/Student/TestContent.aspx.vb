Public Class TestContent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadtest()
    End Sub
    Private Sub loadtest()
        Dim filter As String = "WHERE TestID ='" & Request.QueryString("testid") & "'"

        Dim questions As List(Of Question_Bank) = Question_Bank.listall(filter)


        For Each question As Question_Bank In questions
            testContent.Controls.Add(CreateQuestionHtml(question))
        Next question

        Dim submitbutton As New HtmlGenericControl("div")
        submitbutton.Attributes("class") = "col-sm-12"

        submitbutton.Controls.Add(createsubmitID(Request.QueryString("testid")))

        Dim submitbox As New HtmlGenericControl("div")
        submitbox.Attributes("class") = "form-group mb-4"
        submitbox.Controls.Add(submitbutton)

        testContent.Controls.Add(submitbox)
    End Sub
    Private Function createsubmitID(testid As Integer) As Button
        Dim submitButton As New Button()
        submitButton.ID = String.Format("SubmitTest_{0}", testid)
        submitButton.Text = "Submit"
        submitButton.Attributes("class") = "btn btn-orange"
        'submitButton.Style.Add("height", "fit-content")
        'submitButton.Attributes("data-content-id") = test.id.ToString()
        AddHandler submitButton.Click, AddressOf SubmitTest
        Return submitButton
    End Function
    Protected Sub SubmitTest(ByVal sender As Object, ByVal e As EventArgs)
        'Submit_Test()
    End Sub

    Private Function CreateQuestionHtml(question As Question_Bank) As HtmlGenericControl

        Dim question_type As String = question.Category_ID
        Dim text As New HtmlGenericControl("label")
        Dim answerbox As New HtmlGenericControl("div")

        Dim break As New HtmlGenericControl("br")
        Select Case (question_type)
            Case "oneWord"

            Case "multipleChoice"
                text.Attributes("class") = "col-md-12 p-0"
                text.InnerText = question.Text
                answerbox.Attributes("class") = "col-md-12 border-bottom p-0"
                answerbox.Controls.Add(createAnswerHtml(question.Option1, question.id))
                answerbox.Controls.Add(createAnswerHtml(question.Option2, question.id))
                answerbox.Controls.Add(createAnswerHtml(question.Option3, question.id))
                answerbox.Controls.Add(createAnswerHtml(question.Option4, question.id))

        End Select

        Dim questionbox As New HtmlGenericControl("div")
        questionbox.Attributes("class") = "form-group mb-4"
        questionbox.Controls.Add(text)
        questionbox.Controls.Add(answerbox)

        Return questionbox

    End Function

    Private Function createAnswerHtml(answerText As String, questionID As Integer) As HtmlGenericControl
        Dim container As New HtmlGenericControl("div")

        Dim input As New HtmlGenericControl("input")
        input.Attributes("type") = "radio"
        input.Attributes("id") = answerText & "_" & questionID
        input.Attributes("value") = answerText
        input.Attributes("name") = "question_" & questionID
        container.Controls.Add(input)

        Dim label As New HtmlGenericControl("label")
        label.Attributes("for") = answerText & "_" & questionID
        label.InnerText = answerText
        container.Controls.Add(label)

        Dim break As New HtmlGenericControl("br")
        container.Controls.Add(break)

        Return container
    End Function


    Private Function answersnotnull(question As Question_Bank) As Integer
        Dim count As Integer = 0
        If IsNothing(question.Option1) = False Then count += 1
        If IsNothing(question.Option2) = False Then count += 1
        If IsNothing(question.Option3) = False Then count += 1
        If IsNothing(question.Option4) = False Then count += 1
        Return count
    End Function
End Class