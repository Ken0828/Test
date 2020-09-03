<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QryDAHSMaker.aspx.vb" Inherits="CWMS_DOC_2015.QryDAHSMaker" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
        SelectCommand="SELECT [SPEC_AGENTNAME], [SPEC_EQU_MODEL] FROM [DOC_SET_SPEC]  ">
    </asp:SqlDataSource>
    <dx:ASPxPivotGrid ID="pivotGrid" runat="server" ClientIDMode="AutoID" DataSourceID="SqlDataSource1" Caption="自動監測(視)設施製造廠、型號占比查詢" Width="600px" Height="600px" >
        <Fields>
            <dx:PivotGridField ID="fieldSPECAGENTNAME" Area="RowArea" AreaIndex="0" FieldName="SPEC_AGENTNAME" Caption="製造商名稱">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldSPECEQUMODEL" Area="RowArea" AreaIndex="1" FieldName="SPEC_EQU_MODEL" Caption="型號">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldSPECEQUMODEL1" Area="DataArea" AreaIndex="0" FieldName="SPEC_EQU_MODEL" Caption="型號總數" SummaryType="Count">
            </dx:PivotGridField>            
            <dx:PivotGridField ID="fieldSPECEQUMODEL2" Area="DataArea" AreaIndex="1" FieldName="SPEC_EQU_MODEL" SummaryDisplayType="PercentOfGrandTotal" SummaryType="Count" Caption="百分比">
            </dx:PivotGridField>
        </Fields>
        <OptionsView VerticalScrollBarMode="Visible" />
        <OptionsPager RowsPerPage="300">
        </OptionsPager>
    </dx:ASPxPivotGrid>
</asp:Content>
