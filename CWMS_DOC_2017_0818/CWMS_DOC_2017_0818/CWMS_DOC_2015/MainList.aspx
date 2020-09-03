<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.DocManage_ManList" Codebehind="MainList.aspx.vb" %>

<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 108px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View_Copy" runat="server">
            <table class="dxic-fileManager" bgcolor="#CCFFFF">
        <tr>
            <td width="110">
                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="本功能可協助將先前補登錄之確認報告書內容複製至措施說明書，複製後仍請再行確認內容並修正,但無需再送審!" Width="800px">
                </dx:ASPxLabel>
            </td>
        </tr>
        </table>
    <table class="dxic-fileManager" bgcolor="#CCFFFF">
        <tr>
            <td width="110">
                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="管制編號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_Copy_CNO" runat="server" Width="170px" BackColor="#CCCCCC" Enabled ="false"  ></dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="文書種類:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_Copy_DOCTYPE" runat="server" Width="170px" BackColor="#CCCCCC" Enabled ="false"  ></dx:ASPxTextBox>
            </td>
        </tr>        
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="版號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_Copy_DOCVERSION" runat="server" Width="170px" BackColor="#CCCCCC" Enabled ="false"  ></dx:ASPxTextBox>
            </td>
        </tr>        
        </table>            
            <dx:ASPxButton ID="BT_CopyVrytoSet" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="複製補登確認報告書至措施說明書" Theme="Aqua"></dx:ASPxButton>
            <br />
            <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="提醒:複製完成後請先登出再重新登入，即可前往申請變更!" Width="800px">
            </dx:ASPxLabel>
        </asp:View>
        <asp:View ID="View1" runat="server">
            <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="1" EnableTheming="True" Height="200px" Theme="Aqua">
                <TabPages>
                    <dx:TabPage Text="1〜3批及重大違規之既設業者">
                        <ContentCollection>
                            <dx:ContentControl runat="server">
                                <dx:ASPxRadioButtonList ID="RBL_BATCH_13" runat="server" AutoPostBack="True" Font-Names="微軟正黑體" Font-Size="Large" RepeatDirection="Horizontal" SelectedIndex="0" Theme="Aqua">
                                    <Items>
                                        <dx:ListEditItem Selected="True" Text="涉及廠牌、型號之變更" Value="涉及廠牌、型號之變更" />
                                        <dx:ListEditItem Text="其他變更" Value="其他變更" />
                                        <dx:ListEditItem Text="補登入" Value="補登入" />
                                    </Items>
                                </dx:ASPxRadioButtonList>
                                <dx:ASPxButton ID="ASPxButton1" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="前往登錄" Theme="Aqua">
                                </dx:ASPxButton>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                    <dx:TabPage Text="第4~6批及重大違規及特定工廠登記連線對象之新設業者">
                        <ContentCollection>
                            <dx:ContentControl runat="server">
                                <dx:ASPxRadioButtonList ID="RBL_BATCH_14" runat="server" AutoPostBack="True" Font-Names="微軟正黑體" Font-Size="Large" RepeatDirection="Horizontal" Theme="Aqua">
                                    <Items>
                                        <dx:ListEditItem Text="新增" Value="新增" />
                                        <dx:ListEditItem Text="變更-涉及廠牌、型號之變更" Value="變更-涉及廠牌、型號之變更" />
                                        <dx:ListEditItem Text="變更-其他變更" Value="變更-其他變更" />
                                    </Items>
                                </dx:ASPxRadioButtonList>
                                <dx:ASPxButton ID="ASPxButton2" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="前往登錄" Theme="Aqua">
                                </dx:ASPxButton>
                            </dx:ContentControl>
                        </ContentCollection>
                    </dx:TabPage>
                </TabPages>
                <TabStyle Font-Names="微軟正黑體" Font-Size="Large">
                </TabStyle>
            </dx:ASPxPageControl>
        </asp:View>
        <asp:View ID="View_New" runat="server">
            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="1024px" Font-Names="微軟正黑體" Font-Size="Large" HeaderText="措施說明書/確認報告書搜尋入口" Height="600px" Theme="DevEx">
                        <HeaderImage IconID="find_findbyid_32x32">
                        </HeaderImage>
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <table class="dxeLyGroup_MetropolisBlue">
                                    <tr>
                                        <td width="220">
                                            <dx:ASPxTextBox ID="TB_CNO" runat="server" Caption="請輸入管制編號" Font-Names="微軟正黑體" Font-Size="Medium" Theme="MetropolisBlue" Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            <dx:ASPxButton ID="BT_SUMMIT" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="確定" Theme="MetropolisBlue" Width="100px">
                                            </dx:ASPxButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium">
                                            </dx:ASPxLabel>
                                            <table class="dxeLyGroup_MetropolisBlue">
                                                <tr>
                                                    <td class="auto-style1">
                                                        <dx:ASPxButton ID="BT_NEW" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="新增說明書" Theme="MetropolisBlue" Visible="False" Width="120px">
                                                            <Image IconID="actions_add_16x16">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td>
                                                        <dx:ASPxButton ID="BT_QRY" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="查詢說明書" Theme="MetropolisBlue" Visible="False" Width="120px">
                                                            <Image IconID="actions_editname_16x16">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </dx:PanelContent>
                        </PanelCollection>
                        </dx:ASPxRoundPanel>
            <p>
            </p>
            <br />
        </asp:View>
        <asp:View ID="View_Edit" runat="server">
            
            
            <dx:ASPxGridView ID="GV_SET" runat="server" AutoGenerateColumns="False" Caption="自動監測(視)設施措施說明書總表" DataSourceID="SDS_SET" KeyFieldName="CNO;DOCVERSION" Width="1000px">
                <SettingsBehavior ProcessSelectionChangedOnServer="True" />
                <SettingsSearchPanel ShowClearButton="True" Visible="True" />
                <SettingsText CommandClearSearchPanelFilter="清除" SearchPanelEditorNullText="輸入查詢的關鍵字" />
               <Columns>
                    <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0" Caption=" ">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO" ReadOnly="True" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="版號" FieldName="DOCVERSION" ReadOnly="True" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="事業或污水下水道名稱" FieldName="FAC_NAME" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="建立日期" FieldName="C_DATE" VisibleIndex="9">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="異動日期" FieldName="U_DATE" VisibleIndex="10">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="申請單位" FieldName="REGUNIT" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="類別" FieldName="TYPE" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="事業類別" FieldName="TYPEB" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="污水下水道類別" FieldName="TYPEW" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="說明" FieldName="TYPEDESP" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SDS_SET" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                SelectCommand="SELECT [CNO], [DOCVERSION], [FAC_NAME], [C_DATE], [U_DATE], [REGUNIT], [TYPE], [TYPEB], [TYPEW], [TYPEDESP] FROM [DOC_SET_FACTORY] WHERE ([CNO] = @CNO)" 
                DeleteCommand="DELETE FROM [DOC_SET_FACTORY] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" 
                InsertCommand="INSERT INTO [DOC_SET_FACTORY] ([CNO], [DOCVERSION], [FAC_NAME], [C_DATE], [U_DATE], [REGUNIT], [TYPE], [TYPEB], [TYPEW], [TYPEDESP]) VALUES (@CNO, @DOCVERSION, @FAC_NAME, @C_DATE, @U_DATE, @REGUNIT, @TYPE, @TYPEB, @TYPEW, @TYPEDESP)" 
                UpdateCommand="UPDATE [DOC_SET_FACTORY] SET [FAC_NAME] = @FAC_NAME, [C_DATE] = @C_DATE, [U_DATE] = @U_DATE, [REGUNIT] = @REGUNIT, [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
                <DeleteParameters>
                    <asp:Parameter Name="CNO" Type="String" />
                    <asp:Parameter Name="DOCVERSION" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="CNO" Type="String" />
                    <asp:Parameter Name="DOCVERSION" Type="Int32" />
                    <asp:Parameter Name="FAC_NAME" Type="String" />
                    <asp:Parameter Name="C_DATE" Type="DateTime" />
                    <asp:Parameter Name="U_DATE" Type="DateTime" />
                    <asp:Parameter Name="REGUNIT" Type="String" />
                    <asp:Parameter Name="TYPE" Type="String" />
                    <asp:Parameter Name="TYPEB" Type="String" />
                    <asp:Parameter Name="TYPEW" Type="String" />
                    <asp:Parameter Name="TYPEDESP" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="FAC_NAME" Type="String" />
                    <asp:Parameter Name="C_DATE" Type="DateTime" />
                    <asp:Parameter Name="U_DATE" Type="DateTime" />
                    <asp:Parameter Name="REGUNIT" Type="String" />
                    <asp:Parameter Name="TYPE" Type="String" />
                    <asp:Parameter Name="TYPEB" Type="String" />
                    <asp:Parameter Name="TYPEW" Type="String" />
                    <asp:Parameter Name="TYPEDESP" Type="String" />
                    <asp:Parameter Name="CNO" Type="String" />
                    <asp:Parameter Name="DOCVERSION" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <table class="dxeLyGroup_MetropolisBlue">
                                                <tr>
                                                    <td class="auto-style1">
                                                        <dx:ASPxButton ID="BT_NEW_SET" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="新增措施說明書" Theme="MetropolisBlue" Width="120px">
                                                            <Image IconID="actions_add_16x16">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td>
                                                        <dx:ASPxButton ID="BT_QRY_SET" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="查詢/編輯措施說明書" Theme="MetropolisBlue" Visible="False" Width="120px">
                                                            <Image IconID="actions_editname_16x16">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
            <dx:ASPxGridView ID="GV_VRY" runat="server" AutoGenerateColumns="False" Caption="自動監測(視)設施確認報告書總表" DataSourceID="SDS_VRY" KeyFieldName="CNO;DOCVERSION" Width="1000px">
                <SettingsSearchPanel ShowClearButton="True" Visible="True" />
                <SettingsText CommandClearSearchPanelFilter="清除" SearchPanelEditorNullText="輸入查詢的關鍵字" />
                <Columns>
                    <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" VisibleIndex="0" Caption=" ">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO" ReadOnly="True" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="版號" FieldName="DOCVERSION" ReadOnly="True" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="事業或污水下水道名稱" FieldName="FAC_NAME" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="建立日期" FieldName="C_DATE" VisibleIndex="9">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataDateColumn Caption="異動日期" FieldName="U_DATE" VisibleIndex="10">
                    </dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn Caption="申請單位" FieldName="REGUNIT" VisibleIndex="8">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="類別" FieldName="TYPE" VisibleIndex="4">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="事業類別" FieldName="TYPEB" VisibleIndex="5">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="污水下水道類別" FieldName="TYPEW" VisibleIndex="6">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn Caption="說明" FieldName="TYPEDESP" VisibleIndex="7">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SDS_VRY" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                SelectCommand="SELECT [CNO], [DOCVERSION], [FAC_NAME], [C_DATE], [U_DATE], [REGUNIT], [TYPE], [TYPEB], [TYPEW], [TYPEDESP] FROM [DOC_VRY_FACTORY] WHERE ([CNO] = @CNO)" 
                DeleteCommand="DELETE FROM [DOC_VRY_FACTORY] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" 
                InsertCommand="INSERT INTO [DOC_VRY_FACTORY] ([CNO], [DOCVERSION], [FAC_NAME], [C_DATE], [U_DATE], [REGUNIT], [TYPE], [TYPEB], [TYPEW], [TYPEDESP]) VALUES (@CNO, @DOCVERSION, @FAC_NAME, @C_DATE, @U_DATE, @REGUNIT, @TYPE, @TYPEB, @TYPEW, @TYPEDESP)" 
                UpdateCommand="UPDATE [DOC_VRY_FACTORY] SET [FAC_NAME] = @FAC_NAME, [C_DATE] = @C_DATE, [U_DATE] = @U_DATE, [REGUNIT] = @REGUNIT, [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
                <DeleteParameters>
                    <asp:Parameter Name="CNO" Type="String" />
                    <asp:Parameter Name="DOCVERSION" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="CNO" Type="String" />
                    <asp:Parameter Name="DOCVERSION" Type="Int32" />
                    <asp:Parameter Name="FAC_NAME" Type="String" />
                    <asp:Parameter Name="C_DATE" Type="DateTime" />
                    <asp:Parameter Name="U_DATE" Type="DateTime" />
                    <asp:Parameter Name="REGUNIT" Type="String" />
                    <asp:Parameter Name="TYPE" Type="String" />
                    <asp:Parameter Name="TYPEB" Type="String" />
                    <asp:Parameter Name="TYPEW" Type="String" />
                    <asp:Parameter Name="TYPEDESP" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="FAC_NAME" Type="String" />
                    <asp:Parameter Name="C_DATE" Type="DateTime" />
                    <asp:Parameter Name="U_DATE" Type="DateTime" />
                    <asp:Parameter Name="REGUNIT" Type="String" />
                    <asp:Parameter Name="TYPE" Type="String" />
                    <asp:Parameter Name="TYPEB" Type="String" />
                    <asp:Parameter Name="TYPEW" Type="String" />
                    <asp:Parameter Name="TYPEDESP" Type="String" />
                    <asp:Parameter Name="CNO" Type="String" />
                    <asp:Parameter Name="DOCVERSION" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <table class="dxeLyGroup_MetropolisBlue">
                                                <tr>
                                                    <td class="auto-style1">
                                                        <dx:ASPxButton ID="BT_NEW_VRY" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="新增確認報告書" Theme="MetropolisBlue" Width="120px">
                                                            <Image IconID="actions_add_16x16">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td>
                                                        <dx:ASPxButton ID="BT_QRY_VRY" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="查詢/編輯確認報告書" Theme="MetropolisBlue" Visible="False" Width="120px">
                                                            <Image IconID="actions_editname_16x16">
                                                            </Image>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style1">
                                                        <dx:ASPxButton ID="ASPxButton3" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="回批次選擇頁面" Theme="Aqua">
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                                            DeleteCommand="DELETE FROM [DOC_SET_LP] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" 
                                                            InsertCommand="INSERT INTO [DOC_SET_LP] ([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE], [ITEM1_DATE], [ITEM2_DATE], [ITEM3_DATE], [ITEM4_1_DATE], [ITEM4_2_DATE], [ITEM4_3_DATE], [ITEM4_4_DATE], [ITEM4_5_DATE], [NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DOCVERSION, @SETCOMPANY, @SETPEOPLE, @ITEM1_DATE, @ITEM2_DATE, @ITEM3_DATE, @ITEM4_1_DATE, @ITEM4_2_DATE, @ITEM4_3_DATE, @ITEM4_4_DATE, @ITEM4_5_DATE, @NOTE, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                                                            SelectCommand="SELECT * FROM [DOC_SET_LP]" 
                                                            UpdateCommand="UPDATE [DOC_SET_LP] SET [SETCOMPANY] = @SETCOMPANY, [SETPEOPLE] = @SETPEOPLE, [ITEM1_DATE] = @ITEM1_DATE, [ITEM2_DATE] = @ITEM2_DATE, [ITEM3_DATE] = @ITEM3_DATE, [ITEM4_1_DATE] = @ITEM4_1_DATE, [ITEM4_2_DATE] = @ITEM4_2_DATE, [ITEM4_3_DATE] = @ITEM4_3_DATE, [ITEM4_4_DATE] = @ITEM4_4_DATE, [ITEM4_5_DATE] = @ITEM4_5_DATE, [NOTE] = @NOTE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
                                                            <DeleteParameters>
                                                                <asp:Parameter Name="CNO" Type="String" />
                                                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                                            </DeleteParameters>
                                                            <InsertParameters>
                                                                <asp:Parameter Name="CNO" Type="String" />
                                                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                                                <asp:Parameter Name="SETCOMPANY" Type="String" />
                                                                <asp:Parameter Name="SETPEOPLE" Type="String" />
                                                                <asp:Parameter Name="ITEM1_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM2_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM3_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_1_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_2_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_3_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_4_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_5_DATE" DbType="Date" />
                                                                <asp:Parameter Name="NOTE" Type="String" />
                                                                <asp:Parameter Name="C_ID" Type="String" />
                                                                <asp:Parameter Name="C_DATE" Type="DateTime" />
                                                                <asp:Parameter Name="U_ID" Type="String" />
                                                                <asp:Parameter Name="U_DATE" Type="DateTime" />
                                                            </InsertParameters>
                                                            <UpdateParameters>
                                                                <asp:Parameter Name="SETCOMPANY" Type="String" />
                                                                <asp:Parameter Name="SETPEOPLE" Type="String" />
                                                                <asp:Parameter Name="ITEM1_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM2_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM3_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_1_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_2_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_3_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_4_DATE" DbType="Date" />
                                                                <asp:Parameter Name="ITEM4_5_DATE" DbType="Date" />
                                                                <asp:Parameter Name="NOTE" Type="String" />
                                                                <asp:Parameter Name="C_ID" Type="String" />
                                                                <asp:Parameter Name="C_DATE" Type="DateTime" />
                                                                <asp:Parameter Name="U_ID" Type="String" />
                                                                <asp:Parameter Name="U_DATE" Type="DateTime" />
                                                                <asp:Parameter Name="CNO" Type="String" />
                                                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                                            </UpdateParameters>
                                                        </asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                            </table>
        </asp:View>
    </asp:MultiView>
    <br />
    <br />
    </asp:Content>

