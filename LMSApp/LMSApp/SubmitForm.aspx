<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoard.Master" CodeBehind="SubmitForm.aspx.vb" Inherits="LMSApp.SubmitForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Submit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Submit
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <form action="forms/contact.php" method="post" role="form" class="php-email-form">
              <div class="row">
                <div class="form-group col-md-6">
                  <label for="name">Initials</label>
                  <input type="text" name="name" class="form-control" id="name">
                </div>
                <div class="form-group col-md-6">
                  <label for="name">Student Number</label>
                  <input type="email" class="form-control" name="email" id="email">
                </div>
              </div>
              <div class="form-group">
                <label for="name">Subject</label>
                <input type="text" class="form-control" name="subject" id="subject">
              </div>
              <div class="form-group">
                <i class="bi bi-box-arrow-down"></i> <span style="color:rgb(0 0 0);">Upload File</span>
                <textarea class="form-control" name="message" rows="10"></textarea>
              </div>
              
             <input type="button" value="Submit"  onclick="location.reload();"   class="btn btn-primary btn-lg " style="background-color:#3C1B50">
             <input type="button" value="Cancel"  onclick="history.back()" class="btn btn-primary btn-lg " style="background-color:#3C1B50">
             </form>
</asp:Content>
