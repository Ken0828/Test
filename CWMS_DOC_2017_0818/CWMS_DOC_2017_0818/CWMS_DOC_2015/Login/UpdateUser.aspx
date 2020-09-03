<%@ Page Title="" Language="VB" MasterPageFile="LoginAdmin.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.UpdateUser" Codebehind="UpdateUser.aspx.vb" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="height: 21px">
        <div align="left" >
            <table cellpadding="0" cellspacing="0" style="width: 800px; height: 190px">
                <tr>
                    <td style="width: 98px; height: 20px">
                        <asp:Label ID="Label1" runat="server" Text="帳號：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" style="height: 20px" >
                        <asp:TextBox ID="txtUserAccount" runat="server"></asp:TextBox>
                        <asp:Button ID="btn_SearchAccount" runat="server" Text="查詢" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 98px; height: 20px">
                        <asp:Label ID="Label2" runat="server" Text="舊密碼：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" style="height: 20px">
                        <asp:TextBox ID="txtUserOldPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 98px; height: 20px">
                        <asp:Label ID="Label15" runat="server" Text="新密碼：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" style="height: 20px">
                        <asp:TextBox ID="txtUserNewPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px; width: 98px">
                        <asp:Label ID="Label14" runat="server" Text="姓名：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" style="height: 20px" >
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="dxcpCurrentColor" style="width: 98px; height: 35px">
                        <asp:Label ID="Label11" runat="server" Text="聯絡電話：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" class="dxcpCurrentColor">  
                        <dx:ASPxTextBox ID="txtContactPhone" runat="server" Width="170px">
                            <ValidationSettings>
                                            <RegularExpression ValidationExpression="(02|03|037|04|049|05|06|07|08|082|0826|0836|089)-[0-9]{5,8}" />
                                        </ValidationSettings>
                        </dx:ASPxTextBox>02-xxxxxxxx     
                    </td>
                </tr>
                <tr>
                    <td style="width: 98px; height: 17px">
                    Email：</td>
                    <td align ="left" style="height: 17px"> 
                                                
                        <asp:TextBox ID="txtUserMail" runat="server"></asp:TextBox>
                                                
                    </td>
                </tr>
                <tr>
                   <td style="width: 98px">
                        <asp:Label ID="Label13" runat="server" Text="所屬環保局：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left">
                        <asp:DropDownList ID="DDL_EPB" runat="server" DataSourceID="SqlDataSource2" DataTextField="CITY_NAME" DataValueField="CITY_CODE" Font-Names="微軟正黑體" Font-Size="Medium" Enabled="False" >                            
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" SelectCommand="SELECT [CITY_NAME], [CITY_CODE] FROM [SYSCITY]"></asp:SqlDataSource>
                        </td>
                </tr>
                <tr>
                    <td style="width: 98px; height: 28px;">
                        <asp:Label ID="Label6" runat="server" Text="身分別：" Font-Names="微軟正黑體" Font-Size="Medium"></asp:Label></td>
                    <td align ="left" style="height: 28px">
                        <asp:DropDownList ID="DropDownList2" runat="server"  Font-Names="微軟正黑體" Font-Size="Medium">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 98px; height: 15px;">
                        </td>
                    <td style="height: 15px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 98px; height: 17px">
                        <asp:Label ID="lbl_Comment" runat="server" Text="Comment：" Visible="False"></asp:Label>
                    </td>
                    <td align ="left" style="height: 17px"> 
                                                
                        <asp:TextBox ID="txtUserComment" runat="server" Visible="False"></asp:TextBox>
                                                
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 24px" align ="left">
                    <asp:Button ID="btnUpdate" runat="server" Text="更新使用者資料" Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 24px; width: 98px;">
                        </td>
                    <td style="height: 24px">
                        </td>
                </tr>
                <tr>
                    <td style="width: 98px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                
            </table>
        </div>
                </td>
            </tr>
        </table>
        <asp:Literal ID="txtResult" runat="server"></asp:Literal>&nbsp;
    
    </div>
   </asp:Content>