Public Class CourseResults
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not IsPostBack) Then
            Session("Type") = "3"
            If Session("Type").ToString() = "3" Then
                GenerateTable("student@g.com")
            Else
                Dim noStudentIdMessage As New HtmlGenericControl("p")
                noStudentIdMessage.InnerText = "No student ID provided."
                TableContainer.Controls.Add(noStudentIdMessage)
            End If
        End If
    End Sub
    Private Sub GenerateTable(studentId As String)
        ' Assuming the model StudentResults has a method listall to fetch all records and supports filtering
        Dim filter As String = "WHERE student_id = '" & studentId & "'"
        Dim results As List(Of StudentResults) = StudentResults.listall(filter)

        Dim table As New HtmlGenericControl("table")
        table.Attributes.Add("class", "table no-wrap")

        ' Creating the table header
        Dim thead As New HtmlGenericControl("thead")
        Dim headerRow As New HtmlGenericControl("tr")
        headerRow.Controls.Add(CreateCell("th", "Assessment"))
        headerRow.Controls.Add(CreateCell("th", "Your Mark"))
        headerRow.Controls.Add(CreateCell("th", "Total mark"))
        headerRow.Controls.Add(CreateCell("th", "Average"))
        headerRow.Controls.Add(CreateCell("th", "Date"))
        thead.Controls.Add(headerRow)
        table.Controls.Add(thead)

        ' Creating the table footer
        Dim tfoot As New HtmlGenericControl("tfoot")
        Dim footerRow As New HtmlGenericControl("tr")
        footerRow.Controls.Add(CreateCell("th", "Assessment"))
        footerRow.Controls.Add(CreateCell("th", "Your Mark"))
        footerRow.Controls.Add(CreateCell("th", "Total mark"))
        footerRow.Controls.Add(CreateCell("th", "Average"))
        footerRow.Controls.Add(CreateCell("th", "Date"))
        tfoot.Controls.Add(footerRow)
        table.Controls.Add(tfoot)

        ' Creating the table body
        Dim tbody As New HtmlGenericControl("tbody")

        For Each result As StudentResults In results
            Dim row As New HtmlGenericControl("tr")
            row.Controls.Add(CreateCell("td", result.test_id)) 'use test id to get the name of the test
            row.Controls.Add(CreateCell("td", result.score.ToString()))
            'row.Controls.Add(CreateCell("td", "100")) ' (Placeholder for total mark) use test id to get the tottal mark for the test
            row.Controls.Add(CreateCell("td", "82")) ' Placeholder for average use test ud to get the average for the test 
            row.Controls.Add(CreateCell("td", result.mark_date.ToString()))
            tbody.Controls.Add(row)
        Next

        table.Controls.Add(tbody)
        TableContainer.Controls.Add(table)
    End Sub

    Private Function CreateCell(tag As String, innerText As String) As HtmlGenericControl
        Dim cell As New HtmlGenericControl(tag)
        cell.InnerText = innerText
        Return cell
    End Function
End Class