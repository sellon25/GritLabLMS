<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="ProjectsPage.aspx.vb" Inherits="LMSApp.ProjectsPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">

    Projects

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Manager/ApproveProjects.aspx" Text="Back" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink>
    
    <div class="row" style="padding-top: 20px;">
        <div class="col-md-12">
            <center>
                <h2 style="font-weight: bold;" ID="lblProjectName" runat="server"></h2>
            </center>
        </div>

        <!-- Course Overview Section -->
        <div class="col-md-6">
            <div class="white-box boxShadow">
                <asp:PlaceHolder ID="ProjectOverviewContainer" runat="server"></asp:PlaceHolder>
            </div>
        </div>

        <!-- Course Resources Section -->
        <div class="col-md-6">
            <div class="white-box boxShadow">
                <asp:PlaceHolder ID="ProjectResourcesContainer" runat="server"></asp:PlaceHolder>
            </div>
        </div>

        <!-- Additional Sections (if needed) -->
        <%--<div class="col-md-12">
            <div class="white-box boxShadow">
                <h3 class="box-title" style="font-weight: bold;">Assignments and Tasks</h3>
                <asp:PlaceHolder ID="AssignmentsContainer" runat="server"></asp:PlaceHolder>
            </div>
        </div>--%>

        <!-- Approval and Rejection Buttons -->
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <label for="bulkActions">Action</label>
                    <select ID="bulkActions" name="bulkActions" class="form-control"> 
                        <option value="Approve">Approve</option>
                        <option value="Reject">Reject</option>
                    </select>
                    <asp:Button class="btn btn-primary" style="background-color:#93761E" OnClick="AcceptReject_Click" ID="AcceptReject" runat="server" Text="Apply" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
