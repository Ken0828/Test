

Partial Class DocManage_ManList
    Inherits System.Web.UI.Page

    Protected Sub BT_QRY_SET_Click(sender As Object, e As EventArgs) Handles BT_QRY_SET.Click



        Dim tempcno As String = ""
        Dim TempVersion As String = ""
        Dim strFacName As String = ""
        Dim strScript_Error As String = "<script language=JavaScript> alert(""請先勾選文件版本...""); </script>"

        Try
            Dim fieldValues As List(Of Object) = GV_SET.GetSelectedFieldValues(New String() {"CNO", "DOCVERSION", "FAC_NAME"})

            If fieldValues.Count = 0 Then

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
                Exit Sub

            End If

            For Each item As Object() In fieldValues

                tempcno = item(0).ToString()
                TempVersion = item(1).ToString()
                strFacName = item(2).ToString()
                Session("CNO") = tempcno
                Session("DOCVERSION") = TempVersion
                Session("FACNAME") = strFacName

            Next item

        Catch ex As Exception

        End Try

        Server.Transfer("SetDoc.aspx")

    End Sub

    Public Shared Function GetCaseExamStatus(ByVal MyCno As String) As Boolean
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try
            Sqlstr = "Select *   from DAHS_EXAMLIST where  (EXAM_RESULT ='補正中' or EXAM_RESULT ='補正重送' or EXAM_RESULT ='審查中')  and  cno='" + Trim(MyCno) + "' "
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetCaseExamStatus = True
            Else
                GetCaseExamStatus = False

            End If

        Catch ex As Exception
            GetCaseExamStatus = False
        End Try

        Return GetCaseExamStatus
    End Function

    Public Shared Function GetSETModifoyCaseExamStatus(ByVal MyCno As String) As String
        Dim getresult As DbResult
        Dim getDocResult As DbResult
        Dim Sqlstr As String = ""
        Dim DocSqlstr As String = ""
        Dim strDocVersion As String = ""
        Dim GetSETDOCfoyCaseExamStatus As String = ""

        Try
            Sqlstr = "Select EXAM_RESULT,DOCVERSION  from DAHS_EXAMLIST where   doctype='措施說明書變更申請' and   cno='" + Trim(MyCno) + "' order by reg_date desc  "
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetSETModifoyCaseExamStatus = getresult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
                strDocVersion = getresult.returnDataTable.Rows(0).Item("DOCVERSION").ToString
            Else
                GetSETModifoyCaseExamStatus = False

            End If

            DocSqlstr = "Select EXAM_RESULT  from DAHS_EXAMLIST where   doctype='措施說明書' and   cno='" + Trim(MyCno) + "' and DocVersion='" + strDocVersion + "' order by reg_date desc  "
            getDocResult = EIPDB.GetData(DocSqlstr)

            If getDocResult.returnDataTable.Rows.Count > 0 Then
                GetSETDOCfoyCaseExamStatus = getDocResult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
            Else
                GetSETDOCfoyCaseExamStatus = False

            End If


            If GetSETModifoyCaseExamStatus = "審查通過" And GetSETDOCfoyCaseExamStatus = "審查通過" Then
                GetSETModifoyCaseExamStatus = False
            End If

        Catch ex As Exception
            GetSETModifoyCaseExamStatus = False
        End Try

        Return GetSETModifoyCaseExamStatus
    End Function

    Public Shared Function GetVRYModifoyCaseExamStatus(ByVal MyCno As String) As String
        Dim getresult As DbResult
        Dim getDocResult As DbResult
        Dim Sqlstr As String = ""
        Dim DocSqlstr As String = ""
        Dim strDocVersion As String = ""
        Dim GetVRYDOCfoyCaseExamStatus As String = ""

        Try
            Sqlstr = "Select EXAM_RESULT,DOCVERSION  from DAHS_EXAMLIST where   doctype='確認報告書變更申請' and   cno='" + Trim(MyCno) + "' order by reg_date desc  "

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetVRYModifoyCaseExamStatus = getresult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
                strDocVersion = getresult.returnDataTable.Rows(0).Item("DOCVERSION").ToString
            Else
                GetVRYModifoyCaseExamStatus = False

            End If

            DocSqlstr = "Select EXAM_RESULT  from DAHS_EXAMLIST where   doctype='確認報告書' and   cno='" + Trim(MyCno) + "' and DocVersion='" + strDocVersion + "' order by reg_date desc  "
            getDocResult = EIPDB.GetData(DocSqlstr)

            If getDocResult.returnDataTable.Rows.Count > 0 Then
                GetVRYDOCfoyCaseExamStatus = getDocResult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
            Else
                GetVRYDOCfoyCaseExamStatus = False

            End If


            If GetVRYModifoyCaseExamStatus = "審查通過" And GetVRYDOCfoyCaseExamStatus = "審查通過" Then
                GetVRYModifoyCaseExamStatus = False
            End If

        Catch ex As Exception
            GetVRYModifoyCaseExamStatus = False
        End Try

        Return GetVRYModifoyCaseExamStatus
    End Function

    Public Shared Function GetVRYDOCCaseExamStatus(ByVal MyCno As String) As Boolean
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try
            Sqlstr = "Select *   from DAHS_EXAMLIST where  EXAM_RESULT<>'審查通過' and doctype='確認報告書' and   cno='" + Trim(MyCno) + "' "
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetVRYDOCCaseExamStatus = True
            Else
                GetVRYDOCCaseExamStatus = False

            End If

        Catch ex As Exception
            GetVRYDOCCaseExamStatus = False
        End Try

        Return GetVRYDOCCaseExamStatus
    End Function

    Public Shared Function GetVRYDOCCaseOnFlyStatus(ByVal MyCno As String) As Boolean
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try
            Sqlstr = "Select *   from DAHS_EXAMLIST where  EXAM_RESULT in ('審查中','補中正','補正重送','已送未審') and doctype in ('確認報告書','確認報告書變更申請') and   cno='" + Trim(MyCno) + "' "
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetVRYDOCCaseOnFlyStatus = True
            Else
                GetVRYDOCCaseOnFlyStatus = False

            End If

        Catch ex As Exception
            GetVRYDOCCaseOnFlyStatus = False
        End Try

        Return GetVRYDOCCaseOnFlyStatus
    End Function

    Public Shared Function GetSETDOCCaseOnFlyStatus(ByVal MyCno As String) As Boolean
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try
            Sqlstr = "Select *   from DAHS_EXAMLIST where  EXAM_RESULT in ('審查中','補中正','補正重送','已送未審') and doctype in ('措施說明書','措施說明書變更申請') and   cno='" + Trim(MyCno) + "' "
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetSETDOCCaseOnFlyStatus = True
            Else
                GetSETDOCCaseOnFlyStatus = False

            End If

        Catch ex As Exception
            GetSETDOCCaseOnFlyStatus = False
        End Try

        Return GetSETDOCCaseOnFlyStatus
    End Function


    Public Shared Function GetSETDOCCaseExamStatus(ByVal MyCno As String) As Boolean
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try
            Sqlstr = "Select *   from DAHS_EXAMLIST where  EXAM_RESULT<>'審查通過' and doctype='措施說明書' and   cno='" + Trim(MyCno) + "' "
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetSETDOCCaseExamStatus = True
            Else
                GetSETDOCCaseExamStatus = False

            End If

        Catch ex As Exception
            GetSETDOCCaseExamStatus = False
        End Try

        Return GetSETDOCCaseExamStatus
    End Function



    Private Shared Function GetLastVersion(ByVal MyDocType As String, MyCNO As String) As Integer
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select max(docversion)  from [DOC_SET_FACTORY] where cno='" + Trim(MyCNO) + "'  "
        Else
            Sqlstr = "Select max(docversion)  from [DOC_VRY_FACTORY] where cno='" + Trim(MyCNO) + "'  "
        End If

        Try
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetLastVersion = CInt(getresult.returnDataTable.Rows(0).Item(0).ToString)
            Else
                GetLastVersion = 1
            End If

        Catch ex As Exception

        End Try

        Return GetLastVersion


    End Function


    Private Shared Function GetCNOFacName(MyCNO As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Sqlstr = "SELECT  CompanyName from cwms_1  where controlno='" + MyCNO + "'"

        Try
            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetCNOFacName = getresult.returnDataTable.Rows(0).Item("CompanyName").ToString
            Else
                GetCNOFacName = "許可資料庫中查無此管制編號"
            End If

        Catch ex As Exception

        End Try

        Return GetCNOFacName


    End Function


    Private Shared Function GetCNOStatus(ByVal MyDocType As String, ByVal MyCNO As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select *  from [DOC_SET_FACTORY] where cno='" + Trim(MyCNO) + "' "
        Else
            Sqlstr = "Select *  from [DOC_VRY_FACTORY] where cno='" + Trim(MyCNO) + "' "
        End If


        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetCNOStatus = "TRUE"
            Else
                GetCNOStatus = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return GetCNOStatus


    End Function



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If


        Session("DOCMODE") = ""


        Dim Q_cno As String
        Q_cno = Session("CNO")
        Session("FAC_NAME") = GetCNOFacName(Q_cno)



        If (GetCNOStatus("SET", Q_cno)) Then

            Session("CNO") = Q_cno
            BT_QRY_SET.Visible = True
            BT_NEW_SET.Text = "措施說明書變更申請"
            BT_NEW_SET.Visible = True

            If GetCNOStatus("VRY", Q_cno) Then
                BT_NEW_VRY.Text = "確認報告書變更申請"
                BT_NEW_VRY.Visible = True
                BT_QRY_VRY.Visible = True
            Else
                BT_NEW_VRY.Text = "新增確認報告書"
                BT_NEW_VRY.Visible = True
                BT_QRY_VRY.Visible = False

            End If
            ASPxButton3.Visible = False
            MultiView1.SetActiveView(View_Edit)

        ElseIf (GetCNOStatus("VRY", Q_cno)) Then
            BT_NEW_VRY.Text = "確認報告書變更申請"
            BT_NEW_VRY.Visible = True
            BT_QRY_VRY.Visible = True

            ASPxButton3.Visible = False
            MultiView1.SetActiveView(View_Edit)

        Else
            Session("CNO") = Q_cno
            MultiView1.SetActiveView(View1)
            ASPxButton3.Visible = True

            If ASPxPageControl1.ActiveTabIndex = 0 Then
                If RBL_BATCH_13.SelectedIndex = 0 Then
                    BT_QRY_SET.Visible = False
                    BT_NEW_SET.Text = "措施說明書變更申請"
                    BT_NEW_SET.Visible = True
                    BT_NEW_VRY.Visible = False
                    BT_QRY_VRY.Visible = False
                ElseIf RBL_BATCH_13.SelectedIndex = 1 Then
                    BT_QRY_SET.Visible = False
                    BT_NEW_SET.Text = "措施說明書變更申請"
                    BT_NEW_SET.Visible = True
                    BT_NEW_VRY.Text = "確認報告書變更申請"
                    BT_NEW_VRY.Visible = True
                    BT_QRY_VRY.Visible = False

                Else
                    BT_QRY_SET.Visible = False
                    BT_NEW_SET.Text = "措施說明書變更申請"
                    BT_NEW_SET.Visible = False

                    BT_NEW_VRY.Text = "新增確認報告書"
                    BT_NEW_VRY.Visible = True
                    BT_QRY_VRY.Visible = False

                End If
            Else
                If RBL_BATCH_14.SelectedIndex = 0 Then

                    BT_QRY_SET.Visible = False
                    BT_NEW_SET.Text = "新增措施說明書"
                    BT_NEW_SET.Visible = True
                    BT_NEW_VRY.Visible = False
                    BT_QRY_VRY.Visible = False

                ElseIf RBL_BATCH_14.SelectedIndex = 1 Then

                    BT_QRY_SET.Visible = False
                    BT_NEW_SET.Text = "新增措施說明書"
                    BT_NEW_SET.Visible = True
                    BT_NEW_VRY.Visible = False
                    BT_QRY_VRY.Visible = False

                Else

                    BT_QRY_SET.Visible = False
                    BT_NEW_SET.Text = "措施說明書變更申請"
                    BT_NEW_SET.Visible = False
                    BT_NEW_VRY.Text = "確認報告書變更申請"
                    BT_NEW_VRY.Visible = True
                    BT_QRY_VRY.Visible = False

                End If
            End If
        End If



    End Sub

    Protected Sub BT_QRY_Click(sender As Object, e As EventArgs) Handles BT_QRY.Click

        Try
            MultiView1.SetActiveView(View_Edit)
            GV_SET.DataBind()
            GV_VRY.DataBind()
        Catch ex As Exception

        End Try



    End Sub

    Protected Sub BT_NEW_Click(sender As Object, e As EventArgs) Handles BT_NEW.Click

        Try
            Server.Transfer("SetDoc.aspx")
        Catch ex As Exception

        End Try



    End Sub


    Protected Sub BT_NEW_SET_Click(sender As Object, e As EventArgs) Handles BT_NEW_SET.Click

        Dim tempcno As String = ""
        Dim TempVersion As String = ""
        Dim strFacName As String = ""
        Dim TempDocSerial As String = ""
        Dim strScript_Error As String = "<script language=JavaScript> alert(""請先勾選文件版本...""); </script>"
        Dim strScript_FlowError As String = "<script language=JavaScript> alert(""仍有其他文件審查流程進行中...""); </script>"
        Dim strScript_ModiFlowError As String = "<script language=JavaScript> alert(""仍有變更申請表流程進行中...""); </script>"
        Dim strScript_SETDOCFlowError As String = "<script language=JavaScript> alert(""仍有措施說明書審查流程進行中...""); </script>"




        If BT_NEW_SET.Text = "新增措施說明書" Then
            '新增
            '新增去年已補登錄確認報告書但未登錄措施說明書者，出現協助COPY畫面
            '加上判斷如有流程進行中則停止動作 2019-05-23

            If GetCaseExamStatus(Session("CNO")) Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_FlowError)
                Exit Sub
            End If

            If GetCNOStatus("VRY", Session("CNO")) Then  'if found 表示已有確認報告書但無措施說明書

                '切換至VIEW_COPY
                TB_Copy_CNO.Text = Session("CNO")
                TB_Copy_DOCTYPE.Text = "確認報告書"
                TB_Copy_DOCVERSION.Text = GetLastVersion("VRY", Session("CNO"))
                MultiView1.SetActiveView(View_Copy)
                Exit Sub
            End If

            Try
                Session("DOCVERSION") = "1"
                Session("DOCMODE") = "措施說明書申請"
                Session("DOCTYPE") = "措施說明書申請"
                Session("DOCNEW") = "NEW"
                Server.Transfer("SetDoc.aspx")
            Catch ex As Exception

            End Try

        Else
            '變更
            '先導引至下載變更申請表畫面
            'GetSETModifoyCaseExamStatus 檢查是否有未完成之變更流程

            If GetVRYDOCCaseOnFlyStatus(Session("CNO")) Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_FlowError)
                Exit Sub
            End If

            Dim ModifyDocCaseStatus As String = ""
            Try
                ModifyDocCaseStatus = GetSETModifoyCaseExamStatus(Session("CNO"))
            Catch ex As Exception

            End Try

            Dim DocOnflystatus As String = ""

            Try
                DocOnflystatus = GetSETDOCCaseExamStatus(Session("CNO"))
            Catch ex As Exception

            End Try


            Try
                Dim fieldValues As List(Of Object) = GV_SET.GetSelectedFieldValues(New String() {"CNO", "DOCVERSION", "FAC_NAME", "DOC_SERIAL"})
                For Each item As Object() In fieldValues
                    tempcno = item(0).ToString()
                    TempVersion = item(1).ToString()
                    strFacName = item(2).ToString()
                    TempDocSerial = item(3).ToString()
                    Session("CNO") = tempcno
                    Session("DOCVERSION") = TempVersion
                    Session("MODIFYDOCVERSION") = TempVersion + 1
                    Session("FACNAME") = strFacName
                    Session("DOC_SERIAL") = TempDocSerial
                    Session("MODIFYDOC_SERIAL") = TempDocSerial + 1
                Next item
            Catch ex As Exception

            End Try


            '變更審查表狀態
            Select Case ModifyDocCaseStatus
                Case "已送未審", "審查中", "補正重送"
                    'STOP SUB
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_ModiFlowError)
                    Exit Sub

                Case "審查通過"
                    If DocOnflystatus Then
                        'STOP SUB
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_SETDOCFlowError)
                        Exit Sub

                    Else
                        Try
                            Session("DOCMODE") = "審查通過"
                            Session("DOCTYPE") = "措施說明書變更申請"
                            Server.Transfer("PrepareModify.aspx")
                        Catch ex As Exception

                        End Try
                    End If

                Case "補正中"
                    'Load 最近一版
                    Try
                        Session("DOCMODE") = "載入"
                        Session("DOCTYPE") = "措施說明書變更申請"
                        Server.Transfer("PrepareModify.aspx")
                    Catch ex As Exception

                    End Try

                Case "不適用", "駁回", "False"
                    'NEW FORM
                    Try
                        Session("DOCMODE") = "新表格"
                        Session("DOCTYPE") = "措施說明書變更申請"
                        Server.Transfer("PrepareModify.aspx")
                    Catch ex As Exception

                    End Try
            End Select
        End If
    End Sub

    Protected Sub BT_QRY_VRY_Click(sender As Object, e As EventArgs) Handles BT_QRY_VRY.Click

        Dim tempcno As String = ""
        Dim TempVersion As String = ""
        Dim strFacName As String = ""
        Dim strScript_Error As String = "<script language=JavaScript> alert(""請先勾選文件版本...""); </script>"

        Try
            Dim fieldValues As List(Of Object) = GV_VRY.GetSelectedFieldValues(New String() {"CNO", "DOCVERSION", "FAC_NAME"})

            If fieldValues.Count = 0 Then

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
                Exit Sub

            End If

            For Each item As Object() In fieldValues

                tempcno = item(0).ToString()
                TempVersion = item(1).ToString()
                strFacName = item(2).ToString()
                Session("CNO") = tempcno
                Session("DOCVERSION") = TempVersion
                Session("FACNAME") = strFacName

            Next item

            Server.Transfer("VryDoc.aspx")

        Catch ex As Exception

        End Try


    End Sub

    Protected Sub BT_NEW_VRY_Click(sender As Object, e As EventArgs) Handles BT_NEW_VRY.Click

        Dim tempcno As String = ""
        Dim TempVersion As String = ""
        Dim strFacName As String = ""
        Dim strScript_Error As String = "<script language=JavaScript> alert(""請先勾選文件版本...""); </script>"
        Dim strScript_FlowError As String = "<script language=JavaScript> alert(""仍有流程進行中...""); </script>"
        Dim strScript_ModiFlowError As String = "<script language=JavaScript> alert(""仍有變更申請表流程進行中...""); </script>"
        Dim strScript_SETDOCFlowError As String = "<script language=JavaScript> alert(""仍有確認報告書審查流程進行中...""); </script>"


        '加上判斷如有流程進行中則停止動作 2019-05-23



        If BT_NEW_VRY.Text = "新增確認報告書" Then

            If GetCaseExamStatus(Session("CNO")) Then

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_FlowError)
                Exit Sub
            End If

            Session("DOCVERSION") = "1"
            Session("DOCMODE") = "確認報告書申請"
            Session("DOCTYPE") = "確認報告書申請"
            Session("DOCNEW") = "NEW"

            'CopySetDoc 
            '取得最後一版措施說明書版本

            Dim SetLastVersion As String = GetLastVersion("SET", Session("CNO"))

            Try
                CopySetDoc(Session("CNO"), SetLastVersion)
                Server.Transfer("VryDoc.aspx")
            Catch ex As Exception

            End Try


        Else
            '變更
            '先導引至下載變更申請表畫面
            '加上判斷如有流程進行中則停止動作 2019-05-23

            If GetSETDOCCaseOnFlyStatus(Session("CNO")) Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_FlowError)
                Exit Sub
            End If


            Dim ModifyDocCaseStatus As String = ""
            Try
                ModifyDocCaseStatus = GetVRYModifoyCaseExamStatus(Session("CNO"))
            Catch ex As Exception

            End Try

            Dim DocOnflystatus As String = ""

            Try
                DocOnflystatus = GetVRYDOCCaseExamStatus(Session("CNO"))
            Catch ex As Exception

            End Try


            Try
                Dim fieldValues As List(Of Object) = GV_VRY.GetSelectedFieldValues(New String() {"CNO", "DOCVERSION", "FAC_NAME"})
                If GV_VRY.VisibleRowCount > 0 Then
                    If fieldValues.Count = 0 Then
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
                        Exit Sub
                    End If

                    For Each item As Object() In fieldValues
                        tempcno = item(0).ToString()
                        TempVersion = item(1).ToString()
                        strFacName = item(2).ToString()
                        Session("CNO") = tempcno
                        Session("DOCVERSION") = TempVersion
                        Session("MODIFYDOCVERSION") = TempVersion + 1
                        Session("FACNAME") = strFacName
                    Next item



                End If

            Catch ex As Exception

            End Try

            Select Case ModifyDocCaseStatus
                Case "已送未審", "審查中", "補正重送"
                    'STOP SUB
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_ModiFlowError)
                    Exit Sub

                Case "審查通過"
                    If DocOnflystatus Then
                        'STOP SUB
                        ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_SETDOCFlowError)
                        Exit Sub

                    Else
                        Try
                            Session("DOCMODE") = "審查通過"
                            Session("DOCTYPE") = "確認報告書變更申請"
                            Server.Transfer("PrepareModify.aspx")
                        Catch ex As Exception

                        End Try
                    End If

                Case "補正中"
                    'Load 最近一版
                    Try
                        Session("DOCMODE") = "載入"
                        Session("DOCTYPE") = "確認報告書變更申請"
                        Server.Transfer("PrepareModify.aspx")
                    Catch ex As Exception

                    End Try

                Case "不適用", "駁回", "False"
                    'NEW FORM
                    Try
                        Session("DOCMODE") = "新表格"
                        Session("DOCTYPE") = "確認報告書變更申請"
                        Server.Transfer("PrepareModify.aspx")
                    Catch ex As Exception

                    End Try
            End Select

        End If

    End Sub

    Public Shared Function CopyVryDocToSet(MyCNO As String, ByVal MyDOCVersion As Integer) As String

        'Todo 

        Dim getresult As DbResult

        Dim CopyVry_FacSqlstr As String = "INSERT INTO DOC_SET_FACTORY SELECT * FROM DOC_VRY_FACTORY WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_ItemSqlstr As String = "INSERT INTO DOC_SET_ITEM SELECT * FROM DOC_VRY_ITEM WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LinkSqlstr As String = "INSERT INTO DOC_SET_LINK SELECT * FROM DOC_VRY_LINK WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_SPECSqlstr As String = "INSERT INTO DOC_SET_SPEC(([CNO],[DP_NO],[DPTYPE],[DOCVERSION],[ITEM],[DPNO_DESP],[SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO],[SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO],[SPEC_MO_NOTE_DPNO],[SPEC_MO_NOTE_DPNO1],[SPEC_MO_NOTE_QUA],[SPEC_INS_DATE],[SPEC_AGENTNAME],[SPEC_EQU_MODEL],[SPEC_EQU_SERIAL],[SPEC_SAMPLE_METHOD],[SPEC_SAMPLE_METHOD_DESP],[SPEC_SAMPLE_METHOD_FILTERYES],[SPEC_SAMPLE_METHOD_FILTERNO],[SPEC_CALC_EQU],[SPEC_CALC_FREQ],[SPEC_CALC_METHOD],[SPEC_MAIN_FREQ],[SPEC_MAIN_METHOD],[SPEC_MATERIAL],[SPEC_WASTELIQUID],[SPEC_MATERIAL_FREQ],[SPEC_MEA_SCOPE],[SPEC_MEA_SCOPEUNIT],[SPEC_MEA_RESTIME],[SPEC_MEA_RESTIMEUNIT],[SPEC_MEA_FREQ],[SPEC_MEA_FREQUNIT],[SPEC_CALCAVG],[SPEC_DOCATTACH_INST],[SPEC_DOCATTACH_CALI],[SPEC_VIDEO_F],[SPEC_VIDEO_F_MEMO],[SPEC_VIDEO_R] ,[SPEC_VIDEO_R_MEMO],[SPEC_VIDEO_NV],[SPEC_VIDEO_NV_MEMO],[SPEC_ANASIG_YES],[SPEC_ANASIG],[SPEC_DIGSIG_YES],[SPEC_DIGSIG],[SPEC_DO_HARDWARE_CONNECT],[SPEC_DO_HARDWARE_CONNPARA],[SPEC_DO_HARDWARE_DOC],[SPEC_PLCAGENT],[SPEC_COSPEC],[SPEC_COSPEC_NOTE],[SPEC_H_CHANGE],[SPEC_H_CHANGE_NOTE],[SPEC_NOTE],[C_ID],[C_DATE],[U_ID],[U_DATE])) SELECT [CNO],[DP_NO],[DPTYPE],[DOCVERSION],[ITEM],[DPNO_DESP],[SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO],[SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO],[SPEC_MO_NOTE_DPNO],[SPEC_MO_NOTE_DPNO1],[SPEC_MO_NOTE_QUA],[SPEC_INS_DATE],[SPEC_AGENTNAME],[SPEC_EQU_MODEL],[SPEC_EQU_SERIAL],[SPEC_SAMPLE_METHOD],[SPEC_SAMPLE_METHOD_DESP],[SPEC_SAMPLE_METHOD_FILTERYES],[SPEC_SAMPLE_METHOD_FILTERNO],[SPEC_CALC_EQU],[SPEC_CALC_FREQ],[SPEC_CALC_METHOD],[SPEC_MAIN_FREQ],[SPEC_MAIN_METHOD],[SPEC_MATERIAL],[SPEC_WASTELIQUID],[SPEC_MATERIAL_FREQ],[SPEC_MEA_SCOPE],[SPEC_MEA_SCOPEUNIT],[SPEC_MEA_RESTIME],[SPEC_MEA_RESTIMEUNIT],[SPEC_MEA_FREQ],[SPEC_MEA_FREQUNIT],[SPEC_CALCAVG],[SPEC_DOCATTACH_INST],[SPEC_DOCATTACH_CALI],[SPEC_VIDEO_F],[SPEC_VIDEO_F_MEMO],[SPEC_VIDEO_R] ,[SPEC_VIDEO_R_MEMO],[SPEC_VIDEO_NV],[SPEC_VIDEO_NV_MEMO],[SPEC_ANASIG_YES],[SPEC_ANASIG],[SPEC_DIGSIG_YES],[SPEC_DIGSIG],[SPEC_DO_HARDWARE_CONNECT],[SPEC_DO_HARDWARE_CONNPARA],[SPEC_DO_HARDWARE_DOC],[SPEC_PLCAGENT],[SPEC_COSPEC],[SPEC_COSPEC_NOTE],[SPEC_H_CHANGE],[SPEC_H_CHANGE_NOTE],[SPEC_NOTE],[C_ID],[C_DATE],[U_ID],[U_DATE] FROM DOC_VRY_SPEC WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_DAHSSqlstr As String = "INSERT INTO DOC_SET_DAHS SELECT * FROM DOC_VRY_DAHS WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LPSqlstr As String = "INSERT INTO DOC_SET_LP([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE], [ITEM1_DATE], [ITEM3_DATE]) SELECT [CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE], [ITEM1_DATE], [ITEM3_DATE] FROM DOC_VRY_LP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LEDSqlstr As String = "INSERT INTO DOC_SET_LED SELECT * FROM DOC_VRY_LED WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"


        Try

            getresult = EIPDB.Execute(CopyVry_FacSqlstr)
            getresult = EIPDB.Execute(CopyVry_ItemSqlstr)
            getresult = EIPDB.Execute(CopyVry_LinkSqlstr)
            getresult = EIPDB.Execute(CopyVry_SPECSqlstr)
            getresult = EIPDB.Execute(CopyVry_DAHSSqlstr)
            getresult = EIPDB.Execute(CopyVry_LPSqlstr)
            getresult = EIPDB.Execute(CopyVry_LEDSqlstr)

            CopyVryDocToSet = "TRUE"
        Catch ex As Exception

        End Try

        Return CopyVryDocToSet


    End Function

    Public Shared Function CopySetDoc(MyCNO As String, ByVal MyDOCVersion As Integer) As String

        Dim getresult As DbResult

        Dim CopyVry_FacSqlstr As String = "INSERT INTO DOC_VRY_FACTORY SELECT * FROM DOC_SET_FACTORY WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_ItemSqlstr As String = "INSERT INTO DOC_VRY_ITEM SELECT * FROM DOC_SET_ITEM WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LinkSqlstr As String = "INSERT INTO DOC_VRY_LINK ([cNo], [DP_NO], [DocVersion], [DAHS_REDAN_FUNC], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [NetworkIP], [VideoLineType], [VideoIPType], [VideoIP], [NetworkPortNumber], [NetworkPortNumberOther], [VideoLoginID], [MaintainType], [MonitorCenter], [NOTE1], [NOTE2], [C_ID], [C_DATE], [U_ID], [U_DATE]) SELECT [cNo], [DP_NO], [DocVersion], [DAHS_REDAN_FUNC], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [NetworkIP], [VideoLineType], [VideoIPType], [VideoIP], [NetworkPortNumber], [NetworkPortNumberOther], [VideoLoginID], [MaintainType], [MonitorCenter], [NOTE1], [NOTE2], [C_ID], [C_DATE], [U_ID], [U_DATE] FROM DOC_SET_LINK WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_SPECSqlstr As String = "INSERT INTO DOC_VRY_SPEC ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO], [SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) SELECT [CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO], [SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]  FROM DOC_SET_SPEC WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_DAHSSqlstr As String = "INSERT INTO DOC_VRY_DAHS (CNO,DOCVERSION,DP_NO,PLAN_INSDATE,[AGENT],[REDANDUNT],[CONTROLROOM],[COLUD],[MAINTAINMETHOD],[FITFREQ],[FITFORMAT],[STAR168DATE]) SELECT CNO,DOCVERSION,DP_NO,PLAN_INSDATE,[AGENT],[REDANDUNT],[CONTROLROOM],[COLUD],[MAINTAINMETHOD],[FITFREQ],[FITFORMAT],[STAR168DATE]  FROM DOC_SET_DAHS WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"

        Try

            getresult = EIPDB.Execute(CopyVry_FacSqlstr)
            getresult = EIPDB.Execute(CopyVry_ItemSqlstr)
            getresult = EIPDB.Execute(CopyVry_LinkSqlstr)
            getresult = EIPDB.Execute(CopyVry_SPECSqlstr)
            getresult = EIPDB.Execute(CopyVry_DAHSSqlstr)

            CopySetDoc = "TRUE"
        Catch ex As Exception

        End Try

        Return CopySetDoc


    End Function

    Protected Sub RBL_BATCH_13_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_BATCH_13.SelectedIndexChanged

        '1〜3批及重大違規之既設業者

        If ASPxPageControl1.ActiveTabIndex = 0 Then
            If RBL_BATCH_13.SelectedIndex = 0 Then
                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "變更措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Visible = False
                BT_QRY_VRY.Visible = False
            ElseIf RBL_BATCH_13.SelectedIndex = 1 Then
                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "變更措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Text = "變更確認報告書"
                BT_NEW_VRY.Visible = True
                BT_QRY_VRY.Visible = False

            Else
                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "變更措施說明書"
                BT_NEW_SET.Visible = False

                BT_NEW_VRY.Text = "新增確認報告書"
                BT_NEW_VRY.Visible = True
                BT_QRY_VRY.Visible = False

            End If
        Else '4~6批
            If RBL_BATCH_14.SelectedIndex = 0 Then

                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "新增措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Visible = False
                BT_QRY_VRY.Visible = False

            ElseIf RBL_BATCH_14.SelectedIndex = 1 Then

                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "新增措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Visible = False
                BT_QRY_VRY.Visible = False

            Else

                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "變更措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Text = "變更確認報告書"
                BT_NEW_VRY.Visible = True
                BT_QRY_VRY.Visible = False

            End If
        End If



    End Sub

    Protected Sub RBL_BATCH_14_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_BATCH_14.SelectedIndexChanged

        '第4批及重大違規之新設業者

        If ASPxPageControl1.ActiveTabIndex = 0 Then
            If RBL_BATCH_13.SelectedIndex = 0 Then
                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "變更措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Visible = False
                BT_QRY_VRY.Visible = False
            Else
                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "變更措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Text = "變更確認報告書"
                BT_NEW_VRY.Visible = True
                BT_QRY_VRY.Visible = False

            End If
        Else
            If RBL_BATCH_14.SelectedIndex = 0 Then

                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "新增措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Visible = False
                BT_QRY_VRY.Visible = False

            ElseIf RBL_BATCH_14.SelectedIndex = 1 Then

                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "新增措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Visible = False
                BT_QRY_VRY.Visible = False

            Else

                BT_QRY_SET.Visible = False
                BT_NEW_SET.Text = "變更措施說明書"
                BT_NEW_SET.Visible = True
                BT_NEW_VRY.Text = "變更確認報告書"
                BT_NEW_VRY.Visible = True
                BT_QRY_VRY.Visible = False

            End If
        End If


    End Sub


    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        Session("DOCVERSION") = "1"
        MultiView1.SetActiveView(View_Edit)

    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click
        Session("DOCVERSION") = "1"
        MultiView1.SetActiveView(View_Edit)

    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click
        Session("DOCVERSION") = "1"
        MultiView1.SetActiveView(View1)

    End Sub


    Protected Sub BT_CopyVrytoSet_Click(sender As Object, e As EventArgs) Handles BT_CopyVrytoSet.Click

        'Copy Vry to Set 
        Try

            If CopyVryDocToSet(TB_Copy_CNO.Text, TB_Copy_DOCVERSION.Text) Then

                MultiView1.SetActiveView(View_Edit)

                GV_SET.DataBind()
                GV_VRY.DataBind()


            End If


        Catch ex As Exception

        End Try



    End Sub
End Class
