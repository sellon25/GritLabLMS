<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="KingsmanProjects.aspx.vb" Inherits="LMSApp.KingsmanProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">

    Kingsman Projects

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">

    Kingsman Projects

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Manager/Kingsman.aspx" Text="Back" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink>

    <center><h3>Projects</h3></center>


    <script>
        function resetFilter() {
            document.getElementById('txtSearch').value = '';
            applyFilter();
        }
    </script>

     <div class="row courses-container">
     <!-- Course Card Template -->

    <a class="col-md-3" href="ListKingsManProject.aspx">
        <div class="white-box boxShadow coursebox">
        <div class="description">
        <label class="box-title">Mini Banking App</label>
        <p class="text-muted">MINIBANKINGAPP</p>
        </div>
    </div>
    </a>
<a class="col-md-3" href="ListKingsManProject.aspx">
        <div class="white-box boxShadow coursebox">
        <div class="description">
        <label class="box-title">Fish Feeding 3D</label>
        <p class="text-muted">FISHFEEDING3D</p>
        </div>
    </div>
    </a>
<a class="col-md-3" href="ListKingsManProject.aspx">
        <div class="white-box boxShadow coursebox">
        <div class="description">
        <label class="box-title">VR Courtroom</label>
        <p class="text-muted">VRCOURTROOM</p>
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
