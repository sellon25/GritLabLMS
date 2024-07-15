<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Courses.aspx.vb" Inherits="LMSApp.Courses1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentHead" runat="server">
   <style>
       .add-box{
            max-width:61vh
        }
       .card-ovrd{
            background-color: #ffffff9c;
            border-radius:1rem;
       }
       
       .image-border{
            border: 1px solid #f3f3f3;
       }
       .imageContontainer img{
            width:100%;
       }
       .CreateCourse{

       }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Courses
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
   
    <div id="AddCourseForm" runat="server" class="mt-2">
        <div class="card" style="background-color: #dfd9c2;" >
            <div class="card-body">
                <h4 class="mb-3 text-center text-grey fw-bold">Create a New Course</h4>
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
                    <textarea type="text" id="coureOverview"  runat="server"  class="form-control"></textarea>
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
            <asp:Button ID="CreateCourse" runat="server" CssClass="btn btn-orange" Text="Create Course" OnClick="CreateCourse_Click" />
            <p class="small text-muted mt-1">This will also notify all set facilitators.</p>

            </div>
                <asp:Button ID="CancelBtn" OnClick="CancelBtn_Click" runat="server" CssClass="m-2 btn btn-secondary w-fit" Text="Cancel" />
        </div>        
    </div>

     
    
    <button id="AddNewCourse" runat="server" onserverclick="AddNewCourse_ServerClick"  class="btn w-100 d-flex justify-content-center">           
            <div class="w-100 description add-box" >
                <i class="fa fa-plus" aria-hidden="true"></i>
                <p class="m-1">Add a new course</p>
            </div>            
    </button>
    <div id="CoursesContainer" class="row courses-container" runat="server">
        
        <a class="col-md-3" href="../Admin/SQDG.aspx">
              <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/Squid-Game-1.jpg)">
               <div class="description">
                <label class="box-title">Squidgame</label>
                <p class="text-muted">SQDG</p>
               </div>
            </div>
         </a>     
        <a class="col-md-3" href="../Admin/MBKA.aspx">
              <div class="white-box boxShadow coursebox" style="background-image: url(../plugins/images/miniBanking.jpg)">
               <div class="description">
                <label class="box-title">Mini Banking App</label>
                <p class="text-muted">MBKA</p>
               </div>
            </div>
         </a>
       
    </div>
</asp:Content>
