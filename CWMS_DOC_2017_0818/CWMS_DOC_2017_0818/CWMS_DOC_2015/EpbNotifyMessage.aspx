<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="EpbNotifyMessage.aspx.vb" Inherits="CWMS_DOC_2015.EpbNotifyMessage" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxRichEdit.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRichEdit" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="dxic-fileManager">
        <tr>
            <td>
                <dx:ASPxTextBox ID="TB_CaseNo" runat="server" Caption="案件編號" Font-Names="微軟正黑體" Font-Size="Medium" ReadOnly="True" Width="170px">
                </dx:ASPxTextBox>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <dx:ASPxMemo ID="Memo1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Height="300px" Theme="Aqua" Width="600px" Caption="請檢視系統即將發出的通知信函內容，如有問題可於下列內容直接修正">
                    <CaptionSettings Position="Top" />
                </dx:ASPxMemo>
            </td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
    <p>
    </p>
    <table class="dxic-fileManager">
        <tr>
            <td width="125">
                <dx:ASPxButton ID="ASPxButton1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="發信並前往審查" Width="120px">
                </dx:ASPxButton>
            </td>            
            <td width="125">
                <dx:ASPxButton ID="ASPxButton2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="發信但先返回審查總表" Width="120px">
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="ASPxButton3" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="發信並返回審查總表" Width="120px">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
</asp:Content>
