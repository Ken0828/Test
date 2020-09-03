Imports DevExpress.Web

Public Class QryExamDays
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub ImgBtn_Excel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtn_Excel.Click


        GridViewExporter.WriteXlsToResponse("Report")

    End Sub

    Protected Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As ASPxGridViewColumnDataEventArgs)

        If e.Column.FieldName = "UpgradeDays" Then

            Try
                Dim strUpgradeDays As Date = CDate(e.GetListSourceFieldValue("DOC_RECDATE"))
                e.Value = (Today.Date - strUpgradeDays).TotalDays

            Catch ex As Exception

            End Try

        End If

        If e.Column.FieldName = "AuditDays" Then

            Try
                Dim strEXAM_DOCOUT_DATE As Date = CDate(e.GetListSourceFieldValue("EXAM_DOCOUT_DATE"))
                Dim strDOC_RECDATE As Date = CDate(e.GetListSourceFieldValue("DOC_RECDATE"))
                e.Value = (strEXAM_DOCOUT_DATE - strDOC_RECDATE).TotalDays

            Catch ex As Exception

            End Try

        End If

        If e.Column.FieldName = "Total" Then

            Try
                Dim price As Date = CDate(e.GetListSourceFieldValue("DOC_RECDATE"))
                e.Value = (Today.Date - price).TotalDays

            Catch ex As Exception

            End Try

        End If

    End Sub

End Class