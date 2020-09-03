Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Configuration
Imports System
Imports System.Data.SqlClient


Public Class EIPDB
    '從Web.config取得連線字串
    Shared conn As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("CWMSConnectionString").ConnectionString)
    Shared connPermit As New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("PermitConnectionString").ConnectionString)



    Public Shared Function GetCNOStatus(ByVal MyDocType As String, MyCNO As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select *  from DOC_SET_ITEM where cno='" + Trim(MyCNO) + "' "
        Else
            Sqlstr = "Select *  from DOC_VRY_ITEM where cno='" + Trim(MyCNO) + "' "
        End If


        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetCNOStatus = "TRUE"
            Else
                GetCNOStatus = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return GetCNOStatus


    End Function

    Public Shared Function CopySpecItemStatus(ByVal MyDocType As String, ByVal MyCNO As String, ByVal MyDPNO As String, ByVal MyItem As String, ByVal MyDocVersion As String) As String

        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "INSERT INTO  DOC_SET_SPEC (CNO,DP_NO,DOCVERSION,ITEM ) VALUES ('" + Trim(MyCNO) + "' ,'" + Trim(MyDPNO) + "','" + mydocversion + "','" + MyItem + "')"
        Else
            Sqlstr = "INSERT INTO  DOC_VRY_SPEC (CNO,DP_NO,DOCVERSION,ITEM ) VALUES ('" + Trim(MyCNO) + "' ,'" + Trim(MyDPNO) + "','" + mydocversion + "','" + MyItem + "')"
        End If


        Try

            getresult = EIPDB.Execute(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                CopySpecItemStatus = "TRUE"
            Else
                CopySpecItemStatus = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return CopySpecItemStatus


    End Function


    Public Shared Function GetSpecItemStatus(ByVal MyDocType As String, ByVal MyCNO As String, ByVal MyDPNO As String) As String
        Dim getresult As DbResult

        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select *  from DOC_SET_SPEC where cno='" + Trim(MyCNO) + "' and dp_no='" + Trim(MyDPNO) + "'"
        Else
            Sqlstr = "Select *  from DOC_VRY_SPEC where cno='" + Trim(MyCNO) + "' and dp_no='" + Trim(MyDPNO) + "'"
        End If


        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetSpecItemStatus = "TRUE"
            Else
                GetSpecItemStatus = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return GetSpecItemStatus


    End Function


    Public Shared Function GetItemStatus(ByVal MyDocType As String, MyCNO As String) As String
        Dim getresult As DbResult

        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select *  from DOC_SET_ITEM where cno='" + Trim(MyCNO) + "' "
        Else
            Sqlstr = "Select *  from DOC_VRY_ITEM where cno='" + Trim(MyCNO) + "' "
        End If


        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                GetItemStatus = "TRUE"
            Else
                GetItemStatus = "FALSE"

            End If

        Catch ex As Exception

        End Try

        Return GetItemStatus


    End Function



    Public Shared Function GetDocVersion(ByVal MyDocType As String, MyCNO As String) As Integer
        Dim getresult As DbResult
        Dim mydocversion As Integer
        Dim Sqlstr As String = ""

        If MyDocType = "SET" Then
            Sqlstr = "Select max(DOCVERSION) AS DOCVERSION from DOC_SET_FACTORY where cno='" + Trim(MyCNO) + "' "
        Else
            Sqlstr = "Select max(DOCVERSION) AS DOCVERSION from DOC_VRY_FACTORY where cno='" + Trim(MyCNO) + "' "
        End If


        Try

            getresult = EIPDB.GetData(Sqlstr)
            If getresult.returnDataTable.Rows.Count > 0 Then
                mydocversion = CInt(getresult.returnDataTable.Rows(0).Item("DOCVERSION").ToString)
            Else
                mydocversion = 0

            End If

        Catch ex As Exception

        End Try

        Return mydocversion


    End Function

    Public Shared Function Execute(ByVal sql As String) As DbResult
        '以SqlCommand執行特定SQL指令
        Dim sqlCmd As New SqlClient.SqlCommand
        If conn.State <> ConnectionState.Open Then conn.Open()
        sqlCmd.Connection = conn
        sqlCmd.CommandText = sql

        Dim DbResult As New DbResult
        Try
            '傳回有多少筆資料被影響
            DbResult.ReturnCode = sqlCmd.ExecuteNonQuery()
            DbResult.ExceptionMessage = ""
            DbResult.returnDataTable = Nothing
            DbResult.Success = True
            Return DbResult
        Catch ex As Exception
            '如果發生錯誤
            DbResult.ExceptionMessage = ex.Message
            DbResult.ReturnCode = -1
            DbResult.Success = False
            DbResult.returnDataTable = Nothing
            Return DbResult
        End Try

    End Function


    ''' <summary>
    ''' 執行SQL命令
    ''' </summary>
    ''' <param name="sqlCmd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Execute(ByVal sqlCmd As SqlClient.SqlCommand) As DbResult
        If conn.State <> ConnectionState.Open Then conn.Open()
        sqlCmd.Connection = conn

        Dim DbResult As New DbResult
        Try
            '傳回有多少筆資料被影響
            DbResult.ReturnCode = sqlCmd.ExecuteNonQuery()
            DbResult.ExceptionMessage = ""
            DbResult.returnDataTable = Nothing
            DbResult.Success = True
            Return DbResult
        Catch ex As Exception
            '如果發生錯誤
            DbResult.ExceptionMessage = ex.Message
            DbResult.ReturnCode = -1
            DbResult.Success = False
            DbResult.returnDataTable = Nothing
            Return DbResult
        End Try

    End Function

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

    Public Shared Function GetPermitData(ByVal sql As String) As DbResult
        Dim dt As New DataTable
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(sql, connPermit)

        Dim DbResult As New DbResult
        Try
            da.Fill(dt)
            If dt Is Nothing Then

                DbResult.ReturnCode = -1
                DbResult.ExceptionMessage = "Data Table is nothing"
                DbResult.returnDataTable = Nothing
                DbResult.Success = False
                Return DbResult
            End If
            DbResult.ReturnCode = dt.Rows.Count
            DbResult.ExceptionMessage = ""
            DbResult.returnDataTable = dt
            DbResult.Success = True
            Return DbResult
        Catch ex As Exception
            '如果發生錯誤
            DbResult.ExceptionMessage = ex.Message
            DbResult.ReturnCode = -1
            DbResult.Success = False
            DbResult.returnDataTable = Nothing
            Return DbResult
        End Try
    End Function


    ''' <summary>
    ''' 取得資料
    ''' </summary>
    ''' <param name="sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetData(ByVal sql As String) As DbResult
        Dim dt As New DataTable
        Dim da As SqlClient.SqlDataAdapter = New SqlClient.SqlDataAdapter(sql, conn)

        Dim DbResult As New DbResult
        Try
            da.Fill(dt)
            If dt Is Nothing Then

                DbResult.ReturnCode = -1
                DbResult.ExceptionMessage = "Data Table is nothing"
                DbResult.returnDataTable = Nothing
                DbResult.Success = False
                Return DbResult
            End If
            DbResult.ReturnCode = dt.Rows.Count
            DbResult.ExceptionMessage = ""
            DbResult.returnDataTable = dt
            DbResult.Success = True
            Return DbResult
        Catch ex As Exception
            '如果發生錯誤
            DbResult.ExceptionMessage = ex.Message
            DbResult.ReturnCode = -1
            DbResult.Success = False
            DbResult.returnDataTable = Nothing
            Return DbResult
        End Try
    End Function
End Class

'回傳執行結果
Public Class DbResult
    '是否成功
    Public Success As Boolean
    '回傳碼(被影響的筆數)
    Public ReturnCode As Integer
    '資料表(或view)
    Public returnDataTable As Data.DataTable
    '錯誤訊息
    Public ExceptionMessage As String
End Class
