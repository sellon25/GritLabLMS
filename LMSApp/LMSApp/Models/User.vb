Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class User
inherits Entity

Public Shared Display_emailID as Boolean=True
    Public Shared Display_Username As Boolean = True
    Public Shared Display_FName as Boolean=true
Public Shared Display_LName as Boolean=true
Public Shared Display_password as Boolean=true
Public Shared Display_role  as Boolean=true
Public Shared Display_join_date  as Boolean=true
Public Shared Display_end_date as Boolean=true
Public Shared Display_status as Boolean=true

Private I_Display_emailID as Boolean=True
    Private I_Display_Username As Boolean = True
    Private I_Display_FName as Boolean=true
Private I_Display_LName as Boolean=true
Private I_Display_password as Boolean=true
Private I_Display_role  as Boolean=true
Private I_Display_join_date  as Boolean=true
Private I_Display_end_date as Boolean=true
Private I_Display_status as Boolean=true

Public previous_emailID as System.String

Public emailID as System.String
    Public Username As System.String
    Public FName as System.String
Public LName as System.String
Public password as System.String
Public role  as nullable(of System.Int32)
Public join_date  as nullable(of System.DateTime)
Public end_date as nullable(of System.DateTime)
Public status as System.String
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_emailID=display_flag
        Display_Username = display_flag
        Display_FName =display_flag
Display_LName=display_flag
Display_password=display_flag
Display_role =display_flag
Display_join_date =display_flag
Display_end_date=display_flag
Display_status=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into User (emailID,Username,FName,LName,password,role,join_date,end_date,status)"
        cmd.CommandText = cmd.CommandText & "values(@emailID,@Username,@FName,@LName,@password,@role ,@join_date ,@end_date,@status)"

        cmd.Parameters.Add("@emailID" , 22 , 255 , "emailID")
cmd.Parameters("@emailID").Value = SetNull(emailID)
        cmd.Parameters.Add("@Username", 22, 255, "Username")
        cmd.Parameters("@Username").Value = setNull(Username)
        cmd.Parameters.Add("@FName" , 22 , 255 , "FName")
cmd.Parameters("@FName").Value = SetNull(FName)
cmd.Parameters.Add("@LName" , 22 , 255 , "LName")
cmd.Parameters("@LName").Value = SetNull(LName)
cmd.Parameters.Add("@password" , 22 , 500 , "password")
cmd.Parameters("@password").Value = SetNull(password)
        cmd.Parameters.Add("@role ", 8, 0, "role")
        cmd.Parameters("@role ").Value = setNull(role)
        cmd.Parameters.Add("@join_date ", 31, 0, "join_date")
        cmd.Parameters("@join_date ").Value = setNull(join_date)
        cmd.Parameters.Add("@end_date", 31, 0, "end_date")
        cmd.Parameters("@end_date").Value = setNull(end_date)
        cmd.Parameters.Add("@status", 22, 50, "status")
        cmd.Parameters("@status").Value = setNull(status)


        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub


    Sub delete()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from User where emailID=@previous_emailID"
        cmd.Parameters.Add("@previous_emailID", 22, 255, "previous_emailID")
        cmd.Parameters("@previous_emailID").Value = Me.previous_emailID

        cmd.ExecuteNonQuery()
    End Sub


    Shared Function load(emailID As System.String) As User
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "emailID,"
        If Display_Username = True Then cmd.CommandText = cmd.CommandText & "Username,"
        If Display_FName = True Then cmd.CommandText = cmd.CommandText & "FName,"
        If Display_LName = True Then cmd.CommandText = cmd.CommandText & "LName,"
        If Display_password = True Then cmd.CommandText = cmd.CommandText & "password,"
        If Display_role = True Then cmd.CommandText = cmd.CommandText & "role,"
        If Display_join_date = True Then cmd.CommandText = cmd.CommandText & "join_date,"
        If Display_end_date = True Then cmd.CommandText = cmd.CommandText & "end_date,"
        If Display_status = True Then cmd.CommandText = cmd.CommandText & "status,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from [User] where emailID=@emailID"
        cmd.Parameters.Add("@emailID", 22, 255, "emailID")
        cmd.Parameters("@emailID").Value = emailID

        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        Dim p As New User
        For i = 0 To dt.Rows.Count - 1
            p.emailID = checkNull(dt.Rows(i)("emailID"))
            p.I_Display_emailID = Display_emailID
            If Display_Username = True Then p.Username = checkNull(dt.Rows(i)("Username"))
            p.I_Display_Username = Display_Username
            If Display_FName = True Then p.FName = checkNull(dt.Rows(i)("FName"))
            p.I_Display_FName = Display_FName
            If Display_LName = True Then p.LName = checkNull(dt.Rows(i)("LName"))
            p.I_Display_LName = Display_LName
            If Display_password = True Then p.password = checkNull(dt.Rows(i)("password"))
            p.I_Display_password = Display_password
            If Display_role = True Then p.role = checkNull(dt.Rows(i)("role"))
            p.I_Display_role = Display_role
            If Display_join_date = True Then p.join_date = checkNull(dt.Rows(i)("join_date"))
            p.I_Display_join_date = Display_join_date
            If Display_end_date = True Then p.end_date = checkNull(dt.Rows(i)("end_date"))
            p.I_Display_end_date = Display_end_date
            If Display_status = True Then p.status = checkNull(dt.Rows(i)("status"))
            p.I_Display_status = Display_status
            p.previous_emailID = checkNull(dt.Rows(i)("emailID"))
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

        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update User set "
        cmd.CommandText = cmd.CommandText & " emailID=@emailID,"
        If I_Display_Username = True Then cmd.CommandText = cmd.CommandText & " Username =@Username,"
        If I_Display_FName = True Then cmd.CommandText = cmd.CommandText & " FName=@FName,"
        If I_Display_LName = True Then cmd.CommandText = cmd.CommandText & " LName=@LName,"
        If I_Display_password = True Then cmd.CommandText = cmd.CommandText & " password=@password,"
        If I_Display_role = True Then cmd.CommandText = cmd.CommandText & " role =@role ,"
        If I_Display_join_date = True Then cmd.CommandText = cmd.CommandText & " join_date =@join_date ,"
        If I_Display_end_date = True Then cmd.CommandText = cmd.CommandText & " end_date=@end_date,"
        If I_Display_status = True Then cmd.CommandText = cmd.CommandText & " status=@status,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " where emailID=@previous_emailID"


        cmd.Parameters.Add("@emailID", 22, 255, "emailID")
        cmd.Parameters("@emailID").Value = setNull(emailID)

        If I_Display_Username = True Then cmd.Parameters.Add("@Username ", 22, 255, "Username")
        If I_Display_Username = True Then cmd.Parameters("@Username").Value = setNull(Username)

        If I_Display_FName = True Then cmd.Parameters.Add("@FName", 22, 255, "FName")
        If I_Display_FName = True Then cmd.Parameters("@FName").Value = setNull(FName)

        If I_Display_LName = True Then cmd.Parameters.Add("@LName", 22, 255, "LName")
        If I_Display_LName = True Then cmd.Parameters("@LName").Value = setNull(LName)

        If I_Display_password = True Then cmd.Parameters.Add("@password", 22, 500, "password")
        If I_Display_password = True Then cmd.Parameters("@password").Value = setNull(password)

        If I_Display_role = True Then cmd.Parameters.Add("@role ", 8, 0, "role")
        If I_Display_role = True Then cmd.Parameters("@role ").Value = setNull(role)

        If I_Display_join_date = True Then cmd.Parameters.Add("@join_date ", 31, 0, "join_date ")
        If I_Display_join_date = True Then cmd.Parameters("@join_date ").Value = setNull(join_date)

        If I_Display_end_date = True Then cmd.Parameters.Add("@end_date", 31, 0, "end_date")
        If I_Display_end_date = True Then cmd.Parameters("@end_date").Value = setNull(end_date)

        If I_Display_status = True Then cmd.Parameters.Add("@status", 22, 50, "status")
        If I_Display_status = True Then cmd.Parameters("@status").Value = setNull(status)



        cmd.Parameters.Add("@previous_emailID", 22, 255, "previous_emailID")
        cmd.Parameters("@previous_emailID").Value = Me.previous_emailID



        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub


    Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of User)
        Dim ps As New Generic.List(Of User)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "emailID,"
        If Display_Username = True Then cmd.CommandText = cmd.CommandText & "Username,"
        If Display_FName = True Then cmd.CommandText = cmd.CommandText & "FName,"
        If Display_LName = True Then cmd.CommandText = cmd.CommandText & "LName,"
        If Display_password = True Then cmd.CommandText = cmd.CommandText & "password,"
        If Display_role = True Then cmd.CommandText = cmd.CommandText & "role,"
        If Display_join_date = True Then cmd.CommandText = cmd.CommandText & "join_date ,"
        If Display_end_date = True Then cmd.CommandText = cmd.CommandText & "end_date,"
        If Display_status = True Then cmd.CommandText = cmd.CommandText & "status,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from User " & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New User
            p.emailID = checkNull(dt.Rows(i)("emailID"))
            p.I_Display_emailID = Display_emailID
            If Display_Username = True Then p.Username = checkNull(dt.Rows(i)("Username"))
            p.I_Display_Username = Display_Username
            If Display_FName = True Then p.FName = checkNull(dt.Rows(i)("FName"))
            p.I_Display_FName = Display_FName
            If Display_LName = True Then p.LName = checkNull(dt.Rows(i)("LName"))
            p.I_Display_LName = Display_LName
            If Display_password = True Then p.password = checkNull(dt.Rows(i)("password"))
            p.I_Display_password = Display_password
            If Display_role = True Then p.role = checkNull(dt.Rows(i)("role"))
            p.I_Display_role =Display_role 
if Display_join_date =true then p.join_date =checknull(dt.Rows(i)("join_date "))
p.I_Display_join_date =Display_join_date 
if Display_end_date=true then p.end_date=checknull(dt.Rows(i)("end_date"))
p.I_Display_end_date=Display_end_date
if Display_status=true then p.status=checknull(dt.Rows(i)("status"))
p.I_Display_status=Display_status
p.previous_emailID=checknull(dt.Rows(i)("emailID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of User)
Dim ps As New Generic.List(Of User)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select emailID from User" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New User
p.emailID=checknull(dt.Rows(i)("emailID"))
p.previous_emailID=checknull(dt.Rows(i)("emailID"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class