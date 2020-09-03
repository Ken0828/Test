<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PrepareModify.aspx.vb" Inherits="CWMS_DOC_2015.PrepareModify" %>
<%@ Register assembly="DevExpress.Web.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function previewScreen(suggest, result) {
            var value = suggest.value;
            var checkValue = document.getElementsByName("ctl00$ContentPlaceHolder1$RBL_AuditResult");


            var printPage = window.open("", "printPage", "");
            printPage.document.open();
            printPage.document.write("<OBJECT classid='CLSID:8856F961-340A-11D0-A96B-00C04FD705A2' height=0 id=wc name=wc width=0>友善列印</OBJECT>");
            printPage.document.write("<HTML><head></head><BODY  onload='javascript:window.print();window.close();'>");
            // printPage.document.write("<PRE>");
            printPage.document.write("<H1 style='text-align: center;'>審查結果<h1>");
            for (i = 0; i < checkValue.length; i++) {
                if (checkValue[i].checked == true) {
                    printPage.document.write("<p style='text-align: center; padding:8px; border-style: double;'>" + checkValue[i].value + "</p>");
                    break;
                }
            }

            printPage.document.write("<H1 style='text-align: center;'>審查意見<h1>");
            printPage.document.write("<p style='display: block; margin: 0 auto; width: 21cm; height: auto; min-height: 10cm; padding:8px; border-style: double;'>" + value + "</p>");
            //printPage.document.write("</PRE>");
            printPage.document.close("</BODY></HTML>");
        }


</script>
     <style type="text/css">
         .auto-style1 {
             height: 27px;
         }
         .auto-style2 {
             height: 23px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
            <table >
                                <tr>
                                    <td class="style16">
                                        &nbsp;</td>
                                    <td class="style17" width="420">
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>"
                                            SelectCommand="SELECT * FROM [DAHS_EXAMLIST] WHERE ([CNO] = @CNO)">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="CNO" SessionField="CNO" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                        <asp:SqlDataSource ID="SDS_Audit" runat="server" 
                                            ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                                            SelectCommand="SELECT * FROM [DAHS_AuditResult] ORDER BY AUDITDATE DESC" 
                                            DeleteCommand="DELETE FROM [DAHS_AuditResult] WHERE [CNO] = @CNO AND [DocVersion] = @DocVersion" 
                                            InsertCommand="INSERT INTO [DAHS_AuditResult] ([CNO], [DocVersion], [DocNumber], [DOCTYPE], [AUDITSERIAL], [AUDITRESULT], [AUDITMEMO], [AUDITDATE], [Auditor], [CreatorID], [CreateDate]) VALUES (@CNO, @DocVersion, @DocNumber, @DOCTYPE, @AUDITSERIAL, @AUDITRESULT, @AUDITMEMO, @AUDITDATE, @Auditor, @CreatorID, @CreateDate)" 
                                            UpdateCommand="UPDATE [DAHS_AuditResult] SET [DocNumber] = @DocNumber, [DOCTYPE] = @DOCTYPE, [AUDITSERIAL] = @AUDITSERIAL, [AUDITRESULT] = @AUDITRESULT, [AUDITMEMO] = @AUDITMEMO, [AUDITDATE] = @AUDITDATE, [Auditor] = @Auditor, [CreatorID] = @CreatorID, [CreateDate] = @CreateDate WHERE [CNO] = @CNO AND [DocVersion] = @DocVersion">
                                            <DeleteParameters>
                                                <asp:Parameter Name="CNO" Type="String" />
                                                <asp:Parameter Name="DocVersion" Type="String" />
                                            </DeleteParameters>
                                            <InsertParameters>
                                                <asp:Parameter Name="CNO" Type="String" />
                                                <asp:Parameter Name="DocVersion" Type="String" />
                                                <asp:Parameter Name="DocNumber" Type="String" />
                                                <asp:Parameter Name="DOCTYPE" Type="String" />
                                                <asp:Parameter Name="AUDITSERIAL" Type="DateTime" />
                                                <asp:Parameter Name="AUDITRESULT" Type="String" />
                                                <asp:Parameter Name="AUDITMEMO" Type="String" />
                                                <asp:Parameter Name="AUDITDATE" Type="DateTime" />
                                                <asp:Parameter Name="Auditor" Type="String" />
                                                <asp:Parameter Name="CreatorID" Type="String" />
                                                <asp:Parameter Name="CreateDate" Type="DateTime" />
                                            </InsertParameters>
                                            <UpdateParameters>
                                                <asp:Parameter Name="DocNumber" Type="String" />
                                                <asp:Parameter Name="DOCTYPE" Type="String" />
                                                <asp:Parameter Name="AUDITSERIAL" Type="DateTime" />
                                                <asp:Parameter Name="AUDITRESULT" Type="String" />
                                                <asp:Parameter Name="AUDITMEMO" Type="String" />
                                                <asp:Parameter Name="AUDITDATE" Type="DateTime" />
                                                <asp:Parameter Name="Auditor" Type="String" />
                                                <asp:Parameter Name="CreatorID" Type="String" />
                                                <asp:Parameter Name="CreateDate" Type="DateTime" />
                                                <asp:Parameter Name="CNO" Type="String" />
                                                <asp:Parameter Name="DocVersion" Type="String" />
                                            </UpdateParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="RBL_AuditResult" runat="server" Font-Names="微軟正黑體" 
                                            ForeColor="Black" RepeatDirection="Horizontal" Width ="450" AutoPostBack="True">
                                            <asp:ListItem>審查通過</asp:ListItem>
                                            <asp:ListItem>須補正</asp:ListItem>
                                            <asp:ListItem>駁回</asp:ListItem>
                                            <asp:ListItem>不適用</asp:ListItem>
                                        </asp:RadioButtonList>
                                        
                                        <dx:ASPxDateEdit ID="TB_Audit_DATE" runat="server" Caption="補正期限">
                                        </dx:ASPxDateEdit>
                                        
                                    </td>
                                    <td class="style17" width="500">
                                        <dx:ASPxMemo ID="TB_AuditMemo" runat="server" Caption="審查紀錄區" Font-Size="Medium" Height="100px" Width="800px">
                                            <CaptionSettings HorizontalAlign="Center" Position="Top" />
                                        </dx:ASPxMemo>
                                    </td>
                                    <td class="auto-style20">
                                        <dx:ASPxButton ID="BT_AuditSave" runat="server" Text="審查暫存" Width="100px" ></dx:ASPxButton>
                                        <dx:ASPxButton ID="BT_Audit1" runat="server" Text="完成審查" Width="100px"></dx:ASPxButton>                                        
                                        <asp:Label ID="Label_Audit" runat="server"></asp:Label>
                                        <a onkeypress="previewScreen(ContentPlaceHolder1_TB_AuditMemo_I, ContentPlaceHolder1_RBL_AuditResult)" onclick="previewScreen(ContentPlaceHolder1_TB_AuditMemo_I, ContentPlaceHolder1_RBL_AuditResult)" style="text-decoration:none" target="_blank"> 
   <img src="images/Print_32x32.png"  width="32" height="32" alt="友善列印" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style16" align="center" colspan="3">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td></td>
                                    
                                </tr>
                            </table>
                                        </asp:Panel>
        
    </div>
    <table class="dxic-fileManager" bgcolor="#CCFFFF">
        <tr>
            <td align="center">
                <dx:ASPxLabel ID="ASPxLabel7" runat="server" Font-Names="微軟正黑體" Font-Size="Large" Text="您即將變更措施說明書/確認報告書:" Width="400px">
                </dx:ASPxLabel>
            </td>
        </tr>
        </table>
    <table class="dxic-fileManager" bgcolor="#CCFFFF">
        <tr>
            <td width="110">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="管制編號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_CNO" runat="server" Width="100px" BackColor="#CCCCCC" Enabled="False">
                </dx:ASPxTextBox>
            </td>
            <td width="110">
                <dx:ASPxLabel ID="ASPxLabel5" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="事業名稱:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_FACABBR" runat="server" Width="250px" BackColor="#CCCCCC" Enabled="False">
                </dx:ASPxTextBox>
            </td>
            
            <td>
                <dx:ASPxLabel ID="ASPxLabel6" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="申請變更版號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_DOCVERSION" runat="server" Width="170px" Enabled="False" BackColor="#CCCCCC">
                </dx:ASPxTextBox>
            </td>
        </tr>        
        <tr>
            <td>
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="填寫人:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_REGISTOR" runat="server" Width="100px"></dx:ASPxTextBox>                
            </td>       
            <td>
                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="聯絡電話:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_CONTACTPHONE" runat="server" Width="170px">
                    <ValidationSettings>
                        <RegularExpression ValidationExpression="(02|03|037|04|049|05|06|07|08|082|0826|0836|089)-[0-9]{5,8}" />
                    </ValidationSettings>
                </dx:ASPxTextBox>xxx-xxxxxxxx
            </td>       
            <td>
                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="電子郵件:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_EMAIL" runat="server" Width="170px">
                    <ValidationSettings>
                                <RegularExpression ErrorText="Email 格式不符" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <RequiredField IsRequired="True" />
                            </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <dx:ASPxLabel ID="ASPxLabel8" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="申請日期:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td class="auto-style2">
                <dx:ASPxDateEdit ID="TB_REGDATE" runat="server"></dx:ASPxDateEdit>
            </td>
            <td>
                <dx:ASPxLabel ID="ASPxLabel10" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="變更序號:" Width="100px">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="TB_DOC_SERIAL" runat="server" Width="100px" BackColor="#CCCCCC" Enabled="False">
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <p>
    </p>
     <fieldset>
        <legend >上傳變更申請表PDF檔</legend>

         <asp:MultiView ID="MultiView1" runat="server">
             <asp:View ID="View_EPB" runat="server">
                 <table align="center" bgcolor="White" border="1" class="link3" style="border: 1px solid #2781BA" width="1000">
                 <tr>
                                <td width="220">
                                    &nbsp;</td>

                            
                                <td colspan="2">
                                    <dx:ASPxButton runat="server" Text="下載措施說明書變更申請表空白表單" Width="300px" ID="BT_EPB_PDF_DL" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <Image IconID="reports_insertheader_16x16office2013">
                                        </Image>
                                    </dx:ASPxButton>
                                    <asp:Button ID="BT_EPBDL_SETDOCEx1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="第一階段範例下載" />
                                    <asp:Button ID="BT_EPBDL_SETDOCEx2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="第二階段範例下載" />
                                    <br />
                                </td>

                            
            </tr>
                 <tr>
                                <td>
                                    &nbsp;</td>

                            
                                <td colspan="2">
                                    <dx:ASPxButton runat="server" Text="下載確認報告書變更申請表空白表單" Width="300px" ID="BT_EPB_PDF_DLVRY" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <Image IconID="reports_insertheader_16x16office2013">
                                        </Image>
                                    </dx:ASPxButton>
                                    <asp:Button ID="BT_EPBDL_VRYDOCEx1" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="第一階段範例下載" />
                                    <asp:Button ID="BT_EPBDL_VRYDOCEx2" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="第二階段範例下載" />
                                </td>

                            
            </tr>
                 <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="業者送審的變更申請表(PDF)" Font-Names="微軟正黑體" Font-Size="Medium" ></dx:ASPxLabel>
                                                                      
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="查看上傳檔案" Font-Names="微軟正黑體" Font-Size="Medium" />
                                    <asp:Button ID="BT_EPB_DLPDFExample" runat="server" Text="下載範例" Font-Names="微軟正黑體" Font-Size="Medium" />
                                                                      
                                </td><td>&nbsp;</td>                            
            </tr>
                 <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel11" runat="server" Text="業者上傳的變更申請確認書(JPG)" Font-Names="微軟正黑體" Font-Size="Medium" ></dx:ASPxLabel>
                                                                      
                                </td>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Text="查看上傳檔案" Font-Names="微軟正黑體" Font-Size="Medium" />
                                    <asp:Button ID="BT_EPB_DLJPGExample" runat="server" Text="下載範例" Font-Names="微軟正黑體" Font-Size="Medium" />
                                                                      
                                </td><td>&nbsp;</td>
                                        </tr>
        </table>
             </asp:View>
             <asp:View ID="View_EPC" runat="server">
                 <table align="center" bgcolor="White" border="1" class="link3" style="border: 1px solid #2781BA" width="1000">
                 <tr>
                                <td>
                                    &nbsp;</td>

                            
                                <td colspan="2">
                                    <dx:ASPxButton runat="server" Text="下載措施說明書變更申請表空白表單" Width="300px" ID="BT_PDF_DL" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <Image IconID="reports_insertheader_16x16office2013">
                                        </Image>
                                    </dx:ASPxButton>
                                     <asp:Button ID="BT_DL_SETDOCEx1" runat="server" Text="第一階段範例下載" Font-Names="微軟正黑體" Font-Size="Medium" />
                                    <asp:Button ID="BT_DL_SETDOCEx2" runat="server" Text="第二階段範例下載" Font-Names="微軟正黑體" Font-Size="Medium" />
                                </td>

                            
            </tr>
                 <tr>
                                <td>
                                    &nbsp;</td>

                            
                                <td colspan="2">
                                    <dx:ASPxButton runat="server" Text="下載確認報告書變更申請表空白表單" Width="300px" ID="BT_PDF_DLVRY" Font-Names="微軟正黑體" Font-Size="Medium">
                                        <Image IconID="reports_insertheader_16x16office2013">
                                        </Image>
                                    </dx:ASPxButton>
                                    <asp:Button ID="BT_DL_VRYDOCEx1" runat="server" Text="第一階段範例下載" Font-Names="微軟正黑體" Font-Size="Medium" />
                                    <asp:Button ID="BT_DL_VRYDOCEx2" runat="server" Text="第二階段範例下載" Font-Names="微軟正黑體" Font-Size="Medium" />
                                </td>

                            
            </tr>
                 <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel67" runat="server" Text="上傳變更申請表(PDF)" Font-Names="微軟正黑體" Font-Size="Medium" ></dx:ASPxLabel>
                                                                      
                                </td>
                                <td><dx:ASPxUploadControl ID="AUC_Modify" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px" Font-Names="微軟正黑體" Font-Size="Medium" >
                                    <ValidationSettings AllowedFileExtensions=".PDF"  NotAllowedFileExtensionErrorText="只接受PDF型式的檔案" MaxFileSize="99000000"></ValidationSettings>
                                    <BrowseButton Text="選擇">
                                    </BrowseButton>
                                    <RemoveButton Text="移除">
                                    </RemoveButton>
                                    <UploadButton Text="上傳">
                                        <Image IconID="arrows_moveup_32x32">
                                        </Image>
                                    </UploadButton>
                                    <CancelButton Text="取消">
                                    </CancelButton>
                                    </dx:ASPxUploadControl>
                                    <dx:ASPxLabel ID="ASPxLabel66" runat="server" Text="檔案上傳僅限PDF格式且大小不超過10M" ></dx:ASPxLabel>
                                    <br />
                                    <br />
                                </td><td><asp:Button ID="BT_QryPdf" runat="server" Text="查看上傳檔案" Font-Names="微軟正黑體" Font-Size="Medium" />                        
                                               <asp:Button ID="BT_DEL_PDF" runat="server" Text="刪除上傳檔案" Font-Names="微軟正黑體" Font-Size="Medium" />
                                    <asp:Button ID="BT_DownloadPDFExample" runat="server" Text="下載範例" Font-Names="微軟正黑體" Font-Size="Medium" />
                                     </td>                            
            </tr>
                 <tr>
                                <td>
                                    <dx:ASPxLabel ID="ASPxLabel68" runat="server" Text="上傳變更申請確認書(JPG)" Font-Names="微軟正黑體" Font-Size="Medium" ></dx:ASPxLabel>
                                                                      
                                </td>
                                <td><dx:ASPxUploadControl ID="AUC_Modify_Confirm" runat="server" AddUploadButtonsHorizontalPosition="Right" ButtonSpacing="10px" ShowProgressPanel="True" ShowUploadButton="True" UploadMode="Auto" Width="200px" >
                                    <ValidationSettings AllowedFileExtensions=".JPG"  NotAllowedFileExtensionErrorText="只接受JPG型式的檔案" MaxFileSize="99000000"></ValidationSettings>
                                    <BrowseButton Text="選擇">
                                    </BrowseButton>
                                    <UploadButton Text="上傳">
                                        <Image IconID="arrows_moveup_32x32">
                                        </Image>
                                    </UploadButton>
                                    <UploadButton Text="上傳">
                                    </UploadButton>
                                    <CancelButton Text="取消">
                                    </CancelButton>
                                    </dx:ASPxUploadControl>
                                                                      
                                </td><td><asp:Button ID="BT_QryJPG" runat="server" Text="查看上傳檔案" Font-Names="微軟正黑體" Font-Size="Medium" />                        
                                               <asp:Button ID="BT_DEL_JPG" runat="server" Text="刪除上傳檔案" Font-Names="微軟正黑體" Font-Size="Medium" />
                                    <asp:Button ID="BT_DownloadJPGExample" runat="server" Text="下載範例" Font-Names="微軟正黑體" Font-Size="Medium" />
                                     </td>
                                        </tr>
        </table>
             </asp:View>
         </asp:MultiView>

        
          </fieldset> 
    <table class="dxic-fileManager">        
        <tr>
            <td  width="110" class="auto-style1">
                <dx:ASPxButton ID="bt_summit" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="開始送出案件" Width="120px">
                </dx:ASPxButton>
            </td>
            <td width="120" class="auto-style1">
                <dx:ASPxButton ID="bt_return" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="返回" Width="120px">
                </dx:ASPxButton>
                                    <dx:ASPxLabel ID="Label_File" runat="server" ForeColor="Black">
                                    </dx:ASPxLabel>
            </td>
            <td width="120" class="auto-style1">
                <dx:ASPxButton ID="BT_SetDoc" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="前往變更措施說明書" Width="120px" Visible="False">
                </dx:ASPxButton>
            </td>
            <td class="auto-style1">
                <dx:ASPxButton ID="BT_VryDoc" runat="server" Font-Names="微軟正黑體" Font-Size="Medium" Text="前往變更確認報告書" Width="120px" Visible="False">
                </dx:ASPxButton>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxLabel ID="LABEL_BAS" runat="server">
                </dx:ASPxLabel>
            </td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CWMSConnectionString %>" 
                    DeleteCommand="DELETE FROM [DAHS_MODIFY] WHERE [CNO] = @CNO AND [DOCTYPE] = @DOCTYPE AND [REGDATE] = @REGDATE AND [DOCVERSION] = @DOCVERSION" 
                    InsertCommand="INSERT INTO [DAHS_MODIFY] ([CNO], [ABBR], [DOCTYPE], [REGISTOR], [CONTACTPHONE], [EMAIL], [MIDIFYCOUNT], [REGDATE], [DOCVERSION], [C_ID], [C_DATE]) VALUES (@CNO, @ABBR, @DOCTYPE, @REGISTOR, @CONTACTPHONE, @EMAIL, @MIDIFYCOUNT, @REGDATE, @DOCVERSION, @C_ID, @C_DATE)" 
                    SelectCommand="SELECT * FROM [DAHS_MODIFY]" 
                    UpdateCommand="UPDATE [DAHS_MODIFY] SET [ABBR] = @ABBR, [REGISTOR] = @REGISTOR, [CONTACTPHONE] = @CONTACTPHONE, [EMAIL] = @EMAIL, [MIDIFYCOUNT] = @MIDIFYCOUNT, [C_ID] = @C_ID, [C_DATE] = @C_DATE WHERE [CNO] = @CNO AND [DOCTYPE] = @DOCTYPE AND [REGDATE] = @REGDATE AND [DOCVERSION] = @DOCVERSION">
                    <DeleteParameters>
                        <asp:Parameter Name="CNO" Type="String" />
                        <asp:Parameter Name="DOCTYPE" Type="String" />
                        <asp:Parameter DbType="Date" Name="REGDATE" />
                        <asp:Parameter Name="DOCVERSION" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="CNO" Type="String" />
                        <asp:Parameter Name="ABBR" Type="String" />
                        <asp:Parameter Name="DOCTYPE" Type="String" />
                        <asp:Parameter Name="REGISTOR" Type="String" />
                        <asp:Parameter Name="CONTACTPHONE" Type="String" />
                        <asp:Parameter Name="EMAIL" Type="String" />
                        <asp:Parameter Name="MIDIFYCOUNT" Type="Int32" />
                        <asp:Parameter DbType="Date" Name="REGDATE" />
                        <asp:Parameter Name="DOCVERSION" Type="String" />
                        <asp:Parameter Name="C_ID" Type="String" />
                        <asp:Parameter Name="C_DATE" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ABBR" Type="String" />
                        <asp:Parameter Name="REGISTOR" Type="String" />
                        <asp:Parameter Name="CONTACTPHONE" Type="String" />
                        <asp:Parameter Name="EMAIL" Type="String" />
                        <asp:Parameter Name="MIDIFYCOUNT" Type="Int32" />
                        <asp:Parameter Name="C_ID" Type="String" />
                        <asp:Parameter Name="C_DATE" Type="DateTime" />
                        <asp:Parameter Name="CNO" Type="String" />
                        <asp:Parameter Name="DOCTYPE" Type="String" />
                        <asp:Parameter DbType="Date" Name="REGDATE" />
                        <asp:Parameter Name="DOCVERSION" Type="String" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                </td>
        </tr>
    </table>
</asp:Content>
