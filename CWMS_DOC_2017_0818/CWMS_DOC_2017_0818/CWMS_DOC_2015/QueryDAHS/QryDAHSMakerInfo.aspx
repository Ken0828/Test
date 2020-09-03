<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QryDAHSMakerInfo.aspx.vb" Inherits="CWMS_DOC_2015.QryDAHSMakerInfo" %>
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
     <dx:ASPxGridView ID="GridView1" runat="server" Caption="相對誤差測試查核結果查詢" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="管制編號,收文字號" DataSourceID="SqlDataSource1" Width="995px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small">

         <Columns>
             <dx:GridViewDataTextColumn FieldName="CNO" VisibleIndex="0" Caption="管制編號"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="FAC_NAME" Caption="事業簡稱" VisibleIndex="1"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="DP_NO" Caption="監測位置" VisibleIndex="2"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="DOCVERSION"  Caption="版號" VisibleIndex="3">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_AGENTNAME" Caption="製造商" VisibleIndex="4">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_EQU_MODEL" Caption="型號" VisibleIndex="5">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_SAMPLE_METHOD" Caption="量測方法" VisibleIndex="6">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="RATA" Caption="相對誤差測試查核結果" VisibleIndex="7">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="AVG_A" Caption="實驗室檢測值平均值" VisibleIndex="8">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="AVG_B" Caption="自動監測設施量測值平均值" VisibleIndex="9">
             </dx:GridViewDataTextColumn>             
             <dx:GridViewDataTextColumn FieldName="AVGDIFF" Caption="平均差值" VisibleIndex="10">
             </dx:GridViewDataTextColumn>
         </Columns>       
                <SettingsSearchPanel Visible="True" />
        <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" SearchPanelEditorNullText="輸入關鍵字查詢" />
            </dx:ASPxGridView>
     <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridView1">
        </dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT A.CNO,F.FAC_NAME,A.DP_NO,A.DOCVERSION,A.SPEC_AGENTNAME,A.SPEC_EQU_MODEL,A.SPEC_SAMPLE_METHOD,B.ACCURACY_A AS RATA,B.AVG_A,B.AVG_B,B.AVG_D,B.AVGDIFF FROM [DOC_SET_SPEC] A LEFT JOIN DOC_SET_FACTORY F ON A.CNO=F.CNO  LEFT JOIN DOC_RATA B ON A.CNO=B.CNO AND A.DOCVERSION=B.DOCVERSION AND A.ITEM =B.ITEM  WHERE A.ITEM IN ('210','243','242')">
    </asp:SqlDataSource>
</asp:Content>
