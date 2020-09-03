Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO
Imports DevExpress.Web

Public Class CaseTransfer
    Inherits System.Web.UI.Page

    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString

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
                Session("HELPER") = DatasetOwner.GetString(5) + "_HELPER"
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


        Session("UserCName") = GetOwnerName(Session("UserName"))

    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        'show select info to change owner
        Dim strCNO = GridView1.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GridView1.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GridView1.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GridView1.GetSelectedFieldValues("REG_DATE")
        'Dim strOwner = GridView1.GetSelectedFieldValues("OWNER")
        Dim strOwner = ""


        Dim getresult As DbResult

        Dim Sqlstr As String = "Select * from DAHS_EXAMLIST where cno='" + strCNO(0).ToString + "'  and DocVersion='" + strDOCVERSION(0).ToString + "' and DOCTYPE='" + strDOCTYPE(0).ToString + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                'RBL_SPEC_DPNO.Value = getresult.returnDataTable.Rows(0).Item("DPTYPE").ToString
                tb_Owner_orig.Text = getresult.returnDataTable.Rows(0).Item("OWNER").ToString
                tb_Agent_orig.Text = getresult.returnDataTable.Rows(0).Item("AGENT").ToString
                tb_Helper_orig.Text = getresult.returnDataTable.Rows(0).Item("HELPER").ToString



            End If

        Catch ex As Exception


        End Try

        'ASPxLabel1.Text = "管制編號:" + strCNO(0).ToString + "文件種類:" + strDOCTYPE(0).ToString + "版號:" + strDOCVERSION(0).ToString + "承辦人員:" + strOwner(0).ToString
        ASPxLabel1.Text = "管制編號:" + strCNO(0).ToString + "文件種類:" + strDOCTYPE(0).ToString + "版號:" + strDOCVERSION(0).ToString


    End Sub

    Protected Sub GridView1_FocusedRowChanged(sender As Object, e As EventArgs) Handles GridView1.FocusedRowChanged


        Dim strCNO = GridView1.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GridView1.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GridView1.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GridView1.GetSelectedFieldValues("REG_DATE")

        If strCNO.Count = 0 Then
            Exit Sub
        End If

        Session("CNO") = strCNO(0).ToString
        Session("DOCTYPE") = strDOCTYPE(0).ToString
        Session("DOCVERSION") = strDOCVERSION(0).ToString
        Session("DOCREGDATE") = strDOCREGDATE(0).ToString


    End Sub

    Protected Sub GridView1_SelectionChanged(sender As Object, e As EventArgs) Handles GridView1.SelectionChanged


        Dim strCNO = GridView1.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GridView1.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GridView1.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GridView1.GetSelectedFieldValues("REG_DATE")


        If strCNO.Count = 0 Then
            Exit Sub
        End If

        Session("CNO") = strCNO(0).ToString
        Session("DOCTYPE") = strDOCTYPE(0).ToString
        Session("DOCVERSION") = strDOCVERSION(0).ToString
        Session("DOCREGDATE") = strDOCREGDATE(0).ToString



    End Sub

    Protected Sub ASPxButton2_Click(sender As Object, e As EventArgs) Handles bt_owner.Click

        Dim strCNO = GridView1.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GridView1.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GridView1.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GridView1.GetSelectedFieldValues("REG_DATE")


        Dim aff_row As Integer
        Dim ActionMode As String = ""

        Dim UpdateSQL As String = "UPDATE [DAHS_EXAMLIST] SET [OWNER] = @OWNER WHERE CNO=@CNO AND DOCVERSION=@DOCVERSION AND DOCTYPE=@DOCTYPE "

        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Try

            With SDS_PlanPolFeature

                .UpdateParameters.Add("CNo", strCNO(0).ToString)
                .UpdateParameters.Add("DocVersion", strDOCVERSION(0).ToString)
                .UpdateParameters.Add("DOCTYPE", strDOCTYPE(0).ToString)
                .UpdateParameters.Add("OWNER", CB_NewOwner.Text.ToString.Trim)
                .UpdateCommand = UpdateSQL

                aff_row = .Update()

                If aff_row = 0 Then
                    Label_Owner.Text = "資料更新失敗!"
                Else
                    Label_Owner.Text = "承辦人已更新為:" + CB_NewOwner.Text.ToString
                End If

            End With

        Catch ex As System.Data.SqlClient.SqlException
            Label_Owner.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            Label_Owner.Text = ex.Message.ToString
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

    Protected Sub ASPxButton3_Click(sender As Object, e As EventArgs) Handles ASPxButton3.Click


        Session("MAILTYPE") = "更換審查承辦"


        Try
            Server.Transfer("EpbNotifyMessage.aspx")
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub bt_Agent_Click(sender As Object, e As EventArgs) Handles bt_Agent.Click

        Dim strCNO = GridView1.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GridView1.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GridView1.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GridView1.GetSelectedFieldValues("REG_DATE")


        Dim aff_row As Integer
        Dim ActionMode As String = ""

        Dim UpdateSQL As String = "UPDATE [DAHS_EXAMLIST] SET [AGENT] = @AGENT WHERE CNO=@CNO AND DOCVERSION=@DOCVERSION AND DOCTYPE=@DOCTYPE "

        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Try

            With SDS_PlanPolFeature

                .UpdateParameters.Add("CNo", strCNO(0).ToString)
                .UpdateParameters.Add("DocVersion", strDOCVERSION(0).ToString)
                .UpdateParameters.Add("DOCTYPE", strDOCTYPE(0).ToString)
                .UpdateParameters.Add("AGENT", CB_NewAgent.Text.ToString.Trim)
                .UpdateCommand = UpdateSQL

                aff_row = .Update()

                If aff_row = 0 Then
                    Label_Agent.Text = "資料更新失敗!"
                Else
                    Label_Agent.Text = "代理人已更新為:" + CB_NewAgent.Text.ToString
                End If

            End With

        Catch ex As System.Data.SqlClient.SqlException
            Label_Agent.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            Label_Agent.Text = ex.Message.ToString
        End Try


    End Sub

    Protected Sub bt_helper_Click(sender As Object, e As EventArgs) Handles bt_helper.Click


        Dim strCNO = GridView1.GetSelectedFieldValues("CNO")
        Dim strDOCVERSION = GridView1.GetSelectedFieldValues("DOCVERSION")
        Dim strDOCTYPE = GridView1.GetSelectedFieldValues("DOCTYPE")
        Dim strDOCREGDATE = GridView1.GetSelectedFieldValues("REG_DATE")


        Dim aff_row As Integer
        Dim ActionMode As String = ""

        Dim UpdateSQL As String = "UPDATE [DAHS_EXAMLIST] SET [HELPER] = @HELPER WHERE CNO=@CNO AND DOCVERSION=@DOCVERSION AND DOCTYPE=@DOCTYPE "

        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Try

            With SDS_PlanPolFeature

                .UpdateParameters.Add("CNo", strCNO(0).ToString)
                .UpdateParameters.Add("DocVersion", strDOCVERSION(0).ToString)
                .UpdateParameters.Add("DOCTYPE", strDOCTYPE(0).ToString)
                .UpdateParameters.Add("HELPER", CB_NewHelper.Text.ToString.Trim)
                .UpdateCommand = UpdateSQL

                aff_row = .Update()

                If aff_row = 0 Then
                    Label_Helper.Text = "資料更新失敗!"
                Else
                    Label_Helper.Text = "協審人員已更新為:" + CB_NewHelper.Text.ToString
                End If

            End With

        Catch ex As System.Data.SqlClient.SqlException
            Label_Helper.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            Label_Helper.Text = ex.Message.ToString
        End Try
    End Sub
End Class