<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.index" Codebehind="index.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 140px;
    }
    .style3
    {
        width: 726px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td class="style3">
            <br />
            歡迎光臨 行政院環境保護署 水質保護處處 連續自動監測設施資訊網 (Beta)<br />
            <br />
            我們將利用此網站作為推動工業區連續自動監測之技術服務及資訊平台，敬請各界指教!<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton 
                ID="LinkButton1" runat="server" PostBackUrl="~/EQU/EquipReportEdit.aspx">LinkButton</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ~~~~本網站規劃之各項功能，將依計畫期程陸續完成，謝謝您的等待! ~~~~<br />
            <br />
            <br />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

