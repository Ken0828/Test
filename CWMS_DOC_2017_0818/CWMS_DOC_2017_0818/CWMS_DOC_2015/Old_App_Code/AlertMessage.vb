Imports Microsoft.VisualBasic

Public Class AlertMessage
    '���JavaScript��Alert�T��
    Public Sub showMsg(ByVal thisPage As Page, ByVal AlertMessage As String)
        Dim txtMsg As New Literal()
        txtMsg.Text = "<script>alert('" & AlertMessage & "')</script>" + "<BR/>"
        thisPage.Controls.Add(txtMsg)
    End Sub
End Class
