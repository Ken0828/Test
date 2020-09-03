Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Net.Mail
Imports iTextSharp.text
Imports System.IO
Imports System.Collections


Public Class EpbNotifyMessage
    Inherits System.Web.UI.Page

    Dim SB As New System.Text.StringBuilder
    Dim strNewMailRecord As MailRecord
    Dim strCaseNo As String = ""


    Structure OwnerPara
        Public Name As String
        Public Phone As String
        Public EPB As String
        Public AdminID As String
    End Structure

    Structure MailRecord
        Public Case_No As String
        Public Send_Date As String
        Public CNO As String
        Public Fac_Name As String
        Public Mail_Type As String
        Public DocType As String
        Public Mail_Content As String
        Public EmailToList As String
    End Structure

    Dim Owner_Name As String = ""
    Dim Owner_Epb As String = ""
    Dim Owner_Phone As String = ""

    Protected Shared Function GetUserName(ByVal strName As String) As String

        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString()
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader

        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "select  a.UserName  from aspnet_Users a inner join aspnet_Membership b on a.UserId=b.UserId where b.Name='" + strName + "' "
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                GetUserName = DatasetOwner.GetString(0)
            End While

        Catch ex As Exception

        End Try

        Return GetUserName

    End Function




    Protected Shared Function GetOwnerName(ByVal MyOWNER As String) As Array

        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString()
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader
        Dim strOwner(10) As String

        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "select  b.Name,b.ContactPhone,b.EPB  from aspnet_Users a inner join aspnet_Membership b on a.UserId=b.UserId where a.UserName='" + MyOWNER + "' "
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                strOwner(0) = DatasetOwner.GetString(0)
                strOwner(1) = DatasetOwner.GetString(1)
                strOwner(2) = DatasetOwner.GetString(2)
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


        'If Not IsPostBack Then
        Dim strMailType As String = ""
            Dim strFacName As String = ""
            Dim strCNOInfo As String = ""
            Dim strOWNER As String = ""
            Dim strNewOWNER As String = ""
            Dim strDate As String = ""
            Dim strPhone As String = ""
            Dim strEPB As String = ""
            Dim strPassDate As String = ""
            Dim strFixDate As String = ""
            Dim strDocType As String = ""
            Dim strOwnerName As String = ""
            Dim strOwnerInfo(10) As String


            strMailType = Session("MAILTYPE")
            strCNOInfo = Session("CNO")
            strOWNER = Session("OWNER")
            strNewOWNER = Session("NEWOWNER")
            strDate = Session("DOC_RECDATE")
            strEPB = Session("")
            strPhone = Session("")
            strPassDate = Session("ExamPassDate")
            strFixDate = Session("DOCFIXDATE")
            strDocType = Session("DOCTYPE")
            strFacName = Session("FAC_NAME")

            Try
                strOwnerInfo = GetOwnerName(Session("OWNERID"))
            Catch ex As Exception

            End Try

            strEPB = strOwnerInfo(2)
            strOWNER = strOwnerInfo(0)
            strPhone = strOwnerInfo(1)

            strCaseNo = GetMaxNumMailRecord(Session("CNO"))

            TB_CaseNo.Text = strCaseNo


            Select Case strMailType

                Case "前往審查"
                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:                  案件編號:" + strCaseNo)
                    SB.Append(vbCrLf)
                    SB.Append("    貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)申請(/變更/補正)資料，")
                    SB.Append("本案件由本環保局" & Left(strOWNER, 1) & "先生(小姐)承辦負責審查，聯絡電話:" + strPhone)
                    SB.Append(vbCrLf)
                    SB.Append(strEPB)
                    SB.Append(vbCrLf)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")

                    Memo1.Text = SB.ToString

                    ASPxButton1.Visible = True
                    ASPxButton2.Visible = True
                    ASPxButton3.Visible = False

                Case "不適用"
                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:")
                    SB.Append("    貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)變更資料，")
                    SB.Append("經本局審查發現不適用應設置自動監測（視）設施之適用對象，故退回貴單位之申請案件。")
                    SB.Append(strEPB + "承辦人:" + Left(strOWNER, 1) + "先生(小姐)  聯絡電話:" + strPhone)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")

                    Memo1.Text = SB.ToString

                    ASPxButton1.Visible = False
                    ASPxButton2.Visible = False
                    ASPxButton3.Visible = True

                Case "駁回"
                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:")
                    SB.Append("    貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)變更資料，")
                    SB.Append("經本局審查發現尚未達貴單位申請內容之同意狀況，故予以駁回。")
                    SB.Append(strEPB + "承辦人:" + Left(strOWNER, 1) + "先生(小姐)  聯絡電話:" + strPhone)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")
                    Memo1.Text = SB.ToString

                    ASPxButton1.Visible = False
                    ASPxButton2.Visible = False
                    ASPxButton3.Visible = True
                Case "須補正"
                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:                  案件編號:" + strCaseNo)
                    SB.Append("    貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)申請(/變更/補正)資料，")
                SB.Append("經本局審查後認定尚須補正相關資料，請於" & strFixDate & "前依審查意見至系統完成補正及更新資料，裨利完成後續申請程序。")
                SB.Append(strEPB + "承辦人:" + Left(strOWNER, 1) + "先生(小姐)  聯絡電話:" + strPhone)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")

                    Memo1.Text = SB.ToString

                    ASPxButton1.Visible = False
                    ASPxButton2.Visible = False
                    ASPxButton3.Visible = True
                Case "申請審查通過"
                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:                  案件編號:" + strCaseNo)
                    SB.Append("一、貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)申請資料，")
                    SB.Append("經　本局審查後已於" & strPassDate & "核准， 貴單位自核准日起應依自動監測﹙視﹚及連線傳輸措施說明書或確認報告書之核准內容據以實施。")
                    SB.Append("二、本次核准內容後續如有變更無法依核准內容完成設置者，應於裝設前以網路傳輸方式申請變更，經本局核准後方可實施。")
                    SB.Append("此據")
                    SB.Append(strEPB + "承辦人:" + Left(strOWNER, 1) + "先生(小姐)  聯絡電話:" + strPhone)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")

                    Memo1.Text = SB.ToString

                    ASPxButton1.Visible = False
                    ASPxButton2.Visible = False
                    ASPxButton3.Visible = True

                Case "補正審查通過"
                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:                  案件編號:" + strCaseNo)
                    SB.Append("一、貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)補正資料，")
                    SB.Append("經　本局審查後已於" & strPassDate & "核准， 貴單位自核准日起應依自動監測（視）設施措施說明書或確認報告書之核准內容據以實施。")
                    SB.Append("二、本次核准內容後續如有變更無法依核准內容完成設置者，應於裝設前以網路傳輸方式申請變更，經本局核准後方可實施。")
                    SB.Append("此據")
                    SB.Append(strEPB + "承辦人:" + Left(strOWNER, 1) + "先生(小姐)  聯絡電話:" + strPhone)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")

                    Memo1.Text = SB.ToString

                    ASPxButton1.Visible = False
                    ASPxButton2.Visible = False
                    ASPxButton3.Visible = True

                Case "變更審查通過(第一階段)"
                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:                  案件編號:" + strCaseNo)
                    SB.Append("一、貴單位" & strDate & "日以網路傳輸方式上傳之自動監測（視）設施措施說明書（或確認報告書）變更申請表，")
                    SB.Append("經　本局審查後已於" & strPassDate & "日審查通過，　貴單位應依審核通過之變更申請表內容修正原核准之自動監測（視）設施措施說明書（或確認報告書），")
                    SB.Append("並於" & strPassDate & "日以網路傳輸方式上傳至「廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統」，以利完備核准程序。")
                    SB.Append(vbCrLf)
                    SB.Append("二、本次變更若涉及自動監測（視）設施措施說明書（或確認報告書）附件之內容，應一併上傳修正後之附件至「廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統」。")
                    SB.Append(strEPB + "承辦人:" + Left(strOWNER, 1) + "先生(小姐)  聯絡電話:" + strPhone)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")

                    Memo1.Text = SB.ToString

                    ASPxButton1.Visible = False
                    ASPxButton2.Visible = False
                    ASPxButton3.Visible = True

                Case "變更審查通過(第二階段)"

                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:                  案件編號:" + strCaseNo)
                    SB.Append("貴單位" & strDate & "以網路傳輸方式上傳至「廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統」之自動監測（視）設施措施說明書（或確認報告書）修正內容，")
                    SB.Append("經　本局審查後已於" & strPassDate & "核准， 貴單位自核准日起應依自動監測（視）設施措施說明書（或確認報告書）之核准內容據以實施。")
                    SB.Append(strEPB + "承辦人:" + Left(strOWNER, 1) + "先生(小姐)  聯絡電話:" + strPhone)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")

                    Memo1.Text = SB.ToString

                    ASPxButton1.Visible = False
                    ASPxButton2.Visible = False
                    ASPxButton3.Visible = True

                Case "更換審查承辦"

                    SB.Append(vbCrLf)
                    SB.Append(strFacName + "(管制編號:" + strCNOInfo + ") 您好:                  案件編號:" + strCaseNo)
                    SB.Append("    貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)申請(/變更/補正)資料，")
                    SB.Append("本案件即日起改由本環保局" + Left(strOWNER, 1) + "先生(小姐)承辦負責審查，")
                    SB.Append(strEPB + "承辦人:" + Left(strNewOWNER, 1) + "先生(小姐)  聯絡電話:" + strPhone)
                    SB.Append(strDate)
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                    SB.Append(vbCrLf)
                    SB.Append("如對本通知有疑義，請洽當地核發機關尋求協助。   ")

                    Memo1.Text = SB.ToString
                    ASPxButton1.Visible = False
                    ASPxButton2.Visible = False
                    ASPxButton3.Visible = True
            End Select
        'End If

    End Sub

    Public Sub MailSend()

        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString()
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim conn2 As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim mycommand2 As New SqlCommand
        Dim mailMSG As New MailMessage
        Dim strQryEpbMail As String = ""
        Dim strQryEpcMail As String = ""
        Dim DatasetEpbmail As SqlDataReader
        Dim DatasetEpcmail As SqlDataReader

        Dim strScript_Fail As String = "<script language=JavaScript> alert(""無法成功發送電子郵件,請聯絡客服人員...""); </script>"

        Try
            'epb email list
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  b.email from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid "
            mycommand.CommandText += " inner join DAHS_EXAMLIST c On a.username='" + Session("OWNERID") + "' "
            mycommand.CommandText += " where c.cno ='" + Session("CNO") + "' and c.docversion='" + Session("DOCVERSION") + "' and c.doctype='" + Session("DOCTYPE") + "' "
            mycommand.CommandText += " union all "
            mycommand.CommandText += " Select e.email from aspnet_Users d inner join  dbo.aspnet_Membership e On d.userid=e.userid  "
            mycommand.CommandText += " inner Join DAHS_EXAMLIST f On d.username='" + Session("AGENT") + "' "
            mycommand.CommandText += " where f.cno ='" + Session("CNO") + "' and f.docversion='" + Session("DOCVERSION") + "' and f.doctype='" + Session("DOCTYPE") + "' "
            mycommand.CommandText += " union all "
            mycommand.CommandText += " Select h.email from aspnet_Users g inner join  dbo.aspnet_Membership h On g.userid=h.userid  "
            mycommand.CommandText += " inner Join DAHS_EXAMLIST i On g.username='" + Session("HELPER") + "' "
            mycommand.CommandText += " where i.cno ='" + Session("CNO") + "' and i.docversion='" + Session("DOCVERSION") + "' and i.doctype='" + Session("DOCTYPE") + "' "

            DatasetEpbmail = mycommand.ExecuteReader

            'epc email list
            conn2.Open()
            mycommand2.Connection = conn2
            mycommand2.CommandText = "Select  b.email from aspnet_Users a inner join  dbo.aspnet_Membership b On a.userid=b.userid where a.username='" & Session("CNO") & "'"
            DatasetEpcmail = mycommand2.ExecuteReader


            ' 發送電子郵件=======================================================
            With mailMSG
                .From = New MailAddress("TYCEMS@msa.hinet.net", "廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統   ") '發送者
                '.From = New MailAddress("a0-cwms@epa.gov.tw", "廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統   ") '發送者 
                .SubjectEncoding = System.Text.Encoding.UTF8  '主題編碼格式 
                .Subject = "廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統---通知信"
                .IsBodyHtml = False    'HTML語法(true:開啟false:關閉) 	
                .BodyEncoding = System.Text.Encoding.UTF8 '內文編碼格式 
                .Body = SB.ToString  '內文 
                '.Attachments.Add(New System.Net.Mail.Attachment("C:\Files\FileA.txt"))
                Try
                    .To.Add("ken@leads.tw")
                    '.To.Add("a0-cwms@epa.gov.tw")  '收件者
                    ' .Bcc.Add("456@gmail.com") '隱藏收件者 
                    ' .CC.Add("789@gmail.com")  '副本 

                    While DatasetEpbmail.Read
                        .CC.Add(Trim(DatasetEpbmail.GetString(0)))
                        '.CC.Add(Trim(DatasetEpbmail.GetString(4)))
                    End While

                    While DatasetEpcmail.Read
                        .CC.Add(Trim(DatasetEpcmail.GetString(0)))
                        '.CC.Add(Trim(DatasetEpbmail.GetString(4)))
                    End While

                Catch ex As Exception

                End Try

            End With
            Dim mySmtp As New SmtpClient()  '建立SMTP連線 	
            ' mySmtp.Credentials = New System.Net.NetworkCredential("test@gmail.com", "123456")  '連線驗證 
            mySmtp.Port = 25   'SMTP Port 
            mySmtp.Host = "msa.hinet.net"  'SMTP主機名
            'mySmtp.Host = "10.0.101.51"  'SMTP主機名 	
            'mySmtp.EnableSsl = True '開啟SSL驗證 
            mySmtp.Send(mailMSG) '發送 	

            ' ==================================================================
            'Dim strCaseNo As String = Session("CNO") + (CInt(GetMaxNumMailRecord(Session("CNO")).Substring(9, 4)) + 1).ToString


            InsertMailRecord(TB_CaseNo.Text, Session("CNO"), GetCNOInfo(Session("CNO")), Session("DOCTYPE"), Session("DOCTYPE"), mailMSG.Body.ToString, mailMSG.CC.ToString)

        Catch ex As Exception
            'Call ALARMLOG("無法成功發送電子郵件")
            'MessageBox.Show("無法成功發送電子郵件,請檢查基本設定")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Fail)

            Exit Try
        End Try

    End Sub

    Public Shared Function GetCNOInfo(MyCNO As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try

            Sqlstr = "Select  distinct FAC_NAME  from DOC_SET_FACTORY where cno='" + Trim(MyCNO) + "' "

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetCNOInfo = getresult.returnDataTable.Rows(0).Item(0).ToString
            Else
                GetCNOInfo = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return GetCNOInfo


    End Function

    Public Shared Function GetMaxNumMailRecord(ByVal MyCno As String) As String

        Dim getresult As DbResult
        Dim Sqlstr As String = ""
        Dim TempNo As Integer = 0
        Dim TempLastRecord As String = ""


        Try

            Sqlstr = "Select  top 1  case_no  from DAHS_MESSAGE_LOG where cno='" + Trim(MyCno) + "' order by case_no desc  "

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                TempLastRecord = getresult.returnDataTable.Rows(0).Item(0).ToString.Substring(9, 4)

                TempNo = CInt(TempLastRecord) + 1

                If TempNo < 10 Then
                    GetMaxNumMailRecord = MyCno + "-000" + TempNo.ToString
                ElseIf TempNo < 100 Then
                    GetMaxNumMailRecord = MyCno + "-00" + TempNo.ToString
                ElseIf TempNo < 1000 Then
                    GetMaxNumMailRecord = MyCno + "-0" + TempNo.ToString

                End If



            Else
                GetMaxNumMailRecord = MyCno + "-0001"

            End If

        Catch ex As Exception

        End Try

        Return GetMaxNumMailRecord


    End Function

    Public Shared Function InsertMailRecord(ByVal MyCaseNo As String, ByVal MyCno As String, ByVal MyFacName As String, ByVal MyMailtype As String, ByVal MyDoctype As String, ByVal MyMailContent As String, ByVal MyMailList As String) As String

        '收執聯內容存檔進資料庫中
        '先查詢前一筆的編號再加一
        '

        Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim commandtext As String = ""
        Dim strCaseNo As String = ""
        Dim aff_row As Integer = 0

        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        commandtext = " INSERT INTO [dbo].[DAHS_MESSAGE_LOG] ([CASE_NO],[SEND_DATE],[CNO],[FAC_NAME],[MAIL_TYPE],[DOCTYPE],[MAIL_CONTENT],[EMAILTOLIST],[CR_ID],[CR_DATE]) VALUES (@CASE_NO,@SEND_DATE,@CNO,@FAC_NAME,@MAIL_TYPE,@DOCTYPE,@MAIL_CONTENT,@EMAILTOLIST,@CR_ID,@CR_DATE) "

        'strCaseNo = MyCno + (CInt(GetMaxNumMailRecord(MyCno).Substring(9, 4)) + 1).ToString

        With SDS_PlanPolFeature

            .InsertParameters.Add("CASE_NO", MyCaseNo)
            .InsertParameters.Add("SEND_DATE", Today.Date)
            .InsertParameters.Add("CNO", MyCno)
            .InsertParameters.Add("FAC_NAME", MyFacName)
            .InsertParameters.Add("MAIL_TYPE", MyMailtype)
            .InsertParameters.Add("DOCTYPE", MyDoctype)
            .InsertParameters.Add("MAIL_CONTENT", MyMailContent)
            .InsertParameters.Add("EMAILTOLIST", MyMailList)
            .InsertParameters.Add("CR_ID", "SYSTEM")
            .InsertParameters.Add("CR_DATE", Now.Date)
            .InsertCommand = commandtext
            aff_row = .Insert()

        End With

        Return InsertMailRecord

    End Function

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        '發信並開始審查

        Dim strDocType = Session("DOCTYPE")

        Try

            If strDocType = "措施說明書" Then
                'UpdateDahsMainMode("審查/補正中", Session("CNO"), Session("DOCVERSION"), TB_OWNER.Text, TB_DOC_RECDATE.Text)
                MailSend()
                Server.Transfer("SetDoc.aspx")

            ElseIf strDocType = "措施說明書變更申請" Then
                'UpdateDahsMainMode("審查/補正中", Session("CNO"), Session("DOCVERSION"), TB_OWNER.Text, TB_DOC_RECDATE.Text)
                MailSend()
                Server.Transfer("PrepareModify.aspx")

            ElseIf strDocType = "確認報告書" Then
                'UpdateDahsMainMode("審查/補正中", Session("CNO"), Session("DOCVERSION"), TB_OWNER.Text, TB_DOC_RECDATE.Text)
                MailSend()
                Server.Transfer("VryDoc.aspx")

            ElseIf strDocType = "確認報告書變更申請" Then
                'UpdateDahsMainMode("審查/補正中", Session("CNO"), Session("DOCVERSION"), TB_OWNER.Text, TB_DOC_RECDATE.Text)
                MailSend()
                Server.Transfer("PrepareModify.aspx")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click

        '發信但先返回審查清單

        Try
            MailSend()
            Server.Transfer("SetAudit.aspx")
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click


        Try
            MailSend()
            Server.Transfer("SetAudit.aspx")
        Catch ex As Exception

        End Try
    End Sub
End Class