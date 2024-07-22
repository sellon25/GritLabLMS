Imports System.Net.Mail
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic.ApplicationServices

Public Class StudentsProgress
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim filter As String = Nothing
            BindStudentProgress(filter)
        End If
    End Sub

    Private Sub BindStudentProgress(ByVal filter As String)
        Try
            ' Retrieve the list of students from the database using the ORM with optional filter and sort parameters
            Dim courseEnrollment As New Course_Enrollment()
            Dim students As List(Of Course_Enrollment)

            ' Example of handling filter by User ID (assuming no changes to listall function)
            If Not String.IsNullOrEmpty(filter) Then
                ' Ensure the filter is properly formatted for SQL query
                students = courseEnrollment.listall(filterstr:="WHERE " & filter)
            Else
                students = courseEnrollment.listall()
            End If

            ' Build the HTML for the students table
            Dim studentsHtml As New System.Text.StringBuilder()
            If students IsNot Nothing AndAlso students.Count > 0 Then
                For Each student As Course_Enrollment In students
                    studentsHtml.Append("<tr>")
                    studentsHtml.AppendFormat("<td>{0}</td>", student.id)
                    studentsHtml.AppendFormat("<td class='txt-oflo text-black'>{0}</td>", student.userId)
                    studentsHtml.AppendFormat("<td class='text-black'>{0}</td>", student.course_id)
                    studentsHtml.AppendFormat("<td class='text-black'>{0}</td>", student.date_started)
                    studentsHtml.AppendFormat("<td class='text-black'>
                        <select id='ddlStatus_{0}' onchange='updateStatus({0})' class='form-control'>
                            <option value='Enrolled' {1}>Enrolled</option>
                            <option value='Completed' {2}>Completed</option>
                            <option value='Dropped' {3}>Dropped</option>
                        </select>
                    </td>", student.id, If(student.enrollment_status = "Enrolled", "selected", ""), If(student.enrollment_status = "Completed", "selected", ""), If(student.enrollment_status = "Dropped", "selected", ""))
                    studentsHtml.AppendFormat("<td class='text-black'>{0}</td>", student.date_end)
                    studentsHtml.AppendFormat("<td class='text-black'><a href='mailto:{0}'>{0}</a></td>", student.userId)
                    studentsHtml.Append("</tr>")
                Next
            Else
                ' Display "User Not Found" message if no records are found
                studentsHtml.Append("<tr><td colspan='8' class='text-center'>User Not Found.</td></tr>")
            End If

            ' Add the students HTML to the table body
            StudentsTableBody.InnerHtml = studentsHtml.ToString()
        Catch ex As Exception
            ' Log the error (you can use a logging library or write to a file for real-world applications)
            System.Diagnostics.Debug.WriteLine(ex.Message)
            ' Display the error message in the table
            StudentsTableBody.InnerHtml = String.Format("<tr><td colspan='8' class='text-center'>An error occurred while retrieving data: {0}</td></tr>", ex.Message)
        End Try
    End Sub

    Protected Sub ApplyFilter_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim searchQuery As String = txtSearch.Value.Trim()

        Dim filter As String = Nothing
        If Not String.IsNullOrEmpty(searchQuery) Then
            ' Construct the filter string to apply to the WHERE clause
            filter = String.Format("userId LIKE '%{0}%'", searchQuery.Replace("'", "''"))
        End If

        ' Call BindStudentProgress with the constructed filter
        BindStudentProgress(filter)
    End Sub

    Protected Sub ResetFilter_Click(ByVal sender As Object, ByVal e As EventArgs)
        txtSearch.Value = String.Empty
        Dim filter As String = Nothing
        BindStudentProgress(filter)
    End Sub

    Protected Sub UpdateStatus_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim studentId As String = hfStudentId.Value
        Dim newStatus As String = hfStatus.Value

        Try
            Dim enrollment As New Course_Enrollment()
            enrollment = enrollment.load(studentId)
            If enrollment IsNot Nothing Then
                enrollment.enrollment_status = newStatus
                enrollment.update()
                ' Optionally, provide feedback that the status was updated
                System.Diagnostics.Debug.WriteLine("Status updated successfully!")
            Else
                ' Handle the case where the enrollment record is not found
                System.Diagnostics.Debug.WriteLine("Enrollment record not found.")
            End If
        Catch ex As Exception
            ' Handle any errors
            System.Diagnostics.Debug.WriteLine("Error updating status: " & ex.Message)
        End Try

        ' Rebind the student progress list to reflect the changes
        BindStudentProgress(txtSearch.Value.Trim())
    End Sub

    Protected Sub SendEmail_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            ' Get email details from the form inputs
            Dim toEmail As String = SendToEmail.Value.Trim()
            Dim subject As String = Subjects.Value.Trim()
            Dim body As String = EmailBody.Value.Trim()

            ' Fetch user details by userId
            Dim user As User = New User().load(toEmail)

            If user IsNot Nothing Then
                ' Customize the email body with the user's details
                body = String.Format("Hello {0} {1}, {2}", user.FName, user.LName, body)
            Else
                ' Handle the case where the user is not found
                System.Diagnostics.Debug.WriteLine("User not found.")
                Exit Sub
            End If

            ' Create an instance of the SendEmail class
            Dim emailSender As New SendEmail()

            ' Send the email notification using the userId
            emailSender.SendNotification(toEmail, subject, body)

            ' Optionally, show a success message or handle any post-send actions
            System.Diagnostics.Debug.WriteLine("Email sent successfully!")
        Catch ex As Exception
            ' Handle any errors that occur during the email sending process
            System.Diagnostics.Debug.WriteLine("Error sending email: " & ex.Message)
        End Try
    End Sub

    Protected StudentsTableBody As HtmlGenericControl

End Class
