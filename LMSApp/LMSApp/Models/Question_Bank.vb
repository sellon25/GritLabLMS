Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Question_Bank
inherits Entity

Public Shared Display_id as Boolean=True
    Public Shared Display_Text As Boolean = True
    Public Shared Display_QuestionType As Boolean = True
    Public Shared Display_ParentQuestion As Boolean = True
    Public Shared Display_QuestionNumber As Boolean = True
    Public Shared Display_TestID As Boolean = True
    Public Shared Display_CaseStudy As Boolean = True
    Public Shared Display_Image As Boolean = True
    Public Shared Display_Option1 As Boolean = True
    Public Shared Display_Option2 As Boolean = True
    Public Shared Display_Option3 As Boolean = True
    Public Shared Display_Option4 As Boolean = True
    Public Shared Display_Mark As Boolean = True
    Public Shared Display_Category_ID As Boolean = True
    Public Shared Display_Section_ID As Boolean = True

    Private I_Display_id As Boolean = True
    Private I_Display_Text As Boolean = True
    Private I_Display_QuestionType As Boolean = True
    Private I_Display_QuestionNumber As Boolean = True
    Private I_Display_TestID As Boolean = True
    Private I_Display_ParentQuestion As Boolean = True
    Private I_Display_CaseStudy As Boolean = True
    Private I_Display_Image As Boolean = True
    Private I_Display_Option1 As Boolean = True
    Private I_Display_Option2 As Boolean = True
    Private I_Display_Option3 As Boolean = True
    Private I_Display_Option4 As Boolean = True
    Private I_Display_Mark As Boolean = True
    Private I_Display_Category_ID As Boolean = True
    Private I_Display_Section_ID As Boolean = True

    Public previous_id As System.String

    Public id As System.String
    Public Text As System.String
    Public CaseStudy As System.String
    Public Image As System.Byte()
    Public Option1 As System.String
    Public Option2 As System.String
    Public Option3 As System.String
    Public Option4 As System.String
    Public Mark As Nullable(Of System.Double)
    Public Category_ID As System.String
    Public Section_ID As Nullable(Of System.Int32)
    Public QuestionNumber As Nullable(Of System.Double)
    Public QuestionType As System.String
    Public ParentQuestion As System.String
    Public TestID As System.String
    Private newinstance As Boolean = True


    Shared Sub Set_Display_Field_All(display_flag As Boolean)
        Display_id = display_flag
        Display_Text = display_flag
        Display_QuestionType = display_flag
        Display_QuestionNumber = display_flag
        Display_ParentQuestion = display_flag
        Display_CaseStudy = display_flag
        Display_Image = display_flag
        Display_Option1 = display_flag
        Display_Option2 = display_flag
        Display_Option3 = display_flag
        Display_Option4 = display_flag
        Display_Mark = display_flag
        Display_Category_ID = display_flag
        Display_Section_ID = display_flag
        Display_TestID = display_flag
    End Sub


    Private Sub insert()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "insert into Question_Bank (id,Text,QuestionType,QuestionNumber,ParentQuestion,TestID,CaseStudy,Image,Option1,Option2,Option3,Option4,Mark,Category_ID,Section_ID)"
        cmd.CommandText = cmd.CommandText & "values(@id,@Text,@QuestionType,@QuestionNumber,@ParentQuestion,@TestID,@CaseStudy,@Image,@Option1,@Option2,@Option3,@Option4,@Mark,@Category_ID,@Section_ID)"

        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = setNull(id)
        cmd.Parameters.Add("@Text", 22, -1, "Text")
        cmd.Parameters("@Text").Value = setNull(Text)
        cmd.Parameters.Add("@QuestionType", 22, -1, "QuestionType")
        cmd.Parameters("@QuestionType").Value = setNull(QuestionType)
        cmd.Parameters.Add("@QuestionNumber", 22, -1, "QuestionNumber")
        cmd.Parameters("@QuestionNumber").Value = setNull(QuestionNumber)
        cmd.Parameters.Add("@ParentQuestion", 22, 255, "ParentQuestion")
        cmd.Parameters("@ParentQuestion").Value = setNull(ParentQuestion)
        cmd.Parameters.Add("@TestID", 22, 255, "TestID")
        cmd.Parameters("@TestID").Value = setNull(TestID)
        cmd.Parameters.Add("@CaseStudy", 22, -1, "CaseStudy")
        cmd.Parameters("@CaseStudy").Value = setNull(CaseStudy)
        cmd.Parameters.Add("@Image", 21, -1, "Image")
        cmd.Parameters("@Image").Value = setNull(Image)
        cmd.Parameters.Add("@Option1", 22, -1, "Option1")
        cmd.Parameters("@Option1").Value = setNull(Option1)
        cmd.Parameters.Add("@Option2", 22, -1, "Option2")
        cmd.Parameters("@Option2").Value = setNull(Option2)
        cmd.Parameters.Add("@Option3", 22, -1, "Option3")
        cmd.Parameters("@Option3").Value = setNull(Option3)
        cmd.Parameters.Add("@Option4", 22, -1, "Option4")
        cmd.Parameters("@Option4").Value = setNull(Option4)
        cmd.Parameters.Add("@Mark", 6, 0, "Mark")
        cmd.Parameters("@Mark").Value = setNull(Mark)
        cmd.Parameters.Add("@Category_ID", 22, 255, "Category_ID")
        cmd.Parameters("@Category_ID").Value = setNull(Category_ID)
        cmd.Parameters.Add("@Section_ID", 8, 0, "Section_ID")
        cmd.Parameters("@Section_ID").Value = setNull(Section_ID)


        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub


    Sub delete()
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "delete from Question_Bank where id=@previous_id"
        cmd.Parameters.Add("@previous_id", 22, 255, "previous_id")
        cmd.Parameters("@previous_id").Value = Me.previous_id

        cmd.ExecuteNonQuery()
    End Sub


    Shared Function load(id As System.String) As Question_Bank
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "id,"
        If Display_Text = True Then cmd.CommandText = cmd.CommandText & "Text,"
        If Display_QuestionType = True Then cmd.CommandText = cmd.CommandText & "QuestionType,"
        If Display_QuestionType = True Then cmd.CommandText = cmd.CommandText & "QuestionNumber,"
        If Display_CaseStudy = True Then cmd.CommandText = cmd.CommandText & "CaseStudy,"
        If Display_Image = True Then cmd.CommandText = cmd.CommandText & "Image,"
        If Display_Option1 = True Then cmd.CommandText = cmd.CommandText & "Option1,"
        If Display_Option2 = True Then cmd.CommandText = cmd.CommandText & "Option2,"
        If Display_Option3 = True Then cmd.CommandText = cmd.CommandText & "Option3,"
        If Display_Option4 = True Then cmd.CommandText = cmd.CommandText & "Option4,"
        If Display_Mark = True Then cmd.CommandText = cmd.CommandText & "Mark,"
        If Display_ParentQuestion = True Then cmd.CommandText = cmd.CommandText & "ParentQuestion,"
        If Display_TestID = True Then cmd.CommandText = cmd.CommandText & "TestID,"
        If Display_Category_ID = True Then cmd.CommandText = cmd.CommandText & "Category_ID,"
        If Display_Section_ID = True Then cmd.CommandText = cmd.CommandText & "Section_ID,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Question_Bank where id=@id"
        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = id

        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        Dim p As New Question_Bank
        For i = 0 To dt.Rows.Count - 1
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_Text = True Then p.Text = checkNull(dt.Rows(i)("Text"))
            p.I_Display_Text = Display_Text
            If Display_QuestionType = True Then p.QuestionType = checkNull(dt.Rows(i)("QuestionType"))
            p.I_Display_QuestionType = Display_QuestionType
            If Display_QuestionNumber = True Then p.QuestionNumber = Convert.ToDouble(checkNumNull(dt.Rows(i)("QuestionNumber")))
            p.I_Display_QuestionNumber = Display_QuestionNumber
            If Display_ParentQuestion = True Then p.ParentQuestion = checkNull(dt.Rows(i)("ParentQuestion"))
            p.I_Display_ParentQuestion = Display_ParentQuestion
            If Display_TestID = True Then p.TestID = checkNull(dt.Rows(i)("TestID"))
            p.TestID = Display_TestID
            If Display_CaseStudy = True Then p.CaseStudy = checkNull(dt.Rows(i)("CaseStudy"))
            p.I_Display_CaseStudy = Display_CaseStudy
            If Display_Image = True Then p.Image = checkNull(dt.Rows(i)("Image"))
            p.I_Display_Image = Display_Image
            If Display_Option1 = True Then p.Option1 = checkNull(dt.Rows(i)("Option1"))
            p.I_Display_Option1 = Display_Option1
            If Display_Option2 = True Then p.Option2 = checkNull(dt.Rows(i)("Option2"))
            p.I_Display_Option2 = Display_Option2
            If Display_Option3 = True Then p.Option3 = checkNull(dt.Rows(i)("Option3"))
            p.I_Display_Option3 = Display_Option3
            If Display_Option4 = True Then p.Option4 = checkNull(dt.Rows(i)("Option4"))
            p.I_Display_Option4 = Display_Option4
            If Display_Mark = True Then p.Mark = checkNull(dt.Rows(i)("Mark"))
            p.I_Display_Mark = Display_Mark
            If Display_Category_ID = True Then p.Category_ID = checkNull(dt.Rows(i)("Category_ID"))
            p.I_Display_Category_ID = Display_Category_ID
            If Display_Section_ID = True Then p.Section_ID = checkNull(dt.Rows(i)("Section_ID"))
            p.I_Display_Section_ID = Display_Section_ID
            p.previous_id = checkNull(dt.Rows(i)("id"))
            p.newinstance = False
            Return p
        Next
        Return Nothing
    End Function


    Sub update()
        If newinstance = True Then
            insert()
            Return
        End If

        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "update Question_Bank set "
        cmd.CommandText = cmd.CommandText & " id=@id,"
        If I_Display_Text = True Then cmd.CommandText = cmd.CommandText & " Text=@Text,"
        If I_Display_QuestionType = True Then cmd.CommandText = cmd.CommandText & " QuestionType=@QuestionType,"
        If I_Display_QuestionNumber = True Then cmd.CommandText = cmd.CommandText & " QuestionNumber=@QuestionNumber,"
        If I_Display_ParentQuestion = True Then cmd.CommandText = cmd.CommandText & " ParentQuestion=@ParentQuestion,"
        If I_Display_ParentQuestion = True Then cmd.CommandText = cmd.CommandText & " TestID=@TestID,"
        If I_Display_CaseStudy = True Then cmd.CommandText = cmd.CommandText & " CaseStudy=@CaseStudy,"
        If I_Display_Image = True Then cmd.CommandText = cmd.CommandText & " Image=@Image,"
        If I_Display_Option1 = True Then cmd.CommandText = cmd.CommandText & " Option1=@Option1,"
        If I_Display_Option2 = True Then cmd.CommandText = cmd.CommandText & " Option2=@Option2,"
        If I_Display_Option3 = True Then cmd.CommandText = cmd.CommandText & " Option3=@Option3,"
        If I_Display_Option4 = True Then cmd.CommandText = cmd.CommandText & " Option4=@Option4,"
        If I_Display_Mark = True Then cmd.CommandText = cmd.CommandText & " Mark=@Mark,"
        If I_Display_Category_ID = True Then cmd.CommandText = cmd.CommandText & " Category_ID=@Category_ID,"
        If I_Display_Section_ID = True Then cmd.CommandText = cmd.CommandText & " Section_ID=@Section_ID,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " where id=@previous_id"


        cmd.Parameters.Add("@id", 22, 255, "id")
        cmd.Parameters("@id").Value = setNull(id)

        If I_Display_Text = True Then cmd.Parameters.Add("@Text", 22, -1, "Text")
        If I_Display_Text = True Then cmd.Parameters("@Text").Value = setNull(Text)

        If I_Display_QuestionType = True Then cmd.Parameters.Add("@QuestionType", 22, -1, "QuestionType")
        If I_Display_QuestionType = True Then cmd.Parameters("@QuestionType").Value = setNull(QuestionType)
        If I_Display_QuestionNumber = True Then cmd.Parameters.Add("@QuestionNumber", 22, -1, "QuestionNumber")
        If I_Display_QuestionNumber = True Then cmd.Parameters("@QuestionNumber").Value = setNull(QuestionNumber)
        If I_Display_ParentQuestion = True Then cmd.Parameters.Add("@ParentQuestion", 22, 255, "ParentQuestion")
        If I_Display_ParentQuestion = True Then cmd.Parameters("@ParentQuestion").Value = setNull(ParentQuestion)
        If I_Display_TestID = True Then cmd.Parameters.Add("@TestID", 22, 255, "TestID")
        If I_Display_TestID = True Then cmd.Parameters("@TestID").Value = setNull(TestID)

        If I_Display_CaseStudy = True Then cmd.Parameters.Add("@CaseStudy", 22, -1, "CaseStudy")
        If I_Display_CaseStudy = True Then cmd.Parameters("@CaseStudy").Value = setNull(CaseStudy)

        If I_Display_Image = True Then cmd.Parameters.Add("@Image", 21, -1, "Image")
        If I_Display_Image = True Then cmd.Parameters("@Image").Value = setNull(Image)

        If I_Display_Option1 = True Then cmd.Parameters.Add("@Option1", 22, -1, "Option1")
        If I_Display_Option1 = True Then cmd.Parameters("@Option1").Value = setNull(Option1)

        If I_Display_Option2 = True Then cmd.Parameters.Add("@Option2", 22, -1, "Option2")
        If I_Display_Option2 = True Then cmd.Parameters("@Option2").Value = setNull(Option2)

        If I_Display_Option3 = True Then cmd.Parameters.Add("@Option3", 22, -1, "Option3")
        If I_Display_Option3 = True Then cmd.Parameters("@Option3").Value = setNull(Option3)

        If I_Display_Option4 = True Then cmd.Parameters.Add("@Option4", 22, -1, "Option4")
        If I_Display_Option4 = True Then cmd.Parameters("@Option4").Value = setNull(Option4)

        If I_Display_Mark = True Then cmd.Parameters.Add("@Mark", 6, 0, "Mark")
        If I_Display_Mark = True Then cmd.Parameters("@Mark").Value = setNull(Mark)

        If I_Display_Category_ID = True Then cmd.Parameters.Add("@Category_ID", 22, 255, "Category_ID")
        If I_Display_Category_ID = True Then cmd.Parameters("@Category_ID").Value = setNull(Category_ID)

        If I_Display_Section_ID = True Then cmd.Parameters.Add("@Section_ID", 8, 0, "Section_ID")
        If I_Display_Section_ID = True Then cmd.Parameters("@Section_ID").Value = setNull(Section_ID)



        cmd.Parameters.Add("@previous_id", 22, 255, "previous_id")
        cmd.Parameters("@previous_id").Value = Me.previous_id



        cmd.ExecuteNonQuery()
        newinstance = False
    End Sub


    Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Question_Bank)
        Dim ps As New Generic.List(Of Question_Bank)
        Dim cmd As New SqlCommand
        cmd.Connection = HttpContext.Current.Session("conn")
        If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select "
        cmd.CommandText = cmd.CommandText & "id,"
        If Display_Text = True Then cmd.CommandText = cmd.CommandText & "Text,"
        If Display_QuestionType = True Then cmd.CommandText = cmd.CommandText & "QuestionType,"
        If Display_QuestionType = True Then cmd.CommandText = cmd.CommandText & "QuestionNumber,"
        If Display_QuestionType = True Then cmd.CommandText = cmd.CommandText & "ParentQuestion,"
        If Display_QuestionType = True Then cmd.CommandText = cmd.CommandText & "TestID,"
        If Display_CaseStudy = True Then cmd.CommandText = cmd.CommandText & "CaseStudy,"
        If Display_Image = True Then cmd.CommandText = cmd.CommandText & "Image,"
        If Display_Option1 = True Then cmd.CommandText = cmd.CommandText & "Option1,"
        If Display_Option2 = True Then cmd.CommandText = cmd.CommandText & "Option2,"
        If Display_Option3 = True Then cmd.CommandText = cmd.CommandText & "Option3,"
        If Display_Option4 = True Then cmd.CommandText = cmd.CommandText & "Option4,"
        If Display_Mark = True Then cmd.CommandText = cmd.CommandText & "Mark,"
        If Display_Category_ID = True Then cmd.CommandText = cmd.CommandText & "Category_ID,"
        If Display_Section_ID = True Then cmd.CommandText = cmd.CommandText & "Section_ID,"
        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 1)
        cmd.CommandText = cmd.CommandText & " from Question_Bank " & filterstr & " " & sortstr
        Dim pl As New SqlDataAdapter, dt As New DataTable, i As Integer
        pl.SelectCommand = cmd
        pl.Fill(dt)
        For i = 0 To dt.Rows.Count - 1
            Dim p As New Question_Bank
            p.id = checkNull(dt.Rows(i)("id"))
            p.I_Display_id = Display_id
            If Display_Text = True Then p.Text = checkNull(dt.Rows(i)("Text"))
            p.I_Display_Text = Display_Text
            If Display_QuestionType = True Then p.QuestionType = checkNull(dt.Rows(i)("QuestionType"))
            p.I_Display_QuestionType = Display_QuestionType
            If Display_QuestionNumber = True Then p.QuestionNumber = Convert.ToDouble(checkNumNull(dt.Rows(i)("QuestionNumber")))
            p.I_Display_QuestionNumber = Display_QuestionNumber
            If Display_ParentQuestion = True Then p.ParentQuestion = checkNull(dt.Rows(i)("ParentQuestion"))
            p.I_Display_ParentQuestion = Display_ParentQuestion
            If Display_TestID = True Then p.TestID = checkNull(dt.Rows(i)("TestID"))
            p.TestID = Display_TestID
            If Display_CaseStudy = True Then p.CaseStudy = checkNull(dt.Rows(i)("CaseStudy"))
            p.I_Display_CaseStudy=Display_CaseStudy
if Display_Image=true then p.Image=checknull(dt.Rows(i)("Image"))
p.I_Display_Image=Display_Image
if Display_Option1=true then p.Option1=checknull(dt.Rows(i)("Option1"))
p.I_Display_Option1=Display_Option1
if Display_Option2=true then p.Option2=checknull(dt.Rows(i)("Option2"))
p.I_Display_Option2=Display_Option2
if Display_Option3=true then p.Option3=checknull(dt.Rows(i)("Option3"))
p.I_Display_Option3=Display_Option3
if Display_Option4=true then p.Option4=checknull(dt.Rows(i)("Option4"))
p.I_Display_Option4=Display_Option4
if Display_Mark=true then p.Mark=checknull(dt.Rows(i)("Mark"))
p.I_Display_Mark=Display_Mark
if Display_Category_ID=true then p.Category_ID=checknull(dt.Rows(i)("Category_ID"))
p.I_Display_Category_ID=Display_Category_ID
if Display_Section_ID=true then p.Section_ID=checknull(dt.Rows(i)("Section_ID"))
p.I_Display_Section_ID=Display_Section_ID
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


Shared Function listallPKOnly(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Question_Bank)
Dim ps As New Generic.List(Of Question_Bank)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select id from Question_Bank" & filterstr & " " & sortstr
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Question_Bank
p.id=checknull(dt.Rows(i)("id"))
p.previous_id=checknull(dt.Rows(i)("id"))
p.newinstance = False
ps.add(p)
Next
Return ps
End Function


End Class