Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Net.Mail
Imports iTextSharp.text
Imports System.IO

Public Class PrepareModify
    Inherits System.Web.UI.Page

    Dim SB As New System.Text.StringBuilder
    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
    'Dim strScript_FileUPLCompleted As String = "<script language=JavaScript> alert(""您的檔案已上傳成功，若需檢視請按右側按鍵查看上傳檔案""); </script>"
    Public Shared Function GetCaseExamStatus(ByVal MyCno As String, ByVal MyDocVersion As String, ByVal strDocType As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try

            If strDocType = "措施說明書變更申請" Then
                Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='措施說明書' and  cno='" + Trim(MyCno) + "'  order by docversion desc "
            Else
                Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='確認報告書' and  cno='" + Trim(MyCno) + "'  order by docversion desc "
            End If

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


    Public Shared Function GetDocModifyDocStatus(ByVal MyCno As String, ByVal MyDocVersion As String, ByVal strDocType As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""
        Dim sqlAudit As String = ""
        Dim DocVersion As String = ""
        Dim GetDocModifyAuditStatus As String = ""

        Try

            If strDocType = "措施說明書變更申請" Then
                Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='措施說明書變更申請' and  cno='" + Trim(MyCno) + "' and docversion='" + MyDocVersion + "'  order by docversion desc "
                'Sqlstr = "Select *   from DAHS_MODIFY where  DOCTYPE='措施說明書變更申請' and  cno='" + Trim(MyCno) + "'  order by docversion desc "

            Else
                Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='確認報告書變更申請' and  cno='" + Trim(MyCno) + "' and docversion='" + MyDocVersion + "' order by docversion desc "
                'Sqlstr = "Select *   from DAHS_MODIFY where  DOCTYPE='確認報告書變更申請' and  cno='" + Trim(MyCno) + "' order by docversion desc "

            End If

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetDocModifyDocStatus = getresult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
                DocVersion = getresult.returnDataTable.Rows(0).Item("DOCVERSION").ToString
            Else
                GetDocModifyDocStatus = "FALSE"
                DocVersion = "FALSE"

            End If

        Catch ex As Exception
            GetDocModifyDocStatus = "FALSE"
        End Try


        Return GetDocModifyDocStatus
    End Function


    Public Shared Function GetDocModifyCaseStatus(ByVal MyCno As String, ByVal MyDocVersion As String, ByVal strDocType As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try

            If strDocType = "措施說明書變更申請" Then
                'Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='措施說明書變更申請' and  cno='" + Trim(MyCno) + "' and docversion='" + MyDocVersion + "'  order by docversion desc "
                Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='措施說明書變更申請' and  cno='" + Trim(MyCno) + "'  order by docversion desc "
            Else
                'Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='確認報告書變更申請' and  cno='" + Trim(MyCno) + "' and docversion='" + MyDocVersion + "' order by docversion desc "
                Sqlstr = "Select *   from DAHS_EXAMLIST where  DOCTYPE='確認報告書變更申請' and  cno='" + Trim(MyCno) + "' order by docversion desc "
            End If

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetDocModifyCaseStatus = getresult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
            Else
                GetDocModifyCaseStatus = "FALSE"

            End If

        Catch ex As Exception
            GetDocModifyCaseStatus = "FALSE"
        End Try

        Return GetDocModifyCaseStatus
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strComment As String = Session("Comment")
        Dim strDocMode As String = Session("DOCMODE").ToString
        Dim strDocType As String = Session("DOCTYPE").ToString

        Dim strDocVersion As String = Session("DOCVERSION").ToString
        Dim getresult As DbResult


        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If



        '下載措施說明書變更申請表空白表單
        BT_PDF_DL.Attributes.Add("onclick", "window.open( '措施說明書變更申請表空白表單.DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")
        BT_EPB_PDF_DL.Attributes.Add("onclick", "window.open( '措施說明書變更申請表空白表單.DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")


        '下載確認報告書變更申請表空白表單
        BT_PDF_DLVRY.Attributes.Add("onclick", "window.open( '確認報告書變更申請表空白表單.DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")
        BT_EPB_PDF_DLVRY.Attributes.Add("onclick", "window.open( '確認報告書變更申請表空白表單.DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")

        '措施說明書變更----第一階段範例下載
        'BT_EPBDL_SETDOCEx1
        'BT_DL_SETDOCEx1

        BT_EPBDL_SETDOCEx1.Attributes.Add("onclick", "window.open( '措施說明書變更申請表(第一階段範例).DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")
        BT_DL_SETDOCEx1.Attributes.Add("onclick", "window.open( '措施說明書變更申請表(第一階段範例).DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")


        '措施說明書變更----第二階段範例下載
        'BT_EPBDL_SETDOCEx2
        'BT_DL_SETDOCEx2
        BT_EPBDL_SETDOCEx2.Attributes.Add("onclick", "window.open( '措施說明書變更申請表(第二階段範例).DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")
        BT_DL_SETDOCEx2.Attributes.Add("onclick", "window.open( '措施說明書變更申請表(第二階段範例).DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")

        '確認報告書變更----第一階段範例下載
        'BT_EPBDL_VRYDOCEx1
        'BT_DL_VRYDOCEx1

        BT_EPBDL_VRYDOCEx1.Attributes.Add("onclick", "window.open( '確認報告書變更申請表(第一階段範例).DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")
        BT_DL_VRYDOCEx1.Attributes.Add("onclick", "window.open( '確認報告書變更申請表(第一階段範例).DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")

        '確認報告書變更----第二階段範例下載
        'BT_EPBDL_VRYDOCEx2
        'BT_DL_VRYDOCEx2

        BT_EPBDL_VRYDOCEx2.Attributes.Add("onclick", "window.open( '確認報告書變更申請表(第二階段範例).DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")
        BT_DL_VRYDOCEx2.Attributes.Add("onclick", "window.open( '確認報告書變更申請表(第二階段範例).DOC', '', 'menubar=no, locationbar=false,status=no, scrollbars=yes, resizable=no, top=100, left=200, toolbar=no, width=800, height=700');")


        If Not IsPostBack Then
            If (Left(strComment, 3) = "EPB" Or strComment = "EPA" Or strComment = "TOP_ADMIN") And (Right(strComment, 6) <> "HELPER") Then

                BT_Audit1.Visible = True
                BT_AuditSave.Visible = True
                Panel1.Visible = True

                If strDocType = "措施說明書變更申請" Then
                    Session("MODIDOCVERSION") = (GetLastModifyVersion("SET", Session("CNO"))).ToString
                    Session("MODIFYDOC_SERIAL") = (GetLastModifySerial("SET", Session("CNO"))).ToString
                Else
                    Session("MODIDOCVERSION") = (GetLastModifyVersion("VRY", Session("CNO"))).ToString
                    Session("MODIFYDOC_SERIAL") = (GetLastModifySerial("VRY", Session("CNO"))).ToString
                End If

                FillForm()

                MultiView1.SetActiveView(View_EPB)

                TB_CNO.Enabled = False
                TB_CONTACTPHONE.Enabled = False
                TB_EMAIL.Enabled = False
                TB_FACABBR.Enabled = False
                TB_DOCVERSION.Enabled = False
                TB_REGDATE.Enabled = False
                TB_REGISTOR.Enabled = False
                TB_DOC_SERIAL.Enabled = False
                bt_summit.Visible = False
                bt_return.Visible = False
                BT_SetDoc.Visible = False
                BT_VryDoc.Visible = False

            ElseIf Right(strComment, 6) = "HELPER" Then

                BT_Audit1.Visible = False
                BT_AuditSave.Visible = True
                Panel1.Visible = True
                If strDocType = "措施說明書變更申請" Then
                    Session("MODIDOCVERSION") = (GetLastModifyVersion("SET", Session("CNO"))).ToString
                    Session("MODIFYDOC_SERIAL") = (GetLastModifySerial("SET", Session("CNO"))).ToString
                Else
                    Session("MODIDOCVERSION") = (GetLastModifyVersion("VRY", Session("CNO"))).ToString
                    Session("MODIFYDOC_SERIAL") = (GetLastModifySerial("VRY", Session("CNO"))).ToString
                End If
                FillForm()

                MultiView1.SetActiveView(View_EPB)

                TB_CNO.Enabled = False
                TB_CONTACTPHONE.Enabled = False
                TB_EMAIL.Enabled = False
                TB_FACABBR.Enabled = False
                TB_DOCVERSION.Enabled = False
                TB_REGDATE.Enabled = False
                TB_REGISTOR.Enabled = False
                TB_DOC_SERIAL.Enabled = False
                bt_summit.Visible = False
                bt_return.Visible = False
                BT_SetDoc.Visible = False
                BT_VryDoc.Visible = False

            Else
                '事業單位
                MultiView1.SetActiveView(View_EPC)


                '變更申請的審查狀態
                'Select *   from DAHS_EXAMLIST where  DOCTYPE='措施說明書變更申請'
                Dim CaseModifyStatus = GetDocModifyCaseStatus(Session("CNO"), strDocVersion, strDocType)

                '措施說明書的同版號申請狀態
                'Select *   from DAHS_EXAMLIST where  DOCTYPE='措施說明書'
                Dim CaseExamSta = GetCaseExamStatus(Session("CNO"), strDocVersion, strDocType)
                Dim Sqlstr As String = "Select * from DAHS_MODIFY where cno='" + Session("CNO").ToString + "' and  doctype='" + Session("DOCTYPE").ToString + "'  ORDER BY REGDATE DESC "

                Dim strModifyVersion As String = Session("MODIFYDOCVERSION").ToString
                Dim strModifySerial As String = Session("MODIFYDOC_SERIAL").ToString

                Select Case strDocMode
                    Case "審查通過"
                        FillForm()
                        BT_Audit1.Visible = True
                        BT_Audit1.Enabled = False
                        Panel1.Visible = True
                        Panel1.Enabled = False
                        bt_summit.Visible = True

                        If strDocType = "措施說明書變更申請" Then
                            BT_PDF_DL.Visible = True
                            BT_PDF_DLVRY.Visible = False
                            BT_SetDoc.Visible = True
                            BT_VryDoc.Visible = False
                        Else
                            BT_PDF_DL.Visible = False
                            BT_PDF_DLVRY.Visible = True
                            BT_SetDoc.Visible = False
                            BT_VryDoc.Visible = True
                        End If

                    Case "載入"
                        FillForm()
                        BT_Audit1.Visible = True
                        BT_Audit1.Enabled = False
                        Panel1.Visible = True
                        Panel1.Enabled = False
                        bt_summit.Visible = True

                        If strDocType = "措施說明書變更申請" Then
                            BT_PDF_DL.Visible = True
                            BT_PDF_DLVRY.Visible = False
                        Else
                            BT_PDF_DL.Visible = False
                            BT_PDF_DLVRY.Visible = True
                        End If
                    Case "新表格"

                        BT_Audit1.Visible = True
                        BT_Audit1.Enabled = False
                        Panel1.Visible = True
                        Panel1.Enabled = False
                        bt_summit.Visible = True
                        TB_CNO.Text = Session("CNO")
                        TB_FACABBR.Text = Session("FAC_NAME")
                        TB_DOC_SERIAL.Text = strModifySerial
                        Session("DOC_SERIAL") = strModifySerial
                        TB_DOCVERSION.Text = strModifyVersion
                        Session("DOCVERSION") = strModifyVersion
                        If strDocType = "措施說明書變更申請" Then
                            BT_PDF_DL.Visible = True
                            BT_PDF_DLVRY.Visible = False
                        Else
                            BT_PDF_DL.Visible = False
                            BT_PDF_DLVRY.Visible = True
                        End If
                End Select

            End If
        End If

    End Sub

    Protected Sub BT_RATA_Click(sender As Object, e As EventArgs) Handles BT_QryPdf.Click

        Try
            Dim strDocType As String = Session("DOCTYPE").ToString
            If strDocType = "措施說明書變更申請" Then
                DownLoadPDF("AUC_Modify", strDocType)
            Else
                DownLoadPDF("AUC_VRY_Modify", strDocType)
            End If

        Catch ex As Exception

        End Try



    End Sub

    Protected Sub BT_DELRATA_Click(sender As Object, e As EventArgs) Handles BT_DEL_PDF.Click


        Try
            '儲存檔案到磁碟

            EraseFile2SqlBlob("", "", "")

        Catch ex As Exception
            'txtMsg.Text += ex.Message.ToString()
        End Try


    End Sub

    Private Sub EraseFile2SqlBlob(ByVal SourceFilePath As String, ByVal SourceFileName As String, ByVal PdfIndex As String)


        Dim strDocVersion As String = TB_DOCVERSION.Text.ToString
        Dim cn As New SqlConnection(DBconntext)
        Dim cmd As New SqlCommand("delete from DOC_MODIFY_PDFUPload where cno=@CNo and  DOCVERSION=@DOCVERSION ", cn)


        Dim CNO As New SqlParameter("@CNo", SqlDbType.NVarChar, 8, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
        Dim DOCVERSION As New SqlParameter("@DOCVERSION", SqlDbType.NVarChar, 6, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, strDocVersion)


        cmd.Parameters.Add(CNO)
        cmd.Parameters.Add(DOCVERSION)

        cn.Open()
        cmd.ExecuteNonQuery()
        cn.Close()
    End Sub

    Protected Sub AUC_Modify_FileUploadComplete(sender As Object, e As DevExpress.Web.FileUploadCompleteEventArgs) Handles AUC_Modify.FileUploadComplete

        Dim strDocType As String = Session("DOCTYPE").ToString
        'Dim strScript_Success As String = "<script language=JavaScript> alert(""上傳成功!!!""); </script>"
        'Dim strScript_Fail As String = "<script language=JavaScript> alert(""上傳失敗!!!""); </script>"
        Try

            Upload(AUC_Modify, strDocType)

            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Success)
            'Else
            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Fail)

        Catch ex As Exception

        End Try



    End Sub

    Public Function Upload(ByVal myFileUpload As DevExpress.Web.ASPxUploadControl, ByVal strDocType As String) As Boolean
        '取得網站根目錄路徑
        Dim path As String = HttpContext.Current.Request.MapPath("~/PDFUPLOAD/SetModify/")
        Dim Vrypath As String = HttpContext.Current.Request.MapPath("~/PDFUPLOAD/VerifyModify/")
        Dim docindex As String
        Dim SavePDFFilName As String
        Dim strDocVersion As String = Session("DOCVERSION")

        docindex = 0
        '檢查是否有檔案
        If (myFileUpload.HasFile) Then
            Try
                '儲存檔案到磁碟
                'If Right(myFileUpload.ClientID, 11) = "FileUpload1" Then
                'docindex = "1"
                'End If
                Select Case myFileUpload.ID

                    Case "AUC_Modify"
                        If strDocType = "措施說明書變更申請" Then
                            docindex = "AUC_Modify"
                        Else
                            docindex = "AUC_VRY_Modify"
                        End If

                    Case "AUC_Modify_Confirm"

                        If strDocType = "措施說明書變更申請" Then
                            docindex = "AUC_Modify_Confirm"
                        Else
                            docindex = "AUC_VRY_Modify_Confirm"
                        End If

                        '措施說明書申請確認書
                End Select

                SavePDFFilName = Session("CNO") + Session("DP_NO") + myFileUpload.FileName
                myFileUpload.SaveAs(path & SavePDFFilName)
                File2SqlBlob(path, SavePDFFilName, docindex, strDocVersion)
                Label_File.Text = "<h3>上傳成功</h3>，檔名---- " + SavePDFFilName
                'Dim strScript_QryItem As String = "<script language=JavaScript> alert(""您已順利上傳" + SavePDFFilName + "檔案""); </script>"
                'ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_QryItem)

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

    Private Sub File2SqlBlob(ByVal SourceFilePath As String, ByVal SourceFileName As String, ByVal PdfIndex As String, ByVal MyDocVersion As String)

        'Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CEMS_EQUConnectionString").ConnectionString.ToString

        Dim cn As New SqlConnection(DBconntext)
        Dim getresult As DbResult
        Dim ActionMode As String = ""

        Dim strSql As String = " select * from   DOC_MODIFY_PDFUPload where cno='" + Session("CNO") + "'and  DocIndex='" + PdfIndex + "' and DocVersion='" + MyDocVersion + "'"

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

            Try
                Dim cmd As New SqlCommand("INSERT INTO DOC_MODIFY_PDFUPload (CNo,DocIndex,DocVersion,DocNumber,path,filename,pdffile,CreatorID,CreateDate) VALUES (@CNo,@DocIndex,@DocVersion,@DocNumber,@path,@filename,@pdffile,@CreatorID,@CreateDate) ", cn)
                Dim fs As New System.IO.FileStream(SourceFilePath & SourceFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                Dim b(fs.Length() - 1) As Byte
                fs.Read(b, 0, b.Length)
                fs.Close()
                Dim CNO As New SqlParameter("@CNo", SqlDbType.NVarChar, 8, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
                Dim DocIndex As New SqlParameter("@DocIndex", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, PdfIndex)
                Dim DocVersion As New SqlParameter("@DocVersion", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyDocVersion)
                Dim DocNumber As New SqlParameter("@DocNumber", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, "1")
                Dim path As New SqlParameter("@path", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, SourceFilePath)
                Dim filename As New SqlParameter("@filename", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, SourceFileName)
                Dim P As New SqlParameter("@pdffile", SqlDbType.Image, b.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, b)
                Dim CreatorID As New SqlParameter("@CreatorID", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
                Dim CreateTime As New SqlParameter("@CreateDate", SqlDbType.DateTime, 20, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Today())

                cmd.Parameters.Add(CNO)
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
            Catch ex As Exception

            End Try


        Else

            Try

                Dim cmd As New SqlCommand("UPDATE  DOC_MODIFY_PDFUPload  SET  pdffile=@pdffile,filename=@filename,path=@path  WHERE CNO=@CNO and  docindex=@DocIndex and DocVersion=@DocVersion ", cn)
                Dim fs As New System.IO.FileStream(SourceFilePath & SourceFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                Dim b(fs.Length() - 1) As Byte
                fs.Read(b, 0, b.Length)
                fs.Close()
                Dim CNO As New SqlParameter("@CNo", SqlDbType.NVarChar, 8, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
                Dim DocIndex As New SqlParameter("@DocIndex", SqlDbType.NVarChar, 30, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, PdfIndex)
                Dim DocVersion As New SqlParameter("@DocVersion", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, MyDocVersion)
                Dim DocNumber As New SqlParameter("@DocNumber", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, "1")
                Dim path As New SqlParameter("@path", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, SourceFilePath)
                Dim filename As New SqlParameter("@filename", SqlDbType.NVarChar, 200, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, SourceFileName)
                Dim P As New SqlParameter("@pdffile", SqlDbType.Image, b.Length, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, b)
                Dim CreatorID As New SqlParameter("@CreatorID", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Session("CNO"))
                Dim CreateTime As New SqlParameter("@CreateDate", SqlDbType.DateTime, 20, ParameterDirection.Input, False, 0, 0, Nothing, DataRowVersion.Current, Today())

                cmd.Parameters.Add(CNO)
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
            Catch ex As Exception

            End Try


        End If

        cn.Close()
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles bt_summit.Click


        Dim strDocMode As String = Session("DOCMODE").ToString
        Dim strDocType As String = Session("DOCTYPE").ToString

        Try

            'Save 
            Dim TempCno, TempDP_NO, TempDocVersion, tempDocType As String
            Dim getresult As DbResult
            Dim aff_row As Integer
            Dim ActionMode As String = ""
            Dim InsertSQL As String = "INSERT INTO [DAHS_MODIFY] ([CNO], [ABBR], [DOCTYPE], [REGISTOR], [CONTACTPHONE], [EMAIL], [MODIFYCOUNT], [REGDATE], [DOCVERSION], [DOC_SERIAL], [C_ID], [C_DATE]) VALUES (@CNO, @ABBR, @DOCTYPE, @REGISTOR, @CONTACTPHONE, @EMAIL, @MODIFYCOUNT, @REGDATE, @DOCVERSION, @DOC_SERIAL, @C_ID, @C_DATE)"
            Dim UpdateSQL As String = "UPDATE [DAHS_MODIFY] SET [ABBR] = @ABBR, [REGISTOR] = @REGISTOR, [CONTACTPHONE] = @CONTACTPHONE, [EMAIL] = @EMAIL, [MODIFYCOUNT] = @MODIFYCOUNT, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCTYPE] = @DOCTYPE AND [REGDATE] = @REGDATE AND [DOCVERSION] = @DOCVERSION AND [DOC_SERIAL] = @DOC_SERIAL"

            Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
            SDS_PlanPolFeature.ConnectionString = DBconntext

            TempCno = Session("CNO")
            TempDP_NO = Session("DP_NO")
            tempDocType = Session("DOCTYPE")
            Session("DOCVERSION") = TB_DOCVERSION.Text
            Session("DOC_SERIAL") = TB_DOC_SERIAL.Text

            If strDocMode = "新表格" Then

                Try

                    With SDS_PlanPolFeature

                        .InsertParameters.Add("CNo", Session("CNO"))
                        .InsertParameters.Add("ABBR", TB_FACABBR.Text)
                        .InsertParameters.Add("DOCVERSION", TB_DOCVERSION.Text)
                        .InsertParameters.Add("DOCTYPE", strDocType)
                        .InsertParameters.Add("REGISTOR", TB_REGISTOR.Text)
                        .InsertParameters.Add("CONTACTPHONE", TB_CONTACTPHONE.Text)
                        .InsertParameters.Add("EMAIL", TB_EMAIL.Text)
                        .InsertParameters.Add("MODIFYCOUNT", TB_DOCVERSION.Text)
                        .InsertParameters.Add("REGDATE", CDate(TB_REGDATE.Text))
                        .InsertParameters.Add("DOC_SERIAL", TB_DOC_SERIAL.Text)
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
                        .UpdateParameters.Add("ABBR", TB_FACABBR.Text)
                        .UpdateParameters.Add("DOCVERSION", TB_DOCVERSION.Text)
                        .UpdateParameters.Add("DOCTYPE", strDocType)
                        .UpdateParameters.Add("REGISTOR", TB_REGISTOR.Text)
                        .UpdateParameters.Add("CONTACTPHONE", TB_CONTACTPHONE.Text)
                        .UpdateParameters.Add("EMAIL", TB_EMAIL.Text)
                        .UpdateParameters.Add("MODIFYCOUNT", TB_DOCVERSION.Text)
                        .UpdateParameters.Add("REGDATE", CDate(TB_REGDATE.Text))
                        .UpdateParameters.Add("DOC_SERIAL", TB_DOC_SERIAL.Text)
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


            If RBL_AuditResult.Text = "須補正" Then

                Session("FIXMODE") = "補正件"

            ElseIf RBL_AuditResult.Text = "駁回" Then

                Session("FIXMODE") = "駁回件"

            Else
                Session("FIXMODE") = "正常件"

            End If

            Server.Transfer("PrepareSummit.aspx")

        Catch ex As Exception

        End Try



    End Sub



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


    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles bt_return.Click

        Server.Transfer("MainList.aspx")


    End Sub

    Public Function DownLoadPDF(ByVal MyDocIndex As String, ByVal strDocType As String) As String

        Dim TempCno, TempDP_NO, TempDocVersion As String
        Dim getresult As DbResult

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        TempDocVersion = Session("DOCVERSION")

        Dim Sqlstr As String = "Select pdffile from DOC_MODIFY_PDFUPload where docindex='" + MyDocIndex + "' and cno='" + TempCno + "' and DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                If MyDocIndex = "AUC_Modify_Confirm" Or MyDocIndex = "AUC_VRY_Modify_Confirm" Then
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

    Public Shared Function InsertAuditRecord(ByVal MyCno As String, ByVal MyDocVersion As String, ByVal MyDocSerial As String, ByVal MyDocType As String, ByVal MyDocTranxType As String, ByVal MyAuditMemo As String, ByVal MySendUser As String, ByVal MyFixDate As Date) As String

        '文件在送審、審核、退回、補送各種動作皆會列入交易紀錄

        Dim getresult As DbResult
        Dim ActionMode As String = ""
        Dim aff_row As Integer = 0
        Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim InsertSQL As String = ""
        Dim UpdateSQL As String = ""

        InsertSQL = " INSERT INTO [DAHS_AuditResult] ([CNO], [DocVersion],  [DOC_SERIAL], [DOCTYPE], [AUDITSERIAL], [AUDITRESULT], [AUDITMEMO], [AUDITDATE], [Auditor], [CreatorID], [CreateDate],[U_ID],[U_DATE]) VALUES (@CNO, @DocVersion, @DOC_SERIAL,  @DOCTYPE, @AUDITSERIAL, @AUDITRESULT, @AUDITMEMO, @AUDITDATE, @Auditor, @CreatorID, @CreateDate,@U_ID,@U_DATE) "
        UpdateSQL = " UPDATE [DAHS_AuditResult] SET [AUDITRESULT]=@AUDITRESULT, [AUDITMEMO]=@AUDITMEMO, [AUDITDATE]=@AUDITDATE, [Auditor]=@Auditor,U_ID=@U_ID, U_DATE=@U_DATE WHERE CNO=@CNO AND DOCVERSION=@DOCVERSION AND DOCTYPE=@DOCTYPE AND DOC_SERIAL = @DOC_SERIAL "
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
                    .InsertParameters.Add("DOC_SERIAL", MyDocSerial)
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
                    .UpdateParameters.Add("DOC_SERIAL", MyDocSerial)
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
                    InsertTranxRecord(strCno, strDocVersion, strDocType, strExamResult, strOWNER)
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Else

            commandtext = "Update [DAHS_ExamList] set EXAM_RESULT=@EXAM_RESULT,OWNER=@OWNER,EXAM_DOCOUT_DATE=@EXAM_DOCOUT_DATE  where CNO=@CNO and DOCVERSION=@DOCVERSION and DOCTYPE=@DOCTYPE "
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
                    InsertTranxRecord(strCno, strDocVersion, strDocType, strExamResult, strOWNER)
                End Using
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End If
    End Function

    Protected Function GetOwnerName(ByVal strOwner As String)


        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader

        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  a.username,b.email,b.comment,b.proxyuser,b.proxyemail,b.name from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where a.username='" + strOwner + "'"
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                strOwner = DatasetOwner.GetString(5)
            End While


        Catch ex As Exception

        End Try

        Return strOwner

    End Function

    Protected Sub BT_Audit1_Click(sender As Object, e As EventArgs) Handles BT_Audit1.Click

        Dim strDocVersion As String = TB_DOCVERSION.Text.ToString
        Dim strDocSerial As String = TB_DOC_SERIAL.Text.ToString

        If RBL_AuditResult.Text = "審查通過" Then

            UpdateDahsMainMode(Session("DOCTYPE"), "審查通過", Session("CNO"), strDocVersion, GetOwnerName(Session("UserName")), Today)
            InsertAuditRecord(Session("CNO"), strDocVersion, strDocSerial, Session("DOCTYPE"), "審查通過", TB_AuditMemo.Text, Session("UserName"), Today)
            InsertTranxRecord(Session("CNO"), strDocVersion, Session("DOCTYPE"), "審查通過", Session("UserName"))
            Session("ExamPassDate") = Today.Date.ToShortDateString
            Session("MAILTYPE") = "變更審查通過(第一階段)"

        ElseIf RBL_AuditResult.Text = "須補正" Then

            UpdateDahsMainMode(Session("DOCTYPE"), "補正中", Session("CNO"), strDocVersion, GetOwnerName(Session("UserName")), TB_Audit_DATE.Date)
            InsertAuditRecord(Session("CNO"), strDocVersion, strDocSerial, Session("DOCTYPE"), "須補正", TB_AuditMemo.Text, Session("UserName"), TB_Audit_DATE.Date)
            InsertTranxRecord(Session("CNO"), strDocVersion, Session("DOCTYPE"), "須補正", Session("UserName"))
            Session("MAILTYPE") = "須補正"
            Session("DOCFIXDATE") = TB_Audit_DATE.Date.ToShortDateString

        ElseIf RBL_AuditResult.Text = "駁回" Then

            UpdateDahsMainMode(Session("DOCTYPE"), "駁回", Session("CNO"), strDocVersion, GetOwnerName(Session("UserName")), Today)
            InsertAuditRecord(Session("CNO"), strDocVersion, strDocSerial, Session("DOCTYPE"), "駁回", TB_AuditMemo.Text, Session("UserName"), Today)
            InsertTranxRecord(Session("CNO"), strDocVersion, Session("DOCTYPE"), "駁回", Session("UserName"))
            Session("MAILTYPE") = "駁回"
            Session("ExamPassDate") = Today.Date.ToShortDateString

        ElseIf RBL_AuditResult.Text = "不適用" Then

            UpdateDahsMainMode(Session("DOCTYPE"), "不適用", Session("CNO"), strDocVersion, GetOwnerName(Session("UserName")), Today)
            InsertAuditRecord(Session("CNO"), strDocVersion, strDocSerial, Session("DOCTYPE"), "不適用", TB_AuditMemo.Text, Session("UserName"), Today)
            InsertTranxRecord(Session("CNO"), strDocVersion, Session("DOCTYPE"), "不適用", Session("UserName"))
            Session("MAILTYPE") = "不適用"
            Session("ExamPassDate") = Today.Date.ToShortDateString

        End If

        Try
            Server.Transfer("EpbNotifyMessage.aspx")
        Catch ex As Exception

        End Try

    End Sub



    Private Sub FillForm()

        Dim TempCno, TempDP_NO, tempDocType, strDocVersion, strDoc_Serial As String

        Dim getresult As DbResult
        Dim MYTYPE As String = ""

        TempCno = Session("CNO")
        TempDP_NO = Session("DP_NO")
        tempDocType = Session("DOCTYPE")
        Dim Sqlstr As String = "Select * from DAHS_MODIFY where cno='" + TempCno + "'  and  doctype='" + tempDocType + "'  ORDER BY REGDATE DESC"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                TB_CNO.Text = getresult.returnDataTable.Rows(0).Item("CNO").ToString
                TB_FACABBR.Text = getresult.returnDataTable.Rows(0).Item("ABBR").ToString
                TB_CONTACTPHONE.Text = getresult.returnDataTable.Rows(0).Item("CONTACTPHONE").ToString
                TB_EMAIL.Text = getresult.returnDataTable.Rows(0).Item("EMAIL").ToString
                TB_DOCVERSION.Text = getresult.returnDataTable.Rows(0).Item("DOCVERSION").ToString
                strDocVersion = getresult.returnDataTable.Rows(0).Item("DOCVERSION").ToString
                strDoc_Serial = getresult.returnDataTable.Rows(0).Item("DOC_SERIAL").ToString
                TB_REGISTOR.Text = getresult.returnDataTable.Rows(0).Item("REGISTOR").ToString
                TB_REGDATE.Text = CDate(getresult.returnDataTable.Rows(0).Item("REGDATE").ToString)
                TB_DOC_SERIAL.Text = getresult.returnDataTable.Rows(0).Item("DOC_SERIAL").ToString
                Session("DOCVERSION") = strDocVersion
                Session("DOC_SERIAL") = strDoc_Serial
            End If

            Dim AuditSqlstr As String = "Select * from DAHS_AuditResult where cno='" + TempCno + "'  and docversion='" + strDocVersion + "' and   doctype='" + tempDocType + "' and doc_serial='" + strDoc_Serial + "'"

            getresult = EIPDB.GetData(AuditSqlstr)

            If getresult.ReturnCode >= 1 Then

                TB_AuditMemo.Text = getresult.returnDataTable.Rows(0).Item("AUDITMEMO").ToString
                RBL_AuditResult.SelectedValue = getresult.returnDataTable.Rows(0).Item("AUDITRESULT").ToString
                TB_Audit_DATE.Date = getresult.returnDataTable.Rows(0).Item("AUDITSERIAL").ToString

            End If

        Catch ex As Exception


        End Try


    End Sub

    Protected Sub AUC_Modify_Confirm_FileUploadComplete(sender As Object, e As DevExpress.Web.FileUploadCompleteEventArgs) Handles AUC_Modify_Confirm.FileUploadComplete

        Dim strDocType As String = Session("DOCTYPE").ToString
        'Dim strScript_Fail As String = "<script language=JavaScript> alert(""上傳失敗!!!""); </script>"
        Try

            Upload(AUC_Modify_Confirm, strDocType)
            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_FileUPLCompleted)
            'Else
            'ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Fail)
            'End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub BT_DEL_JPG_Click(sender As Object, e As EventArgs) Handles BT_DEL_JPG.Click

        Try
            '儲存檔案到磁碟

            'EraseFile2SqlBlob("", "", "")

        Catch ex As Exception
            'txtMsg.Text += ex.Message.ToString()
        End Try


    End Sub




    Protected Sub BT_SetDoc_Click(sender As Object, e As EventArgs) Handles BT_SetDoc.Click

        '要檢查上一個版本是否已經審查完成
        Dim strScript_Error As String = "<script language=JavaScript> alert(""文件尚未審查通過前不得進行變更!!!""); </script>"
        Dim strScript_CopySuccess As String = "<script language=JavaScript> alert(""文件複製成功!!!""); </script>"
        Dim strScript_CopyFail As String = "<script language=JavaScript> alert(""文件複製失敗!!!""); </script>"

        Dim LastDocversion As String = EIPDB.GetDocVersion("SET", Session("CNO"))

        Dim getresult As DbResult
        Dim strSQL As String = ""
        Dim strExamResult As String = ""

        'strSQL = "Select EXAM_RESULT  from DAHS_EXAMLIST where cno='" + Session("CNO") + "' and docversion='" + LastDocversion + "'  and DOCTYPE in ('措施說明書變更申請','確認報告書變更申請')"
        strSQL = "Select EXAM_RESULT  from DAHS_EXAMLIST where cno='" + Session("CNO") + "' and docversion='" + LastDocversion + "'  and DOCTYPE in ('措施說明書','確認報告書')"


        Try
            getresult = EIPDB.GetData(strSQL)
            strExamResult = getresult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
        Catch ex As Exception

        End Try


        If strExamResult = "補正中" Or strExamResult = "補正重送" Or strExamResult = "已送未審" Or strExamResult = "審查中" Then

            'show message

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
            Exit Sub

        Else
            'allow change and copy doc data to next version
            Session("DOCVERSION") = LastDocversion
            'Copy Last Doc to New Version

            Try
                Dim CopyReturn As String = CopySetDocToNextVersion(Session("CNO"), (CInt(LastDocversion)).ToString, (CInt(LastDocversion) + 1).ToString)

                If CopyReturn = "TRUE" Then
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_CopySuccess)
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_CopyFail)
                End If
            Catch ex As Exception

            End Try


            Session("DOCFIX") = "變更"
            Session("DOCVERSION") = (LastDocversion + 1).ToString
            Session("NEW_DOCVERSION") = (CInt(LastDocversion) + 1).ToString
            Session("DOCNEW") = "NEW"
            Session("DOCMODE") = "措施說明書變更申請"

            Server.Transfer("SetDoc.aspx")

        End If


    End Sub

    Public Shared Function CopyVryDocToNextVersion(MyCNO As String, ByVal MyDOCVersion As Integer, ByVal NewDocVewrsion As Integer) As String

        Dim getresult As DbResult

        Dim EraseVry_FacSqlstr As String = "DELETE FROM DOC_VRY_FACTORY_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseVry_ItemSqlstr As String = "DELETE FROM DOC_VRY_ITEM_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseVry_LinkSqlstr As String = "DELETE FROM DOC_VRY_LINK_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseVry_SPECSqlstr As String = "DELETE FROM DOC_VRY_SPEC_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseVry_LEDSqlstr As String = "DELETE FROM DOC_VRY_LED_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseVry_DAHSSqlstr As String = "DELETE FROM DOC_VRY_DAHS_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseVry_LPSqlstr As String = "DELETE FROM DOC_VRY_LP_TEMP WHERE CNO='" + MyCNO + "' "
        Dim EraseVry_CHKSqlstr As String = "DELETE FROM DOC_VRY_CHECKLIST_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseVry_PDFSqlstr As String = "DELETE FROM DOC_VRY_PDFUPload_TEMP WHERE CNO='" + MyCNO + "'"

        Dim CopyVry_FacSqlstr As String = "INSERT INTO DOC_VRY_FACTORY_TEMP SELECT * FROM DOC_VRY_FACTORY WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_ItemSqlstr As String = "INSERT INTO DOC_VRY_ITEM_TEMP SELECT * FROM DOC_VRY_ITEM WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LinkSqlstr As String = "INSERT INTO DOC_VRY_LINK_TEMP SELECT * FROM DOC_VRY_LINK WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_SPECSqlstr As String = "INSERT INTO DOC_VRY_SPEC_TEMP SELECT * FROM DOC_VRY_SPEC WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LEDSqlstr As String = "INSERT INTO DOC_VRY_LED_TEMP  SELECT * FROM DOC_VRY_LED WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_DAHSSqlstr As String = "INSERT INTO DOC_VRY_DAHS_TEMP  SELECT * FROM DOC_VRY_DAHS WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LPSqlstr As String = "INSERT INTO DOC_VRY_LP_TEMP  SELECT * FROM DOC_VRY_LP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_CHKSqlstr As String = "INSERT INTO DOC_VRY_CHECKLIST_TEMP  SELECT * FROM DOC_VRY_CHECKLIST WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_PDFSqlstr As String = "INSERT INTO DOC_VRY_PDFUPload_TEMP  SELECT * FROM DOC_VRY_PDFUPload WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"

        Dim UpdateVry_FacSqlstr As String = "UPDATE DOC_VRY_FACTORY_TEMP SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateVry_ItemSqlstr As String = "UPDATE  DOC_VRY_ITEM_TEMP SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateVry_LinkSqlstr As String = "UPDATE DOC_VRY_LINK_TEMP SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateVry_SPECSqlstr As String = "UPDATE DOC_VRY_SPEC_TEMP SET DOCVERSION='" + NewDocVewrsion.ToString + "' WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateVry_LEDSqlstr As String = "UPDATE DOC_VRY_LED_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "' WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateVry_DAHSSqlstr As String = "UPDATE DOC_VRY_DAHS_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "' WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateVry_LPSqlstr As String = "UPDATE DOC_VRY_LP_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "' WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateVry_CHKSqlstr As String = "UPDATE DOC_VRY_CHECKLIST_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateVry_PDFSqlstr As String = "UPDATE DOC_VRY_PDFUPload_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"

        Dim ReInsertVry_FacSqlstr As String = "INSERT INTO DOC_VRY_FACTORY SELECT * FROM DOC_VRY_FACTORY_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertVry_ItemSqlstr As String = "INSERT INTO DOC_VRY_ITEM SELECT * FROM DOC_VRY_ITEM_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertVry_LinkSqlstr As String = "INSERT INTO DOC_VRY_LINK SELECT * FROM DOC_VRY_LINK_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertVry_SPECSqlstr As String = "INSERT INTO DOC_VRY_SPEC SELECT * FROM DOC_VRY_SPEC_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertVry_LEDSqlstr As String = "INSERT INTO DOC_VRY_LED  SELECT * FROM DOC_VRY_LED_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertVry_DAHSSqlstr As String = "INSERT INTO DOC_VRY_DAHS  SELECT * FROM DOC_VRY_DAHS_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertVry_LPSqlstr As String = "INSERT INTO DOC_VRY_LP  SELECT * FROM DOC_VRY_LP_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertVry_CHKSqlstr As String = "INSERT INTO DOC_VRY_CHECKLIST  SELECT * FROM DOC_VRY_CHECKLIST_TEMP  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertVry_PDFSqlstr As String = "INSERT INTO DOC_VRY_PDFUPload  SELECT * FROM DOC_VRY_PDFUPload_TEMP  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"


        Try
            'erase exist data
            getresult = EIPDB.Execute(EraseVry_FacSqlstr)
            getresult = EIPDB.Execute(EraseVry_ItemSqlstr)
            getresult = EIPDB.Execute(EraseVry_LinkSqlstr)
            getresult = EIPDB.Execute(EraseVry_SPECSqlstr)
            getresult = EIPDB.Execute(EraseVry_LEDSqlstr)
            getresult = EIPDB.Execute(EraseVry_DAHSSqlstr)
            getresult = EIPDB.Execute(EraseVry_LPSqlstr)
            getresult = EIPDB.Execute(EraseVry_CHKSqlstr)
            getresult = EIPDB.Execute(EraseVry_PDFSqlstr)

            ' copy to temp
            getresult = EIPDB.Execute(CopyVry_FacSqlstr)
            getresult = EIPDB.Execute(CopyVry_ItemSqlstr)
            getresult = EIPDB.Execute(CopyVry_LinkSqlstr)
            getresult = EIPDB.Execute(CopyVry_SPECSqlstr)
            getresult = EIPDB.Execute(CopyVry_LEDSqlstr)
            getresult = EIPDB.Execute(CopyVry_DAHSSqlstr)
            getresult = EIPDB.Execute(CopyVry_LPSqlstr)
            getresult = EIPDB.Execute(CopyVry_CHKSqlstr)
            getresult = EIPDB.Execute(CopyVry_PDFSqlstr)

            'update version

            getresult = EIPDB.Execute(UpdateVry_FacSqlstr)
            getresult = EIPDB.Execute(UpdateVry_ItemSqlstr)
            getresult = EIPDB.Execute(UpdateVry_LinkSqlstr)
            getresult = EIPDB.Execute(UpdateVry_SPECSqlstr)
            getresult = EIPDB.Execute(UpdateVry_LEDSqlstr)
            getresult = EIPDB.Execute(UpdateVry_DAHSSqlstr)
            getresult = EIPDB.Execute(UpdateVry_LPSqlstr)
            getresult = EIPDB.Execute(UpdateVry_CHKSqlstr)
            getresult = EIPDB.Execute(UpdateVry_PDFSqlstr)

            'return to table 
            getresult = EIPDB.Execute(ReInsertVry_FacSqlstr)
            getresult = EIPDB.Execute(ReInsertVry_ItemSqlstr)
            getresult = EIPDB.Execute(ReInsertVry_LinkSqlstr)
            getresult = EIPDB.Execute(ReInsertVry_SPECSqlstr)
            getresult = EIPDB.Execute(ReInsertVry_LEDSqlstr)
            getresult = EIPDB.Execute(ReInsertVry_DAHSSqlstr)
            getresult = EIPDB.Execute(ReInsertVry_LPSqlstr)
            getresult = EIPDB.Execute(ReInsertVry_CHKSqlstr)
            getresult = EIPDB.Execute(ReInsertVry_PDFSqlstr)


            CopyVryDocToNextVersion = "TRUE"
        Catch ex As Exception
            CopyVryDocToNextVersion = "FALSE"
        End Try

        Return CopyVryDocToNextVersion


    End Function

    Private Shared Function GetLastModifyVersion(ByVal MyDocType As String, MyCNO As String) As Integer
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select top 1 docversion  from DAHS_MODIFY where cno='" + Trim(MyCNO) + "'  and doctype='措施說明書變更申請'  order by docversion desc "
        Else
            Sqlstr = "Select top 1 docversion  from DAHS_MODIFY where cno='" + Trim(MyCNO) + "'  and doctype='確認報告書變更申請' order by docversion  desc "
        End If

        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetLastModifyVersion = CInt(getresult.returnDataTable.Rows(0).Item("DOCVERSION").ToString)
            Else
                GetLastModifyVersion = 1

            End If

        Catch ex As Exception

        End Try

        Return GetLastModifyVersion


    End Function

    Private Shared Function GetLastModifySerial(ByVal MyDocType As String, MyCNO As String) As Integer
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select top 1 DOC_SERIAL  from DAHS_MODIFY where cno='" + Trim(MyCNO) + "'  and doctype='措施說明書變更申請'  order by docversion desc "
        Else
            Sqlstr = "Select top 1 DOC_SERIAL  from DAHS_MODIFY where cno='" + Trim(MyCNO) + "'  and doctype='確認報告書變更申請' order by docversion  desc "
        End If

        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetLastModifySerial = CInt(getresult.returnDataTable.Rows(0).Item("DOC_SERIAL").ToString)
            Else
                GetLastModifySerial = 1

            End If

        Catch ex As Exception

        End Try

        Return GetLastModifySerial


    End Function

    Private Shared Function GetLastVersion(ByVal MyDocType As String, MyCNO As String) As Integer
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select top 1 docversion  from [DOC_SET_FACTORY] where cno='" + Trim(MyCNO) + "' order by docversion "
        Else
            Sqlstr = "Select top 1 docversion  from [DOC_VRY_FACTORY] where cno='" + Trim(MyCNO) + "' order by docversion "
        End If

        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetLastVersion = CInt(getresult.returnDataTable.Rows(0).Item("DOCVERSION").ToString)
            Else
                GetLastVersion = 1

            End If

        Catch ex As Exception

        End Try

        Return GetLastVersion


    End Function


    Private Shared Function GetCNOStatus(ByVal MyDocType As String, MyCNO As String) As String
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

    Public Shared Function CopySetDocToNextVersion(MyCNO As String, ByVal MyDOCVersion As Integer, ByVal NewDocVewrsion As Integer) As String

        Dim getresult As DbResult


        Dim EraseSet_FacSqlstr As String = "DELETE FROM DOC_SET_FACTORY_TEMP WHERE CNO='" + MyCNO + "' "
        Dim EraseSet_ItemSqlstr As String = "DELETE  FROM DOC_SET_ITEM_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseSet_LinkSqlstr As String = "DELETE FROM DOC_SET_LINK_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseSet_SPECSqlstr As String = "DELETE FROM DOC_SET_SPEC_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseSet_LEDSqlstr As String = "DELETE FROM DOC_SET_LED_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseSet_DAHSSqlstr As String = "DELETE FROM DOC_SET_DAHS_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseSet_LPSqlstr As String = "DELETE FROM DOC_SET_LP_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseSet_CheckListSqlstr As String = "DELETE FROM DOC_SET_CHECKLIST_TEMP WHERE CNO='" + MyCNO + "'"
        Dim EraseSet_PDFSqlstr As String = "DELETE FROM DOC_SET_PDFUPload_TEMP WHERE CNO='" + MyCNO + "'"

        Dim CopySet_FacSqlstr As String = "INSERT INTO DOC_SET_FACTORY_TEMP  SELECT * FROM DOC_SET_FACTORY WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopySet_ItemSqlstr As String = "INSERT INTO DOC_SET_ITEM_TEMP SELECT * FROM DOC_SET_ITEM WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopySet_LinkSqlstr As String = "INSERT INTO DOC_SET_LINK_TEMP  SELECT * FROM DOC_SET_LINK WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopySet_SPECSqlstr As String = "INSERT INTO DOC_SET_SPEC_TEMP   SELECT * FROM DOC_SET_SPEC WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopySet_LEDSqlstr As String = "INSERT INTO DOC_SET_LED_TEMP  SELECT * FROM DOC_SET_LED WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopySet_DAHSSqlstr As String = "INSERT INTO DOC_SET_DAHS_TEMP  SELECT * FROM DOC_SET_DAHS WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopySet_LPSqlstr As String = "INSERT INTO DOC_SET_LP_TEMP  SELECT * FROM DOC_SET_LP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopySet_CheckListSqlstr As String = "INSERT INTO DOC_SET_CHECKLIST_TEMP  SELECT * FROM DOC_SET_CHECKLIST WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopySet_PDFSqlstr As String = "INSERT INTO DOC_SET_PDFUPload_TEMP  SELECT * FROM DOC_SET_PDFUPload WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"

        Dim UpdateSet_FacSqlstr As String = "UPDATE  DOC_SET_FACTORY_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateSet_ItemSqlstr As String = "UPDATE DOC_SET_ITEM_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateSet_LinkSqlstr As String = "UPDATE DOC_SET_LINK_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateSet_SPECSqlstr As String = "UPDATE  DOC_SET_SPEC_TEMP   SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateSet_LEDSqlstr As String = "UPDATE  DOC_SET_LED_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateSet_DAHSSqlstr As String = "UPDATE  DOC_SET_DAHS_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateSet_LPSqlstr As String = " UPDATE  DOC_SET_LP_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "' WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateSet_CheckListSqlstr As String = "UPDATE  DOC_SET_CHECKLIST_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim UpdateSet_PDFSqlstr As String = "UPDATE  DOC_SET_PDFUPload_TEMP  SET DOCVERSION='" + NewDocVewrsion.ToString + "'  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"

        Dim ReInsertSet_FacSqlstr As String = "INSERT INTO DOC_SET_FACTORY  SELECT * FROM DOC_SET_FACTORY_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertSet_ItemSqlstr As String = "INSERT INTO DOC_SET_ITEM SELECT * FROM DOC_SET_ITEM_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertSet_LinkSqlstr As String = "INSERT INTO DOC_SET_LINK  SELECT * FROM DOC_SET_LINK_TEMP  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertSet_SPECSqlstr As String = "INSERT INTO DOC_SET_SPEC   SELECT * FROM DOC_SET_SPEC_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertSet_LEDSqlstr As String = "INSERT INTO DOC_SET_LED  SELECT * FROM DOC_SET_LED_TEMP  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertSet_DAHSSqlstr As String = "INSERT INTO DOC_SET_DAHS  SELECT * FROM DOC_SET_DAHS_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertSet_LPSqlstr As String = "INSERT INTO DOC_SET_LP  SELECT * FROM DOC_SET_LP_TEMP WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertSet_CheckListSqlstr As String = "INSERT INTO DOC_SET_CHECKLIST  SELECT * FROM DOC_SET_CHECKLIST_TEMP  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"
        Dim ReInsertSet_PDFSqlstr As String = "INSERT INTO DOC_SET_PDFUPload  SELECT * FROM DOC_SET_PDFUPload_TEMP  WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + NewDocVewrsion.ToString + "'"

        Try

            getresult = EIPDB.Execute(EraseSet_FacSqlstr)
            getresult = EIPDB.Execute(EraseSet_ItemSqlstr)
            getresult = EIPDB.Execute(EraseSet_LinkSqlstr)
            getresult = EIPDB.Execute(EraseSet_SPECSqlstr)
            getresult = EIPDB.Execute(EraseSet_LEDSqlstr)
            getresult = EIPDB.Execute(EraseSet_DAHSSqlstr)
            getresult = EIPDB.Execute(EraseSet_LPSqlstr)
            getresult = EIPDB.Execute(EraseSet_CheckListSqlstr)
            getresult = EIPDB.Execute(EraseSet_PDFSqlstr)

            getresult = EIPDB.Execute(CopySet_FacSqlstr)
            getresult = EIPDB.Execute(CopySet_ItemSqlstr)
            getresult = EIPDB.Execute(CopySet_LinkSqlstr)
            getresult = EIPDB.Execute(CopySet_SPECSqlstr)
            getresult = EIPDB.Execute(CopySet_LEDSqlstr)
            getresult = EIPDB.Execute(CopySet_DAHSSqlstr)
            getresult = EIPDB.Execute(CopySet_LPSqlstr)
            getresult = EIPDB.Execute(CopySet_CheckListSqlstr)
            getresult = EIPDB.Execute(CopySet_PDFSqlstr)

            getresult = EIPDB.Execute(UpdateSet_FacSqlstr)
            getresult = EIPDB.Execute(UpdateSet_ItemSqlstr)
            getresult = EIPDB.Execute(UpdateSet_LinkSqlstr)
            getresult = EIPDB.Execute(UpdateSet_SPECSqlstr)
            getresult = EIPDB.Execute(UpdateSet_LEDSqlstr)
            getresult = EIPDB.Execute(UpdateSet_DAHSSqlstr)
            getresult = EIPDB.Execute(UpdateSet_LPSqlstr)
            getresult = EIPDB.Execute(UpdateSet_CheckListSqlstr)
            getresult = EIPDB.Execute(UpdateSet_PDFSqlstr)

            getresult = EIPDB.Execute(ReInsertSet_FacSqlstr)
            getresult = EIPDB.Execute(ReInsertSet_ItemSqlstr)
            getresult = EIPDB.Execute(ReInsertSet_LinkSqlstr)
            getresult = EIPDB.Execute(ReInsertSet_SPECSqlstr)
            getresult = EIPDB.Execute(ReInsertSet_LEDSqlstr)
            getresult = EIPDB.Execute(ReInsertSet_DAHSSqlstr)
            getresult = EIPDB.Execute(ReInsertSet_LPSqlstr)
            getresult = EIPDB.Execute(ReInsertSet_CheckListSqlstr)
            getresult = EIPDB.Execute(ReInsertSet_PDFSqlstr)

            CopySetDocToNextVersion = "TRUE"
        Catch ex As Exception
            CopySetDocToNextVersion = "FALSE"
        End Try

        Return CopySetDocToNextVersion


    End Function

    Protected Sub BT_VryDoc_Click(sender As Object, e As EventArgs) Handles BT_VryDoc.Click


        '要檢查上一個版本是否已經審查完成
        Dim strScript_Error As String = "<script language=JavaScript> alert(""文件尚未審查通過前不得進行變更!!!""); </script>"
        Dim strScript_CopySuccess As String = "<script language=JavaScript> alert(""文件複製成功!!!""); </script>"
        Dim strScript_CopyFail As String = "<script language=JavaScript> alert(""文件複製失敗!!!""); </script>"


        Dim LastDocversion As String = EIPDB.GetDocVersion("VRY", Session("CNO"))

        'Dim DocLastVersion As Integer = GetLastVersion("措施說明書", Session("CNO"))
        Dim getresult As DbResult
        Dim strSQL As String = ""
        Dim strExamResult As String = ""

        Session("DOCMODE") = "確認報告書變更申請"

        'strSQL = "Select EXAM_RESULT  from DAHS_EXAMLIST where cno='" + Session("CNO") + "' and docversion='" + LastDocversion + "'  and DOCTYPE in ('措施說明書變更申請','確認報告書變更申請')"

        strSQL = "Select EXAM_RESULT  from DAHS_EXAMLIST where cno='" + Session("CNO") + "' and docversion='" + LastDocversion + "'  and DOCTYPE in ('措施說明書','確認報告書')"

        Try
            getresult = EIPDB.GetData(strSQL)
            strExamResult = getresult.returnDataTable.Rows(0).Item("EXAM_RESULT").ToString
        Catch ex As Exception

        End Try

        If strExamResult = "補正中" Or strExamResult = "補正重送" Or strExamResult = "已送未審" Or strExamResult = "審查中" Then

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
            Exit Sub
        Else

            Session("DOCVERSION") = LastDocversion
            'Copy Last Doc to New Version

            Dim CopyReturn As String = CopyVryDocToNextVersion(Session("CNO"), (CInt(LastDocversion)).ToString, (CInt(LastDocversion) + 1).ToString)

            If CopyReturn = "TRUE" Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_CopySuccess)
            Else
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_CopyFail)
            End If

            ' Transfer to set page And load ner version

            Session("DOCFIX") = "變更"
            Session("DOCVERSION") = (LastDocversion + 1).ToString
            Session("NEW_DOCVERSION") = (CInt(LastDocversion) + 1).ToString
            Session("DOCNEW") = "NEW"
            Session("DOCMODE") = "確認報告書變更申請"

            Server.Transfer("VryDoc.aspx")

        End If

    End Sub

    Protected Sub BT_QryJPG_Click(sender As Object, e As EventArgs) Handles BT_QryJPG.Click

        Try
            Dim strDocType As String = Session("DOCTYPE").ToString
            If strDocType = "措施說明書變更申請" Then
                DownLoadPDF("AUC_Modify_Confirm", strDocType)
            Else
                DownLoadPDF("AUC_VRY_Modify_Confirm", strDocType)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub RBL_AuditResult_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RBL_AuditResult.SelectedIndexChanged

        If RBL_AuditResult.Text = "須補正" Then

            TB_Audit_DATE.Visible = True
        Else
            TB_Audit_DATE.Visible = False
        End If

    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            Dim strDocType As String = Session("DOCTYPE").ToString
            If strDocType = "措施說明書變更申請" Then
                DownLoadPDF("AUC_Modify", strDocType)
            Else
                DownLoadPDF("AUC_VRY_Modify", strDocType)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Try
            Dim strDocType As String = Session("DOCTYPE").ToString
            If strDocType = "措施說明書變更申請" Then
                DownLoadPDF("AUC_Modify_Confirm", strDocType)
            Else
                DownLoadPDF("AUC_VRY_Modify_Confirm", strDocType)
            End If
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub BT_AuditSave_Click(sender As Object, e As EventArgs) Handles BT_AuditSave.Click
        'FOR 協辦人員審查暫存使用

        Dim strDocVersion As String = TB_DOCVERSION.Text.ToString
        Dim strDocSerial As String = TB_DOC_SERIAL.Text.ToString

        If RBL_AuditResult.Text = "審查通過" Then
            InsertAuditRecord(Session("CNO"), strDocVersion, strDocSerial, Session("DOCTYPE"), "審查通過", TB_AuditMemo.Text, Session("UserName"), Today)
            InsertTranxRecord(Session("CNO"), strDocVersion, Session("DOCTYPE"), "審查通過", Session("UserName"))

        ElseIf RBL_AuditResult.Text = "須補正" Then
            InsertAuditRecord(Session("CNO"), strDocVersion, strDocSerial, Session("DOCTYPE"), "須補正", TB_AuditMemo.Text, Session("UserName"), TB_Audit_DATE.Date)
            InsertTranxRecord(Session("CNO"), strDocVersion, Session("DOCTYPE"), "須補正", Session("UserName"))

        ElseIf RBL_AuditResult.Text = "駁回" Then
            InsertAuditRecord(Session("CNO"), strDocVersion, strDocSerial, Session("DOCTYPE"), "駁回", TB_AuditMemo.Text, Session("UserName"), Today)
            InsertTranxRecord(Session("CNO"), strDocVersion, Session("DOCTYPE"), "駁回", Session("UserName"))

        ElseIf RBL_AuditResult.Text = "不適用" Then
            InsertAuditRecord(Session("CNO"), strDocVersion, strDocSerial, Session("DOCTYPE"), "不適用", TB_AuditMemo.Text, Session("UserName"), Today)
            InsertTranxRecord(Session("CNO"), strDocVersion, Session("DOCTYPE"), "不適用", Session("UserName"))


        End If

    End Sub
End Class