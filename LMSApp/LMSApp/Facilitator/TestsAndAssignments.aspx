<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="TestsAndAssignments.aspx.vb" Inherits="LMSApp.TestsAndAssignments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Tests And Assessments
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <button type="button" class="btn btn-primary" style="background-color:#93761E;" onclick="window.location.href='NewAssessment.aspx?courseId=<%= Request.QueryString("courseId") %>';">Add New Assessment</button>
    <div class="row" style="padding-top:10px;">

        <a class="col-md-12 text-black" href="AssessmentStudentList.aspx">
            <div class="white-box boxShadow d-flex justify-content-between align-items-center">
                <h3 class="box-title">Test 1</h3>
                <span style="color: green;">Open</span>
            </div>
        </a>

        <a class="col-md-12 text-black" href="AssessmentStudentList.aspx">
            <div class="white-box boxShadow d-flex justify-content-between align-items-center">
                <h3 class="box-title">Assignment 1</h3>
                <span style="color: red;">Closed</span>
            </div>
        </a>

        <a class="col-md-12 text-black" href="AssessmentStudentList.aspx">
            <div class="white-box boxShadow d-flex justify-content-between align-items-center">
                <h3 class="box-title">Assignment 2</h3>
                <span style="color: green;">Open</span>
            </div>
        </a>

        <a class="col-md-12 text-black" href="AssessmentStudentList.aspx">
            <div class="white-box boxShadow d-flex justify-content-between align-items-center">
                <h3 class="box-title">Test 2</h3>
                <span style="color: red;">Closed</span>
            </div>
        </a>

    </div>
</asp:Content>
