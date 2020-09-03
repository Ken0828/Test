<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_SET_SPEC.aspx.vb" Inherits="CWMS_DOC_2015.M_SET_SPEC" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DP_NO;DPTYPE;DOCVERSION;ITEM">
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
            <dx:GridViewDataTextColumn FieldName="ITEM" ReadOnly="True" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DPNO_DESP" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_INSTEAD_YES" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_INSTEAD_NO" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MONITOROTHER_YES" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MONITOROTHER_NO" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MO_NOTE_DPNO" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MO_NOTE_DPNO1" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MO_NOTE_QUA" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="SPEC_INS_DATE" VisibleIndex="13">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_AGENTNAME" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_EQU_MODEL" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_EQU_SERIAL" VisibleIndex="16">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_SAMPLE_METHOD" VisibleIndex="17">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_SAMPLE_METHOD_DESP" VisibleIndex="18">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_SAMPLE_METHOD_FILTERYES" VisibleIndex="19">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_SAMPLE_METHOD_FILTERNO" VisibleIndex="20">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_CALC_EQU" VisibleIndex="21">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_CALC_FREQ" VisibleIndex="22">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_CALC_METHOD" VisibleIndex="23">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MAIN_FREQ" VisibleIndex="24">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MAIN_METHOD" VisibleIndex="25">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MATERIAL" VisibleIndex="26">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_WASTELIQUID" VisibleIndex="27">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MATERIAL_FREQ" VisibleIndex="28">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MEA_SCOPE" VisibleIndex="29">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MEA_SCOPEUNIT" VisibleIndex="30">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MEA_RESTIME" VisibleIndex="31">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MEA_RESTIMEUNIT" VisibleIndex="32">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MEA_FREQ" VisibleIndex="33">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_MEA_FREQUNIT" VisibleIndex="34">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_CALCAVG" VisibleIndex="35">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_DOCATTACH_INST" VisibleIndex="36">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_DOCATTACH_CALI" VisibleIndex="37">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_VIDEO_F" VisibleIndex="38">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_VIDEO_F_MEMO" VisibleIndex="39">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_VIDEO_R" VisibleIndex="40">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_VIDEO_R_MEMO" VisibleIndex="41">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_VIDEO_NV" VisibleIndex="42">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_VIDEO_NV_MEMO" VisibleIndex="43">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_ANASIG_YES" VisibleIndex="44">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_ANASIG" VisibleIndex="45">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_DIGSIG_YES" VisibleIndex="46">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_DIGSIG" VisibleIndex="47">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_DO_HARDWARE_CONNECT" VisibleIndex="48">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_DO_HARDWARE_CONNPARA" VisibleIndex="49">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_DO_HARDWARE_DOC" VisibleIndex="50">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_PLCAGENT" VisibleIndex="51">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_COSPEC" VisibleIndex="52">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_COSPEC_NOTE" VisibleIndex="53">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_H_CHANGE" VisibleIndex="54">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_H_CHANGE_NOTE" VisibleIndex="55">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SPEC_NOTE" VisibleIndex="56">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="57">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="58">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="59">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="60">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_SET_SPEC] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM" InsertCommand="INSERT INTO [DOC_SET_SPEC] ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD_YES], [SPEC_INSTEAD_NO], [SPEC_MONITOROTHER_YES], [SPEC_MONITOROTHER_NO], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_DESP], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_COSPEC_NOTE], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [SPEC_NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DP_NO, @DPTYPE, @DOCVERSION, @ITEM, @DPNO_DESP, @SPEC_INSTEAD_YES, @SPEC_INSTEAD_NO, @SPEC_MONITOROTHER_YES, @SPEC_MONITOROTHER_NO, @SPEC_MO_NOTE_DPNO, @SPEC_MO_NOTE_DPNO1, @SPEC_MO_NOTE_QUA, @SPEC_INS_DATE, @SPEC_AGENTNAME, @SPEC_EQU_MODEL, @SPEC_EQU_SERIAL, @SPEC_SAMPLE_METHOD, @SPEC_SAMPLE_METHOD_DESP, @SPEC_SAMPLE_METHOD_FILTERYES, @SPEC_SAMPLE_METHOD_FILTERNO, @SPEC_CALC_EQU, @SPEC_CALC_FREQ, @SPEC_CALC_METHOD, @SPEC_MAIN_FREQ, @SPEC_MAIN_METHOD, @SPEC_MATERIAL, @SPEC_WASTELIQUID, @SPEC_MATERIAL_FREQ, @SPEC_MEA_SCOPE, @SPEC_MEA_SCOPEUNIT, @SPEC_MEA_RESTIME, @SPEC_MEA_RESTIMEUNIT, @SPEC_MEA_FREQ, @SPEC_MEA_FREQUNIT, @SPEC_CALCAVG, @SPEC_DOCATTACH_INST, @SPEC_DOCATTACH_CALI, @SPEC_VIDEO_F, @SPEC_VIDEO_F_MEMO, @SPEC_VIDEO_R, @SPEC_VIDEO_R_MEMO, @SPEC_VIDEO_NV, @SPEC_VIDEO_NV_MEMO, @SPEC_ANASIG_YES, @SPEC_ANASIG, @SPEC_DIGSIG_YES, @SPEC_DIGSIG, @SPEC_DO_HARDWARE_CONNECT, @SPEC_DO_HARDWARE_CONNPARA, @SPEC_DO_HARDWARE_DOC, @SPEC_PLCAGENT, @SPEC_COSPEC, @SPEC_COSPEC_NOTE, @SPEC_H_CHANGE, @SPEC_H_CHANGE_NOTE, @SPEC_NOTE, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DOC_SET_SPEC]" UpdateCommand="UPDATE [DOC_SET_SPEC] SET [DPNO_DESP] = @DPNO_DESP, [SPEC_INSTEAD_YES] = @SPEC_INSTEAD_YES, [SPEC_INSTEAD_NO] = @SPEC_INSTEAD_NO, [SPEC_MONITOROTHER_YES] = @SPEC_MONITOROTHER_YES, [SPEC_MONITOROTHER_NO] = @SPEC_MONITOROTHER_NO, [SPEC_MO_NOTE_DPNO] = @SPEC_MO_NOTE_DPNO, [SPEC_MO_NOTE_DPNO1] = @SPEC_MO_NOTE_DPNO1, [SPEC_MO_NOTE_QUA] = @SPEC_MO_NOTE_QUA, [SPEC_INS_DATE] = @SPEC_INS_DATE, [SPEC_AGENTNAME] = @SPEC_AGENTNAME, [SPEC_EQU_MODEL] = @SPEC_EQU_MODEL, [SPEC_EQU_SERIAL] = @SPEC_EQU_SERIAL, [SPEC_SAMPLE_METHOD] = @SPEC_SAMPLE_METHOD, [SPEC_SAMPLE_METHOD_DESP] = @SPEC_SAMPLE_METHOD_DESP, [SPEC_SAMPLE_METHOD_FILTERYES] = @SPEC_SAMPLE_METHOD_FILTERYES, [SPEC_SAMPLE_METHOD_FILTERNO] = @SPEC_SAMPLE_METHOD_FILTERNO, [SPEC_CALC_EQU] = @SPEC_CALC_EQU, [SPEC_CALC_FREQ] = @SPEC_CALC_FREQ, [SPEC_CALC_METHOD] = @SPEC_CALC_METHOD, [SPEC_MAIN_FREQ] = @SPEC_MAIN_FREQ, [SPEC_MAIN_METHOD] = @SPEC_MAIN_METHOD, [SPEC_MATERIAL] = @SPEC_MATERIAL, [SPEC_WASTELIQUID] = @SPEC_WASTELIQUID, [SPEC_MATERIAL_FREQ] = @SPEC_MATERIAL_FREQ, [SPEC_MEA_SCOPE] = @SPEC_MEA_SCOPE, [SPEC_MEA_SCOPEUNIT] = @SPEC_MEA_SCOPEUNIT, [SPEC_MEA_RESTIME] = @SPEC_MEA_RESTIME, [SPEC_MEA_RESTIMEUNIT] = @SPEC_MEA_RESTIMEUNIT, [SPEC_MEA_FREQ] = @SPEC_MEA_FREQ, [SPEC_MEA_FREQUNIT] = @SPEC_MEA_FREQUNIT, [SPEC_CALCAVG] = @SPEC_CALCAVG, [SPEC_DOCATTACH_INST] = @SPEC_DOCATTACH_INST, [SPEC_DOCATTACH_CALI] = @SPEC_DOCATTACH_CALI, [SPEC_VIDEO_F] = @SPEC_VIDEO_F, [SPEC_VIDEO_F_MEMO] = @SPEC_VIDEO_F_MEMO, [SPEC_VIDEO_R] = @SPEC_VIDEO_R, [SPEC_VIDEO_R_MEMO] = @SPEC_VIDEO_R_MEMO, [SPEC_VIDEO_NV] = @SPEC_VIDEO_NV, [SPEC_VIDEO_NV_MEMO] = @SPEC_VIDEO_NV_MEMO, [SPEC_ANASIG_YES] = @SPEC_ANASIG_YES, [SPEC_ANASIG] = @SPEC_ANASIG, [SPEC_DIGSIG_YES] = @SPEC_DIGSIG_YES, [SPEC_DIGSIG] = @SPEC_DIGSIG, [SPEC_DO_HARDWARE_CONNECT] = @SPEC_DO_HARDWARE_CONNECT, [SPEC_DO_HARDWARE_CONNPARA] = @SPEC_DO_HARDWARE_CONNPARA, [SPEC_DO_HARDWARE_DOC] = @SPEC_DO_HARDWARE_DOC, [SPEC_PLCAGENT] = @SPEC_PLCAGENT, [SPEC_COSPEC] = @SPEC_COSPEC, [SPEC_COSPEC_NOTE] = @SPEC_COSPEC_NOTE, [SPEC_H_CHANGE] = @SPEC_H_CHANGE, [SPEC_H_CHANGE_NOTE] = @SPEC_H_CHANGE_NOTE, [SPEC_NOTE] = @SPEC_NOTE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DPTYPE] = @DPTYPE AND [DOCVERSION] = @DOCVERSION AND [ITEM] = @ITEM">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DPTYPE" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="ITEM" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DPTYPE" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="ITEM" Type="String" />
            <asp:Parameter Name="DPNO_DESP" Type="String" />
            <asp:Parameter Name="SPEC_INSTEAD_YES" Type="String" />
            <asp:Parameter Name="SPEC_INSTEAD_NO" Type="String" />
            <asp:Parameter Name="SPEC_MONITOROTHER_YES" Type="String" />
            <asp:Parameter Name="SPEC_MONITOROTHER_NO" Type="String" />
            <asp:Parameter Name="SPEC_MO_NOTE_DPNO" Type="String" />
            <asp:Parameter Name="SPEC_MO_NOTE_DPNO1" Type="String" />
            <asp:Parameter Name="SPEC_MO_NOTE_QUA" Type="String" />
            <asp:Parameter DbType="Date" Name="SPEC_INS_DATE" />
            <asp:Parameter Name="SPEC_AGENTNAME" Type="String" />
            <asp:Parameter Name="SPEC_EQU_MODEL" Type="String" />
            <asp:Parameter Name="SPEC_EQU_SERIAL" Type="String" />
            <asp:Parameter Name="SPEC_SAMPLE_METHOD" Type="String" />
            <asp:Parameter Name="SPEC_SAMPLE_METHOD_DESP" Type="String" />
            <asp:Parameter Name="SPEC_SAMPLE_METHOD_FILTERYES" Type="String" />
            <asp:Parameter Name="SPEC_SAMPLE_METHOD_FILTERNO" Type="String" />
            <asp:Parameter Name="SPEC_CALC_EQU" Type="String" />
            <asp:Parameter Name="SPEC_CALC_FREQ" Type="String" />
            <asp:Parameter Name="SPEC_CALC_METHOD" Type="String" />
            <asp:Parameter Name="SPEC_MAIN_FREQ" Type="String" />
            <asp:Parameter Name="SPEC_MAIN_METHOD" Type="String" />
            <asp:Parameter Name="SPEC_MATERIAL" Type="String" />
            <asp:Parameter Name="SPEC_WASTELIQUID" Type="String" />
            <asp:Parameter Name="SPEC_MATERIAL_FREQ" Type="String" />
            <asp:Parameter Name="SPEC_MEA_SCOPE" Type="String" />
            <asp:Parameter Name="SPEC_MEA_SCOPEUNIT" Type="String" />
            <asp:Parameter Name="SPEC_MEA_RESTIME" Type="String" />
            <asp:Parameter Name="SPEC_MEA_RESTIMEUNIT" Type="String" />
            <asp:Parameter Name="SPEC_MEA_FREQ" Type="String" />
            <asp:Parameter Name="SPEC_MEA_FREQUNIT" Type="String" />
            <asp:Parameter Name="SPEC_CALCAVG" Type="String" />
            <asp:Parameter Name="SPEC_DOCATTACH_INST" Type="String" />
            <asp:Parameter Name="SPEC_DOCATTACH_CALI" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_F" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_F_MEMO" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_R" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_R_MEMO" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_NV" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_NV_MEMO" Type="String" />
            <asp:Parameter Name="SPEC_ANASIG_YES" Type="String" />
            <asp:Parameter Name="SPEC_ANASIG" Type="String" />
            <asp:Parameter Name="SPEC_DIGSIG_YES" Type="String" />
            <asp:Parameter Name="SPEC_DIGSIG" Type="String" />
            <asp:Parameter Name="SPEC_DO_HARDWARE_CONNECT" Type="String" />
            <asp:Parameter Name="SPEC_DO_HARDWARE_CONNPARA" Type="String" />
            <asp:Parameter Name="SPEC_DO_HARDWARE_DOC" Type="String" />
            <asp:Parameter Name="SPEC_PLCAGENT" Type="String" />
            <asp:Parameter Name="SPEC_COSPEC" Type="String" />
            <asp:Parameter Name="SPEC_COSPEC_NOTE" Type="String" />
            <asp:Parameter Name="SPEC_H_CHANGE" Type="String" />
            <asp:Parameter Name="SPEC_H_CHANGE_NOTE" Type="String" />
            <asp:Parameter Name="SPEC_NOTE" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="DPNO_DESP" Type="String" />
            <asp:Parameter Name="SPEC_INSTEAD_YES" Type="String" />
            <asp:Parameter Name="SPEC_INSTEAD_NO" Type="String" />
            <asp:Parameter Name="SPEC_MONITOROTHER_YES" Type="String" />
            <asp:Parameter Name="SPEC_MONITOROTHER_NO" Type="String" />
            <asp:Parameter Name="SPEC_MO_NOTE_DPNO" Type="String" />
            <asp:Parameter Name="SPEC_MO_NOTE_DPNO1" Type="String" />
            <asp:Parameter Name="SPEC_MO_NOTE_QUA" Type="String" />
            <asp:Parameter DbType="Date" Name="SPEC_INS_DATE" />
            <asp:Parameter Name="SPEC_AGENTNAME" Type="String" />
            <asp:Parameter Name="SPEC_EQU_MODEL" Type="String" />
            <asp:Parameter Name="SPEC_EQU_SERIAL" Type="String" />
            <asp:Parameter Name="SPEC_SAMPLE_METHOD" Type="String" />
            <asp:Parameter Name="SPEC_SAMPLE_METHOD_DESP" Type="String" />
            <asp:Parameter Name="SPEC_SAMPLE_METHOD_FILTERYES" Type="String" />
            <asp:Parameter Name="SPEC_SAMPLE_METHOD_FILTERNO" Type="String" />
            <asp:Parameter Name="SPEC_CALC_EQU" Type="String" />
            <asp:Parameter Name="SPEC_CALC_FREQ" Type="String" />
            <asp:Parameter Name="SPEC_CALC_METHOD" Type="String" />
            <asp:Parameter Name="SPEC_MAIN_FREQ" Type="String" />
            <asp:Parameter Name="SPEC_MAIN_METHOD" Type="String" />
            <asp:Parameter Name="SPEC_MATERIAL" Type="String" />
            <asp:Parameter Name="SPEC_WASTELIQUID" Type="String" />
            <asp:Parameter Name="SPEC_MATERIAL_FREQ" Type="String" />
            <asp:Parameter Name="SPEC_MEA_SCOPE" Type="String" />
            <asp:Parameter Name="SPEC_MEA_SCOPEUNIT" Type="String" />
            <asp:Parameter Name="SPEC_MEA_RESTIME" Type="String" />
            <asp:Parameter Name="SPEC_MEA_RESTIMEUNIT" Type="String" />
            <asp:Parameter Name="SPEC_MEA_FREQ" Type="String" />
            <asp:Parameter Name="SPEC_MEA_FREQUNIT" Type="String" />
            <asp:Parameter Name="SPEC_CALCAVG" Type="String" />
            <asp:Parameter Name="SPEC_DOCATTACH_INST" Type="String" />
            <asp:Parameter Name="SPEC_DOCATTACH_CALI" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_F" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_F_MEMO" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_R" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_R_MEMO" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_NV" Type="String" />
            <asp:Parameter Name="SPEC_VIDEO_NV_MEMO" Type="String" />
            <asp:Parameter Name="SPEC_ANASIG_YES" Type="String" />
            <asp:Parameter Name="SPEC_ANASIG" Type="String" />
            <asp:Parameter Name="SPEC_DIGSIG_YES" Type="String" />
            <asp:Parameter Name="SPEC_DIGSIG" Type="String" />
            <asp:Parameter Name="SPEC_DO_HARDWARE_CONNECT" Type="String" />
            <asp:Parameter Name="SPEC_DO_HARDWARE_CONNPARA" Type="String" />
            <asp:Parameter Name="SPEC_DO_HARDWARE_DOC" Type="String" />
            <asp:Parameter Name="SPEC_PLCAGENT" Type="String" />
            <asp:Parameter Name="SPEC_COSPEC" Type="String" />
            <asp:Parameter Name="SPEC_COSPEC_NOTE" Type="String" />
            <asp:Parameter Name="SPEC_H_CHANGE" Type="String" />
            <asp:Parameter Name="SPEC_H_CHANGE_NOTE" Type="String" />
            <asp:Parameter Name="SPEC_NOTE" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DPTYPE" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="ITEM" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
