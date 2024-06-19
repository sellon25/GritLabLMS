Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Course
inherits Entity

Public Shared Display_id as Boolean=True
    Public Shared Display_name As Boolean = True
    Public Shared Display_thumbnail As Boolean = True
    Public Shared Display_description As Boolean = True
    Public Shared Display_overview As Boolean = True
    Public Shared Display_status As Boolean = True
    Public Shared Display_date_started As Boolean = True
    Public Shared Display_end_date As Boolean = True

    Private I_Display_id As Boolean = True
    Private I_Display_name As Boolean = True
    Private I_Display_thumbnail As Boolean = True
    Private I_Display_description As Boolean = True
    Private I_Display_overview As Boolean = True
    Private I_Display_status As Boolean = True
    Private I_Display_date_started As Boolean = True
    Private I_Display_end_date As Boolean = True

    Public previous_id As System.String

    Public id As System.String
    Public name As System.String
    Public thumbnail As System.Byte()
    Public description As System.String
    Public overview As System.String
    Public status As Nullable(Of System.Int32)
    Public date_started As Nullable(Of System.DateTime)
    Public end_date As Nullable(Of System.DateTime)
    Private newinstance As Boolean = True

    Shared Sub Set_Display_Field_All(display_flag As Boolean)
        Display_id = display_flag
        Display_name = display_flag
        Display_thumbnail = display_flag
        Display_description = display_flag
        Display_overview = display_flag
        Display_status = display_flag
        Display_date_started = display_flag
        Display_end_date = display_flag
    End Sub


    Private Sub insert()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Course (id,name,thumbnail,description,overview,status,date_started,end_date)"
        cmd.CommandText = cmd.CommandText & "values(@id,@name,@thumbnail,@description,@overview,@status,@date_started,@end_date)"

        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = setNull(id)
        cmd.Parameters.Add("@name", 22, 255, "name")
        cmd.Parameters("@name").Value = setNull(name)
        cmd.Parameters.Add("@thumbnail", 21, -1, "thumbnail")
        cmd.Parameters("@thumbnail").Value = setNull(thumbnail)
        cmd.Parameters.Add("@description", 22, 150, "description")
        cmd.Parameters("@description").Value = setNull(description)
        cmd.Parameters.Add("@overview", 18, 2147483647, "overview")
        cmd.Parameters("@overview").Value = setNull(overview)
        cmd.Parameters.Add("@status", 8, 0, "status")
        cmd.Parameters("@status").Value = setNull(status)
        cmd.Parameters.Add("@date_started", 31, 0, "date_started")
        cmd.Parameters("@date_started").Value = setNull(date_started)
        cmd.Parameters.Add("@end_date", 31, 0, "end_date")
        cmd.Parameters("@end_date").Value = setNull(end_date)


        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub


    Sub delete()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from Course where id=@previous_id"
        cmd.Parameters.Add("@previous_id", 22, 255, "previous_id")
        cmd.Parameters("@previous_id").Value = Me.previous_id

        cmd.ExecuteNonQuery()
    End Sub


    Shared Function load(id As System.String) As Course
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "id,"
        If Display_name = True Then cmd.CommandText = cmd.CommandText & "name,"
        If Display_thumbnail = True Then cmd.CommandText = cmd.CommandText & "thumbnail,"
        If Display_description = True Then cmd.CommandText = cmd.CommandText & "description,"
        If Display_overview = True Then cmd.CommandText = cmd.CommandText & "overview,"
        If Display_status = True Then cmd.CommandText = cmd.CommandText & "status,"
        If Display_date_started = True Then cmd.CommandText = cmd.CommandText & "date_started,"
        If Display_end_date = True Then cmd.CommandText = cmd.CommandText & "end_date,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Course where id=@id"
        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = id

        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        Dim p As New Course
        For i = 0 To dt.Rows.Count - 1
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_name = True Then p.name = checkNull(dt.Rows(i)("name"))
            p.I_Display_name = Display_name
            If Display_thumbnail = True Then p.thumbnail = checkNull(dt.Rows(i)("thumbnail"))
            p.I_Display_thumbnail = Display_thumbnail
            If Display_description = True Then p.description = checkNull(dt.Rows(i)("description"))
            p.I_Display_description = Display_description
            If Display_overview = True Then p.overview = checkNull(dt.Rows(i)("overview"))
            p.I_Display_overview = Display_overview
            If Display_status = True Then p.status = checkNull(dt.Rows(i)("status"))
            p.I_Display_status = Display_status
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
        cmd.CommandText = "update Course set "
        cmd.CommandText = cmd.CommandText & " id=@id,"
        If I_Display_name = True Then cmd.CommandText = cmd.CommandText & "name=@name,"
        If I_Display_thumbnail = True Then cmd.CommandText = cmd.CommandText & " thumbnail=@thumbnail,"
        If I_Display_description = True Then cmd.CommandText = cmd.CommandText & " description=@description,"
        If I_Display_overview = True Then cmd.CommandText = cmd.CommandText & " overview=@overview,"
        If I_Display_status = True Then cmd.CommandText = cmd.CommandText & " status=@status,"
        If I_Display_date_started = True Then cmd.CommandText = cmd.CommandText & " date_started=@date_started,"
        If I_Display_end_date = True Then cmd.CommandText = cmd.CommandText & " end_date=@end_date,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " where id=@previous_id"


        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = setNull(id)

        If I_Display_name = True Then cmd.Parameters.Add("@name", 22, 255, "name")
        If I_Display_name = True Then cmd.Parameters("@name").Value = setNull(name)

        If I_Display_thumbnail = True Then cmd.Parameters.Add("@thumbnail", 21, -1, "thumbnail")
        If I_Display_thumbnail = True Then cmd.Parameters("@thumbnail").Value = setNull(thumbnail)

        If I_Display_description = True Then cmd.Parameters.Add("@description", 22, 150, "description")
        If I_Display_description = True Then cmd.Parameters("@description").Value = setNull(description)

        If I_Display_overview = True Then cmd.Parameters.Add("@overview", 18, 2147483647, "overview")
        If I_Display_overview = True Then cmd.Parameters("@overview").Value = setNull(overview)

        If I_Display_status = True Then cmd.Parameters.Add("@status", 8, 0, "status")
        If I_Display_status = True Then cmd.Parameters("@status").Value = setNull(status)

        If I_Display_date_started = True Then cmd.Parameters.Add("@date_started", 31, 0, "date_started")
        If I_Display_date_started = True Then cmd.Parameters("@date_started").Value = setNull(date_started)

        If I_Display_end_date = True Then cmd.Parameters.Add("@end_date", 31, 0, "end_date")
        If I_Display_end_date = True Then cmd.Parameters("@end_date").Value = setNull(end_date)



        cmd.Parameters.Add("@previous_id", 22, 255, "previous_id")
        cmd.Parameters("@previous_id").Value = Me.previous_id



        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub


    Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course)
        Dim ps As New Generic.List(Of Course)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "id,"
        If Display_name = True Then cmd.CommandText = cmd.CommandText & "name,"
        If Display_thumbnail = True Then cmd.CommandText = cmd.CommandText & "thumbnail,"
        If Display_description = True Then cmd.CommandText = cmd.CommandText & "description,"
        If Display_overview = True Then cmd.CommandText = cmd.CommandText & "overview,"
        If Display_status = True Then cmd.CommandText = cmd.CommandText & "status,"
        If Display_date_started = True Then cmd.CommandText = cmd.CommandText & "date_started,"
        If Display_end_date = True Then cmd.CommandText = cmd.CommandText & "end_date,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Course " & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Course
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_name = True Then p.name = checkNull(dt.Rows(i)("name"))
            p.I_Display_name = Display_name
            If Display_thumbnail = True Then p.thumbnail = checkNull(dt.Rows(i)("thumbnail"))
            p.I_Display_thumbnail = Display_thumbnail
            If Display_description = True Then p.description = checkNull(dt.Rows(i)("description"))
            p.I_Display_description = Display_description
            If Display_overview = True Then p.overview = checkNull(dt.Rows(i)("overview"))
            p.I_Display_overview = Display_overview
            If Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
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


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course)
Dim ps As New Generic.List(Of Course)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Course" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Course
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class