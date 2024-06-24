Public Class Announcements
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    ''Public Function getcourseannouncements(course_ID as integer) 
    ''   dim filter as string = "where courses '=" & Session("C_ID") & "   
    ''end sub

    Private Sub GetAnnounments() 'As List(Of Announcement)
        'Getting the ID of the Course Id 
        ''dim query as string = "select "
        Dim announcements As New Announcement
        ''announcements.load()
    End Sub
End Class