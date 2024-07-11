<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Set_Projects_and_Course.aspx.vb" Inherits="LMSApp.Set_Projects_and_Course" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
   Projects And Courses/Labs
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
     <div class="row" style="padding-top:10px;">
         <!--<div class="row">

         </div>
         <div class="row">

         </div>-->
        <a class="d-flex flex-row comment-row p-3 mt-0 white-box boxShado white-box boxShadow  text-black" href="Courses.aspx">
            <div class="p-2"><i class="fas fa-graduation-cap text-black" aria-hidden="true" style="font-size:26px"></i></div>
             <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                 <h5 class="box-title"> Courses </h5>
               <!-- <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Due:</span>April 14, 2021</div>-->
            </div>
            
        </a>
       <%--  <a class="d-flex flex-row comment-row p-3 mt-0 white-box boxShado white-box boxShadow  text-black" href="Labs.aspx">
             <div class="p-2"><i class="fab fa-python text-black" aria-hidden="true" style="font-size:35px"></i></div>
             <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                 <h5 class="box-title"> Labs </h5>
               <!-- <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Due:</span>April 14, 2021</div>-->
            </div>
            
        </a>--%>
        <a class="d-flex flex-row comment-row p-3 mt-0 white-box boxShado white-box boxShadow text-black" href="Projects.aspx">
            <div class="p-2"><i class="fas fa-cogs text-black" aria-hidden="true" style="font-size:26px"></i></div>
            <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                 <h5 class="box-title"> Projects </h5>
               <!-- <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Due:</span>April 14, 2021</div>-->
            </div>
            
        </a>
    </div>
</asp:Content>
