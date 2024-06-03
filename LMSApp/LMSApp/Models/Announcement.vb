Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Announcement
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_title  as Boolean=true
Public Shared Display_type as Boolean=true
Public Shared Display_text as Boolean=true
Public Shared Display_link  as Boolean=true
Public Shared Display_datetime as Boolean=true
Public Shared Display_status as Boolean=true
Public Shared Display_sentby as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_title  as Boolean=true
Private I_Display_type as Boolean=true
Private I_Display_text as Boolean=true
Private I_Display_link  as Boolean=true
Private I_Display_datetime as Boolean=true
Private I_Display_status as Boolean=true
Private I_Display_sentby as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public title  as System.String
Public type as nullable(of System.Int32)
Public text as System.String
Public link  as System.String
Public datetime as nullable(of System.DateTime)
Public status as nullable(of System.Int32)
Public sentby as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_title =display_flag
Display_type=display_flag
Display_text=display_flag
Display_link =display_flag
Display_datetime=display_flag
Display_status=display_flag
Display_sentby=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Announcement (id,title ,type,text,link ,datetime,status,sentby)"
cmd.CommandText = cmd.CommandText & "values(@id,@title ,@type,@text,@link ,@datetime,@status,@sentby)"

cmd.Parameters.Add("@id" , 8 , 0 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@title " , 22 , 255 , "title ")
cmd.Parameters("@title ").Value = SetNull(title )
cmd.Parameters.Add("@type" , 8 , 0 , "type")
cmd.Parameters("@type").Value = SetNull(type)
cmd.Parameters.Add("@text" , 18 , 2147483647 , "text")
cmd.Parameters("@text").Value = SetNull(text)
cmd.Parameters.Add("@link " , 22 , -1 , "link ")
cmd.Parameters("@link ").Value = SetNull(link )
cmd.Parameters.Add("@datetime" , 4 , 0 , "datetime")
cmd.Parameters("@datetime").Value = SetNull(datetime)
cmd.Parameters.Add("@status" , 8 , 0 , "status")
cmd.Parameters("@status").Value = SetNull(status)
cmd.Parameters.Add("@sentby" , 22 , 255 , "sentby")
cmd.Parameters("@sentby").Value = SetNull(sentby)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Announcement where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As Announcement
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_title =true then cmd.CommandText = cmd.CommandText & "title ,"
if Display_type=true then cmd.CommandText = cmd.CommandText & "type,"
if Display_text=true then cmd.CommandText = cmd.CommandText & "text,"
if Display_link =true then cmd.CommandText = cmd.CommandText & "link ,"
if Display_datetime=true then cmd.CommandText = cmd.CommandText & "datetime,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_sentby=true then cmd.CommandText = cmd.CommandText & "sentby,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Announcement where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Announcement
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_title =true then p.title =checknull(dt.Rows(i)("title "))
p.I_Display_title =Display_title 
if Display_type=true then p.type=checknull(dt.Rows(i)("type"))
p.I_Display_type=Display_type
if Display_text=true then p.text=checknull(dt.Rows(i)("text"))
p.I_Display_text=Display_text
if Display_link =true then p.link =checknull(dt.Rows(i)("link "))
p.I_Display_link =Display_link 
if Display_datetime=true then p.datetime=checknull(dt.Rows(i)("datetime"))
p.I_Display_datetime=Display_datetime
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
if Display_sentby=true then p.sentby=checknull(dt.Rows(i)("sentby"))
p.I_Display_sentby=Display_sentby
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
cmd.CommandText = "update Announcement set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_title =true then cmd.CommandText =cmd.CommandText & " title =@title ,"
if I_Display_type=true then cmd.CommandText =cmd.CommandText & " type=@type,"
if I_Display_text=true then cmd.CommandText =cmd.CommandText & " text=@text,"
if I_Display_link =true then cmd.CommandText =cmd.CommandText & " link =@link ,"
if I_Display_datetime=true then cmd.CommandText =cmd.CommandText & " datetime=@datetime,"
if I_Display_status=true then cmd.CommandText =cmd.CommandText & " status=@status,"
if I_Display_sentby=true then cmd.CommandText =cmd.CommandText & " sentby=@sentby,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_title =true then cmd.Parameters.Add("@title ", 22, 255, "title ")
if I_Display_title =true then cmd.Parameters("@title ").Value = SetNull(title )

if I_Display_type=true then cmd.Parameters.Add("@type", 8, 0, "type")
if I_Display_type=true then cmd.Parameters("@type").Value = SetNull(type)

if I_Display_text=true then cmd.Parameters.Add("@text", 18, 2147483647, "text")
if I_Display_text=true then cmd.Parameters("@text").Value = SetNull(text)

if I_Display_link =true then cmd.Parameters.Add("@link ", 22, -1, "link ")
if I_Display_link =true then cmd.Parameters("@link ").Value = SetNull(link )

if I_Display_datetime=true then cmd.Parameters.Add("@datetime", 4, 0, "datetime")
if I_Display_datetime=true then cmd.Parameters("@datetime").Value = SetNull(datetime)

if I_Display_status=true then cmd.Parameters.Add("@status", 8, 0, "status")
if I_Display_status=true then cmd.Parameters("@status").Value = SetNull(status)

if I_Display_sentby=true then cmd.Parameters.Add("@sentby", 22, 255, "sentby")
if I_Display_sentby=true then cmd.Parameters("@sentby").Value = SetNull(sentby)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Announcement)
Dim ps As New Generic.List(Of Announcement)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_title =true then cmd.CommandText = cmd.CommandText & "title ,"
if Display_type=true then cmd.CommandText = cmd.CommandText & "type,"
if Display_text=true then cmd.CommandText = cmd.CommandText & "text,"
if Display_link =true then cmd.CommandText = cmd.CommandText & "link ,"
if Display_datetime=true then cmd.CommandText = cmd.CommandText & "datetime,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_sentby=true then cmd.CommandText = cmd.CommandText & "sentby,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Announcement " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Announcement
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_title =true then p.title =checknull(dt.Rows(i)("title "))
p.I_Display_title =Display_title 
if Display_type=true then p.type=checknull(dt.Rows(i)("type"))
p.I_Display_type=Display_type
if Display_text=true then p.text=checknull(dt.Rows(i)("text"))
p.I_Display_text=Display_text
if Display_link =true then p.link =checknull(dt.Rows(i)("link "))
p.I_Display_link =Display_link 
if Display_datetime=true then p.datetime=checknull(dt.Rows(i)("datetime"))
p.I_Display_datetime=Display_datetime
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
if Display_sentby=true then p.sentby=checknull(dt.Rows(i)("sentby"))
p.I_Display_sentby=Display_sentby
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Announcement)
Dim ps As New Generic.List(Of Announcement)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Announcement" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Announcement
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class