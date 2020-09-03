<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_MODIFY.aspx.vb" Inherits="CWMS_DOC_2015.M_MODIFY" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DOCVERSION;DOCTYPE;REGDATE">
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ABBR" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" ReadOnly="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="REGISTOR" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CONTACTPHONE" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EMAIL" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MODIFYCOUNT" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="REGDATE" ReadOnly="True" VisibleIndex="7">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="10">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="12">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DAHS_MODIFY] WHERE [CNO] = @CNO AND [DOCTYPE] = @DOCTYPE AND [REGDATE] = @REGDATE AND [DOCVERSION] = @DOCVERSION" InsertCommand="INSERT INTO [DAHS_MODIFY] ([CNO], [ABBR], [DOCTYPE], [REGISTOR], [CONTACTPHONE], [EMAIL], [MODIFYCOUNT], [REGDATE], [DOCVERSION], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @ABBR, @DOCTYPE, @REGISTOR, @CONTACTPHONE, @EMAIL, @MODIFYCOUNT, @REGDATE, @DOCVERSION, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DAHS_MODIFY]" UpdateCommand="UPDATE [DAHS_MODIFY] SET [ABBR] = @ABBR, [REGISTOR] = @REGISTOR, [CONTACTPHONE] = @CONTACTPHONE, [EMAIL] = @EMAIL, [MODIFYCOUNT] = @MODIFYCOUNT, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCTYPE] = @DOCTYPE AND [REGDATE] = @REGDATE AND [DOCVERSION] = @DOCVERSION">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter DbType="Date" Name="REGDATE" />
            <asp:Parameter Name="DOCVERSION" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="ABBR" Type="String" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter Name="REGISTOR" Type="String" />
            <asp:Parameter Name="CONTACTPHONE" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="MODIFYCOUNT" Type="Int32" />
            <asp:Parameter DbType="Date" Name="REGDATE" />
            <asp:Parameter Name="DOCVERSION" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="ABBR" Type="String" />
            <asp:Parameter Name="REGISTOR" Type="String" />
            <asp:Parameter Name="CONTACTPHONE" Type="String" />
            <asp:Parameter Name="EMAIL" Type="String" />
            <asp:Parameter Name="MODIFYCOUNT" Type="Int32" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter DbType="Date" Name="REGDATE" />
            <asp:Parameter Name="DOCVERSION" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
