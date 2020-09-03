<%@ Page Language="VB" MasterPageFile="LoginAdmin.master"  AutoEventWireup="false" Inherits="CWMS_DOC_2015.DeleteUser_O" Codebehind="DeleteUser_O.aspx.vb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

    <div>
    <div align="center">
        <asp:LoginName ID="LoginName1" runat="server" ForeColor="Blue" FormatString="登入者帳號：{0}" />
        <br />
        <asp:Label ID="lbAccount" runat="server" Text="為安全起見，請手動輸入使用者帳號:"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:Button ID="btnDelete" runat="server" Text="刪除使用者帳號" />
     
        <br />
        <br />
     
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="使用者名稱" 
                    SortExpression="UserName" />
                <asp:BoundField DataField="LastActivityDate" HeaderText="最近登入日" 
                    SortExpression="LastActivityDate" />
            </Columns>
        </asp:GridView>
     
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CWMS_aspnetdb %>" 
            SelectCommand="SELECT [UserName], [LastActivityDate] FROM [vw_aspnet_Users]">
        </asp:SqlDataSource>
     
     </div>
    
    </div>

</asp:Content>