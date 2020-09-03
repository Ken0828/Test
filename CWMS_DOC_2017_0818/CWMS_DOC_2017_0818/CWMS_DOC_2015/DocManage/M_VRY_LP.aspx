<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_VRY_LP.aspx.vb" Inherits="CWMS_DOC_2015.M_VRY_LP" %>
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
            <dx:GridViewDataDateColumn FieldName="ITEM4_DATE" VisibleIndex="7">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="LINKTEST_1" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LINKTEST_2" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LINKTEST_3" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LINKTEST_4" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LINKTEST_5" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_VRY_LP] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" InsertCommand="INSERT INTO [DOC_VRY_LP] ([CNO], [DOCVERSION], [SETCOMPANY], [SETPEOPLE], [ITEM1_DATE], [ITEM2_DATE], [ITEM3_DATE], [ITEM4_DATE], [LINKTEST_1], [LINKTEST_2], [LINKTEST_3], [LINKTEST_4], [LINKTEST_5]) VALUES (@CNO, @DOCVERSION, @SETCOMPANY, @SETPEOPLE, @ITEM1_DATE, @ITEM2_DATE, @ITEM3_DATE, @ITEM4_DATE, @LINKTEST_1, @LINKTEST_2, @LINKTEST_3, @LINKTEST_4, @LINKTEST_5)" SelectCommand="SELECT * FROM [DOC_VRY_LP]" UpdateCommand="UPDATE [DOC_VRY_LP] SET [SETCOMPANY] = @SETCOMPANY, [SETPEOPLE] = @SETPEOPLE, [ITEM1_DATE] = @ITEM1_DATE, [ITEM2_DATE] = @ITEM2_DATE, [ITEM3_DATE] = @ITEM3_DATE, [ITEM4_DATE] = @ITEM4_DATE, [LINKTEST_1] = @LINKTEST_1, [LINKTEST_2] = @LINKTEST_2, [LINKTEST_3] = @LINKTEST_3, [LINKTEST_4] = @LINKTEST_4, [LINKTEST_5] = @LINKTEST_5 WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
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
            <asp:Parameter DbType="Date" Name="ITEM1_DATE" />
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
</asp:Content>
