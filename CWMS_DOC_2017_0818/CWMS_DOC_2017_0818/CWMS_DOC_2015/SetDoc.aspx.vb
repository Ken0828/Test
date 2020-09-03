Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO
Imports DevExpress.Web
Imports System.Net.Mail
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Collections
Imports System.ComponentModel
Imports System.Text
Imports NPOI
Imports NPOI.HPSF
Imports NPOI.HSSF
Imports NPOI.HSSF.UserModel
Imports NPOI.POIFS
Imports NPOI.POIFS.FileSystem
Imports NPOI.Util
Imports NPOI.SS.UserModel
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSpreadsheet.Services
Imports DevExpress.XtraSpreadsheet.Services.Implementation
Imports cwmsdoc


Partial Class DocManage_SetDoc
    Inherits System.Web.UI.Page

    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
    Dim RuleAuditFlag As String = WebConfigurationManager.ConnectionStrings("CWMS_Security").ConnectionString.ToString

    Dim strScript_EraseUploadSuccess As String = "<script language=JavaScript> alert(""上傳檔已刪除成功""); </script>"
    Dim strScript_EraseUploadFail As String = "<script language=JavaScript> alert(""上傳檔刪除失敗""); </script>"

    Dim MyDOCVersion As Integer = 0

    Private SqlTxt_Factory As String
    Private SqlTxt_Item As String
    Private SqlTxt_SPEC As String
    Private SqlTxt_LED As String
    Private SqlTxt_LINK As String
    Private SqlTxt_LP As String
    Private SqlTxt_DAHS As String
    Private SqlTxt_DPNOItem As String
    Private SqlTxt_SPEC_DPNO As String
    Private SqlTxt_CHECKLIST As String

    Protected Function GetCaseMailList(ByVal strCno As String, ByVal strDocversion As String, ByVal strDocType As String)


        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader


        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  owner,agent,helper  from dahs_examlist  c  where c.cno ='" + Session("CNO") + "' and c.docversion='" + Session("DOCVERSION") + "' and c.doctype='" + Session("DOCTYPE") + "' "
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                Session("OWNERID") = GetUserName(DatasetOwner.GetString(0))
                Session("AGENT") = GetUserName(DatasetOwner.GetString(1))
                Session("HELPER") = GetUserName(DatasetOwner.GetString(2))
            End While

        Catch ex As Exception

        End Try

        Return GetCaseMailList

    End Function

    Protected Function GetUserName(ByVal strOwner As String) As String



        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader

        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  a.UserName from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where b.name='" + strOwner + "'"
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                GetUserName = DatasetOwner.GetString(0)
            End While

        Catch ex As Exception

        End Try

        DatasetOwner.Close()
        mycommand.Dispose()
        conn.Close()

        Return GetUserName

    End Function


    Protected Function GetOwnerName(ByVal strOwner As String) As String


        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader

        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  b.name from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where a.username='" + strOwner + "'"
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                GetOwnerName = DatasetOwner.GetString(0)
            End While

        Catch ex As Exception
            GetOwnerName = ""
        End Try

        Return GetOwnerName

    End Function


    Private Sub FillDahs()

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_DAHS where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"
        Dim Sqlstr_PDF As String = "Select [DDL318], [DDL33] from DOC_SET_PDF where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "' Group By [DDL318], [DDL33]"

        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.ReturnCode >= 1 Then

                TB_DAHS_DPNO.Text = getresult.returnDataTable.Rows(0).Item("DP_NO").ToString
                TB_DAHS_PLAN_INSDATE.Date = getresult.returnDataTable.Rows(0).Item("PLAN_INSDATE").ToString
                TB_DAHS_AGENT.Text = getresult.returnDataTable.Rows(0).Item("AGENT").ToString
                RBL_DAHS_REDANDENT.SelectedValue = getresult.returnDataTable.Rows(0).Item("REDANDUNT").ToString
                RBL_DAHS_CONTROLROOM.SelectedValue = getresult.returnDataTable.Rows(0).Item("CONTROLROOM").ToString
                RBL_CLOUD.SelectedValue = getresult.returnDataTable.Rows(0).Item("COLUD").ToString
                RBL_MAINTAINMETHOD.SelectedValue = getresult.returnDataTable.Rows(0).Item("MAINTAINMETHOD").ToString
                CB_DAHS_DOCATTACH.Checked = CBool(getresult.returnDataTable.Rows(0).Item("DOCATTACH").ToString)
                RBL_FITFREQ.SelectedValue = getresult.returnDataTable.Rows(0).Item("FITFREQ").ToString
                RBL_FITFORMAT.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("FITFORMAT").ToString)
                'RBL_Link_NetworkIPType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("NetworkIPType").ToString)
                DE_DAHS_STAR168DATE.Date = Trim(getresult.returnDataTable.Rows(0).Item("STAR168DATE").ToString)


            End If

        Catch ex As Exception


        End Try

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)
            If getresult.ReturnCode >= 1 Then

                DDL318.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL318").ToString.Trim
                DDL33.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL33").ToString.Trim

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FillLed()

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_LED where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"
        Dim Sqlstr_PDF As String = "Select [DDL5112A], [DDL5112B], [DDL52], [DDL53] from DOC_SET_PDF where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "' Group By [DDL5112A], [DDL5112B], [DDL52], [DDL53]"

        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.ReturnCode >= 1 Then

                RBL_LED_INSTALL.SelectedValue = getresult.returnDataTable.Rows(0).Item("LED_INSTALL").ToString
                TB_LED_DP_NO.Text = getresult.returnDataTable.Rows(0).Item("DP_NO").ToString
                TB_LED_PLAN_DATE.Text = CDate(getresult.returnDataTable.Rows(0).Item("LED_PLAN_DATE").ToString)
                TB_LED_FACTORY.Text = getresult.returnDataTable.Rows(0).Item("LED_FACTORY").ToString
                TB_LED_MODEL.Text = getresult.returnDataTable.Rows(0).Item("LED_MODEL").ToString
                TB_LED_SERIAL.Text = getresult.returnDataTable.Rows(0).Item("LED_SERIAL").ToString
                RBL_LED_TYPE.SelectedValue = getresult.returnDataTable.Rows(0).Item("LED_TYPE").ToString.Trim
                RBL_LED_INSTALLPOS.SelectedValue = getresult.returnDataTable.Rows(0).Item("LED_INSTALLPOS").ToString.Trim
                RBL_LED_SHOWITEM.SelectedValue = getresult.returnDataTable.Rows(0).Item("LED_SHOWITEM").ToString.Trim
                RBL_LED_FORMAT.SelectedValue = getresult.returnDataTable.Rows(0).Item("LED_FORMAT").ToString.Trim
                RBL_LED_FREQ.SelectedValue = getresult.returnDataTable.Rows(0).Item("LED_FREQ").ToString.Trim
                RBL_LED_Content.SelectedValue = getresult.returnDataTable.Rows(0).Item("LED_CONTENT").ToString.Trim

            End If

        Catch ex As Exception


        End Try

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)
            If getresult.ReturnCode >= 1 Then

                DDL5112A.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL5112A").ToString.Trim
                DDL5112B.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL5112B").ToString.Trim
                DDL52.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL52").ToString.Trim
                DDL53.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL53").ToString.Trim

            End If

        Catch ex As Exception

        End Try

    End Sub


    Private Sub FillLink()

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_LINK where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"
        Dim Sqlstr_PDF As String = "Select [DDL415A], [DDL415B], [DDL42] from DOC_SET_PDF where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "' Group by [DDL415A], [DDL415B], [DDL42]"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                TB_Link_COVERDPNO.Text = getresult.returnDataTable.Rows(0).Item("DP_NO").ToString
                'RBL_Link_Redandant.SelectedValue = getresult.returnDataTable.Rows(0).Item("DAHS_REDAN_FUNC").ToString
                TB_Link_CemsPCCpu.Text = getresult.returnDataTable.Rows(0).Item("CemsPCCpu").ToString
                TB_Link_CemsPCMem.Text = getresult.returnDataTable.Rows(0).Item("CemsPCMem").ToString
                TB_Link_CemsPCHDD.Text = getresult.returnDataTable.Rows(0).Item("CemsPCHDD").ToString
                TB_Link_CemsPCOS.Text = getresult.returnDataTable.Rows(0).Item("CemsPCOS").ToString
                TB_Link_CemsPCNetcard.Text = getresult.returnDataTable.Rows(0).Item("CemsPCNetcard").ToString
                TB_Link_CemsPCAntiVirus.Text = getresult.returnDataTable.Rows(0).Item("CemsPCAntiVirus").ToString
                TB_Link_CemsPCFirewall.Text = getresult.returnDataTable.Rows(0).Item("CemsPCFirewall").ToString
                RBL_Link_NetworkLineType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("NetworkLineType").ToString)
                RBL_Link_NetworkIPType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("NetworkIPType").ToString)
                TB_Link_NetworkIPType_IP.Text = Trim(getresult.returnDataTable.Rows(0).Item("NetworkIP").ToString)
                RBL_Link_VIDEONetworkLineType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("VideoLineType").ToString)
                RBL_Link_VIDEONetworkIPType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("VideoIPType").ToString)
                TB_Link_VIDEONetworkIPType_IP.Text = Trim(getresult.returnDataTable.Rows(0).Item("VideoIP").ToString)
                RBL_Link_NetworkPORT.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("NetworkPortNumber").ToString)
                TB_Link_NetworkPORT_OTHER.Text = Trim(getresult.returnDataTable.Rows(0).Item("NetworkPortNumberOther").ToString)
                RBL_Link_MaintainType.SelectedValue = Trim(getresult.returnDataTable.Rows(0).Item("MaintainType").ToString)
                CB_LINK_5A.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_LINK_5A").ToString)
                CB_LINK_5B.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_LINK_5B").ToString)

            End If

        Catch ex As Exception


        End Try

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)

            If getresult.ReturnCode >= 1 Then

                DDL415A.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL415A").ToString.Trim
                DDL415B.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL415B").ToString.Trim
                DDL42.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL42").ToString.Trim

            End If

        Catch ex As Exception

        End Try

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
                'RBL_TRANS_TYPE.SelectedValue = getresult.returnDataTable.Rows(0).Item("TRANSTYPE").ToString
                TB_LP_DATE1.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM1_DATE").ToString)
                'TB_LP_DATE2.Text = CDate(getresult.returnDataTable.Rows(0).Item("ITEM2_DATE").ToString)
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
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempItem + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                'RBL_SPEC_DPNO.Value = getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString
                TB_SPEC_DPNODESP.Text = getresult.returnDataTable.Rows(0).Item("DP_NO").ToString
                RBL_SPEC_DPNOITEM.Value = getresult.returnDataTable.Rows(0).Item("ITEM").ToString
                RBL_SPEC_INSTEAD_YES.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_INSTEAD_YES").ToString)
                RBL_SPEC_INSTEAD_NO.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_INSTEAD_NO").ToString)
                RBL_MONITOROTHER_YES.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_MONITOROTHER_YES").ToString)
                RBL_MONITOROTHER_NO.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_MONITOROTHER_NO").ToString)
                TB_SPEC_MO_NOTE_DPNO.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MO_NOTE_DPNO").ToString
                TB_SPEC_MO_NOTE_DPNO1.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MO_NOTE_DPNO1").ToString
                TB_SPEC_INS_DATE.Text = CDate(getresult.returnDataTable.Rows(0).Item("SPEC_INS_DATE").ToString)
                TB_SPEC_AGENTNAME.Text = getresult.returnDataTable.Rows(0).Item("SPEC_AGENTNAME").ToString
                TB_SPEC_EQU_MODEL.Text = getresult.returnDataTable.Rows(0).Item("SPEC_EQU_MODEL").ToString
                TB_SPEC_EQU_SERIAL.Text = getresult.returnDataTable.Rows(0).Item("SPEC_EQU_SERIAL").ToString
                TB_SPEC_SAMPLE_METHOD.Text = getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD").ToString
                TB_SPEC_SAMPLE_METHOD_DESP.Text = getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD_DESP").ToString
                RB_SPEC_SAMPLE_METHOD_FilterYes.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERYES").ToString)
                RB_SPEC_SAMPLE_METHOD_FilterNO.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERNO").ToString)
                TB_SPEC_CALC_EQU.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_EQU").ToString
                TB_SPEC_CALC_FREQ.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_FREQ").ToString
                If Not getresult.returnDataTable.Rows(0).Item("SPEC_CALC_METHOD").ToString.Length < 1 Then
                    RBL_SPEC_CALC_FREQMETHOD.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_METHOD").ToString
                End If
                TB_SPEC_MAIN_FREQ.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MAIN_FREQ").ToString
                If Not getresult.returnDataTable.Rows(0).Item("SPEC_MAIN_METHOD").ToString.Length < 1 Then
                    RBL_SPEC_MAIN_FREQMETHOD.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MAIN_METHOD").ToString
                End If
                TB_SPEC_MATERIAL.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MATERIAL").ToString
                If Not getresult.returnDataTable.Rows(0).Item("SPEC_WASTELIQUID").ToString.Length < 1 Then
                    RBL_SPEC__WASTELIQUID.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_WASTELIQUID").ToString
                End If
                TB_SPEC_MATERIAL_FREQ.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MATERIAL_FREQ").ToString
                TB_SPEC_MEA_SCOPE.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_SCOPE").ToString
                DDL_SPEC_MEA_SCOPEUNIT.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_SCOPEUNIT").ToString
                TB_SPEC_MEA_RESTIME.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_RESTIME").ToString
                DDL_SPEC_MEA_RESTIMEUNIT.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_RESTIMEUNIT").ToString
                TB_SPEC_MEA_FREQ.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_FREQ").ToString
                DDL_SPEC_MEA_FREQUNIT.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_FREQUNIT").ToString
                TB_SPEC_CALCAVG.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALCAVG").ToString
                CB_DOC_Instead.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DOCATTACH_INST").ToString.Trim
                CB_DOC_Cali.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DOCATTACH_CALI").ToString.Trim
                RBL_VIDEO_F.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_F").ToString
                TB_VIDEO_F.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString
                RBL_VIDEO_R.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_R").ToString
                TB_VIDEO_R.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString
                RBL_VIDEO_NV.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_NV").ToString
                TB_VIDEO_NV.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString
                TB_SPEC_PLCAGENT.Text = getresult.returnDataTable.Rows(0).Item("SPEC_PLCAGENT").ToString
                RBL_SPEC_COSPEC.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_COSPEC").ToString
                TB_SPEC_COSPEC.Text = getresult.returnDataTable.Rows(0).Item("SPEC_COSPEC_NOTE").ToString

                RBL_SPEC_H_CHANGE.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_H_CHANGE").ToString
                TB_SPEC_H_CHANGE_NOTE.Text = getresult.returnDataTable.Rows(0).Item("SPEC_H_CHANGE_NOTE").ToString
                CB_DO_HARDWARE_CONNECT.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DO_HARDWARE_CONNECT").ToString.Trim
                CB_DO_HARDWARE_CONNPARA.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DO_HARDWARE_CONNPARA").ToString.Trim
                CB_DO_HARDWARE_DOC.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DO_HARDWARE_DOC").ToString.Trim

                TB_Note.Text =getresult.returnDataTable.Rows(0).Item("SPEC_NOTE").ToString

                CB_19_Analog.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_ANASIG_YES").ToString.Trim

                CB_19_Digital.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DIGSIG_YES").ToString.Trim
                TB_19_DIGTAL.Text = getresult.returnDataTable.Rows(0).Item("SPEC_DIGSIG").ToString

                If getresult.returnDataTable.Rows(0).Item("SPEC_ANASIG_YES").ToString = "True" Then
                    DDL_19_Analog.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_ANASIG").ToString
                End If




            End If

        Catch ex As Exception


        End Try

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)
            If getresult.ReturnCode >= 1 Then

                DDL1.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL1").ToString
                DDL2.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL2").ToString
                DDL5.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL5").ToString
                DDL6.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL6").ToString
                DDL7.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL7").ToString
                DDL11.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL11").ToString
                DDL17A.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL17A").ToString
                DDL17B.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL17B").ToString
                DDL19A.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL19A").ToString
                DDL19B.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL19B").ToString
                DDL19C.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL19C").ToString
                DDL20.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL20").ToString

            End If

        Catch ex As Exception

        End Try

        ASPxPageControl1.ActiveTabIndex = 1


    End Sub




    Private Sub FillFactory()

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""
        Dim ChangeType As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_FACTORY where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                'RBL_BAS_TYPE.SelectedValue = getresult.returnDataTable.Rows(0).Item(0).ToString
                MYTYPE = getresult.returnDataTable.Rows(0).Item(0).ToString
                If MYTYPE = "事業" Then
                    RBL_BAS_TYPE_B.Checked = True
                    RBL_BAS_TYPE_I.Checked = False
                    'RBL_BAS_TYPEB.SelectedValue = getresult.returnDataTable.Rows(0).Item("TYPEB").ToString
                    TB_BAS_TYPEB.Text = getresult.returnDataTable.Rows(0).Item("TYPEB").ToString
                ElseIf MYTYPE = "污水下水道系統" Then
                    RBL_BAS_TYPE_B.Checked = False
                    RBL_BAS_TYPE_I.Checked = True
                    RBL_BAS_TYPEW.SelectedValue = getresult.returnDataTable.Rows(0).Item("TYPEW").ToString
                End If

                'RBL_BAS_TYPEB.SelectedValue = getresult.returnDataTable.Rows(0).Item("TYPEDESP").ToString
                'TB_BAS_REGUNIT.Text = getresult.returnDataTable.Rows(0).Item("REGUNIT").ToString
                TB_BAS_FAC_NAME.Text = getresult.returnDataTable.Rows(0).Item("FAC_NAME").ToString
                TB_BAS_FAC_CNO.Text = getresult.returnDataTable.Rows(0).Item("CNO").ToString
                TB_BAS_FAC_CNAME.Text = getresult.returnDataTable.Rows(0).Item("FAC_CNAME").ToString
                TB_BAS_FAC_CTEL.Text = getresult.returnDataTable.Rows(0).Item("FAC_CTEL").ToString
                TB_BAS_FAC_CTEL_EXT.Text = getresult.returnDataTable.Rows(0).Item("FAC_CTEL_EXT").ToString
                TB_BAS_FAC_CMOBILE.Text = getresult.returnDataTable.Rows(0).Item("FAC_CMOBILE").ToString
                TB_BAS_FAC_CFAX.Text = getresult.returnDataTable.Rows(0).Item("FAC_CFAX").ToString
                TB_BAS_FAC_CEMAIL.Text = getresult.returnDataTable.Rows(0).Item("FAC_CEMAIL").ToString
                'TB_REGDATE.Text = CDate(getresult.returnDataTable.Rows(0).Item("REG_DATE").ToString)

                CB_RULE_31.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_31").ToString)
                CB_RULE_56.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_56").ToString)
                CB_RULE_56_1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_56_1").ToString)
                CB_RULE_56_2.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_56_2").ToString)
                CB_RULE_56_3.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_56_3").ToString)
                CB_RULE_56_4.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_56_4").ToString)
                CB_RULE_56_5.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_56_5").ToString)
                CB_RULE_56_6.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_56_6").ToString)
                CB_RULE_56_7.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_56_7").ToString)
                CB_RULE_57_1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_57_1").ToString)
                'CB_RULE_58.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_58").ToString)
                CB_RULE_105.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_105").ToString)
                CB_RULE_1500_I.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_1500_I").ToString)
                CB_RULE_5000_BUSSINESS.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_5000_BUSSINESS").ToString)
                CB_RULE_1500_BUSSINESS.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_1500_BUSSINESS").ToString)
                CB_RULE_5000_LIFE.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_5000_LIFE").ToString)
                CB_RULE_1500_LIFE.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_1500_LIFE").ToString)
                CB_RULE_ELEC.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_ELEC").ToString)
                CB_RULE_WATERCOOLER.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_WATERCOOLER").ToString)
                CB_RULE_E_EQUIP.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_E_EQUIP").ToString)
                CB_RULE_OTHER.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_OTHER").ToString)

                CB_RULE_19.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_19").ToString)
                CB_RULE_19_4.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_19_4").ToString)
                CB_RULE_19_4_56.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_19_4_56").ToString)
                CB_RULE_19_56.Checked = CBool(getresult.returnDataTable.Rows(0).Item("RULE_19_56").ToString)

                CB_CWMS_LINK.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CWMS_LINK").ToString)
                CB_LINKRULE56.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CWMS_LINKRULE_56").ToString)
                CB_LINKRULE57_1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CWMS_LINKRULE_57_1").ToString)
                CB_LINKRULE105.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CWMS_LINKRULE_105").ToString)
                CB_LINKRULE19_4.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CWMS_LINKRULE_19_4").ToString)

                TB_LINKSET.Text = getresult.returnDataTable.Rows(0).Item("LINKSET").ToString
                CB_CWMS_LED.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CWMS_LED").ToString)
                CB_LEDRULE_56.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CWMS_LEDRULE_56").ToString)
                'CB_LEDRULE_105.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CWMS_LEDRULE_105").ToString)
                TB_LEDSET.Text = getresult.returnDataTable.Rows(0).Item("LEDSET").ToString
                TB_BAS_PERMITVOL.Text = getresult.returnDataTable.Rows(0).Item("PERMIT_VOL").ToString
                TB_BAS_OPVOL.Text = getresult.returnDataTable.Rows(0).Item("OPERATION_VOL").ToString


                ChangeType = getresult.returnDataTable.Rows(0).Item("RBL_REG_SET").ToString

                If ChangeType = "設置(新申請)" Then
                    RBL_REG_SET.Checked = True
                    RBL_REG_MODI.Checked = False

                Else
                    RBL_REG_SET.Checked = False
                    RBL_REG_MODI.Checked = True

                    CB_5_MOD_C.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_5_MOD_C").ToString)
                    CB_5_MOD_OTHER.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_5_MOD_OTHER").ToString)

                End If



            End If

        Catch ex As Exception


        End Try

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)

            If getresult.ReturnCode >= 1 Then

                DDL_New.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL_New").ToString.Trim
                DDL_Modify.SelectedItem.Text = getresult.returnDataTable.Rows(0).Item("DDL_Modify").ToString.Trim

            End If

        Catch ex As Exception

        End Try

    End Sub


    Protected Sub BT_BASIC_SAVE_Click(sender As Object, e As EventArgs) Handles BT_BASIC_SAVE.Click

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        'Dim InsertSQL As String = "INSERT INTO [DOC_SET_FACTORY] ([TYPE], [TYPEB], [TYPEW], [TYPEDESP], [CNO], [DOCVERSION], [REGUNIT], [FAC_NAME], [FAC_CNAME], [FAC_CTEL], [FAC_CTEL_EXT], [FAC_CMOBILE], [FAC_CFAX], [FAC_CEMAIL], [REG_DATE], [C_ID], [C_DATE]) VALUES (@TYPE, @TYPEB, @TYPEW, @TYPEDESP, @CNO, @DOCVERSION, @REGUNIT, @FAC_NAME, @FAC_CNAME, @FAC_CTEL,@FAC_CTEL_EXT, @FAC_CMOBILE, @FAC_CFAX, @FAC_CEMAIL, @REG_DATE, @C_ID, @C_DATE)"
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_FACTORY] ([TYPE], [TYPEB], [TYPEW], [TYPEDESP], [CNO], [DOCVERSION], [RULE_31], [RULE_56], [RULE_56_1], [RULE_56_2], [RULE_56_3], [RULE_56_4], [RULE_56_5], [RULE_56_6],[RULE_56_7], [RULE_57_1],  [RULE_105], [RULE_1500_I], [RULE_5000_BUSSINESS], [RULE_1500_BUSSINESS],[RULE_5000_LIFE],[RULE_1500_LIFE], [RULE_ELEC], [RULE_WATERCOOLER], [RULE_E_EQUIP], [RULE_OTHER],[RULE_19],[RULE_19_4],[RULE_19_4_56],[RULE_19_56], [CWMS_LINK], [CWMS_LINKRULE_56], [CWMS_LINKRULE_57_1], [CWMS_LINKRULE_105],[CWMS_LINKRULE_19_4], [LINKSET], [CWMS_LED], [CWMS_LEDRULE_56], [LEDSET], [PERMIT_VOL], [OPERATION_VOL], [REGUNIT], [FAC_NAME], [FAC_CNAME], [FAC_CTEL], [FAC_CTEL_EXT], [FAC_CMOBILE], [FAC_CFAX], [FAC_CEMAIL],[RBL_REG_MODI],[RBL_REG_SET],[CB_5_MOD_C],[CB_5_MOD_OTHER], [C_ID], [C_DATE]) VALUES (@TYPE, @TYPEB, @TYPEW, @TYPEDESP, @CNO, @DOCVERSION, @RULE_31, @RULE_56, @RULE_56_1, @RULE_56_2, @RULE_56_3, @RULE_56_4, @RULE_56_5, @RULE_56_6,@RULE_56_7, @RULE_57_1, @RULE_105, @RULE_1500_I, @RULE_5000_BUSSINESS, @RULE_1500_BUSSINESS,@RULE_5000_LIFE,@RULE_1500_LIFE, @RULE_ELEC, @RULE_WATERCOOLER, @RULE_E_EQUIP, @RULE_OTHER,@RULE_19,@RULE_19_4,@RULE_19_4_56,@RULE_19_56, @CWMS_LINK, @CWMS_LINKRULE_56, @CWMS_LINKRULE_57_1, @CWMS_LINKRULE_105,@CWMS_LINKRULE_19_4, @LINKSET, @CWMS_LED, @CWMS_LEDRULE_56,  @LEDSET, @PERMIT_VOL, @OPERATION_VOL, @REGUNIT, @FAC_NAME, @FAC_CNAME, @FAC_CTEL, @FAC_CTEL_EXT, @FAC_CMOBILE, @FAC_CFAX, @FAC_CEMAIL,@RBL_REG_MODI,@RBL_REG_SET,@CB_5_MOD_C,@CB_5_MOD_OTHER,@C_ID, @C_DATE)"
        'Dim UpdateSQL As String = "UPDATE [DOC_SET_FACTORY] SET [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP, [REGUNIT] = @REGUNIT, [FAC_NAME] = @FAC_NAME, [FAC_CNAME] = @FAC_CNAME, [FAC_CTEL] = @FAC_CTEL, [FAC_CTEL_EXT]=@FAC_CTEL_EXT,[FAC_CMOBILE] = @FAC_CMOBILE, [FAC_CFAX] = @FAC_CFAX, [FAC_CEMAIL] = @FAC_CEMAIL, [REG_DATE] = @REG_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_FACTORY] SET [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP, [RULE_31] = @RULE_31, [RULE_56] = @RULE_56, [RULE_56_1] = @RULE_56_1, [RULE_56_2] = @RULE_56_2, [RULE_56_3] = @RULE_56_3, [RULE_56_4] = @RULE_56_4, [RULE_56_5] = @RULE_56_5, [RULE_56_6] = @RULE_56_6,[RULE_56_7] = @RULE_56_7, [RULE_57_1] = @RULE_57_1, [RULE_105] = @RULE_105, [RULE_1500_I] = @RULE_1500_I, [RULE_5000_BUSSINESS] = @RULE_5000_BUSSINESS, [RULE_1500_BUSSINESS] = @RULE_1500_BUSSINESS,[RULE_5000_LIFE] = @RULE_5000_LIFE,[RULE_1500_LIFE] = @RULE_1500_LIFE, [RULE_ELEC] = @RULE_ELEC, [RULE_WATERCOOLER] = @RULE_WATERCOOLER, [RULE_E_EQUIP] = @RULE_E_EQUIP, [RULE_OTHER] = @RULE_OTHER,[RULE_19]=@RULE_19,[RULE_19_4]=@RULE_19_4,[RULE_19_4_56]=@RULE_19_4_56,[RULE_19_56]=@RULE_19_56, [CWMS_LINK] = @CWMS_LINK, [CWMS_LINKRULE_56] = @CWMS_LINKRULE_56, [CWMS_LINKRULE_57_1] = @CWMS_LINKRULE_57_1, [CWMS_LINKRULE_105] = @CWMS_LINKRULE_105,[CWMS_LINKRULE_19_4]=@CWMS_LINKRULE_19_4, [LINKSET] = @LINKSET, [CWMS_LED] = @CWMS_LED, [CWMS_LEDRULE_56] = @CWMS_LEDRULE_56, [LEDSET] = @LEDSET, [PERMIT_VOL] = @PERMIT_VOL, [OPERATION_VOL] = @OPERATION_VOL, [REGUNIT] = @REGUNIT, [FAC_NAME] = @FAC_NAME, [FAC_CNAME] = @FAC_CNAME, [FAC_CTEL] = @FAC_CTEL, [FAC_CTEL_EXT] = @FAC_CTEL_EXT, [FAC_CMOBILE] = @FAC_CMOBILE, [FAC_CFAX] = @FAC_CFAX, [FAC_CEMAIL] = @FAC_CEMAIL,[RBL_REG_MODI]=@RBL_REG_MODI,[RBL_REG_SET]=@RBL_REG_SET,[CB_5_MOD_C]=@CB_5_MOD_C,[CB_5_MOD_OTHER]=@CB_5_MOD_OTHER,  [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"
        Dim InsertSQL_PDF As String = "INSERT INTO [DOC_SET_PDF] ([CNO], [DOCVERSION], [DDL_New], [DDL_Modify], [CreatorID], [CreateDate]) VALUES (@CNO, @DOCVERSION, @DDL_New, @DDL_Modify, @CreatorID, @CreateDate)"
        Dim UpdateSQL_PDF As String = "UPDATE [DOC_SET_PDF] SET [DDL_New] = @DDL_New, [DDL_Modify] = @DDL_Modify, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"

        'Input Audit


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Dim SDS_PlanPolFeature_PDF As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature_PDF.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Session("FAC_NAME") = TB_BAS_FAC_NAME.Text

        Dim Sqlstr As String = "Select * from DOC_SET_FACTORY where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

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
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If

                    If RBL_BAS_TYPE_B.Checked Then
                        .InsertParameters.Add("TYPE", RBL_BAS_TYPE_B.Text)
                        .InsertParameters.Add("TYPEB", TB_BAS_TYPEB.Text)
                        .InsertParameters.Add("TYPEW", "")
                    End If
                    If RBL_BAS_TYPE_I.Checked Then
                        .InsertParameters.Add("TYPE", RBL_BAS_TYPE_I.Text)
                        .InsertParameters.Add("TYPEB", "")
                        .InsertParameters.Add("TYPEW", RBL_BAS_TYPEW.SelectedItem.Value)
                    End If

                    .InsertParameters.Add("TYPEDESP", "")
                    .InsertParameters.Add("RULE_31", CB_RULE_31.Checked.ToString)
                    .InsertParameters.Add("RULE_56", CB_RULE_56.Checked.ToString)
                    .InsertParameters.Add("RULE_56_1", CB_RULE_56_1.Checked.ToString)
                    .InsertParameters.Add("RULE_56_2", CB_RULE_56_2.Checked.ToString)
                    .InsertParameters.Add("RULE_56_3", CB_RULE_56_3.Checked.ToString)
                    .InsertParameters.Add("RULE_56_4", CB_RULE_56_4.Checked.ToString)
                    .InsertParameters.Add("RULE_56_5", CB_RULE_56_5.Checked.ToString)
                    .InsertParameters.Add("RULE_56_6", CB_RULE_56_6.Checked.ToString)
                    .InsertParameters.Add("RULE_56_7", CB_RULE_56_7.Checked.ToString)
                    .InsertParameters.Add("RULE_57_1", CB_RULE_57_1.Checked.ToString)
                    '.InsertParameters.Add("RULE_58", CB_RULE_58.Checked.ToString)
                    .InsertParameters.Add("RULE_105", CB_RULE_105.Checked.ToString)
                    .InsertParameters.Add("RULE_1500_I", CB_RULE_1500_I.Checked.ToString)
                    .InsertParameters.Add("RULE_5000_BUSSINESS", CB_RULE_5000_BUSSINESS.Checked.ToString)
                    .InsertParameters.Add("RULE_1500_BUSSINESS", CB_RULE_1500_BUSSINESS.Checked.ToString)
                    .InsertParameters.Add("RULE_5000_LIFE", CB_RULE_5000_LIFE.Checked.ToString)
                    .InsertParameters.Add("RULE_1500_LIFE", CB_RULE_1500_LIFE.Checked.ToString)
                    .InsertParameters.Add("RULE_ELEC", CB_RULE_ELEC.Checked.ToString)
                    .InsertParameters.Add("RULE_WATERCOOLER", CB_RULE_WATERCOOLER.Checked.ToString)
                    .InsertParameters.Add("RULE_E_EQUIP", CB_RULE_E_EQUIP.Checked.ToString)
                    .InsertParameters.Add("RULE_OTHER", CB_RULE_OTHER.Checked.ToString)

                    .InsertParameters.Add("RULE_19", CB_RULE_19.Checked.ToString)
                    .InsertParameters.Add("RULE_19_4", CB_RULE_19_4.Checked.ToString)
                    .InsertParameters.Add("RULE_19_4_56", CB_RULE_19_4_56.Checked.ToString)
                    .InsertParameters.Add("RULE_19_56", CB_RULE_19_4_56.Checked.ToString)

                    .InsertParameters.Add("CWMS_LINK", CB_CWMS_LINK.Checked.ToString)
                    .InsertParameters.Add("CWMS_LINKRULE_56", CB_LINKRULE56.Checked.ToString)
                    .InsertParameters.Add("CWMS_LINKRULE_57_1", CB_LINKRULE57_1.Checked.ToString)
                    .InsertParameters.Add("CWMS_LINKRULE_105", CB_LINKRULE105.Checked.ToString)
                    .InsertParameters.Add("CWMS_LINKRULE_19_4", CB_LINKRULE19_4.Checked.ToString)

                    .InsertParameters.Add("LINKSET", TB_LINKSET.Text)
                    .InsertParameters.Add("CWMS_LED", CB_CWMS_LED.Checked.ToString)
                    .InsertParameters.Add("CWMS_LEDRULE_56", CB_LEDRULE_56.Checked.ToString)
                    '.InsertParameters.Add("CWMS_LEDRULE_105", CB_LEDRULE_105.Checked.ToString)
                    .InsertParameters.Add("LEDSET", TB_LEDSET.Text)
                    .InsertParameters.Add("PERMIT_VOL", TB_BAS_PERMITVOL.Text)
                    .InsertParameters.Add("OPERATION_VOL", TB_BAS_OPVOL.Text)
                    .InsertParameters.Add("REGUNIT", TB_BAS_FAC_NAME.Text)
                    .InsertParameters.Add("FAC_NAME", TB_BAS_FAC_NAME.Text)
                    .InsertParameters.Add("FAC_CNAME", TB_BAS_FAC_CNAME.Text)
                    .InsertParameters.Add("FAC_CTEL", TB_BAS_FAC_CTEL.Text)
                    .InsertParameters.Add("FAC_CTEL_EXT", TB_BAS_FAC_CTEL_EXT.Text)
                    .InsertParameters.Add("FAC_CMOBILE", TB_BAS_FAC_CMOBILE.Text)
                    .InsertParameters.Add("FAC_CFAX", TB_BAS_FAC_CFAX.Text)
                    .InsertParameters.Add("FAC_CEMAIL", TB_BAS_FAC_CEMAIL.Text)

                    If RBL_REG_SET.Checked =True Then
                        .InsertParameters.Add("RBL_REG_SET", RBL_REG_SET.Text)                        
                        .InsertParameters.Add("RBL_REG_MODI", "")                    
                    Else
                        .InsertParameters.Add("RBL_REG_SET", "")
                        .InsertParameters.Add("RBL_REG_MODI", RBL_REG_MODI.Text)
                        
                    End If
                    
                    .InsertParameters.Add("CB_5_MOD_C", CB_5_MOD_C.Checked.ToString)
                    .InsertParameters.Add("CB_5_MOD_OTHER", CB_5_MOD_OTHER.Checked.ToString)                   
                    

                    '.InsertParameters.Add("REG_DATE", TB_REGDATE.Text)
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
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If

                    If RBL_BAS_TYPE_B.Checked Then
                        .UpdateParameters.Add("TYPE", RBL_BAS_TYPE_B.Text)
                        .UpdateParameters.Add("TYPEB", TB_BAS_TYPEB.Text)
                        .UpdateParameters.Add("TYPEW", "")
                    End If
                    If RBL_BAS_TYPE_I.Checked Then
                        .UpdateParameters.Add("TYPE", RBL_BAS_TYPE_I.Text)
                        .UpdateParameters.Add("TYPEB", "")
                        .UpdateParameters.Add("TYPEW", RBL_BAS_TYPEW.SelectedItem.Value)
                    End If


                    .UpdateParameters.Add("TYPEDESP", "")
                    .UpdateParameters.Add("RULE_31", CB_RULE_31.Checked.ToString)
                    .UpdateParameters.Add("RULE_56", CB_RULE_56.Checked.ToString)
                    .UpdateParameters.Add("RULE_56_1", CB_RULE_56_1.Checked.ToString)
                    .UpdateParameters.Add("RULE_56_2", CB_RULE_56_2.Checked.ToString)
                    .UpdateParameters.Add("RULE_56_3", CB_RULE_56_3.Checked.ToString)
                    .UpdateParameters.Add("RULE_56_4", CB_RULE_56_4.Checked.ToString)
                    .UpdateParameters.Add("RULE_56_5", CB_RULE_56_5.Checked.ToString)
                    .UpdateParameters.Add("RULE_56_6", CB_RULE_56_6.Checked.ToString)
                    .UpdateParameters.Add("RULE_56_7", CB_RULE_56_7.Checked.ToString)
                    .UpdateParameters.Add("RULE_57_1", CB_RULE_57_1.Checked.ToString)
                    '.UpdateParameters.Add("RULE_58", CB_RULE_58.Checked.ToString)
                    .UpdateParameters.Add("RULE_105", CB_RULE_105.Checked.ToString)
                    .UpdateParameters.Add("RULE_1500_I", CB_RULE_1500_I.Checked.ToString)
                    .UpdateParameters.Add("RULE_5000_BUSSINESS", CB_RULE_5000_BUSSINESS.Checked.ToString)
                    .UpdateParameters.Add("RULE_1500_BUSSINESS", CB_RULE_1500_BUSSINESS.Checked.ToString)
                    .UpdateParameters.Add("RULE_5000_LIFE", CB_RULE_5000_LIFE.Checked.ToString)
                    .UpdateParameters.Add("RULE_1500_LIFE", CB_RULE_1500_LIFE.Checked.ToString)
                    .UpdateParameters.Add("RULE_ELEC", CB_RULE_ELEC.Checked.ToString)
                    .UpdateParameters.Add("RULE_WATERCOOLER", CB_RULE_WATERCOOLER.Checked.ToString)
                    .UpdateParameters.Add("RULE_E_EQUIP", CB_RULE_E_EQUIP.Checked.ToString)
                    .UpdateParameters.Add("RULE_OTHER", CB_RULE_OTHER.Checked.ToString)

                    .UpdateParameters.Add("RULE_19", CB_RULE_19.Checked.ToString)
                    .UpdateParameters.Add("RULE_19_4", CB_RULE_19_4.Checked.ToString)
                    .UpdateParameters.Add("RULE_19_4_56", CB_RULE_19_4_56.Checked.ToString)
                    .UpdateParameters.Add("RULE_19_56", CB_RULE_19_4_56.Checked.ToString)

                    .UpdateParameters.Add("CWMS_LINK", CB_CWMS_LINK.Checked.ToString)
                    .UpdateParameters.Add("CWMS_LINKRULE_56", CB_LINKRULE56.Checked.ToString)
                    .UpdateParameters.Add("CWMS_LINKRULE_57_1", CB_LINKRULE57_1.Checked.ToString)
                    .UpdateParameters.Add("CWMS_LINKRULE_105", CB_LINKRULE105.Checked.ToString)
                    .UpdateParameters.Add("CWMS_LINKRULE_19_4", CB_LINKRULE19_4.Checked.ToString)

                    .UpdateParameters.Add("LINKSET", TB_LINKSET.Text)
                    .UpdateParameters.Add("CWMS_LED", CB_CWMS_LED.Checked.ToString)
                    .UpdateParameters.Add("CWMS_LEDRULE_56", CB_LEDRULE_56.Checked.ToString)
                    '.UpdateParameters.Add("CWMS_LEDRULE_105", CB_LEDRULE_105.Checked.ToString)
                    .UpdateParameters.Add("LEDSET", TB_LEDSET.Text)
                    .UpdateParameters.Add("PERMIT_VOL", TB_BAS_PERMITVOL.Text)
                    .UpdateParameters.Add("OPERATION_VOL", TB_BAS_OPVOL.Text)
                    .UpdateParameters.Add("REGUNIT", TB_BAS_FAC_NAME.Text)
                    .UpdateParameters.Add("FAC_NAME", TB_BAS_FAC_NAME.Text)
                    .UpdateParameters.Add("FAC_CNAME", TB_BAS_FAC_CNAME.Text)
                    .UpdateParameters.Add("FAC_CTEL", TB_BAS_FAC_CTEL.Text)
                    .UpdateParameters.Add("FAC_CTEL_EXT", TB_BAS_FAC_CTEL_EXT.Text)
                    .UpdateParameters.Add("FAC_CMOBILE", TB_BAS_FAC_CMOBILE.Text)
                    .UpdateParameters.Add("FAC_CFAX", TB_BAS_FAC_CFAX.Text)
                    .UpdateParameters.Add("FAC_CEMAIL", TB_BAS_FAC_CEMAIL.Text)
                    '.UpdateParameters.Add("REG_DATE", TB_REGDATE.Text)

                    
                    If RBL_REG_SET.Checked =True Then
                        .UpdateParameters.Add("RBL_REG_SET", RBL_REG_SET.Text)                        
                        .UpdateParameters.Add("RBL_REG_MODI", "")                    
                    Else
                        .UpdateParameters.Add("RBL_REG_SET", "")
                        .UpdateParameters.Add("RBL_REG_MODI", RBL_REG_MODI.Text)
                        
                    End If

                    .UpdateParameters.Add("CB_5_MOD_C", CB_5_MOD_C.Checked.ToString)
                    .UpdateParameters.Add("CB_5_MOD_OTHER", CB_5_MOD_OTHER.Checked.ToString)

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

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try


        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature_PDF

                    .InsertParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DDL_New", DDL_New.SelectedValue.ToString)
                    .InsertParameters.Add("DDL_Modify", DDL_Modify.SelectedValue.ToString)
                    .InsertParameters.Add("CreatorID", Session("UserName"))
                    .InsertParameters.Add("CreateDate", Today())
                    .InsertCommand = InsertSQL_PDF

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

                With SDS_PlanPolFeature_PDF

                    .UpdateParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DDL_New", DDL_New.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL_Modify", DDL_Modify.SelectedValue.ToString)
                    .UpdateParameters.Add("ModifyID", Session("UserName"))
                    .UpdateParameters.Add("ModifyDate", Today())
                    .UpdateCommand = UpdateSQL_PDF

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
        SDS_PlanPolFeature_PDF.dispose()
    End Sub


    Protected Sub OpenSaveButton()

        BT_BASIC_SAVE.Enabled = True
        BT_BASIC_CANCEL.Enabled = True
        BT_SPEC_SAVE.Enabled = True
        BT_SPEC_CANCEL.Enabled = True
        BT_DAHS_SAVE.Enabled = True
        BT_DAHS_CANCEL.Enabled = True
        BT_Link_SAVE.Enabled = True
        BT_LINK_CANCEL.Enabled = True
        BT_LED_SAVE.Enabled = True
        BT_LED_CANCEL.Enabled = True
        BT_LP_SAVE.Enabled = True
        BT_LP_CANCEL.Enabled = True
        BT_CheckList.Enabled = True
        BT_CHECKLIST_CANCEL.Enabled = True
        ASPxButton4.Enabled = True
        ASPxButton5.Enabled = True
        ASPxButton11.Enabled = True
        ASPxButton12.Enabled = True


        AUC_1.Enabled = True
        'AUC_Modify.Enabled = True


        '刪除上傳檔用
        BT_DEL_AUC1.Visible = True

        Session("AccessRight") = "FALSE"

    End Sub

    Protected Sub CloseSaveButton()

        BT_BASIC_SAVE.Enabled = False
        BT_BASIC_CANCEL.Enabled = False
        BT_SPEC_SAVE.Enabled = False
        BT_SPEC_CANCEL.Enabled = False
        BT_DAHS_SAVE.Enabled = False
        BT_DAHS_CANCEL.Enabled = False
        BT_Link_SAVE.Enabled = False
        BT_LINK_CANCEL.Enabled = False
        BT_LED_SAVE.Enabled = False
        BT_LED_CANCEL.Enabled = False
        BT_LP_SAVE.Enabled = False
        BT_LP_CANCEL.Enabled = False
        BT_CheckList.Enabled = False
        BT_CHECKLIST_CANCEL.Enabled = False
        ASPxButton4.Enabled = False
        ASPxButton5.Enabled = False
        ASPxButton11.Enabled = False
        ASPxButton12.Enabled = False

        AUC_1.Enabled = False
        'AUC_Modify.Enabled = False


        '刪除上傳檔用
        BT_DEL_AUC1.Visible = False

        Session("AccessRight") = "TRUE"

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim strScript_Error As String = "<script language=JavaScript> alert(""系統已逾時，請重新登入使用...""); </script>"
        Dim getresult As DbResult

        Dim strCityCode = Session("CityCode")
        Dim strCno As String = Session("CNO")
        Dim strComment As String = Session("Comment")
        Dim strItemStatus = EIPDB.GetItemStatus("SET", strCno)
        Dim strDocMode As String = Session("DOCMODE")

        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If

        'BT_Help_Factory.Attributes.Add("onclick", "window.open( '業者及污水下水道系統端-1051206.PDF', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")

        BT_PDF_DL.Attributes.Add("onclick", "window.open( '措施說明書申請確認書.PDF', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")

        'TB_SPEC_INS_DATE.  設定日期只使用民國年...~~未完

        LABEL_VERSION.Text = "目前版號:" + Session("DOCVERSION")


        If Not IsPostBack Then



            If strCno = "" Or strComment = "" Then

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
                Exit Sub

            End If

            Dim CaseExamSta = GetCaseExamStatus(Session("CNO"), Session("DOCVERSION"))

            '2018/10/3 加入ESTC DIG 二個群組

            If (Left(strComment, 4) = "ESTC" Or Left(strComment, 3) = "EPB") And (Right(strComment, 6) <> "HELPER") Then

                BT_SendAudit.Visible = False
                BT_Audit1.Visible = True
                BT_AuditSave.Visible = True
                BT_AuditAsst.Visible = True
                BT_PRINT.Visible = True
                Panel1.Visible = True

                CloseSaveButton()

            ElseIf strComment = "EPA" Or strComment = "AUDIT" Then

                BT_SendAudit.Visible = False
                BT_Audit1.Visible = False
                BT_AuditSave.Visible = False
                BT_AuditAsst.Visible = False
                BT_PRINT.Visible = True
                Panel1.Visible = True
                RBL_AuditResult.Enabled = False
                TB_AuditMemo.Enabled = False

                CloseSaveButton()



            ElseIf Right(strComment, 6) = "HELPER" Then

                BT_SendAudit.Visible = False
                BT_Audit1.Visible = False
                BT_AuditSave.Visible = True
                BT_AuditAsst.Visible = True
                BT_PRINT.Visible = True
                Panel1.Visible = True

                CloseSaveButton()

            Else
                '工廠端
                '2019-7-5 加上判斷已審查完成版本應鎖住
                If CaseExamSta = "審查中" Or CaseExamSta = "已送未審" Then

                    RBL_AuditResult.Visible = False
                    RBL_AuditResult.Enabled = False
                    TB_AuditMemo.Visible = False

                    CloseSaveButton()

                    BT_CHANGEVERSION.Enabled = False
                    BT_SendAudit.Visible = True
                    BT_SendAudit.Enabled = False

                    BT_AuditSave.Visible = False
                    BT_Audit1.Visible = False
                    BT_AuditAsst.Visible = False

                    Panel1.Visible = False



                ElseIf CaseExamSta = "補正重送" Then

                    RBL_AuditResult.Visible = True
                    RBL_AuditResult.Enabled = False
                    TB_AuditMemo.Visible = True

                    CloseSaveButton()

                    BT_SendAudit.Visible = True
                    BT_SendAudit.Enabled = False

                    BT_CHANGEVERSION.Enabled = False

                    BT_AuditSave.Visible = False
                    BT_Audit1.Visible = False
                    BT_AuditAsst.Visible = False

                    Panel1.Visible = False

                ElseIf CaseExamSta = "補正中" Then

                    RBL_AuditResult.Visible = True
                    RBL_AuditResult.Enabled = False
                    TB_AuditMemo.Visible = True

                    OpenSaveButton()

                    BT_SendAudit.Visible = True
                    BT_SendAudit.Enabled = True

                    BT_CHANGEVERSION.Enabled = False

                    BT_AuditSave.Visible = False
                    BT_Audit1.Visible = False
                    BT_AuditAsst.Visible = False

                    Panel1.Visible = True

                ElseIf CaseExamSta = "FALSE" And strDocMode = "措施說明書變更申請" Then

                    RBL_AuditResult.Visible = True
                    RBL_AuditResult.Enabled = False
                    TB_AuditMemo.Visible = True

                    OpenSaveButton()

                    BT_SendAudit.Visible = True
                    BT_SendAudit.Enabled = True

                    BT_CHANGEVERSION.Enabled = False

                    BT_AuditSave.Visible = False
                    BT_Audit1.Visible = False
                    BT_AuditAsst.Visible = False

                    Panel1.Visible = True

                ElseIf CaseExamSta = "FALSE" And strDocMode = "" Then

                    RBL_AuditResult.Visible = True
                    RBL_AuditResult.Enabled = False
                    TB_AuditMemo.Visible = True

                    OpenSaveButton()

                    BT_SendAudit.Visible = True
                    BT_SendAudit.Enabled = True

                    BT_CHANGEVERSION.Enabled = False

                    BT_AuditSave.Visible = False
                    BT_Audit1.Visible = False
                    BT_AuditAsst.Visible = False

                    Panel1.Visible = True

                ElseIf CaseExamSta = "FALSE" And strDocMode = "措施說明書申請" Then
                    RBL_AuditResult.Visible = True
                    RBL_AuditResult.Enabled = False
                    TB_AuditMemo.Visible = True

                    OpenSaveButton()

                    BT_SendAudit.Visible = True
                    BT_SendAudit.Enabled = True

                    BT_CHANGEVERSION.Enabled = False

                    BT_AuditSave.Visible = False
                    BT_Audit1.Visible = False
                    BT_AuditAsst.Visible = False

                    Panel1.Visible = True

                ElseIf CaseExamSta = "審查通過" And strDocMode = "" Then

                    RBL_AuditResult.Visible = True
                    RBL_AuditResult.Enabled = False
                    TB_AuditMemo.Visible = True

                    CloseSaveButton()
                    BT_SendAudit.Visible = True
                    BT_SendAudit.Enabled = False

                    BT_CHANGEVERSION.Enabled = False

                    BT_AuditSave.Visible = False
                    BT_Audit1.Visible = False
                    BT_AuditAsst.Visible = False

                    Panel1.Visible = True

                Else

                    RBL_AuditResult.Visible = False
                    RBL_AuditResult.Enabled = False
                    TB_AuditMemo.Visible = False

                    BT_AuditSave.Visible = False
                    BT_Audit1.Visible = False
                    BT_AuditAsst.Visible = False

                    BT_CHANGEVERSION.Enabled = False

                    CloseSaveButton()
                    BT_SendAudit.Visible = True
                    BT_SendAudit.Enabled = False



                End If

                BT_SendAudit.Visible = True
                BT_PRINT.Visible = True
                BT_Audit1.Visible = False
                BT_AuditSave.Visible = False
                BT_AuditAsst.Visible = False

                'RBL_AuditResult.Visible = True
                'RBL_AuditResult.Enabled = False
                'TB_AuditMemo.Visible = True
                BT_Audit1.Enabled = False
                GV_Audit.Enabled = False
            End If


            TB_BAS_FAC_CNO.Text = strCno


            Dim mySecurity As String = ConfigurationManager.ConnectionStrings("CWMS_Security").ConnectionString
            Dim myConnectionString As String = ConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString
            Dim conn As New SqlConnection(myConnectionString)
            conn.Open()

            FillFactory()
            FillLink()
            Fillspec()
            FillLINKPLAN()
            FillDahs()
            FillLed()
            FillCheckList()
            Fillspec_self()


            ASPxPageControl1.ActiveTabIndex = 0

            Dim AuditSqlstr As String = "Select * from DAHS_AuditResult where cno='" + Session("CNO") + "'  and DocVersion='" + Session("DOCVERSION") + "' and doctype='措施說明書'"

            getresult = EIPDB.GetData(AuditSqlstr)

            If getresult.ReturnCode >= 1 Then

                TB_AuditMemo.Text = getresult.returnDataTable.Rows(0).Item("AUDITMEMO").ToString
                RBL_AuditResult.SelectedValue = getresult.returnDataTable.Rows(0).Item("AUDITRESULT").ToString
                TB_Audit_DATE.Date = getresult.returnDataTable.Rows(0).Item("AUDITSERIAL").ToString

            End If

            '判斷是否為審查中...如果是則審查意見不SHOW
            'SHOW 的狀態為  : 審查完成  補正中  


        End If


        'If Session("DOCNEW") = "NEW" Then

        '    Dim getresult_Permit As DbResult
        '    Dim strSQL_Permit As String = ""

        '    strSQL_Permit = "select controlno,CompanyName,sum(DayTotalAudit) as DayTotal from cwms_1 where  RunState='營運中' and  controlno='" + Session("CNO") + "'  group by ControlNO,CompanyName "
        '    getresult_Permit = EIPDB.GetData(strSQL_Permit)

        '    Try

        '        If getresult_Permit.ReturnCode >= 1 Then
        '            If getresult_Permit.returnDataTable.Rows(0).Item("CompanyName").ToString <> "" Then

        '                TB_BAS_FAC_NAME.Text = getresult_Permit.returnDataTable.Rows(0).Item("CompanyName").ToString
        '                TB_BAS_PERMITVOL.Text = getresult_Permit.returnDataTable.Rows(0).Item("DayTotal").ToString

        '            Else
        '                TB_BAS_FAC_NAME.Text = ""
        '                TB_BAS_PERMITVOL.Text = ""
        '            End If
        '        End If

        '    Catch ex As Exception

        '    End Try

        'End If

        GV_Audit.DataBind()

        If strCno = "" Or strComment = "" Then

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)

            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()


        End If

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

    Protected Sub BT_SPEC_SAVE_Click(sender As Object, e As EventArgs) Handles BT_SPEC_SAVE.Click

        Dim TempCno, TempDP_NO, TempDocVersion, TempITEM As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_SPEC] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO], [SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD],[SPEC_SAMPLE_METHOD_DESP], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC],[SPEC_COSPEC_NOTE], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE],[SPEC_NOTE], [C_ID], [C_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM, @DPNO_DESP, @SPEC_INSTEAD_YES,@SPEC_INSTEAD_NO, @SPEC_MONITOROTHER_YES,@SPEC_MONITOROTHER_NO, @SPEC_MO_NOTE_DPNO, @SPEC_MO_NOTE_DPNO1, @SPEC_MO_NOTE_QUA, @SPEC_INS_DATE, @SPEC_AGENTNAME, @SPEC_EQU_MODEL, @SPEC_EQU_SERIAL, @SPEC_SAMPLE_METHOD,@SPEC_SAMPLE_METHOD_DESP, @SPEC_SAMPLE_METHOD_FILTERYES, @SPEC_SAMPLE_METHOD_FILTERNO, @SPEC_CALC_EQU, @SPEC_CALC_FREQ, @SPEC_CALC_METHOD, @SPEC_MAIN_FREQ, @SPEC_MAIN_METHOD, @SPEC_MATERIAL, @SPEC_WASTELIQUID, @SPEC_MATERIAL_FREQ, @SPEC_MEA_SCOPE, @SPEC_MEA_SCOPEUNIT, @SPEC_MEA_RESTIME, @SPEC_MEA_RESTIMEUNIT, @SPEC_MEA_FREQ, @SPEC_MEA_FREQUNIT, @SPEC_CALCAVG, @SPEC_DOCATTACH_INST, @SPEC_DOCATTACH_CALI, @SPEC_VIDEO_F, @SPEC_VIDEO_F_MEMO, @SPEC_VIDEO_R, @SPEC_VIDEO_R_MEMO, @SPEC_VIDEO_NV, @SPEC_VIDEO_NV_MEMO, @SPEC_ANASIG_YES, @SPEC_ANASIG, @SPEC_DIGSIG_YES, @SPEC_DIGSIG, @SPEC_DO_HARDWARE_CONNECT, @SPEC_DO_HARDWARE_CONNPARA, @SPEC_DO_HARDWARE_DOC, @SPEC_PLCAGENT, @SPEC_COSPEC,@SPEC_COSPEC_NOTE, @SPEC_H_CHANGE, @SPEC_H_CHANGE_NOTE,@SPEC_NOTE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_SPEC] SET [DPNO_DESP] = @DPNO_DESP, [SPEC_INSTEAD_YES] = @SPEC_INSTEAD_YES,[SPEC_INSTEAD_NO] = @SPEC_INSTEAD_NO, [SPEC_MONITOROTHER_YES] = @SPEC_MONITOROTHER_YES,[SPEC_MONITOROTHER_NO] = @SPEC_MONITOROTHER_NO, [SPEC_MO_NOTE_DPNO] = @SPEC_MO_NOTE_DPNO, [SPEC_MO_NOTE_DPNO1] = @SPEC_MO_NOTE_DPNO1, [SPEC_MO_NOTE_QUA] = @SPEC_MO_NOTE_QUA, [SPEC_INS_DATE] = @SPEC_INS_DATE, [SPEC_AGENTNAME] = @SPEC_AGENTNAME, [SPEC_EQU_MODEL] = @SPEC_EQU_MODEL, [SPEC_EQU_SERIAL] = @SPEC_EQU_SERIAL, [SPEC_SAMPLE_METHOD] = @SPEC_SAMPLE_METHOD,[SPEC_SAMPLE_METHOD_DESP] = @SPEC_SAMPLE_METHOD_DESP, [SPEC_SAMPLE_METHOD_FILTERYES] = @SPEC_SAMPLE_METHOD_FILTERYES, [SPEC_SAMPLE_METHOD_FILTERNO] = @SPEC_SAMPLE_METHOD_FILTERNO, [SPEC_CALC_EQU] = @SPEC_CALC_EQU, [SPEC_CALC_FREQ] = @SPEC_CALC_FREQ, [SPEC_CALC_METHOD] = @SPEC_CALC_METHOD, [SPEC_MAIN_FREQ] = @SPEC_MAIN_FREQ, [SPEC_MAIN_METHOD] = @SPEC_MAIN_METHOD, [SPEC_MATERIAL] = @SPEC_MATERIAL, [SPEC_WASTELIQUID] = @SPEC_WASTELIQUID, [SPEC_MATERIAL_FREQ] = @SPEC_MATERIAL_FREQ, [SPEC_MEA_SCOPE] = @SPEC_MEA_SCOPE, [SPEC_MEA_SCOPEUNIT] = @SPEC_MEA_SCOPEUNIT, [SPEC_MEA_RESTIME] = @SPEC_MEA_RESTIME, [SPEC_MEA_RESTIMEUNIT] = @SPEC_MEA_RESTIMEUNIT, [SPEC_MEA_FREQ] = @SPEC_MEA_FREQ, [SPEC_MEA_FREQUNIT] = @SPEC_MEA_FREQUNIT, [SPEC_CALCAVG] = @SPEC_CALCAVG, [SPEC_DOCATTACH_INST] = @SPEC_DOCATTACH_INST, [SPEC_DOCATTACH_CALI] = @SPEC_DOCATTACH_CALI, [SPEC_VIDEO_F] = @SPEC_VIDEO_F, [SPEC_VIDEO_F_MEMO] = @SPEC_VIDEO_F_MEMO, [SPEC_VIDEO_R] = @SPEC_VIDEO_R, [SPEC_VIDEO_R_MEMO] = @SPEC_VIDEO_R_MEMO, [SPEC_VIDEO_NV] = @SPEC_VIDEO_NV, [SPEC_VIDEO_NV_MEMO] = @SPEC_VIDEO_NV_MEMO, [SPEC_ANASIG_YES] = @SPEC_ANASIG_YES, [SPEC_ANASIG] = @SPEC_ANASIG, [SPEC_DIGSIG_YES] = @SPEC_DIGSIG_YES, [SPEC_DIGSIG] = @SPEC_DIGSIG, [SPEC_DO_HARDWARE_CONNECT] = @SPEC_DO_HARDWARE_CONNECT, [SPEC_DO_HARDWARE_CONNPARA] = @SPEC_DO_HARDWARE_CONNPARA, [SPEC_DO_HARDWARE_DOC] = @SPEC_DO_HARDWARE_DOC, [SPEC_PLCAGENT] = @SPEC_PLCAGENT, [SPEC_COSPEC] = @SPEC_COSPEC,[SPEC_COSPEC_NOTE] = @SPEC_COSPEC_NOTE, [SPEC_H_CHANGE] = @SPEC_H_CHANGE, [SPEC_H_CHANGE_NOTE] = @SPEC_H_CHANGE_NOTE,[SPEC_NOTE]=@SPEC_NOTE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM"
        Dim InsertSQL_PDF As String = "INSERT INTO [DOC_SET_PDF] ([CNO], [DP_NO], [DOCVERSION], [ITEM], [DDL1], [DDL2], [DDL5], [DDL6], [DDL7], [DDL11], [DDL17A], [DDL17B], [DDL19A], [DDL19B], [DDL19C], [DDL20], [CreatorID], [CreateDate]) VALUES (@CNO, @DP_NO, @DOCVERSION, @ITEM, @DDL1, @DDL2, @DDL5, @DDL6, @DDL7, @DDL11, @DDL17A, @DDL17B, @DDL19A, @DDL19B, @DDL19C, @DDL20, @CreatorID, @CreateDate)"
        Dim UpdateSQL_PDF As String = "UPDATE [DOC_SET_PDF] SET [DDL1] = @DDL1, [DDL2] = @DDL2, [DDL5] = @DDL5, [DDL6] = @DDL6, [DDL7] = @DDL7, [DDL11] = @DDL11, [DDL17A] = @DDL17A, [DDL17B] = @DDL17B, [DDL19A] = @DDL19A, [DDL19B] = @DDL19B, [DDL19C] = @DDL19C, [DDL20] = @DDL20, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM"

        Dim strScript_NoDPNO As String = "<script language=JavaScript> alert(""請先選取[監測位置]後再存檔""); </script>"
        Dim strScript_NoInstDate As String = "<script language=JavaScript> alert(""請先填入(三)安裝日期再存檔""); </script>"

        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Dim SDS_PlanPolFeature_PDF As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature_PDF.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")
        TempITEM = RBL_SPEC_DPNOITEM.Value.ToString

        If TempDP_NO = "" Then

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_NoDPNO)
            Exit Sub

        End If

        If TB_SPEC_INS_DATE.Text = "" Then

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_NoInstDate)
            Exit Sub

        End If



        Dim Sqlstr As String = "Select * from DOC_SET_SPEC where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempITEM + "'"
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempITEM + "'"

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
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    '.InsertParameters.Add("DP_NO", RBL_SPEC_DPNO.SelectedItem.Value)
                    .InsertParameters.Add("DP_NO", Session("DP_NO"))
                    .InsertParameters.Add("ITEM", RBL_SPEC_DPNOITEM.SelectedItem.Value)
                    .InsertParameters.Add("DPTYPE", Session("DPTYPE"))
                    .InsertParameters.Add("DPNO_DESP", TB_SPEC_DPNODESP.Text)
                    .InsertParameters.Add("SPEC_INSTEAD_YES", RBL_SPEC_INSTEAD_YES.Checked.ToString)
                    .InsertParameters.Add("SPEC_INSTEAD_NO  ", RBL_SPEC_INSTEAD_NO.Checked.ToString)
                    .InsertParameters.Add("SPEC_MONITOROTHER_YES", RBL_MONITOROTHER_YES.Checked.ToString)
                    .InsertParameters.Add("SPEC_MONITOROTHER_NO", RBL_MONITOROTHER_NO.Checked.ToString)
                    .InsertParameters.Add("SPEC_MO_NOTE_DPNO", TB_SPEC_MO_NOTE_DPNO.Text)
                    .InsertParameters.Add("SPEC_MO_NOTE_DPNO1", TB_SPEC_MO_NOTE_DPNO1.Text)
                    .InsertParameters.Add("SPEC_MO_NOTE_QUA", "")
                    .InsertParameters.Add("SPEC_INS_DATE", CDate(TB_SPEC_INS_DATE.Text))
                    .InsertParameters.Add("SPEC_AGENTNAME", TB_SPEC_AGENTNAME.Text)
                    .InsertParameters.Add("SPEC_EQU_MODEL", TB_SPEC_EQU_MODEL.Text)
                    .InsertParameters.Add("SPEC_EQU_SERIAL", TB_SPEC_EQU_SERIAL.Text)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD", TB_SPEC_SAMPLE_METHOD.Text)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD_DESP", TB_SPEC_SAMPLE_METHOD_DESP.Text)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD_FILTERYES", RB_SPEC_SAMPLE_METHOD_FilterYes.Checked.ToString)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD_FILTERNO", RB_SPEC_SAMPLE_METHOD_FilterNO.Checked.ToString)
                    .InsertParameters.Add("SPEC_CALC_EQU", TB_SPEC_CALC_EQU.Text)
                    .InsertParameters.Add("SPEC_CALC_FREQ", TB_SPEC_CALC_FREQ.Text)
                    .InsertParameters.Add("SPEC_CALC_METHOD", RBL_SPEC_CALC_FREQMETHOD.Text)
                    .InsertParameters.Add("SPEC_MAIN_FREQ", TB_SPEC_MAIN_FREQ.Text)
                    .InsertParameters.Add("SPEC_MAIN_METHOD", RBL_SPEC_MAIN_FREQMETHOD.Text)
                    .InsertParameters.Add("SPEC_MATERIAL", TB_SPEC_MATERIAL.Text)
                    .InsertParameters.Add("SPEC_WASTELIQUID", RBL_SPEC__WASTELIQUID.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_MATERIAL_FREQ", TB_SPEC_MATERIAL_FREQ.Text)
                    .InsertParameters.Add("SPEC_MEA_SCOPE", TB_SPEC_MEA_SCOPE.Text)
                    .InsertParameters.Add("SPEC_MEA_SCOPEUNIT", DDL_SPEC_MEA_SCOPEUNIT.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_MEA_RESTIME", TB_SPEC_MEA_RESTIME.Text)
                    .InsertParameters.Add("SPEC_MEA_RESTIMEUNIT", DDL_SPEC_MEA_RESTIMEUNIT.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_MEA_FREQ", TB_SPEC_MEA_FREQ.Text)
                    .InsertParameters.Add("SPEC_MEA_FREQUNIT", DDL_SPEC_MEA_FREQUNIT.SelectedValue.ToString)
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
                    .InsertParameters.Add("SPEC_COSPEC_NOTE", TB_SPEC_COSPEC.Text)
                    .InsertParameters.Add("SPEC_H_CHANGE", RBL_SPEC_H_CHANGE.SelectedItem.Value)
                    .InsertParameters.Add("SPEC_H_CHANGE_NOTE", TB_SPEC_H_CHANGE_NOTE.Text)
                    .InsertParameters.Add("SPEC_NOTE", TB_Note.Text)
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
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DP_NO", Session("DP_NO"))
                    .UpdateParameters.Add("ITEM", RBL_SPEC_DPNOITEM.SelectedItem.Value)
                    .UpdateParameters.Add("DPTYPE", Session("DPTYPE"))
                    .UpdateParameters.Add("DPNO_DESP", TB_SPEC_DPNODESP.Text)
                    .UpdateParameters.Add("SPEC_INSTEAD_YES", RBL_SPEC_INSTEAD_YES.Checked.ToString)
                    .UpdateParameters.Add("SPEC_INSTEAD_NO  ", RBL_SPEC_INSTEAD_NO.Checked.ToString)
                    .UpdateParameters.Add("SPEC_MONITOROTHER_YES", RBL_MONITOROTHER_YES.Checked.ToString)
                    .UpdateParameters.Add("SPEC_MONITOROTHER_NO", RBL_MONITOROTHER_NO.Checked.ToString)
                    .UpdateParameters.Add("SPEC_MO_NOTE_DPNO", TB_SPEC_MO_NOTE_DPNO.Text)
                    .UpdateParameters.Add("SPEC_MO_NOTE_DPNO1", TB_SPEC_MO_NOTE_DPNO1.Text)
                    .UpdateParameters.Add("SPEC_MO_NOTE_QUA", "")
                    .UpdateParameters.Add("SPEC_INS_DATE", CDate(TB_SPEC_INS_DATE.Text))
                    .UpdateParameters.Add("SPEC_AGENTNAME", TB_SPEC_AGENTNAME.Text)
                    .UpdateParameters.Add("SPEC_EQU_MODEL", TB_SPEC_EQU_MODEL.Text)
                    .UpdateParameters.Add("SPEC_EQU_SERIAL", TB_SPEC_EQU_SERIAL.Text)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD", TB_SPEC_SAMPLE_METHOD.Text)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD_DESP", TB_SPEC_SAMPLE_METHOD_DESP.Text)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD_FILTERYES", RB_SPEC_SAMPLE_METHOD_FilterYes.Checked.ToString)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD_FILTERNO", RB_SPEC_SAMPLE_METHOD_FilterNO.Checked.ToString)
                    .UpdateParameters.Add("SPEC_CALC_EQU", TB_SPEC_CALC_EQU.Text)
                    .UpdateParameters.Add("SPEC_CALC_FREQ", TB_SPEC_CALC_FREQ.Text)
                    .UpdateParameters.Add("SPEC_CALC_METHOD", RBL_SPEC_CALC_FREQMETHOD.Text)
                    .UpdateParameters.Add("SPEC_MAIN_FREQ", TB_SPEC_MAIN_FREQ.Text)
                    .UpdateParameters.Add("SPEC_MAIN_METHOD", RBL_SPEC_MAIN_FREQMETHOD.Text)
                    .UpdateParameters.Add("SPEC_MATERIAL", TB_SPEC_MATERIAL.Text)
                    .UpdateParameters.Add("SPEC_WASTELIQUID", RBL_SPEC__WASTELIQUID.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_MATERIAL_FREQ", TB_SPEC_MATERIAL_FREQ.Text)
                    .UpdateParameters.Add("SPEC_MEA_SCOPE", TB_SPEC_MEA_SCOPE.Text)
                    .UpdateParameters.Add("SPEC_MEA_SCOPEUNIT", DDL_SPEC_MEA_SCOPEUNIT.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_MEA_RESTIME", TB_SPEC_MEA_RESTIME.Text)
                    .UpdateParameters.Add("SPEC_MEA_RESTIMEUNIT", DDL_SPEC_MEA_RESTIMEUNIT.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_MEA_FREQ", TB_SPEC_MEA_FREQ.Text)
                    .UpdateParameters.Add("SPEC_MEA_FREQUNIT", DDL_SPEC_MEA_FREQUNIT.SelectedValue.ToString)
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
                    .UpdateParameters.Add("SPEC_COSPEC_NOTE", TB_SPEC_COSPEC.Text)
                    .UpdateParameters.Add("SPEC_H_CHANGE", RBL_SPEC_H_CHANGE.SelectedItem.Value)
                    .UpdateParameters.Add("SPEC_H_CHANGE_NOTE", TB_SPEC_H_CHANGE_NOTE.Text)
                    .UpdateParameters.Add("SPEC_NOTE", TB_Note.Text)
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

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try



        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature_PDF

                    .InsertParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DP_NO", Session("DP_NO"))
                    .InsertParameters.Add("ITEM", RBL_SPEC_DPNOITEM.SelectedItem.Value)
                    .InsertParameters.Add("DDL1", DDL1.SelectedValue.ToString)
                    .InsertParameters.Add("DDL2", DDL2.SelectedValue.ToString)
                    .InsertParameters.Add("DDL7", DDL7.SelectedValue.ToString)
                    .InsertParameters.Add("DDL11", DDL11.SelectedValue.ToString)
                    .InsertParameters.Add("DDL17A", DDL17A.SelectedValue.ToString)
                    .InsertParameters.Add("DDL17B", DDL17B.SelectedValue.ToString)
                    .InsertParameters.Add("DDL19A", DDL19A.SelectedValue.ToString)
                    .InsertParameters.Add("DDL19B", DDL19B.SelectedValue.ToString)
                    .InsertParameters.Add("DDL19C", DDL19C.SelectedValue.ToString)
                    .InsertParameters.Add("DDL20", DDL20.SelectedValue.ToString)
                    .InsertParameters.Add("DDL5", DDL5.SelectedValue.ToString)
                    .InsertParameters.Add("DDL6", DDL6.SelectedValue.ToString)
                    .InsertParameters.Add("CreatorID", Session("UserName"))
                    .InsertParameters.Add("CreateDate", Today())
                    .InsertCommand = InsertSQL_PDF

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

                With SDS_PlanPolFeature_PDF

                    .UpdateParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DP_NO", Session("DP_NO"))
                    .UpdateParameters.Add("ITEM", RBL_SPEC_DPNOITEM.SelectedItem.Value)
                    .UpdateParameters.Add("DDL1", DDL1.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL2", DDL2.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL7", DDL7.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL11", DDL11.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL17A", DDL17A.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL17B", DDL17B.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL19A", DDL19A.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL19B", DDL19B.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL19C", DDL19C.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL20", DDL20.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL5", DDL5.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL6", DDL6.SelectedValue.ToString)
                    .UpdateParameters.Add("ModifyID", Session("UserName"))
                    .UpdateParameters.Add("ModifyDate", Today())
                    .UpdateCommand = UpdateSQL_PDF

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
        SDS_PlanPolFeature_PDF.Dispose()

    End Sub



    Protected Sub BT_Link_SAVE_Click(sender As Object, e As EventArgs) Handles BT_Link_SAVE.Click


        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_LINK] ([cNo], [DP_NO], [DocVersion], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [NetworkIP], [VideoLineType], [VideoIPType], [VideoIP], [NetworkPortNumber], [NetworkPortNumberOther], [MaintainType],[CB_LINK_5A],[CB_LINK_5B],  [C_ID], [C_DATE]) VALUES (@cNo, @DP_NO, @DocVersion, @CemsPCCpu, @CemsPCMem, @CemsPCHDD, @CemsPCOS, @CemsPCNetcard, @CemsPCAntiVirus, @CemsPCFirewall, @NetworkLineType, @NetworkIPType, @NetworkIP, @VideoLineType, @VideoIPType, @VideoIP, @NetworkPortNumber, @NetworkPortNumberOther, @MaintainType,@CB_LINK_5A,@CB_LINK_5B, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_LINK] SET [DP_NO] = @DP_NO,  [CemsPCCpu] = @CemsPCCpu, [CemsPCMem] = @CemsPCMem, [CemsPCHDD] = @CemsPCHDD, [CemsPCOS] = @CemsPCOS, [CemsPCNetcard] = @CemsPCNetcard, [CemsPCAntiVirus] = @CemsPCAntiVirus, [CemsPCFirewall] = @CemsPCFirewall, [NetworkLineType] = @NetworkLineType, [NetworkIPType] = @NetworkIPType, [NetworkIP] = @NetworkIP, [VideoLineType] = @VideoLineType, [VideoIPType] = @VideoIPType, [VideoIP] = @VideoIP, [NetworkPortNumber] = @NetworkPortNumber, [NetworkPortNumberOther] = @NetworkPortNumberOther, [MaintainType] = @MaintainType,[CB_LINK_5A]=@CB_LINK_5A,[CB_LINK_5B]=@CB_LINK_5B, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion"
        Dim InsertSQL_PDF As String = "INSERT INTO [DOC_SET_PDF] ([CNO], [DOCVERSION], [DDL415A], [DDL415B], [DDL42], [CreatorID], [CreateDate]) VALUES (@CNO, @DOCVERSION, @DDL415A, @DDL415B, @DDL42, @CreatorID, @CreateDate)"
        Dim UpdateSQL_PDF As String = "UPDATE [DOC_SET_PDF] SET [DDL415A] = @DDL415A, [DDL415B] = @DDL415B, [DDL42] = @DDL42, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Dim SDS_PlanPolFeature_PDF As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature_PDF.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_LINK where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

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
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DP_NO", TB_Link_COVERDPNO.Text)
                    '.InsertParameters.Add("DAHS_REDAN_FUNC", RBL_Link_Redandant.SelectedValue.ToString)
                    .InsertParameters.Add("CemsPCCpu", TB_Link_CemsPCCpu.Text)
                    .InsertParameters.Add("CemsPCMem", TB_Link_CemsPCMem.Text)
                    .InsertParameters.Add("CemsPCHDD", TB_Link_CemsPCHDD.Text)
                    .InsertParameters.Add("CemsPCOS", TB_Link_CemsPCOS.Text)
                    .InsertParameters.Add("CemsPCNetcard", TB_Link_CemsPCNetcard.Text)
                    .InsertParameters.Add("CemsPCAntiVirus", TB_Link_CemsPCAntiVirus.Text)
                    .InsertParameters.Add("CemsPCFirewall", TB_Link_CemsPCFirewall.Text)
                    .InsertParameters.Add("NetworkLineType", RBL_Link_NetworkLineType.SelectedValue.ToString)
                    .InsertParameters.Add("NetworkIPType", RBL_Link_NetworkIPType.SelectedValue.ToString)
                    .InsertParameters.Add("NetworkIP", TB_Link_NetworkIPType_IP.Text)
                    .InsertParameters.Add("VideoLineType", RBL_Link_VIDEONetworkLineType.SelectedValue.ToString)
                    .InsertParameters.Add("VideoIPType", RBL_Link_VIDEONetworkIPType.SelectedValue.ToString)
                    .InsertParameters.Add("VideoIP", TB_Link_VIDEONetworkIPType_IP.Text)
                    .InsertParameters.Add("NetworkPortNumber", RBL_Link_NetworkPORT.SelectedValue.ToString)
                    .InsertParameters.Add("NetworkPortNumberOther", TB_Link_NetworkPORT_OTHER.Text)
                    .InsertParameters.Add("MaintainType", RBL_Link_MaintainType.SelectedValue.ToString)
                    'CB_LINK_5A
                    .InsertParameters.Add("CB_LINK_5A", CB_LINK_5A.Checked.ToString.Trim)
                    .InsertParameters.Add("CB_LINK_5B", CB_LINK_5B.Checked.ToString.Trim)
                    '.InsertParameters.Add("MonitorCenter", RBL_Link_MonitorCenter.SelectedValue.ToString)
                    '.InsertParameters.Add("NOTE1", "")
                    '.InsertParameters.Add("NOTE2", "")
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
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DP_NO", TB_Link_COVERDPNO.Text)
                    '.UpdateParameters.Add("DAHS_REDAN_FUNC", RBL_Link_Redandant.SelectedValue.ToString)
                    .UpdateParameters.Add("CemsPCCpu", TB_Link_CemsPCCpu.Text)
                    .UpdateParameters.Add("CemsPCMem", TB_Link_CemsPCMem.Text)
                    .UpdateParameters.Add("CemsPCHDD", TB_Link_CemsPCHDD.Text)
                    .UpdateParameters.Add("CemsPCOS", TB_Link_CemsPCOS.Text)
                    .UpdateParameters.Add("CemsPCNetcard", TB_Link_CemsPCNetcard.Text)
                    .UpdateParameters.Add("CemsPCAntiVirus", TB_Link_CemsPCAntiVirus.Text)
                    .UpdateParameters.Add("CemsPCFirewall", TB_Link_CemsPCFirewall.Text)
                    .UpdateParameters.Add("NetworkLineType", RBL_Link_NetworkLineType.SelectedValue.ToString)
                    .UpdateParameters.Add("NetworkIPType", RBL_Link_NetworkIPType.SelectedValue.ToString)
                    .UpdateParameters.Add("NetworkIP", TB_Link_NetworkIPType_IP.Text)
                    .UpdateParameters.Add("VideoLineType", RBL_Link_VIDEONetworkLineType.SelectedValue.ToString)
                    .UpdateParameters.Add("VideoIPType", RBL_Link_VIDEONetworkIPType.SelectedValue.ToString)
                    .UpdateParameters.Add("VideoIP", TB_Link_VIDEONetworkIPType_IP.Text)
                    .UpdateParameters.Add("NetworkPortNumber", RBL_Link_NetworkPORT.SelectedValue.ToString)
                    .UpdateParameters.Add("NetworkPortNumberOther", TB_Link_NetworkPORT_OTHER.Text)
                    .UpdateParameters.Add("MaintainType", RBL_Link_MaintainType.SelectedValue.ToString)
                    .UpdateParameters.Add("CB_LINK_5A", CB_LINK_5A.Checked.ToString.Trim)
                    .UpdateParameters.Add("CB_LINK_5B", CB_LINK_5B.Checked.ToString.Trim)
                    '.UpdateParameters.Add("MonitorCenter", RBL_Link_MonitorCenter.SelectedValue.ToString)
                    '.UpdateParameters.Add("NOTE1", "")
                    '.UpdateParameters.Add("NOTE2", "")
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

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try


        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature_PDF

                    .InsertParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DDL415A", DDL415A.SelectedValue.ToString)
                    .InsertParameters.Add("DDL415B", DDL415B.SelectedValue.ToString)
                    .InsertParameters.Add("DDL42", DDL42.SelectedValue.ToString)
                    .InsertParameters.Add("CreatorID", Session("UserName"))
                    .InsertParameters.Add("CreateDate", Today())
                    .InsertCommand = InsertSQL_PDF

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

                With SDS_PlanPolFeature_PDF

                    .UpdateParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DDL415A", DDL415A.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL415B", DDL415B.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL42", DDL42.SelectedValue.ToString)
                    .UpdateParameters.Add("ModifyID", Session("UserName"))
                    .UpdateParameters.Add("ModifyDate", Today())
                    .UpdateCommand = UpdateSQL_PDF

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
        SDS_PlanPolFeature_PDF.Dispose()


    End Sub


    Protected Sub GV_SPEC_SelectionChanged(sender As Object, e As EventArgs) Handles GV_SPEC.SelectionChanged


        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempitem As String = ""
        Dim tempDPTYPE As String = ""


        Try
            Dim fieldValues As List(Of Object) = GV_SPEC.GetSelectedFieldValues(New String() {"CNO", "DP_NO", "ITEM", "DPTYPE"})
            For Each item As Object() In fieldValues
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempitem = item(2).ToString()
                tempDPTYPE = item(3).ToString()

                Session("DP_NO") = tempdpno
                Session("ITEM") = tempitem
                Session("DPTYPE") = tempDPTYPE

            Next item

        Catch ex As Exception

        End Try

        Fillspec()


    End Sub

    Protected Sub ASPxButton9_Click(sender As Object, e As EventArgs) Handles ASPxButton9.Click

        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempitem As String = ""
        Dim tempDPType As String = ""

        Try

            Dim fieldValues As List(Of Object) = GV_SPEC.GetSelectedFieldValues(New String() {"CNO", "DP_NO", "ITEM", "DPTYPE"})
            For Each item As Object() In fieldValues
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempitem = item(2).ToString()
                tempDPType = item(3).ToString()

                Session("DP_NO") = tempdpno
                Session("ITEM") = tempitem
                Session("DPTYPE") = tempDPType

            Next item

            Fillspec()

        Catch ex As Exception

        End Try


    End Sub


    Private Sub File2SqlBlob(ByVal SourceFilePath As String, ByVal SourceFileName As String, ByVal MyFileDescription As String, ByVal MyDocVersion As String)


        Dim cn As New SqlConnection(DBconntext)
        Dim getresult As DbResult
        Dim ActionMode As String = ""
        Dim MyDocNumber As String = TB_DocNumber.Text


        Dim strSql As String = " select * from   DOC_PDF_BASIC where CNO='" + Session("CNO") + "' and DocNumber='" + MyDocNumber + "' and DocVersion='" + MyDocVersion + "'"

        Try

            getresult = EIPDB.GetData(strSql)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If
        Catch ex As Exception

        End Try

        If ActionMode = "INSERT" Then
            Dim cmd As New SqlCommand("INSERT INTO DOC_PDF_BASIC (CNO,DocNumber,DocVersion,FileName,FileDescription,pdffile,CreatorID,CreateDate) VALUES (@CNO,@DocNumber,@DocVersion,@FileName,@FileDescription,@pdffile,@CreatorID,@CreateDate) ", cn)
            Dim fs As New System.IO.FileStream(SourceFilePath & SourceFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim b(fs.Length() - 1) As Byte
            fs.Read(b, 0, b.Length)
            fs.Close()
            Dim CNO As New SqlParameter("@CNo", SqlDbType.NVarChar, 8, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
            Dim DocNumber As New SqlParameter("@DocNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyDocNumber)
            Dim DocVersion As New SqlParameter("@DocVersion", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyDocVersion)
            Dim FileName As New SqlParameter("@FileName", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, SourceFileName)
            Dim FileDescription As New SqlParameter("@FileDescription", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyFileDescription)
            Dim P As New SqlParameter("@pdffile", SqlDbType.Image, b.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, b)
            Dim CreatorID As New SqlParameter("@CreatorID", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
            Dim CreateTime As New SqlParameter("@CreateDate", SqlDbType.DateTime, 20, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Today())

            cmd.Parameters.Add(CNO)
            cmd.Parameters.Add(DocNumber)
            cmd.Parameters.Add(DocVersion)
            cmd.Parameters.Add(FileName)
            cmd.Parameters.Add(FileDescription)
            cmd.Parameters.Add(P)
            cmd.Parameters.Add(CreatorID)
            cmd.Parameters.Add(CreateTime)
            cn.Open()
            cmd.ExecuteNonQuery()
        Else
            Dim cmd As New SqlCommand("UPDATE DOC_PDF_BASIC SET pdffile=@pdffile,FileName=@FileName,DocNumber=@DocNumber WHERE CNO=@CNO  and FileDescription=@FileDescription and DocVersion=@DocVersion ", cn)

            Dim fs As New System.IO.FileStream(SourceFilePath & SourceFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            Dim b(fs.Length() - 1) As Byte
            fs.Read(b, 0, b.Length)
            fs.Close()
            Dim CNO As New SqlParameter("@CNo", SqlDbType.NVarChar, 8, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
            Dim DocNumber As New SqlParameter("@DocNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyDocNumber)
            Dim DocVersion As New SqlParameter("@DocVersion", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyDocVersion)
            Dim FileName As New SqlParameter("@FileName", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, SourceFileName)
            Dim FileDescription As New SqlParameter("@FileDescription", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyFileDescription)
            Dim P As New SqlParameter("@pdffile", SqlDbType.Image, b.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, b)

            cmd.Parameters.Add(CNO)
            cmd.Parameters.Add(DocNumber)
            cmd.Parameters.Add(DocVersion)
            cmd.Parameters.Add(FileName)
            cmd.Parameters.Add(FileDescription)
            cmd.Parameters.Add(P)
            cn.Open()
            cmd.ExecuteNonQuery()

            Try
                Dim OldPdfFileName As String = getresult.returnDataTable.Rows(0).Item("FileName").ToString.Trim

                System.IO.File.Delete(Server.MapPath("tmp/" + OldPdfFileName))
                '刪除原來上傳的PDF檔
            Catch ex As Exception

            End Try

        End If

        cn.Close()
    End Sub

    Public Function Upload(ByVal myFileUpload As DevExpress.Web.ASPxUploadControl) As Boolean
        '取得網站根目錄路徑
        Dim path As String = HttpContext.Current.Request.MapPath("~/PDFUPLOAD/SET/")
        Dim FileDescription As String
        Dim SavePDFFilName As String
        Dim TempDocVersion As String = Session("DOCVERSION")
        Dim MyDocNumber As String = TB_DocNumber.Text

        '檢查是否有檔案
        If (myFileUpload.HasFile) Then
            Try
                '儲存檔案到磁碟
                'If Right(myFileUpload.ClientID, 11) = "FileUpload1" Then
                'docindex = "1"
                'End If

                FileDescription = TB_DocNumber.Text + "_" + TB_FileName.Text


                SavePDFFilName = Session("CNO") + "_" + MyDocNumber + "_" + myFileUpload.FileName
                myFileUpload.SaveAs(path & SavePDFFilName)
                File2SqlBlob(path, SavePDFFilName, FileDescription, TempDocVersion)

                'Dim strScript_QryItem As String = "<script language=JavaScript> alert(""您已順利上傳" + SavePDFFilName + "檔案""); </script>"


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

    Protected Sub AUC_1_FileUploadComplete(sender As Object, e As FileUploadCompleteEventArgs) Handles AUC_1.FileUploadComplete

        Try

            Upload(AUC_1)

            'Dim strScript_QryItem As String = "<script language=JavaScript>window.location.reload();</script>"
            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_QryItem)

            Response.Write("<script>opener.window.location.href = opener.window.location.href;</script>")

        Catch ex As Exception

        End Try

    End Sub



    Protected Sub BT_LP_SAVE_Click(sender As Object, e As EventArgs) Handles BT_LP_SAVE.Click

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_LP] ([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE],  [ITEM1_DATE],  [ITEM3_DATE], [ITEM4_1_DATE], [ITEM4_2_DATE], [ITEM4_3_DATE], [ITEM4_4_DATE], [ITEM4_5_DATE], [NOTE], [C_ID], [C_DATE]) VALUES (@CNO, @DOCVERSION, @SETCOMPANY, @SETPEOPLE,  @ITEM1_DATE,  @ITEM3_DATE, @ITEM4_1_DATE, @ITEM4_2_DATE, @ITEM4_3_DATE, @ITEM4_4_DATE, @ITEM4_5_DATE, @NOTE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_LP] SET [SETCOMPANY] = @SETCOMPANY, [SETPEOPLE] = @SETPEOPLE,  [ITEM1_DATE] = @ITEM1_DATE,  [ITEM3_DATE] = @ITEM3_DATE, [ITEM4_1_DATE] = @ITEM4_1_DATE, [ITEM4_2_DATE] = @ITEM4_2_DATE, [ITEM4_3_DATE] = @ITEM4_3_DATE, [ITEM4_4_DATE] = @ITEM4_4_DATE, [ITEM4_5_DATE] = @ITEM4_5_DATE, [NOTE] = @NOTE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"


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
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("SETCOMPANY", TB_LP_SETCOMPANY.Text)
                    .InsertParameters.Add("SETPEOPLE", TB_LP_SETPEOPLE.Text)
                    '.InsertParameters.Add("TRANSTYPE", RBL_TRANS_TYPE.SelectedValue)
                    .InsertParameters.Add("ITEM1_DATE", TB_LP_DATE1.Text)
                    '.InsertParameters.Add("ITEM2_DATE", TB_LP_DATE2.Text)
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
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("SETCOMPANY", TB_LP_SETCOMPANY.Text)
                    .UpdateParameters.Add("SETPEOPLE", TB_LP_SETPEOPLE.Text)
                    '.UpdateParameters.Add("TRANSTYPE", RBL_TRANS_TYPE.SelectedValue)
                    .UpdateParameters.Add("ITEM1_DATE", TB_LP_DATE1.Text)
                    '.UpdateParameters.Add("ITEM2_DATE", TB_LP_DATE2.Text)
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
        e.NewValues("DOCVERSION") = Session("DOCVERSION")
    End Sub


    Private selectedValues As List(Of Object)

    Private Sub GetSelectedValues()
        Dim fieldNames As List(Of String) = New List(Of String)()
        For Each column As GridViewColumn In GV_SETITEM.Columns
            If TypeOf column Is GridViewDataColumn Then
                fieldNames.Add((CType(column, GridViewDataColumn)).FieldName)
            End If
        Next column
        selectedValues = GV_SETITEM.GetSelectedFieldValues(fieldNames.ToArray())
    End Sub



    Private Sub PrintSelectedValues()
        If selectedValues Is Nothing Then
            Return
        End If
        Dim result As String = ""
        For Each item As Object() In selectedValues
            For Each value As Object In item
                result &= String.Format("{0}    ", value)
            Next value
            result &= "</br>"
        Next item
        Literal1.Text = result
    End Sub

    Private Sub SetSpecItem()

        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempDocVersion As String = ""
        Dim tempDPTYPE As String = ""
        Dim strItem248, strItem259, strItem246, strItem247, strItem243, strItem210, strItem299, strItem330, strItem242 As String


        If selectedValues Is Nothing Then
            Return
        End If
        Dim result As String = ""
        For Each item As Object() In selectedValues
            For Each value As Object In item
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempDocVersion = item(2).ToString()
                tempDPTYPE = item(14).ToString()
                strItem248 = item(4).ToString()
                strItem259 = item(5).ToString()
                strItem246 = item(6).ToString()
                strItem247 = item(7).ToString()
                strItem243 = item(8).ToString()
                strItem242 = item(11).ToString()
                strItem210 = item(9).ToString()
                strItem299 = item(13).ToString()
                strItem330 = item(10).ToString()
            Next value
        Next item

        If strItem248 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "248", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "248", tempDocVersion, tempDPTYPE)

        End If
        If strItem259 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "259", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "259", tempDocVersion, tempDPTYPE)
        End If
        If strItem246 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "246", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "246", tempDocVersion, tempDPTYPE)
        End If
        If strItem247 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "247", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "247", tempDocVersion, tempDPTYPE)
        End If
        If strItem243 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "243", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "243", tempDocVersion, tempDPTYPE)
        End If

        If strItem242 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "242", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "242", tempDocVersion, tempDPTYPE)
        End If

        If strItem210 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "210", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "210", tempDocVersion, tempDPTYPE)
        End If

        If strItem299 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "299", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "299", tempDocVersion, tempDPTYPE)
        End If

        If strItem330 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "330", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "330", tempDocVersion, tempDPTYPE)
        End If

    End Sub

    Public Shared Function CopySpecItemStatus(ByVal MyDocType As String, ByVal MyCNO As String, ByVal MyDPNO As String, ByVal MyItem As String, ByVal MyDocVersion As String, ByVal MyDPTYPE As String) As String

        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "INSERT INTO  DOC_SET_SPEC (CNO,DPTYPE,DP_NO,DOCVERSION,ITEM ) VALUES ('" + Trim(MyCNO) + "' ,'" + MyDPTYPE + "','" + Trim(MyDPNO) + "','" + MyDocVersion + "','" + MyItem + "')"
        Else
            Sqlstr = "INSERT INTO  DOC_VRY_SPEC (CNO,DPTYPE,DP_NO,DOCVERSION,ITEM ) VALUES ('" + Trim(MyCNO) + "' ,'" + MyDPTYPE + "','" + Trim(MyDPNO) + "','" + MyDocVersion + "','" + MyItem + "')"
        End If


        Try

            getresult = EIPDB.Execute(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                CopySpecItemStatus = "TRUE"
            Else
                CopySpecItemStatus = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return CopySpecItemStatus


    End Function

    Public Shared Function EraseSpecItemStatus(ByVal MyDocType As String, ByVal MyCNO As String, ByVal MyDPNO As String, ByVal MyItem As String, ByVal MyDocVersion As String, ByVal MyDPTYPE As String) As String

        Dim getresult As DbResult
        Dim Sqlstr As String = ""
        Dim SqlstrPDF As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "DELETE FROM  DOC_SET_SPEC WHERE CNO='" + Trim(MyCNO) + "' AND DPTYPE='" + MyDPTYPE + "' AND DP_NO='" + Trim(MyDPNO) + "' AND DOCVERSION='" + MyDocVersion + "' AND ITEM='" + MyItem + "' "
            SqlstrPDF = "DELETE FROM  DOC_PDF_PDFUPload  WHERE CNO='" + Trim(MyCNO) + "' AND  DP_NO='" + Trim(MyDPNO) + "' AND DOCVERSION='" + MyDocVersion + "' AND left(DocIndex,3)='" + MyItem + "' "
        Else
            Sqlstr = "DELETE FROM  DOC_VRY_SPEC WHERE CNO='" + Trim(MyCNO) + "' AND DPTYPE='" + MyDPTYPE + "' AND DP_NO='" + Trim(MyDPNO) + "' AND DOCVERSION='" + MyDocVersion + "' AND ITEM='" + MyItem + "' "
            SqlstrPDF = "DELETE FROM  DOC_VRY_PDFUPload  WHERE CNO='" + Trim(MyCNO) + "' AND  DP_NO='" + Trim(MyDPNO) + "' AND DOCVERSION='" + MyDocVersion + "' AND left(DocIndex,3)='" + MyItem + "' "
        End If


        Try

            getresult = EIPDB.Execute(Sqlstr)
            getresult = EIPDB.Execute(SqlstrPDF)

            If getresult.returnDataTable.Rows.Count > 0 Then
                EraseSpecItemStatus = "TRUE"
            Else
                EraseSpecItemStatus = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return EraseSpecItemStatus


    End Function



    Protected Sub ASPxButton8_Click(sender As Object, e As EventArgs) Handles ASPxButton8.Click

        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempDocVersion As String = ""
        Dim tempSetType As String = "設置"
        Dim strItem241 As String = "241"
        Dim strItem267 As String = "267"

        'Check  是否已存在

        If tempSetType = "設置" Then

            GetSelectedValues()
            PrintSelectedValues()


            For Each item As Object() In selectedValues
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempDocVersion = item(2).ToString()

                Session("DP_NO") = tempdpno
                Session("DOCVERSION") = tempDocVersion

            Next item

            Dim getresult As DbResult
            Dim Sqlstr As String = ""

            Sqlstr = "select * from DOC_SET_SPEC where cno='" + Session("CNO") + "' and dp_no='" + tempdpno + "' and docversion='" + tempDocVersion + "' and item not in ('" + strItem241 + "','" + strItem267 + "')"

            Try

                getresult = EIPDB.GetData(Sqlstr)

                If getresult.ReturnCode = -1 Then
                    SetSpecItem()
                Else
                    If getresult.returnDataTable.Rows.Count = 0 Then

                        SetSpecItem()

                    End If
                End If


            Catch ex As Exception

            End Try


        Else

            PrintSelectedValues()
            SetSpecItem()
            For Each item As Object() In selectedValues
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempDocVersion = item(2).ToString()

                Session("DP_NO") = tempdpno
                Session("DOCVERSION") = tempDocVersion

            Next item
        End If
    End Sub


    Protected Sub ASPxPageControl1_ActiveTabChanged(source As Object, e As TabControlEventArgs) Handles ASPxPageControl1.ActiveTabChanged

        'Dim strScript_QryItem As String = "<script language=JavaScript> alert(""請先於基本資料頁面選擇[監測位置]""); </script>"

        Dim strDPNO As String = Session("DP_NO")
        Dim strCNO As String = Session("CNO")
        Dim strVersion As String = Session("DOCVERSION")
        Dim strDOCTYPE As String = Session("DOCTYPE")

        'If strDPNO = "" Then
        'If ASPxPageControl1.ActiveTabIndex = 1 Then
        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_QryItem)
        'ASPxPageControl1.ActiveTabIndex = 0
        'End If
        'End If

        GV_SETITEM.DataBind()
        GV_SPEC.DataBind()
        GV_ITEM_SELF.DataBind()
        GV_SPEC_SELF.DataBind()

    End Sub


    Public Function EraseUploadPDF(ByVal MyFileDescription As String) As Boolean

        Dim TempCno, TempDocVersion As String
        Dim MyDocNumber As String = TB_DocNumber.Text

        TempCno = Session("CNO")
        TempDocVersion = Session("DOCVERSION")

        Dim cn As New SqlConnection(DBconntext)


        Try
            Dim cmd As New SqlCommand("delete from DOC_PDF_BASIC where CNO=@CNO and  DocVersion=@DocVersion AND DocNumber=@DocNumber ", cn)
            Dim CNO As New SqlParameter("@CNo", SqlDbType.NVarChar, 8, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, TempCno)
            Dim DocVersion As New SqlParameter("@DocVersion", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, TempDocVersion)
            Dim DocNumber As New SqlParameter("@DocNumber", SqlDbType.NVarChar, 20, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyDocNumber)
            Dim FileDescription As New SqlParameter("@FileDescription", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyFileDescription)
            cmd.Parameters.Add(CNO)
            cmd.Parameters.Add(DocVersion)
            cmd.Parameters.Add(DocNumber)
            cmd.Parameters.Add(FileDescription)
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

            EraseUploadPDF = True
        Catch ex As Exception
            EraseUploadPDF = False
        End Try

    End Function


    Public Function DownLoadPDF(ByVal TempDocVersion As String) As String

        Dim TempCno As String
        Dim getresult As DbResult
        Dim sqlstr As String = ""
        Dim MyDocNumber As String = TB_DocNumber.Text
        Dim FileName As String

        TempCno = Session("CNO")
        TempDocVersion = Session("DOCVERSION")


        sqlstr = "Select pdffile from DOC_PDF_BASIC where DocNumber='" + MyDocNumber + "' and cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"


        'Dim Sqlstr As String = "Select pdffile from DOC_SET_PDFUPload where docindex='" + MyDocIndex + "' and cno='" + TempCno + "' and DP_NO='" + TempDP_NO + "' and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(sqlstr)

            If getresult.ReturnCode >= 1 Then

                If Right(FileName, 3) = "jpg" Then
                    Dim temp() As Byte
                    temp = getresult.returnDataTable.Rows(0).Item("pdffile")
                    Response.Clear()
                    Response.AddHeader("Content-Disposition", "attachment;filename=attach.jpg")
                    Response.ContentType = "application/octet-stream"
                    Response.OutputStream.Write(temp, 0, temp.Count)
                    Response.OutputStream.Flush()
                    Response.OutputStream.Close()
                    'Response.Flush()
                    Response.End()
                Else
                    Dim temp() As Byte
                    temp = getresult.returnDataTable.Rows(0).Item("pdffile")
                    Response.Clear()
                    Response.AddHeader("Content-Disposition", "attachment;filename=attach.pdf")
                    Response.ContentType = "application/octet-stream"
                    Response.OutputStream.Write(temp, 0, temp.Count)
                    Response.OutputStream.Flush()
                    Response.OutputStream.Close()
                    'Response.Flush()
                    Response.End()
                End If

            Else

                DownLoadPDF = "無檔案"

            End If

        Catch ex As Exception


        End Try

    End Function


    Protected Sub BT_AUC1_Click(sender As Object, e As EventArgs) Handles BT_AUC1.Click

        Dim strScript_Error As String = "<script language=JavaScript> alert(""請填入附件編號...""); </script>"

        Try
            If TB_DocNumber.Text = "" Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
                Exit Sub
            Else
                DownLoadPDF("AUC_1")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub BT_DEL_AUC1_Click(sender As Object, e As EventArgs) Handles BT_DEL_AUC1.Click

        Dim strScript_Error As String = "<script language=JavaScript> alert(""請填入附件編號...""); </script>"
        Try
            If TB_DocNumber.Text = "" Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
                Exit Sub
            ElseIf EraseUploadPDF("AUC_1") Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_EraseUploadSuccess)
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_EraseUploadFail)
            End If
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub BT_LED_SAVE_Click(sender As Object, e As EventArgs) Handles BT_LED_SAVE.Click

        'LED 

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_LED] ([CNO], [DP_NO], [DOCVERSION], [LED_INSTALL], [LED_INSTALL_REASON], [LED_PLAN_DATE], [LED_FACTORY], [LED_MODEL], [LED_SERIAL], [LED_TYPE], [LED_TYPE_OTHER], [LED_INSTALLPOS], [LED_INSTALLPOS_REASON], [LED_SHOWITEM], [LED_SHOWITEM_REASON], [LED_FORMAT], [LED_FORMAT_REASON], [LED_FREQ], [LED_FAIL_INSTEAD],[LED_CONTENT], [C_ID], [C_DATE]) VALUES (@CNO, @DP_NO, @DOCVERSION, @LED_INSTALL, @LED_INSTALL_REASON, @LED_PLAN_DATE, @LED_FACTORY, @LED_MODEL, @LED_SERIAL, @LED_TYPE, @LED_TYPE_OTHER, @LED_INSTALLPOS, @LED_INSTALLPOS_REASON, @LED_SHOWITEM, @LED_SHOWITEM_REASON, @LED_FORMAT, @LED_FORMAT_REASON, @LED_FREQ, @LED_FAIL_INSTEAD,@LED_CONTENT, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_LED] SET [LED_INSTALL] = @LED_INSTALL, [LED_INSTALL_REASON] = @LED_INSTALL_REASON, [LED_PLAN_DATE] = @LED_PLAN_DATE, [LED_FACTORY] = @LED_FACTORY, [LED_MODEL] = @LED_MODEL, [LED_SERIAL] = @LED_SERIAL, [LED_TYPE] = @LED_TYPE, [LED_TYPE_OTHER] = @LED_TYPE_OTHER, [LED_INSTALLPOS] = @LED_INSTALLPOS, [LED_INSTALLPOS_REASON] = @LED_INSTALLPOS_REASON, [LED_SHOWITEM] = @LED_SHOWITEM, [LED_SHOWITEM_REASON] = @LED_SHOWITEM_REASON, [LED_FORMAT] = @LED_FORMAT, [LED_FORMAT_REASON] = @LED_FORMAT_REASON, [LED_FREQ] = @LED_FREQ, [LED_FAIL_INSTEAD] = @LED_FAIL_INSTEAD,LED_CONTENT=@LED_CONTENT, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DOCVERSION] = @DOCVERSION"
        Dim InsertSQL_PDF As String = "INSERT INTO [DOC_SET_PDF] ([CNO], [DOCVERSION], [DDL5112A], [DDL5112B], [DDL52], [DDL53], [CreatorID], [CreateDate]) VALUES (@CNO, @DOCVERSION, @DDL5112A, @DDL5112B, @DDL52, @DDL53, @CreatorID, @CreateDate)"
        Dim UpdateSQL_PDF As String = "UPDATE [DOC_SET_PDF] SET [DDL5112A] = @DDL5112A, [DDL5112B] = @DDL5112B, [DDL52] = @DDL52, [DDL53] = @DDL53, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Dim SDS_PlanPolFeature_PDF As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature_PDF.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_LED where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

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
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DP_NO", TB_LED_DP_NO.Text)
                    .InsertParameters.Add("LED_INSTALL", RBL_LED_INSTALL.SelectedValue.ToString)
                    .InsertParameters.Add("LED_INSTALL_REASON", "")
                    .InsertParameters.Add("LED_PLAN_DATE", TB_LED_PLAN_DATE.Text)
                    .InsertParameters.Add("LED_FACTORY", TB_LED_FACTORY.Text)
                    .InsertParameters.Add("LED_MODEL", TB_LED_MODEL.Text)
                    .InsertParameters.Add("LED_SERIAL", TB_LED_SERIAL.Text)
                    .InsertParameters.Add("LED_TYPE", RBL_LED_TYPE.SelectedValue.ToString)
                    .InsertParameters.Add("LED_TYPE_OTHER", "")
                    .InsertParameters.Add("LED_INSTALLPOS", RBL_LED_INSTALLPOS.SelectedValue.ToString)
                    .InsertParameters.Add("LED_INSTALLPOS_REASON", "")
                    .InsertParameters.Add("LED_SHOWITEM", RBL_LED_SHOWITEM.SelectedValue.ToString)
                    .InsertParameters.Add("LED_SHOWITEM_REASON", "")
                    .InsertParameters.Add("LED_FORMAT", RBL_LED_FORMAT.SelectedValue.ToString)
                    .InsertParameters.Add("LED_FORMAT_REASON", "")
                    .InsertParameters.Add("LED_FREQ", RBL_LED_FREQ.SelectedValue.ToString)
                    .InsertParameters.Add("LED_FAIL_INSTEAD", "")
                    .InsertParameters.Add("LED_CONTENT", RBL_LED_Content.SelectedValue.ToString)
                    .InsertParameters.Add("C_ID", Session("UserName"))
                    .InsertParameters.Add("C_DATE", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        Label_LED.Text = "資料新增失敗!"
                    Else
                        Label_LED.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_LED.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_LED.Text = ex.Message.ToString
            End Try


        Else

            'Update 
            Try

                With SDS_PlanPolFeature

                    .UpdateParameters.Add("CNo", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DP_NO", TB_LED_DP_NO.Text)
                    .UpdateParameters.Add("LED_INSTALL", RBL_LED_INSTALL.SelectedValue.ToString)
                    .UpdateParameters.Add("LED_INSTALL_REASON", "")
                    .UpdateParameters.Add("LED_PLAN_DATE", TB_LED_PLAN_DATE.Text)
                    .UpdateParameters.Add("LED_FACTORY", TB_LED_FACTORY.Text)
                    .UpdateParameters.Add("LED_MODEL", TB_LED_MODEL.Text)
                    .UpdateParameters.Add("LED_SERIAL", TB_LED_SERIAL.Text)
                    .UpdateParameters.Add("LED_TYPE", RBL_LED_TYPE.SelectedValue.ToString)
                    .UpdateParameters.Add("LED_TYPE_OTHER", "")
                    .UpdateParameters.Add("LED_INSTALLPOS", RBL_LED_INSTALLPOS.SelectedValue.ToString)
                    .UpdateParameters.Add("LED_INSTALLPOS_REASON", "")
                    .UpdateParameters.Add("LED_SHOWITEM", RBL_LED_SHOWITEM.SelectedValue.ToString)
                    .UpdateParameters.Add("LED_SHOWITEM_REASON", "")
                    .UpdateParameters.Add("LED_FORMAT", RBL_LED_FORMAT.SelectedValue.ToString)
                    .UpdateParameters.Add("LED_FORMAT_REASON", "")
                    .UpdateParameters.Add("LED_FREQ", RBL_LED_FREQ.SelectedValue.ToString)
                    .UpdateParameters.Add("LED_FAIL_INSTEAD", "")
                    .UpdateParameters.Add("LED_CONTENT", RBL_LED_Content.SelectedValue.ToString)
                    .UpdateParameters.Add("U_ID", Session("UserName"))
                    .UpdateParameters.Add("U_Date", Today())
                    .UpdateCommand = UpdateSQL

                    aff_row = .Update()

                    If aff_row = 0 Then
                        Label_LED.Text = "資料更新失敗!"
                    Else
                        Label_LED.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_LED.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_LED.Text = ex.Message.ToString
            End Try
        End If

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try


        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature_PDF

                    .InsertParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DDL5112A", DDL5112A.SelectedValue.ToString)
                    .InsertParameters.Add("DDL5112B", DDL5112B.SelectedValue.ToString)
                    .InsertParameters.Add("DDL52", DDL52.SelectedValue.ToString)
                    .InsertParameters.Add("DDL53", DDL53.SelectedValue.ToString)
                    .InsertParameters.Add("CreatorID", Session("UserName"))
                    .InsertParameters.Add("CreateDate", Today())
                    .InsertCommand = InsertSQL_PDF

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        Label_LED.Text = "資料新增失敗!"
                    Else
                        Label_LED.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_LED.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_LED.Text = ex.Message.ToString
            End Try

        Else

            'Update 
            Try

                With SDS_PlanPolFeature_PDF

                    .UpdateParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DDL5112A", DDL5112A.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL5112B", DDL5112B.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL52", DDL52.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL53", DDL53.SelectedValue.ToString)
                    .UpdateParameters.Add("ModifyID", Session("UserName"))
                    .UpdateParameters.Add("ModifyDate", Today())
                    .UpdateCommand = UpdateSQL_PDF

                    aff_row = .Update()

                    If aff_row = 0 Then
                        Label_LED.Text = "資料更新失敗!"
                    Else
                        Label_LED.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_LED.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_LED.Text = ex.Message.ToString
            End Try

        End If

        SDS_PlanPolFeature.Dispose()
        SDS_PlanPolFeature_PDF.Dispose()

    End Sub

    Public Shared Function GetCaseExamStatus(ByVal MyCno As String, ByVal MyDocVersion As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try
            Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='措施說明書' and  cno='" + Trim(MyCno) + "' and docversion='" + MyDocVersion + "'"
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetCaseExamStatus = getresult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
            Else
                GetCaseExamStatus = "FALSE"

            End If

        Catch ex As Exception
            GetCaseExamStatus = "FALSE"
        End Try

        Return GetCaseExamStatus
    End Function

    Public Shared Function GetCaseStatus(ByVal MyConnString As String, ByVal MyCno As String, ByVal MyDocVersion As String) As Boolean
        Dim getresult As DbResult
        Dim Sqlstr As String = ""


        Try

            Sqlstr = "Select *  from DAHS_EXAMLIST where EXAM_RESULT in ('已送未審','審查中') and  cno='" + Trim(MyCno) + "' and docversion='" + MyDocVersion + "'"

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetCaseStatus = "True"
            Else
                GetCaseStatus = "FALSE"

            End If

        Catch ex As Exception
            GetCaseStatus = "FALSE"
        End Try

        Return GetCaseStatus
    End Function



    Public Shared Function GetDS(ByVal MyConnString As String, ByVal MySqlTxt As String) As DataSet
        Dim Ds As New DataSet

        Try
            Using Conn As New SqlConnection(MyConnString)

                MySqlTxt = MySqlTxt
                Dim Cmmd As New SqlCommand(MySqlTxt, Conn)
                Dim Da As New SqlDataAdapter(Cmmd)
                Da.Fill(Ds)

            End Using

        Catch ex As Exception
            'strErr = ex.Message

        End Try
        Return Ds
    End Function


    Protected Sub AuditHelper(ByVal strCno As String, ByVal strDocversion As String)


        'delete 原先建議的資料

        Try

            EraseAuditHelp(strCno, strDocversion)

        Catch ex As Exception

        End Try


        'check doc rule

        Dim getresult As DbResult
        Dim getItemResult As DbResult
        Dim getSpecResult As DbResult

        Dim strSQL As String = ""
        Dim strItemSQL As String = ""
        Dim strSpecSQL As String = ""


        strSQL = "select * from DOC_SET_FACTORY where cno='" + strCno + "' and docversion='" + strDocversion + "'"
        strItemSQL = "select * from DOC_SET_ITEM where cno='" + strCno + "' and docversion='" + strDocversion + "'"
        strSpecSQL = "select * from DOC_SET_SPEC where cno='" + strCno + "' and docversion='" + strDocversion + "'"

        getresult = EIPDB.GetData(strSQL)
        getItemResult = EIPDB.GetData(strItemSQL)
        getSpecResult = EIPDB.GetData(strSpecSQL)



        'check rule 1

        If getresult.returnDataTable.Rows(0).Item("TYPE").ToString = "污水下水道系統" Then

            If getresult.returnDataTable.Rows(0).Item("PERMIT_VOL").ToString >= "1500" Then

                If getresult.returnDataTable.Rows(0).Item("RULE_1500_I").ToString >= "False" Then
                    InsertAuditResult(strCno, strDocversion, "設置依據", "ERROR", "應勾選「許可核准排放量達每日1,500CMD以上工業區專用污水下水道系統」")
                End If

            End If

        Else
            If getresult.returnDataTable.Rows(0).Item("PERMIT_VOL").ToString >= "1500" And getresult.returnDataTable.Rows(0).Item("PERMIT_VOL").ToString < "5000" Then

                If getresult.returnDataTable.Rows(0).Item("RULE_1500_BUSSINESS").ToString = "False" Then
                    InsertAuditResult(strCno, strDocversion, "設置依據", "ERROR", "應勾選「許可核准排放量達每日1,500CMD以上、未達5,000CMD事業」")
                End If

            ElseIf getresult.returnDataTable.Rows(0).Item("PERMIT_VOL").ToString >= "5000" Then

                If getresult.returnDataTable.Rows(0).Item("RULE_5000_BUSSINESS").ToString = "False" Then
                    InsertAuditResult(strCno, strDocversion, "設置依據", "ERROR", "應勾選「許可核准排放量達每日5,000CMD以上事業」")
                End If
            Else

            End If

        End If

        'check rule 2

        If getresult.returnDataTable.Rows(0).Item("RULE_31").ToString = "True" Then

            If getItemResult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "放流口" Then

                If getItemResult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第31條", "ERROR", "應勾選水量")

                End If

            End If

        End If

        'If getresult.returnDataTable.Rows(0).Item("RULE_56").ToString = "True" Then

        '    If getItemResult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "用水來源" Then

        '        InsertAuditResult(strCno, strDocversion, "第56條", "ERROR", "應填寫用水來源")

        '    ElseIf getItemResult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "電子式電度表" Then

        '        InsertAuditResult(strCno, strDocversion, "第56條", "ERROR", "應填寫電子式電度表")

        '    ElseIf getItemResult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "處理單元(進流或出流)" Then

        '        InsertAuditResult(strCno, strDocversion, "第56條", "ERROR", "應勾選水溫、pH及導電度")

        '    ElseIf getItemResult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "放流口/排放口" Then

        '        InsertAuditResult(strCno, strDocversion, "第56條", "ERROR", "應勾選水量、水溫、pH及導電度")

        '    End If

        'End If

        If getresult.returnDataTable.Rows(0).Item("RULE_105").ToString = "True" Then

            If getItemResult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "進流處" Then

                If getItemResult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之工業區", "ERROR", "應勾選水量")

                End If

            ElseIf getItemResult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "放流口" Then

                If getItemResult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之工業區", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

                ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_259").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之工業區", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

                ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_246").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之工業區", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

                ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_247").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之工業區", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

                ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_243").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之工業區", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

                ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_210").ToString = "NULL" Then

                End If

            End If

        End If

        If getresult.returnDataTable.Rows(0).Item("RULE_1500_BUSSINESS").ToString = "True" Then
            If getItemResult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "放流口" Then

                If getItemResult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且1,500~5000）", "ERROR", "應勾選水量、水溫、pH及導電度")

                ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_259").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且1,500~5000）", "ERROR", "應勾選水量、水溫、pH及導電度")

                ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_246").ToString = "NULL" Then

                    InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且1,500~5000）", "ERROR", "應勾選水量、水溫、pH及導電度")

                ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_247").ToString = "NULL" Then

                End If
            End If
        End If

        If getresult.returnDataTable.Rows(0).Item("RULE_5000_BUSSINESS").ToString = "True" Then

            If getItemResult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "NULL" Then

                InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且≥5,000）", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

            ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_259").ToString = "NULL" Then

                InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且≥5,000）", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

            ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_246").ToString = "NULL" Then

                InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且≥5,000）", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

            ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_247").ToString = "NULL" Then

                InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且≥5,000）", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

            ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_243").ToString = "NULL" Then

                InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且≥5,000）", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

            ElseIf getItemResult.returnDataTable.Rows(0).Item("ITEM_210").ToString = "NULL" Then

                InsertAuditResult(strCno, strDocversion, "第105條之事業（發電廠之外且≥5,000）", "ERROR", "應勾選水量、水溫、pH、導電度、COD、SS及攝錄影監視")

            End If

        End If

        'Check Rule 3

        If getresult.returnDataTable.Rows(0).Item("RULE_56").ToString = "True" Then

            If getresult.returnDataTable.Rows(0).Item("CWMS_LINK").ToString = "" Then

                InsertAuditResult(strCno, strDocversion, "設置依據為第56條者應設置", "ERROR", "應勾選連線傳輸設施")

            End If

        End If

        If getresult.returnDataTable.Rows(0).Item("RULE_57_1").ToString = "True" Then

            If getresult.returnDataTable.Rows(0).Item("CWMS_LINK").ToString = "" Then

                InsertAuditResult(strCno, strDocversion, "設置依據為第57-1條者應設置", "ERROR", "應勾選連線傳輸設施")

            End If

        End If

        If getresult.returnDataTable.Rows(0).Item("RULE_5000_BUSSINESS").ToString = "True" Then

            If getresult.returnDataTable.Rows(0).Item("CWMS_LINK").ToString = "" Then

                InsertAuditResult(strCno, strDocversion, "設置依據為第105條之工業區、發電廠及發電廠之外事業且≥5,000者應設置", "ERROR", "應勾選連線傳輸設施")

            End If

        End If


        If getresult.returnDataTable.Rows(0).Item("RULE_1500_BUSSINESS").ToString = "True" Then

            If getresult.returnDataTable.Rows(0).Item("CWMS_LED").ToString = "" Then

                InsertAuditResult(strCno, strDocversion, "設置依據為第105條發電廠之外事業且1,500~5000，未設置連線傳輸設施者，應設置自動顯示看板", "ERROR", "應勾選自動顯示看板")

            End If

        End If

        'Check rule 4


        'Check rule 5

        'Check rule 6

    End Sub

    Private Sub InsertAuditResult(ByVal strCNO As String, ByVal strDocversion As String, ByVal strRule As String, ByVal a_result As String, ByVal recom_rule As String)

        Dim getresult As DbResult
        Dim InsertSQL As String = "insert into doc_checkresult (cno,docversion,checktime,audit_rule,audit_result,recommand_rule) values('" + strCNO + "','" + strDocversion + "','" + Now.Date.ToLocalTime.ToShortDateString + "','" + strRule + "','" + a_result + "','" + recom_rule + "')"

        getresult = EIPDB.Execute(InsertSQL)

    End Sub



    Protected Sub BT_AuditAsst_Click(sender As Object, e As EventArgs) Handles BT_AuditAsst.Click

        Try
            AuditHelper(Session("CNO"), Session("DOCVERSION"))
            Server.Transfer("AuditHelper.aspx")
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub BT_Audit1_Click(sender As Object, e As EventArgs) Handles BT_Audit1.Click
        Dim strDocVersion As String = ""
        Dim strScript_QryItem As String = "<script language=JavaScript> alert(""您尚未填寫審查內容!""); </script>"
        Dim strScript_SelItem As String = "<script language=JavaScript> alert(""您尚未勾選審查結果!""); </script>"
        Dim strScript_Error As String = "<script language=JavaScript> alert(""審查結果為須補正時應填入補正期限...""); </script>"
        Dim strScript_ErrorOwnerName As String = "<script language=JavaScript> alert(""取得審查人員資訊錯誤!""); </script>"


        strDocVersion = Session("DOCVERSION")
        GetCaseMailList(Session("CNO"), Session("DOCVERSION"), Session("DOCTYPE"))

        If RBL_AuditResult.Text = "須補正" Then

            If TB_Audit_DATE.Text = "" Then

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
                Exit Sub

            End If
        End If

        If RBL_AuditResult.Text = "" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_SelItem)
            Exit Sub
        End If

        If TB_AuditMemo.Text.Length = 0 Then
            '沒寫審查意見跳出
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_QryItem)
            Exit Sub
        Else

            'Dim strOwnerName As String = GetOwnerName(Session("UserName"))
            Dim strOwnerName As String = Session("OWNER").ToString.Trim


            If strOwnerName = "" Then

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_ErrorOwnerName)

                Exit Sub

            End If


            If RBL_AuditResult.Text = "審查通過" Then


                If strDocVersion > "1" Then

                    UpdateDahsMainMode("措施說明書", "審查通過", Session("CNO"), Session("DOCVERSION"), strOwnerName, Today)
                    InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "審查通過", TB_AuditMemo.Text, Session("UserName"), Today)
                    InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "審查通過", Session("UserName"))
                    Session("ExamPassDate") = Today.Date.ToShortDateString
                    Session("MAILTYPE") = "變更審查通過(第二階段)"
                Else
                    UpdateDahsMainMode("措施說明書", "審查通過", Session("CNO"), Session("DOCVERSION"), strOwnerName, Today)
                    InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "審查通過", TB_AuditMemo.Text, Session("UserName"), Today)
                    InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "審查通過", Session("UserName"))
                    Session("ExamPassDate") = Today.Date.ToShortDateString
                    Session("MAILTYPE") = "申請審查通過"
                End If


            ElseIf RBL_AuditResult.Text = "須補正" Then

                UpdateDahsMainMode("措施說明書", "補正中", Session("CNO"), Session("DOCVERSION"), strOwnerName, TB_Audit_DATE.Date)
                InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "須補正", TB_AuditMemo.Text, Session("UserName"), TB_Audit_DATE.Date)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "須補正", Session("UserName"))
                Session("MAILTYPE") = "須補正"
                Session("DOCFIXDATE") = TB_Audit_DATE.Date.ToShortDateString

            ElseIf RBL_AuditResult.Text = "駁回" Then

                UpdateDahsMainMode("措施說明書", "駁回", Session("CNO"), Session("DOCVERSION"), strOwnerName, Today)
                InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "駁回", TB_AuditMemo.Text, Session("UserName"), Today)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "駁回", Session("UserName"))
                Session("MAILTYPE") = "駁回"
                Session("ExamPassDate") = Today.Date.ToShortDateString

            ElseIf RBL_AuditResult.Text = "不適用" Then

                UpdateDahsMainMode("措施說明書", "不適用", Session("CNO"), Session("DOCVERSION"), strOwnerName, Today)
                InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "不適用", TB_AuditMemo.Text, Session("UserName"), Today)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "不適用", Session("UserName"))
                Session("MAILTYPE") = "不適用"
                Session("ExamPassDate") = Today.Date.ToShortDateString

            End If

            Try
                Server.Transfer("EpbNotifyMessage.aspx")
            Catch ex As Exception

            End Try
        End If

    End Sub

    Public Shared Function UpdateDahsMainMode(ByVal strDocType As String, ByVal strExamResult As String, ByVal strCno As String, ByVal strDocVersion As String, ByVal strOWNER As String, ByVal strEXAM_DOCOUT_DATE As String) As String

        Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim commandtext As String = ""

        If strExamResult = "補正中" Then
            commandtext = "Update [DAHS_ExamList] set EXAM_RESULT=@EXAM_RESULT,OWNER=@OWNER,UPGRADE_DATE=@UPGRADE_DATE  where CNO=@CNO and DOCVERSION=@DOCVERSION and DOCTYPE=@DOCTYPE "
            Try
                Using connection As New SqlConnection(DBconntext)
                    Dim command As New SqlCommand(commandtext, connection)
                    command.Parameters.Add("@CNO", SqlDbType.Char)
                    command.Parameters("@CNO").Value = strCno
                    command.Parameters.Add("@DOCVERSION", SqlDbType.Char)
                    command.Parameters("@DOCVERSION").Value = strDocVersion

                    command.Parameters.Add("@OWNER", SqlDbType.Char)
                    command.Parameters("@OWNER").Value = strOWNER

                    command.Parameters.Add("@DOCTYPE", SqlDbType.Char)
                    command.Parameters("@DOCTYPE").Value = strDocType

                    command.Parameters.Add("@UPGRADE_DATE", SqlDbType.Char)
                    command.Parameters("@UPGRADE_DATE").Value = strEXAM_DOCOUT_DATE

                    command.Parameters.Add("@EXAM_RESULT", SqlDbType.Char)
                    command.Parameters("@EXAM_RESULT").Value = strExamResult

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Console.WriteLine("RowsAffected: {0}", rowsAffected)
                    InsertTranxRecord(strCno, strDocVersion, "措施說明書", strExamResult, strOWNER)
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Else

            commandtext = "Update [DAHS_ExamList] set EXAM_RESULT=@EXAM_RESULT,OWNER=@OWNER,EXAM_DOCOUT_DATE=@EXAM_DOCOUT_DATE  where CNO=@CNO and DOCVERSION=@DOCVERSION  and DOCTYPE=@DOCTYPE "
            Try
                Using connection As New SqlConnection(DBconntext)
                    Dim command As New SqlCommand(commandtext, connection)
                    command.Parameters.Add("@CNO", SqlDbType.Char)
                    command.Parameters("@CNO").Value = strCno
                    command.Parameters.Add("@DOCVERSION", SqlDbType.Char)
                    command.Parameters("@DOCVERSION").Value = strDocVersion

                    command.Parameters.Add("@OWNER", SqlDbType.Char)
                    command.Parameters("@OWNER").Value = strOWNER

                    command.Parameters.Add("@DOCTYPE", SqlDbType.Char)
                    command.Parameters("@DOCTYPE").Value = strDocType

                    command.Parameters.Add("@EXAM_DOCOUT_DATE", SqlDbType.Char)
                    command.Parameters("@EXAM_DOCOUT_DATE").Value = strEXAM_DOCOUT_DATE

                    command.Parameters.Add("@EXAM_RESULT", SqlDbType.Char)
                    command.Parameters("@EXAM_RESULT").Value = strExamResult

                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Console.WriteLine("RowsAffected: {0}", rowsAffected)
                    InsertTranxRecord(strCno, strDocVersion, "措施說明書", strExamResult, strOWNER)
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End If



    End Function

    Public Shared Function InsertTranxRecord(ByVal MyCno As String, ByVal MyDocVersion As String, ByVal MyDocType As String, ByVal MyDocTranxType As String, ByVal MySendUser As String) As String

        '文件在送審、審核、退回、補送各種動作皆會列入交易紀錄

        Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim commandtext As String = ""

        commandtext = " INSERT INTO [dbo].[DAHS_TransRecord] ([CNO],[DOCVERSION],[DOCTYPE],[SENDTYPE],[DOCDATE],[SENDUSER],[SENDDATE]) VALUES (@CNO,@DOCVERSION,@DOCTYPE,@SENDTYPE,@DOCDATE,@SENDUSER,@SENDDATE) "


        Try
            Using connection As New SqlConnection(DBconntext)

                Dim command As New SqlCommand(commandtext, connection)
                command.Parameters.Add("@CNO", SqlDbType.Char)
                command.Parameters("@CNO").Value = MyCno
                command.Parameters.Add("@DOCVERSION", SqlDbType.Char)
                command.Parameters("@DOCVERSION").Value = MyDocVersion
                command.Parameters.Add("@DOCTYPE", SqlDbType.Char)
                command.Parameters("@DOCTYPE").Value = MyDocType
                command.Parameters.Add("@SENDTYPE", SqlDbType.Char)
                command.Parameters("@SENDTYPE").Value = MyDocTranxType
                command.Parameters.Add("@DOCDATE", SqlDbType.DateTime)
                command.Parameters("@DOCDATE").Value = Now
                command.Parameters.Add("@SENDUSER", SqlDbType.Char)
                command.Parameters("@SENDUSER").Value = MySendUser
                command.Parameters.Add("@SENDDATE", SqlDbType.DateTime)
                command.Parameters("@SENDDATE").Value = Now
                connection.Open()

                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                'Console.WriteLine("RowsAffected: {0}", rowsAffected)

                If rowsAffected > 0 Then

                    InsertTranxRecord = "Successful"
                End If

            End Using
        Catch ex As Exception

            'Console.WriteLine(ex.Message)

        End Try

        Return InsertTranxRecord

    End Function



    Public Shared Function InsertAuditRecord(ByVal MyCno As String, ByVal MyDocVersion As String, ByVal MyDocType As String, ByVal MyDocTranxType As String, ByVal MyAuditMemo As String, ByVal MySendUser As String, ByVal MyFixDate As Date) As String

        Dim getresult As DbResult
        Dim ActionMode As String = ""
        Dim aff_row As Integer = 0
        Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim InsertSQL As String = ""
        Dim UpdateSQL As String = ""

        InsertSQL = " INSERT INTO [DAHS_AuditResult] ([CNO], [DocVersion],  [DOCTYPE], [AUDITSERIAL], [AUDITRESULT], [AUDITMEMO], [AUDITDATE], [Auditor], [CreatorID], [CreateDate],[U_ID],[U_DATE]) VALUES (@CNO, @DocVersion,  @DOCTYPE, @AUDITSERIAL, @AUDITRESULT, @AUDITMEMO, @AUDITDATE, @Auditor, @CreatorID, @CreateDate,@U_ID,@U_DATE) "
        UpdateSQL = " UPDATE [DAHS_AuditResult] SET [AUDITSERIAL]=@AUDITSERIAL,[AUDITRESULT]=@AUDITRESULT, [AUDITMEMO]=@AUDITMEMO, [AUDITDATE]=@AUDITDATE, [Auditor]=@Auditor,U_ID=@U_ID, U_DATE=@U_DATE WHERE CNO=@CNO AND DOCVERSION=@DOCVERSION AND DOCTYPE=@DOCTYPE  "
        Dim Sqlstr As String = "Select * from DAHS_AuditResult where cno='" + MyCno + "' and DocVersion='" + MyDocVersion + "' and doctype='" + MyDocType + "'"

        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

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
                    .InsertParameters.Add("CNo", MyCno)
                    .InsertParameters.Add("DocVersion", MyDocVersion)
                    .InsertParameters.Add("DOCTYPE", MyDocType)
                    .InsertParameters.Add("AUDITSERIAL", MyFixDate)
                    .InsertParameters.Add("AUDITRESULT", MyDocTranxType)
                    .InsertParameters.Add("AUDITMEMO", MyAuditMemo)
                    .InsertParameters.Add("AUDITDATE", Today())
                    .InsertParameters.Add("Auditor", MySendUser)
                    .InsertParameters.Add("CreatorID", MySendUser)
                    .InsertParameters.Add("CreateDate", Today())
                    .InsertParameters.Add("U_ID", MySendUser)
                    .InsertParameters.Add("U_Date", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()
                    If aff_row = 0 Then
                        InsertAuditRecord = "FALSE"
                    Else
                        InsertAuditRecord = "TRUE"
                    End If

                End With


            Catch ex As Exception

                'Console.WriteLine(ex.Message)

            End Try
        Else
            Try
                With SDS_PlanPolFeature
                    .UpdateParameters.Add("CNo", MyCno)
                    .UpdateParameters.Add("DocVersion", MyDocVersion)
                    .UpdateParameters.Add("DOCTYPE", MyDocType)
                    .UpdateParameters.Add("AUDITSERIAL", MyFixDate)
                    .UpdateParameters.Add("AUDITRESULT", MyDocTranxType)
                    .UpdateParameters.Add("AUDITMEMO", MyAuditMemo)
                    .UpdateParameters.Add("AUDITDATE", Today())
                    .UpdateParameters.Add("Auditor", MySendUser)
                    .UpdateParameters.Add("U_ID", MySendUser)
                    .UpdateParameters.Add("U_Date", Today())
                    .UpdateCommand = UpdateSQL
                    aff_row = .Update()
                    If aff_row = 0 Then
                        InsertAuditRecord = "FALSE"
                    Else
                        InsertAuditRecord = "TRUE"
                    End If

                End With


            Catch ex As Exception

                'Console.WriteLine(ex.Message)

            End Try
        End If


        Return InsertAuditRecord

    End Function

    Protected Sub RuleAudit()

        Dim strMess As New ListEditItem

        Msglist.Items.Clear()
        Dim strScript_Error As String = "<script language=JavaScript> alert(""輸入資料一致性檢查有誤，請參考上方紅字訊息""); </script>"

        strMess.Text = ""

        '防呆機制－廢（污）水排放量：核准許可廢（污）水排放量 ≥ 作業廢水及洩放廢水之排放量

        Try
            If CDbl(TB_BAS_PERMITVOL.Text) < CDbl(TB_BAS_OPVOL.Text) Then
                strMess.Text = "[二、廢(污)水排放量]核准許可廢（污）水排放量 須 ≥ 作業廢水及洩放廢水之排放量"
                Msglist.Items.Insert(0, strMess)
            End If

            '勾選事業及大於5000 

            If RBL_BAS_TYPE_B.Checked = True Then

                If CDbl(TB_BAS_OPVOL.Text) > 5000 Then
                    If CB_RULE_5000_BUSSINESS.Checked <> "True" Then
                        strMess.Text = "[三、設置依據]應勾選---許可核准排放量達每日5,000CMD以上事業"
                        Msglist.Items.Insert(0, strMess)
                    End If
                End If
            End If

            If RBL_BAS_TYPE_I.Checked = True Then
                If CDbl(TB_BAS_OPVOL.Text) > 1500 Then
                    If CB_RULE_1500_I.Checked <> "True" Then
                        strMess.Text = "[三、設置依據]應勾選---許可核准排放量達每日1,500CMD以上工業區專用污水下水道系統"
                        Msglist.Items.Insert(0, strMess)
                    End If
                End If
            End If

            If RBL_BAS_TYPE_B.Checked = True Then
                If TB_BAS_TYPEB.Text = "發電廠" Then
                    If CDbl(TB_BAS_OPVOL.Text) > 5000 Then
                        If CB_RULE_5000_BUSSINESS.Checked <> "True" Then
                            strMess.Text = "[三、設置依據]應勾選---許可核准排放量達每日5,000CMD以上事業"
                            Msglist.Items.Insert(0, strMess)
                        End If
                    ElseIf CDbl(TB_BAS_OPVOL.Text) >= 1500 And CDbl(TB_BAS_OPVOL.Text) < 5000 Then
                        If CB_RULE_1500_BUSSINESS.Checked <> "True" Then
                            strMess.Text = "[三、設置依據]應勾選---許可核准排放量達每日1,500CMD以上、未達5,000CMD事業"
                            Msglist.Items.Insert(0, strMess)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception

        End Try


        'Check Input Error
        '勾稽監測位置編號開頭英文字母： 放流口為D或O；用水來源自來水為FW、地下水為GW、河湖海水為LW、回收水為RW、其他為ZW；電子式電度表為EM

        Dim getresult As DbResult
        Dim strSQL As String = ""

        strSQL = "select * from DOC_SET_ITEM where cno='" + Session("CNO") + "' and docversion='" + Session("DOCVERSION") + "'"
        getresult = EIPDB.GetData(strSQL)

        If getresult.returnDataTable.Rows.Count > 0 Then

            If getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "放流口" Then

                If Left(getresult.returnDataTable.Rows(0).Item("DP_NO").ToString, 1) <> "D" And Left(getresult.returnDataTable.Rows(0).Item("DP_NO").ToString, 1) <> "O" Then
                    strMess.Text = "[六、設施位置及種類]放流口應為D或O開頭"
                    Msglist.Items.Insert(0, strMess)
                End If

            ElseIf getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "用水來源自來水" Then

                If Left(getresult.returnDataTable.Rows(0).Item("DP_NO").ToString, 2) <> "FW" Then
                    strMess.Text = "[六、設施位置及種類]放流口應為FW開頭"
                    Msglist.Items.Insert(0, strMess)
                End If

            ElseIf getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "地下水" Then

                If Left(getresult.returnDataTable.Rows(0).Item("DP_NO").ToString, 2) <> "GW" Then
                    strMess.Text = "[六、設施位置及種類]放流口應為GW開頭"
                    Msglist.Items.Insert(0, strMess)
                End If

            ElseIf getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "河湖海水" Then

                If Left(getresult.returnDataTable.Rows(0).Item("DP_NO").ToString, 2) <> "LW" Then
                    strMess.Text = "[六、設施位置及種類]放流口應為LW開頭"
                    Msglist.Items.Insert(0, strMess)
                End If

            ElseIf getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "回收水" Then
                If Left(getresult.returnDataTable.Rows(0).Item("DP_NO").ToString, 2) <> "RW" Then
                    strMess.Text = "[六、設施位置及種類]放流口應為RW開頭"
                    Msglist.Items.Insert(0, strMess)
                End If

            ElseIf getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "其他" Then
                If Left(getresult.returnDataTable.Rows(0).Item("DP_NO").ToString, 2) <> "ZW" Then
                    strMess.Text = "[六、設施位置及種類]放流口應為ZW開頭"
                    Msglist.Items.Insert(0, strMess)
                End If


            ElseIf getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "電子式電度表" Then
                If Left(getresult.returnDataTable.Rows(0).Item("DP_NO").ToString, 2) <> "EM" Then
                    strMess.Text = "[六、設施位置及種類]放流口應為EM開頭"
                    Msglist.Items.Insert(0, strMess)
                End If

            End If

        End If



        '設施位置及種類 Rule_31

        Dim getRuleResult As DbResult
        Dim strGetRuleSQL As String = ""

        strGetRuleSQL = "select * from DOC_SET_ITEM where cno='" + Session("CNO") + "' and docversion='" + Session("DOCVERSION") + "' "
        getRuleResult = EIPDB.GetData(strGetRuleSQL)

        If CB_RULE_31.Checked Then

            If getresult.returnDataTable.Rows.Count > 0 Then
                If getresult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應至少勾水量"
                    Msglist.Items.Insert(0, strMess)
                End If
            End If
        End If

        '設施位置及種類 Rule_56


        If CB_RULE_56.Checked Then

            strGetRuleSQL = "select * from DOC_SET_ITEM where cno='" + Session("CNO") + "' and docversion='" + Session("DOCVERSION") + "' and DPTYPE='用水來源'"
            getRuleResult = EIPDB.GetData(strGetRuleSQL)

            If getresult.returnDataTable.Rows.Count = 0 Then
                strMess.Text = "[六、設施位置及種類]位置種類應填寫[用水來源]"
                Msglist.Items.Insert(0, strMess)
            End If

            strGetRuleSQL = "select * from DOC_SET_ITEM where cno='" + Session("CNO") + "' and docversion='" + Session("DOCVERSION") + "' and DPTYPE='電子式電度表'"
            getRuleResult = EIPDB.GetData(strGetRuleSQL)

            If getresult.returnDataTable.Rows.Count = 0 Then
                strMess.Text = "[六、設施位置及種類]位置種類應填寫[電子式電度表]"
                Msglist.Items.Insert(0, strMess)
            End If


            strGetRuleSQL = "select * from DOC_SET_ITEM where cno='" + Session("CNO") + "' and docversion='" + Session("DOCVERSION") + "' and (DPTYPE='處理單元(進流口) OR DPTYPE='處理單元(出流口)')"
            getRuleResult = EIPDB.GetData(strGetRuleSQL)

            If getresult.returnDataTable.Rows.Count = 0 Then
                strMess.Text = "[六、設施位置及種類]位置種類應填寫[處理單元(進流口) 或 處理單元(出流口)"
                Msglist.Items.Insert(0, strMess)
            Else

                If getresult.returnDataTable.Rows(0).Item("ITEM_259").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應勾取水溫"
                    Msglist.Items.Insert(0, strMess)
                End If

                If getresult.returnDataTable.Rows(0).Item("ITEM_246").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應至少勾pH"
                    Msglist.Items.Insert(0, strMess)
                End If

                If getresult.returnDataTable.Rows(0).Item("ITEM_247").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應勾取導電度"
                    Msglist.Items.Insert(0, strMess)
                End If
            End If

            strGetRuleSQL = "select * from DOC_SET_ITEM where cno='" + Session("CNO") + "' and docversion='" + Session("DOCVERSION") + "' and (DPTYPE='放流口' or DPTYPE='排放口' )"
            getRuleResult = EIPDB.GetData(strGetRuleSQL)

            If getresult.returnDataTable.Rows.Count = 0 Then
                strMess.Text = "[六、設施位置及種類]位置種類應填寫['放流口'或'排放口']"
                Msglist.Items.Insert(0, strMess)
            Else

                If getresult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應勾取水量"
                    Msglist.Items.Insert(0, strMess)
                End If

                If getresult.returnDataTable.Rows(0).Item("ITEM_259").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應勾取水溫"
                    Msglist.Items.Insert(0, strMess)
                End If

                If getresult.returnDataTable.Rows(0).Item("ITEM_246").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應勾取pH"
                    Msglist.Items.Insert(0, strMess)
                End If

                If getresult.returnDataTable.Rows(0).Item("ITEM_247").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應勾取導電度"
                    Msglist.Items.Insert(0, strMess)
                End If

            End If

        End If

        If CB_RULE_57_1.Checked Then

            If getresult.returnDataTable.Rows.Count > 0 Then

                If getresult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "False" Then
                    strMess.Text = "[六、設施位置及種類]應勾取水量"
                    Msglist.Items.Insert(0, strMess)
                End If
            End If

        End If

        If CB_RULE_105.Checked Then

            strGetRuleSQL = "select * from DOC_SET_ITEM where cno='" + Session("CNO") + "' and docversion='" + Session("DOCVERSION") + "' and (DPTYPE='放流口' or DPTYPE='排放口' )"
            getRuleResult = EIPDB.GetData(strGetRuleSQL)


            If getRuleResult.returnDataTable.Rows.Count = 0 Then
                strMess.Text = "[六、設施位置及種類]位置種類應填寫['放流口'或'排放口']"
                Msglist.Items.Insert(0, strMess)
            Else

                If CDbl(TB_BAS_PERMITVOL.Text.Trim) > 1500 Then

                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_210").ToString = "False" Then
                        strMess.Text = "[六、設施位置及種類]應勾取SS"
                        Msglist.Items.Insert(0, strMess)
                    End If
                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_243").ToString = "False" Then
                        strMess.Text = "[六、設施位置及種類]應勾取COD"
                        Msglist.Items.Insert(0, strMess)
                    End If

                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "False" Then
                        strMess.Text = "六、設施位置及種類]應勾取水量"
                        Msglist.Items.Insert(0, strMess)
                    End If

                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_259").ToString = "False" Then
                        strMess.Text = "[六、設施位置及種類]應勾取水溫"
                        Msglist.Items.Insert(0, strMess)
                    End If

                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_246").ToString = "False" Then
                        strMess.Text = "[六、設施位置及種類]應勾取pH"
                        Msglist.Items.Insert(0, strMess)
                    End If

                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_247").ToString = "False" Then
                        strMess.Text = "[六、設施位置及種類]應勾取導電度"
                        Msglist.Items.Insert(0, strMess)
                    End If
                Else
                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_248").ToString = "False" Then
                        strMess.Text = "六、設施位置及種類]應勾取水量"
                        Msglist.Items.Insert(0, strMess)
                    End If

                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_259").ToString = "False" Then
                        strMess.Text = "[六、設施位置及種類]應勾取水溫"
                        Msglist.Items.Insert(0, strMess)
                    End If

                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_246").ToString = "False" Then
                        strMess.Text = "[六、設施位置及種類]應勾取pH"
                        Msglist.Items.Insert(0, strMess)
                    End If

                    If getRuleResult.returnDataTable.Rows(0).Item("ITEM_247").ToString = "False" Then
                        strMess.Text = "[六、設施位置及種類]應勾取導電度"
                        Msglist.Items.Insert(0, strMess)
                    End If

                End If






            End If

        End If


        'Check 監測位置開頭
        '放流口為D或O

        If getresult.returnDataTable.Rows.Count > 0 Then
            If getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "放流口" Then
                If getresult.returnDataTable.Rows(0).Item("DP_NO").ToString.Substring(0, 1) <> "D" And getresult.returnDataTable.Rows(0).Item("DP_NO").ToString.Substring(0, 1) <> "O" Then
                    strMess.Text = "[六、設施位置及種類]放流口編號應為D或O開頭"
                    Msglist.Items.Insert(0, strMess)
                End If
            End If

            If getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString = "用水來源" Then
                If getresult.returnDataTable.Rows(0).Item("DP_NO").ToString.Substring(0, 1) <> "D" Then
                    strMess.Text = "[六、設施位置及種類]放流口編號應為D或O開頭"
                    Msglist.Items.Insert(0, strMess)
                End If
            End If
        End If


        '量測周期之勾稽：水量、水溫、氫離子濃度指數及導電度量測周期最長不得超過1分鐘；懸浮固體、化學需氧量及氨氮周期最長不得超過180分鐘；用電量周期最長不得超過15分鐘
        'TB_SPEC_MEA_FREQ
        '防呆機制－校正周期之勾稽：水量廠牌未規定校正頻率者，應每年至少校正一次；氫離子濃度指數及導電度之校正周期最長不得超過1個月；懸浮固體、化學需氧量、氨氮之校周期最長不得超過3個月。
        'TB_SPEC_CALC_FREQ
        '防呆機制－監測紀錄值之等時間監測數據個數勾稽：水量、懸浮固體、化學需氧量及氨氮最少為1個；水溫、氫離子濃度指數及導電度最少為5個。
        'TB_SPEC_CALCAVG
        '防呆機制－勾稽自動監測設施使用之檢測方法編號：
        '導電度為NIEA W204.50C、懸浮固體為NIEA W211.50C、水溫為NIEA W218.50C、氫離子濃度指數為NIEA W425.50C、化學需氧量為NIEA W518.50C及水量為NIEA W024.50C

        '應用LOOP 驗證所有測項
        'strSQL = "select * from DOC_SET_SPEC where cno='" + Session("CNO") + "' and docversion='" + Session("DOCVERSION") + "'"
        'getresult = EIPDB.GetData(strSQL)

        'If getresult.returnDataTable.Rows.Count > 0 Then

        '    Dim strMeaFreq As String = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_FREQ").ToString
        '    Dim strCalcFreq As String = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_FREQ").ToString
        '    Dim strCalcAvg As String = getresult.returnDataTable.Rows(0).Item("SPEC_CALCAVG").ToString
        '    Dim strSampleMethod As String = getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD").ToString
        '    Dim strItem As String = getresult.returnDataTable.Rows(0).Item("ITEM").ToString

        '    Select Case strItem

        '        Case "248"
        '            If strMeaFreq <> "1分鐘" Then
        '                strMess.Text = "[貳、三、量測週期]水量量測周期最長不得超過1分鐘"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcFreq <> "每年一次" Then
        '                strMess.Text = "[貳、三、校正週期]水量廠牌未規定校正頻率者，應每年至少校正一次"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcAvg <> "1個" Then
        '                strMess.Text = "[貳、三、等時距個數]水量之等時間監測數據個數最少為1個"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strSampleMethod <> "NIEA W024.50C" Then
        '                strMess.Text = "[貳、三、量測方法]水量檢測方法編號應為NIEA W024.50C"
        '                Msglist.Items.Insert(0, strMess)
        '            End If

        '        Case "259"
        '            If strMeaFreq <> "1分鐘" Then
        '                strMess.Text = "[貳、三、量測週期]水溫量測周期最長不得超過1分鐘"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strSampleMethod <> "NIEA W218.50C" Then
        '                strMess.Text = "[貳、三、量測方法]水溫檢測方法編號應為NIEA W218.50C"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcAvg <> "5個" Then
        '                strMess.Text = "貳、三、等時距個數]水溫之等時間監測數據個數最少為5個"
        '                Msglist.Items.Insert(0, strMess)
        '            End If

        '        Case "246"
        '            If strMeaFreq <> "1分鐘" Then
        '                strMess.Text = "[貳、三、量測週期]氫離子濃度指數量測周期最長不得超過1分鐘"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcAvg <> "5個" Then
        '                strMess.Text = "[貳、三、等時距個數]氫離子濃度指數之等時間監測數據個數最少為5個"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strSampleMethod <> "NIEA W425.50C" Then
        '                strMess.Text = "[貳、三、量測方法]氫離子濃度指數檢測方法編號應為NIEA W425.50C"
        '                Msglist.Items.Insert(0, strMess)
        '            End If


        '        Case "247"
        '            ''最長不得超過1分鐘

        '            If strMeaFreq <> "1分鐘" Then
        '                strMess.Text = "[貳、三、量測週期]導電度量測周期最長不得超過1分鐘"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcFreq <> "1個月" Then
        '                strMess.Text = "[貳、三、校正週期]導電度之校正周期最長不得超過1個月"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcAvg <> "5個" Then
        '                strMess.Text = "[貳、三、等時距個數]水溫、氫離子濃度指數及導電度最少為5個"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strSampleMethod <> "NIEA W204.50C" Then
        '                strMess.Text = "[貳、三、量測方法]導電度檢測方法編號應為NIEA W204.50C"
        '                Msglist.Items.Insert(0, strMess)
        '            End If

        '        Case "210"
        '            If strMeaFreq <> "180分鐘" Then
        '                strMess.Text = "[貳、三、量測週期]懸浮固體周期最長不得超過180分鐘"
        '                Msglist.Items.Insert(0, strMess)

        '            End If
        '            If strCalcFreq <> "3個月" Then
        '                strMess.Text = "[貳、三、校正週期]懸浮固體之校正周期最長不得超過3個月"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcAvg <> "1個" Then
        '                strMess.Text = "[貳、三、等時距個數]水量、懸浮固體、化學需氧量及氨氮最少為1個"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strSampleMethod <> "NIEA W211.50C" Then
        '                strMess.Text = "[貳、三、量測方法]懸浮固體檢測方法編號應為NIEA W211.50C"
        '                Msglist.Items.Insert(0, strMess)
        '            End If

        '        Case "243"
        '            If strMeaFreq <> "180分鐘" Then
        '                strMess.Text = "[貳、三、量測週期]化學需氧量周期最長不得超過180分鐘"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcFreq <> "3個月" Then
        '                strMess.Text = "[貳、三、校正週期]化學需氧量之校正周期最長不得超過3個月"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strCalcAvg <> "1個" Then
        '                strMess.Text = "[貳、三、等時距個數]化學需氧量之等時間監測數據個數最少為1個"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '            If strSampleMethod <> "NIEA W518.50C" Then
        '                strMess.Text = "[貳、三、量測方法]化學需氧量檢測方法編號應為NIEA W518.50C"
        '                Msglist.Items.Insert(0, strMess)
        '            End If

        '        Case "242"
        '            '懸浮固體、化學需氧量及氨氮周期最長不得超過180分鐘
        '            If strMeaFreq <> "180分鐘" Then
        '                strMess.Text = "[貳、三、量測週期]氨氮周期最長不得超過180分鐘"
        '                Msglist.Items.Insert(0, strMess)

        '            End If
        '            If strCalcFreq <> "3個月" Then
        '                strMess.Text = "[貳、三、量測週期]氨氮之校周期最長不得超過3個月"
        '                Msglist.Items.Insert(0, strMess)
        '            End If

        '        Case ""
        '            '用電量周期最長不得超過15分鐘
        '            If strMeaFreq <> "15分鐘" Then
        '                strMess.Text = "[貳、三、量測週期]用電量周期最長不得超過15分鐘"
        '                Msglist.Items.Insert(0, strMess)
        '            End If
        '    End Select

        'End If


        '防呆機制-相對誤差測試查核計算及標準檢核： 可依申請案件輸入之實驗室檢測值及自動監測設施量測值， 重新計算相對誤差測試查核結果及平均差值， 以勾稽申請者之資料是否有輸入錯誤， 同時比對其計算結果是否符合法規之相對準確度標準要求



        '防呆機制-勾稽申請案件之設施規格及基本資料勾選之設施位置及種類之一致性： 由於各監測位置之每項監測（視）設施填應填寫1份完整之監測設施規格，在實務執行上容易發生疏漏，因此運用系統檢核與防呆機制，以確認每項監測（視）設施填均已檢附1份完整之監測設施規格說明

        'Dim conn2 As SqlConnection = New SqlConnection(CEMSDBHOST1)
        'Dim mycommand2 As New SqlCommand
        'Dim Permit_reader As SqlDataReader

        'mycommand2.CommandText = "SELECT  * from cwms_1  where controlno='" + Session("CNO") + "'"
        'Permit_reader = mycommand2.ExecuteReader

        'Dim CnoPermitVOL As String = Permit_reader.GetString(0)

        '輔助審查， 跨系統交叉比對
        '與水系統進行資料交換
        '勾稽事業別欄位
        '勾稽核准許可廢(污)水排放量、作業廢水及洩放廢水排放量

        'Dim getresult_Permit As DbResult
        'Dim strSQL_Permit As String = ""

        'Try
        '    strSQL_Permit = "select controlno,CompanyName,sum(DayTotalAudit) as DayTotal from cwms_1 where RunState='營運中' and controlno='" + Session("CNO") + "'  group by ControlNO,CompanyName "
        '    getresult_Permit = EIPDB.GetData(strSQL_Permit)

        '    If getresult_Permit.returnDataTable.Rows.Count > 0 Then
        '        If CDbl(getresult_Permit.returnDataTable.Rows(0).Item("DayTotal").ToString) <> CDbl(TB_BAS_PERMITVOL.Text) Then

        '            strMess.Text = "核准許可廢(污)水排放量(立方公尺/日)與許可系統不符"
        '            Msglist.Items.Insert(0, strMess)

        '        End If
        '    End If


        'Catch ex As Exception

        'End Try



        If Msglist.Items.Count <> 0 Then
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)

            Exit Sub
        End If


    End Sub

    Protected Sub BT_SendAudit_Click(sender As Object, e As EventArgs) Handles BT_SendAudit.Click

        '事業端送審前勾稽項目
        Dim strScript_Error As String = "<script language=JavaScript> alert(""輸入資料一致性檢查有誤，請參考上方紅字訊息""); </script>"
        Dim strScript_CaseExistError As String = "<script language=JavaScript> alert(""目前已有未完成審查案件，請待審查完成""); </script>"

        If GetCaseStatus(DBconntext, Session("CNO"), Session("DOCVERSION")) Then

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_CaseExistError)
            Exit Sub

        Else

            If RuleAuditFlag = "1" Then
                RuleAudit()
            End If

            If Msglist.Items.Count <> 0 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)

                Exit Sub
            End If

            If RBL_AuditResult.Text = "須補正" Then

                Session("FIXMODE") = "補正件"

            Else
                Session("FIXMODE") = "正常件"

            End If

            Session("DOCTYPE") = "措施說明書"
            Server.Transfer("PrepareSummit.aspx")

        End If

    End Sub

    Protected Sub BT_PRINT_Click(sender As Object, e As EventArgs) Handles BT_PRINT.Click

        '輸出至EXCEL 並轉成 PDF

        Try
            'ToExcel(Session("CNO"), Session("DOCVERSION"))
            Server.Transfer("PrintingMenu.aspx")
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub BT_DAHS_SAVE_Click(sender As Object, e As EventArgs) Handles BT_DAHS_SAVE.Click

        'dahs

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_DAHS] ([CNO], [DOCVERSION], [DP_NO], [PLAN_INSDATE], [AGENT], [REDANDUNT], [CONTROLROOM], [COLUD], [MAINTAINMETHOD],[DOCATTACH], [FITFREQ], [FITFORMAT], [STAR168DATE], [C_ID], [C_DATE]) VALUES (@CNO, @DOCVERSION, @DP_NO, @PLAN_INSDATE, @AGENT, @REDANDUNT, @CONTROLROOM, @COLUD, @MAINTAINMETHOD,@DOCATTACH, @FITFREQ, @FITFORMAT, @STAR168DATE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_DAHS] SET [DP_NO] = @DP_NO, [PLAN_INSDATE] = @PLAN_INSDATE, [AGENT] = @AGENT, [REDANDUNT] = @REDANDUNT, [CONTROLROOM] = @CONTROLROOM, [COLUD] = @COLUD, [MAINTAINMETHOD] = @MAINTAINMETHOD,[DOCATTACH]=@DOCATTACH, [FITFREQ] = @FITFREQ, [FITFORMAT] = @FITFORMAT, [STAR168DATE] = @STAR168DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"
        Dim InsertSQL_PDF As String = "INSERT INTO [DOC_SET_PDF] ([CNO], [DOCVERSION], [DDL318], [DDL33], [CreatorID], [CreateDate]) VALUES (@CNO, @DOCVERSION, @DDL318, @DDL33, @CreatorID, @CreateDate)"
        Dim UpdateSQL_PDF As String = "UPDATE [DOC_SET_PDF] SET [DDL318] = @DDL318, [DDL33] = @DDL33, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Dim SDS_PlanPolFeature_PDF As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature_PDF.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_DAHS where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

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
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", TempDocVersion)
                    End If
                    .InsertParameters.Add("DP_NO", TB_DAHS_DPNO.Text)
                    .InsertParameters.Add("PLAN_INSDATE", CDate(TB_DAHS_PLAN_INSDATE.Date))
                    .InsertParameters.Add("AGENT", TB_DAHS_AGENT.Text)
                    .InsertParameters.Add("REDANDUNT", RBL_DAHS_REDANDENT.SelectedValue.ToString)
                    .InsertParameters.Add("CONTROLROOM", RBL_DAHS_CONTROLROOM.SelectedValue.ToString)
                    .InsertParameters.Add("COLUD", RBL_CLOUD.SelectedValue.ToString)
                    .InsertParameters.Add("MAINTAINMETHOD", RBL_MAINTAINMETHOD.SelectedValue.ToString)
                    .InsertParameters.Add("DOCATTACH", CB_DAHS_DOCATTACH.Checked.ToString)
                    'DOCATTACH
                    .InsertParameters.Add("FITFREQ", RBL_FITFREQ.SelectedValue.ToString)
                    .InsertParameters.Add("FITFORMAT", RBL_FITFORMAT.SelectedValue.ToString)
                    .InsertParameters.Add("STAR168DATE", CDate(DE_DAHS_STAR168DATE.Date))
                    .InsertParameters.Add("C_ID", Session("UserName"))
                    .InsertParameters.Add("C_DATE", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        Label_DAHS.Text = "資料新增失敗!"
                    Else
                        Label_DAHS.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_DAHS.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_DAHS.Text = ex.Message.ToString
            End Try


        Else

            'Update 
            Try

                With SDS_PlanPolFeature

                    .UpdateParameters.Add("CNo", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", TempDocVersion)
                    End If
                    .UpdateParameters.Add("DP_NO", TB_DAHS_DPNO.Text)
                    .UpdateParameters.Add("PLAN_INSDATE", CDate(TB_DAHS_PLAN_INSDATE.Date))
                    .UpdateParameters.Add("AGENT", TB_DAHS_AGENT.Text)
                    .UpdateParameters.Add("REDANDUNT", RBL_DAHS_REDANDENT.SelectedValue.ToString)
                    .UpdateParameters.Add("CONTROLROOM", RBL_DAHS_CONTROLROOM.SelectedValue.ToString)
                    .UpdateParameters.Add("COLUD", RBL_CLOUD.SelectedValue.ToString)
                    .UpdateParameters.Add("MAINTAINMETHOD", RBL_MAINTAINMETHOD.SelectedValue.ToString)
                    .UpdateParameters.Add("DOCATTACH", CB_DAHS_DOCATTACH.Checked.ToString)
                    .UpdateParameters.Add("FITFREQ", RBL_FITFREQ.SelectedValue.ToString)
                    .UpdateParameters.Add("FITFORMAT", RBL_FITFORMAT.SelectedValue.ToString)
                    .UpdateParameters.Add("STAR168DATE", CDate(DE_DAHS_STAR168DATE.Date))
                    .UpdateParameters.Add("U_ID", Session("UserName"))
                    .UpdateParameters.Add("U_Date", Today())
                    .UpdateCommand = UpdateSQL

                    aff_row = .Update()

                    If aff_row = 0 Then
                        Label_DAHS.Text = "資料更新失敗!"
                    Else
                        Label_DAHS.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_DAHS.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_DAHS.Text = ex.Message.ToString
            End Try
        End If

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try


        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature_PDF

                    .InsertParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DDL318", DDL318.SelectedValue.ToString)
                    .InsertParameters.Add("DDL33", DDL33.SelectedValue.ToString)
                    .InsertParameters.Add("CreatorID", Session("UserName"))
                    .InsertParameters.Add("CreateDate", Today())
                    .InsertCommand = InsertSQL_PDF

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        Label_DAHS.Text = "資料新增失敗!"
                    Else
                        Label_DAHS.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_DAHS.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_DAHS.Text = ex.Message.ToString
            End Try

        Else

            'Update 
            Try

                With SDS_PlanPolFeature_PDF

                    .UpdateParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DDL318", DDL318.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL33", DDL33.SelectedValue.ToString)
                    .UpdateParameters.Add("ModifyID", Session("UserName"))
                    .UpdateParameters.Add("ModifyDate", Today())
                    .UpdateCommand = UpdateSQL_PDF

                    aff_row = .Update()

                    If aff_row = 0 Then
                        Label_DAHS.Text = "資料更新失敗!"
                    Else
                        Label_DAHS.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_DAHS.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_DAHS.Text = ex.Message.ToString
            End Try

        End If

        SDS_PlanPolFeature.Dispose()
        SDS_PlanPolFeature_PDF.Dispose()

    End Sub



    Protected Sub RBL_AuditResult_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_AuditResult.SelectedIndexChanged

        If RBL_AuditResult.Text = "須補正" Then

            TB_Audit_DATE.Visible = True
        Else
            TB_Audit_DATE.Visible = False
        End If
    End Sub


    Private Sub mergePDFFiles(ByVal fileList() As String, ByVal outMergeFile As String)

        outMergeFile = Server.MapPath(outMergeFile)
        Dim reader As PdfReader
        Dim document As iTextSharp.text.Document = New iTextSharp.text.Document
        Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(outMergeFile, FileMode.Create))

        document.Open()

        Dim cb As PdfContentByte = writer.DirectContent
        Dim newpage As PdfImportedPage
        Dim i As Integer

        For i = 0 To fileList.Length - 1 Step i + 1

            reader = New PdfReader(Server.MapPath(fileList(i)).ToString)
            Dim iPageNum As Integer = reader.NumberOfPages
            Dim j As Integer
            For j = 1 To iPageNum
                document.NewPage()
                newpage = writer.GetImportedPage(reader, j)
                cb.AddTemplate(newpage, 0, 0)
            Next
        Next

        document.Close()

    End Sub



    Private Sub RBL_BAS_TYPE_B_CheckedChanged(sender As Object, e As EventArgs) Handles RBL_BAS_TYPE_B.CheckedChanged

        RBL_BAS_TYPEW.SelectedIndex = -1
        RBL_BAS_TYPEW.Enabled = False


    End Sub


    Protected Sub BT_CHANGEVERSION_Click(sender As Object, e As EventArgs) Handles BT_CHANGEVERSION.Click

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = ""
        Dim UpdateSQL As String = ""
        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext


        InsertSQL = "INSERT INTO [DOC_SET_FACTORY] ([TYPE], [TYPEB], [TYPEW], [TYPEDESP], [CNO], [DOCVERSION], [RULE_31], [RULE_56], [RULE_56_1], [RULE_56_2], [RULE_56_3], [RULE_56_4], [RULE_56_5], [RULE_56_6],[RULE_56_7], [RULE_57_1],  [RULE_105], [RULE_1500_I], [RULE_5000_BUSSINESS], [RULE_1500_BUSSINESS],[RULE_5000_LIFE],[RULE_1500_LIFE], [RULE_ELEC], [RULE_WATERCOOLER], [RULE_E_EQUIP], [RULE_OTHER], [CWMS_LINK], [CWMS_LINKRULE_56], [CWMS_LINKRULE_57_1], [CWMS_LINKRULE_105], [LINKSET], [CWMS_LED], [CWMS_LEDRULE_56], [LEDSET], [PERMIT_VOL], [OPERATION_VOL], [REGUNIT], [FAC_NAME], [FAC_CNAME], [FAC_CTEL], [FAC_CTEL_EXT], [FAC_CMOBILE], [FAC_CFAX], [FAC_CEMAIL],[RBL_REG_MODI],[RBL_REG_SET],[CB_5_MOD_C],[CB_5_MOD_OTHER], [C_ID], [C_DATE]) VALUES (@TYPE, @TYPEB, @TYPEW, @TYPEDESP, @CNO, @DOCVERSION, @RULE_31, @RULE_56, @RULE_56_1, @RULE_56_2, @RULE_56_3, @RULE_56_4, @RULE_56_5, @RULE_56_6,@RULE_56_7, @RULE_57_1, @RULE_105, @RULE_1500_I, @RULE_5000_BUSSINESS, @RULE_1500_BUSSINESS,@RULE_5000_LIFE,@RULE_1500_LIFE, @RULE_ELEC, @RULE_WATERCOOLER, @RULE_E_EQUIP, @RULE_OTHER, @CWMS_LINK, @CWMS_LINKRULE_56, @CWMS_LINKRULE_57_1, @CWMS_LINKRULE_105, @LINKSET, @CWMS_LED, @CWMS_LEDRULE_56,  @LEDSET, @PERMIT_VOL, @OPERATION_VOL, @REGUNIT, @FAC_NAME, @FAC_CNAME, @FAC_CTEL, @FAC_CTEL_EXT, @FAC_CMOBILE, @FAC_CFAX, @FAC_CEMAIL,@RBL_REG_MODI,@RBL_REG_SET,@CB_5_MOD_C,@CB_5_MOD_OTHER,@C_ID, @C_DATE)"
        UpdateSQL = "UPDATE [DOC_SET_FACTORY] SET [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP, [RULE_31] = @RULE_31, [RULE_56] = @RULE_56, [RULE_56_1] = @RULE_56_1, [RULE_56_2] = @RULE_56_2, [RULE_56_3] = @RULE_56_3, [RULE_56_4] = @RULE_56_4, [RULE_56_5] = @RULE_56_5, [RULE_56_6] = @RULE_56_6,[RULE_56_7] = @RULE_56_7, [RULE_57_1] = @RULE_57_1, [RULE_105] = @RULE_105, [RULE_1500_I] = @RULE_1500_I, [RULE_5000_BUSSINESS] = @RULE_5000_BUSSINESS, [RULE_1500_BUSSINESS] = @RULE_1500_BUSSINESS,[RULE_5000_LIFE] = @RULE_5000_LIFE,[RULE_1500_LIFE] = @RULE_1500_LIFE, [RULE_ELEC] = @RULE_ELEC, [RULE_WATERCOOLER] = @RULE_WATERCOOLER, [RULE_E_EQUIP] = @RULE_E_EQUIP, [RULE_OTHER] = @RULE_OTHER, [CWMS_LINK] = @CWMS_LINK, [CWMS_LINKRULE_56] = @CWMS_LINKRULE_56, [CWMS_LINKRULE_57_1] = @CWMS_LINKRULE_57_1, [CWMS_LINKRULE_105] = @CWMS_LINKRULE_105, [LINKSET] = @LINKSET, [CWMS_LED] = @CWMS_LED, [CWMS_LEDRULE_56] = @CWMS_LEDRULE_56, [LEDSET] = @LEDSET, [PERMIT_VOL] = @PERMIT_VOL, [OPERATION_VOL] = @OPERATION_VOL, [REGUNIT] = @REGUNIT, [FAC_NAME] = @FAC_NAME, [FAC_CNAME] = @FAC_CNAME, [FAC_CTEL] = @FAC_CTEL, [FAC_CTEL_EXT] = @FAC_CTEL_EXT, [FAC_CMOBILE] = @FAC_CMOBILE, [FAC_CFAX] = @FAC_CFAX, [FAC_CEMAIL] = @FAC_CEMAIL,[RBL_REG_MODI]=@RBL_REG_MODI,[RBL_REG_SET]=@RBL_REG_SET,[CB_5_MOD_C]=@CB_5_MOD_C,[CB_5_MOD_OTHER]=@CB_5_MOD_OTHER,  [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"

        Try

            With SDS_PlanPolFeature
                .InsertCommand = ""
                .InsertParameters.Clear()
                .InsertParameters.Add("CNo", Session("CNO"))
                If Session("DOCFIX") = "變更" Then
                    .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                Else
                    .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                End If

                If RBL_BAS_TYPE_B.Checked Then
                    .InsertParameters.Add("TYPE", RBL_BAS_TYPE_B.Text)
                    .InsertParameters.Add("TYPEB", TB_BAS_TYPEB.Text)
                    .InsertParameters.Add("TYPEW", "")
                End If
                If RBL_BAS_TYPE_I.Checked Then
                    .InsertParameters.Add("TYPE", RBL_BAS_TYPE_I.Text)
                    .InsertParameters.Add("TYPEB", "")
                    .InsertParameters.Add("TYPEW", RBL_BAS_TYPEW.SelectedItem.Value)
                End If

                .InsertParameters.Add("TYPEDESP", "")
                .InsertParameters.Add("RULE_31", CB_RULE_31.Checked.ToString)
                .InsertParameters.Add("RULE_56", CB_RULE_56.Checked.ToString)
                .InsertParameters.Add("RULE_56_1", CB_RULE_56_1.Checked.ToString)
                .InsertParameters.Add("RULE_56_2", CB_RULE_56_2.Checked.ToString)
                .InsertParameters.Add("RULE_56_3", CB_RULE_56_3.Checked.ToString)
                .InsertParameters.Add("RULE_56_4", CB_RULE_56_4.Checked.ToString)
                .InsertParameters.Add("RULE_56_5", CB_RULE_56_5.Checked.ToString)
                .InsertParameters.Add("RULE_56_6", CB_RULE_56_6.Checked.ToString)
                .InsertParameters.Add("RULE_56_7", CB_RULE_56_7.Checked.ToString)
                .InsertParameters.Add("RULE_57_1", CB_RULE_57_1.Checked.ToString)
                '.InsertParameters.Add("RULE_58", CB_RULE_58.Checked.ToString)
                .InsertParameters.Add("RULE_105", CB_RULE_105.Checked.ToString)
                .InsertParameters.Add("RULE_1500_I", CB_RULE_1500_I.Checked.ToString)
                .InsertParameters.Add("RULE_5000_BUSSINESS", CB_RULE_5000_BUSSINESS.Checked.ToString)
                .InsertParameters.Add("RULE_1500_BUSSINESS", CB_RULE_1500_BUSSINESS.Checked.ToString)
                .InsertParameters.Add("RULE_5000_LIFE", CB_RULE_5000_LIFE.Checked.ToString)
                .InsertParameters.Add("RULE_1500_LIFE", CB_RULE_1500_LIFE.Checked.ToString)
                .InsertParameters.Add("RULE_ELEC", CB_RULE_ELEC.Checked.ToString)
                .InsertParameters.Add("RULE_WATERCOOLER", CB_RULE_WATERCOOLER.Checked.ToString)
                .InsertParameters.Add("RULE_E_EQUIP", CB_RULE_E_EQUIP.Checked.ToString)
                .InsertParameters.Add("RULE_OTHER", CB_RULE_OTHER.Checked.ToString)
                .InsertParameters.Add("CWMS_LINK", CB_CWMS_LINK.Checked.ToString)
                .InsertParameters.Add("CWMS_LINKRULE_56", CB_LINKRULE56.Checked.ToString)
                .InsertParameters.Add("CWMS_LINKRULE_57_1", CB_LINKRULE57_1.Checked.ToString)
                .InsertParameters.Add("CWMS_LINKRULE_105", CB_LINKRULE105.Checked.ToString)
                .InsertParameters.Add("LINKSET", TB_LINKSET.Text)
                .InsertParameters.Add("CWMS_LED", CB_CWMS_LED.Checked.ToString)
                .InsertParameters.Add("CWMS_LEDRULE_56", CB_LEDRULE_56.Checked.ToString)
                '.InsertParameters.Add("CWMS_LEDRULE_105", CB_LEDRULE_105.Checked.ToString)
                .InsertParameters.Add("LEDSET", TB_LEDSET.Text)
                .InsertParameters.Add("PERMIT_VOL", TB_BAS_PERMITVOL.Text)
                .InsertParameters.Add("OPERATION_VOL", TB_BAS_OPVOL.Text)
                .InsertParameters.Add("REGUNIT", TB_BAS_FAC_NAME.Text)
                .InsertParameters.Add("FAC_NAME", TB_BAS_FAC_NAME.Text)
                .InsertParameters.Add("FAC_CNAME", TB_BAS_FAC_CNAME.Text)
                .InsertParameters.Add("FAC_CTEL", TB_BAS_FAC_CTEL.Text)
                .InsertParameters.Add("FAC_CTEL_EXT", TB_BAS_FAC_CTEL_EXT.Text)
                .InsertParameters.Add("FAC_CMOBILE", TB_BAS_FAC_CMOBILE.Text)
                .InsertParameters.Add("FAC_CFAX", TB_BAS_FAC_CFAX.Text)
                .InsertParameters.Add("FAC_CEMAIL", TB_BAS_FAC_CEMAIL.Text)

                If RBL_REG_SET.Checked = True Then
                    .InsertParameters.Add("RBL_REG_SET", RBL_REG_SET.Text)
                    .InsertParameters.Add("RBL_REG_MODI", "")
                Else
                    .InsertParameters.Add("RBL_REG_SET", "")
                    .InsertParameters.Add("RBL_REG_MODI", RBL_REG_MODI.Text)

                End If

                .InsertParameters.Add("CB_5_MOD_C", CB_5_MOD_C.Checked.ToString)
                .InsertParameters.Add("CB_5_MOD_OTHER", CB_5_MOD_OTHER.Checked.ToString)
                '.InsertParameters.Add("REG_DATE", TB_REGDATE.Text)
                .InsertParameters.Add("C_ID", Session("UserName"))
                .InsertParameters.Add("C_DATE", Today())
                .InsertCommand = InsertSQL

                aff_row = .Insert()

            End With

        Catch ex As System.Data.SqlClient.SqlException
            LABEL_BAS.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            LABEL_BAS.Text = ex.Message.ToString
        End Try

        'ITEM

        'InsertCommand="INSERT INTO [DOC_SET_ITEM] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [DOCTYPE], [PERMIT_SERIAL], [EM_COVER], [ITEM_248], [ITEM_259], [ITEM_246], [ITEM_247], [ITEM_243], [ITEM_210], [ITEM_VIDEO], [ITEM_242], [ITEM_WATER], [ITEM_GROUND], [ITEM_RIVER], [ITEM_RECYCLE], [ITEM_299], [ITEM_OTHER], [OTHER_DESP], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @DOCTYPE, @PERMIT_SERIAL, @EM_COVER, @ITEM_248, @ITEM_259, @ITEM_246, @ITEM_247, @ITEM_243, @ITEM_210, @ITEM_VIDEO, @ITEM_242, @ITEM_WATER, @ITEM_GROUND, @ITEM_RIVER, @ITEM_RECYCLE, @ITEM_299, @ITEM_OTHER, @OTHER_DESP, @C_ID, @C_DATE, @U_ID, @U_DATE)" 

        InsertSQL = "INSERT INTO [DOC_SET_ITEM] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [DOCTYPE], [PERMIT_SERIAL], [EM_COVER], [ITEM_248], [ITEM_259], [ITEM_246], [ITEM_247], [ITEM_243], [ITEM_210], [ITEM_VIDEO], [ITEM_242], [ITEM_241], [ITEM_267], [ITEM_WATER], [ITEM_GROUND], [ITEM_RIVER], [ITEM_RECYCLE], [ITEM_299], [ITEM_OTHER], [OTHER_DESP], [C_ID], [C_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @DOCTYPE, @PERMIT_SERIAL, @EM_COVER, @ITEM_248, @ITEM_259, @ITEM_246, @ITEM_247, @ITEM_243, @ITEM_210, @ITEM_VIDEO, @ITEM_242, @ITEM_241, @ITEM_267, @ITEM_WATER, @ITEM_GROUND, @ITEM_RIVER, @ITEM_RECYCLE, @ITEM_299, @ITEM_OTHER, @OTHER_DESP, @C_ID, @C_DATE)"

        Dim Sqlstr As String = "Select * from DOC_SET_ITEM where cno='" + Session("CNO").ToString + "' and DocVersion='" + Session("DOCVERSION").ToString + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                With SDS_PlanPolFeature
                    .InsertCommand = ""
                    .InsertParameters.Clear()
                    .InsertParameters.Add("CNo", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DP_NO", getresult.returnDataTable.Rows(0).Item("DP_NO").ToString)
                    .InsertParameters.Add("DPTYPE", getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString)
                    .InsertParameters.Add("DOCTYPE", getresult.returnDataTable.Rows(0).Item("DOCTYPE").ToString)
                    .InsertParameters.Add("PERMIT_SERIAL", getresult.returnDataTable.Rows(0).Item("PERMIT_SERIAL").ToString)
                    .InsertParameters.Add("EM_COVER", getresult.returnDataTable.Rows(0).Item("EM_COVER").ToString)
                    .InsertParameters.Add("ITEM_248", getresult.returnDataTable.Rows(0).Item("ITEM_248").ToString)
                    .InsertParameters.Add("ITEM_259", getresult.returnDataTable.Rows(0).Item("ITEM_259").ToString)
                    .InsertParameters.Add("ITEM_246", getresult.returnDataTable.Rows(0).Item("ITEM_246").ToString)
                    .InsertParameters.Add("ITEM_247", getresult.returnDataTable.Rows(0).Item("ITEM_247").ToString)
                    .InsertParameters.Add("ITEM_243", getresult.returnDataTable.Rows(0).Item("ITEM_243").ToString)
                    .InsertParameters.Add("ITEM_210", getresult.returnDataTable.Rows(0).Item("ITEM_210").ToString)
                    .InsertParameters.Add("ITEM_VIDEO", getresult.returnDataTable.Rows(0).Item("ITEM_VIDEO").ToString)
                    .InsertParameters.Add("ITEM_242", getresult.returnDataTable.Rows(0).Item("ITEM_242").ToString)
                    .InsertParameters.Add("ITEM_241", getresult.returnDataTable.Rows(0).Item("ITEM_241").ToString)
                    .InsertParameters.Add("ITEM_267", getresult.returnDataTable.Rows(0).Item("ITEM_267").ToString)
                    .InsertParameters.Add("ITEM_WATER", getresult.returnDataTable.Rows(0).Item("ITEM_WATER").ToString)
                    .InsertParameters.Add("ITEM_GROUND", getresult.returnDataTable.Rows(0).Item("ITEM_GROUND").ToString)
                    .InsertParameters.Add("ITEM_RIVER", getresult.returnDataTable.Rows(0).Item("ITEM_RIVER").ToString)
                    .InsertParameters.Add("ITEM_RECYCLE", getresult.returnDataTable.Rows(0).Item("ITEM_RECYCLE").ToString)
                    .InsertParameters.Add("ITEM_299", getresult.returnDataTable.Rows(0).Item("ITEM_299").ToString)
                    .InsertParameters.Add("ITEM_OTHER", getresult.returnDataTable.Rows(0).Item("ITEM_OTHER").ToString)
                    .InsertParameters.Add("OTHER_DESP", getresult.returnDataTable.Rows(0).Item("OTHER_DESP").ToString)
                    .InsertParameters.Add("C_ID", Session("UserName"))
                    .InsertParameters.Add("C_DATE", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()

                End With

            End If

        Catch ex As Exception


        End Try

        'PDF



        InsertSQL = "INSERT INTO DOC_SET_PDFUPload (CNo,DP_NO,DocIndex,DocVersion,DocNumber,path,filename,pdffile,CreatorID,CreateDate) VALUES (@CNo,@DP_NO,@DocIndex,@DocVersion,@DocNumber,@path,@filename,@pdffile,@CreatorID,@CreateDate) "

        Dim pdfSqlstr As String = "Select  *  from DOC_SET_PDFUPload where cno='" + Session("CNO").ToString + "' and DocVersion='" + Session("DOCVERSION").ToString + "'"

        Try

            getresult = EIPDB.GetData(pdfSqlstr)

            If getresult.ReturnCode >= 1 Then

                For i = 0 To getresult.returnDataTable.Rows.Count
                    With SDS_PlanPolFeature
                        .InsertCommand = ""
                        .InsertParameters.Clear()
                        .InsertParameters.Add("CNo", Session("CNO"))
                        If Session("DOCFIX") = "變更" Then
                            .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                        Else
                            .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                        End If
                        .InsertParameters.Add("DP_NO", getresult.returnDataTable.Rows(i).Item("DP_NO").ToString)
                        .InsertParameters.Add("DocIndex", getresult.returnDataTable.Rows(i).Item("DocIndex").ToString)
                        .InsertParameters.Add("DocNumber", getresult.returnDataTable.Rows(i).Item("DocNumber").ToString)
                        .InsertParameters.Add("path", getresult.returnDataTable.Rows(i).Item("path").ToString)
                        .InsertParameters.Add("filename", getresult.returnDataTable.Rows(i).Item("filename").ToString)
                        .InsertParameters.Add("pdffile", getresult.returnDataTable.Rows(i).Item("pdffile").ToString)
                        .InsertParameters.Add("CreatorID", Session("UserName"))
                        .InsertParameters.Add("CreateDate", Today())
                        .InsertCommand = InsertSQL

                        aff_row = .Insert()

                    End With
                Next



            End If

        Catch ex As Exception


        End Try


        'DAHS
        InsertSQL = "INSERT INTO [DOC_SET_DAHS] ([CNO], [DOCVERSION], [DP_NO], [PLAN_INSDATE], [AGENT], [REDANDUNT], [CONTROLROOM], [COLUD], [MAINTAINMETHOD],[DOCATTACH], [FITFREQ], [FITFORMAT], [STAR168DATE], [C_ID], [C_DATE]) VALUES (@CNO, @DOCVERSION, @DP_NO, @PLAN_INSDATE, @AGENT, @REDANDUNT, @CONTROLROOM, @COLUD, @MAINTAINMETHOD,@DOCATTACH, @FITFREQ, @FITFORMAT, @STAR168DATE, @C_ID, @C_DATE)"

        Try

            With SDS_PlanPolFeature
                .InsertCommand = ""
                .InsertParameters.Clear()
                .InsertParameters.Add("CNo", Session("CNO"))
                If Session("DOCFIX") = "變更" Then
                    .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                Else
                    .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                End If
                .InsertParameters.Add("DP_NO", TB_DAHS_DPNO.Text)
                .InsertParameters.Add("PLAN_INSDATE", CDate(TB_DAHS_PLAN_INSDATE.Date))
                .InsertParameters.Add("AGENT", TB_DAHS_AGENT.Text)
                .InsertParameters.Add("REDANDUNT", RBL_DAHS_REDANDENT.SelectedValue.ToString)
                .InsertParameters.Add("CONTROLROOM", RBL_DAHS_CONTROLROOM.SelectedValue.ToString)
                .InsertParameters.Add("COLUD", RBL_CLOUD.SelectedValue.ToString)
                .InsertParameters.Add("MAINTAINMETHOD", RBL_MAINTAINMETHOD.SelectedValue.ToString)
                .InsertParameters.Add("DOCATTACH", CB_DAHS_DOCATTACH.Checked.ToString)
                'DOCATTACH
                .InsertParameters.Add("FITFREQ", RBL_FITFREQ.SelectedValue.ToString)
                .InsertParameters.Add("FITFORMAT", RBL_FITFORMAT.SelectedValue.ToString)
                .InsertParameters.Add("STAR168DATE", CDate(DE_DAHS_STAR168DATE.Date))
                .InsertParameters.Add("C_ID", Session("UserName"))
                .InsertParameters.Add("C_DATE", Today())
                .InsertCommand = InsertSQL

                aff_row = .Insert()


            End With

        Catch ex As System.Data.SqlClient.SqlException
            Label_LED.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            Label_LED.Text = ex.Message.ToString
        End Try

        'LED

        InsertSQL = "INSERT INTO [DOC_SET_LED] ([CNO], [DP_NO], [DOCVERSION], [LED_INSTALL], [LED_INSTALL_REASON], [LED_PLAN_DATE], [LED_FACTORY], [LED_MODEL], [LED_SERIAL], [LED_TYPE], [LED_TYPE_OTHER], [LED_INSTALLPOS], [LED_INSTALLPOS_REASON], [LED_SHOWITEM], [LED_SHOWITEM_REASON], [LED_FORMAT], [LED_FORMAT_REASON], [LED_FREQ], [LED_FAIL_INSTEAD],[LED_CONTENT], [C_ID], [C_DATE]) VALUES (@CNO, @DP_NO, @DOCVERSION, @LED_INSTALL, @LED_INSTALL_REASON, @LED_PLAN_DATE, @LED_FACTORY, @LED_MODEL, @LED_SERIAL, @LED_TYPE, @LED_TYPE_OTHER, @LED_INSTALLPOS, @LED_INSTALLPOS_REASON, @LED_SHOWITEM, @LED_SHOWITEM_REASON, @LED_FORMAT, @LED_FORMAT_REASON, @LED_FREQ, @LED_FAIL_INSTEAD,@LED_CONTENT, @C_ID, @C_DATE)"

        Try

            With SDS_PlanPolFeature
                .InsertCommand = ""
                .InsertParameters.Clear()

                .InsertParameters.Add("CNo", Session("CNO"))
                If Session("DOCFIX") = "變更" Then
                    .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                Else
                    .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                End If
                .InsertParameters.Add("DP_NO", TB_LED_DP_NO.Text)
                .InsertParameters.Add("LED_INSTALL", RBL_LED_INSTALL.SelectedValue.ToString)
                .InsertParameters.Add("LED_INSTALL_REASON", "")
                .InsertParameters.Add("LED_PLAN_DATE", TB_LED_PLAN_DATE.Text)
                .InsertParameters.Add("LED_FACTORY", TB_LED_FACTORY.Text)
                .InsertParameters.Add("LED_MODEL", TB_LED_MODEL.Text)
                .InsertParameters.Add("LED_SERIAL", TB_LED_SERIAL.Text)
                .InsertParameters.Add("LED_TYPE", RBL_LED_TYPE.SelectedValue.ToString)
                .InsertParameters.Add("LED_TYPE_OTHER", "")
                .InsertParameters.Add("LED_INSTALLPOS", RBL_LED_INSTALLPOS.SelectedValue.ToString)
                .InsertParameters.Add("LED_INSTALLPOS_REASON", "")
                .InsertParameters.Add("LED_SHOWITEM", RBL_LED_SHOWITEM.SelectedValue.ToString)
                .InsertParameters.Add("LED_SHOWITEM_REASON", "")
                .InsertParameters.Add("LED_FORMAT", RBL_LED_FORMAT.SelectedValue.ToString)
                .InsertParameters.Add("LED_FORMAT_REASON", "")
                .InsertParameters.Add("LED_FREQ", RBL_LED_FREQ.SelectedValue.ToString)
                .InsertParameters.Add("LED_FAIL_INSTEAD", "")
                .InsertParameters.Add("LED_CONTENT", RBL_LED_Content.SelectedValue.ToString)
                .InsertParameters.Add("C_ID", Session("UserName"))
                .InsertParameters.Add("C_DATE", Today())
                .InsertCommand = InsertSQL

                aff_row = .Insert()


                .InsertCommand = ""
                .InsertParameters.Clear()
            End With

        Catch ex As System.Data.SqlClient.SqlException
            Label_LED.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            Label_LED.Text = ex.Message.ToString
        End Try

        'LINK

        InsertSQL = "INSERT INTO [DOC_SET_LINK] ([cNo], [DP_NO], [DocVersion], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [NetworkIP], [VideoLineType], [VideoIPType], [VideoIP], [NetworkPortNumber], [NetworkPortNumberOther], [MaintainType],[CB_LINK_5A],[CB_LINK_5B],  [C_ID], [C_DATE]) VALUES (@cNo, @DP_NO, @DocVersion, @CemsPCCpu, @CemsPCMem, @CemsPCHDD, @CemsPCOS, @CemsPCNetcard, @CemsPCAntiVirus, @CemsPCFirewall, @NetworkLineType, @NetworkIPType, @NetworkIP, @VideoLineType, @VideoIPType, @VideoIP, @NetworkPortNumber, @NetworkPortNumberOther, @MaintainType,@CB_LINK_5A,@CB_LINK_5B, @C_ID, @C_DATE)"

        Try

            With SDS_PlanPolFeature
                .InsertCommand = ""
                .InsertParameters.Clear()
                .InsertParameters.Add("CNo", Session("CNO"))
                If Session("DOCFIX") = "變更" Then
                    .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                Else
                    .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                End If
                .InsertParameters.Add("DP_NO", TB_Link_COVERDPNO.Text)
                '.InsertParameters.Add("DAHS_REDAN_FUNC", RBL_Link_Redandant.SelectedValue.ToString)
                .InsertParameters.Add("CemsPCCpu", TB_Link_CemsPCCpu.Text)
                .InsertParameters.Add("CemsPCMem", TB_Link_CemsPCMem.Text)
                .InsertParameters.Add("CemsPCHDD", TB_Link_CemsPCHDD.Text)
                .InsertParameters.Add("CemsPCOS", TB_Link_CemsPCOS.Text)
                .InsertParameters.Add("CemsPCNetcard", TB_Link_CemsPCNetcard.Text)
                .InsertParameters.Add("CemsPCAntiVirus", TB_Link_CemsPCAntiVirus.Text)
                .InsertParameters.Add("CemsPCFirewall", TB_Link_CemsPCFirewall.Text)
                .InsertParameters.Add("NetworkLineType", RBL_Link_NetworkLineType.SelectedValue.ToString)
                .InsertParameters.Add("NetworkIPType", RBL_Link_NetworkIPType.SelectedValue.ToString)
                .InsertParameters.Add("NetworkIP", TB_Link_NetworkIPType_IP.Text)
                .InsertParameters.Add("VideoLineType", RBL_Link_VIDEONetworkLineType.SelectedValue.ToString)
                .InsertParameters.Add("VideoIPType", RBL_Link_VIDEONetworkIPType.SelectedValue.ToString)
                .InsertParameters.Add("VideoIP", TB_Link_VIDEONetworkIPType_IP.Text)
                .InsertParameters.Add("NetworkPortNumber", RBL_Link_NetworkPORT.SelectedValue.ToString)
                .InsertParameters.Add("NetworkPortNumberOther", TB_Link_NetworkPORT_OTHER.Text)
                .InsertParameters.Add("MaintainType", RBL_Link_MaintainType.SelectedValue.ToString)
                'CB_LINK_5A
                .InsertParameters.Add("CB_LINK_5A", CB_LINK_5A.Checked.ToString.Trim)
                .InsertParameters.Add("CB_LINK_5B", CB_LINK_5B.Checked.ToString.Trim)
                '.InsertParameters.Add("MonitorCenter", RBL_Link_MonitorCenter.SelectedValue.ToString)
                '.InsertParameters.Add("NOTE1", "")
                '.InsertParameters.Add("NOTE2", "")
                .InsertParameters.Add("C_ID", Session("UserName"))
                .InsertParameters.Add("C_DATE", Today())
                .InsertCommand = InsertSQL

                aff_row = .Insert()


                .InsertCommand = ""
                .InsertParameters.Clear()
            End With

        Catch ex As System.Data.SqlClient.SqlException
            Label_SetLink.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            Label_SetLink.Text = ex.Message.ToString
        End Try

        'LP

        InsertSQL = "INSERT INTO [DOC_SET_LP] ([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE],  [ITEM1_DATE],  [ITEM3_DATE], [ITEM4_1_DATE], [ITEM4_2_DATE], [ITEM4_3_DATE], [ITEM4_4_DATE], [ITEM4_5_DATE], [NOTE], [C_ID], [C_DATE]) VALUES (@CNO, @DOCVERSION, @SETCOMPANY, @SETPEOPLE,  @ITEM1_DATE,  @ITEM3_DATE, @ITEM4_1_DATE, @ITEM4_2_DATE, @ITEM4_3_DATE, @ITEM4_4_DATE, @ITEM4_5_DATE, @NOTE, @C_ID, @C_DATE)"

        Try

            With SDS_PlanPolFeature
                .InsertCommand = ""
                .InsertParameters.Clear()
                .InsertParameters.Add("CNo", Session("CNO"))
                If Session("DOCFIX") = "變更" Then
                    .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                Else
                    .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                End If
                .InsertParameters.Add("SETCOMPANY", TB_LP_SETCOMPANY.Text)
                .InsertParameters.Add("SETPEOPLE", TB_LP_SETPEOPLE.Text)
                '.InsertParameters.Add("TRANSTYPE", RBL_TRANS_TYPE.SelectedValue)
                .InsertParameters.Add("ITEM1_DATE", TB_LP_DATE1.Text)
                '.InsertParameters.Add("ITEM2_DATE", TB_LP_DATE2.Text)
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


                .InsertCommand = ""
                .InsertParameters.Clear()
            End With

        Catch ex As System.Data.SqlClient.SqlException
            LABEL_BAS.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            LABEL_BAS.Text = ex.Message.ToString
        End Try

        'SPEC


        InsertSQL = "INSERT INTO [DOC_SET_SPEC] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO], [SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD],[SPEC_SAMPLE_METHOD_DESP], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC],[SPEC_COSPEC_NOTE], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE],[SPEC_NOTE], [C_ID], [C_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM, @DPNO_DESP, @SPEC_INSTEAD_YES,@SPEC_INSTEAD_NO, @SPEC_MONITOROTHER_YES,@SPEC_MONITOROTHER_NO, @SPEC_MO_NOTE_DPNO, @SPEC_MO_NOTE_DPNO1, @SPEC_MO_NOTE_QUA, @SPEC_INS_DATE, @SPEC_AGENTNAME, @SPEC_EQU_MODEL, @SPEC_EQU_SERIAL, @SPEC_SAMPLE_METHOD,@SPEC_SAMPLE_METHOD_DESP, @SPEC_SAMPLE_METHOD_FILTERYES, @SPEC_SAMPLE_METHOD_FILTERNO, @SPEC_CALC_EQU, @SPEC_CALC_FREQ, @SPEC_CALC_METHOD, @SPEC_MAIN_FREQ, @SPEC_MAIN_METHOD, @SPEC_MATERIAL, @SPEC_WASTELIQUID, @SPEC_MATERIAL_FREQ, @SPEC_MEA_SCOPE, @SPEC_MEA_SCOPEUNIT, @SPEC_MEA_RESTIME, @SPEC_MEA_RESTIMEUNIT, @SPEC_MEA_FREQ, @SPEC_MEA_FREQUNIT, @SPEC_CALCAVG, @SPEC_DOCATTACH_INST, @SPEC_DOCATTACH_CALI, @SPEC_VIDEO_F, @SPEC_VIDEO_F_MEMO, @SPEC_VIDEO_R, @SPEC_VIDEO_R_MEMO, @SPEC_VIDEO_NV, @SPEC_VIDEO_NV_MEMO, @SPEC_ANASIG_YES, @SPEC_ANASIG, @SPEC_DIGSIG_YES, @SPEC_DIGSIG, @SPEC_DO_HARDWARE_CONNECT, @SPEC_DO_HARDWARE_CONNPARA, @SPEC_DO_HARDWARE_DOC, @SPEC_PLCAGENT, @SPEC_COSPEC,@SPEC_COSPEC_NOTE, @SPEC_H_CHANGE, @SPEC_H_CHANGE_NOTE,@SPEC_NOTE, @C_ID, @C_DATE)"

        Sqlstr = "Select * from DOC_SET_SPEC where cno='" + Session("CNO") + "'  and DocVersion='" + Session("DOCVERSION") + "'"
        Try
            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                For i = 0 To getresult.returnDataTable.Rows.Count

                    With SDS_PlanPolFeature

                        .InsertCommand = ""
                        .InsertParameters.Clear()
                        .InsertParameters.Add("CNo", Session("CNO"))
                        If Session("DOCFIX") = "變更" Then
                            .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                        Else
                            .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                        End If
                        '.InsertParameters.Add("DP_NO", RBL_SPEC_DPNO.SelectedItem.Value)
                        .InsertParameters.Add("DP_NO", getresult.returnDataTable.Rows(i).Item("DP_NO").ToString)
                        .InsertParameters.Add("ITEM", getresult.returnDataTable.Rows(i).Item("ITEM").ToString)
                        .InsertParameters.Add("DPTYPE", getresult.returnDataTable.Rows(i).Item("DPTYPE").ToString)
                        .InsertParameters.Add("DPNO_DESP", getresult.returnDataTable.Rows(i).Item("DPNO_DESP").ToString)
                        .InsertParameters.Add("SPEC_INSTEAD_YES", getresult.returnDataTable.Rows(i).Item("SPEC_INSTEAD_YES").ToString)
                        .InsertParameters.Add("SPEC_INSTEAD_NO  ", getresult.returnDataTable.Rows(i).Item("SPEC_INSTEAD_NO").ToString)
                        .InsertParameters.Add("SPEC_MONITOROTHER_YES", getresult.returnDataTable.Rows(i).Item("SPEC_MONITOROTHER_YES").ToString)
                        .InsertParameters.Add("SPEC_MONITOROTHER_NO", getresult.returnDataTable.Rows(i).Item("SPEC_MONITOROTHER_NO").ToString)
                        .InsertParameters.Add("SPEC_MO_NOTE_DPNO", getresult.returnDataTable.Rows(i).Item("SPEC_MO_NOTE_DPNO").ToString)
                        .InsertParameters.Add("SPEC_MO_NOTE_DPNO1", getresult.returnDataTable.Rows(i).Item("SPEC_MO_NOTE_DPNO1").ToString)
                        .InsertParameters.Add("SPEC_MO_NOTE_QUA", getresult.returnDataTable.Rows(i).Item("SPEC_MO_NOTE_QUA").ToString)
                        .InsertParameters.Add("SPEC_INS_DATE", CDate(getresult.returnDataTable.Rows(i).Item("SPEC_INS_DATE").ToString))
                        .InsertParameters.Add("SPEC_AGENTNAME", getresult.returnDataTable.Rows(i).Item("SPEC_AGENTNAME").ToString)
                        .InsertParameters.Add("SPEC_EQU_MODEL", getresult.returnDataTable.Rows(i).Item("SPEC_EQU_MODEL").ToString)
                        .InsertParameters.Add("SPEC_EQU_SERIAL", getresult.returnDataTable.Rows(i).Item("SPEC_EQU_SERIAL").ToString)
                        .InsertParameters.Add("SPEC_SAMPLE_METHOD", getresult.returnDataTable.Rows(i).Item("SPEC_SAMPLE_METHOD").ToString)
                        .InsertParameters.Add("SPEC_SAMPLE_METHOD_DESP", getresult.returnDataTable.Rows(i).Item("SPEC_SAMPLE_METHOD_DESP").ToString)
                        .InsertParameters.Add("SPEC_SAMPLE_METHOD_FILTERYES", getresult.returnDataTable.Rows(i).Item("SPEC_SAMPLE_METHOD_FILTERYES").ToString)
                        .InsertParameters.Add("SPEC_SAMPLE_METHOD_FILTERNO", getresult.returnDataTable.Rows(i).Item("SPEC_SAMPLE_METHOD_FILTERNO").ToString)
                        .InsertParameters.Add("SPEC_CALC_EQU", getresult.returnDataTable.Rows(i).Item("SPEC_CALC_EQU").ToString)
                        .InsertParameters.Add("SPEC_CALC_FREQ", getresult.returnDataTable.Rows(i).Item("SPEC_CALC_FREQ").ToString)
                        .InsertParameters.Add("SPEC_CALC_METHOD", getresult.returnDataTable.Rows(i).Item("SPEC_CALC_METHOD").ToString)
                        .InsertParameters.Add("SPEC_MAIN_FREQ", getresult.returnDataTable.Rows(i).Item("SPEC_MAIN_FREQ").ToString)
                        .InsertParameters.Add("SPEC_MAIN_METHOD", getresult.returnDataTable.Rows(i).Item("SPEC_MAIN_METHOD").ToString)
                        .InsertParameters.Add("SPEC_MATERIAL", getresult.returnDataTable.Rows(i).Item("SPEC_MATERIAL").ToString)
                        .InsertParameters.Add("SPEC_WASTELIQUID", getresult.returnDataTable.Rows(i).Item("SPEC_WASTELIQUID").ToString)
                        .InsertParameters.Add("SPEC_MATERIAL_FREQ", getresult.returnDataTable.Rows(i).Item("SPEC_MATERIAL_FREQ").ToString)
                        .InsertParameters.Add("SPEC_MEA_SCOPE", getresult.returnDataTable.Rows(i).Item("SPEC_MEA_SCOPE").ToString)
                        .InsertParameters.Add("SPEC_MEA_SCOPEUNIT", getresult.returnDataTable.Rows(i).Item("SPEC_MEA_SCOPEUNIT").ToString)
                        .InsertParameters.Add("SPEC_MEA_RESTIME", getresult.returnDataTable.Rows(i).Item("SPEC_MEA_RESTIME").ToString)
                        .InsertParameters.Add("SPEC_MEA_RESTIMEUNIT", getresult.returnDataTable.Rows(i).Item("SPEC_MEA_RESTIMEUNIT").ToString)
                        .InsertParameters.Add("SPEC_MEA_FREQ", getresult.returnDataTable.Rows(i).Item("SPEC_MEA_FREQ").ToString)
                        .InsertParameters.Add("SPEC_MEA_FREQUNIT", getresult.returnDataTable.Rows(i).Item("SPEC_MEA_FREQUNIT").ToString)
                        .InsertParameters.Add("SPEC_CALCAVG", getresult.returnDataTable.Rows(i).Item("SPEC_CALCAVG").ToString)
                        .InsertParameters.Add("SPEC_DOCATTACH_INST", getresult.returnDataTable.Rows(i).Item("SPEC_DOCATTACH_INST").ToString)
                        .InsertParameters.Add("SPEC_DOCATTACH_CALI", getresult.returnDataTable.Rows(i).Item("SPEC_DOCATTACH_CALI").ToString)
                        .InsertParameters.Add("SPEC_VIDEO_F", getresult.returnDataTable.Rows(i).Item("SPEC_VIDEO_F").ToString)
                        .InsertParameters.Add("SPEC_VIDEO_F_MEMO", getresult.returnDataTable.Rows(i).Item("SPEC_VIDEO_F_MEMO").ToString)
                        .InsertParameters.Add("SPEC_VIDEO_R", getresult.returnDataTable.Rows(i).Item("SPEC_VIDEO_R").ToString)
                        .InsertParameters.Add("SPEC_VIDEO_R_MEMO", getresult.returnDataTable.Rows(i).Item("SPEC_VIDEO_R_MEMO").ToString)
                        .InsertParameters.Add("SPEC_VIDEO_NV", getresult.returnDataTable.Rows(i).Item("SPEC_VIDEO_NV").ToString)
                        .InsertParameters.Add("SPEC_VIDEO_NV_MEMO", getresult.returnDataTable.Rows(i).Item("SPEC_VIDEO_NV_MEMO").ToString)
                        .InsertParameters.Add("SPEC_ANASIG_YES", getresult.returnDataTable.Rows(i).Item("SPEC_ANASIG_YES").ToString)
                        .InsertParameters.Add("SPEC_ANASIG", getresult.returnDataTable.Rows(i).Item("SPEC_ANASIG").ToString)
                        .InsertParameters.Add("SPEC_DIGSIG_YES", getresult.returnDataTable.Rows(i).Item("SPEC_DIGSIG_YES").ToString)
                        .InsertParameters.Add("SPEC_DIGSIG", getresult.returnDataTable.Rows(i).Item("SPEC_DIGSIG").ToString)
                        .InsertParameters.Add("SPEC_DO_HARDWARE_CONNECT", getresult.returnDataTable.Rows(i).Item("SPEC_DO_HARDWARE_CONNECT").ToString)
                        .InsertParameters.Add("SPEC_DO_HARDWARE_CONNPARA", getresult.returnDataTable.Rows(i).Item("SPEC_DO_HARDWARE_CONNPARA").ToString)
                        .InsertParameters.Add("SPEC_DO_HARDWARE_DOC", getresult.returnDataTable.Rows(i).Item("SPEC_DO_HARDWARE_DOC").ToString)
                        .InsertParameters.Add("SPEC_PLCAGENT", getresult.returnDataTable.Rows(i).Item("SPEC_PLCAGENT").ToString)
                        .InsertParameters.Add("SPEC_COSPEC", getresult.returnDataTable.Rows(i).Item("SPEC_COSPEC").ToString)
                        .InsertParameters.Add("SPEC_COSPEC_NOTE", getresult.returnDataTable.Rows(i).Item("SPEC_COSPEC_NOTE").ToString)
                        .InsertParameters.Add("SPEC_H_CHANGE", getresult.returnDataTable.Rows(i).Item("SPEC_H_CHANGE").ToString)
                        .InsertParameters.Add("SPEC_H_CHANGE_NOTE", getresult.returnDataTable.Rows(i).Item("SPEC_H_CHANGE_NOTE").ToString)
                        .InsertParameters.Add("SPEC_NOTE", getresult.returnDataTable.Rows(i).Item("SPEC_NOTE").ToString)
                        .InsertParameters.Add("C_ID", Session("UserName"))
                        .InsertParameters.Add("C_DATE", Today())
                        .InsertCommand = InsertSQL

                        aff_row = .Insert()


                    End With

                Next
            End If

        Catch ex As System.Data.SqlClient.SqlException
            Label_SPEC.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            Label_SPEC.Text = ex.Message.ToString
        End Try

        'CheckList

        InsertSQL = "INSERT INTO [DOC_SET_CHECKLIST] ([CNO], [DOCVERSION], [CB_CHECK_COVER], [CB_CHECK_BASIC], [CB_CHECK_SPEC], [CB_CHECK_DAHS], [CB_CHECK_LINK], [CB_CHECK_LED], [CB_CHECK_BASIC_C1], [CB_CHECK_BASIC_C1_AT], [CB_CHECK_SPEC_C1], [CB_CHECK_SPEC_C1_AT], [CB_CHECK_SPEC_C2], [CB_CHECK_SPEC_C2_AT], [CB_CHECK_SPEC_C3], [CB_CHECK_SPEC_C3_AT], [CB_CHECK_SPEC_C4], [CB_CHECK_SPEC_C4_AT], [CB_CHECK_SPEC_C5], [CB_CHECK_SPEC_C5_AT], [CB_CHECK_SPEC_C6], [CB_CHECK_SPEC_C6_AT], [CB_CHECK_SPEC_C7], [CB_CHECK_SPEC_C7_AT], [CB_CHECK_SPEC_C8], [CB_CHECK_SPEC_C8_AT], [CB_CHECK_SPEC_C9], [CB_CHECK_SPEC_C9_AT], [CB_CHECK_SPEC_C10], [CB_CHECK_SPEC_C10_AT], [CB_CHECK_SPEC_C11], [CB_CHECK_SPEC_C11_AT], [CB_CHECK_SPEC_C12], [CB_CHECK_SPEC_C12_AT], [CB_CHECK_DAHS_C1], [CB_CHECK_DAHS_C1_AT], [CB_CHECK_DAHS_C2], [CB_CHECK_DAHS_C2_AT], [CB_CHECK_LINK_C1], [CB_CHECK_LINK_C1_AT], [CB_CHECK_LINK_C2], [CB_CHECK_LINK_C2_AT], [CB_CHECK_LINK_C3], [CB_CHECK_LINK_C3_AT], [CB_CHECK_LED_C1], [CB_CHECK_LED_C1_AT], [CB_CHECK_LED_C2], [CB_CHECK_LED_C2_AT], [CB_CHECK_LED_C3], [CB_CHECK_LED_C3_AT], [C_ID], [C_DATE]) VALUES (@CNO, @DOCVERSION, @CB_CHECK_COVER, @CB_CHECK_BASIC, @CB_CHECK_SPEC, @CB_CHECK_DAHS, @CB_CHECK_LINK, @CB_CHECK_LED, @CB_CHECK_BASIC_C1, @CB_CHECK_BASIC_C1_AT, @CB_CHECK_SPEC_C1, @CB_CHECK_SPEC_C1_AT, @CB_CHECK_SPEC_C2, @CB_CHECK_SPEC_C2_AT, @CB_CHECK_SPEC_C3, @CB_CHECK_SPEC_C3_AT, @CB_CHECK_SPEC_C4, @CB_CHECK_SPEC_C4_AT, @CB_CHECK_SPEC_C5, @CB_CHECK_SPEC_C5_AT, @CB_CHECK_SPEC_C6, @CB_CHECK_SPEC_C6_AT, @CB_CHECK_SPEC_C7, @CB_CHECK_SPEC_C7_AT, @CB_CHECK_SPEC_C8, @CB_CHECK_SPEC_C8_AT, @CB_CHECK_SPEC_C9, @CB_CHECK_SPEC_C9_AT, @CB_CHECK_SPEC_C10, @CB_CHECK_SPEC_C10_AT, @CB_CHECK_SPEC_C11, @CB_CHECK_SPEC_C11_AT, @CB_CHECK_SPEC_C12, @CB_CHECK_SPEC_C12_AT, @CB_CHECK_DAHS_C1, @CB_CHECK_DAHS_C1_AT, @CB_CHECK_DAHS_C2, @CB_CHECK_DAHS_C2_AT, @CB_CHECK_LINK_C1, @CB_CHECK_LINK_C1_AT, @CB_CHECK_LINK_C2, @CB_CHECK_LINK_C2_AT, @CB_CHECK_LINK_C3, @CB_CHECK_LINK_C3_AT, @CB_CHECK_LED_C1, @CB_CHECK_LED_C1_AT, @CB_CHECK_LED_C2, @CB_CHECK_LED_C2_AT, @CB_CHECK_LED_C3, @CB_CHECK_LED_C3_AT, @C_ID, @C_DATE)"

        Try

            With SDS_PlanPolFeature
                .InsertCommand = ""
                .InsertParameters.Clear()
                .InsertParameters.Add("CNo", Session("CNO"))
                If Session("DOCFIX") = "變更" Then
                    .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                Else
                    .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                End If
                .InsertParameters.Add("CB_CHECK_COVER", CB_CHECK_COVER.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_BASIC", CB_CHECK_BASIC.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC", CB_CHECK_SPEC.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_DAHS", CB_CHECK_DAHS.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_LINK", CB_CHECK_LINK.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_LED", CB_CHECK_LED.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_BASIC_C1", CB_CHECK_BASIC_C1.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_BASIC_C1_AT", TB_CHECK_BASIC_C1.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C1", CB_CHECK_SPEC_C1.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C1_AT", TB_CHECK_SPEC_C1.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C2", CB_CHECK_SPEC_C2.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C2_AT", TB_CHECK_SPEC_C2.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C3", CB_CHECK_SPEC_C3.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C3_AT", TB_CHECK_SPEC_C3.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C4", CB_CHECK_SPEC_C4.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C4_AT", TB_CHECK_SPEC_C4.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C5", CB_CHECK_SPEC_C5.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C5_AT", TB_CHECK_SPEC_C5.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C6", CB_CHECK_SPEC_C6.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C6_AT", TB_CHECK_SPEC_C6.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C7", CB_CHECK_SPEC_C7.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C7_AT", TB_CHECK_SPEC_C7.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C8", CB_CHECK_SPEC_C8.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C8_AT", TB_CHECK_SPEC_C8.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C9", CB_CHECK_SPEC_C9.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C9_AT", TB_CHECK_SPEC_C9.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C10", CB_CHECK_SPEC_C10.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C10_AT", TB_CHECK_SPEC_C10.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C11", CB_CHECK_SPEC_C11.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C11_AT", TB_CHECK_SPEC_C11.Text)
                .InsertParameters.Add("CB_CHECK_SPEC_C12", CB_CHECK_SPEC_C12.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_SPEC_C12_AT", TB_CHECK_SPEC_C12.Text)
                .InsertParameters.Add("CB_CHECK_DAHS_C1", CB_CHECK_DAHS_C1.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_DAHS_C1_AT", TB_CHECK_DAHS_C1.Text)
                .InsertParameters.Add("CB_CHECK_DAHS_C2", CB_CHECK_DAHS_C2.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_DAHS_C2_AT", TB_CHECK_DAHS_C2.Text)
                .InsertParameters.Add("CB_CHECK_LINK_C1", CB_CHECK_LINK_C1.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_LINK_C1_AT", TB_CHECK_LINK_C1.Text)
                .InsertParameters.Add("CB_CHECK_LINK_C2", CB_CHECK_LINK_C2.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_LINK_C2_AT", TB_CHECK_LINK_C2.Text)
                .InsertParameters.Add("CB_CHECK_LINK_C3", CB_CHECK_LINK_C3.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_LINK_C3_AT", TB_CHECK_LINK_C3.Text)
                .InsertParameters.Add("CB_CHECK_LED_C1", CB_CHECK_LED_C1.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_LED_C1_AT", TB_CHECK_LED_C1.Text)
                .InsertParameters.Add("CB_CHECK_LED_C2", CB_CHECK_LED_C2.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_LED_C2_AT", TB_CHECK_LED_C2.Text)
                .InsertParameters.Add("CB_CHECK_LED_C3", CB_CHECK_LED_C3.Checked.ToString)
                .InsertParameters.Add("CB_CHECK_LED_C3_AT", TB_CHECK_LED_C3.Text)
                .InsertParameters.Add("C_ID", Session("UserName"))
                .InsertParameters.Add("C_DATE", Today())
                .InsertCommand = InsertSQL

                aff_row = .Insert()


                .InsertCommand = ""
                .InsertParameters.Clear()
            End With

        Catch ex As System.Data.SqlClient.SqlException
            Label_SetLink.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            Label_SetLink.Text = ex.Message.ToString
        End Try

        Session("DOCVERSION") = Session("NEW_DOCVERSION")
        LABEL_VERSION.Text = "目前版號:" + Session("DOCVERSION")
        SDS_PlanPolFeature.Dispose()

        FillFactory()
        FillLink()
        Fillspec()
        FillLINKPLAN()
        FillDahs()
        FillLed()
        FillCheckList()
        Fillspec_self()

    End Sub


    Protected Sub BT_AuditSave_Click(sender As Object, e As EventArgs) Handles BT_AuditSave.Click

        Dim strDocVersion As String = ""
        Dim strScript_Error As String = "<script language=JavaScript> alert(""審查結果為須補正時應填入補正期限...""); </script>"

        strDocVersion = Session("DOCVERSION")

        If RBL_AuditResult.Text = "須補正" Then

            If TB_Audit_DATE.Text = "" Then

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
                Exit Sub

            End If

        End If
        If RBL_AuditResult.Text = "審查通過" Then


            If strDocVersion > "1" Then

                'UpdateDahsMainMode("審查通過", Session("CNO"), Session("DOCVERSION"), Session("UserName"), Today)
                InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "審查通過", TB_AuditMemo.Text, Session("UserName"), Today)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "審查通過", Session("UserName"))
                Session("ExamPassDate") = Today.Date.ToShortDateString
                Session("MAILTYPE") = "變更審查通過(第二階段)"
            Else
                'UpdateDahsMainMode("審查通過", Session("CNO"), Session("DOCVERSION"), Session("UserName"), Today)
                InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "審查通過", TB_AuditMemo.Text, Session("UserName"), Today)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "審查通過", Session("UserName"))
                Session("ExamPassDate") = Today.Date.ToShortDateString
                Session("MAILTYPE") = "申請審查通過"
            End If

        ElseIf RBL_AuditResult.Text = "須補正" Then

            'UpdateDahsMainMode("審查/補正中", Session("CNO"), Session("DOCVERSION"), Session("UserName"), TB_Audit_DATE.Date)
            InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "須補正", TB_AuditMemo.Text, Session("UserName"), TB_Audit_DATE.Date)
            InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "須補正", Session("UserName"))
            Session("MAILTYPE") = "須補正"
            Session("DOCFIXDATE") = TB_Audit_DATE.Date.ToShortDateString

        ElseIf RBL_AuditResult.Text = "駁回" Then

            'UpdateDahsMainMode("駁回", Session("CNO"), Session("DOCVERSION"), Session("UserName"), Today)
            InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "駁回", TB_AuditMemo.Text, Session("UserName"), Today)
            InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "駁回", Session("UserName"))
            Session("MAILTYPE") = "駁回"
            Session("ExamPassDate") = Today.Date.ToShortDateString

        ElseIf RBL_AuditResult.Text = "不適用" Then

            'UpdateDahsMainMode("不適用", Session("CNO"), Session("DOCVERSION"), Session("UserName"), Today)
            InsertAuditRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "不適用", TB_AuditMemo.Text, Session("UserName"), Today)
            InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "不適用", Session("UserName"))
            Session("MAILTYPE") = "不適用"
            Session("ExamPassDate") = Today.Date.ToShortDateString
        End If
    End Sub




    Protected Sub RBL_BAS_TYPE_I_CheckedChanged(sender As Object, e As EventArgs) Handles RBL_BAS_TYPE_I.CheckedChanged

        RBL_BAS_TYPEW.Enabled = True


    End Sub

    Protected Sub BT_CheckList_Click(sender As Object, e As EventArgs) Handles BT_CheckList.Click

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_CHECKLIST] ([CNO], [DOCVERSION], [CB_CHECK_COVER], [CB_CHECK_BASIC], [CB_CHECK_SPEC], [CB_CHECK_DAHS], [CB_CHECK_LINK], [CB_CHECK_LED], [CB_CHECK_BASIC_C1], [CB_CHECK_BASIC_C1_AT], [CB_CHECK_SPEC_C1], [CB_CHECK_SPEC_C1_AT], [CB_CHECK_SPEC_C2], [CB_CHECK_SPEC_C2_AT], [CB_CHECK_SPEC_C3], [CB_CHECK_SPEC_C3_AT], [CB_CHECK_SPEC_C4], [CB_CHECK_SPEC_C4_AT], [CB_CHECK_SPEC_C5], [CB_CHECK_SPEC_C5_AT], [CB_CHECK_SPEC_C6], [CB_CHECK_SPEC_C6_AT], [CB_CHECK_SPEC_C7], [CB_CHECK_SPEC_C7_AT], [CB_CHECK_SPEC_C8], [CB_CHECK_SPEC_C8_AT], [CB_CHECK_SPEC_C9], [CB_CHECK_SPEC_C9_AT], [CB_CHECK_SPEC_C10], [CB_CHECK_SPEC_C10_AT], [CB_CHECK_SPEC_C11], [CB_CHECK_SPEC_C11_AT], [CB_CHECK_SPEC_C12], [CB_CHECK_SPEC_C12_AT], [CB_CHECK_DAHS_C1], [CB_CHECK_DAHS_C1_AT], [CB_CHECK_DAHS_C2], [CB_CHECK_DAHS_C2_AT], [CB_CHECK_LINK_C1], [CB_CHECK_LINK_C1_AT], [CB_CHECK_LINK_C2], [CB_CHECK_LINK_C2_AT], [CB_CHECK_LINK_C3], [CB_CHECK_LINK_C3_AT], [CB_CHECK_LED_C1], [CB_CHECK_LED_C1_AT], [CB_CHECK_LED_C2], [CB_CHECK_LED_C2_AT], [CB_CHECK_LED_C3], [CB_CHECK_LED_C3_AT], [C_ID], [C_DATE]) VALUES (@CNO, @DOCVERSION, @CB_CHECK_COVER, @CB_CHECK_BASIC, @CB_CHECK_SPEC, @CB_CHECK_DAHS, @CB_CHECK_LINK, @CB_CHECK_LED, @CB_CHECK_BASIC_C1, @CB_CHECK_BASIC_C1_AT, @CB_CHECK_SPEC_C1, @CB_CHECK_SPEC_C1_AT, @CB_CHECK_SPEC_C2, @CB_CHECK_SPEC_C2_AT, @CB_CHECK_SPEC_C3, @CB_CHECK_SPEC_C3_AT, @CB_CHECK_SPEC_C4, @CB_CHECK_SPEC_C4_AT, @CB_CHECK_SPEC_C5, @CB_CHECK_SPEC_C5_AT, @CB_CHECK_SPEC_C6, @CB_CHECK_SPEC_C6_AT, @CB_CHECK_SPEC_C7, @CB_CHECK_SPEC_C7_AT, @CB_CHECK_SPEC_C8, @CB_CHECK_SPEC_C8_AT, @CB_CHECK_SPEC_C9, @CB_CHECK_SPEC_C9_AT, @CB_CHECK_SPEC_C10, @CB_CHECK_SPEC_C10_AT, @CB_CHECK_SPEC_C11, @CB_CHECK_SPEC_C11_AT, @CB_CHECK_SPEC_C12, @CB_CHECK_SPEC_C12_AT, @CB_CHECK_DAHS_C1, @CB_CHECK_DAHS_C1_AT, @CB_CHECK_DAHS_C2, @CB_CHECK_DAHS_C2_AT, @CB_CHECK_LINK_C1, @CB_CHECK_LINK_C1_AT, @CB_CHECK_LINK_C2, @CB_CHECK_LINK_C2_AT, @CB_CHECK_LINK_C3, @CB_CHECK_LINK_C3_AT, @CB_CHECK_LED_C1, @CB_CHECK_LED_C1_AT, @CB_CHECK_LED_C2, @CB_CHECK_LED_C2_AT, @CB_CHECK_LED_C3, @CB_CHECK_LED_C3_AT, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_CHECKLIST] SET [CB_CHECK_COVER] = @CB_CHECK_COVER, [CB_CHECK_BASIC] = @CB_CHECK_BASIC, [CB_CHECK_SPEC] = @CB_CHECK_SPEC, [CB_CHECK_DAHS] = @CB_CHECK_DAHS, [CB_CHECK_LINK] = @CB_CHECK_LINK, [CB_CHECK_LED] = @CB_CHECK_LED, [CB_CHECK_BASIC_C1] = @CB_CHECK_BASIC_C1, [CB_CHECK_BASIC_C1_AT] = @CB_CHECK_BASIC_C1_AT, [CB_CHECK_SPEC_C1] = @CB_CHECK_SPEC_C1, [CB_CHECK_SPEC_C1_AT] = @CB_CHECK_SPEC_C1_AT, [CB_CHECK_SPEC_C2] = @CB_CHECK_SPEC_C2, [CB_CHECK_SPEC_C2_AT] = @CB_CHECK_SPEC_C2_AT, [CB_CHECK_SPEC_C3] = @CB_CHECK_SPEC_C3, [CB_CHECK_SPEC_C3_AT] = @CB_CHECK_SPEC_C3_AT, [CB_CHECK_SPEC_C4] = @CB_CHECK_SPEC_C4, [CB_CHECK_SPEC_C4_AT] = @CB_CHECK_SPEC_C4_AT, [CB_CHECK_SPEC_C5] = @CB_CHECK_SPEC_C5, [CB_CHECK_SPEC_C5_AT] = @CB_CHECK_SPEC_C5_AT, [CB_CHECK_SPEC_C6] = @CB_CHECK_SPEC_C6, [CB_CHECK_SPEC_C6_AT] = @CB_CHECK_SPEC_C6_AT, [CB_CHECK_SPEC_C7] = @CB_CHECK_SPEC_C7, [CB_CHECK_SPEC_C7_AT] = @CB_CHECK_SPEC_C7_AT, [CB_CHECK_SPEC_C8] = @CB_CHECK_SPEC_C8, [CB_CHECK_SPEC_C8_AT] = @CB_CHECK_SPEC_C8_AT, [CB_CHECK_SPEC_C9] = @CB_CHECK_SPEC_C9, [CB_CHECK_SPEC_C9_AT] = @CB_CHECK_SPEC_C9_AT, [CB_CHECK_SPEC_C10] = @CB_CHECK_SPEC_C10, [CB_CHECK_SPEC_C10_AT] = @CB_CHECK_SPEC_C10_AT, [CB_CHECK_SPEC_C11] = @CB_CHECK_SPEC_C11, [CB_CHECK_SPEC_C11_AT] = @CB_CHECK_SPEC_C11_AT, [CB_CHECK_SPEC_C12] = @CB_CHECK_SPEC_C12, [CB_CHECK_SPEC_C12_AT] = @CB_CHECK_SPEC_C12_AT, [CB_CHECK_DAHS_C1] = @CB_CHECK_DAHS_C1, [CB_CHECK_DAHS_C1_AT] = @CB_CHECK_DAHS_C1_AT, [CB_CHECK_DAHS_C2] = @CB_CHECK_DAHS_C2, [CB_CHECK_DAHS_C2_AT] = @CB_CHECK_DAHS_C2_AT, [CB_CHECK_LINK_C1] = @CB_CHECK_LINK_C1, [CB_CHECK_LINK_C1_AT] = @CB_CHECK_LINK_C1_AT, [CB_CHECK_LINK_C2] = @CB_CHECK_LINK_C2, [CB_CHECK_LINK_C2_AT] = @CB_CHECK_LINK_C2_AT, [CB_CHECK_LINK_C3] = @CB_CHECK_LINK_C3, [CB_CHECK_LINK_C3_AT] = @CB_CHECK_LINK_C3_AT, [CB_CHECK_LED_C1] = @CB_CHECK_LED_C1, [CB_CHECK_LED_C1_AT] = @CB_CHECK_LED_C1_AT, [CB_CHECK_LED_C2] = @CB_CHECK_LED_C2, [CB_CHECK_LED_C2_AT] = @CB_CHECK_LED_C2_AT, [CB_CHECK_LED_C3] = @CB_CHECK_LED_C3, [CB_CHECK_LED_C3_AT] = @CB_CHECK_LED_C3_AT, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"


        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_CHECKLIST where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

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

                    .InsertParameters.Add("CNO", Session("CNO"))
                    .InsertParameters.Add("DOCVERSION", Session("DOCVERSION"))
                    .InsertParameters.Add("CB_CHECK_COVER", CB_CHECK_COVER.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_BASIC", CB_CHECK_BASIC.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC", CB_CHECK_SPEC.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_DAHS", CB_CHECK_DAHS.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_LINK", CB_CHECK_LINK.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_LED", CB_CHECK_LED.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_BASIC_C1", CB_CHECK_BASIC_C1.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_BASIC_C1_AT", TB_CHECK_BASIC_C1.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C1", CB_CHECK_SPEC_C1.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C1_AT", TB_CHECK_SPEC_C1.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C2", CB_CHECK_SPEC_C2.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C2_AT", TB_CHECK_SPEC_C2.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C3", CB_CHECK_SPEC_C3.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C3_AT", TB_CHECK_SPEC_C3.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C4", CB_CHECK_SPEC_C4.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C4_AT", TB_CHECK_SPEC_C4.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C5", CB_CHECK_SPEC_C5.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C5_AT", TB_CHECK_SPEC_C5.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C6", CB_CHECK_SPEC_C6.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C6_AT", TB_CHECK_SPEC_C6.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C7", CB_CHECK_SPEC_C7.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C7_AT", TB_CHECK_SPEC_C7.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C8", CB_CHECK_SPEC_C8.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C8_AT", TB_CHECK_SPEC_C8.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C9", CB_CHECK_SPEC_C9.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C9_AT", TB_CHECK_SPEC_C9.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C10", CB_CHECK_SPEC_C10.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C10_AT", TB_CHECK_SPEC_C10.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C11", CB_CHECK_SPEC_C11.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C11_AT", TB_CHECK_SPEC_C11.Text)
                    .InsertParameters.Add("CB_CHECK_SPEC_C12", CB_CHECK_SPEC_C12.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_SPEC_C12_AT", TB_CHECK_SPEC_C12.Text)
                    .InsertParameters.Add("CB_CHECK_DAHS_C1", CB_CHECK_DAHS_C1.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_DAHS_C1_AT", TB_CHECK_DAHS_C1.Text)
                    .InsertParameters.Add("CB_CHECK_DAHS_C2", CB_CHECK_DAHS_C2.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_DAHS_C2_AT", TB_CHECK_DAHS_C2.Text)
                    .InsertParameters.Add("CB_CHECK_LINK_C1", CB_CHECK_LINK_C1.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_LINK_C1_AT", TB_CHECK_LINK_C1.Text)
                    .InsertParameters.Add("CB_CHECK_LINK_C2", CB_CHECK_LINK_C2.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_LINK_C2_AT", TB_CHECK_LINK_C2.Text)
                    .InsertParameters.Add("CB_CHECK_LINK_C3", CB_CHECK_LINK_C3.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_LINK_C3_AT", TB_CHECK_LINK_C3.Text)
                    .InsertParameters.Add("CB_CHECK_LED_C1", CB_CHECK_LED_C1.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_LED_C1_AT", TB_CHECK_LED_C1.Text)
                    .InsertParameters.Add("CB_CHECK_LED_C2", CB_CHECK_LED_C2.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_LED_C2_AT", TB_CHECK_LED_C2.Text)
                    .InsertParameters.Add("CB_CHECK_LED_C3", CB_CHECK_LED_C3.Checked.ToString)
                    .InsertParameters.Add("CB_CHECK_LED_C3_AT", TB_CHECK_LED_C3.Text)
                    .InsertParameters.Add("C_ID", Session("UserName"))
                    .InsertParameters.Add("C_DATE", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        Label_LED.Text = "資料新增失敗!"
                    Else
                        Label_LED.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_LED.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_LED.Text = ex.Message.ToString
            End Try


        Else

            'Update 
            Try

                With SDS_PlanPolFeature

                    .UpdateParameters.Add("CNO", Session("CNO"))
                    .UpdateParameters.Add("DOCVERSION", Session("DOCVERSION"))
                    .UpdateParameters.Add("CB_CHECK_COVER", CB_CHECK_COVER.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_BASIC", CB_CHECK_BASIC.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC", CB_CHECK_SPEC.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_DAHS", CB_CHECK_DAHS.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_LINK", CB_CHECK_LINK.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_LED", CB_CHECK_LED.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_BASIC_C1", CB_CHECK_BASIC_C1.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_BASIC_C1_AT", TB_CHECK_BASIC_C1.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C1", CB_CHECK_SPEC_C1.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C1_AT", TB_CHECK_SPEC_C1.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C2", CB_CHECK_SPEC_C2.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C2_AT", TB_CHECK_SPEC_C2.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C3", CB_CHECK_SPEC_C3.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C3_AT", TB_CHECK_SPEC_C3.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C4", CB_CHECK_SPEC_C4.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C4_AT", TB_CHECK_SPEC_C4.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C5", CB_CHECK_SPEC_C5.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C5_AT", TB_CHECK_SPEC_C5.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C6", CB_CHECK_SPEC_C6.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C6_AT", TB_CHECK_SPEC_C6.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C7", CB_CHECK_SPEC_C7.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C7_AT", TB_CHECK_SPEC_C7.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C8", CB_CHECK_SPEC_C8.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C8_AT", TB_CHECK_SPEC_C8.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C9", CB_CHECK_SPEC_C9.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C9_AT", TB_CHECK_SPEC_C9.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C10", CB_CHECK_SPEC_C10.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C10_AT", TB_CHECK_SPEC_C10.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C11", CB_CHECK_SPEC_C11.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C11_AT", TB_CHECK_SPEC_C11.Text)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C12", CB_CHECK_SPEC_C12.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_SPEC_C12_AT", TB_CHECK_SPEC_C12.Text)
                    .UpdateParameters.Add("CB_CHECK_DAHS_C1", CB_CHECK_DAHS_C1.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_DAHS_C1_AT", TB_CHECK_DAHS_C1.Text)
                    .UpdateParameters.Add("CB_CHECK_DAHS_C2", CB_CHECK_DAHS_C2.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_DAHS_C2_AT", TB_CHECK_DAHS_C2.Text)
                    .UpdateParameters.Add("CB_CHECK_LINK_C1", CB_CHECK_LINK_C1.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_LINK_C1_AT", TB_CHECK_LINK_C1.Text)
                    .UpdateParameters.Add("CB_CHECK_LINK_C2", CB_CHECK_LINK_C2.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_LINK_C2_AT", TB_CHECK_LINK_C2.Text)
                    .UpdateParameters.Add("CB_CHECK_LINK_C3", CB_CHECK_LINK_C3.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_LINK_C3_AT", TB_CHECK_LINK_C3.Text)
                    .UpdateParameters.Add("CB_CHECK_LED_C1", CB_CHECK_LED_C1.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_LED_C1_AT", TB_CHECK_LED_C1.Text)
                    .UpdateParameters.Add("CB_CHECK_LED_C2", CB_CHECK_LED_C2.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_LED_C2_AT", TB_CHECK_LED_C2.Text)
                    .UpdateParameters.Add("CB_CHECK_LED_C3", CB_CHECK_LED_C3.Checked.ToString)
                    .UpdateParameters.Add("CB_CHECK_LED_C3_AT", TB_CHECK_LED_C3.Text)
                    .UpdateParameters.Add("U_ID", Session("UserName"))
                    .UpdateParameters.Add("U_Date", Today())
                    .UpdateCommand = UpdateSQL

                    aff_row = .Update()

                    If aff_row = 0 Then
                        Label_LED.Text = "資料更新失敗!"
                    Else
                        Label_LED.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                Label_LED.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                Label_LED.Text = ex.Message.ToString
            End Try
        End If

        SDS_PlanPolFeature.Dispose()

    End Sub

    Private Sub FillCheckList()

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select * from DOC_SET_CHECKLIST where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.ReturnCode >= 1 Then

                CB_CHECK_COVER.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_COVER").ToString.Trim)
                CB_CHECK_BASIC.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_BASIC").ToString.Trim)
                CB_CHECK_SPEC.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC").ToString.Trim)
                CB_CHECK_DAHS.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_DAHS").ToString.Trim)
                CB_CHECK_LINK.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_LINK").ToString.Trim)
                CB_CHECK_LED.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_LED").ToString.Trim)
                CB_CHECK_BASIC_C1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_BASIC_C1").ToString.Trim)
                CB_CHECK_SPEC_C1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C1").ToString.Trim)
                CB_CHECK_SPEC_C2.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C2").ToString.Trim)
                CB_CHECK_SPEC_C3.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C3").ToString.Trim)
                CB_CHECK_SPEC_C4.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C4").ToString.Trim)
                CB_CHECK_SPEC_C5.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C5").ToString.Trim)
                CB_CHECK_SPEC_C6.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C6").ToString.Trim)
                CB_CHECK_SPEC_C7.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C7").ToString.Trim)
                CB_CHECK_SPEC_C8.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C8").ToString.Trim)
                CB_CHECK_SPEC_C9.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C9").ToString.Trim)
                CB_CHECK_SPEC_C10.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C10").ToString.Trim)
                CB_CHECK_SPEC_C11.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C11").ToString.Trim)
                CB_CHECK_SPEC_C12.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C12").ToString.Trim)
                CB_CHECK_DAHS_C1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_DAHS_C1").ToString.Trim)
                CB_CHECK_DAHS_C2.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_DAHS_C2").ToString.Trim)
                CB_CHECK_LINK_C1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_LINK_C1").ToString.Trim)
                CB_CHECK_LINK_C2.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_LINK_C2").ToString.Trim)
                CB_CHECK_LINK_C3.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_LINK_C3").ToString.Trim)
                CB_CHECK_LED_C1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_LED_C1").ToString.Trim)
                CB_CHECK_LED_C2.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_LED_C2").ToString.Trim)
                CB_CHECK_LED_C3.Checked = CBool(getresult.returnDataTable.Rows(0).Item("CB_CHECK_LED_C3").ToString.Trim)

                TB_CHECK_BASIC_C1.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_BASIC_C1_AT").ToString)
                TB_CHECK_SPEC_C1.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C1_AT").ToString)
                TB_CHECK_SPEC_C2.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C2_AT").ToString)
                TB_CHECK_SPEC_C3.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C3_AT").ToString)
                TB_CHECK_SPEC_C4.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C4_AT").ToString)
                TB_CHECK_SPEC_C5.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C5_AT").ToString)
                TB_CHECK_SPEC_C6.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C6_AT").ToString)
                TB_CHECK_SPEC_C7.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C7_AT").ToString)
                TB_CHECK_SPEC_C8.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C8_AT").ToString)
                TB_CHECK_SPEC_C9.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C9_AT").ToString)
                TB_CHECK_SPEC_C10.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C10_AT").ToString)
                TB_CHECK_SPEC_C11.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C11_AT").ToString)
                TB_CHECK_SPEC_C12.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_SPEC_C12_AT").ToString)
                TB_CHECK_DAHS_C1.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_DAHS_C1_AT").ToString)
                TB_CHECK_DAHS_C2.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_DAHS_C2_AT").ToString)
                TB_CHECK_LINK_C1.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_LINK_C1_AT").ToString)
                TB_CHECK_LINK_C2.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_LINK_C2_AT").ToString)
                TB_CHECK_LINK_C3.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_LINK_C3_AT").ToString)
                TB_CHECK_LED_C1.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_LED_C1_AT").ToString)
                TB_CHECK_LED_C2.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_LED_C2_AT").ToString)
                TB_CHECK_LED_C3.Text = (getresult.returnDataTable.Rows(0).Item("CB_CHECK_LED_C3_AT").ToString)

            End If

        Catch ex As Exception


        End Try

    End Sub


    Protected Sub RBL_REG_SET_CheckedChanged(sender As Object, e As EventArgs) Handles RBL_REG_SET.CheckedChanged

        If RBL_REG_SET.Checked Then

            RBL_REG_MODI.Checked = False
            CB_5_MOD_C.Checked = False
            CB_5_MOD_OTHER.Checked = False

        ElseIf RBL_REG_MODI.Checked = True Then

            RBL_REG_SET.Checked = False
        End If

    End Sub

    Protected Sub RBL_REG_MODI_CheckedChanged(sender As Object, e As EventArgs) Handles RBL_REG_MODI.CheckedChanged

        If RBL_REG_SET.Checked Then

            RBL_REG_MODI.Checked = False
            CB_5_MOD_C.Checked = False
            CB_5_MOD_OTHER.Checked = False

        ElseIf RBL_REG_MODI.Checked = True Then

            RBL_REG_SET.Checked = False
        End If

    End Sub

    Protected Sub GV_SETITEM_RowDeleted(sender As Object, e As Data.ASPxDataDeletedEventArgs) Handles GV_SETITEM.RowDeleted, GV_ITEM_SELF.RowDeleted

        '連帶刪除....SPEC 貳大項資料 該監測點所有測項

        Try
            Dim tempcno As String = e.Keys.Item(0).ToString().Trim
            Dim tempdpno As String = e.Keys.Item(1).ToString().Trim
            Dim tempDPTYPE As String = e.Keys.Item(2).ToString().Trim
            Dim tempDocVersion As String = e.Keys.Item(3).ToString().Trim

            EraseSpecItem(tempcno, tempdpno, tempDPTYPE, CInt(tempDocVersion))


        Catch ex As Exception

        End Try


    End Sub


    Private Sub EraseSpecPDFItem(ByVal strCno As String, ByVal StrDocNumber As String, ByVal StrDocVersion As UInteger)

        Try

            Dim cn As New SqlConnection(DBconntext)
            Dim cmd As New SqlCommand("delete from DOC_PDF_BASIC where cno='" + strCno + "' and DocNumber='" + StrDocNumber.ToString.Trim + "' AND docversion='" + StrDocVersion.ToString.Trim + "' ", cn)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try

    End Sub


    Private Sub EraseSpecItem(ByVal strCno As String, ByVal strDPNO As String, ByVal strDPType As String, ByVal StrDocVersion As UInteger)

        Try
            Dim cn As New SqlConnection(DBconntext)
            Dim cmd As New SqlCommand("delete from DOC_SET_SPEC where cno='" + strCno + "' and dp_no='" + strDPNO + "' and dptype='" + strDPType + "' AND docversion='" + StrDocVersion.ToString.Trim + "' ", cn)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub EraseAuditHelp(ByVal strCno As String, ByVal StrDocVersion As UInteger)

        Try
            Dim cn As New SqlConnection(DBconntext)
            Dim cmd As New SqlCommand("delete from DOC_CHECKRESULT where cno='" + strCno + "' and  docversion='" + StrDocVersion.ToString.Trim + "' ", cn)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub GV_SETITEM_RowUpdated(sender As Object, e As Data.ASPxDataUpdatedEventArgs) Handles GV_SETITEM.RowUpdated



        Dim getresult As DbResult
        Dim MYTYPE As String = ""
        Dim strItem248, strItem259, strItem246, strItem247, strItem243, strItem210, strItem299, strItem330, strItem242 As String

        Dim tempcno As String = e.Keys.Item(0).ToString().Trim
        Dim tempdpno As String = e.Keys.Item(1).ToString().Trim
        Dim tempDPTYPE As String = e.Keys.Item(2).ToString().Trim
        Dim tempDocVersion As String = e.Keys.Item(3).ToString().Trim

        Dim Sqlstr As String = "Select  *  from DOC_SET_ITEM  where cno='" + tempcno + "'  and  DP_NO='" + tempdpno + "'  and DocVersion='" + tempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.ReturnCode >= 1 Then

                strItem248 = getresult.returnDataTable.Rows(0).Item("ITEM_248").ToString.Trim
                strItem259 = getresult.returnDataTable.Rows(0).Item("ITEM_259").ToString.Trim
                strItem246 = getresult.returnDataTable.Rows(0).Item("ITEM_246").ToString.Trim
                strItem247 = getresult.returnDataTable.Rows(0).Item("ITEM_247").ToString.Trim
                strItem243 = getresult.returnDataTable.Rows(0).Item("ITEM_243").ToString.Trim
                strItem210 = getresult.returnDataTable.Rows(0).Item("ITEM_210").ToString.Trim
                strItem299 = getresult.returnDataTable.Rows(0).Item("ITEM_299").ToString.Trim
                strItem330 = getresult.returnDataTable.Rows(0).Item("ITEM_VIDEO").ToString.Trim
                strItem242 = getresult.returnDataTable.Rows(0).Item("ITEM_242").ToString.Trim

            End If

        Catch ex As Exception


        End Try

        If strItem248 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "248", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "248", tempDocVersion, tempDPTYPE)

        End If
        If strItem259 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "259", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "259", tempDocVersion, tempDPTYPE)
        End If
        If strItem246 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "246", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "246", tempDocVersion, tempDPTYPE)
        End If
        If strItem247 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "247", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "247", tempDocVersion, tempDPTYPE)
        End If
        If strItem243 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "243", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "243", tempDocVersion, tempDPTYPE)
        End If

        If strItem242 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "242", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "242", tempDocVersion, tempDPTYPE)
        End If

        If strItem210 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "210", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "210", tempDocVersion, tempDPTYPE)
        End If

        If strItem299 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "299", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "299", tempDocVersion, tempDPTYPE)
        End If

        If strItem330 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "330", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "330", tempDocVersion, tempDPTYPE)
        End If

    End Sub

    Protected Sub CB_19_Analog_CheckedChanged(sender As Object, e As EventArgs) Handles CB_19_Analog.CheckedChanged

        If CB_19_Analog.Checked Then

            DDL_19_Analog.Visible = True
            TB_19_DIGTAL.Visible = False


        Else

            DDL_19_Analog.Visible = False
            TB_19_DIGTAL.Visible = True

        End If

    End Sub

    Protected Sub CB_19_Digital_CheckedChanged(sender As Object, e As EventArgs) Handles CB_19_Digital.CheckedChanged

        If CB_19_Digital.Checked Then
            DDL_19_Analog.Visible = False
            TB_19_DIGTAL.Visible = True
        Else
            DDL_19_Analog.Visible = True
            TB_19_DIGTAL.Visible = False

        End If


    End Sub


    Private Sub GV_SETITEM_CommandButtonInitialize(sender As Object, e As ASPxGridViewCommandButtonEventArgs) Handles GV_SETITEM.CommandButtonInitialize

        If Session("AccessRight") = "TRUE" Then
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

    Protected Sub GV_ITEM_SELF_CommandButtonInitialize(sender As Object, e As ASPxGridViewCommandButtonEventArgs) Handles GV_ITEM_SELF.CommandButtonInitialize

        If Session("AccessRight") = "TRUE" Then
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

    Protected Sub GV_ITEM_SELF_InitNewRow(sender As Object, e As Data.ASPxDataInitNewRowEventArgs) Handles GV_ITEM_SELF.InitNewRow

        e.NewValues("CNO") = Session("CNO")
        e.NewValues("DOCTYPE") = "設置"
        e.NewValues("DOCVERSION") = Session("DOCVERSION")

    End Sub

    Protected Sub GV_ITEM_SELF_RowDeleted(sender As Object, e As Data.ASPxDataDeletedEventArgs)

        '連帶刪除....SPEC 貳大項資料 該監測點所有測項

        Try
            Dim tempcno As String = e.Keys.Item(0).ToString().Trim
            Dim tempdpno As String = e.Keys.Item(1).ToString().Trim
            Dim tempDPTYPE As String = e.Keys.Item(2).ToString().Trim
            Dim tempDocVersion As String = e.Keys.Item(3).ToString().Trim

            EraseSpecItem(tempcno, tempdpno, tempDPTYPE, CInt(tempDocVersion))
            EraseSpecPDFItem(tempcno, tempdpno, CInt(tempDocVersion))


        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GV_ITEM_SELF_RowUpdated(sender As Object, e As Data.ASPxDataUpdatedEventArgs) Handles GV_ITEM_SELF.RowUpdated


        Dim getresult As DbResult
        Dim MYTYPE As String = ""
        Dim strItem241, strItem267 As String

        Dim tempcno As String = e.Keys.Item(0).ToString().Trim
        Dim tempdpno As String = e.Keys.Item(1).ToString().Trim
        Dim tempDPTYPE As String = e.Keys.Item(2).ToString().Trim
        Dim tempDocVersion As String = e.Keys.Item(3).ToString().Trim

        Dim Sqlstr As String = "Select  *  from DOC_SET_ITEM  where cno='" + tempcno + "'  and  DP_NO='" + tempdpno + "'  and DocVersion='" + tempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.ReturnCode >= 1 Then

                strItem241 = getresult.returnDataTable.Rows(0).Item("ITEM_241").ToString.Trim
                strItem267 = getresult.returnDataTable.Rows(0).Item("ITEM_267").ToString.Trim

            End If

        Catch ex As Exception


        End Try

        If strItem241 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "241", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "241", tempDocVersion, tempDPTYPE)

        End If
        If strItem267 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "267", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "267", tempDocVersion, tempDPTYPE)
        End If


    End Sub

    Private SelectedValue_Self As List(Of Object)

    Private Sub GetSelectedValue_self()
        Dim fieldNames As List(Of String) = New List(Of String)()
        For Each column As GridViewColumn In GV_ITEM_SELF.Columns
            If TypeOf column Is GridViewDataColumn Then
                fieldNames.Add((CType(column, GridViewDataColumn)).FieldName)
            End If
        Next column
        SelectedValue_Self = GV_ITEM_SELF.GetSelectedFieldValues(fieldNames.ToArray())
    End Sub

    Private Sub PrintSelectedValue_self()
        If SelectedValue_Self Is Nothing Then
            Return
        End If
        Dim result As String = ""
        For Each item As Object() In SelectedValue_Self
            For Each value As Object In item
                result &= String.Format("{0}    ", value)
            Next value
            result &= "</br>"
        Next item
        Literal1.Text = result
    End Sub

    Private Sub SetSpecItem_self()

        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempDocVersion As String = ""
        Dim tempDPTYPE As String = ""
        Dim strItem241, strItem267 As String


        If SelectedValue_Self Is Nothing Then
            Return
        End If
        Dim result As String = ""
        For Each item As Object() In SelectedValue_Self
            For Each value As Object In item
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempDocVersion = item(2).ToString()
                tempDPTYPE = item(6).ToString()
                strItem241 = item(4).ToString()
                strItem267 = item(5).ToString()

            Next value
        Next item

        If strItem241 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "241", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "241", tempDocVersion, tempDPTYPE)

        End If
        If strItem267 = "True" Then
            CopySpecItemStatus("SET", tempcno, tempdpno, "267", tempDocVersion, tempDPTYPE)
        Else
            EraseSpecItemStatus("SET", tempcno, tempdpno, "267", tempDocVersion, tempDPTYPE)
        End If


    End Sub
    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempDocVersion As String = ""
        Dim tempSetType As String = "設置"
        Dim strItem241 As String = "241"
        Dim strItem267 As String = "267"

        'Check  是否已存在

        If tempSetType = "設置" Then

            GetSelectedValue_self()
            PrintSelectedValue_self()


            For Each item As Object() In SelectedValue_Self
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempDocVersion = item(2).ToString()

                Session("DP_NO") = tempdpno
                Session("DOCVERSION") = tempDocVersion

            Next item

            Dim getresult As DbResult
            Dim Sqlstr As String = ""

            Sqlstr = "select * from DOC_SET_SPEC where cno='" + Session("CNO") + "' and dp_no='" + tempdpno + "' and docversion='" + tempDocVersion + "' and item in('" + strItem241 + "','" + strItem267 + "')"

            Try

                getresult = EIPDB.GetData(Sqlstr)

                If getresult.ReturnCode = -1 Then
                    SetSpecItem_self()
                Else
                    If getresult.returnDataTable.Rows.Count = 0 Then

                        SetSpecItem_self()

                    End If
                End If


            Catch ex As Exception

            End Try


        Else

            PrintSelectedValue_self()
            SetSpecItem_self()
            For Each item As Object() In SelectedValue_Self
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempDocVersion = item(2).ToString()

                Session("DP_NO") = tempdpno
                Session("DOCVERSION") = tempDocVersion

            Next item
        End If
    End Sub
    Protected Sub GV_SPEC_SELF_SelectionChanged(sender As Object, e As EventArgs) Handles GV_SPEC_SELF.SelectionChanged


        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempitem As String = ""
        Dim tempDPTYPE As String = ""


        Try
            Dim fieldValue_self As List(Of Object) = GV_SPEC_SELF.GetSelectedFieldValues(New String() {"CNO", "DP_NO", "ITEM", "DPTYPE"})
            For Each item As Object() In fieldValue_self
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempitem = item(2).ToString()
                tempDPTYPE = item(3).ToString()

                Session("DP_NO") = tempdpno
                Session("ITEM") = tempitem
                Session("DPTYPE") = tempDPTYPE

            Next item

        Catch ex As Exception

        End Try

        Fillspec_self()


    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click

        Dim tempcno As String = ""
        Dim tempdpno As String = ""
        Dim tempitem As String = ""
        Dim tempDPType As String = ""

        Try

            Dim fieldValue_self As List(Of Object) = GV_SPEC_SELF.GetSelectedFieldValues(New String() {"CNO", "DP_NO", "ITEM", "DPTYPE"})
            For Each item As Object() In fieldValue_self
                'ASPxListBox1.Items.Add(item(0).ToString())
                tempcno = item(0).ToString()
                tempdpno = item(1).ToString()
                tempitem = item(2).ToString()
                tempDPType = item(3).ToString()

                Session("DP_NO") = tempdpno
                Session("ITEM") = tempitem
                Session("DPTYPE") = tempDPType

            Next item

            Fillspec_self()

        Catch ex As Exception

        End Try

    End Sub


    Protected Sub ASPxButton4_Click1(sender As Object, e As EventArgs) Handles ASPxButton4.Click

        Dim TempCno, TempDP_NO, TempDocVersion, TempITEM As String
        Dim getresult As DbResult
        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim InsertSQL As String = "INSERT INTO [DOC_SET_SPEC] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO], [SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD],[SPEC_SAMPLE_METHOD_DESP], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC],[SPEC_COSPEC_NOTE], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE],[SPEC_NOTE], [C_ID], [C_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM, @DPNO_DESP, @SPEC_INSTEAD_YES,@SPEC_INSTEAD_NO, @SPEC_MONITOROTHER_YES,@SPEC_MONITOROTHER_NO, @SPEC_MO_NOTE_DPNO, @SPEC_MO_NOTE_DPNO1, @SPEC_MO_NOTE_QUA, @SPEC_INS_DATE, @SPEC_AGENTNAME, @SPEC_EQU_MODEL, @SPEC_EQU_SERIAL, @SPEC_SAMPLE_METHOD,@SPEC_SAMPLE_METHOD_DESP, @SPEC_SAMPLE_METHOD_FILTERYES, @SPEC_SAMPLE_METHOD_FILTERNO, @SPEC_CALC_EQU, @SPEC_CALC_FREQ, @SPEC_CALC_METHOD, @SPEC_MAIN_FREQ, @SPEC_MAIN_METHOD, @SPEC_MATERIAL, @SPEC_WASTELIQUID, @SPEC_MATERIAL_FREQ, @SPEC_MEA_SCOPE, @SPEC_MEA_SCOPEUNIT, @SPEC_MEA_RESTIME, @SPEC_MEA_RESTIMEUNIT, @SPEC_MEA_FREQ, @SPEC_MEA_FREQUNIT, @SPEC_CALCAVG, @SPEC_DOCATTACH_INST, @SPEC_DOCATTACH_CALI, @SPEC_VIDEO_F, @SPEC_VIDEO_F_MEMO, @SPEC_VIDEO_R, @SPEC_VIDEO_R_MEMO, @SPEC_VIDEO_NV, @SPEC_VIDEO_NV_MEMO, @SPEC_ANASIG_YES, @SPEC_ANASIG, @SPEC_DIGSIG_YES, @SPEC_DIGSIG, @SPEC_DO_HARDWARE_CONNECT, @SPEC_DO_HARDWARE_CONNPARA, @SPEC_DO_HARDWARE_DOC, @SPEC_PLCAGENT, @SPEC_COSPEC,@SPEC_COSPEC_NOTE, @SPEC_H_CHANGE, @SPEC_H_CHANGE_NOTE,@SPEC_NOTE, @C_ID, @C_DATE)"
        Dim UpdateSQL As String = "UPDATE [DOC_SET_SPEC] SET [DPNO_DESP] = @DPNO_DESP, [SPEC_INSTEAD_YES] = @SPEC_INSTEAD_YES,[SPEC_INSTEAD_NO] = @SPEC_INSTEAD_NO, [SPEC_MONITOROTHER_YES] = @SPEC_MONITOROTHER_YES,[SPEC_MONITOROTHER_NO] = @SPEC_MONITOROTHER_NO, [SPEC_MO_NOTE_DPNO] = @SPEC_MO_NOTE_DPNO, [SPEC_MO_NOTE_DPNO1] = @SPEC_MO_NOTE_DPNO1, [SPEC_MO_NOTE_QUA] = @SPEC_MO_NOTE_QUA, [SPEC_INS_DATE] = @SPEC_INS_DATE, [SPEC_AGENTNAME] = @SPEC_AGENTNAME, [SPEC_EQU_MODEL] = @SPEC_EQU_MODEL, [SPEC_EQU_SERIAL] = @SPEC_EQU_SERIAL, [SPEC_SAMPLE_METHOD] = @SPEC_SAMPLE_METHOD,[SPEC_SAMPLE_METHOD_DESP] = @SPEC_SAMPLE_METHOD_DESP, [SPEC_SAMPLE_METHOD_FILTERYES] = @SPEC_SAMPLE_METHOD_FILTERYES, [SPEC_SAMPLE_METHOD_FILTERNO] = @SPEC_SAMPLE_METHOD_FILTERNO, [SPEC_CALC_EQU] = @SPEC_CALC_EQU, [SPEC_CALC_FREQ] = @SPEC_CALC_FREQ, [SPEC_CALC_METHOD] = @SPEC_CALC_METHOD, [SPEC_MAIN_FREQ] = @SPEC_MAIN_FREQ, [SPEC_MAIN_METHOD] = @SPEC_MAIN_METHOD, [SPEC_MATERIAL] = @SPEC_MATERIAL, [SPEC_WASTELIQUID] = @SPEC_WASTELIQUID, [SPEC_MATERIAL_FREQ] = @SPEC_MATERIAL_FREQ, [SPEC_MEA_SCOPE] = @SPEC_MEA_SCOPE, [SPEC_MEA_SCOPEUNIT] = @SPEC_MEA_SCOPEUNIT, [SPEC_MEA_RESTIME] = @SPEC_MEA_RESTIME, [SPEC_MEA_RESTIMEUNIT] = @SPEC_MEA_RESTIMEUNIT, [SPEC_MEA_FREQ] = @SPEC_MEA_FREQ, [SPEC_MEA_FREQUNIT] = @SPEC_MEA_FREQUNIT, [SPEC_CALCAVG] = @SPEC_CALCAVG, [SPEC_DOCATTACH_INST] = @SPEC_DOCATTACH_INST, [SPEC_DOCATTACH_CALI] = @SPEC_DOCATTACH_CALI, [SPEC_VIDEO_F] = @SPEC_VIDEO_F, [SPEC_VIDEO_F_MEMO] = @SPEC_VIDEO_F_MEMO, [SPEC_VIDEO_R] = @SPEC_VIDEO_R, [SPEC_VIDEO_R_MEMO] = @SPEC_VIDEO_R_MEMO, [SPEC_VIDEO_NV] = @SPEC_VIDEO_NV, [SPEC_VIDEO_NV_MEMO] = @SPEC_VIDEO_NV_MEMO, [SPEC_ANASIG_YES] = @SPEC_ANASIG_YES, [SPEC_ANASIG] = @SPEC_ANASIG, [SPEC_DIGSIG_YES] = @SPEC_DIGSIG_YES, [SPEC_DIGSIG] = @SPEC_DIGSIG, [SPEC_DO_HARDWARE_CONNECT] = @SPEC_DO_HARDWARE_CONNECT, [SPEC_DO_HARDWARE_CONNPARA] = @SPEC_DO_HARDWARE_CONNPARA, [SPEC_DO_HARDWARE_DOC] = @SPEC_DO_HARDWARE_DOC, [SPEC_PLCAGENT] = @SPEC_PLCAGENT, [SPEC_COSPEC] = @SPEC_COSPEC,[SPEC_COSPEC_NOTE] = @SPEC_COSPEC_NOTE, [SPEC_H_CHANGE] = @SPEC_H_CHANGE, [SPEC_H_CHANGE_NOTE] = @SPEC_H_CHANGE_NOTE,[SPEC_NOTE]=@SPEC_NOTE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM"
        Dim InsertSQL_PDF As String = "INSERT INTO [DOC_SET_PDF] ([CNO], [DP_NO], [DOCVERSION], [ITEM], [DDL61], [DDL62], [DDL65], [DDL66], [DDL67], [DDL611], [DDL617A], [DDL617B], [DDL619A], [DDL619B], [DDL619C], [DDL620], [CreatorID], [CreateDate]) VALUES (@CNO, @DP_NO, @DOCVERSION, @ITEM, @DDL61, @DDL62, @DDL65, @DDL66, @DDL67, @DDL611, @DDL617A, @DDL617B, @DDL619A, @DDL619B, @DDL619C, @DDL620, @CreatorID, @CreateDate)"
        Dim UpdateSQL_PDF As String = "UPDATE [DOC_SET_PDF] SET [DDL61] = @DDL61, [DDL62] = @DDL62, [DDL65] = @DDL65, [DDL66] = @DDL66, [DDL67] = @DDL67, [DDL611] = @DDL611, [DDL617A] = @DDL617A, [DDL617B] = @DDL617B, [DDL619A] = @DDL619A, [DDL619B] = @DDL619B, [DDL619C] = @DDL619C, [DDL620] = @DDL620, [ModifyID] = @ModifyID, [ModifyDate] = @ModifyDate  WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM"

        Dim strScript_NoDPNO As String = "<script language=JavaScript> alert(""請先選取[監測位置]後再存檔""); </script>"
        Dim strScript_NoInstDate As String = "<script language=JavaScript> alert(""請先填入(三)安裝日期再存檔""); </script>"

        Dim SDS_PlanPolFeature_self As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature_self.ConnectionString = DBconntext

        Dim SDS_PlanPolFeature_PDF As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature_PDF.ConnectionString = DBconntext

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")
        TempITEM = ASPxRadioButtonList1.Value.ToString

        If TempDP_NO = "" Then

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_NoDPNO)
            Exit Sub

        End If

        If ASPxDateEdit1.Text = "" Then

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_NoInstDate)
            Exit Sub

        End If



        Dim Sqlstr As String = "Select * from DOC_SET_SPEC where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempITEM + "'"
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempITEM + "'"

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

                With SDS_PlanPolFeature_self

                    .InsertParameters.Add("CNo", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    '.InsertParameters.Add("DP_NO", RBL_SPEC_DPNO.SelectedItem.Value)
                    .InsertParameters.Add("DP_NO", Session("DP_NO"))
                    .InsertParameters.Add("ITEM", ASPxRadioButtonList1.SelectedItem.Value)
                    .InsertParameters.Add("DPTYPE", Session("DPTYPE"))
                    .InsertParameters.Add("DPNO_DESP", ASPxTextBox1.Text)
                    .InsertParameters.Add("SPEC_INSTEAD_YES", RadioButton1.Checked.ToString)
                    .InsertParameters.Add("SPEC_INSTEAD_NO  ", RadioButton2.Checked.ToString)
                    .InsertParameters.Add("SPEC_MONITOROTHER_YES", RadioButton3.Checked.ToString)
                    .InsertParameters.Add("SPEC_MONITOROTHER_NO", RadioButton4.Checked.ToString)
                    .InsertParameters.Add("SPEC_MO_NOTE_DPNO", ASPxTextBox3.Text)
                    .InsertParameters.Add("SPEC_MO_NOTE_DPNO1", ASPxTextBox4.Text)
                    .InsertParameters.Add("SPEC_MO_NOTE_QUA", "")
                    .InsertParameters.Add("SPEC_INS_DATE", CDate(ASPxDateEdit1.Text))
                    .InsertParameters.Add("SPEC_AGENTNAME", ASPxTextBox5.Text)
                    .InsertParameters.Add("SPEC_EQU_MODEL", ASPxTextBox6.Text)
                    .InsertParameters.Add("SPEC_EQU_SERIAL", ASPxTextBox7.Text)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD", ASPxTextBox8.Text)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD_DESP", ASPxTextBox9.Text)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD_FILTERYES", RadioButton5.Checked.ToString)
                    .InsertParameters.Add("SPEC_SAMPLE_METHOD_FILTERNO", RadioButton6.Checked.ToString)
                    .InsertParameters.Add("SPEC_CALC_EQU", ASPxTextBox10.Text)
                    .InsertParameters.Add("SPEC_CALC_FREQ", ASPxTextBox11.Text)
                    .InsertParameters.Add("SPEC_CALC_METHOD", RadioButtonList1.Text)
                    .InsertParameters.Add("SPEC_MAIN_FREQ", ASPxTextBox12.Text)
                    .InsertParameters.Add("SPEC_MAIN_METHOD", RadioButtonList2.Text)
                    .InsertParameters.Add("SPEC_MATERIAL", ASPxTextBox13.Text)
                    .InsertParameters.Add("SPEC_WASTELIQUID", RadioButtonList3.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_MATERIAL_FREQ", ASPxTextBox14.Text)
                    .InsertParameters.Add("SPEC_MEA_SCOPE", ASPxTextBox15.Text)
                    .InsertParameters.Add("SPEC_MEA_SCOPEUNIT", DropDownList1.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_MEA_RESTIME", ASPxTextBox16.Text)
                    .InsertParameters.Add("SPEC_MEA_RESTIMEUNIT", DropDownList2.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_MEA_FREQ", ASPxTextBox17.Text)
                    .InsertParameters.Add("SPEC_MEA_FREQUNIT", DropDownList3.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_CALCAVG", ASPxTextBox18.Text)
                    .InsertParameters.Add("SPEC_DOCATTACH_INST", ASPxCheckBox2.Checked.ToString)
                    .InsertParameters.Add("SPEC_DOCATTACH_CALI", ASPxCheckBox1.Checked.ToString)
                    .InsertParameters.Add("SPEC_VIDEO_F", RadioButtonList4.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_VIDEO_F_MEMO", ASPxTextBox19.Text)
                    .InsertParameters.Add("SPEC_VIDEO_R", RadioButtonList5.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_VIDEO_R_MEMO", ASPxTextBox20.Text)
                    .InsertParameters.Add("SPEC_VIDEO_NV", RadioButtonList6.SelectedValue.ToString)
                    .InsertParameters.Add("SPEC_VIDEO_NV_MEMO", ASPxTextBox21.Text)
                    .InsertParameters.Add("SPEC_ANASIG_YES", RadioButton7.Checked.ToString)
                    .InsertParameters.Add("SPEC_ANASIG", DropDownList4.SelectedValue)
                    .InsertParameters.Add("SPEC_DIGSIG_YES", RadioButton8.Checked.ToString)
                    .InsertParameters.Add("SPEC_DIGSIG", ASPxTextBox22.Text)
                    .InsertParameters.Add("SPEC_DO_HARDWARE_CONNECT", ASPxCheckBox3.Checked.ToString)
                    .InsertParameters.Add("SPEC_DO_HARDWARE_CONNPARA", ASPxCheckBox4.Checked.ToString)
                    .InsertParameters.Add("SPEC_DO_HARDWARE_DOC", ASPxCheckBox5.Checked.ToString)
                    .InsertParameters.Add("SPEC_PLCAGENT", ASPxTextBox23.Text)
                    .InsertParameters.Add("SPEC_COSPEC", RadioButtonList7.SelectedItem.Value)
                    .InsertParameters.Add("SPEC_COSPEC_NOTE", ASPxTextBox24.Text)
                    .InsertParameters.Add("SPEC_H_CHANGE", RadioButtonList8.SelectedItem.Value)
                    .InsertParameters.Add("SPEC_H_CHANGE_NOTE", ASPxTextBox25.Text)
                    .InsertParameters.Add("SPEC_NOTE", ASPxMemo1.Text)
                    .InsertParameters.Add("C_ID", Session("UserName"))
                    .InsertParameters.Add("C_DATE", Today())
                    .InsertCommand = InsertSQL

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        ASPxLabel130.Text = "資料新增失敗!"
                    Else
                        ASPxLabel130.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                ASPxLabel130.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                ASPxLabel130.Text = ex.Message.ToString
            End Try


        Else

            'Update 
            Try

                With SDS_PlanPolFeature_self

                    .UpdateParameters.Add("CNo", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DP_NO", Session("DP_NO"))
                    .UpdateParameters.Add("ITEM", ASPxRadioButtonList1.SelectedItem.Value)
                    .UpdateParameters.Add("DPTYPE", Session("DPTYPE"))
                    .UpdateParameters.Add("DPNO_DESP", ASPxTextBox1.Text)
                    .UpdateParameters.Add("SPEC_INSTEAD_YES", RadioButton1.Checked.ToString)
                    .UpdateParameters.Add("SPEC_INSTEAD_NO  ", RadioButton2.Checked.ToString)
                    .UpdateParameters.Add("SPEC_MONITOROTHER_YES", RadioButton3.Checked.ToString)
                    .UpdateParameters.Add("SPEC_MONITOROTHER_NO", RadioButton4.Checked.ToString)
                    .UpdateParameters.Add("SPEC_MO_NOTE_DPNO", ASPxTextBox3.Text)
                    .UpdateParameters.Add("SPEC_MO_NOTE_DPNO1", ASPxTextBox4.Text)
                    .UpdateParameters.Add("SPEC_MO_NOTE_QUA", "")
                    .UpdateParameters.Add("SPEC_INS_DATE", CDate(ASPxDateEdit1.Text))
                    .UpdateParameters.Add("SPEC_AGENTNAME", ASPxTextBox5.Text)
                    .UpdateParameters.Add("SPEC_EQU_MODEL", ASPxTextBox6.Text)
                    .UpdateParameters.Add("SPEC_EQU_SERIAL", ASPxTextBox7.Text)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD", ASPxTextBox8.Text)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD_DESP", ASPxTextBox9.Text)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD_FILTERYES", RadioButton5.Checked.ToString)
                    .UpdateParameters.Add("SPEC_SAMPLE_METHOD_FILTERNO", RadioButton6.Checked.ToString)
                    .UpdateParameters.Add("SPEC_CALC_EQU", ASPxTextBox10.Text)
                    .UpdateParameters.Add("SPEC_CALC_FREQ", ASPxTextBox11.Text)
                    .UpdateParameters.Add("SPEC_CALC_METHOD", RadioButtonList1.Text)
                    .UpdateParameters.Add("SPEC_MAIN_FREQ", ASPxTextBox12.Text)
                    .UpdateParameters.Add("SPEC_MAIN_METHOD", RadioButtonList2.Text)
                    .UpdateParameters.Add("SPEC_MATERIAL", ASPxTextBox13.Text)
                    .UpdateParameters.Add("SPEC_WASTELIQUID", RadioButtonList3.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_MATERIAL_FREQ", ASPxTextBox14.Text)
                    .UpdateParameters.Add("SPEC_MEA_SCOPE", ASPxTextBox15.Text)
                    .UpdateParameters.Add("SPEC_MEA_SCOPEUNIT", DropDownList1.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_MEA_RESTIME", ASPxTextBox16.Text)
                    .UpdateParameters.Add("SPEC_MEA_RESTIMEUNIT", DropDownList2.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_MEA_FREQ", ASPxTextBox17.Text)
                    .UpdateParameters.Add("SPEC_MEA_FREQUNIT", DropDownList3.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_CALCAVG", ASPxTextBox18.Text)
                    .UpdateParameters.Add("SPEC_DOCATTACH_INST", ASPxCheckBox2.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DOCATTACH_CALI", ASPxCheckBox1.Checked.ToString)
                    .UpdateParameters.Add("SPEC_VIDEO_F", RadioButtonList4.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_VIDEO_F_MEMO", ASPxTextBox19.Text)
                    .UpdateParameters.Add("SPEC_VIDEO_R", RadioButtonList5.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_VIDEO_R_MEMO", ASPxTextBox20.Text)
                    .UpdateParameters.Add("SPEC_VIDEO_NV", RadioButtonList6.SelectedValue.ToString)
                    .UpdateParameters.Add("SPEC_VIDEO_NV_MEMO", ASPxTextBox21.Text)
                    .UpdateParameters.Add("SPEC_ANASIG_YES", RadioButton7.Checked.ToString)
                    .UpdateParameters.Add("SPEC_ANASIG", DropDownList4.SelectedValue)
                    .UpdateParameters.Add("SPEC_DIGSIG_YES", RadioButton7.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DIGSIG", ASPxTextBox22.Text)
                    .UpdateParameters.Add("SPEC_DO_HARDWARE_CONNECT", ASPxCheckBox3.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DO_HARDWARE_CONNPARA", ASPxCheckBox4.Checked.ToString)
                    .UpdateParameters.Add("SPEC_DO_HARDWARE_DOC", ASPxCheckBox5.Checked.ToString)
                    .UpdateParameters.Add("SPEC_PLCAGENT", ASPxTextBox23.Text)
                    .UpdateParameters.Add("SPEC_COSPEC", RadioButtonList7.SelectedItem.Value)
                    .UpdateParameters.Add("SPEC_COSPEC_NOTE", ASPxTextBox24.Text)
                    .UpdateParameters.Add("SPEC_H_CHANGE", RadioButtonList8.SelectedItem.Value)
                    .UpdateParameters.Add("SPEC_H_CHANGE_NOTE", ASPxTextBox25.Text)
                    .UpdateParameters.Add("SPEC_NOTE", ASPxMemo1.Text)
                    .UpdateParameters.Add("U_ID", Session("UserName"))
                    .UpdateParameters.Add("U_Date", Today())
                    .UpdateCommand = UpdateSQL

                    aff_row = .Update()

                    If aff_row = 0 Then
                        ASPxLabel130.Text = "資料更新失敗!"
                    Else
                        ASPxLabel130.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                ASPxLabel130.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                ASPxLabel130.Text = ex.Message.ToString
            End Try



        End If

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)

            If getresult.ReturnCode >= 1 Then
                ActionMode = "EDIT"
            Else
                ActionMode = "INSERT"
            End If

        Catch ex As Exception


        End Try


        If ActionMode = "INSERT" Then

            Try

                With SDS_PlanPolFeature_PDF

                    .InsertParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .InsertParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .InsertParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .InsertParameters.Add("DP_NO", Session("DP_NO"))
                    .InsertParameters.Add("ITEM", ASPxRadioButtonList1.SelectedItem.Value)
                    .InsertParameters.Add("DDL61", DDL61.SelectedValue.ToString)
                    .InsertParameters.Add("DDL62", DDL62.SelectedValue.ToString)
                    .InsertParameters.Add("DDL67", DDL67.SelectedValue.ToString)
                    .InsertParameters.Add("DDL611", DDL611.SelectedValue.ToString)
                    .InsertParameters.Add("DDL617A", DDL617A.SelectedValue.ToString)
                    .InsertParameters.Add("DDL617B", DDL617B.SelectedValue.ToString)
                    .InsertParameters.Add("DDL619A", DDL619A.SelectedValue.ToString)
                    .InsertParameters.Add("DDL619B", DDL619B.SelectedValue.ToString)
                    .InsertParameters.Add("DDL619C", DDL619C.SelectedValue.ToString)
                    .InsertParameters.Add("DDL620", DDL620.SelectedValue.ToString)
                    .InsertParameters.Add("DDL65", DDL65.SelectedValue.ToString)
                    .InsertParameters.Add("DDL66", DDL66.SelectedValue.ToString)
                    .InsertParameters.Add("CreatorID", Session("UserName"))
                    .InsertParameters.Add("CreateDate", Today())
                    .InsertCommand = InsertSQL_PDF

                    aff_row = .Insert()

                    If aff_row = 0 Then
                        ASPxLabel130.Text = "資料新增失敗!"
                    Else
                        ASPxLabel130.Text = "資料新增成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                ASPxLabel130.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                ASPxLabel130.Text = ex.Message.ToString
            End Try

        Else

            'Update 
            Try

                With SDS_PlanPolFeature_PDF

                    .UpdateParameters.Add("CNO", Session("CNO"))
                    If Session("DOCFIX") = "變更" Then
                        .UpdateParameters.Add("DocVersion", Session("NEW_DOCVERSION"))
                    Else
                        .UpdateParameters.Add("DocVersion", Session("DOCVERSION"))
                    End If
                    .UpdateParameters.Add("DP_NO", Session("DP_NO"))
                    .UpdateParameters.Add("ITEM", ASPxRadioButtonList1.SelectedItem.Value)
                    .UpdateParameters.Add("DDL61", DDL61.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL62", DDL62.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL67", DDL67.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL611", DDL611.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL617A", DDL617A.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL617B", DDL617B.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL619A", DDL619A.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL619B", DDL619B.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL619C", DDL619C.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL620", DDL620.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL65", DDL65.SelectedValue.ToString)
                    .UpdateParameters.Add("DDL66", DDL66.SelectedValue.ToString)
                    .UpdateParameters.Add("ModifyID", Session("UserName"))
                    .UpdateParameters.Add("ModifyDate", Today())
                    .UpdateCommand = UpdateSQL_PDF

                    aff_row = .Update()

                    If aff_row = 0 Then
                        ASPxLabel130.Text = "資料更新失敗!"
                    Else
                        ASPxLabel130.Text = "資料更新成功,請繼續下一步驟!"
                    End If

                End With

            Catch ex As System.Data.SqlClient.SqlException
                ASPxLabel130.Text = "可能有資料重覆輸入..."
            Catch ex As Exception
                ASPxLabel130.Text = ex.Message.ToString
            End Try

        End If

        GV_SPEC_SELF.DataBind()
        SDS_PlanPolFeature_self.Dispose()
        SDS_PlanPolFeature_PDF.Dispose()

    End Sub

    Private Sub Fillspec_self()

        Dim TempCno, TempDP_NO, TempDocVersion, TempItem As String
        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")
        TempItem = Session("ITEM")


        Dim Sqlstr As String = "Select * from DOC_SET_SPEC where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempItem + "'"
        Dim Sqlstr_PDF As String = "Select * from DOC_SET_PDF where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "' and dp_no='" + TempDP_NO + "' and item='" + TempItem + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                'RBL_SPEC_DPNO.Value = getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString
                ASPxTextBox1.Text = getresult.returnDataTable.Rows(0).Item("DP_NO").ToString
                ASPxRadioButtonList1.Value = getresult.returnDataTable.Rows(0).Item("ITEM").ToString
                RadioButton1.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_INSTEAD_YES").ToString)
                RadioButton2.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_INSTEAD_NO").ToString)
                RadioButton3.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_MONITOROTHER_YES").ToString)
                RadioButton4.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_MONITOROTHER_NO").ToString)
                ASPxTextBox3.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MO_NOTE_DPNO").ToString
                ASPxTextBox4.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MO_NOTE_DPNO1").ToString
                ASPxDateEdit1.Text = CDate(getresult.returnDataTable.Rows(0).Item("SPEC_INS_DATE").ToString)
                ASPxTextBox5.Text = getresult.returnDataTable.Rows(0).Item("SPEC_AGENTNAME").ToString
                ASPxTextBox6.Text = getresult.returnDataTable.Rows(0).Item("SPEC_EQU_MODEL").ToString
                ASPxTextBox7.Text = getresult.returnDataTable.Rows(0).Item("SPEC_EQU_SERIAL").ToString
                ASPxTextBox8.Text = getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD").ToString
                ASPxTextBox9.Text = getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD_DESP").ToString
                RadioButton5.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERYES").ToString)
                RadioButton6.Checked = CBool(getresult.returnDataTable.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERNO").ToString)
                ASPxTextBox10.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_EQU").ToString
                ASPxTextBox11.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_FREQ").ToString
                If Not getresult.returnDataTable.Rows(0).Item("SPEC_CALC_METHOD").ToString.Length < 1 Then
                    RadioButtonList1.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_CALC_METHOD").ToString
                End If
                ASPxTextBox12.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MAIN_FREQ").ToString
                If Not getresult.returnDataTable.Rows(0).Item("SPEC_MAIN_METHOD").ToString.Length < 1 Then
                    RadioButtonList2.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MAIN_METHOD").ToString
                End If
                ASPxTextBox13.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MATERIAL").ToString
                If Not getresult.returnDataTable.Rows(0).Item("SPEC_WASTELIQUID").ToString.Length < 1 Then
                    RadioButtonList3.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_WASTELIQUID").ToString
                End If
                ASPxTextBox14.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MATERIAL_FREQ").ToString
                ASPxTextBox15.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_SCOPE").ToString
                DropDownList1.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_SCOPEUNIT").ToString
                ASPxTextBox16.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_RESTIME").ToString
                DropDownList2.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_RESTIMEUNIT").ToString
                ASPxTextBox17.Text = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_FREQ").ToString
                DropDownList3.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_MEA_FREQUNIT").ToString
                ASPxTextBox18.Text = getresult.returnDataTable.Rows(0).Item("SPEC_CALCAVG").ToString
                ASPxCheckBox2.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DOCATTACH_INST").ToString.Trim
                ASPxCheckBox1.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DOCATTACH_CALI").ToString.Trim
                RadioButtonList4.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_F").ToString
                ASPxTextBox19.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString
                RadioButtonList5.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_R").ToString
                ASPxTextBox20.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString
                RadioButtonList6.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_NV").ToString
                ASPxTextBox21.Text = getresult.returnDataTable.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString
                ASPxTextBox23.Text = getresult.returnDataTable.Rows(0).Item("SPEC_PLCAGENT").ToString
                RadioButtonList7.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_COSPEC").ToString
                ASPxTextBox24.Text = getresult.returnDataTable.Rows(0).Item("SPEC_COSPEC_NOTE").ToString

                RadioButtonList8.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_H_CHANGE").ToString
                ASPxTextBox25.Text = getresult.returnDataTable.Rows(0).Item("SPEC_H_CHANGE_NOTE").ToString
                ASPxCheckBox3.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DO_HARDWARE_CONNECT").ToString.Trim
                ASPxCheckBox4.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DO_HARDWARE_CONNPARA").ToString.Trim
                ASPxCheckBox5.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DO_HARDWARE_DOC").ToString.Trim

                ASPxMemo1.Text = getresult.returnDataTable.Rows(0).Item("SPEC_NOTE").ToString

                RadioButton7.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_ANASIG_YES").ToString.Trim

                RadioButton8.Checked = getresult.returnDataTable.Rows(0).Item("SPEC_DIGSIG_YES").ToString.Trim
                ASPxTextBox22.Text = getresult.returnDataTable.Rows(0).Item("SPEC_DIGSIG").ToString

                If getresult.returnDataTable.Rows(0).Item("SPEC_ANASIG_YES").ToString = "True" Then
                    DropDownList4.SelectedValue = getresult.returnDataTable.Rows(0).Item("SPEC_ANASIG").ToString
                End If




            End If

        Catch ex As Exception


        End Try

        Try

            getresult = EIPDB.GetData(Sqlstr_PDF)
            If getresult.ReturnCode >= 1 Then

                DDL61.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL61").ToString
                DDL62.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL62").ToString
                DDL65.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL65").ToString
                DDL66.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL66").ToString
                DDL67.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL67").ToString
                DDL611.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL611").ToString
                DDL617A.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL617A").ToString
                DDL617B.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL617B").ToString
                DDL619A.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL619A").ToString
                DDL619B.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL619B").ToString
                DDL619C.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL619C").ToString
                DDL620.SelectedValue = getresult.returnDataTable.Rows(0).Item("DDL620").ToString

            End If

        Catch ex As Exception

        End Try

        ASPxPageControl1.ActiveTabIndex = 5


    End Sub

    Protected Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged

        If RadioButton7.Checked Then

            DropDownList4.Visible = True
            ASPxTextBox22.Visible = False


        Else

            DropDownList4.Visible = False
            ASPxTextBox22.Visible = True

        End If

    End Sub

    Protected Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged

        If RadioButton8.Checked Then
            DropDownList4.Visible = False
            ASPxTextBox22.Visible = True
        Else
            DropDownList4.Visible = True
            ASPxTextBox22.Visible = False

        End If

    End Sub

    Protected Sub GV_PDF_RowDeleted(sender As Object, e As Data.ASPxDataDeletedEventArgs) Handles GV_PDF.RowDeleted

        Try

            Dim tempcno As String = e.Keys.Item(0).ToString().Trim
            Dim MyDocNumber As String = e.Keys.Item(1).ToString().Trim
            Dim tempDocVersion As String = e.Keys.Item(2).ToString().Trim


            EraseSpecPDFItem(tempcno, MyDocNumber, CInt(tempDocVersion))


        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GV_PDF_RowUpdated(sender As Object, e As Data.ASPxDataUpdatedEventArgs) Handles GV_PDF.RowUpdated

        Dim tempcno As String = e.Keys.Item(0).ToString().Trim
        Dim MyDocNumber As String = e.Keys.Item(1).ToString().Trim
        Dim tempDocVersion As String = e.Keys.Item(2).ToString().Trim


        Try
            Dim cn As New SqlConnection(DBconntext)
            Dim cmd As New SqlCommand("UPDATE [DOC_PDF_BASIC] SET [FileDescription] = @FileDescription WHERE [CNO] = @CNO AND [DocNumber] = @DocNumber AND [DOCVERSION] = @DOCVERSION", cn)

            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()

        Catch ex As Exception

        End Try

    End Sub
End Class
