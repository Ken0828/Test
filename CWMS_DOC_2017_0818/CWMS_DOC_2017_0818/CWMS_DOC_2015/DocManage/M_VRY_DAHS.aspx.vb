Public Class M_VRY_DAHS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If

    End Sub

End Class