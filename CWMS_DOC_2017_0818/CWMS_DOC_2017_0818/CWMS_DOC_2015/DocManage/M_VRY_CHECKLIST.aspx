<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_VRY_CHECKLIST.aspx.vb" Inherits="CWMS_DOC_2015.M_VRY_CHECKLIST" %>
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
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_COVER" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_BASIC" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_DAHS" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LED" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_BASIC_C1" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_BASIC_C1_AT" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C1" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C1_AT" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C2" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C2_AT" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C3" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C3_AT" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C4" VisibleIndex="16">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C4_AT" VisibleIndex="17">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C5" VisibleIndex="18">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C5_AT" VisibleIndex="19">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C6" VisibleIndex="20">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C6_AT" VisibleIndex="21">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C7" VisibleIndex="22">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C7_AT" VisibleIndex="23">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C8" VisibleIndex="24">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C8_AT" VisibleIndex="25">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C9" VisibleIndex="26">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C9_AT" VisibleIndex="27">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C10" VisibleIndex="28">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C10_AT" VisibleIndex="29">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C11" VisibleIndex="30">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C11_AT" VisibleIndex="31">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C12" VisibleIndex="32">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C12_AT" VisibleIndex="33">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C13" VisibleIndex="34">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_AT_C13" VisibleIndex="35">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C14" VisibleIndex="36">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C14_AT" VisibleIndex="37">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C15" VisibleIndex="38">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C15_AT" VisibleIndex="39">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C16" VisibleIndex="40">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_SPEC_C16_AT" VisibleIndex="41">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_DAHS_C1" VisibleIndex="42">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_DAHS_C1_AT" VisibleIndex="43">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_DAHS_C2" VisibleIndex="44">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_DAHS_C2_AT" VisibleIndex="45">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C1" VisibleIndex="46">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C1_AT" VisibleIndex="47">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C2" VisibleIndex="48">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C2_AT" VisibleIndex="49">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C3" VisibleIndex="50">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C3_AT" VisibleIndex="51">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C4" VisibleIndex="52">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C4_AT" VisibleIndex="53">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C5" VisibleIndex="54">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LINK_C5_AT" VisibleIndex="55">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LED_C1" VisibleIndex="56">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LED_C1_AT" VisibleIndex="57">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LED_C2" VisibleIndex="58">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LED_C2_AT" VisibleIndex="59">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LED_C3" VisibleIndex="60">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_CHECK_LED_C3_AT" VisibleIndex="61">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="62">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="63">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="64">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="65">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_VRY_CHECKLIST] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" InsertCommand="INSERT INTO [DOC_VRY_CHECKLIST] ([CNO], [DOCVERSION], [CB_CHECK_COVER], [CB_CHECK_BASIC], [CB_CHECK_SPEC], [CB_CHECK_DAHS], [CB_CHECK_LINK], [CB_CHECK_LED], [CB_CHECK_BASIC_C1], [CB_CHECK_BASIC_C1_AT], [CB_CHECK_SPEC_C1], [CB_CHECK_SPEC_C1_AT], [CB_CHECK_SPEC_C2], [CB_CHECK_SPEC_C2_AT], [CB_CHECK_SPEC_C3], [CB_CHECK_SPEC_C3_AT], [CB_CHECK_SPEC_C4], [CB_CHECK_SPEC_C4_AT], [CB_CHECK_SPEC_C5], [CB_CHECK_SPEC_C5_AT], [CB_CHECK_SPEC_C6], [CB_CHECK_SPEC_C6_AT], [CB_CHECK_SPEC_C7], [CB_CHECK_SPEC_C7_AT], [CB_CHECK_SPEC_C8], [CB_CHECK_SPEC_C8_AT], [CB_CHECK_SPEC_C9], [CB_CHECK_SPEC_C9_AT], [CB_CHECK_SPEC_C10], [CB_CHECK_SPEC_C10_AT], [CB_CHECK_SPEC_C11], [CB_CHECK_SPEC_C11_AT], [CB_CHECK_SPEC_C12], [CB_CHECK_SPEC_C12_AT], [CB_CHECK_SPEC_C13], [CB_CHECK_SPEC_AT_C13], [CB_CHECK_SPEC_C14], [CB_CHECK_SPEC_C14_AT], [CB_CHECK_SPEC_C15], [CB_CHECK_SPEC_C15_AT], [CB_CHECK_SPEC_C16], [CB_CHECK_SPEC_C16_AT], [CB_CHECK_DAHS_C1], [CB_CHECK_DAHS_C1_AT], [CB_CHECK_DAHS_C2], [CB_CHECK_DAHS_C2_AT], [CB_CHECK_LINK_C1], [CB_CHECK_LINK_C1_AT], [CB_CHECK_LINK_C2], [CB_CHECK_LINK_C2_AT], [CB_CHECK_LINK_C3], [CB_CHECK_LINK_C3_AT], [CB_CHECK_LINK_C4], [CB_CHECK_LINK_C4_AT], [CB_CHECK_LINK_C5], [CB_CHECK_LINK_C5_AT], [CB_CHECK_LED_C1], [CB_CHECK_LED_C1_AT], [CB_CHECK_LED_C2], [CB_CHECK_LED_C2_AT], [CB_CHECK_LED_C3], [CB_CHECK_LED_C3_AT], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DOCVERSION, @CB_CHECK_COVER, @CB_CHECK_BASIC, @CB_CHECK_SPEC, @CB_CHECK_DAHS, @CB_CHECK_LINK, @CB_CHECK_LED, @CB_CHECK_BASIC_C1, @CB_CHECK_BASIC_C1_AT, @CB_CHECK_SPEC_C1, @CB_CHECK_SPEC_C1_AT, @CB_CHECK_SPEC_C2, @CB_CHECK_SPEC_C2_AT, @CB_CHECK_SPEC_C3, @CB_CHECK_SPEC_C3_AT, @CB_CHECK_SPEC_C4, @CB_CHECK_SPEC_C4_AT, @CB_CHECK_SPEC_C5, @CB_CHECK_SPEC_C5_AT, @CB_CHECK_SPEC_C6, @CB_CHECK_SPEC_C6_AT, @CB_CHECK_SPEC_C7, @CB_CHECK_SPEC_C7_AT, @CB_CHECK_SPEC_C8, @CB_CHECK_SPEC_C8_AT, @CB_CHECK_SPEC_C9, @CB_CHECK_SPEC_C9_AT, @CB_CHECK_SPEC_C10, @CB_CHECK_SPEC_C10_AT, @CB_CHECK_SPEC_C11, @CB_CHECK_SPEC_C11_AT, @CB_CHECK_SPEC_C12, @CB_CHECK_SPEC_C12_AT, @CB_CHECK_SPEC_C13, @CB_CHECK_SPEC_AT_C13, @CB_CHECK_SPEC_C14, @CB_CHECK_SPEC_C14_AT, @CB_CHECK_SPEC_C15, @CB_CHECK_SPEC_C15_AT, @CB_CHECK_SPEC_C16, @CB_CHECK_SPEC_C16_AT, @CB_CHECK_DAHS_C1, @CB_CHECK_DAHS_C1_AT, @CB_CHECK_DAHS_C2, @CB_CHECK_DAHS_C2_AT, @CB_CHECK_LINK_C1, @CB_CHECK_LINK_C1_AT, @CB_CHECK_LINK_C2, @CB_CHECK_LINK_C2_AT, @CB_CHECK_LINK_C3, @CB_CHECK_LINK_C3_AT, @CB_CHECK_LINK_C4, @CB_CHECK_LINK_C4_AT, @CB_CHECK_LINK_C5, @CB_CHECK_LINK_C5_AT, @CB_CHECK_LED_C1, @CB_CHECK_LED_C1_AT, @CB_CHECK_LED_C2, @CB_CHECK_LED_C2_AT, @CB_CHECK_LED_C3, @CB_CHECK_LED_C3_AT, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DOC_VRY_CHECKLIST]" UpdateCommand="UPDATE [DOC_VRY_CHECKLIST] SET [CB_CHECK_COVER] = @CB_CHECK_COVER, [CB_CHECK_BASIC] = @CB_CHECK_BASIC, [CB_CHECK_SPEC] = @CB_CHECK_SPEC, [CB_CHECK_DAHS] = @CB_CHECK_DAHS, [CB_CHECK_LINK] = @CB_CHECK_LINK, [CB_CHECK_LED] = @CB_CHECK_LED, [CB_CHECK_BASIC_C1] = @CB_CHECK_BASIC_C1, [CB_CHECK_BASIC_C1_AT] = @CB_CHECK_BASIC_C1_AT, [CB_CHECK_SPEC_C1] = @CB_CHECK_SPEC_C1, [CB_CHECK_SPEC_C1_AT] = @CB_CHECK_SPEC_C1_AT, [CB_CHECK_SPEC_C2] = @CB_CHECK_SPEC_C2, [CB_CHECK_SPEC_C2_AT] = @CB_CHECK_SPEC_C2_AT, [CB_CHECK_SPEC_C3] = @CB_CHECK_SPEC_C3, [CB_CHECK_SPEC_C3_AT] = @CB_CHECK_SPEC_C3_AT, [CB_CHECK_SPEC_C4] = @CB_CHECK_SPEC_C4, [CB_CHECK_SPEC_C4_AT] = @CB_CHECK_SPEC_C4_AT, [CB_CHECK_SPEC_C5] = @CB_CHECK_SPEC_C5, [CB_CHECK_SPEC_C5_AT] = @CB_CHECK_SPEC_C5_AT, [CB_CHECK_SPEC_C6] = @CB_CHECK_SPEC_C6, [CB_CHECK_SPEC_C6_AT] = @CB_CHECK_SPEC_C6_AT, [CB_CHECK_SPEC_C7] = @CB_CHECK_SPEC_C7, [CB_CHECK_SPEC_C7_AT] = @CB_CHECK_SPEC_C7_AT, [CB_CHECK_SPEC_C8] = @CB_CHECK_SPEC_C8, [CB_CHECK_SPEC_C8_AT] = @CB_CHECK_SPEC_C8_AT, [CB_CHECK_SPEC_C9] = @CB_CHECK_SPEC_C9, [CB_CHECK_SPEC_C9_AT] = @CB_CHECK_SPEC_C9_AT, [CB_CHECK_SPEC_C10] = @CB_CHECK_SPEC_C10, [CB_CHECK_SPEC_C10_AT] = @CB_CHECK_SPEC_C10_AT, [CB_CHECK_SPEC_C11] = @CB_CHECK_SPEC_C11, [CB_CHECK_SPEC_C11_AT] = @CB_CHECK_SPEC_C11_AT, [CB_CHECK_SPEC_C12] = @CB_CHECK_SPEC_C12, [CB_CHECK_SPEC_C12_AT] = @CB_CHECK_SPEC_C12_AT, [CB_CHECK_SPEC_C13] = @CB_CHECK_SPEC_C13, [CB_CHECK_SPEC_AT_C13] = @CB_CHECK_SPEC_AT_C13, [CB_CHECK_SPEC_C14] = @CB_CHECK_SPEC_C14, [CB_CHECK_SPEC_C14_AT] = @CB_CHECK_SPEC_C14_AT, [CB_CHECK_SPEC_C15] = @CB_CHECK_SPEC_C15, [CB_CHECK_SPEC_C15_AT] = @CB_CHECK_SPEC_C15_AT, [CB_CHECK_SPEC_C16] = @CB_CHECK_SPEC_C16, [CB_CHECK_SPEC_C16_AT] = @CB_CHECK_SPEC_C16_AT, [CB_CHECK_DAHS_C1] = @CB_CHECK_DAHS_C1, [CB_CHECK_DAHS_C1_AT] = @CB_CHECK_DAHS_C1_AT, [CB_CHECK_DAHS_C2] = @CB_CHECK_DAHS_C2, [CB_CHECK_DAHS_C2_AT] = @CB_CHECK_DAHS_C2_AT, [CB_CHECK_LINK_C1] = @CB_CHECK_LINK_C1, [CB_CHECK_LINK_C1_AT] = @CB_CHECK_LINK_C1_AT, [CB_CHECK_LINK_C2] = @CB_CHECK_LINK_C2, [CB_CHECK_LINK_C2_AT] = @CB_CHECK_LINK_C2_AT, [CB_CHECK_LINK_C3] = @CB_CHECK_LINK_C3, [CB_CHECK_LINK_C3_AT] = @CB_CHECK_LINK_C3_AT, [CB_CHECK_LINK_C4] = @CB_CHECK_LINK_C4, [CB_CHECK_LINK_C4_AT] = @CB_CHECK_LINK_C4_AT, [CB_CHECK_LINK_C5] = @CB_CHECK_LINK_C5, [CB_CHECK_LINK_C5_AT] = @CB_CHECK_LINK_C5_AT, [CB_CHECK_LED_C1] = @CB_CHECK_LED_C1, [CB_CHECK_LED_C1_AT] = @CB_CHECK_LED_C1_AT, [CB_CHECK_LED_C2] = @CB_CHECK_LED_C2, [CB_CHECK_LED_C2_AT] = @CB_CHECK_LED_C2_AT, [CB_CHECK_LED_C3] = @CB_CHECK_LED_C3, [CB_CHECK_LED_C3_AT] = @CB_CHECK_LED_C3_AT, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
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
            <asp:Parameter Name="CB_CHECK_SPEC_AT_C13" Type="String" />
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
            <asp:Parameter Name="CB_CHECK_SPEC_AT_C13" Type="String" />
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
</asp:Content>
