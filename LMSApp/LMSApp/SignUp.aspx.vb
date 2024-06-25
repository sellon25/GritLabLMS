Imports System.Drawing

Public Class SignUp
    Inherits System.Web.UI.Page

    Dim AnswerControls As New List(Of String)()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LblError.Visible = False
        ApplicationForm.Visible = False
        LoadQuestions()

    End Sub

    Protected Sub Register_Click(sender As Object, e As EventArgs)
        Dim NewUser As New User
        If (userpassword.Value.Trim() = userconfirmp.Value.Trim()) Then
            Dim encrytptedpass As String = CipherGate.EncryptString("inovalabs09", userpassword.Value)

            With NewUser
                .emailID = useremail.Value
                .FName = userfname.Value
                .LName = userlname.Value
                .password = encrytptedpass
                .role = 3
                .status = "New Applicant"
                .update()
            End With
            SignUpform.Visible = False
            LoadQuestions()
            ApplicationForm.Visible = True

        Else
            LblError.Text = "Passwords do not match!"
            LblError.ForeColor = Color.Red
            LblError.Visible = True
        End If
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
        newQuestionDiv.Attributes("class") = "form-group mb-4 border-bottom"

        ' Create the label for the question text
        Dim lblQuestionText As New Label()
        lblQuestionText.CssClass = "col-md-12 p-0"
        lblQuestionText.Text = questionText

        ' Add the delete button and label for question text to the newQuestionDiv
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
                'newQuestionDiv.Attributes("class") &= " border-bottom"

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
                textInput.ID = String.Format("textInput_{0}", questionId)
                textInput.Attributes("runat") = "server"
                textInput.Attributes("type") = "text"
                textInput.Attributes("placeholder") = "Type here..."
                textInput.Attributes("class") = "form-control p-0 border-0"

                ' Add input to newQuestionDiv
                newQuestionDiv.Controls.Add(textInput)
                AnswerControls.Add(textInput.ID)
                ' Add border-bottom class to the div for styling
                'newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "textarea"
                ' Add textarea for textarea type questions
                Dim textInput As New TextBox()
                textInput.ID = String.Format("textInput_{0}", questionId)
                textInput.Attributes("runat") = "server"
                textInput.Attributes("placeholder") = "Type here..."
                textInput.CssClass = "form-control p-0 border-0"

                ' Add input to newQuestionDiv
                newQuestionDiv.Controls.Add(textInput)
                AnswerControls.Add(textInput.ID)

                ' Add border-bottom class to the div for styling
                'newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "dropList"
                ' Add select dropdown for dropList type questions
                Dim selectDropdown As New RadioButtonList
                selectDropdown.Attributes("class") = "form-select shadow-none p-0 border-0 form-control-line"

                ' Add options to select dropdown
                Dim option1 As New ListItem("Option 1")
                Dim option2 As New ListItem("Option 2")
                selectDropdown.Items.Add(option1)
                selectDropdown.Items.Add(option2)

                ' Add select dropdown to newQuestionDiv
                newQuestionDiv.Controls.Add(selectDropdown)

                ' Add border-bottom class to the div for styling
                'newQuestionDiv.Attributes("class") &= " border-bottom"

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
                'newQuestionDiv.Attributes("class") &= " border-bottom"
        End Select

        ' Return the div containing the question content
        Return newQuestionDiv
    End Function


    Protected Sub DeleteQuestion(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim questionId = btn.ID.Replace("btnDelete_", "")
        Dim question As New Question_Bank()
        question = question.load(questionId)
        'question.delete()
        LoadQuestions()
    End Sub

    Protected Sub AddOption(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim questionId = btn.ID.Replace("btnAdd_", "")

    End Sub

    Protected Sub SubmitApplication_Click(sender As Object, e As EventArgs)
        Dim collectedAnswers As New Dictionary(Of String, String)()

        For Each controlID In AnswerControls
            ' Find the control by its ID
            Dim textInput As TextBox = CType(FindControl(controlID), TextBox)

            If textInput IsNot Nothing Then
                ' Get the entered text value
                Dim enteredText As String = textInput.Text

                ' Collect the answer
                collectedAnswers.Add(controlID, enteredText)
            End If
        Next


        For Each kvp In collectedAnswers
            Dim controlID As String = kvp.Key
            Dim answer As String = kvp.Value
            ' Save or process the answer
        Next
    End Sub
End Class