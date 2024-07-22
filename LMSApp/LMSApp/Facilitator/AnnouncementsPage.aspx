<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="AnnouncementsPage.aspx.vb" Inherits="LMSApp.AnnouncementsPage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Manage Announcements
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Announcements
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
<div class="row">
    <!-- Add Announcement Section -->
    <div class="col-md-4">
        <div class="white-box">
            <h3 class="box-title">Add Announcement</h3>
            <asp:PlaceHolder runat="server">
                    <div class="form-group">
                        <label for="announcementTitle">Title</label>
                        <input type="text" class="form-control" id="announcementTitle" runat="server" placeholder="Enter title">
                    </div>
                    <div class="form-group">
                        <label for="announcementType">Type</label> 
                            <select id="announcementType" name="announcementType" class="form-control">
                                <option value="Information">Information</option>
                                <option value="Query">Query</option>
                                <option value="Alert">Alert</option>
                            </select>
                    </div>
                    <div class="form-group">
                        <label for="announcementLink">Link</label>
                        <input type="text" class="form-control" id="announcementLink" runat="server" placeholder="Enter link">
                    </div>
                    <div class="form-group">
                        <label for="announcementBody">Text</label>
                        <textarea class="form-control" id="announcementText" runat="server" rows="3"></textarea>
                    </div>
                    <div class="form-group hide">
                        <label for="announcementSentBy">Sent By</label>
                        <input type="text" class="form-control" id="announcementSentBy" runat="server" placeholder="Enter sender">
                    </div>
                    <div class="form-group">
                        <asp:Button class="btn btn-primary" style="background-color:#93761E" OnClick="addAnnouncement_Click" ID="addAnnouncement" runat="server" Text="Add Announcement" />
                    </div>
            </asp:PlaceHolder>
        </div>
    </div>

    <div class="col-md-8">
        <div class="white-box">
            <div class="card p-0">
                <div class="card-body">
                    <h3 class="box-title mb-0">Announcements</h3>
                </div>
                <div style="height:500px; overflow-y: scroll;" id="AnnouncementsContainer" runat="server">
                    <!-- Announcements will be dynamically injected here -->
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>
