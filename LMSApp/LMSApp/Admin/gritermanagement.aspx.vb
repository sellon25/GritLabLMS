Public Class gritermanagement
    Inherits System.Web.UI.Page

    Private selectedUser As String
    Dim AnswerControls As New List(Of String)()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadUsers()
        'LoadAvailableCourses()
        If Not IsPostBack Then
            pnlEnrollment.Visible = False
        End If

        ApplicationFormPanel.Visible = False
    End Sub

    Protected Sub SelectUser(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ID.Replace("Select_", "")
        Dim selecteduser As New User
        selecteduser = New User().load(id)
        glano.Value = selecteduser.GLANumber
        userFname.Value = selecteduser.FName
        userLname.Value = selecteduser.LName
        useremail.Value = selecteduser.emailID
        userrole.SelectedValue = selecteduser.role
        userroletxt.Value = GetRoleName(selecteduser.role)
        EnrollmentStatustxt.Value = selecteduser.status
        EnrollmentStatus.SelectedValue = 3
    End Sub
    Protected Sub UpdateUser_ServerClick(sender As Object, e As EventArgs)
        Dim userid = useremail.Value.Trim()
        Dim selecteduser As New User
        selecteduser = selecteduser.load(userid)
        With selecteduser
            .FName = New Converter().CapitalizeFirstLetterOfEachWord(userFname.Value)
            .LName = New Converter().CapitalizeFirstLetterOfEachWord(userLname.Value)
            .role = userrole.SelectedValue
            .status = EnrollmentStatus.SelectedItem.Text.Trim()
            .join_date = DateTime.Now
            .update()
        End With

    End Sub
    Protected Sub LoadUsers()
        Dim listUsers As New List(Of User)
        listUsers = New User().listall("where [role]=3 and status != 'Excludeded' ")

        ' Clear existing rows if necessary
        TableUsers.Controls.Clear()

        For Each usr In listUsers
            ' Create a new table row
            Dim row As New HtmlTableRow()

            ' GLA Number
            Dim cellGlaNumber As New HtmlTableCell()
            Dim btnSelect As New Button
            btnSelect.ID = String.Format("Select_{0}", usr.emailID.ToString())
            btnSelect.Attributes("Class") = "btn"
            AddHandler btnSelect.Click, AddressOf SelectUser
            btnSelect.Text = usr.GLANumber.ToString()

            cellGlaNumber.Controls.Add(btnSelect)
            row.Cells.Add(cellGlaNumber)

            ' Name and Surname
            Dim cellName As New HtmlTableCell()
            cellName.InnerText = usr.FName & " " & usr.LName
            row.Cells.Add(cellName)

            ' Email
            Dim cellEmail As New HtmlTableCell()
            cellEmail.InnerText = usr.emailID
            row.Cells.Add(cellEmail)

            ' Role
            Dim cellRole As New HtmlTableCell()
            cellRole.InnerText = GetRoleName(usr.role)
            row.Cells.Add(cellRole)

            ' Status
            Dim cellStatus As New HtmlTableCell()
            cellStatus.InnerText = usr.status
            row.Cells.Add(cellStatus)

            ' Track button
            Dim cellTrack As New HtmlTableCell()
            Dim btnTrack As New Button()
            btnTrack.ID = String.Format("ViewEnrollment_{0}", usr.emailID.ToString())
            btnTrack.Attributes("class") = " btn btn-primary"
            If (usr.status.Trim() = "New Applicant" Or usr.status.Trim() = "Rejected" Or usr.status.Trim() = "Pending Application") Then
                btnTrack.Text = "View Application"
                AddHandler btnTrack.Click, AddressOf ViewApplication
            Else
                btnTrack.Text = "View Enrollment"
                AddHandler btnTrack.Click, AddressOf ViewEnrollment_Click
            End If
            btnTrack.EnableViewState = False

            cellTrack.Controls.Add(btnTrack)
            row.Cells.Add(cellTrack)

            ' Add the row to the table
            TableUsers.Controls.Add(row)
        Next
    End Sub

    Private Sub ViewApplication(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ID.Replace("ViewEnrollment_", "")
        SelectedUserID.Value = id

        LoadQuestions()

        ApplicationFormPanel.Visible = True
        ApplicationFormPanel.Style("display") = "block"

    End Sub
    Private Function GetRoleName(role As Nullable(Of Integer)) As String
        Select Case role
            Case 1
                Return "Admin"
            Case 2
                Return "Manager"
            Case 3
                Return "Student"
            Case Else
                Return "Unknown"
        End Select
    End Function

    Protected Sub ViewEnrollment_Click(sender As Object, e As EventArgs)
        ' Handle the View Enrollment button click event
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ID.Replace("ViewEnrollment_", "")

        ' Fetch user enrollment info
        Dim userEnrollment As New List(Of Course_Enrollment)
        userEnrollment = New Course_Enrollment().listall("WHERE userId = '" & id & "'")

        ' Clear previous enrollment information
        EnrollmentInfo.Controls.Clear()

        ' Generate the enrollment info text
        For Each enrollment In userEnrollment
            ' Create a div to hold enrollment information
            Dim enrolInfoDiv As New HtmlGenericControl("div")
            enrolInfoDiv.Attributes("class") = "enrol-info border-bottom"

            ' Add course ID
            Dim courseIdPara As New HtmlGenericControl("p")
            courseIdPara.InnerText = String.Format("Course ID: {0}", enrollment.course_id)
            enrolInfoDiv.Controls.Add(courseIdPara)

            ' Add date started
            Dim dateStartedPara As New HtmlGenericControl("p")
            dateStartedPara.InnerText = String.Format("Date Started: {0}", enrollment.date_started.ToString())
            enrolInfoDiv.Controls.Add(dateStartedPara)

            ' Add enrollment status
            Dim enrollmentStatusPara As New HtmlGenericControl("p")
            enrollmentStatusPara.InnerText = String.Format("Enrollment Status: {0}", enrollment.enrollment_status)
            enrolInfoDiv.Controls.Add(enrollmentStatusPara)

            ' Add date end
            Dim dateEndPara As New HtmlGenericControl("p")
            dateEndPara.InnerText = String.Format("Date End: {0}", enrollment.date_end.ToString())
            enrolInfoDiv.Controls.Add(dateEndPara)

            ' Add average course mark (assuming it's a property in your ORM)
            Dim averageMarkPara As New HtmlGenericControl("p")
            averageMarkPara.InnerText = String.Format("Average course mark: {0}", GetAverageMark(enrollment.id))
            enrolInfoDiv.Controls.Add(averageMarkPara)

            ' Add remove button
            Dim removeBtn As New Button()
            removeBtn.ID = "RemoveCourse_" & enrollment.id
            removeBtn.CssClass = "btn text-danger m-0 p-0 mt-2"
            removeBtn.Text = "Remove from course"
            removeBtn.EnableViewState = False
            AddHandler removeBtn.Click, AddressOf RemoveCourse_Click
            enrolInfoDiv.Controls.Add(removeBtn)

            ' Add the enrolInfoDiv to the EnrollmentInfo control
            EnrollmentInfo.Controls.Add(enrolInfoDiv)
        Next

        ' Show the popup
        pnlEnrollment.Visible = True
        pnlEnrollment.Style("display") = "block"

    End Sub


    Private Function GetAverageMark(enrollmentId As String) As String
        ' Add logic to fetch the average mark based on the enrollment ID
        Return "85" ' Placeholder value
    End Function


    'Private Sub LoadAvailableCourses()
    '    Dim courses As List(Of Course) = New Course().listall()
    '    CoursesAvailable.Items.Clear()
    '    For Each availableCourse In courses
    '        Dim courseItem As New ListItem
    '        courseItem.Value = availableCourse.id
    '        courseItem.Text = availableCourse.name & "(" & availableCourse.id & ")"
    '        CoursesAvailable.Items.Add(courseItem)
    '    Next
    'End Sub


    Protected Sub btnClose_Click(sender As Object, e As EventArgs)
        ' Hide the popup
        pnlEnrollment.Visible = False
        'pnlEnrollment.Style("display") = "none"
    End Sub



    Protected Sub RemoveUser_ServerClick(sender As Object, e As EventArgs)
        Dim userid = useremail.Value.Trim()
        Dim du As New User
        du = du.load(userid)
        With du
            .status = "Excludeded"
            .end_date = DateTime.Now
            .update()
        End With

    End Sub

    Protected Sub RemoveCourse_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ID.Replace("RemoveCourse_", "")
        Dim enrollment As Course_Enrollment = New Course_Enrollment().load(id)
        enrollment.delete()
    End Sub

    'Protected Sub EnrollStudent_Click(sender As Object, e As EventArgs)
    '    Dim NewEnrollment As New Course_Enrollment
    '    Dim guid As Guid = Guid.NewGuid()
    '    With NewEnrollment
    '        .id = guid.ToString()
    '        .date_started = DateTime.Now
    '        .course_id = CoursesAvailable.SelectedValue.Trim()
    '        .userId = SelectedUserID.Value.Trim()
    '        .enrollment_status = "Active"
    '        .update()
    '    End With
    '    'CoursesAvailable.
    '    pnlEnrollment.Visible = False

    '    Dim btn As New Button
    '    btn.ID = "ViewEnrollment_" + NewEnrollment.userId

    '    ViewEnrollment_Click(btn, Nothing)
    'End Sub

    Protected Sub AcceptApplication_Click(sender As Object, e As EventArgs)
        Dim userid = SelectedUserID.Value.Trim()
        Dim du As New User
        du = du.load(userid)
        With du
            .status = "Active"
            .join_date = DateTime.Now
            .update()
        End With
        ApplicationFormPanel.Visible = False

        Dim newEmail As New SendEmail
        newEmail.SendNotification("sellondaba25@gmail.com", "Congratulations, Your application has been accepted! </br> Your are now officially a Student Of Learnboard africa, we are happy To have you!")

        LoadUsers()
    End Sub

    Protected Sub DeclineApplication_Click(sender As Object, e As EventArgs)
        Dim userid = SelectedUserID.Value.Trim()
        Dim du As New User
        du = du.load(userid)
        With du
            .status = "Rejected"
            .end_date = DateTime.Now
            .update()
        End With
        ApplicationFormPanel.Visible = False
        Dim newEmail As New SendEmail
        newEmail.SendNotification(du.emailID, "It was a pleasure To learn more about you through your application. However, after careful consideration, we unfortunately regret to inform you that your application to Learnboard africa was unsuccessful! </br>")

        LoadUsers()
    End Sub


    Private Sub LoadQuestions()
        Dim questions As List(Of Question_Bank) = Question_Bank.listall(" where ( [Category_ID]='Application Form' or [TestID]='Application Form' ) and QuestionType != 'option' ", " order by QuestionNumber asc ")
        CreatedQuestions.Controls.Clear()

        For Each question In questions
            CreatedQuestions.Controls.Add(AddQuestionHtml(question.id, question.QuestionType, question.Text, SelectedUserID.Value))
        Next
    End Sub
    Protected Function AddQuestionHtml(questionId As String, questionType As String, questionText As String, userId As String) As HtmlGenericControl
        Dim newQuestionDiv As New HtmlGenericControl("div")
        newQuestionDiv.Attributes("class") = "form-group mb-4"

        Dim lblQuestionText As New Label()
        lblQuestionText.CssClass = "col-md-12 p-0"
        lblQuestionText.Text = questionText

        newQuestionDiv.Controls.Add(lblQuestionText)

        Dim answer As String = String.Empty
        Dim studentAnswer As StudentAnswer = studentAnswer.load(questionId, userId)
        If studentAnswer IsNot Nothing Then
            answer = studentAnswer.Answer
        End If

        Select Case questionType
            Case "radio"
                Dim radioList As New RadioButtonList()
                radioList.ID = String.Format("radioList_{0}", questionId)
                radioList.CssClass = "m-2 border-0"

                Dim options As List(Of Question_Bank) = Question_Bank.listall(String.Format(" WHERE [ParentQuestion]='{0}' AND [QuestionType]='option' ", questionId))
                For Each optionText In options
                    radioList.Items.Add(New ListItem(optionText.Text, optionText.id))
                    If optionText.Text.Trim() = answer.Trim() Then
                        answer = optionText.id
                    End If
                Next
                If Not String.IsNullOrEmpty(answer) Then
                    radioList.SelectedValue = answer
                End If
                radioList.Enabled = False
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
                If Not String.IsNullOrEmpty(answer) Then
                    For Each item As ListItem In checkboxList.Items
                        If answer.Contains(item.Text) Then
                            item.Selected = True
                        End If
                    Next
                End If
                checkboxList.Enabled = False
                newQuestionDiv.Controls.Add(checkboxList)
                newQuestionDiv.Attributes("class") &= " border-bottom"
                AnswerControls.Add(checkboxList.ID)

            Case "text"
                Dim textInput As New TextBox()
                textInput.ID = String.Format("textInput_{0}", questionId)
                textInput.Attributes("placeholder") = "Type here..."
                textInput.CssClass = "form-control p-0 border-0"
                textInput.Text = answer
                textInput.ReadOnly = True
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
                textareaInput.Text = answer
                textareaInput.ReadOnly = True
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
                If Not String.IsNullOrEmpty(answer) Then
                    selectDropdown.SelectedValue = answer
                End If
                selectDropdown.Enabled = False
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
                numberInput.Text = answer
                numberInput.ReadOnly = True
                newQuestionDiv.Controls.Add(numberInput)
                newQuestionDiv.Attributes("class") &= " border-bottom"
                AnswerControls.Add(numberInput.ID)
        End Select

        Return newQuestionDiv
    End Function

    'Protected Sub CoursesAvailable_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Dim item As DropDownList = DirectCast(sender, DropDownList)
    '    Dim id = item.SelectedValue

    'End Sub
End Class