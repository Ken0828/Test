<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="AuditHelper.aspx.vb" Inherits="CWMS_DOC_2015.AuditHelper" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <dx:ASPxButton ID="ASPxButton1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="回審查畫面" Theme="Aqua">
        </dx:ASPxButton>
        <dx:ASPxGridView ID="GridView1" runat="server" Caption="審查案件協助" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="管制編號,收文字號" DataSourceID="SqlDataSource1" Width="995px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small" KeyFieldName="CNO">

        <Columns>
            <dx:GridViewDataTextColumn FieldName="CNO"  ReadOnly="True" VisibleIndex="0" Caption ="管制編號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" VisibleIndex="1" ReadOnly="True" Caption ="版號"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="CHECKTIME" VisibleIndex="2" ReadOnly="True" Caption ="檢核時間"></dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="AUDIT_RULE" VisibleIndex="3" Caption ="檢核規則"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AUDIT_RESULT" VisibleIndex="4" Caption ="檢核結果"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RECOMMAND_RULE" VisibleIndex="5" Caption ="建議應更正項目"></dx:GridViewDataTextColumn>            
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT * FROM [DOC_CHECKRESULT] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION)) ORDER BY CHECKTIME DESC" 
        DeleteCommand="DELETE FROM [DOC_CHECKRESULT] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [CHECKTIME] = @CHECKTIME" 
        InsertCommand="INSERT INTO [DOC_CHECKRESULT] ([CNO], [DOCVERSION], [CHECKTIME], [AUDIT_RULE], [AUDIT_RESULT], [RECOMMAND_RULE], [CR_ID], [CR_DATE]) VALUES (@CNO, @DOCVERSION, @CHECKTIME, @AUDIT_RULE, @AUDIT_RESULT, @RECOMMAND_RULE, @CR_ID, @CR_DATE)" 
        UpdateCommand="UPDATE [DOC_CHECKRESULT] SET [AUDIT_RULE] = @AUDIT_RULE, [AUDIT_RESULT] = @AUDIT_RESULT, [RECOMMAND_RULE] = @RECOMMAND_RULE, [CR_ID] = @CR_ID, [CR_DATE] = @CR_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [CHECKTIME] = @CHECKTIME">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="CHECKTIME" Type="DateTime" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="CHECKTIME" Type="DateTime" />
            <asp:Parameter Name="AUDIT_RULE" Type="String" />
            <asp:Parameter Name="AUDIT_RESULT" Type="String" />
            <asp:Parameter Name="RECOMMAND_RULE" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter Name="CR_DATE" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
            <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="AUDIT_RULE" Type="String" />
            <asp:Parameter Name="AUDIT_RESULT" Type="String" />
            <asp:Parameter Name="RECOMMAND_RULE" Type="String" />
            <asp:Parameter Name="CR_ID" Type="String" />
            <asp:Parameter Name="CR_DATE" Type="DateTime" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="CHECKTIME" Type="DateTime" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
