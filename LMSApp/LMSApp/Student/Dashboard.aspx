<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoard.Master" CodeBehind="Dashboard.aspx.vb" Inherits="LMSApp.Dashboard1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Dashboard
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
                            <h3 class="box-title">Total tasks</h3>
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
                            <h3 class="box-title">Total term assessments</h3>
                            <ul class="list-inline two-part d-flex align-items-center mb-0">
                                <li>
                                    <div id="sparklinedash2">
                                        <canvas width="67" height="30" style="display: inline-block; width: 67px; height: 30px; vertical-align: top;"></canvas>
                                    </div>
                                </li>
                                <li class="ms-auto"><span class="counter text-purple">12</span></li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-12">
                        <div class="white-box bbg-danger analytics-info">
                            <h3 class="box-title">Incomplete term assessments</h3>
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
         
                <!-- Assessments summary -->
                <!-- ============================================================== -->
                <div class="row">
                    <div class="col-md-12 col-lg-12 col-sm-12">
                        <div class="white-box bg-transparent">
                            <div class="d-md-flex mb-3">
                                <h3 class="box-title mb-0">Tasks summary</h3>
                                <div class="col-md-3 col-sm-4 col-xs-6 ms-auto">
                                    <select class="form-select shadow-none row border-top">
                                        <option>March 2023</option>
                                        <option>April 2023</option>
                                        <option>May 2023</option>
                                        <option>June 2023</option>
                                        <option>July 2023</option>
                                    </select>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <table class="table no-wrap">
                                    <thead>
                                        <tr>
                                            <th class="border-top-0">#</th>
                                            <th class="border-top-0">Name</th>
                                            <th class="border-top-0">Module</th>
                                            <th class="border-top-0">Date</th>
                                            <th class="border-top-0">Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>1</td>
                                            <td class="txt-oflo text-grey">Graded Lab 2</td>
                                            <td class="text-grey">CHEM1101</td>
                                            <td class="txt-oflo text-grey">April 18, 2021</td>
                                            <td><span class="text-grey">Overdue</span></td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td class="txt-oflo">Graded Lab 3</td>
                                            <td>CHEM1101</td>
                                            <td class="txt-oflo">April 21, 2021</td>
                                            <td><span class="text-danger">Due soon</span></td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td class="txt-oflo">Group assignment A</td>
                                            <td>FSA2171</td>
                                            <td class="txt-oflo">April 27, 2021</td>
                                            <td><span class="text-warning">Due in a week</span></td>
                                        </tr>
                                        <tr>
                                            <td>4</td>
                                            <td class="txt-oflo">Quiz 5</td>
                                            <td>CSC2091</td>
                                            <td class="txt-oflo">April 21, 2021</td>
                                            <td><span class="text-success">Due later</span></td>
                                        </tr>
                                        <tr>
                                            <td>5</td>
                                            <td class="txt-oflo">Graded Lab 3</td>
                                            <td>CHEM1101</td>
                                            <td class="txt-oflo">April 21, 2021</td>
                                            <td><span class="text-danger">Due soon</span></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
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
                                        <h5 class="font-medium">Introduction to chemistry 1101</h5>
                                        <span class="mb-3 d-block">Added Course Content</span>
                                        <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                        </div>
                                    </div>
                               
                                 <!-- Comment Row -->
                                <div class="d-flex flex-row comment-row p-3 mt-0">
                                    <div class="p-2"><i class="far fa-question-circle" style="font-size: 26px;"></i></div>
                                    <div class="comment-text ps-2 ps-md-3 w-100">
                                        <h5 class="font-medium">Computer Science 2131</h5>
                                        <span class="mb-3 d-block">Added a quiz</span>
                                        <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                        </div>
                                    </div>
                               
                                <!-- Comment Row -->
                                <div class="d-flex flex-row comment-row p-3 mt-0">
                                    <div class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                                    <div class="comment-text ps-2 ps-md-3 w-100">
                                        <h5 class="font-medium">Calculus 2011</h5>
                                        <span class="mb-3 d-block">Added an announcement</span>
                                        <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                        </div>
                                </div>
                                 <!-- Comment Row -->
                                 <div class="d-flex flex-row comment-row p-3 mt-0">
                                    <div class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                                    <div class="comment-text ps-2 ps-md-3 w-100">
                                        <h5 class="font-medium">Calculus 2011</h5>
                                        <span class="mb-3 d-block">Added an announcement</span>
                                        <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                        </div>
                                </div>
                                
                                
                            
                            </div>
                          </div>
                        </div>
                    </div>
</asp:Content>
