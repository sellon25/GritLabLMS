<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Notifications.aspx.vb" Inherits="LMSApp.Notifications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Notifications
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <!-- ============================================================== -->
    <!-- Notifications -->
    <!-- ============================================================== -->
    <div class="row">
        <!-- .col -->
        <div class="col-md-12 white-box">
            <div class="card  p-0">
                <div class="card-body">
                    <h3 class="box-title mb-0">Notifications</h3>
                </div>
                <div style="height:500px; overflow-y: scroll;">
                    <!-- Comment Row -->
                    <div class="d-flex flex-row comment-row p-3 mt-0">
                        <div class="p-2"><i class="far fa-file-alt" style="font-size: 26px;"></i></div>
                        <div class="comment-text ps-2 ps-md-3 w-100">
                            <h5 class="font-medium">SET NEW PROJECT</h5>
                            <span class="mb-3 d-block">Learn Management System</span>
                            <span class="mb-3 d-block">ADD AVAILABLE EMPLOYEE </span> </div>
                        </div>
                    
                    <!-- Comment Row -->
                    <div class="d-flex flex-row comment-row p-3 mt-0">
                        <div class="p-2"><i class="far fa-question-circle" style="font-size: 26px;"></i></div>
                        <div class="comment-text ps-2 ps-md-3 w-100">
                            <h5 class="font-medium">SET NEW STUDENTS</h5>
                            <span class="mb-3 d-block">CHAT BOT</span>
                            <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                        </div>
                    </div>
                    <!-- Comment Row -->
                    <div class="d-flex flex-row comment-row p-3 mt-0">
                        <div class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                        <div class="comment-text ps-2 ps-md-3 w-100">
                            <h5 class="font-medium">SET ANNOUCEMENT FOR STUDENTS</h5>
                            <span class="mb-3 d-block">SMME Breif</span>
                            <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                        </div>
                    </div>
                    <!-- Comment Row -->
                    <div class="d-flex flex-row comment-row p-3 mt-0">
                         <div class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                         <div class="comment-text ps-2 ps-md-3 w-100">
                             <h5 class="font-medium">SET ANNOUCEMENT FOR STUDENTS</h5>
                             <span class="mb-3 d-block">CHAPTER ZERO Brief</span>
                             <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                             <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                         </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
