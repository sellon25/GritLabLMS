<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="UploadPDF.aspx.vb" Inherits="LMSApp.UploadPDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Send Project
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">

    <form action="forms/contact.php" method="post" role="form" class="php-email-form">
          <div class="row">
            <div class="form-group col-md-6">
              <label for="name">File Name</label>
              <select id="ddlFilter" class="form-control" onselect="applyFilter()">
    
                <option value="SN">Mini-Banking App</option>
                <option value="GL">Squid Game</option>

            </select>
            </div>
            <div class="form-group col-md-6">
                <label for="name">Send To GL-Code</label>
                <input type="text" name="Code" class="form-control" id="Code">
            </div>
          </div>
          <div class="form-group">
            <label for="name">Project Name</label>
            <input type="text" class="form-control" name="Project" id="Project">
          </div>
          <div class="form-group">
            <i class="bi bi-box-arrow-down"></i> <span style="color:rgb(0 0 0);">Upload File</span>
            <textarea class="form-control" name="message" rows="10"></textarea>
          </div>
          
         <input type="button" value="Submit"  onclick="location.reload();"   class="btn btn-primary btn-lg " style="background-color:#3C1B50">
         <input type="button" value="Cancel"  onclick="history.back()" class="btn btn-primary btn-lg " style="background-color:#3C1B50">
         
    </form>
</asp:Content>
