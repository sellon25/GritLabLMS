Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Project
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_name  as Boolean=true
Public Shared Display_description as Boolean=true
Public Shared Display_overview  as Boolean=true
Public Shared Display_status as Boolean=true
Public Shared Display_avg_progress as Boolean=true
Public Shared Display_date_started as Boolean=true
Public Shared Display_end_date as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_name  as Boolean=true
Private I_Display_description as Boolean=true
Private I_Display_overview  as Boolean=true
Private I_Display_status as Boolean=true
Private I_Display_avg_progress as Boolean=true
Private I_Display_date_started as Boolean=true
Private I_Display_end_date as Boolean=true

Public previous_id as System.String

Public id as System.String
Public name  as System.String
Public description as System.String
Public overview  as System.String
Public status as nullable(of System.Int32)
Public avg_progress as nullable(of System.Int32)
Public date_started as nullable(of System.DateTime)
Public end_date as nullable(of System.DateTime)
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_name =display_flag
Display_description=display_flag
Display_overview =display_flag
Display_status=display_flag
Display_avg_progress=display_flag
Display_date_started=display_flag
Display_end_date=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Project (id,name ,description,overview ,status,avg_progress,date_started,end_date)"
cmd.CommandText = cmd.CommandText & "values(@id,@name ,@description,@overview ,@status,@avg_progress,@date_started,@end_date)"

cmd.Parameters.Add("@id" , 22 , 255 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@name " , 22 , 255 , "name ")
cmd.Parameters("@name ").Value = SetNull(name )
cmd.Parameters.Add("@description" , 22 , 150 , "description")
cmd.Parameters("@description").Value = SetNull(description)
cmd.Parameters.Add("@overview " , 18 , 2147483647 , "overview ")
cmd.Parameters("@overview ").Value = SetNull(overview )
cmd.Parameters.Add("@status" , 8 , 0 , "status")
cmd.Parameters("@status").Value = SetNull(status)
cmd.Parameters.Add("@avg_progress" , 8 , 0 , "avg_progress")
cmd.Parameters("@avg_progress").Value = SetNull(avg_progress)
cmd.Parameters.Add("@date_started" , 31 , 0 , "date_started")
cmd.Parameters("@date_started").Value = SetNull(date_started)
cmd.Parameters.Add("@end_date" , 31 , 0 , "end_date")
cmd.Parameters("@end_date").Value = SetNull(end_date)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Project where id=@previous_id"
cmd.Parameters.Add("@previous_id", 22, 255, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.String) As Project
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_name =true then cmd.CommandText = cmd.CommandText & "name ,"
if Display_description=true then cmd.CommandText = cmd.CommandText & "description,"
if Display_overview =true then cmd.CommandText = cmd.CommandText & "overview ,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_avg_progress=true then cmd.CommandText = cmd.CommandText & "avg_progress,"
if Display_date_started=true then cmd.CommandText = cmd.CommandText & "date_started,"
if Display_end_date=true then cmd.CommandText = cmd.CommandText & "end_date,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Project where id=@id"
cmd.Parameters.Add("@id", 22, 255, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Project
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_name =true then p.name =checknull(dt.Rows(i)("name "))
p.I_Display_name =Display_name 
if Display_description=true then p.description=checknull(dt.Rows(i)("description"))
p.I_Display_description=Display_description
if Display_overview =true then p.overview =checknull(dt.Rows(i)("overview "))
p.I_Display_overview =Display_overview 
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
if Display_avg_progress=true then p.avg_progress=checknull(dt.Rows(i)("avg_progress"))
p.I_Display_avg_progress=Display_avg_progress
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
cmd.CommandText = "update Project set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_name =true then cmd.CommandText =cmd.CommandText & " name =@name ,"
if I_Display_description=true then cmd.CommandText =cmd.CommandText & " description=@description,"
if I_Display_overview =true then cmd.CommandText =cmd.CommandText & " overview =@overview ,"
if I_Display_status=true then cmd.CommandText =cmd.CommandText & " status=@status,"
if I_Display_avg_progress=true then cmd.CommandText =cmd.CommandText & " avg_progress=@avg_progress,"
if I_Display_date_started=true then cmd.CommandText =cmd.CommandText & " date_started=@date_started,"
if I_Display_end_date=true then cmd.CommandText =cmd.CommandText & " end_date=@end_date,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 22, 255, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_name =true then cmd.Parameters.Add("@name ", 22, 255, "name ")
if I_Display_name =true then cmd.Parameters("@name ").Value = SetNull(name )

if I_Display_description=true then cmd.Parameters.Add("@description", 22, 150, "description")
if I_Display_description=true then cmd.Parameters("@description").Value = SetNull(description)

if I_Display_overview =true then cmd.Parameters.Add("@overview ", 18, 2147483647, "overview ")
if I_Display_overview =true then cmd.Parameters("@overview ").Value = SetNull(overview )

if I_Display_status=true then cmd.Parameters.Add("@status", 8, 0, "status")
if I_Display_status=true then cmd.Parameters("@status").Value = SetNull(status)

if I_Display_avg_progress=true then cmd.Parameters.Add("@avg_progress", 8, 0, "avg_progress")
if I_Display_avg_progress=true then cmd.Parameters("@avg_progress").Value = SetNull(avg_progress)

if I_Display_date_started=true then cmd.Parameters.Add("@date_started", 31, 0, "date_started")
if I_Display_date_started=true then cmd.Parameters("@date_started").Value = SetNull(date_started)

if I_Display_end_date=true then cmd.Parameters.Add("@end_date", 31, 0, "end_date")
if I_Display_end_date=true then cmd.Parameters("@end_date").Value = SetNull(end_date)



cmd.Parameters.Add("@previous_id", 22, 255, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Project)
Dim ps As New Generic.List(Of Project)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_name =true then cmd.CommandText = cmd.CommandText & "name ,"
if Display_description=true then cmd.CommandText = cmd.CommandText & "description,"
if Display_overview =true then cmd.CommandText = cmd.CommandText & "overview ,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_avg_progress=true then cmd.CommandText = cmd.CommandText & "avg_progress,"
if Display_date_started=true then cmd.CommandText = cmd.CommandText & "date_started,"
if Display_end_date=true then cmd.CommandText = cmd.CommandText & "end_date,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Project " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Project
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_name =true then p.name =checknull(dt.Rows(i)("name "))
p.I_Display_name =Display_name 
if Display_description=true then p.description=checknull(dt.Rows(i)("description"))
p.I_Display_description=Display_description
if Display_overview =true then p.overview =checknull(dt.Rows(i)("overview "))
p.I_Display_overview =Display_overview 
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
if Display_avg_progress=true then p.avg_progress=checknull(dt.Rows(i)("avg_progress"))
p.I_Display_avg_progress=Display_avg_progress
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


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Project)
Dim ps As New Generic.List(Of Project)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Project" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Project
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class