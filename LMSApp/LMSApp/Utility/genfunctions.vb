Imports System.Data.SqlClient
Imports System.Net.Mail
'Imports CrystalDecisions.Web.Report
'Imports CrystalDecisions.CrystalReports.Engine
'Imports CrystalDecisions.Shared
'Imports System.ServiceModel.Web
'Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Office.Interop
Imports Microsoft.VisualBasic.FileIO

Public Class genfunctions
    Public Shared dtsettings As New DataSet
    Public Shared apppath As String
    Public Shared connectstr As String
    Public Shared eod_report As String
    Public Shared eod_user As String
    Public Shared eod_running As Boolean
    Public Shared eod_conn As SqlConnection
    Public Shared eod_trans As SqlTransaction
    Public Shared eod_percent_done As Decimal
    Public Shared CSV_dir As String = HttpContext.Current.Server.MapPath("CSV")
    Shared Function DoesUserHaveAccessToPage(pagename As String) As Boolean
        Dim access As Boolean = True
        Dim views As ArrayList = HttpContext.Current.Session("views")

        If IsNothing(views) Then
            access = False
        Else
            If Not (views.Contains(pagename)) Then
                access = False
            End If
        End If


        Return access
    End Function

    'Public Shared Sub LogThisActivity(stud_num As String)
    '    Dim log As New Tbl_SessionLog
    '    With log
    '        .stud_num = stud_num
    '        .sess_id = Guid.NewGuid().ToString()
    '        .sess_date = DateTime.Now
    '        .update()
    '    End With
    'End Sub


    Public Shared Sub SetupPage()
        Dim role As String = System.Web.HttpContext.Current.Session("role")
        Dim all_screens As New ArrayList

        If role = "uj" Or role = "DSA" Then
            all_screens.AddRange({"upload", "sales", "allstudents", "history", "sendmessages", "targetmessages"})
        ElseIf (role = "tupperware") Or (role = "avon") Or (role = "tablecharm") Then
            all_screens.AddRange({"upload", "sales", "allstudents", "sendmessages", "history", "targetmessages"})
        End If
        System.Web.HttpContext.Current.Session("views") = all_screens
    End Sub

    Shared Sub initi(ByVal apppath As String)
        Try
            genfunctions.apppath = apppath
            genfunctions.dtsettings.ReadXmlSchema(apppath & "\" & "appsettings.xsd")
            genfunctions.dtsettings.ReadXml(apppath & "\" & "appsettings.xml")
            connectstr = "Data Source=" & dtsettings.Tables("gensettings").Rows(0)("dbserver") & ";Initial Catalog=" & dtsettings.Tables("gensettings").Rows(0)("dbname") & ";Persist Security Info=True;"
            connectstr = connectstr & "User ID=" & dtsettings.Tables("gensettings").Rows(0)("dbuserid") & ";"
            Dim password As String = dtsettings.Tables("gensettings").Rows(0)("dbpassword")
            connectstr = connectstr & "Password=" & password & ";"

        Catch ex As Exception
            'LogException(ex)
        End Try
    End Sub
    'Public Shared Sub LogException(ByVal ex As Exception)
    '    Dim nrow As DataRow = dtsettings.Tables("exceptions").NewRow()
    '    nrow("DATA") = ex.ToString
    '    nrow("DATETIMEOCCURED") = Now
    '    If Not ex.InnerException Is Nothing Then
    '        nrow("INNEREXCEPTION_DATA") = ex.InnerException.ToString
    '    End If
    '    dtsettings.Tables("exceptions").Rows.Add(nrow)
    '    dtsettings.WriteXml(apppath & "\" & "appsettings.xml")
    'End Sub
    'Shared Sub View_report(ByVal dt As System.Data.DataTable, ByVal report_filename As String, ByVal report_name As String, ByVal exp_type As ExportFormatType, Optional ByVal subreports As Generic.List(Of SubReport) = Nothing)
    '    Dim hReport As New ReportDocument : Dim i As Integer
    '    hReport.Load(HttpContext.Current.Server.MapPath(report_filename))
    '    hReport.SetDataSource(dt)

    '    If Not subreports Is Nothing Then
    '        For i = 0 To subreports.Count - 1
    '            hReport.Subreports(subreports(i).report_name).SetDataSource(subreports(i).datatable)
    '        Next
    '    End If

    '    Dim strattachname As String = report_name

    '    If exp_type = ExportFormatType.HTML32 Or exp_type = ExportFormatType.HTML40 Then
    '        hReport.ExportToHttpResponse(exp_type, HttpContext.Current.Response, False, strattachname)
    '    Else
    '        hReport.ExportToHttpResponse(exp_type, HttpContext.Current.Response, True, strattachname)
    '    End If

    'End Sub
    'Shared Function Save_report(ByVal dt As System.Data.DataTable, ByVal report_filename As String, ByVal report_name As String, ByVal exp_type As ExportFormatType, Optional ByVal subreports As Generic.List(Of SubReport) = Nothing) As String
    '    'Dim doc As New report

    '    Dim hReport As New ReportDocument, i As Integer
    '    hReport.Load(genfunctions.apppath & "\" & report_filename)

    '    hReport.SetDataSource(dt)
    '    If Not subreports Is Nothing Then
    '        For i = 0 To subreports.Count - 1
    '            hReport.Subreports(subreports(i).report_name).SetDataSource(dt)
    '        Next
    '    End If

    '    Dim strattachname As String = report_name

    '    Select Case exp_type
    '        Case ExportFormatType.CrystalReport
    '            strattachname = strattachname & ".RPT"
    '        Case ExportFormatType.Excel
    '            strattachname = strattachname & ".XLS"
    '        Case ExportFormatType.HTML32
    '            strattachname = strattachname & ".HTM"
    '        Case ExportFormatType.HTML40
    '            strattachname = strattachname & ".HTM"
    '        Case ExportFormatType.PortableDocFormat
    '            strattachname = strattachname & ".PDF"
    '        Case ExportFormatType.RichText
    '            strattachname = strattachname & ".RTF"
    '        Case ExportFormatType.WordForWindows
    '            strattachname = strattachname & ".DOC"
    '    End Select

    '    strattachname = genfunctions.apppath & "\exported_reports\" & strattachname
    '    hReport.ExportToDisk(exp_type, strattachname)


    '    Return strattachname

    'End Function
    Shared Sub SendEmail(ByVal mailto As String, ByVal subject As String, ByVal body As String)
        Dim smtpservername As String = dtsettings.Tables("mailsettings").Rows(0)("smtpserverip")
        Dim smtpserverport As String = dtsettings.Tables("mailsettings").Rows(0)("smtpserverport")
        Dim smtpfrom As String = dtsettings.Tables("mailsettings").Rows(0)("smtpfrom")
        Dim smail As New SmtpClient
        smail.Port = smtpserverport
        smail.Host = smtpservername
        smail.Send(smtpfrom, mailto, subject, body)
    End Sub
    Shared Sub SendEmailWithAttachment(ByVal mailto As String, ByVal cc As String, ByVal bcc As String, ByVal subject As String, ByVal body As String, ByVal attachments As Generic.List(Of String))
        Dim smail As New SmtpClient, i As Integer
        Dim smessage As New MailMessage
        If Not attachments Is Nothing Then
            For i = 0 To attachments.Count - 1
                smessage.Attachments.Add(New Attachment(attachments(i)))
            Next
        End If

        smail.Port = dtsettings.Tables("mailsettings").Rows(0)("smtpserverport")
        smail.Host = dtsettings.Tables("mailsettings").Rows(0)("smtpserverip")
        'smail.UseDefaultCredentials = False
        'smail.EnableSsl = True

        smail.DeliveryMethod = SmtpDeliveryMethod.Network
        smail.Credentials = New System.Net.NetworkCredential("adeibijola@yahoo.ca", "password")
        'smail.Credentials = New System.Net.NetworkCredential("adeibijola@yahoo.ca", "password")
        smessage.Body = body
        smessage.To.Add(mailto)
        If Not (ENTITY.checkNull(bcc) Is Nothing) Then
            smessage.Bcc.Add(bcc)
        End If
        If Not (ENTITY.checkNull(bcc) Is Nothing) Then
            smessage.CC.Add(cc)
        End If
        smessage.From = New System.Net.Mail.MailAddress(dtsettings.Tables("mailsettings").Rows(0)("replyto"), dtsettings.Tables("mailsettings").Rows(0)("smtpfrom"))
        smessage.IsBodyHtml = False
        smessage.Subject = subject
        smessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess

        smail.Send(smessage)
        smessage.Dispose()
    End Sub

    Public Shared Function LoadSingleLineItems(filename As String) As ArrayList
        Dim retval As New ArrayList

        Dim field As String()
        Dim delimiter As String = "\n"
        Using parser As New TextFieldParser(filename)
            parser.SetDelimiters(delimiter)
            While Not parser.EndOfData
                ' Read in the fields for the current line
                field = parser.ReadFields()
                ' Add code here to use data in fields variable.

                retval.Add(field(0))
            End While
        End Using
        Return retval
    End Function

    'Public Shared Function CreateCategory_with_TBL(fname As String) As Generic.List(Of Tbl_Category)

    '    Dim arr_categories As New ArrayList
    '    Dim all_categories As New Generic.List(Of Tbl_Category)
    '    arr_categories = genfunctions.LoadSingleLineItems(fname)


    '    Dim lastseen_node As String = ""

    '    Dim i As Integer = 0
    '    For Each line As String In arr_categories
    '        Dim retv As New Category
    '        Dim split_line As Array = line.Split(";")

    '        Dim cat As New Tbl_Category

    '        With cat
    '            .Category_id = Guid.NewGuid().ToString()
    '            .c1 = split_line(0)
    '            .c2 = split_line(1)
    '            .c3 = split_line(2)

    '        End With
    '        all_categories.Add(cat)

    '    Next

    '    Return all_categories
    'End Function



    'Public Shared Function CreateCategory(fname As String) As Generic.List(Of Category)

    '    Dim arr_categories As New ArrayList
    '    Dim all_categories As New Generic.List(Of Category)
    '    arr_categories = genfunctions.LoadSingleLineItems(fname)


    '    Dim lastseen_node As String = ""

    '    Dim i As Integer = 0
    '    For Each line As String In arr_categories
    '        Dim retv As New Category
    '        Dim split_line As Array = line.Split(";")

    '        Dim cat As New Category

    '        With cat
    '            .parentId = Guid.NewGuid().ToString()
    '            .Text = split_line(0)

    '            'get sub category
    '            Dim sc As New Category
    '            sc.parentId = Guid.NewGuid().ToString()
    '            sc.Text = split_line(1)

    '            'get SSC
    '            Dim ssc As New Category
    '            ssc.parentId = Guid.NewGuid().ToString()
    '            ssc.Text = split_line(2)

    '            cat.sub_category = sc
    '            cat.sub_category.sub_category = ssc
    '        End With
    '        all_categories.Add(cat)

    '    Next

    '    Return all_categories
    'End Function


    'Public Shared Function LoadQuotes() As Generic.List(Of Tbl_quote)
    '    Dim retval As New Generic.List(Of Tbl_quote)
    '    Dim file As New ArrayList


    '    file = LoadSingleLineItems(CSV_dir & "\Quotes.csv")
    '    Dim i As Integer = 1
    '    For Each line In file
    '        Dim lst_qs As New Tbl_quote
    '        'Splits into list of cities
    '        'Dim arr1 As Array = line.Split(",")

    '        With lst_qs
    '            .quote_id = i ' arr1(0).ToString
    '            .message = line.ToString.ToLower ' arr1(0) ' Guid.NewGuid().ToString()
    '        End With

    '        retval.Add(lst_qs)
    '        i += 1
    '    Next

    '    Return retval
    'End Function

    'Public Shared Function LoadCities() As Generic.List(Of City)
    '    Dim retval As New Generic.List(Of City)
    '    Dim file As New ArrayList


    '    file = LoadSingleLineItems(CSV_dir & "\CitiesInSAV2.csv")
    '    For Each line In file
    '        Dim lst_cities As New City
    '        'Splits into list of cities
    '        Dim arr1 As Array = line.Split(",")

    '        With lst_cities
    '            .city_name = arr1(0).ToString
    '            .city_id = Guid.NewGuid().ToString()
    '        End With

    '        retval.Add(lst_cities)
    '    Next

    '    Return retval
    'End Function

    'Public Shared Function LoadProvinces() As Generic.List(Of Province)
    '    Dim retval As New Generic.List(Of Province)
    '    Dim file As New ArrayList


    '    file = LoadSingleLineItems(CSV_dir & "\ProvincesInSA.csv")
    '    For Each line In file
    '        Dim lst_provinces As New Province
    '        'Splits into list of cities


    '        With lst_provinces
    '            .province_name = line
    '            .province_id = Guid.NewGuid().ToString()
    '        End With

    '        retval.Add(lst_provinces)
    '    Next

    '    Return retval
    'End Function



    'Public Shared Function LoadAllQuotes() As Generic.List(Of Tbl_quote)

    '    Dim retval As New Generic.List(Of Tbl_quote)
    '    Dim file As New ArrayList

    '    file = LoadSingleLineItems("Files\Quotes.csv")

    '    For Each line In file
    '        Dim lst_quote As New Tbl_quote
    '        'Splits into array of message and author
    '        Dim arr1 As Array = line.Split(";")

    '        With lst_quote
    '            .last_used_date = DateAndTime.Now
    '            .quote_id = Guid.NewGuid.ToString()
    '            .message = arr1(0).ToString
    '            .Author = arr1(1).ToString
    '        End With

    '        retval.Add(lst_quote)
    '    Next
    '    Return retval
    'End Function

    'Public Shared Function LoadCountries() As Generic.List(Of Country)
    '    Dim retval As New Generic.List(Of Country)
    '    Dim file As New ArrayList


    '    file = LoadSingleLineItems(CSV_dir & "\CountryCapitalscsvV2.csv")
    '    For Each line In File
    '        Dim lst_countries As New Country
    '        'Splits into list of Countries
    '        Dim arr1 As Array = line.Split(",")

    '        With lst_countries
    '            .country_id = Guid.NewGuid.ToString()
    '            .country_name = arr1(0)
    '        End With

    '        retval.Add(lst_countries)
    '    Next

    '    Return retval
    'End Function

    'Public Shared Function LoadCategories() As Generic.List(Of Category)
    '    Dim retval As New Generic.List(Of Category)
    '    Dim file As New ArrayList


    '    file = LoadSingleLineItems(CSV_dir & "\CategoriesV3.csv")
    '    For Each line In file
    '        Dim lst_cats As New Category
    '        'Splits into list of Countries
    '        Dim arr1 As Array = line.Split(",")

    '        With lst_countries
    '            .country_id = Guid.NewGuid.ToString()
    '            .country_name = arr1(0)
    '        End With

    '        retval.Add(lst_countries)
    '    Next

    '    Return retval
    'End Function





    'Public Shared Function LoadQualification() As Generic.List(Of Qualification)

    '    Dim retval As New Generic.List(Of Qualification)
    '    Dim file As New ArrayList


    '    file = LoadSingleLineItems(CSV_dir & "\QualificationsInSA.csv")
    '    For Each line In file
    '        Dim lst_qualifications As New Qualification

    '        With lst_qualifications
    '            .qualification_id = Guid.NewGuid.ToString()
    '            .qualification_name = line
    '        End With



    '        retval.Add(lst_qualifications)
    '    Next

    '    Return retval
    'End Function

    'Public Shared Function LoadLanguages() As Generic.List(Of Language)
    '    Dim retval As New Generic.List(Of Language)
    '    Dim file As New ArrayList


    '    file = LoadSingleLineItems("Seeds\Languages.csv")
    '    For Each line In file
    '        Dim lst_languages As New Language
    '        'Splits into list of countries and associated languages
    '        Dim arr1 As Array = line.Split(";")
    '        'Splits into list of languages
    '        Dim arr2 As Array = arr1(1).Split(",")
    '        lst_languages.country.Add(arr1(0).Trim())
    '        For Each lang In arr2
    '            lst_languages.language.Add(lang.Trim())
    '        Next

    '        retval.Add(lst_languages)
    '    Next

    '    Return retval
    'End Function

    'Public Shared Function CreateCategory() As Generic.List(Of Category)

    '    Dim arr_categories As New ArrayList
    '    Dim all_categories As New Generic.List(Of Category)
    '    arr_categories = Utility.LoadSingleLineItems("Seeds\Categories.csv")

    '    Dim i As Integer = 0
    '    For Each line As String In arr_categories
    '        Dim retv As New Category
    '        Dim split_line As Array = line.Split(";")

    '        Dim cat As New Category

    '        With cat
    '            .id = Guid.NewGuid().ToString()
    '            .descr = split_line(0)

    '            'get sub category
    '            Dim sc As New Category
    '            sc.id = Guid.NewGuid().ToString()
    '            sc.descr = split_line(1)

    '            'get SSC
    '            Dim ssc As New Category
    '            ssc.id = Guid.NewGuid().ToString()
    '            ssc.descr = split_line(2)

    '            cat.sub_category = sc
    '            cat.sub_category.sub_category = ssc
    '        End With
    '        all_categories.Add(cat)

    '    Next

    '    Return all_categories
    'End Function


    'Public Shared Function LoadCapitals_and_Countries() As Generic.List(Of FlashCard)
    '    Dim retval As New Generic.List(Of FlashCard)
    '    Dim file As New ArrayList

    '    file = LoadSingleLineItems("Seeds\CountryCapitals.csv")

    '    For Each line In file
    '        Dim a_FC As New FlashCard
    '        Dim arrC_C As Array = line.Split(",")

    '        a_FC.fact_id = Guid.NewGuid.ToString
    '        a_FC.question = "What is the Capital of " & arrC_C(0) & "?"
    '        a_FC.answer = arrC_C(1)

    '        a_FC.fact = "The capital of " & arrC_C(0) & " is " & arrC_C(1) & "."

    '        retval.Add(a_FC)
    '    Next

    '    Return retval
    'End Function

End Class
