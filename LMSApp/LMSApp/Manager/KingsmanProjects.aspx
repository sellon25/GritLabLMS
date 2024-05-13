<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="KingsmanProjects.aspx.vb" Inherits="LMSApp.KingsmanProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">

    Kingsman Projects

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">

    Kingsman Projects

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">

    <center><h3>Projects</h3></center>


    <script>
        function resetFilter() {
            document.getElementById('txtSearch').value = '';
            applyFilter();
        }
    </script>

     <div class="row courses-container">
     <!-- Course Card Template -->

    <a class="col-md-3" href="ProjectsPage.aspx">
        <div class="white-box boxShadow coursebox">
        <div class="description">
        <label class="box-title">Mini Banking App</label>
        <p class="text-muted">TUT1</p>
        </div>
    </div>
    </a>
<a class="col-md-3" href="ProjectsPage.aspx">
        <div class="white-box boxShadow coursebox">
        <div class="description">
        <label class="box-title">Fish Feeding 3D</label>
        <p class="text-muted">TUT2</p>
        </div>
    </div>
    </a>
<a class="col-md-3" href="ProjectsPage.aspx">
        <div class="white-box boxShadow coursebox">
        <div class="description">
        <label class="box-title">VR Courtroom</label>
        <p class="text-muted">TUT3</p>
        </div>
    </div>
    </a>  
     
     <!-- Add more course cards dynamically based on data -->
     <!-- Example: -->
     <%-- <div class="col-md-3">
             <a href="CoursePage.aspx">
                 <div class="white-box boxShadow coursebox">
                     <div class="description">
                         <label class="box-title">Course Name 1</label>
                         <p class="text-muted">COURSENAME1</p>
                     </div>
                 </div>
             </a>
         </div> 
     --%>
 </div>

</asp:Content>
