Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class StudentAnswer
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_Answer as Boolean=true
Public Shared Display_Image as Boolean=true
Public Shared Display_student_id as Boolean=true
Public Shared Display_question_id as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_Answer as Boolean=true
Private I_Display_Image as Boolean=true
Private I_Display_student_id as Boolean=true
Private I_Display_question_id as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public Answer as System.String
Public Image as System.Byte()
Public student_id as System.String
Public question_id as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_Answer=display_flag
Display_Image=display_flag
Display_student_id=display_flag
Display_question_id=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into StudentAnswer (id,Answer,Image,student_id,question_id)"
cmd.CommandText = cmd.CommandText & "values(@id,@Answer,@Image,@student_id,@question_id)"

cmd.Parameters.Add("@id" , 8 , 0 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@Answer" , 22 , -1 , "Answer")
cmd.Parameters("@Answer").Value = SetNull(Answer)
cmd.Parameters.Add("@Image" , 21 , -1 , "Image")
cmd.Parameters("@Image").Value = SetNull(Image)
cmd.Parameters.Add("@student_id" , 22 , 255 , "student_id")
cmd.Parameters("@student_id").Value = SetNull(student_id)
cmd.Parameters.Add("@question_id" , 22 , 255 , "question_id")
cmd.Parameters("@question_id").Value = SetNull(question_id)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from StudentAnswer where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As StudentAnswer
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_Answer=true then cmd.CommandText = cmd.CommandText & "Answer,"
if Display_Image=true then cmd.CommandText = cmd.CommandText & "Image,"
if Display_student_id=true then cmd.CommandText = cmd.CommandText & "student_id,"
if Display_question_id=true then cmd.CommandText = cmd.CommandText & "question_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from StudentAnswer where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New StudentAnswer
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_Answer=true then p.Answer=checknull(dt.Rows(i)("Answer"))
p.I_Display_Answer=Display_Answer
if Display_Image=true then p.Image=checknull(dt.Rows(i)("Image"))
p.I_Display_Image=Display_Image
if Display_student_id=true then p.student_id=checknull(dt.Rows(i)("student_id"))
p.I_Display_student_id=Display_student_id
if Display_question_id=true then p.question_id=checknull(dt.Rows(i)("question_id"))
p.I_Display_question_id=Display_question_id
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
cmd.CommandText = "update StudentAnswer set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_Answer=true then cmd.CommandText =cmd.CommandText & " Answer=@Answer,"
if I_Display_Image=true then cmd.CommandText =cmd.CommandText & " Image=@Image,"
if I_Display_student_id=true then cmd.CommandText =cmd.CommandText & " student_id=@student_id,"
if I_Display_question_id=true then cmd.CommandText =cmd.CommandText & " question_id=@question_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_Answer=true then cmd.Parameters.Add("@Answer", 22, -1, "Answer")
if I_Display_Answer=true then cmd.Parameters("@Answer").Value = SetNull(Answer)

if I_Display_Image=true then cmd.Parameters.Add("@Image", 21, -1, "Image")
if I_Display_Image=true then cmd.Parameters("@Image").Value = SetNull(Image)

if I_Display_student_id=true then cmd.Parameters.Add("@student_id", 22, 255, "student_id")
if I_Display_student_id=true then cmd.Parameters("@student_id").Value = SetNull(student_id)

if I_Display_question_id=true then cmd.Parameters.Add("@question_id", 22, 255, "question_id")
if I_Display_question_id=true then cmd.Parameters("@question_id").Value = SetNull(question_id)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of StudentAnswer)
Dim ps As New Generic.List(Of StudentAnswer)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_Answer=true then cmd.CommandText = cmd.CommandText & "Answer,"
if Display_Image=true then cmd.CommandText = cmd.CommandText & "Image,"
if Display_student_id=true then cmd.CommandText = cmd.CommandText & "student_id,"
if Display_question_id=true then cmd.CommandText = cmd.CommandText & "question_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from StudentAnswer " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New StudentAnswer
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_Answer=true then p.Answer=checknull(dt.Rows(i)("Answer"))
p.I_Display_Answer=Display_Answer
if Display_Image=true then p.Image=checknull(dt.Rows(i)("Image"))
p.I_Display_Image=Display_Image
if Display_student_id=true then p.student_id=checknull(dt.Rows(i)("student_id"))
p.I_Display_student_id=Display_student_id
if Display_question_id=true then p.question_id=checknull(dt.Rows(i)("question_id"))
p.I_Display_question_id=Display_question_id
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of StudentAnswer)
Dim ps As New Generic.List(Of StudentAnswer)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from StudentAnswer" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New StudentAnswer
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class