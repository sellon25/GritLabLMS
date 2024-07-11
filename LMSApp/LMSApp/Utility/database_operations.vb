Imports System.Data.SqlClient
Imports System.Reflection

Public Class database_operations

    Public Shared Function GetNewPrimaryKey(ByVal pkColumnName As String, ByVal tableName As String, ByVal conn As SqlConnection) As Integer
        Dim newPk As Integer

        Try
            Dim cmd As New SqlCommand("SELECT MAX(" & pkColumnName & ") FROM " & tableName, conn)
            Dim result As Object = cmd.ExecuteScalar()
            If IsDBNull(result) Then
                newPk = 1
            Else
                newPk = Convert.ToInt32(result) + 1
            End If
        Catch ex As Exception
            ' Handle exception
            newPk = 1
        End Try

        ' Double-check that the newPk does not already exist
        Do While doesFieldExistInTable(pkColumnName, newPk.ToString(), tableName, conn)
            newPk += 1
        Loop

        Return newPk
    End Function


    Public Shared Sub insertIntoDB(ByVal sql As String, ByVal conn As SqlConnection)
        Try
            Dim cmd As New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub updateDB(ByVal sql As String, ByVal conn As SqlConnection)
        Try
            Dim cmd As New SqlCommand(sql, conn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            'donothing
        End Try
    End Sub
    Public Shared Sub DeleteFromDB(ByVal SQL As String, ByVal conn As SqlConnection)
        Dim cmd As New SqlCommand(SQL, conn)
        cmd.ExecuteNonQuery()
    End Sub
    Public Shared Function doesFieldExistInTable(ByVal columnName As String, ByVal columnValue As String, ByVal tableName As String, ByVal conn As SqlConnection) As Boolean
        Dim cmd As New SqlCommand()
        Dim sql As String
        Dim myReader As SqlDataReader = Nothing
        Dim retValue As Boolean = False
        sql = "select * from " & tableName & " where lower(" & columnName & ")=@columnValue"
        Try
            cmd.CommandText = sql
            cmd.Parameters.AddWithValue("@columnValue", columnValue)
            cmd.Connection = conn
            myReader = cmd.ExecuteReader()
            While myReader.Read
                retValue = True
            End While
            myReader.Close()
            Return retValue
        Catch ex As Exception
            'DO NUFFIN
        End Try
        Return retValue
    End Function
    Public Shared Function listAll(ByVal sql As String, ByVal conn As SqlConnection) As ArrayList
        'returns a column
        Dim cmd As New SqlCommand()
        Dim myReader As SqlDataReader = Nothing
        Dim a_list As New ArrayList

        cmd.CommandText = sql
        cmd.Connection = conn
        myReader = cmd.ExecuteReader()
        While myReader.Read
            a_list.Add(myReader.GetValue(0))
        End While
        myReader.Close()
        Return a_list

    End Function
    Public Shared Function get_value_with_key(ByVal sql As String, ByVal conn As SqlConnection) As Object
        Dim cmd As New SqlCommand()
        Dim myReader As SqlDataReader = Nothing
        Dim retval As Object = Nothing

        cmd.CommandText = sql
        cmd.Connection = conn
        myReader = cmd.ExecuteReader()
        While myReader.Read
            retval = myReader.GetValue(0)
        End While
        myReader.Close()
        Return retval
    End Function
    Public Shared Function get_variant_value_from_db_with_sql(ByVal sql As String, ByVal conn As SqlConnection) As String
        Dim retval As String = ""

        Dim cmd As New SqlCommand()
        Dim myReader As SqlDataReader = Nothing

        cmd.CommandText = sql
        cmd.Connection = conn
        myReader = cmd.ExecuteReader()
        While myReader.Read
            If myReader.GetValue(0) Is Nothing Then
                retval = "NA"
            Else
                retval = myReader.GetValue(0).ToString
            End If

        End While
        myReader.Close()

        Return retval

    End Function
    Public Shared Function get_next_ID(ByVal sql As String, ByVal conn As SqlConnection) As Integer
        Dim retval As Integer = 0

        'sql="select max(p_key_colunmnname) from tablename 

        Dim cmd As New SqlCommand()
        Dim myReader As SqlDataReader = Nothing
        Dim a_list As New ArrayList

        cmd.CommandText = sql
        cmd.Connection = conn
        myReader = cmd.ExecuteReader()
        While myReader.Read
            a_list.Add(myReader.GetValue(0))
        End While
        myReader.Close()
        If a_list.Item(0).ToString = "" Then
            retval = 1
        Else
            retval = CInt(a_list.Item(0)) + 1
        End If
        Return retval
    End Function
End Class
