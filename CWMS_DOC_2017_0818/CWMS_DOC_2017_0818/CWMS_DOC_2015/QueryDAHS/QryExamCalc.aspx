<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QryExamCalc.aspx.vb" Inherits="CWMS_DOC_2015.QryExamCalc" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="Table1" runat="server" Width="850px" CellPadding="0" CellSpacing="0" BorderWidth="0" Visible="false">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server" Width="780px">&nbsp;</asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server" Width="35px"> <asp:ImageButton ID="ImgBtn_Excel" OnClick="ImgBtn_Excel_Click"
                      runat="server" ImageUrl="~/Images/Excel-24.ico" />
                </asp:TableCell>
                <asp:TableCell ID="TableCell3" runat="server" Width="35px"> <asp:ImageButton ID="ImgBtn_XML"  Visible="false"
                      runat="server" ImageUrl="~/Images/XML-24.ico" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    <dx:ASPxGridView ID="gv_master" runat="server" Caption="審查件數查詢" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="EXAM_RESULT" DataSourceID="SqlDataSource1" Width="600px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small">

        <Columns>
            <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0" Caption ="" >
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" Caption ="審查結果" VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEMCOUNTS" Caption="案件數(件)" VisibleIndex="2" ReadOnly="True"></dx:GridViewDataTextColumn>
        </Columns>             
                <SettingsBehavior AllowFocusedRow="True" />
                <SettingsSearchPanel Visible="True" />
        <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" SearchPanelEditorNullText="輸入關鍵字查詢" />
       
            </dx:ASPxGridView>
    <br />
    <dx:ASPxGridView ID="gv_master0" runat="server" Caption="案件審查進度統計-詳細資料" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="EXAM_RESULT" DataSourceID="SqlDataSource2" Width="600px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small">

        <Columns>
            <dx:GridViewDataTextColumn FieldName="CNO" Caption ="管制編號"  VisibleIndex="0"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ABBR" Caption ="名稱"  VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" Caption ="文書種類"  VisibleIndex="2"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="REG_DATE" Caption ="申請日期"  VisibleIndex="3">
            </dx:GridViewDataDateColumn>
        </Columns>             
                <SettingsSearchPanel Visible="True" />
        <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" SearchPanelEditorNullText="輸入關鍵字查詢" />
       
            </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridView1">
        </dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT EXAM_RESULT AS 'EXAM_RESULT',COUNT(*)  AS  'ITEMCOUNTS'  FROM [DAHS_EXAMLIST] GROUP BY EXAM_RESULT">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.[CNO], a.[DOCTYPE], a.[REG_DATE],b.ABBR FROM [DAHS_EXAMLIST] a inner join wpf b on a.cno=b.cno WHERE a.EXAM_RESULT='審查/補正中' ">
    </asp:SqlDataSource>
    
</asp:Content>
