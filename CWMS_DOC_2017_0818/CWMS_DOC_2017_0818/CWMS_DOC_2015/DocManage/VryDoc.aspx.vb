Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports DevExpress.Web

Partial Class DocManage_VryDoc
    Inherits System.Web.UI.Page

    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
    Dim MyDOCVersion As Integer = 0

    Protected Sub ASPxRadioButtonList3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_BAS_TYPE.SelectedIndexChanged

        If RBL_BAS_TYPE.SelectedIndex = 0 Then

            RBL_BAS_TYPEB.Enabled = True
            RBL_BAS_TYPEW.SelectedIndex = -1
            RBL_BAS_TYPEW.Enabled = False

        ElseIf RBL_BAS_TYPE.SelectedIndex = 1 Then

            RBL_BAS_TYPEB.SelectedIndex = -1
            RBL_BAS_TYPEB.Enabled = False
            RBL_BAS_TYPEW.Enabled = True

        Else
            RBL_BAS_TYPEB.SelectedIndex = -1
            RBL_BAS_TYPEW.SelectedIndex = -1
            RBL_BAS_TYPEB.Enabled = False
            RBL_BAS_TYPEW.Enabled = False

        End If



    End Sub



    Protected Sub ASPxRadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_SETCHANGE.SelectedIndexChanged


        If RBL_SETCHANGE.SelectedIndex = 0 Then

            GV_SETITEM.Enabled = True
            GV_CHANGEITEM.Enabled = False

        Else
            GV_SETITEM.Enabled = False
            GV_CHANGEITEM.Enabled = True

        End If

    End Sub

    Private Sub FillLINKPLAN()

        Dim TempCno, TempDP_NO, TempDocVersion, TempItem As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")
        TempItem = Session("ITEM")


        Dim Sqlstr As String = "Select * from DOC_SET_LP where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                TB_LP_SETCOMPANY.Text = getresult.returnDataTable.Rows(0).Item("SETCOMPANY").ToString
                TB_LP_SETPEOPLE.Text = getresult.returnDataTable.Rows(0).Item("SETPEOPLE").ToString
                RBL_TRANS_TYPE.SelectedValue = getresult.returnDataTable.Rows(0).Item("TRANSTYPE").ToString
                TB_LP_DATE1.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM1_DATE").ToString)
                TB_LP_DATE2.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM2_DATE").ToString)
                TB_LP_DATE3.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM3_DATE").ToString)
                TB_LP_DATE4.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM4_DATE").ToString)
                RBL_ACTEST_1.SelectedValue = getresult.returnDataTable.Rows(0).Item("LINKTEST_1").ToString
                RBL_ACTEST_2.SelectedValue = getresult.returnDataTable.Rows(0).Item("LINKTEST_2").ToString
                RBL_ACTEST_3.SelectedValue = getresult.returnDataTable.Rows(0).Item("LINKTEST_3").ToString
                RBL_ACTEST_4.SelectedValue = getresult.returnDataTable.Rows(0).Item("LINKTEST_4").ToString
                RBL_ACTEST_5.SelectedValue = getresult.returnDataTable.Rows(0).Item("LINKTEST_5").ToString
                TB_LP_MEMO.Text = getresult.returnDataTable.Rows(0).Item("NOTE").ToString

            End If

        Catch ex As Exception


        End Try

        ASPxPageControl1.ActiveTabIndex = 1


    End Sub

    Private Sub Fillspec()

        Dim TempCno, TempDP_NO, TempDocVersion, TempItem As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")
        TempItem = Session("ITEM")


        Dim Sqlstr As String = "Select * from DOC_VRY_SPEC where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempItem + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                RBL_SPEC_DPNO.Value = getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString
                TB_SPEC_DPNODESP.Text = getresult.returnDataTable.Rows(0).Item("DPNO_DESP").ToString
                RBL_SPEC_DPNOITEM.Value = getresult.returnDataTable.Rows(0).Item("ITEM").ToString
                RBL_SPEC_INSTEAD.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_INSTEAD").ToString
                RBL_SPEC_MONITOROTHER.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MONITOROTHER").ToString
                TB_SPEC_MO_NOTE_DPNO.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MO_NOTE_DPNO").ToString
                TB_SPEC_MO_NOTE_DPNO1.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MO_NOTE_DPNO1").ToString
                TB_SPEC_INS_DATE.Text = CDate(getresult.returnDataTable.Rows(0).Item("SPEC_INS_DATE").ToString)
                TB_SPEC_AGENTNAME.Text = getresult.returnDataTable.Rows(0).Item("SPEC_AGENTNAME").ToString
                TB_SPEC_EQU_MODEL.Text = getresult.returnDataTable.Rows(0).Item("SPEC_EQU_MODEL").ToString
                TB_SPEC_EQU_SERIAL.Text = getresult.returnDataTable.Rows(0).Item("SPEC_EQU_SERIAL").ToString
                TB_SPEC_SAMPLE_METHOD.Text = getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD").ToString
                CB_SPEC_SAMPLE_METHOD_FilterYes.Value = getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERYES").ToString
                CB_SPEC_SAMPLE_METHOD_FilterNo.Value = getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERNO").ToString
                TB_SPEC_CALC_EQU.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_EQU").ToString
                TB_SPEC_CALC_FREQ.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_FREQ").ToString
                RBL_SPEC_CALC_FREQMETHOD.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_METHOD").ToString
                TB_SPEC_MAIN_FREQ.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MAIN_FREQ").ToString
                RBL_SPEC_MAIN_FREQMETHOD.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MAIN_METHOD").ToString
                TB_SPEC_MATERIAL.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MATERIAL").ToString
                RBL_SPEC__WASTELIQUID.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_WASTELIQUID").ToString
                TB_SPEC_MATERIAL_FREQ.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MATERIAL_FREQ").ToString
                TB_SPEC_MEA_SCOPE.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_SCOPE").ToString
                TB_SPEC_MEA_SCOPEUNIT.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_SCOPEUNIT").ToString
                TB_SPEC_MEA_RESTIME.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_RESTIME").ToString
                TB_SPEC_MEA_RESTIMEUNIT.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_RESTIMEUNIT").ToString
                TB_SPEC_MEA_FREQ.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_FREQ").ToString
                TB_SPEC_MEA_FREQUNIT.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_FREQUNIT").ToString
                TB_SPEC_CALCAVG.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALCAVG").ToString
                CB_DOC_Cali.Value = getresult.returnDataTable.Rows(0).Item("SPEC_DOCATTACH_CALI").ToString
                RBL_VIDEO_F.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_F").ToString
                RBL_VIDEO_R.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_R").ToString
                RBL_VIDEO_NV.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_NV").ToString
                TB_SPEC_PLCAGENT.Text = getresult.returnDataTable.Rows(0).Item("SPEC_PLCAGENT").ToString
                RBL_SPEC_COSPEC.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_COSPEC").ToString
                RBL_SPEC_H_CHANGE.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_H_CHANGE").ToString
                TB_SPEC_H_CHANGE_NOTE.Text = getresult.returnDataTable.Rows(0).Item("SPEC_H_CHANGE_NOTE").ToString

            End If

        Catch ex As Exception


        End Try

        ASPxPageControl1.ActiveTabIndex = 1


    End Sub

    Private Sub FillLink()

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_VRY_LINK where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                TB_Link_COVERDPNO.Text = getresult.returnDataTable.Rows(0).Item("DP_NO").ToString
                RBL_Link_Redandant.SelectedValue = getresult.returnDataTable.Rows(0).Item("DAHS_REDAN_FUNC").ToString
                TB_Link_CemsPCCpu.Text = getresult.returnDataTable.Rows(0).Item("CemsPCCpu").ToString
                TB_Link_CemsPCMem.Text = getresult.returnDataTable.Rows(0).Item("CemsPCMem").ToString
                TB_Link_CemsPCHDD.Text = getresult.returnDataTable.Rows(0).Item("CemsPCHDD").ToString
                TB_Link_CemsPCOS.Text = getresult.returnDataTable.Rows(0).Item("CemsPCOS").ToString
                TB_Link_CemsPCNetcard.Text = getresult.returnDataTable.Rows(0).Item("CemsPCNetcard").ToString
                TB_Link_CemsPCAntiVirus.Text = getresult.returnDataTable.Rows(0).Item("CemsPCAntiVirus").ToString
                TB_Link_CemsPCFirewall.Text = getresult.returnDataTable.Rows(0).Item("CemsPCFirewall").ToString
                RBL_Link_NetworkLineType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("NetworkLineType").ToString)
                RBL_Link_NetworkIPType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("NetworkIPType").ToString)
                RBL_Link_MaintainType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("MaintainType").ToString)
                RBL_Link_MonitorCenter.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("MonitorCenter").ToString)


            End If

        Catch ex As Exception


        End Try


    End Sub


    Private Sub FillFactory()

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_VRY_FACTORY where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                RBL_BAS_TYPE.SelectedValue = getresult.returnDataTable.Rows(0).Item(0).ToString
                MYTYPE = getresult.returnDataTable.Rows(0).Item(0).ToString
                If MYTYPE = "事業" Then
                    RBL_BAS_TYPEB.SelectedValue = getresult.returnDataTable.Rows(0).Item("TYPEB").ToString

                Else
                    RBL_BAS_TYPEW.SelectedValue = getresult.returnDataTable.Rows(0).Item("TYPEW").ToString
                End If

                'RBL_BAS_TYPEB.SelectedValue = getresult.returnDataTable.Rows(0).Item("TYPEDESP").ToString
                TB_BAS_REGUNIT.Text = getresult.returnDataTable.Rows(0).Item("REGUNIT").ToString
                TB_BAS_FAC_NAME.Text = getresult.returnDataTable.Rows(0).Item("FAC_NAME").ToString
                TB_BAS_FAC_CNO.Text = getresult.returnDataTable.Rows(0).Item("CNO").ToString
                TB_BAS_FAC_CNAME.Text = getresult.returnDataTable.Rows(0).Item("FAC_CNAME").ToString
                TB_BAS_FAC_CTEL.Text = getresult.returnDataTable.Rows(0).Item("FAC_CTEL").ToString
                TB_BAS_FAC_CMOBILE.Text = getresult.returnDataTable.Rows(0).Item("FAC_CMOBILE").ToString
                TB_BAS_FAC_CFAX.Text = getresult.returnDataTable.Rows(0).Item("FAC_CFAX").ToString
                TB_BAS_FAC_CEMAIL.Text = getresult.returnDataTable.Rows(0).Item("FAC_CEMAIL").ToString
                TB_REGDATE.Text = CDate(getresult.returnDataTable.Rows(0).Item("REG_DATE").ToString)


            End If

        Catch ex As Exception


        End Try


    End Sub


    Protected Sub BT_BASIC_SAVE_Click(sender As Object, e As EventArgs) Handles BT_BASIC_SAVE.Click

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_VRY_FACTORY] ([TYPE], [TYPEB], [TYPEW], [TYPEDESP], [CNO], [DOCVERSION], [REGUNIT], [FAC_NAME], [FAC_CNAME], [FAC_CTEL], [FAC_CMOBILE], [FAC_CFAX], [FAC_CEMAIL], [REG_DATE], [C_ID], [C_DATE]) VALUES (@TYPE, @TYPEB, @TYPEW, @TYPEDESP, @CNO, @DOCVERSION, @REGUNIT, @FAC_NAME, @FAC_CNAME, @FAC_CTEL, @FAC_CMOBILE, @FAC_CFAX, @FAC_CEMAIL, @REG_DATE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_VRY_FACTORY] SET [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP, [REGUNIT] = @REGUNIT, [FAC_NAME] = @FAC_NAME, [FAC_CNAME] = @FAC_CNAME, [FAC_CTEL] = @FAC_CTEL, [FAC_CMOBILE] = @FAC_CMOBILE, [FAC_CFAX] = @FAC_CFAX, [FAC_CEMAIL] = @FAC_CEMAIL, [REG_DATE] = @REG_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_VRY_FACTORY where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try

        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature

                    .InsertParameters.Add("CNo", Session("CNO"))
                    .InsertParameters.Add("DocVersion", "1")
                    .InsertParameters.Add("TYPE", RBL_BAS_TYPE.SelectedItem.Value)
                    If RBL_BAS_TYPE.SelectedItem.Value = "事業" Then
                        .InsertParameters.Add("TYPEB", RBL_BAS_TYPEB.SelectedItem.Value)
                        .InsertParameters.Add("TYPEW", "")
                    Else
                        .InsertParameters.Add("TYPEB", "")
                        .InsertParameters.Add("TYPEW", RBL_BAS_TYPEW.SelectedItem.Value)
                    End If

                    .InsertParameters.Add("TYPEDESP", "")
                    .InsertParameters.Add("REGUNIT", TB_BAS_REGUNIT.Text)
                    .InsertParameters.Add("FAC_NAME", TB_BAS_FAC_NAME.Text)
                    .InsertParameters.Add("FAC_CNAME", TB_BAS_FAC_CNAME.Text)
                    .InsertParameters.Add("FAC_CTEL", TB_BAS_FAC_CTEL.Text)
                    .InsertParameters.Add("FAC_CMOBILE", TB_BAS_FAC_CMOBILE.Text)
                    .InsertParameters.Add("FAC_CFAX", TB_BAS_FAC_CFAX.Text)
                    .InsertParameters.Add("FAC_CEMAIL", TB_BAS_FAC_CEMAIL.Text)
                    .InsertParameters.Add("REG_DATE", TB_REGDATE.Text)
                    .InsertParameters.Add("C_ID", Session("UserName"))
                    .InsertParameters.Add("C_DATE", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        LABEL_BAS.Text = "資料新增失敗!"
                    Else
                        LABEL_BAS.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                LABEL_BAS.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                LABEL_BAS.Text = ex.Message.ToString
            End Try


        Else

            'Update 
            Try

                With SDS_PlanPolFeature

                    .UpdateParameters.Add("CNo", Session("CNO"))
                    .UpdateParameters.Add("DocVersion", "1")
                    .UpdateParameters.Add("TYPE", RBL_BAS_TYPE.SelectedItem.Value)

                    If RBL_BAS_TYPE.SelectedItem.Value = "事業" Then
                        .UpdateParameters.Add("TYPEB", RBL_BAS_TYPEB.SelectedItem.Value)
                        .UpdateParameters.Add("TYPEW", "")
                    Else
                        .UpdateParameters.Add("TYPEB", "")
                        .UpdateParameters.Add("TYPEW", RBL_BAS_TYPEW.SelectedItem.Value)
                    End If

                    .UpdateParameters.Add("TYPEDESP", RBL_BAS_TYPEB.SelectedItem.Value)
                    .UpdateParameters.Add("REGUNIT", TB_BAS_REGUNIT.Text)
                    .UpdateParameters.Add("FAC_NAME", TB_BAS_FAC_NAME.Text)
                    .UpdateParameters.Add("FAC_CNAME", TB_BAS_FAC_CNAME.Text)
                    .UpdateParameters.Add("FAC_CTEL", TB_BAS_FAC_CTEL.Text)
                    .UpdateParameters.Add("FAC_CMOBILE", TB_BAS_FAC_CMOBILE.Text)
                    .UpdateParameters.Add("FAC_CFAX", TB_BAS_FAC_CFAX.Text)
                    .UpdateParameters.Add("FAC_CEMAIL", TB_BAS_FAC_CEMAIL.Text)
                    .UpdateParameters.Add("REG_DATE", TB_REGDATE.Text)
                    .UpdateParameters.Add("U_ID", Session("UserName"))
                    .UpdateParameters.Add("U_Date", Today())
                    .UpdateCommand = UpdateSQL

                    aff_row = .Update()

                    If aff_row = 0 Then
                        LABEL_BAS.Text = "資料更新失敗!"
                    Else
                        LABEL_BAS.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                LABEL_BAS.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                LABEL_BAS.Text = ex.Message.ToString
            End Try

        End If

        SDS_PlanPolFeature.Dispose()


    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load



        If Not IsPostBack Then

            Dim strCityCode = Session("CityCode")
            Dim strComment As String = Session("Comment")
            'Session("CNO") = strComment
            Session("DOCVERSION") = EIPDB.GetDocVersion("VRY", strComment)

            Dim mySecurity As String = ConfigurationManager.ConnectionStrings("CWMS_Security").ConnectionString
            Dim myConnectionString As String = ConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString
            Dim conn As New SqlConnection(myConnectionString)
            conn.Open()

            FillFactory()
            FillLink()
            Fillspec()
            FillLINKPLAN()

            ASPxPageControl1.ActiveTabIndex = 0

        End If



    End Sub

    Protected Sub BT_SPEC_SAVE_Click(sender As Object, e As EventArgs) Handles BT_SPEC_SAVE.Click

        Dim TempCno, TempDP_NO, TempDocVersion, TempITEM As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_VRY_SPEC] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD], [SPEC_MONITOROTHER], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_DPNO2], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_CALI], [SPEC_DOCATTACH_MAIN], [SPEC_DOCATTACH_RATA], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [C_ID], [C_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM, @DPNO_DESP, @SPEC_INSTEAD, @SPEC_MONITOROTHER, @SPEC_MO_NOTE_DPNO, @SPEC_MO_NOTE_DPNO1, @SPEC_MO_NOTE_DPNO2, @SPEC_MO_NOTE_QUA, @SPEC_INS_DATE, @SPEC_AGENTNAME, @SPEC_EQU_MODEL, @SPEC_EQU_SERIAL, @SPEC_SAMPLE_METHOD, @SPEC_SAMPLE_METHOD_FILTERYES, @SPEC_SAMPLE_METHOD_FILTERNO, @SPEC_CALC_EQU, @SPEC_CALC_FREQ, @SPEC_CALC_METHOD, @SPEC_MAIN_FREQ, @SPEC_MAIN_METHOD, @SPEC_MATERIAL, @SPEC_WASTELIQUID, @SPEC_MATERIAL_FREQ, @SPEC_MEA_SCOPE, @SPEC_MEA_SCOPEUNIT, @SPEC_MEA_RESTIME, @SPEC_MEA_RESTIMEUNIT, @SPEC_MEA_FREQ, @SPEC_MEA_FREQUNIT, @SPEC_CALCAVG, @SPEC_DOCATTACH_CALI, @SPEC_DOCATTACH_MAIN, @SPEC_DOCATTACH_RATA, @SPEC_VIDEO_F, @SPEC_VIDEO_F_MEMO, @SPEC_VIDEO_R, @SPEC_VIDEO_R_MEMO, @SPEC_VIDEO_NV, @SPEC_VIDEO_NV_MEMO, @SPEC_ANASIG_YES, @SPEC_ANASIG, @SPEC_DIGSIG_YES, @SPEC_DIGSIG, @SPEC_DO_HARDWARE_CONNECT, @SPEC_DO_HARDWARE_CONNPARA, @SPEC_DO_HARDWARE_DOC, @SPEC_PLCAGENT, @SPEC_COSPEC, @SPEC_H_CHANGE, @SPEC_H_CHANGE_NOTE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_VRY_SPEC] SET [DPNO_DESP] = @DPNO_DESP, [SPEC_INSTEAD] = @SPEC_INSTEAD, [SPEC_MONITOROTHER] = @SPEC_MONITOROTHER, [SPEC_MO_NOTE_DPNO] = @SPEC_MO_NOTE_DPNO, [SPEC_MO_NOTE_DPNO1] = @SPEC_MO_NOTE_DPNO1, [SPEC_MO_NOTE_DPNO2] = @SPEC_MO_NOTE_DPNO2, [SPEC_MO_NOTE_QUA] = @SPEC_MO_NOTE_QUA, [SPEC_INS_DATE] = @SPEC_INS_DATE, [SPEC_AGENTNAME] = @SPEC_AGENTNAME, [SPEC_EQU_MODEL] = @SPEC_EQU_MODEL, [SPEC_EQU_SERIAL] = @SPEC_EQU_SERIAL, [SPEC_SAMPLE_METHOD] = @SPEC_SAMPLE_METHOD, [SPEC_SAMPLE_METHOD_FILTERYES] = @SPEC_SAMPLE_METHOD_FILTERYES, [SPEC_SAMPLE_METHOD_FILTERNO] = @SPEC_SAMPLE_METHOD_FILTERNO, [SPEC_CALC_EQU] = @SPEC_CALC_EQU, [SPEC_CALC_FREQ] = @SPEC_CALC_FREQ, [SPEC_CALC_METHOD] = @SPEC_CALC_METHOD, [SPEC_MAIN_FREQ] = @SPEC_MAIN_FREQ, [SPEC_MAIN_METHOD] = @SPEC_MAIN_METHOD, [SPEC_MATERIAL] = @SPEC_MATERIAL, [SPEC_WASTELIQUID] = @SPEC_WASTELIQUID, [SPEC_MATERIAL_FREQ] = @SPEC_MATERIAL_FREQ, [SPEC_MEA_SCOPE] = @SPEC_MEA_SCOPE, [SPEC_MEA_SCOPEUNIT] = @SPEC_MEA_SCOPEUNIT, [SPEC_MEA_RESTIME] = @SPEC_MEA_RESTIME, [SPEC_MEA_RESTIMEUNIT] = @SPEC_MEA_RESTIMEUNIT, [SPEC_MEA_FREQ] = @SPEC_MEA_FREQ, [SPEC_MEA_FREQUNIT] = @SPEC_MEA_FREQUNIT, [SPEC_CALCAVG] = @SPEC_CALCAVG, [SPEC_DOCATTACH_CALI] = @SPEC_DOCATTACH_CALI, [SPEC_DOCATTACH_MAIN] = @SPEC_DOCATTACH_MAIN, [SPEC_DOCATTACH_RATA] = @SPEC_DOCATTACH_RATA, [SPEC_VIDEO_F] = @SPEC_VIDEO_F, [SPEC_VIDEO_F_MEMO] = @SPEC_VIDEO_F_MEMO, [SPEC_VIDEO_R] = @SPEC_VIDEO_R, [SPEC_VIDEO_R_MEMO] = @SPEC_VIDEO_R_MEMO, [SPEC_VIDEO_NV] = @SPEC_VIDEO_NV, [SPEC_VIDEO_NV_MEMO] = @SPEC_VIDEO_NV_MEMO, [SPEC_ANASIG_YES] = @SPEC_ANASIG_YES, [SPEC_ANASIG] = @SPEC_ANASIG, [SPEC_DIGSIG_YES] = @SPEC_DIGSIG_YES, [SPEC_DIGSIG] = @SPEC_DIGSIG, [SPEC_DO_HARDWARE_CONNECT] = @SPEC_DO_HARDWARE_CONNECT, [SPEC_DO_HARDWARE_CONNPARA] = @SPEC_DO_HARDWARE_CONNPARA, [SPEC_DO_HARDWARE_DOC] = @SPEC_DO_HARDWARE_DOC, [SPEC_PLCAGENT] = @SPEC_PLCAGENT, [SPEC_COSPEC] = @SPEC_COSPEC, [SPEC_H_CHANGE] = @SPEC_H_CHANGE, [SPEC_H_CHANGE_NOTE] = @SPEC_H_CHANGE_NOTE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")
        tempItem = Session("ITEM")

        Dim Sqlstr As String = "Select * from DOC_VRY_SPEC where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempITEM + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try

        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature

                    .InsertParameters.Add("CNo", Session("CNO"))
                    .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    .InsertParameters.Add("DP_NO", TB_SPEC_DPNODESP.Text)
                    .InsertParameters.Add("ITEM", RBL_SPEC_DPNOITEM.SelectedItem.Value)
                    .InsertParameters.Add("DPTYPE", RBL_SPEC_DPNO.SelectedItem.Value)
                    .InsertParameters.Add("DPNO_DESP", TB_SPEC_DPNODESP.Text)
                    .InsertParameters.Add("SPEC_INSTEAD", RBL_SPEC_INSTEAD.SelectedItem.Value)
                    .InsertParameters.Add("SPEC_MONITOROTHER", RBL_SPEC_MONITOROTHER.SelectedItem.Value)
                    .InsertParameters.Add("SPEC_MO_NOTE_DPNO", TB_SPEC_MO_NOTE_DPNO.Text)
                    .InsertParameters.Add("SPEC_MO_NOTE_DPNO1", TB_SPEC_MO_NOTE_DPNO1.Text)
                    .InsertParameters.Add("SPEC_MO_NOTE_QUA", "")
                    .InsertParameters.Add("SPEC_INS_DATE", CDate(TB_SPEC_INS_DATE.Text))
                    .InsertParameters.Add("SPEC_AGENTNAME", TB_SPEC_AGENTNAME.Text)
                    .InsertParameters.Add("SPEC_EQU_MODEL", TB_SPEC_EQU_MODEL.Text)
                    .InsertParameters.Add("SPEC_EQU_SERIAL", TB_SPEC_EQU_SERIAL.Text)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD", TB_SPEC_SAMPLE_METHOD.Text)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD_FILTERYES", CB_SPEC_SAMPLE_METHOD_FilterYes.Checked.ToString)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD_FILTERNO", CB_SPEC_SAMPLE_METHOD_FilterNo.Checked.ToString)
                    .InsertParameters.Add("SPEC_CALC_EQU", TB_SPEC_CALC_EQU.Text)
                    .InsertParameters.Add("SPEC_CALC_FREQ", TB_SPEC_CALC_FREQ.Text)
                    .InsertParameters.Add("SPEC_CALC_METHOD", RBL_SPEC_CALC_FREQMETHOD.Text)
                    .InsertParameters.Add("SPEC_MAIN_FREQ", TB_SPEC_MAIN_FREQ.Text)
                    .InsertParameters.Add("SPEC_MAIN_METHOD", RBL_SPEC_MAIN_FREQMETHOD.Text)
                    .InsertParameters.Add("SPEC_MATERIAL", TB_SPEC_MATERIAL.Text)
                    .InsertParameters.Add("SPEC_WASTELIQUID", RBL_SPEC__WASTELIQUID.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_MATERIAL_FREQ", TB_SPEC_MATERIAL_FREQ.Text)
                    .InsertParameters.Add("SPEC_MEA_SCOPE", TB_SPEC_MEA_SCOPE.Text)
                    .InsertParameters.Add("SPEC_MEA_SCOPEUNIT", TB_SPEC_MEA_SCOPEUNIT.Text)
                    .InsertParameters.Add("SPEC_MEA_RESTIME", TB_SPEC_MEA_RESTIME.Text)
                    .InsertParameters.Add("SPEC_MEA_RESTIMEUNIT", TB_SPEC_MEA_RESTIMEUNIT.Text)
                    .InsertParameters.Add("SPEC_MEA_FREQ", TB_SPEC_MEA_FREQ.Text)
                    .InsertParameters.Add("SPEC_MEA_FREQUNIT", TB_SPEC_MEA_FREQUNIT.Text)
                    .InsertParameters.Add("SPEC_CALCAVG", TB_SPEC_CALCAVG.Text)
                    .InsertParameters.Add("SPEC_DOCATTACH_CALI", CB_DOC_Cali.Checked.ToString)
                    .InsertParameters.Add("SPEC_DOCATTACH_MAIN", CB_DOC_Maintain.Checked.ToString)
                    .InsertParameters.Add("SPEC_DOCATTACH_RATA", CB_DOC_Maintain.Checked.ToString)
                    .InsertParameters.Add("SPEC_VIDEO_F", RBL_VIDEO_F.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_VIDEO_F_MEMO", TB_VIDEO_F.Text)
                    .InsertParameters.Add("SPEC_VIDEO_R", RBL_VIDEO_R.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_VIDEO_R_MEMO", TB_VIDEO_R.Text)
                    .InsertParameters.Add("SPEC_VIDEO_NV", RBL_VIDEO_NV.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_VIDEO_NV_MEMO", TB_VIDEO_NV.Text)
                    .InsertParameters.Add("SPEC_ANASIG_YES", CB_19_Analog.Checked.ToString)
                    .InsertParameters.Add("SPEC_ANASIG", DDL_19_Analog.SelectedValue)
                    .InsertParameters.Add("SPEC_DIGSIG_YES", CB_19_Digital.Checked.ToString)
                    .InsertParameters.Add("SPEC_DIGSIG", TB_19_DIGTAL.Text)
                    .InsertParameters.Add("SPEC_DO_HARDWARE_CONNECT", CB_DO_HARDWARE_CONNECT.Checked.ToString)
                    .InsertParameters.Add("SPEC_DO_HARDWARE_CONNPARA", CB_DO_HARDWARE_CONNPARA.Checked.ToString)
                    .InsertParameters.Add("SPEC_DO_HARDWARE_DOC", CB_DO_HARDWARE_DOC.Checked.ToString)
                    .InsertParameters.Add("SPEC_PLCAGENT", TB_SPEC_PLCAGENT.Text)
                    .InsertParameters.Add("SPEC_COSPEC", RBL_SPEC_COSPEC.SelectedItem.Value)
                    .InsertParameters.Add("SPEC_H_CHANGE", RBL_SPEC_H_CHANGE.SelectedItem.Value)
                    .InsertParameters.Add("SPEC_H_CHANGE_NOTE", TB_SPEC_H_CHANGE_NOTE.Text)
                    .InsertParameters.Add("C_ID", Session("UserName"))
                    .InsertParameters.Add("C_DATE", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        Label_SPEC.Text = "資料新增失敗!"
                    Else
                        Label_SPEC.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_SPEC.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_SPEC.Text = ex.Message.ToString
            End Try


        Else

            'Update 
            Try

                With SDS_PlanPolFeature

                    .UpdateParameters.Add("CNo", Session("CNO"))
                    .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    .UpdateParameters.Add("DP_NO", TB_SPEC_DPNODESP.Text)
                    .UpdateParameters.Add("ITEM", RBL_SPEC_DPNOITEM.SelectedItem.Value)
                    .UpdateParameters.Add("DPTYPE", RBL_SPEC_DPNO.SelectedItem.Value)
                    .UpdateParameters.Add("DPNO_DESP", TB_SPEC_DPNODESP.Text)
                    .UpdateParameters.Add("SPEC_INSTEAD", RBL_SPEC_INSTEAD.SelectedItem.Value)
                    .UpdateParameters.Add("SPEC_MONITOROTHER", RBL_SPEC_MONITOROTHER.SelectedItem.Value)
                    .UpdateParameters.Add("SPEC_MO_NOTE_DPNO", TB_SPEC_MO_NOTE_DPNO.Text)
                    .UpdateParameters.Add("SPEC_MO_NOTE_DPNO1", TB_SPEC_MO_NOTE_DPNO1.Text)
                    .UpdateParameters.Add("SPEC_MO_NOTE_QUA", "")
                    .UpdateParameters.Add("SPEC_INS_DATE", CDate(TB_SPEC_INS_DATE.Text))
                    .UpdateParameters.Add("SPEC_AGENTNAME", TB_SPEC_AGENTNAME.Text)
                    .UpdateParameters.Add("SPEC_EQU_MODEL", TB_SPEC_EQU_MODEL.Text)
                    .UpdateParameters.Add("SPEC_EQU_SERIAL", TB_SPEC_EQU_SERIAL.Text)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD", TB_SPEC_SAMPLE_METHOD.Text)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD_FILTERYES", CB_SPEC_SAMPLE_METHOD_FilterYes.Checked.ToString)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD_FILTERNO", CB_SPEC_SAMPLE_METHOD_FilterNo.Checked.ToString)
                    .UpdateParameters.Add("SPEC_CALC_EQU", TB_SPEC_CALC_EQU.Text)
                    .UpdateParameters.Add("SPEC_CALC_FREQ", TB_SPEC_CALC_FREQ.Text)
                    .UpdateParameters.Add("SPEC_CALC_METHOD", RBL_SPEC_CALC_FREQMETHOD.Text)
                    .UpdateParameters.Add("SPEC_MAIN_FREQ", TB_SPEC_MAIN_FREQ.Text)
                    .UpdateParameters.Add("SPEC_MAIN_METHOD", RBL_SPEC_MAIN_FREQMETHOD.Text)
                    .UpdateParameters.Add("SPEC_MATERIAL", TB_SPEC_MATERIAL.Text)
                    .UpdateParameters.Add("SPEC_WASTELIQUID", RBL_SPEC__WASTELIQUID.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_MATERIAL_FREQ", TB_SPEC_MATERIAL_FREQ.Text)
                    .UpdateParameters.Add("SPEC_MEA_SCOPE", TB_SPEC_MEA_SCOPE.Text)
                    .UpdateParameters.Add("SPEC_MEA_SCOPEUNIT", TB_SPEC_MEA_SCOPEUNIT.Text)
                    .UpdateParameters.Add("SPEC_MEA_RESTIME", TB_SPEC_MEA_RESTIME.Text)
                    .UpdateParameters.Add("SPEC_MEA_RESTIMEUNIT", TB_SPEC_MEA_RESTIMEUNIT.Text)
                    .UpdateParameters.Add("SPEC_MEA_FREQ", TB_SPEC_MEA_FREQ.Text)
                    .UpdateParameters.Add("SPEC_MEA_FREQUNIT", TB_SPEC_MEA_FREQUNIT.Text)
                    .UpdateParameters.Add("SPEC_CALCAVG", TB_SPEC_CALCAVG.Text)
                    .UpdateParameters.Add("SPEC_DOCATTACH_CALI", CB_DOC_Cali.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DOCATTACH_MAIN", CB_DOC_Maintain.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DOCATTACH_RATA", CB_DOC_Maintain.Checked.ToString)
                    .UpdateParameters.Add("SPEC_VIDEO_F", RBL_VIDEO_F.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_VIDEO_F_MEMO", TB_VIDEO_F.Text)
                    .UpdateParameters.Add("SPEC_VIDEO_R", RBL_VIDEO_R.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_VIDEO_R_MEMO", TB_VIDEO_R.Text)
                    .UpdateParameters.Add("SPEC_VIDEO_NV", RBL_VIDEO_NV.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_VIDEO_NV_MEMO", TB_VIDEO_NV.Text)
                    .UpdateParameters.Add("SPEC_ANASIG_YES", CB_19_Analog.Checked.ToString)
                    .UpdateParameters.Add("SPEC_ANASIG", DDL_19_Analog.SelectedValue)
                    .UpdateParameters.Add("SPEC_DIGSIG_YES", CB_19_Digital.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DIGSIG", TB_19_DIGTAL.Text)
                    .UpdateParameters.Add("SPEC_DO_HARDWARE_CONNECT", CB_DO_HARDWARE_CONNECT.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DO_HARDWARE_CONNPARA", CB_DO_HARDWARE_CONNPARA.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DO_HARDWARE_DOC", CB_DO_HARDWARE_DOC.Checked.ToString)
                    .UpdateParameters.Add("SPEC_PLCAGENT", TB_SPEC_PLCAGENT.Text)
                    .UpdateParameters.Add("SPEC_COSPEC", RBL_SPEC_COSPEC.SelectedItem.Value)
                    .UpdateParameters.Add("SPEC_H_CHANGE", RBL_SPEC_H_CHANGE.SelectedItem.Value)
                    .UpdateParameters.Add("SPEC_H_CHANGE_NOTE", TB_SPEC_H_CHANGE_NOTE.Text)
                    .UpdateParameters.Add("U_ID", Session("UserName"))
                    .UpdateParameters.Add("U_Date", Today())
                    .UpdateCommand = UpdateSQL

                    aff_row = .Update()

                    If aff_row = 0 Then
                        Label_SPEC.Text = "資料更新失敗!"
                    Else
                        Label_SPEC.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_SPEC.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_SPEC.Text = ex.Message.ToString
            End Try



        End If

        GV_SPEC.DataBind()
        SDS_PlanPolFeature.Dispose()

    End Sub



    Protected Sub BT_Link_SAVE_Click(sender As Object, e As EventArgs) Handles BT_Link_SAVE.Click


        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_VRY_LINK] ([cNo], [DP_NO], [DocVersion], [UploadMapping], [DAHS_REDAN_FUNC], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [MaintainType], [MonitorCenter], [NOTE1], [NOTE2], [C_ID], [C_DATE]) VALUES (@cNo, @DP_NO, @DocVersion, @UploadMapping, @DAHS_REDAN_FUNC, @CemsPCCpu, @CemsPCMem, @CemsPCHDD, @CemsPCOS, @CemsPCNetcard, @CemsPCAntiVirus, @CemsPCFirewall, @NetworkLineType, @NetworkIPType, @MaintainType, @MonitorCenter, @NOTE1, @NOTE2, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_VRY_LINK] SET [DP_NO] = @DP_NO, [UploadMapping] = @UploadMapping, [DAHS_REDAN_FUNC] = @DAHS_REDAN_FUNC, [CemsPCCpu] = @CemsPCCpu, [CemsPCMem] = @CemsPCMem, [CemsPCHDD] = @CemsPCHDD, [CemsPCOS] = @CemsPCOS, [CemsPCNetcard] = @CemsPCNetcard, [CemsPCAntiVirus] = @CemsPCAntiVirus, [CemsPCFirewall] = @CemsPCFirewall, [NetworkLineType] = @NetworkLineType, [NetworkIPType] = @NetworkIPType, [MaintainType] = @MaintainType, [MonitorCenter] = @MonitorCenter, [NOTE1] = @NOTE1, [NOTE2] = @NOTE2, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_VRY_LINK where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try

        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature

                    .InsertParameters.Add("CNo", Session("CNO"))
                    .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    .InsertParameters.Add("DP_NO", TB_Link_COVERDPNO.Text)
                    .InsertParameters.Add("DAHS_REDAN_FUNC", RBL_Link_Redandant.SelectedValue.ToString)
                    .InsertParameters.Add("CemsPCCpu", TB_Link_CemsPCCpu.Text)
                    .InsertParameters.Add("CemsPCMem", TB_Link_CemsPCMem.Text)
                    .InsertParameters.Add("CemsPCHDD", TB_Link_CemsPCHDD.Text)
                    .InsertParameters.Add("CemsPCOS", TB_Link_CemsPCOS.Text)
                    .InsertParameters.Add("CemsPCNetcard", TB_Link_CemsPCNetcard.Text)
                    .InsertParameters.Add("CemsPCAntiVirus", TB_Link_CemsPCAntiVirus.Text)
                    .InsertParameters.Add("CemsPCFirewall", TB_Link_CemsPCFirewall.Text)
                    .InsertParameters.Add("NetworkLineType", RBL_Link_NetworkLineType.SelectedValue.ToString)
                    .InsertParameters.Add("NetworkIPType", RBL_Link_NetworkIPType.SelectedValue.ToString)
                    .InsertParameters.Add("MaintainType", RBL_Link_MaintainType.SelectedValue.ToString)
                    .InsertParameters.Add("MonitorCenter", RBL_Link_MonitorCenter.SelectedValue.ToString)
                    .InsertParameters.Add("NOTE1", "")
                    .InsertParameters.Add("NOTE2", "")
                    .InsertParameters.Add("C_ID", Session("UserName"))
                    .InsertParameters.Add("C_DATE", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        Label_SetLink.Text = "資料新增失敗!"
                    Else
                        Label_SetLink.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_SetLink.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_SetLink.Text = ex.Message.ToString
            End Try


        Else

            'Update 
            Try

                With SDS_PlanPolFeature

                    .UpdateParameters.Add("CNo", Session("CNO"))
                    .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    .UpdateParameters.Add("DP_NO", TB_Link_COVERDPNO.Text)
                    .UpdateParameters.Add("DAHS_REDAN_FUNC", RBL_Link_Redandant.SelectedValue.ToString)
                    .UpdateParameters.Add("CemsPCCpu", TB_Link_CemsPCCpu.Text)
                    .UpdateParameters.Add("CemsPCMem", TB_Link_CemsPCMem.Text)
                    .UpdateParameters.Add("CemsPCHDD", TB_Link_CemsPCHDD.Text)
                    .UpdateParameters.Add("CemsPCOS", TB_Link_CemsPCOS.Text)
                    .UpdateParameters.Add("CemsPCNetcard", TB_Link_CemsPCNetcard.Text)
                    .UpdateParameters.Add("CemsPCAntiVirus", TB_Link_CemsPCAntiVirus.Text)
                    .UpdateParameters.Add("CemsPCFirewall", TB_Link_CemsPCFirewall.Text)
                    .UpdateParameters.Add("NetworkLineType", RBL_Link_NetworkLineType.SelectedValue.ToString)
                    .UpdateParameters.Add("NetworkIPType", RBL_Link_NetworkIPType.SelectedValue.ToString)
                    .UpdateParameters.Add("MaintainType", RBL_Link_MaintainType.SelectedValue.ToString)
                    .UpdateParameters.Add("MonitorCenter", RBL_Link_MonitorCenter.SelectedValue.ToString)
                    .UpdateParameters.Add("NOTE1", "")
                    .UpdateParameters.Add("NOTE2", "")
                    .UpdateParameters.Add("U_ID", Session("UserName"))
                    .UpdateParameters.Add("U_Date", Today())
                    .UpdateCommand = UpdateSQL

                    aff_row = .Update()

                    If aff_row = 0 Then
                        Label_SetLink.Text = "資料更新失敗!"
                    Else
                        Label_SetLink.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_SetLink.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_SetLink.Text = ex.Message.ToString
            End Try



        End If

        SDS_PlanPolFeature.Dispose()


    End Sub


    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles BT_SETDPNO.Click

        Dim tempcno As String = ""
        Dim tempdpno As String = ""


        Try
            Dim fieldValues As List(Of Object) = GV_SETITEM.GetSelectedFieldValues(New String() {"CNO", "DP_NO"})
            For Each item As Object() In fieldValues
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()

                Session("DP_NO") = tempdpno

            Next item

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GV_SPEC_SelectionChanged(sender As Object, e As EventArgs) Handles GV_SPEC.SelectionChanged


        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempitem As String = ""


        Try
            Dim fieldValues As List(Of Object) = GV_SPEC.GetSelectedFieldValues(New String() {"CNO", "DP_NO", "ITEM"})
            For Each item As Object() In fieldValues
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempitem = item(2).ToString()

                Session("DP_NO") = tempdpno
                Session("ITEM") = tempitem

            Next item

        Catch ex As Exception

        End Try

        'Fillspec()


    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click

        Try
            Fillspec()

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub TB_STD1_TextChanged(sender As Object, e As EventArgs) Handles TB_STD1.TextChanged, TB_CEMS1.TextChanged

        If TB_STD1.Text <> "" And TB_CEMS1.Text <> "" Then
            TB_DIFF1.Text = Math.Abs(Math.Round(Val(TB_STD1.Text) - Val(TB_CEMS1.Text), 2))
        End If

        If TB_STD1.Text = "" Then
            TB_STD1.Focus()
        ElseIf TB_CEMS1.Text = "" Then
            TB_CEMS1.Focus()
        Else
            TB_STD2.Focus()

        End If
    End Sub

    Protected Sub TB_STD2_TextChanged(sender As Object, e As EventArgs) Handles TB_STD2.TextChanged, TB_CEMS2.TextChanged

        If TB_STD2.Text <> "" And TB_CEMS2.Text <> "" Then
            TB_DIFF2.Text = Math.Abs(Math.Round(Val(TB_STD2.Text) - Val(TB_CEMS2.Text), 2))
        End If

        If TB_STD2.Text = "" Then
            TB_STD2.Focus()
        ElseIf TB_CEMS2.Text = "" Then
            TB_CEMS2.Focus()
        Else
            TB_STD3.Focus()

        End If

    End Sub

    Protected Sub TB_STD3_TextChanged(sender As Object, e As EventArgs) Handles TB_STD3.TextChanged, TB_CEMS3.TextChanged

        If TB_STD3.Text <> "" And TB_CEMS3.Text <> "" Then
            TB_DIFF3.Text = Math.Abs(Math.Round(Val(TB_STD3.Text) - Val(TB_CEMS3.Text), 2))
        End If

        If TB_STD3.Text = "" Then
            TB_STD3.Focus()
        ElseIf TB_CEMS3.Text = "" Then
            TB_CEMS3.Focus()
        Else
            TB_STD4.Focus()

        End If
    End Sub

    Protected Sub TB_STD4_TextChanged(sender As Object, e As EventArgs) Handles TB_STD4.TextChanged, TB_CEMS4.TextChanged

        If TB_STD4.Text <> "" And TB_CEMS4.Text <> "" Then
            TB_DIFF4.Text = Math.Abs(Math.Round(Val(TB_STD4.Text) - Val(TB_CEMS4.Text), 2))
        End If

        If TB_STD4.Text = "" Then
            TB_STD4.Focus()
        ElseIf TB_CEMS4.Text = "" Then
            TB_CEMS4.Focus()
        Else
            TB_STD5.Focus()

        End If
    End Sub

    Protected Sub TB_STD5_TextChanged(sender As Object, e As EventArgs) Handles TB_STD5.TextChanged, TB_CEMS5.TextChanged

        If TB_STD5.Text <> "" And TB_CEMS5.Text <> "" Then
            TB_DIFF5.Text = Math.Abs(Math.Round(Val(TB_STD5.Text) - Val(TB_CEMS5.Text), 2))
        End If

        If TB_STD5.Text = "" Then
            TB_STD5.Focus()
        ElseIf TB_CEMS5.Text = "" Then
            TB_CEMS5.Focus()
        Else
            TB_STD6.Focus()

        End If
    End Sub

    Protected Sub TB_STD6_TextChanged(sender As Object, e As EventArgs) Handles TB_STD6.TextChanged, TB_CEMS6.TextChanged

        If TB_STD6.Text <> "" And TB_CEMS6.Text <> "" Then
            TB_DIFF6.Text = Math.Abs(Math.Round(Val(TB_STD6.Text) - Val(TB_CEMS6.Text), 2))
        End If

        If TB_STD6.Text = "" Then
            TB_STD6.Focus()
        ElseIf TB_CEMS6.Text = "" Then
            TB_CEMS6.Focus()
        Else
            TB_STD7.Focus()

        End If
    End Sub

    Protected Sub TB_STD7_TextChanged(sender As Object, e As EventArgs) Handles TB_STD7.TextChanged, TB_CEMS7.TextChanged

        If TB_STD7.Text <> "" And TB_CEMS7.Text <> "" Then
            TB_DIFF7.Text = Math.Abs(Math.Round(Val(TB_STD7.Text) - Val(TB_CEMS7.Text), 2))
        End If

        If TB_STD7.Text = "" Then
            TB_STD7.Focus()
        ElseIf TB_CEMS7.Text = "" Then
            TB_CEMS7.Focus()
        Else
            TB_STD8.Focus()

        End If
    End Sub

    Protected Sub TB_STD8_TextChanged(sender As Object, e As EventArgs) Handles TB_STD8.TextChanged, TB_CEMS8.TextChanged

        If TB_STD8.Text <> "" And TB_CEMS8.Text <> "" Then
            TB_DIFF8.Text = Math.Abs(Math.Round(Val(TB_STD8.Text) - Val(TB_CEMS8.Text), 2))
        End If

        If TB_STD8.Text = "" Then
            TB_STD8.Focus()
        ElseIf TB_CEMS8.Text = "" Then
            TB_CEMS8.Focus()
        Else
            TB_STD9.Focus()

        End If
    End Sub

    Protected Sub TB_STD9_TextChanged(sender As Object, e As EventArgs) Handles TB_STD9.TextChanged, TB_CEMS9.TextChanged

        If TB_STD9.Text <> "" And TB_CEMS9.Text <> "" Then
            TB_DIFF9.Text = Math.Abs(Math.Round(Val(TB_STD9.Text) - Val(TB_CEMS9.Text), 2))
        End If

        If TB_STD9.Text = "" Then
            TB_STD9.Focus()
        ElseIf TB_CEMS9.Text = "" Then
            TB_CEMS9.Focus()
        Else
            TB_STD10.Focus()

        End If
    End Sub

    Protected Sub TB_STD10_TextChanged(sender As Object, e As EventArgs) Handles TB_STD10.TextChanged, TB_CEMS10.TextChanged

        If TB_STD10.Text <> "" And TB_CEMS10.Text <> "" Then
            TB_DIFF10.Text = Math.Abs(Math.Round(Val(TB_STD10.Text) - Val(TB_CEMS10.Text), 2))
        End If

        If TB_STD10.Text = "" Then
            TB_STD10.Focus()
        ElseIf TB_CEMS10.Text = "" Then
            TB_CEMS10.Focus()
        Else
            TB_STD11.Focus()

        End If
    End Sub

    Protected Sub TB_STD11_TextChanged(sender As Object, e As EventArgs) Handles TB_STD11.TextChanged, TB_CEMS11.TextChanged

        If TB_STD11.Text <> "" And TB_CEMS11.Text <> "" Then
            TB_DIFF11.Text = Math.Abs(Math.Round(Val(TB_STD11.Text) - Val(TB_CEMS11.Text), 2))
        End If

        If TB_STD11.Text = "" Then
            TB_STD11.Focus()
        ElseIf TB_CEMS11.Text = "" Then
            TB_CEMS11.Focus()
        Else
            TB_STD12.Focus()

        End If
    End Sub

    Protected Sub TB_STD12_TextChanged(sender As Object, e As EventArgs) Handles TB_STD12.TextChanged, TB_CEMS12.TextChanged

        If TB_STD12.Text <> "" And TB_CEMS12.Text <> "" Then
            TB_DIFF12.Text = Math.Abs(Math.Round(Val(TB_STD12.Text) - Val(TB_CEMS12.Text), 2))
        End If

        If TB_STD12.Text = "" Then
            TB_STD12.Focus()
        ElseIf TB_CEMS12.Text = "" Then
            TB_CEMS12.Focus()
        Else
            TB_STDAVG.Focus()

        End If
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        If RadioButtonList1.SelectedValue.ToString = "9組" Then

            TB_STD10.Enabled = False
            TB_CEMS10.Enabled = False
            TB_DIFF10.Enabled = False
            TB_STD11.Enabled = False
            TB_CEMS11.Enabled = False
            TB_DIFF11.Enabled = False
            TB_STD12.Enabled = False
            TB_CEMS12.Enabled = False
            TB_DIFF12.Enabled = False

        Else

            TB_STD10.Enabled = True
            TB_CEMS10.Enabled = True
            TB_DIFF10.Enabled = True
            TB_STD11.Enabled = True
            TB_CEMS11.Enabled = True
            TB_DIFF11.Enabled = True
            TB_STD12.Enabled = True
            TB_CEMS12.Enabled = True
            TB_DIFF12.Enabled = True

        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Diff9(8) As Double
        Dim Diff12(11) As Double
        Dim Sample9(8) As Double
        Dim Sample12(11) As Double
        Dim StdAvg As Double
        Dim RataAvg As Double
        Dim RataStd As Double
        Dim CC As Double
        Dim Rata As Double

        If RadioButtonList1.SelectedValue.ToString = "9組" Then

            Sample9(0) = CDbl(TB_STD1.Text)
            Sample9(1) = CDbl(TB_STD2.Text)
            Sample9(2) = CDbl(TB_STD3.Text)
            Sample9(3) = CDbl(TB_STD4.Text)
            Sample9(4) = CDbl(TB_STD5.Text)
            Sample9(5) = CDbl(TB_STD6.Text)
            Sample9(6) = CDbl(TB_STD7.Text)
            Sample9(7) = CDbl(TB_STD8.Text)
            Sample9(8) = CDbl(TB_STD9.Text)


            Diff9(0) = CDbl(TB_DIFF1.Text)
            Diff9(1) = CDbl(TB_DIFF2.Text)
            Diff9(2) = CDbl(TB_DIFF3.Text)
            Diff9(3) = CDbl(TB_DIFF4.Text)
            Diff9(4) = CDbl(TB_DIFF5.Text)
            Diff9(5) = CDbl(TB_DIFF6.Text)
            Diff9(6) = CDbl(TB_DIFF7.Text)
            Diff9(7) = CDbl(TB_DIFF8.Text)
            Diff9(8) = CDbl(TB_DIFF9.Text)

            StdAvg = Math.Round(MathLib.AVERAGE(Sample9), 2)
            RataAvg = Math.Round(MathLib.AVERAGE(Diff9), 2)
            RataStd = Math.Round(MathLib.STDEV(Diff9), 2)
            CC = Math.Round(MathLib.CONFIDENCE(2.306, RataStd, 9), 2)
            Rata = Math.Round(((RataAvg + CC) / StdAvg) * 100, 2)

            TB_STDAVG.Text = RataAvg
            TB_STD.Text = RataStd
            TB_TRUST.Text = CC
            TB_RATA.Text = Rata

        Else

            Sample12(0) = CDbl(TB_STD1.Text)
            Sample12(1) = CDbl(TB_STD2.Text)
            Sample12(2) = CDbl(TB_STD3.Text)
            Sample12(3) = CDbl(TB_STD4.Text)
            Sample12(4) = CDbl(TB_STD5.Text)
            Sample12(5) = CDbl(TB_STD6.Text)
            Sample12(6) = CDbl(TB_STD7.Text)
            Sample12(7) = CDbl(TB_STD8.Text)
            Sample12(8) = CDbl(TB_STD9.Text)
            Sample12(9) = CDbl(TB_STD10.Text)
            Sample12(10) = CDbl(TB_STD11.Text)
            Sample12(11) = CDbl(TB_STD12.Text)

            Diff12(0) = CDbl(TB_DIFF1.Text)
            Diff12(1) = CDbl(TB_DIFF2.Text)
            Diff12(2) = CDbl(TB_DIFF3.Text)
            Diff12(3) = CDbl(TB_DIFF4.Text)
            Diff12(4) = CDbl(TB_DIFF5.Text)
            Diff12(5) = CDbl(TB_DIFF6.Text)
            Diff12(6) = CDbl(TB_DIFF7.Text)
            Diff12(7) = CDbl(TB_DIFF8.Text)
            Diff12(8) = CDbl(TB_DIFF9.Text)
            Diff12(9) = CDbl(TB_DIFF10.Text)
            Diff12(10) = CDbl(TB_DIFF11.Text)
            Diff12(11) = CDbl(TB_DIFF12.Text)

            StdAvg = Math.Round(MathLib.AVERAGE(Sample12), 2)
            RataAvg = Math.Round(MathLib.AVERAGE(Diff12), 2)
            RataStd = Math.Round(MathLib.STDEV(Diff12), 2)
            CC = Math.Round(MathLib.CONFIDENCE(2.201, RataStd, 12), 2)
            Rata = Math.Round(((RataAvg + CC) / StdAvg) * 100, 2)

            TB_STDAVG.Text = RataAvg
            TB_STD.Text = RataStd
            TB_TRUST.Text = CC
            TB_RATA.Text = Rata

        End If

    End Sub


    Protected Sub BT_RATA_SAVE_Click(sender As Object, e As EventArgs) Handles BT_RATA_SAVE.Click

        Dim TempCno, TempPolno, TempItem As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        'Dim InsertSQL As String = "INSERT INTO [MRATA] ([CNO], [DP_NO], [ITEM], [MM], [STARTTIME], [ENDTIME], [DATA_1A], [DATA_1B], [DATA_1D], [DATA_2A], [DATA_2B], [DATA_2D], [DATA_3A], [DATA_3B], [DATA_3D], [DATA_4A], [DATA_4B], [DATA_4D], [DATA_5A], [DATA_5B], [DATA_5D], [DATA_6A], [DATA_6B], [DATA_6D], [DATA_7A], [DATA_7B], [DATA_7D], [DATA_8A], [DATA_8B], [DATA_8D], [DATA_9A], [DATA_9B], [DATA_9D], [DATA_10A], [DATA_10B], [DATA_10D], [DATA_11A], [DATA_11B], [DATA_11D], [DATA_12A], [DATA_12B], [DATA_12D], [AVG_A], [AVG_B], [AVG_D], [FACTOR_A], [FACTOR_B], [FACTOR_D], [ACCURACY_A]) VALUES (@CNO, @DP_NO, @ITEM, @MM, @STARTTIME, @ENDTIME, @DATA_1A, @DATA_1B, @DATA_1D, @DATA_2A, @DATA_2B, @DATA_2D, @DATA_3A, @DATA_3B, @DATA_3D, @DATA_4A, @DATA_4B, @DATA_4D, @DATA_5A, @DATA_5B, @DATA_5D, @DATA_6A, @DATA_6B, @DATA_6D, @DATA_7A, @DATA_7B, @DATA_7D, @DATA_8A, @DATA_8B, @DATA_8D, @DATA_9A, @DATA_9B, @DATA_9D, @DATA_10A, @DATA_10B, @DATA_10D, @DATA_11A, @DATA_11B, @DATA_11D, @DATA_12A, @DATA_12B, @DATA_12D, @AVG_A, @AVG_B, @AVG_D, @FACTOR_A, @FACTOR_B, @FACTOR_D, @ACCURACY_A)"
        Dim UpdateSQL As String = "UPDATE [MRATA] SET [STARTTIME] = @STARTTIME, [ENDTIME] = @ENDTIME, [DATA_1A] = @DATA_1A, [DATA_1B] = @DATA_1B, [DATA_1D] = @DATA_1D, [DATA_2A] = @DATA_2A, [DATA_2B] = @DATA_2B, [DATA_2D] = @DATA_2D, [DATA_3A] = @DATA_3A, [DATA_3B] = @DATA_3B, [DATA_3D] = @DATA_3D, [DATA_4A] = @DATA_4A, [DATA_4B] = @DATA_4B, [DATA_4D] = @DATA_4D, [DATA_5A] = @DATA_5A, [DATA_5B] = @DATA_5B, [DATA_5D] = @DATA_5D, [DATA_6A] = @DATA_6A, [DATA_6B] = @DATA_6B, [DATA_6D] = @DATA_6D, [DATA_7A] = @DATA_7A, [DATA_7B] = @DATA_7B, [DATA_7D] = @DATA_7D, [DATA_8A] = @DATA_8A, [DATA_8B] = @DATA_8B, [DATA_8D] = @DATA_8D, [DATA_9A] = @DATA_9A, [DATA_9B] = @DATA_9B, [DATA_9D] = @DATA_9D, [DATA_10A] = @DATA_10A, [DATA_10B] = @DATA_10B, [DATA_10D] = @DATA_10D, [DATA_11A] = @DATA_11A, [DATA_11B] = @DATA_11B, [DATA_11D] = @DATA_11D, [DATA_12A] = @DATA_12A, [DATA_12B] = @DATA_12B, [DATA_12D] = @DATA_12D, [AVG_A] = @AVG_A, [AVG_B] = @AVG_B, [AVG_D] = @AVG_D, [FACTOR_A] = @FACTOR_A, [FACTOR_B] = @FACTOR_B, [FACTOR_D] = @FACTOR_D, [ACCURACY_A] = @ACCURACY_A WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [ITEM] = @ITEM AND [MM] = @MM"
        Dim Stime As String = ""
        Dim Etime As String = ""
        Dim mm As String = ""
        Dim year As String = ""



        Dim SDS_Rata As SqlDataSource = New SqlDataSource
        SDS_Rata.ConnectionString = DBconntext
        TempCno = Session("CNO")
        TempPolno = DDL_RATADPNO.SelectedValue.ToString
        TempItem = DDL_RATAITEM.SelectedValue.ToString

        year = CStr(CInt(DDL_RATAYEAR.SelectedValue.ToString) - 1911)
        Stime = TB_1H_Day_S.Text + DDL_1H_HH_S.SelectedValue.ToString
        Etime = TB_1H_Day_E.Text + DDL_1H_HH_E.SelectedValue.ToString
        mm = Mid(Stime, 5, 2)


        ActionMode = "INSERT"
        Dim Sqlstr As String = "Select * from MRATA where cno='" + TempCno + "' and dp_no='" + TempPolno + "' and item='" + TempItem + "'"

        'Try

        '    getresult = EIPDB.GetData(Sqlstr)

        '    If getresult.ReturnCode >= 1 Then
        '        ActionMode = "EDIT"
        '    Else
        '        ActionMode = "INSERT"
        '    End If

        'Catch ex As Exception


        'End Try

        'Check USER輸入的組數決定INSERT的方式 沒有輸入的組數需補NULL 且不列入計算平均及信賴係數及RATA值

        If RadioButtonList1.SelectedValue.ToString = "9組" Then
            If ActionMode = "INSERT" Then

                Dim InsertSQL As String = "INSERT INTO [MRATA] ([CNO], [DP_NO], [ITEM], [YEAR],[MM], [STARTTIME], [ENDTIME], [DATA_1A], [DATA_1B], [DATA_1D], [DATA_2A], [DATA_2B], [DATA_2D], [DATA_3A], [DATA_3B], [DATA_3D], [DATA_4A], [DATA_4B], [DATA_4D], [DATA_5A], [DATA_5B], [DATA_5D], [DATA_6A], [DATA_6B], [DATA_6D], [DATA_7A], [DATA_7B], [DATA_7D], [DATA_8A], [DATA_8B], [DATA_8D], [DATA_9A], [DATA_9B], [DATA_9D],  [AVG_A], [STD], [FACTOR_A], [ACCURACY_A],[SampleMethod]) VALUES (@CNO, @DP_NO, @ITEM, @YEAR,@MM, @STARTTIME, @ENDTIME, @DATA_1A, @DATA_1B, @DATA_1D, @DATA_2A, @DATA_2B, @DATA_2D, @DATA_3A, @DATA_3B, @DATA_3D, @DATA_4A, @DATA_4B, @DATA_4D, @DATA_5A, @DATA_5B, @DATA_5D, @DATA_6A, @DATA_6B, @DATA_6D, @DATA_7A, @DATA_7B, @DATA_7D, @DATA_8A, @DATA_8B, @DATA_8D, @DATA_9A, @DATA_9B, @DATA_9D,  @AVG_A,@STD,  @FACTOR_A,  @ACCURACY_A,@SampleMethod)"
                Try
                    With SDS_Rata
                        .InsertParameters.Add("CNo", Session("CNO"))
                        .InsertParameters.Add("DP_NO", DDL_RATADPNO.SelectedValue.ToString)
                        .InsertParameters.Add("item", DDL_RATAITEM.SelectedValue.ToString)
                        .InsertParameters.Add("mm", mm)
                        .InsertParameters.Add("YEAR", year)
                        .InsertParameters.Add("STARTTIME", Stime)
                        .InsertParameters.Add("ENDTIME", Etime)
                        .InsertParameters.Add("DATA_1A", CDbl(TB_STD1.Text))
                        .InsertParameters.Add("DATA_2A", CDbl(TB_STD2.Text))
                        .InsertParameters.Add("DATA_3A", CDbl(TB_STD3.Text))
                        .InsertParameters.Add("DATA_4A", CDbl(TB_STD4.Text))
                        .InsertParameters.Add("DATA_5A", CDbl(TB_STD5.Text))
                        .InsertParameters.Add("DATA_6A", CDbl(TB_STD6.Text))
                        .InsertParameters.Add("DATA_7A", CDbl(TB_STD7.Text))
                        .InsertParameters.Add("DATA_8A", CDbl(TB_STD8.Text))
                        .InsertParameters.Add("DATA_9A", CDbl(TB_STD9.Text))
                        .InsertParameters.Add("DATA_1B", CDbl(TB_CEMS1.Text))
                        .InsertParameters.Add("DATA_2B", CDbl(TB_CEMS2.Text))
                        .InsertParameters.Add("DATA_3B", CDbl(TB_CEMS3.Text))
                        .InsertParameters.Add("DATA_4B", CDbl(TB_CEMS4.Text))
                        .InsertParameters.Add("DATA_5B", CDbl(TB_CEMS5.Text))
                        .InsertParameters.Add("DATA_6B", CDbl(TB_CEMS6.Text))
                        .InsertParameters.Add("DATA_7B", CDbl(TB_CEMS7.Text))
                        .InsertParameters.Add("DATA_8B", CDbl(TB_CEMS8.Text))
                        .InsertParameters.Add("DATA_9B", CDbl(TB_CEMS9.Text))
                        .InsertParameters.Add("DATA_1D", CDbl(TB_DIFF1.Text))
                        .InsertParameters.Add("DATA_2D", CDbl(TB_DIFF2.Text))
                        .InsertParameters.Add("DATA_3D", CDbl(TB_DIFF3.Text))
                        .InsertParameters.Add("DATA_4D", CDbl(TB_DIFF4.Text))
                        .InsertParameters.Add("DATA_5D", CDbl(TB_DIFF5.Text))
                        .InsertParameters.Add("DATA_6D", CDbl(TB_DIFF6.Text))
                        .InsertParameters.Add("DATA_7D", CDbl(TB_DIFF7.Text))
                        .InsertParameters.Add("DATA_8D", CDbl(TB_DIFF8.Text))
                        .InsertParameters.Add("DATA_9D", CDbl(TB_DIFF9.Text))
                        .InsertParameters.Add("AVG_A", CDbl(TB_STDAVG.Text))
                        .InsertParameters.Add("STD", CDbl(TB_STD.Text))
                        .InsertParameters.Add("FACTOR_A", CDbl(TB_TRUST.Text))
                        .InsertParameters.Add("ACCURACY_A", CDbl(TB_RATA.Text))
                        .InsertParameters.Add("SampleMethod", DropDownList1.SelectedValue.ToString)
                        .InsertParameters.Add("CreatorID", Session("LoginUserName"))
                        .InsertParameters.Add("CreateDate", Today())
                        .InsertCommand = InsertSQL



                        aff_row = .Insert()

                        If aff_row = 0 Then
                            Label_Rata.Text = "資料新增失敗!"
                        Else
                            Label_Rata.Text = "資料新增成功,請繼續下一步驟!"
                        End If


                    End With
                Catch ex As Exception

                End Try
            Else
                Try
                    With SDS_Rata
                        .UpdateParameters.Add("CNo", Session("CNO"))
                        .UpdateParameters.Add("DP_NO", DDL_RATADPNO.SelectedValue.ToString)
                        .UpdateParameters.Add("item", DDL_RATAITEM.SelectedValue.ToString)
                        .UpdateParameters.Add("mm", mm)
                        .UpdateParameters.Add("year", year)
                        .UpdateParameters.Add("STARTTIME", Stime)
                        .UpdateParameters.Add("ENDTIME", Etime)
                        .UpdateParameters.Add("DATA_1A", CDbl(TB_STD1.Text))
                        .UpdateParameters.Add("DATA_2A", CDbl(TB_STD2.Text))
                        .UpdateParameters.Add("DATA_3A", CDbl(TB_STD3.Text))
                        .UpdateParameters.Add("DATA_4A", CDbl(TB_STD4.Text))
                        .UpdateParameters.Add("DATA_5A", CDbl(TB_STD5.Text))
                        .UpdateParameters.Add("DATA_6A", CDbl(TB_STD6.Text))
                        .UpdateParameters.Add("DATA_7A", CDbl(TB_STD7.Text))
                        .UpdateParameters.Add("DATA_8A", CDbl(TB_STD8.Text))
                        .UpdateParameters.Add("DATA_9A", CDbl(TB_STD9.Text))
                        .UpdateParameters.Add("DATA_1B", CDbl(TB_CEMS1.Text))
                        .UpdateParameters.Add("DATA_2B", CDbl(TB_CEMS2.Text))
                        .UpdateParameters.Add("DATA_3B", CDbl(TB_CEMS3.Text))
                        .UpdateParameters.Add("DATA_4B", CDbl(TB_CEMS4.Text))
                        .UpdateParameters.Add("DATA_5B", CDbl(TB_CEMS5.Text))
                        .UpdateParameters.Add("DATA_6B", CDbl(TB_CEMS6.Text))
                        .UpdateParameters.Add("DATA_7B", CDbl(TB_CEMS7.Text))
                        .UpdateParameters.Add("DATA_8B", CDbl(TB_CEMS8.Text))
                        .UpdateParameters.Add("DATA_9B", CDbl(TB_CEMS9.Text))
                        .UpdateParameters.Add("DATA_1D", CDbl(TB_DIFF1.Text))
                        .UpdateParameters.Add("DATA_2D", CDbl(TB_DIFF2.Text))
                        .UpdateParameters.Add("DATA_3D", CDbl(TB_DIFF3.Text))
                        .UpdateParameters.Add("DATA_4D", CDbl(TB_DIFF4.Text))
                        .UpdateParameters.Add("DATA_5D", CDbl(TB_DIFF5.Text))
                        .UpdateParameters.Add("DATA_6D", CDbl(TB_DIFF6.Text))
                        .UpdateParameters.Add("DATA_7D", CDbl(TB_DIFF7.Text))
                        .UpdateParameters.Add("DATA_8D", CDbl(TB_DIFF8.Text))
                        .UpdateParameters.Add("DATA_9D", CDbl(TB_DIFF9.Text))
                        .UpdateParameters.Add("AVG_A", CDbl(TB_STDAVG.Text))
                        .UpdateParameters.Add("STD", CDbl(TB_STD.Text))
                        .UpdateParameters.Add("FACTOR_A", CDbl(TB_TRUST.Text))
                        .UpdateParameters.Add("ACCURACY_A", CDbl(TB_RATA.Text))
                        .UpdateParameters.Add("SampleMethod", DropDownList1.SelectedValue.ToString)
                        .UpdateParameters.Add("ModifyID", Session("LoginUserName"))
                        .UpdateParameters.Add("ModifyDate", Today())
                        .UpdateCommand = UpdateSQL

                        aff_row = .Update()

                        If aff_row = 0 Then
                            Label_Rata.Text = "資料更新失敗!"
                        Else
                            Label_Rata.Text = "資料更新成功,請繼續下一步驟!"
                        End If


                    End With
                Catch ex As Exception

                End Try
            End If
        Else '12組

            If ActionMode = "INSERT" Then

                Dim InsertSQL As String = "INSERT INTO [MRATA] ([CNO], [DP_NO], [ITEM], [YEAR],[MM], [STARTTIME], [ENDTIME], [DATA_1A], [DATA_1B], [DATA_1D], [DATA_2A], [DATA_2B], [DATA_2D], [DATA_3A], [DATA_3B], [DATA_3D], [DATA_4A], [DATA_4B], [DATA_4D], [DATA_5A], [DATA_5B], [DATA_5D], [DATA_6A], [DATA_6B], [DATA_6D], [DATA_7A], [DATA_7B], [DATA_7D], [DATA_8A], [DATA_8B], [DATA_8D], [DATA_9A], [DATA_9B], [DATA_9D], [DATA_10A], [DATA_10B], [DATA_10D], [DATA_11A], [DATA_11B], [DATA_11D], [DATA_12A], [DATA_12B], [DATA_12D], [AVG_A], [STD], [FACTOR_A], [ACCURACY_A],[SampleMethod]) VALUES (@CNO, @DP_NO, @ITEM, @YEAR,@MM, @STARTTIME, @ENDTIME, @DATA_1A, @DATA_1B, @DATA_1D, @DATA_2A, @DATA_2B, @DATA_2D, @DATA_3A, @DATA_3B, @DATA_3D, @DATA_4A, @DATA_4B, @DATA_4D, @DATA_5A, @DATA_5B, @DATA_5D, @DATA_6A, @DATA_6B, @DATA_6D, @DATA_7A, @DATA_7B, @DATA_7D, @DATA_8A, @DATA_8B, @DATA_8D, @DATA_9A, @DATA_9B, @DATA_9D, @DATA_10A, @DATA_10B, @DATA_10D, @DATA_11A, @DATA_11B, @DATA_11D, @DATA_12A, @DATA_12B, @DATA_12D, @AVG_A,@STD,  @FACTOR_D, @ACCURACY_A,@SampleMethod)"
                Try
                    With SDS_Rata
                        .InsertParameters.Add("CNo", Session("CNO"))
                        .InsertParameters.Add("Polno", DDL_RATADPNO.SelectedValue.ToString)
                        .InsertParameters.Add("item", DDL_RATAITEM.SelectedValue.ToString)
                        .InsertParameters.Add("mm", mm)
                        .InsertParameters.Add("year", year)
                        .InsertParameters.Add("DATA_1A", CDbl(TB_STD1.Text))
                        .InsertParameters.Add("DATA_2A", CDbl(TB_STD2.Text))
                        .InsertParameters.Add("DATA_3A", CDbl(TB_STD3.Text))
                        .InsertParameters.Add("DATA_4A", CDbl(TB_STD4.Text))
                        .InsertParameters.Add("DATA_5A", CDbl(TB_STD5.Text))
                        .InsertParameters.Add("DATA_6A", CDbl(TB_STD6.Text))
                        .InsertParameters.Add("DATA_7A", CDbl(TB_STD7.Text))
                        .InsertParameters.Add("DATA_8A", CDbl(TB_STD8.Text))
                        .InsertParameters.Add("DATA_9A", CDbl(TB_STD9.Text))
                        .InsertParameters.Add("DATA_10A", CDbl(TB_STD10.Text))
                        .InsertParameters.Add("DATA_11A", CDbl(TB_STD11.Text))
                        .InsertParameters.Add("DATA_12A", CDbl(TB_STD12.Text))
                        .InsertParameters.Add("DATA_1B", CDbl(TB_CEMS1.Text))
                        .InsertParameters.Add("DATA_2B", CDbl(TB_CEMS2.Text))
                        .InsertParameters.Add("DATA_3B", CDbl(TB_CEMS3.Text))
                        .InsertParameters.Add("DATA_4B", CDbl(TB_CEMS4.Text))
                        .InsertParameters.Add("DATA_5B", CDbl(TB_CEMS5.Text))
                        .InsertParameters.Add("DATA_6B", CDbl(TB_CEMS6.Text))
                        .InsertParameters.Add("DATA_7B", CDbl(TB_CEMS7.Text))
                        .InsertParameters.Add("DATA_8B", CDbl(TB_CEMS8.Text))
                        .InsertParameters.Add("DATA_9B", CDbl(TB_CEMS9.Text))
                        .InsertParameters.Add("DATA_10B", CDbl(TB_CEMS10.Text))
                        .InsertParameters.Add("DATA_11B", CDbl(TB_CEMS11.Text))
                        .InsertParameters.Add("DATA_12B", CDbl(TB_CEMS12.Text))
                        .InsertParameters.Add("DATA_1D", CDbl(TB_DIFF1.Text))
                        .InsertParameters.Add("DATA_2D", CDbl(TB_DIFF2.Text))
                        .InsertParameters.Add("DATA_3D", CDbl(TB_DIFF3.Text))
                        .InsertParameters.Add("DATA_4D", CDbl(TB_DIFF4.Text))
                        .InsertParameters.Add("DATA_5D", CDbl(TB_DIFF5.Text))
                        .InsertParameters.Add("DATA_6D", CDbl(TB_DIFF6.Text))
                        .InsertParameters.Add("DATA_7D", CDbl(TB_DIFF7.Text))
                        .InsertParameters.Add("DATA_8D", CDbl(TB_DIFF8.Text))
                        .InsertParameters.Add("DATA_9D", CDbl(TB_DIFF9.Text))
                        .InsertParameters.Add("DATA_10D", CDbl(TB_DIFF10.Text))
                        .InsertParameters.Add("DATA_11D", CDbl(TB_DIFF11.Text))
                        .InsertParameters.Add("DATA_12D", CDbl(TB_DIFF12.Text))
                        .InsertParameters.Add("AVG_A", CDbl(TB_STDAVG.Text))
                        .InsertParameters.Add("STD", CDbl(TB_STD.Text))
                        .InsertParameters.Add("FACTOR_A", CDbl(TB_TRUST.Text))
                        .InsertParameters.Add("ACCURACY_A", CDbl(TB_RATA.Text))
                        .InsertParameters.Add("SampleMethod", DropDownList1.SelectedValue.ToString)
                        .InsertParameters.Add("CreatorID", Session("LoginUserName"))
                        .InsertParameters.Add("CreateDate", Today())
                        .InsertCommand = InsertSQL

                        aff_row = .Insert()

                        If aff_row = 0 Then
                            Label_Rata.Text = "資料新增失敗!"
                        Else
                            Label_Rata.Text = "資料新增成功,請繼續下一步驟!"
                        End If


                    End With
                Catch ex As Exception

                End Try
            Else
                Try
                    With SDS_Rata
                        .UpdateParameters.Add("CNo", Session("CNO"))
                        .UpdateParameters.Add("Polno", DDL_RATADPNO.SelectedValue.ToString)
                        .UpdateParameters.Add("item", DDL_RATAITEM.SelectedValue.ToString)
                        .UpdateParameters.Add("mm", mm)
                        .UpdateParameters.Add("year", year)
                        .UpdateParameters.Add("DATA_1A", CDbl(TB_STD1.Text))
                        .UpdateParameters.Add("DATA_2A", CDbl(TB_STD2.Text))
                        .UpdateParameters.Add("DATA_3A", CDbl(TB_STD3.Text))
                        .UpdateParameters.Add("DATA_4A", CDbl(TB_STD4.Text))
                        .UpdateParameters.Add("DATA_5A", CDbl(TB_STD5.Text))
                        .UpdateParameters.Add("DATA_6A", CDbl(TB_STD6.Text))
                        .UpdateParameters.Add("DATA_7A", CDbl(TB_STD7.Text))
                        .UpdateParameters.Add("DATA_8A", CDbl(TB_STD8.Text))
                        .UpdateParameters.Add("DATA_9A", CDbl(TB_STD9.Text))
                        .UpdateParameters.Add("DATA_10A", CDbl(TB_STD10.Text))
                        .UpdateParameters.Add("DATA_11A", CDbl(TB_STD11.Text))
                        .UpdateParameters.Add("DATA_12A", CDbl(TB_STD12.Text))
                        .UpdateParameters.Add("DATA_1B", CDbl(TB_CEMS1.Text))
                        .UpdateParameters.Add("DATA_2B", CDbl(TB_CEMS2.Text))
                        .UpdateParameters.Add("DATA_3B", CDbl(TB_CEMS3.Text))
                        .UpdateParameters.Add("DATA_4B", CDbl(TB_CEMS4.Text))
                        .UpdateParameters.Add("DATA_5B", CDbl(TB_CEMS5.Text))
                        .UpdateParameters.Add("DATA_6B", CDbl(TB_CEMS6.Text))
                        .UpdateParameters.Add("DATA_7B", CDbl(TB_CEMS7.Text))
                        .UpdateParameters.Add("DATA_8B", CDbl(TB_CEMS8.Text))
                        .UpdateParameters.Add("DATA_9B", CDbl(TB_CEMS9.Text))
                        .UpdateParameters.Add("DATA_10B", CDbl(TB_CEMS10.Text))
                        .UpdateParameters.Add("DATA_11B", CDbl(TB_CEMS11.Text))
                        .UpdateParameters.Add("DATA_12B", CDbl(TB_CEMS12.Text))
                        .UpdateParameters.Add("DATA_1D", CDbl(TB_DIFF1.Text))
                        .UpdateParameters.Add("DATA_2D", CDbl(TB_DIFF2.Text))
                        .UpdateParameters.Add("DATA_3D", CDbl(TB_DIFF3.Text))
                        .UpdateParameters.Add("DATA_4D", CDbl(TB_DIFF4.Text))
                        .UpdateParameters.Add("DATA_5D", CDbl(TB_DIFF5.Text))
                        .UpdateParameters.Add("DATA_6D", CDbl(TB_DIFF6.Text))
                        .UpdateParameters.Add("DATA_7D", CDbl(TB_DIFF7.Text))
                        .UpdateParameters.Add("DATA_8D", CDbl(TB_DIFF8.Text))
                        .UpdateParameters.Add("DATA_9D", CDbl(TB_DIFF9.Text))
                        .UpdateParameters.Add("DATA_10D", CDbl(TB_DIFF10.Text))
                        .UpdateParameters.Add("DATA_11D", CDbl(TB_DIFF11.Text))
                        .UpdateParameters.Add("DATA_12D", CDbl(TB_DIFF12.Text))
                        .UpdateParameters.Add("AVG_A", CDbl(TB_STDAVG.Text))
                        .UpdateParameters.Add("STD", CDbl(TB_STD.Text))
                        .UpdateParameters.Add("FACTOR_A", CDbl(TB_TRUST.Text))
                        .UpdateParameters.Add("ACCURACY_A", CDbl(TB_RATA.Text))
                        .UpdateParameters.Add("SampleMethod", DropDownList1.SelectedValue.ToString)
                        .UpdateParameters.Add("ModifyID", Session("LoginUserName"))
                        .UpdateParameters.Add("ModifyDate", Today())
                        .UpdateCommand = UpdateSQL

                        aff_row = .Update()

                        If aff_row = 0 Then
                            Label_Rata.Text = "資料更新失敗!"
                        Else
                            Label_Rata.Text = "資料更新成功,請繼續下一步驟!"
                        End If


                    End With
                Catch ex As Exception

                End Try
            End If
        End If
        SDS_Rata.SelectCommand = "SELECT * FROM [MRATA] WHERE ([CNO]='" + Session("CNO") + "'"
        SDS_Rata.DeleteCommand = "DELETE FROM [MRATA] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [ITEM] = @ITEM AND [MM] = @MM"
        SDS_Rata.DeleteParameters.Add("CNO", DbType.String)
        SDS_Rata.DeleteParameters.Add("DP_NO", DbType.String)
        SDS_Rata.DeleteParameters.Add("ITEM", DbType.String)
        SDS_Rata.DeleteParameters.Add("MM", DbType.String)

        SDS_Rata.DataBind()
        GV_RATA.DataBind()

    End Sub

    Protected Sub BT_RATA_CAN_Click(sender As Object, e As EventArgs) Handles BT_RATA_CAN.Click

        For i As Integer = 0 To Panel1.Controls.Count - 1

            If Panel1.Controls(i).GetType.ToString = "System.Web.UI.WebControls.TextBox" Then
                Dim obj As TextBox = CType(Panel1.Controls(i), TextBox)
                obj.Text = Nothing
            End If
        Next

        TB_STDAVG.Text = Nothing
        TB_STD.Text = Nothing
        TB_TRUST.Text = Nothing
        TB_RATA.Text = Nothing

    End Sub

    Private Sub File2SqlBlob(ByVal SourceFilePath As String, ByVal SourceFileName As String, ByVal PdfIndex As String, ByVal MyDocVersion As String)

        'Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CEMS_EQUConnectionString").ConnectionString.ToString

        Dim cn As New SqlConnection(DBconntext)
        'Dim cmd As New SqlCommand("UPDATE PolUPloadDoc SET pdffile=@pdffile WHERE PFTFacNo='E5600841' and PolNo='P001' and docindex='1'", cn)
        Dim cmd As New SqlCommand("INSERT INTO DOC_VRY_PDFUPload (CNo,DP_NO,DocIndex,DocVersion,DocNumber,path,filename,pdffile,CreatorID,CreateDate) VALUES (@CNo,@DP_NO,@DocIndex,@DocVersion,@DocNumber,@path,@filename,@pdffile,@CreatorID,@CreateDate) ", cn)
        Dim fs As New System.IO.FileStream(SourceFilePath & SourceFileName, IO.FileMode.Open, IO.FileAccess.Read)
        Dim b(fs.Length() - 1) As Byte
        fs.Read(b, 0, b.Length)
        fs.Close()
        Dim CNO As New SqlParameter("@CNo", SqlDbType.NVarChar, 8, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
        Dim DP_NO As New SqlParameter("@DP_NO", SqlDbType.NVarChar, 4, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("DP_NO"))
        Dim DocIndex As New SqlParameter("@DocIndex", SqlDbType.NVarChar, 20, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, PdfIndex)
        Dim DocVersion As New SqlParameter("@DocVersion", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyDocVersion)
        Dim DocNumber As New SqlParameter("@DocNumber", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, "1")
        Dim path As New SqlParameter("@path", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, SourceFilePath)
        Dim filename As New SqlParameter("@filename", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, SourceFileName)
        Dim P As New SqlParameter("@pdffile", SqlDbType.Image, b.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, b)
        Dim CreatorID As New SqlParameter("@CreatorID", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("UserName"))
        Dim CreateTime As New SqlParameter("@CreateDate", SqlDbType.DateTime, 20, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Today())


        cmd.Parameters.Add(CNO)
        cmd.Parameters.Add(DP_NO)
        cmd.Parameters.Add(DocIndex)
        cmd.Parameters.Add(DocVersion)
        cmd.Parameters.Add(DocNumber)
        cmd.Parameters.Add(path)
        cmd.Parameters.Add(filename)
        cmd.Parameters.Add(P)
        cmd.Parameters.Add(CreatorID)
        cmd.Parameters.Add(CreateTime)

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Public Function Upload(ByVal myFileUpload As DevExpress.Web.ASPxUploadControl) As Boolean
        '取得網站根目錄路徑
        Dim path As String = HttpContext.Current.Request.MapPath("~/pdfupload/VRY/")
        Dim docindex As String
        Dim SavePDFFilName As String
        Dim TempDocVersion As String = Session("DOCVERSION")
        docindex = 0
        '檢查是否有檔案
        If (myFileUpload.HasFile) Then
            Try
                '儲存檔案到磁碟
                'If Right(myFileUpload.ClientID, 11) = "FileUpload1" Then
                'docindex = "1"
                'End If
                Select Case myFileUpload.ID
                    Case "AUC_1"
                        docindex = "AUC_1"
                    Case "AUC_2"
                        docindex = "AUC_2"
                    Case "AUC_7"
                        docindex = "AUC_7"
                    Case "AUC_11"
                        docindex = "AUC_11"
                    Case "AUC_17A"
                        docindex = "AUC_17A"
                    Case "AUC_17B"
                        docindex = "AUC_17B"
                    Case "AUC_17C"
                        docindex = "AUC_17C"
                    Case "AUC_5"
                        docindex = "AUC_5"
                    Case "AUC_19A"
                        docindex = "AUC_19A"
                    Case "AUC_19B"
                        docindex = "AUC_19B"
                    Case "AUC_19C"
                        docindex = "AUC_19C"
                    Case "AUC_325A"
                        docindex = "AUC_325A"
                    Case "AUC_325B"
                        docindex = "AUC_325B"
                    Case "AUC_325C"
                        docindex = "AUC_325C"

                End Select


                SavePDFFilName = Session("CNO") + Session("DP_NO") + myFileUpload.FileName
                myFileUpload.SaveAs(path & SavePDFFilName)
                File2SqlBlob(path, SavePDFFilName, docindex, TempDocVersion)
                'ViewState("Uploads") += myFileUpload.PostedFile.FileName.ToString() & "<br>"
                'ViewState("Uploads") += myFileUpload.PostedFile.FileName.ToString()
            Catch ex As Exception
                'txtMsg.Text += ex.Message.ToString()
            End Try
        Else
            '檢查至少必須指定一個上載檔案
            'If hasFile() Then
            '    txtMsg.Text = "必須指定檔案！"
            '    Return False
            'End If
        End If
    End Function

    Protected Sub GV_SETITEM_InitNewRow(sender As Object, e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles GV_SETITEM.InitNewRow

        e.NewValues("CNO") = Session("CNO")
        e.NewValues("DOCTYPE") = "設置"
        e.NewValues("DOCVERSION") = "1"
    End Sub

    Protected Sub GV_CHANGEITEM_InitNewRow(sender As Object, e As DevExpress.Web.Data.ASPxDataInitNewRowEventArgs) Handles GV_CHANGEITEM.InitNewRow

        e.NewValues("CNO") = Session("CNO")
        e.NewValues("DOCTYPE") = "變更"
        e.NewValues("DOCVERSION") = CInt(Session("DOCVERSION")) + 1

    End Sub

    Private Sub GV_SETITEM_CommandButtonInitialize(sender As Object, e As ASPxGridViewCommandButtonEventArgs) Handles GV_SETITEM.CommandButtonInitialize

        If Session("DOCEXIST") = "TRUE" Then
            Select Case e.ButtonType
                Case ColumnCommandButtonType.[New]
                    e.Visible = False
                Case ColumnCommandButtonType.Edit
                    e.Visible = False
                Case ColumnCommandButtonType.Delete
                    e.Visible = False


            End Select
        Else

            Select Case e.ButtonType
                Case ColumnCommandButtonType.[New]
                    e.Visible = True
                Case ColumnCommandButtonType.Edit
                    e.Visible = True
                Case ColumnCommandButtonType.Delete
                    e.Visible = True


            End Select

        End If




    End Sub

    Protected Sub GV_CHANGEITEM_CommandButtonInitialize(sender As Object, e As ASPxGridViewCommandButtonEventArgs) Handles GV_CHANGEITEM.CommandButtonInitialize

        If Session("DOCEXIST") = "TRUE" Then
            Select Case e.ButtonType
                Case ColumnCommandButtonType.[New]
                    e.Visible = True
                Case ColumnCommandButtonType.Edit
                    e.Visible = True
                Case ColumnCommandButtonType.Delete
                    e.Visible = True


            End Select
        Else

            Select Case e.ButtonType
                Case ColumnCommandButtonType.[New]
                    e.Visible = False
                Case ColumnCommandButtonType.Edit
                    e.Visible = False
                Case ColumnCommandButtonType.Delete
                    e.Visible = False


            End Select

        End If
    End Sub

    Protected Sub GV_SET_MAPPING_InitNewRow(sender As Object, e As Data.ASPxDataInitNewRowEventArgs) Handles GV_SET_MAPPING.InitNewRow


        e.NewValues("CNO") = Session("CNO")
        e.NewValues("DOCVERSION") = Session("DOCVERSION")

    End Sub

    Protected Sub AUC_2_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_2.FileUploadComplete

        Try

            Upload(AUC_2)

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub AUC_1_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_1.FileUploadComplete

        Try

            Upload(AUC_1)

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub AUC_7_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_7.FileUploadComplete


        Try

            Upload(AUC_7)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub AUC_11_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_11.FileUploadComplete

        Try

            Upload(AUC_11)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub AUC_17A_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_17A.FileUploadComplete
        Try

            Upload(AUC_17A)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub AUC_17B_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_17B.FileUploadComplete
        Try

            Upload(AUC_17B)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub AUC_17C_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_17C.FileUploadComplete
        Try

            Upload(AUC_17C)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub AUC_19A_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_19A.FileUploadComplete
        Try

            Upload(AUC_19A)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub AUC_19B_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_19B.FileUploadComplete
        Try

            Upload(AUC_19B)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub AUC_19C_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_19C.FileUploadComplete
        Try

            Upload(AUC_19C)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub AUC_5_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_5.FileUploadComplete

        Try

            Upload(AUC_5)

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub AUC_325A_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_325A.FileUploadComplete

        Try

            Upload(AUC_325A)

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub AUC_325B_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_325B.FileUploadComplete

        Try

            Upload(AUC_325B)

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub AUC_325C_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_325C.FileUploadComplete

        Try

            Upload(AUC_325C)

        Catch ex As Exception

        End Try

    End Sub
End Class
