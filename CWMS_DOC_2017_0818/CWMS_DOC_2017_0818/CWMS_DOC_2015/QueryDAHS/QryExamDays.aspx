<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QryExamDays.aspx.vb" Inherits="CWMS_DOC_2015.QryExamDays" %>
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
    <dx:ASPxGridView ID="GridView1" runat="server" Caption="審查天數查詢" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="管制編號,收文字號" DataSourceID="SqlDataSource1" Width="995px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small" KeyFieldName="REG_DATE" OnCustomUnboundColumnData="grid_CustomUnboundColumnData">

        <Columns>
            <dx:GridViewDataDateColumn FieldName="REG_DATE" Caption="申請日期"  VisibleIndex="5" ReadOnly="True"></dx:GridViewDataDateColumn>            
            <dx:GridViewDataDateColumn FieldName="DOC_RECDATE" Caption="收文日期" VisibleIndex="6"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="EXAM_DOCOUT_DATE" Caption="審查完成日期" VisibleIndex="7"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="UPGRADE_DATE" Caption="補件日期"  VisibleIndex="8"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" Caption="管制編號" ReadOnly="True" VisibleIndex="0"></dx:GridViewDataTextColumn>            
            <dx:GridViewDataTextColumn FieldName="ABBR" Caption="名稱" ReadOnly="True" VisibleIndex="1"></dx:GridViewDataTextColumn>            
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" Caption="版號" VisibleIndex="2" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" Caption="種類"  ReadOnly="True" VisibleIndex="3"> </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" Caption="審查結果"  VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Total" Caption="審查總天數" VisibleIndex="9" UnboundType="Decimal"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AuditDays" Caption="審查天數" VisibleIndex="10" UnboundType="Decimal"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="UpgradeDays" Caption="補件天數" VisibleIndex="11" UnboundType="Decimal"></dx:GridViewDataTextColumn>
            
        </Columns>        
                <SettingsSearchPanel Visible="True" />
        <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" SearchPanelEditorNullText="輸入關鍵字查詢" />
            </dx:ASPxGridView>
     <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridView1">
        </dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.[REG_DATE], a.[DOC_RECDATE], a.[EXAM_DOCOUT_DATE], a.[UPGRADE_DATE], a.[CNO],b.ABBR, a.[DOCVERSION], a.[DOCTYPE], a.[EXAM_RESULT] FROM [DAHS_EXAMLIST] a inner join wpf b on a.cno=b.cno">
    </asp:SqlDataSource>
</asp:Content>
