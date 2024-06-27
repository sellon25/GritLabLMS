Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Class StudentsProgress
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindStudentProgress()
        End If
    End Sub

    Private Sub BindStudentProgress(Optional ByVal filter As String = Nothing, Optional ByVal sort As String = Nothing)
        Try
            ' Retrieve the list of students from the database using the ORM with optional filter and sort parameters
            Dim courseEnrollment As New Course_Enrollment()
            Dim students As List(Of Course_Enrollment)

            If String.IsNullOrEmpty(filter) Then
                students = courseEnrollment.listall(sortstr:=sort)
            Else
                students = courseEnrollment.listall(filterstr:="userId LIKE '%" & filter & "%'", sortstr:=sort)
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
                    studentsHtml.AppendFormat("<td class='text-black'>{0}</td>", student.enrollment_status)
                    studentsHtml.AppendFormat("<td class='text-black'>{0}</td>", student.date_end)
                    studentsHtml.AppendFormat("<td class='text-black'><a href='mailto:{0}'>{0}</a></td>", student.userId)
                    studentsHtml.AppendFormat("<td><a href='#' class='breadcrumb-link font-bold'>Track Progress</a></td>")
                    studentsHtml.Append("</tr>")
                Next
            Else
                studentsHtml.Append("<tr><td colspan='8' class='text-center'>No students found</td></tr>")
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

    Protected StudentsTableBody As HtmlGenericControl

    Protected Sub applyFilter()
        Dim filter As String = txtSearch.Value ' Adjust filter logic as needed
        Dim sort As String = ddlFilter.Items(ddlFilter.SelectedIndex).Value ' Adjust sort logic as needed
        BindStudentProgress(filter, sort)
    End Sub

    Protected Sub resetFilter()
        txtSearch.Value = ""
        ddlFilter.SelectedIndex = 0
        BindStudentProgress()
    End Sub

    Protected Sub Resert_Click(sender As Object, e As EventArgs)
        resetFilter()
    End Sub

    Protected Sub ApplyFilter_Click(sender As Object, e As EventArgs)
        applyFilter()
    End Sub
End Class
