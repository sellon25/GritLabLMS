<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="ApproveProjects.aspx.vb" Inherits="LMSApp.ApproveProjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    
    Approve Projects

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Manager/ApproveProjectsCourses.aspx" Text="Back" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink>
 
<a class="col-md-3" href="ProjectsPage.aspx">
        <div class="white-box boxShadow coursebox">
        <div class="description">
        <label class="box-title">Tutorials</label>
        <p class="text-muted">TUTS</p>
        </div>
    </div>
    </a>
<a class="col-md-3" href="../Manager/Labs.aspx">
        <div class="white-box boxShadow coursebox">
        <div class="description">
        <label class="box-title">Labs</label>
        <p class="text-muted">LABS</p>
        </div>
    </div>
    </a>
<a class="col-md-3" href="../Manager/SQWID.aspx">
        <div class="white-box boxShadow coursebox">
            <div class="description">
            <label class="box-title">Squidgame</label>
            <p class="text-muted">SQDG</p>
        </div>
    </div>
</a>     

</asp:Content>
