<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_SET_PDF.aspx.vb" Inherits="CWMS_DOC_2015.M_SET_PDF" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" KeyFieldName="CNO;DP_NO;DocIndex;DocVersion;DocNumber">
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CNO" ReadOnly="True" VisibleIndex="0">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DP_NO" ReadOnly="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DocIndex" ReadOnly="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DocVersion" ReadOnly="True" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DocNumber" ReadOnly="True" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Path" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FileName" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CreatorID" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="CreateDate" VisibleIndex="8">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="ModifyDate" VisibleIndex="9">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="ModifyID" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_SET_PDFUPload] WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DocIndex] = @DocIndex AND [DocVersion] = @DocVersion AND [DocNumber] = @DocNumber" InsertCommand="INSERT INTO [DOC_SET_PDFUPload] ([CNO], [DP_NO], [DocIndex], [DocVersion], [DocNumber], [Path], [FileName], [CreatorID], [CreateDate], [ModifyDate], [ModifyID]) VALUES (@CNO, @DP_NO, @DocIndex, @DocVersion, @DocNumber, @Path, @FileName, @CreatorID, @CreateDate, @ModifyDate, @ModifyID)" SelectCommand="SELECT [CNO], [DP_NO], [DocIndex], [DocVersion], [DocNumber], [Path], [FileName], [CreatorID], [CreateDate], [ModifyDate], [ModifyID] FROM [DOC_SET_PDFUPload]" UpdateCommand="UPDATE [DOC_SET_PDFUPload] SET [Path] = @Path, [FileName] = @FileName, [CreatorID] = @CreatorID, [CreateDate] = @CreateDate, [ModifyDate] = @ModifyDate, [ModifyID] = @ModifyID WHERE [CNO] = @CNO AND [DP_NO] = @DP_NO AND [DocIndex] = @DocIndex AND [DocVersion] = @DocVersion AND [DocNumber] = @DocNumber">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DocIndex" Type="String" />
            <asp:Parameter Name="DocVersion" Type="String" />
            <asp:Parameter Name="DocNumber" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DocIndex" Type="String" />
            <asp:Parameter Name="DocVersion" Type="String" />
            <asp:Parameter Name="DocNumber" Type="String" />
            <asp:Parameter Name="Path" Type="String" />
            <asp:Parameter Name="FileName" Type="String" />
            <asp:Parameter Name="CreatorID" Type="String" />
            <asp:Parameter Name="CreateDate" Type="DateTime" />
            <asp:Parameter Name="ModifyDate" Type="DateTime" />
            <asp:Parameter Name="ModifyID" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Path" Type="String" />
            <asp:Parameter Name="FileName" Type="String" />
            <asp:Parameter Name="CreatorID" Type="String" />
            <asp:Parameter Name="CreateDate" Type="DateTime" />
            <asp:Parameter Name="ModifyDate" Type="DateTime" />
            <asp:Parameter Name="ModifyID" Type="String" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter Name="DocIndex" Type="String" />
            <asp:Parameter Name="DocVersion" Type="String" />
            <asp:Parameter Name="DocNumber" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
