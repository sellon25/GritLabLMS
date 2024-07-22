
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Public Class ContentPage1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim courseId As String = Request.QueryString("CourseID")
            System.Diagnostics.Debug.WriteLine($"CourseID from QueryString: {courseId}")
            If Not String.IsNullOrEmpty(courseId) Then
                LoadContent(courseId)
            Else
                System.Diagnostics.Debug.WriteLine("CourseID is null or empty.")
            End If
        End If

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

    Private Sub LoadContent(ByVal courseId As String)
        Try
            ' Assume Content.listall(...) retrieves list of Content objects
            Dim courseContentList As List(Of Content) = Content.listall($"WHERE course_id = '{courseId}'")

            If courseContentList IsNot Nothing AndAlso courseContentList.Count > 0 Then
                For Each contentItem As Content In courseContentList
                    Dim newContentDiv As New HtmlGenericControl("div")
                    newContentDiv.Attributes("class") = "d-flex flex-row comment-row p-3 mt-0 white-box boxShadow"

                    Dim fileLinkDiv As New HtmlGenericControl("div")
                    fileLinkDiv.Attributes("class") = "p-2"

                    If contentItem.file_data IsNot Nothing Then
                        If contentItem.file_data.Length > 0 Then
                            ' Determine the MIME type of the content
                            Dim mimeType As String = GetMimeType(contentItem.file_data)

                            If mimeType.StartsWith("video/") Then
                                ' Create a video element for video content
                                Dim videoElement As New HtmlGenericControl("video")
                                videoElement.Attributes("src") = $"ContentPage.aspx?contentId={contentItem.id}"
                                videoElement.Attributes("controls") = "controls"
                                videoElement.Attributes("class") = "video-js vjs-default-skin vjs-big-play-centered"
                                videoElement.Attributes("width") = "640"
                                videoElement.Attributes("height") = "264"
                                videoElement.InnerHtml = $"Your browser does not support the video tag."

                                newContentDiv.Controls.Add(videoElement)
                            ElseIf mimeType = "application/pdf" Then
                                ' Create a link to view the PDF
                                Dim pdfLink As New HyperLink()
                                pdfLink.NavigateUrl = $"ContentPage.aspx?contentId={contentItem.id}"
                                pdfLink.CssClass = "text-black"
                                pdfLink.Text = "View PDF"
                                fileLinkDiv.Controls.Add(pdfLink)
                            ElseIf mimeType.StartsWith("image/") Then
                                ' Create an image element for image content
                                Dim imageElement As New HtmlImage()
                                imageElement.Src = $"data:{mimeType};base64,{Convert.ToBase64String(contentItem.file_data)}"
                                imageElement.Attributes("class") = "img-thumbnail"
                                imageElement.Style.Add("max-width", "200px")
                                fileLinkDiv.Controls.Add(imageElement)
                            Else
                                ' Handle other types of content (e.g., documents)
                                Dim fileLink As New HyperLink()
                                fileLink.NavigateUrl = $"ContentPage.aspx?contentId={contentItem.id}"
                                fileLink.CssClass = "text-black"
                                fileLink.Text = "View File"
                                fileLinkDiv.Controls.Add(fileLink)
                            End If
                        End If
                    End If

                    newContentDiv.Controls.Add(fileLinkDiv)

                    Dim textDiv As New HtmlGenericControl("div")
                    textDiv.Attributes("class") = "comment-text ps-2 ps-md-3 w-100 text-black"
                    textDiv.InnerHtml = $"<h5 class='font-medium'>{Server.HtmlEncode(contentItem.title)}</h5>" &
                                        $"<span class='mb-3 d-block'>{Server.HtmlEncode(contentItem.description)}</span>" &
                                        $"<div class='text-muted fs-2 ms-auto mt-2 mt-md-0'>{contentItem.datetime:MMMM dd, yyyy}</div>"
                    newContentDiv.Controls.Add(textDiv)

                    ' Add newContentDiv to ContentContainer
                    ContentContainer.Controls.Add(newContentDiv)
                Next
            Else
                Dim noContentDiv As New HtmlGenericControl("p")
                noContentDiv.InnerHtml = "No content available."
                ContentContainer.Controls.Add(noContentDiv)
            End If
        Catch ex As Exception
            Dim errorDiv As New HtmlGenericControl("p")
            errorDiv.InnerHtml = "Error loading content."
            ContentContainer.Controls.Add(errorDiv)
        End Try
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

        Dim videoHtml As String = "<div style='display: flex; justify-content: center; align-items: center; height: 100vh;'>
                               <video width='1000' controls>
                                   <source src='" & videoUrl & "' type='" & mimeType & "'>
                                   Your browser does not support the video tag.
                               </video>
                           </div>"

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

    Private Function GetMimeType(ByVal fileData As Byte()) As String
        ' A simple way to determine MIME type based on file header
        ' This function can be extended to handle more file types
        Dim mimeType As String = "application/octet-stream" ' Default binary stream type

        If fileData IsNot Nothing AndAlso fileData.Length > 4 Then
            Dim header As String = BitConverter.ToString(fileData, 0, 4).Replace("-", String.Empty).ToUpperInvariant()
            Select Case header
                Case "25504446"
                    mimeType = "application/pdf"
                Case "000001BA", "000001B3"
                    mimeType = "video/mpeg"
                Case "66747970", "00000020"
                    mimeType = "video/mp4"
                Case "FFD8FF"
                    mimeType = "image/jpeg"
                Case "89504E47"
                    mimeType = "image/png"
                    ' Add more cases for different file types as needed
            End Select
        End If

        Return mimeType
    End Function

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