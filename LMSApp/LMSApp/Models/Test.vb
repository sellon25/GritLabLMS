Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Test
inherits Entity

Public Shared Display_id as Boolean=True
    Public Shared Display_title As Boolean = True
    Public Shared Display_project_id As Boolean = True
    Public Shared Display_course_id As Boolean = True
    Public Shared Display_date_started As Boolean = True
    Public Shared Display_end_date As Boolean = True

    Private I_Display_id As Boolean = True
    Private I_Display_title As Boolean = True
    Private I_Display_project_id As Boolean = True
    Private I_Display_course_id As Boolean = True
    Private I_Display_date_started As Boolean = True
    Private I_Display_end_date As Boolean = True

    Public previous_id As System.String

    Public id As System.String
    Public title As System.String
    Public project_id As System.String
    Public course_id As System.String
    Public date_started As Nullable(Of System.DateTime)
    Public end_date As Nullable(Of System.DateTime)
    Private newinstance As Boolean = True

    Shared Sub Set_Display_Field_All(display_flag As Boolean)
        Display_id = display_flag
        Display_title = display_flag
        Display_project_id = display_flag
        Display_course_id = display_flag
        Display_date_started = display_flag
        Display_end_date = display_flag
    End Sub


    Private Sub insert()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Test (id,title,project_id,course_id,date_started,end_date)"
        cmd.CommandText = cmd.CommandText & "values(@id,@title,@project_id,@course_id,@date_started,@end_date)"

        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = setNull(id)
        cmd.Parameters.Add("@title", 22, 255, "title")
        cmd.Parameters("@title").Value = setNull(title)
        cmd.Parameters.Add("@project_id", 22, 255, "project_id")
        cmd.Parameters("@project_id").Value = setNull(project_id)
        cmd.Parameters.Add("@course_id", 22, 255, "course_id")
        cmd.Parameters("@course_id").Value = setNull(course_id)
        cmd.Parameters.Add("@date_started", 4, 0, "date_started")
        cmd.Parameters("@date_started").Value = setNull(date_started)
        cmd.Parameters.Add("@end_date", 4, 0, "end_date")
        cmd.Parameters("@end_date").Value = setNull(end_date)


        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub


    Sub delete()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from Test where id=@previous_id"
        cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
        cmd.Parameters("@previous_id").Value = Me.previous_id

        cmd.ExecuteNonQuery()
    End Sub


    Shared Function load(id As System.Int32) As Test
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "id,"
        If Display_title = True Then cmd.CommandText = cmd.CommandText & "title,"
        If Display_project_id = True Then cmd.CommandText = cmd.CommandText & "project_id,"
        If Display_course_id = True Then cmd.CommandText = cmd.CommandText & "course_id,"
        If Display_date_started = True Then cmd.CommandText = cmd.CommandText & "date_started,"
        If Display_end_date = True Then cmd.CommandText = cmd.CommandText & "end_date,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Test where id=@id"
        cmd.Parameters.Add("@id", 8, 0, "id")
        cmd.Parameters("@id").Value = id

        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        Dim p As New Test
        For i = 0 To dt.Rows.Count - 1
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_title = True Then p.title = checkNull(dt.Rows(i)("title"))
            p.I_Display_title = Display_title
            If Display_project_id = True Then p.project_id = checkNull(dt.Rows(i)("project_id"))
            p.I_Display_project_id = Display_project_id
            If Display_course_id = True Then p.course_id = checkNull(dt.Rows(i)("course_id"))
            p.I_Display_course_id = Display_course_id
            If Display_date_started = True Then p.date_started = checkNull(dt.Rows(i)("date_started"))
            p.I_Display_date_started = Display_date_started
            If Display_end_date = True Then p.end_date = checkNull(dt.Rows(i)("end_date"))
            p.I_Display_end_date = Display_end_date
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
        cmd.CommandText = "update Test set "
        cmd.CommandText = cmd.CommandText & " id=@id,"
        If I_Display_title = True Then cmd.CommandText = cmd.CommandText & " title=@title,"
        If I_Display_project_id = True Then cmd.CommandText = cmd.CommandText & " project_id=@project_id,"
        If I_Display_course_id = True Then cmd.CommandText = cmd.CommandText & " course_id=@course_id,"
        If I_Display_date_started = True Then cmd.CommandText = cmd.CommandText & " date_started=@date_started,"
        If I_Display_end_date = True Then cmd.CommandText = cmd.CommandText & " end_date=@end_date,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " where id=@previous_id"


        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = setNull(id)

        If I_Display_title = True Then cmd.Parameters.Add("@title", 22, 255, "title")
        If I_Display_title = True Then cmd.Parameters("@title").Value = setNull(title)

        If I_Display_project_id = True Then cmd.Parameters.Add("@project_id", 22, 255, "project_id")
        If I_Display_project_id = True Then cmd.Parameters("@project_id").Value = setNull(project_id)

        If I_Display_course_id = True Then cmd.Parameters.Add("@course_id", 22, 255, "course_id")
        If I_Display_course_id = True Then cmd.Parameters("@course_id").Value = setNull(course_id)

        If I_Display_date_started = True Then cmd.Parameters.Add("@date_started", 4, 0, "date_started")
        If I_Display_date_started = True Then cmd.Parameters("@date_started").Value = setNull(date_started)

        If I_Display_end_date = True Then cmd.Parameters.Add("@end_date", 4, 0, "end_date")
        If I_Display_end_date = True Then cmd.Parameters("@end_date").Value = setNull(end_date)



        cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
        cmd.Parameters("@previous_id").Value = Me.previous_id



        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub


    Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Test)
        Dim ps As New Generic.List(Of Test)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "id,"
        If Display_title = True Then cmd.CommandText = cmd.CommandText & "title,"
        If Display_project_id = True Then cmd.CommandText = cmd.CommandText & "project_id,"
        If Display_course_id = True Then cmd.CommandText = cmd.CommandText & "course_id,"
        If Display_date_started = True Then cmd.CommandText = cmd.CommandText & "date_started,"
        If Display_end_date = True Then cmd.CommandText = cmd.CommandText & "end_date,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Test " & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Test
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_title = True Then p.title = checkNull(dt.Rows(i)("title"))
            p.I_Display_title = Display_title
            If Display_project_id=true then p.project_id=checknull(dt.Rows(i)("project_id"))
p.I_Display_project_id=Display_project_id
if Display_course_id=true then p.course_id=checknull(dt.Rows(i)("course_id"))
p.I_Display_course_id=Display_course_id
if Display_date_started=true then p.date_started=checknull(dt.Rows(i)("date_started"))
p.I_Display_date_started=Display_date_started
if Display_end_date=true then p.end_date=checknull(dt.Rows(i)("end_date"))
p.I_Display_end_date=Display_end_date
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Test)
Dim ps As New Generic.List(Of Test)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Test" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Test
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class