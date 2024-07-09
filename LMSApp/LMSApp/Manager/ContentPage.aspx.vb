Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

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

                    newContentDiv.Controls.Add(fileLinkDiv)

                    '$"<div class=text-muted fs-2 mt-2 mt-md-0'><span class='me-1'>Link:</span><a href='{Server.HtmlEncode(announcement.link)}'>{Server.HtmlEncode(announcement.link)}</a></div>" &

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
                ' Render the PDF or file
                Response.Clear()
                Response.ContentType = "application/pdf" ' Change the MIME type as per your file type
                Response.AddHeader("Content-Disposition", "inline; filename=" & content.title & ".pdf") ' Change the file extension if needed
                Response.BinaryWrite(content.file_data)
                Response.End()
            Else
                ' Handle case when content or file data is not found
                Response.Write("Content not found or no file data available.")
            End If
        End If
    End Sub
End Class
