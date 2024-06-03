Imports System.Data.OleDb
'Imports Excel = Microsoft.Office.Interop.Excel

Public Class EXCEL_MANIPULATIONS



    'Public Shared Function read_existing_data_to_grid() As DataTable
    '    Dim dt As DataTable
    '    Dim pp As String = HttpContext.Current.Application("fname")
    '    dt = getExcelDataIntoDataTable(pp, 1, 3, 17, 1, 5)
    '    Return dt
    'End Function
    'Public Shared Sub iterate_thr_excel_data()
    '    Dim dt As ArrayList
    '    For ws As Integer = 1 To 3
    '        For irows As Integer = 7 To 17
    '            dt = getExcelRowOrColumnDataIntoArrayList("c:\portfolio.xlsx", ws, 2, 5, "row", irows)
    '            For Each element In dt
    '                Console.Write(element & "     ")
    '            Next
    '            Console.WriteLine()
    '            dt.Clear()
    '        Next
    '    Next

    '    Console.ReadKey()

    'End Sub
    Public Sub WriteToCSV()
        Dim FN As Integer = FreeFile()
        FileOpen(FN, "C:\NEWW.csv", OpenMode.Append)
        For I As Integer = 1 To 200
            WriteLine(FN, I, I + 2, I + 4)
        Next
        FileClose(FN)
    End Sub
    'Public Shared Function getExcelDataIntoDataTable(ByVal strPath As String, ByVal WSheetIndex As Integer, ByVal rowStart As Integer, ByVal rowEnd As Integer, ByVal colStart As Integer, ByVal colEnd As Integer) As DataTable
    '    'this method reads a data table from excel into an arraylist
    '    Dim dt As New DataTable("table_data")

    '    'reads data values from excel books worksheets
    '    Dim oXL As New Excel.Application
    '    Dim oWBK As Excel.Workbook
    '    Dim oWS As Excel.Worksheet
    '    Dim oRNG As Excel.Range
    '    Dim irow, icol As Integer
    '    Dim dt_row, dt_col As Integer
    '    dt_row = dt_col = 1

    '    Try

    '        oWBK = oXL.Workbooks.Open(strPath)
    '        oWS = oXL.Worksheets(WSheetIndex)
    '        For irow = rowStart To rowEnd
    '            For icol = colStart To colEnd
    '                oRNG = oWS.Cells(irow, icol)
    '                dt.Rows(dt_row).Item(dt_col) = oRNG.Value
    '                dt_col += 1
    '            Next
    '            dt_row += 1
    '        Next

    '        oWBK.Close()
    '    Catch ex As Exception

    '    Finally
    '        oWBK = Nothing
    '        oXL = Nothing

    '    End Try
    '    Return dt
    'End Function
    'Public Shared Function getExcelRowOrColumnDataIntoArrayList(ByVal strPath As String, ByVal WSheetIndex As Integer, ByVal StartIndx As Integer, ByVal EndIndx As Integer, ByVal rowOrCol As String, ByVal rowOrColIndx As Integer) As ArrayList
    '    'this method reads a data table from excel into an arraylist
    '    'owner class should import "Imports Excel = Microsoft.Office.Interop.Excel"

    '    Dim arr_list As New ArrayList

    '    'reads data values from excel books worksheets
    '    Dim oXL As New Excel.Application
    '    Dim oWBK As Excel.Workbook
    '    Dim oWS As Excel.Worksheet
    '    Dim oRNG As Excel.Range


    '    Try

    '        oWBK = oXL.Workbooks.Open(strPath)
    '        oWS = oXL.Worksheets(WSheetIndex)
    '        For indx = StartIndx To EndIndx
    '            If rowOrCol = "row" Then
    '                oRNG = oWS.Cells(rowOrColIndx, indx)
    '                arr_list.Add(oRNG.Value)
    '            ElseIf rowOrCol = "col" Then
    '                oRNG = oWS.Cells(indx, rowOrColIndx)
    '                arr_list.Add(oRNG.Value)
    '            End If
    '        Next
    '        oWBK.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        oWBK = Nothing
    '        oXL = Nothing
    '    End Try
    '    Return arr_list
    'End Function
    'Public Sub readFromExcel()
    '    'reads data values from excel books worksheets
    '    Dim oXL As New Excel.Application
    '    Dim oWBK As Excel.Workbook
    '    Dim oWS As Excel.Worksheet
    '    Dim oRNG As Excel.Range
    '    Dim strPath As String = "c:\input_file.xlsx"
    '    Try

    '        oWBK = oXL.Workbooks.Open(strPath)
    '        oWS = oXL.Worksheets(2)
    '        For irow As Integer = 2 To 5
    '            'fetches from row 2 to 5, column one only
    '            For icol As Integer = 1 To 4
    '                oRNG = oWS.Cells(irow, icol)
    '                Console.WriteLine(oRNG.Value)
    '            Next

    '            'oRNG = oWS.Cells(irow, 1)
    '            'Console.WriteLine (oRNG.
    '            'Console.WriteLine(oRNG.Value)
    '            'Console.WriteLine(oRNG.Font.Name)
    '        Next
    '        oWBK.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        oWBK = Nothing
    '        oXL = Nothing
    '    End Try

    'End Sub
    Public Shared Function getExcelData(ByVal fname As String, ByVal sheetName As String) As DataTable
        'Dim ole_conn As OleDbConnection
        Dim retTable As DataTable
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        Dim query As String
        Dim connString As String = ""

        'Connection String to Excel Workbook
        'Connection String to Excel Workbook
        If Right(fname, 4) = ".xls" Then
            connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fname & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf Right(fname, 5) = ".xlsx" Then
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fname & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
        End If

        connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & fname & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""

        query = "SELECT * FROM [" & sheetName & "$]" '[Sheet1$]"

        'Create the connection object
        Dim ole_conn = New OleDbConnection(connString)
        'Open connection
        If ole_conn.State = ConnectionState.Closed Then ole_conn.Open()
        'Create the command object
        cmd = New OleDbCommand(query, ole_conn)
        da = New OleDbDataAdapter(cmd)
        ds = New DataSet()
        da.Fill(ds)

        retTable = ds.Tables(0)


        da.Dispose()
        ole_conn.Close()
        ole_conn.Dispose()

        Return retTable

    End Function
End Class
