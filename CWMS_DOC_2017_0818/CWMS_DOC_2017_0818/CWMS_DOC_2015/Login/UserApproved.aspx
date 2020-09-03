<%@ Page Title="" Language="VB" MasterPageFile="LoginAdmin.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.UserApproved" Codebehind="UserApproved.aspx.vb" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
     <div>
        <div>
            <asp:DropDownList ID="dwnUserName" runat="server" AutoPostBack="True">
            </asp:DropDownList><asp:CheckBox ID="cbxIsApproved" runat="server" Text="啟用" /><asp:Button
                ID="btnSave" runat="server" Text="儲存狀態" /><br />
            <asp:Button ID="btnShowApproved" runat="server" Text="顯示使用者帳號是否已啟用" /><br />
            <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
                BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="使用者帳號" />
                    <asp:BoundField DataField="IsApproved" HeaderText="是否啟用" />
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
    
    </div>
 </asp:Content>