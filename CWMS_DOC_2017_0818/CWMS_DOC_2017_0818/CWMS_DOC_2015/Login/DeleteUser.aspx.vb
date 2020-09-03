Imports WSC
Imports GVClass2

Partial Class DeleteUser
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim i As Integer = 0
        Dim getname As String = Page.User.Identity.Name

        '檢查身份是否通過驗證
        If (Not User.Identity.IsAuthenticated) Then
            '導向Authentication中的loginUrl網址進行驗證
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

    '刪除使用者帳號
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        '確認是否為系統管理者群組之人員才能進行刪除動作
        '在此先以User層級來判別是否有權限刪除,後面談到
        '角色API時,可以改用角色群組來判別是否有權限

        If Left(Session("Comment"), 5).ToUpper = "ADMIN" Or Left(Session("Comment"), 3).ToUpper = "EPB" Or Left(Session("Comment"), 9).ToUpper = "TOP_ADMIN" Then
            If (Membership.DeleteUser(txtUserName.Text)) Then
                txtUserName.Text = ""
                Dim txtMsg As String = "刪除" & txtUserName.Text & "使用者成功!"
                Dim myMsg As New AlertMessage()
                myMsg.showMsg(Me.Page, txtMsg)
            Else
                Dim txtMsg As String = "刪除" & txtUserName.Text & "使用者失敗!"
                Dim myMsg As New AlertMessage()
                myMsg.showMsg(Me.Page, txtMsg)
            End If
        Else
            Dim myMsg As New AlertMessage()
            myMsg.showMsg(Me.Page, "您不是管理人員，無刪除權限！")
        End If


        
    End Sub
End Class
