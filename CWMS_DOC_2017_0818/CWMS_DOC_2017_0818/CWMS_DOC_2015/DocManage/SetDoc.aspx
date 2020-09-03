<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.DocManage_SetDoc" Codebehind="SetDoc.aspx.vb" %>

<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2
        {
            height: 16px;
        }
        .auto-style3
        {
            height: 55px;
        }
        .auto-style4
        {
            height: 74px;
        }
        .auto-style5
        {
            height: 22px;
        }
        .auto-style6
        {
            height: 43px;
        }
        .auto-style7
        {
            height: 43px;
            width: 118px;
        }
        .auto-style8
        {
        }
        .auto-style9
        {
            width: 437px;
        }
        .auto-style10
        {
            width: 202px;
        }
        .auto-style11
        {
            width: 143px;
        }
        .auto-style12
        {
            width: 136px;
        }
        .auto-style13
        {
            width: 80px;
        }
        .auto-style14
        {
            width: 72px;
        }
        .auto-style15
        {
            width: 41px;
        }
        .auto-style16
        {
            height: 24px;
        }
        .auto-style17
        {
            height: 23px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <dx:ASPxPanel ID="ASPxPanel3" runat="server" BackColor="#0099CC" Font-Names="微軟正黑體" Font-Size="Large" height="40px" ForeColor="White"  Width="1024px">
        <PanelCollection>
<dx:PanelContent ID="PanelContent1" runat="server">&nbsp;自動監測(視)及連線傳輸措施說明書</dx:PanelContent>
</PanelCollection>
    </dx:ASPxPanel>
    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="1" EnableTheming="True" Height="1800px" Theme="Office2003Blue" Width="1024px" Font-Names="微軟正黑體" Font-Size="Medium">
        <tabpages>
            <dx:TabPage Text="基本資料">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <contentcollection>
                    <dx:ContentControl runat="server">
                        <br />
                        <table style="width:100%;" border="1">
                            <tr>

                                <td class="auto-style10" valign="top" rowspan="2">
                                    <asp:RadioButtonList ID="RBL_BAS_TYPE" runat="server" Width="440px" AutoPostBack="True" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <asp:ListItem>事業</asp:ListItem>
                                        <asp:ListItem>污水下水道</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td width="200">
                                    <asp:RadioButtonList ID="RBL_BAS_TYPEB" runat="server" RepeatDirection="Horizontal" Width="400px" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <asp:ListItem>核准許可廢(污)水排放量達設置規模者</asp:ListItem>
                                        <asp:ListItem>發電廠</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                            </tr>
                            <tr>
                                <td width="200">
                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" Width="700px" ID="RBL_BAS_TYPEW" Font-Names="微軟正黑體" Font-Size="Medium"><asp:ListItem>公共污水下水道系統</asp:ListItem>
<asp:ListItem>工業區專用污水下水道系統</asp:ListItem>
<asp:ListItem>指定地區或場所專用之污水下水道系統</asp:ListItem>
</asp:RadioButtonList>

                                </td>
                            </tr>                            
                        </table>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <p>
                        </p>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style7">
                                    <dx:ASPxLabel ID="ASPxLabel40" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="申請單位名稱:">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style6">
                                    <dx:ASPxTextBox ID="TB_BAS_REGUNIT" runat="server" Width="400px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                        <p>
                        </p>
                        <table style="width:100%;" border="1">                            
                            <tr>
                                <td width="160" colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="事業或污染下水道系統名稱:" Width="160px">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_NAME" runat="server" Width="400px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="管制編號:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CNO" runat="server" MaxLength="8" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="聯絡人姓名:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CNAME" runat="server" MaxLength="20" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="聯絡電話:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CTEL" runat="server" Width="170px">
                                        <MaskSettings Mask="(999) 000-0000" />
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="行動電話:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CMOBILE" runat="server" Width="170px">
                                        <MaskSettings Mask="(999) 000-0000" />
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="傳真電話:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CFAX" runat="server" Width="170px">
                                        <MaskSettings Mask="(999) 000-0000" />
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="電子郵件地址:">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style5">
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CEMAIL" runat="server" Width="400px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="申請日期:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_REGDATE" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td width="80">
                                    <dx:ASPxButton ID="BT_BASIC_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton2" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <br />
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_SET_FACTORY] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" 
                            InsertCommand="INSERT INTO [DOC_SET_FACTORY] ([TYPE], [TYPEB], [TYPEW], [TYPEDESP], [CNO], [DOCVERSION], [REGUNIT], [FAC_NAME], [FAC_CNAME], [FAC_CTEL], [FAC_CMOBILE], [FAC_CFAX], [FAC_CEMAIL], [REG_DATE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@TYPE, @TYPEB, @TYPEW, @TYPEDESP, @CNO, @DOCVERSION, @REGUNIT, @FAC_NAME, @FAC_CNAME, @FAC_CTEL, @FAC_CMOBILE, @FAC_CFAX, @FAC_CEMAIL, @REG_DATE, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                            SelectCommand="SELECT * FROM [DOC_SET_FACTORY]" 
                            UpdateCommand="UPDATE [DOC_SET_FACTORY] SET [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP, [REGUNIT] = @REGUNIT, [FAC_NAME] = @FAC_NAME, [FAC_CNAME] = @FAC_CNAME, [FAC_CTEL] = @FAC_CTEL, [FAC_CMOBILE] = @FAC_CMOBILE, [FAC_CFAX] = @FAC_CFAX, [FAC_CEMAIL] = @FAC_CEMAIL, [REG_DATE] = @REG_DATE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
                            <DeleteParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="TYPE" Type="String" />
                                <asp:Parameter Name="TYPEB" Type="String" />
                                <asp:Parameter Name="TYPEW" Type="String" />
                                <asp:Parameter Name="TYPEDESP" Type="String" />
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                <asp:Parameter Name="REGUNIT" Type="String" />
                                <asp:Parameter Name="FAC_NAME" Type="String" />
                                <asp:Parameter Name="FAC_CNAME" Type="String" />
                                <asp:Parameter Name="FAC_CTEL" Type="String" />
                                <asp:Parameter Name="FAC_CMOBILE" Type="String" />
                                <asp:Parameter Name="FAC_CFAX" Type="String" />
                                <asp:Parameter Name="FAC_CEMAIL" Type="String" />
                                <asp:Parameter Name="REG_DATE" DbType="Date" />
                                <asp:Parameter Name="C_ID" Type="String" />
                                <asp:Parameter Name="C_DATE" Type="DateTime" />
                                <asp:Parameter Name="U_ID" Type="String" />
                                <asp:Parameter Name="U_DATE" Type="DateTime" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="TYPE" Type="String" />
                                <asp:Parameter Name="TYPEB" Type="String" />
                                <asp:Parameter Name="TYPEW" Type="String" />
                                <asp:Parameter Name="TYPEDESP" Type="String" />
                                <asp:Parameter Name="REGUNIT" Type="String" />
                                <asp:Parameter Name="FAC_NAME" Type="String" />
                                <asp:Parameter Name="FAC_CNAME" Type="String" />
                                <asp:Parameter Name="FAC_CTEL" Type="String" />
                                <asp:Parameter Name="FAC_CMOBILE" Type="String" />
                                <asp:Parameter Name="FAC_CFAX" Type="String" />
                                <asp:Parameter Name="FAC_CEMAIL" Type="String" />
                                <asp:Parameter Name="REG_DATE" DbType="Date" />
                                <asp:Parameter Name="C_ID" Type="String" />
                                <asp:Parameter Name="C_DATE" Type="DateTime" />
                                <asp:Parameter Name="U_ID" Type="String" />
                                <asp:Parameter Name="U_DATE" Type="DateTime" />
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <dx:ASPxLabel ID="LABEL_BAS" runat="server">
                        </dx:ASPxLabel>
                        <br />
                        <dx:ASPxRadioButtonList ID="RBL_SETCHANGE" runat="server" RepeatDirection="Horizontal" SelectedIndex="0" AutoPostBack="True">
                            <Items>
                                <dx:ListEditItem Selected="True" Text="設置" Value="設置" />
                                <dx:ListEditItem Text="變更" Value="變更" />
                            </Items>
                        </dx:ASPxRadioButtonList>
                        <br />
                        <dx:ASPxLabel ID="Label_DocVersion" runat="server">
                        </dx:ASPxLabel>
                        <dx:ASPxGridView ID="GV_SETITEM" runat="server" AutoGenerateColumns="False" Caption="設置自動監測(視)設施位置及種類(可複選，列次不足者請自行增列填寫)" DataSourceID="SDS_ITEM" KeyFieldName="CNO" Width="800px">
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO"  ShowInCustomizationForm="True" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="版號" FieldName="DOCVERSION" ShowInCustomizationForm="True" VisibleIndex="4" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="文件種類" FieldName="DOCTYPE" ShowInCustomizationForm="True" VisibleIndex="5" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="水量計" FieldName="ITEM_248" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="水溫" FieldName="ITEM_259" ShowInCustomizationForm="True" VisibleIndex="7">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="pH" FieldName="ITEM_246" ShowInCustomizationForm="True" VisibleIndex="8">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="導電度" FieldName="ITEM_247" ShowInCustomizationForm="True" VisibleIndex="9">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="COD" FieldName="ITEM_243" ShowInCustomizationForm="True" VisibleIndex="10">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="SS" FieldName="ITEM_210" ShowInCustomizationForm="True" VisibleIndex="11">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="攝錄影監視" FieldName="ITEM_VIDEO" ShowInCustomizationForm="True" VisibleIndex="12">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="氨氮" FieldName="ITEM_242" ShowInCustomizationForm="True" VisibleIndex="13">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="其他" FieldName="ITEM_OTHER" ShowInCustomizationForm="True" VisibleIndex="14">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn Caption="監測點" FieldName="DP_NO" ShowInCustomizationForm="True" VisibleIndex="2"  >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn Caption="位置種類" FieldName="DPTYPE" ShowInCustomizationForm="True" VisibleIndex="3">
                                    <PropertiesComboBox>
                                        <Items>
                                            <dx:ListEditItem Text="進流" Value="進流" />
                                            <dx:ListEditItem Text="放流" Value="放流" />
                                            <dx:ListEditItem Text="處理單元(進流)" Value="處理單元(進流)" />
                                            <dx:ListEditItem Text="處理單元(出流)" Value="處理單元(出流)" />
                                            <dx:ListEditItem Text="雨水放流" Value="雨水放流" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="True" ProcessFocusedRowChangedOnServer="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridView ID="GV_CHANGEITEM" runat="server" AutoGenerateColumns="False" Caption="變更設置自動監測(視)設施位置及種類(可複選，列次不足者請自行增列填寫)（非屬變更者免填）" DataSourceID="sds_item_c" KeyFieldName="CNO" Width="800px">
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO"  ShowInCustomizationForm="True" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="監測點" FieldName="DP_NO"  ShowInCustomizationForm="True" VisibleIndex="2" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="版號" FieldName="DOCVERSION" ShowInCustomizationForm="True" VisibleIndex="4" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="文件種類" FieldName="DOCTYPE" ShowInCustomizationForm="True" VisibleIndex="5" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="水量計" FieldName="ITEM_248" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="水溫" FieldName="ITEM_259" ShowInCustomizationForm="True" VisibleIndex="7">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="pH" FieldName="ITEM_246" ShowInCustomizationForm="True" VisibleIndex="8">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="導電度" FieldName="ITEM_247" ShowInCustomizationForm="True" VisibleIndex="9">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="COD" FieldName="ITEM_243" ShowInCustomizationForm="True" VisibleIndex="10">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="SS" FieldName="ITEM_210" ShowInCustomizationForm="True" VisibleIndex="11">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="攝錄影監視" FieldName="ITEM_VIDEO" ShowInCustomizationForm="True" VisibleIndex="12">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="氨氮" FieldName="ITEM_242" ShowInCustomizationForm="True" VisibleIndex="13">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="其他" FieldName="ITEM_OTHER" ShowInCustomizationForm="True" VisibleIndex="14">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataComboBoxColumn Caption="位置種類" FieldName="DPTYPE" ShowInCustomizationForm="True" VisibleIndex="3">
                                    <PropertiesComboBox>
                                        <Items>
                                            <dx:ListEditItem Text="進流" Value="進流" />
                                            <dx:ListEditItem Text="放流" Value="放流" />
                                            <dx:ListEditItem Text="處理單元(進流)" Value="處理單元(進流)" />
                                            <dx:ListEditItem Text="處理單元(出流)" Value="處理單元(出流)" />
                                            <dx:ListEditItem Text="雨水放流" Value="雨水放流" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="sds_item_c" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                            DeleteCommand="DELETE FROM [DOC_SET_ITEM] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" 
                            InsertCommand="INSERT INTO [DOC_SET_ITEM] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [DOCTYPE], [ITEM_248], [ITEM_259], [ITEM_246], [ITEM_247], [ITEM_243], [ITEM_210], [ITEM_VIDEO], [ITEM_242], [ITEM_OTHER], [OTHER_DESP], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @DOCTYPE, @ITEM_248, @ITEM_259, @ITEM_246, @ITEM_247, @ITEM_243, @ITEM_210, @ITEM_VIDEO, @ITEM_242, @ITEM_OTHER, @OTHER_DESP, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                            SelectCommand="SELECT * FROM [DOC_SET_ITEM] WHERE (([CNO] = @CNO) AND ([DOCTYPE] = @DOCTYPE))" 
                            UpdateCommand="UPDATE [DOC_SET_ITEM] SET [ITEM_248] = @ITEM_248, [ITEM_259] = @ITEM_259, [ITEM_246] = @ITEM_246, [ITEM_247] = @ITEM_247, [ITEM_243] = @ITEM_243, [ITEM_210] = @ITEM_210, [ITEM_VIDEO] = @ITEM_VIDEO, [ITEM_242] = @ITEM_242, [ITEM_OTHER] = @ITEM_OTHER, [OTHER_DESP] = @OTHER_DESP, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">
                            <DeleteParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                <asp:Parameter Name="DOCTYPE" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                <asp:Parameter Name="DOCTYPE" Type="String" />
                                <asp:Parameter Name="ITEM_248" Type="String" />
                                <asp:Parameter Name="ITEM_259" Type="String" />
                                <asp:Parameter Name="ITEM_246" Type="String" />
                                <asp:Parameter Name="ITEM_247" Type="String" />
                                <asp:Parameter Name="ITEM_243" Type="String" />
                                <asp:Parameter Name="ITEM_210" Type="String" />
                                <asp:Parameter Name="ITEM_VIDEO" Type="String" />
                                <asp:Parameter Name="ITEM_242" Type="String" />
                                <asp:Parameter Name="ITEM_OTHER" Type="String" />
                                <asp:Parameter Name="OTHER_DESP" Type="String" />
                                <asp:Parameter Name="C_ID" Type="String" />
                                <asp:Parameter Name="C_DATE" Type="DateTime" />
                                <asp:Parameter Name="U_ID" Type="String" />
                                <asp:Parameter Name="U_DATE" Type="DateTime" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                <asp:Parameter DefaultValue="變更" Name="DOCTYPE" Type="String" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ITEM_248" Type="String" />
                                <asp:Parameter Name="ITEM_259" Type="String" />
                                <asp:Parameter Name="ITEM_246" Type="String" />
                                <asp:Parameter Name="ITEM_247" Type="String" />
                                <asp:Parameter Name="ITEM_243" Type="String" />
                                <asp:Parameter Name="ITEM_210" Type="String" />
                                <asp:Parameter Name="ITEM_VIDEO" Type="String" />
                                <asp:Parameter Name="ITEM_242" Type="String" />
                                <asp:Parameter Name="ITEM_OTHER" Type="String" />
                                <asp:Parameter Name="OTHER_DESP" Type="String" />
                                <asp:Parameter Name="C_ID" Type="String" />
                                <asp:Parameter Name="C_DATE" Type="DateTime" />
                                <asp:Parameter Name="U_ID" Type="String" />
                                <asp:Parameter Name="U_DATE" Type="DateTime" />
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                <asp:Parameter Name="DOCTYPE" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SDS_ITEM" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                            DeleteCommand="DELETE FROM [DOC_SET_ITEM] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" 
                            InsertCommand="INSERT INTO [DOC_SET_ITEM] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [DOCTYPE], [ITEM_248], [ITEM_259], [ITEM_246], [ITEM_247], [ITEM_243], [ITEM_210], [ITEM_VIDEO], [ITEM_242], [ITEM_OTHER], [OTHER_DESP], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @DOCTYPE, @ITEM_248, @ITEM_259, @ITEM_246, @ITEM_247, @ITEM_243, @ITEM_210, @ITEM_VIDEO, @ITEM_242, @ITEM_OTHER, @OTHER_DESP, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                            SelectCommand="SELECT * FROM [DOC_SET_ITEM] WHERE (([CNO] = @CNO) AND ([DOCTYPE] = @DOCTYPE))" 
                            UpdateCommand="UPDATE [DOC_SET_ITEM] SET [ITEM_248] = @ITEM_248, [ITEM_259] = @ITEM_259, [ITEM_246] = @ITEM_246, [ITEM_247] = @ITEM_247, [ITEM_243] = @ITEM_243, [ITEM_210] = @ITEM_210, [ITEM_VIDEO] = @ITEM_VIDEO, [ITEM_242] = @ITEM_242, [ITEM_OTHER] = @ITEM_OTHER, [OTHER_DESP] = @OTHER_DESP, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">
                            <DeleteParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                <asp:Parameter Name="DOCTYPE" Type="String" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                <asp:Parameter Name="DOCTYPE" Type="String" />
                                <asp:Parameter Name="ITEM_248" Type="String" />
                                <asp:Parameter Name="ITEM_259" Type="String" />
                                <asp:Parameter Name="ITEM_246" Type="String" />
                                <asp:Parameter Name="ITEM_247" Type="String" />
                                <asp:Parameter Name="ITEM_243" Type="String" />
                                <asp:Parameter Name="ITEM_210" Type="String" />
                                <asp:Parameter Name="ITEM_VIDEO" Type="String" />
                                <asp:Parameter Name="ITEM_242" Type="String" />
                                <asp:Parameter Name="ITEM_OTHER" Type="String" />
                                <asp:Parameter Name="OTHER_DESP" Type="String" />
                                <asp:Parameter Name="C_ID" Type="String" />
                                <asp:Parameter Name="C_DATE" Type="DateTime" />
                                <asp:Parameter Name="U_ID" Type="String" />
                                <asp:Parameter Name="U_DATE" Type="DateTime" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                <asp:Parameter DefaultValue="設置" Name="DOCTYPE" Type="String" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ITEM_248" Type="String" />
                                <asp:Parameter Name="ITEM_259" Type="String" />
                                <asp:Parameter Name="ITEM_246" Type="String" />
                                <asp:Parameter Name="ITEM_247" Type="String" />
                                <asp:Parameter Name="ITEM_243" Type="String" />
                                <asp:Parameter Name="ITEM_210" Type="String" />
                                <asp:Parameter Name="ITEM_VIDEO" Type="String" />
                                <asp:Parameter Name="ITEM_242" Type="String" />
                                <asp:Parameter Name="ITEM_OTHER" Type="String" />
                                <asp:Parameter Name="OTHER_DESP" Type="String" />
                                <asp:Parameter Name="C_ID" Type="String" />
                                <asp:Parameter Name="C_DATE" Type="DateTime" />
                                <asp:Parameter Name="U_ID" Type="String" />
                                <asp:Parameter Name="U_DATE" Type="DateTime" />
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                <asp:Parameter Name="DOCTYPE" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <div>
                            <table style="width:100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" width="80">
                                        <dx:ASPxButton ID="ASPxButton8" runat="server" Text="選定資料" Width="80px">
                                        </dx:ASPxButton>
                                    </td>
                                    <td class="auto-style2">
                                        <dx:ASPxButton ID="ASPxButton10" runat="server" Text="列印" Visible="False" Width="80px">
                                        </dx:ASPxButton>
                                    </td>
                                    <td class="auto-style2"></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </dx:ContentControl>
                </contentcollection>
            </dx:TabPage>
            <dx:TabPage Text="自動監測(視)設施規劃說明">
                <contentcollection>
                    <dx:ContentControl runat="server">
                        <br />
                        <dx:ASPxGridView ID="GV_SPEC" runat="server" Caption="自動監測(視)設施資料總表" Width="600px" AutoGenerateColumns="False" DataSourceID="SDS_SPEC" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION;ITEM">
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Visible ="false"  >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DP_NO" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Visible ="false" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DPTYPE" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="3" Caption="種類">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="4" Visible="False">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ITEM" ShowInCustomizationForm="True" VisibleIndex="5" ReadOnly="True" Caption="監測項目">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DPNO_DESP" ShowInCustomizationForm="True" VisibleIndex="6" Caption="位置">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <dx:ASPxButton ID="ASPxButton9" runat="server" Text="取得資料" Width="80px">
                        </dx:ASPxButton>
                        <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="800px">
                            <panelcollection>
                                <dx:PanelContent runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="auto-style9">
                                                <dx:ASPxRadioButtonList ID="RBL_SPEC_DPNO" runat="server" RepeatDirection="Horizontal">
                                                    <Items>
                                                        <dx:ListEditItem Text="進流" Value="進流" />
                                                        <dx:ListEditItem Text="放流" Value="放流" />
                                                        <dx:ListEditItem Text="處理單元(進流)" Value="處理單元(進流)" />
                                                        <dx:ListEditItem Text="處理單元(出流)" Value="處理單元(出流)" />
                                                        <dx:ListEditItem Text="雨水放流" Value="雨水放流" />
                                                    </Items>
                                                </dx:ASPxRadioButtonList>
                                            </td>
                                            <td class="auto-style8">
                                                <dx:ASPxLabel ID="ASPxLabel41" runat="server" Text="位置編號">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="TB_SPEC_DPNODESP" runat="server" Width="170px">
                                                </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <p>
                                    </p>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <dx:ASPxRadioButtonList ID="RBL_SPEC_DPNOITEM" runat="server" RepeatDirection="Horizontal" Width="500px">
                                                    <Items>
                                                        <dx:ListEditItem Text="水量" Value="248" />
                                                        <dx:ListEditItem Text="水溫" Value="259" />
                                                        <dx:ListEditItem Text="pH" Value="246" />
                                                        <dx:ListEditItem Text="導電度" Value="247" />
                                                        <dx:ListEditItem Text="COD" Value="243" />
                                                        <dx:ListEditItem Text="SS" Value="210" />
                                                        <dx:ListEditItem Text="攝錄影監視" Value="310" />
                                                        <dx:ListEditItem Text="氨氮" Value="242" />
                                                        <dx:ListEditItem Text="其他" Value="其他" />
                                                    </Items>
                                                </dx:ASPxRadioButtonList>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="TB_SPEC_DPNODESP0" runat="server" Width="170px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </panelcollection>
                        </dx:ASPxPanel>
                        <br />
                        <table style="width:100%;" border="1">
                            <tr>
                                <td class="auto-style2" width="250">
                                    <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="(一)本監測設施是否為報經主管機關核准採行之替代措施">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style2" colspan="2" width="300">
                                    <asp:RadioButtonList ID="RBL_SPEC_INSTEAD" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>是</asp:ListItem>
                                        <asp:ListItem Selected="True">否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="auto-style2" colspan="8">
                                    <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="385px">
                                        <PanelCollection>
                                            <dx:PanelContent runat="server">
                                                主管機關核准公文影本見附件&nbsp;
                                                <dx:ASPxUploadControl ID="AUC_1" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                                    <BrowseButton Text="選擇">
                                                    </BrowseButton>
                                                    <UploadButton Text="上傳">
                                                    </UploadButton>
                                                    <CancelButton Text="取消">
                                                    </CancelButton>
                                                </dx:ASPxUploadControl>
                                            </dx:PanelContent>
                                        </PanelCollection>
                                    </dx:ASPxPanel>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="(二)本監測設施是否同時監測其他位置">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="RBL_SPEC_MONITOROTHER" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>是</asp:ListItem>
                                        <asp:ListItem Selected="True">否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>與位置編號:
                                </td>
                                <td class="auto-style15" colspan="2"><dx:ASPxTextBox ID="TB_SPEC_MO_NOTE_DPNO" runat="server" Width="40px" MaxLength ="10">
                                    </dx:ASPxTextBox></td>
                                <td colspan="2">共設</td>
                                <td colspan="2" width="40"><dx:ASPxTextBox ID="TB_SPEC_MO_NOTE_DPNO1" runat="server" Width="40px" MaxLength ="10">
                                    </dx:ASPxTextBox></td>
                                <td>處</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                                <td colspan="8">
                                    <dx:ASPxUploadControl ID="AUC_2" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="(三)預定安裝日期">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="10">
                                    <dx:ASPxDateEdit ID="TB_SPEC_INS_DATE" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="(四)監測設施之製造商或代理商">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="10">
                                    <dx:ASPxTextBox ID="TB_SPEC_AGENTNAME" runat="server" Width="250px" MaxLength ="50">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="(五)型號" >
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="10">
                                    <dx:ASPxTextBox ID="TB_SPEC_EQU_MODEL" runat="server" Width="250px" MaxLength="25">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="(六)序號(無則免填)">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="10">
                                    <dx:ASPxTextBox ID="TB_SPEC_EQU_SERIAL" runat="server" Width="250px" MaxLength="50">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3" rowspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="(七)量測方式(分析方法)">
                                    </dx:ASPxLabel>
                                </td>
                                <td rowspan="2" colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_SAMPLE_METHOD" runat="server" Width="250px" MaxLength="25">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="6">
                                    <dx:ASPxCheckBox ID="CB_SPEC_SAMPLE_METHOD_FilterYes" runat="server" CheckState="Unchecked" Text="有過濾器/前處理裝置，影響說明" AllowGrayed="True">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxUploadControl ID="AUC_7" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <dx:ASPxCheckBox ID="CB_SPEC_SAMPLE_METHOD_FilterNo" runat="server" CheckState="Unchecked" Text="無過濾器/前處理裝置">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="(八)校正器材">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="10">
                                    <dx:ASPxTextBox ID="TB_SPEC_CALC_EQU" runat="server" Width="250px" MaxLength="50">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="(九)校正周期">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_CALC_FREQ" runat="server" Width="250px" MaxLength="20">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="8">
                                    <asp:RadioButtonList ID="RBL_SPEC_CALC_FREQMETHOD" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">擬自行校正</asp:ListItem>
                                        <asp:ListItem>擬委外校正</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel15" runat="server" Text="(十)維護周期">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_MAIN_FREQ" runat="server" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="8">
                                    <asp:RadioButtonList ID="RBL_SPEC_MAIN_FREQMETHOD" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>擬自行保養</asp:ListItem>
                                        <asp:ListItem Selected="True">擬委外保養</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="(十一)耗材內容">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" rowspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_MATERIAL" runat="server" Width="250px" MaxLength="15">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="6">
                                    <asp:RadioButtonList ID="RBL_SPEC__WASTELIQUID" runat="server">
                                        <asp:ListItem Selected="True">無產生廢液(材)</asp:ListItem>
                                        <asp:ListItem>有產生廢液(材)</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td colspan="2">儲存清理方式說明(詳附件)
                                    </td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <dx:ASPxUploadControl ID="AUC_11" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="(十二)耗材應更換頻率">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="10">
                                    <dx:ASPxTextBox ID="TB_SPEC_MATERIAL_FREQ" runat="server" Width="170px" MaxLength="10">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style16">
                                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="(十三)量測範圍">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" class="auto-style16">
                                    <dx:ASPxTextBox ID="TB_SPEC_MEA_SCOPE" runat="server" Width="170px" MaxLength="15">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="8" class="auto-style16">
                                    <dx:ASPxTextBox ID="TB_SPEC_MEA_SCOPEUNIT" runat="server" Width="170px" MaxLength="10">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="(十四)應答時間(儀器每次取樣至完成分析所需之時間)">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_MEA_RESTIME" runat="server" Width="170px" MaxLength="5">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="2" width="40">
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_MEA_RESTIMEUNIT" runat="server" MaxLength="10" Width="50px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="2">&nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel20" runat="server" Text="(十五)量測周期(每次監測數據產生之時間間隔)">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_MEA_FREQ" runat="server" Width="170px" MaxLength="5">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox runat="server" Width="50px" MaxLength="10" ID="TB_SPEC_MEA_FREQUNIT"></dx:ASPxTextBox>

                                </td>
                                <td colspan="2">&nbsp;</td>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel21" runat="server" Text="(十六)監測紀錄值為幾個等時距監測數據之算術平均值">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="10">
                                    <dx:ASPxTextBox ID="TB_SPEC_CALCAVG" runat="server" Width="170px" MaxLength="5">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4" rowspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="(十七)補充說明及相關證明文件影本">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxCheckBox ID="CB_DOC_Instead" runat="server" CheckState="Unchecked" Text="需核准採行替代措施之具體說明(詳附件" AutoPostBack="True" ></dx:ASPxCheckBox>
                                </td>
                                <td colspan="8">

                                    <dx:ASPxUploadControl ID="AUC_17A" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxCheckBox ID="CB_DOC_Cali" runat="server" CheckState="Unchecked" Text="設施製造商校正方式及周期說明(詳附件" AutoPostBack="True">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td colspan="8">
                                    <dx:ASPxUploadControl ID="AUC_17B" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4" rowspan="3">
                                    <dx:ASPxLabel ID="ASPxLabel44" runat="server" Text="(十八)攝錄影設施規格">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel45" runat="server" Text="影像格式:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="4">

                                    <asp:RadioButtonList ID="RBL_VIDEO_F" runat="server" RepeatDirection="Horizontal" Width="194px">
                                        <asp:ListItem Selected="True">MPEG</asp:ListItem>
                                        <asp:ListItem>H264</asp:ListItem>
                                        <asp:ListItem>AVI</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:RadioButtonList>

                                </td>
                                <td colspan="4">
                                    <dx:ASPxTextBox ID="TB_VIDEO_F" runat="server" Width="170px" Caption ="其他說明">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Text="解析度:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="4">
                                    <asp:RadioButtonList ID="RBL_VIDEO_R" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">640X480</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td colspan="4">
                                    <dx:ASPxTextBox ID="TB_VIDEO_R" runat="server" Caption="其他說明" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="夜視功能:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="4">
                                    <asp:RadioButtonList ID="RBL_VIDEO_NV" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">有</asp:ListItem>
                                        <asp:ListItem>無</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td colspan="4">
                                    <dx:ASPxTextBox ID="TB_VIDEO_NV" runat="server" Caption="其他說明" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td></td>
                            </tr>
                             <tr>
                                <td>
                                    (十九)輸出訊號格式</td>
                                <td>
                                    <dx:ASPxCheckBox ID="CB_19_Analog" runat="server" CheckState="Unchecked" Text="類比訊號" AutoPostBack="True"></dx:ASPxCheckBox>
                                 </td>
                                 <td colspan="9">
                                    
                                     <asp:DropDownList ID="DDL_19_Analog" runat="server" Width="120px">
                                         <asp:ListItem>4~20mA</asp:ListItem>
                                     </asp:DropDownList>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td> </td>
                                 <td colspan="2">
                                    <dx:ASPxCheckBox ID="CB_19_Digital" runat="server" CheckState="Unchecked" Text="數位訊號" AutoPostBack="True"></dx:ASPxCheckBox>
                                </td>
                                <td colspan="8">                                    
                                    <dx:ASPxTextBox ID="TB_19_DIGTAL" runat="server" Width="170px"></dx:ASPxTextBox>                                    

                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <dx:ASPxCheckBox ID="CB_DO_HARDWARE_CONNECT" runat="server" AutoPostBack="True" CheckState="Unchecked" Text="該數位介面之硬體連接方法說明">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td colspan="8">
                                    <dx:ASPxUploadControl ID="AUC_19A" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <dx:ASPxCheckBox ID="CB_DO_HARDWARE_CONNPARA" runat="server" AutoPostBack="True" CheckState="Unchecked" Text="該數位設備之連接參數資料">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td colspan="8">
                                    <dx:ASPxUploadControl ID="AUC_19B" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <dx:ASPxCheckBox ID="CB_DO_HARDWARE_DOC" runat="server" AutoPostBack="True" CheckState="Unchecked" Text="引用此介面之相關功能文件">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td colspan="8">
                                    <dx:ASPxUploadControl ID="AUC_19C" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                                <td colspan="8">&nbsp;</td>
                            </tr>
                        </table>
                       
                        <p>
                        </p>
                        <table border="1" style="width:100%;">
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="(一)I/O模組或PLC廠牌">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_PLCAGENT" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="(二)使用之通訊規格" Width="200px">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style13" colspan="2">
                                    <asp:RadioButtonList ID="RBL_SPEC_COSPEC" runat="server" Width="180px">
                                        <asp:ListItem Selected="True">Modbus TCP</asp:ListItem>
                                        <asp:ListItem>Modbus RTU</asp:ListItem>
                                        <asp:ListItem>RS-232</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <dx:ASPxTextBox ID="TB_SPEC_H_CHANGE_NOTE0" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="(三)監測數據、訊號是否可經由人工異動">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RBL_SPEC_H_CHANGE" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">否</asp:ListItem>
                                        <asp:ListItem>可</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_SPEC_H_CHANGE_NOTE" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                       
                        <p>
                        </p>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style14">
                                    <dx:ASPxButton ID="BT_SPEC_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton7" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxLabel ID="Label_SPEC" runat="server">
                                    </dx:ASPxLabel>
                                    <asp:SqlDataSource ID="SDS_SPEC" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        DeleteCommand="DELETE FROM [DOC_SET_SPEC] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM" 
                                        InsertCommand="INSERT INTO [DOC_SET_SPEC] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD], [SPEC_MONITOROTHER], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM, @DPNO_DESP, @SPEC_INSTEAD, @SPEC_MONITOROTHER, @SPEC_MO_NOTE_DPNO, @SPEC_MO_NOTE_DPNO1, @SPEC_MO_NOTE_QUA, @SPEC_INS_DATE, @SPEC_AGENTNAME, @SPEC_EQU_MODEL, @SPEC_EQU_SERIAL, @SPEC_SAMPLE_METHOD, @SPEC_SAMPLE_METHOD_FILTERYES, @SPEC_SAMPLE_METHOD_FILTERNO, @SPEC_CALC_EQU, @SPEC_CALC_FREQ, @SPEC_CALC_METHOD, @SPEC_MAIN_FREQ, @SPEC_MAIN_METHOD, @SPEC_MATERIAL, @SPEC_WASTELIQUID, @SPEC_MATERIAL_FREQ, @SPEC_MEA_SCOPE, @SPEC_MEA_SCOPEUNIT, @SPEC_MEA_RESTIME, @SPEC_MEA_RESTIMEUNIT, @SPEC_MEA_FREQ, @SPEC_MEA_FREQUNIT, @SPEC_CALCAVG, @SPEC_DOCATTACH_INST, @SPEC_DOCATTACH_CALI, @SPEC_VIDEO_F, @SPEC_VIDEO_F_MEMO, @SPEC_VIDEO_R, @SPEC_VIDEO_R_MEMO, @SPEC_VIDEO_NV, @SPEC_VIDEO_NV_MEMO, @SPEC_ANASIG_YES, @SPEC_ANASIG, @SPEC_DIGSIG_YES, @SPEC_DIGSIG, @SPEC_DO_HARDWARE_CONNECT, @SPEC_DO_HARDWARE_CONNPARA, @SPEC_DO_HARDWARE_DOC, @SPEC_PLCAGENT, @SPEC_COSPEC, @SPEC_H_CHANGE, @SPEC_H_CHANGE_NOTE, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                                        SelectCommand="SELECT * FROM [DOC_SET_SPEC] WHERE (([CNO] = @CNO) AND ([DP_NO] = @DP_NO) AND ([DOCVERSION] = @DOCVERSION))" 
                                        UpdateCommand="UPDATE [DOC_SET_SPEC] SET [DPNO_DESP] = @DPNO_DESP, [SPEC_INSTEAD] = @SPEC_INSTEAD, [SPEC_MONITOROTHER] = @SPEC_MONITOROTHER, [SPEC_MO_NOTE_DPNO] = @SPEC_MO_NOTE_DPNO, [SPEC_MO_NOTE_DPNO1] = @SPEC_MO_NOTE_DPNO1, [SPEC_MO_NOTE_QUA] = @SPEC_MO_NOTE_QUA, [SPEC_INS_DATE] = @SPEC_INS_DATE, [SPEC_AGENTNAME] = @SPEC_AGENTNAME, [SPEC_EQU_MODEL] = @SPEC_EQU_MODEL, [SPEC_EQU_SERIAL] = @SPEC_EQU_SERIAL, [SPEC_SAMPLE_METHOD] = @SPEC_SAMPLE_METHOD, [SPEC_SAMPLE_METHOD_FILTERYES] = @SPEC_SAMPLE_METHOD_FILTERYES, [SPEC_SAMPLE_METHOD_FILTERNO] = @SPEC_SAMPLE_METHOD_FILTERNO, [SPEC_CALC_EQU] = @SPEC_CALC_EQU, [SPEC_CALC_FREQ] = @SPEC_CALC_FREQ, [SPEC_CALC_METHOD] = @SPEC_CALC_METHOD, [SPEC_MAIN_FREQ] = @SPEC_MAIN_FREQ, [SPEC_MAIN_METHOD] = @SPEC_MAIN_METHOD, [SPEC_MATERIAL] = @SPEC_MATERIAL, [SPEC_WASTELIQUID] = @SPEC_WASTELIQUID, [SPEC_MATERIAL_FREQ] = @SPEC_MATERIAL_FREQ, [SPEC_MEA_SCOPE] = @SPEC_MEA_SCOPE, [SPEC_MEA_SCOPEUNIT] = @SPEC_MEA_SCOPEUNIT, [SPEC_MEA_RESTIME] = @SPEC_MEA_RESTIME, [SPEC_MEA_RESTIMEUNIT] = @SPEC_MEA_RESTIMEUNIT, [SPEC_MEA_FREQ] = @SPEC_MEA_FREQ, [SPEC_MEA_FREQUNIT] = @SPEC_MEA_FREQUNIT, [SPEC_CALCAVG] = @SPEC_CALCAVG, [SPEC_DOCATTACH_INST] = @SPEC_DOCATTACH_INST, [SPEC_DOCATTACH_CALI] = @SPEC_DOCATTACH_CALI, [SPEC_VIDEO_F] = @SPEC_VIDEO_F, [SPEC_VIDEO_F_MEMO] = @SPEC_VIDEO_F_MEMO, [SPEC_VIDEO_R] = @SPEC_VIDEO_R, [SPEC_VIDEO_R_MEMO] = @SPEC_VIDEO_R_MEMO, [SPEC_VIDEO_NV] = @SPEC_VIDEO_NV, [SPEC_VIDEO_NV_MEMO] = @SPEC_VIDEO_NV_MEMO, [SPEC_ANASIG_YES] = @SPEC_ANASIG_YES, [SPEC_ANASIG] = @SPEC_ANASIG, [SPEC_DIGSIG_YES] = @SPEC_DIGSIG_YES, [SPEC_DIGSIG] = @SPEC_DIGSIG, [SPEC_DO_HARDWARE_CONNECT] = @SPEC_DO_HARDWARE_CONNECT, [SPEC_DO_HARDWARE_CONNPARA] = @SPEC_DO_HARDWARE_CONNPARA, [SPEC_DO_HARDWARE_DOC] = @SPEC_DO_HARDWARE_DOC, [SPEC_PLCAGENT] = @SPEC_PLCAGENT, [SPEC_COSPEC] = @SPEC_COSPEC, [SPEC_H_CHANGE] = @SPEC_H_CHANGE, [SPEC_H_CHANGE_NOTE] = @SPEC_H_CHANGE_NOTE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM">
                                        <DeleteParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DPTYPE" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DPTYPE" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                            <asp:Parameter Name="DPNO_DESP" Type="String" />
                                            <asp:Parameter Name="SPEC_INSTEAD" Type="String" />
                                            <asp:Parameter Name="SPEC_MONITOROTHER" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_DPNO" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_DPNO1" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_QUA" Type="String" />
                                            <asp:Parameter Name="SPEC_INS_DATE" DbType="Date" />
                                            <asp:Parameter Name="SPEC_AGENTNAME" Type="String" />
                                            <asp:Parameter Name="SPEC_EQU_MODEL" Type="String" />
                                            <asp:Parameter Name="SPEC_EQU_SERIAL" Type="String" />
                                            <asp:Parameter Name="SPEC_SAMPLE_METHOD" Type="String" />
                                            <asp:Parameter Name="SPEC_SAMPLE_METHOD_FILTERYES" Type="String" />
                                            <asp:Parameter Name="SPEC_SAMPLE_METHOD_FILTERNO" Type="String" />
                                            <asp:Parameter Name="SPEC_CALC_EQU" Type="String" />
                                            <asp:Parameter Name="SPEC_CALC_FREQ" Type="String" />
                                            <asp:Parameter Name="SPEC_CALC_METHOD" Type="String" />
                                            <asp:Parameter Name="SPEC_MAIN_FREQ" Type="String" />
                                            <asp:Parameter Name="SPEC_MAIN_METHOD" Type="String" />
                                            <asp:Parameter Name="SPEC_MATERIAL" Type="String" />
                                            <asp:Parameter Name="SPEC_WASTELIQUID" Type="String" />
                                            <asp:Parameter Name="SPEC_MATERIAL_FREQ" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_SCOPE" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_SCOPEUNIT" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_RESTIME" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_RESTIMEUNIT" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_FREQ" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_FREQUNIT" Type="String" />
                                            <asp:Parameter Name="SPEC_CALCAVG" Type="String" />
                                            <asp:Parameter Name="SPEC_DOCATTACH_INST" Type="String" />
                                            <asp:Parameter Name="SPEC_DOCATTACH_CALI" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_F" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_F_MEMO" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_R" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_R_MEMO" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_NV" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_NV_MEMO" Type="String" />
                                            <asp:Parameter Name="SPEC_ANASIG_YES" Type="String" />
                                            <asp:Parameter Name="SPEC_ANASIG" Type="String" />
                                            <asp:Parameter Name="SPEC_DIGSIG_YES" Type="String" />
                                            <asp:Parameter Name="SPEC_DIGSIG" Type="String" />
                                            <asp:Parameter Name="SPEC_DO_HARDWARE_CONNECT" Type="String" />
                                            <asp:Parameter Name="SPEC_DO_HARDWARE_CONNPARA" Type="String" />
                                            <asp:Parameter Name="SPEC_DO_HARDWARE_DOC" Type="String" />
                                            <asp:Parameter Name="SPEC_PLCAGENT" Type="String" />
                                            <asp:Parameter Name="SPEC_COSPEC" Type="String" />
                                            <asp:Parameter Name="SPEC_H_CHANGE" Type="String" />
                                            <asp:Parameter Name="SPEC_H_CHANGE_NOTE" Type="String" />
                                            <asp:Parameter Name="C_ID" Type="String" />
                                            <asp:Parameter Name="C_DATE" Type="DateTime" />
                                            <asp:Parameter Name="U_ID" Type="String" />
                                            <asp:Parameter Name="U_DATE" Type="DateTime" />
                                        </InsertParameters>
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                            <asp:SessionParameter Name="DP_NO" SessionField="DP_NO" Type="String" />
                                            <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
                                        </SelectParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="DPNO_DESP" Type="String" />
                                            <asp:Parameter Name="SPEC_INSTEAD" Type="String" />
                                            <asp:Parameter Name="SPEC_MONITOROTHER" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_DPNO" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_DPNO1" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_QUA" Type="String" />
                                            <asp:Parameter Name="SPEC_INS_DATE" DbType="Date" />
                                            <asp:Parameter Name="SPEC_AGENTNAME" Type="String" />
                                            <asp:Parameter Name="SPEC_EQU_MODEL" Type="String" />
                                            <asp:Parameter Name="SPEC_EQU_SERIAL" Type="String" />
                                            <asp:Parameter Name="SPEC_SAMPLE_METHOD" Type="String" />
                                            <asp:Parameter Name="SPEC_SAMPLE_METHOD_FILTERYES" Type="String" />
                                            <asp:Parameter Name="SPEC_SAMPLE_METHOD_FILTERNO" Type="String" />
                                            <asp:Parameter Name="SPEC_CALC_EQU" Type="String" />
                                            <asp:Parameter Name="SPEC_CALC_FREQ" Type="String" />
                                            <asp:Parameter Name="SPEC_CALC_METHOD" Type="String" />
                                            <asp:Parameter Name="SPEC_MAIN_FREQ" Type="String" />
                                            <asp:Parameter Name="SPEC_MAIN_METHOD" Type="String" />
                                            <asp:Parameter Name="SPEC_MATERIAL" Type="String" />
                                            <asp:Parameter Name="SPEC_WASTELIQUID" Type="String" />
                                            <asp:Parameter Name="SPEC_MATERIAL_FREQ" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_SCOPE" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_SCOPEUNIT" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_RESTIME" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_RESTIMEUNIT" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_FREQ" Type="String" />
                                            <asp:Parameter Name="SPEC_MEA_FREQUNIT" Type="String" />
                                            <asp:Parameter Name="SPEC_CALCAVG" Type="String" />
                                            <asp:Parameter Name="SPEC_DOCATTACH_INST" Type="String" />
                                            <asp:Parameter Name="SPEC_DOCATTACH_CALI" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_F" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_F_MEMO" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_R" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_R_MEMO" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_NV" Type="String" />
                                            <asp:Parameter Name="SPEC_VIDEO_NV_MEMO" Type="String" />
                                            <asp:Parameter Name="SPEC_ANASIG_YES" Type="String" />
                                            <asp:Parameter Name="SPEC_ANASIG" Type="String" />
                                            <asp:Parameter Name="SPEC_DIGSIG_YES" Type="String" />
                                            <asp:Parameter Name="SPEC_DIGSIG" Type="String" />
                                            <asp:Parameter Name="SPEC_DO_HARDWARE_CONNECT" Type="String" />
                                            <asp:Parameter Name="SPEC_DO_HARDWARE_CONNPARA" Type="String" />
                                            <asp:Parameter Name="SPEC_DO_HARDWARE_DOC" Type="String" />
                                            <asp:Parameter Name="SPEC_PLCAGENT" Type="String" />
                                            <asp:Parameter Name="SPEC_COSPEC" Type="String" />
                                            <asp:Parameter Name="SPEC_H_CHANGE" Type="String" />
                                            <asp:Parameter Name="SPEC_H_CHANGE_NOTE" Type="String" />
                                            <asp:Parameter Name="C_ID" Type="String" />
                                            <asp:Parameter Name="C_DATE" Type="DateTime" />
                                            <asp:Parameter Name="U_ID" Type="String" />
                                            <asp:Parameter Name="U_DATE" Type="DateTime" />
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DPTYPE" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>                           
                        </table>
                        <table >
                            <tr>
                                <td>規劃各項自動監測(視)設施設置位置圖(與廠區或廢水處理設施相對位置</td>
                                <td>
                                    <dx:ASPxUploadControl ID="AUC_5" runat="server" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px">
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                                    </UploadButton>
                                                    <CancelButton Text="取消">
                                                    </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                        </table>
                       
                    </dx:ContentControl>
                </contentcollection>
            </dx:TabPage>
            <dx:TabPage Text="連線傳輸設施規劃說明">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        

<table  style="width:100%;" border="1">
                                        <tr>
                                            <td>

                                                一、數據採擷及處理系統(DAHS)</td>
                                            <td>(一)資料擷取及處理系統涵蓋位置編號:

                                            </td>
                                            <td>

                                                <asp:TextBox ID="TB_Link_COVERDPNO" runat="server" MaxLength="50" Width="200px" Wrap="False" ></asp:TextBox>

                                            </td>
                                            <td>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>(二)資料上傳編號對照表(註2):</td>
                                            <td>
                                                請至資料上傳編號對照表輸入</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>(三)DAHS系統具有備援功能:</td>
                                            <td>
                                                <asp:RadioButtonList ID="RBL_Link_Redandant" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style11" rowspan="15">
                                                連線傳輸規格</td>
                                            <td rowspan="4" class="auto-style10">
                                                (一)電腦主機：</td>
                                            <td>
                                                中央處理器：<asp:TextBox ID="TB_Link_CemsPCCpu" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td>
                                                網&nbsp; 路 卡：<asp:TextBox ID="TB_Link_CemsPCNetcard" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                記&nbsp;&nbsp; 憶&nbsp;&nbsp; 體：<asp:TextBox ID="TB_Link_CemsPCMem" runat="server" 
                                                    Width="200px" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td>
                                                防毒軟體：<asp:TextBox ID="TB_Link_CemsPCAntiVirus" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                硬 碟 空 間：<asp:TextBox ID="TB_Link_CemsPCHDD" runat="server" Height="17px" 
                                                    Width="200px" MaxLength="50" ></asp:TextBox>
                                            </td>
                                            <td>
                                                防 火 牆：<asp:TextBox ID="TB_Link_CemsPCFirewall" runat="server" Width="200px" MaxLength="50" Wrap="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                作 業 系 統：<asp:TextBox ID="TB_Link_CemsPCOS" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td rowspan="7" class="auto-style10">
                                                (二)連線網路：</td>
                                            <td colspan="2" bgcolor="#66FFCC">
                                                監測紀錄值傳輸網路</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="RBL_Link_NetworkLineType" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">ADSL專線</asp:ListItem>
                                                    <asp:ListItem>廠內既有網路</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButtonList ID="RBL_Link_NetworkIPType" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">伺服器固定IP位址</asp:ListItem>
                                                    <asp:ListItem>無固定IP</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TB_Link_CemsPCOS0" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" bgcolor="#66FFCC">
                                                攝錄影監視影像傳輸</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="auto-style12">
                                                <asp:RadioButtonList ID="RBL_Link_NetworkLineType0" runat="server" RepeatDirection="Horizontal" Width="200px">
                                                    <asp:ListItem>廠內既有網路</asp:ListItem>
                                                    <asp:ListItem Selected="True">ADSL專線</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style12" colspan="2">
                                                <asp:RadioButtonList ID="RBL_Link_NetworkIPType1" runat="server" RepeatDirection="Horizontal" Width="200px">
                                                    <asp:ListItem Selected="True">伺服器固定IP位址</asp:ListItem>
                                                    <asp:ListItem>無固定IP</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style12">
                                                <asp:RadioButtonList ID="RBL_Link_NetworkIPType2" runat="server" RepeatDirection="Horizontal" Width="200px">
                                                    <asp:ListItem Selected="True">80</asp:ListItem>
                                                    <asp:ListItem>86</asp:ListItem>
                                                    <asp:ListItem>8080</asp:ListItem>
                                                    <asp:ListItem>其他</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td class="auto-style12">
                                                <asp:TextBox ID="TB_Link_CemsPCOS1" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style10">
                                                (三)維修保養：</td>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="RBL_Link_MaintainType" runat="server" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem>自行保養</asp:ListItem>
                                                    <asp:ListItem Selected="True">委外保養</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style10">
                                                (四)是否設置監控中心管理監測數據：</td>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="RBL_Link_MonitorCenter" runat="server" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">是</asp:ListItem>
                                                    <asp:ListItem>否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style10" rowspan="2">(五)補充說明及相關證明文件影本：</td>
                                            <td>設施製造商維修保養說明</td>
                                            <td>
                                                <dx:ASPxUploadControl ID="AUC_325A" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                                    <BrowseButton Text="選擇">
                                                    </BrowseButton>
                                                    <UploadButton Text="上傳">
                                                    </UploadButton>
                                                    <CancelButton Text="取消">
                                                    </CancelButton>
                                                </dx:ASPxUploadControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>連線傳輸設施設置計畫書畫(註3)</td>
                                            <td>
                                                <dx:ASPxUploadControl ID="AUC_325B" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                                    <BrowseButton Text="選擇">
                                                    </BrowseButton>
                                                    <UploadButton Text="上傳">
                                                    </UploadButton>
                                                    <CancelButton Text="取消">
                                                    </CancelButton>
                                                </dx:ASPxUploadControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style11">
                                                三、規劃連線傳輸設施設置位置圖（網路配置圖，應清楚標示自動監測（視）設施之訊號傳輸流程及方式）</td>
                                            <td colspan="3">
                                                <dx:ASPxUploadControl ID="AUC_15" runat="server" UploadMode="Auto" Width="200px" ShowProgressPanel="True" ShowUploadButton="True" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px">
                                                    <BrowseButton Text="選擇">
                                                    </BrowseButton>
                                                    <UploadButton Text="上傳">
                                                    </UploadButton>
                                                    <CancelButton Text="取消">
                                                    </CancelButton>
                                                </dx:ASPxUploadControl>
                                            </td>
                                        </tr>
                                    </table>
                        <p>
                        </p>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style13">
                                    <dx:ASPxButton ID="BT_Link_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td class="auto-style11">
                                    <dx:ASPxButton ID="ASPxButton5" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <asp:Label ID="Label_SetLink" runat="server" ForeColor="White"></asp:Label>
                                    <asp:SqlDataSource ID="SDS_SetLink" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        DeleteCommand="DELETE FROM [DOC_SET_LINK] WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion" 
                                        InsertCommand="INSERT INTO [DOC_SET_LINK] ([cNo], [DP_NO], [DocVersion], [UploadMapping], [DAHS_REDAN_FUNC], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [MaintainType], [MonitorCenter], [NOTE1], [NOTE2], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@cNo, @DP_NO, @DocVersion, @UploadMapping, @DAHS_REDAN_FUNC, @CemsPCCpu, @CemsPCMem, @CemsPCHDD, @CemsPCOS, @CemsPCNetcard, @CemsPCAntiVirus, @CemsPCFirewall, @NetworkLineType, @NetworkIPType, @MaintainType, @MonitorCenter, @NOTE1, @NOTE2, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                                        SelectCommand="SELECT * FROM [DOC_SET_LINK]" 
                                        UpdateCommand="UPDATE [DOC_SET_LINK] SET [DP_NO] = @DP_NO, [UploadMapping] = @UploadMapping, [DAHS_REDAN_FUNC] = @DAHS_REDAN_FUNC, [CemsPCCpu] = @CemsPCCpu, [CemsPCMem] = @CemsPCMem, [CemsPCHDD] = @CemsPCHDD, [CemsPCOS] = @CemsPCOS, [CemsPCNetcard] = @CemsPCNetcard, [CemsPCAntiVirus] = @CemsPCAntiVirus, [CemsPCFirewall] = @CemsPCFirewall, [NetworkLineType] = @NetworkLineType, [NetworkIPType] = @NetworkIPType, [MaintainType] = @MaintainType, [MonitorCenter] = @MonitorCenter, [NOTE1] = @NOTE1, [NOTE2] = @NOTE2, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion">
                                        <DeleteParameters>
                                            <asp:Parameter Name="cNo" Type="String" />
                                            <asp:Parameter Name="DocVersion" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="cNo" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DocVersion" Type="Int32" />
                                            <asp:Parameter Name="UploadMapping" Type="String" />
                                            <asp:Parameter Name="DAHS_REDAN_FUNC" Type="String" />
                                            <asp:Parameter Name="CemsPCCpu" Type="String" />
                                            <asp:Parameter Name="CemsPCMem" Type="String" />
                                            <asp:Parameter Name="CemsPCHDD" Type="String" />
                                            <asp:Parameter Name="CemsPCOS" Type="String" />
                                            <asp:Parameter Name="CemsPCNetcard" Type="String" />
                                            <asp:Parameter Name="CemsPCAntiVirus" Type="String" />
                                            <asp:Parameter Name="CemsPCFirewall" Type="String" />
                                            <asp:Parameter Name="NetworkLineType" Type="String" />
                                            <asp:Parameter Name="NetworkIPType" Type="String" />
                                            <asp:Parameter Name="MaintainType" Type="String" />
                                            <asp:Parameter Name="MonitorCenter" Type="String" />
                                            <asp:Parameter Name="NOTE1" Type="String" />
                                            <asp:Parameter Name="NOTE2" Type="String" />
                                            <asp:Parameter Name="C_ID" Type="String" />
                                            <asp:Parameter Name="C_DATE" Type="DateTime" />
                                            <asp:Parameter Name="U_ID" Type="String" />
                                            <asp:Parameter Name="U_DATE" Type="DateTime" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="UploadMapping" Type="String" />
                                            <asp:Parameter Name="DAHS_REDAN_FUNC" Type="String" />
                                            <asp:Parameter Name="CemsPCCpu" Type="String" />
                                            <asp:Parameter Name="CemsPCMem" Type="String" />
                                            <asp:Parameter Name="CemsPCHDD" Type="String" />
                                            <asp:Parameter Name="CemsPCOS" Type="String" />
                                            <asp:Parameter Name="CemsPCNetcard" Type="String" />
                                            <asp:Parameter Name="CemsPCAntiVirus" Type="String" />
                                            <asp:Parameter Name="CemsPCFirewall" Type="String" />
                                            <asp:Parameter Name="NetworkLineType" Type="String" />
                                            <asp:Parameter Name="NetworkIPType" Type="String" />
                                            <asp:Parameter Name="MaintainType" Type="String" />
                                            <asp:Parameter Name="MonitorCenter" Type="String" />
                                            <asp:Parameter Name="NOTE1" Type="String" />
                                            <asp:Parameter Name="NOTE2" Type="String" />
                                            <asp:Parameter Name="C_ID" Type="String" />
                                            <asp:Parameter Name="C_DATE" Type="DateTime" />
                                            <asp:Parameter Name="U_ID" Type="String" />
                                            <asp:Parameter Name="U_DATE" Type="DateTime" />
                                            <asp:Parameter Name="cNo" Type="String" />
                                            <asp:Parameter Name="DocVersion" Type="Int32" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="資料上傳編號對照表">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <table style="width:100%;" align="center">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <dx:ASPxGridView ID="GV_SET_MAPPING" runat="server" AutoGenerateColumns="False" DataSourceID="SDS_SET_MAPPING" KeyFieldName="CNO;DOCVERSION;PER_W_NO" Theme="Aqua" Width="950px">
                                        <SettingsPager PageSize="20">
                                        </SettingsPager>
                                        <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" />
                                        <EditFormLayoutProperties ColCount="2">
                                            <Items>
                                                <dx:GridViewColumnLayoutItem ColumnName="CNO" BackColor="Silver">
                                                </dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="DOCVERSION">
                                                </dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="PER_W_NO">
                                                </dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="PER_E_NO">
                                                </dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="PER_DESC">
                                                </dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="PER_TYPE">
                                                </dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="CWMS_NO">
                                                </dx:GridViewColumnLayoutItem>
                                                <dx:GridViewColumnLayoutItem ColumnName="MEMO">
                                                </dx:GridViewColumnLayoutItem>
                                                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                                                </dx:EditModeCommandLayoutItem>
                                            </Items>
                                        </EditFormLayoutProperties>
                                        <Columns>
                                            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO"  ShowInCustomizationForm="True" VisibleIndex="1" ReadOnly="True">
                                                <EditCellStyle BackColor="#CCCCCC">
                                                </EditCellStyle>
                                                <EditFormCaptionStyle BackColor="#CCCCCC">
                                                </EditFormCaptionStyle>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DOCVERSION"  ShowInCustomizationForm="True" VisibleIndex="2" Caption="版號" ReadOnly="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PER_W_NO" ShowInCustomizationForm="True" VisibleIndex="3" Caption="許可證水流編號">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PER_E_NO" ShowInCustomizationForm="True" VisibleIndex="4" Caption="許可證設備編號">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PER_DESC" ShowInCustomizationForm="True" VisibleIndex="5" Caption="許可證設備中文描述">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="PER_TYPE" ShowInCustomizationForm="True" VisibleIndex="6" Caption="進/出流">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CWMS_NO" ShowInCustomizationForm="True" VisibleIndex="7" Caption="監測上傳位置編號">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="MEMO" ShowInCustomizationForm="True" VisibleIndex="8" Caption="中文備註">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:SqlDataSource ID="SDS_SET_MAPPING" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        DeleteCommand="DELETE FROM [DOC_SET_MAPPING] WHERE [CNO] = @CNO" 
                                        InsertCommand="INSERT INTO [DOC_SET_MAPPING] ([CNO], [DOCVERSION], [PER_W_NO], [PER_E_NO], [PER_DESC], [PER_TYPE], [CWMS_NO], [MEMO]) VALUES (@CNO, @DOCVERSION, @PER_W_NO, @PER_E_NO, @PER_DESC, @PER_TYPE, @CWMS_NO, @MEMO)" 
                                        SelectCommand="SELECT * FROM [DOC_SET_MAPPING] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION))" 
                                        UpdateCommand="UPDATE [DOC_SET_MAPPING] SET [DOCVERSION] = @DOCVERSION,  [PER_E_NO] = @PER_E_NO, [PER_DESC] = @PER_DESC, [PER_TYPE] = @PER_TYPE, [CWMS_NO] = @CWMS_NO, [MEMO] = @MEMO WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [PER_W_NO] = @PER_W_NO ">
                                        <DeleteParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                            <asp:Parameter Name="PER_W_NO" Type="String" />
                                            <asp:Parameter Name="PER_E_NO" Type="String" />
                                            <asp:Parameter Name="PER_DESC" Type="String" />
                                            <asp:Parameter Name="PER_TYPE" Type="String" />
                                            <asp:Parameter Name="CWMS_NO" Type="String" />
                                            <asp:Parameter Name="MEMO" Type="String" />
                                        </InsertParameters>
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                            <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
                                        </SelectParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                            <asp:Parameter Name="PER_W_NO" Type="String" />
                                            <asp:Parameter Name="PER_E_NO" Type="String" />
                                            <asp:Parameter Name="PER_DESC" Type="String" />
                                            <asp:Parameter Name="PER_TYPE" Type="String" />
                                            <asp:Parameter Name="CWMS_NO" Type="String" />
                                            <asp:Parameter Name="MEMO" Type="String" />
                                            <asp:Parameter Name="CNO" Type="String" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="連線傳輸設施設置計畫書">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <table style="width:100%;">
                            <tr>
                                <td align="center" width="140" bgcolor="#00FFCC">
                                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="建置項目" Width="300px">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="center" bgcolor="#00FFCC"><dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="預計完成日期" Width="500px">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td width="160">
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="傳輸設施建置" Width="120px">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_LP_SETCOMPANY" runat="server" Width="300px" Caption="負責設置公司">
                                    </dx:ASPxTextBox>
                                    <dx:ASPxTextBox ID="TB_LP_SETPEOPLE" runat="server" Caption="負責設置人員" Width="300px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_LP_DATE1" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="傳輸模組設置時程:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RBL_TRANS_TYPE" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>地方主管機關提供</asp:ListItem>
                                        <asp:ListItem>自行開發</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_LP_DATE2" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="監測數據採擷及處理系統(監測資料傳輸檔案處理)" Width="160px">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_LP_DATE3" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center" bgcolor="#00FFCC">
                                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="連線測試預計時間">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(1)連線線路備妥（線路號碼）">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxDateEdit ID="TB_LP_DATE4_1" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(2)連線電腦備妥">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxDateEdit ID="TB_LP_DATE4_2" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(3)確認資料獲取系統資料產生頻率符合規範">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style5" colspan="2">
                                    <dx:ASPxDateEdit ID="TB_LP_DATE4_3" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style17">
                                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(4)確認傳輸檔案格式正確">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style17" colspan="2">
                                    <dx:ASPxDateEdit ID="TB_LP_DATE4_4" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(5)傳輸連線168小時測試（開始時間）">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxDateEdit ID="TB_LP_DATE4_5" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="TB_LP_MEMO" runat="server" Caption="備註欄" Height="300px" HorizontalAlign="Center" Width="800px" Font-Names="微軟正黑體" Font-Size="Large">
                                        <CaptionSettings HorizontalAlign="Center" Position="Top" />
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                        <p>
                        </p>
                        <table style="width:100%;">
                            <tr>
                                <td width="80">
                                    <dx:ASPxButton ID="BT_LP_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="BT_LP_CANCEL" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <asp:SqlDataSource ID="SDS_SET_LP" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        DeleteCommand="DELETE FROM [DOC_SET_LP] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" 
                                        InsertCommand="INSERT INTO [DOC_SET_LP] ([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE], [TRANSTYPE], [ITEM1_DATE], [ITEM2_DATE], [ITEM3_DATE], [ITEM4_1_DATE], [ITEM4_2_DATE], [ITEM4_3_DATE], [ITEM4_4_DATE], [ITEM4_5_DATE], [NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DOCVERSION, @SETCOMPANY, @SETPEOPLE, @TRANSTYPE, @ITEM1_DATE, @ITEM2_DATE, @ITEM3_DATE, @ITEM4_1_DATE, @ITEM4_2_DATE, @ITEM4_3_DATE, @ITEM4_4_DATE, @ITEM4_5_DATE, @NOTE, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                                        SelectCommand="SELECT * FROM [DOC_SET_LP] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION))" 
                                        UpdateCommand="UPDATE [DOC_SET_LP] SET [SETCOMPANY] = @SETCOMPANY, [SETPEOPLE] = @SETPEOPLE, [TRANSTYPE] = @TRANSTYPE, [ITEM1_DATE] = @ITEM1_DATE, [ITEM2_DATE] = @ITEM2_DATE, [ITEM3_DATE] = @ITEM3_DATE, [ITEM4_1_DATE] = @ITEM4_1_DATE, [ITEM4_2_DATE] = @ITEM4_2_DATE, [ITEM4_3_DATE] = @ITEM4_3_DATE, [ITEM4_4_DATE] = @ITEM4_4_DATE, [ITEM4_5_DATE] = @ITEM4_5_DATE, [NOTE] = @NOTE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
                                        <DeleteParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                            <asp:Parameter Name="SETCOMPANY" Type="String" />
                                            <asp:Parameter Name="SETPEOPLE" Type="String" />
                                            <asp:Parameter Name="TRANSTYPE" Type="String" />
                                            <asp:Parameter DbType="Date" Name="ITEM1_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM2_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM3_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_1_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_2_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_3_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_4_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_5_DATE" />
                                            <asp:Parameter Name="NOTE" Type="String" />
                                            <asp:Parameter Name="C_ID" Type="String" />
                                            <asp:Parameter Name="C_DATE" Type="DateTime" />
                                            <asp:Parameter Name="U_ID" Type="String" />
                                            <asp:Parameter Name="U_DATE" Type="DateTime" />
                                        </InsertParameters>
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                            <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
                                        </SelectParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="SETCOMPANY" Type="String" />
                                            <asp:Parameter Name="SETPEOPLE" Type="String" />
                                            <asp:Parameter Name="TRANSTYPE" Type="String" />
                                            <asp:Parameter DbType="Date" Name="ITEM1_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM2_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM3_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_1_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_2_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_3_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_4_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_5_DATE" />
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
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
         </tabpages>
        <ActiveTabStyle BackColor="#66FFFF">
        </ActiveTabStyle>
    </dx:ASPxPageControl>
</asp:Content>

