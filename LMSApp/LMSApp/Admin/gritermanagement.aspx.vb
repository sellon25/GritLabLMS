Public Class gritermanagement
    Inherits System.Web.UI.Page

    Private selectedUser As String
    Dim AnswerControls As New List(Of String)()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadUsers()

        pnlEnrollment.Visible = False
        ApplicationFormPanel.Visible = False
        If Not IsPostBack Then
            ' Initial load logic
            LoadAvailableCourses()
        Else
            ' Recreate dynamic controls on postback
            Dim userId As String = SelectedUserID.Value
            If Not String.IsNullOrEmpty(userId) Then
                PopulateEnrollmentInfo(userId)
            End If
        End If
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

        Response.Redirect("gritermanagement.aspx")
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
            If (usr.status = "New Applicant") Then
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
            Case 4
                Return "Employee"
            Case Else
                Return "Unknown"
        End Select
    End Function

    Protected Sub ViewEnrollment_Click(sender As Object, e As EventArgs)
        ' Handle the View Enrollment button click event
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ID.Replace("ViewEnrollment_", "")

        ' Store the selected user ID in a hidden field
        SelectedUserID.Value = id

        ' Populate the enrollment information
        PopulateEnrollmentInfo(id)

        ' Show the popup
        pnlEnrollment.Visible = True
        pnlEnrollment.Style("display") = "block"
    End Sub
    Private Sub PopulateEnrollmentInfo(userId As String)
        ' Fetch user enrollment info
        Dim userEnrollment As New List(Of Course_Enrollment)
        userEnrollment = New Course_Enrollment().listall("WHERE userId = '" & userId & "'")

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
            removeBtn.Text = "Remove"
            removeBtn.EnableViewState = False
            AddHandler removeBtn.Click, AddressOf RemoveCourse_Click
            enrolInfoDiv.Controls.Add(removeBtn)

            ' Add the enrolInfoDiv to the EnrollmentInfo control
            EnrollmentInfo.Controls.Add(enrolInfoDiv)
        Next
<<<<<<< Updated upstream

        ' Show the popup
        pnlEnrollment.Visible = True
        pnlEnrollment.Style("display") = "block"
=======
>>>>>>> Stashed changes
    End Sub

    Private Function GetAverageMark(enrollmentId As String) As String
        ' Add logic to fetch the average mark based on the enrollment ID
        Return "85" ' Placeholder value
    End Function


    Private Sub LoadAvailableCourses()
        Dim courses As List(Of Course) = New Course().listall()
        CoursesAvailable.Items.Clear()
        For Each availableCourse In courses
            Dim courseItem As New ListItem
            courseItem.Value = availableCourse.id
            courseItem.Text = availableCourse.name & "(" & availableCourse.id & ")"
            CoursesAvailable.Items.Add(courseItem)
        Next
    End Sub


    Protected Sub btnClose_Click(sender As Object, e As EventArgs)
        ' Hide the popup
        pnlEnrollment.Visible = False
        pnlEnrollment.Style("display") = "none"
        SelectedUserID.Value = String.Empty
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

        Dim btn2 As New Button
        btn2.ID = "ViewEnrollment_" + SelectedUserID.Value

        ViewEnrollment_Click(btn, Nothing)

    End Sub

    Protected Sub EnrollStudent_Click(sender As Object, e As EventArgs)
        Dim NewEnrollment As New Course_Enrollment
        Dim guid As Guid = Guid.NewGuid()
        With NewEnrollment
            .id = guid.ToString()
            .date_started = DateTime.Now
            .course_id = CoursesAvailable.SelectedValue.Trim()
            .userId = SelectedUserID.Value.Trim()
            .enrollment_status = "Active"
            .update()
        End With
        'CoursesAvailable.
        pnlEnrollment.Visible = False

        Dim btn As New Button
        btn.ID = "ViewEnrollment_" + NewEnrollment.userId

        ViewEnrollment_Click(btn, Nothing)
    End Sub

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
        LoadUsers()
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
                'AddHandler addButton.Click, AddressOf AddOption

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

    Protected Sub CoursesAvailable_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim x = CoursesAvailable.SelectedValue
    End Sub
End Class