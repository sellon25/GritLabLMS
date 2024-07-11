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
        
        <a class="col-md-12 text-black" href="SQDGOverview.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title" >Overview</h3>
            </div> 
        </a>
        <a class="col-md-12 text-black" href="../Admin/SQDGSubmission.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title" >Submission Links</h3>
            </div> 
        </a>
        <a class="col-md-12 text-black" href="../Admin/ManageUsers.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title" >Manager Enrollment</h3>
            </div> 
        </a>
        <a class="col-md-12 text-black" href="../Admin/SQDGAnnoucements.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title">Announcements</h3>
            </div> 
        </a>
        <div class="col-md-12 border-1">
            <h4 class="w-100 border-bottom">Action:</h4>

        </div>
        
    </div>
</asp:Content>
