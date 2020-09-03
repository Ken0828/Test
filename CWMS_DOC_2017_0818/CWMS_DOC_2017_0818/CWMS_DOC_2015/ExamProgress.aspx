<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ExamProgress.aspx.vb" Inherits="CWMS_DOC_2015.ExamProgress" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 108px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SDS_EXAM" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                SelectCommand="SELECT * FROM [DAHS_EXAMLIST] WHERE ([CNO] = @CNO) AND EXAM_RESULT  NOT IN ('審查通過','不適用')">
                <SelectParameters>
                    <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" Caption="審查中總表" DataSourceID="SDS_EXAM" KeyFieldName="CNO" Width="1000px">
                 <Columns>
                   <dx:GridViewCommandColumn VisibleIndex="0" Visible="False" Caption="">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="1" Caption="管制編號"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DOCVERSION" VisibleIndex="2" Caption="版號" ReadOnly="True"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DOCTYPE" VisibleIndex="3" Caption="文書種類" ReadOnly="True"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="REG_DATE" VisibleIndex="4" Caption="申請日期"></dx:GridViewDataDateColumn>                    
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
                <SettingsSearchPanel ShowClearButton="True" Visible="True" />
                <SettingsText CommandCancel="取消" CommandDelete="刪除" CommandEdit="編輯" CommandNew="新增" CommandSelect="選取" CommandUpdate="更新" SearchPanelEditorNullText="輸入關鍵字查詢" CommandClearSearchPanelFilter="清除" />
                <SettingsBehavior EnableCustomizationWindow="True"  />
            </dx:ASPxGridView>
</asp:Content>
