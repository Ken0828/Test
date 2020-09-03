Public Class QryDAHSMakerInfo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ImgBtn_Excel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtn_Excel.Click


        GridViewExporter.WriteXlsToResponse("Report")

    End Sub

End Class