Imports System.IO
Imports System.Security.Cryptography
Public Class CipherGate
    Shared Function getPassword(ByVal mykey As String) As String
        Return mykey & "igottoomanytoomnine1408"
    End Function

    Shared Function EncryptString(ByVal inputtext As String, ByVal password As String) As String
        password = getPassword(password)

        If inputtext = "" Then Return inputtext
        'We are now going to create an instance of theRihndael class. 
        Dim rijndaelcipher As New RijndaelManaged

        'First we need to turn the input strings into a byte array.
        Dim plaintext() As Byte = System.Text.Encoding.Unicode.GetBytes(inputtext)
        'We are using salt to make it harder to guess our key using a dictionary attack.
        Dim salt() As Byte = Encoding.ASCII.GetBytes(password)
        'The (Secret Key) will be generated from the specified password and salt.
        Dim secretkey As New Rfc2898DeriveBytes(password, salt)
        'Create a encryptor from the existing SecretKey bytes.
        'We use 32 bytes for the secret key.The default Rijndael key length is 256 bit = 32 bytes)
        'then 16 bytes for the IV (initialization vector).The default Rijndael IV length is 128 bit = 16 bytes)
        Dim encryptor As ICryptoTransform = rijndaelcipher.CreateEncryptor(secretkey.GetBytes(32), secretkey.GetBytes(16))
        'Create a MemoryStream that is going to hold the encrypted bytes
        Dim memstream As New MemoryStream()
        'Create a CryptoStream through which we are going to be processing our data.
        'CryptoStreamMode.Write means that we are going to be writing data
        'to the stream and the output will be written in the MemoryStream
        'we have provided. (always use write mode for encryption)
        Dim mycryptostream As New CryptoStream(memstream, encryptor, CryptoStreamMode.Write)
        'Start the encryption process.
        mycryptostream.Write(plaintext, 0, plaintext.Length)
        'Finish encrypting.
        mycryptostream.FlushFinalBlock()
        'Convert our encrypted data from a memoryStream into a byte array.
        Dim cipherbytes() As Byte = memstream.ToArray()
        'Close both streams.
        memstream.Close()
        mycryptostream.Close()
        'Convert encrypted data into a base64-encoded string.
        'A common mistake would be to use an Encoding class for that.
        'It does not work, because not all byte values can be
        'represented by characters. We are going to be using Base64 encoding
        'That is designed exactly for what we are trying to do.
        Dim encrypteddata As String = Convert.ToBase64String(cipherbytes)
        'Return encrypted string.
        Return encrypteddata
    End Function

    Shared Function DecryptString(ByVal inputtext As String, ByVal password As String) As String
        Dim retval As String = ""
        password = getPassword(password)

        Try
            If inputtext = "" Then Return inputtext
            Dim rijndaelcipher As New RijndaelManaged()
            Dim encrypteddata() As Byte = Convert.FromBase64String(inputtext)
            Dim salt() As Byte = Encoding.ASCII.GetBytes(password)
            Dim secretkey As New Rfc2898DeriveBytes(password, salt)
            ' Create a decryptor from the existing SecretKey bytes.
            Dim decryptor As ICryptoTransform = rijndaelcipher.CreateDecryptor(secretkey.GetBytes(32), secretkey.GetBytes(16))
            Dim memStream As New MemoryStream(encrypteddata)
            ' Create a CryptoStream. (always use Read mode for decryption).
            Dim mycryptoStream As New CryptoStream(memStream, decryptor, CryptoStreamMode.Read)
            ' Since at this point we don't know what the size of decrypted data
            ' will be, allocate the buffer long enough to hold EncryptedData;
            ' DecryptedData is never longer than EncryptedData.
            Dim plaintext(encrypteddata.Length) As Byte
            ' Start decrypting.
            Dim decryptedcount As Integer = mycryptoStream.Read(plaintext, 0, plaintext.Length)
            memStream.Close()
            mycryptoStream.Close()
            ' Convert decrypted data into a string.
            Dim DecryptedData As String = Encoding.Unicode.GetString(plaintext, 0, decryptedcount)
            ' Return decrypted string.  
            retval = DecryptedData
        Catch ex As Exception
            retval = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
        End Try
        Return retval
    End Function
End Class
