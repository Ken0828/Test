Imports DevExpress.Web
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Net
Imports System.Net.Mail

Public Class SetAuditAll
    Inherits System.Web.UI.Page

    Protected Function GetOwnerName(ByVal strOwner As String)


        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader

        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  a.username,b.email,b.comment,b.name,b.epb,b.idtype from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where a.username='" + strOwner + "'"
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                strOwner = DatasetOwner.GetString(3)
                Session("UserCName") = DatasetOwner.GetString(3)
                Session("UserEPB") = Right(DatasetOwner.GetString(4), 1)
                Session("IDTYPE") = DatasetOwner.GetString(5)
            End While


        Catch ex As Exception

        End Try

        Return strOwner

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If


        '1. epb epb_helper
        '2. epa
        '3. 督察大隊
        '4. Super User





        Session("UserCName") = GetOwnerName(Session("UserName"))

        Dim strIdtype As String = Session("IDTYPE")

        If strIdtype.Length > 4 Then

            BT_NewCase.Enabled = False

        Else
            BT_NewCase.Enabled = True

        End If

    End Sub

    Protected Sub GridView1_SelectionChanged(sender As Object, e As EventArgs) Handles GV_NEW.SelectionChanged


        Dim strCNO = GV_NEW.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GV_NEW.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GV_NEW.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GV_NEW.GetSelectedFieldValues("REG_DATE")
        Dim strDOCReceiveDATE = GV_NEW.GetSelectedFieldValues("DOC_RECDATE")
        Dim strOwner = GV_NEW.GetSelectedFieldValues("OWNER")
        Dim strFacName = GV_NEW.GetSelectedFieldValues("FAC_NAME")


        If strCNO.Count = 0 Then
            Exit Sub
        End If

        Session("CNO") = strCNO(0).ToString
        Session("DOCTYPE") = strDOCTYPE(0).ToString
        Session("DOCVERSION") = strDOCVERSION(0).ToString
        Session("DOCREGDATE") = strDOCREGDATE(0).ToString
        Session("DOCRECEIVEDATE") = strDOCReceiveDATE(0).ToString
        Session("OWNER") = strOwner(0).ToString
        Session("FAC_NAME") = strFacName(0).ToString



    End Sub

    Protected Sub GridView1_FocusedRowChanged(sender As Object, e As EventArgs) Handles GV_NEW.FocusedRowChanged


        Dim strCNO = GV_NEW.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GV_NEW.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GV_NEW.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GV_NEW.GetSelectedFieldValues("REG_DATE")
        Dim strDOCReceiveDATE = GV_NEW.GetSelectedFieldValues("DOC_RECDATE")
        Dim strOwner = GV_NEW.GetSelectedFieldValues("OWNER")
        Dim strFacName = GV_NEW.GetSelectedFieldValues("FAC_NAME")

        If strCNO.Count = 0 Then
            Exit Sub
        End If

        Session("CNO") = strCNO(0).ToString
        Session("DOCTYPE") = strDOCTYPE(0).ToString
        Session("DOCVERSION") = strDOCVERSION(0).ToString
        Session("DOCREGDATE") = strDOCREGDATE(0).ToString
        Session("DOCRECEIVEDATE") = strDOCReceiveDATE(0).ToString
        Session("OWNER") = strOwner(0).ToString
        Session("FAC_NAME") = strFacName(0).ToString



    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles BT_NewCase.Click

        Dim strDocType As String = Session("DOCTYPE")

        Try
            Server.Transfer("PrepareAudit.aspx")
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub grid_CustomUnboundColumnData(ByVal sender As Object, ByVal e As ASPxGridViewColumnDataEventArgs)
        If e.Column.FieldName = "Total" Then

            Try
                Dim price As Date = CDate(e.GetListSourceFieldValue("DOC_RECDATE"))
                e.Value = (Today.Date - price).TotalDays

            Catch ex As Exception

            End Try

        End If
    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles BT_QryExaming.Click

        Dim strDocType As String = Session("DOCTYPE")

        If strDocType = "措施說明書" Then

            Server.Transfer("SetDoc.aspx")
        ElseIf strDocType = "措施說明書變更申請" Then

            Server.Transfer("PrepareModify.aspx")

        ElseIf strDocType = "確認報告書變更申請" Then

            Server.Transfer("PrepareModify.aspx")

        Else

            Server.Transfer("VryDoc.aspx")
        End If


    End Sub

    Protected Sub GridView2_FocusedRowChanged(sender As Object, e As EventArgs) Handles GV_Examing.FocusedRowChanged

        Dim strCNO = GV_Examing.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GV_Examing.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GV_Examing.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GV_Examing.GetSelectedFieldValues("REG_DATE")
        Dim strOwner = GV_Examing.GetSelectedFieldValues("OWNER")

        If strCNO.Count = 0 Then
            Exit Sub
        End If

        Session("CNO") = strCNO(0).ToString
        Session("DOCTYPE") = strDOCTYPE(0).ToString
        Session("DOCVERSION") = strDOCVERSION(0).ToString
        Session("DOCREGDATE") = strDOCREGDATE(0).ToString
        Session("OWNER") = strOwner(0).ToString
    End Sub

    Protected Sub GridView2_SelectionChanged(sender As Object, e As EventArgs) Handles GV_Examing.SelectionChanged

        Dim strCNO = GV_Examing.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GV_Examing.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GV_Examing.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GV_Examing.GetSelectedFieldValues("REG_DATE")
        Dim strOwner = GV_Examing.GetSelectedFieldValues("OWNER")

        If strCNO.Count = 0 Then
            Exit Sub
        End If

        Session("CNO") = strCNO(0).ToString
        Session("DOCTYPE") = strDOCTYPE(0).ToString
        Session("DOCVERSION") = strDOCVERSION(0).ToString
        Session("DOCREGDATE") = strDOCREGDATE(0).ToString
        Session("OWNER") = strOwner(0).ToString
    End Sub

    Protected Sub ASPxGridView1_FocusedRowChanged(sender As Object, e As EventArgs) Handles GV_ExamComplete.FocusedRowChanged

        Dim strCNO = GV_ExamComplete.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GV_ExamComplete.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GV_ExamComplete.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GV_ExamComplete.GetSelectedFieldValues("REG_DATE")
        Dim strOwner = GV_ExamComplete.GetSelectedFieldValues("OWNER")

        If strCNO.Count = 0 Then
            Exit Sub
        End If

        Session("CNO") = strCNO(0).ToString
        Session("DOCTYPE") = strDOCTYPE(0).ToString
        Session("DOCVERSION") = strDOCVERSION(0).ToString
        Session("DOCREGDATE") = strDOCREGDATE(0).ToString
        Session("OWNER") = strOwner(0).ToString
    End Sub

    Protected Sub ASPxGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles GV_ExamComplete.SelectionChanged

        Dim strCNO = GV_ExamComplete.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GV_ExamComplete.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GV_ExamComplete.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GV_ExamComplete.GetSelectedFieldValues("REG_DATE")
        Dim strOwner = GV_ExamComplete.GetSelectedFieldValues("OWNER")

        If strCNO.Count = 0 Then
            Exit Sub
        End If

        Session("CNO") = strCNO(0).ToString
        Session("DOCTYPE") = strDOCTYPE(0).ToString
        Session("DOCVERSION") = strDOCVERSION(0).ToString
        Session("DOCREGDATE") = strDOCREGDATE(0).ToString
        Session("OWNER") = strOwner(0).ToString
    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles BT_CaseComplete.Click


        Dim strDocType As String = Session("DOCTYPE")


        If strDocType = "措施說明書" Then

            Server.Transfer("SetDoc.aspx")
        ElseIf strDocType = "措施說明書變更申請" Then

            Server.Transfer("PrepareModify.aspx")

        ElseIf strDocType = "確認報告書變更申請" Then

            Server.Transfer("PrepareModify.aspx")

        Else

            Server.Transfer("VryDoc.aspx")
        End If

    End Sub

End Class