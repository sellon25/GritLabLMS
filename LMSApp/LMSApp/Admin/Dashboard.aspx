<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Dashboard.aspx.vb" Inherits="LMSApp.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Dashboard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <!-- ============================================================== -->
           <!-- Three charts -->
           <!-- ============================================================== -->
           <div class="row justify-content-center">
               <div class="col-lg-4 col-md-12">
                   <div class="white-box bbg-good analytics-info">
                       <h3 class="box-title"> Total Projects </h3>
                       <ul class="list-inline two-part d-flex align-items-center mb-0">
                           <li>
                               <div id="sparklinedash">
                                   <canvas width="67" height="30" style="display: inline-block; width: 67px; height: 30px; vertical-align: top;"></canvas>
                               </div>
                           </li>
                           <li class="ms-auto"><span class="counter text-warning">24</span></li>
                       </ul>
                   </div>
               </div>
               <div class="col-lg-4 col-md-12">
                   <div class="white-box bbg-mid analytics-info">
                       <h3 class="box-title">Complete Projects</h3>
                       <ul class="list-inline two-part d-flex align-items-center mb-0">
                           <li>
                               <div id="sparklinedash2">
                                   <canvas width="67" height="30" style="display: inline-block; width: 67px; height: 30px; vertical-align: top;"></canvas>
                               </div>
                           </li>
                           <li class="ms-auto"><span class="counter text-purple">13</span></li>
                       </ul>
                   </div>
               </div>
               <div class="col-lg-4 col-md-12">
                   <div class="white-box bbg-danger analytics-info">
                       <h3 class="box-title">Assigned Projects</h3>
                       <ul class="list-inline two-part d-flex align-items-center mb-0">
                           <li>
                               <div id="sparklinedash3"><canvas width="67" height="30"
                                       style="display: inline-block; width: 67px; height: 30px; vertical-align: top;"></canvas>
                               </div>
                           </li>
                           <li class="ms-auto"><span class="counter text-info">11</span>
                           </li>
                       </ul>
                   </div>
               </div>
           </div>
    
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
                                    <span class="mb-3 d-block">ADD AVAILABLE KINGSMEN </span> </div>
                                </div>
                
                            <!-- Comment Row -->
                            <div class="d-flex flex-row comment-row p-3 mt-0">
                                <div class="p-2"><i class="far fa-question-circle" style="font-size: 26px;"></i></div>
                                <div class="comment-text ps-2 ps-md-3 w-100">
                                    <h5 class="font-medium">SET NEW PROJECT</h5>
                                    <span class="mb-3 d-block">CHAT BOT</span>
                                    <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                </div>
                            </div>
                            <!-- Comment Row -->
                            <div class="d-flex flex-row comment-row p-3 mt-0">
                                <div class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                                <div class="comment-text ps-2 ps-md-3 w-100">
                                    <h5 class="font-medium">SET ANNOUCEMENT FOR KINGSMEN/SOLIDERS</h5>
                                    <span class="mb-3 d-block">SMME Breif</span>
                                    <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                </div>
                            </div>
                            <!-- Comment Row -->
                            <div class="d-flex flex-row comment-row p-3 mt-0">
                                 <div class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                                 <div class="comment-text ps-2 ps-md-3 w-100">
                                     <h5 class="font-medium">SET ANNOUCEMENT FOR GRITERS</h5>
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
