<%@ Page Title="" Language="VB" MasterPageFile="LoginAdmin.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.ChangePasswordAPI" Codebehind="ChangePasswordAPI.aspx.vb" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
        <div>
            <table>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lbUserName" runat="server" Text="登入者姓名：" Width="125px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:LoginName ID="LoginName1" runat="server" Width="128px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="lbOldPwd" runat="server" Text="舊密碼：" Width="119px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label3" runat="server" Text="新密碼："></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtNewPwd1" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Label ID="Label4" runat="server" Text="確認密碼：" Width="124px"></asp:Label></td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        <asp:Button ID="btnChangePwd" runat="server" Text="變更密碼" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="btnSignout" runat="server" Text="登出" Width="70px" /></td>
                </tr>
            </table>
        </div>
    
    
   </asp:Content>
