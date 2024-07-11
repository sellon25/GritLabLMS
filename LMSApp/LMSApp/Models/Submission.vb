Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Submission
    Inherits ENTITY

    Public Shared Display_id As Boolean = True
    Public Shared Display_title As Boolean = True
    Public Shared Display_text As Boolean = True
    Public Shared Display_file_data As Boolean = True
    Public Shared Display_datetime As Boolean = True
    Public Shared Display_link As Boolean = True
    Public Shared Display_enddate As Boolean = True
    Public Shared Display_project_id As Boolean = True
    Public Shared Display_course_id As Boolean = True

    Private I_Display_id As Boolean = True
    Private I_Display_title As Boolean = True
    Private I_Display_text As Boolean = True
    Private I_Display_file_data As Boolean = True
    Private I_Display_datetime As Boolean = True
    Private I_Display_link As Boolean = True
    Private I_Display_enddate As Boolean = True
    Private I_Display_project_id As Boolean = True
    Private I_Display_course_id As Boolean = True

    Public previous_id As Nullable(Of System.Int32)

    Public id As Nullable(Of System.Int32)
    Public title As System.String
    Public text As System.String
    Public file_data As System.Byte()
    Public datetime As Nullable(Of System.DateTime)
    Public link As System.String
    Public enddate As Nullable(Of System.DateTime)
    Public project_id As System.String
    Public course_id As System.String

    Private newinstance As Boolean = True

    Shared Sub Set_Display_Field_All(display_flag As Boolean)
        Display_id = display_flag
        Display_title = display_flag
        Display_text = display_flag
        Display_file_data = display_flag
        Display_datetime = display_flag
        Display_link = display_flag
        Display_enddate = display_flag
        Display_project_id = display_flag
        Display_course_id = display_flag
    End Sub

    Private Sub insert()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Submission (id,title,text,file_data,link,enddate,datetime,project_id,course_id)"
        cmd.CommandText = cmd.CommandText & "values(@id,@title,@text,@file_data,@link,@enddate,@datetime,@project_id,@course_id)"

        cmd.Parameters.Add("@id", 8, 0, "id")
        cmd.Parameters("@id").Value = setNull(id)
        cmd.Parameters.Add("@title", 22, 255, "title")
        cmd.Parameters("@title").Value = setNull(title)
        cmd.Parameters.Add("@text", 18, 2147483647, "text")
        cmd.Parameters("@text").Value = setNull(text)
        cmd.Parameters.Add("@link", 18, 2147483647, "link")
        cmd.Parameters("@link").Value = setNull(link)
        cmd.Parameters.Add("@file_data", 21, -1, "file_data")
        cmd.Parameters("@file_data").Value = setNull(file_data)
        cmd.Parameters.Add("@datetime", 4, 0, "datetime")
        cmd.Parameters("@datetime").Value = setNull(datetime)
        cmd.Parameters.Add("@enddate", 4, 0, "enddate")
        cmd.Parameters("@enddate").Value = setNull(enddate)
        cmd.Parameters.Add("@project_id", 22, 255, "project_id")
        cmd.Parameters("@project_id").Value = setNull(project_id)
        cmd.Parameters.Add("@course_id", 22, 255, "course_id")
        cmd.Parameters("@course_id").Value = setNull(course_id)

        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub

    Sub delete()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from Submission where id=@previous_id"
        cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
        cmd.Parameters("@previous_id").Value = Me.previous_id

        cmd.ExecuteNonQuery()
    End Sub

    Shared Function load(id As System.Int32) As Submission
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "id,"
        If Display_title = True Then cmd.CommandText = cmd.CommandText & "title,"
        If Display_text = True Then cmd.CommandText = cmd.CommandText & "text,"
        If Display_file_data = True Then cmd.CommandText = cmd.CommandText & "file_data,"
        If Display_datetime = True Then cmd.CommandText = cmd.CommandText & "link,"
        If Display_datetime = True Then cmd.CommandText = cmd.CommandText & "enddate,"
        If Display_datetime = True Then cmd.CommandText = cmd.CommandText & "datetime,"
        If Display_project_id = True Then cmd.CommandText = cmd.CommandText & "project_id,"
        If Display_course_id = True Then cmd.CommandText = cmd.CommandText & "course_id,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Submission where id=@id"
        cmd.Parameters.Add("@id", 8, 0, "id")
        cmd.Parameters("@id").Value = id

        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        Dim p As New Submission
        For i = 0 To dt.Rows.Count - 1
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_title = True Then p.title = checkNull(dt.Rows(i)("title"))
            p.I_Display_title = Display_title
            If Display_text = True Then p.text = checkNull(dt.Rows(i)("text"))
            p.I_Display_text = Display_text
            If Display_file_data = True Then p.file_data = checkNull(dt.Rows(i)("file_data"))
            p.I_Display_file_data = Display_file_data
            If Display_link = True Then p.link = checkNull(dt.Rows(i)("link"))
            p.I_Display_link = Display_link
            If Display_datetime = True Then p.datetime = checkNull(dt.Rows(i)("datetime"))
            p.I_Display_datetime = Display_datetime
            If Display_enddate = True Then p.enddate = checkNull(dt.Rows(i)("enddate"))
            p.I_Display_enddate = Display_enddate
            If Display_project_id = True Then p.project_id = checkNull(dt.Rows(i)("project_id"))
            p.I_Display_project_id = Display_project_id
            If Display_course_id = True Then p.course_id = checkNull(dt.Rows(i)("course_id"))
            p.I_Display_course_id = Display_course_id
            p.previous_id = checkNull(dt.Rows(i)("id"))
            p.newinstance = False
            Return p
        Next
        Return Nothing
    End Function

    Sub update()
        If newinstance = True Then
            insert()
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update Submission set "
        cmd.CommandText = cmd.CommandText & " id=@id,"
        If I_Display_title = True Then cmd.CommandText = cmd.CommandText & " title=@title,"
        If I_Display_text = True Then cmd.CommandText = cmd.CommandText & " text=@text,"
        If I_Display_file_data = True Then cmd.CommandText = cmd.CommandText & " file_data=@file_data,"
        If I_Display_link = True Then cmd.CommandText = cmd.CommandText & " link=@link,"
        If I_Display_datetime = True Then cmd.CommandText = cmd.CommandText & " datetime=@datetime,"
        If I_Display_enddate = True Then cmd.CommandText = cmd.CommandText & " enddate=@enddate,"
        If I_Display_project_id = True Then cmd.CommandText = cmd.CommandText & " project_id=@project_id,"
        If I_Display_course_id = True Then cmd.CommandText = cmd.CommandText & " course_id=@course_id,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " where id=@previous_id"

        cmd.Parameters.Add("@id", 8, 0, "id")
        cmd.Parameters("@id").Value = setNull(id)

        If I_Display_title = True Then cmd.Parameters.Add("@title", 22, 255, "title")
        If I_Display_title = True Then cmd.Parameters("@title").Value = setNull(title)

        If I_Display_text = True Then cmd.Parameters.Add("@text", 18, 2147483647, "text")
        If I_Display_text = True Then cmd.Parameters("@text").Value = setNull(text)

        If I_Display_link = True Then cmd.Parameters.Add("@link", 18, 2147483647, "link")
        If I_Display_link = True Then cmd.Parameters("@link").Value = setNull(link)

        If I_Display_file_data = True Then cmd.Parameters.Add("@file_data", 21, -1, "file_data")
        If I_Display_file_data = True Then cmd.Parameters("@file_data").Value = setNull(file_data)

        If I_Display_datetime = True Then cmd.Parameters.Add("@datetime", 4, 0, "datetime")
        If I_Display_datetime = True Then cmd.Parameters("@datetime").Value = setNull(datetime)

        If I_Display_enddate = True Then cmd.Parameters.Add("@enddate", 4, 0, "enddate")
        If I_Display_enddate = True Then cmd.Parameters("@enddate").Value = setNull(enddate)

        If I_Display_project_id = True Then cmd.Parameters.Add("@project_id", 22, 255, "project_id")
        If I_Display_project_id = True Then cmd.Parameters("@project_id").Value = setNull(project_id)

        If I_Display_course_id = True Then cmd.Parameters.Add("@course_id", 22, 255, "course_id")
        If I_Display_course_id = True Then cmd.Parameters("@course_id").Value = setNull(course_id)

        cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
        cmd.Parameters("@previous_id").Value = Me.previous_id

        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub

    Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Submission)
        Dim ps As New Generic.List(Of Submission)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "id,"
        If Display_title = True Then cmd.CommandText = cmd.CommandText & "title,"
        If Display_text = True Then cmd.CommandText = cmd.CommandText & "text,"
        If Display_link = True Then cmd.CommandText = cmd.CommandText & "link,"
        If Display_file_data = True Then cmd.CommandText = cmd.CommandText & "file_data,"
        If Display_datetime = True Then cmd.CommandText = cmd.CommandText & "datetime,"
        If Display_enddate = True Then cmd.CommandText = cmd.CommandText & "enddate,"
        If Display_project_id = True Then cmd.CommandText = cmd.CommandText & "project_id,"
        If Display_course_id = True Then cmd.CommandText = cmd.CommandText & "course_id,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Submission " & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Submission
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_title = True Then p.title = checkNull(dt.Rows(i)("title"))
            p.I_Display_title = Display_title
            If Display_text = True Then p.text = checkNull(dt.Rows(i)("text"))
            p.I_Display_text = Display_text
            If Display_file_data = True Then p.file_data = checkNull(dt.Rows(i)("file_data"))
            p.I_Display_file_data = Display_file_data
            If Display_link = True Then p.link = checkNull(dt.Rows(i)("link"))
            p.I_Display_link = Display_link
            If Display_datetime = True Then p.datetime = checkNull(dt.Rows(i)("datetime"))
            p.I_Display_datetime = Display_datetime
            If Display_enddate = True Then p.enddate = checkNull(dt.Rows(i)("enddate"))
            p.I_Display_enddate = Display_enddate
            If Display_project_id = True Then p.project_id = checkNull(dt.Rows(i)("project_id"))
            p.I_Display_project_id = Display_project_id
            If Display_course_id = True Then p.course_id = checkNull(dt.Rows(i)("course_id"))
            p.I_Display_course_id = Display_course_id
            p.previous_id = checkNull(dt.Rows(i)("id"))
            p.newinstance = False
            ps.Add(p)
        Next
        Return ps
    End Function

    Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Submission)
        Dim ps As New Generic.List(Of Submission)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select id from Submission" & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Submission
            p.id = checkNull(dt.Rows(i)("id"))
            p.previous_id = checkNull(dt.Rows(i)("id"))
            p.newinstance = False
            ps.Add(p)
        Next
        Return ps
    End Function
End Class
