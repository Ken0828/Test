<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_VRY_LINK.aspx.vb" Inherits="CWMS_DOC_2015.M_VRY_LINK" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="cNo;DocVersion">
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="cNo" ReadOnly="True" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DP_NO" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DocVersion" ReadOnly="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DAHS_REDAN_FUNC" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CemsPCCpu" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CemsPCMem" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CemsPCHDD" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CemsPCOS" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CemsPCNetcard" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CemsPCAntiVirus" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CemsPCFirewall" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NetworkLineType" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NetworkIPType" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NetworkIP" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="VideoLineType" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="VideoIPType" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="VideoIP" VisibleIndex="16">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NetworkPortNumber" VisibleIndex="17">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NetworkPortNumberOther" VisibleIndex="18">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="VideoLoginID" VisibleIndex="19">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MaintainType" VisibleIndex="20">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MonitorCenter" VisibleIndex="21">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NOTE1" VisibleIndex="22">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="NOTE2" VisibleIndex="23">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_LINK_5A" VisibleIndex="24">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_LINK_5B" VisibleIndex="25">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CB_LINK_5C" VisibleIndex="26">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="27">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="28">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="29">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="30">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_VRY_LINK] WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion" InsertCommand="INSERT INTO [DOC_VRY_LINK] ([cNo], [DP_NO], [DocVersion], [DAHS_REDAN_FUNC], [CemsPCCpu], [CemsPCMem], [CemsPCHDD], [CemsPCOS], [CemsPCNetcard], [CemsPCAntiVirus], [CemsPCFirewall], [NetworkLineType], [NetworkIPType], [NetworkIP], [VideoLineType], [VideoIPType], [VideoIP], [NetworkPortNumber], [NetworkPortNumberOther], [VideoLoginID], [MaintainType], [MonitorCenter], [NOTE1], [NOTE2], [CB_LINK_5A], [CB_LINK_5B], [CB_LINK_5C], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@cNo, @DP_NO, @DocVersion, @DAHS_REDAN_FUNC, @CemsPCCpu, @CemsPCMem, @CemsPCHDD, @CemsPCOS, @CemsPCNetcard, @CemsPCAntiVirus, @CemsPCFirewall, @NetworkLineType, @NetworkIPType, @NetworkIP, @VideoLineType, @VideoIPType, @VideoIP, @NetworkPortNumber, @NetworkPortNumberOther, @VideoLoginID, @MaintainType, @MonitorCenter, @NOTE1, @NOTE2, @CB_LINK_5A, @CB_LINK_5B, @CB_LINK_5C, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DOC_VRY_LINK]" UpdateCommand="UPDATE [DOC_VRY_LINK] SET [DP_NO] = @DP_NO, [DAHS_REDAN_FUNC] = @DAHS_REDAN_FUNC, [CemsPCCpu] = @CemsPCCpu, [CemsPCMem] = @CemsPCMem, [CemsPCHDD] = @CemsPCHDD, [CemsPCOS] = @CemsPCOS, [CemsPCNetcard] = @CemsPCNetcard, [CemsPCAntiVirus] = @CemsPCAntiVirus, [CemsPCFirewall] = @CemsPCFirewall, [NetworkLineType] = @NetworkLineType, [NetworkIPType] = @NetworkIPType, [NetworkIP] = @NetworkIP, [VideoLineType] = @VideoLineType, [VideoIPType] = @VideoIPType, [VideoIP] = @VideoIP, [NetworkPortNumber] = @NetworkPortNumber, [NetworkPortNumberOther] = @NetworkPortNumberOther, [VideoLoginID] = @VideoLoginID, [MaintainType] = @MaintainType, [MonitorCenter] = @MonitorCenter, [NOTE1] = @NOTE1, [NOTE2] = @NOTE2, [CB_LINK_5A] = @CB_LINK_5A, [CB_LINK_5B] = @CB_LINK_5B, [CB_LINK_5C] = @CB_LINK_5C, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [cNo] = @cNo AND [DocVersion] = @DocVersion">
        <DeleteParameters>
            <asp:Parameter Name="cNo" Type="String" />
            <asp:Parameter Name="DocVersion" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="cNo" Type="String" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DocVersion" Type="Int32" />
            <asp:Parameter Name="DAHS_REDAN_FUNC" Type="String" />
            <asp:Parameter Name="CemsPCCpu" Type="String" />
            <asp:Parameter Name="CemsPCMem" Type="String" />
            <asp:Parameter Name="CemsPCHDD" Type="String" />
            <asp:Parameter Name="CemsPCOS" Type="String" />
            <asp:Parameter Name="CemsPCNetcard" Type="String" />
            <asp:Parameter Name="CemsPCAntiVirus" Type="String" />
            <asp:Parameter Name="CemsPCFirewall" Type="String" />
            <asp:Parameter Name="NetworkLineType" Type="String" />
            <asp:Parameter Name="NetworkIPType" Type="String" />
            <asp:Parameter Name="NetworkIP" Type="String" />
            <asp:Parameter Name="VideoLineType" Type="String" />
            <asp:Parameter Name="VideoIPType" Type="String" />
            <asp:Parameter Name="VideoIP" Type="String" />
            <asp:Parameter Name="NetworkPortNumber" Type="String" />
            <asp:Parameter Name="NetworkPortNumberOther" Type="String" />
            <asp:Parameter Name="VideoLoginID" Type="String" />
            <asp:Parameter Name="MaintainType" Type="String" />
            <asp:Parameter Name="MonitorCenter" Type="String" />
            <asp:Parameter Name="NOTE1" Type="String" />
            <asp:Parameter Name="NOTE2" Type="String" />
            <asp:Parameter Name="CB_LINK_5A" Type="String" />
            <asp:Parameter Name="CB_LINK_5B" Type="String" />
            <asp:Parameter Name="CB_LINK_5C" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DAHS_REDAN_FUNC" Type="String" />
            <asp:Parameter Name="CemsPCCpu" Type="String" />
            <asp:Parameter Name="CemsPCMem" Type="String" />
            <asp:Parameter Name="CemsPCHDD" Type="String" />
            <asp:Parameter Name="CemsPCOS" Type="String" />
            <asp:Parameter Name="CemsPCNetcard" Type="String" />
            <asp:Parameter Name="CemsPCAntiVirus" Type="String" />
            <asp:Parameter Name="CemsPCFirewall" Type="String" />
            <asp:Parameter Name="NetworkLineType" Type="String" />
            <asp:Parameter Name="NetworkIPType" Type="String" />
            <asp:Parameter Name="NetworkIP" Type="String" />
            <asp:Parameter Name="VideoLineType" Type="String" />
            <asp:Parameter Name="VideoIPType" Type="String" />
            <asp:Parameter Name="VideoIP" Type="String" />
            <asp:Parameter Name="NetworkPortNumber" Type="String" />
            <asp:Parameter Name="NetworkPortNumberOther" Type="String" />
            <asp:Parameter Name="VideoLoginID" Type="String" />
            <asp:Parameter Name="MaintainType" Type="String" />
            <asp:Parameter Name="MonitorCenter" Type="String" />
            <asp:Parameter Name="NOTE1" Type="String" />
            <asp:Parameter Name="NOTE2" Type="String" />
            <asp:Parameter Name="CB_LINK_5A" Type="String" />
            <asp:Parameter Name="CB_LINK_5B" Type="String" />
            <asp:Parameter Name="CB_LINK_5C" Type="String" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter Name="C_DATE" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_DATE" Type="DateTime" />
            <asp:Parameter Name="cNo" Type="String" />
            <asp:Parameter Name="DocVersion" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
