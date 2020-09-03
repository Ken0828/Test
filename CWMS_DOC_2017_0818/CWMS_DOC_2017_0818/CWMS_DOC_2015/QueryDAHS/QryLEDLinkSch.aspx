<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QryLEDLinkSch.aspx.vb" Inherits="CWMS_DOC_2015.QryLEDLinkSch" %>
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
    <dx:ASPxGridView ID="GridView1" runat="server" Caption="自動監測(試)、連線、電子看板建置時程查詢" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="管制編號,收文字號" DataSourceID="SqlDataSource1" Width="995px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small" KeyFieldName="CNO">

        <Columns>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="0" Caption="管制編號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_NAME" ReadOnly="True" VisibleIndex="1" Caption="名稱"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" VisibleIndex="2" ReadOnly="True" Caption="版號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="PLAN_INSDATE" VisibleIndex="3" Caption="DAHS預計安裝"></dx:GridViewDataDateColumn>            
            <dx:GridViewDataDateColumn FieldName="LED_PLAN_DATE" VisibleIndex="5" Caption="LED預計安裝">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="DAHS_ACTUALDATE" VisibleIndex="4" Caption="DAHS實際安裝">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="LED_ACTUALDATE" VisibleIndex="6" Caption="LED實際安裝">
            </dx:GridViewDataDateColumn>
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
     <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridView1">        </dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.CNO,c.FAC_NAME, a.DOCVERSION, a.PLAN_INSDATE, SL.LED_PLAN_DATE, b.PLAN_INSDATE AS DAHS_ACTUALDATE, VL.LED_PLAN_DATE AS LED_ACTUALDATE FROM DOC_SET_DAHS a inner join DOC_SET_FACTORY c on a.cno=c.cno LEFT JOIN DOC_SET_LED SL ON a.CNO = SL.CNO LEFT JOIN DOC_VRY_DAHS b ON a.CNO = b.CNO LEFT JOIN DOC_VRY_LED VL ON a.CNO = VL.CNO">
    </asp:SqlDataSource>
</asp:Content>
