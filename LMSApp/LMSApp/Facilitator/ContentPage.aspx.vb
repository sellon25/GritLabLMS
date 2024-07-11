Imports System.Data.SqlClient
Imports System.IO

'Public Class ContentPage
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        Dim contentId As String = Request.QueryString("contentId")

'        If Not String.IsNullOrEmpty(contentId) Then
'            Dim content As Content = Content.load(Convert.ToInt32(contentId))
'            If content IsNot Nothing AndAlso content.file_data IsNot Nothing Then
'                ' Determine the file type
'                Dim fileName As String = content.title
'                Dim fileExtension As String = Path.GetExtension(fileName).ToLower()

'                ' Set the appropriate MIME type and render the content
'                Select Case fileExtension
'                    Case ".pdf"
'                        RenderPdf(content)
'                    Case ".mp4", ".avi", ".mov", ".wmv"
'                        RenderVideo(content, fileExtension)
'                    Case Else
'                        Response.Write("Unsupported file type.")
'                End Select
'            Else
'                ' Handle case when content or file data is not found
'                Response.Write("Content not found or no file data available.")
'            End If
'        Else
'            ' Handle case when contentId is not provided
'            Response.Write("No contentId provided.")
'        End If
'    End Sub

'    Private Sub RenderPdf(content As Content)
'        Response.Clear()
'        Response.ContentType = "application/pdf"
'        Response.AddHeader("Content-Disposition", "inline; filename=" & content.title & ".pdf")
'        Response.BinaryWrite(content.file_data)
'        Response.End()
'    End Sub

'    Private Sub RenderVideo(content As Content, fileExtension As String)
'        Dim mimeType As String = GetMimeType(fileExtension)
'        Dim base64Video As String = Convert.ToBase64String(content.file_data)
'        Dim videoUrl As String = "data:" & mimeType & ";base64," & base64Video

'        Dim videoHtml As String = "<video width='600' controls>
'                                    <source src='" & videoUrl & "' type='" & mimeType & "'>
'                                    Your browser does not support the video tag.
'                                   </video>"

'        Response.Clear()
'        Response.ContentType = "text/html"
'        Response.Write(videoHtml)
'        Response.End()
'    End Sub

'    Private Function GetMimeType(fileExtension As String) As String
'        Select Case fileExtension
'            Case ".mp4"
'                Return "video/mp4"
'            Case ".avi"
'                Return "video/x-msvideo"
'            Case ".mov"
'                Return "video/quicktime"
'            Case ".wmv"
'                Return "video/x-ms-wmv"
'            Case Else
'                Return "application/octet-stream" ' Fallback MIME type
'        End Select
'    End Function
'End Class



Public Class ContentPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim contentId As String = Request.QueryString("contentId")

        If Not String.IsNullOrEmpty(contentId) Then
            Dim content As Content = Content.load(Convert.ToInt32(contentId))
            If content IsNot Nothing AndAlso content.file_data IsNot Nothing Then
                ' Determine the file type
                Dim fileType As String = DetermineMediaType(content.file_data)

                ' Set the appropriate MIME type and render the content
                Select Case fileType
                    Case "application/pdf"
                        RenderPdf(content)
                    Case "video/mp4", "video/x-msvideo", "video/quicktime", "video/x-ms-wmv"
                        RenderVideo(content, fileType)
                    Case "image/jpeg", "image/png"
                        RenderImage(content, fileType)
                    Case Else
                        Response.Write("Unsupported file type.")
                End Select
            Else
                ' Handle case when content or file data is not found
                Response.Write("Content not found or no file data available.")
            End If
        Else
            ' Handle case when contentId is not provided
            Response.Write("No contentId provided.")
        End If
    End Sub

    Private Sub RenderPdf(content As Content)
        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("Content-Disposition", "inline; filename=" & content.title & ".pdf")
        Response.BinaryWrite(content.file_data)
        Response.End()
    End Sub

    Private Sub RenderVideo(content As Content, mimeType As String)
        Dim base64Video As String = Convert.ToBase64String(content.file_data)
        Dim videoUrl As String = "data:" & mimeType & ";base64," & base64Video

        Dim videoHtml As String = "<video width='600' controls>
                                    <source src='" & videoUrl & "' type='" & mimeType & "'>
                                    Your browser does not support the video tag.
                                   </video>"

        Response.Clear()
        Response.ContentType = "text/html"
        Response.Write(videoHtml)
        Response.End()
    End Sub

    Private Sub RenderImage(content As Content, mimeType As String)
        Response.Clear()
        Response.ContentType = mimeType
        Response.AddHeader("Content-Disposition", "inline; filename=" & content.title & Path.GetExtension(content.title))
        Response.BinaryWrite(content.file_data)
        Response.End()
    End Sub

    Private Function DetermineMediaType(ByVal fileData As Byte()) As String
        If fileData Is Nothing OrElse fileData.Length < 12 Then
            Return "Unknown"
        End If

        ' Check for PDF (magic number: 25 50 44 46)
        If fileData(0) = &H25 AndAlso fileData(1) = &H50 AndAlso fileData(2) = &H44 AndAlso fileData(3) = &H46 Then
            Return "application/pdf"
        End If

        ' Check for JPEG (magic number: FF D8 FF)
        If fileData(0) = &HFF AndAlso fileData(1) = &HD8 AndAlso fileData(2) = &HFF Then
            Return "image/jpeg"
        End If

        ' Check for PNG (magic number: 89 50 4E 47)
        If fileData(0) = &H89 AndAlso fileData(1) = &H50 AndAlso fileData(2) = &H4E AndAlso fileData(3) = &H47 Then
            Return "image/png"
        End If

        ' Check for MP4 (common magic numbers: 00 00 00 ?? 66 74 79 70 ?? ?? ?? ?? or 00 00 00 ?? 66 74 79 70 69 73 6F 6D)
        If fileData(4) = &H66 AndAlso fileData(5) = &H74 AndAlso fileData(6) = &H79 AndAlso fileData(7) = &H70 Then
            If fileData(8) = &H69 AndAlso fileData(9) = &H73 AndAlso fileData(10) = &H6F AndAlso fileData(11) = &H6D Then
                Return "video/mp4"
            End If
            If fileData(8) = &H6D AndAlso fileData(9) = &H70 AndAlso fileData(10) = &H34 AndAlso fileData(11) = &H32 Then
                Return "video/mp4"
            End If
        End If

        ' Check for AVI (magic number: 52 49 46 46 xx xx xx xx 41 56 49 20)
        If fileData(0) = &H52 AndAlso fileData(1) = &H49 AndAlso fileData(2) = &H46 AndAlso fileData(3) = &H46 AndAlso
           fileData(8) = &H41 AndAlso fileData(9) = &H56 AndAlso fileData(10) = &H49 AndAlso fileData(11) = &H20 Then
            Return "video/x-msvideo"
        End If

        ' Check for MOV (magic number: 00 00 00 14 66 74 79 70 71 74 20 20)
        If fileData(0) = &H0 AndAlso fileData(1) = &H0 AndAlso fileData(2) = &H0 AndAlso fileData(3) = &H14 AndAlso
           fileData(4) = &H66 AndAlso fileData(5) = &H74 AndAlso fileData(6) = &H79 AndAlso fileData(7) = &H70 AndAlso
           fileData(8) = &H71 AndAlso fileData(9) = &H74 AndAlso fileData(10) = &H20 AndAlso fileData(11) = &H20 Then
            Return "video/quicktime"
        End If

        ' Check for WMV (magic number: 30 26 B2 75 8E 66 CF 11 A6 D9 00 AA 00 62 CE 6C)
        If fileData(0) = &H30 AndAlso fileData(1) = &H26 AndAlso fileData(2) = &HB2 AndAlso fileData(3) = &H75 AndAlso
           fileData(4) = &H8E AndAlso fileData(5) = &H66 AndAlso fileData(6) = &HCF AndAlso fileData(7) = &H11 AndAlso
           fileData(8) = &HA6 AndAlso fileData(9) = &HD9 AndAlso fileData(10) = &H0 AndAlso fileData(11) = &HAA AndAlso
           fileData(12) = &H0 AndAlso fileData(13) = &H62 AndAlso fileData(14) = &HCE AndAlso fileData(15) = &H6C Then
            Return "video/x-ms-wmv"
        End If

        ' more checks for other file types as needed

        Return "Unknown"
    End Function
End Class


