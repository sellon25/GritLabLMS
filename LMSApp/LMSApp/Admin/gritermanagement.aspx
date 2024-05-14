<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="gritermanagement.aspx.vb" Inherits="LMSApp.gritermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Griters
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row">
    <!-- Add Announcement Section -->
    <div class="col-md-4">
        <div class="white-box">
            <h3 class="box-title">GRITER PROFILE</h3>
            <form>
                <div class="form-group">
                    <label for="Load_student">Enter Student Number To Load</label> 
                    <input type="text" class="form-control" id="Load_student" placeholder="Enter Student Number"><button type="button" class=" btn-success">GO</button>
                </div>
                
                <div class="form-group">
                    <label for="studentno">Student No.</label>
                    <input type="text" class="form-control" id="studentno" placeholder="123456789 ">
                </div>
                <div class="form-group">
                    <label for="Faculty">Faculty</label>
                    <input type="text" class="form-control" id="Faculty" placeholder="Faculty of ...">
                </div>
                <div class="form-group">
                    <label for="Average">Average</label>
                    <input type="text" class="form-control" id="average" placeholder="Average">
                </div>
                <!-- style="background-color:#93761E"-->
                <button type="button" class=" btn-success">ACCEPT</button>
                <button type="button" class=" btn-danger" >Denied</button>
            </form>
        </div>
    </div>
    <!-- Existing Announcements Section -->
    <div class="col-md-8">
        <div class="white-box">
            <div class="card p-0">
                <div class="card-body">
                    <h3 class="box-title mb-0">APPLICANTS FOR GRIT LAB YEAR</h3>
                </div>
                <div class="row">
                <div class="col-md-12 col-lg-12 col-sm-12">
                    <div class="white-box bg-transparent">
            
                    <div class="row mb-3">
                        <div class="col-md-4">
                            <label for="txtSearch">Search:</label>
                            <input type="text" id="txtSearch" class="form-control" placeholder="Enter" onselect="applyFilter()">
                        </div>
                        <div class="col-md-4">
                            <label for="ddlFilter">Filter by:</label>
                            <select id="ddlFilter" class="form-control" onselect="applyFilter()">
                                <option value="NAME">Name</option>
                                <option value="SN">Student Number</option>
                                <option value="SUR">Surname</option>
                                <option value="FAC"> Faculty</option>
                            </select>
                        </div>
                        <div class="col-md-4">
                            <label>&nbsp;</label><br>
                            <button type="button" class="btn btn-primary" onclick="applyFilter()">Apply Filter</button>
                            <button type="button" class="btn btn-secondary" onclick="resetFilter()">Reset</button>
                 
                        </div>
                    </div>
                       <div class="table-responsive">
                            <table class="table no-wrap">
                                <thead>
                                    <tr>
                                        <th class="border-top-0" style="font-weight: bold;">Name and Surname</th>
                                        <th class="border-top-0" style="font-weight: bold;">Faculty</th>
                                        <th class="border-top-0" style="font-weight: bold;">Student Number</th>
                                        <th class="border-top-0" style="font-weight: bold;">Email</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td class="txt-oflo text-black">Manqoba Siyabonga</td>
                                        <td class="text-black">Faculty of Science</td>
                                        <td class="text-black">222800393</td>
                            
                                        <td class="text-black"> student@uj.ac.za </td>
                                        <!--<th> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                    -->
                                    </tr>
                                    <tr>
                   
                                        <td class="txt-oflo text-black">Tim Jacob</td>
                                        <td class="text-black">Faculty of Humanities</td>
                                        <td class="text-black">222800393</td>
                            
                                        <td class="text-black"> student@uj.ac.za </td>
                                       <!-- <th> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                   --> </tr>
                                    <tr>
                            
                                        <td class="txt-oflo text-black">Jerry Martha</td>
                                        <td class="text-black">Faculty of College of Business and Economics</td>
                                        <td class="text-black">224892921</td>
                            
                                        <td class="text-black"> student@uj.ac.za </td>

                                    </tr>
                                    <tr>
                        
                                        <td class="txt-oflo text-black">Carol Nyathi</td>
                                        <td class="text-black"> Faculty of Art, Design and Architecture</td>
                                        <td class="text-black">224322254</td>
                            
                                        <td class="text-black"> student@uj.ac.za </td>
                                                  
                                    </tr>
                                    <tr>
                          
                                        <td class="txt-oflo text-black">Majola Wendy</td>
                                        <td class="text-black">Faculty of Engineering & the Built Environment</td>
                                        <td class="text-black">223893937</td>
                            
                                        <td class="text-black"> student@uj.ac.za </td>
                                    </tr>
                                     <tr>
                           
                                         <td class="txt-oflo text-black"> Wendy Prudence</td>
                                         <td class="text-black">Faculty of Health Sciences</td>
                                         <td class="text-black">224008006</td>
                             
                                         <td class="text-black"> student@uj.ac.za </td>
                                     </tr>
                                     <tr>
                                         <td class="txt-oflo text-black"> Logan Rooney</td>
                                         <td class="text-black">Faculty of Education</td>
                                         <td class="text-black">224030033</td>
                             
                                         <td class="text-black"> student@uj.ac.za </td>
                                     </tr>
                                     <tr>
                                         <td class="txt-oflo text-black"> Mbali Ndlovu</td>
                                         <td class="text-black">Faculty of Law</td>
                                         <td class="text-black">223923224</td>
                                         <td class="text-black"> student@uj.ac.za </td>
                                     </tr>
                                </tbody>
                            </table>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
