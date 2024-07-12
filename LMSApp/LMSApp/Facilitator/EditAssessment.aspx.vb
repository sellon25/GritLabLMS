Public Class EditAssessment
    Inherits System.Web.UI.Page

    ' Store the question list to use in the event handler
    Private questions As List(Of Question_Bank)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadtest()

        End If
    End Sub

    Private Sub loadtest()
        Dim filter As String = "WHERE TestID ='" & Request.QueryString("testId") & "'"
        editAssessment.Controls.Clear()

        ' Get the list of questions based on the filter
        questions = Question_Bank.listall(filter)
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

        ' Show the first question
        If questionsContainer.Controls.Count > 0 Then
            CType(questionsContainer.Controls(0), HtmlGenericControl).Style.Add("display", "block")
        End If

        editAssessment.Controls.Add(questionsContainer)

        ' Create navigation dots and buttons
        Dim navContainer As New HtmlGenericControl("div")
        navContainer.Attributes("id") = "navContainer"
        navContainer.Attributes("class") = "nav-container"

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
                        var currentQuestionIndex = 0;

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
                            }
                        }

                        function showNextQuestion() {
                            var questions = document.getElementsByClassName('question');
                            if (currentQuestionIndex < questions.length - 1) {
                                showQuestion(currentQuestionIndex + 1);
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
        questionNumberLabel.Attributes("for") = "questionNumber"
        questionNumberLabel.InnerText = "Question Number:"
        questionNumberDiv.Controls.Add(questionNumberLabel)
        Dim questionNumberInput As New HtmlGenericControl("input")
        questionNumberInput.Attributes("runat") = "server"
        questionNumberInput.Attributes("type") = "text"
        questionNumberInput.Attributes("class") = "form-control"
        questionNumberInput.Attributes("id") = "questionNumber"
        questionNumberInput.Attributes("name") = "questionNumber"
        questionNumberInput.Attributes("value") = question.QuestionNumber
        questionNumberDiv.Controls.Add(questionNumberInput)
        questionContainer.Controls.Add(questionNumberDiv)

        ' Question text
        Dim questionTextDiv As New HtmlGenericControl("div")
        questionTextDiv.Attributes("class") = "form-group"
        Dim questionTextLabel As New HtmlGenericControl("label")
        questionTextLabel.Attributes("for") = "questionText"
        questionTextLabel.InnerText = "Question Text:"
        questionTextDiv.Controls.Add(questionTextLabel)
        Dim questionTextInput As New HtmlGenericControl("input")
        questionTextInput.Attributes("runat") = "server"
        questionTextInput.Attributes("type") = "text"
        questionTextInput.Attributes("class") = "form-control"
        questionTextInput.Attributes("id") = "questionText"
        questionTextInput.Attributes("name") = "questionText"
        questionTextInput.Attributes("value") = question.Text
        questionTextDiv.Controls.Add(questionTextInput)
        questionContainer.Controls.Add(questionTextDiv)

        ' Create the label and FileUpload for the question image
        Dim questionImageLabel As New HtmlGenericControl("label")
        questionImageLabel.Attributes("for") = "questionImage_" & question.id
        questionImageLabel.InnerText = "Change Question Image:"

        ' Display the current image if it exists
        If question.Image IsNot Nothing AndAlso question.Image.Length > 0 Then
            Dim imageContainer As New HtmlGenericControl("div")

            Dim base64Image As String = Convert.ToBase64String(question.Image)
            Dim imgSrc As String = "data:image/png;base64," & base64Image
            Dim questionImage As New HtmlGenericControl("img")
            questionImage.Attributes("src") = imgSrc
            questionImage.Attributes("class") = "img-fluid"
            questionImage.Attributes("alt") = "Question Image"
            questionImage.Attributes("style") = "width: 40%; height: auto;"
            imageContainer.Controls.Add(questionImage)
            questionContainer.Controls.Add(imageContainer)
        End If


        ' File upload control for updating the image
        Dim questionImageUpload As New FileUpload()
        questionImageUpload.ID = "questionImage_" & question.id
        questionImageUpload.CssClass = "form-control-file"
        questionImageUpload.Attributes("runat") = "server"

        questionContainer.Controls.Add(questionImageLabel)
        questionContainer.Controls.Add(questionImageUpload)


        ' Question type and options
        Dim questionTypeDiv As New HtmlGenericControl("div")
        questionTypeDiv.Attributes("class") = "form-group"
        Dim questionTypeLabel As New HtmlGenericControl("label")
        questionTypeLabel.InnerText = "Question Type:"
        questionTypeDiv.Controls.Add(questionTypeLabel)

        ' Option A
        Dim answerADiv As New HtmlGenericControl("div")
        answerADiv.Attributes("class") = "form-group"
        Dim answerALabel As New HtmlGenericControl("label")
        answerALabel.Attributes("for") = "answerA"
        answerALabel.InnerText = "Answer A:"
        answerADiv.Controls.Add(answerALabel)
        Dim answerAInput As New HtmlGenericControl("input")
        answerAInput.Attributes("type") = "text"
        answerAInput.Attributes("class") = "form-control"
        answerAInput.Attributes("id") = "answerA"
        answerAInput.Attributes("name") = "answerA"
        answerAInput.Attributes("value") = question.Option1
        answerADiv.Controls.Add(answerAInput)
        questionContainer.Controls.Add(answerADiv)

        ' Option B
        Dim answerBDiv As New HtmlGenericControl("div")
        answerBDiv.Attributes("class") = "form-group"
        Dim answerBLabel As New HtmlGenericControl("label")
        answerBLabel.Attributes("for") = "answerB"
        answerBLabel.InnerText = "Answer B:"
        answerBDiv.Controls.Add(answerBLabel)
        Dim answerBInput As New HtmlGenericControl("input")
        answerBInput.Attributes("type") = "text"
        answerBInput.Attributes("class") = "form-control"
        answerBInput.Attributes("id") = "answerB"
        answerBInput.Attributes("name") = "answerB"
        answerBInput.Attributes("value") = question.Option2
        answerBDiv.Controls.Add(answerBInput)
        questionContainer.Controls.Add(answerBDiv)

        ' Option C
        Dim answerCDiv As New HtmlGenericControl("div")
        answerCDiv.Attributes("class") = "form-group"
        Dim answerCLabel As New HtmlGenericControl("label")
        answerCLabel.Attributes("for") = "answerC"
        answerCLabel.InnerText = "Answer C:"
        answerCDiv.Controls.Add(answerCLabel)
        Dim answerCInput As New HtmlGenericControl("input")
        answerCInput.Attributes("type") = "text"
        answerCInput.Attributes("class") = "form-control"
        answerCInput.Attributes("id") = "answerC"
        answerCInput.Attributes("name") = "answerC"
        answerCInput.Attributes("value") = question.Option3
        answerCDiv.Controls.Add(answerCInput)
        questionContainer.Controls.Add(answerCDiv)

        ' Option D
        Dim answerDDiv As New HtmlGenericControl("div")
        answerDDiv.Attributes("class") = "form-group"
        Dim answerDLabel As New HtmlGenericControl("label")
        answerDLabel.Attributes("for") = "answerD"
        answerDLabel.InnerText = "Answer D:"
        answerDDiv.Controls.Add(answerDLabel)
        Dim answerDInput As New HtmlGenericControl("input")
        answerDInput.Attributes("type") = "text"
        answerDInput.Attributes("class") = "form-control"
        answerDInput.Attributes("id") = "answerD"
        answerDInput.Attributes("name") = "answerD"
        answerDInput.Attributes("value") = question.Option4
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
        correctAnswerLabel.Attributes("for") = "correctAnswer"
        correctAnswerLabel.InnerText = "Correct Answer:"
        correctAnswerDiv.Controls.Add(correctAnswerLabel)
        Dim correctAnswerInput As New HtmlGenericControl("input")
        correctAnswerInput.Attributes("type") = "text"
        correctAnswerInput.Attributes("class") = "form-control"
        correctAnswerInput.Attributes("id") = "correctAnswer"
        correctAnswerInput.Attributes("name") = "correctAnswer"
        correctAnswerInput.Attributes("readonly") = "readonly"
        correctAnswerInput.Attributes("value") = correctAnswer.Answer
        correctAnswerDiv.Controls.Add(correctAnswerInput)
        questionContainer.Controls.Add(correctAnswerDiv)

        ' Mark
        Dim markDiv As New HtmlGenericControl("div")
        markDiv.Attributes("class") = "form-group"
        Dim markLabel As New HtmlGenericControl("label")
        markLabel.Attributes("for") = "mark"
        markLabel.InnerText = "Mark:"
        markDiv.Controls.Add(markLabel)
        Dim markInput As New HtmlGenericControl("input")
        markInput.Attributes("type") = "text"
        markInput.Attributes("class") = "form-control"
        markInput.Attributes("id") = "mark"
        markInput.Attributes("name") = "mark"
        markInput.Attributes("value") = question.Mark
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

        Dim questionNumber As String = CType(questionDiv.FindControl("questionNumber"), HtmlInputText).Value
        Dim questionText As String = CType(questionDiv.FindControl("questionText"), HtmlInputText).Value
        Dim answerA As String = CType(questionDiv.FindControl("answerA"), HtmlInputText).Value
        Dim answerB As String = CType(questionDiv.FindControl("answerB"), HtmlInputText).Value
        Dim answerC As String = CType(questionDiv.FindControl("answerC"), HtmlInputText).Value
        Dim answerD As String = CType(questionDiv.FindControl("answerD"), HtmlInputText).Value
        Dim correctAnswer As String = CType(questionDiv.FindControl("correctAnswer"), HtmlInputText).Value
        Dim mark As String = CType(questionDiv.FindControl("mark"), HtmlInputText).Value

        ' Update the question in the database
        Dim question As New Question_Bank()
        question.id = questionId
        question.QuestionNumber = questionNumber
        question.Text = questionText
        question.Option1 = answerA
        question.Option2 = answerB
        question.Option3 = answerC
        question.Option4 = answerD
        'question.CorrectAnswer = correctAnswer
        question.Mark = mark
        question.update()

        ' Display success message
        Dim successMessage As New HtmlGenericControl("div")
        successMessage.Attributes("class") = "alert alert-success"
        successMessage.InnerText = "Question updated successfully!"
        questionDiv.Controls.Add(successMessage)
    End Sub
End Class









'Public Class EditAssessment
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        If Not IsPostBack Then
'            loadtest()
'        End If
'    End Sub

'    Private Sub loadtest()
'        Dim filter As String = "WHERE TestID ='" & Request.QueryString("testId") & "'"
'        editAssessment.Controls.Clear()

'        ' Get the list of questions based on the filter
'        Dim questions As List(Of Question_Bank) = Question_Bank.listall(filter)
'        Dim questionIDs As New List(Of String)

'        ' Create a container for all questions
'        Dim questionsContainer As New HtmlGenericControl("div")
'        questionsContainer.Attributes("id") = "questionsContainer"

'        For Each question As Question_Bank In questions
'            questionIDs.Add(question.id.ToString())
'            Dim questionDiv As HtmlGenericControl = CreateQuestionHtml(question)
'            questionDiv.Attributes("class") = "question"
'            questionDiv.Style.Add("display", "none")
'            questionsContainer.Controls.Add(questionDiv)
'        Next

'        ' Show the first question
'        If questionsContainer.Controls.Count > 0 Then
'            CType(questionsContainer.Controls(0), HtmlGenericControl).Style.Add("display", "block")
'        End If

'        editAssessment.Controls.Add(questionsContainer)

'        ' Create navigation dots
'        Dim navDotsContainer As New HtmlGenericControl("div")
'        navDotsContainer.Attributes("id") = "navDotsContainer"
'        For i As Integer = 0 To questionIDs.Count - 1
'            Dim dot As New HtmlGenericControl("span")
'            dot.Attributes("class") = "dot"
'            dot.Attributes("onclick") = "showQuestion(" & i & ")"
'            navDotsContainer.Controls.Add(dot)
'        Next
'        editAssessment.Controls.Add(navDotsContainer)

'        ' Store the question IDs in a hidden field
'        Dim hiddenField As New HiddenField()
'        hiddenField.ID = "hiddenQuestionIDs"
'        hiddenField.Value = String.Join(",", questionIDs)
'        editAssessment.Controls.Add(hiddenField)

'        ' Add JavaScript for navigation
'        Dim script As New LiteralControl()
'        script.Text = "<script type='text/javascript'>
'                        function showQuestion(index) {
'                            var questions = document.getElementsByClassName('question');
'                            for (var i = 0; i < questions.length; i++) {
'                                questions[i].style.display = 'none';
'                            }
'                            questions[index].style.display = 'block';
'                            var dots = document.getElementsByClassName('dot');
'                            for (var i = 0; i < dots.length; i++) {
'                                dots[i].classList.remove('active');
'                            }
'                            dots[index].classList.add('active');
'                        }
'                       </script>"
'        editAssessment.Controls.Add(script)
'    End Sub

'    'Private Function CreateQuestionHtml(question As Question_Bank) As HtmlGenericControl
'    '    Dim questionContainer As New HtmlGenericControl("div")
'    '    questionContainer.Attributes("class") = "question-container"

'    '    ' Question number
'    '    Dim questionNumberDiv As New HtmlGenericControl("div")
'    '    questionNumberDiv.Attributes("class") = "form-group"
'    '    Dim questionNumberLabel As New HtmlGenericControl("label")
'    '    questionNumberLabel.Attributes("for") = "questionNumber"
'    '    questionNumberLabel.InnerText = "Question Number:"
'    '    questionNumberDiv.Controls.Add(questionNumberLabel)
'    '    Dim questionNumberInput As New HtmlGenericControl("input")
'    '    questionNumberInput.Attributes("runat") = "server"
'    '    questionNumberInput.Attributes("type") = "text"
'    '    questionNumberInput.Attributes("class") = "form-control"
'    '    questionNumberInput.Attributes("id") = "questionNumber"
'    '    questionNumberInput.Attributes("name") = "questionNumber"
'    '    questionNumberInput.Attributes("value") = question.QuestionNumber
'    '    questionNumberInput.Attributes("readonly") = "readonly"
'    '    questionNumberDiv.Controls.Add(questionNumberInput)
'    '    questionContainer.Controls.Add(questionNumberDiv)

'    '    ' Question text
'    '    Dim questionTextDiv As New HtmlGenericControl("div")
'    '    questionTextDiv.Attributes("class") = "form-group"
'    '    Dim questionTextLabel As New HtmlGenericControl("label")
'    '    questionTextLabel.Attributes("for") = "questionText"
'    '    questionTextLabel.InnerText = "Question Text:"
'    '    questionTextDiv.Controls.Add(questionTextLabel)
'    '    Dim questionTextInput As New HtmlGenericControl("input")
'    '    questionTextInput.Attributes("runat") = "server"
'    '    questionTextInput.Attributes("type") = "text"
'    '    questionTextInput.Attributes("class") = "form-control"
'    '    questionTextInput.Attributes("id") = "questionText"
'    '    questionTextInput.Attributes("name") = "questionText"
'    '    questionTextInput.Attributes("value") = question.Text
'    '    questionTextInput.Attributes("readonly") = "readonly"
'    '    questionTextDiv.Controls.Add(questionTextInput)
'    '    questionContainer.Controls.Add(questionTextDiv)

'    '    ' Display the current image if it exists
'    '    If question.Image IsNot Nothing AndAlso question.Image.Length > 0 Then
'    '        Dim base64Image As String = Convert.ToBase64String(question.Image)
'    '        Dim imgSrc As String = "data:image/png;base64," & base64Image
'    '        Dim questionImage As New HtmlGenericControl("img")
'    '        questionImage.Attributes("src") = imgSrc
'    '        questionImage.Attributes("class") = "img-fluid"
'    '        questionImage.Attributes("alt") = "Question Image"
'    '        questionContainer.Controls.Add(questionImage)
'    '    End If

'    '    ' Question type and options
'    '    Dim questionTypeDiv As New HtmlGenericControl("div")
'    '    questionTypeDiv.Attributes("class") = "form-group"
'    '    Dim questionTypeLabel As New HtmlGenericControl("label")
'    '    questionTypeLabel.InnerText = "Question Type:"
'    '    questionTypeDiv.Controls.Add(questionTypeLabel)

'    '    ' Option A
'    '    Dim answerADiv As New HtmlGenericControl("div")
'    '    answerADiv.Attributes("class") = "form-group"
'    '    Dim answerALabel As New HtmlGenericControl("label")
'    '    answerALabel.Attributes("for") = "answerA"
'    '    answerALabel.InnerText = "Answer A:"
'    '    answerADiv.Controls.Add(answerALabel)
'    '    Dim answerAInput As New HtmlGenericControl("input")
'    '    answerAInput.Attributes("type") = "text"
'    '    answerAInput.Attributes("class") = "form-control"
'    '    answerAInput.Attributes("id") = "answerA"
'    '    answerAInput.Attributes("name") = "answerA"
'    '    answerAInput.Attributes("value") = question.Option1
'    '    answerAInput.Attributes("readonly") = "readonly"
'    '    answerADiv.Controls.Add(answerAInput)
'    '    questionContainer.Controls.Add(answerADiv)

'    '    ' Option B
'    '    Dim answerBDiv As New HtmlGenericControl("div")
'    '    answerBDiv.Attributes("class") = "form-group"
'    '    Dim answerBLabel As New HtmlGenericControl("label")
'    '    answerBLabel.Attributes("for") = "answerB"
'    '    answerBLabel.InnerText = "Answer B:"
'    '    answerBDiv.Controls.Add(answerBLabel)
'    '    Dim answerBInput As New HtmlGenericControl("input")
'    '    answerBInput.Attributes("type") = "text"
'    '    answerBInput.Attributes("class") = "form-control"
'    '    answerBInput.Attributes("id") = "answerB"
'    '    answerBInput.Attributes("name") = "answerB"
'    '    answerBInput.Attributes("value") = question.Option2
'    '    answerBInput.Attributes("readonly") = "readonly"
'    '    answerBDiv.Controls.Add(answerBInput)
'    '    questionContainer.Controls.Add(answerBDiv)

'    '    ' Option C
'    '    Dim answerCDiv As New HtmlGenericControl("div")
'    '    answerCDiv.Attributes("class") = "form-group"
'    '    Dim answerCLabel As New HtmlGenericControl("label")
'    '    answerCLabel.Attributes("for") = "answerC"
'    '    answerCLabel.InnerText = "Answer C:"
'    '    answerCDiv.Controls.Add(answerCLabel)
'    '    Dim answerCInput As New HtmlGenericControl("input")
'    '    answerCInput.Attributes("type") = "text"
'    '    answerCInput.Attributes("class") = "form-control"
'    '    answerCInput.Attributes("id") = "answerC"
'    '    answerCInput.Attributes("name") = "answerC"
'    '    answerCInput.Attributes("value") = question.Option3
'    '    answerCInput.Attributes("readonly") = "readonly"
'    '    answerCDiv.Controls.Add(answerCInput)
'    '    questionContainer.Controls.Add(answerCDiv)

'    '    ' Option D
'    '    Dim answerDDiv As New HtmlGenericControl("div")
'    '    answerDDiv.Attributes("class") = "form-group"
'    '    Dim answerDLabel As New HtmlGenericControl("label")
'    '    answerDLabel.Attributes("for") = "answerD"
'    '    answerDLabel.InnerText = "Answer D:"
'    '    answerDDiv.Controls.Add(answerDLabel)
'    '    Dim answerDInput As New HtmlGenericControl("input")
'    '    answerDInput.Attributes("type") = "text"
'    '    answerDInput.Attributes("class") = "form-control"
'    '    answerDInput.Attributes("id") = "answerD"
'    '    answerDInput.Attributes("name") = "answerD"
'    '    answerDInput.Attributes("value") = question.Option4
'    '    answerDInput.Attributes("readonly") = "readonly"
'    '    answerDDiv.Controls.Add(answerDInput)
'    '    questionContainer.Controls.Add(answerDDiv)

'    '    ' Correct answer
'    '    Dim correctAnswerDiv As New HtmlGenericControl("div")
'    '    correctAnswerDiv.Attributes("class") = "form-group"
'    '    Dim correctAnswerLabel As New HtmlGenericControl("label")
'    '    correctAnswerLabel.Attributes("for") = "correctAnswer"
'    '    correctAnswerLabel.InnerText = "Correct Answer:"
'    '    correctAnswerDiv.Controls.Add(correctAnswerLabel)
'    '    Dim correctAnswerInput As New HtmlGenericControl("input")
'    '    correctAnswerInput.Attributes("type") = "text"
'    '    correctAnswerInput.Attributes("class") = "form-control"
'    '    correctAnswerInput.Attributes("id") = "correctAnswer"
'    '    correctAnswerInput.Attributes("name") = "correctAnswer"
'    '    correctAnswerInput.Attributes("value") = question.Option4
'    '    correctAnswerInput.Attributes("readonly") = "readonly"
'    '    correctAnswerDiv.Controls.Add(correctAnswerInput)
'    '    questionContainer.Controls.Add(correctAnswerDiv)

'    '    ' Mark
'    '    Dim markDiv As New HtmlGenericControl("div")
'    '    markDiv.Attributes("class") = "form-group"
'    '    Dim markLabel As New HtmlGenericControl("label")
'    '    markLabel.Attributes("for") = "mark"
'    '    markLabel.InnerText = "Mark:"
'    '    markDiv.Controls.Add(markLabel)
'    '    Dim markInput As New HtmlGenericControl("input")
'    '    markInput.Attributes("type") = "text"
'    '    markInput.Attributes("class") = "form-control"
'    '    markInput.Attributes("id") = "mark"
'    '    markInput.Attributes("name") = "mark"
'    '    markInput.Attributes("value") = question.Mark
'    '    markInput.Attributes("readonly") = "readonly"
'    '    markDiv.Controls.Add(markInput)
'    '    questionContainer.Controls.Add(markDiv)

'    '    ' Add a thin line to separate questions
'    '    Dim separator As New HtmlGenericControl("hr")
'    '    questionContainer.Controls.Add(separator)

'    '    Return questionContainer
'    'End Function

'    Private Function CreateQuestionHtml(question As Question_Bank) As HtmlGenericControl
'        ' Create the main container for the question
'        Dim questionContainer As New HtmlGenericControl("div")
'        questionContainer.Attributes("class") = "form-group"

'        ' Create the label and input for the question number
'        Dim questionNumberLabel As New HtmlGenericControl("label")
'        questionNumberLabel.Attributes("for") = "questionNumber_" & question.id
'        questionNumberLabel.InnerText = "Question Number:"

'        Dim questionNumberInput As New HtmlGenericControl("input")
'        questionNumberInput.Attributes("runat") = "server"
'        questionNumberInput.Attributes("type") = "text"
'        questionNumberInput.Attributes("class") = "form-control"
'        questionNumberInput.Attributes("id") = "questionNumber_" & question.id
'        questionNumberInput.Attributes("name") = "questionNumber_" & question.id
'        questionNumberInput.Attributes("placeholder") = "Enter number"
'        questionNumberInput.Attributes("value") = question.QuestionNumber

'        questionContainer.Controls.Add(questionNumberLabel)
'        questionContainer.Controls.Add(questionNumberInput)

'        ' Create the label and input for the question text
'        Dim questionTextLabel As New HtmlGenericControl("label")
'        questionTextLabel.Attributes("for") = "questionText_" & question.id
'        questionTextLabel.InnerText = "Question Text:"

'        Dim questionTextInput As New HtmlGenericControl("input")
'        questionTextInput.Attributes("runat") = "server"
'        questionTextInput.Attributes("type") = "text"
'        questionTextInput.Attributes("class") = "form-control"
'        questionTextInput.Attributes("id") = "questionText_" & question.id
'        questionTextInput.Attributes("name") = "questionText_" & question.id
'        questionTextInput.Attributes("placeholder") = "Enter question text"
'        questionTextInput.Attributes("value") = question.Text

'        questionContainer.Controls.Add(questionTextLabel)
'        questionContainer.Controls.Add(questionTextInput)

'        ' Create the label and FileUpload for the question image
'        Dim questionImageLabel As New HtmlGenericControl("label")
'        questionImageLabel.Attributes("for") = "questionImage_" & question.id
'        questionImageLabel.InnerText = "Change Question Image:"

'        ' Display the current image if it exists
'        If question.Image IsNot Nothing AndAlso question.Image.Length > 0 Then
'            Dim imageContainer As New HtmlGenericControl("div")

'            Dim base64Image As String = Convert.ToBase64String(question.Image)
'            Dim imgSrc As String = "data:image/png;base64," & base64Image
'            Dim questionImage As New HtmlGenericControl("img")
'            questionImage.Attributes("src") = imgSrc
'            questionImage.Attributes("class") = "img-fluid"
'            questionImage.Attributes("alt") = "Question Image"
'            questionImage.Attributes("style") = "width: 40%; height: auto;"
'            imageContainer.Controls.Add(questionImage)
'            questionContainer.Controls.Add(imageContainer)
'        End If


'        ' File upload control for updating the image
'        Dim questionImageUpload As New FileUpload()
'        questionImageUpload.ID = "questionImage_" & question.id
'        questionImageUpload.CssClass = "form-control-file"
'        questionImageUpload.Attributes("runat") = "server"

'        questionContainer.Controls.Add(questionImageLabel)
'        questionContainer.Controls.Add(questionImageUpload)

'        ' Create the question type radio buttons
'        Dim questionTypeLabel As New HtmlGenericControl("label")
'        questionTypeLabel.InnerText = "Question Type:"

'        Dim multipleChoiceRadio As New HtmlGenericControl("input")
'        multipleChoiceRadio.Attributes("class") = "form-check-input"
'        multipleChoiceRadio.Attributes("type") = "radio"
'        multipleChoiceRadio.Attributes("name") = "questionType_" & question.id
'        multipleChoiceRadio.Attributes("id") = "multipleChoice_" & question.id
'        multipleChoiceRadio.Attributes("value") = "multipleChoice"
'        If question.Category_ID = "multipleChoice" Then
'            multipleChoiceRadio.Attributes("checked") = "checked"
'        End If

'        Dim multipleChoiceLabel As New HtmlGenericControl("label")
'        multipleChoiceLabel.Attributes("class") = "form-check-label"
'        multipleChoiceLabel.Attributes("for") = "multipleChoice_" & question.id
'        multipleChoiceLabel.InnerText = "Multiple Choice"

'        Dim oneWordRadio As New HtmlGenericControl("input")
'        oneWordRadio.Attributes("class") = "form-check-input"
'        oneWordRadio.Attributes("type") = "radio"
'        oneWordRadio.Attributes("name") = "questionType_" & question.id
'        oneWordRadio.Attributes("id") = "oneWord_" & question.id
'        oneWordRadio.Attributes("value") = "oneWord"
'        If question.Category_ID = "oneWord" Then
'            oneWordRadio.Attributes("checked") = "checked"
'        End If

'        Dim oneWordLabel As New HtmlGenericControl("label")
'        oneWordLabel.Attributes("class") = "form-check-label"
'        oneWordLabel.Attributes("for") = "oneWord_" & question.id
'        oneWordLabel.InnerText = "One Word"

'        questionContainer.Controls.Add(questionTypeLabel)
'        questionContainer.Controls.Add(multipleChoiceRadio)
'        questionContainer.Controls.Add(multipleChoiceLabel)
'        questionContainer.Controls.Add(oneWordRadio)
'        questionContainer.Controls.Add(oneWordLabel)

'        ' Create the answer inputs
'        Dim multipleChoiceAnswers As New HtmlGenericControl("div")
'        multipleChoiceAnswers.Attributes("id") = "multipleChoiceAnswers_" & question.id
'        multipleChoiceAnswers.Attributes("class") = "form-group"

'        ' Create inputs for answers
'        Dim options As String() = {question.Option1, question.Option2, question.Option3, question.Option4}
'        Dim optionIds As String() = {"A", "B", "C", "D"}
'        For i As Integer = 0 To options.Length - 1
'            Dim answerLabel As New HtmlGenericControl("label")
'            answerLabel.InnerText = "Answer " & optionIds(i) & ":"

'            Dim answerInput As New HtmlGenericControl("input")
'            answerInput.Attributes("type") = "text"
'            answerInput.Attributes("class") = "form-control"
'            answerInput.Attributes("id") = "answer" & optionIds(i) & "_" & question.id
'            answerInput.Attributes("name") = "answer" & optionIds(i) & "_" & question.id
'            answerInput.Attributes("value") = options(i)

'            multipleChoiceAnswers.Controls.Add(answerLabel)
'            multipleChoiceAnswers.Controls.Add(answerInput)
'        Next

'        ' Create the correct answer dropdown
'        Dim correctAnswerLabel As New HtmlGenericControl("label")
'        correctAnswerLabel.InnerText = "Correct Answer:"

'        Dim correctAnswerDropdown As New HtmlGenericControl("select")
'        correctAnswerDropdown.Attributes("class") = "form-control"
'        correctAnswerDropdown.Attributes("id") = "correctAnswer_" & question.id
'        correctAnswerDropdown.Attributes("name") = "correctAnswer_" & question.id

'        For Each optionValue As String In optionIds
'            Dim optionItem As New HtmlGenericControl("option")
'            optionItem.Attributes("value") = optionValue
'            optionItem.InnerText = "Answer " & optionValue
'            correctAnswerDropdown.Controls.Add(optionItem)
'        Next

'        multipleChoiceAnswers.Controls.Add(correctAnswerLabel)
'        multipleChoiceAnswers.Controls.Add(correctAnswerDropdown)

'        ' Add mark input
'        Dim markLabel As New HtmlGenericControl("label")
'        markLabel.InnerText = "Mark:"

'        Dim markInput As New HtmlGenericControl("input")
'        markInput.Attributes("type") = "text"
'        markInput.Attributes("class") = "form-control"
'        markInput.Attributes("id") = "mark_" & question.id
'        markInput.Attributes("name") = "mark_" & question.id
'        markInput.Attributes("value") = question.Mark

'        multipleChoiceAnswers.Controls.Add(markLabel)
'        multipleChoiceAnswers.Controls.Add(markInput)

'        questionContainer.Controls.Add(multipleChoiceAnswers)

'        ' Add a thin line after each question
'        Dim separator As New HtmlGenericControl("hr")
'        separator.Attributes("class") = "question-separator"
'        questionContainer.Controls.Add(separator)

'        Return questionContainer
'    End Function
'End Class














'Public Class EditAssessment
'    Inherits System.Web.UI.Page

'    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'        If Not IsPostBack Then
'            loadtest()
'        Else
'            ' Recreate dynamic controls with the same IDs and properties
'            RecreateDynamicControls()
'        End If
'    End Sub
'    Private Sub RecreateDynamicControls()
'        Dim filter As String = "WHERE TestID ='" & Request.QueryString("testId") & "'"
'        editAssessment.Controls.Clear()

'        ' Get the list of questions based on the filter
'        Dim questions As List(Of Question_Bank) = Question_Bank.listall(filter)
'        Dim questionIDs As New List(Of String)

'        For Each question As Question_Bank In questions
'            questionIDs.Add(question.id.ToString())
'            EditAssessment.Controls.Add(CreateQuestionHtml(question))
'        Next

'        ' Store the question IDs in a hidden field
'        Dim hiddenField As New HiddenField()
'        hiddenField.ID = "hiddenQuestionIDs"
'        hiddenField.Value = String.Join(",", questionIDs)
'        EditAssessment.Controls.Add(hiddenField)

'        ' Create and add the submit button to the test content
'        Dim submitbutton As New HtmlGenericControl("div")
'        submitbutton.Attributes("class") = "col-sm-12"
'        submitbutton.Controls.Add(createsubmitbutton(Request.QueryString("testId")))

'        Dim submitbox As New HtmlGenericControl("div")
'        submitbox.Attributes("class") = "form-group mb-4"
'        submitbox.Controls.Add(submitbutton)

'        EditAssessment.Controls.Add(submitbox)
'    End Sub

'    Private Sub loadtest()
'        Dim filter As String = "WHERE TestID ='" & Request.QueryString("testId") & "'"
'        editAssessment.Controls.Clear()

'        ' Get the list of questions based on the filter
'        Dim questions As List(Of Question_Bank) = Question_Bank.listall(filter)
'        Dim questionIDs As New List(Of String)

'        For Each question As Question_Bank In questions
'            questionIDs.Add(question.id.ToString())
'            editAssessment.Controls.Add(CreateQuestionHtml(question))
'        Next

'        ' Store the question IDs in a hidden field
'        Dim hiddenField As New HiddenField()
'        hiddenField.ID = "hiddenQuestionIDs"
'        hiddenField.Value = String.Join(",", questionIDs)
'        EditAssessment.Controls.Add(hiddenField)

'        ' Create and add the submit button to the test content
'        Dim submitbutton As New HtmlGenericControl("div")
'        submitbutton.Attributes("class") = "col-sm-12"
'        submitbutton.Controls.Add(createsubmitbutton(Request.QueryString("testId")))

'        Dim submitbox As New HtmlGenericControl("div")
'        submitbox.Attributes("class") = "form-group mb-4"
'        submitbox.Controls.Add(submitbutton)

'        EditAssessment.Controls.Add(submitbox)
'    End Sub


'    Private Function createsubmitbutton(testid As Integer) As Button
'        Dim submitButton As New Button()
'        submitButton.ID = String.Format("SubmitTest_{0}", testid)
'        submitButton.Text = "Submit"
'        submitButton.Attributes("class") = "btn btn-orange"
'        'submitButton.Style.Add("height", "fit-content")
'        'submitButton.Attributes("data-content-id") = test.id.ToString()
'        AddHandler submitButton.Click, AddressOf SubmitTest
'        Return submitButton
'    End Function
'    Protected Sub SubmitTest(ByVal sender As Object, ByVal e As EventArgs)
'        Submit_Test()
'    End Sub

'    Private Sub Submit_Test()
'        Dim collectedAnswers As New Dictionary(Of String, String)()

'        ' Retrieve the question IDs from the hidden field
'        Dim hiddenField As HiddenField = CType(EditAssessment.FindControl("hiddenQuestionIDs"), HiddenField)
'        Dim questionIDs As String() = hiddenField.Value.Split(","c)

'        For Each questionID As String In questionIDs
'            ' Find the control by its ID
'            Dim textControl As Control = EditAssessment.FindControl("textInput_" & questionID)
'            Dim radioControl As Control = EditAssessment.FindControl("radioList_" & questionID)
'            Dim dropdownControl As Control = EditAssessment.FindControl("dropdownlist_" & questionID)

'            ' Check for TextBox control
'            If textControl IsNot Nothing AndAlso TypeOf textControl Is TextBox Then
'                Dim textInput As TextBox = CType(textControl, TextBox)
'                Dim enteredText As String = textInput.Text
'                collectedAnswers.Add(questionID, enteredText)
'            End If

'            ' Check for RadioButtonList control
'            If radioControl IsNot Nothing AndAlso TypeOf radioControl Is RadioButtonList Then
'                Dim radioInput As RadioButtonList = CType(radioControl, RadioButtonList)
'                If radioInput.SelectedItem IsNot Nothing Then
'                    collectedAnswers.Add(questionID, radioInput.SelectedItem.Text)
'                End If
'            End If

'            ' Check for DropDownList control
'            If dropdownControl IsNot Nothing AndAlso TypeOf dropdownControl Is DropDownList Then
'                Dim dropdownInput As DropDownList = CType(dropdownControl, DropDownList)
'                Dim selectedValue As String = dropdownInput.SelectedValue
'                collectedAnswers.Add(questionID, selectedValue)
'            End If
'        Next

'        ' Process the collected answers
'        For Each kvp In collectedAnswers
'            Dim questionID As String = kvp.Key
'            Dim answer As String = kvp.Value
'            ' Save or process the answer
'            Dim student_Answer As New StudentAnswer()
'            student_Answer.id = questionID + 5
'            student_Answer.Answer = answer
'            student_Answer.question_id = questionID

'            student_Answer.update()
'        Next

'        Response.Redirect("TestContent.aspx")
'    End Sub

'    Private Function CreateQuestionHtml(question As Question_Bank) As HtmlGenericControl
'        ' Create the main container for the question
'        Dim questionContainer As New HtmlGenericControl("div")
'        questionContainer.Attributes("class") = "form-group"

'        ' Create the label and input for the question number
'        Dim questionNumberLabel As New HtmlGenericControl("label")
'        questionNumberLabel.Attributes("for") = "questionNumber_" & question.id
'        questionNumberLabel.InnerText = "Question Number:"

'        Dim questionNumberInput As New HtmlGenericControl("input")
'        questionNumberInput.Attributes("runat") = "server"
'        questionNumberInput.Attributes("type") = "text"
'        questionNumberInput.Attributes("class") = "form-control"
'        questionNumberInput.Attributes("id") = "questionNumber_" & question.id
'        questionNumberInput.Attributes("name") = "questionNumber_" & question.id
'        questionNumberInput.Attributes("placeholder") = "Enter number"
'        questionNumberInput.Attributes("value") = question.QuestionNumber

'        questionContainer.Controls.Add(questionNumberLabel)
'        questionContainer.Controls.Add(questionNumberInput)

'        ' Create the label and input for the question text
'        Dim questionTextLabel As New HtmlGenericControl("label")
'        questionTextLabel.Attributes("for") = "questionText_" & question.id
'        questionTextLabel.InnerText = "Question Text:"

'        Dim questionTextInput As New HtmlGenericControl("input")
'        questionTextInput.Attributes("runat") = "server"
'        questionTextInput.Attributes("type") = "text"
'        questionTextInput.Attributes("class") = "form-control"
'        questionTextInput.Attributes("id") = "questionText_" & question.id
'        questionTextInput.Attributes("name") = "questionText_" & question.id
'        questionTextInput.Attributes("placeholder") = "Enter question text"
'        questionTextInput.Attributes("value") = question.Text

'        questionContainer.Controls.Add(questionTextLabel)
'        questionContainer.Controls.Add(questionTextInput)

'        ' Create the label and FileUpload for the question image
'        Dim questionImageLabel As New HtmlGenericControl("label")
'        questionImageLabel.Attributes("for") = "questionImage_" & question.id
'        questionImageLabel.InnerText = "Change Question Image:"

'        ' Display the current image if it exists
'        If question.Image IsNot Nothing AndAlso question.Image.Length > 0 Then
'            Dim base64Image As String = Convert.ToBase64String(question.Image)
'            Dim imgSrc As String = "data:image/png;base64," & base64Image
'            Dim questionImage As New HtmlGenericControl("img")
'            questionImage.Attributes("src") = imgSrc
'            questionImage.Attributes("class") = "img-fluid"
'            questionImage.Attributes("alt") = "Question Image"
'            questionContainer.Controls.Add(questionImage)
'        End If


'        ' File upload control for updating the image
'        Dim questionImageUpload As New FileUpload()
'        questionImageUpload.ID = "questionImage_" & question.id
'        questionImageUpload.CssClass = "form-control-file"
'        questionImageUpload.Attributes("runat") = "server"

'        questionContainer.Controls.Add(questionImageLabel)
'        questionContainer.Controls.Add(questionImageUpload)

'        ' Create the question type radio buttons
'        Dim questionTypeLabel As New HtmlGenericControl("label")
'        questionTypeLabel.InnerText = "Question Type:"

'        Dim multipleChoiceRadio As New HtmlGenericControl("input")
'        multipleChoiceRadio.Attributes("class") = "form-check-input"
'        multipleChoiceRadio.Attributes("type") = "radio"
'        multipleChoiceRadio.Attributes("name") = "questionType_" & question.id
'        multipleChoiceRadio.Attributes("id") = "multipleChoice_" & question.id
'        multipleChoiceRadio.Attributes("value") = "multipleChoice"
'        If question.Category_ID = "multipleChoice" Then
'            multipleChoiceRadio.Attributes("checked") = "checked"
'        End If

'        Dim multipleChoiceLabel As New HtmlGenericControl("label")
'        multipleChoiceLabel.Attributes("class") = "form-check-label"
'        multipleChoiceLabel.Attributes("for") = "multipleChoice_" & question.id
'        multipleChoiceLabel.InnerText = "Multiple Choice"

'        Dim oneWordRadio As New HtmlGenericControl("input")
'        oneWordRadio.Attributes("class") = "form-check-input"
'        oneWordRadio.Attributes("type") = "radio"
'        oneWordRadio.Attributes("name") = "questionType_" & question.id
'        oneWordRadio.Attributes("id") = "oneWord_" & question.id
'        oneWordRadio.Attributes("value") = "oneWord"
'        If question.Category_ID = "oneWord" Then
'            oneWordRadio.Attributes("checked") = "checked"
'        End If

'        Dim oneWordLabel As New HtmlGenericControl("label")
'        oneWordLabel.Attributes("class") = "form-check-label"
'        oneWordLabel.Attributes("for") = "oneWord_" & question.id
'        oneWordLabel.InnerText = "One Word"

'        questionContainer.Controls.Add(questionTypeLabel)
'        questionContainer.Controls.Add(multipleChoiceRadio)
'        questionContainer.Controls.Add(multipleChoiceLabel)
'        questionContainer.Controls.Add(oneWordRadio)
'        questionContainer.Controls.Add(oneWordLabel)

'        ' Create the answer inputs
'        Dim multipleChoiceAnswers As New HtmlGenericControl("div")
'        multipleChoiceAnswers.Attributes("id") = "multipleChoiceAnswers_" & question.id
'        multipleChoiceAnswers.Attributes("class") = "form-group"

'        ' Create inputs for answers
'        Dim options As String() = {question.Option1, question.Option2, question.Option3, question.Option4}
'        Dim optionIds As String() = {"A", "B", "C", "D"}
'        For i As Integer = 0 To options.Length - 1
'            Dim answerLabel As New HtmlGenericControl("label")
'            answerLabel.InnerText = "Answer " & optionIds(i) & ":"

'            Dim answerInput As New HtmlGenericControl("input")
'            answerInput.Attributes("type") = "text"
'            answerInput.Attributes("class") = "form-control"
'            answerInput.Attributes("id") = "answer" & optionIds(i) & "_" & question.id
'            answerInput.Attributes("name") = "answer" & optionIds(i) & "_" & question.id
'            answerInput.Attributes("value") = options(i)

'            multipleChoiceAnswers.Controls.Add(answerLabel)
'            multipleChoiceAnswers.Controls.Add(answerInput)
'        Next

'        ' Create the correct answer dropdown
'        Dim correctAnswerLabel As New HtmlGenericControl("label")
'        correctAnswerLabel.InnerText = "Correct Answer:"

'        Dim correctAnswerDropdown As New HtmlGenericControl("select")
'        correctAnswerDropdown.Attributes("class") = "form-control"
'        correctAnswerDropdown.Attributes("id") = "correctAnswer_" & question.id
'        correctAnswerDropdown.Attributes("name") = "correctAnswer_" & question.id

'        For Each optionValue As String In optionIds
'            Dim optionItem As New HtmlGenericControl("option")
'            optionItem.Attributes("value") = optionValue
'            optionItem.InnerText = "Answer " & optionValue
'            correctAnswerDropdown.Controls.Add(optionItem)
'        Next

'        multipleChoiceAnswers.Controls.Add(correctAnswerLabel)
'        multipleChoiceAnswers.Controls.Add(correctAnswerDropdown)

'        ' Add mark input
'        Dim markLabel As New HtmlGenericControl("label")
'        markLabel.InnerText = "Mark:"

'        Dim markInput As New HtmlGenericControl("input")
'        markInput.Attributes("type") = "text"
'        markInput.Attributes("class") = "form-control"
'        markInput.Attributes("id") = "mark_" & question.id
'        markInput.Attributes("name") = "mark_" & question.id
'        markInput.Attributes("value") = question.Mark

'        multipleChoiceAnswers.Controls.Add(markLabel)
'        multipleChoiceAnswers.Controls.Add(markInput)

'        questionContainer.Controls.Add(multipleChoiceAnswers)

'        ' Add a thin line after each question
'        Dim separator As New HtmlGenericControl("hr")
'        separator.Attributes("class") = "question-separator"
'        questionContainer.Controls.Add(separator)

'        Return questionContainer
'    End Function




'    Private Function createMultilineText(question As Question_Bank) As TextBox
'        Dim multiTextbox As New TextBox
'        multiTextbox.Attributes("id") = String.Format("textInput{0}", question.id)
'        multiTextbox.Attributes("class") = "form-control p-0 border-0"
'        multiTextbox.Attributes("placeholder") = "Type here..."
'        multiTextbox.Attributes("rows") = "5"
'        Return multiTextbox
'    End Function
'    Private Function createOneWord(question As Question_Bank) As TextBox
'        Dim text_box As New TextBox
'        text_box.ID = String.Format("textInput_{0}", question.id)
'        text_box.Attributes("placeholder") = "Type here..."
'        text_box.Attributes("class") = "form-control p-0 border-0"
'        text_box.Attributes("name") = question.id
'        text_box.EnableViewState = True ' Ensure ViewState is enabled for TextBox

'        Return text_box
'    End Function
'    Private Function createRadiolist(question As Question_Bank) As RadioButtonList
'        Dim _radioList As New RadioButtonList
'        _radioList.Attributes("id") = String.Format("radioList_{0}", question.id)
'        _radioList.Attributes("class") = "col-md-12 border-bottom p-0"
'        ' Create ListItem objects for each option
'        Dim option1 As New ListItem(question.Option1)
'        Dim option2 As New ListItem(question.Option2)
'        Dim option3 As New ListItem(question.Option3)
'        Dim option4 As New ListItem(question.Option4)

'        ' Check if each option is not Nothing or an empty string before adding
'        If Not String.IsNullOrEmpty(question.Option1) Then _radioList.Items.Add(option1)
'        If Not String.IsNullOrEmpty(question.Option2) Then _radioList.Items.Add(option2)
'        If Not String.IsNullOrEmpty(question.Option3) Then _radioList.Items.Add(option3)
'        If Not String.IsNullOrEmpty(question.Option4) Then _radioList.Items.Add(option4)

'        Return _radioList
'    End Function

'    Private Function createDroplist(question As Question_Bank) As DropDownList
'        Dim _dropdownlist As New DropDownList
'        _dropdownlist.Attributes("id") = String.Format("dropdownlist_{0}", question.id)
'        _dropdownlist.Attributes("class") = "form-select shadow-none p-0 border-0 form-control-line"
'        ' Create ListItem objects for each option
'        Dim option1 As New ListItem(question.Option1)
'        Dim option2 As New ListItem(question.Option2)
'        Dim option3 As New ListItem(question.Option3)
'        Dim option4 As New ListItem(question.Option4)

'        ' Check if each option is not Nothing or an empty string before adding
'        If Not String.IsNullOrEmpty(question.Option1) Then _dropdownlist.Items.Add(option1)
'        If Not String.IsNullOrEmpty(question.Option2) Then _dropdownlist.Items.Add(option2)
'        If Not String.IsNullOrEmpty(question.Option3) Then _dropdownlist.Items.Add(option3)
'        If Not String.IsNullOrEmpty(question.Option4) Then _dropdownlist.Items.Add(option4)

'        Return _dropdownlist
'    End Function

'End Class
