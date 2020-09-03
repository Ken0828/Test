Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports DevExpress.Web

Partial Class DocManage_SetDoc
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
                TB_LP_DATE4_1.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM4_1_DATE").ToString)
                TB_LP_DATE4_2.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM4_2_DATE").ToString)
                TB_LP_DATE4_3.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM4_3_DATE").ToString)
                TB_LP_DATE4_4.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM4_4_DATE").ToString)
                TB_LP_DATE4_5.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM4_5_DATE").ToString)
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


        Dim Sqlstr As String = "Select * from DOC_SET_SPEC where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempItem + "'"

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
                CB_DOC_Instead.Value = getresult.returnDataTable.Rows(0).Item("SPEC_DOCATTACH_INST").ToString
                CB_DOC_Cali.Value = getresult.returnDataTable.Rows(0).Item("SPEC_DOCATTACH_CALI").ToString
                RBL_VIDEO_F.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_F").ToString
                TB_VIDEO_F.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString
                RBL_VIDEO_R.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_R").ToString
                TB_VIDEO_R.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString
                RBL_VIDEO_NV.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_NV").ToString
                TB_VIDEO_NV.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString
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

        Dim Sqlstr As String = "Select * from DOC_SET_LINK where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"

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

        Dim Sqlstr As String = "Select * from DOC_SET_FACTORY where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"

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
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_FACTORY] ([TYPE], [TYPEB], [TYPEW], [TYPEDESP], [CNO], [DOCVERSION], [REGUNIT], [FAC_NAME], [FAC_CNAME], [FAC_CTEL], [FAC_CMOBILE], [FAC_CFAX], [FAC_CEMAIL], [REG_DATE], [C_ID], [C_DATE]) VALUES (@TYPE, @TYPEB, @TYPEW, @TYPEDESP, @CNO, @DOCVERSION, @REGUNIT, @FAC_NAME, @FAC_CNAME, @FAC_CTEL, @FAC_CMOBILE, @FAC_CFAX, @FAC_CEMAIL, @REG_DATE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_FACTORY] SET [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP, [REGUNIT] = @REGUNIT, [FAC_NAME] = @FAC_NAME, [FAC_CNAME] = @FAC_CNAME, [FAC_CTEL] = @FAC_CTEL, [FAC_CMOBILE] = @FAC_CMOBILE, [FAC_CFAX] = @FAC_CFAX, [FAC_CEMAIL] = @FAC_CEMAIL, [REG_DATE] = @REG_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_FACTORY where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

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
            Dim strComment As String = Session("CNO")
            Dim strItemStatus = EIPDB.GetItemStatus("SET", strComment)
            Session("DOCEXIST") = strItemStatus
            'Session("CNO") = strComment
            Session("DOCVERSION") = EIPDB.GetDocVersion("SET", strComment)
            Label_DocVersion.Text = Session("DOCVERSION")

            If strItemStatus = "TRUE" Then
                RBL_SETCHANGE.Enabled = True
                RBL_SETCHANGE.SelectedIndex = 1


                'GV_CHANGEITEM.Enabled = True
            Else
                RBL_SETCHANGE.Enabled = False
                GV_CHANGEITEM.Enabled = False
            End If


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
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_SPEC] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD], [SPEC_MONITOROTHER], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [C_ID], [C_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM, @DPNO_DESP, @SPEC_INSTEAD, @SPEC_MONITOROTHER, @SPEC_MO_NOTE_DPNO, @SPEC_MO_NOTE_DPNO1, @SPEC_MO_NOTE_QUA, @SPEC_INS_DATE, @SPEC_AGENTNAME, @SPEC_EQU_MODEL, @SPEC_EQU_SERIAL, @SPEC_SAMPLE_METHOD, @SPEC_SAMPLE_METHOD_FILTERYES, @SPEC_SAMPLE_METHOD_FILTERNO, @SPEC_CALC_EQU, @SPEC_CALC_FREQ, @SPEC_CALC_METHOD, @SPEC_MAIN_FREQ, @SPEC_MAIN_METHOD, @SPEC_MATERIAL, @SPEC_WASTELIQUID, @SPEC_MATERIAL_FREQ, @SPEC_MEA_SCOPE, @SPEC_MEA_SCOPEUNIT, @SPEC_MEA_RESTIME, @SPEC_MEA_RESTIMEUNIT, @SPEC_MEA_FREQ, @SPEC_MEA_FREQUNIT, @SPEC_CALCAVG, @SPEC_DOCATTACH_INST, @SPEC_DOCATTACH_CALI, @SPEC_VIDEO_F, @SPEC_VIDEO_F_MEMO, @SPEC_VIDEO_R, @SPEC_VIDEO_R_MEMO, @SPEC_VIDEO_NV, @SPEC_VIDEO_NV_MEMO, @SPEC_ANASIG_YES, @SPEC_ANASIG, @SPEC_DIGSIG_YES, @SPEC_DIGSIG, @SPEC_DO_HARDWARE_CONNECT, @SPEC_DO_HARDWARE_CONNPARA, @SPEC_DO_HARDWARE_DOC, @SPEC_PLCAGENT, @SPEC_COSPEC, @SPEC_H_CHANGE, @SPEC_H_CHANGE_NOTE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_SPEC] SET [DPNO_DESP] = @DPNO_DESP, [SPEC_INSTEAD] = @SPEC_INSTEAD, [SPEC_MONITOROTHER] = @SPEC_MONITOROTHER, [SPEC_MO_NOTE_DPNO] = @SPEC_MO_NOTE_DPNO, [SPEC_MO_NOTE_DPNO1] = @SPEC_MO_NOTE_DPNO1, [SPEC_MO_NOTE_QUA] = @SPEC_MO_NOTE_QUA, [SPEC_INS_DATE] = @SPEC_INS_DATE, [SPEC_AGENTNAME] = @SPEC_AGENTNAME, [SPEC_EQU_MODEL] = @SPEC_EQU_MODEL, [SPEC_EQU_SERIAL] = @SPEC_EQU_SERIAL, [SPEC_SAMPLE_METHOD] = @SPEC_SAMPLE_METHOD, [SPEC_SAMPLE_METHOD_FILTERYES] = @SPEC_SAMPLE_METHOD_FILTERYES, [SPEC_SAMPLE_METHOD_FILTERNO] = @SPEC_SAMPLE_METHOD_FILTERNO, [SPEC_CALC_EQU] = @SPEC_CALC_EQU, [SPEC_CALC_FREQ] = @SPEC_CALC_FREQ, [SPEC_CALC_METHOD] = @SPEC_CALC_METHOD, [SPEC_MAIN_FREQ] = @SPEC_MAIN_FREQ, [SPEC_MAIN_METHOD] = @SPEC_MAIN_METHOD, [SPEC_MATERIAL] = @SPEC_MATERIAL, [SPEC_WASTELIQUID] = @SPEC_WASTELIQUID, [SPEC_MATERIAL_FREQ] = @SPEC_MATERIAL_FREQ, [SPEC_MEA_SCOPE] = @SPEC_MEA_SCOPE, [SPEC_MEA_SCOPEUNIT] = @SPEC_MEA_SCOPEUNIT, [SPEC_MEA_RESTIME] = @SPEC_MEA_RESTIME, [SPEC_MEA_RESTIMEUNIT] = @SPEC_MEA_RESTIMEUNIT, [SPEC_MEA_FREQ] = @SPEC_MEA_FREQ, [SPEC_MEA_FREQUNIT] = @SPEC_MEA_FREQUNIT, [SPEC_CALCAVG] = @SPEC_CALCAVG, [SPEC_DOCATTACH_INST] = @SPEC_DOCATTACH_INST, [SPEC_DOCATTACH_CALI] = @SPEC_DOCATTACH_CALI, [SPEC_VIDEO_F] = @SPEC_VIDEO_F, [SPEC_VIDEO_F_MEMO] = @SPEC_VIDEO_F_MEMO, [SPEC_VIDEO_R] = @SPEC_VIDEO_R, [SPEC_VIDEO_R_MEMO] = @SPEC_VIDEO_R_MEMO, [SPEC_VIDEO_NV] = @SPEC_VIDEO_NV, [SPEC_VIDEO_NV_MEMO] = @SPEC_VIDEO_NV_MEMO, [SPEC_ANASIG_YES] = @SPEC_ANASIG_YES, [SPEC_ANASIG] = @SPEC_ANASIG, [SPEC_DIGSIG_YES] = @SPEC_DIGSIG_YES, [SPEC_DIGSIG] = @SPEC_DIGSIG, [SPEC_DO_HARDWARE_CONNECT] = @SPEC_DO_HARDWARE_CONNECT, [SPEC_DO_HARDWARE_CONNPARA] = @SPEC_DO_HARDWARE_CONNPARA, [SPEC_DO_HARDWARE_DOC] = @SPEC_DO_HARDWARE_DOC, [SPEC_PLCAGENT] = @SPEC_PLCAGENT, [SPEC_COSPEC] = @SPEC_COSPEC, [SPEC_H_CHANGE] = @SPEC_H_CHANGE, [SPEC_H_CHANGE_NOTE] = @SPEC_H_CHANGE_NOTE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")
        TempITEM = RBL_SPEC_DPNOITEM.Value.ToString


        Dim Sqlstr As String = "Select * from DOC_SET_SPEC where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempITEM + "'"

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
                    .InsertParameters.Add("DP_NO", RBL_SPEC_DPNO.SelectedItem.Value)
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
                    .InsertParameters.Add("SPEC_DOCATTACH_INST", CB_DOC_Instead.Checked.ToString)
                    .InsertParameters.Add("SPEC_DOCATTACH_CALI", CB_DOC_Cali.Checked.ToString)
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
                    .UpdateParameters.Add("DP_NO", Session("DP_NO"))
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
                    .UpdateParameters.Add("SPEC_DOCATTACH_INST", CB_DOC_Instead.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DOCATTACH_CALI", CB_DOC_Cali.Checked.ToString)
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
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_LINK] ([cNo], [DP_NO], [DocVersion],  [DAHS_REDAN_FUNC], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [MaintainType], [MonitorCenter], [NOTE1], [NOTE2], [C_ID], [C_DATE]) VALUES (@cNo, @DP_NO, @DocVersion, @UploadMapping, @DAHS_REDAN_FUNC, @CemsPCCpu, @CemsPCMem, @CemsPCHDD, @CemsPCOS, @CemsPCNetcard, @CemsPCAntiVirus, @CemsPCFirewall, @NetworkLineType, @NetworkIPType, @MaintainType, @MonitorCenter, @NOTE1, @NOTE2, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_LINK] SET [DP_NO] = @DP_NO,  [DAHS_REDAN_FUNC] = @DAHS_REDAN_FUNC, [CemsPCCpu] = @CemsPCCpu, [CemsPCMem] = @CemsPCMem, [CemsPCHDD] = @CemsPCHDD, [CemsPCOS] = @CemsPCOS, [CemsPCNetcard] = @CemsPCNetcard, [CemsPCAntiVirus] = @CemsPCAntiVirus, [CemsPCFirewall] = @CemsPCFirewall, [NetworkLineType] = @NetworkLineType, [NetworkIPType] = @NetworkIPType, [MaintainType] = @MaintainType, [MonitorCenter] = @MonitorCenter, [NOTE1] = @NOTE1, [NOTE2] = @NOTE2, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_LINK where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

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


    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click

        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempDocVersion As String = ""

        If RBL_SETCHANGE.Value = "設置" Then

            Try
                Dim fieldValues As List(Of Object) = GV_SETITEM.GetSelectedFieldValues(New String() {"CNO", "DP_NO", "DOCVERSION"})
                For Each item As Object() In fieldValues
                    'ASPxListBox1.Items.Add(item(0).ToString())
                    tempcno = item(0).ToString()
                    tempdpno = item(1).ToString()
                    tempDocVersion = item(2).ToString()

                    Session("DP_NO") = tempdpno
                    Session("DOCVERSION") = tempDocVersion

                Next item

            Catch ex As Exception

            End Try
        Else

            Try
                Dim fieldValues As List(Of Object) = GV_CHANGEITEM.GetSelectedFieldValues(New String() {"CNO", "DP_NO", "DOCVERSION"})
                For Each item As Object() In fieldValues
                    'ASPxListBox1.Items.Add(item(0).ToString())
                    tempcno = item(0).ToString()
                    tempdpno = item(1).ToString()
                    tempDocVersion = item(2).ToString()


                    Session("DP_NO") = tempdpno
                    Session("DOCVERSION") = tempDocVersion

                Next item

            Catch ex As Exception

            End Try
        End If

        GV_SPEC.DataBind()
        FillLINKPLAN()
        FillLink()



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


    Private Sub File2SqlBlob(ByVal SourceFilePath As String, ByVal SourceFileName As String, ByVal PdfIndex As String, ByVal MyDocVersion As String)

        'Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CEMS_EQUConnectionString").ConnectionString.ToString

        Dim cn As New SqlConnection(DBconntext)
        'Dim cmd As New SqlCommand("UPDATE PolUPloadDoc SET pdffile=@pdffile WHERE PFTFacNo='E5600841' and PolNo='P001' and docindex='1'", cn)
        Dim cmd As New SqlCommand("INSERT INTO DOC_SET_PDFUPload (CNo,DP_NO,DocIndex,DocVersion,DocNumber,path,filename,pdffile,CreatorID,CreateDate) VALUES (@CNo,@DP_NO,@DocIndex,@DocVersion,@DocNumber,@path,@filename,@pdffile,@CreatorID,@CreateDate) ", cn)
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
        Dim path As String = HttpContext.Current.Request.MapPath("~/pdfupload/SET/")
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

                End Select

                SavePDFFilName = Session("CNO") + Session("DP_NO") + myFileUpload.FileName
                myFileUpload.SaveAs(path & SavePDFFilName)
                File2SqlBlob(path, SavePDFFilName, docindex, TempDocVersion)

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

    Protected Sub RBL_SPEC_MONITOROTHER_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_SPEC_MONITOROTHER.SelectedIndexChanged

        If RBL_SPEC_MONITOROTHER.SelectedValue = "是" Then

            TB_SPEC_MO_NOTE_DPNO.Enabled = False
            TB_SPEC_MO_NOTE_DPNO1.Enabled = False

        Else
            TB_SPEC_MO_NOTE_DPNO.Enabled = True
            TB_SPEC_MO_NOTE_DPNO1.Enabled = True
        End If

    End Sub

    Protected Sub RBL_SPEC__WASTELIQUID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_SPEC__WASTELIQUID.SelectedIndexChanged

        If RBL_SPEC__WASTELIQUID.SelectedIndex = 0 Then

            AUC_11.Enabled = False
        Else

            AUC_11.Enabled = True


        End If

    End Sub

    Protected Sub CB_DOC_Instead_CheckedChanged(sender As Object, e As EventArgs) Handles CB_DOC_Instead.CheckedChanged

        If CB_DOC_Instead.Checked = True Then

            AUC_17A.Enabled = True
        Else
            AUC_17A.Enabled = False

        End If
    End Sub

    Protected Sub CB_DOC_Cali_CheckedChanged(sender As Object, e As EventArgs) Handles CB_DOC_Cali.CheckedChanged

        If CB_DOC_Cali.Checked = True Then
            AUC_17B.Enabled = True
        Else
            AUC_17B.Enabled = False

        End If

    End Sub

    Protected Sub CB_19_Analog_CheckedChanged(sender As Object, e As EventArgs) Handles CB_19_Analog.CheckedChanged

        If CB_19_Analog.Checked = True Then
            DDL_19_Analog.Enabled = True
        Else
            DDL_19_Analog.Enabled = False
        End If

    End Sub

    Protected Sub CB_19_Digital_CheckedChanged(sender As Object, e As EventArgs) Handles CB_19_Digital.CheckedChanged

        If CB_19_Digital.Checked = True Then
            TB_19_DIGTAL.Enabled = True
        Else
            TB_19_DIGTAL.Enabled = False
        End If
    End Sub


    Protected Sub BT_LP_SAVE_Click(sender As Object, e As EventArgs) Handles BT_LP_SAVE.Click

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_LP] ([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE], [TRANSTYPE], [ITEM1_DATE], [ITEM2_DATE], [ITEM3_DATE], [ITEM4_1_DATE], [ITEM4_2_DATE], [ITEM4_3_DATE], [ITEM4_4_DATE], [ITEM4_5_DATE], [NOTE], [C_ID], [C_DATE]) VALUES (@CNO, @DOCVERSION, @SETCOMPANY, @SETPEOPLE, @TRANSTYPE, @ITEM1_DATE, @ITEM2_DATE, @ITEM3_DATE, @ITEM4_1_DATE, @ITEM4_2_DATE, @ITEM4_3_DATE, @ITEM4_4_DATE, @ITEM4_5_DATE, @NOTE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_LP] SET [SETCOMPANY] = @SETCOMPANY, [SETPEOPLE] = @SETPEOPLE, [TRANSTYPE] = @TRANSTYPE, [ITEM1_DATE] = @ITEM1_DATE, [ITEM2_DATE] = @ITEM2_DATE, [ITEM3_DATE] = @ITEM3_DATE, [ITEM4_1_DATE] = @ITEM4_1_DATE, [ITEM4_2_DATE] = @ITEM4_2_DATE, [ITEM4_3_DATE] = @ITEM4_3_DATE, [ITEM4_4_DATE] = @ITEM4_4_DATE, [ITEM4_5_DATE] = @ITEM4_5_DATE, [NOTE] = @NOTE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_LP where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

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
                    .InsertParameters.Add("SETCOMPANY", TB_LP_SETCOMPANY.Text)
                    .InsertParameters.Add("SETPEOPLE", TB_LP_SETPEOPLE.Text)
                    .InsertParameters.Add("TRANSTYPE", RBL_TRANS_TYPE.SelectedValue)
                    .InsertParameters.Add("ITEM1_DATE", TB_LP_DATE1.Text)
                    .InsertParameters.Add("ITEM2_DATE", TB_LP_DATE2.Text)
                    .InsertParameters.Add("ITEM3_DATE", TB_LP_DATE3.Text)
                    .InsertParameters.Add("ITEM4_1_DATE", TB_LP_DATE4_1.Text)
                    .InsertParameters.Add("ITEM4_2_DATE", TB_LP_DATE4_2.Text)
                    .InsertParameters.Add("ITEM4_3_DATE", TB_LP_DATE4_3.Text)
                    .InsertParameters.Add("ITEM4_4_DATE", TB_LP_DATE4_4.Text)
                    .InsertParameters.Add("ITEM4_5_DATE", TB_LP_DATE4_5.Text)
                    .InsertParameters.Add("NOTE", TB_LP_MEMO.Text)
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
                    .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    .UpdateParameters.Add("SETCOMPANY", TB_LP_SETCOMPANY.Text)
                    .UpdateParameters.Add("SETPEOPLE", TB_LP_SETPEOPLE.Text)
                    .UpdateParameters.Add("TRANSTYPE", RBL_TRANS_TYPE.SelectedValue)
                    .UpdateParameters.Add("ITEM1_DATE", TB_LP_DATE1.Text)
                    .UpdateParameters.Add("ITEM2_DATE", TB_LP_DATE2.Text)
                    .UpdateParameters.Add("ITEM3_DATE", TB_LP_DATE3.Text)
                    .UpdateParameters.Add("ITEM4_1_DATE", TB_LP_DATE4_1.Text)
                    .UpdateParameters.Add("ITEM4_2_DATE", TB_LP_DATE4_2.Text)
                    .UpdateParameters.Add("ITEM4_3_DATE", TB_LP_DATE4_3.Text)
                    .UpdateParameters.Add("ITEM4_4_DATE", TB_LP_DATE4_4.Text)
                    .UpdateParameters.Add("ITEM4_5_DATE", TB_LP_DATE4_5.Text)
                    .UpdateParameters.Add("NOTE", TB_LP_MEMO.Text)
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

    End Sub

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

    Protected Sub ASPxButton10_Click(sender As Object, e As EventArgs) Handles ASPxButton10.Click

        Server.Transfer("SetReport.aspx")

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
End Class
