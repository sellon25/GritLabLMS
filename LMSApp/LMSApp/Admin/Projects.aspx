<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Projects.aspx.vb" Inherits="LMSApp.Projects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Projects
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row" >
        <a class="d-flex flex-row comment-row p-3 mt-0 white-box boxShado white-box boxShadow" href="AddProject.aspx" >
            <div class="p-2"><i class="far fa-file-alt text-black" style="font-size: 26px;"></i></div>
            <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                <h5 class="font-medium">ADD PROJECT</h5>       
               <!-- <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Due:</span>April 14, 2021</div>-->
            </div>
        </a>
    </div>
    <div class="row" >
        <a class="d-flex flex-row comment-row p-3 mt-0 white-box boxShado white-box boxShadow" href="ProjectList.aspx" >
            <div class="p-2"><i class="far fa-file-alt text-black" style="font-size: 26px;"></i></div>
            <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                <h5 class="font-medium">PROJECT LIST</h5>
            </div>
        </a>
    </div>
</asp:Content>
