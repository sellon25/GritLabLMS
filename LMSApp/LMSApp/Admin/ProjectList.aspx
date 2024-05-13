<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="ProjectList.aspx.vb" Inherits="LMSApp.ProjectList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Project List 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
  <!--  <div class="white-box" style="height: 100%;">-->

        <div class="d-md-flex mb-3">
            <!--<h3 class="box-title mb-0">Latest</h3>-->
            <div class="col-md-3 col-sm-4 col-xs-6 ms-auto">
                <select class="form-select shadow-none row border-top">
                    <option>Latest</option>
                    <option>Last 2 Months</option>
                    <option>Last 6 Months</option>
                    <option>In A Year</option>
                    <!-- <option>July 2023</option>-->
                </select>
            </div>

        </div>
   <!--  <div class="d-md-flex mb-3">
     <h3 class="box-title mb-0">Latest</h3>
     <div class="col-md-3 col-sm-4 col-xs-6 ">
         LATEST
     </div>

 </div>-->
     <!--</div>-->

        
    <ul class="project-list">
        
        <li class="d-flex">
         
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">June 14, 2020</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                <h5 class="font-medium">GritLab Management System</h5>       
                 <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT</span>
                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team leader : </span>JODY</div>
                </div>
            </div>                                          
 
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">June 14, 2024</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">

                    <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                    <h5 class="font-medium">Banking App</h5>       
                    <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT  </span>
                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team leader : </span>SIMON</div>   
                    </div> 
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">June 14, 2023</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <h5 class="font-medium">Food App</h5>       
                   <span class="mb-3 d-block text-dark">MEMBER LIST WORKING or WORKED ON THE PROJECT  </span>
                   <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>LOGAN</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">April 14, 2023</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <h5 class="font-medium">SACNAPS ZULU Translate </h5>       
                    <span class="mb-3 d-block text-dark">MEMBER LIST WORKING or WORKED ON THE PROJECT  </span>
                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>SIMBA</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">December 14, 2022</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <h5 class="font-medium">CHIETA Tracker</h5>       
                   <span class="mb-3 d-block text-dark">MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                   <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Barkley James</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">December 14, 2022</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                    <h5 class="font-medium">SACNAPS </h5>       
                     <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT</span>
                     <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Bruce Rooney</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">December 14, 2022</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                    <h5 class="font-medium">VR Court Room</h5>       
                    <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Henkel Van de Ven</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">December 14, 2022</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <h5 class="font-medium">Teaching Evalution</h5>       
                    <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Chris London</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">December 14, 2022</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                    <h5 class="font-medium">Rogue AI</h5>       
                    <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Sibusiso Ndlovu</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">December 14, 2022</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                    <h5 class="font-medium">Santa game </h5>       
                    <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Prudence Van Wyk</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">December 14, 2022</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                    <h5 class="font-medium">SACNAPS </h5>       
                     <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT</span>
                     <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Bruce Rooney</div>
                   </div>
                </div>
            </div>
        </li>
        <li class="d-flex" >
            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0 w-25">December 14, 2022</div>
            <div class="txt-oflo w-75">
                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                   <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                     <h5 class="font-medium">Chieta Marking System</h5>       
                      <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT</span>
                     <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>OBI</div>
                   </div>
                </div>
            </div>
        </li>
       
    </ul>
   <!--
    
    <div class="row" style="
        height: 100vh;">

        <div class="col-md-12 col-lg-12 col-sm-12">
            <div class="white-box" style="height: 100%;">
                <div class="d-md-flex mb-3">
                    <h3 class="box-title mb-0">Latest</h3>
                    <div class="col-md-3 col-sm-4 col-xs-6 ms-auto">
                                    <select class="form-select shadow-none row border-top">
                                        <option>Latest</option>
                                        <option>Last 2 Months</option>
                                        <option>Last 6 Months</option>
                                        <option>In A Year</option>
                                       <!-- <option>July 2023</option>
                                    </select>
                                </div>
                            </div>
                            <div class="table-responsive" style="max-height: 100%;">


                                <table class="table no-wrap">
                                    <thead>
                                        <tr>
                                            <th class="border-top-0">Sent on</th>
                                            <th class="border-top-0" style="width:80%">Project Name and Members</th>
                                          
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                        <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">June 14, 2020</td>
                                        <td class="txt-oflo">
                                            <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                            <h5 class="font-medium">GritLab Management Equipment</h5>       
                                            <span class="mb-3 d-block text-dark"> </span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team leader : </span>JODY</div>
                                            </div>
                                        </td>                                          
                                        </tr><tr>
                                        <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">October 6, 2020</td>
                                        <td class="txt-oflo">
                                            <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                            <h5 class="font-medium">Banking App</h5>       
                                            <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT  </span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team leader : </span>SIMON</div>
                                            </div>
                                        </td>                                          
                                        </tr><tr>
                                        <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">July 14, 2019</td>
                                        <td class="txt-oflo">
                                            <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                            <h5 class="font-medium">Food App</h5>       
                                            <span class="mb-3 d-block text-dark">MEMBER LIST WORKING or WORKED ON THE PROJECT  </span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>LOGAN</div>
                                            </div>
                                        </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2023</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium">SACNAPS ZULU Translate </h5>       
                                                <span class="mb-3 d-block text-dark">MEMBER LIST WORKING or WORKED ON THE PROJECT  </span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>SIMBA</div>
                                                </div>
                                            </td>                                          
                                        </tr><tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">December 14, 2022</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium">CHIETA Tracker</h5>       
                                                <span class="mb-3 d-block text-dark">MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Barkley James</div>
                                                </div>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium">SACNAPS </h5>       
                                                <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT</span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Bruce Rooney</div>
                                                </div>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium">VR Court Room</h5>       
                                                <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Henkel Van de Ven</div>
                                                </div>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium">Teaching Evalution</h5>       
                                                <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Chris London</div>
                                                </div>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium">Rogue AI</h5>       
                                                <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Sibusiso Ndlovu</div>
                                                </div>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                                            <td class="txt-oflo">
                                            <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                            <h5 class="font-medium">Santa game </h5>       
                                            <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Prudence Van Wyk</div>
                                            </div>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium"> SIZWE</h5>       
                                                <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Laura de Villers</div>
                                                </div>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium">SMME</h5>       
                                                <span class="mb-3 d-block text-dark"> MEMBER LIST WORKING or WORKED ON THE PROJECT </span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>Sibongile Zulu</div>
                                                </div>
                                            </td>                                          
                                        </tr>
                                        <tr>
                                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                                            <td class="txt-oflo">
                                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                                <h5 class="font-medium">Chieta Marking System</h5>       
                                                <span class="mb-3 d-block text-dark"> </span>
                                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Team Leader: </span>OBI</div>
                                                </div>
                                            </td>                                          
                                        </tr></tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>-->
</asp:Content>
