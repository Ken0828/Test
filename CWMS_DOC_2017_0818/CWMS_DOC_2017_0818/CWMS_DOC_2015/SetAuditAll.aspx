<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SetAuditAll.aspx.vb" Inherits="CWMS_DOC_2015.SetAuditAll" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <dx:ASPxGridView ID="GV_NEW" runat="server" Caption="審查案件管理系統----已送未審" OnCustomUnboundColumnData="grid_CustomUnboundColumnData" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CNO,DOCVERSION,DOCTYPE,REG_DATE" DataSourceID="SqlDataSource1" Width="1480px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Medium" KeyFieldName="CNO;DOCVERSION;DOCTYPE;REG_DATE">

        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" caption="">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="1" Caption ="管制編號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_NAME" ReadOnly="True" VisibleIndex="2" Caption ="名稱"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" VisibleIndex="3" Caption ="版號" ReadOnly="True" ></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" VisibleIndex="4" Caption ="文書種類" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="REG_DATE" VisibleIndex="5" Caption ="申請日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DOC_SERIAL" VisibleIndex="6" Caption ="收文字號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DOC_RECDATE" VisibleIndex="7" Caption ="本文號收件日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" VisibleIndex="8" Caption ="審查結果"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="EXAM_DOCOUT_DATE" VisibleIndex="10" Caption ="完成本次審查結果（發文）日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="UPGRADE_DATE" VisibleIndex="11" Caption ="補正期限"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DOCOUT_SERIAL" VisibleIndex="12" Caption ="發文字號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="OWNER" VisibleIndex="13" Caption ="承辦人員"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MEMO" VisibleIndex="14" Caption ="備註"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Total" Caption="審查天數" VisibleIndex="9" UnboundType="Decimal">
                <CellStyle ForeColor="Red">
                </CellStyle>
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
    <dx:ASPxButton ID="BT_NewCase" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="前往審查....">
                  </dx:ASPxButton>
    <br />
    <dx:ASPxGridView ID="GV_Examing" runat="server" Caption="審查案件管理系統----審查/補正中" OnCustomUnboundColumnData="grid_CustomUnboundColumnData" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CNO,DOCVERSION,REG_DATE" DataSourceID="SqlDataSource3" Width="1480px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Medium" KeyFieldName="CNO;DOCVERSION;DOCTYPE;REG_DATE">
           <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" Caption ="">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="1" Caption ="管制編號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_NAME" ReadOnly="True" VisibleIndex="2" Caption ="名稱"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" VisibleIndex="3" Caption ="版號" ReadOnly="True" ></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" VisibleIndex="4" Caption ="文書種類" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="REG_DATE" VisibleIndex="5" Caption ="申請日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DOC_SERIAL" VisibleIndex="6" Caption ="收文字號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DOC_RECDATE" VisibleIndex="7" Caption ="本文號收件日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" VisibleIndex="8" Caption ="審查結果"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="EXAM_DOCOUT_DATE" VisibleIndex="10" Caption ="完成本次審查結果（發文）日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="UPGRADE_DATE" VisibleIndex="11" Caption ="補正期限"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DOCOUT_SERIAL" VisibleIndex="12" Caption ="發文字號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="OWNER" VisibleIndex="13" Caption ="承辦人員"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MEMO" VisibleIndex="14" Caption ="備註"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Total" Caption="審查天數" VisibleIndex="9" UnboundType="Decimal">
                <CellStyle ForeColor="Red">
                </CellStyle>
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
    
    <dx:ASPxButton ID="BT_QryExaming" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="前往審查....">
                  </dx:ASPxButton>
    <dx:ASPxGridView ID="GV_ExamComplete" runat="server" Caption="審查案件管理系統----已審查/駁回" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CNO,DOCVERSION,REG_DATE" DataSourceID="SqlDataSource2" Width="1480px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Medium" KeyFieldName="CNO;DOCVERSION;DOCTYPE;REG_DATE">

         <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" Caption ="" >
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="1" Caption ="管制編號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_NAME" ReadOnly="True" VisibleIndex="2" Caption ="名稱"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" VisibleIndex="3" Caption ="版號" ReadOnly="True" ></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" VisibleIndex="4" Caption ="文書種類" ReadOnly="True"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="REG_DATE" VisibleIndex="5" Caption ="申請日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DOC_SERIAL" VisibleIndex="6" Caption ="收文字號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DOC_RECDATE" VisibleIndex="7" Caption ="本文號收件日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" VisibleIndex="8" Caption ="審查結果"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="EXAM_DOCOUT_DATE" VisibleIndex="10" Caption ="完成本次審查結果（發文）日期"></dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="UPGRADE_DATE" VisibleIndex="11" Caption ="補正期限"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DOCOUT_SERIAL" VisibleIndex="12" Caption ="發文字號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="OWNER" VisibleIndex="13" Caption ="承辦人員"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MEMO" VisibleIndex="14" Caption ="備註"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Total" Caption="審查天數" VisibleIndex="9" UnboundType="Decimal">
                <CellStyle ForeColor="Red">
                </CellStyle>
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
    <dx:ASPxButton ID="BT_CaseComplete" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="前往查看....">
                  </dx:ASPxButton>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.* FROM [DAHS_EXAMLIST] a  where a.EXAM_RESULT='已送未審'   " 
        DeleteCommand="DELETE FROM [DAHS_EXAMLIST] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE AND [REG_DATE] = @REG_DATE" 
        InsertCommand="INSERT INTO [DAHS_EXAMLIST] ([CNO], [DOCVERSION], [DOCTYPE], [REG_DATE], [DOC_SERIAL], [DOC_RECDATE], [EXAM_RESULT], [EXAM_DOCOUT_DATE], [UPGRADE_DATE], [DOCOUT_SERIAL], [OWNER], [MEMO], [CR_ID], [CR_DATE], [UP_ID], [UP_DATE]) VALUES (@CNO, @DOCVERSION, @DOCTYPE, @REG_DATE, @DOC_SERIAL, @DOC_RECDATE, @EXAM_RESULT, @EXAM_DOCOUT_DATE, @UPGRADE_DATE, @DOCOUT_SERIAL, @OWNER, @MEMO, @CR_ID, @CR_DATE, @UP_ID, @UP_DATE)" 
        UpdateCommand="UPDATE [DAHS_EXAMLIST] SET [DOC_SERIAL] = @DOC_SERIAL, [DOC_RECDATE] = @DOC_RECDATE, [EXAM_RESULT] = @EXAM_RESULT, [EXAM_DOCOUT_DATE] = @EXAM_DOCOUT_DATE, [UPGRADE_DATE] = @UPGRADE_DATE, [DOCOUT_SERIAL] = @DOCOUT_SERIAL, [OWNER] = @OWNER, [MEMO] = @MEMO, [CR_ID] = @CR_ID, [CR_DATE] = @CR_DATE, [UP_ID] = @UP_ID, [UP_DATE] = @UP_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE AND [REG_DATE] = @REG_DATE">         
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter DbType="Date" Name="REG_DATE" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter DbType="Date" Name="REG_DATE" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter DbType="Date" Name="DOC_RECDATE" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter DbType="Date" Name="EXAM_DOCOUT_DATE" />
            <asp:Parameter DbType="Date" Name="UPGRADE_DATE" />
            <asp:Parameter Name="DOCOUT_SERIAL" Type="String" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="MEMO" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="CR_DATE" />
            <asp:Parameter Name="UP_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="UP_DATE" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter Name="DOC_RECDATE" DbType="Date" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter Name="EXAM_DOCOUT_DATE" DbType="Date" />
            <asp:Parameter DbType="Date" Name="UPGRADE_DATE" />
            <asp:Parameter Name="DOCOUT_SERIAL" Type="String" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="MEMO" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter Name="CR_DATE" DbType="Date" />
            <asp:Parameter Name="UP_ID" Type="String" />
            <asp:Parameter Name="UP_DATE" DbType="Date" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter Name="REG_DATE" DbType="Date" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.* FROM [DAHS_EXAMLIST] a  where  a.EXAM_RESULT in ('審查通過','駁回')   " 
        DeleteCommand="DELETE FROM [DAHS_EXAMLIST] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" 
        InsertCommand="INSERT INTO [DAHS_EXAMLIST] ([CNO], [DOCVERSION], [DOCTYPE], [REG_DATE], [DOC_SERIAL], [DOC_RECDATE], [EXAM_RESULT], [EXAM_DOCOUT_DATE], [UPGRADE_DATE], [DOCOUT_SERIAL], [OWNER], [MEMO], [CR_ID], [CR_DATE], [UP_ID], [UP_DATE]) VALUES (@CNO, @DOCVERSION, @DOCTYPE, @REG_DATE, @DOC_SERIAL, @DOC_RECDATE, @EXAM_RESULT, @EXAM_DOCOUT_DATE, @UPGRADE_DATE, @DOCOUT_SERIAL, @OWNER, @MEMO, @CR_ID, @CR_DATE, @UP_ID, @UP_DATE)" 
        UpdateCommand="UPDATE [DAHS_EXAMLIST] SET [REG_DATE] = @REG_DATE, [DOC_SERIAL] = @DOC_SERIAL, [DOC_RECDATE] = @DOC_RECDATE, [EXAM_RESULT] = @EXAM_RESULT, [EXAM_DOCOUT_DATE] = @EXAM_DOCOUT_DATE, [UPGRADE_DATE] = @UPGRADE_DATE, [DOCOUT_SERIAL] = @DOCOUT_SERIAL, [OWNER] = @OWNER, [MEMO] = @MEMO, [CR_ID] = @CR_ID, [CR_DATE] = @CR_DATE, [UP_ID] = @UP_ID, [UP_DATE] = @UP_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter DbType="Date" Name="REG_DATE" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter DbType="Date" Name="DOC_RECDATE" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter DbType="Date" Name="EXAM_DOCOUT_DATE" />
            <asp:Parameter DbType="Date" Name="UPGRADE_DATE" />
            <asp:Parameter Name="DOCOUT_SERIAL" Type="String" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="MEMO" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="CR_DATE" />
            <asp:Parameter Name="UP_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="UP_DATE" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter DbType="Date" Name="REG_DATE" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter DbType="Date" Name="DOC_RECDATE" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter DbType="Date" Name="EXAM_DOCOUT_DATE" />
            <asp:Parameter DbType="Date" Name="UPGRADE_DATE" />
            <asp:Parameter Name="DOCOUT_SERIAL" Type="String" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="MEMO" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="CR_DATE" />
            <asp:Parameter Name="UP_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="UP_DATE" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.* FROM [DAHS_EXAMLIST] a  where  a.EXAM_RESULT in ('審查中','補正中','補正重送')   " 
        DeleteCommand="DELETE FROM [DAHS_EXAMLIST] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" 
        InsertCommand="INSERT INTO [DAHS_EXAMLIST] ([CNO], [DOCVERSION], [DOCTYPE], [REG_DATE], [DOC_SERIAL], [DOC_RECDATE], [EXAM_RESULT], [EXAM_DOCOUT_DATE], [UPGRADE_DATE], [DOCOUT_SERIAL], [OWNER], [MEMO], [CR_ID], [CR_DATE], [UP_ID], [UP_DATE]) VALUES (@CNO, @DOCVERSION, @DOCTYPE, @REG_DATE, @DOC_SERIAL, @DOC_RECDATE, @EXAM_RESULT, @EXAM_DOCOUT_DATE, @UPGRADE_DATE, @DOCOUT_SERIAL, @OWNER, @MEMO, @CR_ID, @CR_DATE, @UP_ID, @UP_DATE)" 
        UpdateCommand="UPDATE [DAHS_EXAMLIST] SET [REG_DATE] = @REG_DATE, [DOC_SERIAL] = @DOC_SERIAL, [DOC_RECDATE] = @DOC_RECDATE, [EXAM_RESULT] = @EXAM_RESULT, [EXAM_DOCOUT_DATE] = @EXAM_DOCOUT_DATE, [UPGRADE_DATE] = @UPGRADE_DATE, [DOCOUT_SERIAL] = @DOCOUT_SERIAL, [OWNER] = @OWNER, [MEMO] = @MEMO, [CR_ID] = @CR_ID, [CR_DATE] = @CR_DATE, [UP_ID] = @UP_ID, [UP_DATE] = @UP_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">        
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter DbType="Date" Name="REG_DATE" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter DbType="Date" Name="DOC_RECDATE" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter DbType="Date" Name="EXAM_DOCOUT_DATE" />
            <asp:Parameter DbType="Date" Name="UPGRADE_DATE" />
            <asp:Parameter Name="DOCOUT_SERIAL" Type="String" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="MEMO" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="CR_DATE" />
            <asp:Parameter Name="UP_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="UP_DATE" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter DbType="Date" Name="REG_DATE" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter DbType="Date" Name="DOC_RECDATE" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter DbType="Date" Name="EXAM_DOCOUT_DATE" />
            <asp:Parameter DbType="Date" Name="UPGRADE_DATE" />
            <asp:Parameter Name="DOCOUT_SERIAL" Type="String" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="MEMO" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="CR_DATE" />
            <asp:Parameter Name="UP_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="UP_DATE" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
