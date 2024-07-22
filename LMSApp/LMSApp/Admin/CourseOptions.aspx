<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="CourseOptions.aspx.vb" Inherits="LMSApp.CourseOptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
     <div>
       <!-- <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/Squid-Game-1.jpg)"></div>-->
        
        <%--<div id="EditCourseInfo" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Edit course details</h3>
          </div> 
        </div>--%>
      <div id="ActionContainer" runat="server" class="col-md-12 white-box">
            <h4 class="w-100 border-bottom fw-bold">Action:</h4>
            <div class="">
                <button id="EditCourseInfo" class="btn btn-secondary m-r-10" runat="server" onserverclick="AddNewCourse_ServerClick" >Edit course info</button>
                <button id="RequestDelete" class="btn btn-danger" runat="server">Request to remove course</button>
                
                <div class="text-muted mt-2"><span>Status: </span> <span class="fw-bold text-black pl-1"> Active</span></div>
            </div>
        </div>
          <div id="CourseForm" runat="server" class="mt-2">
        <div class="card" style="background-color: #dfd9c2;" >
            <div class="card-body">
                <h4 class="mb-3 text-center text-grey fw-bold">Update Course</h4>
                <div class="form-group">
                    <label>Course Name</label>
                    <input type="text" id="coureName" runat="server" placeholder="Development Software 1A" class="form-control text-capitalize"/>
                </div>
                 <div class="form-group">
                    <label>Course ID</label>
                    <input type="text" id="coureID"  runat="server" placeholder="DEV1A"  class="form-control text-uppercase"/>
                </div>
                <div class="form-group">
                    <label>Course Thumbnail</label>
                    <asp:FileUpload ID="FileUpload1" accept="image/*" OnChange="previewImage(this, 'imageContontainer')" CssClass="form-control-file" runat="server" />
                    <div  class="col-md-3" >
                        <div id="imageContontainer" class="white-box boxShadow coursebox image-border">

                        </div>

                    </div>

                </div>
                 <div class="form-group">
                    <label>Description</label>
                    <input type="text" id="coureDesription"  runat="server"  class="form-control"/>
                </div>
                <div class="form-group">
                    <label>Overview</label>
                    <textarea type="text" id="coureOverview" style="min-height: 20vh;"  runat="server" class="form-control"></textarea>
                </div>
                <div class="form-group">
                    <label>Course activatation date</label>
                    <input type="date" id="coureStartDate"  runat="server"  class="form-control"/>
                </div>
                <div class="form-group">
                    <label>Course end date</label>
                    <input type="date" id="coureEndDate"  runat="server"  class="form-control"/>
                </div>
                <div class="form-group">
                    <label>Course Status</label>
                     <asp:DropDownList CssClass="form-select" ID="CourseStatus" runat="server">
                        <asp:ListItem Value="0">Active</asp:ListItem>
                        <asp:ListItem Value="1">Suspended - Admin</asp:ListItem>
                        <asp:ListItem Value="2">Suspended - Manager</asp:ListItem>
                        <asp:ListItem Value="3">Rejected - Manager</asp:ListItem>
                        <asp:ListItem Value="4">Rejected - Faclitator(s)</asp:ListItem>
                        <asp:ListItem Value="5">Expired</asp:ListItem>
                        <asp:ListItem Selected Value="6">Waiting For Approval</asp:ListItem>
                    </asp:DropDownList>
                </div>
                 <div class="form-group">
                    <label>Select factilitators</label>
                     <asp:CheckBoxList CssClass=" form-control-lg" ID="Selectfactilitators" runat="server">
                        <asp:ListItem Value="0">AS Ndaba</asp:ListItem>
                        <asp:ListItem Value="1">RS Brown</asp:ListItem>
                        <asp:ListItem Value="2">E Malatji</asp:ListItem>                        
                    </asp:CheckBoxList>
                </div>
            </div>
            <div class="d-flex flex-column align-items-center">
            <asp:Button ID="CreateCourse" runat="server" CssClass="btn btn-orange" Text="Update Course" OnClick="UpdateCourse_Click" />
            <p class="small text-muted mt-1">This will also notify all set facilitators.</p>

            </div>
                <asp:Button ID="CancelBtn" OnClick="CancelBtn_Click" runat="server" CssClass="m-2 btn btn-secondary w-fit" Text="Cancel" />
        </div>        
    </div>
         <%--<a id="linkOverview" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Overview</h3>
            </div> 
        </a>--%>
         <a id="linkManageUsers" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Manage Enrollments</h3>
            </div> 
        </a>
         <a id="linkAnnouncements" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Announcements</h3>
            </div> 
        </a>
        <a id="linkSubmission" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Submissions</h3>
            </div> 
        </a>
        
        <a id="linkResults" class="col-md-12 text-black" runat="server">
            <div class="white-box boxShadow">
                <h3 class="box-title">Results</h3>
            </div> 
        </a>
       
        
        
    </div>
</asp:Content>
