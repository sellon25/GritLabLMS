Public Class gritermanagement
    Inherits System.Web.UI.Page

    Private selectedUser As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadUsers()
        LoadAvailableCourses()
    End Sub

    Protected Sub SelectUser(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ID.Replace("Select_", "")
        Dim selecteduser As New User
        selecteduser = New User().load(id)
        glano.Value = selecteduser.GLANumber
        userFname.Value = selecteduser.FName
        userLname.Value = selecteduser.LName
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
        listUsers = New User().listall("where [role]=3")

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
            btnTrack.Text = "View Enrolment"
            AddHandler btnTrack.Click, AddressOf ViewEnrollment_Click
            cellTrack.Controls.Add(btnTrack)
            row.Cells.Add(cellTrack)

            ' Add the row to the table
            TableUsers.Controls.Add(row)
        Next
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
        SelectedUserID.Value = id
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
            Dim removeBtnDiv As New HtmlGenericControl("div")
            removeBtnDiv.Attributes("class") = "w-100 d-flex justify-content-end"
            Dim removeBtn As New Button()
            removeBtn.ID = "RemoveCourse_" & enrollment.id
            removeBtn.CssClass = "btn text-danger m-0 p-0 mt-2"
            removeBtn.Text = "Remove"
            AddHandler removeBtn.Click, AddressOf RemoveCourse_Click
            removeBtnDiv.Controls.Add(removeBtn)
            enrolInfoDiv.Controls.Add(removeBtnDiv)

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
    End Sub



    Protected Sub RemoveUser_ServerClick(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ID.Replace("RemoveCourse_", "")
        Dim enrollment As Course_Enrollment = New Course_Enrollment().load(id)
        enrollment.delete()

    End Sub

    Protected Sub RemoveCourse_Click(sender As Object, e As EventArgs)

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
    End Sub
End Class