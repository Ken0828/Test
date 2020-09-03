<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Qry_MailLogHistory.aspx.vb" Inherits="CWMS_DOC_2015.Qry_MailLogHistory" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Table ID="Table1" runat="server" Width="850px" CellPadding="0" CellSpacing="0" BorderWidth="0" Visible="false">
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
      <dx:ASPxGridView ID="GridView1" runat="server" Caption="收執聯歷史資料查詢" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="CASE_NO" DataSourceID="SqlDataSource1" Width="1200px" Theme="Aqua" Font-Names="微軟正黑體" Font-Size="Small" KeyFieldName="CASE_NO">

          <Columns>
              <dx:GridViewDataTextColumn FieldName="CASE_NO" ReadOnly="True" VisibleIndex="0" Caption ="案件編號" Width="120px"></dx:GridViewDataTextColumn>
              <dx:GridViewDataDateColumn FieldName="SEND_DATE" VisibleIndex="1" Caption ="發送日期" Width="120px" ></dx:GridViewDataDateColumn>
              <dx:GridViewDataTextColumn FieldName="CNO" VisibleIndex="2" Caption ="管制編號" Width="80px"></dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="FAC_NAME" VisibleIndex="3" Caption ="名稱" Width="200px"></dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="MAIL_TYPE" VisibleIndex="4" Caption ="發送類別"></dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="DOCTYPE" VisibleIndex="5" Caption ="文件種類"></dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="MAIL_CONTENT" VisibleIndex="6" Caption ="收執聯內容" Width="300px"></dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="EMAILTOLIST" VisibleIndex="7" Caption ="發送對象"></dx:GridViewDataTextColumn>
              <dx:GridViewDataTextColumn FieldName="CR_ID" VisibleIndex="8" Visible ="false" >
              </dx:GridViewDataTextColumn>
              <dx:GridViewDataDateColumn FieldName="CR_DATE" VisibleIndex="9" Visible ="false" ></dx:GridViewDataDateColumn>
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
            </dx:ASPxGridView>
    <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="GridView1">
        </dx:ASPxGridViewExporter>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT * FROM [DAHS_MESSAGE_LOG] order by case_no desc ">
    </asp:SqlDataSource>
</asp:Content>
