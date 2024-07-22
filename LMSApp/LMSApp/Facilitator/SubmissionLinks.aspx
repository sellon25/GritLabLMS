<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="SubmissionLinks.aspx.vb" Inherits="LMSApp.SubmissionLinks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Submission Links
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <button type="button" class="btn btn-primary" style="background-color:#93761E;" onclick="window.location.href='NewSubmissionLink.aspx?courseId=<%= Request.QueryString("courseId") %>';">Add Submission Link</button>
    <div class="row" style="padding-top:10px;">

        <div class="row" style="padding-top:10px;" id="submissionsContainer" runat="server">
            <!-- Dynamic content will be inserted here -->
        </div>

        <%--<a class="col-md-12 text-decoration-underline" href="SubmitForm.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title" >Group Assignment 1A</h3>
            </div>
        </a>

        <a class="col-md-12 text-decoration-underline" href="SubmitForm.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title">Tests 4</h3>
            </div>
        </a>--%>
             

    </div>
</asp:Content>
