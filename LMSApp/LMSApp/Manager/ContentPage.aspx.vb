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
                            Else
                                ' Handle other types of content (e.g., PDFs, images, etc.)
                                ' Create a link to view the file with a thumbnail
                                Dim fileLink As New HyperLink()
                                fileLink.NavigateUrl = $"ContentPage.aspx?contentId={contentItem.id}"
                                fileLink.CssClass = "text-black"

                                If contentItem.thumbnail IsNot Nothing Then
                                    ' Create an image control for the thumbnail
                                    Dim thumbnailImage As New HtmlImage()
                                    thumbnailImage.Src = $"data:image/png;base64,{Convert.ToBase64String(contentItem.thumbnail)}"
                                    thumbnailImage.Attributes("class") = "img-thumbnail"
                                    thumbnailImage.Style.Add("max-width", "65px")
                                    fileLink.Controls.Add(thumbnailImage)
                                Else
                                    fileLink.Text = "View File"
                                End If

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

    Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
        MyBase.OnPreRender(e)

        Dim contentId As String = Request.QueryString("contentId")

        If Not String.IsNullOrEmpty(contentId) Then
            Dim content As Content = Content.load(Convert.ToInt32(contentId))
            If content IsNot Nothing AndAlso content.file_data IsNot Nothing Then
                ' Determine the MIME type and handle accordingly
                Dim mimeType As String = GetMimeType(content.file_data)

                If mimeType = "application/pdf" Then
                    ' Render the PDF
                    Response.Clear()
                    Response.ContentType = mimeType
                    Response.AddHeader("Content-Disposition", "inline; filename=" & content.title & ".pdf")
                    Response.BinaryWrite(content.file_data)
                    Response.End()
                ElseIf mimeType.StartsWith("video/") Then
                    ' Render the video
                    ServeVideo(content)
                Else
                    ' Handle other file types if needed
                    Response.Write("Unsupported content type.")
                End If
            Else
                ' Handle case when content or file data is not found
                Response.Write("Content not found or no file data available.")
            End If
        End If
    End Sub

    Private Sub ServeVideo(ByVal content As Content)
        Dim mimeType As String = GetMimeType(content.file_data)
        Response.Clear()
        Response.ContentType = mimeType

        ' Handling the video as a stream
        Dim rangeHeader As String = Request.Headers("Range")
        Dim contentLength As Long = content.file_data.Length
        Dim start As Long = 0
        Dim endPos As Long = contentLength - 1

        If Not String.IsNullOrEmpty(rangeHeader) AndAlso rangeHeader.StartsWith("bytes=") Then
            Dim range As String = rangeHeader.Substring(6)
            Dim rangeParts() As String = range.Split("-"c)
            If rangeParts.Length > 0 AndAlso Not String.IsNullOrEmpty(rangeParts(0)) Then
                start = Long.Parse(rangeParts(0))
            End If
            If rangeParts.Length > 1 AndAlso Not String.IsNullOrEmpty(rangeParts(1)) Then
                endPos = Long.Parse(rangeParts(1))
            End If
            Response.StatusCode = 206 ' Partial Content
            Response.AddHeader("Content-Range", String.Format("bytes {0}-{1}/{2}", start, endPos, contentLength))
        End If

        Response.AddHeader("Content-Disposition", "inline; filename=" & content.title & GetFileExtension(mimeType))
        Response.AddHeader("Content-Length", (endPos - start + 1).ToString())
        Response.BinaryWrite(content.file_data.Skip(start).Take(endPos - start + 1).ToArray())
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
                    ' Add more cases for different file types as needed
            End Select
        End If

        Return mimeType
    End Function

    Private Function GetFileExtension(ByVal mimeType As String) As String
        ' A simple way to get file extension based on MIME type
        Select Case mimeType
            Case "application/pdf"
                Return ".pdf"
            Case "video/mpeg"
                Return ".mpg"
            Case "video/mp4"
                Return ".mp4"
                ' Add more cases for different file types as needed
            Case Else
                Return String.Empty
        End Select
    End Function
End Class
