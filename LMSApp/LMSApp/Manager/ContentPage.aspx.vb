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

                    Dim iconDiv As New HtmlGenericControl("div")
                    iconDiv.Attributes("class") = "p-2"
                    iconDiv.InnerHtml = $"<i class='far fa-file-alt text-black' style='font-size: 26px;'>{Server.HtmlEncode(contentItem.file_data)}</i>"
                    'newContentDiv.Controls.Add(iconDiv)

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
End Class
