
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Private Sub MasterPage_Load(sender As Object, e As EventArgs) Handles Me.Load


        Page.ClientScript.RegisterStartupScript(Me.[GetType](), "onLoad", "DisplaySessionTimeout();", True)

    End Sub
End Class

