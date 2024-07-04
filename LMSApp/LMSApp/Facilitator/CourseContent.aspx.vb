Imports System.Data.SqlClient

Public Class CourseContent1
    Inherits System.Web.UI.Page

    Dim courseId As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        courseId = Request.QueryString("courseId")


        If Not IsPostBack Then
            BindContent()
        Else
            BindContent()
        End If

    End Sub

    Private Sub BindContent()
        Dim facilitatorId As String = Session("ID").ToString()
        Dim courseId As String = Request.QueryString("courseId")

        ' Fetch content
        Dim contentList As List(Of Content) = GetContentByCourse(courseId)

        ' Bind content
        For Each content As Content In contentList
            ContentContainer.Controls.Add(CreateContentHtml(content))
        Next
    End Sub

    Private Function CreateContentHtml(content As Content) As HtmlGenericControl
        Dim container As New HtmlGenericControl("div")
        container.Attributes("class") = "content-item d-md-flex white-box boxShadow align-items-center"
        container.Attributes("id") = "ContentItem_" & content.id
        container.Style.Add("justify-content", "space-between")

        Dim link As New HtmlAnchor()
        link.HRef = "ContentPage.aspx?contentId=" & content.id
        link.Attributes("class") = "content-link d-flex align-items-center"

        Dim contentBox As New HtmlGenericControl("div")
        contentBox.Attributes("class") = "textboookarea d-flex align-items-center"

        Dim img As New HtmlGenericControl("img")
        img.Attributes("class") = "content-thumbnail mr-3"
        img.Attributes("src") = GetContentImageUrl(content.thumbnail)
        img.Attributes("style") = "width: 50px; height: 50px;"

        Dim contentDetails As New HtmlGenericControl("div")

        Dim nameLabel As New HtmlGenericControl("h3")
        nameLabel.Attributes("class") = "text-black mb-0"
        nameLabel.InnerText = content.title

        Dim descriptionLabel As New HtmlGenericControl("p")
        descriptionLabel.Attributes("class") = "text-dark mb-0"
        descriptionLabel.InnerText = content.description

        contentDetails.Controls.Add(nameLabel)
        contentDetails.Controls.Add(descriptionLabel)

        contentBox.Controls.Add(img)
        contentBox.Controls.Add(contentDetails)
        link.Controls.Add(contentBox)

        ' Add the link to the container
        container.Controls.Add(link)

        ' Create the delete button
        Dim deleteButton As New Button()
        deleteButton.ID = String.Format("DeleteContent_{0}", content.id)
        deleteButton.Text = "Delete"
        deleteButton.Attributes("class") = "btn btn-danger ml-auto"
        deleteButton.Style.Add("height", "fit-content")
        deleteButton.Attributes("data-content-id") = content.id.ToString()
        AddHandler deleteButton.Click, AddressOf DeleteContent

        ' Add the delete button to the container
        container.Controls.Add(deleteButton)

        Return container
    End Function


    Protected Sub DeleteContent(ByVal sender As Object, ByVal e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)
        Dim contentId As Integer = Convert.ToInt32(button.ID.Replace("DeleteContent_", ""))

        ' Load the content item by ID and delete it
        Dim content As Content = Content.load(contentId)
        If content IsNot Nothing Then
            content.delete()
        End If

        ' Rebind the content list to refresh the display
        Response.Redirect("CourseContent.aspx?courseId=" & courseId)
    End Sub



    Private Function GetContentByCourse(courseId As String) As List(Of Content)
        Dim filter As String = "WHERE course_id = '" & courseId & "'"
        Dim contentList As List(Of Content) = Content.listall(filter)
        Return contentList
    End Function

    Public Function GetContentImageUrl(thumbnail As Object) As String
        If thumbnail IsNot Nothing AndAlso Not Convert.IsDBNull(thumbnail) Then
            Dim bytes As Byte() = DirectCast(thumbnail, Byte())
            Return "data:image/jpeg;base64," & Convert.ToBase64String(bytes)
        End If
        Return "../plugins/images/default-content.jpg" ' Default image URL for content
    End Function


    Protected Sub btnAddContent_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Fetch values from the form
        Dim title As String = newContentTitle.Text.Trim()
        Dim description As String = newContentDescription.Text.Trim()


        Dim thumbnail As Byte() = Nothing
        Dim fileData As Byte() = Nothing

        If newContentThumbnail.HasFile Then
            thumbnail = newContentThumbnail.FileBytes
        End If

        If newContentDocument.HasFile Then
            fileData = newContentDocument.FileBytes
        End If


        ' Create a new instance of Course_Content
        Dim dbOp = New database_operations
        Dim contentList As List(Of Content) = New Content().listallPKOnly()

        Dim newContent As New Content()
        'newContent.id = New database_operations().GetNewPrimaryKey(Of Content)(contentList)
        newContent.course_id = courseId
        newContent.title = title
        newContent.description = description
        newContent.thumbnail = thumbnail
        newContent.file_data = fileData

        ' Insert into database
        Try
            newContent.update() ' This will execute the insert method from Course_Content
            Response.Redirect(Request.Url.AbsoluteUri)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try

        BindContent()
    End Sub

End Class