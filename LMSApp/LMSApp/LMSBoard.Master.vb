Public Class LMSBoard
    Inherits System.Web.UI.MasterPage

    Public username As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        username = Session("User_name")
    End Sub

End Class