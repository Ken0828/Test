Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Configuration
Imports System.IO
Imports DevExpress.Web
Imports System.Net.Mail
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Collections
Imports System.ComponentModel
Imports System.Text
Imports NPOI
Imports NPOI.HPSF
Imports NPOI.HSSF
Imports NPOI.HSSF.UserModel
Imports NPOI.SS.UserModel
Imports NPOI.SS.Util
Imports NPOI.XSSF.UserModel
Imports NPOI.HSSF.Util
Imports NPOI.HSSFColor
Imports NPOI.POIFS
Imports NPOI.POIFS.FileSystem
Imports NPOI.Util
Imports DevExpress.Spreadsheet
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSpreadsheet.Services
Imports DevExpress.XtraSpreadsheet.Services.Implementation



Public Class PrintingMenu
    Inherits System.Web.UI.Page

    Dim DBconntext As String = WebConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString.ToString
    Dim RuleAuditFlag As String = WebConfigurationManager.ConnectionStrings("CWMS_Security").ConnectionString.ToString
    Dim MyDOCVersion As Integer = 0

    Private SqlTxt_Factory As String
    Private SqlTxt_Item As String
    Private SqlTxt_SPEC As String
    Private SqlTxt_LED As String
    Private SqlTxt_LINK As String
    Private SqlTxt_LP As String
    Private SqlTxt_DAHS As String
    Private SqlTxt_DPNOItem As String
    Private SqlTxt_SPEC_DPNO As String
    Private SqlTxt_CHECKLIST As String


    Public Shared Function GetDS(ByVal MyConnString As String, ByVal MySqlTxt As String) As DataSet
        Dim Ds As New DataSet

        Try
            Using Conn As New SqlConnection(MyConnString)

                MySqlTxt = MySqlTxt
                Dim Cmmd As New SqlCommand(MySqlTxt, Conn)
                Dim Da As New SqlDataAdapter(Cmmd)
                Da.Fill(Ds)

            End Using

        Catch ex As Exception
            'strErr = ex.Message

        End Try
        Return Ds
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not User.Identity.IsAuthenticated) Then
            FormsAuthentication.RedirectToLoginPage()
            Response.Flush()
            Response.End()
        End If

    End Sub


    Protected Sub ToExcel(ByVal strCno As String, ByVal strDocVersion As String, ByVal strPrintType As String, ByVal strResultFileName As String)

        SqlTxt_Factory = "select distinct * from DOC_SET_FACTORY where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"
        SqlTxt_Item = "select distinct * from DOC_SET_ITEM where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"
        SqlTxt_SPEC_DPNO = "select distinct  * from DOC_SET_SPEC where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"
        SqlTxt_SPEC = "select distinct * from DOC_SET_SPEC where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"
        SqlTxt_LED = "select distinct * from DOC_SET_LED where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"
        SqlTxt_LINK = "select distinct * from DOC_SET_LINK where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"
        SqlTxt_LP = "select distinct * from DOC_SET_LP where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"
        SqlTxt_DAHS = "select distinct * from DOC_SET_DAHS where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"
        SqlTxt_CHECKLIST = "select distinct * from DOC_SET_CHECKLIST where cno='" + strCno + "' and Docversion='" + strDocVersion + "'"



        Try
            Dim dsRpt_Factory As DataSet = GetDS(DBconntext, SqlTxt_Factory)
            Dim dsRpt_ITEM As DataSet = GetDS(DBconntext, SqlTxt_Item)
            Dim dsRpt_SPEC_DPNO As DataSet = GetDS(DBconntext, SqlTxt_SPEC_DPNO)
            Dim dsRpt_SPEC_DPNO_Self As DataSet = GetDS(DBconntext, SqlTxt_SPEC_DPNO)
            Dim dsRpt_SPEC As DataSet = GetDS(DBconntext, SqlTxt_SPEC)
            Dim dsRpt_LED As DataSet = GetDS(DBconntext, SqlTxt_LED)
            Dim dsRpt_LINK As DataSet = GetDS(DBconntext, SqlTxt_LINK)
            Dim dsRpt_LP As DataSet = GetDS(DBconntext, SqlTxt_LP)
            Dim dsRpt_DAHS As DataSet = GetDS(DBconntext, SqlTxt_DAHS)
            Dim dsRpt_CHECKLIST As DataSet = GetDS(DBconntext, SqlTxt_CHECKLIST)


            Dim fs As FileStream

            fs = New FileStream(Server.MapPath("DocSetTemplate.xls"), FileMode.Open, FileAccess.Read)
            Dim xlWorkBook As HSSFWorkbook = New HSSFWorkbook(fs)
            Dim ms As MemoryStream = New MemoryStream()  '==需要 System.IO命名空間 
            Dim u_sheet As HSSFSheet

            ' for factory 
            Dim dtFactory As DataTable

            dtFactory = dsRpt_Factory.Tables(0)
            'u_sheet = xlWorkBook.GetSheet("Cover")
            u_sheet = xlWorkBook.CloneSheet(1)
            Dim Coverx As Integer = xlWorkBook.GetSheetIndex(u_sheet.SheetName)
            Dim CoverstrSheetName As String = "基本資料-"
            xlWorkBook.SetSheetName(Coverx, CoverstrSheetName)
            If dtFactory.Rows.Count > 0 Then

                If dtFactory.Rows(0).Item("TYPE").ToString.Trim = "事業" Then

                    u_sheet.GetRow(2).GetCell(2).SetCellValue("■事業")
                    u_sheet.GetRow(3).GetCell(2).SetCellValue("主業別:" + dtFactory.Rows(0).Item("TYPEB").ToString.Trim)
                    u_sheet.GetRow(4).GetCell(2).SetCellValue("□污水下水道系統")
                Else
                    u_sheet.GetRow(2).GetCell(2).SetCellValue("□事業")
                    u_sheet.GetRow(4).GetCell(2).SetCellValue("■污水下水道系統")

                    If dtFactory.Rows(0).Item("TYPEW").ToString.Trim = "工業區專用污水下水道系統" Then
                        u_sheet.GetRow(5).GetCell(2).SetCellValue("■工業區專用污水下水道系統")
                    ElseIf dtFactory.Rows(0).Item("TYPEW").ToString.Trim = "公共污水下水道系統" Then
                        u_sheet.GetRow(5).GetCell(2).SetCellValue("■公共污水下水道系統")
                    ElseIf dtFactory.Rows(0).Item("TYPEW").ToString.Trim = "指定地區或場所專用污水下水道系統" Then
                        u_sheet.GetRow(5).GetCell(2).SetCellValue("■指定地區或場所專用污水下水道系統")
                    Else
                        u_sheet.GetRow(5).GetCell(2).SetCellValue("   ")

                    End If
                End If


                u_sheet.GetRow(1).GetCell(7).SetCellValue(dtFactory.Rows(0).Item("FAC_NAME").ToString.Trim)
                u_sheet.GetRow(1).GetCell(2).SetCellValue(dtFactory.Rows(0).Item("CNO").ToString.Trim)
                u_sheet.GetRow(6).GetCell(5).SetCellValue(dtFactory.Rows(0).Item("PERMIT_VOL").ToString.Trim)
                u_sheet.GetRow(7).GetCell(5).SetCellValue(dtFactory.Rows(0).Item("OPERATION_VOL").ToString.Trim)

                If dtFactory.Rows(0).Item("RULE_31").ToString.Trim = "True" Then
                    u_sheet.GetRow(8).GetCell(2).SetCellValue("■水污染防治法第31條")
                Else
                    u_sheet.GetRow(8).GetCell(2).SetCellValue("□水污染防治法第31條")
                End If

                If dtFactory.Rows(0).Item("RULE_56").ToString.Trim = "True" Then
                    u_sheet.GetRow(9).GetCell(2).SetCellValue("■水污染防治措施及檢測申報管理辦法第56條")
                Else
                    u_sheet.GetRow(9).GetCell(2).SetCellValue("□水污染防治措施及檢測申報管理辦法第56條")
                End If

                If dtFactory.Rows(0).Item("RULE_56_1").ToString.Trim = "True" Then
                    u_sheet.GetRow(10).GetCell(2).SetCellValue("■具第1項第1款情形")
                Else
                    u_sheet.GetRow(10).GetCell(2).SetCellValue("□具第1項第1款情形")
                End If

                If dtFactory.Rows(0).Item("RULE_56_2").ToString.Trim = "True" Then
                    u_sheet.GetRow(11).GetCell(2).SetCellValue("■具第1項第2款情形")
                Else
                    u_sheet.GetRow(11).GetCell(2).SetCellValue("□具第1項第2款情形")
                End If

                If dtFactory.Rows(0).Item("RULE_56_3").ToString.Trim = "True" Then
                    u_sheet.GetRow(12).GetCell(2).SetCellValue("■具第1項第3款情形")
                Else
                    u_sheet.GetRow(12).GetCell(2).SetCellValue("□具第1項第3款情形")
                End If

                If dtFactory.Rows(0).Item("RULE_56_4").ToString.Trim = "True" Then
                    u_sheet.GetRow(13).GetCell(2).SetCellValue("■具第1項第4款情形")
                Else
                    u_sheet.GetRow(13).GetCell(2).SetCellValue("□具第1項第4款情形")
                End If

                If dtFactory.Rows(0).Item("RULE_56_5").ToString.Trim = "True" Then
                    u_sheet.GetRow(14).GetCell(2).SetCellValue("■具第1項第5款情形")
                Else
                    u_sheet.GetRow(14).GetCell(2).SetCellValue("□具第1項第5款情形")
                End If

                If dtFactory.Rows(0).Item("RULE_56_6").ToString.Trim = "True" Then
                    u_sheet.GetRow(15).GetCell(2).SetCellValue("■具第1項第6款情形")
                Else
                    u_sheet.GetRow(15).GetCell(2).SetCellValue("□具第1項第6款情形")
                End If

                If dtFactory.Rows(0).Item("RULE_56_7").ToString.Trim = "True" Then
                    u_sheet.GetRow(16).GetCell(2).SetCellValue("■具第2項情形")
                Else
                    u_sheet.GetRow(16).GetCell(2).SetCellValue("□具第2項情形")
                End If

                If dtFactory.Rows(0).Item("RULE_57_1").ToString.Trim = "True" Then
                    u_sheet.GetRow(17).GetCell(2).SetCellValue("■水污染防治措施及檢測申報管理辦法第57-1條")
                Else
                    u_sheet.GetRow(17).GetCell(2).SetCellValue("□水污染防治措施及檢測申報管理辦法第57-1條")
                End If

                If dtFactory.Rows(0).Item("RULE_105").ToString.Trim = "True" Then
                    u_sheet.GetRow(18).GetCell(2).SetCellValue("■水污染防治措施及檢測申報管理辦法第105條")
                Else
                    u_sheet.GetRow(18).GetCell(2).SetCellValue("□水污染防治措施及檢測申報管理辦法第105條")
                End If

                If dtFactory.Rows(0).Item("RULE_1500_I").ToString.Trim = "True" Then
                    u_sheet.GetRow(19).GetCell(2).SetCellValue("■許可核准排放量達每日1,500 CMD以上工業區專用污水下水道系統")
                Else
                    u_sheet.GetRow(19).GetCell(2).SetCellValue("□許可核准排放量達每日1,500 CMD以上工業區專用污水下水道系統")
                End If

                If dtFactory.Rows(0).Item("RULE_5000_BUSSINESS").ToString.Trim = "True" Then
                    u_sheet.GetRow(20).GetCell(2).SetCellValue("■許可核准排放量達每日5,000 CMD以上事業")
                Else
                    u_sheet.GetRow(20).GetCell(2).SetCellValue("□許可核准排放量達每日5,000 CMD以上事業")
                End If

                If dtFactory.Rows(0).Item("RULE_1500_BUSSINESS").ToString.Trim = "True" Then
                    u_sheet.GetRow(21).GetCell(2).SetCellValue("■許可核准排放量達每日1,500 CMD以上、未達5,000 CMD事業")
                Else
                    u_sheet.GetRow(21).GetCell(2).SetCellValue("□許可核准排放量達每日1,500 CMD以上、未達5,000 CMD事業")
                End If

                If dtFactory.Rows(0).Item("RULE_5000_LIFE").ToString.Trim = "True" Then
                    u_sheet.GetRow(22).GetCell(2).SetCellValue("■許可核准排放量達每日5,000 CMD以上公共污水下水道系統")
                Else
                    u_sheet.GetRow(22).GetCell(2).SetCellValue("□許可核准排放量達每日5,000 CMD以上公共污水下水道系統")
                End If

                If dtFactory.Rows(0).Item("RULE_1500_LIFE").ToString.Trim = "True" Then
                    u_sheet.GetRow(23).GetCell(2).SetCellValue("■許可核准排放量達每日1,500 CMD以上、未達5,000 CMD公共污水下水道系統")
                Else
                    u_sheet.GetRow(23).GetCell(2).SetCellValue("□許可核准排放量達每日1,500 CMD以上、未達5,000 CMD公共污水下水道系統")
                End If

                If dtFactory.Rows(0).Item("RULE_ELEC").ToString.Trim = "True" Then
                    u_sheet.GetRow(24).GetCell(2).SetCellValue(" ■發電廠")
                Else
                    u_sheet.GetRow(24).GetCell(2).SetCellValue(" □發電廠")
                End If

                If dtFactory.Rows(0).Item("RULE_WATERCOOLER").ToString.Trim = "True" Then
                    u_sheet.GetRow(25).GetCell(2).SetCellValue(" ■排放未接觸冷卻水")
                Else
                    u_sheet.GetRow(25).GetCell(2).SetCellValue(" □排放未接觸冷卻水")
                End If

                If dtFactory.Rows(0).Item("RULE_E_EQUIP").ToString.Trim = "True" Then
                    u_sheet.GetRow(26).GetCell(2).SetCellValue(" ■採海水排煙脫硫空氣污染防制設施者")
                Else
                    u_sheet.GetRow(26).GetCell(2).SetCellValue(" □採海水排煙脫硫空氣污染防制設施者")
                End If

                If dtFactory.Rows(0).Item("RULE_OTHER").ToString.Trim = "True" Then
                    u_sheet.GetRow(26).GetCell(2).SetCellValue(" ■其他經中央主管機關指定者")
                Else
                    u_sheet.GetRow(26).GetCell(2).SetCellValue(" □其他經中央主管機關指定者")
                End If

                '2020-02-13 加上特登事業

                If dtFactory.Rows(0).Item("RULE_19").ToString.Trim = "True" Then
                    u_sheet.GetRow(27).GetCell(2).SetCellValue(" ■經濟部「特定工廠登記辦法」第19條第4項")
                Else
                    u_sheet.GetRow(27).GetCell(2).SetCellValue(" □經濟部「特定工廠登記辦法」第19條第4項")
                End If

                If dtFactory.Rows(0).Item("RULE_19_4").ToString.Trim = "True" Then
                    u_sheet.GetRow(28).GetCell(2).SetCellValue(" ■具第19條第4項情形")
                Else
                    u_sheet.GetRow(28).GetCell(2).SetCellValue(" □具第19條第4項情形")
                End If

                If dtFactory.Rows(0).Item("RULE_19_4_56").ToString.Trim = "True" Then
                    u_sheet.GetRow(29).GetCell(2).SetCellValue(" ■具第19條第4項情形，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                Else
                    u_sheet.GetRow(29).GetCell(2).SetCellValue(" □具第19條第4項情形，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                End If

                If dtFactory.Rows(0).Item("RULE_19_56").ToString.Trim = "True" Then
                    u_sheet.GetRow(30).GetCell(2).SetCellValue(" ■屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                Else
                    u_sheet.GetRow(30).GetCell(2).SetCellValue(" □屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                End If

                u_sheet.GetRow(33).GetCell(2).SetCellValue(dtFactory.Rows(0).Item("FAC_CNAME").ToString.Trim)
                u_sheet.GetRow(33).GetCell(6).SetCellValue(dtFactory.Rows(0).Item("FAC_CTEL").ToString.Trim)
                u_sheet.GetRow(33).GetCell(9).SetCellValue(dtFactory.Rows(0).Item("FAC_CTEL_EXT").ToString.Trim)
                u_sheet.GetRow(34).GetCell(2).SetCellValue(dtFactory.Rows(0).Item("FAC_CMOBILE").ToString.Trim)
                u_sheet.GetRow(34).GetCell(6).SetCellValue(dtFactory.Rows(0).Item("FAC_CFAX").ToString.Trim)
                u_sheet.GetRow(35).GetCell(2).SetCellValue(dtFactory.Rows(0).Item("FAC_CEMAIL").ToString.Trim)

                'RBL_REG_SET
                If dtFactory.Rows(0).Item("RBL_REG_SET").ToString.Trim = "設置(新申請)" Then
                    u_sheet.GetRow(36).GetCell(2).SetCellValue("■設置（新申請）")
                Else
                    u_sheet.GetRow(36).GetCell(2).SetCellValue("□設置（新申請）")
                End If


                '□變更，變更類型（可複選）：□設施汰換  □其他
                If dtFactory.Rows(0).Item("RBL_REG_MODI").ToString.Trim = "變更" Then

                    If dtFactory.Rows(0).Item("CB_5_MOD_C").ToString.Trim = "True" And dtFactory.Rows(0).Item("CB_5_MOD_OTHER").ToString.Trim = "True" Then

                        u_sheet.GetRow(37).GetCell(2).SetCellValue("■變更，變更類型（可複選）：■設施汰換  ■其他")

                    ElseIf dtFactory.Rows(0).Item("CB_5_MOD_C").ToString.Trim = "True" And dtFactory.Rows(0).Item("CB_5_MOD_OTHER").ToString.Trim = "False" Then

                        u_sheet.GetRow(37).GetCell(2).SetCellValue("■變更，變更類型（可複選）：■設施汰換  □其他")

                    ElseIf dtFactory.Rows(0).Item("CB_5_MOD_C").ToString.Trim = "False" And dtFactory.Rows(0).Item("CB_5_MOD_OTHER").ToString.Trim = "True" Then

                        u_sheet.GetRow(37).GetCell(2).SetCellValue("■變更，變更類型（可複選）：□設施汰換  ■其他")
                    Else
                        u_sheet.GetRow(37).GetCell(2).SetCellValue("■變更，變更類型（可複選）：□設施汰換  □其他")

                    End If

                Else
                    u_sheet.GetRow(37).GetCell(2).SetCellValue("□變更，變更類型（可複選）：□設施汰換  □其他")
                End If

                '六 位置及種類
                'loop by dp_no


                Dim dtITEM As DataTable
                dtITEM = dsRpt_ITEM.Tables(0)

                Dim strItem As String = ""
                Dim strRows As Integer = 41

                Dim Style = xlWorkBook.CreateCellStyle()
                Dim titleFont = xlWorkBook.CreateFont()

                If dtITEM.Rows.Count > 0 Then

                    For Each dr As DataRow In dtITEM.Rows

                        strItem = ""
                        If dtFactory.Rows(0).Item("RULE_31").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then


                                'u_sheet.CreateRow (strRows).createcell(1).SetCellValue("■放流口")
                                'u_sheet.GetRow(strRows).createcell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治法第31條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")


                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If

                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))




                            End If
                        End If

                        If dtFactory.Rows(0).Item("RULE_56").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■放流口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "處理單元(進流口)" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■處理單元(進流口)")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim()+" 許可證水流編號:"+dr.Item("PERMIT_SERIAL").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■處理單元(進流口)")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "處理單元(出流口)" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■處理單元(出流口)")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim()+" 許可證水流編號:"+dr.Item("PERMIT_SERIAL").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■處理單元(出流口)")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "排放口" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■排放口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■排放口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-自來水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-自來水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-自來水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-地下水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-地下水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-地下水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-河湖海水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-河湖海水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-河湖海水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-回收水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-回收水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-回收水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "電子式電度表" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■電子式電度表")
                                'u_sheet.GetRow(strRows+1).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第56條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■電子式電度表")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")


                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("涵蓋之廢（污）水（前）處理設施編號:" + dr.Item("EM_COVER").ToString.Trim())

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))



                                strRows += 2
                            End If
                        End If

                        If dtFactory.Rows(0).Item("RULE_57_1").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■放流口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第57-1條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")

                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "處理單元(進流口)" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■處理單元(進流口)")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim()+" 許可證水流編號:"+dr.Item("PERMIT_SERIAL").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第57-1條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■處理單元(進流口)")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "處理單元(出流口)" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■處理單元(出流口)")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim()+" 許可證水流編號:"+dr.Item("PERMIT_SERIAL").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第57-1條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■處理單元(出流口)")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")

                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True



                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))
                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "排放口" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■排放口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第57-1條規定設置之對象")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■排放口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            End If
                        End If

                        If dtFactory.Rows(0).Item("RULE_1500_I").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■放流口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第105條規定設置之工業區專用污水下水道系統")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True



                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2


                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "排放口" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■排放口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第105條規定設置之工業區專用污水下水道系統")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■排放口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")

                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True



                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))
                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "進流口" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■進流口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第105條規定設置之工業區專用污水下水道系統")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■進流口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")

                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "雨水放流" Then


                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■雨水放流")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第105條規定設置之工業區專用污水下水道系統")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■雨水放流")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")


                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2
                            End If
                        End If

                        If dtFactory.Rows(0).Item("RULE_5000_BUSSINESS").ToString.Trim = "True" Or dtFactory.Rows(0).Item("RULE_1500_BUSSINESS").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then

                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("")
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")

                                For k = 1 To 9
                                    u_sheet.GetRow(strRows).CreateCell(k).SetCellValue("")
                                    u_sheet.GetRow(strRows + 1).CreateCell(k).SetCellValue("")
                                Next

                                u_sheet.GetRow(strRows).GetCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第105條規定設置之事業")
                                u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If


                                u_sheet.GetRow(strRows + 1).GetCell(3).SetCellValue("種類:" + strItem)

                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                For k = 0 To 9
                                    u_sheet.GetRow(strRows).GetCell(k).CellStyle = Style
                                    u_sheet.GetRow(strRows + 1).GetCell(k).CellStyle = Style
                                Next

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                            End If
                        End If


                        If dtFactory.Rows(0).Item("RULE_ELEC").ToString.Trim = "True" Or dtFactory.Rows(0).Item("RULE_WATERCOOLER").ToString.Trim = "True" Or dtFactory.Rows(0).Item("RULE_E_EQUIP").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then

                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("")
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")

                                For k = 1 To 11
                                    u_sheet.GetRow(strRows).CreateCell(k).SetCellValue("")
                                    u_sheet.GetRow(strRows + 1).CreateCell(k).SetCellValue("")
                                Next

                                u_sheet.GetRow(strRows).GetCell(0).SetCellValue("依水污染防治措施及檢測申報管理辦法第105條規定設置之事業")
                                u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                If dr.Item("ITEM_241").ToString.Trim() = "True" Then
                                    strItem += "■硝酸鹽氮"
                                End If
                                If dr.Item("ITEM_267").ToString.Trim() = "True" Then
                                    strItem += "■硼"
                                End If

                                u_sheet.GetRow(strRows + 1).GetCell(3).SetCellValue("種類:" + strItem)

                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                For k = 0 To 11
                                    u_sheet.GetRow(strRows).GetCell(k).CellStyle = Style
                                    u_sheet.GetRow(strRows + 1).GetCell(k).CellStyle = Style
                                Next

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                            End If
                        End If

                        If dtFactory.Rows(0).Item("RULE_19_4").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■放流口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("經濟部「特定工廠登記辦法」第19條第4項")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-自來水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-自來水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("經濟部「特定工廠登記辦法」第19條第4項")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-自來水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-地下水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-地下水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("經濟部「特定工廠登記辦法」第19條第4項")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-地下水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-用水貯存區進入製程前" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-河湖海水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("經濟部「特定工廠登記辦法」第19條第4項")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-用水貯存區進入製程前")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")

                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "電子式電度表" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■電子式電度表")
                                'u_sheet.GetRow(strRows+1).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("經濟部「特定工廠登記辦法」第19條第4項")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■電子式電度表")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")

                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("涵蓋之廢（污）水（前）處理設施編號:" + dr.Item("EM_COVER").ToString.Trim())

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2
                            End If
                        End If

                        If dtFactory.Rows(0).Item("RULE_19_4_56").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■放流口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "處理單元(進流口)" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■處理單元(進流口)")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim()+" 許可證水流編號:"+dr.Item("PERMIT_SERIAL").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■處理單元(進流口)")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "處理單元(出流口)" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■處理單元(出流口)")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim()+" 許可證水流編號:"+dr.Item("PERMIT_SERIAL").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■處理單元(出流口)")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "排放口" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■排放口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■排放口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-自來水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-自來水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-自來水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-地下水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-地下水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-地下水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-河湖海水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-河湖海水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-河湖海水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-回收水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-回收水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-回收水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-用水貯存區進入製程前" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-河湖海水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-用水貯存區進入製程前")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")

                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "電子式電度表" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■電子式電度表")
                                'u_sheet.GetRow(strRows+1).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("具第19條第4項規定者同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■電子式電度表")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")


                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("涵蓋之廢（污）水（前）處理設施編號:" + dr.Item("EM_COVER").ToString.Trim())

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))



                                strRows += 2
                            End If
                        End If

                        If dtFactory.Rows(0).Item("RULE_19_56").ToString.Trim = "True" Then
                            If dr.Item("DPTYPE").ToString.Trim() = "放流口" Then
                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■放流口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■放流口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "處理單元(進流口)" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■處理單元(進流口)")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim()+" 許可證水流編號:"+dr.Item("PERMIT_SERIAL").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■處理單元(進流口)")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")

                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "處理單元(出流口)" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■處理單元(出流口)")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim()+" 許可證水流編號:"+dr.Item("PERMIT_SERIAL").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■處理單元(出流口)")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "排放口" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■排放口")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■排放口")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-自來水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-自來水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-自來水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-地下水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-地下水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-地下水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-河湖海水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-河湖海水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-河湖海水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-回收水" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-回收水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-回收水")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")



                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True


                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "用水來源-用水貯存區進入製程前" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■用水來源-河湖海水")
                                'u_sheet.GetRow(strRows).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■用水來源-用水貯存區進入製程前")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")
                                If dr.Item("ITEM_248").ToString.Trim() = "True" Then
                                    strItem += "■水量"
                                End If
                                If dr.Item("ITEM_259").ToString.Trim() = "True" Then
                                    strItem += "■水溫"
                                End If
                                If dr.Item("ITEM_246").ToString.Trim() = "True" Then
                                    strItem += "■pH"
                                End If
                                If dr.Item("ITEM_247").ToString.Trim() = "True" Then
                                    strItem += "■導電度"
                                End If
                                If dr.Item("ITEM_243").ToString.Trim() = "True" Then
                                    strItem += "■COD"
                                End If
                                If dr.Item("ITEM_210").ToString.Trim() = "True" Then
                                    strItem += "■SS"
                                End If
                                If dr.Item("ITEM_VIDEO").ToString.Trim() = "True" Then
                                    strItem += "■攝錄影監視"
                                End If
                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("種類:" + strItem)

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")

                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))

                                strRows += 2

                            ElseIf dr.Item("DPTYPE").ToString.Trim() = "電子式電度表" Then

                                'u_sheet.GetRow(strRows).GetCell(1).SetCellValue("■電子式電度表")
                                'u_sheet.GetRow(strRows+1).GetCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())
                                u_sheet.CreateRow(strRows).CreateCell(0).SetCellValue("屬低污染事業，並同時違反水污染防治措施及檢測申報管理辦法第56條規定者")
                                u_sheet.GetRow(strRows).CreateCell(1).SetCellValue("■電子式電度表")
                                u_sheet.GetRow(strRows).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(3).SetCellValue("監測位置編號:" + dr.Item("DP_NO").ToString.Trim() + " 監測位置名稱:" + dr.Item("DPTYPE").ToString.Trim())

                                u_sheet.GetRow(strRows).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows).CreateCell(9).SetCellValue("")


                                u_sheet.CreateRow(strRows + 1).CreateCell(0).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(1).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(2).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(3).SetCellValue("涵蓋之廢（污）水（前）處理設施編號:" + dr.Item("EM_COVER").ToString.Trim())

                                u_sheet.GetRow(strRows + 1).CreateCell(4).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(5).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(6).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(7).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(8).SetCellValue("")
                                u_sheet.GetRow(strRows + 1).CreateCell(9).SetCellValue("")


                                Style.BorderBottom = BorderStyle.THIN
                                Style.BorderLeft = BorderStyle.THIN
                                Style.BorderRight = BorderStyle.THIN
                                Style.BorderTop = BorderStyle.THIN
                                Style.VerticalAlignment = VerticalAlignment.TOP
                                Style.Alignment = HorizontalAlignment.LEFT
                                Style.WrapText = True

                                titleFont.FontHeightInPoints = 10
                                titleFont.FontName = "標楷體"
                                titleFont.Color = HSSFColor.BLACK.index
                                Style.SetFont(titleFont)

                                u_sheet.GetRow(strRows).GetCell(0).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(0).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(2).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(1).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(2).CellStyle = Style

                                u_sheet.GetRow(strRows).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows).GetCell(9).CellStyle = Style

                                u_sheet.GetRow(strRows + 1).GetCell(3).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(4).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(5).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(6).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(7).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(8).CellStyle = Style
                                u_sheet.GetRow(strRows + 1).GetCell(9).CellStyle = Style

                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 0, 0))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows + 1, 1, 2))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows, strRows, 3, 9))
                                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 1, strRows + 1, 3, 9))



                                strRows += 2
                            End If
                        End If

                    Next
                End If


                u_sheet.CreateRow(strRows + 2).CreateCell(0).SetCellValue("六、設置、汰換或變更連線傳輸設施及放流水水量、水質自動顯示看板")

                For k = 1 To 9
                    u_sheet.GetRow(strRows + 2).CreateCell(k).SetCellValue("")
                Next

                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 2, strRows + 2, 0, 9))


                '七、設置

                If dtFactory.Rows(0).Item("CWMS_LINK").ToString.Trim = "True" Then
                    u_sheet.CreateRow(strRows + 3).CreateCell(0).SetCellValue("■連線傳輸設施")
                Else
                    u_sheet.CreateRow(strRows + 3).CreateCell(0).SetCellValue("□連線傳輸設施")
                End If

                u_sheet.CreateRow(strRows + 4).CreateCell(0).SetCellValue("")
                u_sheet.CreateRow(strRows + 5).CreateCell(0).SetCellValue("")
                u_sheet.CreateRow(strRows + 6).CreateCell(0).SetCellValue("")


                For k = 1 To 9
                    u_sheet.GetRow(strRows + 3).CreateCell(k).SetCellValue("")
                    u_sheet.GetRow(strRows + 4).CreateCell(k).SetCellValue("")
                    u_sheet.GetRow(strRows + 5).CreateCell(k).SetCellValue("")
                    u_sheet.GetRow(strRows + 6).CreateCell(k).SetCellValue("")
                Next

                If dtFactory.Rows(0).Item("CWMS_LINKRULE_56").ToString.Trim = "True" Then
                    u_sheet.GetRow(strRows + 3).CreateCell(2).SetCellValue("■依水污染防治措施及檢測申報管理辦法第56條規定設置")
                Else
                    u_sheet.GetRow(strRows + 3).CreateCell(2).SetCellValue("□依水污染防治措施及檢測申報管理辦法第56條規定設置")
                End If

                If dtFactory.Rows(0).Item("CWMS_LINKRULE_57_1").ToString.Trim = "True" Then
                    u_sheet.GetRow(strRows + 4).CreateCell(2).SetCellValue("■依水污染防治措施及檢測申報管理辦法第57-1條規定設置")
                Else
                    u_sheet.GetRow(strRows + 4).CreateCell(2).SetCellValue("□依水污染防治措施及檢測申報管理辦法第57-1條規定設置")
                End If

                If dtFactory.Rows(0).Item("CWMS_LINKRULE_105").ToString.Trim = "True" Then
                    u_sheet.GetRow(strRows + 5).CreateCell(2).SetCellValue("■依水污染防治措施及檢測申報管理辦法第105條規定設置")
                Else
                    u_sheet.GetRow(strRows + 5).CreateCell(2).SetCellValue("□依水污染防治措施及檢測申報管理辦法第105條規定設置")
                End If

                If dtFactory.Rows(0).Item("CWMS_LINKRULE_19_4").ToString.Trim = "True" Then
                    u_sheet.GetRow(strRows + 6).CreateCell(2).SetCellValue("■經濟部「特定工廠登記辦法」第19條第4項情形")
                Else
                    u_sheet.GetRow(strRows + 6).CreateCell(2).SetCellValue("□經濟部「特定工廠登記辦法」第19條第4項情形")
                End If

                u_sheet.GetRow(strRows + 3).GetCell(8).SetCellValue("設置數量：" + dtFactory.Rows(0).Item("LINKSET").ToString.Trim + "套")

                Style.BorderBottom = BorderStyle.THIN
                Style.BorderLeft = BorderStyle.THIN
                Style.BorderRight = BorderStyle.THIN
                Style.BorderTop = BorderStyle.THIN
                Style.VerticalAlignment = VerticalAlignment.TOP
                Style.Alignment = HorizontalAlignment.LEFT
                Style.WrapText = True

                titleFont.FontHeightInPoints = 10
                titleFont.FontName = "標楷體"
                titleFont.Color = HSSFColor.BLACK.index
                Style.SetFont(titleFont)

                For k = 0 To 9
                    u_sheet.GetRow(strRows + 2).GetCell(k).CellStyle = Style
                    u_sheet.GetRow(strRows + 3).GetCell(k).CellStyle = Style
                    u_sheet.GetRow(strRows + 4).GetCell(k).CellStyle = Style
                    u_sheet.GetRow(strRows + 5).GetCell(k).CellStyle = Style
                    u_sheet.GetRow(strRows + 6).GetCell(k).CellStyle = Style
                Next

                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 3, strRows + 6, 0, 1))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 3, strRows + 3, 2, 7))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 3, strRows + 3, 8, 9))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 4, strRows + 4, 2, 7))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 4, strRows + 4, 8, 9))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 5, strRows + 5, 2, 7))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 5, strRows + 5, 8, 9))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 6, strRows + 6, 2, 7))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 6, strRows + 6, 8, 9))

                If dtFactory.Rows(0).Item("CWMS_LED").ToString.Trim = "True" Then
                    u_sheet.CreateRow(strRows + 7).CreateCell(0).SetCellValue("■放流水水量、水質自動顯示看板")
                Else
                    u_sheet.CreateRow(strRows + 7).CreateCell(0).SetCellValue("□放流水水量、水質自動顯示看板")
                End If

                For k = 1 To 9
                    u_sheet.GetRow(strRows + 7).CreateCell(k).SetCellValue("")
                Next

                If dtFactory.Rows(0).Item("CWMS_LEDRULE_56").ToString.Trim = "True" Then
                    u_sheet.GetRow(strRows + 7).GetCell(2).SetCellValue("■依水污染防治措施及檢測申報管理辦法第56條第2項規定設置")
                Else
                    u_sheet.GetRow(strRows + 7).GetCell(2).SetCellValue("□依水污染防治措施及檢測申報管理辦法第56條第2項規定設置")
                End If

                u_sheet.GetRow(strRows + 7).GetCell(8).SetCellValue("設置數量：" + dtFactory.Rows(0).Item("LEDSET").ToString.Trim + "套")

                For k = 0 To 9
                    u_sheet.GetRow(strRows + 7).GetCell(k).CellStyle = Style
                Next

                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 7, strRows + 7, 0, 1))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 7, strRows + 7, 2, 7))
                u_sheet.AddMergedRegion(New CellRangeAddress(strRows + 7, strRows + 7, 8, 9))


            End If

            Dim dtSPEC_DPNO As DataTable
            Dim dtSPEC As DataTable

            dtSPEC_DPNO = dsRpt_SPEC_DPNO.Tables(0)

            If dtSPEC_DPNO.Rows.Count > 0 Then

                For Each dr As DataRow In dtSPEC_DPNO.Rows

                    u_sheet = xlWorkBook.CloneSheet(2)
                    Dim Ref4x As Integer = xlWorkBook.GetSheetIndex(u_sheet.SheetName)
                    Dim Ref4strSheetName = "貳、" + dr.Item("DP_NO").ToString.Trim + "-" + dr.Item("ITEM").ToString.Trim
                    xlWorkBook.SetSheetName(Ref4x, Ref4strSheetName)


                    Dim SqlTxt_REF4 As String = "select distinct * from DOC_SET_SPEC where cno='" + strCno + "' and Docversion='" + strDocVersion + "' and  DP_NO='" + dr.Item("DP_NO").ToString.Trim + "' and item='" + dr.Item("ITEM").ToString.Trim + "'"

                    Dim dsSPEC As DataSet = GetDS(DBconntext, SqlTxt_REF4)
                    dtSPEC = dsSPEC.Tables(0)


                    u_sheet.GetRow(1).GetCell(1).SetCellValue(dtSPEC.Rows(0).Item("DP_NO").ToString.Trim)

                    If dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "210" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■SS")
                    ElseIf dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "243" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■COD")
                    ElseIf dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "242" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■氨氮")
                    ElseIf dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "246" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■pH")
                    ElseIf dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "247" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■導電度")
                    ElseIf dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "248" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■水量")
                    ElseIf dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "259" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■水溫")
                    ElseIf dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "330" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■攝錄影監視")
                    ElseIf dtSPEC.Rows(0).Item("ITEM").ToString.Trim = "299" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■用電量")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_INSTEAD_YES").ToString.Trim = "True" Then
                        u_sheet.GetRow(4).GetCell(2).SetCellValue("■是（核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本見附件）")
                    Else
                        u_sheet.GetRow(4).GetCell(2).SetCellValue("□是（核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本見附件）")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_INSTEAD_NO").ToString.Trim = "True" Then
                        u_sheet.GetRow(5).GetCell(2).SetCellValue("■否")
                    Else
                        u_sheet.GetRow(5).GetCell(2).SetCellValue("□否")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_MONITOROTHER_YES").ToString.Trim = "True" Then
                        u_sheet.GetRow(6).GetCell(2).SetCellValue("■是，與監測位置編號：" + dtSPEC.Rows(0).Item("SPEC_MO_NOTE_DPNO").ToString.Trim + "共設" + dtSPEC.Rows(0).Item("SPEC_MO_NOTE_DPNO1").ToString.Trim + " 處（詳附件）")
                    Else
                        u_sheet.GetRow(6).GetCell(2).SetCellValue("□是，與監測位置編號：     共設   處（詳附件）")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_MONITOROTHER_NO").ToString.Trim = "True" Then
                        u_sheet.GetRow(7).GetCell(2).SetCellValue("■否")
                    Else
                        u_sheet.GetRow(7).GetCell(2).SetCellValue("□否")
                    End If

                    'SPEC_SAMPLE_METHOD

                    u_sheet.GetRow(12).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_SAMPLE_METHOD").ToString.Trim + "(" + dtSPEC.Rows(0).Item("SPEC_SAMPLE_METHOD_DESP").ToString.Trim + "法)")



                    'SPEC_SAMPLE_METHOD_FILTERYES
                    If dtSPEC.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERYES").ToString.Trim = "True" Then
                        u_sheet.GetRow(14).GetCell(2).SetCellValue("■有過濾器/前處理裝置；□無過濾器/前處理裝置")
                    ElseIf dtSPEC.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERNO").ToString.Trim = "True" Then
                        u_sheet.GetRow(14).GetCell(2).SetCellValue("□有過濾器/前處理裝置；■無過濾器/前處理裝置")
                    Else
                        u_sheet.GetRow(14).GetCell(2).SetCellValue("□有過濾器/前處理裝置；□無過濾器/前處理裝置")
                    End If


                    Try
                        u_sheet.GetRow(8).GetCell(2).SetCellValue(CDate(dtSPEC.Rows(0).Item("SPEC_INS_DATE")))
                    Catch ex As Exception

                    End Try

                    u_sheet.GetRow(9).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_AGENTNAME").ToString.Trim)
                    u_sheet.GetRow(10).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_EQU_MODEL").ToString.Trim)
                    u_sheet.GetRow(11).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_EQU_SERIAL").ToString.Trim)

                    u_sheet.GetRow(15).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_CALC_EQU").ToString.Trim)
                    '[SPEC_CALC_METHOD]
                    If dtSPEC.Rows(0).Item("SPEC_CALC_METHOD").ToString.Trim = "擬自行校正" Then

                        u_sheet.GetRow(16).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_CALC_FREQ").ToString.Trim + ";■擬自行校正 □擬委外校正  □不適用")
                    ElseIf dtSPEC.Rows(0).Item("SPEC_CALC_METHOD").ToString.Trim = "擬委外校正" Then
                        u_sheet.GetRow(16).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_CALC_FREQ").ToString.Trim + ";□擬自行校正 ■擬委外校正  □不適用")
                    ElseIf dtSPEC.Rows(0).Item("SPEC_CALC_METHOD").ToString.Trim = "不適用" Then
                        u_sheet.GetRow(16).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_CALC_FREQ").ToString.Trim + ";□擬自行校正 □擬委外校正  ■不適用")

                    End If

                    '[SPEC_MAIN_METHOD]
                    If dtSPEC.Rows(0).Item("SPEC_MAIN_METHOD").ToString.Trim = "擬自行保養" Then
                        u_sheet.GetRow(17).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_MAIN_FREQ").ToString.Trim + ";■擬自行校正 □擬委外校正")
                    Else
                        u_sheet.GetRow(17).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_MAIN_FREQ").ToString.Trim + "；□擬自行保養 ■擬委外保養")
                    End If

                    u_sheet.GetRow(18).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_MATERIAL").ToString.Trim)

                    If dtSPEC.Rows(0).Item("SPEC_WASTELIQUID").ToString.Trim = "無產生廢液(材)" Then

                        u_sheet.GetRow(19).GetCell(2).SetCellValue("■無產生廢液(材)")
                        u_sheet.GetRow(20).GetCell(2).SetCellValue("□有產生廢液(材),儲存清理方式說明(詳附件)")
                    Else
                        u_sheet.GetRow(19).GetCell(2).SetCellValue("□無產生廢液(材)")
                        u_sheet.GetRow(20).GetCell(2).SetCellValue("■有產生廢液(材),儲存清理方式說明(詳附件)")

                    End If

                    u_sheet.GetRow(21).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_MATERIAL_FREQ").ToString.Trim)
                    u_sheet.GetRow(22).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_MEA_SCOPE").ToString.Trim + "（單位：" + dtSPEC.Rows(0).Item("SPEC_MEA_SCOPEUNIT").ToString.Trim + ")")
                    u_sheet.GetRow(23).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_MEA_RESTIME").ToString.Trim + "（單位：" + dtSPEC.Rows(0).Item("SPEC_MEA_RESTIMEUNIT").ToString.Trim + ")")
                    u_sheet.GetRow(24).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_MEA_FREQ").ToString.Trim + "（單位：" + dtSPEC.Rows(0).Item("SPEC_MEA_FREQUNIT").ToString.Trim + ")")
                    u_sheet.GetRow(25).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_CALCAVG").ToString.Trim)


                    '影像格式：□ MPEG；□H.264；□AVI；□其他：

                    If dtSPEC.Rows(0).Item("SPEC_VIDEO_F").ToString.Trim = "MPEG" Then
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：■ MPEG；□H.264；□AVI；□其他 ; □不適用：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    ElseIf dtSPEC.Rows(0).Item("SPEC_VIDEO_F").ToString.Trim = "H.264" Then
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：□ MPEG；■H.264；□AVI；□其他 ; □不適用：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    ElseIf dtSPEC.Rows(0).Item("SPEC_VIDEO_F").ToString.Trim = "AVI" Then
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：□ MPEG；□H.264；■AVI；□其他 ; □不適用：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    ElseIf dtSPEC.Rows(0).Item("SPEC_VIDEO_F").ToString.Trim = "其他" Then
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：□ MPEG；□H.264；□AVI；■其他 ; □不適用：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    Else
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：□ MPEG；□H.264；□AVI；□其他 ; ■不適用：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    End If

                    '解析度：□640x480；□其他：        

                    If dtSPEC.Rows(0).Item("SPEC_VIDEO_R").ToString.Trim = "640X480" Then
                        u_sheet.GetRow(30).GetCell(2).SetCellValue("解析度：■640x480；□其他 ; □不適用 ：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString.Trim)
                    ElseIf dtSPEC.Rows(0).Item("SPEC_VIDEO_R").ToString.Trim = "其他" Then
                        u_sheet.GetRow(30).GetCell(2).SetCellValue("解析度：□640x480；■其他; □不適用 ：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString.Trim)
                    Else
                        u_sheet.GetRow(30).GetCell(2).SetCellValue("解析度：□640x480；□其他; ■不適用：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString.Trim)

                    End If

                    '夜視功能：□有；□無，請說明：

                    If dtSPEC.Rows(0).Item("SPEC_VIDEO_NV").ToString.Trim = "有" Then
                        u_sheet.GetRow(31).GetCell(2).SetCellValue("夜視功能：■有；□無 ; □不適用，請說明：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString.Trim)
                    ElseIf dtSPEC.Rows(0).Item("SPEC_VIDEO_NV").ToString.Trim = "無" Then
                        u_sheet.GetRow(31).GetCell(2).SetCellValue("夜視功能：□有；■無 ; □不適用，請說明：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString.Trim)
                    Else
                        u_sheet.GetRow(31).GetCell(2).SetCellValue("夜視功能：□有；□無 ; ■不適用，請說明：" + dtSPEC.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString.Trim)
                    End If


                    If dtSPEC.Rows(0).Item("SPEC_ANASIG_YES").ToString.Trim = "True" Then
                        u_sheet.GetRow(32).GetCell(2).SetCellValue("■類比訊號：" + dtSPEC.Rows(0).Item("SPEC_ANASIG").ToString.Trim)
                    Else
                        u_sheet.GetRow(32).GetCell(2).SetCellValue("□類比訊號：" + dtSPEC.Rows(0).Item("SPEC_ANASIG").ToString.Trim)
                    End If


                    If dtSPEC.Rows(0).Item("SPEC_DIGSIG_YES").ToString.Trim = "True" Then

                        u_sheet.GetRow(33).GetCell(2).SetCellValue("■數位訊號：" + dtSPEC.Rows(0).Item("SPEC_DIGSIG").ToString.Trim)
                    Else

                        u_sheet.GetRow(33).GetCell(2).SetCellValue("□數位訊號：")
                    End If

                    ' 17b 17a
                    If dtSPEC.Rows(0).Item("SPEC_DOCATTACH_INST").ToString.Trim = "True" Then
                        u_sheet.GetRow(26).GetCell(2).SetCellValue("■電子式電度表規格符合國家標準說明（如附件）")
                    Else
                        u_sheet.GetRow(26).GetCell(2).SetCellValue("□電子式電度表規格符合國家標準說明（如附件）")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_DOCATTACH_CALI").ToString.Trim = "True" Then
                        u_sheet.GetRow(27).GetCell(2).SetCellValue("■設施製造商校正方式及周期說明 （如附件）")
                    Else
                        u_sheet.GetRow(27).GetCell(2).SetCellValue("□設施製造商校正方式及周期說明 （如附件）")
                    End If

                    '19a b c

                    If dtSPEC.Rows(0).Item("SPEC_DO_HARDWARE_CONNECT").ToString.Trim = "True" Then
                        u_sheet.GetRow(34).GetCell(2).SetCellValue("■該數位介面之硬體連接方法說明（如附件）")
                    Else
                        u_sheet.GetRow(34).GetCell(2).SetCellValue("□該數位介面之硬體連接方法說明（如附件）")
                    End If
                    If dtSPEC.Rows(0).Item("SPEC_DO_HARDWARE_CONNPARA").ToString.Trim = "True" Then
                        u_sheet.GetRow(35).GetCell(2).SetCellValue("■該數位設備之連接參數資料（如附件）")
                    Else
                        u_sheet.GetRow(35).GetCell(2).SetCellValue("□該數位設備之連接參數資料（如附件）")
                    End If
                    If dtSPEC.Rows(0).Item("SPEC_DO_HARDWARE_DOC").ToString.Trim = "True" Then
                        u_sheet.GetRow(36).GetCell(2).SetCellValue("■引用此介面之相關功能文件（如附件）")
                    Else
                        u_sheet.GetRow(36).GetCell(2).SetCellValue("□引用此介面之相關功能文件（如附件）")
                    End If


                    u_sheet.GetRow(37).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_NOTE").ToString.Trim)

                    u_sheet.GetRow(38).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_PLCAGENT").ToString.Trim)

                    If dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "Modbus RTU" Then
                        u_sheet.GetRow(40).GetCell(2).SetCellValue("□Modbus TCP     ■Modbus RTU")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "Modbus TCP" Then
                        u_sheet.GetRow(40).GetCell(2).SetCellValue("■Modbus TCP     □Modbus RTU")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "RS-485" Then
                        u_sheet.GetRow(41).GetCell(2).SetCellValue("□RS-232          ■RS-485")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "RS-232" Then
                        u_sheet.GetRow(41).GetCell(2).SetCellValue("■RS-232          □RS-485")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "USB" Then
                        u_sheet.GetRow(42).GetCell(2).SetCellValue("■USB          □LPT")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "LPT" Then
                        u_sheet.GetRow(42).GetCell(2).SetCellValue("□USB          ■LPT")
                    End If

                    If dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "其他" Then
                        u_sheet.GetRow(43).GetCell(2).SetCellValue("■其他" + dtSPEC.Rows(0).Item("SPEC_COSPEC_NOTE").ToString.Trim)
                    End If

                    'u_sheet.GetRow(38).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim)


                    If dtSPEC.Rows(0).Item("SPEC_H_CHANGE").ToString.Trim = "否" Then
                        u_sheet.GetRow(44).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_H_CHANGE").ToString.Trim)
                    Else
                        u_sheet.GetRow(44).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_H_CHANGE").ToString.Trim + "，原因:" + dtSPEC.Rows(0).Item("SPEC_H_CHANGE_NOTE").ToString.Trim)
                    End If


                Next
            End If


            Dim dtDAHS As DataTable

            dtDAHS = dsRpt_DAHS.Tables(0)
            u_sheet = xlWorkBook.CloneSheet(3)
            Dim DAHSx As Integer = xlWorkBook.GetSheetIndex(u_sheet.SheetName)
            Dim DAHSstrSheetName As String = "叁、數據採擷及處理系統規劃說明"
            xlWorkBook.SetSheetName(DAHSx, DAHSstrSheetName)

            If dtDAHS.Rows.Count > 0 Then
                u_sheet.GetRow(1).GetCell(1).SetCellValue("(一)數據採擷及處理系統涵蓋監測位置編號：" + dtDAHS.Rows(0).Item("DP_NO").ToString.Trim)
                Try
                    u_sheet.GetRow(2).GetCell(2).SetCellValue(CDate(dtDAHS.Rows(0).Item("PLAN_INSDATE")))
                Catch ex As Exception

                End Try

                u_sheet.GetRow(3).GetCell(2).SetCellValue(dtDAHS.Rows(0).Item("AGENT").ToString.Trim)
                If dtDAHS.Rows(0).Item("REDANDUNT").ToString.Trim = "是" Then
                    u_sheet.GetRow(4).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(4).GetCell(2).SetCellValue("□是  ■否  ")
                End If
                If dtDAHS.Rows(0).Item("CONTROLROOM").ToString.Trim = "是" Then
                    u_sheet.GetRow(5).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(5).GetCell(2).SetCellValue("□是  ■否  ")
                End If
                If dtDAHS.Rows(0).Item("COLUD").ToString.Trim = "是" Then
                    u_sheet.GetRow(6).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(6).GetCell(2).SetCellValue("□是  ■否  ")
                End If
                If dtDAHS.Rows(0).Item("MAINTAINMETHOD").ToString.Trim = "自行保養" Then
                    u_sheet.GetRow(7).GetCell(2).SetCellValue("■自行保養   □委外保養")
                Else
                    u_sheet.GetRow(7).GetCell(2).SetCellValue("□自行保養   ■委外保養")
                End If

                If dtDAHS.Rows(0).Item("DOCATTACH").ToString.Trim = "True" Then

                    u_sheet.GetRow(8).GetCell(2).SetCellValue("■系統維修保養說明（如附件）")
                Else

                    u_sheet.GetRow(8).GetCell(2).SetCellValue("□系統維修保養說明（如附件）")
                End If


                If dtDAHS.Rows(0).Item("FITFREQ").ToString.Trim = "是" Then
                    u_sheet.GetRow(9).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(9).GetCell(2).SetCellValue("□是  ■否  ")
                End If

                If dtDAHS.Rows(0).Item("FITFORMAT").ToString.Trim = "是" Then
                    u_sheet.GetRow(10).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(10).GetCell(2).SetCellValue("□是  ■否  ")
                End If

                Try
                    u_sheet.GetRow(11).GetCell(2).SetCellValue(CDate(dtDAHS.Rows(0).Item("STAR168DATE")))
                Catch ex As Exception

                End Try

            End If

            Dim dtLINK As DataTable

            dtLINK = dsRpt_LINK.Tables(0)
            u_sheet = xlWorkBook.CloneSheet(4)
            Dim LINKx As Integer = xlWorkBook.GetSheetIndex(u_sheet.SheetName)
            Dim LINKstrSheetName As String = "連線傳輸設施"
            xlWorkBook.SetSheetName(LINKx, LINKstrSheetName)

            If dtLINK.Rows.Count > 0 Then

                u_sheet.GetRow(1).GetCell(1).SetCellValue("一)連線傳輸設施涵蓋監測位置編號：" + dtLINK.Rows(0).Item("DP_NO").ToString.Trim)
                u_sheet.GetRow(2).GetCell(2).SetCellValue("中央處理器:" + dtLINK.Rows(0).Item("CemsPCCpu").ToString.Trim)
                u_sheet.GetRow(3).GetCell(2).SetCellValue("記憶體:" + dtLINK.Rows(0).Item("CemsPCMem").ToString.Trim)
                u_sheet.GetRow(4).GetCell(2).SetCellValue("硬碟空間:" + dtLINK.Rows(0).Item("CemsPCHDD").ToString.Trim)
                u_sheet.GetRow(5).GetCell(2).SetCellValue("作業系統:" + dtLINK.Rows(0).Item("CemsPCOS").ToString.Trim)
                u_sheet.GetRow(2).GetCell(4).SetCellValue("網路卡:" + dtLINK.Rows(0).Item("CemsPCNetcard").ToString.Trim)
                u_sheet.GetRow(3).GetCell(4).SetCellValue("防毒軟體:" + dtLINK.Rows(0).Item("CemsPCAntiVirus").ToString.Trim)
                u_sheet.GetRow(4).GetCell(4).SetCellValue("防火牆:" + dtLINK.Rows(0).Item("CemsPCFirewall").ToString.Trim)

                If dtLINK.Rows(0).Item("NetworkLineType").ToString.Trim = "ADSL專線" Then
                    u_sheet.GetRow(6).GetCell(2).SetCellValue("監測紀錄值傳輸網路:■ADSL專線   □廠內既有網路  □不適用 ")
                ElseIf dtLINK.Rows(0).Item("NetworkLineType").ToString.Trim = "廠內既有網路" Then
                    u_sheet.GetRow(6).GetCell(2).SetCellValue("監測紀錄值傳輸網路:□ADSL專線   ■廠內既有網路  □不適用")
                Else
                    u_sheet.GetRow(6).GetCell(2).SetCellValue("監測紀錄值傳輸網路:□ADSL專線   □廠內既有網路  ■不適用")
                End If

                If dtLINK.Rows(0).Item("NetworkIPType").ToString.Trim = "伺服器固定IP位址" Then
                    u_sheet.GetRow(7).GetCell(2).SetCellValue(dtLINK.Rows(0).Item("NetworkIPType").ToString.Trim + ":" + dtLINK.Rows(0).Item("NetworkIP").ToString.Trim)
                Else
                    u_sheet.GetRow(7).GetCell(2).SetCellValue(dtLINK.Rows(0).Item("NetworkIPType").ToString.Trim)
                End If


                If dtLINK.Rows(0).Item("VideoLineType").ToString.Trim = "ADSL專線" Then
                    u_sheet.GetRow(8).GetCell(2).SetCellValue("攝錄影監視影像傳輸:■ADSL專線   □廠內既有網路  □不適用")
                ElseIf dtLINK.Rows(0).Item("VideoLineType").ToString.Trim = "廠內既有網路" Then
                    u_sheet.GetRow(8).GetCell(2).SetCellValue("攝錄影監視影像傳輸:□ADSL專線   ■廠內既有網路  □不適用")
                Else
                    u_sheet.GetRow(8).GetCell(2).SetCellValue("攝錄影監視影像傳輸:□ADSL專線   □廠內既有網路  ■不適用")
                End If

                If dtLINK.Rows(0).Item("VideoIPType").ToString.Trim = "伺服器固定IP位址" Then
                    u_sheet.GetRow(9).GetCell(2).SetCellValue(dtLINK.Rows(0).Item("VideoIPType").ToString.Trim + ":" + dtLINK.Rows(0).Item("VideoIP").ToString.Trim)
                Else
                    u_sheet.GetRow(9).GetCell(2).SetCellValue(dtLINK.Rows(0).Item("VideoIPType").ToString.Trim)
                End If


                If dtLINK.Rows(0).Item("NetworkPortNumber").ToString.Trim = "其他" Then
                    u_sheet.GetRow(10).GetCell(2).SetCellValue("PORT:" + dtLINK.Rows(0).Item("NetworkPortNumber").ToString.Trim + ":" + dtLINK.Rows(0).Item("NetworkPortNumberOther").ToString.Trim)
                Else
                    u_sheet.GetRow(10).GetCell(2).SetCellValue("PORT:" + dtLINK.Rows(0).Item("NetworkPortNumber").ToString.Trim)
                End If




                If dtLINK.Rows(0).Item("MaintainType").ToString.Trim = "自行保養" Then
                    u_sheet.GetRow(11).GetCell(2).SetCellValue("■自行保養   □委外保養")
                Else
                    u_sheet.GetRow(11).GetCell(2).SetCellValue("□自行保養   ■委外保養")
                End If

                If dtLINK.Rows(0).Item("CB_LINK_5A").ToString.Trim = "True" Then
                    u_sheet.GetRow(12).GetCell(3).SetCellValue("■設施製造商維修保養說明（如附件）")
                Else
                    u_sheet.GetRow(12).GetCell(3).SetCellValue("□設施製造商維修保養說明（如附件）")
                End If



                If dtLINK.Rows(0).Item("CB_LINK_5B").ToString.Trim = "True" Then
                    u_sheet.GetRow(13).GetCell(3).SetCellValue("■連線傳輸設施設置計畫書（如附件）")
                Else
                    u_sheet.GetRow(13).GetCell(3).SetCellValue("□連線傳輸設施設置計畫書（如附件）")
                End If



            End If
            '  LED

            Dim dtLED As DataTable

            dtLED = dsRpt_LED.Tables(0)
            u_sheet = xlWorkBook.CloneSheet(5)
            Dim LEDx As Integer = xlWorkBook.GetSheetIndex(u_sheet.SheetName)
            Dim LEDstrSheetName As String = "LED設施"
            xlWorkBook.SetSheetName(LEDx, LEDstrSheetName)

            If dtLED.Rows.Count > 0 Then

                If dtLED.Rows(0).Item("LED_INSTALL").ToString.Trim = "是" Then
                    u_sheet.GetRow(1).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(1).GetCell(2).SetCellValue("□是  ■否，原因:" + dtLED.Rows(0).Item("LED_INSTALL_REASON").ToString.Trim)
                End If

                u_sheet.GetRow(2).GetCell(2).SetCellValue(dtLED.Rows(0).Item("DP_NO").ToString.Trim)
                Try
                    u_sheet.GetRow(3).GetCell(2).SetCellValue(dtLED.Rows(0).Item("LED_PLAN_DATE").ToString.Trim)
                Catch ex As Exception

                End Try

                u_sheet.GetRow(4).GetCell(2).SetCellValue(dtLED.Rows(0).Item("LED_FACTORY").ToString.Trim)
                u_sheet.GetRow(5).GetCell(2).SetCellValue(dtLED.Rows(0).Item("LED_MODEL").ToString.Trim)
                u_sheet.GetRow(6).GetCell(2).SetCellValue(dtLED.Rows(0).Item("LED_SERIAL").ToString.Trim)

                If dtLED.Rows(0).Item("LED_TYPE").ToString.Trim = "TV" Then
                    u_sheet.GetRow(7).GetCell(2).SetCellValue("■TV  □LED □其他:")
                ElseIf dtLED.Rows(0).Item("LED_TYPE").ToString.Trim = "LED" Then
                    u_sheet.GetRow(7).GetCell(2).SetCellValue("□TV  ■LED □其他:")
                Else
                    u_sheet.GetRow(7).GetCell(2).SetCellValue("□TV  □LED ■其他:" + dtLED.Rows(0).Item("LED_TYPE_OTHER").ToString.Trim)
                End If

                If dtLED.Rows(0).Item("LED_INSTALLPOS").ToString.Trim = "是" Then
                    u_sheet.GetRow(8).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(8).GetCell(2).SetCellValue("□是  ■否，原因:" + dtLED.Rows(0).Item("LED_INSTALLPOS_REASON").ToString.Trim)
                End If

                If dtLED.Rows(0).Item("LED_SHOWITEM").ToString.Trim = "是" Then
                    u_sheet.GetRow(9).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(9).GetCell(2).SetCellValue("□是  ■否，原因:" + dtLED.Rows(0).Item("LED_SHOWITEM_REASON").ToString.Trim)
                End If

                If dtLED.Rows(0).Item("LED_FORMAT").ToString.Trim = "是" Then
                    u_sheet.GetRow(10).GetCell(2).SetCellValue("■是  □否  ")
                Else
                    u_sheet.GetRow(10).GetCell(2).SetCellValue("□是  ■否，原因:" + dtLED.Rows(0).Item("LED_FORMAT_REASON").ToString.Trim)
                End If

                If dtLED.Rows(0).Item("LED_FREQ").ToString.Trim = "是" Then
                    u_sheet.GetRow(11).GetCell(2).SetCellValue("■是  □否")
                Else
                    u_sheet.GetRow(11).GetCell(2).SetCellValue("□是  ■否")
                End If

                'u_sheet.GetRow(12).GetCell(2).SetCellValue(dtLED.Rows(0).Item("LED_FREQ").ToString.Trim)
                u_sheet.GetRow(12).GetCell(2).SetCellValue(dtLED.Rows(0).Item("LED_FAIL_INSTEAD").ToString.Trim)



                If dtLED.Rows(0).Item("LED_CONTENT").ToString.Trim = "是" Then
                    u_sheet.GetRow(14).GetCell(2).SetCellValue("■是  □否")
                Else
                    u_sheet.GetRow(14).GetCell(2).SetCellValue("□是  ■否")
                End If


            End If

            '附錄1

            Dim dtLP As DataTable

            dtLP = dsRpt_LP.Tables(0)
            u_sheet = xlWorkBook.CloneSheet(6)
            Dim LPx As Integer = xlWorkBook.GetSheetIndex(u_sheet.SheetName)
            Dim LPstrSheetName As String = "連線傳輸設施設置計畫書"
            xlWorkBook.SetSheetName(LPx, LPstrSheetName)

            If dtLP.Rows.Count > 0 Then

                u_sheet.GetRow(3).GetCell(0).SetCellValue("負責設置公司：" + dtLP.Rows(0).Item("SETCOMPANY").ToString.Trim)
                Try
                    u_sheet.GetRow(2).GetCell(1).SetCellValue(CDate(dtLP.Rows(0).Item("ITEM1_DATE").ToString.Trim))
                Catch ex As Exception

                End Try

                u_sheet.GetRow(4).GetCell(0).SetCellValue("負責設置人員：" + dtLP.Rows(0).Item("SETPEOPLE").ToString.Trim)
                'u_sheet.GetRow(4).GetCell(1).SetCellValue(CDate(dtLP.Rows(0).Item("ITEM2_DATE").ToString.Trim))
                Try
                    u_sheet.GetRow(5).GetCell(1).SetCellValue(CDate(dtLP.Rows(0).Item("ITEM3_DATE").ToString.Trim))
                Catch ex As Exception

                End Try
                Try
                    u_sheet.GetRow(7).GetCell(1).SetCellValue(CDate(dtLP.Rows(0).Item("ITEM4_1_DATE").ToString.Trim))
                Catch ex As Exception

                End Try

                Try
                    u_sheet.GetRow(8).GetCell(1).SetCellValue(CDate(dtLP.Rows(0).Item("ITEM4_2_DATE").ToString.Trim))
                Catch ex As Exception

                End Try

                Try
                    u_sheet.GetRow(9).GetCell(1).SetCellValue(CDate(dtLP.Rows(0).Item("ITEM4_3_DATE").ToString.Trim))
                Catch ex As Exception

                End Try

                Try
                    u_sheet.GetRow(10).GetCell(1).SetCellValue(CDate(dtLP.Rows(0).Item("ITEM4_4_DATE").ToString.Trim))
                Catch ex As Exception

                End Try

                Try
                    u_sheet.GetRow(11).GetCell(1).SetCellValue(CDate(dtLP.Rows(0).Item("ITEM4_5_DATE").ToString.Trim))
                Catch ex As Exception

                End Try



            End If



            '附錄2

            Dim dtCHECKLIST As DataTable

            dtCHECKLIST = dsRpt_CHECKLIST.Tables(0)
            u_sheet = xlWorkBook.CloneSheet(7)
            Dim CheckListx As Integer = xlWorkBook.GetSheetIndex(u_sheet.SheetName)
            Dim CheckListstrSheetName As String = "文件檢核表"
            xlWorkBook.SetSheetName(CheckListx, CheckListstrSheetName)

            If dtCHECKLIST.Rows.Count > 0 Then

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_COVER").ToString.Trim = "True" Then
                    u_sheet.GetRow(2).GetCell(0).SetCellValue("■申請表首頁")
                Else
                    u_sheet.GetRow(2).GetCell(0).SetCellValue("□申請表首頁")
                End If
                If dtCHECKLIST.Rows(0).Item("CB_CHECK_BASIC").ToString.Trim = "True" Then
                    u_sheet.GetRow(3).GetCell(0).SetCellValue("■基本資料")
                Else
                    u_sheet.GetRow(3).GetCell(0).SetCellValue("□基本資料")
                End If
                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC").ToString.Trim = "True" Then
                    u_sheet.GetRow(4).GetCell(0).SetCellValue("■自動監測（視）設施規劃說明")
                Else
                    u_sheet.GetRow(4).GetCell(0).SetCellValue("□自動監測（視）設施規劃說明")
                End If
                If dtCHECKLIST.Rows(0).Item("CB_CHECK_DAHS").ToString.Trim = "True" Then
                    u_sheet.GetRow(5).GetCell(0).SetCellValue("■數據採擷及處理系統規劃說明")
                Else
                    u_sheet.GetRow(5).GetCell(0).SetCellValue("□數據採擷及處理系統規劃說明")
                End If
                If dtCHECKLIST.Rows(0).Item("CB_CHECK_LINK").ToString.Trim = "True" Then
                    u_sheet.GetRow(6).GetCell(0).SetCellValue("■連線傳輸設施規劃說明")
                Else
                    u_sheet.GetRow(6).GetCell(0).SetCellValue("□連線傳輸設施規劃說明")
                End If
                If dtCHECKLIST.Rows(0).Item("CB_CHECK_LED").ToString.Trim = "True" Then
                    u_sheet.GetRow(7).GetCell(0).SetCellValue("■放流水水量、水質自動顯示看板規劃說明")
                Else
                    u_sheet.GetRow(7).GetCell(0).SetCellValue("□放流水水量、水質自動顯示看板規劃說明")
                End If
                If dtCHECKLIST.Rows(0).Item("CB_CHECK_BASIC_C1").ToString.Trim = "True" Then
                    u_sheet.GetRow(9).GetCell(0).SetCellValue("■負責人授權之證明文件及原因說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_BASIC_C1_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(9).GetCell(0).SetCellValue("□負責人授權之證明文件及原因說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C1").ToString.Trim = "True" Then
                    u_sheet.GetRow(11).GetCell(0).SetCellValue("■核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C1_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(11).GetCell(0).SetCellValue("□核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C2").ToString.Trim = "True" Then
                    u_sheet.GetRow(12).GetCell(0).SetCellValue("■監測設施同時監測其他位置之說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C2_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(12).GetCell(0).SetCellValue("□監測設施同時監測其他位置之說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C3").ToString.Trim = "True" Then
                    u_sheet.GetRow(13).GetCell(0).SetCellValue("■核准採行替代量測方式具體說明及報經主管機關核准採行之核准公文影本（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C3_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(13).GetCell(0).SetCellValue("□核准採行替代量測方式具體說明及報經主管機關核准採行之核准公文影本（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C4").ToString.Trim = "True" Then
                    u_sheet.GetRow(14).GetCell(0).SetCellValue("■監測設施有過濾器/前處理裝置之影響說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C4_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(14).GetCell(0).SetCellValue("□監測設施有過濾器/前處理裝置之影響說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C5").ToString.Trim = "True" Then
                    u_sheet.GetRow(15).GetCell(0).SetCellValue("■監測設施有產生廢液（材）之儲存清理方式說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C5_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(15).GetCell(0).SetCellValue("□監測設施有產生廢液（材）之儲存清理方式說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C6").ToString.Trim = "True" Then
                    u_sheet.GetRow(16).GetCell(0).SetCellValue("■監測設施製造商校正方式及周期說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C6_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(16).GetCell(0).SetCellValue("□監測設施製造商校正方式及周期說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C7").ToString.Trim = "True" Then
                    u_sheet.GetRow(17).GetCell(0).SetCellValue("■電子式電度表規格符合國家標準說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C7_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(17).GetCell(0).SetCellValue("□電子式電度表規格符合國家標準說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C8").ToString.Trim = "True" Then
                    u_sheet.GetRow(18).GetCell(0).SetCellValue("■監測設施輸出訊號格式之數位介面硬體連接方法說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C8_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(18).GetCell(0).SetCellValue("□監測設施輸出訊號格式之數位介面硬體連接方法說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C9").ToString.Trim = "True" Then
                    u_sheet.GetRow(19).GetCell(0).SetCellValue("■監測設施輸出訊號格式之數位設備連接參數資料（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C9_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(19).GetCell(0).SetCellValue("□監測設施輸出訊號格式之數位設備連接參數資料（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C10").ToString.Trim = "True" Then
                    u_sheet.GetRow(20).GetCell(0).SetCellValue("■監測設施輸出訊號格式引用介面之相關功能文件（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C10_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(20).GetCell(0).SetCellValue("□監測設施輸出訊號格式引用介面之相關功能文件（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C11").ToString.Trim = "True" Then
                    u_sheet.GetRow(21).GetCell(0).SetCellValue("■規劃各項自動監測（視）設施設置位置圖（與廢水處理設施相對位置）（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C11_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(21).GetCell(0).SetCellValue("□規劃各項自動監測（視）設施設置位置圖（與廢水處理設施相對位置）（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C12").ToString.Trim = "True" Then
                    u_sheet.GetRow(22).GetCell(0).SetCellValue("■規劃各項自動監測（視）設施設置位置圖（與廠區相對位置）（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_SPEC_C12_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(22).GetCell(0).SetCellValue("□規劃各項自動監測（視）設施設置位置圖（與廠區相對位置）（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_DAHS_C1").ToString.Trim = "True" Then
                    u_sheet.GetRow(24).GetCell(0).SetCellValue("■系統維修保養說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_DAHS_C1_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(24).GetCell(0).SetCellValue("□系統維修保養說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_DAHS_C2").ToString.Trim = "True" Then
                    u_sheet.GetRow(25).GetCell(0).SetCellValue("■規劃數據採擷及處理系統網路配置圖（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_DAHS_C2_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(25).GetCell(0).SetCellValue("□規劃數據採擷及處理系統網路配置圖（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_LINK_C1").ToString.Trim = "True" Then
                    u_sheet.GetRow(27).GetCell(0).SetCellValue("■連線傳輸設施製造商維修保養說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_LINK_C1_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(27).GetCell(0).SetCellValue("□連線傳輸設施製造商維修保養說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_LINK_C2").ToString.Trim = "True" Then
                    u_sheet.GetRow(28).GetCell(0).SetCellValue("■連線傳輸設施設置計畫書（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_LINK_C2_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(28).GetCell(0).SetCellValue("□連線傳輸設施設置計畫書（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_LINK_C3").ToString.Trim = "True" Then
                    u_sheet.GetRow(29).GetCell(0).SetCellValue("■規劃連線傳輸設施設置位置圖（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_LINK_C3_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(29).GetCell(0).SetCellValue("□規劃連線傳輸設施設置位置圖（附件          ）")
                End If

                'LED
                If dtCHECKLIST.Rows(0).Item("CB_CHECK_LED_C1").ToString.Trim = "True" Then
                    u_sheet.GetRow(31).GetCell(0).SetCellValue("■自動顯示看板故障或校正維護期間之替代方式說明（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_LED_C1_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(31).GetCell(0).SetCellValue("□自動顯示看板故障或校正維護期間之替代方式說明（附件          ）")
                End If

                If dtCHECKLIST.Rows(0).Item("CB_CHECK_LED_C2").ToString.Trim = "True" Then
                    u_sheet.GetRow(32).GetCell(0).SetCellValue("■規劃放流水水量、水質自動顯示看板設置位置圖（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_LED_C2_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(32).GetCell(0).SetCellValue("□規劃放流水水量、水質自動顯示看板設置位置圖（附件          ）")
                End If


                If dtCHECKLIST.Rows(0).Item("CB_CHECK_LED_C3").ToString.Trim = "True" Then
                    u_sheet.GetRow(32).GetCell(0).SetCellValue("■放流水水量、水質自動顯示看板預計設置位置之現場實景照片（附件" + dtCHECKLIST.Rows(0).Item("CB_CHECK_LED_C3_AT").ToString.Trim + "）")
                Else
                    u_sheet.GetRow(32).GetCell(0).SetCellValue("□放流水水量、水質自動顯示看板預計設置位置之現場實景照片（附件          ）")
                End If



            End If


            Dim dtSPEC_DPNO_Self As DataTable
            Dim dtSPEC_Self As DataTable

            dtSPEC_DPNO_Self = dsRpt_SPEC_DPNO_Self.Tables(0)

            If dtSPEC_DPNO_Self.Rows.Count > 0 Then

                For Each dr As DataRow In dtSPEC_DPNO_Self.Rows

                    u_sheet = xlWorkBook.CloneSheet(8)
                    Dim Ref4x_Self As Integer = xlWorkBook.GetSheetIndex(u_sheet.SheetName)
                    Dim Ref4str_Self_SheetName = "陸、" + dr.Item("DP_NO").ToString.Trim + "-" + dr.Item("ITEM").ToString.Trim
                    xlWorkBook.SetSheetName(Ref4x_Self, Ref4str_Self_SheetName)


                    Dim SqlTxt_REF4 As String = "select distinct * from DOC_SET_SPEC where cno='" + strCno + "' and Docversion='" + strDocVersion + "' and  DP_NO='" + dr.Item("DP_NO").ToString.Trim + "' and item='" + dr.Item("ITEM").ToString.Trim + "'"

                    Dim dsSPEC_Self As DataSet = GetDS(DBconntext, SqlTxt_REF4)
                    dtSPEC_Self = dsSPEC_Self.Tables(0)


                    u_sheet.GetRow(1).GetCell(1).SetCellValue(dtSPEC_Self.Rows(0).Item("DP_NO").ToString.Trim)

                    If dtSPEC_Self.Rows(0).Item("ITEM").ToString.Trim = "241" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■硝酸鹽氮")
                    ElseIf dtSPEC_Self.Rows(0).Item("ITEM").ToString.Trim = "267" Then
                        u_sheet.GetRow(2).GetCell(1).SetCellValue("■硼")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_INSTEAD_YES").ToString.Trim = "True" Then
                        u_sheet.GetRow(4).GetCell(2).SetCellValue("■是（核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本見附件）")
                    Else
                        u_sheet.GetRow(4).GetCell(2).SetCellValue("□是（核准採行替代措施具體說明及報經主管機關核准採行替代措施之核准公文影本見附件）")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_INSTEAD_NO").ToString.Trim = "True" Then
                        u_sheet.GetRow(5).GetCell(2).SetCellValue("■否")
                    Else
                        u_sheet.GetRow(5).GetCell(2).SetCellValue("□否")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_MONITOROTHER_YES").ToString.Trim = "True" Then
                        u_sheet.GetRow(6).GetCell(2).SetCellValue("■是，與監測位置編號：" + dtSPEC_Self.Rows(0).Item("SPEC_MO_NOTE_DPNO").ToString.Trim + "共設" + dtSPEC_Self.Rows(0).Item("SPEC_MO_NOTE_DPNO1").ToString.Trim + " 處（詳附件）")
                    Else
                        u_sheet.GetRow(6).GetCell(2).SetCellValue("□是，與監測位置編號：     共設   處（詳附件）")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_MONITOROTHER_NO").ToString.Trim = "True" Then
                        u_sheet.GetRow(7).GetCell(2).SetCellValue("■否")
                    Else
                        u_sheet.GetRow(7).GetCell(2).SetCellValue("□否")
                    End If

                    'SPEC_SAMPLE_METHOD

                    u_sheet.GetRow(12).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_SAMPLE_METHOD").ToString.Trim + "(" + dtSPEC_Self.Rows(0).Item("SPEC_SAMPLE_METHOD_DESP").ToString.Trim + "法)")



                    'SPEC_SAMPLE_METHOD_FILTERYES
                    If dtSPEC_Self.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERYES").ToString.Trim = "True" Then
                        u_sheet.GetRow(14).GetCell(2).SetCellValue("■有過濾器/前處理裝置；□無過濾器/前處理裝置")
                    ElseIf dtSPEC_Self.Rows(0).Item("SPEC_SAMPLE_METHOD_FILTERNO").ToString.Trim = "True" Then
                        u_sheet.GetRow(14).GetCell(2).SetCellValue("□有過濾器/前處理裝置；■無過濾器/前處理裝置")
                    Else
                        u_sheet.GetRow(14).GetCell(2).SetCellValue("□有過濾器/前處理裝置；□無過濾器/前處理裝置")
                    End If


                    Try
                        u_sheet.GetRow(8).GetCell(2).SetCellValue(CDate(dtSPEC_Self.Rows(0).Item("SPEC_INS_DATE")))
                    Catch ex As Exception

                    End Try

                    u_sheet.GetRow(9).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_AGENTNAME").ToString.Trim)
                    u_sheet.GetRow(10).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_EQU_MODEL").ToString.Trim)
                    u_sheet.GetRow(11).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_EQU_SERIAL").ToString.Trim)

                    u_sheet.GetRow(15).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_CALC_EQU").ToString.Trim)
                    '[SPEC_CALC_METHOD]
                    If dtSPEC_Self.Rows(0).Item("SPEC_CALC_METHOD").ToString.Trim = "擬自行校正" Then

                        u_sheet.GetRow(16).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_CALC_FREQ").ToString.Trim + ";■擬自行校正 □擬委外校正  □不適用")
                    ElseIf dtSPEC_Self.Rows(0).Item("SPEC_CALC_METHOD").ToString.Trim = "擬委外校正" Then
                        u_sheet.GetRow(16).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_CALC_FREQ").ToString.Trim + ";□擬自行校正 ■擬委外校正  □不適用")
                    ElseIf dtSPEC_Self.Rows(0).Item("SPEC_CALC_METHOD").ToString.Trim = "不適用" Then
                        u_sheet.GetRow(16).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_CALC_FREQ").ToString.Trim + ";□擬自行校正 □擬委外校正  ■不適用")

                    End If

                    '[SPEC_MAIN_METHOD]
                    If dtSPEC_Self.Rows(0).Item("SPEC_MAIN_METHOD").ToString.Trim = "擬自行保養" Then
                        u_sheet.GetRow(17).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_MAIN_FREQ").ToString.Trim + ";■擬自行校正 □擬委外校正")
                    Else
                        u_sheet.GetRow(17).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_MAIN_FREQ").ToString.Trim + "；□擬自行保養 ■擬委外保養")
                    End If

                    u_sheet.GetRow(18).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_MATERIAL").ToString.Trim)

                    If dtSPEC_Self.Rows(0).Item("SPEC_WASTELIQUID").ToString.Trim = "無產生廢液(材)" Then

                        u_sheet.GetRow(19).GetCell(2).SetCellValue("■無產生廢液(材)")
                        u_sheet.GetRow(20).GetCell(2).SetCellValue("□有產生廢液(材),儲存清理方式說明(詳附件)")
                    Else
                        u_sheet.GetRow(19).GetCell(2).SetCellValue("□無產生廢液(材)")
                        u_sheet.GetRow(20).GetCell(2).SetCellValue("■有產生廢液(材),儲存清理方式說明(詳附件)")

                    End If

                    u_sheet.GetRow(21).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_MATERIAL_FREQ").ToString.Trim)
                    u_sheet.GetRow(22).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_MEA_SCOPE").ToString.Trim + "（單位：" + dtSPEC_Self.Rows(0).Item("SPEC_MEA_SCOPEUNIT").ToString.Trim + ")")
                    u_sheet.GetRow(23).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_MEA_RESTIME").ToString.Trim + "（單位：" + dtSPEC_Self.Rows(0).Item("SPEC_MEA_RESTIMEUNIT").ToString.Trim + ")")
                    u_sheet.GetRow(24).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_MEA_FREQ").ToString.Trim + "（單位：" + dtSPEC_Self.Rows(0).Item("SPEC_MEA_FREQUNIT").ToString.Trim + ")")
                    u_sheet.GetRow(25).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_CALCAVG").ToString.Trim)


                    '影像格式：□ MPEG；□H.264；□AVI；□其他：

                    If dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F").ToString.Trim = "MPEG" Then
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：■ MPEG；□H.264；□AVI；□其他 ; □不適用：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    ElseIf dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F").ToString.Trim = "H.264" Then
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：□ MPEG；■H.264；□AVI；□其他 ; □不適用：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    ElseIf dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F").ToString.Trim = "AVI" Then
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：□ MPEG；□H.264；■AVI；□其他 ; □不適用：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    ElseIf dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F").ToString.Trim = "其他" Then
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：□ MPEG；□H.264；□AVI；■其他 ; □不適用：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    Else
                        u_sheet.GetRow(28).GetCell(2).SetCellValue("影像格式：□ MPEG；□H.264；□AVI；□其他 ; ■不適用：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_F_MEMO").ToString.Trim)
                    End If

                    '解析度：□640x480；□其他：        

                    If dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_R").ToString.Trim = "640X480" Then
                        u_sheet.GetRow(30).GetCell(2).SetCellValue("解析度：■640x480；□其他 ; □不適用 ：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString.Trim)
                    ElseIf dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_R").ToString.Trim = "其他" Then
                        u_sheet.GetRow(30).GetCell(2).SetCellValue("解析度：□640x480；■其他; □不適用 ：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString.Trim)
                    Else
                        u_sheet.GetRow(30).GetCell(2).SetCellValue("解析度：□640x480；□其他; ■不適用：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_R_MEMO").ToString.Trim)

                    End If

                    '夜視功能：□有；□無，請說明：

                    If dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_NV").ToString.Trim = "有" Then
                        u_sheet.GetRow(31).GetCell(2).SetCellValue("夜視功能：■有；□無 ; □不適用，請說明：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString.Trim)
                    ElseIf dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_NV").ToString.Trim = "無" Then
                        u_sheet.GetRow(31).GetCell(2).SetCellValue("夜視功能：□有；■無 ; □不適用，請說明：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString.Trim)
                    Else
                        u_sheet.GetRow(31).GetCell(2).SetCellValue("夜視功能：□有；□無 ; ■不適用，請說明：" + dtSPEC_Self.Rows(0).Item("SPEC_VIDEO_NV_MEMO").ToString.Trim)
                    End If


                    If dtSPEC_Self.Rows(0).Item("SPEC_ANASIG_YES").ToString.Trim = "True" Then
                        u_sheet.GetRow(32).GetCell(2).SetCellValue("■類比訊號：" + dtSPEC_Self.Rows(0).Item("SPEC_ANASIG").ToString.Trim)
                    Else
                        u_sheet.GetRow(32).GetCell(2).SetCellValue("□類比訊號：" + dtSPEC_Self.Rows(0).Item("SPEC_ANASIG").ToString.Trim)
                    End If


                    If dtSPEC_Self.Rows(0).Item("SPEC_DIGSIG_YES").ToString.Trim = "True" Then

                        u_sheet.GetRow(33).GetCell(2).SetCellValue("■數位訊號：" + dtSPEC_Self.Rows(0).Item("SPEC_DIGSIG").ToString.Trim)
                    Else

                        u_sheet.GetRow(33).GetCell(2).SetCellValue("□數位訊號：")
                    End If

                    ' 17b 17a
                    If dtSPEC_Self.Rows(0).Item("SPEC_DOCATTACH_INST").ToString.Trim = "True" Then
                        u_sheet.GetRow(26).GetCell(2).SetCellValue("■電子式電度表規格符合國家標準說明（如附件）")
                    Else
                        u_sheet.GetRow(26).GetCell(2).SetCellValue("□電子式電度表規格符合國家標準說明（如附件）")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_DOCATTACH_CALI").ToString.Trim = "True" Then
                        u_sheet.GetRow(27).GetCell(2).SetCellValue("■設施製造商校正方式及周期說明 （如附件）")
                    Else
                        u_sheet.GetRow(27).GetCell(2).SetCellValue("□設施製造商校正方式及周期說明 （如附件）")
                    End If

                    '19a b c

                    If dtSPEC_Self.Rows(0).Item("SPEC_DO_HARDWARE_CONNECT").ToString.Trim = "True" Then
                        u_sheet.GetRow(34).GetCell(2).SetCellValue("■該數位介面之硬體連接方法說明（如附件）")
                    Else
                        u_sheet.GetRow(34).GetCell(2).SetCellValue("□該數位介面之硬體連接方法說明（如附件）")
                    End If
                    If dtSPEC_Self.Rows(0).Item("SPEC_DO_HARDWARE_CONNPARA").ToString.Trim = "True" Then
                        u_sheet.GetRow(35).GetCell(2).SetCellValue("■該數位設備之連接參數資料（如附件）")
                    Else
                        u_sheet.GetRow(35).GetCell(2).SetCellValue("□該數位設備之連接參數資料（如附件）")
                    End If
                    If dtSPEC_Self.Rows(0).Item("SPEC_DO_HARDWARE_DOC").ToString.Trim = "True" Then
                        u_sheet.GetRow(36).GetCell(2).SetCellValue("■引用此介面之相關功能文件（如附件）")
                    Else
                        u_sheet.GetRow(36).GetCell(2).SetCellValue("□引用此介面之相關功能文件（如附件）")
                    End If


                    u_sheet.GetRow(37).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_NOTE").ToString.Trim)

                    u_sheet.GetRow(38).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_PLCAGENT").ToString.Trim)

                    If dtSPEC_Self.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "Modbus RTU" Then
                        u_sheet.GetRow(40).GetCell(2).SetCellValue("□Modbus TCP     ■Modbus RTU")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "Modbus TCP" Then
                        u_sheet.GetRow(40).GetCell(2).SetCellValue("■Modbus TCP     □Modbus RTU")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "RS-485" Then
                        u_sheet.GetRow(41).GetCell(2).SetCellValue("□RS-232          ■RS-485")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "RS-232" Then
                        u_sheet.GetRow(41).GetCell(2).SetCellValue("■RS-232          □RS-485")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "USB" Then
                        u_sheet.GetRow(42).GetCell(2).SetCellValue("■USB          □LPT")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "LPT" Then
                        u_sheet.GetRow(42).GetCell(2).SetCellValue("□USB          ■LPT")
                    End If

                    If dtSPEC_Self.Rows(0).Item("SPEC_COSPEC").ToString.Trim = "其他" Then
                        u_sheet.GetRow(43).GetCell(2).SetCellValue("■其他" + dtSPEC_Self.Rows(0).Item("SPEC_COSPEC_NOTE").ToString.Trim)
                    End If

                    'u_sheet.GetRow(38).GetCell(2).SetCellValue(dtSPEC.Rows(0).Item("SPEC_COSPEC").ToString.Trim)


                    If dtSPEC_Self.Rows(0).Item("SPEC_H_CHANGE").ToString.Trim = "否" Then
                        u_sheet.GetRow(44).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_H_CHANGE").ToString.Trim)
                    Else
                        u_sheet.GetRow(44).GetCell(2).SetCellValue(dtSPEC_Self.Rows(0).Item("SPEC_H_CHANGE").ToString.Trim + "，原因:" + dtSPEC.Rows(0).Item("SPEC_H_CHANGE_NOTE").ToString.Trim)
                    End If


                Next
            End If


            Dim fn As String = ""
            Dim strFN1 As String = "tmp/" + strCno + "/" + "Report_SET_" & "TEST" & ".xls"
            Dim strFN2 As String = "tmp/" + strCno + "/" + "Report_SET_" & strResultFileName & ".pdf"

            'File.Delete(Server.MapPath(strFN1))
            'File.Delete(Server.MapPath(strFN2))


            'write to EXCEL
            Dim FS1 As FileStream = New FileStream(Server.MapPath(strFN1), FileMode.Create)
            xlWorkBook.Write(FS1)
            FS1.Close()
            FS1.Dispose()
            System.Threading.Thread.Sleep(3000)

            Dim fs2 As FileStream = New FileStream(Server.MapPath(strFN1), FileMode.Open, FileAccess.Read)
            Dim xlWorkBook_Reopen As HSSFWorkbook = New HSSFWorkbook(fs2)
            Dim ms2 As MemoryStream = New MemoryStream()  '==需要 System.IO命名空間 

            For i = 0 To 8
                xlWorkBook_Reopen.RemoveSheetAt(0)
            Next

            File.Delete(Server.MapPath(strFN1))

            Dim FS3 As FileStream = New FileStream(Server.MapPath(strFN1), FileMode.Create)
            xlWorkBook_Reopen.Write(FS3)
            FS3.Close()
            FS3.Dispose()
            System.Threading.Thread.Sleep(1000)

            'write to PDF
            Dim workbook As New Workbook()
            workbook.LoadDocument((Server.MapPath(strFN1)))
            workbook.ExportToPdf(Server.MapPath(strFN2))
            System.Threading.Thread.Sleep(1000)

            If strPrintType = "NOATTACH" Then


                Dim path As String = (Server.MapPath(strFN2))
                Dim client As New WebClient()
                Dim buffer As [Byte]() = client.DownloadData(path)

                If buffer IsNot Nothing Then
                    Response.ContentType = "application/octet-stream"
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "Report_SET_" + strCno + "_" + strDocVersion + ".pdf")
                    Response.BinaryWrite(buffer)
                    Response.End()

                End If
            End If



            'Response.Redirect("~\tmp\" & strFN2)
            'Response.Flush()
            'Response.End()


            '== 釋放資源 
            xlWorkBook = Nothing   '== C#為 null 
            'xlWorkBook_Reopen = Nothing
            ms.Close()
            ms.Dispose()
            'ms2.Close()
            'ms2.Dispose()

            'Label_Audit.Text = "資料處理完畢"

        Catch ex As Exception

            'Label_Audit.Text = ex.ToString


        End Try



    End Sub






    Protected Sub ASPxButton1_Click(sender As Object, e As EventArgs) Handles ASPxButton1.Click

        Dim pdflist(1000) As String
        Dim strRandon As String = Session("CNO") + "_" + Session("DOCVERSION").ToString.Trim + "_" + Now.Year.ToString + Now.Month.ToString + Now.Day.ToString + Now.Hour.ToString + Now.Minute.ToString + Now.Millisecond.ToString

        Try
            Directory.Delete(Server.MapPath("tmp/" + Session("CNO")), True)
        Catch ex As Exception

        End Try

        Try
            '建立暫存目錄供輸出PDF使用
            Directory.CreateDirectory(Server.MapPath("tmp/" + Session("CNO")))
        Catch ex As Exception

        End Try


        If RBL_SEL.SelectedIndex = 0 Then
            '只印本體
            Try
                ToExcel(Session("CNO"), Session("DOCVERSION"), "NOATTACH", strRandon)
            Catch ex As Exception

            End Try


        Else
            '本體加附件
            'Create private directory 
            'Exit Sub

            Try
                ToExcel(Session("CNO"), Session("DOCVERSION"), "WITHATTACH", strRandon)

                Dim strSQL As String = ""
                strSQL = "Select distinct b.FileName  from [DOC_PDF_BASIC] b inner join [DOC_SET_PDF] a On a.CNO=b.CNO And a.DocVersion=b.DocVersion where b.cno='" + Session("CNO") + "'  and b.DocVersion='" + Session("DOCVERSION").ToString.Trim + "' and right(b.FileName,3) <> 'jpg'"
                Dim ds_Report As DataSet = GetDS(DBconntext, strSQL)
                Dim dtReport As DataTable

                dtReport = ds_Report.Tables(0)
                Dim i As Integer = 1

                DownLoadPDF(Session("CNO"), Session("DOCVERSION"))

                pdflist(0) = "tmp/" + Session("CNO").ToString + "/" + "Report_SET_" + strRandon + ".pdf"

                If dtReport.Rows.Count > 0 Then
                    For Each dr As DataRow In dtReport.Rows
                        'pdflist(i) = "PDFUPLOAD/SET/" + dr.Item("FileName").ToString.Trim()
                        pdflist(i) = "tmp/" + Session("CNO").ToString + "/" + dr.Item("FileName").ToString.Trim()
                        i = i + 1
                    Next
                End If

                '合併
                Dim fn As String = RandomNumber(1000, 9999)

                'mergePDFFiles(pdflist, "tmp/" + Session("CNO") & fn & "_final.pdf", i)
                mergePDFFiles(pdflist, "tmp/" + strRandon + "_final.pdf", i)


                '輸出PDF

                'Dim path As String = (Server.MapPath("tmp/" + Session("CNO") & fn & "_final.pdf"))
                Dim path As String = (Server.MapPath("tmp/" + strRandon + "_final.pdf"))
                Dim client As New WebClient()
                Dim buffer As [Byte]() = client.DownloadData(path)

                If buffer IsNot Nothing Then
                    Response.ContentType = "application/octet-stream"
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "Report_Merge.pdf")
                    Response.BinaryWrite(buffer)
                    Response.End()

                End If

                Response.Redirect("~\tmp\" & "tmp/Report_MergePDF.pdf")
            Catch ex As Exception

            End Try


        End If

        'System.IO.File.Delete(Server.MapPath("tmp/" + Session("CNO") + "final.pdf"))

    End Sub

    Private Function RandomNumber(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim random As New Random()
        Return random.Next(min, max)
    End Function 'RandomNumber 

    Private Sub mergePDFFiles(ByVal fileList() As String, ByVal outMergeFile As String, ByVal strloop As Integer)

        Try
            outMergeFile = Server.MapPath(outMergeFile)
            Dim reader As PdfReader
            Dim document As iTextSharp.text.Document = New iTextSharp.text.Document
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(outMergeFile, FileMode.Create))

            Dim rotation As Integer

            document.Open()

            Dim cb As PdfContentByte = writer.DirectContent
            Dim newpage As PdfImportedPage
            Dim i As Integer

            For i = 0 To strloop - 1 Step i + 1

                reader = New PdfReader(Server.MapPath(fileList(i)).ToString)
                Dim iPageNum As Integer = reader.NumberOfPages
                Dim j As Integer
                For j = 1 To iPageNum
                    document.SetPageSize((reader.GetPageSizeWithRotation(j)))
                    document.NewPage()
                    newpage = writer.GetImportedPage(reader, j)
                    rotation = reader.GetPageRotation(j)

                    Select Case rotation
                        Case "0"
                            cb.AddTemplate(newpage, 1.0F, 0, 0, 1.0F, 0, 0)
                        Case "90"
                            cb.AddTemplate(newpage, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(iPageNum).Height)
                        Case "180"
                            cb.AddTemplate(newpage, -1.0F, 0, 0, -1.0F, reader.GetPageSizeWithRotation(iPageNum).Width, reader.GetPageSizeWithRotation(iPageNum).Height)
                        Case "270"
                            cb.AddTemplate(newpage, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(iPageNum).Height)
                    End Select
                Next
            Next

            document.Close()
        Catch ex As Exception

        Finally

        End Try


    End Sub

    Protected Sub BT_RETURN_Click(sender As Object, e As EventArgs) Handles BT_RETURN.Click


        Server.Transfer("MainList.aspx")


    End Sub


    Public Function DownLoadPDF(ByVal TempCno As String, ByVal TempDocVersion As String) As String

        Dim getresult As DbResult
        Dim Sqlstr As String = ""
        Dim FileName As String = ""

        Sqlstr = "Select pdffile,filename from DOC_PDF_BASIC where   cno='" + TempCno + "' and  DocVersion='" + TempDocVersion + "'"

        Try

            getresult = EIPDB.GetData(Sqlstr)

            If getresult.ReturnCode >= 1 Then

                Dim temp As Byte()

                For i = 0 To getresult.returnDataTable.Rows.Count
                    temp = getresult.returnDataTable.Rows(i).Item("pdffile")
                    FileName = getresult.returnDataTable.Rows(i).Item("filename")

                    Dim path As String = (Server.MapPath("tmp/" + TempCno + "/" + FileName))
                    Dim fs As New FileStream(path, FileMode.Create)
                    Dim bw As New BinaryWriter(fs)
                    bw.Write(temp)
                    bw.Close()
                    fs.Close()

                Next
            Else

                DownLoadPDF = "無檔案"

            End If

        Catch ex As Exception


        End Try

    End Function








End Class