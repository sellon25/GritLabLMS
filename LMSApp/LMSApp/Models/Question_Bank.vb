Imports microsoft.visualbasic
Imports System.Data.SqlClient
Imports system.data

Public Class Question_Bank
inherits Entity

Public Shared Display_id as Boolean=true
Public Shared Display_Text as Boolean=true
Public Shared Display_CaseStudy as Boolean=true
Public Shared Display_Image as Boolean=true
Public Shared Display_Option1 as Boolean=true
Public Shared Display_Option2 as Boolean=true
Public Shared Display_Option3 as Boolean=true
Public Shared Display_Option4 as Boolean=true
Public Shared Display_Mark as Boolean=true
Public Shared Display_Category_ID as Boolean=true
Public Shared Display_Section_ID as Boolean=true

Private I_Display_id as Boolean=true
Private I_Display_Text as Boolean=true
Private I_Display_CaseStudy as Boolean=true
Private I_Display_Image as Boolean=true
Private I_Display_Option1 as Boolean=true
Private I_Display_Option2 as Boolean=true
Private I_Display_Option3 as Boolean=true
Private I_Display_Option4 as Boolean=true
Private I_Display_Mark as Boolean=true
Private I_Display_Category_ID as Boolean=true
Private I_Display_Section_ID as Boolean=true

Public previous_id as System.String

Public id as System.String
Public Text as System.String
Public CaseStudy as System.String
Public Image as System.Byte()
Public Option1 as System.String
Public Option2 as System.String
Public Option3 as System.String
Public Option4 as System.String
Public Mark as nullable(of System.Double)
Public Category_ID as System.String
Public Section_ID as nullable(of System.Int32)
Private newinstance As Boolean = True

Shared Sub Set_Display_Field_All(display_flag as boolean)
Display_id=display_flag
Display_Text=display_flag
Display_CaseStudy=display_flag
Display_Image=display_flag
Display_Option1=display_flag
Display_Option2=display_flag
Display_Option3=display_flag
Display_Option4=display_flag
Display_Mark=display_flag
Display_Category_ID=display_flag
Display_Section_ID=display_flag
End Sub


Private Sub insert()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "insert into Question_Bank (id,Text,CaseStudy,Image,Option1,Option2,Option3,Option4,Mark,Category_ID,Section_ID)"
cmd.CommandText = cmd.CommandText & "values(@id,@Text,@CaseStudy,@Image,@Option1,@Option2,@Option3,@Option4,@Mark,@Category_ID,@Section_ID)"

cmd.Parameters.Add("@id" , 22 , 255 , "id")
cmd.Parameters("@id").Value = SetNull(id)
cmd.Parameters.Add("@Text" , 22 , -1 , "Text")
cmd.Parameters("@Text").Value = SetNull(Text)
cmd.Parameters.Add("@CaseStudy" , 22 , -1 , "CaseStudy")
cmd.Parameters("@CaseStudy").Value = SetNull(CaseStudy)
cmd.Parameters.Add("@Image" , 21 , -1 , "Image")
cmd.Parameters("@Image").Value = SetNull(Image)
cmd.Parameters.Add("@Option1" , 22 , -1 , "Option1")
cmd.Parameters("@Option1").Value = SetNull(Option1)
cmd.Parameters.Add("@Option2" , 22 , -1 , "Option2")
cmd.Parameters("@Option2").Value = SetNull(Option2)
cmd.Parameters.Add("@Option3" , 22 , -1 , "Option3")
cmd.Parameters("@Option3").Value = SetNull(Option3)
cmd.Parameters.Add("@Option4" , 22 , -1 , "Option4")
cmd.Parameters("@Option4").Value = SetNull(Option4)
cmd.Parameters.Add("@Mark" , 6 , 0 , "Mark")
cmd.Parameters("@Mark").Value = SetNull(Mark)
cmd.Parameters.Add("@Category_ID" , 22 , 255 , "Category_ID")
cmd.Parameters("@Category_ID").Value = SetNull(Category_ID)
cmd.Parameters.Add("@Section_ID" , 8 , 0 , "Section_ID")
cmd.Parameters("@Section_ID").Value = SetNull(Section_ID)


cmd.ExecuteNonQuery()
newinstance = False
End Sub


Sub delete()
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "delete from Question_Bank where id=@previous_id"
cmd.Parameters.Add("@previous_id", 22, 255, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id

cmd.ExecuteNonQuery()
End Sub


Shared Function load(id as System.String) As Question_Bank
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_Text=true then cmd.CommandText = cmd.CommandText & "Text,"
if Display_CaseStudy=true then cmd.CommandText = cmd.CommandText & "CaseStudy,"
if Display_Image=true then cmd.CommandText = cmd.CommandText & "Image,"
if Display_Option1=true then cmd.CommandText = cmd.CommandText & "Option1,"
if Display_Option2=true then cmd.CommandText = cmd.CommandText & "Option2,"
if Display_Option3=true then cmd.CommandText = cmd.CommandText & "Option3,"
if Display_Option4=true then cmd.CommandText = cmd.CommandText & "Option4,"
if Display_Mark=true then cmd.CommandText = cmd.CommandText & "Mark,"
if Display_Category_ID=true then cmd.CommandText = cmd.CommandText & "Category_ID,"
if Display_Section_ID=true then cmd.CommandText = cmd.CommandText & "Section_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Question_Bank where id=@id"
cmd.Parameters.Add("@id", 22, 255, "id")
cmd.Parameters("@id").Value = id

Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
Dim p As New Question_Bank
For i = 0 To dt.Rows.Count - 1
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_Text=true then p.Text=checknull(dt.Rows(i)("Text"))
p.I_Display_Text=Display_Text
if Display_CaseStudy=true then p.CaseStudy=checknull(dt.Rows(i)("CaseStudy"))
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
Return p
Next
Return Nothing
End Function


Sub update()
If newinstance = True Then
insert()
Return
End If

Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "update Question_Bank set "
cmd.CommandText =cmd.CommandText & " id=@id,"
if I_Display_Text=true then cmd.CommandText =cmd.CommandText & " Text=@Text,"
if I_Display_CaseStudy=true then cmd.CommandText =cmd.CommandText & " CaseStudy=@CaseStudy,"
if I_Display_Image=true then cmd.CommandText =cmd.CommandText & " Image=@Image,"
if I_Display_Option1=true then cmd.CommandText =cmd.CommandText & " Option1=@Option1,"
if I_Display_Option2=true then cmd.CommandText =cmd.CommandText & " Option2=@Option2,"
if I_Display_Option3=true then cmd.CommandText =cmd.CommandText & " Option3=@Option3,"
if I_Display_Option4=true then cmd.CommandText =cmd.CommandText & " Option4=@Option4,"
if I_Display_Mark=true then cmd.CommandText =cmd.CommandText & " Mark=@Mark,"
if I_Display_Category_ID=true then cmd.CommandText =cmd.CommandText & " Category_ID=@Category_ID,"
if I_Display_Section_ID=true then cmd.CommandText =cmd.CommandText & " Section_ID=@Section_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " where id=@previous_id"


cmd.Parameters.Add("@id", 22, 255, "id")
cmd.Parameters("@id").Value = SetNull(id)

if I_Display_Text=true then cmd.Parameters.Add("@Text", 22, -1, "Text")
if I_Display_Text=true then cmd.Parameters("@Text").Value = SetNull(Text)

if I_Display_CaseStudy=true then cmd.Parameters.Add("@CaseStudy", 22, -1, "CaseStudy")
if I_Display_CaseStudy=true then cmd.Parameters("@CaseStudy").Value = SetNull(CaseStudy)

if I_Display_Image=true then cmd.Parameters.Add("@Image", 21, -1, "Image")
if I_Display_Image=true then cmd.Parameters("@Image").Value = SetNull(Image)

if I_Display_Option1=true then cmd.Parameters.Add("@Option1", 22, -1, "Option1")
if I_Display_Option1=true then cmd.Parameters("@Option1").Value = SetNull(Option1)

if I_Display_Option2=true then cmd.Parameters.Add("@Option2", 22, -1, "Option2")
if I_Display_Option2=true then cmd.Parameters("@Option2").Value = SetNull(Option2)

if I_Display_Option3=true then cmd.Parameters.Add("@Option3", 22, -1, "Option3")
if I_Display_Option3=true then cmd.Parameters("@Option3").Value = SetNull(Option3)

if I_Display_Option4=true then cmd.Parameters.Add("@Option4", 22, -1, "Option4")
if I_Display_Option4=true then cmd.Parameters("@Option4").Value = SetNull(Option4)

if I_Display_Mark=true then cmd.Parameters.Add("@Mark", 6, 0, "Mark")
if I_Display_Mark=true then cmd.Parameters("@Mark").Value = SetNull(Mark)

if I_Display_Category_ID=true then cmd.Parameters.Add("@Category_ID", 22, 255, "Category_ID")
if I_Display_Category_ID=true then cmd.Parameters("@Category_ID").Value = SetNull(Category_ID)

if I_Display_Section_ID=true then cmd.Parameters.Add("@Section_ID", 8, 0, "Section_ID")
if I_Display_Section_ID=true then cmd.Parameters("@Section_ID").Value = SetNull(Section_ID)



cmd.Parameters.Add("@previous_id", 22, 255, "previous_id")
cmd.Parameters("@previous_id").Value = Me.previous_id



cmd.ExecuteNonQuery()
newinstance = False
End Sub


Shared Function listall(Optional ByVal filterstr As String = Nothing, Optional ByVal sortstr As String = Nothing) As System.Collections.Generic.List(Of Question_Bank)
Dim ps As New Generic.List(Of Question_Bank)
Dim cmd As New sqlCommand
cmd.Connection = HttpContext.Current.Session("conn")
If Not IsNothing(HttpContext.Current.Session("trans")) Then cmd.Transaction = HttpContext.Current.Session("trans")
cmd.CommandType = CommandType.Text
cmd.CommandText = "select "
cmd.CommandText = cmd.CommandText & "id,"
if Display_Text=true then cmd.CommandText = cmd.CommandText & "Text,"
if Display_CaseStudy=true then cmd.CommandText = cmd.CommandText & "CaseStudy,"
if Display_Image=true then cmd.CommandText = cmd.CommandText & "Image,"
if Display_Option1=true then cmd.CommandText = cmd.CommandText & "Option1,"
if Display_Option2=true then cmd.CommandText = cmd.CommandText & "Option2,"
if Display_Option3=true then cmd.CommandText = cmd.CommandText & "Option3,"
if Display_Option4=true then cmd.CommandText = cmd.CommandText & "Option4,"
if Display_Mark=true then cmd.CommandText = cmd.CommandText & "Mark,"
if Display_Category_ID=true then cmd.CommandText = cmd.CommandText & "Category_ID,"
if Display_Section_ID=true then cmd.CommandText = cmd.CommandText & "Section_ID,"
cmd.CommandText = cmd.CommandText.Substring(0,cmd.CommandText.Length-1)
cmd.CommandText = cmd.CommandText & " from Question_Bank " & filterstr & " " & sortstr 
Dim pl As New sqlDataAdapter, dt As New DataTable, i As Integer
pl.SelectCommand = cmd
pl.Fill(dt)
For i = 0 To dt.Rows.Count - 1
Dim p As New Question_Bank
p.id=checknull(dt.Rows(i)("id"))
p.I_Display_id=Display_id
if Display_Text=true then p.Text=checknull(dt.Rows(i)("Text"))
p.I_Display_Text=Display_Text
if Display_CaseStudy=true then p.CaseStudy=checknull(dt.Rows(i)("CaseStudy"))
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