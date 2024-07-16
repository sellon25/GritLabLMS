Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography
Imports System.Web.Services
Imports System.Windows

Public Class ManageApplicationForm
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadQuestions()
        If Not IsPostBack Then
            ' Initial rendering of options

        End If
        RenderOptions()
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

        ' Insert options if applicable
        If OptionsList IsNot Nothing AndAlso OptionsList.Count > 0 Then
            For Each optionText As String In OptionsList
                Dim optionGuid As Guid = Guid.NewGuid()
                Dim optionQuestion As New Question_Bank()
                With optionQuestion
                    .id = optionGuid.ToString()
                    .QuestionType = "option" ' or any specific type you want to use for options
                    .Text = optionText
                    .Category_ID = "Application Form"
                    .ParentQuestion = newQuestion.id
                End With
                optionQuestion.update()
            Next
        End If

        ' Clear the options list after insertion
        OptionsList.Clear()

        newQuestion.update()
        LoadQuestions()
        Response.Redirect(Request.Url.ToString())
    End Sub

    Private Sub LoadQuestions()
        Dim questions As List(Of Question_Bank) = Question_Bank.listall(" where [Category_ID]='Application Form' and [QuestionType] != 'option' ")
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
                ' Add RadioButtonList for radio type questions
                Dim radioList As New RadioButtonList()
                radioList.ID = String.Format("radioList_{0}", questionId)
                radioList.CssClass = "m-2 border-0"

                ' Fetch options for this radio type question
                Dim options As List(Of Question_Bank) = Question_Bank.listall(String.Format(" WHERE [ParentQuestion]='{0}' AND [QuestionType]='option' ", questionId))

                ' Add options to RadioButtonList
                For Each optionText In options
                    radioList.Items.Add(New ListItem(optionText.Text, optionText.id))
                Next

                ' Add RadioButtonList to newQuestionDiv
                newQuestionDiv.Controls.Add(radioList)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"


            Case "checkbox"
                ' Add CheckBoxList for checkbox type questions
                Dim checkboxList As New CheckBoxList()
                checkboxList.ID = String.Format("checkboxList_{0}", questionId)
                checkboxList.CssClass = "m-2 border-0"

                ' Fetch options for this checkbox type question
                Dim options As List(Of Question_Bank) = Question_Bank.listall(String.Format(" WHERE [ParentQuestion]='{0}' AND [QuestionType]='option' ", questionId))

                ' Add options to CheckBoxList
                For Each optionText In options
                    checkboxList.Items.Add(New ListItem(optionText.Text, optionText.id))
                Next

                ' Add CheckBoxList to newQuestionDiv
                newQuestionDiv.Controls.Add(checkboxList)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "text"
                ' Add input for text type questions
                Dim textInput As New TextBox()
                textInput.ID = String.Format("textInput_{0}", questionId)
                textInput.Attributes("placeholder") = "Type here..."
                textInput.CssClass = "form-control p-0 border-0"

                ' Add input to newQuestionDiv
                newQuestionDiv.Controls.Add(textInput)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "textarea"
                ' Add textarea for textarea type questions
                Dim textareaInput As New TextBox()
                textareaInput.ID = String.Format("textareaInput_{0}", questionId)
                textareaInput.TextMode = TextBoxMode.MultiLine
                textareaInput.Rows = 4
                textareaInput.Attributes("placeholder") = "Type here..."
                textareaInput.CssClass = "form-control p-0 border-0"

                ' Add textarea to newQuestionDiv
                newQuestionDiv.Controls.Add(textareaInput)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "dropList"
                ' Add select dropdown for dropList type questions
                Dim selectDropdown As New DropDownList()
                selectDropdown.ID = String.Format("selectDropdown_{0}", questionId)
                selectDropdown.CssClass = "form-select shadow-none p-0 border-0 form-control-line"

                ' Fetch options for this dropList question
                Dim options As List(Of Question_Bank) = Question_Bank.listall(String.Format(" WHERE [ParentQuestion]='{0}' AND [QuestionType]='option' ", questionId))

                ' Add options to select dropdown
                For Each optionText In options
                    selectDropdown.Items.Add(New ListItem(optionText.Text, optionText.id))
                Next

                ' Add select dropdown to newQuestionDiv
                newQuestionDiv.Controls.Add(selectDropdown)

                ' Add border-bottom class to the div for styling
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "number"
                ' Add input for number type questions
                Dim numberInput As New TextBox()
                numberInput.ID = String.Format("numberInput_{0}", questionId)
                numberInput.TextMode = TextBoxMode.Number
                numberInput.Attributes("min") = "0"
                numberInput.Attributes("max") = "10"
                numberInput.Attributes("placeholder") = "Type here..."
                numberInput.CssClass = "form-control p-0 border-0"

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

        Dim sdtAnswers As StudentAnswer = New StudentAnswer
        sdtAnswers.delete(String.Format(" where [question_id]='{0}'", question.id))


        question.delete()



        LoadQuestions()
    End Sub

    Protected Sub AddOption(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim questionId = btn.ID.Replace("btnAdd_", "")
    End Sub

    ' Property to manage the options list using ViewState
    Private Property OptionsList As List(Of String)
        Get
            If ViewState("OptionsList") Is Nothing Then
                ViewState("OptionsList") = New List(Of String)()
            End If
            Return CType(ViewState("OptionsList"), List(Of String))
        End Get
        Set(value As List(Of String))
            ViewState("OptionsList") = value
        End Set
    End Property

    Protected Sub questionTypeList_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim selectedType As String = questionTypeList.SelectedValue

        If selectedType = "radio" OrElse selectedType = "checkbox" OrElse selectedType = "dropList" Then
            pnlAdditionalOptions.Visible = True
        Else
            pnlAdditionalOptions.Visible = False
        End If
    End Sub

    Protected Sub AddOption_Click(sender As Object, e As EventArgs)
        If Not String.IsNullOrWhiteSpace(txtOption.Text) Then
            ' Add the new option to the list
            OptionsList.Add(txtOption.Text)

            ' Clear the text box
            txtOption.Text = String.Empty

            ' Re-render the options
            RenderOptions()
        End If
    End Sub

    Private Sub RenderOptions()
        ' Clear existing controls
        phOptions.Controls.Clear()

        ' Render each option
        For Each optionText As String In OptionsList
            ' Create a new placeholder div for the option
            Dim optionDiv As New HtmlGenericControl("div")
            optionDiv.Attributes("class") = "option-item"

            ' Create a label to display the option text
            Dim optionLabel As New Label()
            optionLabel.Text = optionText
            optionLabel.CssClass = "col-md-10 p-0"

            ' Create a button to remove the option
            Dim removeButton As New Button()
            removeButton.Text = "Remove"
            removeButton.CssClass = "btn text-danger float-end"
            removeButton.CommandArgument = optionText
            AddHandler removeButton.Click, AddressOf RemoveOption_Click

            ' Add the label and remove button to the option div
            optionDiv.Controls.Add(optionLabel)
            optionDiv.Controls.Add(removeButton)

            ' Add the option div to the placeholder
            phOptions.Controls.Add(optionDiv)
        Next
    End Sub

    Protected Sub RemoveOption_Click(sender As Object, e As EventArgs)
        Dim button As Button = CType(sender, Button)
        Dim optionText As String = button.CommandArgument

        ' Remove the option from the list
        OptionsList.Remove(optionText)

        ' Re-render the options
        RenderOptions()
    End Sub




End Class