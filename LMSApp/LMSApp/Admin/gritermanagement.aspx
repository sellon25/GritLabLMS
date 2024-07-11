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
            <div>
                <div class="form-group">
                    <label for="Load_student">Enter GLA Number To Load</label> 
                    <input type="text" class="form-control" id="Load_student" runat="server" placeholder="Enter Student Number"><button type="button" class=" btn-success">GO</button>
                </div>
                
                <div class="form-group">
                    <label for="glano">GLA No.</label>
                    <input type="text" class="form-control" id="glano" runat="server" placeholder="123456789">
                </div>
                <div class="form-group">
                    <label for="userFname">First name</label>
                    <input type="text" class="form-control" id="userFname" runat="server" placeholder="123456789">
                </div>
                <div class="form-group">
                    <label for="userLname">Last name</label>
                    <input type="text" class="form-control" id="userLname" runat="server" placeholder="123456789">
                </div>
                <div class="form-group">
                    <label for="useremail">Email</label>
                    <input type="email" class="form-control" id="useremail" runat="server" placeholder="abcd@efg.com">
                </div>
                <div class="form-group">
                    <label for="userrole">Role</label>
                    <input type="text" class="form-control text-muted mb-1" id="userroletxt" runat="server" readonly placeholder="">
                     <asp:DropDownList  CssClass="form-select" ID="userrole" runat="server">
                        <asp:ListItem Value="0">Manager</asp:ListItem>
                        <asp:ListItem Value="1">Admin</asp:ListItem>
                        <asp:ListItem Value="2">Facilitator/Leader</asp:ListItem>
                         <asp:ListItem Value="4">Employee</asp:ListItem>
                        <asp:ListItem Value="3">Student</asp:ListItem>                        
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="EnrollmentStatus">Enrollment Status</label>
                    <input type="text" class="form-control text-muted mb-1" id="EnrollmentStatustxt" runat="server" readonly placeholder="">
                    <asp:DropDownList CssClass="form-select" ID="EnrollmentStatus" runat="server">
                        <asp:ListItem Value="0">Accepted</asp:ListItem>
                        <asp:ListItem Value="1">Rejected</asp:ListItem>
                        <asp:ListItem Value="3">Pending - New Applicant</asp:ListItem>
                        <asp:ListItem Value="4">Active</asp:ListItem>
                        <asp:ListItem Value="5">Suspended</asp:ListItem>
                    </asp:DropDownList>
                    
                </div>
                <!-- style="background-color:#93761E"-->
                <button id="UpdateUser" type="button" runat="server" onserverclick="UpdateUser_ServerClick" class="btn btn-success">Submit Changes</button>
                <button id="RemoveUser" type="button" class="btn btn-danger" runat="server" onserverclick="RemoveUser_ServerClick">Remove User</button>
            </div>
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
                                        <th class="border-top-0" style="font-weight: bold;">GLA no.</th>
                                        <th class="border-top-0" style="font-weight: bold;">Name and Surname</th>                                       
                                        <th class="border-top-0" style="font-weight: bold;">Email</th>
                                        <th class="border-top-0" style="font-weight: bold;">Role</th>
                                        <th class="border-top-0" style="font-weight: bold;">Status</th>
                                        <th class="border-top-0" style="font-weight: bold;">Track</th>
                                    </tr>
                                </thead>
                                <tbody id="TableUsers" runat="server">

                                </tbody>
                            </table>
                        </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <asp:Panel ID="pnlEnrollment" runat="server" CssClass="modal">
            <asp:HiddenField ID="SelectedUserID" runat="server" />
        <div class="modal-content p-2">
        <h3 class="border-bottom text-center text-muted">Enrollment Information</h3>
            <div id="EnrollmentInfo" class="Enrollments col-12 " runat="server">
              <%--  <div class="enrol-info border-bottom w-100"> 
                    <div>
                        <p>Course ID: GAME101</p>
                        <p>Date Started: </p>
                        <p>Enrollment Status: Active</p>
                        <p>Date End: </p>
                        <p>Average course mark:</p>
                    </div>
                    <div class="w-100 d-flex justify-content-end">
                        <asp:Button ID="RemoveCourse_id" CssClass="btn text-danger m-0 p-0 mt-2" runat="server" Text="Remove" OnClick="RemoveCourse_Click" />
                    </div>
                </div>--%>
            </div>
            <div class="form-group w-100 mb-0 pt-2 border-top">
                <asp:DropDownList ID="CoursesAvailable" class="form-select w-100" runat="server">

                </asp:DropDownList>
                <asp:Button  ID="EnrollStudent" runat="server" OnClick="EnrollStudent_Click" class="btn mb-2 btn-primary" Text="Enroll To Course" />
            </div>

      
        

        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-secondary" OnClientClick="hidePopup('<%= pnlEnrollment.ClientID %>'); return false;" />

        <script type="text/javascript">
            function hidePopup(id) {
                var popup = document.getElementById(id);
                popup.style.display = 'none';
            }
        </script><script type="text/javascript">
            function hidePopup() {
                var popup = document.getElementById(id);
                popup.style.display = 'none';
            }
        </script>
    </div>
</asp:Panel>
<asp:Panel ID="ApplicationFormPanel" runat="server" CssClass="modal">
     <div id="ApplicationForm" runat="server" class="card" style="min-width:50vh">
            <div class="card-body">
                <h3 class="mb-4 ">Application Form</h3>
                <div class="form-horizontal form-material">
                    <div id="CreatedQuestions"  runat="server" class="ApplicationQuestions mb-4 border-bottom">
                        <h4 class="mb-4 fw-bold ">Application Form</h4>
                
           
                    </div> 
                </div>
            </div>
              <div class="form-group mb-4">
                    <div class="col-sm-12">
                        <asp:Button ID="AcceptApplication" runat="server" Text="Accept" OnClick="AcceptApplication_Click" class="m-2 mb-0 btn btn-orange" />                        
                        <asp:Button ID="DeclineApplication" runat="server" Text="Decline" OnClick="DeclineApplication_Click" class="m-2 mb-0 btn btn-danger" />                        
                    </div>                   
                </div>
        </div>
    <asp:Button ID="CloseAPl" runat="server" Text="Close" CssClass="btn btn-secondary" OnClientClick="hidePopup(this.id); return false;" />
    
</asp:Panel>
</div>
</asp:Content>
