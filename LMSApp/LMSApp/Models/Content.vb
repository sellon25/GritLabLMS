Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Content
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_title  as Boolean=true
Public Shared Display_thumbnail as Boolean=true
Public Shared Display_description  as Boolean=true
Public Shared Display_link  as Boolean=true
Public Shared Display_file_data as Boolean=true
Public Shared Display_datetime as Boolean=true
Public Shared Display_status as Boolean=true
Public Shared Display_project_id as Boolean=true
Public Shared Display_course_id as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_title  as Boolean=true
Private I_Display_thumbnail as Boolean=true
Private I_Display_description  as Boolean=true
Private I_Display_link  as Boolean=true
Private I_Display_file_data as Boolean=true
Private I_Display_datetime as Boolean=true
Private I_Display_status as Boolean=true
Private I_Display_project_id as Boolean=true
Private I_Display_course_id as Boolean=true

Public previous_id as nullable(of System.Int32)

Public id as nullable(of System.Int32)
Public title  as System.String
Public thumbnail as System.Byte()
Public description  as System.String
Public link  as System.String
Public file_data as System.Byte()
Public datetime as nullable(of System.DateTime)
Public status as nullable(of System.Int32)
Public project_id as System.String
Public course_id as System.String
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
Display_project_id=display_flag
Display_course_id=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Content (title ,thumbnail,description ,link ,file_data,datetime,status,project_id,course_id)"
        cmd.CommandText = cmd.CommandText & "values(@title ,@thumbnail,@description ,@link ,@file_data,@datetime,@status,@project_id,@course_id)"

        'cmd.Parameters.Add("@id" , 8 , 0 , "id")
        'cmd.Parameters("@id").Value = SetNull(id)
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
cmd.Parameters.Add("@status" , 8 , 0 , "status")
cmd.Parameters("@status").Value = SetNull(status)
cmd.Parameters.Add("@project_id" , 22 , 255 , "project_id")
cmd.Parameters("@project_id").Value = SetNull(project_id)
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
cmd.CommandText = "delete from Content where id=@previous_id"
cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.Int32) As Content
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
if Display_project_id=true then cmd.CommandText = cmd.CommandText & "project_id,"
if Display_course_id=true then cmd.CommandText = cmd.CommandText & "course_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Content where id=@id"
cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Content
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
            If Display_title = True Then p.title = checkNull(dt.Rows(i)("title"))
            p.I_Display_title =Display_title 
if Display_thumbnail=true then p.thumbnail=checknull(dt.Rows(i)("thumbnail"))
p.I_Display_thumbnail=Display_thumbnail
            If Display_description = True Then p.description = checkNull(dt.Rows(i)("description"))
            p.I_Display_description =Display_description
            If Display_link = True Then p.link = checkNull(dt.Rows(i)("link"))
            p.I_Display_link =Display_link 
if Display_file_data=true then p.file_data=checknull(dt.Rows(i)("file_data"))
p.I_Display_file_data=Display_file_data
if Display_datetime=true then p.datetime=checknull(dt.Rows(i)("datetime"))
p.I_Display_datetime=Display_datetime
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
if Display_project_id=true then p.project_id=checknull(dt.Rows(i)("project_id"))
p.I_Display_project_id=Display_project_id
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
cmd.CommandText = "update Content set "
cmd.CommandText =cmd.CommandText & " id=@id,"
        If I_Display_title = True Then cmd.CommandText = cmd.CommandText & " title =@title,"
        If I_Display_thumbnail=true then cmd.CommandText =cmd.CommandText & " thumbnail=@thumbnail,"
        If I_Display_description = True Then cmd.CommandText = cmd.CommandText & " description =@description,"
        If I_Display_link = True Then cmd.CommandText = cmd.CommandText & " link =@link,"
        If I_Display_file_data=true then cmd.CommandText =cmd.CommandText & " file_data=@file_data,"
if I_Display_datetime=true then cmd.CommandText =cmd.CommandText & " datetime=@datetime,"
if I_Display_status=true then cmd.CommandText =cmd.CommandText & " status=@status,"
if I_Display_project_id=true then cmd.CommandText =cmd.CommandText & " project_id=@project_id,"
if I_Display_course_id=true then cmd.CommandText =cmd.CommandText & " course_id=@course_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 8, 0, "id")
cmd.Parameters("@id").Value = SetNull(id)

        If I_Display_title = True Then cmd.Parameters.Add("@title ", 22, 255, "title")
        If I_Display_title =true then cmd.Parameters("@title ").Value = SetNull(title )

if I_Display_thumbnail=true then cmd.Parameters.Add("@thumbnail", 21, -1, "thumbnail")
if I_Display_thumbnail=true then cmd.Parameters("@thumbnail").Value = SetNull(thumbnail)

        If I_Display_description = True Then cmd.Parameters.Add("@description", 18, 2147483647, "description")
        If I_Display_description = True Then cmd.Parameters("@description").Value = setNull(description)

        If I_Display_link = True Then cmd.Parameters.Add("@link", 22, -1, "link")
        If I_Display_link = True Then cmd.Parameters("@link").Value = setNull(link)

        If I_Display_file_data=true then cmd.Parameters.Add("@file_data", 21, -1, "file_data")
if I_Display_file_data=true then cmd.Parameters("@file_data").Value = SetNull(file_data)

if I_Display_datetime=true then cmd.Parameters.Add("@datetime", 4, 0, "datetime")
if I_Display_datetime=true then cmd.Parameters("@datetime").Value = SetNull(datetime)

if I_Display_status=true then cmd.Parameters.Add("@status", 8, 0, "status")
if I_Display_status=true then cmd.Parameters("@status").Value = SetNull(status)

if I_Display_project_id=true then cmd.Parameters.Add("@project_id", 22, 255, "project_id")
if I_Display_project_id=true then cmd.Parameters("@project_id").Value = SetNull(project_id)

if I_Display_course_id=true then cmd.Parameters.Add("@course_id", 22, 255, "course_id")
if I_Display_course_id=true then cmd.Parameters("@course_id").Value = SetNull(course_id)



cmd.Parameters.Add("@previous_id", 8, 0, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Content)
Dim ps As New Generic.List(Of Content)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
        If Display_title = True Then cmd.CommandText = cmd.CommandText & "title,"
        If Display_thumbnail=true then cmd.CommandText = cmd.CommandText & "thumbnail,"
        If Display_description = True Then cmd.CommandText = cmd.CommandText & "description,"
        If Display_link = True Then cmd.CommandText = cmd.CommandText & "link,"
        If Display_file_data=true then cmd.CommandText = cmd.CommandText & "file_data,"
if Display_datetime=true then cmd.CommandText = cmd.CommandText & "datetime,"
if Display_status=true then cmd.CommandText = cmd.CommandText & "status,"
if Display_project_id=true then cmd.CommandText = cmd.CommandText & "project_id,"
if Display_course_id=true then cmd.CommandText = cmd.CommandText & "course_id,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Content " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Content
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
            If Display_title = True Then p.title = checkNull(dt.Rows(i)("title"))
            p.I_Display_title =Display_title 
if Display_thumbnail=true then p.thumbnail=checknull(dt.Rows(i)("thumbnail"))
p.I_Display_thumbnail=Display_thumbnail
            If Display_description = True Then p.description = checkNull(dt.Rows(i)("description"))
            p.I_Display_description =Display_description
            If Display_link = True Then p.link = checkNull(dt.Rows(i)("link"))
            p.I_Display_link =Display_link 
if Display_file_data=true then p.file_data=checknull(dt.Rows(i)("file_data"))
p.I_Display_file_data=Display_file_data
if Display_datetime=true then p.datetime=checknull(dt.Rows(i)("datetime"))
p.I_Display_datetime=Display_datetime
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
if Display_project_id=true then p.project_id=checknull(dt.Rows(i)("project_id"))
p.I_Display_project_id=Display_project_id
if Display_course_id=true then p.course_id=checknull(dt.Rows(i)("course_id"))
p.I_Display_course_id=Display_course_id
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Content)
Dim ps As New Generic.List(Of Content)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Content" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Content
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class