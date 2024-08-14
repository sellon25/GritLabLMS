Imports System.Drawing

Public Class Announcements
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If (Session("Type") = "3") Then
                GenerateTable(Session("userID"))
            Else

            End If
        End If
    End Sub


    Private Sub GenerateTable(studentId As String)

        Dim filter As String = "WHERE course_id = '" & Request.QueryString("cId") & "'"
        Dim annoucements_ As List(Of Course_Announcement) = Course_Announcement.listall(filter)

        Dim table As New HtmlGenericControl("table")
        table.Attributes.Add("class", "table no-wrap")

        ' Creating the table header
        Dim thead As New HtmlGenericControl("thead")
        Dim headerRow As New HtmlGenericControl("tr")
        headerRow.Controls.Add(CreateCell("th", ""))
        headerRow.Controls.Add(CreateCell("th", "Description"))
        thead.Controls.Add(headerRow)
        table.Controls.Add(thead)

        ' Creating the table footer
        Dim tfoot As New HtmlGenericControl("tfoot")
        Dim footerRow As New HtmlGenericControl("tr")
        footerRow.Controls.Add(CreateCell("th", ""))
        footerRow.Controls.Add(CreateCell("th", "Description"))
        tfoot.Controls.Add(footerRow)
        table.Controls.Add(tfoot)

        ' Creating the table body
        Dim tbody As New HtmlGenericControl("tbody")

        For Each _announcement As Course_Announcement In annoucements_

            Dim courseannouncement As Announcement = courseannouncement.load(_announcement.announcement_id)

            Dim td2 As New HtmlGenericControl("td")
            td2.Attributes("class") = "text-muted fs-2 ms-auto mt-2 mt-md-0"
            td2.InnerText = courseannouncement.datetime
            'row.Controls.Add(CreateCell("td", _announcement.datetime)) 'use test id to get the name of the test


            Dim title As New HtmlGenericControl("h5")
            title.Attributes("class") = "font-medium"
            title.InnerText = courseannouncement.title

            Dim text As New HtmlGenericControl("span")
            text.Attributes("class") = "mb-3 d-block text-dark"
            text.InnerText = courseannouncement.text

            Dim Post As New HtmlGenericControl("span")
            Post.InnerText = "Post by:"

            Dim author As New HtmlGenericControl("div")
            author.Attributes("class") = "text-muted fs-2 ms-auto mt-2 mt-md-0"
            author.Controls.Add(Post)
            author.InnerText = GetAuthor(courseannouncement.sentby)

            Dim comment As New HtmlGenericControl("div")
            comment.Attributes("class") = "comment-text ps-2 ps-md-3 w-100 text-black"
            comment.Controls.Add(title)
            comment.Controls.Add(text)
            comment.Controls.Add(author)

            Dim td1 As New HtmlGenericControl("td")
            td1.Attributes("class") = "txt-oflo"
            td1.Controls.Add(comment)

            Dim row As New HtmlGenericControl("tr")
            row.Controls.Add(td2)
            row.Controls.Add(td1)

            tbody.Controls.Add(row)
        Next

        'Dim tfoot As New HtmlGenericControl("tfoot")
        'Dim footerRow As New HtmlGenericControl("tr")
        'footerRow.Controls.Add(CreateCell("th", "Assessment"))
        'footerRow.Controls.Add(CreateCell("th", "Your Mark"))
        'footerRow.Controls.Add(CreateCell("th", "Total mark"))
        'footerRow.Controls.Add(CreateCell("th", "Average"))
        'footerRow.Controls.Add(CreateCell("th", "Date"))
        'tfoot.Controls.Add(footerRow)
        'table.Controls.Add(tfoot)



        table.Controls.Add(tbody)
        tableAnnouncements.Controls.Add(table)
    End Sub
    Private Function GetAuthor(userId As String) As String
        Dim filter As String = "WHERE userId ='" & userId & "'"
        Dim user_ As User = user_.load(userId)

        Return user_.LName
    End Function
    Private Function CreateCell(tag As String, innerText As String) As HtmlGenericControl
        Dim cell As New HtmlGenericControl(tag)
        cell.InnerText = innerText
        Return cell
    End Function
End Class