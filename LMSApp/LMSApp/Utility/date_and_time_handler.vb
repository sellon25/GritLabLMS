Public Class date_and_time_handler
    Shared Function makeDate(ByVal dd As String, ByVal mm As String, ByVal yyyy As String) As Date
        Dim retval As Date = Nothing
        Try
            retval = CDate("#" & mm & "/" & dd & "/" & yyyy & "#")
        Catch ex As Exception
        End Try
        Return retval
    End Function
    Shared Function getAge(ByVal DOB As Date) As Integer
        Return DateDiff(DateInterval.Year, DOB, Date.Today)
    End Function
    Shared Function getMonthNameAbrv(ByVal MthName As String) As String
        Return MthName.Substring(0, 3).ToUpper
    End Function
    Shared Function customFormatDate(a_date As Date) As String
        Return Day(a_date).ToString & "-" & Left(MonthName(Month(a_date)), 3) & "-" & Right(Year(a_date).ToString, 2)
    End Function

#Region "Date Manipulations"
    Shared Function loginSummary(arrDates As ArrayList) As String
        'Dim arrStrippedDates(arrDates.Length) As String
        Dim arrSummary(11) As String
        'Dim arrTotalLoginsAMonth(11) As Integer
        Dim arrTotalLoginsAMonth = New Integer() {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        Dim arrDateMonthYear(3) As String
        Dim arrStrippedDates As New List(Of String)
        Dim sStrippedLine, sResult As String
        Dim iDate, iMonth, iYear As Integer
        Dim sError As String = ""
        sResult = ""

        'Strip all the spaces and put the new data in another array
        For Each line In arrDates
            sStrippedLine = RemoveWhitespace(line)
            arrStrippedDates.Add(sStrippedLine)
        Next


        For Each line In arrStrippedDates
            'Extract date, month and year and place it into arrDateMonthYear
            arrDateMonthYear = line.Split("/")

            'Assign date, month and year to individual variables
            iDate = Integer.Parse(arrDateMonthYear(0))
            iMonth = Integer.Parse(arrDateMonthYear(1))
            iYear = Integer.Parse(arrDateMonthYear(2))

            'Sum the total for every month and insert the total number of logins per month. 
            'insert all the dates in the array according to the month.
            Select Case iMonth
                Case 1
                    arrSummary(0) = arrSummary(0) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(0) = arrTotalLoginsAMonth(0) + 1
                Case 2
                    arrSummary(1) = arrSummary(1) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(1) = arrTotalLoginsAMonth(1) + 1
                Case 3
                    arrSummary(2) = arrSummary(2) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(2) = arrTotalLoginsAMonth(2) + 1
                Case 4
                    arrSummary(3) = arrSummary(3) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(3) = arrTotalLoginsAMonth(3) + 1
                Case 5
                    arrSummary(4) = arrSummary(4) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(4) = arrTotalLoginsAMonth(4) + 1
                Case 6
                    arrSummary(5) = arrSummary(5) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(5) = arrTotalLoginsAMonth(5) + 1
                Case 7
                    arrSummary(6) = arrSummary(6) + iDate.ToString + ", "

                    arrTotalLoginsAMonth(6) = arrTotalLoginsAMonth(6) + 1
                Case 8
                    arrSummary(7) = arrSummary(7) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(7) = arrTotalLoginsAMonth(7) + 1
                Case 9
                    arrSummary(8) = arrSummary(8) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(8) = arrTotalLoginsAMonth(8) + 1
                Case 10
                    arrSummary(9) = arrSummary(9) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(9) = arrTotalLoginsAMonth(9) + 1
                Case 11
                    arrSummary(10) = arrSummary(10) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(10) = arrTotalLoginsAMonth(10) + 1
                Case 12
                    arrSummary(11) = arrSummary(11) + iDate.ToString + ", "
                    arrTotalLoginsAMonth(11) = arrTotalLoginsAMonth(11) + 1
                Case Else
                    sError = "Invalid Month"
                    Console.WriteLine("Invalid Month")
            End Select

        Next

        arrSummary = getSortedDates(arrSummary)
        sResult = "Total Logins: " + arrTotalLoginsAMonth.Sum.ToString + vbNewLine + "" + vbNewLine
        For count = 0 To arrTotalLoginsAMonth.Length - 1
            'check if total logins for the month is 0
            If (Not arrTotalLoginsAMonth(count) = 0) Then
                'sResult = sResult + "0 logins in " + ConvertMonth(count + 1) + vbNewLine
                sResult = sResult + arrTotalLoginsAMonth(count).ToString + " login(s) in " + ConvertMonth(count + 1) + ": " + getLoginsPerDate(arrSummary(count)) + vbNewLine + "" + vbNewLine
            End If

        Next

        Return sResult

    End Function


    Shared Function ConvertMonth(iMonth As Integer) As String
        Dim sResult = ""
        Select Case iMonth
            Case 1
                sResult = "January"
            Case 2
                sResult = "February"
            Case 3
                sResult = "March"
            Case 4
                sResult = "April"
            Case 5
                sResult = "May"
            Case 6
                sResult = "June"
            Case 7
                sResult = "July"
            Case 8
                sResult = "August"
            Case 9
                sResult = "September"
            Case 10
                sResult = "October"
            Case 11
                sResult = "November"
            Case 12
                sResult = "December"
            Case Else
                Console.WriteLine("Invalid Month")
        End Select

        Return sResult
    End Function

    Shared Function ValidateDate(iDate As Integer, iMonth As Integer, iYear As Integer) As Boolean
        Dim sDate As String
        sDate = iDate.ToString + "/" + iMonth.ToString + "/" + iYear.ToString

        Return IsDate(sDate)

    End Function

    Shared Function RemoveWhitespace(fullString As String) As String
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function

    Shared Function getSortedDates(arrDates As String()) As String()

        For count = 0 To arrDates.Length - 1
            Dim sLine = arrDates(count)

            If (Not arrDates(count) = Nothing) Then
                sLine = RemoveWhitespace(sLine)
                Dim arrSortedDates() As String
                arrSortedDates = sLine.Split(",")

                Dim arrISortedDates(arrSortedDates.Count - 1) As Integer

                For i = 0 To arrSortedDates.Length - 2
                    If (Not arrSortedDates(i) = "") Then
                        arrISortedDates(i) = Integer.Parse(arrSortedDates(i))
                    End If

                Next

                System.Array.Sort(arrISortedDates)

                For i = 0 To arrISortedDates.Length - 1
                    If (Not arrISortedDates(i) = 0) Then
                        arrSortedDates(i) = arrISortedDates(i).ToString
                    End If

                Next

                sLine = ""

                For iCount = 1 To arrSortedDates.Length - 1
                    If (Not sLine = "") Then
                        sLine = sLine + "," + arrSortedDates(iCount)
                    Else
                        sLine = arrSortedDates(iCount)
                    End If

                Next

                arrDates(count) = sLine

            End If

        Next

        Return arrDates

    End Function

    Shared Function getLoginsPerDate(sDates As String) As String
        'Input:     2,2,2,2,2,4,4,8
        'Output:    5 times on the 2nd, 2 times on the 4th, 1 time on the 8th

        Dim sResult As String = ""
        Dim iDate, iDateCount As Integer
        Dim str() As String = sDates.Split(",")

        For count = 0 To str.Length - 1
            iDate = str(count)
            iDateCount = getRepeatedDates(str, iDate)
            If count = 0 Then
                sResult += iDateCount.ToString + " time(s) on the " + getConvertedDate(iDate) + ", "
            ElseIf (Not iDate = str(count - 1)) Then
                sResult += iDateCount.ToString + " time(s) on the " + getConvertedDate(iDate) + ", "
            End If

        Next

        'Remove the last comma
        sResult = sResult.Trim().Substring(0, sResult.Length - 2)
        sResult += "."
        'str.Distinct().ToList().ForEach(Sub(digit) Console.WriteLine("{0} exists {1}", digit, str.Count(Function(s) s = digit)))
        Return sResult

    End Function

    Shared Function getRepeatedDates(arrDates As String(), iDate As Integer) As Integer
        Dim iCount As Integer = 0
        For count = 0 To arrDates.Length - 1
            If arrDates(count) = iDate Then
                iCount += 1
            End If

        Next

        Return iCount
    End Function

    Shared Function getConvertedDate(iDate As Integer) As String
        Dim sresult As String = ""

        Select Case iDate
            Case 1, 21, 31
                sresult = iDate.ToString + "st"
            Case 2, 22
                sresult = iDate.ToString + "nd"
            Case 3, 23
                sresult = iDate.ToString + "rd"
            Case Else
                sresult = iDate.ToString + "th"
        End Select

        Return sresult


    End Function
#End Region




End Class
