<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Labs.aspx.vb" Inherits="LMSApp.Admin.Labs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Labs Information
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
   <div class="row" style="padding-top:10px;"> 
   <!-- <a class="col-md-12 text-black" href="Setlab.aspx">
        <div class="white-box boxShadow">            
            <h3 class="box-title" >Set Labs</h3>
        </div>
    </a>-->
    <a class="col-md-12 text-black" href="lablist.aspx">
        <div class="white-box boxShadow">            
            <h3 class="box-title" >Lab List</h3>
        </div>
    </a>
</div>
</asp:Content>
