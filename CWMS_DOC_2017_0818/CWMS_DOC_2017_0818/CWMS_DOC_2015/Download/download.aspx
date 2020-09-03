<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" Inherits="CWMS_DOC_2015.stratagem_stratagem" Codebehind="download.aspx.vb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 194px;
        }
        .style3
        {
        }
        .style4
        {
            width: 427px;
        }
        .style5
        {
            width: 14px;
        }
        .style6
        {
            width: 96px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3" colspan="4">
                <p class="MsoNormal">
                    &nbsp;</p>
                <p class="MsoNormal">
                    下載專區</p>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="txt">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                <asp:Image ID="Image3" runat="server" Height="100px" Width="96px" 
                    ImageUrl="~/Images/News-1.png" />
            </td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                工業區<span>請填入下列申請資料，以取得最新版連線傳輸模組 :<br />
                <br />
                <asp:FormView ID="FormView1" runat="server" DataKeyNames="CNO" 
                    DataSourceID="SqlDataSource1" Width="261px" DefaultMode="Insert" 
                    Height="139px">
                    <EditItemTemplate>
                     
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        管制編號 :
                        <asp:TextBox ID="CNOTextBox" runat="server" Text='<%# Bind("CNO") %>' />
                        <span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="CNOTextBox" ErrorMessage="必填"></asp:RequiredFieldValidator>
                        </span>
                        <br />
                        <br />
                        申請人:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="AppmanTextBox" runat="server" Text='<%# Bind("Appman") %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="AppmanTextBox" ErrorMessage="必填"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        EMAilL :&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="EMAilLTextBox" runat="server" Text='<%# Bind("EMAilL") %>' 
                            Height="17px" Width="210px" />
                        <span>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="EMAilLTextBox" ErrorMessage="必填"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="EMAilLTextBox" ErrorMessage="Email 格式錯誤" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        </span>
                        <br />
                        <br />
                        聯絡電話:&nbsp;
                        <asp:TextBox ID="TELTextBox" runat="server" Text='<%# Bind("TEL") %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="TELTextBox" ErrorMessage="必填"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" 
                            CommandName="Insert" Text="確認" />
                        &nbsp;<asp:Button ID="InsertCancelButton" runat="server" 
                            CausesValidation="False" CommandName="Cancel" Text="取消" />
                    </InsertItemTemplate>
                    <ItemTemplate>
                        
                    </ItemTemplate>
                </asp:FormView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                    DeleteCommand="DELETE FROM [WEPCNETAPP] WHERE [CNO] = @CNO" 
                    InsertCommand="INSERT INTO [WEPCNETAPP] ([CNO], [Appman], [EMAilL], [TEL]) VALUES (@CNO, @Appman, @EMAilL, @TEL)" 
                    SelectCommand="SELECT [CNO], [Appman], [EMAilL], [TEL] FROM [WEPCNETAPP]" 
                    UpdateCommand="UPDATE [WEPCNETAPP] SET [Appman] = @Appman, [EMAilL] = @EMAilL, [TEL] = @TEL WHERE [CNO] = @CNO">
                    <DeleteParameters>
                        <asp:Parameter Name="CNO" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="Appman" Type="String" />
                        <asp:Parameter Name="EMAilL" Type="String" />
                        <asp:Parameter Name="TEL" Type="String" />
                        <asp:Parameter Name="CNO" Type="String" />
                    </UpdateParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CNO" Type="String" />
                        <asp:Parameter Name="Appman" Type="String" />
                        <asp:Parameter Name="EMAilL" Type="String" />
                        <asp:Parameter Name="TEL" Type="String" />
                    </InsertParameters>
                </asp:SqlDataSource>
                </span></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

