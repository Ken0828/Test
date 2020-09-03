Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Configuration



Partial Class Login_ChangePass
    Inherits System.Web.UI.Page

    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMS_aspnetdb").ConnectionString.ToString

    Protected Sub ChangePassword1_ChangedPassword(sender As Object, e As EventArgs) Handles ChangePassword1.ChangedPassword

        'update the password change info to changed

        Dim aff_row As Integer
        Dim ActionMode As String = ""
        Dim UpdateSQL As String = "UPDATE [aspnet_Membership] SET PassWordChange=@PassWordChange  from   aspnet_Users a inner join aspnet_Membership b   on  a.userid=b.userid where a.username=@UserName "

        Dim SDS_PlanPolFeature As SqlDataSource = New SqlDataSource
        SDS_PlanPolFeature.ConnectionString = DBconntext

        Try

            With SDS_PlanPolFeature
                .UpdateParameters.Add("UserName", ChangePassword1.UserName)
                .UpdateParameters.Add("PassWordChange", "PasswordChanged")
                .UpdateCommand = UpdateSQL
                aff_row = .Update()
            End With

        Catch ex As System.Data.SqlClient.SqlException
            'ASPxLabel1.Text = "可能有資料重覆輸入..."
        Catch ex As Exception
            'ASPxLabel1.Text = ex.Message.ToString
        End Try


    End Sub
End Class
