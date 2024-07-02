Imports System
Imports System.Web.UI

Public Class NewAssessment
    Inherits System.Web.UI.Page

    'variables
    Private testId As Integer = 1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

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

        ' Create and insert new Test
        Dim newTest As New Test()
        newTest.id = 1
        testId = newTest.id
        newTest.course_id = courseId
        newTest.title = assessmentName
        newTest.date_started = openDateTime
        newTest.end_date = closeDateTime
        newTest.update()
        testId = newTest.id
    End Sub

    Protected Sub btnAddQuestion_Click(sender As Object, e As EventArgs)
        AddQuestion()
    End Sub
    Protected Sub AddQuestion()

        ' Get question values from form
        Dim questionText As String = Request.Form("questionText")
        Dim questionType As String = Request.Form("questionType")
        ' Create and insert new Question_Bank: Using Category id as type indicator
        Dim newQuestion As New Question_Bank()
        newQuestion.id = 0
        newQuestion.TestID = testId
        newQuestion.Text = questionText
        newQuestion.Category_ID = questionType
        newQuestion.Option1 = answerA.Value
        newQuestion.Option2 = answerB.Value
        newQuestion.Option3 = answerC.Value
        newQuestion.Option4 = answerD.Value
        newQuestion.Mark = CDbl(mark.Value)

        newQuestion.update()
        Dim questionId As Integer = newQuestion.id

        ' If multiple choice, add answers
        If questionType = "multipleChoice" Then
            Dim answer As New Answer()
            answer.id = 0
            answer.Answer = correctAnswer.Value
            answer.question_id = newQuestion.id
            answer.update()
        End If

        ' Clear the form for the next question
        ClearQuestionForm()
    End Sub

    Private Sub ClearQuestionForm()
        ' Logic to clear the question form fields
        'questionText.Text = ""
        ' answerA.Text = ""
        ' answerB.Text = ""
        ' answerC.Text = ""
        '  answerD.Text = ""
        correctAnswer.SelectedIndex = 0
    End Sub

    Protected Sub AddAnotherQuestion(ByVal sender As Object, ByVal e As EventArgs)
        ' Add question without creating a new test
        AddQuestion()
        ' Update the UI for new question
        Response.Redirect(Request.Url.AbsoluteUri)
    End Sub


End Class
