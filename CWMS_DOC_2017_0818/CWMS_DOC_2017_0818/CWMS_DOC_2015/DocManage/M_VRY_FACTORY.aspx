<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_VRY_FACTORY.aspx.vb" Inherits="CWMS_DOC_2015.M_VRY_FACTORY" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DOCVERSION">
        <Settings ShowFilterRow="True" />

<SettingsPopup>
<HeaderFilter MinHeight="140px"></HeaderFilter>
</SettingsPopup>

        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="TYPE" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TYPEB" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TYPEW" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TYPEDESP" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CNO"  VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCVERSION"  VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_31" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_56" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_56_1" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_56_2" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_56_3" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_56_4" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_56_5" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_56_6" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_56_7" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_57_1" VisibleIndex="16">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_58" VisibleIndex="17">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_105" VisibleIndex="18">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_1500_I" VisibleIndex="19">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_5000_BUSSINESS" VisibleIndex="20">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_1500_BUSSINESS" VisibleIndex="21">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_5000_LIFE" VisibleIndex="22">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_1500_LIFE" VisibleIndex="23">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_ELEC" VisibleIndex="24">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_WATERCOOLER" VisibleIndex="25">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_E_EQUIP" VisibleIndex="26">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_OTHER" VisibleIndex="27">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_19" VisibleIndex="28">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_19_4" VisibleIndex="29">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_19_4_56" VisibleIndex="30">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RULE_19_56" VisibleIndex="31">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CWMS_LINK" VisibleIndex="32">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CWMS_LINKRULE_56" VisibleIndex="33">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CWMS_LINKRULE_57_1" VisibleIndex="34">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CWMS_LINKRULE_105" VisibleIndex="35">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CWMS_LINKRULE_19_4" VisibleIndex="36">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LINKSET" VisibleIndex="37">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CWMS_LED" VisibleIndex="38">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CWMS_LEDRULE_56" VisibleIndex="39">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CWMS_LEDRULE_105" VisibleIndex="40">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LEDSET" VisibleIndex="41">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PERMIT_VOL" VisibleIndex="42">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="OPERATION_VOL" VisibleIndex="43">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="REGUNIT" VisibleIndex="44">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_NAME" VisibleIndex="45">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_CNAME" VisibleIndex="46">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_CTEL" VisibleIndex="47">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_CTEL_EXT" VisibleIndex="48">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_CMOBILE" VisibleIndex="49">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_CFAX" VisibleIndex="50">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FAC_CEMAIL" VisibleIndex="51">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="REG_DATE" VisibleIndex="52">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="RBL_REG_MODI" VisibleIndex="53">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RBL_REG_SET" VisibleIndex="54">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_5_MOD_C" VisibleIndex="55">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_5_MOD_D" VisibleIndex="56">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_5_MOD_OTHER" VisibleIndex="57">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="58">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="59">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="60">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="61">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        DeleteCommand="DELETE FROM [DOC_VRY_FACTORY] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" 
        InsertCommand="INSERT INTO [DOC_VRY_FACTORY] ([TYPE], [TYPEB], [TYPEW], [TYPEDESP], [CNO], [DOCVERSION], [RULE_31], [RULE_56], [RULE_56_1], [RULE_56_2], [RULE_56_3], [RULE_56_4], [RULE_56_5], [RULE_56_6], [RULE_56_7], [RULE_57_1], [RULE_58], [RULE_105], [RULE_1500_I], [RULE_5000_BUSSINESS], [RULE_1500_BUSSINESS], [RULE_5000_LIFE], [RULE_1500_LIFE], [RULE_ELEC], [RULE_WATERCOOLER], [RULE_E_EQUIP], [RULE_OTHER], [RULE_19], [RULE_19_4], [RULE_19_4_56], [RULE_19_56], [CWMS_LINK], [CWMS_LINKRULE_56], [CWMS_LINKRULE_57_1], [CWMS_LINKRULE_105], [CWMS_LINKRULE_19_4], [LINKSET], [CWMS_LED], [CWMS_LEDRULE_56], [CWMS_LEDRULE_105], [LEDSET], [PERMIT_VOL], [OPERATION_VOL], [REGUNIT], [FAC_NAME], [FAC_CNAME], [FAC_CTEL], [FAC_CTEL_EXT], [FAC_CMOBILE], [FAC_CFAX], [FAC_CEMAIL], [REG_DATE], [RBL_REG_MODI], [RBL_REG_SET], [CB_5_MOD_C], [CB_5_MOD_D], [CB_5_MOD_OTHER], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@TYPE, @TYPEB, @TYPEW, @TYPEDESP, @CNO, @DOCVERSION, @RULE_31, @RULE_56, @RULE_56_1, @RULE_56_2, @RULE_56_3, @RULE_56_4, @RULE_56_5, @RULE_56_6, @RULE_56_7, @RULE_57_1, @RULE_58, @RULE_105, @RULE_1500_I, @RULE_5000_BUSSINESS, @RULE_1500_BUSSINESS, @RULE_5000_LIFE, @RULE_1500_LIFE, @RULE_ELEC, @RULE_WATERCOOLER, @RULE_E_EQUIP, @RULE_OTHER, @RULE_19, @RULE_19_4, @RULE_19_4_56, @RULE_19_56, @CWMS_LINK, @CWMS_LINKRULE_56, @CWMS_LINKRULE_57_1, @CWMS_LINKRULE_105, @CWMS_LINKRULE_19_4, @LINKSET, @CWMS_LED, @CWMS_LEDRULE_56, @CWMS_LEDRULE_105, @LEDSET, @PERMIT_VOL, @OPERATION_VOL, @REGUNIT, @FAC_NAME, @FAC_CNAME, @FAC_CTEL, @FAC_CTEL_EXT, @FAC_CMOBILE, @FAC_CFAX, @FAC_CEMAIL, @REG_DATE, @RBL_REG_MODI, @RBL_REG_SET, @CB_5_MOD_C, @CB_5_MOD_D, @CB_5_MOD_OTHER, @C_ID, @C_DATE, @U_ID, @U_DATE)" 
        SelectCommand="SELECT * FROM [DOC_VRY_FACTORY]" 
        UpdateCommand="UPDATE [DOC_VRY_FACTORY] SET [TYPE] = @TYPE, [TYPEB] = @TYPEB, [TYPEW] = @TYPEW, [TYPEDESP] = @TYPEDESP, [RULE_31] = @RULE_31, [RULE_56] = @RULE_56, [RULE_56_1] = @RULE_56_1, [RULE_56_2] = @RULE_56_2, [RULE_56_3] = @RULE_56_3, [RULE_56_4] = @RULE_56_4, [RULE_56_5] = @RULE_56_5, [RULE_56_6] = @RULE_56_6, [RULE_56_7] = @RULE_56_7, [RULE_57_1] = @RULE_57_1, [RULE_58] = @RULE_58, [RULE_105] = @RULE_105, [RULE_1500_I] = @RULE_1500_I, [RULE_5000_BUSSINESS] = @RULE_5000_BUSSINESS, [RULE_1500_BUSSINESS] = @RULE_1500_BUSSINESS, [RULE_5000_LIFE] = @RULE_5000_LIFE, [RULE_1500_LIFE] = @RULE_1500_LIFE, [RULE_ELEC] = @RULE_ELEC, [RULE_WATERCOOLER] = @RULE_WATERCOOLER, [RULE_E_EQUIP] = @RULE_E_EQUIP, [RULE_OTHER] = @RULE_OTHER, [RULE_19] = @RULE_19, [RULE_19_4] = @RULE_19_4, [RULE_19_4_56] = @RULE_19_4_56, [RULE_19_56] = @RULE_19_56, [CWMS_LINK] = @CWMS_LINK, [CWMS_LINKRULE_56] = @CWMS_LINKRULE_56, [CWMS_LINKRULE_57_1] = @CWMS_LINKRULE_57_1, [CWMS_LINKRULE_105] = @CWMS_LINKRULE_105, [CWMS_LINKRULE_19_4] = @CWMS_LINKRULE_19_4, [LINKSET] = @LINKSET, [CWMS_LED] = @CWMS_LED, [CWMS_LEDRULE_56] = @CWMS_LEDRULE_56, [CWMS_LEDRULE_105] = @CWMS_LEDRULE_105, [LEDSET] = @LEDSET, [PERMIT_VOL] = @PERMIT_VOL, [OPERATION_VOL] = @OPERATION_VOL, [REGUNIT] = @REGUNIT, [FAC_NAME] = @FAC_NAME, [FAC_CNAME] = @FAC_CNAME, [FAC_CTEL] = @FAC_CTEL, [FAC_CTEL_EXT] = @FAC_CTEL_EXT, [FAC_CMOBILE] = @FAC_CMOBILE, [FAC_CFAX] = @FAC_CFAX, [FAC_CEMAIL] = @FAC_CEMAIL, [REG_DATE] = @REG_DATE, [RBL_REG_MODI] = @RBL_REG_MODI, [RBL_REG_SET] = @RBL_REG_SET, [CB_5_MOD_C] = @CB_5_MOD_C, [CB_5_MOD_D] = @CB_5_MOD_D, [CB_5_MOD_OTHER] = @CB_5_MOD_OTHER, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TYPE" Type="String" />
            <asp:Parameter Name="TYPEB" Type="String" />
            <asp:Parameter Name="TYPEW" Type="String" />
            <asp:Parameter Name="TYPEDESP" Type="String" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="RULE_31" Type="String" />
            <asp:Parameter Name="RULE_56" Type="String" />
            <asp:Parameter Name="RULE_56_1" Type="String" />
            <asp:Parameter Name="RULE_56_2" Type="String" />
            <asp:Parameter Name="RULE_56_3" Type="String" />
            <asp:Parameter Name="RULE_56_4" Type="String" />
            <asp:Parameter Name="RULE_56_5" Type="String" />
            <asp:Parameter Name="RULE_56_6" Type="String" />
            <asp:Parameter Name="RULE_56_7" Type="String" />
            <asp:Parameter Name="RULE_57_1" Type="String" />
            <asp:Parameter Name="RULE_58" Type="String" />
            <asp:Parameter Name="RULE_105" Type="String" />
            <asp:Parameter Name="RULE_1500_I" Type="String" />
            <asp:Parameter Name="RULE_5000_BUSSINESS" Type="String" />
            <asp:Parameter Name="RULE_1500_BUSSINESS" Type="String" />
            <asp:Parameter Name="RULE_5000_LIFE" Type="String" />
            <asp:Parameter Name="RULE_1500_LIFE" Type="String" />
            <asp:Parameter Name="RULE_ELEC" Type="String" />
            <asp:Parameter Name="RULE_WATERCOOLER" Type="String" />
            <asp:Parameter Name="RULE_E_EQUIP" Type="String" />
            <asp:Parameter Name="RULE_OTHER" Type="String" />
            <asp:Parameter Name="RULE_19" Type="String" />
            <asp:Parameter Name="RULE_19_4" Type="String" />
            <asp:Parameter Name="RULE_19_4_56" Type="String" />
            <asp:Parameter Name="RULE_19_56" Type="String" />
            <asp:Parameter Name="CWMS_LINK" Type="String" />
            <asp:Parameter Name="CWMS_LINKRULE_56" Type="String" />
            <asp:Parameter Name="CWMS_LINKRULE_57_1" Type="String" />
            <asp:Parameter Name="CWMS_LINKRULE_105" Type="String" />
            <asp:Parameter Name="CWMS_LINKRULE_19_4" Type="String" />
            <asp:Parameter Name="LINKSET" Type="String" />
            <asp:Parameter Name="CWMS_LED" Type="String" />
            <asp:Parameter Name="CWMS_LEDRULE_56" Type="String" />
            <asp:Parameter Name="CWMS_LEDRULE_105" Type="String" />
            <asp:Parameter Name="LEDSET" Type="String" />
            <asp:Parameter Name="PERMIT_VOL" Type="String" />
            <asp:Parameter Name="OPERATION_VOL" Type="String" />
            <asp:Parameter Name="REGUNIT" Type="String" />
            <asp:Parameter Name="FAC_NAME" Type="String" />
            <asp:Parameter Name="FAC_CNAME" Type="String" />
            <asp:Parameter Name="FAC_CTEL" Type="String" />
            <asp:Parameter Name="FAC_CTEL_EXT" Type="String" />
            <asp:Parameter Name="FAC_CMOBILE" Type="String" />
            <asp:Parameter Name="FAC_CFAX" Type="String" />
            <asp:Parameter Name="FAC_CEMAIL" Type="String" />
            <asp:Parameter Name="REG_DATE" DbType="Date" />
            <asp:Parameter Name="RBL_REG_MODI" Type="String" />
            <asp:Parameter Name="RBL_REG_SET" Type="String" />
            <asp:Parameter Name="CB_5_MOD_C" Type="String" />
            <asp:Parameter Name="CB_5_MOD_D" Type="String" />
            <asp:Parameter Name="CB_5_MOD_OTHER" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="TYPE" Type="String" />
            <asp:Parameter Name="TYPEB" Type="String" />
            <asp:Parameter Name="TYPEW" Type="String" />
            <asp:Parameter Name="TYPEDESP" Type="String" />
            <asp:Parameter Name="RULE_31" Type="String" />
            <asp:Parameter Name="RULE_56" Type="String" />
            <asp:Parameter Name="RULE_56_1" Type="String" />
            <asp:Parameter Name="RULE_56_2" Type="String" />
            <asp:Parameter Name="RULE_56_3" Type="String" />
            <asp:Parameter Name="RULE_56_4" Type="String" />
            <asp:Parameter Name="RULE_56_5" Type="String" />
            <asp:Parameter Name="RULE_56_6" Type="String" />
            <asp:Parameter Name="RULE_56_7" Type="String" />
            <asp:Parameter Name="RULE_57_1" Type="String" />
            <asp:Parameter Name="RULE_58" Type="String" />
            <asp:Parameter Name="RULE_105" Type="String" />
            <asp:Parameter Name="RULE_1500_I" Type="String" />
            <asp:Parameter Name="RULE_5000_BUSSINESS" Type="String" />
            <asp:Parameter Name="RULE_1500_BUSSINESS" Type="String" />
            <asp:Parameter Name="RULE_5000_LIFE" Type="String" />
            <asp:Parameter Name="RULE_1500_LIFE" Type="String" />
            <asp:Parameter Name="RULE_ELEC" Type="String" />
            <asp:Parameter Name="RULE_WATERCOOLER" Type="String" />
            <asp:Parameter Name="RULE_E_EQUIP" Type="String" />
            <asp:Parameter Name="RULE_OTHER" Type="String" />
            <asp:Parameter Name="RULE_19" Type="String" />
            <asp:Parameter Name="RULE_19_4" Type="String" />
            <asp:Parameter Name="RULE_19_4_56" Type="String" />
            <asp:Parameter Name="RULE_19_56" Type="String" />
            <asp:Parameter Name="CWMS_LINK" Type="String" />
            <asp:Parameter Name="CWMS_LINKRULE_56" Type="String" />
            <asp:Parameter Name="CWMS_LINKRULE_57_1" Type="String" />
            <asp:Parameter Name="CWMS_LINKRULE_105" Type="String" />
            <asp:Parameter Name="CWMS_LINKRULE_19_4" Type="String" />
            <asp:Parameter Name="LINKSET" Type="String" />
            <asp:Parameter Name="CWMS_LED" Type="String" />
            <asp:Parameter Name="CWMS_LEDRULE_56" Type="String" />
            <asp:Parameter Name="CWMS_LEDRULE_105" Type="String" />
            <asp:Parameter Name="LEDSET" Type="String" />
            <asp:Parameter Name="PERMIT_VOL" Type="String" />
            <asp:Parameter Name="OPERATION_VOL" Type="String" />
            <asp:Parameter Name="REGUNIT" Type="String" />
            <asp:Parameter Name="FAC_NAME" Type="String" />
            <asp:Parameter Name="FAC_CNAME" Type="String" />
            <asp:Parameter Name="FAC_CTEL" Type="String" />
            <asp:Parameter Name="FAC_CTEL_EXT" Type="String" />
            <asp:Parameter Name="FAC_CMOBILE" Type="String" />
            <asp:Parameter Name="FAC_CFAX" Type="String" />
            <asp:Parameter Name="FAC_CEMAIL" Type="String" />
            <asp:Parameter Name="REG_DATE" DbType="Date" />
            <asp:Parameter Name="RBL_REG_MODI" Type="String" />
            <asp:Parameter Name="RBL_REG_SET" Type="String" />
            <asp:Parameter Name="CB_5_MOD_C" Type="String" />
            <asp:Parameter Name="CB_5_MOD_D" Type="String" />
            <asp:Parameter Name="CB_5_MOD_OTHER" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
