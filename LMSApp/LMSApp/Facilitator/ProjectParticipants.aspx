<%@ Page Title="Project Participants" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="ProjectParticipants.aspx.vb" Inherits="LMSApp.ProjectParticipants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Project Participants
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Project Participants
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
        <h2>Participants of the Project</h2>
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Surname</th>
                    <th>Role</th>
                    <th>Email</th>
                    <th>Phone</th>
                </tr>
            </thead>
            <tbody>
                <!-- Sample data, should be dynamically populated from database -->
                <tr>
                    <td>John</td>
                    <td>Doe</td>
                    <td>TeamLead</td>
                    <td>johndoe@example.com</td>
                    <td>123-456-7890</td>
                </tr>
                <tr>
                    <td>Jane</td>
                    <td>Smith</td>
                    <td>Design</td>
                    <td>janesmith@example.com</td>
                    <td>234-567-8901</td>
                </tr>
                <!-- More participants -->
            </tbody>
        </table>
    </div>
</asp:Content>
