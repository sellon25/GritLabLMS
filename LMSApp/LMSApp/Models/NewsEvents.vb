Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class NewsEvents
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_title  as Boolean=true
Public Shared Display_thumbnail as Boolean=true
Public Shared Display_description  as Boolean=true
Public Shared Display_link  as Boolean=true
Public Shared Display_file_data as Boolean=true
Public Shared Display_datetime as Boolean=true
Public Shared Display_status as Boolean=true
Public Shared Display_sentby as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_title  as Boolean=true
Private I_Display_thumbnail as Boolean=true
Private I_Display_description  as Boolean=true
Private I_Display_link  as Boolean=true
Private I_Display_file_data as Boolean=true
Private I_Display_datetime as Boolean=true
Private I_Display_status as Boolean=true
Private I_Display_sentby as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public title  as System.String
Public thumbnail as System.Byte()
Public description  as System.String
Public link  as System.String
Public file_data as System.Byte()
Public datetime as nullable(of System.DateTime)
Public status as System.String
Public sentby as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_title =display_flag
Display_thumbnail=display_flag
Display_description =display_flag
Display_link =display_flag
Display_file_data=display_flag
Display_datetime=display_flag
Display_status=display_flag
Display_sentby=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into NewsEvents (id,title ,thumbnail,description ,link ,file_data,datetime,status,sentby)"
cmd.CommandText = cmd.CommandText & "values(@id,@title ,@thumbnail,@description ,@link ,@file_data,@datetime,@status,@sentby)"

cmd.Parameters.Add("@id" , 8 , 0 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@title " , 22 , 255 , "title ")
cmd.Parameters("@title ").Value = SetNull(title )
cmd.Parameters.Add("@thumbnail" , 21 , -1 , "thumbnail")
cmd.Parameters("@thumbnail").Value = SetNull(thumbnail)
cmd.Parameters.Add("@description " , 18 , 2147483647 , "description ")
cmd.Parameters("@description ").Value = SetNull(description )
cmd.Parameters.Add("@link " , 22 , -1 , "link ")
cmd.Parameters("@link ").Value = SetNull(link )
cmd.Parameters.Add("@file_data" , 21 , -1 , "file_data")
cmd.Parameters("@file_data").Value = SetNull(file_data)
cmd.Parameters.Add("@datetime" , 4 , 0 , "datetime")
cmd.Parameters("@datetime").Value = SetNull(datetime)
cmd.Parameters.Add("@status" , 22 , 150 , "status")
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
cmd.CommandText = "delete from NewsEvents where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As NewsEvents
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_title =true then cmd.CommandText = cmd.CommandText & "title ,"
if Display_thumbnail=true then cmd.CommandText = cmd.CommandText & "thumbnail,"
if Display_description =true then cmd.CommandText = cmd.CommandText & "description ,"
if Display_link =true then cmd.CommandText = cmd.CommandText & "link ,"
if Display_file_data=true then cmd.CommandText = cmd.CommandText & "file_data,"
if Display_datetime=true then cmd.CommandText = cmd.CommandText & "datetime,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_sentby=true then cmd.CommandText = cmd.CommandText & "sentby,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from NewsEvents where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New NewsEvents
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_title =true then p.title =checknull(dt.Rows(i)("title "))
p.I_Display_title =Display_title 
if Display_thumbnail=true then p.thumbnail=checknull(dt.Rows(i)("thumbnail"))
p.I_Display_thumbnail=Display_thumbnail
if Display_description =true then p.description =checknull(dt.Rows(i)("description "))
p.I_Display_description =Display_description 
if Display_link =true then p.link =checknull(dt.Rows(i)("link "))
p.I_Display_link =Display_link 
if Display_file_data=true then p.file_data=checknull(dt.Rows(i)("file_data"))
p.I_Display_file_data=Display_file_data
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
cmd.CommandText = "update NewsEvents set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_title =true then cmd.CommandText =cmd.CommandText & " title =@title ,"
if I_Display_thumbnail=true then cmd.CommandText =cmd.CommandText & " thumbnail=@thumbnail,"
if I_Display_description =true then cmd.CommandText =cmd.CommandText & " description =@description ,"
if I_Display_link =true then cmd.CommandText =cmd.CommandText & " link =@link ,"
if I_Display_file_data=true then cmd.CommandText =cmd.CommandText & " file_data=@file_data,"
if I_Display_datetime=true then cmd.CommandText =cmd.CommandText & " datetime=@datetime,"
if I_Display_status=true then cmd.CommandText =cmd.CommandText & " status=@status,"
if I_Display_sentby=true then cmd.CommandText =cmd.CommandText & " sentby=@sentby,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_title =true then cmd.Parameters.Add("@title ", 22, 255, "title ")
if I_Display_title =true then cmd.Parameters("@title ").Value = SetNull(title )

if I_Display_thumbnail=true then cmd.Parameters.Add("@thumbnail", 21, -1, "thumbnail")
if I_Display_thumbnail=true then cmd.Parameters("@thumbnail").Value = SetNull(thumbnail)

if I_Display_description =true then cmd.Parameters.Add("@description ", 18, 2147483647, "description ")
if I_Display_description =true then cmd.Parameters("@description ").Value = SetNull(description )

if I_Display_link =true then cmd.Parameters.Add("@link ", 22, -1, "link ")
if I_Display_link =true then cmd.Parameters("@link ").Value = SetNull(link )

if I_Display_file_data=true then cmd.Parameters.Add("@file_data", 21, -1, "file_data")
if I_Display_file_data=true then cmd.Parameters("@file_data").Value = SetNull(file_data)

if I_Display_datetime=true then cmd.Parameters.Add("@datetime", 4, 0, "datetime")
if I_Display_datetime=true then cmd.Parameters("@datetime").Value = SetNull(datetime)

if I_Display_status=true then cmd.Parameters.Add("@status", 22, 150, "status")
if I_Display_status=true then cmd.Parameters("@status").Value = SetNull(status)

if I_Display_sentby=true then cmd.Parameters.Add("@sentby", 22, 255, "sentby")
if I_Display_sentby=true then cmd.Parameters("@sentby").Value = SetNull(sentby)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of NewsEvents)
Dim ps As New Generic.List(Of NewsEvents)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_title =true then cmd.CommandText = cmd.CommandText & "title ,"
if Display_thumbnail=true then cmd.CommandText = cmd.CommandText & "thumbnail,"
if Display_description =true then cmd.CommandText = cmd.CommandText & "description ,"
if Display_link =true then cmd.CommandText = cmd.CommandText & "link ,"
if Display_file_data=true then cmd.CommandText = cmd.CommandText & "file_data,"
if Display_datetime=true then cmd.CommandText = cmd.CommandText & "datetime,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_sentby=true then cmd.CommandText = cmd.CommandText & "sentby,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from NewsEvents " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New NewsEvents
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_title =true then p.title =checknull(dt.Rows(i)("title "))
p.I_Display_title =Display_title 
if Display_thumbnail=true then p.thumbnail=checknull(dt.Rows(i)("thumbnail"))
p.I_Display_thumbnail=Display_thumbnail
if Display_description =true then p.description =checknull(dt.Rows(i)("description "))
p.I_Display_description =Display_description 
if Display_link =true then p.link =checknull(dt.Rows(i)("link "))
p.I_Display_link =Display_link 
if Display_file_data=true then p.file_data=checknull(dt.Rows(i)("file_data"))
p.I_Display_file_data=Display_file_data
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


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of NewsEvents)
Dim ps As New Generic.List(Of NewsEvents)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from NewsEvents" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New NewsEvents
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class