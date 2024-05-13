<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Manage_Griters.aspx.vb" Inherits="LMSApp.Manage_People_and_Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Griters
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row" style="padding-top:10px;"> 
        <a class="col-md-12 text-black" href="gritermanagement.aspx">
            <div class="white-box boxShadow">            
                <h3 class="box-title" >Griter Management</h3>
            </div>
        </a>
        <a class="col-md-12 text-black" href="AdminAnnouncement.aspx">
            <div class="white-box boxShadow">            
                <h3 class="box-title" >Set Announcements</h3>
            </div>
        </a>
        <a class="col-md-12 text-black" href="labresults.aspx">
            <div class="white-box boxShadow">            
                <h3 class="box-title" >Lab Results</h3>
            </div>
        </a>
    </div>
</asp:Content>
