<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_SET_LED.aspx.vb" Inherits="CWMS_DOC_2015.M_SET_LED" %>
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
            <dx:GridViewDataTextColumn FieldName="DP_NO" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_INSTALL" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_INSTALL_REASON" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="LED_PLAN_DATE" VisibleIndex="5">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="LED_FACTORY" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_MODEL" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_SERIAL" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_TYPE" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_TYPE_OTHER" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_INSTALLPOS" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_INSTALLPOS_REASON" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_SHOWITEM" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_SHOWITEM_REASON" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_FORMAT" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_FORMAT_REASON" VisibleIndex="16">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_FREQ" VisibleIndex="17">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_FAIL_INSTEAD" VisibleIndex="18">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LED_CONTENT" VisibleIndex="19">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="20">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="21">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="22">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="23">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_SET_LED] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" InsertCommand="INSERT INTO [DOC_SET_LED] ([CNO], [DP_NO], [DOCVERSION], [LED_INSTALL], [LED_INSTALL_REASON], [LED_PLAN_DATE], [LED_FACTORY], [LED_MODEL], [LED_SERIAL], [LED_TYPE], [LED_TYPE_OTHER], [LED_INSTALLPOS], [LED_INSTALLPOS_REASON], [LED_SHOWITEM], [LED_SHOWITEM_REASON], [LED_FORMAT], [LED_FORMAT_REASON], [LED_FREQ], [LED_FAIL_INSTEAD], [LED_CONTENT], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DOCVERSION, @LED_INSTALL, @LED_INSTALL_REASON, @LED_PLAN_DATE, @LED_FACTORY, @LED_MODEL, @LED_SERIAL, @LED_TYPE, @LED_TYPE_OTHER, @LED_INSTALLPOS, @LED_INSTALLPOS_REASON, @LED_SHOWITEM, @LED_SHOWITEM_REASON, @LED_FORMAT, @LED_FORMAT_REASON, @LED_FREQ, @LED_FAIL_INSTEAD, @LED_CONTENT, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DOC_SET_LED]" UpdateCommand="UPDATE [DOC_SET_LED] SET [DP_NO] = @DP_NO, [LED_INSTALL] = @LED_INSTALL, [LED_INSTALL_REASON] = @LED_INSTALL_REASON, [LED_PLAN_DATE] = @LED_PLAN_DATE, [LED_FACTORY] = @LED_FACTORY, [LED_MODEL] = @LED_MODEL, [LED_SERIAL] = @LED_SERIAL, [LED_TYPE] = @LED_TYPE, [LED_TYPE_OTHER] = @LED_TYPE_OTHER, [LED_INSTALLPOS] = @LED_INSTALLPOS, [LED_INSTALLPOS_REASON] = @LED_INSTALLPOS_REASON, [LED_SHOWITEM] = @LED_SHOWITEM, [LED_SHOWITEM_REASON] = @LED_SHOWITEM_REASON, [LED_FORMAT] = @LED_FORMAT, [LED_FORMAT_REASON] = @LED_FORMAT_REASON, [LED_FREQ] = @LED_FREQ, [LED_FAIL_INSTEAD] = @LED_FAIL_INSTEAD, [LED_CONTENT] = @LED_CONTENT, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="LED_INSTALL" Type="String" />
            <asp:Parameter Name="LED_INSTALL_REASON" Type="String" />
            <asp:Parameter DbType="Date" Name="LED_PLAN_DATE" />
            <asp:Parameter Name="LED_FACTORY" Type="String" />
            <asp:Parameter Name="LED_MODEL" Type="String" />
            <asp:Parameter Name="LED_SERIAL" Type="String" />
            <asp:Parameter Name="LED_TYPE" Type="String" />
            <asp:Parameter Name="LED_TYPE_OTHER" Type="String" />
            <asp:Parameter Name="LED_INSTALLPOS" Type="String" />
            <asp:Parameter Name="LED_INSTALLPOS_REASON" Type="String" />
            <asp:Parameter Name="LED_SHOWITEM" Type="String" />
            <asp:Parameter Name="LED_SHOWITEM_REASON" Type="String" />
            <asp:Parameter Name="LED_FORMAT" Type="String" />
            <asp:Parameter Name="LED_FORMAT_REASON" Type="String" />
            <asp:Parameter Name="LED_FREQ" Type="String" />
            <asp:Parameter Name="LED_FAIL_INSTEAD" Type="String" />
            <asp:Parameter Name="LED_CONTENT" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="LED_INSTALL" Type="String" />
            <asp:Parameter Name="LED_INSTALL_REASON" Type="String" />
            <asp:Parameter DbType="Date" Name="LED_PLAN_DATE" />
            <asp:Parameter Name="LED_FACTORY" Type="String" />
            <asp:Parameter Name="LED_MODEL" Type="String" />
            <asp:Parameter Name="LED_SERIAL" Type="String" />
            <asp:Parameter Name="LED_TYPE" Type="String" />
            <asp:Parameter Name="LED_TYPE_OTHER" Type="String" />
            <asp:Parameter Name="LED_INSTALLPOS" Type="String" />
            <asp:Parameter Name="LED_INSTALLPOS_REASON" Type="String" />
            <asp:Parameter Name="LED_SHOWITEM" Type="String" />
            <asp:Parameter Name="LED_SHOWITEM_REASON" Type="String" />
            <asp:Parameter Name="LED_FORMAT" Type="String" />
            <asp:Parameter Name="LED_FORMAT_REASON" Type="String" />
            <asp:Parameter Name="LED_FREQ" Type="String" />
            <asp:Parameter Name="LED_FAIL_INSTEAD" Type="String" />
            <asp:Parameter Name="LED_CONTENT" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
