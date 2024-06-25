Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Test
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_thumbnail as Boolean=true
Public Shared Display_project_id as Boolean=true
Public Shared Display_course_id as Boolean=true
Public Shared Display_date_started as Boolean=true
Public Shared Display_end_date as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_thumbnail as Boolean=true
Private I_Display_project_id as Boolean=true
Private I_Display_course_id as Boolean=true
Private I_Display_date_started as Boolean=true
Private I_Display_end_date as Boolean=True

    Public previous_id As System.String

    Public id As System.String
    Public thumbnail as System.String
Public project_id as System.String
Public course_id as System.String
Public date_started as nullable(of System.DateTime)
Public end_date as nullable(of System.DateTime)
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_thumbnail=display_flag
Display_project_id=display_flag
Display_course_id=display_flag
Display_date_started=display_flag
Display_end_date=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Test (id,thumbnail,project_id,course_id,date_started,end_date)"
cmd.CommandText = cmd.CommandText & "values(@id,@thumbnail,@project_id,@course_id,@date_started,@end_date)"

        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@thumbnail" , 22 , 255 , "thumbnail")
cmd.Parameters("@thumbnail").Value = SetNull(thumbnail)
cmd.Parameters.Add("@project_id" , 22 , 255 , "project_id")
cmd.Parameters("@project_id").Value = SetNull(project_id)
cmd.Parameters.Add("@course_id" , 22 , 255 , "course_id")
cmd.Parameters("@course_id").Value = SetNull(course_id)
cmd.Parameters.Add("@date_started" , 4 , 0 , "date_started")
cmd.Parameters("@date_started").Value = SetNull(date_started)
cmd.Parameters.Add("@end_date" , 4 , 0 , "end_date")
cmd.Parameters("@end_date").Value = SetNull(end_date)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Test where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As Test
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_thumbnail=true then cmd.CommandText = cmd.CommandText & "thumbnail,"
if Display_project_id=true then cmd.CommandText = cmd.CommandText & "project_id,"
if Display_course_id=true then cmd.CommandText = cmd.CommandText & "course_id,"
if Display_date_started=true then cmd.CommandText = cmd.CommandText & "date_started,"
if Display_end_date=true then cmd.CommandText = cmd.CommandText & "end_date,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Test where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Test
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_thumbnail=true then p.thumbnail=checknull(dt.Rows(i)("thumbnail"))
p.I_Display_thumbnail=Display_thumbnail
if Display_project_id=true then p.project_id=checknull(dt.Rows(i)("project_id"))
p.I_Display_project_id=Display_project_id
if Display_course_id=true then p.course_id=checknull(dt.Rows(i)("course_id"))
p.I_Display_course_id=Display_course_id
if Display_date_started=true then p.date_started=checknull(dt.Rows(i)("date_started"))
p.I_Display_date_started=Display_date_started
if Display_end_date=true then p.end_date=checknull(dt.Rows(i)("end_date"))
p.I_Display_end_date=Display_end_date
p.previous_id=checknull(dt.Rows(i)("id"))
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

Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "update Test set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_thumbnail=true then cmd.CommandText =cmd.CommandText & " thumbnail=@thumbnail,"
if I_Display_project_id=true then cmd.CommandText =cmd.CommandText & " project_id=@project_id,"
if I_Display_course_id=true then cmd.CommandText =cmd.CommandText & " course_id=@course_id,"
if I_Display_date_started=true then cmd.CommandText =cmd.CommandText & " date_started=@date_started,"
if I_Display_end_date=true then cmd.CommandText =cmd.CommandText & " end_date=@end_date,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = SetNull(id)

if I_Display_thumbnail=true then cmd.Parameters.Add("@thumbnail", 22, 255, "thumbnail")
if I_Display_thumbnail=true then cmd.Parameters("@thumbnail").Value = SetNull(thumbnail)

if I_Display_project_id=true then cmd.Parameters.Add("@project_id", 22, 255, "project_id")
if I_Display_project_id=true then cmd.Parameters("@project_id").Value = SetNull(project_id)

if I_Display_course_id=true then cmd.Parameters.Add("@course_id", 22, 255, "course_id")
if I_Display_course_id=true then cmd.Parameters("@course_id").Value = SetNull(course_id)

if I_Display_date_started=true then cmd.Parameters.Add("@date_started", 4, 0, "date_started")
if I_Display_date_started=true then cmd.Parameters("@date_started").Value = SetNull(date_started)

if I_Display_end_date=true then cmd.Parameters.Add("@end_date", 4, 0, "end_date")
if I_Display_end_date=true then cmd.Parameters("@end_date").Value = SetNull(end_date)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Test)
Dim ps As New Generic.List(Of Test)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_thumbnail=true then cmd.CommandText = cmd.CommandText & "thumbnail,"
if Display_project_id=true then cmd.CommandText = cmd.CommandText & "project_id,"
if Display_course_id=true then cmd.CommandText = cmd.CommandText & "course_id,"
if Display_date_started=true then cmd.CommandText = cmd.CommandText & "date_started,"
if Display_end_date=true then cmd.CommandText = cmd.CommandText & "end_date,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Test " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Test
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_thumbnail=true then p.thumbnail=checknull(dt.Rows(i)("thumbnail"))
p.I_Display_thumbnail=Display_thumbnail
if Display_project_id=true then p.project_id=checknull(dt.Rows(i)("project_id"))
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