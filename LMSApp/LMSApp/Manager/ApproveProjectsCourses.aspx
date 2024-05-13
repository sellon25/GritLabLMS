<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="ApproveProjectsCourses.aspx.vb" Inherits="LMSApp.ApproveProjectsCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">

<a class="col-md-3" href="../Manager/ApproveCourses.aspx">
    <div class="white-box boxShadow coursebox">
        <div class="description">
            <label class="box-title">Approve Courses</label>
            <p class="text-muted">COURSE</p>
        </div>
    </div>
</a>

<a class="col-md-3" href="../Manager/ApproveProjects.aspx">
    <div class="white-box boxShadow coursebox">
        <div class="description">
            <label class="box-title">Approve Projects</label>
            <p class="text-muted">PROJECT</p>
        </div>
    </div>
</a>

</asp:Content>
