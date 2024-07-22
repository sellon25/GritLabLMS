Imports System.IO

Public Class EditAssessment
    Inherits System.Web.UI.Page

    ' Store the question list to use in the event handler
    Private questions As List(Of Question_Bank)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadtest()
        Else
            questions = CType(Session("questions"), List(Of Question_Bank))
            RebuildUI()
        End If
    End Sub


    Private Sub loadtest()
        Dim filter As String = "WHERE TestID ='" & Request.QueryString("testId") & "'"
        editAssessment.Controls.Clear()

        ' Get the list of questions based on the filter
        questions = Question_Bank.listall(filter)
        Session("questions") = questions ' Store in session

        RebuildUI()
    End Sub

    Private Sub RebuildUI()
        Dim questionIDs As New List(Of String)

        ' Create a container for all questions
        Dim questionsContainer As New HtmlGenericControl("div")
        questionsContainer.Attributes("id") = "questionsContainer"

        For Each question As Question_Bank In questions
            questionIDs.Add(question.id.ToString())
            Dim questionDiv As HtmlGenericControl = CreateQuestionHtml(question)
            questionDiv.Attributes("class") = "question"
            questionDiv.Style.Add("display", "none")
            questionsContainer.Controls.Add(questionDiv)
        Next

        ' Determine the question index to show
        Dim questionIndex As Integer = 0
        If Not String.IsNullOrEmpty(Request.QueryString("questionIndex")) Then
            Integer.TryParse(Request.QueryString("questionIndex"), questionIndex)
            If questionIndex < 0 OrElse questionIndex >= questions.Count Then
                questionIndex = 0
            End If
        End If

        ' Show the specific question
        If questionsContainer.Controls.Count > 0 Then
            CType(questionsContainer.Controls(questionIndex), HtmlGenericControl).Style.Add("display", "block")
        End If

        editAssessment.Controls.Add(questionsContainer)

        ' Create navigation dots and buttons
        Dim navContainer As New HtmlGenericControl("div")
        navContainer.Attributes("id") = "navContainer"
        navContainer.Attributes("class") = "nav-container"
        navContainer.Attributes("style") = "text-align:center;"

        Dim prevButton As New HtmlGenericControl("span")
        prevButton.InnerText = "<<prev"
        prevButton.Attributes("class") = "nav-button"
        prevButton.Attributes("onclick") = "showPreviousQuestion()"
        navContainer.Controls.Add(prevButton)

        For i As Integer = 0 To questionIDs.Count - 1
            Dim dot As New HtmlGenericControl("span")
            dot.Attributes("class") = "dot"
            dot.Attributes("onclick") = "showQuestion(" & i & ")"
            navContainer.Controls.Add(dot)
        Next

        Dim nextButton As New HtmlGenericControl("span")
        nextButton.InnerText = "next>>"
        nextButton.Attributes("class") = "nav-button"
        nextButton.Attributes("onclick") = "showNextQuestion()"
        navContainer.Controls.Add(nextButton)

        editAssessment.Controls.Add(navContainer)

        ' Store the question IDs in a hidden field
        Dim hiddenField As New HiddenField()
        hiddenField.ID = "hiddenQuestionIDs"
        hiddenField.Value = String.Join(",", questionIDs)
        editAssessment.Controls.Add(hiddenField)

        ' Add JavaScript for navigation
        Dim script As New LiteralControl()
        script.Text = "<script type='text/javascript'>
                    var currentQuestionIndex = " & questionIndex & ";

                    function showQuestion(index) {
                        var questions = document.getElementsByClassName('question');
                        for (var i = 0; i < questions.length; i++) {
                            questions[i].style.display = 'none';
                        }
                        questions[index].style.display = 'block';
                        var dots = document.getElementsByClassName('dot');
                        for (var i = 0; i < dots.length; i++) {
                            dots[i].classList.remove('active');
                        }
                        dots[index].classList.add('active');
                        currentQuestionIndex = index;
                       
                    }

                    function showPreviousQuestion() {
                        if (currentQuestionIndex > 0) {
                            showQuestion(currentQuestionIndex - 1);
                            window.scrollTo(0, 0);
                        }
                    }

                    function showNextQuestion() {
                        var questions = document.getElementsByClassName('question');
                        if (currentQuestionIndex < questions.length - 1) {
                            showQuestion(currentQuestionIndex + 1);
                             window.scrollTo(0, 0);
                        }
                    }
                   </script>"
        editAssessment.Controls.Add(script)
    End Sub



    Private Function CreateQuestionHtml(question As Question_Bank) As HtmlGenericControl
        Dim questionContainer As New HtmlGenericControl("div")
        questionContainer.ID = "question-" & question.id.ToString()
        questionContainer.Attributes("class") = "question-container"

        ' Question number
        Dim questionNumberDiv As New HtmlGenericControl("div")
        questionNumberDiv.Attributes("class") = "form-group"
        Dim questionNumberLabel As New HtmlGenericControl("label")
        questionNumberLabel.Attributes("for") = "questionNumber-" & question.id.ToString()
        questionNumberLabel.InnerText = "Question Number:"
        questionNumberDiv.Controls.Add(questionNumberLabel)
        Dim questionNumberInput As New HtmlInputText()
        questionNumberInput.Attributes("runat") = "server"
        questionNumberInput.ID = "questionNumber-" & question.id.ToString()
        questionNumberInput.Value = question.QuestionNumber
        questionNumberInput.Attributes("class") = "form-control"
        questionNumberDiv.Controls.Add(questionNumberInput)
        questionContainer.Controls.Add(questionNumberDiv)

        ' Question text
        Dim questionTextDiv As New HtmlGenericControl("div")
        questionTextDiv.Attributes("class") = "form-group"
        Dim questionTextLabel As New HtmlGenericControl("label")
        questionTextLabel.Attributes("for") = "questionText-" & question.id.ToString()
        questionTextLabel.InnerText = "Question Text:"
        questionTextDiv.Controls.Add(questionTextLabel)
        Dim questionTextInput As New HtmlInputText()
        questionTextInput.Attributes("runat") = "server"
        questionTextInput.ID = "questionText-" & question.id.ToString()
        questionTextInput.Value = question.Text
        questionTextInput.Attributes("class") = "form-control"
        questionTextDiv.Controls.Add(questionTextInput)
        questionContainer.Controls.Add(questionTextDiv)

        ' Create the label and FileUpload for the question image
        Dim questionImageLabel As New HtmlGenericControl("label")
        questionImageLabel.Attributes("for") = "questionImage_" & question.id
        questionImageLabel.InnerText = "Change Question Image:"

        ' File upload control for updating the image
        Dim questionImageUpload As New FileUpload()
        questionImageUpload.ID = "questionImage_" & question.id
        questionImageUpload.CssClass = "form-control-file"
        questionImageUpload.Attributes("runat") = "server"

        questionContainer.Controls.Add(questionImageLabel)
        questionContainer.Controls.Add(questionImageUpload)

        ' Display the current image if it exists
        If question.Image IsNot Nothing AndAlso question.Image.Length > 0 Then
            Dim base64Image As String = Convert.ToBase64String(question.Image)
            Dim imgSrc As String = "data:image/png;base64," & base64Image
            Dim questionImage As New HtmlGenericControl("img")
            questionImage.Attributes("src") = imgSrc
            questionImage.Attributes("class") = "img-fluid"
            questionImage.Attributes("style") = "width: 40%; height: auto;"
            questionImage.Attributes("alt") = "Question Image"
            questionContainer.Controls.Add(questionImage)
        End If



        ' Option A
        Dim answerADiv As New HtmlGenericControl("div")
        answerADiv.Attributes("class") = "form-group"
        Dim answerALabel As New HtmlGenericControl("label")
        answerALabel.Attributes("for") = "answerA-" & question.id.ToString()
        answerALabel.InnerText = "Answer A:"
        answerADiv.Controls.Add(answerALabel)
        Dim answerAInput As New HtmlInputText()
        answerAInput.Attributes("runat") = "server"
        answerAInput.ID = "answerA-" & question.id.ToString()
        answerAInput.Value = question.Option1
        answerAInput.Attributes("class") = "form-control"
        answerADiv.Controls.Add(answerAInput)
        questionContainer.Controls.Add(answerADiv)

        ' Option B
        Dim answerBDiv As New HtmlGenericControl("div")
        answerBDiv.Attributes("class") = "form-group"
        Dim answerBLabel As New HtmlGenericControl("label")
        answerBLabel.Attributes("for") = "answerB-" & question.id.ToString()
        answerBLabel.InnerText = "Answer B:"
        answerBDiv.Controls.Add(answerBLabel)
        Dim answerBInput As New HtmlInputText()
        answerBInput.Attributes("runat") = "server"
        answerBInput.ID = "answerB-" & question.id.ToString()
        answerBInput.Value = question.Option2
        answerBInput.Attributes("class") = "form-control"
        answerBDiv.Controls.Add(answerBInput)
        questionContainer.Controls.Add(answerBDiv)

        ' Option C
        Dim answerCDiv As New HtmlGenericControl("div")
        answerCDiv.Attributes("class") = "form-group"
        Dim answerCLabel As New HtmlGenericControl("label")
        answerCLabel.Attributes("for") = "answerC-" & question.id.ToString()
        answerCLabel.InnerText = "Answer C:"
        answerCDiv.Controls.Add(answerCLabel)
        Dim answerCInput As New HtmlInputText()
        answerCInput.Attributes("runat") = "server"
        answerCInput.ID = "answerC-" & question.id.ToString()
        answerCInput.Value = question.Option3
        answerCInput.Attributes("class") = "form-control"
        answerCDiv.Controls.Add(answerCInput)
        questionContainer.Controls.Add(answerCDiv)

        ' Option D
        Dim answerDDiv As New HtmlGenericControl("div")
        answerDDiv.Attributes("class") = "form-group"
        Dim answerDLabel As New HtmlGenericControl("label")
        answerDLabel.Attributes("for") = "answerD-" & question.id.ToString()
        answerDLabel.InnerText = "Answer D:"
        answerDDiv.Controls.Add(answerDLabel)
        Dim answerDInput As New HtmlInputText()
        answerDInput.Attributes("runat") = "server"
        answerDInput.ID = "answerD-" & question.id.ToString()
        answerDInput.Value = question.Option4
        answerDInput.Attributes("class") = "form-control"
        answerDDiv.Controls.Add(answerDInput)
        questionContainer.Controls.Add(answerDDiv)

        ' Correct answer
        Dim correctAnswer As New Answer
        Dim filter As String = "WHERE question_id = '" & question.id & "'"
        Dim answerList As List(Of Answer) = Answer.listall(filter)

        For Each a In answerList
            correctAnswer = a
        Next

        Dim correctAnswerDiv As New HtmlGenericControl("div")
        correctAnswerDiv.Attributes("class") = "form-group"
        Dim correctAnswerLabel As New HtmlGenericControl("label")
        correctAnswerLabel.Attributes("for") = "correctAnswer-" & question.id.ToString()
        correctAnswerLabel.InnerText = "Correct Answer:"
        correctAnswerDiv.Controls.Add(correctAnswerLabel)
        Dim correctAnswerInput As New HtmlInputText()
        correctAnswerInput.Attributes("runat") = "server"
        correctAnswerInput.ID = "correctAnswer-" & question.id.ToString()
        correctAnswerInput.Value = correctAnswer.Answer
        correctAnswerInput.Attributes("class") = "form-control"
        correctAnswerDiv.Controls.Add(correctAnswerInput)
        questionContainer.Controls.Add(correctAnswerDiv)

        ' Mark
        Dim markDiv As New HtmlGenericControl("div")
        markDiv.Attributes("class") = "form-group"
        Dim markLabel As New HtmlGenericControl("label")
        markLabel.Attributes("for") = "mark-" & question.id.ToString()
        markLabel.InnerText = "Mark:"
        markDiv.Controls.Add(markLabel)
        Dim markInput As New HtmlInputText()
        markInput.Attributes("runat") = "server"
        markInput.ID = "mark-" & question.id.ToString()
        markInput.Value = question.Mark
        markInput.Attributes("class") = "form-control"
        markDiv.Controls.Add(markInput)
        questionContainer.Controls.Add(markDiv)

        ' Add a thin line to separate questions
        Dim separator As New HtmlGenericControl("hr")
        questionContainer.Controls.Add(separator)

        ' Update Question Button
        Dim updateButton As New Button()
        updateButton.Text = "Update Question"
        updateButton.CssClass = "btn btn-primary"
        AddHandler updateButton.Click, AddressOf Me.UpdateQuestion_Click
        updateButton.CommandArgument = question.id.ToString()
        questionContainer.Controls.Add(updateButton)

        Return questionContainer
    End Function


    Protected Sub UpdateQuestion_Click(sender As Object, e As EventArgs)
        Dim button As Button = CType(sender, Button)
        Dim questionId As Integer = Convert.ToInt32(button.CommandArgument)
        Dim questionDiv As HtmlGenericControl = CType(editAssessment.FindControl("question-" & questionId.ToString()), HtmlGenericControl)

        If questionDiv Is Nothing Then
            ' Handle case where questionDiv is not found
            Return
        End If

        Dim questionNumberInput As HtmlInputText = CType(questionDiv.FindControl("questionNumber-" & questionId.ToString()), HtmlInputText)
        Dim questionTextInput As HtmlInputText = CType(questionDiv.FindControl("questionText-" & questionId.ToString()), HtmlInputText)
        Dim answerAInput As HtmlInputText = CType(questionDiv.FindControl("answerA-" & questionId.ToString()), HtmlInputText)
        Dim answerBInput As HtmlInputText = CType(questionDiv.FindControl("answerB-" & questionId.ToString()), HtmlInputText)
        Dim answerCInput As HtmlInputText = CType(questionDiv.FindControl("answerC-" & questionId.ToString()), HtmlInputText)
        Dim answerDInput As HtmlInputText = CType(questionDiv.FindControl("answerD-" & questionId.ToString()), HtmlInputText)
        Dim correctAnswerInput As HtmlInputText = CType(questionDiv.FindControl("correctAnswer-" & questionId.ToString()), HtmlInputText)
        Dim markInput As HtmlInputText = CType(questionDiv.FindControl("mark-" & questionId.ToString()), HtmlInputText)
        Dim questionImageUpload As FileUpload = CType(questionDiv.FindControl("questionImage_" & questionId.ToString()), FileUpload)


        If questionNumberInput Is Nothing OrElse questionTextInput Is Nothing OrElse answerAInput Is Nothing OrElse answerBInput Is Nothing OrElse answerCInput Is Nothing OrElse answerDInput Is Nothing OrElse correctAnswerInput Is Nothing OrElse markInput Is Nothing Then
            ' Handle case where any control is not found
            Return
        End If



        Dim questionNumber As String = questionNumberInput.Value
        Dim questionText As String = questionTextInput.Value
        Dim answerA As String = answerAInput.Value
        Dim answerB As String = answerBInput.Value
        Dim answerC As String = answerCInput.Value
        Dim answerD As String = answerDInput.Value
        Dim correctAnswer As String = correctAnswerInput.Value
        Dim mark As String = markInput.Value

        ' Update the question in the database
        Dim question As New Question_Bank()
        question = Question_Bank.load(questionId)
        question.QuestionNumber = questionNumber
        question.Text = questionText
        question.Option1 = answerA
        question.Option2 = answerB
        question.Option3 = answerC
        question.Option4 = answerD
        question.Mark = mark

        ' Check if a new image has been uploaded
        If questionImageUpload IsNot Nothing AndAlso questionImageUpload.HasFile Then
            Dim questionImageUpdated As Byte() = Nothing
            Using br As New BinaryReader(questionImageUpload.PostedFile.InputStream)
                questionImageUpdated = br.ReadBytes(questionImageUpload.PostedFile.ContentLength)
            End Using
            question.Image = questionImageUpdated
        End If

        question.update()
        Dim questionIndex As Integer = questions.FindIndex(Function(q) q.id = questionId)
        Response.Redirect("EditAssessment.aspx?testId=" & Request.QueryString("testId") & "&questionIndex=" & questionIndex)

        ' Display success message
        Dim successMessage As New HtmlGenericControl("div")
        successMessage.Attributes("class") = "alert alert-success"
        successMessage.InnerText = "Question updated successfully!"
        questionDiv.Controls.Add(successMessage)
    End Sub
End Class