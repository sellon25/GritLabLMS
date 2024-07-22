<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="NewAssessment.aspx.vb" Inherits="LMSApp.NewAssessment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    New Assessment
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
        <form method="post" action="SubmitNewAssessment.aspx" id="newAssessmentForm">
            <asp:HiddenField ID="hfTestId" runat="server" />
            <asp:HiddenField ID="hfTestCreated" runat="server" Value="false" />
            <div class="form-group">
                <label for="assessmentName">Assessment Name:</label>
                <input type="text" class="form-control" id="assessmentName" name="assessmentName" placeholder="Enter assessment name" value="<%= Request.Form("assessmentName") %>">
            </div>
            <div class="form-row">
                <div class="col">
                    <label for="openDateTime">Open Date and Time:</label>
                    <input type="datetime-local" class="form-control" id="openDateTime" name="openDateTime" value="<%= Request.Form("openDateTime") %>">
                </div>
                <div class="col">
                    <label for="closeDateTime">Close Date and Time:</label>
                    <input type="datetime-local" class="form-control" id="closeDateTime" name="closeDateTime" value="<%= Request.Form("closeDateTime") %>">
                </div>

                <asp:Button ID="btnCreateTest" runat="server" type="button" class="btn btn-primary" OnClick="btnCreateTest_Click" Text="Create Test" />
            </div>
            <div class="mt-4">
                <h4 runat="server">Add Questions</h4>
                <div class="form-group">
                    <label for="questionNumber">Question Number:</label>
                    <input runat="server" type="text" class="form-control" id="questionNumber" name="questionNumber" placeholder="Enter number">
                </div>

                <div class="form-group">
                    <label>Question Type:</label>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="questionType" id="multipleChoice" value="multipleChoice" checked onchange="toggleMultipleChoice()">
                        <label class="form-check-label" for="multipleChoice">
                            Multiple Choice
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="questionType" id="longText" value="longText" onchange="toggleMultipleChoice()">

                        <label class="form-check-label" for="longText">
                            Long Text
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="questionType" id="text" value="text" onchange="toggleMultipleChoice()">
                        <label class="form-check-label" for="text">
                            Text
                        </label>
                    </div>
                </div>

                <div class="form-group">
                    <label for="questionText">Question Text:</label>
                    <input runat="server" type="text" class="form-control" id="questionText" name="questionText" placeholder="Enter question text">
                </div>
                <div class="form-group">
                    <label for="newQuestionImage">Question Image:</label>
                    <asp:FileUpload ID="newQuestionImage" runat="server" CssClass="form-control-file" />
                </div>
                
               
                <div id="multipleChoiceAnswers" class="form-group">
                    <label for="answerA">Answer A:</label>
                    <input type="text" class="form-control" id="answerA" name="answerA" runat="server">
                    <label for="answerB">Answer B:</label>
                    <input type="text" class="form-control" id="answerB" name="answerB" runat="server">
                    <label for="answerC">Answer C:</label>
                    <input type="text" class="form-control" id="answerC" name="answerC" runat="server">
                    <label for="answerD">Answer D:</label>
                    <input type="text" class="form-control" id="answerD" name="answerD" runat="server">
                    <label for="correctAnswer">Correct Answer:</label>
                    <select class="form-control" id="correctAnswer" name="correctAnswer" runat="server">
                        <option value="A">--Select--</option>
                        <option value="A">Answer A</option>
                        <option value="B">Answer B</option>
                        <option value="C">Answer C</option>
                        <option value="C">Answer D</option>
                    </select>
                    
                </div>

                <label for="mark">Mark:</label>
                <input type="text" class="form-control" id="mark" name="mark" runat="server">
                <asp:Button ID="btnAddQuestion" runat="server" type="button" class="btn btn-primary" OnClick="btnAddQuestion_Click" Text="Add Another Question" />
                
            </div>
            <button  runat="server" type="submit" class="btn btn-success mt-4">Submit Assessment</button>
        </form>
        
    </div>

    <script type="text/javascript">
            function createOrUpdateTest() {
                __doPostBack('<%= btnCreateTest.ClientID %>', '');
            }

            function addQuestion() {
                __doPostBack('<%= btnAddQuestion.ClientID %>', '');
            }
    </script>
    <asp:Button ID="Button1" runat="server" Text="Hidden Button" style="display:none;" OnClick="btnCreateTest_Click" />
    <asp:Button ID="Button2" runat="server" Text="Hidden Button" style="display:none;" OnClick="btnAddQuestion_Click" />

    <script type="text/javascript">
        function toggleMultipleChoice() {
            var questionType = document.querySelector('input[name="questionType"]:checked').value;
            var multipleChoiceAnswers = document.getElementById('multipleChoiceAnswers');
            if (questionType === 'multipleChoice') {
                multipleChoiceAnswers.style.display = 'block';
            } else {
                multipleChoiceAnswers.style.display = 'none';
            }
        }

        document.addEventListener('DOMContentLoaded', function () {
            toggleMultipleChoice();  // Call the function on page load to set the correct initial state
        });
    </script>
</asp:Content>
