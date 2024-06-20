Public Class ApproveCourses
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindCourses()
        End If
    End Sub

    Private Sub BindCourses()
        Try
            Dim courses As List(Of Course) = Course.listall()
            If courses IsNot Nothing AndAlso courses.Count > 0 Then
                Dim courseHtml As New System.Text.StringBuilder()
                For Each course As Course In courses
                    courseHtml.Append("<div class='col-md-3'>")
                    courseHtml.Append("<a href='CoursePage.aspx'>")
                    courseHtml.Append("<div class='white-box boxShadow coursebox'>")
                    courseHtml.Append("<div class='description'>")
                    courseHtml.AppendFormat("<label class='box-title'>{0}</label>", course.name)
                    courseHtml.AppendFormat("<p class='text-muted'>{0}</p>", course.id)
                    courseHtml.Append("</div>")
                    courseHtml.Append("</div>")
                    courseHtml.Append("</a>")
                    courseHtml.Append("</div>")
                Next
                CoursesContainer.InnerHtml = courseHtml.ToString()
            Else
                CoursesContainer.InnerHtml = "<p>No courses available.</p>"
            End If
        Catch ex As Exception
            ' Handle exceptions (e.g., log them)
            CoursesContainer.InnerHtml = "<p>Error loading courses.</p>"
        End Try
    End Sub
End Class

'  Select Case TOP(1000) [id]
'    ,[name ]
'    ,[thumbnail]
'    ,[description]
'    ,[overview ]
'    ,[status]
'    ,[date_started]
'    ,[end_date]
'FROM [GritLabLMS].[dbo].[Course]