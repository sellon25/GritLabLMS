Namespace Student
    Public Class Dashboard1
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If (IsPostBack) Then
                '' funtion to load the functions to update number of assignments for student \
                ' getallassements(Session("ID"))
                ' getallincompleteassements(Session("ID"))
                ' getallcomplete(Session("ID")
            End If
        End Sub
    End Class
End Namespace