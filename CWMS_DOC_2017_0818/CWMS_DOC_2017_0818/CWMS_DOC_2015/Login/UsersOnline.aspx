<%@ Page Title="" Language="VB" MasterPageFile="LoginAdmin.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.UsersOnline" Codebehind="UsersOnline.aspx.vb" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <div>
        <h3>
            目前線上使用者統計</h3>
        目前線上使用者人數：
        <asp:Label ID="txtUsersOnline" runat="Server"></asp:Label><br />
        <asp:Panel ID="NavigationPanel" runat="server">
            <table border="0" cellpadding="3" cellspacing="3">
                <tr>
                    <td >
                        分頁碼：<asp:Label ID="txtCurrentPage" runat="server"></asp:Label>
                        of
                        <asp:Label ID="txtTotalPages" runat="server"></asp:Label></td>
                    <td >
                        &nbsp;<asp:ImageButton ID="PreviousButton" runat="server" ImageUrl="~/Images/Previous.gif" /></td>
                    <td style="width: 60px">
                        &nbsp;<asp:ImageButton ID="NextButton" runat="server" ImageUrl="~/Images/Next.gif" /></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:GridView ID="UserGrid" runat="server" BackColor="LightGoldenrodYellow"   Width="750px" style="table-layout: fixed; text-align: center"
            BorderColor="Tan" BorderWidth="1px" CellPadding="1" Font-Size="8pt" ForeColor="Black" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="使用者帳號" />
                <asp:BoundField DataField="Email" HeaderText="Email" Visible="False" />
                <asp:BoundField DataField="PasswordQuestion" HeaderText="密碼提示" />
                <asp:BoundField DataField="Comment" HeaderText="身分別" />
                <asp:BoundField DataField="IsApproved" HeaderText="是否啟用" />
                <asp:BoundField DataField="IsLockedOut" HeaderText="鎖定" />
                <asp:BoundField DataField="LastLockoutDate" HeaderText="鎖定日期" />
                <asp:BoundField DataField="CreationDate" HeaderText="建立日期" />
                <asp:BoundField DataField="LastLoginDate" HeaderText="最近一次登入" />
                <asp:BoundField DataField="LastActivityDate" HeaderText="最近一次啟用日期" />
                <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="最近一次密碼變更" />
                <asp:BoundField DataField="IsOnline" HeaderText="是否上線中" />
                <asp:BoundField DataField="ProviderName" HeaderText="提供者" Visible="False" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />            
            <HeaderStyle BackColor="Tan" Font-Bold="True" />            
            <AlternatingRowStyle BackColor="PaleGoldenrod" />            
        </asp:GridView>
        &nbsp;&nbsp;
    
    </div>
     </asp:Content>
