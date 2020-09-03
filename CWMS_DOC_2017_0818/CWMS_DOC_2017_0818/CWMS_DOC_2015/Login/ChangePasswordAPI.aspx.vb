
Partial Class ChangePasswordAPI
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim i As Integer = 0
        Dim getname As String = Page.User.Identity.Name

        'If Not Roles.RoleExists("Administrators") Then
        'Roles.CreateRole("Administrators")
        'End If

        'If getname.ToUpper <> "ADMIN" Then
        'For Each u As String In Roles.GetUsersInRole("Administrators")
        'i = i + 1
        'Next
        'If i > 0 Then

        '檢查身份是否通過驗證
        'If (Not User.Identity.IsAuthenticated) Then
        '導向Authentication中的loginUrl網址進行驗證
        'FormsAuthentication.RedirectToLoginPage()
        'End If

        'End If
        'End If
    End Sub

    '變更使用者密碼
    Protected Sub btnChangePwd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePwd.Click
        '取得目前使用者
        Dim currentUser As MembershipUser = Membership.GetUser(User.Identity.Name)
        Try
            'User Guest can't change password
            If currentUser.UserName.ToUpper = "GUEST" Then
                Dim myMsg As New AlertMessage()
                myMsg.showMsg(Me.Page, "Guest can not change password！")
                '檢查使用者身份 & 新密碼是否一致
            ElseIf (currentUser IsNot Nothing And txtNewPwd1.Text = txtNewPwd2.Text) Then
                '改變使用者密碼
                If (currentUser.ChangePassword(txtOldPwd.Text, txtNewPwd1.Text)) Then
                    Dim myMsg As New AlertMessage()
                    myMsg.showMsg(Me.Page, "變更密碼成功！")
                Else
                    Dim myMsg As New AlertMessage()
                    myMsg.showMsg(Me.Page, "變更密碼失敗！")
                End If
            Else
                Dim myMsg As New AlertMessage()
                myMsg.showMsg(Me.Page, "新輸入的密碼不一致！")
            End If
        Catch ex As Exception
            '顯示錯誤訊息
            Response.Write(Server.HtmlEncode(ex.Message))
        End Try
    End Sub

    '登出
    Protected Sub btnSignout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignout.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class
