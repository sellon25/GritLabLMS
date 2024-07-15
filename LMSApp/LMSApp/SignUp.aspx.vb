Imports System.Drawing

Public Class SignUp
    Inherits System.Web.UI.Page

    Dim AnswerControls As New List(Of String)()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        LblError.Visible = False
        ApplicationForm.Visible = False
        LoadQuestions()
    End Sub

    Protected Sub Register_Click(sender As Object, e As EventArgs)
        Dim NewUser As New User
        If (userpassword.Value.Trim() = userconfirmp.Value.Trim()) Then
            Dim encryptedPass As String = CipherGate.EncryptString("inovalabs09", userpassword.Value)

            With NewUser
                .emailID = useremail.Value
                .FName = userfname.Value
                .LName = userlname.Value
                .password = encryptedPass
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
        Dim questions As List(Of Question_Bank) = Question_Bank.listall(" WHERE [Category_ID]='Application Form' AND [QuestionType]!='option' ")
        CreatedQuestions.Controls.Clear()

        For Each question In questions
            CreatedQuestions.Controls.Add(AddQuestionHtml(question.id, question.QuestionType, question.Text))
        Next
    End Sub

    Protected Function AddQuestionHtml(questionId As String, questionType As String, questionText As String) As HtmlGenericControl
        Dim newQuestionDiv As New HtmlGenericControl("div")
        newQuestionDiv.Attributes("class") = "form-group mb-4"

        Dim btnDelete As New Button()
        btnDelete.ID = String.Format("btnDelete_{0}", questionId)
        btnDelete.Text = "Delete"
        btnDelete.CssClass = "btn-0 border-0 text-danger bg-none float-end"
        AddHandler btnDelete.Click, AddressOf DeleteQuestion
        btnDelete.EnableViewState = True

        Dim lblQuestionText As New Label()
        lblQuestionText.CssClass = "col-md-12 p-0"
        lblQuestionText.Text = questionText

        newQuestionDiv.Controls.Add(btnDelete)
        newQuestionDiv.Controls.Add(lblQuestionText)

        Select Case questionType
            Case "radio"
                Dim radioList As New RadioButtonList()
                radioList.ID = String.Format("radioList_{0}", questionId)
                radioList.CssClass = "m-2 border-0"

                Dim options As List(Of Question_Bank) = Question_Bank.listall(String.Format(" WHERE [ParentQuestion]='{0}' AND [QuestionType]='option' ", questionId))
                For Each optionText In options
                    radioList.Items.Add(New ListItem(optionText.Text, optionText.id))
                Next
                newQuestionDiv.Controls.Add(radioList)
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "checkbox"
                Dim checkboxList As New CheckBoxList()
                checkboxList.ID = String.Format("checkboxList_{0}", questionId)
                checkboxList.CssClass = "m-2 border-0"

                Dim options As List(Of Question_Bank) = Question_Bank.listall(String.Format(" WHERE [ParentQuestion]='{0}' AND [QuestionType]='option' ", questionId))
                For Each optionText In options
                    checkboxList.Items.Add(New ListItem(optionText.Text, optionText.id))
                Next
                newQuestionDiv.Controls.Add(checkboxList)
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "text"
                Dim textInput As New TextBox()
                textInput.ID = String.Format("textInput_{0}", questionId)
                textInput.Attributes("placeholder") = "Type here..."
                textInput.CssClass = "form-control p-0 border-0"
                newQuestionDiv.Controls.Add(textInput)
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "textarea"
                Dim textareaInput As New TextBox()
                textareaInput.ID = String.Format("textareaInput_{0}", questionId)
                textareaInput.TextMode = TextBoxMode.MultiLine
                textareaInput.Rows = 4
                textareaInput.Attributes("placeholder") = "Type here..."
                textareaInput.CssClass = "form-control p-0 border-0"
                newQuestionDiv.Controls.Add(textareaInput)
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "dropList"
                Dim selectDropdown As New DropDownList()
                selectDropdown.ID = String.Format("selectDropdown_{0}", questionId)
                selectDropdown.CssClass = "form-select shadow-none p-0 border-0 form-control-line"
                Dim options As List(Of Question_Bank) = Question_Bank.listall(String.Format(" WHERE [ParentQuestion]='{0}' AND [QuestionType]='option' ", questionId))
                For Each optionText In options
                    selectDropdown.Items.Add(New ListItem(optionText.Text, optionText.id))
                Next
                newQuestionDiv.Controls.Add(selectDropdown)
                newQuestionDiv.Attributes("class") &= " border-bottom"

            Case "number"
                Dim numberInput As New TextBox()
                numberInput.ID = String.Format("numberInput_{0}", questionId)
                numberInput.Attributes("type") = "number"
                numberInput.Attributes("min") = "0"
                numberInput.Attributes("max") = "10"
                numberInput.Attributes("placeholder") = "Type here..."
                numberInput.CssClass = "form-control p-0 border-0"
                newQuestionDiv.Controls.Add(numberInput)
                newQuestionDiv.Attributes("class") &= " border-bottom"
        End Select

        AnswerControls.Add(questionId)
        Return newQuestionDiv
    End Function

    Protected Sub DeleteQuestion(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim questionId = btn.ID.Replace("btnDelete_", "")
        Dim question As New Question_Bank()
        question = question.load(questionId)
        LoadQuestions()
    End Sub

    Protected Sub SubmitApplication_Click(sender As Object, e As EventArgs)
        Dim collectedAnswers As New Dictionary(Of String, String)()

        For Each controlID In AnswerControls
            Dim control As Control = FindControl(controlID)
            If control IsNot Nothing Then
                If TypeOf control Is TextBox Then
                    Dim textInput As TextBox = CType(control, TextBox)
                    collectedAnswers.Add(controlID, textInput.Text)
                ElseIf TypeOf control Is RadioButtonList Then
                    Dim radioInput As RadioButtonList = CType(control, RadioButtonList)
                    If radioInput.SelectedItem IsNot Nothing Then
                        collectedAnswers.Add(controlID, radioInput.SelectedItem.Text)
                    End If
                ElseIf TypeOf control Is CheckBoxList Then
                    Dim checkboxList As CheckBoxList = CType(control, CheckBoxList)
                    Dim selectedOptions As New List(Of String)()
                    For Each item As ListItem In checkboxList.Items
                        If item.Selected Then
                            selectedOptions.Add(item.Text)
                        End If
                    Next
                    If selectedOptions.Count > 0 Then
                        collectedAnswers.Add(controlID, String.Join(", ", selectedOptions))
                    End If
                ElseIf TypeOf control Is DropDownList Then
                    Dim dropdownInput As DropDownList = CType(control, DropDownList)
                    collectedAnswers.Add(controlID, dropdownInput.SelectedValue)
                End If
            End If
        Next

        For Each kvp In collectedAnswers
            Dim studentAnswer As New StudentAnswer()
            studentAnswer.id = New database_operations().GetNewPrimaryKey("[id]", "[StudentAnswer]", HttpContext.Current.Session("conn"))
            studentAnswer.Answer = kvp.Value
            studentAnswer.student_id = "your_student_id_here" ' Replace with actual student ID
            studentAnswer.question_id = kvp.Key
            studentAnswer.update()
        Next

        ' Optionally, redirect or display a message after saving
        ' Response.Redirect("ThankYou.aspx")
    End Sub
End Class
