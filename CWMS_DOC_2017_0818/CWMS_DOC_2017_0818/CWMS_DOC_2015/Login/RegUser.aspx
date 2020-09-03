<%@ Page Title="" Language="VB" MasterPageFile="~/Login.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.Login_RegUser" Codebehind="RegUser.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

     <div>
        <div>
            <table cellpadding="0" cellspacing="0" style="width: 268px; height: 190px">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="帳號："></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="密碼："></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="155px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="電子郵件："></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtMail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                   <td>
                        <asp:Label ID="Label8" runat="server" Text="代理人："></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtProxyUser" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                   <td>
                        <asp:Label ID="Label9" runat="server" Text="代理人電子郵件："></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtProxyMail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="身分別："></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" >
                            <asp:ListItem Value="ADMIN">系統管理者</asp:ListItem>
                            <asp:ListItem  Value="EPB">環保局人員</asp:ListItem>
                            <asp:ListItem Selected="True" Value ="EPC">事業/工業區</asp:ListItem>
                            
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="縣市別："></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1" DataTextField="CITY_NAME" DataValueField="CITY_CODE" >                            
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" SelectCommand="SELECT [CITY_NAME], [CITY_CODE] FROM [SYSCITY]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 24px">
                        <asp:Button ID="btnCreateUser" runat="server" Text="建立使用者帳號" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 24px">
                        <asp:Label ID="Label4" runat="server" Text="提示問題：" Visible="False"></asp:Label></td>
                    <td style="height: 24px">
                        <asp:TextBox ID="txtQuestion" runat="server" Visible="False">123</asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="答案：" Visible="False"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtAnswer" runat="server" Visible="False">123</asp:TextBox></td>
                </tr>
                
            </table>
        </div>
    
    </div>
</asp:Content>

