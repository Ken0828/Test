<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SetAuditEdit.aspx.vb" Inherits="CWMS_DOC_2015.SetAuditEdit" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="GV_NEW" runat="server" Caption="審查案件管理系統"  AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CNO,DOCVERSION,DOCTYPE,REG_DATE" DataSourceID="SqlDataSource1" Width="1480px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Medium" KeyFieldName="CNO;DOCVERSION;DOCTYPE">
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="1"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" VisibleIndex="2"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" VisibleIndex="3" ReadOnly="True" ></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_NAME" VisibleIndex="4"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="REG_DATE" VisibleIndex="5"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="DOC_RECDATE" VisibleIndex="7"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" VisibleIndex="8"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="EXAM_DOCOUT_DATE" VisibleIndex="9"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="UPGRADE_DATE" VisibleIndex="10"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="OWNER" VisibleIndex="12"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AGENT" VisibleIndex="13"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="HELPER" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EPB" VisibleIndex="16">
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
        <SettingsBehavior EnableCustomizationWindow="True" AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessFocusedRowChangedOnServer="True" ProcessSelectionChangedOnServer="True" />
            </dx:ASPxGridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT * FROM [DAHS_EXAMLIST]" 
        DeleteCommand="DELETE FROM [DAHS_EXAMLIST] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" 
        InsertCommand="INSERT INTO [DAHS_EXAMLIST] ([CNO], [DOCVERSION], [DOCTYPE], [FAC_NAME], [REG_DATE], [DOC_SERIAL], [DOC_RECDATE], [EXAM_RESULT], [EXAM_DOCOUT_DATE], [UPGRADE_DATE], [DOCOUT_SERIAL], [OWNER], [AGENT], [HELPER], [MEMO], [EPB], [CR_ID], [CR_DATE], [UP_ID], [UP_DATE]) VALUES (@CNO, @DOCVERSION, @DOCTYPE, @FAC_NAME, @REG_DATE, @DOC_SERIAL, @DOC_RECDATE, @EXAM_RESULT, @EXAM_DOCOUT_DATE, @UPGRADE_DATE, @DOCOUT_SERIAL, @OWNER, @AGENT, @HELPER, @MEMO, @EPB, @CR_ID, @CR_DATE, @UP_ID, @UP_DATE)" 
        UpdateCommand="UPDATE [DAHS_EXAMLIST] SET [FAC_NAME] = @FAC_NAME, [REG_DATE] = @REG_DATE, [DOC_SERIAL] = @DOC_SERIAL, [DOC_RECDATE] = @DOC_RECDATE, [EXAM_RESULT] = @EXAM_RESULT, [EXAM_DOCOUT_DATE] = @EXAM_DOCOUT_DATE, [UPGRADE_DATE] = @UPGRADE_DATE, [DOCOUT_SERIAL] = @DOCOUT_SERIAL, [OWNER] = @OWNER, [AGENT] = @AGENT, [HELPER] = @HELPER, [MEMO] = @MEMO, [EPB] = @EPB, [CR_ID] = @CR_ID, [CR_DATE] = @CR_DATE, [UP_ID] = @UP_ID, [UP_DATE] = @UP_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter Name="FAC_NAME" Type="String" />
            <asp:Parameter Name="REG_DATE" DbType="Date" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter Name="DOC_RECDATE" DbType="Date" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter DbType="Date" Name="EXAM_DOCOUT_DATE" />
            <asp:Parameter Name="UPGRADE_DATE" DbType="Date" />
            <asp:Parameter Name="DOCOUT_SERIAL" Type="String" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="AGENT" Type="String" />
            <asp:Parameter Name="HELPER" Type="String" />
            <asp:Parameter Name="MEMO" Type="String" />
            <asp:Parameter Name="EPB" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="CR_DATE" />
            <asp:Parameter Name="UP_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="UP_DATE" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FAC_NAME" Type="String" />
            <asp:Parameter Name="REG_DATE" DbType="Date" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter Name="DOC_RECDATE" DbType="Date" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter Name="EXAM_DOCOUT_DATE" DbType="Date" />
            <asp:Parameter Name="UPGRADE_DATE" DbType="Date" />
            <asp:Parameter Name="DOCOUT_SERIAL" Type="String" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="AGENT" Type="String" />
            <asp:Parameter Name="HELPER" Type="String" />
            <asp:Parameter Name="MEMO" Type="String" />
            <asp:Parameter Name="EPB" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter Name="CR_DATE" DbType="Date" />
            <asp:Parameter Name="UP_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="UP_DATE" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
        
</asp:Content>
