Imports Microsoft.VisualBasic

Public Class AlertMessage
    '顯示JavaScript的Alert訊息
    Public Sub showMsg(ByVal thisPage As Page, ByVal AlertMessage As String)
        Dim txtMsg As New Literal()
        txtMsg.Text = "<script>alert('" & AlertMessage & "')</script>" + "<BR/>"
        thisPage.Controls.Add(txtMsg)
    End Sub
End Class
