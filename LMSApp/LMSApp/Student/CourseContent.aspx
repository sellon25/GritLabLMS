<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoard.Master" CodeBehind="CourseContent.aspx.vb" Inherits="LMSApp.CourseContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Course Content
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Course Content
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
   <div class="row">
       <a class="d-md-flex white-box boxShadow" href="#">
            <div class="textboookarea">
                <img src="plugins/images/chemtextbook.jpg" class="textbook">
                 <div>
                     <h3 class="text-black">General Chemistry</h3>
                     <p class="text-dark">Lorem ipsum, or lipsum as it is sometimes known, is dummy text used in laying out print, graphic or web designs. The passage is attributed to an unknown typesetter in the 15th century who is thought to have scrambled parts of Cicero's De Finibus Bonorum et Malorum for use in a type specimen book</p>
                 </div>
            </div>
        </a>

    </div>
</asp:Content>
