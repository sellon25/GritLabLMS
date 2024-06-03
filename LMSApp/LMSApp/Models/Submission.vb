Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Submission
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_title as Boolean=true
Public Shared Display_text as Boolean=true
Public Shared Display_file_data as Boolean=true
Public Shared Display_datetime as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_title as Boolean=true
Private I_Display_text as Boolean=true
Private I_Display_file_data as Boolean=true
Private I_Display_datetime as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public title as System.String
Public text as System.String
Public file_data as System.Byte()
Public datetime as nullable(of System.DateTime)
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_title=display_flag
Display_text=display_flag
Display_file_data=display_flag
Display_datetime=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Submission (id,title,text,file_data,datetime)"
cmd.CommandText = cmd.CommandText & "values(@id,@title,@text,@file_data,@datetime)"

cmd.Parameters.Add("@id" , 8 , 0 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@title" , 22 , 255 , "title")
cmd.Parameters("@title").Value = SetNull(title)
cmd.Parameters.Add("@text" , 18 , 2147483647 , "text")
cmd.Parameters("@text").Value = SetNull(text)
cmd.Parameters.Add("@file_data" , 21 , -1 , "file_data")
cmd.Parameters("@file_data").Value = SetNull(file_data)
cmd.Parameters.Add("@datetime" , 4 , 0 , "datetime")
cmd.Parameters("@datetime").Value = SetNull(datetime)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Submission where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As Submission
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_title=true then cmd.CommandText = cmd.CommandText & "title,"
if Display_text=true then cmd.CommandText = cmd.CommandText & "text,"
if Display_file_data=true then cmd.CommandText = cmd.CommandText & "file_data,"
if Display_datetime=true then cmd.CommandText = cmd.CommandText & "datetime,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Submission where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Submission
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_title=true then p.title=checknull(dt.Rows(i)("title"))
p.I_Display_title=Display_title
if Display_text=true then p.text=checknull(dt.Rows(i)("text"))
p.I_Display_text=Display_text
if Display_file_data=true then p.file_data=checknull(dt.Rows(i)("file_data"))
p.I_Display_file_data=Display_file_data
if Display_datetime=true then p.datetime=checknull(dt.Rows(i)("datetime"))
p.I_Display_datetime=Display_datetime
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
cmd.CommandText = "update Submission set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_title=true then cmd.CommandText =cmd.CommandText & " title=@title,"
if I_Display_text=true then cmd.CommandText =cmd.CommandText & " text=@text,"
if I_Display_file_data=true then cmd.CommandText =cmd.CommandText & " file_data=@file_data,"
if I_Display_datetime=true then cmd.CommandText =cmd.CommandText & " datetime=@datetime,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_title=true then cmd.Parameters.Add("@title", 22, 255, "title")
if I_Display_title=true then cmd.Parameters("@title").Value = SetNull(title)

if I_Display_text=true then cmd.Parameters.Add("@text", 18, 2147483647, "text")
if I_Display_text=true then cmd.Parameters("@text").Value = SetNull(text)

if I_Display_file_data=true then cmd.Parameters.Add("@file_data", 21, -1, "file_data")
if I_Display_file_data=true then cmd.Parameters("@file_data").Value = SetNull(file_data)

if I_Display_datetime=true then cmd.Parameters.Add("@datetime", 4, 0, "datetime")
if I_Display_datetime=true then cmd.Parameters("@datetime").Value = SetNull(datetime)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Submission)
Dim ps As New Generic.List(Of Submission)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_title=true then cmd.CommandText = cmd.CommandText & "title,"
if Display_text=true then cmd.CommandText = cmd.CommandText & "text,"
if Display_file_data=true then cmd.CommandText = cmd.CommandText & "file_data,"
if Display_datetime=true then cmd.CommandText = cmd.CommandText & "datetime,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Submission " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Submission
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_title=true then p.title=checknull(dt.Rows(i)("title"))
p.I_Display_title=Display_title
if Display_text=true then p.text=checknull(dt.Rows(i)("text"))
p.I_Display_text=Display_text
if Display_file_data=true then p.file_data=checknull(dt.Rows(i)("file_data"))
p.I_Display_file_data=Display_file_data
if Display_datetime=true then p.datetime=checknull(dt.Rows(i)("datetime"))
p.I_Display_datetime=Display_datetime
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Submission)
Dim ps As New Generic.List(Of Submission)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Submission" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Submission
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class