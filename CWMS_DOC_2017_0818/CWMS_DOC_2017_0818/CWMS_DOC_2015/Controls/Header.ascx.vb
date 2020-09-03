
Partial Class Controls_Header
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim strComment As String = Session("Comment")
        Dim strUser As String = Session("UserName")

        lblUserName.Text = strUser

        If strUser <> "" Then
            lnkLogin.Text = "登出"
            lnkLogin.NavigateUrl = "~/Login/Login.aspx?lout=Y"
        End If


        If (Not IsPostBack) Then
            Try
                If Left(strComment, 3) = "EPB" And strComment.Length = 4 Then
                    '各環保局承辦
                    CreateADMMenu()
                ElseIf Left(strComment, 3) = "EPA" Then
                    CreateEPAMenu()
                ElseIf Left(strComment, 5) = "ADMIN" Then
                    '各縣市管理者
                    CreateSYSADMMenu()
                ElseIf Left(strComment, 9) = "TOP_ADMIN" Then
                    'SuperAdmin
                    CreateTopADMMenu()
                ElseIf Right(strComment, 6) = "HELPER" Then
                    CreateEPBHELPERMenu()
                ElseIf strComment.Length = 8 Then
                    CreateFacMenu()
                End If

            Catch ex As Exception

            End Try

        End If
    End Sub


    Protected Sub CreateSYSADMMenu()

        'For 各縣市管理者  comment 為  ADMIN_?
        '管理帳號 轉移案件  審查查詢

        ASPxMenu1.Items.Add("帳號管理", "RegUser", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/RegUserN.aspx")

        ASPxMenu1.Items.Add("審查查詢", "QueryExam", "~/Images/menu/ChartsShowLegend_16x16.png")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查結果查詢", "QUERY1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_ExamResult.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查件數查詢", "QUERY1-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamCalc.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查天數查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamDays.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("收執聯歷史資料查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_MailLogHistory.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("歷次審查結果查詢", "QUERY3", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryHistoryExam.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("自動監測(視)、連線、電子看板建置時程查詢", "QUERY4", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryLEDLinkSch.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施製造商、型號占比查詢", "QUERY5", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMaker.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施性能資訊查詢", "QUERY6", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("相對誤差測試查核結果查詢", "QUERY6-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMakerInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("電表資訊查詢", "QUERY7", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryElecMeter.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("攝錄影資訊查詢", "QUERY8", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryVideoINfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("網路資訊查詢", "QUERY9", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryIPInfo.aspx")

        ASPxMenu1.Items.Add("審查中案件轉移", "RegUser", "~/Images/menu/ChartsShowLegend_16x16.png", "~/CaseTransfer.aspx")

    End Sub


    Protected Sub CreateTopADMMenu()

        'For ESTC use
        'ASPxMenu1.Items.Add("TestData", "TestData", "~/Images/menu/ChartsShowLegend_16x16.png", "~/CopyTestData.aspx")
        ASPxMenu1.Items.Add("帳號管理", "RegUser", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/RegUserN.aspx")
        ASPxMenu1.Items.Add("變更密碼", "ChangePassword", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/ChangePasswordSingle.aspx")

        ASPxMenu1.Items.Add("重設使用者密碼", "PassWordReset", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/PasswordRecovery.aspx")

        ASPxMenu1.Items.Add("審查總表-已送未審", "ExamMainEdit", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryCasePhase1.aspx")
        ASPxMenu1.Items.Add("審查總表-審查/補正中", "ExamMainEdit", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryCasePhase2.aspx")
        ASPxMenu1.Items.Add("審查總表-已審查/駁回", "ExamMainEdit", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryCasePhase3.aspx")
        ASPxMenu1.Items.Add("審查查詢", "QueryExam", "~/Images/menu/ChartsShowLegend_16x16.png")
        ASPxMenu1.Items.Add("措施資料管理", "SETEDIT", "~/Images/menu/ChartsShowLegend_16x16.png")
        ASPxMenu1.Items.Add("確認資料管理", "VRYEDIT", "~/Images/menu/ChartsShowLegend_16x16.png")
        ASPxMenu1.Items.Add("流程資料管理", "FLOWEDIT", "~/Images/menu/ChartsShowLegend_16x16.png")
        'ASPxMenu1.Items.Add("審查中案件轉移", "RegUser", "~/Images/menu/ChartsShowLegend_16x16.png", "~/CaseTransfer.aspx")
        'ASPxMenu1.Items.Add("操作手冊(地方主管機關)", "Manual", "~/Images/menu/ChartsShowLegend_16x16.png", "~/地方主管機關端.PDF", "_blank")
        'ASPxMenu1.Items.Add("操作手冊(事業端)", "Manual", "~/Images/menu/ChartsShowLegend_16x16.png", "~/業者及污水下水道系統端.PDF", "_blank")

        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查結果查詢", "QUERY1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_ExamResult.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查件數查詢", "QUERY1-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamCalc.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查天數查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamDays.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("收執聯歷史資料查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_MailLogHistory.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("歷次審查結果查詢", "QUERY3", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryHistoryExam.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("自動監測(視)、連線、電子看板建置時程查詢", "QUERY4", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryLEDLinkSch.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施製造商、型號占比查詢", "QUERY5", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMaker.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施性能資訊查詢", "QUERY6", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("相對誤差測試查核結果查詢", "QUERY6-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMakerInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("電表資訊查詢", "QUERY7", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryElecMeter.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("攝錄影資訊查詢", "QUERY8", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryVideoINfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("網路資訊查詢", "QUERY9", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryIPInfo.aspx")
        'ASPxMenu1.Items.FindByText("審查查詢").Items.Add("相對誤差測試查核結果查詢", "QUERY10", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryElecMeter.aspx")

        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-FACTORY", "SET-FACTORY", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_FACTORY.aspx")
        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-ITEM", "SET-ITEM", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_ITEM.aspx")
        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-SPEC", "SET-SPEC", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_SPEC.aspx")
        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-DAHS", "SET-DAHS", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_DAHS.aspx")
        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-LP", "SET-LP", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_LP.aspx")
        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-LED", "SET-LED", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_LED.aspx")
        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-LINK", "SET-LINK", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_LINK.aspx")
        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-CHECKLIST", "SET-CHECKLIST", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_CHECKLIST.aspx")
        ASPxMenu1.Items.FindByText("措施資料管理").Items.Add("措施資料管理-PDF", "SET-PDF", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_SET_PDF.aspx")

        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-FACTORY", "VRY-FACTORY", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_FACTORY.aspx")
        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-ITEM", "VRY-ITEM", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_ITEM.aspx")
        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-SPEC", "VRY-SPEC", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_SPEC.aspx")
        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-DAHS", "VRY-DAHS", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_DAHS.aspx")
        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-LP", "VRY-LP", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_LP.aspx")
        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-LED", "VRY-LED", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_LED.aspx")
        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-LINK", "VRY-LINK", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_LINK.aspx")
        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-CHECKLIST", "VRY-CHECKLIST", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_CHECKLIST.aspx")
        ASPxMenu1.Items.FindByText("確認資料管理").Items.Add("確認資料管理-PDF", "VRY-PDF", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_VRY_PDF.aspx")

        ASPxMenu1.Items.FindByText("流程資料管理").Items.Add("流程資料管理-EXAMLIST", "EXAMLIST", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_EXAMLIST.aspx")
        ASPxMenu1.Items.FindByText("流程資料管理").Items.Add("流程資料管理-AUDITRESULT", "AUDITRESULT", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_AUDITRESULT.aspx")
        ASPxMenu1.Items.FindByText("流程資料管理").Items.Add("流程資料管理-MODIFY", "MODIFY", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_MODIFY.aspx")
        ASPxMenu1.Items.FindByText("流程資料管理").Items.Add("流程資料管理-MODIFY-PDF", "MODIFY", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/M_Modify_PDF.aspx")


    End Sub

    Protected Sub CreateEPBHELPERMenu()

        '各環保局協審人員
        ASPxMenu1.Items.Add("變更密碼", "ChangePassword", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/ChangePasswordSingle.aspx")

        ASPxMenu1.Items.Add("審查總表", "ExamMainList", "~/Images/menu/ChartsShowLegend_16x16.png", "~/SetAudit.aspx")

        ASPxMenu1.Items.Add("審查查詢", "QueryExam", "~/Images/menu/ChartsShowLegend_16x16.png")
        ASPxMenu1.Items.Add("操作手冊(地方主管機關)", "Manual", "~/Images/menu/ChartsShowLegend_16x16.png", "~/地方主管機關端.PDF", "_blank")
        ASPxMenu1.Items.Add("操作手冊(事業端)", "Manual", "~/Images/menu/ChartsShowLegend_16x16.png", "~/業者及污水下水道系統端.PDF", "_blank")

        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查結果查詢", "QUERY1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_ExamResult.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查件數查詢", "QUERY1-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamCalc.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查天數查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamDays.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("收執聯歷史資料查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_MailLogHistory.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("歷次審查結果查詢", "QUERY3", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryHistoryExam.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("自動監測(視)、連線、電子看板建置時程查詢", "QUERY4", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryLEDLinkSch.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施製造商、型號占比查詢", "QUERY5", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMaker.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施性能資訊查詢", "QUERY6", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("相對誤差測試查核結果查詢", "QUERY6-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMakerInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("電表資訊查詢", "QUERY7", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryElecMeter.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("攝錄影資訊查詢", "QUERY8", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryVideoINfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("網路資訊查詢", "QUERY9", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryIPInfo.aspx")


    End Sub



    Protected Sub CreateADMMenu()

        'Main item
        ASPxMenu1.Items.Add("變更密碼", "ChangePassword", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/ChangePasswordSingle.aspx")
        ASPxMenu1.Items.Add("帳號管理", "RegUser", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/RegUserN.aspx")

        ASPxMenu1.Items.Add("審查總表", "ExamMainList", "~/Images/menu/ChartsShowLegend_16x16.png", "~/SetAudit.aspx")
        ASPxMenu1.Items.Add("審查查詢", "QueryExam", "~/Images/menu/ChartsShowLegend_16x16.png")
        ASPxMenu1.Items.Add("審查中案件轉移", "RegUser", "~/Images/menu/ChartsShowLegend_16x16.png", "~/CaseTransfer.aspx")
        ASPxMenu1.Items.Add("操作手冊(地方主管機關)", "Manual", "~/Images/menu/ChartsShowLegend_16x16.png", "~/地方主管機關端.PDF", "_blank")
        ASPxMenu1.Items.Add("操作手冊(事業端)", "Manual", "~/Images/menu/ChartsShowLegend_16x16.png", "~/業者及污水下水道系統端.PDF", "_blank")

        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查結果查詢", "QUERY1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_ExamResult.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查件數查詢", "QUERY1-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamCalc.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查天數查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamDays.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("收執聯歷史資料查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_MailLogHistory.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("歷次審查結果查詢", "QUERY3", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryHistoryExam.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("自動監測(視)、連線、電子看板建置時程查詢", "QUERY4", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryLEDLinkSch.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施製造商、型號占比查詢", "QUERY5", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMaker.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施性能資訊查詢", "QUERY6", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("相對誤差測試查核結果查詢", "QUERY6-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMakerInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("電表資訊查詢", "QUERY7", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryElecMeter.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("攝錄影資訊查詢", "QUERY8", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryVideoINfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("網路資訊查詢", "QUERY9", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryIPInfo.aspx")

    End Sub

    Protected Sub CreateEPAMenu()

        ASPxMenu1.Items.Add("變更密碼", "ChangePassword", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/ChangePasswordSingle.aspx")

        ASPxMenu1.Items.Add("審查總表-已送未審", "ExamMainEdit", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryCasePhase1.aspx")
        ASPxMenu1.Items.Add("審查總表-審查/補正中", "ExamMainEdit", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryCasePhase2.aspx")
        ASPxMenu1.Items.Add("審查總表-已審查/駁回", "ExamMainEdit", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryCasePhase3.aspx")

        ASPxMenu1.Items.Add("審查查詢", "QueryExam", "~/Images/menu/ChartsShowLegend_16x16.png")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查結果查詢", "QUERY1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_ExamResult.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查件數查詢", "QUERY1-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamCalc.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("審查天數查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryExamDays.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("收執聯歷史資料查詢", "QUERY2", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/Qry_MailLogHistory.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("歷次審查結果查詢", "QUERY3", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryHistoryExam.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("自動監測(視)、連線、電子看板建置時程查詢", "QUERY4", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryLEDLinkSch.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施製造商、型號占比查詢", "QUERY5", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMaker.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("監測設施性能資訊查詢", "QUERY6", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("相對誤差測試查核結果查詢", "QUERY6-1", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryDAHSMakerInfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("電表資訊查詢", "QUERY7", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryElecMeter.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("攝錄影資訊查詢", "QUERY8", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryVideoINfo.aspx")
        ASPxMenu1.Items.FindByText("審查查詢").Items.Add("網路資訊查詢", "QUERY9", "~/Images/menu/ChartsShowLegend_16x16.png", "~/QueryDAHS/QryIPInfo.aspx")

        ASPxMenu1.Items.Add("水系統相關連結", "WebUrlLink", "~/Images/menu/ChartsShowLegend_16x16.png", "~/DocManage/WebUrlLink.aspx")

    End Sub

    Protected Sub CreateFacMenu()

        'Main item

        ASPxMenu1.Items.Add("變更密碼", "ChangePassword", "~/Images/menu/ChartsShowLegend_16x16.png", "~/Login/ChangePasswordSingle.aspx")
        ASPxMenu1.Items.Add("文件總表", "ExamMainList", "~/Images/menu/ChartsShowLegend_16x16.png", "~/MainList.aspx")
        ASPxMenu1.Items.Add("審查中文件查詢", "ExamProgress", "~/Images/menu/ChartsShowLegend_16x16.png", "~/ExamProgress.aspx")
        ASPxMenu1.Items.Add("操作手冊", "Manual", "~/Images/menu/ChartsShowLegend_16x16.png", "~/業者及污水下水道系統端.PDF", "_blank")


        'PasswordRecovery

    End Sub

    'Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut

    '    FormsAuthentication.SignOut()
    '    Session.Clear()
    '    FormsAuthentication.RedirectToLoginPage()

    'End Sub

End Class
