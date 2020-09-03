Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Net.Mail
Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser


Public Class PrepareSummit
    Inherits System.Web.UI.Page

    Dim strAbbr As String = ""
    Dim SB As New System.Text.StringBuilder


    Public Shared Function ReturnEPBOwner(ByVal MyCno As String) As String

        Dim QueryResult As String = ""
        Dim myid As String = Right(MyCno, 1)

        Select Case myid

            Case "A"
                If Right(MyCno, 1) = "A" Then QueryResult = "A"
            Case "B"
                If Right(MyCno, 1) = "B" Or Right(MyCno, 1) = "L" Then QueryResult = "B"
            Case "C"
                If Right(MyCno, 1) = "C" Then QueryResult = "C"
            Case "D"
                If Right(MyCno, 1) = "D" Or Right(MyCno, 1) = "R" Then QueryResult = "D"
            Case "E"
                If Right(MyCno, 1) = "E" Or Right(MyCno, 1) = "S" Then QueryResult = "E"
            Case "F"
                If Right(MyCno, 1) = "F" Then QueryResult = "F"
            Case "G"
                If Right(MyCno, 1) = "G" Then QueryResult = "G"
            Case "H"
                If Right(MyCno, 1) = "H" Then QueryResult = "H"
            Case "I"
                If Right(MyCno, 1) = "I" Then QueryResult = "I"
            Case "J"
                If Right(MyCno, 1) = "J" Then QueryResult = "J"
            Case "K"
                If Right(MyCno, 1) = "K" Then QueryResult = "K"
            Case "L"
                If Right(MyCno, 1) = "L" Or Right(MyCno, 1) = "B" Then QueryResult = "B"
            Case "M"
                If Right(MyCno, 1) = "M" Then QueryResult = "M"
            Case "N"
                If Right(MyCno, 1) = "N" Then QueryResult = "N"
            Case "O"
                If Right(MyCno, 1) = "O" Then QueryResult = "O"
            Case "P"
                If Right(MyCno, 1) = "P" Then QueryResult = "P"
            Case "Q"
                If Right(MyCno, 1) = "Q" Then QueryResult = "Q"
            Case "R"
                If Right(MyCno, 1) = "R" Or Right(MyCno, 1) = "D" Then QueryResult = "D"
            Case "S"
                If Right(MyCno, 1) = "S" Or Right(MyCno, 1) = "E" Then QueryResult = "E"
            Case "T"
                If Right(MyCno, 1) = "T" Then QueryResult = "T"
            Case "U"
                If Right(MyCno, 1) = "U" Then QueryResult = "U"
            Case "V"
                If Right(MyCno, 1) = "V" Then QueryResult = "V"
            Case "X"
                If Right(MyCno, 1) = "X" Then QueryResult = "X"
            Case "W"
                If Right(MyCno, 1) = "W" Then QueryResult = "W"
            Case "Z"
                If Right(MyCno, 1) = "Z" Then QueryResult = "Z"

        End Select

        Return QueryResult


    End Function

    Public Shared Function GetEPBInfo(MyCNO As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try

            Sqlstr = "SELECT  b.epb from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where  a.username='" + MyCNO + "' "

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetEPBInfo = getresult.returnDataTable.Rows(0).Item(0).ToString
            Else
                GetEPBInfo = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return GetEPBInfo

    End Function

    Public Shared Function GetCNOInfo(MyCNO As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try

            Sqlstr = "SELECT  CompanyName from cwms_1  where controlno='" + MyCNO + "'"

            Try
                getresult = EIPDB.GetData(Sqlstr)
                If getresult.returnDataTable.Rows.Count > 0 Then
                    GetCNOInfo = getresult.returnDataTable.Rows(0).Item("CompanyName").ToString
                Else
                    GetCNOInfo = "許可資料庫中查無此管制編號"
                End If

            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try

        Return GetCNOInfo


    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strScript_Error As String = "<script language=JavaScript> alert(""系統已逾時，請重新登入使用...""); </script>"

        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If

        If Session("CNO") = "" Then

            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Error)
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
            Exit Sub

        Else
            TB_CNO.Text = Session("CNO")
            TB_DOCTYPE.Text = Session("DOCTYPE")
            TB_DOCVERSION.Text = Session("DOCVERSION")
            DOC_REGDATE.Text = CDate(Today.Date.ToShortDateString)
            TB_FIXMODE.Text = Session("FIXMODE")
            strAbbr = Session("FAC_NAME")
            'Session("FAC_NAME") = strAbbr
        End If


    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click

        Try
            Server.Transfer("MainList.aspx")
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        Dim ReturnRow As Integer
        Dim strDocTypr As String = ""
        Dim strEpbBelong As String = ""
        Dim strScript_Successful As String = "<script language=JavaScript> alert(""文件已成功送出，系統將會送出收執聯至您登記的信箱中...""); </script>"
        'Dim strDocSerial As Integer

        strDocTypr = Session("DOCTYPE")

        Try
            strEpbBelong = ReturnEPBOwner(GetEPBInfo(Session("CNO")))
        Catch ex As Exception

        End Try

        ' strDocSerial += 1

        Try

            If strDocTypr = "措施說明書" And TB_FIXMODE.Text = "正常件" Then

                ReturnRow = InsertExamList(Session("CNO"), Session("FAC_NAME"), Session("DOCVERSION"), "措施說明書", "已送未審", strEpbBelong)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "送出審查", Session("UserName"))

            ElseIf strDocTypr = "措施說明書" And TB_FIXMODE.Text = "補正件" Then

                ReturnRow = UpdateExamList(Session("CNO"), Session("DOCVERSION"), "措施說明書", "補正重送")
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "補件後重送", Session("UserName"))

            ElseIf strDocTypr = "措施說明書" And TB_FIXMODE.Text = "駁回件" Then

                ReturnRow = UpdateExamList(Session("CNO"), Session("DOCVERSION"), "措施說明書", "駁回重送")
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書", "駁回後重送", Session("UserName"))

            ElseIf strDocTypr = "措施說明書變更申請" And TB_FIXMODE.Text = "正常件" Then

                ReturnRow = InsertExamList(Session("CNO"), Session("FAC_NAME"), Session("DOCVERSION"), "措施說明書變更申請", "已送未審", strEpbBelong)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書變更申請", "送出審查", Session("UserName"))

            ElseIf strDocTypr = "措施說明書變更申請" And TB_FIXMODE.Text = "補正件" Then

                ReturnRow = UpdateExamList(Session("CNO"), Session("DOCVERSION"), "措施說明書變更申請", "補正重送")
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書變更申請", "補件後重送", Session("UserName"))

            ElseIf strDocTypr = "措施說明書變更申請" And TB_FIXMODE.Text = "駁回件" Then

                ReturnRow = UpdateExamList(Session("CNO"), Session("DOCVERSION"), "措施說明書變更申請", "駁回重送")
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "措施說明書變更申請", "駁回後重送", Session("UserName"))

            ElseIf strDocTypr = "確認報告書" And TB_FIXMODE.Text = "正常件" Then

                ReturnRow = InsertExamList(Session("CNO"), Session("FAC_NAME"), Session("DOCVERSION"), "確認報告書", "已送未審", strEpbBelong)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "確認報告書", "送出審查", Session("UserName"))

            ElseIf strDocTypr = "確認報告書" And TB_FIXMODE.Text = "補正件" Then

                ReturnRow = UpdateExamList(Session("CNO"), Session("DOCVERSION"), "確認報告書", "補正重送")
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "確認報告書", "補件後重送", Session("UserName"))

            ElseIf strDocTypr = "確認報告書" And TB_FIXMODE.Text = "駁回件" Then

                ReturnRow = UpdateExamList(Session("CNO"), Session("DOCVERSION"), "確認報告書", "駁回重送")
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "確認報告書", "駁回後重送", Session("UserName"))

            ElseIf strDocTypr = "確認報告書變更申請" And TB_FIXMODE.Text = "正常件" Then

                ReturnRow = InsertExamList(Session("CNO"), Session("FAC_NAME"), Session("DOCVERSION"), "確認報告書變更申請", "已送未審", strEpbBelong)
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "確認報告書變更申請", "送出審查", Session("UserName"))

            ElseIf strDocTypr = "確認報告書變更申請" And TB_FIXMODE.Text = "補正件" Then

                ReturnRow = UpdateExamList(Session("CNO"), Session("DOCVERSION"), "確認報告書變更申請", "補正重送")
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "確認報告書變更申請", "補件後重送", Session("UserName"))

            ElseIf strDocTypr = "確認報告書變更申請" And TB_FIXMODE.Text = "駁回件" Then

                ReturnRow = UpdateExamList(Session("CNO"), Session("DOCVERSION"), "確認報告書變更申請", "駁回重送")
                InsertTranxRecord(Session("CNO"), Session("DOCVERSION"), "確認報告書變更申請", "駁回後重送", Session("UserName"))

            End If


            '送出通知信
            If ReturnRow > 0 Then
                mailSEND(Session("CNO"), strAbbr, DOC_REGDATE.Text, Session("UserName"), "EPB" + strEpbBelong)

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Successful)
            End If

        Catch ex As Exception

        End Try

        'Server.Transfer("MainList.aspx")



    End Sub

    Public Sub mailSEND(ByVal strCNOInfo As String, ByVal strAbbr As String, ByVal strDate As String, ByVal strEpcUserName As String, ByVal strEpbInfo As String) ' 發送 Email 的程序(超限警示)

        'Dim CEMSDBHOST1 As String = "data source=localhost;initial catalog=cwms_test;user id=sa;pwd=VisionGood!;packet size=4096"
        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString()

        Dim strScript_Fail As String = "<script language=JavaScript> alert(""無法成功發送電子郵件,請聯絡客服人員...""); </script>"
        'WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString()

        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim conn2 As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim mycommand2 As New SqlCommand

        Dim mailMSG As New MailMessage
        Dim strQryEpbMail As String = ""
        Dim strQryEpcMail As String = ""
        Dim DatasetEpbmail As SqlDataReader
        Dim DatasetEpcmail As SqlDataReader

        Dim strDocTypr As String = ""
        strDocTypr = Session("DOCTYPE")

        Dim strCaseNo As String = GetMaxNumMailRecord(Session("CNO"))

        Try

            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  a.username,b.email,b.comment from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where left(b.IdType,4)='" + strEpbInfo + "'"

            DatasetEpbmail = mycommand.ExecuteReader

            conn2.Open()
            mycommand2.Connection = conn2
            mycommand2.CommandText = "Select  a.username,b.email,b.comment from aspnet_Users a inner join  dbo.aspnet_Membership b On a.userid=b.userid where a.username='" & strEpcUserName & "'"
            DatasetEpcmail = mycommand2.ExecuteReader


            If strDocTypr = "措施說明書" Then
                If TB_FIXMODE.Text = "正常件" Then
                    SB.Append(vbCrLf)
                    SB.Append("收執聯" + "                                案件編號:" + strCaseNo)
                    SB.Append(vbCrLf)
                    SB.Append(strAbbr + "(管制編號: " + strCNOInfo + ") 您好:")
                    SB.Append("本系統已收到 貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)申請資料。")
                    SB.Append(vbCrLf)
                    SB.Append("此據")
                    SB.Append("受理申請系統:廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統")
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                Else
                    SB.Append(vbCrLf)
                    SB.Append("收執聯" + "                                案件編號:" + strCaseNo)
                    SB.Append(vbCrLf)
                    SB.Append(strAbbr + "(管制編號: " + strCNOInfo + ") 您好:")
                    SB.Append("本系統已收到 貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)補正資料。")
                    SB.Append(vbCrLf)
                    SB.Append("此據")
                    SB.Append("受理申請系統:廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統")
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                End If
            Else

                If TB_FIXMODE.Text = "正常件" Then
                    SB.Append(vbCrLf)
                    SB.Append("收執聯" + "                                案件編號:" + strCaseNo)
                    SB.Append(vbCrLf)
                    SB.Append(strAbbr + "(管制編號: " + strCNOInfo + ") 您好:")
                    SB.Append("本系統已收到 貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)變更申請資料。")
                    SB.Append(vbCrLf)
                    SB.Append("此據")
                    SB.Append("受理申請系統:廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統")
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                Else
                    SB.Append(vbCrLf)
                    SB.Append("收執聯" + "                                案件編號:" + strCaseNo)
                    SB.Append(vbCrLf)
                    SB.Append(strAbbr + "(管制編號: " + strCNOInfo + ") 您好:")
                    SB.Append("本系統已收到 貴單位" & strDate & "以網路傳輸方式上傳之自動監測（視）設施措施說明書(或確認報告書)變更補正資料。")
                    SB.Append(vbCrLf)
                    SB.Append("此據")
                    SB.Append("受理申請系統:廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統")
                    SB.Append(vbCrLf)
                    SB.Append("*本信函係由系統自動發送，請勿直接回覆！   ")
                End If

            End If

            SB.Append(vbCrLf)

            ' 發送電子郵件=======================================================
            With mailMSG
                .From = New MailAddress("TYCEMS@msa.hinet.net", "廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統   ") '發送者
                '.From = New MailAddress("a0-cwms@epa.gov.tw", "廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統") '發送者 
                .SubjectEncoding = System.Text.Encoding.UTF8  '主題編碼格式 
                .Subject = "廢（污）水自動監測(視)設施措施說明書及確認報告書登錄系統---通知信"
                .IsBodyHtml = False    'HTML語法(true:開啟false:關閉) 	
                .BodyEncoding = System.Text.Encoding.UTF8 '內文編碼格式 
                .Body = SB.ToString  '內文 
                '.Attachments.Add(New System.Net.Mail.Attachment("C:\Files\FileA.txt"))
                Try
                    .To.Add("ken@leads.tw")  '收件者
                    '.To.Add("a0-cwms@epa.gov.tw")  '收件者
                    ' .Bcc.Add("456@gmail.com") '隱藏收件者 
                    '.CC.Add("aaron.")  '副本 

                    While DatasetEpbmail.Read
                        .CC.Add(Trim(DatasetEpbmail.GetString(1)))
                        '.CC.Add(Trim(DatasetEpbmail.GetString(4)))
                    End While

                    While DatasetEpcmail.Read
                        .CC.Add(Trim(DatasetEpcmail.GetString(1)))
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
            ''mySmtp.EnableSsl = True '開啟SSL驗證 
            mySmtp.Send(mailMSG) '發送 	

            InsertMailRecord(strCaseNo, Session("CNO"), GetCNOInfo(Session("CNO")), Session("DOCTYPE"), Session("DOCTYPE"), mailMSG.Body.ToString, mailMSG.CC.ToString)


            ' ==================================================================
        Catch ex As Exception
            'Call ALARMLOG("無法成功發送電子郵件")
            'MessageBox.Show("無法成功發送電子郵件,請檢查基本設定")
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript_Fail)
            Exit Try
        End Try



    End Sub

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

    Public Shared Function InsertExamList(ByVal strCNO As String, ByVal strFacName As String, ByVal strDocversion As String, ByVal strDocType As String, ByVal strExamResult As String, ByVal strEpb As String) As Integer

        Dim getresult As DbResult
        Dim ReturnRow As Integer
        Dim InsertSQL As String = "insert into DAHS_EXAMLIST (cno,fac_name,docversion,doctype,reg_date,exam_result,epb) values('" + strCNO + "','" + strFacName + "','" + strDocversion + "','" + strDocType + "','" + Now.Date.ToLocalTime.ToShortDateString + "','" + strExamResult + "','" + strEpb + "')"

        Try
            getresult = EIPDB.Execute(InsertSQL)
            ReturnRow = getresult.ReturnCode
            Return ReturnRow
        Catch ex As Exception

        End Try

    End Function

    Private Shared Function UpdateExamList(ByVal strCNO As String, ByVal strDocversion As String, ByVal strDocType As String, ByVal strExamResult As String) As Integer

        Dim getresult As DbResult
        Dim ReturnRow As Integer
        Dim UpdateSQL As String = "update  DAHS_EXAMLIST set  exam_result='" + strExamResult + "' where cno='" + strCNO + "' and docversion='" + strDocversion + "' and doctype='" + strDocType + "'"

        Try
            getresult = EIPDB.Execute(UpdateSQL)
            ReturnRow = getresult.ReturnCode
            Return ReturnRow
        Catch ex As Exception

        End Try

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



    Public Shared Function InsertAuditRecord(ByVal MyCno As String, ByVal MyDocVersion As String, ByVal MyDocSerial As String, ByVal MyDocType As String, ByVal MyDocTranxType As String, ByVal MyAuditMemo As String, ByVal MySendUser As String) As String

        '文件在送審、審核、退回、補送各種動作皆會列入交易紀錄

        Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim commandtext As String = ""

        commandtext = " INSERT INTO [DAHS_AuditResult] ([CNO], [DocVersion], [DOC_SERIAL],  [DOCTYPE], [AUDITSERIAL], [AUDITRESULT], [AUDITMEMO], [AUDITDATE], [Auditor], [CreatorID], [CreateDate]) VALUES (@CNO, @DocVersion, @DOC_SERIAL,  @DOCTYPE, @AUDITSERIAL, @AUDITRESULT, @AUDITMEMO, @AUDITDATE, @Auditor, @CreatorID, @CreateDate) "


        Try
            Using connection As New SqlConnection(DBconntext)

                Dim command As New SqlCommand(commandtext, connection)

                command.Parameters.Add("@CNO", SqlDbType.Char)
                command.Parameters("@CNO").Value = MyCno
                command.Parameters.Add("@DocVersion", SqlDbType.Int)
                command.Parameters("@DocVersion").Value = MyDocVersion
                command.Parameters.Add("@DocVersion", SqlDbType.Int)
                command.Parameters("@DocVersion").Value = MyDocSerial
                command.Parameters.Add("@DOCTYPE", SqlDbType.Char)
                command.Parameters("@DOCTYPE").Value = MyDocType
                command.Parameters.Add("@AUDITSERIAL", SqlDbType.DateTime)
                command.Parameters("@AUDITSERIAL").Value = Now
                command.Parameters.Add("@AUDITRESULT", SqlDbType.Char)
                command.Parameters("@AUDITRESULT").Value = MyDocTranxType
                command.Parameters.Add("@AUDITMEMO", SqlDbType.Char)
                command.Parameters("@AUDITMEMO").Value = ""
                command.Parameters.Add("@AUDITDATE", SqlDbType.DateTime)
                command.Parameters("@AUDITDATE").Value = Now
                command.Parameters.Add("@Auditor", SqlDbType.Char)
                command.Parameters("@Auditor").Value = MySendUser
                command.Parameters.Add("@CreatorID", SqlDbType.Char)
                command.Parameters("@CreatorID").Value = MySendUser
                command.Parameters.Add("@CreateDate", SqlDbType.DateTime)
                command.Parameters("@CreateDate").Value = Now

                connection.Open()

                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                'Console.WriteLine("RowsAffected: {0}", rowsAffected)

                If rowsAffected > 0 Then

                    InsertAuditRecord = "Successful"
                End If

            End Using
        Catch ex As Exception

            'Console.WriteLine(ex.Message)

        End Try

        Return InsertAuditRecord

    End Function

    Protected Sub BT_RECEIPT_Click(sender As Object, e As EventArgs) Handles BT_RECEIPT.Click

        Dim doc = New Document(PageSize.A4, 50, 50, 80, 50)

        Dim memory = New MemoryStream
        PdfWriter.GetInstance(doc, memory)

        Dim bfchinese = BaseFont.CreateFont("C:\WINDOWS\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED)


        Dim chFont_blue = New Font(bfchinese, 14, Font.NORMAL, New BaseColor(51, 0, 153))

        'SB.Clear()
        'SB.Append("<header></header>")
        'SB.Append("<main>")
        'SB.Append("<table><tr><td>THIS IS TEST</td></tr></table>")
        'SB.Append("</main>")

        doc.Open()

        doc.Add(New Paragraph(10.0F, "本系統已接獲 貴單位以網路傳輸方式申請之自動監測﹙視﹚及連線傳輸措施說明書或確認報告書申請資料。", chFont_blue))

        doc.Close()

        Response.Clear()
        Response.AddHeader("content-Disposition", "attachment;filename=pdfExample.pdf")
        Response.ContentType = "application/octet-stream"
        Response.OutputStream.Write(memory.GetBuffer, 0, memory.GetBuffer().Length)
        Response.OutputStream.Flush()
        Response.OutputStream.Close()
        Response.Flush()
        Response.End()


    End Sub
End Class