<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.DocManage_VryDoc" CodeBehind="VryDoc.aspx.vb" %>

<%@ Register Assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 16px;
        }

        .auto-style3 {
            height: 55px;
        }

        .auto-style4 {
            height: 74px;
        }

        .auto-style5 {
            height: 22px;
        }

        .auto-style6 {
            height: 43px;
        }

        .auto-style7 {
            height: 43px;
            width: 118px;
        }

        .auto-style8 {
        }

        .auto-style9 {
            width: 437px;
        }

        .auto-style10 {
            width: 202px;
        }

        .auto-style11 {
            width: 143px;
        }

        .auto-style12 {
            width: 136px;
        }

        .auto-style13 {
            width: 80px;
        }

        .auto-style14 {
            width: 72px;
        }

        .auto-style15 {
            width: 41px;
        }

        .auto-style16 {
            width: 266px;
        }

        .auto-style17 {
            height: 22px;
            width: 266px;
        }

        .auto-style18 {
            width: 233px;
        }

        .auto-style19 {
            height: 22px;
            width: 233px;
        }

        .auto-style20 {
            width: 222px;
        }

        .auto-style21 {
            height: 22px;
            width: 222px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxPanel ID="ASPxPanel3" runat="server" BackColor="#0099CC" Font-Names="微軟正黑體" Font-Size="Large" ForeColor="White" Height="40px" Width="1024px">
        <PanelCollection>
            <dx:PanelContent runat="server">&nbsp;自動監測(視)及連線傳輸確認報告書
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"  >
                        <ContentTemplate>
    
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="3" EnableTheming="True" Height="1024px" Theme="Office2003Blue" Width="1024px">
        <TabPages>
            <dx:TabPage Text="基本資料">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <br />
                        <table style="width: 100%;">
                            <tr>

                                <td class="auto-style10" valign="top" rowspan="2">
                                    <asp:RadioButtonList ID="RBL_BAS_TYPE" runat="server" Width="240px" AutoPostBack="True" BorderColor="#CCCCCC" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <asp:ListItem Selected="True">事業</asp:ListItem>
                                        <asp:ListItem>污水下水道系統</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td width="200">
                                    <asp:RadioButtonList ID="RBL_BAS_TYPEB" runat="server" RepeatDirection="Horizontal" Width="400px" BorderColor="#CCCCCC" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <asp:ListItem Selected="True">核准許可廢(污)水排放量達設置規模者</asp:ListItem>
                                        <asp:ListItem>發電廠</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>

                            </tr>
                            <tr>
                                <td width="200">
                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" Width="700px" ID="RBL_BAS_TYPEW" BorderColor="#CCCCCC" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <asp:ListItem Selected="True">公共污水下水道系統</asp:ListItem>
                                        <asp:ListItem>工業區專用污水下水道系統</asp:ListItem>
                                        <asp:ListItem>指定地區或場所專用之污水下水道系統</asp:ListItem>
                                    </asp:RadioButtonList>

                                </td>
                            </tr>
                            <tr>
                                <td width="200">&nbsp;</td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <p>
                        </p>
                        <table style="width: 100%;">
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
                        <table style="width: 100%;">
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="200">
                                    <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="事業或污染下水道系統名稱:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_NAME" runat="server" Width="400px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="管制編號:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CNO" runat="server" MaxLength="8" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="聯絡人姓名:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CNAME" runat="server" MaxLength="20" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
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
                                <td>
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
                                <td>
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
                                <td class="auto-style5">
                                    <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="電子郵件地址:">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style5">
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CEMAIL" runat="server" Width="400px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="申請日期:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_REGDATE" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <br />
                        <dx:ASPxButton ID="BT_BASIC_SAVE" runat="server" Text="儲存" Width="80px">
                        </dx:ASPxButton>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="取消" Width="80px">
                        </dx:ASPxButton>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_VRY_FACTORY] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"
                            InsertCommand="INSERT INTO [DOC_VRY_FACTORY] ([TYPE], [TYPEB], [TYPEW], [TYPEDESP], [CNO], [DOCVERSION], [REGUNIT], [FAC_NAME], [FAC_CNAME], [FAC_CTEL], [FAC_CMOBILE], [FAC_CFAX], [FAC_CEMAIL], [REG_DATE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@TYPE, @TYPEB, @TYPEW, @TYPEDESP, @CNO, @DOCVERSION, @REGUNIT, @FAC_NAME, @FAC_CNAME, @FAC_CTEL, @FAC_CMOBILE, @FAC_CFAX, @FAC_CEMAIL, @REG_DATE, @C_ID, @C_DATE, @U_ID, @U_DATE)"
                            SelectCommand="SELECT * FROM [DOC_VRY_FACTORY] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION))"
                            UpdateCommand="UPDATE [DOC_VRY_FACTORY] SET [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP, [REGUNIT] = @REGUNIT, [FAC_NAME] = @FAC_NAME, [FAC_CNAME] = @FAC_CNAME, [FAC_CTEL] = @FAC_CTEL, [FAC_CMOBILE] = @FAC_CMOBILE, [FAC_CFAX] = @FAC_CFAX, [FAC_CEMAIL] = @FAC_CEMAIL, [REG_DATE] = @REG_DATE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
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
                            <SelectParameters>
                                <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
                            </SelectParameters>
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
                        <dx:ASPxGridView ID="GV_SETITEM" runat="server" AutoGenerateColumns="False" Caption="設置自動監測(視)設施位置及種類(可複選，列次不足者請自行增列填寫)" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION" Width="800px">
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="CNO" ShowInCustomizationForm="True" VisibleIndex="1" Caption="管制編號">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DP_NO" ShowInCustomizationForm="True" VisibleIndex="2" Caption="監測點">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DOCVERSION" ShowInCustomizationForm="True" VisibleIndex="4" Caption="版本號">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OTHER_DESP" ShowInCustomizationForm="True" VisibleIndex="14" Caption="其他說明">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="水量計" FieldName="ITEM_248" ShowInCustomizationForm="True" VisibleIndex="5">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="水溫" FieldName="ITEM_259" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="pH" FieldName="ITEM_246" ShowInCustomizationForm="True" VisibleIndex="7">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="導電度" FieldName="ITEM_247" ShowInCustomizationForm="True" VisibleIndex="8">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="COD" FieldName="ITEM_243" ShowInCustomizationForm="True" VisibleIndex="9">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="SS" FieldName="ITEM_210" ShowInCustomizationForm="True" VisibleIndex="10">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="攝錄影監視" FieldName="ITEM_VIDEO" ShowInCustomizationForm="True" VisibleIndex="11">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="氨氮" FieldName="ITEM_242" ShowInCustomizationForm="True" VisibleIndex="12">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="其他" FieldName="ITEM_OTHER" ShowInCustomizationForm="True" VisibleIndex="13">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn FieldName="DPTYPE" ShowInCustomizationForm="True" VisibleIndex="3" Caption="位置種類">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ConfirmDelete="True" ProcessFocusedRowChangedOnServer="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <dx:ASPxGridView ID="GV_CHANGEITEM" runat="server" AutoGenerateColumns="False" Caption="變更設置自動監測(視)設施位置及種類(可複選，列次不足者請自行增列填寫)（非屬變更者免填）" DataSourceID="sds_item_c" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION" Width="800px">
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="CNO" ShowInCustomizationForm="True" VisibleIndex="1" Caption="管制編號">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DP_NO" ShowInCustomizationForm="True" VisibleIndex="2" Caption="監測點">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DOCVERSION" ShowInCustomizationForm="True" VisibleIndex="4" Caption="版本號">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OTHER_DESP" ShowInCustomizationForm="True" VisibleIndex="14" Caption="其他說明">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="水量計" FieldName="ITEM_248" ShowInCustomizationForm="True" VisibleIndex="5">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="水溫" FieldName="ITEM_259" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="pH" FieldName="ITEM_246" ShowInCustomizationForm="True" VisibleIndex="7">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="導電度" FieldName="ITEM_247" ShowInCustomizationForm="True" VisibleIndex="8">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="COD" FieldName="ITEM_243" ShowInCustomizationForm="True" VisibleIndex="9">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="SS" FieldName="ITEM_210" ShowInCustomizationForm="True" VisibleIndex="10">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="攝錄影監視" FieldName="ITEM_VIDEO" ShowInCustomizationForm="True" VisibleIndex="11">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="氨氮" FieldName="ITEM_242" ShowInCustomizationForm="True" VisibleIndex="12">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="其他" FieldName="ITEM_OTHER" ShowInCustomizationForm="True" VisibleIndex="13">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn FieldName="DPTYPE" ShowInCustomizationForm="True" VisibleIndex="3" Caption="位置種類">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                            <SettingsBehavior AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="sds_item_c" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_VRY_ITEM_C] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION" InsertCommand="INSERT INTO [DOC_VRY_ITEM_C] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM_248], [ITEM_259], [ITEM_246], [ITEM_247], [ITEM_243], [ITEM_210], [ITEM_VIDEO], [ITEM_242], [ITEM_OTHER], [OTHER_DESP], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM_248, @ITEM_259, @ITEM_246, @ITEM_247, @ITEM_243, @ITEM_210, @ITEM_VIDEO, @ITEM_242, @ITEM_OTHER, @OTHER_DESP, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DOC_VRY_ITEM_C] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION))" UpdateCommand="UPDATE [DOC_VRY_ITEM_C] SET [ITEM_248] = @ITEM_248, [ITEM_259] = @ITEM_259, [ITEM_246] = @ITEM_246, [ITEM_247] = @ITEM_247, [ITEM_243] = @ITEM_243, [ITEM_210] = @ITEM_210, [ITEM_VIDEO] = @ITEM_VIDEO, [ITEM_242] = @ITEM_242, [ITEM_OTHER] = @ITEM_OTHER, [OTHER_DESP] = @OTHER_DESP, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION">
                            <DeleteParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
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
                                <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
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
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>"
                            DeleteCommand="DELETE FROM [DOC_VRY_ITEM] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION"
                            InsertCommand="INSERT INTO [DOC_VRY_ITEM] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM_248], [ITEM_259], [ITEM_246], [ITEM_247], [ITEM_243], [ITEM_210], [ITEM_VIDEO], [ITEM_242], [ITEM_OTHER], [OTHER_DESP], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM_248, @ITEM_259, @ITEM_246, @ITEM_247, @ITEM_243, @ITEM_210, @ITEM_VIDEO, @ITEM_242, @ITEM_OTHER, @OTHER_DESP, @C_ID, @C_DATE, @U_ID, @U_DATE)"
                            SelectCommand="SELECT * FROM [DOC_VRY_ITEM] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION))"
                            UpdateCommand="UPDATE [DOC_VRY_ITEM] SET [ITEM_248] = @ITEM_248, [ITEM_259] = @ITEM_259, [ITEM_246] = @ITEM_246, [ITEM_247] = @ITEM_247, [ITEM_243] = @ITEM_243, [ITEM_210] = @ITEM_210, [ITEM_VIDEO] = @ITEM_VIDEO, [ITEM_242] = @ITEM_242, [ITEM_OTHER] = @ITEM_OTHER, [OTHER_DESP] = @OTHER_DESP, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION">
                            <DeleteParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DP_NO" Type="String" />
                                <asp:Parameter Name="DPTYPE" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
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
                                <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
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
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <div>
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style2" width="90">
                                        <dx:ASPxButton ID="BT_SETDPNO" runat="server" Text="選定資料" Width="80"></dx:ASPxButton>
                                    </td>
                                    <td class="auto-style2">
                                        <dx:ASPxButton ID="ASPxButton10" runat="server" Text="列印" Visible="False" Width="80">
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
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="自動監測(視)設施資料">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <br />
                        <dx:ASPxGridView ID="GV_SPEC" runat="server" Caption="自動監測(視)設施資料總表" Width="600px" AutoGenerateColumns="False" DataSourceID="SDS_SPEC" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION;ITEM">
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowInCustomizationForm="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Visible="false">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DP_NO" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Visible="false">
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
                        <dx:ASPxButton ID="ASPxButton9" runat="server" Text="取得資料">
                        </dx:ASPxButton>
                        <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="800px">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="auto-style9">
                                                <dx:ASPxRadioButtonList ID="RBL_SPEC_DPNO" runat="server" RepeatDirection="Horizontal" SelectedIndex="0">
                                                    <Items>
                                                        <dx:ListEditItem Text="進流" Value="進流" Selected="True" />
                                                        <dx:ListEditItem Text="放流" Value="放流" />
                                                        <dx:ListEditItem Text="處理單元(進流)" Value="處理單元(進流)" />
                                                        <dx:ListEditItem Text="處理單元(出流)" Value="處理單元(出流)" />
                                                        <dx:ListEditItem Text="雨水放流" Value="雨水放流" />
                                                    </Items>
                                                </dx:ASPxRadioButtonList>
                                            </td>
                                            <td class="auto-style8">
                                                <dx:ASPxLabel ID="ASPxLabel41" runat="server" Text="位置">
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
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <dx:ASPxRadioButtonList ID="RBL_SPEC_DPNOITEM" runat="server" RepeatDirection="Horizontal" Width="500px" SelectedIndex="0">
                                                    <Items>
                                                        <dx:ListEditItem Text="水量" Value="248" Selected="True" />
                                                        <dx:ListEditItem Text="水溫" Value="259" />
                                                        <dx:ListEditItem Text="pH" Value="246" />
                                                        <dx:ListEditItem Text="導電度" Value="247" />
                                                        <dx:ListEditItem Text="COD" Value="243" />
                                                        <dx:ListEditItem Text="SS" Value="210" />
                                                        <dx:ListEditItem Text="攝錄影監視" Value="310" />
                                                        <dx:ListEditItem Text="氨氮" Value="242" />
                                                    </Items>
                                                </dx:ASPxRadioButtonList>
                                            </td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxPanel>
                        <br />
                        <table style="width: 100%;" border="1">
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
                                <td class="auto-style15" colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_MO_NOTE_DPNO" runat="server" Width="40px" MaxLength="10">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="2">共設</td>
                                <td colspan="2" width="40">
                                    <dx:ASPxTextBox ID="TB_SPEC_MO_NOTE_DPNO1" runat="server" Width="40px" MaxLength="10">
                                    </dx:ASPxTextBox>
                                </td>
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
                                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="(三)安裝日期">
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
                                    <dx:ASPxTextBox ID="TB_SPEC_AGENTNAME" runat="server" Width="250px" MaxLength="50">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="(五)型號">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="10">
                                    <dx:ASPxTextBox ID="TB_SPEC_EQU_MODEL" runat="server" Width="250px" MaxLength="25">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="(六)序號">
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
                                    <dx:ASPxCheckBox ID="CB_SPEC_SAMPLE_METHOD_FilterYes" runat="server" CheckState="Unchecked" Text="有過濾器/前處理裝置，影響說明">
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
                                        <asp:ListItem Selected="True">自行校正</asp:ListItem>
                                        <asp:ListItem>委外校正</asp:ListItem>
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
                                        <asp:ListItem>自行保養</asp:ListItem>
                                        <asp:ListItem Selected="True">委外保養</asp:ListItem>
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
                                <td colspan="2" width="40">
                                    <dx:ASPxLabel ID="ASPxLabel43" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_MEA_SCOPEUNIT" runat="server" Width="50px" MaxLength="10">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="2">&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
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
                                <td colspan="2">&nbsp;</td>
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
                                <td colspan="2">&nbsp;</td>
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
                                <td class="auto-style4" rowspan="3">
                                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="(十七)補充說明及相關證明文件影本">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxCheckBox ID="CB_DOC_Cali" runat="server" CheckState="Unchecked" Text="設施製造商校正方式及周期說明(詳附件" AutoPostBack="True"></dx:ASPxCheckBox>
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
                                    <dx:ASPxCheckBox ID="CB_DOC_Maintain" runat="server" CheckState="Unchecked" Text="維修保養合約書或計畫書(註2)" AutoPostBack="True">
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
                                <td colspan="2">
                                    <dx:ASPxCheckBox ID="CB_DOC_RATA" runat="server" CheckState="Unchecked" Text="水質自動監測設施相對誤差測試報告(註3)" AutoPostBack="True">
                                    </dx:ASPxCheckBox>
                                </td>
                                <td colspan="8">
                                    <dx:ASPxUploadControl ID="AUC_17C" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
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

                                    <asp:RadioButtonList ID="RBL_VIDEO_F" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">MPEG</asp:ListItem>
                                        <asp:ListItem>H264</asp:ListItem>
                                        <asp:ListItem>AVI</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td colspan="4">
                                    <dx:ASPxTextBox ID="TB_VIDEO_F" runat="server" Width="170px" Caption="其他說明">
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
                                <td>(十九)輸出訊號格式</td>
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
                                <td></td>
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
                        <table border="1" style="width: 100%;">
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
                                    <dx:ASPxTextBox ID="TB_SPEC_H_CHANGE_NOTE" runat="server" Width="170px" Caption="原因">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                        <p>
                        </p>
                        <table style="width: 100%;">
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
                                        DeleteCommand="DELETE FROM [DOC_VRY_SPEC] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM"
                                        InsertCommand="INSERT INTO [DOC_VRY_SPEC] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD], [SPEC_MONITOROTHER], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_DPNO2], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_CALI], [SPEC_DOCATTACH_MAIN], [SPEC_DOCATTACH_RATA], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM, @DPNO_DESP, @SPEC_INSTEAD, @SPEC_MONITOROTHER, @SPEC_MO_NOTE_DPNO, @SPEC_MO_NOTE_DPNO1, @SPEC_MO_NOTE_DPNO2, @SPEC_MO_NOTE_QUA, @SPEC_INS_DATE, @SPEC_AGENTNAME, @SPEC_EQU_MODEL, @SPEC_EQU_SERIAL, @SPEC_SAMPLE_METHOD, @SPEC_SAMPLE_METHOD_FILTERYES, @SPEC_SAMPLE_METHOD_FILTERNO, @SPEC_CALC_EQU, @SPEC_CALC_FREQ, @SPEC_CALC_METHOD, @SPEC_MAIN_FREQ, @SPEC_MAIN_METHOD, @SPEC_MATERIAL, @SPEC_WASTELIQUID, @SPEC_MATERIAL_FREQ, @SPEC_MEA_SCOPE, @SPEC_MEA_SCOPEUNIT, @SPEC_MEA_RESTIME, @SPEC_MEA_RESTIMEUNIT, @SPEC_MEA_FREQ, @SPEC_MEA_FREQUNIT, @SPEC_CALCAVG, @SPEC_DOCATTACH_CALI, @SPEC_DOCATTACH_MAIN, @SPEC_DOCATTACH_RATA, @SPEC_VIDEO_F, @SPEC_VIDEO_F_MEMO, @SPEC_VIDEO_R, @SPEC_VIDEO_R_MEMO, @SPEC_VIDEO_NV, @SPEC_VIDEO_NV_MEMO, @SPEC_ANASIG_YES, @SPEC_ANASIG, @SPEC_DIGSIG_YES, @SPEC_DIGSIG, @SPEC_DO_HARDWARE_CONNECT, @SPEC_DO_HARDWARE_CONNPARA, @SPEC_DO_HARDWARE_DOC, @SPEC_PLCAGENT, @SPEC_COSPEC, @SPEC_H_CHANGE, @SPEC_H_CHANGE_NOTE, @C_ID, @C_DATE, @U_ID, @U_DATE)"
                                        SelectCommand="SELECT * FROM [DOC_VRY_SPEC] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION) AND ([DP_NO] = @DP_NO))"
                                        UpdateCommand="UPDATE [DOC_VRY_SPEC] SET [DPNO_DESP] = @DPNO_DESP, [SPEC_INSTEAD] = @SPEC_INSTEAD, [SPEC_MONITOROTHER] = @SPEC_MONITOROTHER, [SPEC_MO_NOTE_DPNO] = @SPEC_MO_NOTE_DPNO, [SPEC_MO_NOTE_DPNO1] = @SPEC_MO_NOTE_DPNO1, [SPEC_MO_NOTE_DPNO2] = @SPEC_MO_NOTE_DPNO2, [SPEC_MO_NOTE_QUA] = @SPEC_MO_NOTE_QUA, [SPEC_INS_DATE] = @SPEC_INS_DATE, [SPEC_AGENTNAME] = @SPEC_AGENTNAME, [SPEC_EQU_MODEL] = @SPEC_EQU_MODEL, [SPEC_EQU_SERIAL] = @SPEC_EQU_SERIAL, [SPEC_SAMPLE_METHOD] = @SPEC_SAMPLE_METHOD, [SPEC_SAMPLE_METHOD_FILTERYES] = @SPEC_SAMPLE_METHOD_FILTERYES, [SPEC_SAMPLE_METHOD_FILTERNO] = @SPEC_SAMPLE_METHOD_FILTERNO, [SPEC_CALC_EQU] = @SPEC_CALC_EQU, [SPEC_CALC_FREQ] = @SPEC_CALC_FREQ, [SPEC_CALC_METHOD] = @SPEC_CALC_METHOD, [SPEC_MAIN_FREQ] = @SPEC_MAIN_FREQ, [SPEC_MAIN_METHOD] = @SPEC_MAIN_METHOD, [SPEC_MATERIAL] = @SPEC_MATERIAL, [SPEC_WASTELIQUID] = @SPEC_WASTELIQUID, [SPEC_MATERIAL_FREQ] = @SPEC_MATERIAL_FREQ, [SPEC_MEA_SCOPE] = @SPEC_MEA_SCOPE, [SPEC_MEA_SCOPEUNIT] = @SPEC_MEA_SCOPEUNIT, [SPEC_MEA_RESTIME] = @SPEC_MEA_RESTIME, [SPEC_MEA_RESTIMEUNIT] = @SPEC_MEA_RESTIMEUNIT, [SPEC_MEA_FREQ] = @SPEC_MEA_FREQ, [SPEC_MEA_FREQUNIT] = @SPEC_MEA_FREQUNIT, [SPEC_CALCAVG] = @SPEC_CALCAVG, [SPEC_DOCATTACH_CALI] = @SPEC_DOCATTACH_CALI, [SPEC_DOCATTACH_MAIN] = @SPEC_DOCATTACH_MAIN, [SPEC_DOCATTACH_RATA] = @SPEC_DOCATTACH_RATA, [SPEC_VIDEO_F] = @SPEC_VIDEO_F, [SPEC_VIDEO_F_MEMO] = @SPEC_VIDEO_F_MEMO, [SPEC_VIDEO_R] = @SPEC_VIDEO_R, [SPEC_VIDEO_R_MEMO] = @SPEC_VIDEO_R_MEMO, [SPEC_VIDEO_NV] = @SPEC_VIDEO_NV, [SPEC_VIDEO_NV_MEMO] = @SPEC_VIDEO_NV_MEMO, [SPEC_ANASIG_YES] = @SPEC_ANASIG_YES, [SPEC_ANASIG] = @SPEC_ANASIG, [SPEC_DIGSIG_YES] = @SPEC_DIGSIG_YES, [SPEC_DIGSIG] = @SPEC_DIGSIG, [SPEC_DO_HARDWARE_CONNECT] = @SPEC_DO_HARDWARE_CONNECT, [SPEC_DO_HARDWARE_CONNPARA] = @SPEC_DO_HARDWARE_CONNPARA, [SPEC_DO_HARDWARE_DOC] = @SPEC_DO_HARDWARE_DOC, [SPEC_PLCAGENT] = @SPEC_PLCAGENT, [SPEC_COSPEC] = @SPEC_COSPEC, [SPEC_H_CHANGE] = @SPEC_H_CHANGE, [SPEC_H_CHANGE_NOTE] = @SPEC_H_CHANGE_NOTE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM">
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
                                            <asp:Parameter Name="SPEC_MO_NOTE_DPNO2" Type="String" />
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
                                            <asp:Parameter Name="SPEC_DOCATTACH_CALI" Type="String" />
                                            <asp:Parameter Name="SPEC_DOCATTACH_MAIN" Type="String" />
                                            <asp:Parameter Name="SPEC_DOCATTACH_RATA" Type="String" />
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
                                            <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
                                            <asp:SessionParameter Name="DP_NO" SessionField="DP_NO" Type="String" />
                                        </SelectParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="DPNO_DESP" Type="String" />
                                            <asp:Parameter Name="SPEC_INSTEAD" Type="String" />
                                            <asp:Parameter Name="SPEC_MONITOROTHER" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_DPNO" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_DPNO1" Type="String" />
                                            <asp:Parameter Name="SPEC_MO_NOTE_DPNO2" Type="String" />
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
                                            <asp:Parameter Name="SPEC_DOCATTACH_CALI" Type="String" />
                                            <asp:Parameter Name="SPEC_DOCATTACH_MAIN" Type="String" />
                                            <asp:Parameter Name="SPEC_DOCATTACH_RATA" Type="String" />
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
                        <table>
                            <tr>
                                <td>規劃各項自動監測(視)設施設置位置圖(與廠區或廢水處理設施相對位置</td>
                                <td>
                                    <dx:ASPxUploadControl ID="AUC_5" runat="server" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="280px">
                                        <UploadButton Text="上傳">
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                    </dx:ASPxUploadControl>
                                </td>
                            </tr>
                        </table>

                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="連線傳輸設施資料">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">


                        <table style="width: 100%;" border="1">
                            <tr>
                                <td>一、數據採擷及處理系統(DAHS)</td>
                                <td>(一)資料擷取及處理系統涵蓋位置編號:

                                </td>
                                <td>

                                    <asp:TextBox ID="TB_Link_COVERDPNO" runat="server" MaxLength="50" Width="200px" Wrap="False"></asp:TextBox>

                                </td>
                                <td></td>
                            </tr>
                            <td>&nbsp;</td>
                            <td>(二)資料上傳編號對照表(註2):</td>
                            <td>請至資料上傳編號對照表輸入</td>
                            <td>&nbsp;</td>
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
                                <td class="auto-style11" rowspan="17">連線傳輸規格</td>
                                <td rowspan="4" class="auto-style10">(一)電腦主機：</td>
                                <td>中央處理器：<asp:TextBox ID="TB_Link_CemsPCCpu" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>網&nbsp; 路 卡：<asp:TextBox ID="TB_Link_CemsPCNetcard" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>記&nbsp;&nbsp; 憶&nbsp;&nbsp; 體：<asp:TextBox ID="TB_Link_CemsPCMem" runat="server"
                                    Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>防毒軟體：<asp:TextBox ID="TB_Link_CemsPCAntiVirus" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>硬 碟 空 間：<asp:TextBox ID="TB_Link_CemsPCHDD" runat="server" Height="17px"
                                    Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>防 火 牆：<asp:TextBox ID="TB_Link_CemsPCFirewall" runat="server" Width="200px" MaxLength="50" Wrap="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>作 業 系 統：<asp:TextBox ID="TB_Link_CemsPCOS" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td rowspan="8" class="auto-style10">(二)連線網路：</td>
                                <td colspan="2" bgcolor="#66FFCC">監測紀錄值傳輸網路</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="RBL_Link_NetworkLineType" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">ADSL專線</asp:ListItem>
                                        <asp:ListItem>廠內既有網路</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>&nbsp;</td>
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
                                <td colspan="2" bgcolor="#66FFCC">攝錄影監視影像傳輸</td>
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
                                <td class="auto-style12">
                                    <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Caption="登入帳號:" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style10">(三)維修保養：</td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="RBL_Link_MaintainType" runat="server"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem>自行保養</asp:ListItem>
                                        <asp:ListItem Selected="True">委外保養</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10">(四)是否設置監控中心管理監測數據：</td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="RBL_Link_MonitorCenter" runat="server"
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">是</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10" rowspan="3">(五)補充說明及相關證明文件影本：</td>
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
                                <td>維修保養合約書或計畫書(註5)</td>
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
                                <td>連線傳輸設施設置確認書(註6)</td>
                                <td>
                                    <dx:ASPxUploadControl ID="AUC_325C" runat="server" UploadMode="Auto" ShowProgressPanel="True" ShowUploadButton="True" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" Width="200px" >
                                        <BrowseButton Text="選擇"></BrowseButton>

                                        <UploadButton Text="上傳"></UploadButton>

                                        <CancelButton Text="取消"></CancelButton>
                                    </dx:ASPxUploadControl>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">三、實際連線傳輸設施設置位置圖（網路配置圖，應清楚標示自動監測（視）設施之訊號傳輸流程及方式）</td>
                                <td colspan="3">
                                    <dx:ASPxUploadControl ID="AUC_33" runat="server" UploadMode="Auto" Width="200px" ShowProgressPanel="True" ShowUploadButton="True" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px">
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
                        <table style="width: 100%;">
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
                                        DeleteCommand="DELETE FROM [DOC_VRY_LINK] WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion"
                                        InsertCommand="INSERT INTO [DOC_VRY_LINK] ([cNo], [DP_NO], [DocVersion], [UploadMapping], [DAHS_REDAN_FUNC], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [MaintainType], [MonitorCenter], [NOTE1], [NOTE2], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@cNo, @DP_NO, @DocVersion, @UploadMapping, @DAHS_REDAN_FUNC, @CemsPCCpu, @CemsPCMem, @CemsPCHDD, @CemsPCOS, @CemsPCNetcard, @CemsPCAntiVirus, @CemsPCFirewall, @NetworkLineType, @NetworkIPType, @MaintainType, @MonitorCenter, @NOTE1, @NOTE2, @C_ID, @C_DATE, @U_ID, @U_DATE)"
                                        SelectCommand="SELECT * FROM [DOC_VRY_LINK] WHERE (([cNo] = @cNo) AND ([DocVersion] = @DocVersion))"
                                        UpdateCommand="UPDATE [DOC_VRY_LINK] SET [DP_NO] = @DP_NO, [UploadMapping] = @UploadMapping, [DAHS_REDAN_FUNC] = @DAHS_REDAN_FUNC, [CemsPCCpu] = @CemsPCCpu, [CemsPCMem] = @CemsPCMem, [CemsPCHDD] = @CemsPCHDD, [CemsPCOS] = @CemsPCOS, [CemsPCNetcard] = @CemsPCNetcard, [CemsPCAntiVirus] = @CemsPCAntiVirus, [CemsPCFirewall] = @CemsPCFirewall, [NetworkLineType] = @NetworkLineType, [NetworkIPType] = @NetworkIPType, [MaintainType] = @MaintainType, [MonitorCenter] = @MonitorCenter, [NOTE1] = @NOTE1, [NOTE2] = @NOTE2, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion">
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
                                        <SelectParameters>
                                            <asp:SessionParameter Name="cNo" SessionField="CNO" Type="String" />
                                            <asp:SessionParameter Name="DocVersion" SessionField="DOCVERSION" Type="Int32" />
                                        </SelectParameters>
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
            <dx:TabPage Text="RATA">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <table align="center" class="link3" bgcolor="White" width="800" border="1" style="border: 1px solid #2781BA">
                            <tr align="center">
                                <td>
                                    <asp:GridView ID="GV_RATA" runat="server" AutoGenerateColumns="False" DataKeyNames="CNO,DP_NO,ITEM,YEAR,MM"
                                        DataSourceID="SDS_Rata" BackColor="#D4D8DD" ForeColor="Black" AllowPaging="True" Width="800px">
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" />
                                            <asp:BoundField DataField="CNO" HeaderText="管制編號" ReadOnly="True" SortExpression="CNO" />
                                            <asp:BoundField DataField="DP_NO" HeaderText="監測位置" ReadOnly="True" SortExpression="DP_NO" />
                                            <asp:BoundField DataField="ITEM" HeaderText="測項" ReadOnly="True" SortExpression="ITEM" />
                                            <asp:BoundField DataField="YEAR" HeaderText="年份" ReadOnly="True" SortExpression="YEAR" />
                                            <asp:BoundField DataField="MM" HeaderText="月份" SortExpression="MM" ReadOnly="True" />
                                            <asp:BoundField DataField="STARTTIME" HeaderText="啟始時間" SortExpression="STARTTIME" />
                                            <asp:BoundField DataField="ENDTIME" HeaderText="結束時間" SortExpression="ENDTIME" />
                                            <asp:BoundField DataField="AVG_A" HeaderText="檢驗平均值" SortExpression="AVG_A" />
                                            <asp:BoundField DataField="STD" HeaderText="標準差" SortExpression="STD" />
                                            <asp:BoundField DataField="FACTOR_A" HeaderText="信賴係數" SortExpression="FACTOR_A" />
                                            <asp:BoundField DataField="ACCURACY_A" HeaderText="相對準確度" SortExpression="ACCURACY_A" />

                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>

                        </table>

                        <table align="center" class="link3" bgcolor="White" width="800" border="1" style="border: 1px solid #2781BA">

                            <tr>
                                <td class="auto-style1">監測位置</td>
                                <td>
                                    <asp:DropDownList ID="DDL_RATADPNO" runat="server" DataSourceID="SDS_DPOINT" DataTextField="DP_NO"
                                        DataValueField="DP_NO" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:SqlDataSource ID="SDS_DPOINT" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        SelectCommand="SELECT DISTINCT DP_NO FROM [D_point] WHERE ([CNO] = @CNO)">
                                         <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />                                            
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="auto-style1">監測項目
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDL_RATAITEM" runat="server">
                                        <asp:ListItem Value="210">懸浮固體</asp:ListItem>
                                        <asp:ListItem Value="242">氨氮</asp:ListItem>
                                        <asp:ListItem Value="243">化學需氧量</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td></td>
                                <td>&nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td class="auto-style1">年份</td>
                                <td>
                                    <asp:DropDownList ID="DDL_RATAYEAR" runat="server">
                                        <asp:ListItem Selected="True">請選擇年份</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1">月份</td>
                                <td>
                                    <asp:DropDownList ID="DDL_RATAMM" runat="server">
                                        <asp:ListItem Selected="True">請選擇月份</asp:ListItem>
                                        <asp:ListItem>01</asp:ListItem>
                                        <asp:ListItem>02</asp:ListItem>
                                        <asp:ListItem>03</asp:ListItem>
                                        <asp:ListItem>04</asp:ListItem>
                                        <asp:ListItem>05</asp:ListItem>
                                        <asp:ListItem>06</asp:ListItem>
                                        <asp:ListItem>07</asp:ListItem>
                                        <asp:ListItem>08</asp:ListItem>
                                        <asp:ListItem>09</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td class="auto-style1">RATA數據</td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">9組</asp:ListItem>
                                        <asp:ListItem>12組</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel1" runat="server">
                            <table align="center" bgcolor="White" border="1" class="link3" style="border: 1px solid #2781BA" width="800">
                                <tr class="border1">
                                    <td style="background-color: #C0C0C0">檢測時間</td>
                                    <td colspan="3" style="background-color: #C0C0C0">日期(起)：<asp:TextBox ID="TB_1H_Day_S" runat="server" MaxLength="8" Width="60px"></asp:TextBox>

                                        <asp:DropDownList ID="DDL_1H_HH_S" runat="server">
                                            <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;～&nbsp; 日期(迄)：<asp:TextBox ID="TB_1H_Day_E" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
                                        <asp:DropDownList ID="DDL_1H_HH_E" runat="server">
                                            <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                            <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                            <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                            <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                            <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                            <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                            <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                            <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                            <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                            <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                            <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                            <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                            <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                            <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                            <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                            <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                            <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;(YYYYMMDD hh)</td>
                                </tr>
                                <tr class="border1">
                                    <td style="background-color: #C0C0C0">測試數據 </td>
                                    <td style="background-color: #C0C0C0">標準檢驗方法量測數據 </td>
                                    <td style="background-color: #C0C0C0">監測設施量測數據 </td>
                                    <td style="background-color: #C0C0C0">差值 </td>
                                </tr>
                                <tr>
                                    <td>數據一 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD1" runat="server" AutoPostBack="True" TabIndex="1"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS1" runat="server" AutoPostBack="True" TabIndex="2"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF1" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據二 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD2" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS2" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF2" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據三 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD3" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS3" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF3" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據四 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD4" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS4" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF4" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據五 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD5" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS5" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF5" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據六 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD6" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td class="IE8Fix">
                                        <asp:TextBox ID="TB_CEMS6" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF6" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據七 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD7" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS7" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF7" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據八 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD8" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS8" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF8" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據九 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD9" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS9" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF9" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據十 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD10" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS10" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF10" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據十一 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD11" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS11" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF11" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據十二 </td>
                                    <td>
                                        <asp:TextBox ID="TB_STD12" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_CEMS12" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TB_DIFF12" runat="server" AutoPostBack="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <table align="center" bgcolor="White" border="1" class="link3" style="border: 1px solid #2781BA" width="800">
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="計算" Width="80px" />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>差值算術平均值 </td>
                                <td>
                                    <asp:TextBox ID="TB_STDAVG" runat="server"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>標準偏差 </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TB_STD" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>信賴係數 </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TB_TRUST" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>相對準確度 </td>
                                <td colspan="3">
                                    <asp:TextBox ID="TB_RATA" runat="server"></asp:TextBox>
                                    % </td>
                            </tr>
                            <tr>
                                <td>實驗室採用檢測方法</td>
                                <td colspan="3">
                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource3" DataTextField="SampleName" DataValueField="SampleID" Width="400px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>"
                                        SelectCommand="SELECT [SampleID], [SampleName] FROM [SampleMethod]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <dx:ASPxButton ID="BT_RATA_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="BT_RATA_CAN" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                    <asp:Label ID="Label_Rata" runat="server" ForeColor="White"></asp:Label>
                                    <asp:SqlDataSource ID="SDS_Rata" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>"
                                        DeleteCommand="DELETE FROM [MRATA] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [ITEM] = @ITEM AND [YEAR] = @YEAR AND [MM] = @MM"
                                        InsertCommand="INSERT INTO [MRATA] ([CNO], [DP_NO], [ITEM], [YEAR], [MM], [STARTTIME], [ENDTIME], [DATA_1A], [DATA_1B], [DATA_1D], [DATA_2A], [DATA_2B], [DATA_2D], [DATA_3A], [DATA_3B], [DATA_3D], [DATA_4A], [DATA_4B], [DATA_4D], [DATA_5A], [DATA_5B], [DATA_5D], [DATA_6A], [DATA_6B], [DATA_6D], [DATA_7A], [DATA_7B], [DATA_7D], [DATA_8A], [DATA_8B], [DATA_8D], [DATA_9A], [DATA_9B], [DATA_9D], [DATA_10A], [DATA_10B], [DATA_10D], [DATA_11A], [DATA_11B], [DATA_11D], [DATA_12A], [DATA_12B], [DATA_12D], [AVG_A], [AVG_B], [AVG_D], [FACTOR_A], [FACTOR_B], [FACTOR_D], [ACCURACY_A], [PreRataID]) VALUES (@CNO, @DP_NO, @ITEM, @YEAR, @MM, @STARTTIME, @ENDTIME, @DATA_1A, @DATA_1B, @DATA_1D, @DATA_2A, @DATA_2B, @DATA_2D, @DATA_3A, @DATA_3B, @DATA_3D, @DATA_4A, @DATA_4B, @DATA_4D, @DATA_5A, @DATA_5B, @DATA_5D, @DATA_6A, @DATA_6B, @DATA_6D, @DATA_7A, @DATA_7B, @DATA_7D, @DATA_8A, @DATA_8B, @DATA_8D, @DATA_9A, @DATA_9B, @DATA_9D, @DATA_10A, @DATA_10B, @DATA_10D, @DATA_11A, @DATA_11B, @DATA_11D, @DATA_12A, @DATA_12B, @DATA_12D, @AVG_A, @AVG_B, @AVG_D, @FACTOR_A, @FACTOR_B, @FACTOR_D, @ACCURACY_A, @PreRataID)"
                                        SelectCommand="SELECT * FROM [MRATA] WHERE ([CNO] = @CNO)"
                                        UpdateCommand="UPDATE [MRATA] SET [STARTTIME] = @STARTTIME, [ENDTIME] = @ENDTIME, [DATA_1A] = @DATA_1A, [DATA_1B] = @DATA_1B, [DATA_1D] = @DATA_1D, [DATA_2A] = @DATA_2A, [DATA_2B] = @DATA_2B, [DATA_2D] = @DATA_2D, [DATA_3A] = @DATA_3A, [DATA_3B] = @DATA_3B, [DATA_3D] = @DATA_3D, [DATA_4A] = @DATA_4A, [DATA_4B] = @DATA_4B, [DATA_4D] = @DATA_4D, [DATA_5A] = @DATA_5A, [DATA_5B] = @DATA_5B, [DATA_5D] = @DATA_5D, [DATA_6A] = @DATA_6A, [DATA_6B] = @DATA_6B, [DATA_6D] = @DATA_6D, [DATA_7A] = @DATA_7A, [DATA_7B] = @DATA_7B, [DATA_7D] = @DATA_7D, [DATA_8A] = @DATA_8A, [DATA_8B] = @DATA_8B, [DATA_8D] = @DATA_8D, [DATA_9A] = @DATA_9A, [DATA_9B] = @DATA_9B, [DATA_9D] = @DATA_9D, [DATA_10A] = @DATA_10A, [DATA_10B] = @DATA_10B, [DATA_10D] = @DATA_10D, [DATA_11A] = @DATA_11A, [DATA_11B] = @DATA_11B, [DATA_11D] = @DATA_11D, [DATA_12A] = @DATA_12A, [DATA_12B] = @DATA_12B, [DATA_12D] = @DATA_12D, [AVG_A] = @AVG_A, [AVG_B] = @AVG_B, [AVG_D] = @AVG_D, [FACTOR_A] = @FACTOR_A, [FACTOR_B] = @FACTOR_B, [FACTOR_D] = @FACTOR_D, [ACCURACY_A] = @ACCURACY_A, [PreRataID] = @PreRataID WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [ITEM] = @ITEM AND [YEAR] = @YEAR AND [MM] = @MM">
                                        <DeleteParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                            <asp:Parameter Name="YEAR" Type="String" />
                                            <asp:Parameter Name="MM" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                            <asp:Parameter Name="YEAR" Type="String" />
                                            <asp:Parameter Name="MM" Type="String" />
                                            <asp:Parameter Name="STARTTIME" Type="String" />
                                            <asp:Parameter Name="ENDTIME" Type="String" />
                                            <asp:Parameter Name="DATA_1A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_1B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_1D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12D" Type="Decimal" />
                                            <asp:Parameter Name="AVG_A" Type="Decimal" />
                                            <asp:Parameter Name="FACTOR_A" Type="Decimal" />
                                            <asp:Parameter Name="FACTOR_B" Type="Decimal" />
                                            <asp:Parameter Name="FACTOR_D" Type="Decimal" />
                                            <asp:Parameter Name="ACCURACY_A" Type="Decimal" />
                                            <asp:Parameter Name="PreRataID" Type="String" />
                                        </InsertParameters>
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                        </SelectParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="STARTTIME" Type="String" />
                                            <asp:Parameter Name="ENDTIME" Type="String" />
                                            <asp:Parameter Name="DATA_1A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_1B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_1D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11D" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12D" Type="Decimal" />
                                            <asp:Parameter Name="AVG_A" Type="Decimal" />
                                            <asp:Parameter Name="FACTOR_A" Type="Decimal" />
                                            <asp:Parameter Name="FACTOR_B" Type="Decimal" />
                                            <asp:Parameter Name="FACTOR_D" Type="Decimal" />
                                            <asp:Parameter Name="ACCURACY_A" Type="Decimal" />
                                            <asp:Parameter Name="PreRataID" Type="String" />
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                            <asp:Parameter Name="YEAR" Type="String" />
                                            <asp:Parameter Name="MM" Type="String" />
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
                        <table style="width: 100%;" align="center">
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
                                                <dx:GridViewColumnLayoutItem ColumnName="CNO">
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
                                            <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO" ShowInCustomizationForm="True" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DOCVERSION" ShowInCustomizationForm="True" VisibleIndex="2" Caption="版號">
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
                                        UpdateCommand="UPDATE [DOC_SET_MAPPING] SET [DOCVERSION] = @DOCVERSION,  [PER_E_NO] = @PER_E_NO, [PER_DESC] = @PER_DESC, [PER_TYPE] = @PER_TYPE, [CWMS_NO] = @CWMS_NO, [MEMO] = @MEMO WHERE [CNO] = @CNO AND  [DOCVERSION] = @DOCVERSION AND  [PER_W_NO] = @PER_W_NO">
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
            <dx:TabPage Text="連線傳輸設施設置確認書">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <table style="width: 100%;">
                            <tr>
                                <td align="center" bgcolor="#00FFCC" colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="建置項目" Width="300px">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="center" bgcolor="#00FFCC">
                                    <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="實際完成日期" Width="200px">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="傳輸設施建置" Width="120px">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style18">
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
                                <td class="auto-style20">
                                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="傳輸模組設置時程:">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style18">
                                    <asp:RadioButtonList ID="RBL_TRANS_TYPE" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">地方主管機關提供</asp:ListItem>
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
                                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="監測數據採擷及處理系統(監測資料傳輸檔案處理)" Width="200px">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style18">&nbsp;</td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_LP_DATE3" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#00FFCC" class="auto-style20">
                                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="連線測試開始時間">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style18">&nbsp;</td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_LP_DATE4" runat="server">
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <dx:ASPxLabel ID="ASPxLabel28" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(1)連線線路備妥（線路號碼）">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style18">&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="RBL_ACTEST_1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">是</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <dx:ASPxLabel ID="ASPxLabel29" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(2)連線電腦備妥">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style18">&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="RBL_ACTEST_2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">開機後自動執行連線</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style21">
                                    <dx:ASPxLabel ID="ASPxLabel30" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(3)資料獲取系統資料產生頻率">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style19">&nbsp;</td>
                                <td class="auto-style5">
                                    <asp:RadioButtonList ID="RBL_ACTEST_3" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">測試通過</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style21">
                                    <dx:ASPxLabel ID="ASPxLabel31" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(4)傳輸檔案格式正確">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style19">&nbsp;</td>
                                <td class="auto-style17">
                                    <asp:RadioButtonList ID="RBL_ACTEST_4" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">測試通過</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <dx:ASPxLabel ID="ASPxLabel47" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="(5)傳輸連線168小時測試">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style18">&nbsp;</td>
                                <td>
                                    <asp:RadioButtonList ID="RBL_ACTEST_5" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">測試通過</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">&nbsp;</td>
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
                        <table style="width: 100%;">
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
                                        DeleteCommand="DELETE FROM [DOC_SET_LP] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO"
                                        InsertCommand="INSERT INTO [DOC_SET_LP] ([CNO], [DP_NO], [SETCOMPANY], [SETPEOPLE], [TRANSTYPE], [ITEM1_DATE], [ITEM2_DATE], [ITEM3_DATE], [ITEM4_1_DATE], [ITEM4_2_DATE], [ITEM4_3_DATE], [ITEM4_4_DATE], [ITEM4_5_DATE]) VALUES (@CNO, @DP_NO, @SETCOMPANY, @SETPEOPLE, @TRANSTYPE, @ITEM1_DATE, @ITEM2_DATE, @ITEM3_DATE, @ITEM4_1_DATE, @ITEM4_2_DATE, @ITEM4_3_DATE, @ITEM4_4_DATE, @ITEM4_5_DATE)"
                                        SelectCommand="SELECT * FROM [DOC_SET_LP]"
                                        UpdateCommand="UPDATE [DOC_SET_LP] SET [SETCOMPANY] = @SETCOMPANY, [SETPEOPLE] = @SETPEOPLE, [TRANSTYPE] = @TRANSTYPE, [ITEM1_DATE] = @ITEM1_DATE, [ITEM2_DATE] = @ITEM2_DATE, [ITEM3_DATE] = @ITEM3_DATE, [ITEM4_1_DATE] = @ITEM4_1_DATE, [ITEM4_2_DATE] = @ITEM4_2_DATE, [ITEM4_3_DATE] = @ITEM4_3_DATE, [ITEM4_4_DATE] = @ITEM4_4_DATE, [ITEM4_5_DATE] = @ITEM4_5_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO">
                                        <DeleteParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
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
                                        </InsertParameters>
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
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
</ContentTemplate>
        </asp:UpdatePanel>    
</asp:Content>

