<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PrepareSummit.aspx.vb" Inherits="CWMS_DOC_2015.PrepareSummit" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="dxic-fileManager" bgcolor="#CCFFFF">
        <tr>
            <td width="110">
                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="您即將送審措施說明書/措施說明書變更請/確認報告書/確認報告書變更申請:" Width="500px">
                </dx:ASPxLabel>
            </td>
        </tr>
        </table>
    <table class="dxic-fileManager" bgcolor="#CCFFFF">
        <tr>
            <td width="110">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="管制編號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_CNO" runat="server" Width="170px" BackColor="#CCCCCC">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="文書種類:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_DOCTYPE" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="事業送審時間:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="DOC_REGDATE" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="版號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_DOCVERSION" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
           <td>
                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="狀態:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_FIXMODE" runat="server" Width="170px" BackColor="#CCCCCC">
                </dx:ASPxTextBox>
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="dxic-fileManager">        
        <tr>
            <td  width="110" class="auto-style1">
                <dx:ASPxButton ID="ASPxButton1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="確認送出案件" Width="120px">
                </dx:ASPxButton>
            </td>
            <td width="120" class="auto-style1">
                <dx:ASPxButton ID="ASPxButton2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="返回主畫面" Width="120px">
                </dx:ASPxButton>
            </td>
            <td class="auto-style1">
                <dx:ASPxButton ID="BT_RECEIPT" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="[收執聯]下載" Width="120px" Visible="False">
                </dx:ASPxButton>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
