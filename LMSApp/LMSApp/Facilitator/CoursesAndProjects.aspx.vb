Imports System.Data
Imports System.Data.SqlClient

Public Class CoursesAndProjects
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Type") IsNot Nothing AndAlso Session("Type").ToString() = "2" Then
                BindCoursesAndProjects()
            Else
                ' Redirect to an appropriate page if the user is not a facilitator
                Response.Redirect("~/Unauthorized.aspx")
            End If
        End If
    End Sub

    Private Sub BindCoursesAndProjects()
        Dim facilitatorId As String = Session("ID").ToString()

        ' Fetch courses and projects
        Dim courses As DataTable = GetCoursesByFacilitator(facilitatorId)
        Dim projects As DataTable = GetProjectsByFacilitator(facilitatorId)


        ' Bind courses
        CoursesRepeater.DataSource = courses
        CoursesRepeater.DataBind()

        ' Bind projects
        ProjectsRepeater.DataSource = projects
        ProjectsRepeater.DataBind()
    End Sub


    Private Function GetCoursesByFacilitator(facilitatorId As String) As DataTable
        Dim dt As New DataTable()
        Dim conn As SqlConnection = DirectCast(HttpContext.Current.Session("conn"), SqlConnection)

        Dim query As String = "SELECT id, name, thumbnail, description, facilitator, overview, status, date_started, end_date FROM Course WHERE facilitator = @facilitator"
        Using cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@facilitator", facilitatorId)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        End Using

        Return dt
    End Function

    Private Function GetProjectsByFacilitator(facilitatorId As String) As DataTable
        Dim dt As New DataTable()
        Dim conn As SqlConnection = DirectCast(HttpContext.Current.Session("conn"), SqlConnection)

        Dim query As String = "SELECT id, name, thumbnail, description, facilitator, overview, status, avg_progress, date_started, end_date FROM Project WHERE facilitator = @facilitator"
        Using cmd As New SqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@facilitator", facilitatorId)
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dt)
        End Using

        Return dt
    End Function


    Private Sub LogColumns(dt As DataTable, tableName As String)
        Response.Write("Table: " & tableName & "<br/>")
        For Each column As DataColumn In dt.Columns
            Response.Write("Column: " & column.ColumnName & "<br/>")
        Next
    End Sub

    Private Sub LogDataTable(dt As DataTable, tableName As String)
        Response.Write("Table: " & tableName & "<br/>")
        For Each row As DataRow In dt.Rows
            For Each column As DataColumn In dt.Columns
                Response.Write(column.ColumnName & ": " & row(column.ColumnName).ToString() & "<br/>")
            Next
            Response.Write("<br/>")
        Next
    End Sub


    Public Function GetImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso thumbnail IsNot DBNull.Value Then
            ' Convert the thumbnail to a base64 string
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        ' Return a default image URL if no thumbnail is available
        Return "../plugins/images/sldr.jpg"
    End Function

    Public Function GetProjectImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso thumbnail IsNot DBNull.Value Then
            ' Convert the thumbnail to a base64 string
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        ' Return a default image URL if no thumbnail is available
        Return "../plugins/images/Squid-Game-1.jpg"
    End Function
End Class
