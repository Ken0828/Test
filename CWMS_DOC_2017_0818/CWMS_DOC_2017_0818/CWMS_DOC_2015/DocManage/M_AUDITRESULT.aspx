<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_AUDITRESULT.aspx.vb" Inherits="CWMS_DOC_2015.M_AUDITRESULT" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DocVersion;DOCTYPE">
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DocVersion" ReadOnly="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOC_SERIAL" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCTYPE" ReadOnly="True" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="AUDITSERIAL" VisibleIndex="4">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="AUDITRESULT" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="AUDITMEMO" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="AUDITDATE" VisibleIndex="7">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="Auditor" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CreatorID" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="CreateDate" VisibleIndex="10">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_Date" VisibleIndex="12">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DAHS_AuditResult] WHERE [CNO] = @CNO AND [DocVersion] = @DocVersion AND [DOCTYPE] = @DOCTYPE" InsertCommand="INSERT INTO [DAHS_AuditResult] ([CNO], [DocVersion], [DOC_SERIAL], [DOCTYPE], [AUDITSERIAL], [AUDITRESULT], [AUDITMEMO], [AUDITDATE], [Auditor], [CreatorID], [CreateDate], [U_ID], [U_Date]) VALUES (@CNO, @DocVersion, @DOC_SERIAL, @DOCTYPE, @AUDITSERIAL, @AUDITRESULT, @AUDITMEMO, @AUDITDATE, @Auditor, @CreatorID, @CreateDate, @U_ID, @U_Date)" SelectCommand="SELECT * FROM [DAHS_AuditResult]" UpdateCommand="UPDATE [DAHS_AuditResult] SET [DOC_SERIAL] = @DOC_SERIAL, [AUDITSERIAL] = @AUDITSERIAL, [AUDITRESULT] = @AUDITRESULT, [AUDITMEMO] = @AUDITMEMO, [AUDITDATE] = @AUDITDATE, [Auditor] = @Auditor, [CreatorID] = @CreatorID, [CreateDate] = @CreateDate, [U_ID] = @U_ID, [U_Date] = @U_Date WHERE [CNO] = @CNO AND [DocVersion] = @DocVersion AND [DOCTYPE] = @DOCTYPE">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DocVersion" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DocVersion" Type="Int32" />
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
            <asp:Parameter Name="AUDITSERIAL" Type="DateTime" />
            <asp:Parameter Name="AUDITRESULT" Type="String" />
            <asp:Parameter Name="AUDITMEMO" Type="String" />
            <asp:Parameter Name="AUDITDATE" Type="DateTime" />
            <asp:Parameter Name="Auditor" Type="String" />
            <asp:Parameter Name="CreatorID" Type="String" />
            <asp:Parameter Name="CreateDate" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_Date" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="DOC_SERIAL" Type="String" />
            <asp:Parameter Name="AUDITSERIAL" Type="DateTime" />
            <asp:Parameter Name="AUDITRESULT" Type="String" />
            <asp:Parameter Name="AUDITMEMO" Type="String" />
            <asp:Parameter Name="AUDITDATE" Type="DateTime" />
            <asp:Parameter Name="Auditor" Type="String" />
            <asp:Parameter Name="CreatorID" Type="String" />
            <asp:Parameter Name="CreateDate" Type="DateTime" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter Name="U_Date" Type="DateTime" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DocVersion" Type="Int32" />
            <asp:Parameter Name="DOCTYPE" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
