Public Class QryExamCalc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub detailGrid_DataSelect(ByVal sender As Object, ByVal e As EventArgs)

        Dim grid As DevExpress.Web.ASPxGridView = TryCast(sender, DevExpress.Web.ASPxGridView)
        Dim key As Object = grid.GetMasterRowKeyValue()
        Dim currentIndex As Integer = gv_master.FindVisibleIndexByKeyValue(key)
        Dim keyValues As String() = key.ToString().Split("|")
        Dim strEXAM_RESULT As String


        strEXAM_RESULT = Convert.ToString(keyValues(0))
        Session("EXAM_RESULT") = strEXAM_RESULT

    End Sub


    Protected Sub ImgBtn_Excel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtn_Excel.Click


        GridViewExporter.WriteXlsToResponse("Report")

    End Sub


End Class