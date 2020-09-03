<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PrepareAudit.aspx.vb" Inherits="CWMS_DOC_2015.PrepareAudit" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 22px;
        }
        .auto-style3 {
            margin-top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="dxic-fileManager" bgcolor="#CCFFFF">
        <tr>
            <td width="800">
                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="您選擇了下列事業單位送審的措施說明書/措施說明書變更請/確認報告書/確認報告書變更申請:" Width="800px">
                </dx:ASPxLabel>
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="dxic-fileManager" bgcolor="#CCFFFF">
        <tr>
            <td width="110">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="管制編號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_CNO" runat="server" Width="170px" BackColor="#F0F0F0" ReadOnly="True">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td width="110">
                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="名稱:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_FAC_NAME" runat="server" Width="370px" BackColor="#F0F0F0" CssClass="auto-style3" ReadOnly="True">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="文書種類:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_DOCTYPE" runat="server" Width="170px" BackColor="#F0F0F0" ReadOnly="True">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="事業送審時間:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_DOC_REGDATE" runat="server" Width="170px" BackColor="#F0F0F0" ReadOnly="True">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="版號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_DOCVERSION" runat="server" Width="170px" BackColor="#F0F0F0" ReadOnly="True">
                </dx:ASPxTextBox>
            </td>
        </tr>
        </table>
    <p>
    </p>
    <table class="dxic-fileManager">
        <tr>
            <td width="110" ></td>
            <td ></td>
        </tr>
        <tr>
            <td class="auto-style2">
                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="審查人員:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td class="auto-style2">
                <dx:ASPxTextBox ID="TB_OWNER" runat="server" Width="170px" ReadOnly="True"></dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="代理人:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxComboBox ID="CB_AGENT" runat="server" DataSourceID="SqlDataSource1" TextField="Name" ValueField="UserName" Font-Names="微軟正黑體" Font-Size="Medium">
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="協審人員:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxComboBox ID="CB_HELPER" runat="server" DataSourceID="SqlDataSource1" TextField="Name" ValueField="UserName" Font-Names="微軟正黑體" Font-Size="Medium">
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="收件日期:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_DOC_RECDATE" runat="server" Width="170px" ReadOnly="True">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <p>
    </p>
    <table class="dxic-fileManager">
        <tr>
            <td width="130">
                <dx:ASPxButton ID="ASPxButton1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="開始審查案件">
                </dx:ASPxButton>
            </td>
            <td width="130">
                <dx:ASPxButton ID="ASPxButton2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="返回案件清單">
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="ASPxButton3" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="編輯並確認通知信內容" Visible="False">
                </dx:ASPxButton></td>
        </tr>
        <tr>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMS_aspnetdb %>" 
                    SelectCommand="SELECT a.Name,b.[UserName] FROM [aspnet_Membership] a inner join [aspnet_Users] b on a.userid=b.userid where a.EPB=@EPB and left(a.idtype,3)='EPB' ">
                    <SelectParameters>
                        <asp:SessionParameter Name="EPB" SessionField="EPB" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
