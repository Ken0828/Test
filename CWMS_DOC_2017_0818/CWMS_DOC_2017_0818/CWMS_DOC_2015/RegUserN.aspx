<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="RegUserN.aspx.vb" Inherits="CWMS_DOC_2015.RegUserN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div>
        <div align="center" >
            <table cellpadding="0" cellspacing="0" style="width: 400px; height: 190px">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="帳號："></asp:Label></td>
                    <td align ="left" >
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="密碼："></asp:Label></td>
                    <td align ="left">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="155px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="姓名："></asp:Label></td>
                    <td align ="left">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="聯絡電話："></asp:Label></td>
                    <td align ="left">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="電子郵件："></asp:Label></td>
                    <td align ="left">
                        <asp:TextBox ID="txtMail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                   <td>
                        <asp:Label ID="Label13" runat="server" Text="所屬環保局："></asp:Label></td>
                    <td align ="left">
                        <asp:DropDownList ID="DDL_EPB" runat="server" DataSourceID="SqlDataSource1" DataTextField="CITY_NAME" DataValueField="CITY_CODE" >                            
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="管理者帳號："></asp:Label></td>
                    <td align ="left">
                        <asp:TextBox ID="txtAdminId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="身分別："></asp:Label></td>
                    <td align ="left">
                        <asp:DropDownList ID="DropDownList1" runat="server" >
                            <asp:ListItem Value="ADMIN">系統管理者</asp:ListItem>
                            <asp:ListItem  Value="EPB">環保局人員</asp:ListItem>
                            <asp:ListItem Selected="True" Value ="EPC">事業/工業區</asp:ListItem>                            
                            <asp:ListItem Value ="EPB_HELPER">協審單位</asp:ListItem>                            
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 24px" align ="left">
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
                        <asp:TextBox ID="txtAnswer" runat="server" Visible="False">123</asp:TextBox>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" SelectCommand="SELECT [CITY_NAME], [CITY_CODE] FROM [SYSCITY]"></asp:SqlDataSource>
                    </td>
                </tr>
                
            </table>
        </div>
    
    </div>
</asp:Content>
