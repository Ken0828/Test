Imports WSC
Imports GVClass2
Imports System.Data

Partial Class UserApproved
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

        If (Not IsPostBack) Then
            getUsers()
            ShowApproved()
        End If
    End Sub

    '顯示帳號是否可以進行驗證狀態
    Protected Sub btnShowApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShowApproved.Click
        ShowApproved()
    End Sub

    '顯示使用者名稱之DropDownList控制項選項變更時的事件
    Protected Sub dwnUserName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dwnUserName.SelectedIndexChanged
        '預設的請選擇使用者項目
        If (dwnUserName.SelectedIndex = 0) Then
            'CheckBox不作用
            cbxIsApproved.Checked = False
            cbxIsApproved.Enabled = False
        Else
            '設定被選擇使用者其IsApproved狀態
            cbxIsApproved.Enabled = True
            Dim singleUser As MembershipUser = Membership.GetUser(dwnUserName.SelectedItem.ToString())
            cbxIsApproved.Checked = IIf(singleUser.IsApproved = True, True, False)
        End If
    End Sub

    '變更儲存Approved狀態
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Not dwnUserName.SelectedIndex = 0) Then
            Dim singleUser As MembershipUser = Membership.GetUser(dwnUserName.SelectedItem.ToString())
            singleUser.IsApproved = cbxIsApproved.Checked
            Membership.UpdateUser(singleUser) '更新Membership資料
        End If
    End Sub

    '將使用者讀進DropDownList
    Protected Sub getUsers()
        '請選擇使用者
        dwnUserName.Items.Add("請選擇使用者")
        cbxIsApproved.Checked = False
        cbxIsApproved.Enabled = False
        '取得所有使用者的集合
        Dim Users As MembershipUserCollection = Membership.GetAllUsers()
        '將使用者的集合中的使用者姓名加入DropDownList
        For Each singleUser As MembershipUser In Users
            dwnUserName.Items.Add(singleUser.UserName)
        Next
    End Sub

    '顯示帳號是否可以進行驗證狀態
    Protected Sub ShowApproved()
        Dim dtApproved As New DataTable()
        dtApproved.Columns.Add("UserName", GetType(String))
        dtApproved.Columns.Add("IsApproved", GetType(Boolean))

        '取出Membership中所有使用者
        Dim Users As MembershipUserCollection = Membership.GetAllUsers()

        For Each singleUser As MembershipUser In Users
            Dim singleRow As DataRow = dtApproved.NewRow()
            singleRow("UserName") = singleUser.UserName
            singleRow("IsApproved") = IIf(singleUser.IsApproved = True, True, False)
            dtApproved.Rows.Add(singleRow)
        Next
        GridView1.DataSource = dtApproved
        GridView1.DataBind()
    End Sub
End Class
