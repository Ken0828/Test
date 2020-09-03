<%@ Page Title="" Language="VB" MasterPageFile="~/Login.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.Login_Login" Codebehind="Login.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <asp:Login ID="Login1" runat="server" BorderColor="#99CCFF" BorderStyle="Solid" 
     Width="293px" Height="206px" PasswordLabelText="密碼 :" UserNameLabelText="帳號 :" 
    UserNameRequiredErrorMessage="必須提供使用者帳號。" ForeColor="Black" >
        <LayoutTemplate>
            <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                <tr>
                    <td>
                        <table cellpadding="0" style="height:206px;width:293px;">
                            <tr>
                                <td align="center" colspan="2">登入</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">帳號 :</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="必須提供使用者帳號。" ToolTip="必須提供使用者帳號。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密碼 :</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="必須提供密碼。" ToolTip="必須提供密碼。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="記憶密碼供下次使用。" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="height: 36px">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登入" ValidationGroup="Login1" Font-Size="Medium" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
</asp:Login>
</asp:Content>

