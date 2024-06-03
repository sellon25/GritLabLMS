Public Class MoneyMatters
    Public Shared Function getAmountInWords(ByVal amount As String) As String
        Dim naira As String = "", kobo As String = ""
        Dim hasKobo As Boolean = True

        naira = SplitAmountReturnNaira(amount)
        kobo = SplitAmountReturnKobo(amount)
        'Debug.Print(kobo)

        If kobo = "00" Then
            hasKobo = False
        End If

        Dim retval As String = ""
        Select Case naira.Length
            Case 1
                retval = GetDigit(naira)
            Case 2
                retval = GetTens(naira)
            Case 3
                retval = getHundred(naira)
            Case 4 To 6
                retval = GetThousand(naira)
            Case 7 To 9
                retval = getMillion(naira)
            Case 10 To 12
                retval = getBillion(naira)
            Case 13 To 15
                retval = getTrillion(naira)
            Case 16 To 18
                retval = getQuadrillion(naira)
            Case Else
                retval = "Amount in words Not Available"
        End Select

        If hasKobo Then
            Dim koboInWords As String = GetTens(kobo)
            retval &= " Naira, " & koboInWords & " Kobo Only."
        Else
            retval &= " Naira Only."
        End If

        Return retval.Replace("  ", " ")
    End Function
    Private Shared Function getQuadrillion(ByVal quadrill_text As String) As String
        Dim retval As String = ""
        If (Left(quadrill_text, 1) = "0") And (quadrill_text.Length = 16) Then
            retval = getTrillion(quadrill_text.Substring(1))
        ElseIf (Left(quadrill_text, 1) = "0") And (quadrill_text.Length > 16) Then
            'recursive call
            retval = getQuadrillion(quadrill_text.Substring(1))
        Else
            Select Case quadrill_text.Length
                Case 16
                    If quadrill_text.Substring(1, 13) <> "0000000000000" Then
                        retval = GetDigit(Left(quadrill_text, 1)) & " Quadrillion, " & getTrillion(quadrill_text.Substring(1))
                    Else
                        retval = GetDigit(Left(quadrill_text, 1)) & " Quadrillion " & getTrillion(quadrill_text.Substring(1))
                    End If
                Case 17
                    If quadrill_text.Substring(2, 13) <> "0000000000000" Then
                        retval = GetTens(Left(quadrill_text, 2)) & " Quadrillion, " & getTrillion(quadrill_text.Substring(2))
                    Else
                        retval = GetTens(Left(quadrill_text, 2)) & " Quadrillion " & getTrillion(quadrill_text.Substring(2))
                    End If
                Case 18
                    If quadrill_text.Substring(3, 13) <> "0000000000000" Then
                        retval = getHundred(Left(quadrill_text, 3)) & " Quadrillion, " & getTrillion(quadrill_text.Substring(3))
                    Else
                        retval = getHundred(Left(quadrill_text, 3)) & " Quadrillion " & getTrillion(quadrill_text.Substring(3))
                    End If
            End Select
        End If
        Return retval
    End Function
    Private Shared Function getTrillion(ByVal trill_text As String) As String
        Dim retval As String = ""
        If (Left(trill_text, 1) = "0") And (trill_text.Length = 13) Then
            retval = getBillion(trill_text.Substring(1))
        ElseIf (Left(trill_text, 1) = "0") And (trill_text.Length > 13) Then
            'recursive call
            retval = getTrillion(trill_text.Substring(1))
        Else
            Select Case trill_text.Length
                Case 13
                    If trill_text.Substring(1, 10) <> "0000000000" Then
                        retval = GetDigit(Left(trill_text, 1)) & " Trillion, " & getBillion(trill_text.Substring(1))
                    Else
                        retval = GetDigit(Left(trill_text, 1)) & " Trillion " & getBillion(trill_text.Substring(1))
                    End If
                Case 14
                    If trill_text.Substring(2, 10) <> "0000000000" Then
                        retval = GetTens(Left(trill_text, 2)) & " Trillion, " & getBillion(trill_text.Substring(2))
                    Else
                        retval = GetTens(Left(trill_text, 2)) & " Trillion " & getBillion(trill_text.Substring(2))
                    End If
                Case 15
                    If trill_text.Substring(3, 10) <> "0000000000" Then
                        retval = getHundred(Left(trill_text, 3)) & " Trillion, " & getBillion(trill_text.Substring(3))
                    Else
                        retval = getHundred(Left(trill_text, 3)) & " Trillion " & getBillion(trill_text.Substring(3))
                    End If

            End Select
        End If
        Return retval
    End Function
    Private Shared Function getBillion(ByVal bill_text As String) As String
        Dim retval As String = ""
        If (Left(bill_text, 1) = "0") And (bill_text.Length = 10) Then
            retval = getMillion(bill_text.Substring(1))
        ElseIf (Left(bill_text, 1) = "0") And (bill_text.Length > 10) Then
            'recursive call
            retval = getBillion(bill_text.Substring(1))
        Else
            Select Case bill_text.Length
                Case 10
                    If bill_text.Substring(1, 7) <> "0000000" Then
                        retval = GetDigit(Left(bill_text, 1)) & " Billion, " & getMillion(bill_text.Substring(1))
                    Else
                        retval = GetDigit(Left(bill_text, 1)) & " Billion " & getMillion(bill_text.Substring(1))
                    End If
                Case 11
                    If bill_text.Substring(2, 7) <> "0000000" Then
                        retval = GetTens(Left(bill_text, 2)) & " Billion, " & getMillion(bill_text.Substring(2))
                    Else
                        retval = GetTens(Left(bill_text, 2)) & " Billion " & getMillion(bill_text.Substring(2))
                    End If
                Case 12
                    If bill_text.Substring(3, 7) <> "0000000" Then
                        retval = getHundred(Left(bill_text, 3)) & " Billion, " & getMillion(bill_text.Substring(3))
                    Else
                        retval = getHundred(Left(bill_text, 3)) & " Billion " & getMillion(bill_text.Substring(3))
                    End If
            End Select
        End If
        Return retval
    End Function
    Private Shared Function getMillion(ByVal mill_text As String) As String
        Dim retval As String = ""
        If Left(mill_text, 1) = "0" And mill_text.Length = 7 Then
            retval = GetThousand(mill_text.Substring(1))
        ElseIf Left(mill_text, 1) = "0" And mill_text.Length > 7 Then
            'recursive call
            retval = getMillion(mill_text.Substring(1))
        Else
            Select Case mill_text.Length
                Case 7
                    If mill_text.Substring(1, 4) <> "0000" Then
                        retval = GetDigit(Left(mill_text, 1)) & " Million, " & GetThousand(mill_text.Substring(1))
                    Else
                        retval = GetDigit(Left(mill_text, 1)) & " Million " & GetThousand(mill_text.Substring(1))
                    End If
                Case 8
                    If mill_text.Substring(2, 4) <> "0000" Then
                        retval = GetTens(Left(mill_text, 2)) & " Million, " & GetThousand(mill_text.Substring(2))
                    Else
                        retval = GetTens(Left(mill_text, 2)) & " Million " & GetThousand(mill_text.Substring(2))
                    End If
                Case 9
                    If mill_text.Substring(3, 4) <> "0000" Then
                        retval = getHundred(Left(mill_text, 3)) & " Million, " & GetThousand(mill_text.Substring(3))
                    Else
                        retval = getHundred(Left(mill_text, 3)) & " Million " & GetThousand(mill_text.Substring(3))
                    End If

            End Select
        End If
        Return retval
    End Function
    Private Shared Function GetThousand(ByVal Th_text As String) As String
        Dim retval As String = ""
        If Left(Th_text, 1) = "0" And Th_text.Length = 4 Then
            retval = getHundred(Th_text.Substring(1))
        ElseIf Left(Th_text, 1) = "0" And Th_text.Length > 4 Then
            retval = GetThousand(Th_text.Substring(1))
        Else
            Select Case Th_text.Length
                Case 4
                    If Th_text.Substring(1, 1) <> "0" Then
                        retval = GetDigit(Left(Th_text, 1)) & " Thousand, " & getHundred(Th_text.Substring(1))
                    Else
                        retval = GetDigit(Left(Th_text, 1)) & " Thousand " & getHundred(Th_text.Substring(1))
                    End If
                Case 5
                    If Th_text.Substring(2, 1) <> "0" Then
                        retval = GetTens(Left(Th_text, 2)) & " Thousand, " & getHundred(Th_text.Substring(2))
                    Else
                        retval = GetTens(Left(Th_text, 2)) & " Thousand " & getHundred(Th_text.Substring(2))
                    End If
                Case 6
                    If Th_text.Substring(3, 1) <> "0" Then
                        retval = getHundred(Left(Th_text, 3)) & " Thousand, " & getHundred(Th_text.Substring(3))
                    Else
                        retval = getHundred(Left(Th_text, 3)) & " Thousand " & getHundred(Th_text.Substring(3))
                    End If
            End Select
        End If
        Return retval
    End Function
    Private Shared Function getHundred(ByVal hund_text As String) As String
        Dim retval As String = ""
        If (Left(hund_text, 1) = "0") And (hund_text <> "000") Then
            retval = " and " & GetTens(hund_text.Substring(1))
        ElseIf (Left(hund_text, 1) = "0") And (hund_text = "000") Then
            retval = "" ' GetDigit(Left(hund_text, 1)) & " Hundred " & GetTens(hund_text.Substring(1))
        ElseIf (Left(hund_text, 1) <> "0") And (hund_text.Substring(1, 2) = "00") Then
            retval = GetDigit(Left(hund_text, 1)) & " Hundred " & GetTens(hund_text.Substring(1))  ' GetDigit(Left(hund_text, 1)) & " Hundred " & GetTens(hund_text.Substring(1))
        Else
            retval = GetDigit(Left(hund_text, 1)) & " Hundred and " & GetTens(hund_text.Substring(1))
        End If
        Return retval
    End Function
    Private Shared Function GetTens(ByVal TensText As String) As String 'pronouces 00 
        Dim Result As String
        If Left(TensText, 1) = "0" Then
            Result = GetDigit(TensText.Substring(1))
        Else
            Result = ""           'null out the temporary function value
            If Val(Left(TensText, 1)) = 1 Then   ' If value between 10-19
                Select Case Val(TensText)
                    Case 10 : Result = "Ten"
                    Case 11 : Result = "Eleven"
                    Case 12 : Result = "Twelve"
                    Case 13 : Result = "Thirteen"
                    Case 14 : Result = "Fourteen"
                    Case 15 : Result = "Fifteen"
                    Case 16 : Result = "Sixteen"
                    Case 17 : Result = "Seventeen"
                    Case 18 : Result = "Eighteen"
                    Case 19 : Result = "Nineteen"
                    Case Else
                End Select
            Else                                 ' If value between 20-99
                Select Case Val(Left(TensText, 1))
                    Case 2 : Result = "Twenty "
                    Case 3 : Result = "Thirty "
                    Case 4 : Result = "Forty "
                    Case 5 : Result = "Fifty "
                    Case 6 : Result = "Sixty "
                    Case 7 : Result = "Seventy "
                    Case 8 : Result = "Eighty "
                    Case 9 : Result = "Ninety "
                        'Case 0 : Result = ""
                    Case Else
                End Select
                Result = Result & GetDigit(Right(TensText, 1))   'Retrieve ones place _

            End If
        End If
        Return Result
    End Function
    Private Shared Function GetDigit(ByVal Digit As Integer) As String
        Dim retval As String = ""
        Select Case Val(Digit)
            Case 1 : retval = "One"
            Case 2 : retval = "Two"
            Case 3 : retval = "Three"
            Case 4 : retval = "Four"
            Case 5 : retval = "Five"
            Case 6 : retval = "Six"
            Case 7 : retval = "Seven"
            Case 8 : retval = "Eight"
            Case 9 : retval = "Nine"
            Case Else : retval = ""

        End Select
        Return retval
    End Function
    Public Shared Function SplitAmountReturnNaira(ByVal amount As String) As String
        Dim naira As String
        Dim kobo_index As Integer
        amount = amount.Trim
        If amount.Contains(".") Then
            kobo_index = amount.IndexOf(".")
            naira = amount.Substring(0, kobo_index)
        Else
            naira = amount
        End If
        Return naira
    End Function
    Public Shared Function SplitAmountReturnKobo(ByVal amount As String) As String
        Dim naira, kobo As String
        Dim kobo_index As Integer
        amount = amount.Trim
        If amount.Contains(".") Then
            kobo_index = amount.IndexOf(".")
            naira = amount.Substring(0, kobo_index)
            kobo = amount.Substring(kobo_index + 1, (amount.Length - naira.Length - 1))
            If kobo.Length >= 2 Then
                kobo = amount.Substring(kobo_index + 1, 2)
            ElseIf kobo.Length = 1 Then
                kobo &= "0"
            End If
        Else
            kobo = "00"
        End If
        Return kobo
    End Function
    Shared Function turnToCurrency(ByVal amount As String) As String
        Dim naira, kobo As String
        Dim kobo_index As Integer
        amount = amount.Trim
        If amount.Contains(".") Then
            kobo_index = amount.IndexOf(".")
            naira = amount.Substring(0, kobo_index)

            kobo = amount.Substring(kobo_index + 1, (amount.Length - naira.Length - 1))
            If kobo.Length >= 2 Then
                kobo = amount.Substring(kobo_index + 1, 2)
            ElseIf kobo.Length = 1 Then
                kobo &= "0"
            End If
        Else
            naira = amount
            kobo = "00"
        End If
        Dim retval As String = "00.00"
        Select Case Len(naira)
            Case 1, 2, 3 : retval = naira & "." & kobo
            Case 4 : retval = naira.Insert(1, ",") & "." & kobo
            Case 5 : retval = naira.Insert(2, ",") & "." & kobo
            Case 6 : retval = naira.Insert(3, ",") & "." & kobo
            Case 7
                retval = naira.Insert(1, ",")
                retval = retval.Insert(5, ",") & "." & kobo
            Case 8
                retval = naira.Insert(2, ",")
                retval = retval.Insert(6, ",") & "." & kobo
            Case 9
                retval = naira.Insert(3, ",")
                retval = retval.Insert(7, ",") & "." & kobo
            Case 10
                retval = naira.Insert(1, ",")
                retval = retval.Insert(5, ",")
                retval = retval.Insert(9, ",") & "." & kobo
            Case 11
                retval = naira.Insert(2, ",")
                retval = retval.Insert(6, ",")
                retval = retval.Insert(10, ",") & "." & kobo
            Case 12
                retval = naira.Insert(3, ",")
                retval = retval.Insert(7, ",")
                retval = retval.Insert(11, ",") & "." & kobo
            Case 13
                retval = naira.Insert(1, ",")
                retval = retval.Insert(5, ",")
                retval = retval.Insert(9, ",")
                retval = retval.Insert(13, ",") & "." & kobo
            Case 14
                retval = naira.Insert(2, ",")
                retval = retval.Insert(6, ",")
                retval = retval.Insert(10, ",")
                retval = retval.Insert(14, ",") & "." & kobo
            Case 15
                retval = naira.Insert(3, ",")
                retval = retval.Insert(7, ",")
                retval = retval.Insert(11, ",")
                retval = retval.Insert(15, ",") & "." & kobo
            Case 16
                retval = naira.Insert(1, ",")
                retval = retval.Insert(5, ",")
                retval = retval.Insert(9, ",")
                retval = retval.Insert(13, ",")
                retval = retval.Insert(17, ",") & "." & kobo
            Case 17
                retval = naira.Insert(2, ",")
                retval = retval.Insert(6, ",")
                retval = retval.Insert(10, ",")
                retval = retval.Insert(14, ",")
                retval = retval.Insert(18, ",") & "." & kobo
            Case 18
                retval = naira.Insert(3, ",")
                retval = retval.Insert(7, ",")
                retval = retval.Insert(11, ",")
                retval = retval.Insert(15, ",")
                retval = retval.Insert(19, ",") & "." & kobo
            Case Else
                retval = naira & "." & kobo
        End Select
        Return "₦ " & retval
    End Function
End Class
