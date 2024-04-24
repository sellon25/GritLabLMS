<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="CoursesAndProjects.aspx.vb" Inherits="LMSApp.CoursesAndProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    CoursesAndProjects
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <!-- ============================================================== -->
    <!-- Alerts and Notifications -->
    <!-- ============================================================== -->
    <div class="row">
        <!-- .col -->
        <div class="col-md-12 white-box">
            <div class="card  p-0">
                <div class="card-body">
                    <h3 class="box-title mb-0">Courses</h3>
                </div>
                <div style="overflow-y: scroll; height: 250px;">

                    <div class="row courses-container" style="width: 95%">
                        <a class="col-md-3" href="CoursePage.aspx">
                           <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/sldr.jpg)">
                               <div class="description">
                                <label class="box-title">Chapter 0</label>
                                <p class="text-muted">CHPTR0</p>
                               </div>
                            </div>
                        </a>
                        <a class="col-md-3" href="CoursePage.aspx">
                            <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/calculus.png)">
                                <div class="description">
                                <label class="box-title">Tutorials 1</label>
                                <p class="text-muted">TUT1</p>
                                </div>
                            </div>
                        </a>
                        <a class="col-md-3" href="CoursePage.aspx">
                            <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/code.png)">
                            <div class="description">
                            <label class="box-title">Tutorials 2</label>
                            <p class="text-muted">TUT2</p>
                            </div>
                        </div>
                        </a>
                        <a class="col-md-3" href="CoursePage.aspx">
                            <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/calculus.png)">
                                <div class="description">
                                <label class="box-title">Tutorials 1</label>
                                <p class="text-muted">TUT1</p>
                                </div>
                            </div>
                        </a>

                        <a class="col-md-3" href="CoursePage.aspx">
                            <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/code.png)">
                            <div class="description">
                            <label class="box-title">Tutorials 2</label>
                            <p class="text-muted">TUT2</p>
                            </div>
                        </div>
                        </a>
                         
                    </div>
                     
                                
                </div>
                </div>
            </div>
        </div>

        <div class="row">
        <!-- .col -->
        <div class="col-md-12 white-box">
            <div class="card  p-0">
                <div class="card-body">
                    <h3 class="box-title mb-0">Projects</h3>
                </div>
                <div style="height:250px; overflow-y: scroll;">
                    <div class="row courses-container" style="width: 95%">
                        <a class="col-md-3" href="CoursePage.aspx">
                            <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/Squid-Game-1.jpg)">
                                <div class="description">
                                <label class="box-title">Loss Aversion</label>
                                <p class="text-muted">LA</p>
                                </div>
                            </div>
                        </a>
                        <a class="col-md-3" href="CoursePage.aspx">
                              <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/Squid-Game-1.jpg)">
                               <div class="description">
                                <label class="box-title">E-LMS</label>
                                <p class="text-muted">LB</p>
                               </div>
                            </div>
                         </a> 
                      </div>          
                </div>
                </div>
            </div>
        </div>

</asp:Content>
