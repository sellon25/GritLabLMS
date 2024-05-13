<%@ Page Title="Course Content" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="CourseContent.aspx.vb" Inherits="LMSApp.CourseContent1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Course Content
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Course Content
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
        <div class="mb-3">
            <button type="button" class="btn btn-primary" onclick="addNewTopic();">New Topic</button>
        </div>
        <div class="accordion" id="accordionExample">
            <div class="card">
                <div class="card-header d-flex justify-content-between align-items-center" id="headingOne">
                    <h5 class="mb-0">
                        Topic 1: Introduction
                    </h5>
                    <button class="btn btn-secondary" onclick="uploadFileToTopic('Topic1');">Upload File</button>
                </div>

                <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                    <div class="card-body">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item"><a href="path_to_pdf/Introduction_Part1.pdf" target="_blank">Introduction Part 1</a></li>
                            <li class="list-group-item"><a href="path_to_pdf/Introduction_Part2.pdf" target="_blank">Introduction Part 2</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header d-flex justify-content-between align-items-center" id="headingTwo">
                    <h5 class="mb-0">
                        Topic 2: Advanced Concepts
                    </h5>
                    <button class="btn btn-secondary" onclick="uploadFileToTopic('Topic2');">Upload File</button>
                </div>
                <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                    <div class="card-body">
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item"><a href="path_to_pdf/AdvancedConcepts_Part1.pdf" target="_blank">Advanced Concepts Part 1</a></li>
                            <li class="list-group-item"><a href="path_to_pdf/AdvancedConcepts_Part2.pdf" target="_blank">Advanced Concepts Part 2</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!-- Additional topics can be added here -->
        </div>
    </div>
</asp:Content>
