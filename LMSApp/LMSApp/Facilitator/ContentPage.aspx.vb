Imports System.IO

Public Class ContentPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim contentId As String = Request.QueryString("contentId")

        If Not String.IsNullOrEmpty(contentId) Then
            Dim content As Content = Content.load(Convert.ToInt32(contentId))
            If content IsNot Nothing AndAlso content.file_data IsNot Nothing Then
                ' Determine the file type
                Dim fileName As String = content.title
                Dim fileExtension As String = Path.GetExtension(fileName).ToLower()

                ' Set the appropriate MIME type and render the content
                Select Case fileExtension
                    Case ".pdf"
                        RenderPdf(content)
                    Case ".mp4", ".avi", ".mov", ".wmv"
                        RenderVideo(content, fileExtension)
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

    Private Sub RenderVideo(content As Content, fileExtension As String)
        Dim mimeType As String = GetMimeType(fileExtension)
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

    Private Function GetMimeType(fileExtension As String) As String
        Select Case fileExtension
            Case ".mp4"
                Return "video/mp4"
            Case ".avi"
                Return "video/x-msvideo"
            Case ".mov"
                Return "video/quicktime"
            Case ".wmv"
                Return "video/x-ms-wmv"
            Case Else
                Return "application/octet-stream" ' Fallback MIME type
        End Select
    End Function
End Class


'Public Class ContentPage
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        Dim contentId As String = Request.QueryString("contentId")

'        If Not String.IsNullOrEmpty(contentId) Then
'            Dim content As Content = Content.load(Convert.ToInt32(contentId))
'            If content IsNot Nothing AndAlso content.file_data IsNot Nothing Then
'                ' Render the PDF or file
'                Response.Clear()
'                Response.ContentType = "application/pdf" ' Change the MIME type as per your file type
'                Response.AddHeader("Content-Disposition", "inline; filename=" & content.title & ".pdf") ' Change the file extension if needed
'                Response.BinaryWrite(content.file_data)
'                Response.End()
'            Else
'                ' Handle case when content or file data is not found
'                Response.Write("Content not found or no file data available.")
'            End If
'        Else
'            ' Handle case when contentId is not provided
'            Response.Write("No contentId provided.")
'        End If
'    End Sub

'End Class