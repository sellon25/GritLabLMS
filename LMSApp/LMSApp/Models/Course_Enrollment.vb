Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Course_Enrollment
    Inherits ENTITY

    Public Shared Display_id As Boolean = True
    Public Shared Display_userId As Boolean = True
    Public Shared Display_course_id As Boolean = True
    Public Shared Display_date_started As Boolean = True
    Public Shared Display_enrollment_status As Boolean = True
    Public Shared Display_date_end As Boolean = True

    Private I_Display_id As Boolean = True
    Private I_Display_userId As Boolean = True
    Private I_Display_course_id As Boolean = True
    Private I_Display_date_started As Boolean = True
    Private I_Display_enrollment_status As Boolean = True
    Private I_Display_date_end As Boolean = True

    Public previous_id As System.String

    Public id As System.String
    Public userId As System.String
    Public course_id As System.String
    Public date_started As Nullable(Of DateTime)
    Public enrollment_status As System.String
    Public date_end As Nullable(Of DateTime)
    Private newinstance As Boolean = True

    Shared Sub Set_Display_Field_All(display_flag As Boolean)
        Display_id = display_flag
        Display_userId = display_flag
        Display_course_id = display_flag
        Display_date_started = display_flag
        Display_enrollment_status = display_flag
        Display_date_end = display_flag
    End Sub

    Private Sub insert()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Course_Enrollment (id, userId, course_id, date_started, enrollment_status, date_end)"
        cmd.CommandText = cmd.CommandText & " values (@id, @userId, @course_id, @date_started, @enrollment_status, @date_end)"

        cmd.Parameters.Add("@id", SqlDbType.VarChar, 255).Value = setNull(id)
        cmd.Parameters.Add("@userId", SqlDbType.VarChar, 255).Value = setNull(userId)
        cmd.Parameters.Add("@course_id", SqlDbType.VarChar, 255).Value = setNull(course_id)
        cmd.Parameters.Add("@date_started", SqlDbType.DateTime).Value = setNull(date_started)
        cmd.Parameters.Add("@enrollment_status", SqlDbType.VarChar, 50).Value = setNull(enrollment_status)
        cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = setNull(date_end)

        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub

    Sub delete()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from Course_Enrollment where id=@previous_id"
        cmd.Parameters.Add("@previous_id", SqlDbType.VarChar, 255).Value = Me.previous_id

        cmd.ExecuteNonQuery()
    End Sub

    Shared Function load(id As System.String) As Course_Enrollment
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        If Display_id = True Then cmd.CommandText = cmd.CommandText & "id,"
        If Display_userId = True Then cmd.CommandText = cmd.CommandText & "userId,"
        If Display_course_id = True Then cmd.CommandText = cmd.CommandText & "course_id,"
        If Display_date_started = True Then cmd.CommandText = cmd.CommandText & "date_started,"
        If Display_enrollment_status = True Then cmd.CommandText = cmd.CommandText & "enrollment_status,"
        If Display_date_end = True Then cmd.CommandText = cmd.CommandText & "date_end,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Course_Enrollment where id=@id"
        cmd.Parameters.Add("@id", SqlDbType.VarChar, 255).Value = id

        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        Dim p As New Course_Enrollment
        For i = 0 To dt.Rows.Count - 1
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_userId = True Then p.userId = checkNull(dt.Rows(i)("userId"))
            p.I_Display_userId = Display_userId
            If Display_course_id = True Then p.course_id = checkNull(dt.Rows(i)("course_id"))
            p.I_Display_course_id = Display_course_id
            If Display_date_started = True Then p.date_started = checkNull(dt.Rows(i)("date_started"))
            p.I_Display_date_started = Display_date_started
            If Display_enrollment_status = True Then p.enrollment_status = checkNull(dt.Rows(i)("enrollment_status"))
            p.I_Display_enrollment_status = Display_enrollment_status
            If Display_date_end = True Then p.date_end = checkNull(dt.Rows(i)("date_end"))
            p.I_Display_date_end = Display_date_end
            p.previous_id = checkNull(dt.Rows(i)("id"))
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
        cmd.CommandText = "update Course_Enrollment set "
        If I_Display_id = True Then cmd.CommandText = cmd.CommandText & "id=@id,"
        If I_Display_userId = True Then cmd.CommandText = cmd.CommandText & "userId=@userId,"
        If I_Display_course_id = True Then cmd.CommandText = cmd.CommandText & "course_id=@course_id,"
        If I_Display_date_started = True Then cmd.CommandText = cmd.CommandText & "date_started=@date_started,"
        If I_Display_enrollment_status = True Then cmd.CommandText = cmd.CommandText & "enrollment_status=@enrollment_status,"
        If I_Display_date_end = True Then cmd.CommandText = cmd.CommandText & "date_end=@date_end,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " where id=@previous_id"

        cmd.Parameters.Add("@id", SqlDbType.VarChar, 255).Value = setNull(id)
        If I_Display_userId = True Then cmd.Parameters.Add("@userId", SqlDbType.VarChar, 255).Value = setNull(userId)
        If I_Display_course_id = True Then cmd.Parameters.Add("@course_id", SqlDbType.VarChar, 255).Value = setNull(course_id)
        If I_Display_date_started = True Then cmd.Parameters.Add("@date_started", SqlDbType.DateTime).Value = setNull(date_started)
        If I_Display_enrollment_status = True Then cmd.Parameters.Add("@enrollment_status", SqlDbType.VarChar, 50).Value = setNull(enrollment_status)
        If I_Display_date_end = True Then cmd.Parameters.Add("@date_end", SqlDbType.DateTime).Value = setNull(date_end)
        cmd.Parameters.Add("@previous_id", SqlDbType.VarChar, 255).Value = Me.previous_id

        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub

    Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course_Enrollment)
        Dim ps As New Generic.List(Of Course_Enrollment)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        If Display_id = True Then cmd.CommandText = cmd.CommandText & "id,"
        If Display_userId = True Then cmd.CommandText = cmd.CommandText & "userId,"
        If Display_course_id = True Then cmd.CommandText = cmd.CommandText & "course_id,"
        If Display_date_started = True Then cmd.CommandText = cmd.CommandText & "date_started,"
        If Display_enrollment_status = True Then cmd.CommandText = cmd.CommandText & "enrollment_status,"
        If Display_date_end = True Then cmd.CommandText = cmd.CommandText & "date_end,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Course_Enrollment " & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Course_Enrollment
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_userId = True Then p.userId = checkNull(dt.Rows(i)("userId"))
            p.I_Display_userId = Display_userId
            If Display_course_id = True Then p.course_id = checkNull(dt.Rows(i)("course_id"))
            p.I_Display_course_id = Display_course_id
            If Display_date_started = True Then p.date_started = checkNull(dt.Rows(i)("date_started"))
            p.I_Display_date_started = Display_date_started
            If Display_enrollment_status = True Then p.enrollment_status = checkNull(dt.Rows(i)("enrollment_status"))
            p.I_Display_enrollment_status = Display_enrollment_status
            If Display_date_end = True Then p.date_end = checkNull(dt.Rows(i)("date_end"))
            p.I_Display_date_end = Display_date_end
            p.previous_id = checkNull(dt.Rows(i)("id"))
            p.newinstance = False
            ps.Add(p)
        Next
        Return ps
    End Function

    Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course_Enrollment)
        Dim ps As New Generic.List(Of Course_Enrollment)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select id from Course_Enrollment" & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Course_Enrollment
            p.id = checkNull(dt.Rows(i)("id"))
            p.previous_id = checkNull(dt.Rows(i)("id"))
            p.newinstance = False
            ps.Add(p)
        Next
        Return ps
    End Function
End Class
