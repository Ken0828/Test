Imports System.Data.SqlClient
Imports System.Web.Configuration

Partial Class Login_Login
    Inherits System.Web.UI.Page



    Protected Sub Login1_LoggedIn(sender As Object, e As EventArgs) Handles Login1.LoggedIn


        Dim User As MembershipUser = Membership.GetUser(Login1.UserName)
        Dim strUserName As String = Login1.UserName
        Dim strComment As String = User.Comment
        Dim strEmail As String = User.Email
        Dim strPasswordStatus As String = GetUserInfo(Login1.UserName)

        If strPasswordStatus = "MustChangePassword" Then

            Response.Redirect("~/Login/ChangePass.aspx")
            Response.End()
            Exit Sub

        Else
            Session("UserName") = Server.HtmlEncode(Trim(strUserName))
            Session("Comment") = Server.HtmlEncode(Trim(strComment))
            Session("CNO") = Server.HtmlEncode(Trim(strComment))
            Session("EPB") = Server.HtmlEncode(Trim(strComment))

            If Left(strComment, 3) = "EPB" Or Left(strComment, 5) = "ADMIN" Then
                'Server.Transfer("../SetAudit.aspx")
                Response.Redirect("../SetAudit.aspx")
                Response.End()
            ElseIf strComment = "EPA" Then
                Response.Redirect("../QueryCasePhase2.aspx")
                Response.End()
            ElseIf strComment = "TOP_ADMIN" Then
                Response.Redirect("../QueryCasePhase2.aspx")
                Response.End()
            Else
                'Server.Transfer("../MainList.aspx")
                Response.Redirect("../MainList.aspx")
                Response.End()
                'Server.Transfer("../SetDoc.aspx")
            End If

        End If

    End Sub

    Private Sub Login_Login_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim Status As String = Request.QueryString("lout")

        If Status <> "" Then
            Session("UserName") = Nothing
            Session.RemoveAll()
        End If


    End Sub


    Protected Function GetUserInfo(ByVal strOwner As String) As String


        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand
        Dim DatasetOwner As SqlDataReader

        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "SELECT  b.PassWordChange from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where a.username='" + strOwner + "'"
            DatasetOwner = mycommand.ExecuteReader

            While DatasetOwner.Read
                GetUserInfo = DatasetOwner.GetString(0)
            End While
        Catch ex As Exception

        End Try

        Return GetUserInfo

    End Function
End Class
