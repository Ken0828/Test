Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO

Partial Class UpdateUser
    Inherits System.Web.UI.Page
    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMS_aspnetdb").ConnectionString.ToString

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DropDownList2.Items.Clear()
        '檢查是否身份通過驗證
        If (User.Identity.IsAuthenticated) Then
            '顯示使用者資料
            Dim singleUser As MembershipUser = Membership.GetUser()
            ShowUserInfo(singleUser)
            Dim CountyCode As String = Right(singleUser.Comment.ToString, 1)
            If Left(singleUser.Comment.ToString, 5) = "ADMIN" Then

                DDL_EPB.Text = CountyCode
                DropDownList2.Items.Add(New ListItem("環保局人員", "EPB"))
                DropDownList2.Items.Add(New ListItem("事業/工業區", "EPC"))
                DropDownList2.Items.Add(New ListItem("協審單位", "EPB_HELPER"))

            ElseIf Left(singleUser.Comment.ToString, 4) = "ESTC" Or Left(singleUser.Comment.ToString, 9) = "TOP_ADMIN" Then

                DDL_EPB.Enabled = True
                DropDownList2.Items.Add(New ListItem("環保局人員", "EPB"))
                DropDownList2.Items.Add(New ListItem("事業/工業區", "EPC"))
                DropDownList2.Items.Add(New ListItem("協審單位", "EPB_HELPER"))
                DropDownList2.Items.Add(New ListItem("稽查大隊", "DIG"))
                DropDownList2.Items.Add(New ListItem("管理帳號", "ADMIN"))
                If Left(singleUser.Comment.ToString, 9) = "TOP_ADMIN" Then
                    lbl_Comment.Visible = True
                    txtUserComment.Visible = True
                End If
            ElseIf Left(singleUser.Comment.ToString, 3) = "EPB" Then

                DDL_EPB.Text = CountyCode
                DropDownList2.Items.Add(New ListItem("環保局人員", "EPB"))
                DropDownList2.Items.Add(New ListItem("事業/工業區", "EPC"))
                DropDownList2.Items.Add(New ListItem("協審單位", "EPB_HELPER"))

            Else
                Exit Sub

            End If

        Else
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

    '更新使用者資料
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        '取得登入的使用者 

        Dim strIdtype As String
        If DropDownList2.SelectedValue = "EPC" Then
            strIdtype = txtUserName.Text
        ElseIf DropDownList2.SelectedValue = "EPB_HELPER" Then
            strIdtype = "EPB" + DDL_EPB.SelectedValue.ToString + "_HELPER"
        ElseIf DropDownList2.SelectedValue = "ADMIN" Then
            strIdtype = "ADMIN_" + DDL_EPB.SelectedValue.ToString
        Else
            strIdtype = "EPB" + DDL_EPB.SelectedValue.ToString
        End If

        Dim singleUser As MembershipUser = Membership.GetUser(txtUserAccount.Text)

        Dim userId As String = singleUser.ProviderUserKey.ToString
        Dim UpdateSQL As String
        If txtUserComment.Visible Then
            UpdateSQL = "UPDATE [aspnet_Membership] SET Name=@Name,Email=@Email,ContactPhone=@ContactPhone,IdType=@IdType,Comment=@Comment WHERE UserId=@UserId "
        Else
            UpdateSQL = "UPDATE [aspnet_Membership] SET Name=@Name,Email=@Email,ContactPhone=@ContactPhone,IdType=@IdType WHERE UserId=@UserId "
        End If

        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext
        Dim aff_row As Integer

        Try
            With SDS_PlanPolFeature
                .UpdateParameters.Add("UserId", userId)
                .UpdateParameters.Add("Name", txtUserName.Text)
                .UpdateParameters.Add("ContactPhone", txtContactPhone.Text)
                .UpdateParameters.Add("IdType", strIdtype)
                .UpdateParameters.Add("Email", txtUserMail.Text)
                If txtUserComment.Visible Then
                    .UpdateParameters.Add("Comment", txtUserComment.Text)
                End If
                .UpdateCommand = UpdateSQL
                aff_row = .Update()
            End With

        Catch ex As System.Data.SqlClient.SqlException
            'ASPxLabel1.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            'ASPxLabel1.Text = ex.Message.ToString
        End Try

        If txtUserOldPassword.Text <> "" And txtUserNewPassword.Text <> "" Then
            singleUser.ChangePassword(txtUserOldPassword.Text, txtUserNewPassword.Text)
            txtUserOldPassword.Text = ""
            txtUserNewPassword.Text = ""
        End If

    End Sub

    Protected Sub btn_SearchAccount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_SearchAccount.Click
        txtUserOldPassword.Text = ""
        txtUserNewPassword.Text = ""

        Dim strUserName As String = Session("UserName")
        Dim LoginUser As MembershipUser = Membership.GetUser(strUserName)
        Dim CountyCode As String = Right(LoginUser.Comment.ToString, 1)
        Dim singleUser As MembershipUser
        Try
            txtUserName.Text = "查無此號"
            txtContactPhone.Text = ""
            txtUserMail.Text = ""
            btnUpdate.Enabled = False

            singleUser = Membership.GetUser(txtUserAccount.Text)


            Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString

            Dim strSQL As String
            System.Diagnostics.Debug.WriteLine(singleUser.Comment.ToString)
            If LoginUser.Comment.ToString.Trim() = "TOP_ADMIN" Then
                strSQL = "SELECT * FROM [aspnet_Membership] where UserId = '" & singleUser.ProviderUserKey.ToString & "' "
                DDL_EPB.Enabled = True
            Else
                strSQL = "SELECT * FROM [aspnet_Membership] where UserId = '" & singleUser.ProviderUserKey.ToString & "' and EPB = 'EPB" & CountyCode & "'"
                DDL_EPB.Enabled = False

            End If
            System.Diagnostics.Debug.WriteLine(strSQL)
            Dim Conn As New SqlConnection(CEMSDBHOST1)
            Conn.Open()
            Dim Cmmd As New SqlCommand(strSQL, Conn)
            Cmmd.ExecuteNonQuery()
            Dim rdr As SqlDataReader = Cmmd.ExecuteReader()
            While rdr.Read()



                txtUserName.Text = rdr("Name").toString
                txtUserComment.Text = rdr("Comment").toString
                txtContactPhone.Text = rdr("ContactPhone").toString
                txtUserMail.Text = rdr("Email").toString
                For i As Integer = 0 To DDL_EPB.Items.Count - 1
                    If Right(rdr("EPB").toString, 1) = DDL_EPB.Items(i).Value Then
                        DDL_EPB.SelectedIndex = i
                        Exit For
                    End If
                Next

                Dim IdType As String
                If Left(rdr("IdType").toString, 3) = "EPB" And rdr("IdType").toString.Length = 4 Then
                    '各環保局承辦 
                    IdType = "環保局人員"
                ElseIf Left(rdr("IdType").toString, 5) = "ADMIN" Then
                    '各縣市管理者 
                    IdType = "管理帳號"
                ElseIf Right(rdr("IdType").toString, 6) = "HELPER" Then
                    IdType = "協審單位"
                ElseIf rdr("IdType").toString.Length = 8 Then
                    IdType = "事業/工業區"
                End If


                For i As Integer = 0 To DropDownList2.Items.Count - 1
                    System.Diagnostics.Debug.Write(DropDownList2.Items(i).Text)
                    If IdType = DropDownList2.Items(i).Text Then
                        DropDownList2.SelectedIndex = i
                        Exit For
                    End If
                Next
            End While


            Conn.close()
            rdr.close()
            btnUpdate.Enabled = True
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try

        '取得登入的使用者 
        'txtUserName.Text = singleUser.UserName
        'txtContactPhone.Text = singleUser.ProviderUserKey("ContactPhone")
        'txtUserMail.Text = singleUser.Email
    End Sub
    '顯示使用者詳細資訊
    Protected Sub ShowUserInfo(ByVal singleUser As MembershipUser)
        txtResult.Text = ""
        If (Not singleUser.UserName = Nothing) Then
            txtResult.Text += "使用者帳號:" & singleUser.UserName & "<BR>"
            txtResult.Text += "電子郵件信箱:" & singleUser.Email & "<BR>"
            txtResult.Text += "Comment:" & singleUser.Comment & "<BR>"
        End If
    End Sub
End Class
