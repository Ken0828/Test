<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QryElecMeter.aspx.vb" Inherits="CWMS_DOC_2015.QryElecMeter" %>
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
    <dx:ASPxGridView ID="GridView1" runat="server" Caption="電表資訊查詢" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="管制編號,收文字號" DataSourceID="SqlDataSource1" Width="1300px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small">

        <Columns>
            <dx:GridViewDataTextColumn FieldName="SPEC_AGENTNAME" VisibleIndex="3" Caption="製造商"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_EQU_MODEL" VisibleIndex="4" Caption="型號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="校正週期" FieldName="SPEC_CALC_FREQ" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="維護週期" FieldName="SPEC_MAIN_FREQ" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="量測範圍" FieldName="SPEC_MEA_SCOPE" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="名稱" FieldName="FAC_NAME" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="監測位置" FieldName="DP_NO" VisibleIndex="2">
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
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridView1">
        </dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.[SPEC_AGENTNAME], a.[SPEC_EQU_MODEL], a.[SPEC_CALC_FREQ], a.[SPEC_MAIN_FREQ], a.[SPEC_MEA_SCOPE], a.[CNO], a.[DP_NO],b.FAC_NAME FROM [DOC_SET_SPEC] a inner join DOC_SET_FACTORY b on a.cno=b.cno WHERE left(a.[ITEM],2) ='EM'">
        
    </asp:SqlDataSource>
</asp:Content>
