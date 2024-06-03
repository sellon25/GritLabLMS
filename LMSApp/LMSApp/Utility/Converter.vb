Imports System.IO
Public Class Converter
    Public Shared Function ConvertBinaryStringToJpg(binaryString As String, filePath As String) As Boolean
        Try
            ' Convert the binary string to bytes
            Dim imageBytes As Byte() = Convert.FromBase64String(binaryString)

            ' Create a file stream to write the bytes to a file
            Using fs As New FileStream(filePath, FileMode.Create)
                fs.Write(imageBytes, 0, imageBytes.Length)
            End Using

            ' File saved successfully
            Return True
        Catch ex As Exception
            ' Handle exceptions (e.g., file not saved)
            Console.WriteLine("Error converting binary string to JPG: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function ConvertJpgToVarbinary(imagePath As String) As Byte()
        Try
            ' Read the image file into bytes
            Dim imageBytes As Byte() = File.ReadAllBytes(imagePath)

            ' Return the image bytes as varbinary
            Return imageBytes
        Catch ex As Exception
            ' Handle exceptions (e.g., file not found)
            Console.WriteLine("Error converting JPG to varbinary: " & ex.Message)
            Return Nothing
        End Try
    End Function

    'Protected Sub UploadImage(sender As Object, e As EventArgs)
    '    If FileUpload.HasFile Then
    '        Dim connectionString As String = "Your_Connection_String"
    '        Using connection As New SqlConnection(connectionString)
    '            connection.Open()
    '            Dim sql As String = "INSERT INTO Images (ImageName, ImageData) VALUES (@ImageName, @ImageData)"
    '            Using command As New SqlCommand(sql, connection)
    '                command.Parameters.AddWithValue("@ImageName", FileUpload.FileName)
    '                command.Parameters.AddWithValue("@ImageData", FileUpload.FileBytes)
    '                command.ExecuteNonQuery()
    '            End Using
    '        End Using
    '    End If
    'End Sub

    'Protected Sub RetrieveImage(sender As Object, e As EventArgs)
    '    Dim connectionString As String = "Your_Connection_String"
    '    Using connection As New SqlConnection(connectionString)
    '        connection.Open()
    '        Dim sql As String = "SELECT TOP 1 ImageData FROM Images ORDER BY ID DESC"
    '        Using command As New SqlCommand(sql, connection)
    '            Using reader As SqlDataReader = command.ExecuteReader()
    '                If reader.Read() Then
    '                    Dim imageData As Byte() = DirectCast(reader("ImageData"), Byte())
    '                    Dim base64String As String = Convert.ToBase64String(imageData)
    '                    imgUploaded.ImageUrl = "data:image/png;base64," & base64String
    '                End If
    '            End Using
    '        End Using
    '    End Using
    'End Sub


End Class
