<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Manage_Griters_and_Kingsmen.aspx.vb" Inherits="LMSApp.Manage_Students_and_Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Students & Kingsmen
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row" style="padding-top:10px;"> 
        <a class="col-md-12 text-black" href="Manage_Griters.aspx">
            <div class="white-box boxShadow">            
                <h3 class="box-title" >Manage Griters Infomation</h3>
            </div>
        </a>
        <a class="col-md-12 text-black" href="Manage_Kingsmen.aspx">
            <div class="white-box boxShadow">            
                <h3 class="box-title" >Manage Kingsmen Infomation</h3>
            </div>
        </a>
    </div>
</asp:Content>
