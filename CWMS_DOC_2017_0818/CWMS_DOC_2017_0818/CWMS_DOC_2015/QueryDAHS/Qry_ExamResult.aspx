<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Qry_ExamResult.aspx.vb" Inherits="CWMS_DOC_2015.Qry_ExamResult" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Table ID="Table1" runat="server" Width="995px" CellPadding="0" CellSpacing="0" BorderWidth="0">
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
      <dx:ASPxGridView ID="GridView1" runat="server" Caption="審查結果查詢" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="管制編號,收文字號" DataSourceID="SqlDataSource1" Width="995px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small" KeyFieldName="CNO">

          <Columns>
              <dx:GridViewDataTextColumn FieldName="CNO" Caption="管制編號" ReadOnly="True" VisibleIndex="0">
              </dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="FAC_NAME" Caption="名稱" ReadOnly="True" VisibleIndex="1"></dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="DOCVERSION" Caption="版號" VisibleIndex="2" ReadOnly="True"></dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="DOCTYPE" Caption="種類" ReadOnly="True" VisibleIndex="3"></dx:GridViewDataTextColumn>
              <dx:GridViewDataDateColumn FieldName="REG_DATE" Caption="申請日期" VisibleIndex="4"></dx:GridViewDataDateColumn>
              <dx:GridViewDataDateColumn FieldName="EXAM_DOCOUT_DATE" Caption="審查日期" VisibleIndex="4"></dx:GridViewDataDateColumn>
              <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" Caption="審查結果" VisibleIndex="5"></dx:GridViewDataTextColumn>
          </Columns>
          <Settings ShowFooter="True" />
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
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridView1">
        </dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT a.* FROM [DAHS_EXAMLIST] a  ">
    </asp:SqlDataSource>
</asp:Content>
