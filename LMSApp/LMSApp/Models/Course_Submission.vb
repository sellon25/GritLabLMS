Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Course_Submission
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_submission_id as Boolean=true
Public Shared Display_course_id as Boolean=true
Public Shared Display_user_id as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_submission_id as Boolean=true
Private I_Display_course_id as Boolean=true
Private I_Display_user_id as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public submission_id as nullable(of System.Int32)
Public course_id as System.String
Public user_id as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_submission_id=display_flag
Display_course_id=display_flag
Display_user_id=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Course_Submission (id,submission_id,course_id,user_id)"
cmd.CommandText = cmd.CommandText & "values(@id,@submission_id,@course_id,@user_id)"

cmd.Parameters.Add("@id" , 8 , 0 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@submission_id" , 8 , 0 , "submission_id")
cmd.Parameters("@submission_id").Value = SetNull(submission_id)
cmd.Parameters.Add("@course_id" , 22 , 255 , "course_id")
cmd.Parameters("@course_id").Value = SetNull(course_id)
cmd.Parameters.Add("@user_id" , 22 , 255 , "user_id")
cmd.Parameters("@user_id").Value = SetNull(user_id)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Course_Submission where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As Course_Submission
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_submission_id=true then cmd.CommandText = cmd.CommandText & "submission_id,"
if Display_course_id=true then cmd.CommandText = cmd.CommandText & "course_id,"
if Display_user_id=true then cmd.CommandText = cmd.CommandText & "user_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Course_Submission where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Course_Submission
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_submission_id=true then p.submission_id=checknull(dt.Rows(i)("submission_id"))
p.I_Display_submission_id=Display_submission_id
if Display_course_id=true then p.course_id=checknull(dt.Rows(i)("course_id"))
p.I_Display_course_id=Display_course_id
if Display_user_id=true then p.user_id=checknull(dt.Rows(i)("user_id"))
p.I_Display_user_id=Display_user_id
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
cmd.CommandText = "update Course_Submission set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_submission_id=true then cmd.CommandText =cmd.CommandText & " submission_id=@submission_id,"
if I_Display_course_id=true then cmd.CommandText =cmd.CommandText & " course_id=@course_id,"
if I_Display_user_id=true then cmd.CommandText =cmd.CommandText & " user_id=@user_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_submission_id=true then cmd.Parameters.Add("@submission_id", 8, 0, "submission_id")
if I_Display_submission_id=true then cmd.Parameters("@submission_id").Value = SetNull(submission_id)

if I_Display_course_id=true then cmd.Parameters.Add("@course_id", 22, 255, "course_id")
if I_Display_course_id=true then cmd.Parameters("@course_id").Value = SetNull(course_id)

if I_Display_user_id=true then cmd.Parameters.Add("@user_id", 22, 255, "user_id")
if I_Display_user_id=true then cmd.Parameters("@user_id").Value = SetNull(user_id)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course_Submission)
Dim ps As New Generic.List(Of Course_Submission)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_submission_id=true then cmd.CommandText = cmd.CommandText & "submission_id,"
if Display_course_id=true then cmd.CommandText = cmd.CommandText & "course_id,"
if Display_user_id=true then cmd.CommandText = cmd.CommandText & "user_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Course_Submission " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Course_Submission
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_submission_id=true then p.submission_id=checknull(dt.Rows(i)("submission_id"))
p.I_Display_submission_id=Display_submission_id
if Display_course_id=true then p.course_id=checknull(dt.Rows(i)("course_id"))
p.I_Display_course_id=Display_course_id
if Display_user_id=true then p.user_id=checknull(dt.Rows(i)("user_id"))
p.I_Display_user_id=Display_user_id
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course_Submission)
Dim ps As New Generic.List(Of Course_Submission)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Course_Submission" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Course_Submission
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class