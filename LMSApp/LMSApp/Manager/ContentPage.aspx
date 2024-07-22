<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="ContentPage.aspx.vb" Inherits="LMSApp.ContentPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">

     
        <div class="col-md-12">
            <div class="white-box boxShadow">
                <h3 class="box-title" style="font-weight: bold;">Course Content</h3>
            <asp:PlaceHolder ID="ContentContainer" runat="server"></asp:PlaceHolder>
            </div>
        </div>



</asp:Content>
