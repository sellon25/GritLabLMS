<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="SQDG.aspx.vb" Inherits="LMSApp.SQDG1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Squid Game
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div>
       <!-- <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/Squid-Game-1.jpg)"></div>-->
        
        <a class="col-md-12 text-black" href="SQDGOverview.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title" >Overview of Squid Game</h3>
            </div> 
        </a>
        <a class="col-md-12 text-black" href="../Admin/SQDGSubmission.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title" >Submission Link</h3>
            </div> 
        </a>
        <a class="col-md-12 text-black" href="../Admin/ManageUsers.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title" >Manager Users</h3>
            </div> 
        </a>
        <a class="col-md-12 text-black" href="../Admin/SQDGAnnoucements.aspx">
            <div class="white-box boxShadow">
                <h3 class="box-title" >Announcements</h3>
            </div> 
        </a>
        
        
    </div>
   
</asp:Content>
