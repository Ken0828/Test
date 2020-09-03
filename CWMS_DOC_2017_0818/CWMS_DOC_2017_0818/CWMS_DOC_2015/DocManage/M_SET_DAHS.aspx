<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="M_SET_DAHS.aspx.vb" Inherits="CWMS_DOC_2015.M_SET_DAHS" %>
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
            <dx:GridViewDataTextColumn FieldName="DP_NO" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="PLAN_INSDATE" VisibleIndex="3">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="AGENT" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="REDANDUNT" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CONTROLROOM" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="COLUD" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="MAINTAINMETHOD" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DOCATTACH" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FITFREQ" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="FITFORMAT" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="STAR168DATE" VisibleIndex="12">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="C_ID" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="C_DATE" VisibleIndex="14">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="U_ID" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="U_DATE" VisibleIndex="16">
            </dx:GridViewDataDateColumn>
        </Columns>
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" DeleteCommand="DELETE FROM [DOC_SET_DAHS] WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION" InsertCommand="INSERT INTO [DOC_SET_DAHS] ([CNO], [DOCVERSION], [DP_NO], [PLAN_INSDATE], [AGENT], [REDANDUNT], [CONTROLROOM], [COLUD], [MAINTAINMETHOD], [DOCATTACH], [FITFREQ], [FITFORMAT], [STAR168DATE], [C_ID], [C_DATE], [U_ID], [U_DATE]) VALUES (@CNO, @DOCVERSION, @DP_NO, @PLAN_INSDATE, @AGENT, @REDANDUNT, @CONTROLROOM, @COLUD, @MAINTAINMETHOD, @DOCATTACH, @FITFREQ, @FITFORMAT, @STAR168DATE, @C_ID, @C_DATE, @U_ID, @U_DATE)" SelectCommand="SELECT * FROM [DOC_SET_DAHS]" UpdateCommand="UPDATE [DOC_SET_DAHS] SET [DP_NO] = @DP_NO, [PLAN_INSDATE] = @PLAN_INSDATE, [AGENT] = @AGENT, [REDANDUNT] = @REDANDUNT, [CONTROLROOM] = @CONTROLROOM, [COLUD] = @COLUD, [MAINTAINMETHOD] = @MAINTAINMETHOD, [DOCATTACH] = @DOCATTACH, [FITFREQ] = @FITFREQ, [FITFORMAT] = @FITFORMAT, [STAR168DATE] = @STAR168DATE, [C_ID] = @C_ID, [C_DATE] = @C_DATE, [U_ID] = @U_ID, [U_DATE] = @U_DATE WHERE [CNO] = @CNO AND [DOCVERSION] = @DOCVERSION">
        <DeleteParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter DbType="Date" Name="PLAN_INSDATE" />
            <asp:Parameter Name="AGENT" Type="String" />
            <asp:Parameter Name="REDANDUNT" Type="String" />
            <asp:Parameter Name="CONTROLROOM" Type="String" />
            <asp:Parameter Name="COLUD" Type="String" />
            <asp:Parameter Name="MAINTAINMETHOD" Type="String" />
            <asp:Parameter Name="DOCATTACH" Type="String" />
            <asp:Parameter Name="FITFREQ" Type="String" />
            <asp:Parameter Name="FITFORMAT" Type="String" />
            <asp:Parameter DbType="Date" Name="STAR168DATE" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="C_DATE" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="U_DATE" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="DP_NO" Type="String" />
            <asp:Parameter DbType="Date" Name="PLAN_INSDATE" />
            <asp:Parameter Name="AGENT" Type="String" />
            <asp:Parameter Name="REDANDUNT" Type="String" />
            <asp:Parameter Name="CONTROLROOM" Type="String" />
            <asp:Parameter Name="COLUD" Type="String" />
            <asp:Parameter Name="MAINTAINMETHOD" Type="String" />
            <asp:Parameter Name="DOCATTACH" Type="String" />
            <asp:Parameter Name="FITFREQ" Type="String" />
            <asp:Parameter Name="FITFORMAT" Type="String" />
            <asp:Parameter DbType="Date" Name="STAR168DATE" />
            <asp:Parameter Name="C_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="C_DATE" />
            <asp:Parameter Name="U_ID" Type="String" />
            <asp:Parameter DbType="Date" Name="U_DATE" />
            <asp:Parameter Name="CNO" Type="String" />
            <asp:Parameter Name="DOCVERSION" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
