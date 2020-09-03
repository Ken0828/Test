<%@ Page Language="VB" MasterPageFile="LoginAdmin.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.DeleteUser" Codebehind="DeleteUser.aspx.vb" %>
<%@ Import Namespace="System.Web.Security" %>


 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <div><div>
        <asp:LoginName ID="LoginName1" runat="server" ForeColor="Blue" FormatString="登入者帳號為：{0}" />
        <br />
        <asp:Label ID="lbAccount" runat="server" Text="使用者帳號:"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:Button ID="btnDelete" runat="server" Text="刪除使用者帳號" /></div>
    
    </div>
    
</asp:Content>