<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="NewAssessment.aspx.vb" Inherits="LMSApp.NewAssessment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    New Assessment
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
        <form method="post" action="SubmitNewAssessment.aspx" id="newAssessmentForm">
            <div class="form-group">
                <label for="assessmentName">Assessment Name:</label>
                <input type="text" class="form-control" id="assessmentName" name="assessmentName" placeholder="Enter assessment name">
            </div>
            <div class="form-row">
                <div class="col">
                    <label for="openDateTime">Open Date and Time:</label>
                    <input type="datetime-local" class="form-control" id="openDateTime" name="openDateTime">
                </div>
                <div class="col">
                    <label for="closeDateTime">Close Date and Time:</label>
                    <input type="datetime-local" class="form-control" id="closeDateTime" name="closeDateTime">
                </div>
            </div>
            <div class="mt-4">
                <h4>Add Questions</h4>
                <div class="form-group">
                    <label for="questionText">Question Text:</label>
                    <input type="text" class="form-control" id="questionText" name="questionText" placeholder="Enter question text">
                </div>
                <div class="form-group">
                    <label>Question Type:</label>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="questionType" id="multipleChoice" value="multipleChoice" checked>
                        <label class="form-check-label" for="multipleChoice">
                            Multiple Choice
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="questionType" id="oneWord" value="oneWord">
                        <label class="form-check-label" for="oneWord">
                            One Word
                        </label>
                    </div>
                </div>
                <div id="multipleChoiceAnswers" class="form-group">
                    <label for="answerA">Answer A:</label>
                    <input type="text" class="form-control" id="answerA" name="answerA">
                    <label for="answerB">Answer B:</label>
                    <input type="text" class="form-control" id="answerB" name="answerB">
                    <label for="answerC">Answer C:</label>
                    <input type="text" class="form-control" id="answerC" name="answerC">
                    <label for="answerD">Answer D:</label>
                    <input type="text" class="form-control" id="answerD" name="answerD">
                    <label for="correctAnswer">Correct Answer:</label>
                    <select class="form-control" id="correctAnswer" name="correctAnswer">
                        <option value="A">Answer A</option>
                        <option value="B">Answer B</option>
                        <option value="C">Answer C</option>
                        <option value="C">Answer D</option>
                    </select>
                </div>
                <button type="button" class="btn btn-primary" onclick="addQuestion();">Add Another Question</button>
            </div>
            <button type="submit" class="btn btn-success mt-4">Submit Assessment</button>
        </form>
    </div>
</asp:Content>
