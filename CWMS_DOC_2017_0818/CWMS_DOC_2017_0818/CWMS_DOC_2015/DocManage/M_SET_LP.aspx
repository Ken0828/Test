<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_SET_LP.aspx.vb" Inherits="CWMS_DOC_2015.M_SET_LP" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DOCVERSION">
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SETCOMPANY" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SETPEOPLE" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="ITEM1_DATE" VisibleIndex="4">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ITEM2_DATE" VisibleIndex="5">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ITEM3_DATE" VisibleIndex="6">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ITEM4_1_DATE" VisibleIndex="7">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ITEM4_2_DATE" VisibleIndex="8">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ITEM4_3_DATE" VisibleIndex="9">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ITEM4_4_DATE" VisibleIndex="10">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ITEM4_5_DATE" VisibleIndex="11">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="NOTE" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="14">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="16">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_SET_LP] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" InsertCommand="INSERT INTO [DOC_SET_LP] ([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE], [ITEM1_DATE], [ITEM2_DATE], [ITEM3_DATE], [ITEM4_1_DATE], [ITEM4_2_DATE], [ITEM4_3_DATE], [ITEM4_4_DATE], [ITEM4_5_DATE], [NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DOCVERSION, @SETCOMPANY, @SETPEOPLE, @ITEM1_DATE, @ITEM2_DATE, @ITEM3_DATE, @ITEM4_1_DATE, @ITEM4_2_DATE, @ITEM4_3_DATE, @ITEM4_4_DATE, @ITEM4_5_DATE, @NOTE, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DOC_SET_LP]" UpdateCommand="UPDATE [DOC_SET_LP] SET [SETCOMPANY] = @SETCOMPANY, [SETPEOPLE] = @SETPEOPLE, [ITEM1_DATE] = @ITEM1_DATE, [ITEM2_DATE] = @ITEM2_DATE, [ITEM3_DATE] = @ITEM3_DATE, [ITEM4_1_DATE] = @ITEM4_1_DATE, [ITEM4_2_DATE] = @ITEM4_2_DATE, [ITEM4_3_DATE] = @ITEM4_3_DATE, [ITEM4_4_DATE] = @ITEM4_4_DATE, [ITEM4_5_DATE] = @ITEM4_5_DATE, [NOTE] = @NOTE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="SETCOMPANY" Type="String" />
            <asp:Parameter Name="SETPEOPLE" Type="String" />
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
        <UpdateParameters>
            <asp:Parameter Name="SETCOMPANY" Type="String" />
            <asp:Parameter Name="SETPEOPLE" Type="String" />
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
</asp:Content>
