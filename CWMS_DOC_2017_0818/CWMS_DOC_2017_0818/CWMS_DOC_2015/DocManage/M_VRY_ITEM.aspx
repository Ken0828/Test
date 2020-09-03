<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_VRY_ITEM.aspx.vb" Inherits="CWMS_DOC_2015.M_VRY_ITEM" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION;DOCTYPE">
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DP_NO" ReadOnly="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DPTYPE" ReadOnly="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION" ReadOnly="True" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" ReadOnly="True" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PERMIT_SERIAL" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="EM_COVER" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_248" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_259" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_246" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_247" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_243" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_210" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_VIDEO" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_242" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_WATER" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_GROUND" VisibleIndex="16">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_RIVER" VisibleIndex="17">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_RECYCLE" VisibleIndex="18">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_299" VisibleIndex="19">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_261" VisibleIndex="20">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_262" VisibleIndex="21">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_263" VisibleIndex="22">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_264" VisibleIndex="23">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_265" VisibleIndex="24">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_266" VisibleIndex="25">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ITEM_OTHER" VisibleIndex="26">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="OTHER_DESP" VisibleIndex="27">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="28">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="29">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="30">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="31">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_VRY_ITEM] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE" InsertCommand="INSERT INTO [DOC_VRY_ITEM] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [DOCTYPE], [PERMIT_SERIAL], [EM_COVER], [ITEM_248], [ITEM_259], [ITEM_246], [ITEM_247], [ITEM_243], [ITEM_210], [ITEM_VIDEO], [ITEM_242], [ITEM_WATER], [ITEM_GROUND], [ITEM_RIVER], [ITEM_RECYCLE], [ITEM_299], [ITEM_261], [ITEM_262], [ITEM_263], [ITEM_264], [ITEM_265], [ITEM_266], [ITEM_OTHER], [OTHER_DESP], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @DOCTYPE, @PERMIT_SERIAL, @EM_COVER, @ITEM_248, @ITEM_259, @ITEM_246, @ITEM_247, @ITEM_243, @ITEM_210, @ITEM_VIDEO, @ITEM_242, @ITEM_WATER, @ITEM_GROUND, @ITEM_RIVER, @ITEM_RECYCLE, @ITEM_299, @ITEM_261, @ITEM_262, @ITEM_263, @ITEM_264, @ITEM_265, @ITEM_266, @ITEM_OTHER, @OTHER_DESP, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DOC_VRY_ITEM]" UpdateCommand="UPDATE [DOC_VRY_ITEM] SET [PERMIT_SERIAL] = @PERMIT_SERIAL, [EM_COVER] = @EM_COVER, [ITEM_248] = @ITEM_248, [ITEM_259] = @ITEM_259, [ITEM_246] = @ITEM_246, [ITEM_247] = @ITEM_247, [ITEM_243] = @ITEM_243, [ITEM_210] = @ITEM_210, [ITEM_VIDEO] = @ITEM_VIDEO, [ITEM_242] = @ITEM_242, [ITEM_WATER] = @ITEM_WATER, [ITEM_GROUND] = @ITEM_GROUND, [ITEM_RIVER] = @ITEM_RIVER, [ITEM_RECYCLE] = @ITEM_RECYCLE, [ITEM_299] = @ITEM_299, [ITEM_261] = @ITEM_261, [ITEM_262] = @ITEM_262, [ITEM_263] = @ITEM_263, [ITEM_264] = @ITEM_264, [ITEM_265] = @ITEM_265, [ITEM_266] = @ITEM_266, [ITEM_OTHER] = @ITEM_OTHER, [OTHER_DESP] = @OTHER_DESP, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [DOCTYPE] = @DOCTYPE">
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
            <asp:Parameter Name="ITEM_261" Type="String" />
            <asp:Parameter Name="ITEM_262" Type="String" />
            <asp:Parameter Name="ITEM_263" Type="String" />
            <asp:Parameter Name="ITEM_264" Type="String" />
            <asp:Parameter Name="ITEM_265" Type="String" />
            <asp:Parameter Name="ITEM_266" Type="String" />
            <asp:Parameter Name="ITEM_OTHER" Type="String" />
            <asp:Parameter Name="OTHER_DESP" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
        </InsertParameters>
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
            <asp:Parameter Name="ITEM_261" Type="String" />
            <asp:Parameter Name="ITEM_262" Type="String" />
            <asp:Parameter Name="ITEM_263" Type="String" />
            <asp:Parameter Name="ITEM_264" Type="String" />
            <asp:Parameter Name="ITEM_265" Type="String" />
            <asp:Parameter Name="ITEM_266" Type="String" />
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
</asp:Content>
