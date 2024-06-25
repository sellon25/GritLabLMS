Public Class ContentPage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
        Else
            ' Handle case when contentId is not provided
            Response.Write("No contentId provided.")
        End If
    End Sub

End Class