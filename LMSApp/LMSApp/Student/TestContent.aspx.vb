Public Class TestContent
    Inherits System.Web.UI.Page
    Dim studentAnswers As List(Of String)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadtest()
    End Sub

    Private Sub loadtest()
        Dim filter As String = "WHERE TestID ='" & Request.QueryString("testid") & "'"

        ' Initialize the studentAnswers list
        studentAnswers = New List(Of String)

        ' Get the list of questions based on the filter
        Dim questions As List(Of Question_Bank) = Question_Bank.listall(filter)

        For Each question As Question_Bank In questions
            ' Add the question ID to the studentAnswers list
            studentAnswers.Add(question.id.ToString())

            ' Add the question HTML to the test content
            testContent.Controls.Add(CreateQuestionHtml(question))
        Next question

        ' Create and add the submit button to the test content
        Dim submitbutton As New HtmlGenericControl("div")
        submitbutton.Attributes("class") = "col-sm-12"
        submitbutton.Controls.Add(createsubmitbutton(Request.QueryString("testid")))

        Dim submitbox As New HtmlGenericControl("div")
        submitbox.Attributes("class") = "form-group mb-4"
        submitbox.Controls.Add(submitbutton)

        testContent.Controls.Add(submitbox)
    End Sub

    Private Function createsubmitbutton(testid As Integer) As Button
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
        Submit_Test()
    End Sub
    Private Sub Submit_Test()

    End Sub
    Private Function CreateQuestionHtml(question As Question_Bank) As HtmlGenericControl

        Dim question_type As String = question.Category_ID
        'Dim question_type As String = question.QuestionType
        Dim text As New HtmlGenericControl("label")
        text.Attributes("class") = "col-md-12 p-0"
        text.InnerText = question.QuestionNumber & ". " & question.Text

        Dim answerbox As New HtmlGenericControl("div")
        'answerbox.Attributes("class") = "col-md-12 border-bottom p-0"

        'Dim break As New HtmlGenericControl("br")
        Select Case (question_type)
            'Case "text"

            Case "oneWord"
                answerbox.Attributes("class") = "col-md-12 border-bottom p-0"
                answerbox.Controls.Add(createOneWord(question))

            Case "multipleChoice"
                answerbox.Attributes("class") = "col-md-12 border-bottom p-0"
                answerbox.Controls.Add(createRadiolist(question))

            Case "dropList"
                answerbox.Attributes("class") = "col-md-12 border-bottom"
                answerbox.Controls.Add(createDroplist(question))

            Case "textArea"
                answerbox.Attributes("class") = "col-md-12 border-bottom p-0"
                answerbox.Controls.Add(createMultilineText(question))
                'Case "digits"

        End Select

        Dim questionbox As New HtmlGenericControl("div")
        questionbox.Attributes("class") = "form-group mb-4"
        questionbox.Controls.Add(text)
        questionbox.Controls.Add(answerbox)

        Return questionbox

    End Function
    Private Function createMultilineText(question As Question_Bank) As TextBox
        Dim multiTextbox As New TextBox
        multiTextbox.ID = String.Format("textInput{0}", question.id)
        multiTextbox.Attributes("class") = "form-control p-0 border-0"
        multiTextbox.Attributes("placeholder") = "Type here..."
        multiTextbox.Attributes("rows") = "5"
        Return multiTextbox
    End Function
    Private Function createOneWord(question As Question_Bank) As TextBox
        Dim text_box As New TextBox
        text_box.ID = String.Format("textInput_{0}", question.id)
        text_box.Attributes("placeholder") = "Type here..."
        text_box.Attributes("class") = "form-control p-0 border-0"
        text_box.Attributes("name") = question.id

        Return text_box

    End Function
    Private Function createRadiolist(question As Question_Bank) As RadioButtonList
        Dim _radioList As New RadioButtonList
        _radioList.ID = String.Format("_radioList{0}", question.id)
        _radioList.Attributes("class") = "col-md-12 border-bottom p-0"
        ' Create ListItem objects for each option
        Dim option1 As New ListItem(question.Option1)
        Dim option2 As New ListItem(question.Option2)
        Dim option3 As New ListItem(question.Option3)
        Dim option4 As New ListItem(question.Option4)

        ' Check if each option is not Nothing or an empty string before adding
        If Not String.IsNullOrEmpty(question.Option1) Then _radioList.Items.Add(option1)
        If Not String.IsNullOrEmpty(question.Option2) Then _radioList.Items.Add(option2)
        If Not String.IsNullOrEmpty(question.Option3) Then _radioList.Items.Add(option3)
        If Not String.IsNullOrEmpty(question.Option4) Then _radioList.Items.Add(option4)

        Return _radioList
    End Function

    Private Function createDroplist(question As Question_Bank) As DropDownList
        Dim _dropdownlist As New DropDownList
        _dropdownlist.ID = String.Format("_dropdownlist{0}", question.id)
        _dropdownlist.Attributes("class") = "form-select shadow-none p-0 border-0 form-control-line"
        ' Create ListItem objects for each option
        Dim option1 As New ListItem(question.Option1)
        Dim option2 As New ListItem(question.Option2)
        Dim option3 As New ListItem(question.Option3)
        Dim option4 As New ListItem(question.Option4)

        ' Check if each option is not Nothing or an empty string before adding
        If Not String.IsNullOrEmpty(question.Option1) Then _dropdownlist.Items.Add(option1)
        If Not String.IsNullOrEmpty(question.Option2) Then _dropdownlist.Items.Add(option2)
        If Not String.IsNullOrEmpty(question.Option3) Then _dropdownlist.Items.Add(option3)
        If Not String.IsNullOrEmpty(question.Option4) Then _dropdownlist.Items.Add(option4)

        Return _dropdownlist
    End Function

    'Private Function createAnswerHtml(answerText As String, questionID As Integer) As HtmlGenericControl
    '    Dim container As New HtmlGenericControl("div")

    '    If answerText = Nothing Then Return Nothing

    '    Dim input As New RadioButton()
    '    'input.Attributes("type") = "radio"
    '    input.Attributes("id") = answerText & "_" & questionID
    '    input.Attributes("value") = answerText
    '    input.Attributes("name") = "question_" & questionID
    '    container.Controls.Add(input)

    '    Dim label As New HtmlGenericControl("label")
    '    label.Attributes("for") = answerText & "_" & questionID
    '    label.InnerText = answerText
    '    container.Controls.Add(label)

    '    Dim break As New HtmlGenericControl("br")
    '    container.Controls.Add(break)

    '    'Dim input As New HtmlGenericControl("input")
    '    'input.Attributes("type") = "radio"
    '    'input.Attributes("id") = answerText & "_" & questionID
    '    'input.Attributes("value") = answerText
    '    'input.Attributes("name") = "question_" & questionID
    '    'container.Controls.Add(input)



    '    Return container
    'End Function


    'Private Function answersnotnull(question As Question_Bank) As Integer
    '    Dim count As Integer = 0
    '    If IsNothing(question.Option1) = False Then count += 1
    '    If IsNothing(question.Option2) = False Then count += 1
    '    If IsNothing(question.Option3) = False Then count += 1
    '    If IsNothing(question.Option4) = False Then count += 1
    '    Return count
    'End Function
End Class