<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="VryPrintingMenu.aspx.vb" Inherits="CWMS_DOC_2015.VryPrintingMenu" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxPanel ID="ASPxPanel1" runat="server" Width="400px">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxRadioButtonList ID="RBL_SEL" runat="server" EnableTheming="True" Font-Names="微軟正黑體" Font-Size="Large" SelectedIndex="0" Theme="Aqua" Width="390px">
                    <Items>
                        <dx:ListEditItem Selected="True" Text="只列印文件本體" Value="只列印文件本體" />
                        <dx:ListEditItem Text="列印文件本體及所有附件" Value="列印文件本體及所有附件" />
                    </Items>
                </dx:ASPxRadioButtonList>
                <dx:ASPxButton ID="ASPxButton1" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="開始列印" Width="120px">
                </dx:ASPxButton>
                <dx:ASPxButton ID="BT_RETURN" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="返回" Width="120px">
                </dx:ASPxButton>

            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxPanel>
</asp:Content>
