<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="WebUrlLink.aspx.vb" Inherits="CWMS_DOC_2015.WebUrlLink" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="dx-justification">
        
        <tr>
            <td>            
                <dx:ASPxButton ID="ASPxButton1" runat="server" PostBackUrl="https://a0-cwms.epa.gov.tw/cwms_doc" Theme="Aqua" Width="400px" Font-Names="微軟正黑體" Font-Size="Large" Text="措施說明書及確認報告書登錄系統">
                </dx:ASPxButton>
            </td>
            <td><dx:ASPxButton ID="ASPxButton2" runat="server" PostBackUrl="https://a0-cwms.epa.gov.tw:8080/" Theme="Aqua" Width="400px" Font-Names="微軟正黑體" Font-Size="Large" Text="RWD_措施說明書及確認報告書查詢">
                </dx:ASPxButton>

            </td>
            <td>&nbsp;</td>
        </tr>
        
        <tr>
            <td>            
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        
        <tr>
            <td>            
                &nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <dx:ASPxButton ID="ASPxButton4" runat="server" PostBackUrl="https://a0-cwms.epa.gov.tw/" Theme="Aqua" Width="400px" Font-Names="微軟正黑體" Font-Size="Large" Text="重大點源放流水自動連續監測資訊公開查詢系統">
                </dx:ASPxButton>
            </td>
            <td><dx:ASPxButton ID="ASPxButton3" runat="server" PostBackUrl="https://a0-cwms.epa.gov.tw:8082/" Theme="Aqua" Width="400px" Font-Names="微軟正黑體" Font-Size="Large" Text="RWD_重大點源放流水自動連續監測資訊公開查詢系統">
                </dx:ASPxButton></td>
            <td></td>
        </tr>
        <tr>
            <td>            
                
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
