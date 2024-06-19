Imports System.Data.SqlClient

Public Class DBInterface
    'Apps Connection String
    Public Shared connectstring As String = "Data Source=.;Initial Catalog=GritsLabDB;Integrated Security=True;Encrypt=False"


    Public Shared Sub SetUpConnection()
        If IsNothing(HttpContext.Current.Session("conn")) Then
            'Setup a DB Connection if it does not exist
            HttpContext.Current.Session("conn") = connect()
        End If
    End Sub

    Public Shared Function connect() As SqlConnection
        Try
            Dim conn As New SqlConnection
            conn.ConnectionString = connectstring
            conn.Open()
            Return conn
        Catch ex As Exception
            Throw New DatabaseConnectException(ex)
            Return Nothing
        End Try
    End Function
    Shared Sub copyRow(ByVal srctable As String, ByVal desttable As String, ByVal condition As String)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn") : If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandText = "INSERT INTO " + desttable + " SELECT * FROM " + srctable + " WHERE (" + condition + ")"
        cmd.ExecuteNonQuery()
    End Sub
End Class
