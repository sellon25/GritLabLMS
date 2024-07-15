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
            'LoadQuestions()
            Dim otp As New SendEmail
            HiddenpField.Value = otp.SendOTP(useremail.Value)
            OTPform.Visible = True

        Else
            LblError.Text = "Passwords do not match!"
            LblError.ForeColor = Color.Red
            LblError.Visible = True
        End If
    End Sub

    Protected Sub ResendOTP_Click(sender As Object, e As EventArgs)
        Dim otp As New SendEmail
        userotp.Value = ""
        HiddenpField.Value = otp.SendOTP(useremail.Value)
    End Sub

    Protected Sub SubmitOTP_Click(sender As Object, e As EventArgs)
        If HiddenpField.Value = userotp.Value.Trim() Then
            ApplicationForm.Visible = True
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
                Dim radioInput1 As New RadioButton()
                radioInput1.ID = String.Format("radioInput1_{0}", questionId)
                radioInput1.GroupName = questionId
                radioInput1.Text = "Option 1"

                Dim radioInput2 As New RadioButton()
                radioInput2.ID = String.Format("radioInput2_{0}", questionId)
                radioInput2.GroupName = questionId
                radioInput2.Text = "Option 2"

                ' Add radio inputs to newQuestionDiv
                newQuestionDiv.Controls.Add(radioInput1)
                newQuestionDiv.Controls.Add(radioInput2)

                ' Add an input and button for radio type questions
                Dim radioTextInput As New TextBox()
                radioTextInput.ID = "rinp-" & questionId
                radioTextInput.Attributes("placeholder") = "Type here..."
                radioTextInput.CssClass = "form-control p-0 border-0"

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
                Dim checkboxInput1 As New CheckBox()
                checkboxInput1.ID = String.Format("checkboxInput1_{0}", questionId)
                checkboxInput1.Text = "Option 1"

                Dim checkboxInput2 As New CheckBox()
                checkboxInput2.ID = String.Format("checkboxInput2_{0}", questionId)
                checkboxInput2.Text = "Option 2"

                ' Add checkbox inputs to newQuestionDiv
                newQuestionDiv.Controls.Add(checkboxInput1)
                newQuestionDiv.Controls.Add(checkboxInput2)

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
                Dim numberInput As New TextBox()
                numberInput.ID = String.Format("numberInput_{0}", questionId)
                numberInput.Attributes("type") = "number"
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
            Dim control As Control = FindControl(controlID)

            If control IsNot Nothing Then
                If TypeOf control Is TextBox Then
                    Dim textInput As TextBox = CType(control, TextBox)
                    Dim enteredText As String = textInput.Text
                    collectedAnswers.Add(controlID, enteredText)
                ElseIf TypeOf control Is RadioButton Then
                    Dim radioInput As RadioButton = CType(control, RadioButton)
                    If radioInput.Checked Then
                        collectedAnswers.Add(controlID, radioInput.Text)
                    End If
                ElseIf TypeOf control Is CheckBox Then
                    Dim checkboxInput As CheckBox = CType(control, CheckBox)
                    If checkboxInput.Checked Then
                        collectedAnswers.Add(controlID, checkboxInput.Text)
                    End If
                ElseIf TypeOf control Is DropDownList Then
                    Dim dropdownInput As DropDownList = CType(control, DropDownList)
                    Dim selectedValue As String = dropdownInput.SelectedValue
                    collectedAnswers.Add(controlID, selectedValue)
                End If
            End If
        Next

        ' Process the collected answers
        For Each kvp In collectedAnswers
            Dim controlID As String = kvp.Key
            Dim answer As String = kvp.Value
            ' Save or process the answer
        Next
    End Sub

    Protected Sub ResendOTP_Click1(sender As Object, e As EventArgs)

    End Sub
End Class