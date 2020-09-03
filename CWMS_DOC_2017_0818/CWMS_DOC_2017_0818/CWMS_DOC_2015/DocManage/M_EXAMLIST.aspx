<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_EXAMLIST.aspx.vb" Inherits="CWMS_DOC_2015.M_EXAMLIST" %>
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
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DOCVERSION;DOCTYPE">
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" ReadOnly="True" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_NAME" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="REG_DATE" VisibleIndex="5">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DOC_SERIAL" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="DOC_RECDATE" VisibleIndex="7">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="EXAM_RESULT" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="EXAM_DOCOUT_DATE" VisibleIndex="9">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="UPGRADE_DATE" VisibleIndex="10">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="OWNER" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AGENT" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="HELPER" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EPB" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        DeleteCommand="DELETE FROM [DAHS_EXAMLIST] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" 
        InsertCommand="INSERT INTO [DAHS_EXAMLIST] ([CNO], [DOCVERSION], [DOCTYPE], [FAC_NAME], [REG_DATE], [DOC_SERIAL], [DOC_RECDATE], [EXAM_RESULT], [EXAM_DOCOUT_DATE], [UPGRADE_DATE], [OWNER], [AGENT], [HELPER], [EPB]) VALUES (@CNO, @DOCVERSION, @DOCTYPE, @FAC_NAME, @REG_DATE, @DOC_SERIAL, @DOC_RECDATE, @EXAM_RESULT, @EXAM_DOCOUT_DATE, @UPGRADE_DATE, @OWNER, @AGENT, @HELPER, @EPB)" 
        SelectCommand="SELECT [CNO], [DOCVERSION], [DOCTYPE], [FAC_NAME], [REG_DATE], [DOC_SERIAL], [DOC_RECDATE], [EXAM_RESULT], [EXAM_DOCOUT_DATE], [UPGRADE_DATE], [OWNER], [AGENT], [HELPER], [EPB] FROM [DAHS_EXAMLIST]" 
        UpdateCommand="UPDATE [DAHS_EXAMLIST] SET [FAC_NAME] = @FAC_NAME, [REG_DATE] = @REG_DATE, [DOC_SERIAL] = @DOC_SERIAL, [DOC_RECDATE] = @DOC_RECDATE, [EXAM_RESULT] = @EXAM_RESULT, [EXAM_DOCOUT_DATE] = @EXAM_DOCOUT_DATE, [UPGRADE_DATE] = @UPGRADE_DATE, [OWNER] = @OWNER, [AGENT] = @AGENT, [HELPER] = @HELPER, [EPB] = @EPB WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter Name="FAC_NAME" Type="String" />
            <asp:Parameter DbType="Date" Name="REG_DATE" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter DbType="Date" Name="DOC_RECDATE" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter DbType="Date" Name="EXAM_DOCOUT_DATE" />
            <asp:Parameter DbType="Date" Name="UPGRADE_DATE" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="AGENT" Type="String" />
            <asp:Parameter Name="HELPER" Type="String" />
            <asp:Parameter Name="EPB" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="FAC_NAME" Type="String" />
            <asp:Parameter DbType="Date" Name="REG_DATE" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter DbType="Date" Name="DOC_RECDATE" />
            <asp:Parameter Name="EXAM_RESULT" Type="String" />
            <asp:Parameter DbType="Date" Name="EXAM_DOCOUT_DATE" />
            <asp:Parameter DbType="Date" Name="UPGRADE_DATE" />
            <asp:Parameter Name="OWNER" Type="String" />
            <asp:Parameter Name="AGENT" Type="String" />
            <asp:Parameter Name="HELPER" Type="String" />
            <asp:Parameter Name="EPB" Type="String" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
     <dx:ASPxGridViewExporter ID="GridViewExporter" runat="server" GridViewID="ASPxGridView1">
        </dx:ASPxGridViewExporter>
</asp:Content>
