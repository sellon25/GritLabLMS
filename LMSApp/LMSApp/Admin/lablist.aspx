<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="lablist.aspx.vb" Inherits="LMSApp.lablist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    LAB LIST
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
     <div class="row" style="
     height: 100vh;">
         <div class="col-md-12 col-lg-12 col-sm-12">
             <div class="white-box" style="height: 100%;">
                 <div class="d-md-flex mb-3">
                     <h3 class="box-title mb-0">Lab List </h3>
                     <div class="col-md-3 col-sm-4 col-xs-6 ms-auto">
                         <select class="form-select shadow-none row border-top">
                             <option>Beta</option>
                             <option>Alpha</option>
                             <option>Mega</option>
                            <!--<option>In A Year</option>-->
                        <!-- <option>July 2023</option>-->
                         </select>

                     </div>

                 </div>
                 <div class="table-responsive" style="max-height: 100%;">
                     <table class="table no-wrap">
                        <thead>
                            <tr>
                                <th class="border-top-0">Lab Date</th>
                                <th class="border-top-0" style="width:80%">Labs</th>
                                       
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                            <td class="txt-oflo">
                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                <h5 class="font-medium">Lab 1</h5>       
                                <span class="mb-3 d-block text-dark">LOGIC </span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Create by: </span> Barkley Bacus</div>
                                </div>
                            </td>                                          
                            </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                            <td class="txt-oflo">
                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                <h5 class="font-medium">Lab 2 </h5>       
                                <span class="mb-3 d-block text-dark">Data types </span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Create by: </span> Barkley Bacus</div>
                                </div>
                            </td>                                          
                            </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                            <td class="txt-oflo">
                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                <h5 class="font-medium">Lab 3</h5>       
                                <span class="mb-3 d-block text-dark"> LOOPS </span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Create by: </span> Barkley Bacus</div>
                                </div>
                            </td>                                          
                            </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                            <td class="txt-oflo">
                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                <h5 class="font-medium">Lab 4</h5>       
                                <span class="mb-3 d-block text-dark"> Loops Continued</span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Create by: </span> Barkley Bacus</div>
                                </div>
                            </td>                                          
                            </tr>
                                
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                            <td class="txt-oflo">
                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                <h5 class="font-medium">Lab 5</h5>       
                                <span class="mb-3 d-block text-dark"> Lists  </span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Create by: </span> Barkley Bacus</div>
                                </div>
                            </td>                                          
                            </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                            <td class="txt-oflo">
                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                <h5 class="font-medium">Lab 6</h5>       
                                <span class="mb-3 d-block text-dark"> Files </span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Create by: </span> Barkley Bacus</div>
                                </div>
                            </td>                                          
                            </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                            <td class="txt-oflo">
                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                <h5 class="font-medium">Lab 7</h5>       
                                <span class="mb-3 d-block text-dark"> Fractals </span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Create by: </span> Barkley Bacus</div>
                                </div>
                            </td>                                          
                            </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</td>
                            <td class="txt-oflo">
                                <div class="comment-text ps-2 ps-md-3 w-100 text-black">
                                <h5 class="font-medium">Lab 8</h5>       
                                <span class="mb-3 d-block text-dark">Griter Group Project</span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><span>Create by: </span> Barkley Bacus</div>
                                </div>
                            </td>                                          
                            </tr></tbody>
                    </table>

                 </div>

             </div>

         </div>

     </div>
</asp:Content>
