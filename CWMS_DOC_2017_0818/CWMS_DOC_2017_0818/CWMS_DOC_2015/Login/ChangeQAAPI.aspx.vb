
Partial Class ChangeQAAPI
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '檢查身份是否通過驗證
        If (Not User.Identity.IsAuthenticated) Then
            '導向Authentication中的loginUrl網址進行驗證
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

    '變更安全性問題與回答
    Protected Sub btnChangeQA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangeQA.Click
        '取得目前使用者
        Dim currentUser As MembershipUser = Membership.GetUser(User.Identity.Name)
        Try
            If (currentUser IsNot Nothing And currentUser.ChangePasswordQuestionAndAnswer(txtPassword.Text, txtQuestion.Text, txtPassword.Text)) Then
                Dim myMsg As New AlertMessage()
                myMsg.showMsg(Me.Page, "變更安全性問題與回答成功！")
            Else
                Dim myMsg As New AlertMessage()
                myMsg.showMsg(Me.Page, "變更安全性問題與回答失敗！")
            End If
        Catch ex As Exception
            Dim myMsg As New AlertMessage()
            myMsg.showMsg(Me.Page, Server.HtmlEncode(ex.Message))
        End Try
    End Sub

    '登出
    Protected Sub btnSignout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSignout.Click
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class
