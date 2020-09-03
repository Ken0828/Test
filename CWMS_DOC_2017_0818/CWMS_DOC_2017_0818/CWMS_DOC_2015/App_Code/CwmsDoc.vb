Public Class CwmsDocLib


    Public Shared Function GetCNOInfo(MyCNO As String) As String
        Dim getresult As DbResult
        Dim Sqlstr As String = ""

        Try

            Sqlstr = "Select  distinct abbr  from wpf where cno='" + Trim(MyCNO) + "' "
            getresult = EIPDB.GetData(Sqlstr)

            If getresult.returnDataTable.Rows.Count > 0 Then
                GetCNOInfo = getresult.returnDataTable.Rows(0).Item(0).ToString
            Else
                GetCNOInfo = "FALSE"
            End If

        Catch ex As Exception

        End Try

        Return GetCNOInfo




    End Function



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

    Public Shared Function CopySetDocToNextVersion(MyCNO As String, ByVal MyDOCVersion As Integer) As String

        Dim getresult As DbResult
        Dim CopyVry_FacSqlstr As String = "INSERT INTO DOC_VRY_FACTORY SELECT * FROM DOC_SET_FACTORY WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_ItemSqlstr As String = "INSERT INTO DOC_VRY_ITEM SELECT * FROM DOC_SET_ITEM WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LinkSqlstr As String = "INSERT INTO DOC_VRY_LINK SELECT * FROM DOC_SET_LINK WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_SPECSqlstr As String = "INSERT INTO DOC_VRY_SPEC ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO], [SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) SELECT * FROM DOC_SET_SPEC WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_DAHSSqlstr As String = "INSERT INTO DOC_VRY_DAHS SELECT * FROM DOC_SET_DAHS WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"




        Try

            getresult = EIPDB.Execute(CopyVry_FacSqlstr)
            getresult = EIPDB.Execute(CopyVry_ItemSqlstr)
            getresult = EIPDB.Execute(CopyVry_LinkSqlstr)
            getresult = EIPDB.Execute(CopyVry_SPECSqlstr)
            getresult = EIPDB.Execute(CopyVry_DAHSSqlstr)

            CopySetDocToNextVersion = "TRUE"
        Catch ex As Exception

        End Try

        Return CopySetDocToNextVersion


    End Function



    Public Shared Function CopySetDoc(MyCNO As String, ByVal MyDOCVersion As Integer) As String

        Dim getresult As DbResult

        Dim CopyVry_FacSqlstr As String = "INSERT INTO DOC_VRY_FACTORY SELECT * FROM DOC_SET_FACTORY WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_ItemSqlstr As String = "INSERT INTO DOC_VRY_ITEM SELECT * FROM DOC_SET_ITEM WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_LinkSqlstr As String = "INSERT INTO DOC_VRY_LINK SELECT * FROM DOC_SET_LINK WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_SPECSqlstr As String = "INSERT INTO DOC_VRY_SPEC ([CNO], [DP_NO], [DPTYPE], [DOCVERSION], [ITEM], [DPNO_DESP], [SPEC_INSTEAD_YES],[SPEC_INSTEAD_NO], [SPEC_MONITOROTHER_YES],[SPEC_MONITOROTHER_NO], [SPEC_MO_NOTE_DPNO], [SPEC_MO_NOTE_DPNO1], [SPEC_MO_NOTE_QUA], [SPEC_INS_DATE], [SPEC_AGENTNAME], [SPEC_EQU_MODEL], [SPEC_EQU_SERIAL], [SPEC_SAMPLE_METHOD], [SPEC_SAMPLE_METHOD_FILTERYES], [SPEC_SAMPLE_METHOD_FILTERNO], [SPEC_CALC_EQU], [SPEC_CALC_FREQ], [SPEC_CALC_METHOD], [SPEC_MAIN_FREQ], [SPEC_MAIN_METHOD], [SPEC_MATERIAL], [SPEC_WASTELIQUID], [SPEC_MATERIAL_FREQ], [SPEC_MEA_SCOPE], [SPEC_MEA_SCOPEUNIT], [SPEC_MEA_RESTIME], [SPEC_MEA_RESTIMEUNIT], [SPEC_MEA_FREQ], [SPEC_MEA_FREQUNIT], [SPEC_CALCAVG], [SPEC_DOCATTACH_INST], [SPEC_DOCATTACH_CALI], [SPEC_VIDEO_F], [SPEC_VIDEO_F_MEMO], [SPEC_VIDEO_R], [SPEC_VIDEO_R_MEMO], [SPEC_VIDEO_NV], [SPEC_VIDEO_NV_MEMO], [SPEC_ANASIG_YES], [SPEC_ANASIG], [SPEC_DIGSIG_YES], [SPEC_DIGSIG], [SPEC_DO_HARDWARE_CONNECT], [SPEC_DO_HARDWARE_CONNPARA], [SPEC_DO_HARDWARE_DOC], [SPEC_PLCAGENT], [SPEC_COSPEC], [SPEC_H_CHANGE], [SPEC_H_CHANGE_NOTE], [C_ID], [C_DATE], [U_ID], [U_DATE]) SELECT * FROM DOC_SET_SPEC WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"
        Dim CopyVry_DAHSSqlstr As String = "INSERT INTO DOC_VRY_DAHS SELECT * FROM DOC_SET_DAHS WHERE CNO='" + MyCNO + "' AND DOCVERSION='" + MyDOCVersion.ToString + "'"

        Try

            getresult = EIPDB.Execute(CopyVry_FacSqlstr)
            getresult = EIPDB.Execute(CopyVry_ItemSqlstr)
            getresult = EIPDB.Execute(CopyVry_LinkSqlstr)
            getresult = EIPDB.Execute(CopyVry_SPECSqlstr)
            getresult = EIPDB.Execute(CopyVry_DAHSSqlstr)

            CopySetDoc = "TRUE"
        Catch ex As Exception

        End Try

        Return CopySetDoc


    End Function


    Public Shared Function GetCountryOwner(ByVal MyCno As String, ByVal MyID As String) As Boolean

        Dim QueryResult As Boolean = False

        Select Case MyID

            Case "A"
                If Left(MyCno, 1) = "A" Then QueryResult = True
            Case "B"
                If Left(MyCno, 1) = "B" Or "L" Then QueryResult = True
            Case "C"
                If Left(MyCno, 1) = "C" Then QueryResult = True
            Case "D"
                If Left(MyCno, 1) = "D" Or "R" Then QueryResult = True
            Case "E"
                If Left(MyCno, 1) = "E" Or "S" Then QueryResult = True
            Case "F"
                If Left(MyCno, 1) = "F" Then QueryResult = True
            Case "G"
                If Left(MyCno, 1) = "G" Then QueryResult = True
            Case "H"
                If Left(MyCno, 1) = "H" Then QueryResult = True
            Case "I"
                If Left(MyCno, 1) = "I" Then QueryResult = True
            Case "J"
                If Left(MyCno, 1) = "J" Then QueryResult = True
            Case "K"
                If Left(MyCno, 1) = "K" Then QueryResult = True
            Case "L"
                If Left(MyCno, 1) = "L" Or "B" Then QueryResult = True
            Case "M"
                If Left(MyCno, 1) = "M" Then QueryResult = True
            Case "N"
                If Left(MyCno, 1) = "N" Then QueryResult = True
            Case "O"
                If Left(MyCno, 1) = "O" Then QueryResult = True
            Case "P"
                If Left(MyCno, 1) = "P" Then QueryResult = True
            Case "Q"
                If Left(MyCno, 1) = "Q" Then QueryResult = True
            Case "R"
                If Left(MyCno, 1) = "R" Or Left(MyCno, 1) = "D" Then QueryResult = True
            Case "S"
                If Left(MyCno, 1) = "S" Or Left(MyCno, 1) = "E" Then QueryResult = True
            Case "T"
                If Left(MyCno, 1) = "T" Then QueryResult = True
            Case "U"
                If Left(MyCno, 1) = "U" Then QueryResult = True
            Case "V"
                If Left(MyCno, 1) = "V" Then QueryResult = True
            Case "X"
                If Left(MyCno, 1) = "X" Then QueryResult = True
            Case "W"
                If Left(MyCno, 1) = "W" Then QueryResult = True
            Case "Z"
                If Left(MyCno, 1) = "Z" Then QueryResult = True

        End Select

        Return QueryResult


    End Function


    Public Shared Function ReturnEPBOwner(ByVal MyCno As String) As String

        Dim QueryResult As String = ""
        Dim myid As String = Left(MyCno, 1)

        Select Case myid

            Case "A"
                If Left(MyCno, 1) = "A" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "B"
                If Left(MyCno, 1) = "B" Or "L" Then QueryResult = "EPBB"
            Case "C"
                If Left(MyCno, 1) = "C" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "D"
                If Left(MyCno, 1) = "D" Or "R" Then QueryResult = "EPBD"
            Case "E"
                If Left(MyCno, 1) = "E" Or "S" Then QueryResult = "EPBE"
            Case "F"
                If Left(MyCno, 1) = "F" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "G"
                If Left(MyCno, 1) = "G" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "H"
                If Left(MyCno, 1) = "H" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "I"
                If Left(MyCno, 1) = "I" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "J"
                If Left(MyCno, 1) = "J" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "K"
                If Left(MyCno, 1) = "K" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "L"
                If Left(MyCno, 1) = "L" Or "B" Then QueryResult = "EPBB"
            Case "M"
                If Left(MyCno, 1) = "M" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "N"
                If Left(MyCno, 1) = "N" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "O"
                If Left(MyCno, 1) = "O" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "P"
                If Left(MyCno, 1) = "P" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "Q"
                If Left(MyCno, 1) = "Q" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "R"
                If Left(MyCno, 1) = "R" Or Left(MyCno, 1) = "D" Then QueryResult = "EPBD"
            Case "S"
                If Left(MyCno, 1) = "S" Or Left(MyCno, 1) = "E" Then QueryResult = "EPBE"
            Case "T"
                If Left(MyCno, 1) = "T" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "U"
                If Left(MyCno, 1) = "U" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "V"
                If Left(MyCno, 1) = "V" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "X"
                If Left(MyCno, 1) = "X" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "W"
                If Left(MyCno, 1) = "W" Then QueryResult = "EPB" + Left(MyCno, 1)
            Case "Z"
                If Left(MyCno, 1) = "Z" Then QueryResult = "EPB" + Left(MyCno, 1)

        End Select

        Return QueryResult


    End Function

End Class
