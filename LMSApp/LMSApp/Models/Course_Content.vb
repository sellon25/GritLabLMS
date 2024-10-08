﻿Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Course_Content
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_content_id as Boolean=true
Public Shared Display_course_id as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_content_id as Boolean=true
Private I_Display_course_id as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public content_id as nullable(of System.Int32)
Public course_id as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_content_id=display_flag
Display_course_id=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Course_Content (id,content_id,course_id)"
cmd.CommandText = cmd.CommandText & "values(@id,@content_id,@course_id)"

cmd.Parameters.Add("@id" , 8 , 0 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@content_id" , 8 , 0 , "content_id")
cmd.Parameters("@content_id").Value = SetNull(content_id)
cmd.Parameters.Add("@course_id" , 22 , 255 , "course_id")
cmd.Parameters("@course_id").Value = SetNull(course_id)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Course_Content where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As Course_Content
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_content_id=true then cmd.CommandText = cmd.CommandText & "content_id,"
if Display_course_id=true then cmd.CommandText = cmd.CommandText & "course_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Course_Content where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Course_Content
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_content_id=true then p.content_id=checknull(dt.Rows(i)("content_id"))
p.I_Display_content_id=Display_content_id
if Display_course_id=true then p.course_id=checknull(dt.Rows(i)("course_id"))
p.I_Display_course_id=Display_course_id
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
cmd.CommandText = "update Course_Content set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_content_id=true then cmd.CommandText =cmd.CommandText & " content_id=@content_id,"
if I_Display_course_id=true then cmd.CommandText =cmd.CommandText & " course_id=@course_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_content_id=true then cmd.Parameters.Add("@content_id", 8, 0, "content_id")
if I_Display_content_id=true then cmd.Parameters("@content_id").Value = SetNull(content_id)

if I_Display_course_id=true then cmd.Parameters.Add("@course_id", 22, 255, "course_id")
if I_Display_course_id=true then cmd.Parameters("@course_id").Value = SetNull(course_id)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course_Content)
Dim ps As New Generic.List(Of Course_Content)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_content_id=true then cmd.CommandText = cmd.CommandText & "content_id,"
if Display_course_id=true then cmd.CommandText = cmd.CommandText & "course_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Course_Content " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Course_Content
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_content_id=true then p.content_id=checknull(dt.Rows(i)("content_id"))
p.I_Display_content_id=Display_content_id
if Display_course_id=true then p.course_id=checknull(dt.Rows(i)("course_id"))
p.I_Display_course_id=Display_course_id
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course_Content)
Dim ps As New Generic.List(Of Course_Content)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Course_Content" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Course_Content
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class