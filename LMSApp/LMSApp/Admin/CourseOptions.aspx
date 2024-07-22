<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="CourseOptions.aspx.vb" Inherits="LMSApp.CourseOptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
     <div>
       <!-- <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/Squid-Game-1.jpg)"></div>-->
        
        <a id="linkOverview" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Overview</h3>
            </div> 
        </a>
         <a id="linkAnnouncements" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Announcements</h3>
            </div> 
        </a>
        <a id="linkSubmission" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Submission Links</h3>
            </div> 
        </a>
        <a id="linkManageUsers" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Manage Enrollments</h3>
            </div> 
        </a>
        <a id="linkResults" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Results</h3>
            </div> 
        </a>
       
        <div class="col-md-12 white-box">
            <h4 class="w-100 border-bottom fw-bold">Action:</h4>
            <div class="">
                <button id="RequestDelete" class="btn btn-danger" runat="server">Request to remove course</button>
                <div class="text-muted mt-2"><span>Status: </span> <span class="fw-bold text-black pl-1"> Active</span></div>
            </div>
        </div>
        
    </div>
</asp:Content>
