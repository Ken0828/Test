Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class RegUserN
    Inherits System.Web.UI.Page

    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMS_aspnetdb").ConnectionString.ToString
    Dim userId As String = ""

    Protected Function GetUserInfo(ByVal strOwner As String) As String



        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader

        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  b.EPB,B.IDTYPE from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where a.username='" + strOwner + "'"
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                GetUserInfo = DatasetOwner.GetString(0)
            End While
        Catch ex As Exception

        End Try

        Return GetUserInfo

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim user As MembershipUser
        Dim strUserName As String = Session("UserName")
        user = Membership.GetUser(strUserName)
        Dim CountyCode As String = Right(user.Comment.ToString, 1)

        If (Not IsPostBack) Then
            If Left(user.Comment.ToString, 5) = "ADMIN" Then

                DDL_EPB.Text = CountyCode
                DropDownList1.Items.Add(New ListItem("環保局人員", "EPB"))
                DropDownList1.Items.Add(New ListItem("事業/工業區", "EPC"))
                DropDownList1.Items.Add(New ListItem("協審單位", "EPB_HELPER"))

            ElseIf Left(user.Comment.ToString, 4) = "ESTC" Or Left(user.Comment.ToString, 9) = "TOP_ADMIN" Then

                DDL_EPB.Enabled = True
                DropDownList1.Items.Add(New ListItem("環保局人員", "EPB"))
                DropDownList1.Items.Add(New ListItem("事業/工業區", "EPC"))
                DropDownList1.Items.Add(New ListItem("協審單位", "EPB_HELPER"))
                DropDownList1.Items.Add(New ListItem("稽查大隊", "DIG"))
                DropDownList1.Items.Add(New ListItem("管理帳號", "ADMIN"))

            ElseIf Left(user.Comment.ToString, 3) = "EPB" Then

                DDL_EPB.Text = CountyCode
                DropDownList1.Items.Add(New ListItem("事業/工業區", "EPC"))
                DropDownList1.Items.Add(New ListItem("協審單位", "EPB_HELPER"))

            Else
                Exit Sub

            End If

        End If

        txtQuestion.Text = "123"
        txtAnswer.Text = "123"


    End Sub

    Protected Sub btnCreateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateUser.Click
        Dim CreateStatus As MembershipCreateStatus
        Dim sComment As String = DropDownList1.SelectedValue.ToString
        Dim strScript As String = "<script language=JavaScript> alert(""需填入有效的管制編號共8碼""); </script>"
        Dim strEmailScript As String = "<script language=JavaScript> alert(""需填入有效的電子郵件信箱""); </script>"
        Dim strTeleScript As String = "<script language=JavaScript> alert(""需填入連絡電話""); </script>"
        Dim strIDScript As String = "<script language=JavaScript> alert(""需填入帳號""); </script>"

        If DropDownList1.SelectedValue.ToString = "EPC" Then
            If txtUserName.Text.Length <> 8 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
                Exit Sub
            ElseIf txtMail.Text.Length = 0 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strEmailScript)
                Exit Sub
            ElseIf txtContactPhone.Text.Length = 0 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strTeleScript)
                Exit Sub
            End If

        Else
            If txtMail.Text.Length = 0 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strEmailScript)
                Exit Sub
            ElseIf txtContactPhone.Text.Length = 0 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strTeleScript)
                Exit Sub
            ElseIf txtUserName.Text.Length = 0 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strIDScript)
                Exit Sub

            End If

        End If

        Try
            Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtMail.Text, txtQuestion.Text, txtAnswer.Text, True, CreateStatus)

            If (CreateStatus = MembershipCreateStatus.Success) Then

                Dim user As MembershipUser
                Dim strIdtype As String = ""
                Dim strPassWordChange As String = "MustChangePassword"

                user = Membership.GetUser(txtUserName.Text)
                If sComment = "EPC" Then
                    user.Comment = txtUserName.Text
                    strIdtype = txtUserName.Text

                ElseIf sComment = "EPB_HELPER" Then
                    user.Comment = "EPB" + DDL_EPB.SelectedValue.ToString + "_HELPER"
                    strIdtype = "EPB" + DDL_EPB.SelectedValue.ToString + "_HELPER"
                ElseIf sComment = "ADMIN" Then
                    user.Comment = "ADMIN_" + DDL_EPB.SelectedValue.ToString
                    strIdtype = "ADMIN_" + DDL_EPB.SelectedValue.ToString
                Else
                    user.Comment = "EPB" + DDL_EPB.SelectedValue.ToString
                    strIdtype = "EPB" + DDL_EPB.SelectedValue.ToString
                End If

                Membership.UpdateUser(user)

                userId = user.ProviderUserKey.ToString

                Dim aff_row As Integer
                Dim ActionMode As String = ""
                Dim UpdateSQL As String = "UPDATE [aspnet_Membership] SET PassWordChange=@PassWordChange,Name=@Name,ContactPhone=@ContactPhone,EPB=@EPB,IdType=@IdType WHERE UserId=@UserId "

                Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
                SDS_PlanPolFeature.ConnectionString = DBconntext

                Try

                    With SDS_PlanPolFeature
                        .UpdateParameters.Add("UserId", userId)
                        .UpdateParameters.Add("Name", txtName.Text)
                        .UpdateParameters.Add("ContactPhone", txtContactPhone.Text)
                        .UpdateParameters.Add("EPB", "EPB" + DDL_EPB.SelectedValue.ToString)
                        .UpdateParameters.Add("IdType", strIdtype)
                        .UpdateParameters.Add("PassWordChange", strPassWordChange)
                        .UpdateCommand = UpdateSQL
                        aff_row = .Update()
                    End With

                Catch ex As System.Data.SqlClient.SqlException
                    'ASPxLabel1.Text = "可能有資料重覆輸入..."
                Catch ex As Exception
                    'ASPxLabel1.Text = ex.Message.ToString
                End Try

                ClearText()
            End If
        Catch ex As Exception

        End Try


        '顯示帳號建立成功或失敗訊息
        Dim myMsg As New AlertMessage()
        myMsg.showMsg(Me.Page, CreateStatus.ToString())
    End Sub

    '清除TextBox內容
    Protected Sub ClearText()
        Me.txtUserName.Text = ""
        Me.txtPassword.Text = ""
        Me.txtMail.Text = ""
        Me.txtName.Text = ""
        Me.txtContactPhone.Text = ""
    End Sub

End Class