Public Class AuditHelper
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click


        Server.Transfer("SetDoc.Aspx")

    End Sub


End Class