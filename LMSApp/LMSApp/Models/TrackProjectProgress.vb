Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class TrackProjectProgress
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_milestone  as Boolean=true
Public Shared Display_comment as Boolean=true
Public Shared Display_status as Boolean=true
Public Shared Display_date_started as Boolean=true
Public Shared Display_date_end as Boolean=true
Public Shared Display_progress as Boolean=true
Public Shared Display_project_id as Boolean=true
Public Shared Display_employee_id as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_milestone  as Boolean=true
Private I_Display_comment as Boolean=true
Private I_Display_status as Boolean=true
Private I_Display_date_started as Boolean=true
Private I_Display_date_end as Boolean=true
Private I_Display_progress as Boolean=true
Private I_Display_project_id as Boolean=true
Private I_Display_employee_id as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public milestone  as System.String
Public comment as System.String
Public status as System.String
Public date_started as nullable(of System.DateTime)
Public date_end as nullable(of System.DateTime)
Public progress as nullable(of System.Double)
Public project_id as System.String
Public employee_id as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_milestone =display_flag
Display_comment=display_flag
Display_status=display_flag
Display_date_started=display_flag
Display_date_end=display_flag
Display_progress=display_flag
Display_project_id=display_flag
Display_employee_id=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into TrackProjectProgress (id,milestone ,comment,status,date_started,date_end,progress,project_id,employee_id)"
cmd.CommandText = cmd.CommandText & "values(@id,@milestone ,@comment,@status,@date_started,@date_end,@progress,@project_id,@employee_id)"

cmd.Parameters.Add("@id" , 8 , 0 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@milestone " , 22 , 500 , "milestone ")
cmd.Parameters("@milestone ").Value = SetNull(milestone )
cmd.Parameters.Add("@comment" , 22 , -1 , "comment")
cmd.Parameters("@comment").Value = SetNull(comment)
cmd.Parameters.Add("@status" , 22 , 150 , "status")
cmd.Parameters("@status").Value = SetNull(status)
cmd.Parameters.Add("@date_started" , 4 , 0 , "date_started")
cmd.Parameters("@date_started").Value = SetNull(date_started)
cmd.Parameters.Add("@date_end" , 4 , 0 , "date_end")
cmd.Parameters("@date_end").Value = SetNull(date_end)
cmd.Parameters.Add("@progress" , 6 , 0 , "progress")
cmd.Parameters("@progress").Value = SetNull(progress)
cmd.Parameters.Add("@project_id" , 22 , 255 , "project_id")
cmd.Parameters("@project_id").Value = SetNull(project_id)
cmd.Parameters.Add("@employee_id" , 22 , 255 , "employee_id")
cmd.Parameters("@employee_id").Value = SetNull(employee_id)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from TrackProjectProgress where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As TrackProjectProgress
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_milestone =true then cmd.CommandText = cmd.CommandText & "milestone ,"
if Display_comment=true then cmd.CommandText = cmd.CommandText & "comment,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_date_started=true then cmd.CommandText = cmd.CommandText & "date_started,"
if Display_date_end=true then cmd.CommandText = cmd.CommandText & "date_end,"
if Display_progress=true then cmd.CommandText = cmd.CommandText & "progress,"
if Display_project_id=true then cmd.CommandText = cmd.CommandText & "project_id,"
if Display_employee_id=true then cmd.CommandText = cmd.CommandText & "employee_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from TrackProjectProgress where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New TrackProjectProgress
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_milestone =true then p.milestone =checknull(dt.Rows(i)("milestone "))
p.I_Display_milestone =Display_milestone 
if Display_comment=true then p.comment=checknull(dt.Rows(i)("comment"))
p.I_Display_comment=Display_comment
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
if Display_date_started=true then p.date_started=checknull(dt.Rows(i)("date_started"))
p.I_Display_date_started=Display_date_started
if Display_date_end=true then p.date_end=checknull(dt.Rows(i)("date_end"))
p.I_Display_date_end=Display_date_end
if Display_progress=true then p.progress=checknull(dt.Rows(i)("progress"))
p.I_Display_progress=Display_progress
if Display_project_id=true then p.project_id=checknull(dt.Rows(i)("project_id"))
p.I_Display_project_id=Display_project_id
if Display_employee_id=true then p.employee_id=checknull(dt.Rows(i)("employee_id"))
p.I_Display_employee_id=Display_employee_id
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
cmd.CommandText = "update TrackProjectProgress set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_milestone =true then cmd.CommandText =cmd.CommandText & " milestone =@milestone ,"
if I_Display_comment=true then cmd.CommandText =cmd.CommandText & " comment=@comment,"
if I_Display_status=true then cmd.CommandText =cmd.CommandText & " status=@status,"
if I_Display_date_started=true then cmd.CommandText =cmd.CommandText & " date_started=@date_started,"
if I_Display_date_end=true then cmd.CommandText =cmd.CommandText & " date_end=@date_end,"
if I_Display_progress=true then cmd.CommandText =cmd.CommandText & " progress=@progress,"
if I_Display_project_id=true then cmd.CommandText =cmd.CommandText & " project_id=@project_id,"
if I_Display_employee_id=true then cmd.CommandText =cmd.CommandText & " employee_id=@employee_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_milestone =true then cmd.Parameters.Add("@milestone ", 22, 500, "milestone ")
if I_Display_milestone =true then cmd.Parameters("@milestone ").Value = SetNull(milestone )

if I_Display_comment=true then cmd.Parameters.Add("@comment", 22, -1, "comment")
if I_Display_comment=true then cmd.Parameters("@comment").Value = SetNull(comment)

if I_Display_status=true then cmd.Parameters.Add("@status", 22, 150, "status")
if I_Display_status=true then cmd.Parameters("@status").Value = SetNull(status)

if I_Display_date_started=true then cmd.Parameters.Add("@date_started", 4, 0, "date_started")
if I_Display_date_started=true then cmd.Parameters("@date_started").Value = SetNull(date_started)

if I_Display_date_end=true then cmd.Parameters.Add("@date_end", 4, 0, "date_end")
if I_Display_date_end=true then cmd.Parameters("@date_end").Value = SetNull(date_end)

if I_Display_progress=true then cmd.Parameters.Add("@progress", 6, 0, "progress")
if I_Display_progress=true then cmd.Parameters("@progress").Value = SetNull(progress)

if I_Display_project_id=true then cmd.Parameters.Add("@project_id", 22, 255, "project_id")
if I_Display_project_id=true then cmd.Parameters("@project_id").Value = SetNull(project_id)

if I_Display_employee_id=true then cmd.Parameters.Add("@employee_id", 22, 255, "employee_id")
if I_Display_employee_id=true then cmd.Parameters("@employee_id").Value = SetNull(employee_id)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of TrackProjectProgress)
Dim ps As New Generic.List(Of TrackProjectProgress)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_milestone =true then cmd.CommandText = cmd.CommandText & "milestone ,"
if Display_comment=true then cmd.CommandText = cmd.CommandText & "comment,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_date_started=true then cmd.CommandText = cmd.CommandText & "date_started,"
if Display_date_end=true then cmd.CommandText = cmd.CommandText & "date_end,"
if Display_progress=true then cmd.CommandText = cmd.CommandText & "progress,"
if Display_project_id=true then cmd.CommandText = cmd.CommandText & "project_id,"
if Display_employee_id=true then cmd.CommandText = cmd.CommandText & "employee_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from TrackProjectProgress " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New TrackProjectProgress
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_milestone =true then p.milestone =checknull(dt.Rows(i)("milestone "))
p.I_Display_milestone =Display_milestone 
if Display_comment=true then p.comment=checknull(dt.Rows(i)("comment"))
p.I_Display_comment=Display_comment
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
if Display_date_started=true then p.date_started=checknull(dt.Rows(i)("date_started"))
p.I_Display_date_started=Display_date_started
if Display_date_end=true then p.date_end=checknull(dt.Rows(i)("date_end"))
p.I_Display_date_end=Display_date_end
if Display_progress=true then p.progress=checknull(dt.Rows(i)("progress"))
p.I_Display_progress=Display_progress
if Display_project_id=true then p.project_id=checknull(dt.Rows(i)("project_id"))
p.I_Display_project_id=Display_project_id
if Display_employee_id=true then p.employee_id=checknull(dt.Rows(i)("employee_id"))
p.I_Display_employee_id=Display_employee_id
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of TrackProjectProgress)
Dim ps As New Generic.List(Of TrackProjectProgress)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from TrackProjectProgress" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New TrackProjectProgress
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class