Public Class gritermanagement
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadUsers()
    End Sub

    Protected Sub SelectUser(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim id As String = btn.ID.Replace("Select_", "")
        Dim selecteduser As New User
        selecteduser = New User().load(id)
        glano.Value = selecteduser.GLANumber
        username.Value = selecteduser.FName & " " & selecteduser.LName
        userrole.SelectedValue = selecteduser.role
        EnrollmentStatustxt.Value = selecteduser.status
        EnrollmentStatus.SelectedValue = 3
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

        ' Fetch user enrollment info
        Dim userEnrollment As New List(Of Course_Enrollment)
        userEnrollment = New Course_Enrollment().listall("WHERE userId = '" & id & "'")

        ' Generate the enrollment info text
        Dim enrollmentInfo As New StringBuilder()

        For Each enrollment In userEnrollment
            enrollmentInfo.Append("<div class='enrol-info border-bottom'>")
            enrollmentInfo.AppendFormat("<p>Course ID: {0}</p>", enrollment.course_id)
            enrollmentInfo.AppendFormat("<p>Date Started: {0}</p>", enrollment.date_started)
            enrollmentInfo.AppendFormat("<p>Enrollment Status: {0}</p>", enrollment.enrollment_status)
            enrollmentInfo.AppendFormat("<p>Date End: {0}</p>", enrollment.date_end)
            enrollmentInfo.Append("</div>")
        Next

        ' Set the label text to the enrollment info
        lblEnrollmentInfo.Text = enrollmentInfo.ToString()

        ' Show the popup
        pnlEnrollment.Visible = True
        pnlEnrollment.Style("display") = "block"
    End Sub

    Protected Sub btnClose_Click(sender As Object, e As EventArgs)
        ' Hide the popup
        pnlEnrollment.Visible = False
        pnlEnrollment.Style("display") = "none"
    End Sub

    Protected Sub UpdateUser_ServerClick(sender As Object, e As EventArgs)

    End Sub

    Protected Sub RemoveUser_ServerClick(sender As Object, e As EventArgs)

    End Sub
End Class