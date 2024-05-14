<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="CoursePage.aspx.vb" Inherits="LMSApp.Manager.CoursePage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Courses
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Manager/ApproveCourses.aspx" Text="Back" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink>

    <div class="row" style="padding-top: 20px;">
        <div class="col-md-12">
            <center>
                <h2 style="font-weight: bold;">Course Name</h2>
            </center>
        </div>

        <!-- Course Overview Section -->
        <div class="col-md-6">
            <div class="white-box boxShadow">
                <h3 class="box-title" style="font-weight: bold;">Course Overview</h3>
                <p><strong>Description: </strong> A brief description of the course.</p>
                <p><strong>Duration: </strong> Duration of the course.</p>
                <p><strong>Prerequisites: </strong> Prerequisites required for the course.</p>
            </div>
        </div>

        <!-- Course Resources Section -->
        <div class="col-md-6">
            <div class="white-box boxShadow">
                <h3 class="box-title" style="font-weight: bold;">Course Resources</h3>
                <ul style="list-style-type: none; padding-left: 0;">
                    <li><a href="Tests.aspx">Course Learning Guide</a></li>
                    <li><a href="CourseContent.aspx">Course Content</a></li>
                    <li><a href="CourseResults.aspx">Course Facilitators</a></li>
                    <!-- Add more relevant links to resources -->
                </ul>
            </div>
        </div>

        <!-- Additional Sections (if needed) -->
        <div class="col-md-12">
            <div class="white-box boxShadow">
                <h3 class="box-title" style="font-weight: bold;">Assignments and Tasks</h3>
                <!-- Add more relevant sections as needed -->

                <div class="row" >
                    <a class="d-flex flex-row comment-row p-3 mt-0 white-box boxShado white-box boxShadow" href="TestContent.aspx" >
                     <div class="p-2"><i class="far fa-file-alt text-black" style="font-size: 26px;"></i></div>
                     <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                         <h5 class="font-medium">Test 1</h5>       
                         <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                             <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Due:</span>April 14, 2021</div>
                         </div>
                     </a>
                        </div>
                     <div class="row" >
                    <a class="d-flex flex-row comment-row p-3 mt-0 white-box boxShado white-box boxShadow" href="TestContent.aspx" >
                     <div class="p-2"><i class="far fa-file-alt text-black" style="font-size: 26px;"></i></div>
                     <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                         <h5 class="font-medium">Quiz 4</h5>       
                         <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                             <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Due:</span>April 14, 2021</div>
                         </div>
                     </a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
