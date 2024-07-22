Imports System.Globalization

Public Class ENTITY

    Shared Function checkNull(ByVal val As Object) As Object
        If IsDBNull(val) Then
            Return Nothing
        Else
            Return val
        End If

    End Function
    Shared Function setNull(ByVal val As Object) As Object
        If val Is Nothing Then
            Return DBNull.Value
        Else
            Return val
        End If

    End Function
    Shared Function getConnection() As System.Data.SqlClient.SqlConnection
        If HttpContext.Current Is Nothing Then
            Return genfunctions.eod_conn
        Else
            Return HttpContext.Current.Session("conn")
        End If

    End Function
    Shared Function getTransaction() As System.Data.SqlClient.SqlTransaction
        If HttpContext.Current Is Nothing Then
            Return genfunctions.eod_trans
        Else
            Return HttpContext.Current.Session("trans")
        End If

    End Function

    Shared Function checkStrNull(ByVal val As Object) As Object
        If val Is Nothing Then
            Return "Null"
        Else
            Return val
        End If

    End Function
    Shared Function checkNumNull(ByVal val As Object) As Object
        If val Is Nothing Then
            Return 0
        ElseIf val.ToString().Trim() = "" Then
            Return 0
        Else
            Return val
        End If

    End Function

    Shared Function ToTitleCase(input As String) As String
        If String.IsNullOrEmpty(input) Then
            Return input
        End If

        Dim cultureInfo As CultureInfo = cultureInfo.CurrentCulture
        Dim textInfo As TextInfo = cultureInfo.TextInfo

        Return textInfo.ToTitleCase(input.ToLower())
    End Function

End Class
