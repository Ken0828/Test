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
        .auto-style22 {
            height: 27px;
        }
        .auto-style23 {
            height: 24px;
        }
        .auto-style24 {
            height: 18px;
        }
        .auto-style26 {
            height: 23px;
        }
        .auto-style27 {
            width: 430px;
        }
        .auto-style29 {
            height: 23px;
            width: 550px;
        }
        .auto-style31 {
            width: 550px;
        }
        .auto-style32 {
            height: 48px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <dx:ASPxPanel ID="ASPxPanel3" runat="server" BackColor="#0099CC" Font-Names="微軟正黑體" Font-Size="Large" ForeColor="White" Height="40px" Width="1680px">
        <PanelCollection>
            <dx:PanelContent runat="server"><dx:ASPxLabel ID="ASPxLabel_Doc" runat="server" Font-Names="微軟正黑體"  Text="自動監測(視)及連線傳輸確認報告書" Font-Size="Large"></dx:ASPxLabel>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
    <div>
        <asp:Panel ID="Panel2" runat="server"  Width="1680px">
            <table >
                                <tr>
                                    <td class="style16">
                                        &nbsp;</td>
                                    <td class="style17" width="420">
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>"
                                            SelectCommand="SELECT * FROM [DAHS_EXAMLIST] WHERE ([CNO] = @CNO) and (DOCTYPE='確認報告書' OR DOCTYPE='確認報告書變更申請' ) ">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="SDS_Audit" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                            SelectCommand="SELECT * FROM [DAHS_AuditResult] ORDER BY AUDITDATE DESC" 
                                            DeleteCommand="DELETE FROM [DAHS_AuditResult] WHERE [CNO] = @CNO AND [DocVersion] = @DocVersion" 
                                            InsertCommand="INSERT INTO [DAHS_AuditResult] ([CNO], [DocVersion], [DocNumber], [DOCTYPE], [AUDITSERIAL], [AUDITRESULT], [AUDITMEMO], [AUDITDATE], [Auditor], [CreatorID], [CreateDate]) VALUES (@CNO, @DocVersion, @DocNumber, @DOCTYPE, @AUDITSERIAL, @AUDITRESULT, @AUDITMEMO, @AUDITDATE, @Auditor, @CreatorID, @CreateDate)" 
                                            UpdateCommand="UPDATE [DAHS_AuditResult] SET [DocNumber] = @DocNumber, [DOCTYPE] = @DOCTYPE, [AUDITSERIAL] = @AUDITSERIAL, [AUDITRESULT] = @AUDITRESULT, [AUDITMEMO] = @AUDITMEMO, [AUDITDATE] = @AUDITDATE, [Auditor] = @Auditor, [CreatorID] = @CreatorID, [CreateDate] = @CreateDate WHERE [CNO] = @CNO AND [DocVersion] = @DocVersion">
                                            <DeleteParameters>
                                                <asp:Parameter Name="CNO" Type="String" />
                                                <asp:Parameter Name="DocVersion" Type="String" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="CNO" Type="String" />
                                                <asp:Parameter Name="DocVersion" Type="String" />
                                                <asp:Parameter Name="DocNumber" Type="String" />
                                                <asp:Parameter Name="DOCTYPE" Type="String" />
                                                <asp:Parameter Name="AUDITSERIAL" Type="DateTime" />
                                                <asp:Parameter Name="AUDITRESULT" Type="String" />
                                                <asp:Parameter Name="AUDITMEMO" Type="String" />
                                                <asp:Parameter Name="AUDITDATE" Type="DateTime" />
                                                <asp:Parameter Name="Auditor" Type="String" />
                                                <asp:Parameter Name="CreatorID" Type="String" />
                                                <asp:Parameter Name="CreateDate" Type="DateTime" />
                                            </InsertParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="DocNumber" Type="String" />
                                                <asp:Parameter Name="DOCTYPE" Type="String" />
                                                <asp:Parameter Name="AUDITSERIAL" Type="DateTime" />
                                                <asp:Parameter Name="AUDITRESULT" Type="String" />
                                                <asp:Parameter Name="AUDITMEMO" Type="String" />
                                                <asp:Parameter Name="AUDITDATE" Type="DateTime" />
                                                <asp:Parameter Name="Auditor" Type="String" />
                                                <asp:Parameter Name="CreatorID" Type="String" />
                                                <asp:Parameter Name="CreateDate" Type="DateTime" />
                                                <asp:Parameter Name="CNO" Type="String" />
                                                <asp:Parameter Name="DocVersion" Type="String" />
                                            </UpdateParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                   <td>
                                        <asp:RadioButtonList ID="RBL_AuditResult" runat="server" Font-Names="微軟正黑體" 
                                            ForeColor="Black" Width ="200px" AutoPostBack="True" Font-Size="Medium">
                                            <asp:ListItem>審查通過</asp:ListItem>
                                            <asp:ListItem>須補正</asp:ListItem>
                                            <asp:ListItem>駁回</asp:ListItem>
                                            <asp:ListItem>不適用</asp:ListItem>
                                        </asp:RadioButtonList>                                        
                                        <dx:ASPxDateEdit ID="TB_Audit_DATE" runat="server" Caption="補正期限" MinDate="1970-01-01"></dx:ASPxDateEdit>YYYY-MM-DD                                        
                                    </td>
                                    <td class="style17" width="500">
                                        <dx:ASPxMemo ID="TB_AuditMemo" runat="server" Caption="審查意見" Font-Size="Medium" Height="100px" Width="800px">
                                            <CaptionSettings HorizontalAlign="Center" Position="Top" />
                                        </dx:ASPxMemo>
                                    </td>
                                    <td class="auto-style20">
                                        <asp:Button ID="BT_AuditSave" runat="server" Height="30px" Text="審查暫存" Width="100px" />
                                        <asp:Button ID="BT_Audit1" runat="server" Height="30px" Text="完成審查" Width="100px" />
                                        <asp:Button ID="BT_AuditAsst" runat="server" Height="30px" Text="審查助理" Width="100px" />
                                        <asp:Label ID="Label_Audit" runat="server"></asp:Label>
                                        <a onkeypress="previewScreen(PrintDiv1)" onclick="previewScreen(PrintDiv1)" style="text-decoration:none" target="_blank"> 
   <img src="images/Print_32x32.png"  width="32" height="32" alt="友善列印"/></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style16" align="center" colspan="3">
                                        <dx:ASPxGridView ID="GV_Audit" runat="server" Caption="審查案件管理系統" OnCustomUnboundColumnData="grid_CustomUnboundColumnData" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CNO,DOCVERSION,REG_DATE" DataSourceID="SqlDataSource1" Width="1024px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small" KeyFieldName="CNO">

                                            <Columns>
                                                <dx:GridViewCommandColumn VisibleIndex="0" Caption ="" >
                                                </dx:GridViewCommandColumn>
                                                <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="1" Caption="管制編號"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DOCVERSION" VisibleIndex="2" Caption="版號" ReadOnly="True"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="DOCTYPE" VisibleIndex="3" Caption="文書種類" ReadOnly="True"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="REG_DATE" VisibleIndex="4" Caption="申請日期"></dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="DOC_SERIAL" VisibleIndex="5" Caption="收文字號"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="DOC_RECDATE" VisibleIndex="6" Caption="本文號收件日期"></dx:GridViewDataDateColumn>
                                                <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" VisibleIndex="7" Caption="審查結果"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataDateColumn FieldName="EXAM_DOCOUT_DATE" VisibleIndex="9" Caption="完成本次審查結果（發文）日期"></dx:GridViewDataDateColumn>
                                                <dx:GridViewDataDateColumn FieldName="UPGRADE_DATE" VisibleIndex="10" Caption="補正期限"></dx:GridViewDataDateColumn>                                                
                                                <dx:GridViewDataTextColumn FieldName="OWNER" VisibleIndex="12" Caption="承辦人員"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="AGENT" VisibleIndex="13" Caption="代理人"></dx:GridViewDataTextColumn> 
                                                <dx:GridViewDataTextColumn FieldName="MEMO" VisibleIndex="14" Caption="備註"></dx:GridViewDataTextColumn>
                                                <dx:GridViewDataTextColumn FieldName="Total" Caption="審查天數" VisibleIndex="8" UnboundType="Decimal">
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
                                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" SearchPanelEditorNullText="輸入關鍵字查詢" />
                                            <SettingsBehavior EnableCustomizationWindow="True" AllowFocusedRow="True" AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessFocusedRowChangedOnServer="True" ProcessSelectionChangedOnServer="True" />
                                        </dx:ASPxGridView>
                                    </td>
                                    <td>
                                        <dx:ASPxListBox ID="Msglist" runat="server" Caption="系統勾稽異常內容" Font-Size="Medium" ForeColor="Red" Height="230px" ValueType="System.String" Width="500px">
                                            <ItemStyle ForeColor="Red" />
                                            <CaptionSettings HorizontalAlign="Center" Position="Top" />
                                        </dx:ASPxListBox>
                                    </td>
                                    <td></td>
                                    
                                </tr>
                            </table>
                                        </asp:Panel>        
    </div>
     <table>
        <tr>
            <td><dx:ASPxButton ID="BT_SendAudit" runat="server" Text="送審" Width="100px"></dx:ASPxButton>
                <dx:ASPxButton ID="BT_PRINT" runat="server" Text="列印" Width="100px"  >
                </dx:ASPxButton>
                <dx:ASPxButton ID="BT_CHANGEVERSION" runat="server" Text="版次變更" Width="100px" Enabled ="false" Visible ="false"   >
                </dx:ASPxButton>
                <dx:ASPxLabel ID="LABEL_VERSION" runat="server">
                </dx:ASPxLabel>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

   
    
        <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" EnableTheming="True" Height="1024px" Theme="Office2003Blue" Width="1680px" AutoPostBack="True">
        <TabPages>
            <dx:TabPage Text="壹、基本資料">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <br />
                        
                        <table style="width:100%;" border="1">
                            <tr>
                                <td colspan="2"><dx:ASPxLabel ID="ASPxLabel33" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="管制編號:" Width="100px">
                                    </dx:ASPxLabel></td>
                                <td><dx:ASPxTextBox ID="TB_BAS_FAC_CNO" runat="server" MaxLength="8" Width="170px" ReadOnly="True">
                                    </dx:ASPxTextBox></td>
                                <td width="160" >
                                    <dx:ASPxLabel ID="ASPxLabel32" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="事業或污水下水道系統名稱:" Width="200px">
                                    </dx:ASPxLabel>
                                </td>
                                <td >
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_NAME" runat="server" Width="400px"  > 
                                    </dx:ASPxTextBox>
                                </td>                                
                            </tr>                            
                            <tr>
                                <td class="auto-style10" valign="top" rowspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel34" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="一、事業別">
                                    </dx:ASPxLabel>
                                </td>
                                <td width="200" colspan="4">
                                    <asp:RadioButton ID="RBL_BAS_TYPE_B" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="事業" />
                                    <dx:ASPxTextBox ID="TB_BAS_TYPEB" runat="server" Caption="主業別" Font-Names="微軟正黑體" Font-Size="Medium" Width="400px">
                                    </dx:ASPxTextBox>
                                </td>
                                 
                            </tr>
                            <tr>
                                <td width="200" colspan="4">
                                    <asp:RadioButton ID="RBL_BAS_TYPE_I" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="污水下水道系統" />
                                    <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" Width="700px" ID="RBL_BAS_TYPEW" Font-Names="微軟正黑體" Font-Size="Medium">
                                         <asp:ListItem>工業區專用污水下水道系統</asp:ListItem>
                                        <asp:ListItem>公共污水下水道系統</asp:ListItem>                                        
                                        <asp:ListItem>指定地區或場所專用之污水下水道系統</asp:ListItem>
                                    </asp:RadioButtonList>

                                </td>
                            </tr>                            
                            <tr>
                                <td class="auto-style10" valign="top" rowspan="2"/>
                                    <dx:ASPxLabel ID="ASPxLabel35" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="二、廢(污)水排放量">
                                    </dx:ASPxLabel>
                                <td width="200" colspan="2" class="auto-style18">
                                    <dx:ASPxTextBox ID="TB_BAS_PERMITVOL" runat="server" Caption="核准許可廢(污)水排放量(立方公尺/日)" Font-Names="微軟正黑體" Font-Size="Medium" Width="400px">
                                    <ValidationSettings>
                                            <RequiredField ErrorText="必要填寫項目" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                    </td>
                                    <td colspan="2" style="width: 100px" width="200">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style18" colspan="2" width="200">
                                    <dx:ASPxTextBox ID="TB_BAS_OPVOL" runat="server" Caption="作業廢水及洩放廢水之排放量(立方公尺/日)" Font-Names="微軟正黑體" Font-Size="Medium" Width="400px">
                                    <ValidationSettings>
                                            <RequiredField ErrorText="必要填寫項目" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="2" style="width: 100px" width="200">&nbsp;</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style10" valign="top" rowspan="24">
                                    <dx:ASPxLabel ID="ASPxLabel65" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="三、設置依據">
                                    </dx:ASPxLabel>
                                    <td colspan="2" >                                        
                                        <asp:CheckBox ID="CB_RULE_31" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="水污染防治法第31條" />
                                    </td>                                    
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:CheckBox ID="CB_RULE_56" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="水污染防治措施及檢測申報管理辦法第56條" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_56_1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第1項第1款情形" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_56_2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第1項第2款情形" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_56_3" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第1項第3款情形" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_56_4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第1項第4款情形" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_56_5" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第1項第5款情形" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_56_6" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第1項第6款情形" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_56_7" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第2項情形" /></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:CheckBox ID="CB_RULE_57_1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="水污染防治措施及檢測申報管理辦法第57-1條" /></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:CheckBox ID="CB_RULE_105" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="水污染防治措施及檢測申報管理辦法第105條" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_1500_I" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="許可核准排放量達每日1,500CMD以上工業區專用污水下水道系統" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_5000_BUSSINESS" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="許可核准排放量達每日5,000CMD以上事業" /></td>
                            </tr>
                             <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_1500_BUSSINESS" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="許可核准排放量達每日1,500CMD以上、未達5,000CMD事業" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_5000_LIFE" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="許可核准排放量達每日5,000 CMD以上公共污水下水道系統" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_1500_LIFE" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="許可核准排放量達每日1,500 CMD以上、未達5,000 CMD公共污水下水道系統" /></td>
                            </tr>
                             <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_ELEC" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="發電廠" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_WATERCOOLER" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="排放未接觸冷卻水" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_E_EQUIP" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="採海水排煙脫硫空氣污染防制設施者" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_OTHER" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="其他經中央主管機關指定者" /></td>
                            </tr>
                            <tr>
                                <td colspan="2"><asp:CheckBox ID="CB_RULE_19" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="經濟部「特定工廠登記辦法」" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_19_4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第19條第4項情形" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_19_4_56" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="具第19條第4項情形，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="CB_RULE_19_56" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type" Text="屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者" /></td>
                            </tr>
                        </table>
                                               
                        <p>
                        </p>
                        <table style="width:100%;" border="1">                            
                            
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxLabel ID="ASPxLabel87" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="四、聯絡人及方式">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel36" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="聯絡人姓名:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CNAME" runat="server" MaxLength="20" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel37" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="聯絡電話:">
                                    </dx:ASPxLabel>
                                </td>
                                <td width="150">
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CTEL" runat="server" Width="170px">
                                        <ValidationSettings>
                                            <RegularExpression ValidationExpression="(02|03|037|04|049|05|06|07|08|082|0826|0836|089)-[0-9]{5,8}" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>xxx-xxxxxxxx                                    
                                </td>
                                <td width="55">
                                    <dx:ASPxLabel ID="ASPxLabel38" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="分機:" Width="50px">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CTEL_EXT" runat="server" Width="100px">                                        
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel39" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="行動電話:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CMOBILE" runat="server" Width="170px">
                                        <MaskSettings Mask="0000-000000" />
                                    </dx:ASPxTextBox>09xx-xxxxxx
                                    </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel67" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="傳真電話:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CFAX" runat="server" Width="170px">
                                        <ValidationSettings>
                                            <RegularExpression ValidationExpression="(02|03|037|04|049|05|06|07|08|082|0826|0836|089)-[0-9]{5,8}" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>xxx-xxxxxxxx
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel68" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="電子郵件地址:">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style5" colspan="3">
                                    <dx:ASPxTextBox ID="TB_BAS_FAC_CEMAIL" runat="server" Width="400px">
                                        <ValidationSettings>
                                <RegularExpression ErrorText="Email 格式不符" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxLabel ID="ASPxLabel85" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="五、申請類別(不可複選)">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" colspan="2">
                                    <asp:RadioButton ID="RBL_REG_SET" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type5" Text="設置(新申請)"   AutoPostBack="True" />
                                </td>
                                <td class="auto-style5" colspan="3">
                                    
                                    
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" colspan="2">
                                    <asp:RadioButton ID="RBL_REG_MODI" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type5" Text="變更"  AutoPostBack="True" />
                                </td>
                                <td class="auto-style5" colspan="3">
                                    <asp:CheckBox ID="CB_5_MOD_C" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type5mod" Text="設施汰換" />
                                    <asp:CheckBox ID="CB_5_MOD_D" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type5mod" Text="免除設置" />
                                    <asp:CheckBox ID="CB_5_MOD_OTHER" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="type5mod" Text="其他" />                                    
                                </td>
                            </tr>                          
                            <tr>
                                <td width="80">
                                    <dx:ASPxButton ID="BT_BASIC_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="BT_BASIC_CANCEL" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td colspan="3">&nbsp;</td>
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
                        <br /> 
                        <div>
                             <table style="width:100%;" border="1">
                                <tr>
                                    <td colspan="3"><dx:ASPxLabel ID="ASPxLabel86" runat="server" Text ="六、設置、汰換或變更連線傳輸設施及放流水水量、水質自動顯示看板"></dx:ASPxLabel></td>
                                </tr>
                                <tr>
                                    <td>
                                        <dx:ASPxCheckBox ID="CB_CWMS_LINK" runat="server" CheckState="Unchecked" Text="連線傳輸設施" Width="150px">
                                        </dx:ASPxCheckBox>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="CB_LINKRULE56" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="LINKRULE" Text="依水污染防治措施及檢測申報管理辦法第56條規定設置" />
                                        <br />
                                        <asp:RadioButton ID="CB_LINKRULE57_1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="LINKRULE" Text="依水污染防治措施及檢測申報管理辦法第57-1條規定設置" />
                                        <br />
                                        <asp:RadioButton ID="CB_LINKRULE105" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="LINKRULE" Text="依水污染防治措施及檢測申報管理辦法第105條規定設置" />
                                        <br />
                                        <asp:RadioButton ID="CB_LINKRULE19_4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" GroupName="LINKRULE" Text="依經濟部「特定工廠登記辦法」第19條第4項情形規定設置" />
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_LINKSET" runat="server" Caption="設置數量" Font-Names="微軟正黑體" Font-Size="Medium" Width="400px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>                                 
                                <tr>
                                    <td>
                                        <dx:ASPxCheckBox ID="CB_CWMS_LED" runat="server" CheckState="Unchecked" Text="放流水水量、水質自動顯示看板" Width="150px">
                                        </dx:ASPxCheckBox>
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="CB_LEDRULE_56" runat="server" Font-Names="微軟正黑體" Font-Size="Medium"  Text="水污染防治措施及檢測申報管理辦法第56條第2項規定設置" />
                                        <br />
                                        <br />                                        
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_LEDSET" runat="server" Caption="設置數量" Font-Names="微軟正黑體" Font-Size="Medium" Width="400px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td>
                                        <dx:ASPxButton ID="BT_PDF_DL" runat="server" Text="下載確認報告書申請確認書" Width="200px">
                                            <Image IconID="print_printviapdf_16x16">
                                            </Image>
                                        </dx:ASPxButton>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <dx:ASPxLabel ID="Label_NewMode" runat="server" Text="請上傳已簽署之確認報告書申請確認書(JPG)">
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td><dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="附件:"></dx:ASPxLabel>
                                        <asp:DropDownList ID="DDL_New" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="auto-style24">
                                        <dx:ASPxLabel ID="Label_ModifyMode" runat="server" Text="請上傳已簽署之確認報告書變更申請確認書(PDF)" Visible ="false" >
                                        </dx:ASPxLabel>
                                    </td>
                                    <td class="auto-style24"></td>
                                    <td class="auto-style24"></td>
                                </tr>
                                <tr>
                                    <td><dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="附件:" Visible="False"></dx:ASPxLabel>
                                        <asp:DropDownList ID="DDL_Modify" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True" Visible="False">
                                            <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                    <td colspan="3">
                                        <dx:ASPxLabel ID="ASPxLabel89" runat="server" Text="請上傳已核可之確認報告書掃瞄電子檔(PDF)" >
                                        </dx:ASPxLabel>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                 <tr>
                                    <td><dx:ASPxLabel ID="ASPxLabel50" runat="server" Text="附件:"></dx:ASPxLabel>
                                        <asp:DropDownList ID="DDL_BATCH3" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                            <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;</td>
                                </tr>  
                            </table>
                            <asp:Literal ID="Literal1" runat="server" Visible ="false" ></asp:Literal>
                            </div>                       

                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="貳、自動監測(視)設施資料">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <br />
                        <dx:ASPxLabel ID="Label_DocVersion" runat="server">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel90" runat="server" Text ="一、設置、汰換或變更自動監測（視）設施位置及種類">
                        </dx:ASPxLabel>
                        <dx:ASPxGridView ID="GV_SETITEM" runat="server" AutoGenerateColumns="False" Caption="設置、汰換或變更自動監測（視）設施位置及種類(可複選，列次不足者請自行增列填寫)" DataSourceID="SDS_ITEM" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION;DOCTYPE" Width="800px">

<EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" Caption ="" >
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO"  ShowInCustomizationForm="True" VisibleIndex="2" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Caption="位置編號" FieldName="DP_NO" ShowInCustomizationForm="True" VisibleIndex="3"  >
                                     <PropertiesTextEdit MaxLength="6">
                                     </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="版號" FieldName="DOCVERSION" ShowInCustomizationForm="True" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="文件種類" FieldName="DOCTYPE" ShowInCustomizationForm="True" VisibleIndex="4" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="水量" FieldName="ITEM_248" ShowInCustomizationForm="True" VisibleIndex="7">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="水溫" FieldName="ITEM_259" ShowInCustomizationForm="True" VisibleIndex="8">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="氫離子濃度指數" FieldName="ITEM_246" ShowInCustomizationForm="True" VisibleIndex="9">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="導電度" FieldName="ITEM_247" ShowInCustomizationForm="True" VisibleIndex="10">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="化學需氧量" FieldName="ITEM_243" ShowInCustomizationForm="True" VisibleIndex="11">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="懸浮固體" FieldName="ITEM_210" ShowInCustomizationForm="True" VisibleIndex="12">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="攝錄影監視" FieldName="ITEM_VIDEO" ShowInCustomizationForm="True" VisibleIndex="13">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="氨氮" FieldName="ITEM_242" ShowInCustomizationForm="True" VisibleIndex="14">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="其他" FieldName="ITEM_OTHER" ShowInCustomizationForm="True" VisibleIndex="15">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>                                
                                <dx:GridViewDataCheckColumn Caption="用電量" FieldName="ITEM_299" ShowInCustomizationForm="True" VisibleIndex="16">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>                               
                                <dx:GridViewDataComboBoxColumn Caption="位置種類" FieldName="DPTYPE" ShowInCustomizationForm="True" VisibleIndex="5">
                                    <PropertiesComboBox>
                                        <Items>
                                            <dx:ListEditItem Text="進流口" Value="進流口" />
                                            <dx:ListEditItem Text="放流口" Value="放流口" />
                                            <dx:ListEditItem Text="處理單元(進流口)" Value="處理單元(進流口)" />
                                            <dx:ListEditItem Text="處理單元(出流口)" Value="處理單元(出流口)" />
                                            <dx:ListEditItem Text="雨水放流口" Value="雨水放流口" />
                                            <dx:ListEditItem Text="用水來源-自來水" Value="用水來源-自來水" />
                                            <dx:ListEditItem Text="用水來源-地下水" Value="用水來源-地下水" />
                                            <dx:ListEditItem Text="用水來源-河湖海水" Value="用水來源-河湖海水" />
                                            <dx:ListEditItem Text="用水來源-回收水" Value="用水來源-回收水" />
                                            <dx:ListEditItem Text="用水貯存區進入製程前" Value="用水貯存區進入製程前" />
                                            <dx:ListEditItem Text="電子式電度表" Value="電子式電度表" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn Caption="許可證水流編號" FieldName ="PERMIT_SERIAL" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Caption="涵蓋之廢（污）水（前）處理設施編號(電子式電度表適用)" FieldName ="EM_COVER" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                            </Columns>                        
<SettingsAdaptivity>
<AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
</SettingsAdaptivity>

                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <dx:ASPxButton ID="ASPxButton8" runat="server" Text="選定資料" Width="80px"></dx:ASPxButton>
                        <asp:SqlDataSource ID="SDS_ITEM" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                            DeleteCommand="DELETE FROM [DOC_VRY_ITEM] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" 
                            InsertCommand="INSERT INTO [DOC_VRY_ITEM] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [DOCTYPE], [PERMIT_SERIAL], [EM_COVER], [ITEM_248], [ITEM_259], [ITEM_246], [ITEM_247], [ITEM_243], [ITEM_210], [ITEM_VIDEO], [ITEM_242], [ITEM_WATER], [ITEM_GROUND], [ITEM_RIVER], [ITEM_RECYCLE], [ITEM_299], [ITEM_OTHER], [OTHER_DESP], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @DOCTYPE, @PERMIT_SERIAL, @EM_COVER, @ITEM_248, @ITEM_259, @ITEM_246, @ITEM_247, @ITEM_243, @ITEM_210, @ITEM_VIDEO, @ITEM_242, @ITEM_WATER, @ITEM_GROUND, @ITEM_RIVER, @ITEM_RECYCLE, @ITEM_299, @ITEM_OTHER, @OTHER_DESP, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                            SelectCommand="SELECT * FROM [DOC_VRY_ITEM] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION) AND (ITEM_210 is not null))" 
                            UpdateCommand="UPDATE [DOC_VRY_ITEM] SET [PERMIT_SERIAL] = @PERMIT_SERIAL, [EM_COVER] = @EM_COVER, [ITEM_248] = @ITEM_248, [ITEM_259] = @ITEM_259, [ITEM_246] = @ITEM_246, [ITEM_247] = @ITEM_247, [ITEM_243] = @ITEM_243, [ITEM_210] = @ITEM_210, [ITEM_VIDEO] = @ITEM_VIDEO, [ITEM_242] = @ITEM_242, [ITEM_WATER] = @ITEM_WATER, [ITEM_GROUND] = @ITEM_GROUND, [ITEM_RIVER] = @ITEM_RIVER, [ITEM_RECYCLE] = @ITEM_RECYCLE, [ITEM_299] = @ITEM_299, [ITEM_OTHER] = @ITEM_OTHER, [OTHER_DESP] = @OTHER_DESP, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">
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
                                <asp:Parameter Name="PERMIT_SERIAL" Type="String" />
                                <asp:Parameter Name="EM_COVER" Type="String" />
                                <asp:Parameter Name="ITEM_248" Type="String" />
                                <asp:Parameter Name="ITEM_259" Type="String" />
                                <asp:Parameter Name="ITEM_246" Type="String" />
                                <asp:Parameter Name="ITEM_247" Type="String" />
                                <asp:Parameter Name="ITEM_243" Type="String" />
                                <asp:Parameter Name="ITEM_210" Type="String" />
                                <asp:Parameter Name="ITEM_VIDEO" Type="String" />
                                <asp:Parameter Name="ITEM_242" Type="String" />
                                <asp:Parameter Name="ITEM_WATER" Type="String" />
                                <asp:Parameter Name="ITEM_GROUND" Type="String" />
                                <asp:Parameter Name="ITEM_RIVER" Type="String" />
                                <asp:Parameter Name="ITEM_RECYCLE" Type="String" />
                                <asp:Parameter Name="ITEM_299" Type="String" />
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
                                <asp:Parameter Name="PERMIT_SERIAL" Type="String" />
                                <asp:Parameter Name="EM_COVER" Type="String" />
                                <asp:Parameter Name="ITEM_248" Type="String" />
                                <asp:Parameter Name="ITEM_259" Type="String" />
                                <asp:Parameter Name="ITEM_246" Type="String" />
                                <asp:Parameter Name="ITEM_247" Type="String" />
                                <asp:Parameter Name="ITEM_243" Type="String" />
                                <asp:Parameter Name="ITEM_210" Type="String" />
                                <asp:Parameter Name="ITEM_VIDEO" Type="String" />
                                <asp:Parameter Name="ITEM_242" Type="String" />
                                <asp:Parameter Name="ITEM_WATER" Type="String" />
                                <asp:Parameter Name="ITEM_GROUND" Type="String" />
                                <asp:Parameter Name="ITEM_RIVER" Type="String" />
                                <asp:Parameter Name="ITEM_RECYCLE" Type="String" />
                                <asp:Parameter Name="ITEM_299" Type="String" />
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
                        <dx:ASPxGridView ID="GV_SPEC" runat="server" Caption="自動監測(視)設施資料總表" Width="600px" AutoGenerateColumns="False" DataSourceID="SDS_SPEC_GV" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION;ITEM">

<EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0" Caption="">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="DPTYPE" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Caption="種類"  >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="7" Visible ="false"  >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ITEM" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Caption="監測項目編號">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DP_NO" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="6" Visible ="false" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CNO" ShowInCustomizationForm="True" VisibleIndex="5" ReadOnly="True" Visible ="false"  >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DPNO_DESP" ShowInCustomizationForm="True" VisibleIndex="4" Caption="位置">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="監測項目說明" FieldName="DESP" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                            </Columns>
<SettingsAdaptivity>
<AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
</SettingsAdaptivity>

                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="SDS_SPEC_GV" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                            SelectCommand="SELECT DOC_VRY_SPEC.DPTYPE, DOC_VRY_SPEC.DOCVERSION, DOC_VRY_SPEC.ITEM, DOC_VRY_SPEC.DP_NO, DOC_VRY_SPEC.CNO, DOC_VRY_SPEC.DPNO_DESP, CODE1.DESP FROM DOC_VRY_SPEC INNER JOIN CODE1 ON DOC_VRY_SPEC.ITEM = CODE1.ITEM WHERE DOC_VRY_SPEC.CNO=@CNO AND DOC_VRY_SPEC.DP_NO=@DP_NO AND DOC_VRY_SPEC.DOCVERSION=@DOCVERSION AND DOC_VRY_SPEC.ITEM NOT IN('241','267')">
                            <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                            <asp:SessionParameter Name="DP_NO" SessionField="DP_NO" Type="String" />
                                            <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
                                        </SelectParameters>
                        </asp:SqlDataSource>
                        <dx:ASPxButton ID="ASPxButton9" runat="server" Text="取得資料" Width="80px">
                        </dx:ASPxButton>
                        <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="800px">
                            <panelcollection>
                                <dx:PanelContent runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="auto-style9">
                                                <dx:ASPxTextBox ID="TB_SPEC_DPNODESP" runat="server" Caption="監測位置編號" Width="170px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td class="auto-style8">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
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
                                                        <dx:ListEditItem Text="氫離子濃度指數" Value="246" />
                                                        <dx:ListEditItem Text="導電度" Value="247" />
                                                        <dx:ListEditItem Text="化學需氧量" Value="243" />
                                                        <dx:ListEditItem Text="懸浮固體" Value="210" />
                                                        <dx:ListEditItem Text="攝錄影監視" Value="330" />
                                                        <dx:ListEditItem Text="氨氮" Value="242" />
                                                        <dx:ListEditItem Text="用電量" Value="299" />
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
                                <td class="auto-style2" colspan="6" width="500">                                                    
                                     <asp:RadioButton ID="RBL_SPEC_INSTEAD_YES" runat="server" GroupName="SPEC_INSTEAD" Text="是(核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本見附件" />&nbsp;<asp:RadioButton ID="RBL_SPEC_INSTEAD_NO" runat="server" Text="否" GroupName="SPEC_INSTEAD" />
                                    &nbsp;<dx:ASPxLabel ID="ASPxLabel52" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL1" runat="server" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" AppendDataBoundItems="True">
                                                   <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                     </asp:DropDownList>
                                    <asp:SqlDataSource ID="SDS_PDF_DDL" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        SelectCommand="SELECT [DocNumber] FROM [DOC_PDF_BASIC] WHERE (([CNO] = @CNO) AND ([DocVersion] = @DocVersion))">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                            <asp:SessionParameter Name="DocVersion" SessionField="DocVersion" Type="String" />
                                        </SelectParameters>
                                     </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel40" runat="server" Text="(二)本監測設施是否同時監測其他位置">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style2" colspan="6" width="400" >
                                    <asp:RadioButton ID="RBL_MONITOROTHER_YES" runat="server" Text="是,與位置編號:" GroupName="MONITOROTHER" />                                    
                                    <dx:ASPxTextBox ID="TB_SPEC_MO_NOTE_DPNO" runat="server" MaxLength="10" Width="150px" style="margin:0px;display: inline">
                                    </dx:ASPxTextBox>
                                    共設
                                    <dx:ASPxTextBox ID="TB_SPEC_MO_NOTE_DPNO1" runat="server" MaxLength="10" Width="40px" style="margin:0px;display: inline">
                                    </dx:ASPxTextBox>處                                 
                                    <asp:RadioButton ID="RBL_MONITOROTHER_NO" runat="server" Text="否" style="margin:0px;display: inline" GroupName="MONITOROTHER" />&nbsp;
                                    <br />
                                    <dx:ASPxLabel ID="ASPxLabel54" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL2" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>         
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel8" runat="server" Text="(三)安裝日期">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxDateEdit ID="TB_SPEC_INS_DATE" runat="server" MinDate="1970-01-01">
                                    </dx:ASPxDateEdit>(必填)YYYY-MM-DD
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="(四)監測設施之製造商或代理商">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="TB_SPEC_AGENTNAME" runat="server" Width="250px" MaxLength ="50">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel10" runat="server" Text="(五)型號" >
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="TB_SPEC_EQU_MODEL" runat="server" Width="250px" MaxLength="250">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="(六)序號">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="TB_SPEC_EQU_SERIAL" runat="server" Width="250px" MaxLength="250">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3" >
                                    <dx:ASPxLabel ID="ASPxLabel12" runat="server" Text="(七)量測方式(分析方法)">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="TB_SPEC_SAMPLE_METHOD" runat="server" Width="250px" MaxLength="25" Caption ="NIEA">
                                    </dx:ASPxTextBox>
                                    <dx:ASPxTextBox ID="TB_SPEC_SAMPLE_METHOD_DESP" runat="server" Width="250px" MaxLength="25" Caption ="( ">
                                    </dx:ASPxTextBox>                               
                                    <dx:ASPxLabel ID="ASPxLabel51" runat="server" Text="核准採行替代量測方式具體說明及報經主管機關核准採行之核准公文影本見附件"></dx:ASPxLabel>
                                    <asp:RadioButton ID="RB_SPEC_SAMPLE_METHOD_FilterYes" runat="server" Text="有過濾器/前處理裝置，影響說明" GroupName="SPEC_SampleMethod" />&nbsp;<asp:RadioButton ID="RB_SPEC_SAMPLE_METHOD_FilterNO" runat="server" GroupName="SPEC_SampleMethod" Text="無過濾器/前處理裝置" />
                                    &nbsp;<dx:ASPxLabel ID="ASPxLabel55" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL7" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                                   
                            </tr>                            
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="(八)校正器材">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
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
                                <td colspan="3">
                                    <asp:RadioButtonList ID="RBL_SPEC_CALC_FREQMETHOD" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>擬自行校正</asp:ListItem>
                                        <asp:ListItem>擬委外校正</asp:ListItem>
                                        <asp:ListItem>不適用</asp:ListItem>
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
                                <td colspan="3">
                                    <asp:RadioButtonList ID="RBL_SPEC_MAIN_FREQMETHOD" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>擬自行保養</asp:ListItem>
                                        <asp:ListItem>擬委外保養</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel16" runat="server" Text="(十一)耗材內容">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" rowspan="2">
                                    <dx:ASPxTextBox ID="TB_SPEC_MATERIAL" runat="server" Width="250px" MaxLength="100">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="RBL_SPEC__WASTELIQUID" runat="server">
                                        <asp:ListItem>無產生廢液(材)</asp:ListItem>
                                        <asp:ListItem>有產生廢液(材),儲存清理方式說明(詳附件)</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <dx:ASPxLabel ID="ASPxLabel56" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL11" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                                
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel17" runat="server" Text="(十二)耗材應更換頻率">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="TB_SPEC_MATERIAL_FREQ" runat="server" Width="170px" MaxLength="10">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    <dx:ASPxLabel ID="ASPxLabel18" runat="server" Text="(十三)量測範圍">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" >
                                    <dx:ASPxTextBox ID="TB_SPEC_MEA_SCOPE" runat="server" Width="300px" MaxLength="50">
                                    </dx:ASPxTextBox>
                                </td>
                                <td width="40">
                                    <dx:ASPxLabel ID="ASPxLabel43" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" >                                    
                                    <asp:DropDownList ID="DDL_SPEC_MEA_SCOPEUNIT" runat="server">
                                        <asp:ListItem>mg/L</asp:ListItem>
                                        <asp:ListItem>---</asp:ListItem>
                                        <asp:ListItem>umho/cm</asp:ListItem>
                                        <asp:ListItem>m3</asp:ListItem>
                                        <asp:ListItem>℃</asp:ListItem>
                                        <asp:ListItem>m/分鐘</asp:ListItem>
                                        <asp:ListItem>度</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SDS_UNIT" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" SelectCommand="SELECT [UnitName] FROM [DOC_UNIT]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23">
                                    <dx:ASPxLabel ID="ASPxLabel19" runat="server" Text="(十四)應答時間(儀器每次取樣至完成分析所需之時間)">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" class="auto-style23">
                                    <dx:ASPxTextBox ID="TB_SPEC_MEA_RESTIME" runat="server" Width="170px" MaxLength="5">
                                    </dx:ASPxTextBox>
                                </td>
                                <td width="40" class="auto-style23">
                                    <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" class="auto-style23">                                    
                                    <asp:DropDownList ID="DDL_SPEC_MEA_RESTIMEUNIT" runat="server" DataSourceID="SDS_UNIT" DataTextField="UnitName" DataValueField="UnitName">
                                    </asp:DropDownList>
                                </td>
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
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">                                    
                                    <asp:DropDownList ID="DDL_SPEC_MEA_FREQUNIT" runat="server" DataSourceID="SDS_UNIT" DataTextField="UnitName" DataValueField="UnitName">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel21" runat="server" Text="(十六)監測紀錄值為幾個等時距監測數據之算術平均值">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="TB_SPEC_CALCAVG" runat="server" Width="170px" MaxLength="5">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4" rowspan="4">
                                    <dx:ASPxLabel ID="ASPxLabel22" runat="server" Text="(十七)補充說明及相關證明文件影本">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                   <dx:ASPxCheckBox ID="CB_DOC_Cali" runat="server" CheckState="Unchecked" Text="設施製造商校正方式及周期說明(詳附件)" AutoPostBack="True">
                                    </dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel57" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL17A" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">                                    
                                     <dx:ASPxCheckBox ID="CB_DOC_MainPlan" runat="server" CheckState="Unchecked" Text="維修保養合約書或計畫書(如附件)" AutoPostBack="True" ></dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel59" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL17B" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                         <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                     </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">                                    
                                     <dx:ASPxCheckBox ID="CB_DOC_RATA" runat="server" CheckState="Unchecked" Text="水質自動監測設施相對誤差測試報告(如附件)" AutoPostBack="True" ></dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel60" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL17C" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                         <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                     </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">                                    
                                     <dx:ASPxCheckBox ID="CB_DOC_EM" runat="server" CheckState="Unchecked" Text="電子式電度表規格符合國家標準說明(如附件)" AutoPostBack="True" ></dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel61" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL17D" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                         <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                     </asp:DropDownList>
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
                                <td colspan="2">

                                    <asp:RadioButtonList ID="RBL_VIDEO_F" runat="server" Width="170px">
                                        <asp:ListItem>MPEG</asp:ListItem>
                                        <asp:ListItem>H.264</asp:ListItem>
                                        <asp:ListItem>AVI</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                        <asp:ListItem Selected="True">不適用</asp:ListItem>                                        
                                    </asp:RadioButtonList>

                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_VIDEO_F" runat="server" Width="170px" Caption ="其他說明">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel46" runat="server" Text="解析度:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="RBL_VIDEO_R" runat="server">
                                        <asp:ListItem>640X480</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                        <asp:ListItem Selected="True">不適用</asp:ListItem>                                        
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_VIDEO_R" runat="server" Caption="其他說明" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="夜視功能:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="RBL_VIDEO_NV" runat="server">
                                        <asp:ListItem>有</asp:ListItem>
                                        <asp:ListItem>無</asp:ListItem>
                                        <asp:ListItem Selected="True">不適用</asp:ListItem>                                        
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_VIDEO_NV" runat="server" Caption="其他說明" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td></td>
                            </tr>
                             <tr>
                                <td rowspan="5">(十九)輸出訊號格式</td>
                                <td>
                                    <asp:RadioButton ID="CB_19_Analog" runat="server"  Text="類比訊號" GroupName ="Signal" AutoPostBack="True" ></asp:RadioButton>
                                </td>
                                <td colspan="5">
                                    <asp:DropDownList ID="DDL_19_Analog" runat="server" Width="120px" DataSourceID="SDS_SIGNAL" DataTextField="SINGALNAME" DataValueField="SINGALNAME">                                    
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SDS_SIGNAL" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" SelectCommand="SELECT [SINGALNAME] FROM [DOC_SINGAL] WHERE ([SINGALID] = @SINGALID)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="ANALOG" Name="SINGALID" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                
                                <td >
                                    <asp:RadioButton ID="CB_19_Digital" runat="server"  Text="數位訊號" GroupName ="Signal" AutoPostBack="True" ></asp:RadioButton>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="TB_19_DIGTAL" runat="server" Width="170px"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxCheckBox ID="CB_DO_HARDWARE_CONNECT" runat="server" CheckState="Unchecked" Text="該數位介面之硬體連接方法說明">
                                    </dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel62" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL19A" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxCheckBox ID="CB_DO_HARDWARE_CONNPARA" runat="server" AutoPostBack="True" CheckState="Unchecked" Text="該數位設備之連接參數資料">
                                    </dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel63" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL19B" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxCheckBox ID="CB_DO_HARDWARE_DOC" runat="server" AutoPostBack="True" CheckState="Unchecked" Text="引用此介面之相關功能文件">
                                    </dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel64" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL19C" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                             <tr>
                                <td class="auto-style4" >
                                    <dx:ASPxLabel ID="ASPxLabel41" runat="server" Text="備註">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                   <dx:ASPxMemo ID="TB_Note" runat="server" Caption="備註說明文字" Font-Size="Medium" Height="100px" Width="800px">
                                            <CaptionSettings HorizontalAlign="Center" Position="Top" />
                                        </dx:ASPxMemo>
                                </td>
                                 <td colspan="3"><dx:ASPxLabel ID="ASPxLabel66" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL20" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                     &nbsp;</td>
                            </tr>
                           <tr>
                                <td class="auto-style4" rowspan="3">
                                    <dx:ASPxLabel ID="ASPxLabel49" runat="server" Text="四、數據採擷及處理系統(DAHS)規格">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel23" runat="server" Text="(一)I/O模組或PLC廠牌">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">

                                    <dx:ASPxTextBox ID="TB_SPEC_PLCAGENT" runat="server" Width="170px">
                                    </dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel24" runat="server" Text="(二)使用之通訊規格" Width="200px">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">

                                    <asp:RadioButtonList ID="RBL_SPEC_COSPEC" runat="server" Width="180px">
                                        <asp:ListItem Selected="True">Modbus TCP</asp:ListItem>
                                        <asp:ListItem>Modbus RTU</asp:ListItem>
                                        <asp:ListItem>RS-232</asp:ListItem>
                                        <asp:ListItem>RS-485</asp:ListItem>
                                        <asp:ListItem>USB</asp:ListItem>
                                        <asp:ListItem>LPT</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <dx:ASPxTextBox ID="TB_SPEC_COSPEC" runat="server" Width="170px" Caption="其他說明">
                                    </dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel58" runat="server" Text="(三)監測數據、訊號是否可經由人工異動">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">

                                    <asp:RadioButtonList ID="RBL_SPEC_H_CHANGE" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">否</asp:ListItem>
                                        <asp:ListItem>可</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <dx:ASPxTextBox ID="TB_SPEC_H_CHANGE_NOTE" runat="server" Width="170px" Caption ="原因">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>                        
                            <tr>
                                <td>五、各項自動監測(視)設施設置位置圖(與廢水處理設施相對位置)</td>
                                <td colspan="2"><dx:ASPxLabel ID="ASPxLabel70" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL5" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>六、各項自動監測(視)設施設置位置圖(與廠區相對位置)</td>
                                <td colspan="2"><dx:ASPxLabel ID="ASPxLabel71" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL6" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>七、各項自動監測(視)設施及電子式電度表設置完工圖</td>
                                <td colspan="2"><dx:ASPxLabel ID="ASPxLabel72" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL27" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style14">
                                    <dx:ASPxButton ID="BT_SPEC_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="BT_SPEC_CANCEL" runat="server" Text="取消" Width="80px">
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
                       

                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="叁、數據採擷及處理系統資料">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                       
            <table  style="width:100%;" border="1">
                                        <tr>
                                            <td rowspan ="8">一、數據採擷及處理系統(DAHS)</td>
                                            <td width="330px">(一)數據擷取及處理系統涵蓋位置編號:</td>
                                            <td>
                                                <asp:TextBox ID="TB_DAHS_DPNO" runat="server" MaxLength="400" Width="400px" Wrap="False" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>                                            
                                            <td>(二)實際完成日期:</td>
                                            <td><dx:ASPxDateEdit ID="TB_DAHS_PLAN_INSDATE" runat="server" MinDate="1970-01-01">
                                                <DateRangeSettings MinErrorText="日期必需大於或等於 {0} " />
                                                </dx:ASPxDateEdit>YYYY-MM-DD
                                            </td>
                                        </tr>
                                        <tr>                                            
                                            <td class="dxflEmptyItem_Aqua">(三)系統建置之負責公司:</td>
                                            <td class="dxflEmptyItem_Aqua"><asp:TextBox ID="TB_DAHS_AGENT" runat="server" MaxLength="50" Width="400px" Wrap="False" ></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>                                            
                                            <td class="auto-style25">(四)DAHS系統具有備援功能:</td>
                                            <td class="auto-style25">
                                                    <asp:RadioButtonList ID="RBL_DAHS_REDANDENT" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem>是</asp:ListItem>
                                                        <asp:ListItem Selected="True">否</asp:ListItem>
                                                    </asp:RadioButtonList>
                                            </td>
                                            
                                        </tr>
                                        <tr>                                            
                                            <td>(五)設置監控中心管理監測數據:</td>
                                            <td>
                                                <asp:RadioButtonList ID="RBL_DAHS_CONTROLROOM" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                           
                                        </tr>
                                        <tr>                                            
                                            <td>(六)DAHS監測數據為直接傳輸，未透過其他單位主機或雲端機房代為傳輸:</td>
                                            <td> <asp:RadioButtonList ID="RBL_CLOUD" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">是</asp:ListItem>
                                                    <asp:ListItem>否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td class="auto-style10">
                                                (七)維修保養：</td>
                                            <td>
                                                <asp:RadioButtonList ID="RBL_MAINTAINMETHOD" runat="server" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem>自行保養</asp:ListItem>
                                                    <asp:ListItem Selected="True">委外保養</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>                                        
                                        <tr>
                                            <td class="auto-style10" >(八)補充說明及相關證明文件影本：</td>                                            
                                            <td><asp:CheckBox runat="server" Text="系統維修保養說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_DAHS_DOCATTACH" ></asp:CheckBox>
                                                &nbsp;<dx:ASPxLabel ID="ASPxLabel73" runat="server" Text="附件:"></dx:ASPxLabel>
                                                <asp:DropDownList ID="DDL318" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="請選擇"> 請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                                        </tr>                                    
                                        <tr>
                                            <td rowspan ="3">二、監測紀錄值保留(存)之檔案格式：</td>
                                        <td width="330px">(一)水量、水質監測紀錄值產生頻率符合規範:</td>
                                            <td><asp:RadioButtonList ID="RBL_FITFREQ" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value ="是" Text ="測試通過">測試通過</asp:ListItem>
                                                    <asp:ListItem Value ="否" Text ="否" >否</asp:ListItem>
                                                </asp:RadioButtonList></td>                                            
                                        </tr>
                                        <tr>
                                            <td>(二)水量、水質監測紀錄值儲存格式符合「自動監測（視）及連線傳輸數據類別及格式」:</td>
                                            <td><asp:RadioButtonList ID="RBL_FITFORMAT" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value ="是" Text ="測試通過">測試通過</asp:ListItem>
                                                    <asp:ListItem Value ="否" Text ="否">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>(三)資料檔案168小時測試預計開始時間:</td>
                                            <td><dx:ASPxDateEdit ID="DE_DAHS_STAR168DATE" runat="server" MinDate="1970-01-01"></dx:ASPxDateEdit>YYYY-MM-DD
                                            </td>
                                        </tr>                                    
                                         <tr>
                                            <td colspan ="3" >
                                                三、實際數據採擷及處理系統網路配置圖（網路配置圖，應清楚標示自動監測（視）設施之訊號傳輸流程及方式）
                                                <dx:ASPxLabel ID="ASPxLabel74" runat="server" Text="附件:"></dx:ASPxLabel>
                                                <asp:DropDownList ID="DDL33" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                                        </tr></table>
                        <p>
                        </p>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style13">
                                    <dx:ASPxButton ID="BT_DAHS_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td class="auto-style11">
                                    <dx:ASPxButton ID="BT_DAHS_CANCEL" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <asp:Label ID="Label_DAHS" runat="server" ForeColor="White"></asp:Label>                                    
                                </td>
                            </tr>
                        </table>
                        </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="肆、連線傳輸設施資料">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        

                         <table  style="width:100%;" border="1">
                                        <tr>
                                            <td class="auto-style11" rowspan="16">一、連線傳輸規格</td>
                                            <td colspan ="3"><dx:ASPxTextBox ID="TB_Link_COVERDPNO" runat="server" MaxLength="250"  Width="270px" Caption ="(一)連線傳輸設施涵蓋監測位置編號">
                                    </dx:ASPxTextBox>
                                                &nbsp;</td>                                            
                                        </tr>
                                        <tr>
                                            <td rowspan="4" class="auto-style10">
                                                (二)電腦主機：</td>
                                            <td class="auto-style31">中央處理器：<asp:TextBox ID="TB_Link_CemsPCCpu" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                                            </td>
                                            <td>網&nbsp; 路 卡：<asp:TextBox ID="TB_Link_CemsPCNetcard" runat="server" MaxLength="150" Width="200px"></asp:TextBox>
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
                                                硬 碟 空 間：<asp:TextBox ID="TB_Link_CemsPCHDD" runat="server" Height="17px" MaxLength="50" Width="200px"></asp:TextBox>
                                            
                                                <td>防 火 牆：<asp:TextBox ID="TB_Link_CemsPCFirewall" runat="server" MaxLength="50" Width="200px" Wrap="False"></asp:TextBox>
                                                </td>
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
                                    <td class="auto-style10" rowspan="7">(三)對外連線傳輸網路(不可複選)：
                                            <td bgcolor="#66FFCC" colspan="2">監測紀錄值傳輸網路</td>
                                            </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RBL_Link_NetworkLineType" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True">ADSL專線</asp:ListItem>
                                            <asp:ListItem>廠內既有網路</asp:ListItem>
                                            <asp:ListItem>不適用</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RBL_Link_NetworkIPType" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True">伺服器固定IP位址</asp:ListItem>
                                            <asp:ListItem>無固定IP</asp:ListItem>
                                            <asp:ListItem>不適用</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <dx:ASPxTextBox ID="TB_Link_NetworkIPType_IP" runat="server" Caption="伺服器固定IP位址" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="#66FFCC" colspan="2">攝錄影監視影像傳輸</td>
                                </tr>
                                <tr>
                                    <td class="auto-style12" colspan="2">
                                        <asp:RadioButtonList ID="RBL_Link_VIDEONetworkLineType" runat="server" RepeatDirection="Horizontal" >
                                            <asp:ListItem>廠內既有網路</asp:ListItem>
                                            <asp:ListItem>ADSL專線</asp:ListItem>
                                            <asp:ListItem Selected="True">不適用</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style12" colspan="2">
                                        <asp:RadioButtonList ID="RBL_Link_VIDEONetworkIPType" runat="server" RepeatDirection="Horizontal" >
                                            <asp:ListItem>伺服器固定IP位址</asp:ListItem>
                                            <asp:ListItem>無固定IP</asp:ListItem>
                                            <asp:ListItem Selected="True">不適用</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <dx:ASPxTextBox ID="TB_Link_VIDEONetworkIPType_IP" runat="server" Caption="伺服器固定IP位址" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RBL_Link_NetworkPORT" runat="server" RepeatDirection="Horizontal" Width="200px">
                                            <asp:ListItem>80</asp:ListItem>
                                            <asp:ListItem>86</asp:ListItem>
                                            <asp:ListItem>8080</asp:ListItem>
                                            <asp:ListItem>其他</asp:ListItem>
                                            <asp:ListItem Selected="True">不適用</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <dx:ASPxTextBox ID="TB_Link_NetworkPORT_OTHER" runat="server" Caption="其他PORT號" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                        <tr>
                                            <td class="auto-style10">
                                                (四)維修保養：</td>
                                            <td colspan="2">
                                                <asp:RadioButtonList ID="RBL_Link_MaintainType" runat="server" 
                                                    RepeatDirection="Horizontal">
                                                    <asp:ListItem>自行保養</asp:ListItem>
                                                    <asp:ListItem Selected="True">委外保養</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>                                        
                                        <tr>
                                            <td class="auto-style10" rowspan="3">(五)補充說明及相關證明文件影本：</td>
                                            <td class="auto-style29">設施製造商維修保養說明</td>
                                            <td class="auto-style26"><dx:ASPxLabel ID="ASPxLabel75" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL415A" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True" CssClass="auto-style30">
                                        <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                             <tr>
                                            <td class="auto-style31">維修保養合約書或計畫書</td>
                                            <td><dx:ASPxLabel ID="ASPxLabel76" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL415B" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style31">連線傳輸設施設置確認書</td>
                                            <td><dx:ASPxLabel ID="ASPxLabel77" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL415C" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                二、實際連線傳輸設施設置位置圖（網路配置圖，應清楚標示自動監測（視）設施之訊號傳輸流程及方式）
                                                <dx:ASPxLabel ID="ASPxLabel79" runat="server" Text="附件:"></dx:ASPxLabel>
                                                <asp:DropDownList ID="DDL42" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                                        </tr>
                             <tr>
                                            <td colspan="4">
                                                三、連線傳輸設施設置完工照片&nbsp;
                                                <dx:ASPxLabel ID="ASPxLabel78" runat="server" Text="附件:"></dx:ASPxLabel>
                                                <asp:DropDownList ID="DDL43" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
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
                                    <dx:ASPxButton ID="BT_LINK_CANCEL" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <asp:Label ID="Label_SetLink" runat="server" ForeColor="White"></asp:Label>
                                    <asp:SqlDataSource ID="SDS_SetLink" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        DeleteCommand="DELETE FROM [DOC_SET_LINK] WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion" 
                                        InsertCommand="INSERT INTO [DOC_SET_LINK] ([cNo], [DP_NO], [DocVersion], [DAHS_REDAN_FUNC], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [NetworkIP], [VideoLineType], [VideoIPType], [VideoIP], [NetworkPortNumber], [NetworkPortNumberOther], [VideoLoginID], [MaintainType], [MonitorCenter], [NOTE1], [NOTE2], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@cNo, @DP_NO, @DocVersion, @DAHS_REDAN_FUNC, @CemsPCCpu, @CemsPCMem, @CemsPCHDD, @CemsPCOS, @CemsPCNetcard, @CemsPCAntiVirus, @CemsPCFirewall, @NetworkLineType, @NetworkIPType, @NetworkIP, @VideoLineType, @VideoIPType, @VideoIP, @NetworkPortNumber, @NetworkPortNumberOther, @VideoLoginID, @MaintainType, @MonitorCenter, @NOTE1, @NOTE2, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                                        SelectCommand="SELECT * FROM [DOC_SET_LINK]" 
                                        UpdateCommand="UPDATE [DOC_SET_LINK] SET [DP_NO] = @DP_NO, [DAHS_REDAN_FUNC] = @DAHS_REDAN_FUNC, [CemsPCCpu] = @CemsPCCpu, [CemsPCMem] = @CemsPCMem, [CemsPCHDD] = @CemsPCHDD, [CemsPCOS] = @CemsPCOS, [CemsPCNetcard] = @CemsPCNetcard, [CemsPCAntiVirus] = @CemsPCAntiVirus, [CemsPCFirewall] = @CemsPCFirewall, [NetworkLineType] = @NetworkLineType, [NetworkIPType] = @NetworkIPType, [NetworkIP] = @NetworkIP, [VideoLineType] = @VideoLineType, [VideoIPType] = @VideoIPType, [VideoIP] = @VideoIP, [NetworkPortNumber] = @NetworkPortNumber, [NetworkPortNumberOther] = @NetworkPortNumberOther, [VideoLoginID] = @VideoLoginID, [MaintainType] = @MaintainType, [MonitorCenter] = @MonitorCenter, [NOTE1] = @NOTE1, [NOTE2] = @NOTE2, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion">
                                        <DeleteParameters>
                                            <asp:Parameter Name="cNo" Type="String" />
                                            <asp:Parameter Name="DocVersion" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="cNo" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DocVersion" Type="Int32" />
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
                                            <asp:Parameter Name="NetworkIP" Type="String" />
                                            <asp:Parameter Name="VideoLineType" Type="String" />
                                            <asp:Parameter Name="VideoIPType" Type="String" />
                                            <asp:Parameter Name="VideoIP" Type="String" />
                                            <asp:Parameter Name="NetworkPortNumber" Type="String" />
                                            <asp:Parameter Name="NetworkPortNumberOther" Type="String" />
                                            <asp:Parameter Name="VideoLoginID" Type="String" />
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
                                            <asp:Parameter Name="NetworkIP" Type="String" />
                                            <asp:Parameter Name="VideoLineType" Type="String" />
                                            <asp:Parameter Name="VideoIPType" Type="String" />
                                            <asp:Parameter Name="VideoIP" Type="String" />
                                            <asp:Parameter Name="NetworkPortNumber" Type="String" />
                                            <asp:Parameter Name="NetworkPortNumberOther" Type="String" />
                                            <asp:Parameter Name="VideoLoginID" Type="String" />
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
            <dx:TabPage Text="伍、顯示看板資料">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        
                        <table  style="width:100%;" border="1">
                                        <tr>
                                            <td class="auto-style11" rowspan="14">一、自動顯示看板規格</td>
                                            <td width="400" >(一)於正門外牆明顯處設置放流水水量、水質自動顯示看板</td> 
                                            <td colspan ="2"><asp:RadioButtonList ID="RBL_LED_INSTALL" runat="server" RepeatDirection="Horizontal" Width="70px">
                                            <asp:ListItem>是</asp:ListItem>
                                            <asp:ListItem>否</asp:ListItem>
                                        </asp:RadioButtonList>
                                                &nbsp;</td>                                            
                                        </tr>                                       
                                    
                                <tr>
                                    <td >(二)看板顯示之放流口監測位置編號</td> 
                                    <td colspan="2">
                                        <dx:ASPxTextBox ID="TB_LED_DP_NO" runat="server"  Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            <tr>
                                    <td >(三)實際安裝日期</td> 
                                    <td colspan="2">
                                        <dx:ASPxTextBox ID="TB_LED_PLAN_DATE" runat="server"  Width="170px">
                                        </dx:ASPxTextBox>
                                        <dx:ASPxLabel ID="ASPxLabel146" runat="server" Text="(必填)YYYY/MM/DD" >
                                    </dx:ASPxLabel>
                                    </td>
                                </tr>
                            <tr>
                                    <td >(四)設備製造商<td colspan="2">
                                        <dx:ASPxTextBox ID="TB_LED_FACTORY" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                        </td>
                                    </td>
                                </tr>
                            <tr>
                                    <td >(五)型號(無則免填)</td> 
                                    <td colspan="2">
                                        <dx:ASPxTextBox ID="TB_LED_MODEL" runat="server"  Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            <tr>
                                    <td >(六)序號(無則免填)</td> 
                                    <td colspan="2">
                                        <dx:ASPxTextBox ID="TB_LED_SERIAL" runat="server" Width="170px">
                                        </dx:ASPxTextBox>
                                    </td>
                                    </td>
                                </tr>
                            <tr>
                                    <td >(七)自動顯示看板類型(戶外型專用)</td> 
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RBL_LED_TYPE" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>TV</asp:ListItem>
                                            <asp:ListItem>LED</asp:ListItem>
                                            <asp:ListItem>其他</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            <tr>
                                    <td class="auto-style32" >(八)看板設置高度適中，且安裝穩固安全，不輕易移動</td> 
                                    <td colspan="2" class="auto-style32">
                                        <asp:RadioButtonList ID="RBL_LED_INSTALLPOS" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>是</asp:ListItem>
                                            <asp:ListItem>否</asp:ListItem>                                            
                                        </asp:RadioButtonList>
                                        <dx:ASPxTextBox ID="TB_LED_TYPE_OTHER" runat="server" Caption="選擇其他選項時填寫" Width="120px" style="margin:0px;display: inline">
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            <tr>
                                    <td >(九)看板應同時顯示所有應監測項目之監測紀錄值（不得以跑馬燈型式顯示）</td> 
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RBL_LED_SHOWITEM" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>是</asp:ListItem>
                                            <asp:ListItem>否</asp:ListItem>                                            
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            <tr>
                                    <td >(十)看板顯示字體大小適中，內容清晰可見，並未擅加其他圖案</td> 
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RBL_LED_FORMAT" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>是</asp:ListItem>
                                            <asp:ListItem>否</asp:ListItem>                                            
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            <tr>
                                    <td >(十一)自動顯示看板更新頻率為每5分鐘1次</td> 
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RBL_LED_FREQ" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>是</asp:ListItem>
                                            <asp:ListItem>否</asp:ListItem>                                            
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                                              
                                        <tr>
                                            <td class="auto-style10" rowspan="2">(十二)故障或校正維護期間監測數據公布方式之替代方式：</td>
                                            <td class="auto-style27">可將該期間之水量、水質自動監測資料，公布於公司網頁</td>
                                            <td>
                                                <dx:ASPxLabel ID="ASPxLabel84" runat="server" Text="附件:"></dx:ASPxLabel>
                                                <asp:DropDownList ID="DDL5112A" runat="server" AppendDataBoundItems="True" CssClass="auto-style25" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber">
                                                    <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style27">其他替代方式</td>
                                            <td><dx:ASPxLabel ID="ASPxLabel94" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL5112B" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                                <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                            <tr>
                                    <td >(十三)顯示內容應至少包括管制編號、事業名稱、日期、時間、放流水水量及水質監測資料、公害陳情專線</td> 
                                    <td colspan="2">
                                        <asp:RadioButtonList ID="RBL_LED_Content" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem>是</asp:ListItem>
                                            <asp:ListItem>否</asp:ListItem>                                            
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                        <tr>
                                            <td colspan="4" class="auto-style26">
                                                二、實際放流水水量、水質自動顯示看板設置位置圖（與廠區相對位置）
                                                <dx:ASPxLabel ID="ASPxLabel96" runat="server" Text="附件:"></dx:ASPxLabel>
                                                <asp:DropDownList ID="DDL52" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                                        </tr>
                            <tr>
                                            <td colspan="4">
                                                三、放流水水量、水質自動顯示看板設置完工照片
                                                <dx:ASPxLabel ID="ASPxLabel103" runat="server" Text="附件:"></dx:ASPxLabel>
                                                <asp:DropDownList ID="DDL53" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                            </td>
                                        </tr>

                                    </table>
                        <p>
                        </p>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style13">
                                    <dx:ASPxButton ID="BT_LED_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td class="auto-style11">
                                    <dx:ASPxButton ID="BT_LED_CANCEL" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <asp:Label ID="Label_LED" runat="server" ForeColor="White"></asp:Label>
                                    
                                </td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="陸、自主監測設施資料">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <br />
                        <dx:ASPxLabel ID="ASPxLabel91" runat="server">
                        </dx:ASPxLabel>
                        <dx:ASPxLabel ID="ASPxLabel92" runat="server" Text ="設置、汰換或變更自主監測設施位置及種類">
                        </dx:ASPxLabel>
                        <dx:ASPxGridView ID="GV_ITEM_SELF" runat="server" AutoGenerateColumns="False" Caption="設置、汰換或變更自主監測設施位置及種類(可複選，列次不足者請自行增列填寫)" DataSourceID="SDS_ITEM_SELF" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION;DOCTYPE" Width="800px">

<EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" Caption ="" >
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="管制編號" FieldName="CNO"  ShowInCustomizationForm="True" VisibleIndex="2" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Caption="位置編號" FieldName="DP_NO" ShowInCustomizationForm="True" VisibleIndex="3"  >
                                     <PropertiesTextEdit MaxLength="6">
                                     </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="版號" FieldName="DOCVERSION" ShowInCustomizationForm="True" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="文件種類" FieldName="DOCTYPE" ShowInCustomizationForm="True" VisibleIndex="4" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn Caption="硝酸鹽氮" FieldName="ITEM_241" ShowInCustomizationForm="True" VisibleIndex="8">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataCheckColumn Caption="硼" FieldName="ITEM_267" ShowInCustomizationForm="True" VisibleIndex="9">
                                    <PropertiesCheckEdit AllowGrayedByClick="False" ValueGrayed="False">
                                    </PropertiesCheckEdit>
                                </dx:GridViewDataCheckColumn>                               
                                <dx:GridViewDataComboBoxColumn Caption="位置種類" FieldName="DPTYPE" ShowInCustomizationForm="True" VisibleIndex="5">
                                    <PropertiesComboBox>
                                        <Items>
                                            <dx:ListEditItem Text="進流口" Value="進流口" />
                                            <dx:ListEditItem Text="放流口" Value="放流口" />
                                            <dx:ListEditItem Text="處理單元(進流口)" Value="處理單元(進流口)" />
                                            <dx:ListEditItem Text="處理單元(出流口)" Value="處理單元(出流口)" />
                                            <dx:ListEditItem Text="雨水放流口" Value="雨水放流口" />
                                            <dx:ListEditItem Text="用水來源-自來水" Value="用水來源-自來水" />
                                            <dx:ListEditItem Text="用水來源-地下水" Value="用水來源-地下水" />
                                            <dx:ListEditItem Text="用水來源-河湖海水" Value="用水來源-河湖海水" />
                                            <dx:ListEditItem Text="用水來源-回收水" Value="用水來源-回收水" />
                                            <dx:ListEditItem Text="用水貯存區進入製程前" Value="用水貯存區進入製程前" />
                                            <dx:ListEditItem Text="電子式電度表" Value="電子式電度表" />
                                        </Items>
                                    </PropertiesComboBox>
                                </dx:GridViewDataComboBoxColumn>
                                <dx:GridViewDataTextColumn Caption="許可證水流編號" FieldName ="PERMIT_SERIAL" ShowInCustomizationForm="True" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Caption="涵蓋之廢（污）水（前）處理設施編號(電子式電度表適用)" FieldName ="EM_COVER" ShowInCustomizationForm="True" VisibleIndex="7">
                                </dx:GridViewDataTextColumn>
                            </Columns>                        
<SettingsAdaptivity>
<AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
</SettingsAdaptivity>

                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="選定資料" Width="80px"></dx:ASPxButton>
                        <asp:SqlDataSource ID="SDS_ITEM_SELF" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                            DeleteCommand="DELETE FROM [DOC_VRY_ITEM] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" 
                            InsertCommand="INSERT INTO [DOC_VRY_ITEM] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [DOCTYPE], [PERMIT_SERIAL], [EM_COVER], [ITEM_241], [ITEM_267],  [ITEM_WATER], [ITEM_GROUND], [ITEM_RIVER], [ITEM_RECYCLE], [OTHER_DESP], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @DOCTYPE, @PERMIT_SERIAL, @EM_COVER, @ITEM_241, @ITEM_267, @ITEM_WATER, @ITEM_GROUND, @ITEM_RIVER, @ITEM_RECYCLE, @OTHER_DESP, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                            SelectCommand="SELECT * FROM [DOC_VRY_ITEM] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION) AND (ITEM_241 is not null))" 
                            UpdateCommand="UPDATE [DOC_VRY_ITEM] SET [PERMIT_SERIAL] = @PERMIT_SERIAL, [EM_COVER] = @EM_COVER, [ITEM_241] = @ITEM_241, [ITEM_267] = @ITEM_267,  [ITEM_WATER] = @ITEM_WATER, [ITEM_GROUND] = @ITEM_GROUND, [ITEM_RIVER] = @ITEM_RIVER, [ITEM_RECYCLE] = @ITEM_RECYCLE, [OTHER_DESP] = @OTHER_DESP, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">
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
                                <asp:Parameter Name="PERMIT_SERIAL" Type="String" />
                                <asp:Parameter Name="EM_COVER" Type="String" />
                                <asp:Parameter Name="ITEM_241" Type="String" />
                                <asp:Parameter Name="ITEM_267" Type="String" /> 
                                <asp:Parameter Name="ITEM_WATER" Type="String" />
                                <asp:Parameter Name="ITEM_GROUND" Type="String" />
                                <asp:Parameter Name="ITEM_RIVER" Type="String" />
                                <asp:Parameter Name="ITEM_RECYCLE" Type="String" />
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
                                <asp:Parameter Name="PERMIT_SERIAL" Type="String" />
                                <asp:Parameter Name="EM_COVER" Type="String" />
                                <asp:Parameter Name="ITEM_241" Type="String" />
                                <asp:Parameter Name="ITEM_267" Type="String" />
                                <asp:Parameter Name="ITEM_WATER" Type="String" />
                                <asp:Parameter Name="ITEM_GROUND" Type="String" />
                                <asp:Parameter Name="ITEM_RIVER" Type="String" />
                                <asp:Parameter Name="ITEM_RECYCLE" Type="String" />
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
                        <dx:ASPxGridView ID="GV_SPEC_SELF" runat="server" Caption="自主監測設施資料總表" Width="600px" AutoGenerateColumns="False" DataSourceID="SDS_SPEC_SELF" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION;ITEM">

<EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0" Caption="">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="DPTYPE" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Caption="種類"  >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="7" Visible ="false"  >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ITEM" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Caption="監測項目編號">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DP_NO" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="6" Visible ="false" >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CNO" ShowInCustomizationForm="True" VisibleIndex="5" ReadOnly="True" Visible ="false"  >
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="DPNO_DESP" ShowInCustomizationForm="True" VisibleIndex="4" Caption="位置">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="監測項目說明" FieldName="DESP" ShowInCustomizationForm="True" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                            </Columns>
<SettingsAdaptivity>
<AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
</SettingsAdaptivity>

                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" />
                        </dx:ASPxGridView>
                        <asp:SqlDataSource ID="SDS_SPEC_SELF" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                            SelectCommand="SELECT DOC_VRY_SPEC.DPTYPE, DOC_VRY_SPEC.DOCVERSION, DOC_VRY_SPEC.ITEM, DOC_VRY_SPEC.DP_NO, DOC_VRY_SPEC.CNO, DOC_VRY_SPEC.DPNO_DESP, CODE1.DESP FROM DOC_VRY_SPEC INNER JOIN CODE1 ON DOC_VRY_SPEC.ITEM = CODE1.ITEM WHERE DOC_VRY_SPEC.CNO=@CNO AND DOC_VRY_SPEC.DP_NO=@DP_NO AND DOC_VRY_SPEC.DOCVERSION=@DOCVERSION AND DOC_VRY_SPEC.ITEM IN('241','267')">
                            <SelectParameters>
                                <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                <asp:SessionParameter Name="DP_NO" SessionField="DP_NO" Type="String" />
                                <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="取得資料" Width="80px">
                        </dx:ASPxButton>
                        <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="800px">
                            <panelcollection>
                                <dx:PanelContent runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td class="auto-style9">
                                                <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Caption="監測位置編號" Width="170px">
                                                </dx:ASPxTextBox>
                                            </td>
                                            <td class="auto-style8">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                    <p>
                                    </p>
                                    <table style="width:100%;">
                                        <tr>
                                            <td>
                                                <dx:ASPxRadioButtonList ID="ASPxRadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="400px">
                                                    <Items>
                                                        <dx:ListEditItem Text="硝酸鹽氮" Value="241" />
                                                        <dx:ListEditItem Text="硼" Value="267" />
                                                    </Items>
                                                </dx:ASPxRadioButtonList>
                                            </td>
                                            <td>
                                                <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="170px">
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
                                    <dx:ASPxLabel ID="ASPxLabel93" runat="server" Text="(一)本監測設施是否為報經主管機關核准採行之替代措施">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style2" colspan="6" width="500">                                                    
                                     <asp:RadioButton ID="RadioButton1" runat="server" GroupName="SPEC_INSTEAD" Text="是(核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本見附件" />&nbsp;<asp:RadioButton ID="RadioButton2" runat="server" Text="否" GroupName="SPEC_INSTEAD" />
                                     &nbsp;
                                    <dx:ASPxLabel ID="ASPxLabel108" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL61" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel95" runat="server" Text="(二)本監測設施是否同時監測其他位置">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style2" colspan="6" width="400" >
                                    <asp:RadioButton ID="RadioButton3" runat="server" Text="是,與位置編號:" GroupName="MONITOROTHER" />                                    
                                    <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" MaxLength="10" Width="150px" style="margin:0px;display: inline">
                                    </dx:ASPxTextBox>
                                    共設
                                    <dx:ASPxTextBox ID="ASPxTextBox4" runat="server" MaxLength="10" Width="40px" style="margin:0px;display: inline">
                                    </dx:ASPxTextBox>處                                 
                                    <asp:RadioButton ID="RadioButton4" runat="server" Text="否" style="margin:0px;display: inline" GroupName="MONITOROTHER" />
                                    <br />
                                    <dx:ASPxLabel ID="ASPxLabel118" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL62" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>         
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel97" runat="server" Text="(三)安裝日期">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxDateEdit ID="ASPxDateEdit13" runat="server" MinDate="1970-01-01">
                                    </dx:ASPxDateEdit>(必填)YYYY-MM-DD
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel98" runat="server" Text="(四)監測設施之製造商或代理商">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="ASPxTextBox5" runat="server" Width="250px" MaxLength ="50">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel99" runat="server" Text="(五)型號" >
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="ASPxTextBox6" runat="server" Width="250px" MaxLength="250">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel100" runat="server" Text="(六)序號">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="ASPxTextBox7" runat="server" Width="250px" MaxLength="250">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3" >
                                    <dx:ASPxLabel ID="ASPxLabel101" runat="server" Text="(七)量測方式(分析方法)">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="ASPxTextBox8" runat="server" Width="250px" MaxLength="25" Caption ="NIEA">
                                    </dx:ASPxTextBox>
                                    <dx:ASPxTextBox ID="ASPxTextBox9" runat="server" Width="250px" MaxLength="25" Caption ="( ">
                                    </dx:ASPxTextBox>                               
                                    <dx:ASPxLabel ID="ASPxLabel102" runat="server" Text="核准採行替代量測方式具體說明及報經主管機關核准採行之核准公文影本見附件"></dx:ASPxLabel>
                                    <asp:RadioButton ID="RadioButton5" runat="server" Text="有過濾器/前處理裝置，影響說明" GroupName="SPEC_SampleMethod" />&nbsp;<asp:RadioButton ID="RadioButton6" runat="server" GroupName="SPEC_SampleMethod" Text="無過濾器/前處理裝置" />
                                    <dx:ASPxLabel ID="ASPxLabel119" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL67" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>    
                                
                            </tr>                            
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel104" runat="server" Text="(八)校正器材">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="ASPxTextBox10" runat="server" Width="250px" MaxLength="50">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel105" runat="server" Text="(九)校正周期">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="ASPxTextBox11" runat="server" Width="250px" MaxLength="20">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>擬自行校正</asp:ListItem>
                                        <asp:ListItem>擬委外校正</asp:ListItem>
                                        <asp:ListItem>不適用</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel106" runat="server" Text="(十)維護周期">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="ASPxTextBox12" runat="server" Width="250px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>擬自行保養</asp:ListItem>
                                        <asp:ListItem>擬委外保養</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel107" runat="server" Text="(十一)耗材內容">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" rowspan="2">
                                    <dx:ASPxTextBox ID="ASPxTextBox13" runat="server" Width="250px" MaxLength="100">
                                    </dx:ASPxTextBox>
                                </td>
                                <td colspan="3">
                                    <asp:RadioButtonList ID="RadioButtonList3" runat="server">
                                        <asp:ListItem>無產生廢液(材)</asp:ListItem>
                                        <asp:ListItem>有產生廢液(材),儲存清理方式說明(詳附件)</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <dx:ASPxLabel ID="ASPxLabel120" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL611" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>                                
                            </tr>
                            <tr>
                                <td colspan="3">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel109" runat="server" Text="(十二)耗材應更換頻率">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="ASPxTextBox14" runat="server" Width="170px" MaxLength="10">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td >
                                    <dx:ASPxLabel ID="ASPxLabel110" runat="server" Text="(十三)量測範圍">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" >
                                    <dx:ASPxTextBox ID="ASPxTextBox15" runat="server" Width="300px" MaxLength="50">
                                    </dx:ASPxTextBox>
                                </td>
                                <td width="40">
                                    <dx:ASPxLabel ID="ASPxLabel111" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" >                                    
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem>mg/L</asp:ListItem>
                                        <asp:ListItem>---</asp:ListItem>
                                        <asp:ListItem>umho/cm</asp:ListItem>
                                        <asp:ListItem>m3</asp:ListItem>
                                        <asp:ListItem>℃</asp:ListItem>
                                        <asp:ListItem>m/分鐘</asp:ListItem>
                                        <asp:ListItem>度</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" SelectCommand="SELECT [UnitName] FROM [DOC_UNIT]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style23">
                                    <dx:ASPxLabel ID="ASPxLabel112" runat="server" Text="(十四)應答時間(儀器每次取樣至完成分析所需之時間)">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" class="auto-style23">
                                    <dx:ASPxTextBox ID="ASPxTextBox16" runat="server" Width="170px" MaxLength="5">
                                    </dx:ASPxTextBox>
                                </td>
                                <td width="40" class="auto-style23">
                                    <dx:ASPxLabel ID="ASPxLabel113" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2" class="auto-style23">                                    
                                    <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SDS_UNIT" DataTextField="UnitName" DataValueField="UnitName">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel114" runat="server" Text="(十五)量測周期(每次監測數據產生之時間間隔)">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="ASPxTextBox17" runat="server" Width="170px" MaxLength="5">
                                    </dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel115" runat="server" Text="單位:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">                                    
                                    <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SDS_UNIT" DataTextField="UnitName" DataValueField="UnitName">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel116" runat="server" Text="(十六)監測紀錄值為幾個等時距監測數據之算術平均值">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="ASPxTextBox18" runat="server" Width="170px" MaxLength="5">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4" rowspan="4">
                                    <dx:ASPxLabel ID="ASPxLabel117" runat="server" Text="(十七)補充說明及相關證明文件影本">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="5">
                                   <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" CheckState="Unchecked" Text="設施製造商校正方式及周期說明(詳附件)" AutoPostBack="True">
                                    </dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel121" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL617A" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">                                    
                                     <dx:ASPxCheckBox ID="ASPxCheckBox2" runat="server" CheckState="Unchecked" Text="維修保養合約書或計畫書(如附件)" AutoPostBack="True" ></dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel126" runat="server" Text="附件:"></dx:ASPxLabel>
                                     <asp:DropDownList ID="DDL617B" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">                                    
                                     <dx:ASPxCheckBox ID="ASPxCheckBox3" runat="server" CheckState="Unchecked" Text="水質自動監測設施相對誤差測試報告(如附件)" AutoPostBack="True" ></dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel127" runat="server" Text="附件:"></dx:ASPxLabel>
                                     <asp:DropDownList ID="DDL617C" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">                                    
                                     <dx:ASPxCheckBox ID="ASPxCheckBox4" runat="server" CheckState="Unchecked" Text="電子式電度表規格符合國家標準說明(如附件)" AutoPostBack="True" ></dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel128" runat="server" Text="附件:"></dx:ASPxLabel>
                                     <asp:DropDownList ID="DDL617D" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style4" rowspan="3">
                                    <dx:ASPxLabel ID="ASPxLabel122" runat="server" Text="(十八)攝錄影設施規格">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel123" runat="server" Text="影像格式:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">

                                    <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="170px">
                                        <asp:ListItem>MPEG</asp:ListItem>
                                        <asp:ListItem>H.264</asp:ListItem>
                                        <asp:ListItem>AVI</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                        <asp:ListItem Selected="True">不適用</asp:ListItem>                                        
                                    </asp:RadioButtonList>

                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="ASPxTextBox19" runat="server" Width="170px" Caption ="其他說明">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel124" runat="server" Text="解析度:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="RadioButtonList5" runat="server">
                                        <asp:ListItem>640X480</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                        <asp:ListItem Selected="True">不適用</asp:ListItem>                                        
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="ASPxTextBox20" runat="server" Caption="其他說明" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel125" runat="server" Text="夜視功能:">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <asp:RadioButtonList ID="RadioButtonList6" runat="server">
                                        <asp:ListItem>有</asp:ListItem>
                                        <asp:ListItem>無</asp:ListItem>
                                        <asp:ListItem Selected="True">不適用</asp:ListItem>                                        
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <dx:ASPxTextBox ID="ASPxTextBox21" runat="server" Caption="其他說明" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td></td>
                            </tr>
                             <tr>
                                <td rowspan="5">(十九)輸出訊號格式</td>
                                <td>
                                    <asp:RadioButton ID="RadioButton7" runat="server"  Text="類比訊號" GroupName ="Signal" AutoPostBack="True" ></asp:RadioButton>
                                </td>
                                <td colspan="5">
                                    <asp:DropDownList ID="DropDownList4" runat="server" Width="120px" DataSourceID="SDS_SIGNAL" DataTextField="SINGALNAME" DataValueField="SINGALNAME">                                    
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" SelectCommand="SELECT [SINGALNAME] FROM [DOC_SINGAL] WHERE ([SINGALID] = @SINGALID)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="ANALOG" Name="SINGALID" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                
                                <td >
                                    <asp:RadioButton ID="RadioButton8" runat="server"  Text="數位訊號" GroupName ="Signal" AutoPostBack="True" ></asp:RadioButton>
                                </td>
                                <td colspan="5">
                                    <dx:ASPxTextBox ID="ASPxTextBox22" runat="server" Width="170px"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxCheckBox ID="ASPxCheckBox5" runat="server" AutoPostBack="True" CheckState="Unchecked" Text="該數位介面之硬體連接方法說明">
                                    </dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel130" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL619A" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxCheckBox ID="ASPxCheckBox6" runat="server" AutoPostBack="True" CheckState="Unchecked" Text="該數位設備之連接參數資料">
                                    </dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel135" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL619B" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <dx:ASPxCheckBox ID="ASPxCheckBox7" runat="server" AutoPostBack="True" CheckState="Unchecked" Text="引用此介面之相關功能文件">
                                    </dx:ASPxCheckBox>
                                    <dx:ASPxLabel ID="ASPxLabel136" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL619C" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                             <tr>
                                <td class="auto-style4" >
                                    <dx:ASPxLabel ID="ASPxLabel129" runat="server" Text="備註">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">
                                   <dx:ASPxMemo ID="ASPxMemo1" runat="server" Caption="備註說明文字" Font-Size="Medium" Height="100px" Width="800px">
                                            <CaptionSettings HorizontalAlign="Center" Position="Top" />
                                        </dx:ASPxMemo>
                                </td>
                                 <td colspan="3"> 
                                     <dx:ASPxLabel ID="ASPxLabel137" runat="server" Text="附件:"></dx:ASPxLabel>
                                     <asp:DropDownList ID="DDL620" runat="server" AppendDataBoundItems="True" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber">
                                         <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                     </asp:DropDownList>
                                 </td>
                            </tr>
                           <tr>
                                <td class="auto-style4" rowspan="3">
                                    <dx:ASPxLabel ID="ASPxLabel131" runat="server" Text="四、數據採擷及處理系統(DAHS)規格">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel132" runat="server" Text="(一)I/O模組或PLC廠牌">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">

                                    <dx:ASPxTextBox ID="ASPxTextBox23" runat="server" Width="170px">
                                    </dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel133" runat="server" Text="(二)使用之通訊規格" Width="200px">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">

                                    <asp:RadioButtonList ID="RadioButtonList7" runat="server" Width="180px">
                                        <asp:ListItem Selected="True">Modbus TCP</asp:ListItem>
                                        <asp:ListItem>Modbus RTU</asp:ListItem>
                                        <asp:ListItem>RS-232</asp:ListItem>
                                        <asp:ListItem>RS-485</asp:ListItem>
                                        <asp:ListItem>USB</asp:ListItem>
                                        <asp:ListItem>LPT</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <dx:ASPxTextBox ID="ASPxTextBox24" runat="server" Width="170px" Caption="其他說明">
                                    </dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel134" runat="server" Text="(三)監測數據、訊號是否可經由人工異動">
                                    </dx:ASPxLabel>
                                </td>
                                <td colspan="3">

                                    <asp:RadioButtonList ID="RadioButtonList8" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">否</asp:ListItem>
                                        <asp:ListItem>可</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <dx:ASPxTextBox ID="ASPxTextBox25" runat="server" Width="170px" Caption ="原因">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>                        
                            <tr>
                                <td>五、各項自動監測(視)設施設置位置圖(與廢水處理設施相對位置)</td>
                                <td colspan="2"><dx:ASPxLabel ID="ASPxLabel142" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL65" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>六、各項自動監測(視)設施設置位置圖(與廠區相對位置)</td>
                                <td colspan="2"><dx:ASPxLabel ID="ASPxLabel143" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL66" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>七、各項自動監測(視)設施及電子式電度表設置完工圖</td>
                                <td colspan="2"><dx:ASPxLabel ID="ASPxLabel144" runat="server" Text="附件:"></dx:ASPxLabel><asp:DropDownList ID="DDL627" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                        </table>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style14">
                                    <dx:ASPxButton ID="ASPxButton3" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton4" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel138" runat="server">
                                    </dx:ASPxLabel>
                                    <asp:SqlDataSource ID="SqlDataSource10" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
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
                       

                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="柒、檔案上傳">
                <contentcollection>
                    <dx:ContentControl runat="server">
                        
                        <br />
                        <dx:ASPxLabel ID="ASPxLabel139" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text ="附件">
                        </dx:ASPxLabel>
                        <dx:ASPxGridView ID="GV_PDF" runat="server" AutoGenerateColumns="False" Caption="附件" DataSourceID="SDS_PDF" KeyFieldName="CNO;DocNumber;DocVersion" Width="800px">

<EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" VisibleIndex="0" SelectAllCheckboxMode="Page" ShowSelectCheckbox="True" Caption ="" >
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn Caption="附件編號" FieldName="DocNumber"  ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                 <dx:GridViewDataTextColumn Caption="上傳附件名稱" FieldName="FileDescription" ShowInCustomizationForm="True" VisibleIndex="3"  >
                                     <PropertiesTextEdit MaxLength="12">
                                     </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="版號" FieldName="DocVersion" ShowInCustomizationForm="True" VisibleIndex="1" ReadOnly="True">
                                </dx:GridViewDataTextColumn>
                            </Columns>                        
<SettingsAdaptivity>
<AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
</SettingsAdaptivity>

                            <SettingsBehavior AllowSelectByRowClick="True" AllowSelectSingleRowOnly="True" ProcessSelectionChangedOnServer="True" ConfirmDelete="True" />
                            <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandUpdate="更新" CommandNew="新增" ConfirmDelete="您確定要刪除本附件嗎" />
                        </dx:ASPxGridView>                                                              
                        <asp:SqlDataSource ID="SDS_PDF" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                            DeleteCommand="DELETE FROM [DOC_PDF_BASIC] WHERE [CNO] = @CNO AND [DocNumber] = @DocNumber AND [FileName] = @FileName AND [DOCVERSION] = @DOCVERSION" 
                            InsertCommand="INSERT INTO [DOC_PDF_BASIC] ([CNO], [DocNumber], [FileName], [DOCVERSION]) VALUES (@CNO, @DocNumber, @FileName, @DOCVERSION)" 
                            SelectCommand="SELECT * FROM [DOC_PDF_BASIC] WHERE (([CNO] = @CNO) AND ([DOCVERSION] = @DOCVERSION))" 
                            UpdateCommand="UPDATE [DOC_PDF_BASIC] SET [FileDescription] = @FileDescription WHERE [CNO] = @CNO AND [DocNumber] = @DocNumber AND [DOCVERSION] = @DOCVERSION">
                            <DeleteParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DocNumber" Type="String" />
                                <asp:Parameter Name="FileName" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="CNO" Type="String" />
                                <asp:Parameter Name="DocNumber" Type="String" />
                                <asp:Parameter Name="FileName" Type="String" />
                                <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                <asp:Parameter Name="FileDescription" Type="String" />
                                <asp:Parameter Name="pdffile" Type="String" />
                                <asp:Parameter Name="CreatorID" Type="String" />
                                <asp:Parameter Name="CreateDate" Type="DateTime" />
                                <asp:Parameter Name="ModifyID" Type="String" />
                                <asp:Parameter Name="ModifyDate" Type="DateTime" />
                            </InsertParameters>
                            <SelectParameters>
                                <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="Int32" />
                            </SelectParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="FileDescription" Type="String" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <dx:ASPxPanel ID="ASPxPanel4" runat="server" Width="800px">
                            <panelcollection>
                                <dx:PanelContent runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                             <td>                                                
                                                 <dx:ASPxTextBox ID="TB_DocNumber" runat="server" Caption="請填入附件編號" Font-Names="微軟正黑體" Font-Size="Medium" Width="170px">
                                                 </dx:ASPxTextBox>
                                                 <br />
                                                 <dx:ASPxTextBox ID="TB_FileName" runat="server" Caption="請填入附件名稱" Font-Names="微軟正黑體" Font-Size="Medium" Width="170px">
                                                 </dx:ASPxTextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </panelcollection>
                        </dx:ASPxPanel>
                        <br />
                        <table style="width:100%;" border="1">                            
                            <tr>
                                <td><dx:ASPxLabel ID="ASPxLabel140" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="檔案上傳">
                                    </dx:ASPxLabel></td>
                            </tr>
                            <tr>
                                <td class="auto-style2" width="250">
                                    <dx:ASPxUploadControl ID="AUC_1" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" FileUploadMode="OnPageLoad" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px">
                                        <ValidationSettings AllowedFileExtensions=".PDF" GeneralErrorText="檔案上傳錯誤" MaxFileSize="10000000" MaxFileSizeErrorText="檔案請壓縮在10MB以下，超過將無法上傳" NotAllowedFileExtensionErrorText="只接受PDF型式的檔案">
                                        </ValidationSettings>
                                        <BrowseButton Text="選擇">
                                        </BrowseButton>
                                        <UploadButton Text="上傳">
                                            <Image IconID="arrows_moveup_32x32">
                                            </Image>
                                        </UploadButton>
                                        <CancelButton Text="取消">
                                        </CancelButton>
                                        <AdvancedModeSettings EnableFileList="True" EnableMultiSelect="True">
                                        </AdvancedModeSettings>
                                    </dx:ASPxUploadControl>
                                    <asp:Button ID="BT_AUC1" runat="server" Text="查看上傳檔案" />
                                    <asp:Button ID="BT_DEL_AUC1" runat="server" Text="刪除上傳檔案" />
                                    <dx:ASPxLabel ID="ASPxLabel141" runat="server" Text="檔案上傳僅限PDF格式且大小不超過10M，並且取消PDF安全性限制(如列印、合併等限制)，以免造成合併列印錯誤">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                        </table>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style14">
                                    <dx:ASPxButton ID="ASPxButton11" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="ASPxButton12" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>                           
                        </table>
                        
                       
                    </dx:ContentControl>
                </contentcollection>
            </dx:TabPage>
            <dx:TabPage Text="附錄2、RATA">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        
                        <dx:ASPxLabel ID="ASPxLabel88" runat="server" ForeColor="Red" Text ="RATA結果不符合法規之相對準確度標準要求" Visible="False">
                        </dx:ASPxLabel>
                        <table align="center" class="link3" bgcolor="White" width="1000" border="1" style="border: 1px solid #2781BA">
                            <tr align="center">
                                <td align="left">
                                    <dx:ASPxGridView ID="GV_RATA" runat="server" AutoGenerateColumns="False" DataSourceID="SDS_SELRATA" KeyFieldName="CNO;DP_NO;DOCVERSION;ITEM" ClientIDMode="Predictable">

<EditFormLayoutProperties ColCount="1"></EditFormLayoutProperties>
                                        <Columns>
                                            <dx:GridViewCommandColumn SelectAllCheckboxMode="Page" ShowDeleteButton="True" ShowInCustomizationForm="True" ShowSelectCheckbox="True" VisibleIndex="0" Caption ="" >
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn FieldName="DESP" ShowInCustomizationForm="True" VisibleIndex="5" Caption="測試項目說明">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="1" Caption ="管制編號">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DP_NO" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="2" Caption="測試位置">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" ShowInCustomizationForm="True" VisibleIndex="3" Visible="False">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ITEM" ShowInCustomizationForm="True" VisibleIndex="4" Caption="測試項目編號" ReadOnly="True">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="STD" ShowInCustomizationForm="True" VisibleIndex="7" Caption="標準偏差">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="ACCURACY_A" ShowInCustomizationForm="True" VisibleIndex="8" Caption="RATA">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FACTOR_A" ShowInCustomizationForm="True" VisibleIndex="9" Caption="信賴係數">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="AVGDIFF" ShowInCustomizationForm="True" VisibleIndex="10" Caption="平均差值">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="AVG_A" ShowInCustomizationForm="True" VisibleIndex="6" Caption="平均差值">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
<SettingsAdaptivity>
<AdaptiveDetailLayoutProperties ColCount="1"></AdaptiveDetailLayoutProperties>
</SettingsAdaptivity>

                                        <SettingsBehavior AllowSelectByRowClick="True" ProcessSelectionChangedOnServer="True" />
                                        <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" />
                                    </dx:ASPxGridView>
                                    <asp:SqlDataSource ID="SDS_SELRATA" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        SelectCommand="SELECT CODE1.DESP, DOC_RATA.CNO, DOC_RATA.DP_NO, DOC_RATA.DOCVERSION, DOC_RATA.ITEM, DOC_RATA.STD, DOC_RATA.ACCURACY_A, DOC_RATA.AVG_A,DOC_RATA.FACTOR_A, DOC_RATA.AVGDIFF FROM DOC_RATA INNER JOIN CODE1 ON DOC_RATA.ITEM = CODE1.ITEM where doc_rata.cno=@cno" 
                                        DeleteCommand="delete from doc_rata where cno=@cno and dp_no=@dp_no and docversion=@docversion and item=@item">
                                         <DeleteParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="String" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                        </DeleteParameters>
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                            <asp:SessionParameter Name="DOCVERSION" SessionField="DOCVERSION" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <br />
                                </td>
                            </tr>

                        </table>
                        <dx:ASPxButton ID="BT_SELRATA" runat="server" Text="選定資料" Width="80" Visible="False"></dx:ASPxButton>
                        <table align="center" class="link3" bgcolor="White" width="1000" border="1" style="border: 1px solid #2781BA">

                            <tr>
                                <td class="auto-style1">RATA數據組數選擇</td>
                                <td>
                                    <asp:RadioButtonList ID="RBL_RATA_GROUP" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">9組</asp:ListItem>
                                        <asp:ListItem>12組</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">測試位置</td>
                                <td>
                                    <asp:DropDownList ID="DDL_RATADPNO" runat="server" DataSourceID="SDS_DPOINT" DataTextField="DP_NO"
                                        DataValueField="DP_NO" AutoPostBack="True" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True">請選擇監測位置</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SDS_DPOINT" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        SelectCommand="SELECT DISTINCT DP_NO FROM [DOC_VRY_SPEC] WHERE left(DP_NO,1) in ('D','O') and  ([CNO] = @CNO)">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>                            
                            <tr>
                                <td class="auto-style1">監測項目
                                </td>
                                <td>
                                    <asp:DropDownList ID="DDL_RATAITEM" runat="server" AutoPostBack="True">
                                        <asp:ListItem Selected="True">請選擇監測項目</asp:ListItem>
                                        <asp:ListItem Value="210">懸浮固體</asp:ListItem>
                                        <asp:ListItem Value="242">氨氮</asp:ListItem>
                                        <asp:ListItem Value="243">化學需氧量</asp:ListItem>
                                        <asp:ListItem Value="999">其他</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="TB_ITEM_OTHER" runat="server"  TabIndex="1"></asp:TextBox>
                                    &nbsp;
                                </td>
                            </tr>              
                            <tr>
                                <td class="auto-style1">相對誤差測試查核結果</td>
                                <td><dx:ASPxTextBox ID="TB_RATA" runat="server" Width="200px">                                            
                                        </dx:ASPxTextBox>
                                    % </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">平均差值</td>
                                <td><dx:ASPxTextBox ID="TB_AVGDIFF" runat="server" Width="180px">                                            
                                        </dx:ASPxTextBox>
                                    mg/L</td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel1" runat="server">
                            <table align="center" bgcolor="White" border="1" class="link3" style="border: 1px solid #2781BA" width="1000">
                                
                                <tr class="border1">
                                    <td style="background-color: #C0C0C0">測試數據</td>
                                    <td style="background-color: #C0C0C0">日期(YYYY/MM/DD)</td>
                                    <td style="background-color: #C0C0C0">時間(hh:mm)</td>                                    
                                    <td style="background-color: #C0C0C0">標準檢驗方法量測數據 </td>
                                    <td style="background-color: #C0C0C0">監測設施量測數據 </td>
                                    <td style="background-color: #C0C0C0">差值 </td>
                                </tr>
                                <tr>
                                    <td>數據一 </td>
                                    <td>
                                        <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD           
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME1" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD1" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS1" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF1" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據二 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit2" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME2" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD2" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS2" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF2" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據三 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit3" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME3" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD3" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS3" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF3" runat="server" Width="80px">                                           
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據四 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit4" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME4" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD4" runat="server" Width="80px">
                                                                                   </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS4" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF4" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據五 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit5" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME5" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD5" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS5" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF5" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據六 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit6" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME6" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD6" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS6" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF6" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據七 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit7" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME7" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD7" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS7" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF7" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據八 </td>
                                   <td><dx:ASPxDateEdit ID="ASPxDateEdit8" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME8" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD8" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS8" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF8" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據九 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit9" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME9" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD9" runat="server" Width="80px">                                        
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS9" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF9" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據十 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit10" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME10" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD10" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS10" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF10" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據十一 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit11" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME11" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD11" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS11" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF11" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>數據十二 </td>
                                    <td><dx:ASPxDateEdit ID="ASPxDateEdit12" runat="server" Width="120px" MinDate="1970-01-01">
                                        </dx:ASPxDateEdit>YYYY-MM-DD
                                    </td>
                                    <td><dx:ASPxTextBox ID="TB_STIME12" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox></td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STD12" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMS12" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFF12" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>平均值(mg/L)</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_STDAVG" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_CEMSAVG" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                    <td>
                                        <dx:ASPxTextBox ID="TB_DIFFAVG" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <table align="center" bgcolor="White" border="1" class="link3" style="border: 1px solid #2781BA" width="1000">
                            <tr>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>                            
                            <tr>
                                <td>標準偏差 </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_STD" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>信賴係數 </td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_TRUST" runat="server" Width="80px">                                            
                                        </dx:ASPxTextBox>
                                </td>
                            </tr>                            
                            <tr>
                                <td>實驗室名稱</td>
                                <td>
                                    <asp:DropDownList ID="DDL_FabName" runat="server" DataSourceID="SDS_FabName" DataTextField="AgentName" DataValueField="AgentName" Width="400px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SDS_FabName" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" SelectCommand="SELECT [AgentName], [ExamUnit] FROM [ExamUnit]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>實驗室採用檢測方法</td>
                                <td>
                                    <asp:DropDownList ID="DDL_FabMethod" runat="server" DataSourceID="SqlDataSource3" DataTextField="SampleName" DataValueField="SampleID" Width="400px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>"
                                        SelectCommand="SELECT [SampleID], [SampleName] FROM [SampleMethod]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td>自動監測設施廠牌名稱</td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_CWMSAGENT" runat="server" Width="600px">                                            
                                        </dx:ASPxTextBox></td>
                            </tr>
                            <tr>
                                <td>自動監測設施型號</td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_CWMSMODEL" runat="server" Width="600px">                                            
                                        </dx:ASPxTextBox></td>
                            </tr>
                            <tr>
                                <td>自動監測設施序號</td>
                                <td>
                                    <dx:ASPxTextBox ID="TB_CWMSSERIAL" runat="server" Width="600px">                                            
                                        </dx:ASPxTextBox></td>
                            </tr>
                            <tr>
                                <td>自動監測設施採用量測方法</td>
                                <td>
                                    <asp:DropDownList ID="DDL_CWMSMETHOD" runat="server" DataSourceID="SqlDataSource4" DataTextField="SampleName" DataValueField="SampleName" Width="400px">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>"
                                        SelectCommand="SELECT [SampleID], [SampleName] FROM [CWMSSampleMethod]"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">請檢附實驗室出具之檢測報告影本
                                    <dx:ASPxLabel ID="ASPxLabel145" runat="server" Text="附件:"></dx:ASPxLabel>
                                    <asp:DropDownList ID="DDL_RATA" DataSourceID="SDS_PDF_DDL" DataTextField="DocNumber" DataValueField="DocNumber" runat="server" AppendDataBoundItems="True">
                                        <asp:ListItem Selected="True" Value="請選擇">請選擇</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxButton ID="BT_RATA_SAVE" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                    <dx:ASPxButton ID="BT_RATA_CAN" runat="server" Text="取消" Width="80px">
                                    </dx:ASPxButton>
                                    <asp:Label ID="Label_Rata" runat="server" ForeColor="White"></asp:Label>
                                    <asp:SqlDataSource ID="SDS_Rata" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>"
                                        SelectCommand="SELECT * FROM [DOC_RATA] WHERE ([CNO] = @CNO)" 
                                        DeleteCommand="DELETE FROM [DOC_RATA] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM"
                                        InsertCommand="INSERT INTO [DOC_RATA] ([CNO], [DP_NO], [DOCVERSION], [ITEM], [YEAR], [MM], [GROUPSELECT], [DATA_1_SDate], [DATA_1_STime], [DATA_1A], [DATA_1B], [DATA_1D], [DATA_2_SDate], [DATA_2_STime], [DATA_2A], [DATA_2B], [DATA_2D], [DATA_3_SDate], [DATA_3_STime], [DATA_3A], [DATA_3B], [DATA_3D], [DATA_4_SDate], [DATA_4_STime], [DATA_4A], [DATA_4B], [DATA_4D], [DATA_5_SDate], [DATA_5_STime], [DATA_5A], [DATA_5B], [DATA_5D], [DATA_6_SDate], [DATA_6_STime], [DATA_6A], [DATA_6B], [DATA_6D], [DATA_7_SDate], [DATA_7_STime], [DATA_7A], [DATA_7B], [DATA_7D], [DATA_8_SDate], [DATA_8_STime], [DATA_8A], [DATA_8B], [DATA_8D], [DATA_9_SDate], [DATA_9_STime], [DATA_9A], [DATA_9B], [DATA_9D], [DATA_10_SDate], [DATA_10_STime], [DATA_10A], [DATA_10B], [DATA_10D], [DATA_11_SDate], [DATA_11_STime], [DATA_11A], [DATA_11B], [DATA_11D], [DATA_12_SDate], [DATA_12_STime], [DATA_12A], [DATA_12B], [DATA_12D], [AVG_A], [AVG_B], [AVG_D], [AVGDIFF], [FACTOR_A], [ACCURACY_A], [STD], [SampleMethod], [PreRataID], [CWMSAGENT], [CWMSMODEL], [CWMSSERIAL], [CWMSMETHOD]) VALUES (@CNO, @DP_NO, @DOCVERSION, @ITEM, @YEAR, @MM, @GROUPSELECT, @DATA_1_SDate, @DATA_1_STime, @DATA_1A, @DATA_1B, @DATA_1D, @DATA_2_SDate, @DATA_2_STime, @DATA_2A, @DATA_2B, @DATA_2D, @DATA_3_SDate, @DATA_3_STime, @DATA_3A, @DATA_3B, @DATA_3D, @DATA_4_SDate, @DATA_4_STime, @DATA_4A, @DATA_4B, @DATA_4D, @DATA_5_SDate, @DATA_5_STime, @DATA_5A, @DATA_5B, @DATA_5D, @DATA_6_SDate, @DATA_6_STime, @DATA_6A, @DATA_6B, @DATA_6D, @DATA_7_SDate, @DATA_7_STime, @DATA_7A, @DATA_7B, @DATA_7D, @DATA_8_SDate, @DATA_8_STime, @DATA_8A, @DATA_8B, @DATA_8D, @DATA_9_SDate, @DATA_9_STime, @DATA_9A, @DATA_9B, @DATA_9D, @DATA_10_SDate, @DATA_10_STime, @DATA_10A, @DATA_10B, @DATA_10D, @DATA_11_SDate, @DATA_11_STime, @DATA_11A, @DATA_11B, @DATA_11D, @DATA_12_SDate, @DATA_12_STime, @DATA_12A, @DATA_12B, @DATA_12D, @AVG_A, @AVG_B, @AVG_D, @AVGDIFF, @FACTOR_A, @ACCURACY_A, @STD, @SampleMethod, @PreRataID, @CWMSAGENT, @CWMSMODEL, @CWMSSERIAL, @CWMSMETHOD)" 
                                        UpdateCommand="UPDATE [DOC_RATA] SET [YEAR] = @YEAR, [MM] = @MM, [GROUPSELECT] = @GROUPSELECT, [DATA_1_SDate] = @DATA_1_SDate, [DATA_1_STime] = @DATA_1_STime, [DATA_1A] = @DATA_1A, [DATA_1B] = @DATA_1B, [DATA_1D] = @DATA_1D, [DATA_2_SDate] = @DATA_2_SDate, [DATA_2_STime] = @DATA_2_STime, [DATA_2A] = @DATA_2A, [DATA_2B] = @DATA_2B, [DATA_2D] = @DATA_2D, [DATA_3_SDate] = @DATA_3_SDate, [DATA_3_STime] = @DATA_3_STime, [DATA_3A] = @DATA_3A, [DATA_3B] = @DATA_3B, [DATA_3D] = @DATA_3D, [DATA_4_SDate] = @DATA_4_SDate, [DATA_4_STime] = @DATA_4_STime, [DATA_4A] = @DATA_4A, [DATA_4B] = @DATA_4B, [DATA_4D] = @DATA_4D, [DATA_5_SDate] = @DATA_5_SDate, [DATA_5_STime] = @DATA_5_STime, [DATA_5A] = @DATA_5A, [DATA_5B] = @DATA_5B, [DATA_5D] = @DATA_5D, [DATA_6_SDate] = @DATA_6_SDate, [DATA_6_STime] = @DATA_6_STime, [DATA_6A] = @DATA_6A, [DATA_6B] = @DATA_6B, [DATA_6D] = @DATA_6D, [DATA_7_SDate] = @DATA_7_SDate, [DATA_7_STime] = @DATA_7_STime, [DATA_7A] = @DATA_7A, [DATA_7B] = @DATA_7B, [DATA_7D] = @DATA_7D, [DATA_8_SDate] = @DATA_8_SDate, [DATA_8_STime] = @DATA_8_STime, [DATA_8A] = @DATA_8A, [DATA_8B] = @DATA_8B, [DATA_8D] = @DATA_8D, [DATA_9_SDate] = @DATA_9_SDate, [DATA_9_STime] = @DATA_9_STime, [DATA_9A] = @DATA_9A, [DATA_9B] = @DATA_9B, [DATA_9D] = @DATA_9D, [DATA_10_SDate] = @DATA_10_SDate, [DATA_10_STime] = @DATA_10_STime, [DATA_10A] = @DATA_10A, [DATA_10B] = @DATA_10B, [DATA_10D] = @DATA_10D, [DATA_11_SDate] = @DATA_11_SDate, [DATA_11_STime] = @DATA_11_STime, [DATA_11A] = @DATA_11A, [DATA_11B] = @DATA_11B, [DATA_11D] = @DATA_11D, [DATA_12_SDate] = @DATA_12_SDate, [DATA_12_STime] = @DATA_12_STime, [DATA_12A] = @DATA_12A, [DATA_12B] = @DATA_12B, [DATA_12D] = @DATA_12D, [AVG_A] = @AVG_A, [AVG_B] = @AVG_B, [AVG_D] = @AVG_D, [AVGDIFF] = @AVGDIFF, [FACTOR_A] = @FACTOR_A, [ACCURACY_A] = @ACCURACY_A, [STD] = @STD, [SampleMethod] = @SampleMethod, [PreRataID] = @PreRataID, [CWMSAGENT] = @CWMSAGENT, [CWMSMODEL] = @CWMSMODEL, [CWMSSERIAL] = @CWMSSERIAL, [CWMSMETHOD] = @CWMSMETHOD WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM">
                                        <DeleteParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="String" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="String" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                            <asp:Parameter Name="YEAR" Type="String" />
                                            <asp:Parameter Name="MM" Type="String" />
                                            <asp:Parameter Name="GROUPSELECT" Type="String" />
                                            <asp:Parameter DbType="Date" Name="DATA_1_SDate" />
                                            <asp:Parameter Name="DATA_1_STime" Type="String" />
                                            <asp:Parameter Name="DATA_1A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_1B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_1D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_2_SDate" />
                                            <asp:Parameter Name="DATA_2_STime" Type="String" />
                                            <asp:Parameter Name="DATA_2A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_3_SDate" />
                                            <asp:Parameter Name="DATA_3_STime" Type="String" />
                                            <asp:Parameter Name="DATA_3A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_4_SDate" />
                                            <asp:Parameter Name="DATA_4_STime" Type="String" />
                                            <asp:Parameter Name="DATA_4A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_5_SDate" />
                                            <asp:Parameter Name="DATA_5_STime" Type="String" />
                                            <asp:Parameter Name="DATA_5A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_6_SDate" />
                                            <asp:Parameter Name="DATA_6_STime" Type="String" />
                                            <asp:Parameter Name="DATA_6A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_7_SDate" />
                                            <asp:Parameter Name="DATA_7_STime" Type="String" />
                                            <asp:Parameter Name="DATA_7A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_8_SDate" />
                                            <asp:Parameter Name="DATA_8_STime" Type="String" />
                                            <asp:Parameter Name="DATA_8A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_9_SDate" />
                                            <asp:Parameter Name="DATA_9_STime" Type="String" />
                                            <asp:Parameter Name="DATA_9A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_10_SDate" />
                                            <asp:Parameter Name="DATA_10_STime" Type="String" />
                                            <asp:Parameter Name="DATA_10A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_11_SDate" />
                                            <asp:Parameter Name="DATA_11_STime" Type="String" />
                                            <asp:Parameter Name="DATA_11A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_12_SDate" />
                                            <asp:Parameter Name="DATA_12_STime" Type="String" />
                                            <asp:Parameter Name="DATA_12A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12D" Type="Decimal" />
                                            <asp:Parameter Name="AVG_A" Type="Decimal" />
                                            <asp:Parameter Name="AVG_B" Type="Decimal" />
                                            <asp:Parameter Name="AVG_D" Type="Decimal" />
                                            <asp:Parameter Name="AVGDIFF" Type="Decimal" />
                                            <asp:Parameter Name="FACTOR_A" Type="Decimal" />
                                            <asp:Parameter Name="ACCURACY_A" Type="Decimal" />
                                            <asp:Parameter Name="STD" Type="Decimal" />
                                            <asp:Parameter Name="SampleMethod" Type="String" />
                                            <asp:Parameter Name="PreRataID" Type="String" />
                                            <asp:Parameter Name="CWMSAGENT" Type="String" />
                                            <asp:Parameter Name="CWMSMODEL" Type="String" />
                                            <asp:Parameter Name="CWMSSERIAL" Type="String" />
                                            <asp:Parameter Name="CWMSMETHOD" Type="String" />
                                        </InsertParameters>
                                        <SelectParameters>
                                            <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                        </SelectParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="YEAR" Type="String" />
                                            <asp:Parameter Name="MM" Type="String" />
                                            <asp:Parameter Name="GROUPSELECT" Type="String" />
                                            <asp:Parameter DbType="Date" Name="DATA_1_SDate" />
                                            <asp:Parameter Name="DATA_1_STime" Type="String" />
                                            <asp:Parameter Name="DATA_1A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_1B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_1D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_2_SDate" />
                                            <asp:Parameter Name="DATA_2_STime" Type="String" />
                                            <asp:Parameter Name="DATA_2A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_2D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_3_SDate" />
                                            <asp:Parameter Name="DATA_3_STime" Type="String" />
                                            <asp:Parameter Name="DATA_3A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_3D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_4_SDate" />
                                            <asp:Parameter Name="DATA_4_STime" Type="String" />
                                            <asp:Parameter Name="DATA_4A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_4D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_5_SDate" />
                                            <asp:Parameter Name="DATA_5_STime" Type="String" />
                                            <asp:Parameter Name="DATA_5A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_5D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_6_SDate" />
                                            <asp:Parameter Name="DATA_6_STime" Type="String" />
                                            <asp:Parameter Name="DATA_6A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_6D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_7_SDate" />
                                            <asp:Parameter Name="DATA_7_STime" Type="String" />
                                            <asp:Parameter Name="DATA_7A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_7D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_8_SDate" />
                                            <asp:Parameter Name="DATA_8_STime" Type="String" />
                                            <asp:Parameter Name="DATA_8A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_8D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_9_SDate" />
                                            <asp:Parameter Name="DATA_9_STime" Type="String" />
                                            <asp:Parameter Name="DATA_9A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_9D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_10_SDate" />
                                            <asp:Parameter Name="DATA_10_STime" Type="String" />
                                            <asp:Parameter Name="DATA_10A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_10D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_11_SDate" />
                                            <asp:Parameter Name="DATA_11_STime" Type="String" />
                                            <asp:Parameter Name="DATA_11A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_11D" Type="Decimal" />
                                            <asp:Parameter DbType="Date" Name="DATA_12_SDate" />
                                            <asp:Parameter Name="DATA_12_STime" Type="String" />
                                            <asp:Parameter Name="DATA_12A" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12B" Type="Decimal" />
                                            <asp:Parameter Name="DATA_12D" Type="Decimal" />
                                            <asp:Parameter Name="AVG_A" Type="Decimal" />
                                            <asp:Parameter Name="AVG_B" Type="Decimal" />
                                            <asp:Parameter Name="AVG_D" Type="Decimal" />
                                            <asp:Parameter Name="AVGDIFF" Type="Decimal" />
                                            <asp:Parameter Name="FACTOR_A" Type="Decimal" />
                                            <asp:Parameter Name="ACCURACY_A" Type="Decimal" />
                                            <asp:Parameter Name="STD" Type="Decimal" />
                                            <asp:Parameter Name="SampleMethod" Type="String" />
                                            <asp:Parameter Name="PreRataID" Type="String" />
                                            <asp:Parameter Name="CWMSAGENT" Type="String" />
                                            <asp:Parameter Name="CWMSMODEL" Type="String" />
                                            <asp:Parameter Name="CWMSSERIAL" Type="String" />
                                            <asp:Parameter Name="CWMSMETHOD" Type="String" />
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DP_NO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="String" />
                                            <asp:Parameter Name="ITEM" Type="String" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="附錄4、連線傳輸設施設置確認書">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        
                        <table style="width: 100%;" border="1">
                            <tr>
                                <td align="center" bgcolor="#00FFCC" colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel48" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="設置項目" Width="300px">
                                    </dx:ASPxLabel>
                                </td>
                                <td align="center" bgcolor="#00FFCC">
                                    <dx:ASPxLabel ID="ASPxLabel42" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="實際完成日期" Width="200px">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style20">
                                    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="1.傳輸設施建置" Width="120px">
                                    </dx:ASPxLabel>
                                </td>
                                <td class="auto-style18">
                                    <dx:ASPxTextBox ID="TB_LP_SETCOMPANY" runat="server" Width="300px" Caption="負責設置公司">
                                    </dx:ASPxTextBox>
                                    <dx:ASPxTextBox ID="TB_LP_SETPEOPLE" runat="server" Caption="負責設置人員" Width="300px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_LP_DATE1" runat="server" MinDate="1970-01-01">
                                    </dx:ASPxDateEdit>(完工驗收日期)YYYY-MM-DD
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="ASPxLabel26" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="2.監測數據採擷及處理系統(監測資料傳輸檔案處理)" Width="420px">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxDateEdit ID="TB_LP_DATE3" runat="server" MinDate="1970-01-01">
                                    </dx:ASPxDateEdit>YYYY-MM-DD
                                </td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2" >
                                    <dx:ASPxLabel ID="ASPxLabel27" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="3.連線測試開始時間">
                                    </dx:ASPxLabel>
                                </td>                                
                                <td>
                                    <dx:ASPxDateEdit ID="TB_LP_DATE4" runat="server" MinDate="1970-01-01">
                                    </dx:ASPxDateEdit>YYYY-MM-DD
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" bgcolor="#00FFCC" align="center">
                                    <dx:ASPxLabel ID="ASPxLabel53" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="實際連線測試結果(以下列(1)~(5)由地方主管機關填寫，必要時應至現場實際確認">
                                    </dx:ASPxLabel>
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
                                        DeleteCommand="DELETE FROM [DOC_VRY_LP] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION"
                                        InsertCommand="INSERT INTO [DOC_VRY_LP] ([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE], [ITEM1_DATE], [ITEM2_DATE], [ITEM3_DATE], [ITEM4_DATE], [LINKTEST_1], [LINKTEST_2], [LINKTEST_3], [LINKTEST_4], [LINKTEST_5]) VALUES (@CNO, @DOCVERSION, @SETCOMPANY, @SETPEOPLE, @ITEM1_DATE, @ITEM2_DATE, @ITEM3_DATE, @ITEM4_DATE, @LINKTEST_1, @LINKTEST_2, @LINKTEST_3, @LINKTEST_4, @LINKTEST_5)"
                                        SelectCommand="SELECT * FROM [DOC_VRY_LP]"
                                        UpdateCommand="UPDATE [DOC_VRY_LP] SET [SETCOMPANY] = @SETCOMPANY, [SETPEOPLE] = @SETPEOPLE, [ITEM1_DATE] = @ITEM1_DATE, [ITEM2_DATE] = @ITEM2_DATE, [ITEM3_DATE] = @ITEM3_DATE, [ITEM4_DATE] = @ITEM4_DATE, [LINKTEST_1] = @LINKTEST_1, [LINKTEST_2] = @LINKTEST_2, [LINKTEST_3] = @LINKTEST_3, [LINKTEST_4] = @LINKTEST_4, [LINKTEST_5] = @LINKTEST_5 WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
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
                                            <asp:Parameter DbType="Date" Name="ITEM2_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM3_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_DATE" />
                                            <asp:Parameter Name="LINKTEST_1" Type="String" />
                                            <asp:Parameter Name="LINKTEST_2" Type="String" />
                                            <asp:Parameter Name="LINKTEST_3" Type="String" />
                                            <asp:Parameter Name="LINKTEST_4" Type="String" />
                                            <asp:Parameter Name="LINKTEST_5" Type="String" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="SETCOMPANY" Type="String" />
                                            <asp:Parameter Name="SETPEOPLE" Type="String" />
                                            <asp:Parameter Name="ITEM1_DATE" DbType="Date" />
                                            <asp:Parameter DbType="Date" Name="ITEM2_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM3_DATE" />
                                            <asp:Parameter DbType="Date" Name="ITEM4_DATE" />
                                            <asp:Parameter Name="LINKTEST_1" Type="String" />
                                            <asp:Parameter Name="LINKTEST_2" Type="String" />
                                            <asp:Parameter Name="LINKTEST_3" Type="String" />
                                            <asp:Parameter Name="LINKTEST_4" Type="String" />
                                            <asp:Parameter Name="LINKTEST_5" Type="String" />
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
           <dx:TabPage Text="附錄5、確認報告書申請文件檢核表">
                <TabStyle VerticalAlign="Top">
                </TabStyle>
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        
                        <table style="width:100%;" border ="1">
                            <tr>
                                <td align="center" bgcolor="#00FFCC" colspan ="2">
                                    <dx:ASPxLabel ID="ASPxLabel25" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="本次申請檢附之申請表" Width="300px">
                                    </dx:ASPxLabel>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="申請表首頁" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_COVER" ></asp:CheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="基本資料" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_BASIC" ></asp:CheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="自動監測（視）設施規劃說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC" ></asp:CheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td >
                                    <asp:CheckBox runat="server" Text="數據採擷及處理系統規劃說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_DAHS" ></asp:CheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="連線傳輸設施規劃說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LINK" ></asp:CheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="放流水水量、水質自動顯示看板規劃說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LED" ></asp:CheckBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2" align="center" bgcolor="#00FFCC">
                                    <dx:ASPxLabel ID="ASPxLabel69" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="基本資料相關附件" Width="300px">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="負責人授權之證明文件及原因說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_BASIC_C1" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_BASIC_C1"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td colspan ="2" align="center" bgcolor="#00FFCC">
                                    <dx:ASPxLabel ID="ASPxLabel80" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="自動監測（視）設施規劃說明相關附件" Width="300px">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C1" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C1"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style22">
                                    <asp:CheckBox runat="server" Text="監測設施同時監測其他位置之說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C2" GroupName="type"></asp:CheckBox>

                                </td>
                                <td class="auto-style22">
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C2"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="核准採行替代量測方式具體說明及報經主管機關核准採行之核准公文影本" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C3" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C3"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="監測設施有過濾器/前處理裝置之影響說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C4" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C4"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="監測設施有產生廢液（材）之儲存清理方式說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C5" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C5"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="監測設施製造商校正方式及周期說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C6" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C6"></dx:ASPxTextBox>

                                </td>
                            </tr>                            
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="自動監測（視）設施維修保養合約書或計畫書" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C7" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C7"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="水質自動監測設施相對誤差測試報告" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C8" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C8"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="經水質檢驗認證合格之環境檢驗測定機構實驗室出具之水質檢測報告影本" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C9" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C9"></dx:ASPxTextBox>

                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="電子式電度表規格符合國家標準說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C10" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C10"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="監測設施輸出訊號格式之數位介面硬體連接方法說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C11" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C11"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="監測設施輸出訊號格式之數位設備連接參數資料" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C12" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C12"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="監測設施輸出訊號格式引用介面之相關功能文件" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C13" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C13"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="各項自動監測（視）設施設置位置圖（與廢水處理設施相對位置）" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C14" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C14"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="各項自動監測（視）設施設置位置圖（與廠區相對位置）" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C15" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C15"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="各項自動監測（視）設施及電子式電度表設置完工照片" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_SPEC_C16" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_SPEC_C16"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#00FFCC" colspan="2">
                                    <dx:ASPxLabel runat="server" Text="數據採擷及處理系統規劃說明相關附件" Width="300px" Font-Names="微軟正黑體" Font-Size="Medium" ID="ASPxLabel81"></dx:ASPxLabel>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="系統維修保養說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_DAHS_C1" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_DAHS_C1"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="實際數據採擷及處理系統網路配置圖" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_DAHS_C2" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_DAHS_C2"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#00FFCC" colspan="2">
                                    <dx:ASPxLabel runat="server" Text="連線傳輸設施規劃說明相關附件" Width="300px" Font-Names="微軟正黑體" Font-Size="Medium" ID="ASPxLabel82"></dx:ASPxLabel>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="連線傳輸設施製造商維修保養說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LINK_C1" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_LINK_C1"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="連線傳輸設施維修保養合約書或計畫書" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LINK_C2" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_LINK_C2"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="連線傳輸設施設置確認書" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LINK_C3" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_LINK_C3"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="實際連線傳輸設施設置位置圖" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LINK_C4" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_LINK_C4"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="連線傳輸設施設置完工照片" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LINK_C5" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_LINK_C5"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="center" bgcolor="#00FFCC" colspan="2">
                                    <dx:ASPxLabel runat="server" Text="放流水水量、水質自動顯示看板規劃說明相關附件" Width="300px" Font-Names="微軟正黑體" Font-Size="Medium" ID="ASPxLabel83"></dx:ASPxLabel>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="自動顯示看板故障或校正維護期間之替代方式說明" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LED_C1" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_LED_C1"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="實際放流水水量、水質自動顯示看板設置位置圖" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LED_C2" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_LED_C2"></dx:ASPxTextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox runat="server" Text="放流水水量、水質自動顯示看板設置完工照片" Font-Names="微軟正黑體" Font-Size="Medium" ID="CB_CHECK_LED_C3" GroupName="type"></asp:CheckBox>

                                </td>
                                <td>
                                    <dx:ASPxTextBox runat="server" Width="100px" Caption="附件" Font-Names="微軟正黑體" Font-Size="Medium" ID="TB_CHECK_LED_C3"></dx:ASPxTextBox>

                                </td>
                            </tr>
                        </table>
                        <p>
                        </p>
                        <table style="width:100%;">
                            <tr>
                                <td width="80">
                                    <dx:ASPxButton ID="BT_CheckList" runat="server" Text="儲存" Width="80px">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton runat="server" Text="取消" Width="80px" ID="BT_CHECKLIST_CANCEL"></dx:ASPxButton>

                                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                        DeleteCommand="DELETE FROM [DOC_VRY_CHECKLIST] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" 
                                        InsertCommand="INSERT INTO [DOC_VRY_CHECKLIST] ([CNO], [DOCVERSION], [CB_CHECK_COVER], [CB_CHECK_BASIC], [CB_CHECK_SPEC], [CB_CHECK_DAHS], [CB_CHECK_LINK], [CB_CHECK_LED], [CB_CHECK_BASIC_C1], [CB_CHECK_BASIC_C1_AT], [CB_CHECK_SPEC_C1], [CB_CHECK_SPEC_C1_AT], [CB_CHECK_SPEC_C2], [CB_CHECK_SPEC_C2_AT], [CB_CHECK_SPEC_C3], [CB_CHECK_SPEC_C3_AT], [CB_CHECK_SPEC_C4], [CB_CHECK_SPEC_C4_AT], [CB_CHECK_SPEC_C5], [CB_CHECK_SPEC_C5_AT], [CB_CHECK_SPEC_C6], [CB_CHECK_SPEC_C6_AT], [CB_CHECK_SPEC_C7], [CB_CHECK_SPEC_C7_AT], [CB_CHECK_SPEC_C8], [CB_CHECK_SPEC_C8_AT], [CB_CHECK_SPEC_C9], [CB_CHECK_SPEC_C9_AT], [CB_CHECK_SPEC_C10], [CB_CHECK_SPEC_C10_AT], [CB_CHECK_SPEC_C11], [CB_CHECK_SPEC_C11_AT], [CB_CHECK_SPEC_C12], [CB_CHECK_SPEC_C12_AT], [CB_CHECK_SPEC_C13], [CB_CHECK_SPEC_C13_AT], [CB_CHECK_SPEC_C14], [CB_CHECK_SPEC_C14_AT], [CB_CHECK_SPEC_C15], [CB_CHECK_SPEC_C15_AT], [CB_CHECK_SPEC_C16], [CB_CHECK_SPEC_C16_AT], [CB_CHECK_DAHS_C1], [CB_CHECK_DAHS_C1_AT], [CB_CHECK_DAHS_C2], [CB_CHECK_DAHS_C2_AT], [CB_CHECK_LINK_C1], [CB_CHECK_LINK_C1_AT], [CB_CHECK_LINK_C2], [CB_CHECK_LINK_C2_AT], [CB_CHECK_LINK_C3], [CB_CHECK_LINK_C3_AT], [CB_CHECK_LINK_C4], [CB_CHECK_LINK_C4_AT], [CB_CHECK_LINK_C5], [CB_CHECK_LINK_C5_AT], [CB_CHECK_LED_C1], [CB_CHECK_LED_C1_AT], [CB_CHECK_LED_C2], [CB_CHECK_LED_C2_AT], [CB_CHECK_LED_C3], [CB_CHECK_LED_C3_AT], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DOCVERSION, @CB_CHECK_COVER, @CB_CHECK_BASIC, @CB_CHECK_SPEC, @CB_CHECK_DAHS, @CB_CHECK_LINK, @CB_CHECK_LED, @CB_CHECK_BASIC_C1, @CB_CHECK_BASIC_C1_AT, @CB_CHECK_SPEC_C1, @CB_CHECK_SPEC_C1_AT, @CB_CHECK_SPEC_C2, @CB_CHECK_SPEC_C2_AT, @CB_CHECK_SPEC_C3, @CB_CHECK_SPEC_C3_AT, @CB_CHECK_SPEC_C4, @CB_CHECK_SPEC_C4_AT, @CB_CHECK_SPEC_C5, @CB_CHECK_SPEC_C5_AT, @CB_CHECK_SPEC_C6, @CB_CHECK_SPEC_C6_AT, @CB_CHECK_SPEC_C7, @CB_CHECK_SPEC_C7_AT, @CB_CHECK_SPEC_C8, @CB_CHECK_SPEC_C8_AT, @CB_CHECK_SPEC_C9, @CB_CHECK_SPEC_C9_AT, @CB_CHECK_SPEC_C10, @CB_CHECK_SPEC_C10_AT, @CB_CHECK_SPEC_C11, @CB_CHECK_SPEC_C11_AT, @CB_CHECK_SPEC_C12, @CB_CHECK_SPEC_C12_AT, @CB_CHECK_SPEC_C13, @CB_CHECK_SPEC_C13_AT, @CB_CHECK_SPEC_C14, @CB_CHECK_SPEC_C14_AT, @CB_CHECK_SPEC_C15, @CB_CHECK_SPEC_C15_AT, @CB_CHECK_SPEC_C16, @CB_CHECK_SPEC_C16_AT, @CB_CHECK_DAHS_C1, @CB_CHECK_DAHS_C1_AT, @CB_CHECK_DAHS_C2, @CB_CHECK_DAHS_C2_AT, @CB_CHECK_LINK_C1, @CB_CHECK_LINK_C1_AT, @CB_CHECK_LINK_C2, @CB_CHECK_LINK_C2_AT, @CB_CHECK_LINK_C3, @CB_CHECK_LINK_C3_AT, @CB_CHECK_LINK_C4, @CB_CHECK_LINK_C4_AT, @CB_CHECK_LINK_C5, @CB_CHECK_LINK_C5_AT, @CB_CHECK_LED_C1, @CB_CHECK_LED_C1_AT, @CB_CHECK_LED_C2, @CB_CHECK_LED_C2_AT, @CB_CHECK_LED_C3, @CB_CHECK_LED_C3_AT, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
                                        SelectCommand="SELECT * FROM [DOC_VRY_CHECKLIST]" 
                                        UpdateCommand="UPDATE [DOC_VRY_CHECKLIST] SET [CB_CHECK_COVER] = @CB_CHECK_COVER, [CB_CHECK_BASIC] = @CB_CHECK_BASIC, [CB_CHECK_SPEC] = @CB_CHECK_SPEC, [CB_CHECK_DAHS] = @CB_CHECK_DAHS, [CB_CHECK_LINK] = @CB_CHECK_LINK, [CB_CHECK_LED] = @CB_CHECK_LED, [CB_CHECK_BASIC_C1] = @CB_CHECK_BASIC_C1, [CB_CHECK_BASIC_C1_AT] = @CB_CHECK_BASIC_C1_AT, [CB_CHECK_SPEC_C1] = @CB_CHECK_SPEC_C1, [CB_CHECK_SPEC_C1_AT] = @CB_CHECK_SPEC_C1_AT, [CB_CHECK_SPEC_C2] = @CB_CHECK_SPEC_C2, [CB_CHECK_SPEC_C2_AT] = @CB_CHECK_SPEC_C2_AT, [CB_CHECK_SPEC_C3] = @CB_CHECK_SPEC_C3, [CB_CHECK_SPEC_C3_AT] = @CB_CHECK_SPEC_C3_AT, [CB_CHECK_SPEC_C4] = @CB_CHECK_SPEC_C4, [CB_CHECK_SPEC_C4_AT] = @CB_CHECK_SPEC_C4_AT, [CB_CHECK_SPEC_C5] = @CB_CHECK_SPEC_C5, [CB_CHECK_SPEC_C5_AT] = @CB_CHECK_SPEC_C5_AT, [CB_CHECK_SPEC_C6] = @CB_CHECK_SPEC_C6, [CB_CHECK_SPEC_C6_AT] = @CB_CHECK_SPEC_C6_AT, [CB_CHECK_SPEC_C7] = @CB_CHECK_SPEC_C7, [CB_CHECK_SPEC_C7_AT] = @CB_CHECK_SPEC_C7_AT, [CB_CHECK_SPEC_C8] = @CB_CHECK_SPEC_C8, [CB_CHECK_SPEC_C8_AT] = @CB_CHECK_SPEC_C8_AT, [CB_CHECK_SPEC_C9] = @CB_CHECK_SPEC_C9, [CB_CHECK_SPEC_C9_AT] = @CB_CHECK_SPEC_C9_AT, [CB_CHECK_SPEC_C10] = @CB_CHECK_SPEC_C10, [CB_CHECK_SPEC_C10_AT] = @CB_CHECK_SPEC_C10_AT, [CB_CHECK_SPEC_C11] = @CB_CHECK_SPEC_C11, [CB_CHECK_SPEC_C11_AT] = @CB_CHECK_SPEC_C11_AT, [CB_CHECK_SPEC_C12] = @CB_CHECK_SPEC_C12, [CB_CHECK_SPEC_C12_AT] = @CB_CHECK_SPEC_C12_AT, [CB_CHECK_SPEC_C13] = @CB_CHECK_SPEC_C13, [CB_CHECK_SPEC_C13_AT] = @CB_CHECK_SPEC_C13_AT, [CB_CHECK_SPEC_C14] = @CB_CHECK_SPEC_C14, [CB_CHECK_SPEC_C14_AT] = @CB_CHECK_SPEC_C14_AT, [CB_CHECK_SPEC_C15] = @CB_CHECK_SPEC_C15, [CB_CHECK_SPEC_C15_AT] = @CB_CHECK_SPEC_C15_AT, [CB_CHECK_SPEC_C16] = @CB_CHECK_SPEC_C16, [CB_CHECK_SPEC_C16_AT] = @CB_CHECK_SPEC_C16_AT, [CB_CHECK_DAHS_C1] = @CB_CHECK_DAHS_C1, [CB_CHECK_DAHS_C1_AT] = @CB_CHECK_DAHS_C1_AT, [CB_CHECK_DAHS_C2] = @CB_CHECK_DAHS_C2, [CB_CHECK_DAHS_C2_AT] = @CB_CHECK_DAHS_C2_AT, [CB_CHECK_LINK_C1] = @CB_CHECK_LINK_C1, [CB_CHECK_LINK_C1_AT] = @CB_CHECK_LINK_C1_AT, [CB_CHECK_LINK_C2] = @CB_CHECK_LINK_C2, [CB_CHECK_LINK_C2_AT] = @CB_CHECK_LINK_C2_AT, [CB_CHECK_LINK_C3] = @CB_CHECK_LINK_C3, [CB_CHECK_LINK_C3_AT] = @CB_CHECK_LINK_C3_AT, [CB_CHECK_LINK_C4] = @CB_CHECK_LINK_C4, [CB_CHECK_LINK_C4_AT] = @CB_CHECK_LINK_C4_AT, [CB_CHECK_LINK_C5] = @CB_CHECK_LINK_C5, [CB_CHECK_LINK_C5_AT] = @CB_CHECK_LINK_C5_AT, [CB_CHECK_LED_C1] = @CB_CHECK_LED_C1, [CB_CHECK_LED_C1_AT] = @CB_CHECK_LED_C1_AT, [CB_CHECK_LED_C2] = @CB_CHECK_LED_C2, [CB_CHECK_LED_C2_AT] = @CB_CHECK_LED_C2_AT, [CB_CHECK_LED_C3] = @CB_CHECK_LED_C3, [CB_CHECK_LED_C3_AT] = @CB_CHECK_LED_C3_AT, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
                                        <DeleteParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                        </DeleteParameters>
                                        <InsertParameters>
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                            <asp:Parameter Name="CB_CHECK_COVER" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_BASIC" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_BASIC_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_BASIC_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C2" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C2_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C3" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C3_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C4" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C4_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C5" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C5_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C6" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C6_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C7" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C7_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C8" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C8_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C9" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C9_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C10" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C10_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C11" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C11_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C12" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C12_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C13" Type="String" />
                                            <asp:Parameter Name="column1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C14" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C14_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C15" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C15_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C16" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C16_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS_C2" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS_C2_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C2" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C2_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C3" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C3_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C4" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C4_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C5" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C5_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C2" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C2_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C3" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C3_AT" Type="String" />
                                            <asp:Parameter Name="C_ID" Type="String" />
                                            <asp:Parameter DbType="Date" Name="C_DATE" />
                                            <asp:Parameter Name="U_ID" Type="String" />
                                            <asp:Parameter DbType="Date" Name="U_DATE" />
                                        </InsertParameters>
                                        <UpdateParameters>
                                            <asp:Parameter Name="CB_CHECK_COVER" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_BASIC" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_BASIC_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_BASIC_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C2" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C2_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C3" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C3_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C4" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C4_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C5" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C5_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C6" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C6_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C7" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C7_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C8" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C8_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C9" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C9_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C10" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C10_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C11" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C11_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C12" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C12_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C13" Type="String" />
                                            <asp:Parameter Name="column1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C14" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C14_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C15" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C15_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C16" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_SPEC_C16_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS_C2" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_DAHS_C2_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C2" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C2_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C3" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C3_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C4" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C4_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C5" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LINK_C5_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C1" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C1_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C2" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C2_AT" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C3" Type="String" />
                                            <asp:Parameter Name="CB_CHECK_LED_C3_AT" Type="String" />
                                            <asp:Parameter Name="C_ID" Type="String" />
                                            <asp:Parameter DbType="Date" Name="C_DATE" />
                                            <asp:Parameter Name="U_ID" Type="String" />
                                            <asp:Parameter DbType="Date" Name="U_DATE" />
                                            <asp:Parameter Name="CNO" Type="String" />
                                            <asp:Parameter Name="DOCVERSION" Type="Int32" />
                                        </UpdateParameters>
                                    </asp:SqlDataSource>

                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
  <script type ="text/jscript" >  
        
	function enhancedRadio() {  
	    var r = document.forms[0].elements[this.name];  
	    for (var i=0;i<r.length;i++) {  
	        if (r[i].index != this.index)  
	            r[i].isChecked = false;  
	    }  
	    this.isChecked = !this.isChecked;  
	    this.checked = this.isChecked;  
	}  
	function deployRadioEvent() {  
	    var f = document.forms[0];  
	    for (var i=0;i<f.elements.length;i++) { 
	        var e = f.elements[i]; 
	        if (e.type == "radio") { 
	            e.onclick = enhancedRadio;  
	            e.setAttribute("isChecked",false);  
	            e.setAttribute("index",i); 
	        }     
	    }     
	}  
	deployRadioEvent();  
</script>   
</asp:Content>

