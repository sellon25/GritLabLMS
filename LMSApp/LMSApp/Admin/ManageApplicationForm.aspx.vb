Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Web.Services
Imports System.Windows

Public Class ManageApplicationForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadQuestions()

    End Sub

    Protected Sub AddQuestionButton_Click(sender As Object, e As EventArgs)
        Dim questionType As String = questionTypeList.SelectedValue
        Dim questionNum = inputQuestionNum.Value
        Dim questionText As String = inputQuestionText.Value.Trim()
        Dim guid As Guid = Guid.NewGuid()
        Dim newQuestion As New Question_Bank()
        With newQuestion
            .id = guid.ToString()
            .QuestionType = questionType
            .Text = questionText.Trim()
            .Category_ID = "Application Form"
        End With
        Dim validnum = Double.TryParse(questionNum, 0.01)
        If validnum And questionNum IsNot Nothing And questionNum IsNot "" Then
            newQuestion.QuestionNumber = Double.Parse(questionNum, 0.01)
        End If

        newQuestion.update()
        LoadQuestions()
    End Sub

    Private Sub LoadQuestions()
        Dim questions As List(Of Question_Bank) = Question_Bank.listall(" where [Category_ID]='Application Form' ")
        CreatedQuestions.Controls.Clear()

        For Each question In questions
            CreatedQuestions.Controls.Add(AddQuestionHtml(question.id, question.QuestionType, question.Text))
        Next
    End Sub
    Protected Function AddQuestionHtml(questionId As String, questionType As String, questionText As String) As HtmlGenericControl
        ' Create a new HtmlGenericControl representing a <div> element
        Dim newQuestionDiv As New HtmlGenericControl("div")
        newQuestionDiv.Attributes("class") = "form-group mb-4"

        ' Create the delete button
        Dim btnDelete As New Button()
        btnDelete.ID = String.Format("btnDelete_{0}", questionId)
        btnDelete.Text = "Delete"
        btnDelete.CssClass = "btn-0 border-0 text-danger bg-none float-end"
        AddHandler btnDelete.Click, AddressOf DeleteQuestion
        btnDelete.EnableViewState = True

        ' Create the label for the question text
        Dim lblQuestionText As New Label()
        lblQuestionText.CssClass = "col-md-12 p-0"
        lblQuestionText.Text = questionText

        ' Add the delete button and label for question text to the newQuestionDiv
        newQuestionDiv.Controls.Add(btnDelete)
        newQuestionDiv.Controls.Add(lblQuestionText)

        ' Add additional controls based on question type
        Select Case questionType
            Case "radio"
                ' Add radio button inputs and additional controls for radio type questions
                Dim radioInput1 As New HtmlGenericControl("input")
                radioInput1.Attributes("type") = "radio"
                radioInput1.Attributes("name") = questionId
                radioInput1.Attributes("value") = "Option 1"

                Dim radioInput2 As New HtmlGenericControl("input")
                radioInput2.Attributes("type") = "radio"
                radioInput2.Attributes("name") = questionId
                radioInput2.Attributes("value") = "Option 2"

                ' Add radio inputs to newQuestionDiv
                newQuestionDiv.Controls.Add(radioInput1)
                newQuestionDiv.Controls.Add(radioInput2)

                ' Add an input and button for radio type questions
                Dim radioTextInput As New HtmlGenericControl("input")
                radioTextInput.Attributes("id") = "rinp-" & questionId
                radioTextInput.Attributes("type") = "text"
                radioTextInput.Attributes("placeholder") = "Type here..."
                radioTextInput.Attributes("class") = "form-control p-0 border-0"

                Dim addButton As New Button()
                addButton.ID = "btnAddOp_" + questionId
                addButton.Text = "Add"
                addButton.CssClass = "btn mb-2 btn-primary"
                addButton.Style.Add("background-color", "#3C1B50")

                ' Add button click event handler
                AddHandler addButton.Click, AddressOf AddOption

                ' Add input and button to newQuestionDiv
                newQuestionDiv.Controls.Add(radioTextInput)
                newQuestionDiv.Controls.Add(addButton)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "checkbox"
                ' Add checkbox inputs for checkbox type questions
                Dim checkboxInput1 As New HtmlGenericControl("input")
                checkboxInput1.Attributes("type") = "checkbox"
                checkboxInput1.Attributes("name") = questionId
                checkboxInput1.Attributes("value") = "Option 1"

                Dim checkboxInput2 As New HtmlGenericControl("input")
                checkboxInput2.Attributes("type") = "checkbox"
                checkboxInput2.Attributes("name") = questionId
                checkboxInput2.Attributes("value") = "Option 2"

                ' Add checkbox inputs to newQuestionDiv
                newQuestionDiv.Controls.Add(checkboxInput1)
                newQuestionDiv.Controls.Add(checkboxInput2)

            Case "text"
                ' Add input for text type questions
                Dim textInput As New HtmlGenericControl("input")
                textInput.Attributes("type") = "text"
                textInput.Attributes("placeholder") = "Type here..."
                textInput.Attributes("class") = "form-control p-0 border-0"

                ' Add input to newQuestionDiv
                newQuestionDiv.Controls.Add(textInput)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "textarea"
                ' Add textarea for textarea type questions
                Dim textareaInput As New HtmlGenericControl("textarea")
                textareaInput.Attributes("cols") = "1"
                textareaInput.Attributes("rows") = "4"
                textareaInput.Attributes("placeholder") = "Type here..."
                textareaInput.Attributes("class") = "form-control p-0 border-0"

                ' Add textarea to newQuestionDiv
                newQuestionDiv.Controls.Add(textareaInput)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "dropList"
                ' Add select dropdown for dropList type questions
                Dim selectDropdown As New DropDownList
                selectDropdown.Attributes("class") = "form-select shadow-none p-0 border-0 form-control-line"

                ' Add options to select dropdown
                Dim option1 As New ListItem("Game development")
                Dim option2 As New ListItem("Web development")
                Dim option3 As New ListItem("Design")
                Dim option4 As New ListItem("Microsoft360")
                selectDropdown.Items.Add(option1)
                selectDropdown.Items.Add(option2)
                selectDropdown.Items.Add(option3)
                selectDropdown.Items.Add(option4)

                ' Add select dropdown to newQuestionDiv
                newQuestionDiv.Controls.Add(selectDropdown)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "number"
                ' Add input for number type questions
                Dim numberInput As New HtmlGenericControl("input")
                numberInput.Attributes("type") = "number"
                numberInput.Attributes("min") = "0"
                numberInput.Attributes("max") = "10"
                numberInput.Attributes("placeholder") = "Type here..."
                numberInput.Attributes("class") = "form-control p-0 border-0"

                ' Add input to newQuestionDiv
                newQuestionDiv.Controls.Add(numberInput)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"
        End Select

        ' Return the div containing the question content
        Return newQuestionDiv
    End Function


    Protected Sub DeleteQuestion(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim questionId = btn.ID.Replace("btnDelete_", "")
        Dim question As New Question_Bank()
        question = question.load(questionId)
        question.delete()
        LoadQuestions()
    End Sub

    Protected Sub AddOption(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim questionId = btn.ID.Replace("btnAdd_", "")
    End Sub





End Class