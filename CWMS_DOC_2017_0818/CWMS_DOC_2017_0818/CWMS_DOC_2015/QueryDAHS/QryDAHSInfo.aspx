<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QryDAHSInfo.aspx.vb" Inherits="CWMS_DOC_2015.QryDAHSInfo" %>
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
     <dx:ASPxGridView ID="GridView1" runat="server" Caption="監測設施性能資訊查詢" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="管制編號,收文字號" DataSourceID="SqlDataSource1" Width="995px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small" KeyFieldName="CNO">

         <Columns>
             <dx:GridViewDataTextColumn FieldName="CNO" Caption="管制編號" ReadOnly="True" VisibleIndex="0"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="ABBR" Caption="名稱" ReadOnly="True" VisibleIndex="1"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="DP_NO" Caption="監測位置" VisibleIndex="2" ReadOnly="True"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="DOCVERSION" Caption="版號" ReadOnly="True" VisibleIndex="3"></dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="ITEM" Caption="監測項目" ReadOnly="True" VisibleIndex="4">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_AGENTNAME" Caption="製造商或代理商" VisibleIndex="14">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_EQU_MODEL" Caption="型號" VisibleIndex="15">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_EQU_SERIAL" Caption="序號" VisibleIndex="16">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_SAMPLE_METHOD" VisibleIndex="17" Caption="量測方式">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_CALC_EQU" VisibleIndex="20" Caption="校正器材">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_CALC_FREQ" VisibleIndex="21" Caption="校正週期">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_MAIN_FREQ" VisibleIndex="23" Caption="維護週期">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_MATERIAL" VisibleIndex="26" Caption="耗材內容">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_MATERIAL_FREQ" VisibleIndex="28" Caption="耗材更換頻率">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_MEA_SCOPE" VisibleIndex="29" Caption="量測範圍">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_MEA_RESTIME" VisibleIndex="31" Caption="應答時間">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_MEA_FREQ" VisibleIndex="33" Caption="量測週期">
             </dx:GridViewDataTextColumn>
             <dx:GridViewDataTextColumn FieldName="SPEC_CALCAVG" VisibleIndex="35" Caption="等時距">
             </dx:GridViewDataTextColumn>
         </Columns>
        <SettingsCommandButton>
                <NewButton>
                    <Image IconID="actions_add_16x16">
                    </Image>
                </NewButton>
                <UpdateButton>
                    <Image IconID="data_exportmodeldifferences_16x16">
                    </Image>
                </UpdateButton>
                <CancelButton>
                    <Image IconID="actions_cancel_16x16">
                    </Image>
                </CancelButton>
                <EditButton>
                    <Image IconID="actions_clip_16x16">
                    </Image>
                </EditButton>
                <DeleteButton>
                    <Image IconID="actions_close_16x16">
                    </Image>
                </DeleteButton>
            </SettingsCommandButton>
                <SettingsSearchPanel Visible="True" />
        <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" SearchPanelEditorNullText="輸入關鍵字查詢" />
            </dx:ASPxGridView>
     <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridView1"></dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.*,b.ABBR FROM [DOC_SET_SPEC]  a inner join wpf b on a.cno=b.cno ">
    </asp:SqlDataSource>
</asp:Content>
