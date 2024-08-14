<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Manage_Kingsmen.aspx.vb" Inherits="LMSApp.Manage_Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Employees
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row" style="padding-top:10px;"> 
    <a class="col-md-12 text-black" href="kingsmenmanagement.aspx">
        <div class="white-box boxShadow">            
            <h3 class="box-title" >Employee Track Progress</h3>
        </div>
    </a>
    <a class="col-md-12 text-black" href="AnnouncementsKingsmen.aspx">
        <div class="white-box boxShadow">            
            <h3 class="box-title" >Set Announcements</h3>
        </div>
    </a>
    <a class="col-md-12 text-black" href="addkingsmen.aspx">
        <div class="white-box boxShadow">            
            <h3 class="box-title" >Add Employee</h3>
        </div>
    </a>
</div>
</asp:Content>
