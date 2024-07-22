Imports System
Imports System.Web.UI

Public Class NewAssessment
    Inherits System.Web.UI.Page

    'variables
    Private testId As Integer
    Private testCreated As Boolean = False
    Private tempId As Integer = 6

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            hfTestCreated.Value = "false"
        Else

            ' Handle potential issues with converting the test ID and test created status
            If Not String.IsNullOrEmpty(hfTestId.Value) AndAlso IsNumeric(hfTestId.Value) Then
                testId = Convert.ToInt32(hfTestId.Value)
            End If

            If Not String.IsNullOrEmpty(hfTestCreated.Value) Then
                testCreated = Convert.ToBoolean(hfTestCreated.Value)
            End If

        End If
    End Sub

    Protected Sub SubmitAssessment(ByVal sender As Object, ByVal e As EventArgs)


        ' Add the first question
        AddQuestion()

        ' Redirect or update the UI as needed
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub

    Protected Sub btnCreateTest_Click(sender As Object, e As EventArgs)
        ' Get values from form
        Dim assessmentName As String = Request.Form("assessmentName")
        Dim openDateTime As DateTime = DateTime.Parse(Request.Form("openDateTime"))
        Dim closeDateTime As DateTime = DateTime.Parse(Request.Form("closeDateTime"))
        Dim courseId As Integer = Integer.Parse(Request.QueryString("courseId"))

        If hfTestCreated.Value = "true" Then
            ' update Test
            Dim updateTest = Test.load(testId)
            updateTest.course_id = courseId
            updateTest.title = assessmentName
            updateTest.date_started = openDateTime
            updateTest.end_date = closeDateTime
            updateTest.update()
        Else
            ' Create and insert new Test
            Dim newTest As New Test()
            newTest.id = New database_operations().GetNewPrimaryKey("id", "Test", HttpContext.Current.Session("conn"))
            newTest.course_id = courseId
            newTest.title = assessmentName
            newTest.date_started = openDateTime
            newTest.end_date = closeDateTime
            newTest.update()
            testId = newTest.id
            hfTestId.Value = testId.ToString()
            hfTestCreated.Value = "true"
            testCreated = True
        End If
        MsgBox("Test Created: Proceed Add Questions")
    End Sub

    Protected Sub btnAddQuestion_Click(sender As Object, e As EventArgs)
        AddQuestion()
    End Sub
    Protected Sub AddQuestion()

        ' Get question values from form

        Dim questionType As String = Request.Form("questionType")
        ' Create and insert new Question_Bank: Using Category id as type indicator
        Dim newQuestion As New Question_Bank()
        newQuestion.id = New database_operations().GetNewPrimaryKey("id", "Question_Bank", HttpContext.Current.Session("conn"))
        newQuestion.TestID = testId
        newQuestion.Text = questionText.Value
        newQuestion.QuestionType = questionType

        Select Case questionType
            Case "multipleChoice"
                newQuestion.Option1 = answerA.Value
                newQuestion.Option2 = answerB.Value
                newQuestion.Option3 = answerC.Value
                newQuestion.Option4 = answerD.Value
        End Select

        newQuestion.Mark = CDbl(mark.Value)

        Dim questionImage As Byte() = Nothing
        If newQuestionImage.HasFile Then
            questionImage = newQuestionImage.FileBytes
        End If

        newQuestion.QuestionNumber = questionNumber.Value
        newQuestion.Image = questionImage

        newQuestion.update()

        ' If multiple choice, add answers
        If questionType = "multipleChoice" Then
            Dim answer As New Answer()
            answer.id = New database_operations().GetNewPrimaryKey("id", "Answer", HttpContext.Current.Session("conn"))
            answer.Answer = correctAnswer.Value
            answer.question_id = newQuestion.id
            answer.update()
        End If

        ' Clear the form for the next question
        ClearQuestionForm()
    End Sub

    Private Sub ClearQuestionForm()
        questionText.Value = ""
        answerA.Value = ""
        answerB.Value = ""
        answerC.Value = ""
        answerD.Value = ""
        questionNumber.Value = ""
        mark.Value = ""
        correctAnswer.SelectedIndex = 0
    End Sub

    Protected Sub AddAnotherQuestion(ByVal sender As Object, ByVal e As EventArgs)
        ' Add question without creating a new test
        AddQuestion()
        ' Update the UI for new question
        'Response.Redirect(Request.Url.AbsoluteUri)
    End Sub


End Class
