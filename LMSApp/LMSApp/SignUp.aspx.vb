Imports System.Drawing
Imports Microsoft.VisualBasic.ApplicationServices

Public Class SignUp
    Inherits System.Web.UI.Page

    Dim AnswerControls As New List(Of String)()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        AcknowledgementDiv.Visible = False
        LblError.Visible = False
        ApplicationForm.Visible = False
        hiddenuserID.Visible = False
        If Not IsPostBack Then
            OTPform.Visible = False
        End If
        LoadQuestions()
    End Sub

    Protected Sub Register_Click(sender As Object, e As EventArgs)
        Register.Enabled = False
        hiddenuserID.Value = ""

        ' Validate that all required fields are filled
        If String.IsNullOrWhiteSpace(useremail.Value) OrElse
           String.IsNullOrWhiteSpace(userfname.Value) OrElse
           String.IsNullOrWhiteSpace(userlname.Value) OrElse
           String.IsNullOrWhiteSpace(userpassword.Value) OrElse
           String.IsNullOrWhiteSpace(userconfirmp.Value) Then

            LblError.Text = "All fields are required. Please fill in all fields."
            LblError.ForeColor = Color.Red
            LblError.Visible = True
            Register.Enabled = True
            Exit Sub
        End If


        Dim NewUser As New User
        If (userpassword.Value.Trim() = userconfirmp.Value.Trim()) Then
            Dim encryptedPass As String = CipherGate.EncryptString("inovalabs09", userpassword.Value)
            Try
                With NewUser
                    .emailID = useremail.Value
                    .FName = userfname.Value
                    .LName = userlname.Value
                    .password = encryptedPass
                    .role = 3
                    .status = "notVerified"
                    .update()
                End With
            Catch ex As Exception
                LblError.Text = "Email already exists. Try logining in or contact GLA help to confirm your account."
                LblError.ForeColor = Color.Red
                LblError.Visible = True
                Register.Enabled = True
                Exit Sub
            End Try
            hiddenuserID.Value = useremail.Value
            SignUpform.Visible = False
            Dim otp As New SendEmail
            userotp.Value = ""
            HiddenpField.Value = otp.SendOTP("sellondaba25@gmail.com", String.Format("{0} {1}", NewUser.FName, NewUser.LName))
            OTPform.Visible = True
        Else
            LblError.Text = "Passwords do not match!"
            LblError.ForeColor = Color.Red
            LblError.Visible = True
            Register.Enabled = True
        End If
    End Sub
    Protected Sub ResendOTP_Click(sender As Object, e As EventArgs)
        ResendOTP.Enabled = False
        Dim otp As New SendEmail
        userotp.Value = ""
        HiddenpField.Value = otp.SendOTP(hiddenuserID.Value)
        LblError.Text = "OTP has been resent!"
        LblError.ForeColor = Color.Green
        LblError.Visible = True
        ResendOTP.Enabled = True
    End Sub

    Private Function confirmOTP() As Boolean
        Dim confirm As Boolean = False
        If HiddenpField.Value = userotp.Value.Trim() Then
            Dim vuser As User = New User().load(hiddenuserID.Value)
            vuser.status = "New Applicant"
            vuser.update()
            ApplicationForm.Visible = True
            confirm = True
        Else
            lblOtpError.Text = "Incorrect OTP! Try again or Resend OTP."
            lblOtpError.Visible = True
        End If
        Return confirm
    End Function
    Protected Sub SubmitOTP_Click(sender As Object, e As EventArgs)
        If confirmOTP() Then
            LoadQuestions()
            hiddenuserID.Value = useremail.Value
            OTPform.Visible = False
            ApplicationForm.Visible = True
        Else
            OTPform.Visible = True
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

        'Dim btnDelete As New Button()
        'btnDelete.ID = String.Format("btnDelete_{0}", questionId)
        'btnDelete.Text = "Delete"
        'btnDelete.CssClass = "btn-0 border-0 text-danger bg-none float-end"
        'AddHandler btnDelete.Click, AddressOf DeleteQuestion
        'btnDelete.EnableViewState = True

        Dim lblQuestionText As New Label()
        lblQuestionText.CssClass = "col-md-12 p-0"
        lblQuestionText.Text = questionText

        'newQuestionDiv.Controls.Add(btnDelete)
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
                AnswerControls.Add(radioList.ID)

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
                AnswerControls.Add(checkboxList.ID)


            Case "text"
                Dim textInput As New TextBox()
                textInput.ID = String.Format("textInput_{0}", questionId)
                textInput.Attributes("placeholder") = "Type here..."
                textInput.CssClass = "form-control p-0 border-0"
                newQuestionDiv.Controls.Add(textInput)
                newQuestionDiv.Attributes("class") &= " border-bottom"
                AnswerControls.Add(textInput.ID)


            Case "textarea"
                Dim textareaInput As New TextBox()
                textareaInput.ID = String.Format("textareaInput_{0}", questionId)
                textareaInput.TextMode = TextBoxMode.MultiLine
                textareaInput.Rows = 4
                textareaInput.Attributes("placeholder") = "Type here..."
                textareaInput.CssClass = "form-control p-0 border-0"
                newQuestionDiv.Controls.Add(textareaInput)
                newQuestionDiv.Attributes("class") &= " border-bottom"
                AnswerControls.Add(textareaInput.ID)


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
                AnswerControls.Add(selectDropdown.ID)


            Case "number"
                Dim numberInput As New TextBox()
                numberInput.ID = String.Format("numberInput_{0}", questionId)
                numberInput.TextMode = TextBoxMode.Number
                numberInput.Attributes("min") = "0"
                numberInput.Attributes("max") = "25"
                numberInput.Attributes("placeholder") = "Type here..."
                numberInput.CssClass = "form-control p-0 border-0"
                newQuestionDiv.Controls.Add(numberInput)
                newQuestionDiv.Attributes("class") &= " border-bottom"
                AnswerControls.Add(numberInput.ID)

        End Select


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
        SubmitApplication.Enabled = False
        Dim collectedAnswers As New Dictionary(Of String, String)()

        For Each controlID In AnswerControls
            Dim control As Control = FindControl(controlID)
            If control IsNot Nothing Then
                If TypeOf control Is TextBox Then
                    Dim textInput As TextBox = CType(control, TextBox)
                    controlID = controlID.Replace("textInput_", String.Empty)
                    controlID = controlID.Replace("textareaInput_", String.Empty)
                    controlID = controlID.Replace("numberInput_", String.Empty)
                    collectedAnswers.Add(controlID, textInput.Text)
                ElseIf TypeOf control Is RadioButtonList Then
                    Dim radioInput As RadioButtonList = CType(control, RadioButtonList)
                    controlID = controlID.Replace("radioList_", String.Empty)
                    If radioInput.SelectedItem IsNot Nothing Then
                        collectedAnswers.Add(controlID, radioInput.SelectedItem.Text)
                    End If
                ElseIf TypeOf control Is CheckBoxList Then
                    Dim checkboxList As CheckBoxList = CType(control, CheckBoxList)
                    Dim selectedOptions As New List(Of String)()
                    controlID = controlID.Replace("checkboxList_", String.Empty)
                    For Each item As ListItem In checkboxList.Items
                        If item.Selected Then
                            selectedOptions.Add(item.Text)
                        End If
                    Next
                    If selectedOptions.Count > 0 Then
                        collectedAnswers.Add(controlID, String.Join(", ", selectedOptions))
                    End If
                ElseIf TypeOf control Is DropDownList Then
                    controlID = controlID.Replace("selectDropdown_", String.Empty)
                    Dim dropdownInput As DropDownList = CType(control, DropDownList)
                    collectedAnswers.Add(controlID, dropdownInput.SelectedValue)
                End If
            End If
        Next

        Dim reguser As User = New User().load(hiddenuserID.Value)
        If reguser Is Nothing Then
            lblApplError.Text = "There was an error with registering your account please try signing up again."
            Exit Sub
        End If


        For Each kvp In collectedAnswers
            Dim studentAnswer As New StudentAnswer()
            studentAnswer.id = New database_operations().GetNewPrimaryKey("[id]", "[StudentAnswer]", HttpContext.Current.Session("conn"))
            studentAnswer.Answer = kvp.Value
            studentAnswer.student_id = hiddenuserID.Value
            studentAnswer.question_id = kvp.Key
            studentAnswer.update()
        Next

        Dim message As String = "Thank you for applying for Learnboard LAB , we really appreciate the time and effort you have spent to do so." + Environment.NewLine +
             "We are dedicated to acquiring the most dedicated students. We review each application with care to ensure we progress only those candidates who are the best fit for the bootcamp." +
         Environment.NewLine + "You can expect to hear from us as soon as we review your application."

        Dim email As SendEmail = New SendEmail
        email.SendNotification("Sellondaba25@gmail.com", message)

        AcknowledgementDiv.Visible = True
        ' Optionally, redirect or display a message after saving
        ' Response.Redirect("ThankYou.aspx")
    End Sub
End Class
