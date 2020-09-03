Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Public Class RegUserN
    Inherits System.Web.UI.Page

    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMS_aspnetdb").ConnectionString.ToString
    Dim userId As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnCreateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateUser.Click
        Dim CreateStatus As MembershipCreateStatus
        Dim sComment As String = DropDownList1.SelectedValue.ToString
        Dim strScript As String = "<script language=JavaScript> alert(""需填入有效的管制編號共8碼""); </script>"


        If sComment = "EPC" Then

            If txtUserName.Text.Length <> 8 Then

                ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", strScript)
                Exit Sub
            End If

        End If


        Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtMail.Text, txtQuestion.Text, txtAnswer.Text, True, CreateStatus)

        If (CreateStatus = MembershipCreateStatus.Success) Then

            'If txtUserName.Text.ToUpper = "ADMIN" Then

            '    If Not Roles.IsUserInRole("Admin", "Administrators") Then
            '        Roles.AddUserToRole("Admin", "Administrators")
            '    End If
            'End If

            Dim user As MembershipUser


            user = Membership.GetUser(txtUserName.Text)
            If sComment = "EPC" Then
                user.Comment = txtUserName.Text
            ElseIf sComment = "EPB_HELPER" Then
                user.Comment = "EPB" + DDL_EPB.SelectedValue.ToString + "_HELPER"
            Else
                user.Comment = "EPB" + DDL_EPB.SelectedValue.ToString
            End If

            Membership.UpdateUser(user)

            userId = user.ProviderUserKey.ToString

            Dim aff_row As Integer
            Dim ActionMode As String = ""

            Dim UpdateSQL As String = "UPDATE [aspnet_Membership] SET Name=@Name,ContactPhone=@ContactPhone,AdminId=@AdminId,EPB=@EPB WHERE UserId=@UserId "

            Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
            SDS_PlanPolFeature.ConnectionString = DBconntext

            Try

                With SDS_PlanPolFeature
                    .UpdateParameters.Add("UserId", userId)
                    .UpdateParameters.Add("Name", txtName.Text)
                    .UpdateParameters.Add("ContactPhone", txtPhone.Text)
                    .UpdateParameters.Add("AdminId", txtAdminId.Text)
                    .UpdateParameters.Add("EPB", "EPB" + DDL_EPB.SelectedValue.ToString)
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

        '顯示帳號建立成功或失敗訊息
        Dim myMsg As New AlertMessage()
        myMsg.showMsg(Me.Page, CreateStatus.ToString())
    End Sub

    '清除TextBox內容
    Protected Sub ClearText()
        Me.txtUserName.Text = ""
        Me.txtPassword.Text = ""
        Me.txtMail.Text = ""
        Me.txtQuestion.Text = ""
        Me.txtAnswer.Text = ""
        Me.txtAdminId.Text = ""
        Me.txtName.Text = ""
        Me.txtPhone.Text = ""
    End Sub

End Class