Imports WSC
Imports GVClass2
Imports System.Data

Partial Class UnlockUser
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
        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "clientScript", GVClass.strScript_Admin)
        'Exit Sub
        'End If
        'End If

        '檢查身份是否通過驗證
        If (Not User.Identity.IsAuthenticated) Then
            '導向Authentication中的loginUrl網址進行驗證
            FormsAuthentication.RedirectToLoginPage()
        End If
    End Sub

    Protected Sub btnUnlockUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUnlockUser.Click
        If (User.Identity.Name.ToUpper() = "ADMIN") Or Left(Session("Comment"), 3).ToUpper = "EPB" Or Left(Session("Comment"), 9).ToUpper = "TOP_ADMIN" Then
            '取得欲解除鎖定的使用者
            Dim currentUser As MembershipUser = Membership.GetUser(txtUserName.Text)
            '解除使用者鎖定狀態
            If (currentUser.UnlockUser()) Then
                Dim myMsg As New AlertMessage()
                myMsg.showMsg(Me.Page, "解除帳號鎖定成功！")
                ShowLockedStatus()
            Else
                Dim myMsg As New AlertMessage()
                myMsg.showMsg(Me.Page, "解除帳號鎖定失敗！")
            End If
        Else
            Dim myMsg As New AlertMessage()
            myMsg.showMsg(Me.Page, "您不是管理人員，無解除鎖定權限！")
        End If
    End Sub

    '顯示使用者被鎖定狀態
    Protected Sub btnShowLockedStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowLockedStatus.Click
        ShowLockedStatus()
    End Sub

    '以GridView顯示使用者帳號鎖定狀態
    Protected Sub ShowLockedStatus()
        Dim dtLockedUsers As New DataTable()
        dtLockedUsers.Columns.Add("UserName", GetType(String))
        dtLockedUsers.Columns.Add("LockedStaus", GetType(Boolean))

        '取得所有使用者
        Dim Users As MembershipUserCollection = Membership.GetAllUsers()
        '一一取出MembershipUserCollection中的使用者判斷狀態
        For Each singleUser As MembershipUser In Users
            Dim singleRow As DataRow = dtLockedUsers.NewRow()
            singleRow("UserName") = singleUser.UserName
            If (singleUser.IsLockedOut) Then
                singleRow("LockedStaus") = True
            Else
                singleRow("LockedStaus") = False
            End If
            dtLockedUsers.Rows.Add(singleRow)
        Next
        '透過GridView顯示DataTable中的資料
        GridView1.DataSource = dtLockedUsers
        GridView1.DataBind()
    End Sub
End Class
