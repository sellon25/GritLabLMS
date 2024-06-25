Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Course_Submission
    Inherits ENTITY

    Public Shared Display_id As Boolean = True
    Public Shared Display_submission_id As Boolean = True
    Public Shared Display_course_id As Boolean = True
    Public Shared Display_user_id As Boolean = True
    Public Shared Display_sub_datetime As Boolean = True
    Public Shared Display_text As Boolean = True
    Public Shared Display_file_data As Boolean = True

    Private I_Display_id As Boolean = True
    Private I_Display_submission_id As Boolean = True
    Private I_Display_course_id As Boolean = True
    Private I_Display_user_id As Boolean = True
    Private I_Display_sub_datetime As Boolean = True
    Private I_Display_text As Boolean = True
    Private I_Display_file_data As Boolean = True

    Public previous_id As Nullable(Of System.Int32)

    Public id As Nullable(Of System.Int32)
    Public submission_id As Nullable(Of System.Int32)
    Public course_id As System.String
    Public user_id As System.String
    Public sub_datetime As Nullable(Of System.DateTime)
    Public text As System.String
    Public file_data As System.String

    Private newinstance As Boolean = True

    Shared Sub Set_Display_Field_All(display_flag As Boolean)
        Display_id = display_flag
        Display_submission_id = display_flag
        Display_course_id = display_flag
        Display_user_id = display_flag
        Display_sub_datetime = display_flag
        Display_text = display_flag
        Display_file_data = display_flag
    End Sub

    Private Sub insert()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "INSERT INTO Course_Submission (id, submission_id, course_id, user_id, sub_datetime, text, file_data) "
        cmd.CommandText &= "VALUES (@id, @submission_id, @course_id, @user_id, @sub_datetime, @text, @file_data)"

        cmd.Parameters.Add("@id", 8, 0, "id").Value = setNull(id)
        cmd.Parameters.Add("@submission_id", 8, 0, "submission_id").Value = setNull(submission_id)
        cmd.Parameters.Add("@course_id", 22, 255, "course_id").Value = setNull(course_id)
        cmd.Parameters.Add("@user_id", 22, 255, "user_id").Value = setNull(user_id)
        cmd.Parameters.Add("@sub_datetime", 4, 0, "sub_datetime").Value = setNull(sub_datetime)
        cmd.Parameters.Add("@text", 18, -1, "text").Value = setNull(text)
        cmd.Parameters.Add("@file_data", 18, -1, "file_data").Value = setNull(file_data)

        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub

    Sub delete()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "DELETE FROM Course_Submission WHERE id=@previous_id"
        cmd.Parameters.Add("@previous_id", 8, 0, "previous_id").Value = Me.previous_id

        cmd.ExecuteNonQuery()
    End Sub

    Shared Function load(id As System.Int32) As Course_Submission
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT id, submission_id, course_id, user_id, sub_datetime, text, file_data FROM Course_Submission WHERE id=@id"
        cmd.Parameters.Add("@id", 8, 0, "id").Value = id

        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        Dim p As New Course_Submission
        For i = 0 To dt.Rows.Count - 1
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            p.submission_id = checkNull(dt.Rows(i)("submission_id"))
            p.I_Display_submission_id = Display_submission_id
            p.course_id = checkNull(dt.Rows(i)("course_id"))
            p.I_Display_course_id = Display_course_id
            p.user_id = checkNull(dt.Rows(i)("user_id"))
            p.I_Display_user_id = Display_user_id
            p.sub_datetime = checkNull(dt.Rows(i)("sub_datetime"))
            p.I_Display_sub_datetime = Display_sub_datetime
            p.text = checkNull(dt.Rows(i)("text"))
            p.I_Display_text = Display_text
            p.file_data = checkNull(dt.Rows(i)("file_data"))
            p.I_Display_file_data = Display_file_data
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
        cmd.CommandText = "UPDATE Course_Submission SET id=@id, submission_id=@submission_id, course_id=@course_id, "
        cmd.CommandText &= "user_id=@user_id, sub_datetime=@sub_datetime, text=@text, file_data=@file_data WHERE id=@previous_id"

        cmd.Parameters.Add("@id", 8, 0, "id").Value = setNull(id)
        cmd.Parameters.Add("@submission_id", 8, 0, "submission_id").Value = setNull(submission_id)
        cmd.Parameters.Add("@course_id", 22, 255, "course_id").Value = setNull(course_id)
        cmd.Parameters.Add("@user_id", 22, 255, "user_id").Value = setNull(user_id)
        cmd.Parameters.Add("@sub_datetime", 4, 0, "sub_datetime").Value = setNull(sub_datetime)
        cmd.Parameters.Add("@text", 18, -1, "text").Value = setNull(text)
        cmd.Parameters.Add("@file_data", 18, -1, "file_data").Value = setNull(file_data)
        cmd.Parameters.Add("@previous_id", 8, 0, "previous_id").Value = Me.previous_id

        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub

    Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course_Submission)
        Dim ps As New Generic.List(Of Course_Submission)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT id, submission_id, course_id, user_id, sub_datetime, text, file_data FROM Course_Submission " & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Course_Submission
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            p.submission_id = checkNull(dt.Rows(i)("submission_id"))
            p.I_Display_submission_id = Display_submission_id
            p.course_id = checkNull(dt.Rows(i)("course_id"))
            p.I_Display_course_id = Display_course_id
            p.user_id = checkNull(dt.Rows(i)("user_id"))
            p.I_Display_user_id = Display_user_id
            p.sub_datetime = checkNull(dt.Rows(i)("sub_datetime"))
            p.I_Display_sub_datetime = Display_sub_datetime
            p.text = checkNull(dt.Rows(i)("text"))
            p.I_Display_text = Display_text
            p.file_data = checkNull(dt.Rows(i)("file_data"))
            p.I_Display_file_data = Display_file_data
            p.previous_id = checkNull(dt.Rows(i)("id"))
            p.newinstance = False
            ps.Add(p)
        Next
        Return ps
    End Function

    Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Course_Submission)
        Dim ps As New Generic.List(Of Course_Submission)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT id FROM Course_Submission " & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Course_Submission
            p.id = checkNull(dt.Rows(i)("id"))
            p.previous_id = checkNull(dt.Rows(i)("id"))
            p.newinstance = False
            ps.Add(p)
        Next
        Return ps
    End Function

End Class
