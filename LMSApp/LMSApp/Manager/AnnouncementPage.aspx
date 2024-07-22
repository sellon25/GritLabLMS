<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="AnnouncementPage.aspx.vb" Inherits="LMSApp.AnnouncementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Announcement
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <h3>Module Announcements</h3>
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
                        <label for="announcementsForm">Form</label> 
                        <asp:DropDownList ID="announcementsForm" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="announcementsForm_SelectedIndexChanged">
                            <asp:ListItem Text="Default" Value="Default"></asp:ListItem>
                            <asp:ListItem Text="Course Announcement" Value="Course"></asp:ListItem>
                            <asp:ListItem Text="Project Announcement" Value="Project"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="sendTo">Send To</label>
                        <asp:DropDownList ID="sendTo" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="UpdateSendToDropdown">
                            <asp:ListItem Text="Everyone" Value="Default"></asp:ListItem>
                            <asp:ListItem Text="Course" Value="Course"></asp:ListItem>
                            <asp:ListItem Text="Project" Value="Project"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CheckBoxList ID="chkListCoursesProjects" runat="server" CssClass="form-check mt-2" Visible="False"></asp:CheckBoxList>
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
                        <label for="announcementBody">Text</label>
                        <textarea class="form-control" id="announcementText" runat="server" rows="3"></textarea>
                    </div>
                    <div class="form-group">
                        <label for="announcementLink">Link</label>
                        <input type="text" class="form-control" id="announcementLink" runat="server" placeholder="Enter link">
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
                <!-- Announcements Container -->
                <asp:PlaceHolder ID="AnnouncementsContainer" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>
