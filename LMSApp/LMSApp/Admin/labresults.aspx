<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="labresults.aspx.vb" Inherits="LMSApp.Marks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Lab Results
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row" style="height: 100vh;">
        <div class="col-md-12 col-lg-12 col-sm-12">
           <!-- <div class="white-box" style="height: 100%;">-->
                <div class="d-md-flex mb-3">
                    <h3 class="box-title mb-0">JBS GL Tracker</h3>
                    <div class="col-md-3 col-sm-4 col-xs-6 ms-auto">
                                    <select class="form-select shadow-none row border-top">
                                        <option>All</option>
                                        <option>Beta</option>
                                        <option>Alpha</option>
                                        <option>Mega</option>
                                        <!--<option>In A Year</option>
                                        <option>July 2023</option>-->
                                    </select>
                                </div>
                            </div>
            <div class="col-md-6">
                <div class="col-md-4">
                <label for="txtSearch">Search:</label>
                <input type="text" id="txtSearch" class="form-control" placeholder="Enter" onselect="applyFilter()">
            </div>
            <div class="col-md-6">
                <label for="ddlFilter">Filter by:</label>
                <select id="ddlFilter" class="form-control" onselect="applyFilter()">
                    <option value="AV_MARK">Average Mark</option>
                    <option value="GLC">GL-CODE</option>
                    <option value="FAC">Faculty</option>
                </select>
            </div>
                
            </div>
            <div class="table-responsive" style="max-height: 100%;">
                <table class="table no-wrap">
                    <thead>
                        <tr>
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> JBSGL-CODE </th>
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 1 </th> 
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 2 </th> 
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 3 </th>
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 4 </th>
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 5 </th>
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 6 </th>
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 7 </th>
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 8 </th> 
                            <th class="border-top-0 fs-4 ms-auto mt-2 mt-md-0"> Lab 9 </th>
                                            
                            <th class="border-top-0 fs-2 ms-auto mt-2 mt-md-0"> Av. Mark </th>
                            <th class="border-top-0 fs-2 ms-auto mt-2 mt-md-0"> Total Attendence </th>
                            <th class="border-top-0 fs-2 ms-auto mt-2 mt-md-0"> Faculty </th>
                                          
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black "> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black "> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black "> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr><tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr> <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr>
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr>
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr>
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr>
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr>
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr>
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>
                                        
                        </tr>
                        <tr>
                            <td class="text-muted fs-2 ms-auto mt-2 mt-md-0 text-center">555</td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 70 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 60 </td>
                            <td class="text-black"> 10 </td>
                            <td class="text-black"> 90 </td>
                            <td class="text-black"> 43 </td>
                            <td class="text-black"> 100 </td>
                            <td class="text-black"> Faculty of Science </td>                     
                        </tr></tbody>
                </table>
            </div>
        </div>
    <!-- </div>-->
</div>
       
    
                
</asp:Content>
