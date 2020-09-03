<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="LoginAdmin.master" CodeBehind="RegUserN.aspx.vb" Inherits="CWMS_DOC_2015.RegUserN" %>

<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      <div>
        <div align="left" >
            <table cellpadding="0" cellspacing="0" style="width: 800px; height: 190px">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="帳號：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" >
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="密碼：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="155px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="姓名：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="聯絡電話：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left">  
                        <dx:ASPxTextBox ID="txtContactPhone" runat="server" Width="170px">
                            <ValidationSettings>
                                            <RegularExpression ValidationExpression="(02|03|037|04|049|05|06|07|08|082|0826|0836|089)-[0-9]{5,8}" />
                                        </ValidationSettings>
                        </dx:ASPxTextBox>02-xxxxxxxx     
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                        <asp:Label ID="Label3" runat="server" Text="電子郵件：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" style="height: 20px"> 
                                                
                        <dx:ASPxTextBox ID="txtMail" runat="server" Width="270px">
                            <ValidationSettings>
                                <RegularExpression ErrorText="Email 格式不符" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxTextBox>
                                                
                    </td>
                </tr>
                <tr>
                   <td style="height: 24px">
                        <asp:Label ID="Label13" runat="server" Text="所屬環保局：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" style="height: 24px">
                        <asp:DropDownList ID="DDL_EPB" runat="server" DataSourceID="SqlDataSource1" DataTextField="CITY_NAME" DataValueField="CITY_CODE" Font-Names="微軟正黑體" Font-Size="Medium" Enabled="False" >                            
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="身分別：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left">
                        <asp:DropDownList ID="DropDownList1" runat="server"  Font-Names="微軟正黑體" Font-Size="Medium">                                                       
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
                        <asp:Button ID="btnCreateUser" runat="server" Text="建立使用者帳號" Font-Names="微軟正黑體" Font-Size="Medium" />
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
