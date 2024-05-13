<%@ Page Title="Mark Assessment" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="MarkAssessment.aspx.vb" Inherits="LMSApp.MarkAssessment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Mark Assessment
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Mark Assessment
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
        <h2>Student Responses</h2>
        <form id="marksForm">
            <!-- Multiple Choice Question -->
            <div class="question">
                <p><strong>Question 1: What is the capital of France?</strong></p>
                <p>Student's Answer: Paris</p>
                <button type="button" class="btn btn-success">Correct</button>
                <button type="button" class="btn btn-danger">Incorrect</button>
            </div>

            <!-- Fill-in-the-Blank Question -->
            <div class="question">
                <p><strong>Question 2: Newton discovered the law of ________.</strong></p>
                <p>Student's Answer: gravity</p>
                <button type="button" class="btn btn-success">Correct</button>
                <button type="button" class="btn btn-danger">Incorrect</button>
            </div>

            <!-- Additional questions would be added here in a similar format -->

            <!-- Submit button for the marksheet -->
            <div class="mt-4">
                <button type="submit" class="btn btn-primary">Submit Marksheet</button>
            </div>
        </form>
    </div>
</asp:Content>
