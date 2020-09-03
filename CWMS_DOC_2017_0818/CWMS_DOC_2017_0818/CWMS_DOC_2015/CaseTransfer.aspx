<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CaseTransfer.aspx.vb" Inherits="CWMS_DOC_2015.CaseTransfer" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="GridView1" runat="server" Caption="審查案件管理系統----審查/補正中" OnCustomUnboundColumnData="grid_CustomUnboundColumnData" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CNO,DOCVERSION,REG_DATE" DataSourceID="SqlDataSource3" Width="1480px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Medium" KeyFieldName="CNO">
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
            </dx:ASPxGridView>
     <dx:ASPxButton ID="ASPxButton1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="選擇欲更換案件....">
                  </dx:ASPxButton>
    <br />
    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium">
    </dx:ASPxLabel>
    <br />
    <table class="dxflInternalEditorTable">
        <tr>
            <td width="200">
                <dx:ASPxTextBox ID="tb_Owner_orig" runat="server" Caption="原審查人員" Width="170px" Font-Names="微軟正黑體" Font-Size="Medium">
                </dx:ASPxTextBox>
            </td>
            <td width="130">
                <dx:ASPxComboBox ID="CB_NewOwner" runat="server" Caption="更換後審查人員" DataSourceID="SqlDataSource1" TextField="name" ValueField="name" Font-Names="微軟正黑體" Font-Size="Medium">
                </dx:ASPxComboBox>
            </td>
            <td width="120">
     <dx:ASPxButton ID="bt_owner" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="更換審查人員....">
                  </dx:ASPxButton>
    
            </td>
            <td><dx:ASPxLabel ID="Label_Owner" runat="server" Font-Names="微軟正黑體" Font-Size="Medium"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td width="200">
                <dx:ASPxTextBox ID="tb_Agent_orig" runat="server" Caption="原代理人員" Width="170px" Font-Names="微軟正黑體" Font-Size="Medium" Visible="False">
                </dx:ASPxTextBox>
            </td>
            <td width="130">
                <dx:ASPxComboBox ID="CB_NewAgent" runat="server" Caption="更換後代理人員" DataSourceID="SqlDataSource4" TextField="name" ValueField="name" Font-Names="微軟正黑體" Font-Size="Medium" Visible="False">
                </dx:ASPxComboBox>
            </td>
            <td>
     <dx:ASPxButton ID="bt_Agent" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="更換代理人員...." Visible="False">
                  </dx:ASPxButton>
            </td>
             <td><dx:ASPxLabel ID="Label_Agent" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Visible="False"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td width="200">
                <dx:ASPxTextBox ID="tb_Helper_orig" runat="server" Caption="原協審人員" Width="170px" Font-Names="微軟正黑體" Font-Size="Medium" Visible="False">
                </dx:ASPxTextBox>
            </td>
            <td width="130">
                <dx:ASPxComboBox ID="CB_NewHelper" runat="server" Caption="更換後協審人員" DataSourceID="SqlDataSource2" TextField="name" ValueField="name" Font-Names="微軟正黑體" Font-Size="Medium" Visible="False">
                </dx:ASPxComboBox>
            </td>
            <td>
     <dx:ASPxButton ID="bt_helper" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="更換協審人員...." Visible="False">
                  </dx:ASPxButton>
            </td>
            <td><dx:ASPxLabel ID="Label_Helper" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Visible="False"></dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxButton ID="ASPxButton3" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="編輯並確認通知信內容">
                </dx:ASPxButton></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.* FROM [DAHS_EXAMLIST] a  where a.EXAM_RESULT in ('審查中','補正中','補正重送') and epb=@UserEPB " 
        DeleteCommand="DELETE FROM [DAHS_EXAMLIST] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE AND [REG_DATE] = @REG_DATE" 
        InsertCommand="INSERT INTO [DAHS_EXAMLIST] ([CNO], [DOCVERSION], [DOCTYPE], [REG_DATE], [DOC_SERIAL], [DOC_RECDATE], [EXAM_RESULT], [EXAM_DOCOUT_DATE], [UPGRADE_DATE], [DOCOUT_SERIAL], [OWNER], [MEMO], [CR_ID], [CR_DATE], [UP_ID], [UP_DATE]) VALUES (@CNO, @DOCVERSION, @DOCTYPE, @REG_DATE, @DOC_SERIAL, @DOC_RECDATE, @EXAM_RESULT, @EXAM_DOCOUT_DATE, @UPGRADE_DATE, @DOCOUT_SERIAL, @OWNER, @MEMO, @CR_ID, @CR_DATE, @UP_ID, @UP_DATE)" 
        UpdateCommand="UPDATE [DAHS_EXAMLIST] SET [DOC_SERIAL] = @DOC_SERIAL, [DOC_RECDATE] = @DOC_RECDATE, [EXAM_RESULT] = @EXAM_RESULT, [EXAM_DOCOUT_DATE] = @EXAM_DOCOUT_DATE, [UPGRADE_DATE] = @UPGRADE_DATE, [DOCOUT_SERIAL] = @DOCOUT_SERIAL, [OWNER] = @OWNER, [MEMO] = @MEMO, [CR_ID] = @CR_ID, [CR_DATE] = @CR_DATE, [UP_ID] = @UP_ID, [UP_DATE] = @UP_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE AND [REG_DATE] = @REG_DATE">
        
        <SelectParameters>            
             <asp:SessionParameter Name="UserEPB" SessionField="UserEPB" Type="String" />
        </SelectParameters>
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
            <asp:Parameter DbType="Date" Name="REG_DATE" />
        </UpdateParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMS_aspnetdb %>" 
                    SelectCommand="SELECT  b.name from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where b.idtype=@IDTYPE">
                    <SelectParameters>
                        <asp:SessionParameter Name="IDTYPE" SessionField="IDTYPE" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
     <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CWMS_aspnetdb %>" 
                    SelectCommand="SELECT  b.name from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where b.idtype=@IDTYPE">
                    <SelectParameters>
                        <asp:SessionParameter Name="IDTYPE" SessionField="IDTYPE" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CWMS_aspnetdb %>"
        SelectCommand="SELECT  b.name from aspnet_Users a inner join  dbo.aspnet_Membership b on a.userid=b.userid where b.idtype=@IDTYPE">
        <SelectParameters>
            <asp:SessionParameter Name="IDTYPE" SessionField="HELPER" Type="String" />
        </SelectParameters>

    </asp:SqlDataSource>
            </asp:Content>