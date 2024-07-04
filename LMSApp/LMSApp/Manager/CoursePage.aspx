﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="CoursePage.aspx.vb" Inherits="LMSApp.Manager.CoursePage1" %>
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
                <h2 style="font-weight: bold;" ID="lblCourseName" runat="server"></h2>
            </center>
        </div>

        <!-- Course Overview Section -->
        <div class="col-md-6">
            <div class="white-box boxShadow">
                <asp:PlaceHolder ID="CourseOverviewContainer" runat="server"></asp:PlaceHolder>
            </div>
        </div>

        <!-- Course Resources Section -->
        <div class="col-md-6">
            <div class="white-box boxShadow">
                <h3 class="box-title" style="font-weight: bold;">Course Resources</h3>
                <ul style="list-style-type: none; padding-left: 0;">
                    <li><a href="Tests.aspx">Course Learning Guide</a></li>
                    <li><a href="Content.aspx">Course Content</a></li>
                    <li><a href="CourseFacilitators.aspx">Course Facilitators</a></li>
                    <!-- Add more relevant links to resources -->
                </ul>
            </div>
        </div>

        <!-- Additional Sections (if needed) -->
        <div class="col-md-12">
            <div class="white-box boxShadow">
                <h3 class="box-title" style="font-weight: bold;">Assignments and Tasks</h3>
                <asp:PlaceHolder ID="AssignmentsContainer" runat="server"></asp:PlaceHolder>
            </div>
        </div>

        <!-- Approval and Rejection Buttons -->
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="bulkActions">Action</label>
                    <select ID="bulkActions" name="bulkActions" class="form-control"> 
                        <option value="Approve">Approve</option>
                        <option value="Reject">Reject</option>
                    </select>
                    <asp:Button class="btn btn-primary" style="background-color:#93761E" OnClick="AcceptReject_Click" ID="AcceptReject" runat="server" Text="Apply" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
