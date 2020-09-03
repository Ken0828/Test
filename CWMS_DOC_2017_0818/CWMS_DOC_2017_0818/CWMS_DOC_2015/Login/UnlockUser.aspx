<%@ Page Title="" Language="VB" MasterPageFile="LoginAdmin.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.UnlockUser" Codebehind="UnlockUser.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
        <div>
        </div>
        <asp:LoginName ID="LoginName1" runat="server" ForeColor="Blue" FormatString="您登入的帳號名稱：{0}" />
        <br />
        <asp:Label ID="Label1" runat="server" Height="22px" Text="解除鎖定之使用者帳號：" Width="154px"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:Button ID="btnUnlockUser" runat="server" Text="解除鎖定" /><br />
        <asp:Button ID="btnShowLockedStatus" runat="server" Text="顯示使用者帳號鎖定狀態" /><br />
        <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
            BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="使用者帳號" />
                <asp:BoundField DataField="LockedStaus" HeaderText="鎖定狀態" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
    
    </div>
   </asp:Content>