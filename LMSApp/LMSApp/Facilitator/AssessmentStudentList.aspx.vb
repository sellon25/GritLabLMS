Imports LMSApp.Admin

Public Class AssessmentStudentList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindStudentResults()

    End Sub

    Private Sub BindStudentResults()
        Dim testId As String = Request.QueryString("testId")
        Dim filter As String = "WHERE test_id = '" & Request.QueryString("testId") & "'"
        Dim studentResults As List(Of StudentResults) = New StudentResults().listall(filter)

        ' Clear existing rows
        tblStudentResults.Rows.Clear()

        ' Create table header
        Dim headerRow As New TableRow()
        headerRow.Cells.Add(CreateTableCell("Student Email", True))
        headerRow.Cells.Add(CreateTableCell("Mark", True))
        headerRow.Cells.Add(CreateTableCell("Status", True))
        headerRow.Cells.Add(CreateTableCell("", True))
        tblStudentResults.Rows.Add(headerRow)

        ' Populate table with data
        For Each result As StudentResults In studentResults
            Dim row As New TableRow()
            row.Cells.Add(CreateTableCell(result.student_id))
            row.Cells.Add(CreateTableCell(If(result.score.HasValue, result.score.Value.ToString(), "-")))
            row.Cells.Add(CreateTableCell(If(result.comment IsNot Nothing, result.comment, "-")))
            row.Cells.Add(CreateTableCell($"<button class='btn btn-primary' onclick=""location.href='MarkAssessment.aspx?studentId={result.id}&testId={testId}'"">Mark Assessment</button>"))
            tblStudentResults.Rows.Add(row)
        Next
    End Sub

    Private Function CreateTableCell(text As String, Optional isHeader As Boolean = False) As TableCell
        Dim cell As New TableCell()
        If isHeader Then
            cell.Text = $"<strong>{text}</strong>"
        Else
            cell.Text = text
        End If
        Return cell
    End Function
End Class