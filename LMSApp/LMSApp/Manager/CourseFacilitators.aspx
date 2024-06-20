<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="CourseFacilitators.aspx.vb" Inherits="LMSApp.CourceFacilitators" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    
    Cource Facilitators

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Manager/CoursePage.aspx" Text="Back" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink>

   <div class="row" style="padding-top: 20px;">
        <div class="col-md-12">
            <center>
                <h2 style="font-weight: bold;">Course Facilitators</h2>
            </center>
        </div>
    </div>

    <div class="row" style="padding-top: 20px;">
        <div class="col-md-4">
            <div class="facilitator-card">
                <img src="Manager%20Files/imgs/R%20(4).jpeg" alt="Facilitator 1" class="facilitator-img" style="width: 100px; height: 100px; border-radius: 8px;" />
                <h3 style="margin-top: 15px;">Jack Foroa</h3>
                <p><strong>Email: </strong> Jack@gmail.com</p>
                <p><strong>Contact Number: </strong> 0658642456</p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="facilitator-card">
                <img src="Manager%20Files/imgs/R%20(5).jpeg"  class="facilitator-img" style="width: 100px; height: 100px; border-radius: 8px;" alt="Facilitator 2"  />
                <h3 style="margin-top: 15px;">Mike Rose</h3>
                <p><strong>Email: </strong> MikeRose@gmail.com</p>
                <p><strong>Contact Number: </strong> 0656587962</p>
            </div>
        </div>
        <div class="col-md-4">
            <div class="facilitator-card">
            <div class="facilitator-card">
                <img src="Manager%20Files/imgs/R%20(5).jpeg"  class="facilitator-img" style="width: 100px; height: 100px; border-radius: 8px;" alt="Facilitator 2"  />
                <h3 style="margin-top: 15px;">Mike Rose</h3>
                <p><strong>Email: </strong> MikeRose@gmail.com</p>
                <p><strong>Contact Number: </strong> 06565879652</p>
            </div>
        </div>
    </div>
</asp:Content>

