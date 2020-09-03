<%@ Page Title="" Language="VB" MasterPageFile="LoginAdmin.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.ChangeQAAPI" Codebehind="ChangeQAAPI.aspx.vb" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div><div>
        <table>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbUserName" runat="server" Text="登入者姓名：" Width="132px"></asp:Label></td>
                <td style="width: 100px">
                    <asp:LoginName ID="LoginName1" runat="server" Width="140px" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbPassword" runat="server" Text="密碼："></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbQuestion" runat="server" Text="問題："></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Label ID="lbAnswer" runat="server" Text="回答："></asp:Label></td>
                <td style="width: 100px">
                    <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <asp:Button ID="btnChangeQA" runat="server" Text="變更" /></td>
                <td style="width: 100px">
                    <asp:Button ID="btnSignout" runat="server" Text="登出" /></td>
            </tr>
        </table>
    </div>
    
    </div>
    </asp:Content>