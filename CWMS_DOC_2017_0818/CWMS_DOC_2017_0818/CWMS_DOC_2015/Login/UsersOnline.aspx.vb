Imports WSC
Imports GVClass2

Partial Class UsersOnline
    Inherits System.Web.UI.Page

    Dim pageSize As Integer = 5 '一頁顯示五筆資料
    Dim totalUsers As Integer   '全部使用者數
    Dim totalPages As Integer   '總分頁數
    Dim currentPage As Integer = 1 '目前所在分頁

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

        Response.Write("<Font Color='Blue'>使用者Online時間為最近" & Membership.UserIsOnlineTimeWindow & "分鐘內</Font>")
        If Not IsPostBack Then
            GetUsers()
        End If
    End Sub


    '統計目前在線上的使用者
    Protected Sub GetUsers()
        txtUsersOnline.Text = Membership.GetNumberOfUsersOnline().ToString()

        UserGrid.DataSource = Membership.GetAllUsers(currentPage - 1, pageSize, totalUsers)
        totalPages = ((totalUsers - 1) \ pageSize) + 1

        ' Ensure that we do not navigate past the last page of users.

        If currentPage > totalPages Then
            currentPage = totalPages
            GetUsers()
            Return
        End If

        UserGrid.DataBind()
        txtCurrentPage.Text = currentPage.ToString()
        txtTotalPages.Text = totalPages.ToString()

        If currentPage = totalPages Then
            NextButton.Visible = False
        Else
            NextButton.Visible = True
        End If

        If currentPage = 1 Then
            PreviousButton.Visible = False
        Else
            PreviousButton.Visible = True
        End If

        If totalUsers <= 0 Then
            NavigationPanel.Visible = False
        Else
            NavigationPanel.Visible = True
        End If
    End Sub

    Protected Sub gvOnlineUsers_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles UserGrid.RowDataBound

        Dim i As Integer
        For i = 0 To UserGrid.Columns.Count - 1
            UserGrid.Columns(i).ItemStyle.Width = 50
        Next

    End Sub


    '檢查分頁按鈕狀態
    Protected Sub CheckNavigation()
        If (currentPage <= 0) Then
            PreviousButton.Visible = False
            Return
        Else
            PreviousButton.Visible = True
        End If

        If (currentPage >= totalPages) Then
            NextButton.Visible = False
            Return
        Else
            NextButton.Visible = True
        End If
    End Sub


    '上一頁
    Protected Sub PreviousButton_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles PreviousButton.Click
        currentPage = Convert.ToInt32(txtCurrentPage.Text)
        currentPage -= 1
        GetUsers()
    End Sub

    '下一頁
    Protected Sub NextButton_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles NextButton.Click
        currentPage = Convert.ToInt32(txtCurrentPage.Text)
        currentPage += 1
        GetUsers()
    End Sub
End Class
