<%@ Control Language="VB" AutoEventWireup="false" Inherits="CWMS_DOC_2015.Controls_Header" Codebehind="Header.ascx.vb" %>

<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<table  width="1680px" border="0" cellpadding="0" cellspacing="0">
<tr><td>
<div class="bluecolor2" style="width:1680px">
 <div style="width:1680px; float:left; padding-top:5px;"></div>
 <div class="link1" style="width:700px; float:right; padding-top:5px;">
     &nbsp;<asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login/Login.aspx"    Text="登入" />
     &nbsp;<asp:Label ID="lblUserName" runat="server"  ></asp:Label>
     &nbsp;|&nbsp;
     <asp:HyperLink ID="hlSiteMap" runat="server" Text="使用手冊" 
         NavigateUrl="~/業者及污水下水道系統端.pdf" Target="_blank" />
      &nbsp;|&nbsp;
     <asp:HyperLink ID="idOrg1" runat="server" NavigateUrl="~/Default.aspx"  Text="首頁" />
     &nbsp;&nbsp;|&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" Text="首長信箱" 
         NavigateUrl="https://epamail.epa.gov.tw/front/mailboxhome" Target="_blank" />&nbsp;&nbsp;|&nbsp;
     <asp:HyperLink ID="HyperLink2" runat="server" Text="網站資料開放宣告" 
         NavigateUrl="https://www.epa.gov.tw/Page/A33D3A6556ABFCD2" Target="_blank" />&nbsp;&nbsp;|&nbsp;
     <asp:HyperLink ID="HyperLink3" runat="server" Text="隱私權及資訊安全宣告" 
         NavigateUrl="https://www.epa.gov.tw/Page/70E67DE2079DF931" Target="_blank" />&nbsp;&nbsp;|&nbsp;
     <asp:HyperLink ID="HyperLink4" runat="server" Text="手機版" 
         NavigateUrl="https://a0-cwms.epa.gov.tw:8080" Target="_blank" />
     </div>
  <div style="width:100%; float:none; margin-left:0px; text-align: left;">
    <asp:HyperLink ID="hlItz" runat="server" >
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/banner_1612x100.jpg" />
     </asp:HyperLink>
 </div>
  <div style="width:1680px; float:none" >
      <dx:ASPxMenu ID="ASPxMenu1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" HorizontalAlign="Center" Width="1680px"  Theme="DevEx" ItemAutoWidth="False">
                    <LoadingPanelStyle HorizontalAlign="Center">
                    </LoadingPanelStyle>
                    <SubMenuStyle HorizontalAlign="Center" />
                </dx:ASPxMenu>
  </div>
</div>
</td></tr>
<tr><td align="center">
     &nbsp;</td>
 </tr></table>