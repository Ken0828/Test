
Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration

Public Class CopyTestData
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If
    End Sub

    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click


        Dim CEMSDBHOST1 As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
        Dim conn As SqlConnection = New SqlConnection(CEMSDBHOST1)
        Dim mycommand As New SqlCommand


        Try
            conn.Open()
            mycommand.Connection = conn
            mycommand.CommandText = "delete from  doc_set_factory_temp "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into doc_set_factory_temp select * from  doc_set_factory where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  doc_set_factory_temp set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into doc_set_factory select * from  doc_set_factory_temp "
            mycommand.ExecuteNonQuery()

            mycommand.CommandText = "delete from  DOC_SET_VerifyDocSet_TEMP "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_VerifyDocSet_TEMP select * from  DOC_SET_VerifyDocSet where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  DOC_SET_VerifyDocSet_TEMP set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_VerifyDocSet select * from  DOC_SET_VerifyDocSet_TEMP "
            mycommand.ExecuteNonQuery()


            mycommand.CommandText = "delete from  DOC_SET_SPEC_TEMP "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_SPEC_TEMP select * from  DOC_SET_SPEC where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  DOC_SET_SPEC_TEMP set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_SPEC select * from  DOC_SET_SPEC_TEMP "
            mycommand.ExecuteNonQuery()



            mycommand.CommandText = "delete from  DOC_SET_MAPPING_TEMP "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_MAPPING_TEMP select * from  DOC_SET_MAPPING where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  DOC_SET_MAPPING_TEMP set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_MAPPING select * from  DOC_SET_MAPPING_TEMP "
            mycommand.ExecuteNonQuery()



            mycommand.CommandText = "delete from  DOC_SET_LP_TEMP "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_LP_TEMP select * from  DOC_SET_LP where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  DOC_SET_LP_TEMP set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_LP select * from  DOC_SET_LP_TEMP "
            mycommand.ExecuteNonQuery()



            mycommand.CommandText = "delete from  DOC_SET_LINK_TEMP "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_LINK_TEMP select * from  DOC_SET_LINK where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  DOC_SET_LINK_TEMP set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_LINK select * from  DOC_SET_LINK_TEMP "
            mycommand.ExecuteNonQuery()


            mycommand.CommandText = "delete from  DOC_SET_LED_TEMP "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_LED_TEMP select * from  DOC_SET_LED where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  DOC_SET_LED_TEMP set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_LED select * from  DOC_SET_LED_TEMP "
            mycommand.ExecuteNonQuery()


            mycommand.CommandText = "delete from  DOC_SET_ITEM_TEMP "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_ITEM_TEMP select * from  DOC_SET_ITEM where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  DOC_SET_ITEM_TEMP set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_ITEM select * from  DOC_SET_ITEM_TEMP "
            mycommand.ExecuteNonQuery()



            mycommand.CommandText = "delete from  DOC_SET_DAHS_TEMP "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_DAHS_TEMP select * from  DOC_SET_DAHS where cno='" + tb_From.Text + "'"
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "update  DOC_SET_DAHS_TEMP set cno='" + TB_TO.Text + "' "
            mycommand.ExecuteNonQuery()
            mycommand.CommandText = "insert into DOC_SET_DAHS select * from  DOC_SET_DAHS_TEMP "
            mycommand.ExecuteNonQuery()


            'mycommand.CommandText = "delete from  DOC_MODIFY_PDFUPload_TEMP "
            'mycommand.ExecuteNonQuery()
            'mycommand.CommandText = "insert into DOC_MODIFY_PDFUPload_TEMP select * from  DOC_MODIFY_PDFUPload where cno='" + tb_From.Text + "'"
            'mycommand.ExecuteNonQuery()
            'mycommand.CommandText = "update  DOC_MODIFY_PDFUPload_TEMP set cno='" + TB_TO.Text + "' "
            'mycommand.ExecuteNonQuery()
            'mycommand.CommandText = "insert into DOC_MODIFY_PDFUPload select * from  DOC_MODIFY_PDFUPload_TEMP "
            'mycommand.ExecuteNonQuery()



        Catch ex As Exception

        End Try

    End Sub
End Class