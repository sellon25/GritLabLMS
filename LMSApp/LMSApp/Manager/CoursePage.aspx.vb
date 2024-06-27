Namespace Manager
    Public Class CoursePage1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                ' Check if CourseName is provided in query string
                If Not String.IsNullOrEmpty(Request.QueryString("CourseName")) Then
                    Dim courseName As String = Request.QueryString("CourseName")
                    lblCourseName.InnerText = courseName
                Else
                    ' Handle case where CourseName is not provided
                    lblCourseName.InnerText = "Course Details"
                End If
            End If
        End Sub

    End Class



End Namespace
