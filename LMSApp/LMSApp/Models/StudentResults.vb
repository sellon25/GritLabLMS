Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class StudentResults
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_markedby as Boolean=true
Public Shared Display_comment as Boolean=true
Public Shared Display_score as Boolean=true
Public Shared Display_mark_date as Boolean=true
Public Shared Display_test_id as Boolean=true
Public Shared Display_student_id as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_markedby as Boolean=true
Private I_Display_comment as Boolean=true
Private I_Display_score as Boolean=true
Private I_Display_mark_date as Boolean=true
Private I_Display_test_id as Boolean=true
Private I_Display_student_id as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public markedby as System.String
Public comment as System.String
Public score as nullable(of System.Double)
Public mark_date as nullable(of System.DateTime)
Public test_id as System.String
Public student_id as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_markedby=display_flag
Display_comment=display_flag
Display_score=display_flag
Display_mark_date=display_flag
Display_test_id=display_flag
Display_student_id=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into StudentResults (id,markedby,comment,score,mark_date,test_id,student_id)"
cmd.CommandText = cmd.CommandText & "values(@id,@markedby,@comment,@score,@mark_date,@test_id,@student_id)"

cmd.Parameters.Add("@id" , 8 , 0 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@markedby" , 22 , 255 , "markedby")
cmd.Parameters("@markedby").Value = SetNull(markedby)
cmd.Parameters.Add("@comment" , 22 , -1 , "comment")
cmd.Parameters("@comment").Value = SetNull(comment)
cmd.Parameters.Add("@score" , 6 , 0 , "score")
cmd.Parameters("@score").Value = SetNull(score)
cmd.Parameters.Add("@mark_date" , 4 , 0 , "mark_date")
cmd.Parameters("@mark_date").Value = SetNull(mark_date)
cmd.Parameters.Add("@test_id" , 22 , 255 , "test_id")
cmd.Parameters("@test_id").Value = SetNull(test_id)
cmd.Parameters.Add("@student_id" , 22 , 255 , "student_id")
cmd.Parameters("@student_id").Value = SetNull(student_id)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from StudentResults where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As StudentResults
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_markedby=true then cmd.CommandText = cmd.CommandText & "markedby,"
if Display_comment=true then cmd.CommandText = cmd.CommandText & "comment,"
if Display_score=true then cmd.CommandText = cmd.CommandText & "score,"
if Display_mark_date=true then cmd.CommandText = cmd.CommandText & "mark_date,"
if Display_test_id=true then cmd.CommandText = cmd.CommandText & "test_id,"
if Display_student_id=true then cmd.CommandText = cmd.CommandText & "student_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from StudentResults where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New StudentResults
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_markedby=true then p.markedby=checknull(dt.Rows(i)("markedby"))
p.I_Display_markedby=Display_markedby
if Display_comment=true then p.comment=checknull(dt.Rows(i)("comment"))
p.I_Display_comment=Display_comment
if Display_score=true then p.score=checknull(dt.Rows(i)("score"))
p.I_Display_score=Display_score
if Display_mark_date=true then p.mark_date=checknull(dt.Rows(i)("mark_date"))
p.I_Display_mark_date=Display_mark_date
if Display_test_id=true then p.test_id=checknull(dt.Rows(i)("test_id"))
p.I_Display_test_id=Display_test_id
if Display_student_id=true then p.student_id=checknull(dt.Rows(i)("student_id"))
p.I_Display_student_id=Display_student_id
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
cmd.CommandText = "update StudentResults set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_markedby=true then cmd.CommandText =cmd.CommandText & " markedby=@markedby,"
if I_Display_comment=true then cmd.CommandText =cmd.CommandText & " comment=@comment,"
if I_Display_score=true then cmd.CommandText =cmd.CommandText & " score=@score,"
if I_Display_mark_date=true then cmd.CommandText =cmd.CommandText & " mark_date=@mark_date,"
if I_Display_test_id=true then cmd.CommandText =cmd.CommandText & " test_id=@test_id,"
if I_Display_student_id=true then cmd.CommandText =cmd.CommandText & " student_id=@student_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_markedby=true then cmd.Parameters.Add("@markedby", 22, 255, "markedby")
if I_Display_markedby=true then cmd.Parameters("@markedby").Value = SetNull(markedby)

if I_Display_comment=true then cmd.Parameters.Add("@comment", 22, -1, "comment")
if I_Display_comment=true then cmd.Parameters("@comment").Value = SetNull(comment)

if I_Display_score=true then cmd.Parameters.Add("@score", 6, 0, "score")
if I_Display_score=true then cmd.Parameters("@score").Value = SetNull(score)

if I_Display_mark_date=true then cmd.Parameters.Add("@mark_date", 4, 0, "mark_date")
if I_Display_mark_date=true then cmd.Parameters("@mark_date").Value = SetNull(mark_date)

if I_Display_test_id=true then cmd.Parameters.Add("@test_id", 22, 255, "test_id")
if I_Display_test_id=true then cmd.Parameters("@test_id").Value = SetNull(test_id)

if I_Display_student_id=true then cmd.Parameters.Add("@student_id", 22, 255, "student_id")
if I_Display_student_id=true then cmd.Parameters("@student_id").Value = SetNull(student_id)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of StudentResults)
Dim ps As New Generic.List(Of StudentResults)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_markedby=true then cmd.CommandText = cmd.CommandText & "markedby,"
if Display_comment=true then cmd.CommandText = cmd.CommandText & "comment,"
if Display_score=true then cmd.CommandText = cmd.CommandText & "score,"
if Display_mark_date=true then cmd.CommandText = cmd.CommandText & "mark_date,"
if Display_test_id=true then cmd.CommandText = cmd.CommandText & "test_id,"
if Display_student_id=true then cmd.CommandText = cmd.CommandText & "student_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from StudentResults " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New StudentResults
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_markedby=true then p.markedby=checknull(dt.Rows(i)("markedby"))
p.I_Display_markedby=Display_markedby
if Display_comment=true then p.comment=checknull(dt.Rows(i)("comment"))
p.I_Display_comment=Display_comment
if Display_score=true then p.score=checknull(dt.Rows(i)("score"))
p.I_Display_score=Display_score
if Display_mark_date=true then p.mark_date=checknull(dt.Rows(i)("mark_date"))
p.I_Display_mark_date=Display_mark_date
if Display_test_id=true then p.test_id=checknull(dt.Rows(i)("test_id"))
p.I_Display_test_id=Display_test_id
if Display_student_id=true then p.student_id=checknull(dt.Rows(i)("student_id"))
p.I_Display_student_id=Display_student_id
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of StudentResults)
Dim ps As New Generic.List(Of StudentResults)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from StudentResults" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New StudentResults
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class