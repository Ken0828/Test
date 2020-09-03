<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CopyTestData.aspx.vb" Inherits="CWMS_DOC_2015.CopyTestData" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxTextBox ID="tb_From" runat="server" Width="170px">
    </dx:ASPxTextBox>
    <dx:ASPxTextBox ID="TB_TO" runat="server" Width="170px">
    </dx:ASPxTextBox>
    <dx:ASPxButton ID="ASPxButton1" runat="server" Text="複製資料">
    </dx:ASPxButton>
</asp:Content>
