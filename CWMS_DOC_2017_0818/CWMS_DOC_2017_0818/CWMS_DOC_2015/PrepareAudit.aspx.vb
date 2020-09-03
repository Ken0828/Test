Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.Net
Imports System.Net.Mail


Public Class PrepareAudit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If

        TB_CNO.Text = Session("CNO")
        TB_DOCTYPE.Text = Session("DOCTYPE")
        TB_DOCVERSION.Text = Session("DOCVERSION")
        'TB_DOC_REGDATE.Text = Session("DOCREGDATE")
        TB_OWNER.Text = GetOwnerName(Session("UserName"))
        TB_FAC_NAME.Text = Session("FAC_NAME")
        TB_DOC_RECDATE.Text = CDate(Today.Date.ToShortDateString)

        Session("EPB") = ReturnEPBOwner(Session("CNO"))

        Dim TempCno, TempDocVersion, TempDocType, TempSendType As String

        TempCno = Session("CNO")
        TempDocVersion = Session("DOCVERSION")
        TempDocType = Session("DOCTYPE")
        TempSendType = Session("SENDTYPE")
        Dim Sqlstr As String = "Select top 1 DOCDATE from DAHS_TransRecord where cno='" + TempCno + "'  and DocVersion='" + TempDocVersion + "'"
        Dim getresult As DbResult
        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.ReturnCode >= 1 Then

                TB_DOC_REGDATE.Text = getresult.returnDataTable.Rows(0).Item("DOCDATE").ToString
            End If

        Catch ex As Exception


        End Try

    End Sub



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

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click



        '更改案件狀態
        Try

            If TB_DOCTYPE.Text = "措施說明書" Then
                UpdateDahsMainMode("措施說明書", "審查中", Session("CNO"), Session("DOCVERSION"), TB_OWNER.Text, CB_AGENT.Text, CB_HELPER.Text, TB_DOC_RECDATE.Text)
                'mailSEND(Session("CNO"), "", TB_DOC_RECDATE.Text, TB_OWNER.Text)
                Session("DOCTYPE") = "措施說明書"
                Session("MAILTYPE") = "前往審查"
                Session("OWNER") = TB_OWNER.Text
                Session("OWNERID") = Session("UserName")
                Session("AGENT") = CB_AGENT.Value.ToString
                Session("HELPER") = CB_HELPER.Value.ToString
                'Server.Transfer("SetDoc.aspx")

            ElseIf TB_DOCTYPE.Text = "措施說明書變更申請" Then
                UpdateDahsMainMode("措施說明書變更申請", "審查中", Session("CNO"), Session("DOCVERSION"), TB_OWNER.Text, CB_AGENT.Text, CB_HELPER.Text, TB_DOC_RECDATE.Text)
                'mailSEND(Session("CNO"), "", TB_DOC_RECDATE.Text, TB_OWNER.Text)
                Session("DOCTYPE") = "措施說明書變更申請"
                Session("MAILTYPE") = "前往審查"
                Session("OWNER") = TB_OWNER.Text
                Session("OWNERID") = Session("UserName")
                Session("AGENT") = CB_AGENT.Value.ToString
                Session("HELPER") = CB_HELPER.Value.ToString
                'Server.Transfer("PrepareModify.aspx")

            ElseIf TB_DOCTYPE.Text = "確認報告書" Then
                UpdateDahsMainMode("確認報告書", "審查中", Session("CNO"), Session("DOCVERSION"), TB_OWNER.Text, CB_AGENT.Text, CB_HELPER.Text, TB_DOC_RECDATE.Text)
                'mailSEND(Session("CNO"), "", TB_DOC_RECDATE.Text, TB_OWNER.Text)
                Session("DOCTYPE") = "確認報告書"
                Session("MAILTYPE") = "前往審查"
                Session("OWNER") = TB_OWNER.Text
                Session("OWNERID") = Session("UserName")
                Session("AGENT") = CB_AGENT.Value.ToString
                Session("HELPER") = CB_HELPER.Value.ToString
                'Server.Transfer("VryDoc.aspx")

            ElseIf TB_DOCTYPE.Text = "確認報告書變更申請" Then
                UpdateDahsMainMode("確認報告書變更申請", "審查中", Session("CNO"), Session("DOCVERSION"), TB_OWNER.Text, CB_AGENT.Text, CB_HELPER.Text, TB_DOC_RECDATE.Text)
                'mailSEND(Session("CNO"), "", TB_DOC_RECDATE.Text, TB_OWNER.Text)
                Session("DOCTYPE") = "確認報告書變更申請"
                Session("MAILTYPE") = "前往審查"
                Session("OWNER") = TB_OWNER.Text
                Session("OWNERID") = Session("UserName")
                Session("AGENT") = CB_AGENT.Value.ToString
                Session("HELPER") = CB_HELPER.Value.ToString
                'Server.Transfer("PrepareModify.aspx")

            End If


            Server.Transfer("EpbNotifyMessage.aspx")


        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles ASPxButton2.Click

        Server.Transfer("SetAudit.aspx")

    End Sub

    Public Shared Function UpdateDahsMainMode(ByVal strDocType As String, ByVal strExamResult As String, ByVal strCno As String, ByVal strDocVersion As String, ByVal strOWNER As String, ByVal strAGENT As String, ByVal strHELPER As String, ByVal strDOC_RECDATE As String) As String

        Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim commandtext As String = ""

        commandtext = "Update [DAHS_ExamList] set EXAM_RESULT=@EXAM_RESULT,OWNER=@OWNER,AGENT=@AGENT,HELPER=@HELPER,DOC_RECDATE=@DOC_RECDATE  where CNO=@CNO and DOCVERSION=@DOCVERSION and DOCTYPE=@DOCTYPE "
        Try
            Using connection As New SqlConnection(DBconntext)
                Dim command As New SqlCommand(commandtext, connection)
                command.Parameters.Add("@CNO", SqlDbType.Char)
                command.Parameters("@CNO").Value = strCno
                command.Parameters.Add("@DOCVERSION", SqlDbType.Char)
                command.Parameters("@DOCVERSION").Value = strDocVersion
                command.Parameters.Add("@OWNER", SqlDbType.Char)
                command.Parameters("@OWNER").Value = strOWNER
                command.Parameters.Add("@AGENT", SqlDbType.Char)
                command.Parameters("@AGENT").Value = strAGENT
                command.Parameters.Add("@DOCTYPE", SqlDbType.Char)
                command.Parameters("@DOCTYPE").Value = strDocType
                command.Parameters.Add("@HELPER", SqlDbType.Char)
                command.Parameters("@HELPER").Value = strHELPER
                command.Parameters.Add("@DOC_RECDATE", SqlDbType.Char)
                command.Parameters("@DOC_RECDATE").Value = strDOC_RECDATE
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

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click

        Session("MAILTYPE") = "前往審查"


        Try
            Server.Transfer("EpbNotifyMessage.aspx")
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub SqlDataSource1_Selecting(sender As Object, e As SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub

    Public Shared Function ReturnEPBOwner(ByVal MyCno As String) As String

        Dim QueryResult As String = ""
        Dim myid As String = Left(MyCno, 1)

        Select Case myid

            Case "A"
                If Left(MyCno, 1) = "A" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "B"
                If Left(MyCno, 1) = "B" Or Left(MyCno, 1) = "L" Then QueryResult = "EPBB"
            Case "C"
                If Left(MyCno, 1) = "C" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "D"
                If Left(MyCno, 1) = "D" Or Left(MyCno, 1) = "R" Then QueryResult = "EPBD"
            Case "E"
                If Left(MyCno, 1) = "E" Or Left(MyCno, 1) = "S" Then QueryResult = "EPBE"
            Case "F"
                If Left(MyCno, 1) = "F" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "G"
                If Left(MyCno, 1) = "G" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "H"
                If Left(MyCno, 1) = "H" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "I"
                If Left(MyCno, 1) = "I" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "J"
                If Left(MyCno, 1) = "J" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "K"
                If Left(MyCno, 1) = "K" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "L"
                If Left(MyCno, 1) = "L" Or Left(MyCno, 1) = "B" Then QueryResult = "EPBB"
            Case "M"
                If Left(MyCno, 1) = "M" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "N"
                If Left(MyCno, 1) = "N" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "O"
                If Left(MyCno, 1) = "O" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "P"
                If Left(MyCno, 1) = "P" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "Q"
                If Left(MyCno, 1) = "Q" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "R"
                If Left(MyCno, 1) = "R" Or Left(MyCno, 1) = "D" Then QueryResult = "EPBD"
            Case "S"
                If Left(MyCno, 1) = "S" Or Left(MyCno, 1) = "E" Then QueryResult = "EPBE"
            Case "T"
                If Left(MyCno, 1) = "T" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "U"
                If Left(MyCno, 1) = "U" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "V"
                If Left(MyCno, 1) = "V" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "X"
                If Left(MyCno, 1) = "X" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "W"
                If Left(MyCno, 1) = "W" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "Z"
                If Left(MyCno, 1) = "Z" Then QueryResult = "EPB" + Left(MyCno, 1)

        End Select

        Return QueryResult


    End Function

End Class