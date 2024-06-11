<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="AnnouncementsPage.aspx.vb" Inherits="LMSApp.AnnouncementsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Announcements
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row">
        <!-- Add Announcement Section -->
        <div class="col-md-4">
            <div class="white-box">
                <h3 class="box-title">Add Announcement</h3>
                <form runat="server">
                    <div class="form-group">
                        <label for="announcementTitle">Title</label>
                        <input type="text" class="form-control" id="announcementTitle" placeholder="Enter title" runat="server">
                    </div>
                    <div class="form-group">
                        <label for="announcementType">Type</label>
                        <select class="form-control" id="announcementType" runat="server">
                            <option value="0">--Select--</option>
                            <option value="0">Information</option>
                            <option value="1">Query</option>
                            <option value="2">Alert</option>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="announcementBody">Body</label>
                        <textarea class="form-control" id="announcementBody" rows="3" runat="server"></textarea>
                    </div>
                    <asp:Button ID="AddAnnouncementButton" runat="server" Text="Add Announcement" CssClass="btn btn-primary" OnClick="AddAnnouncement_Click" style="background-color:#93761E" />
                </form>
            </div>
        </div>
        <!-- Existing Announcements Section -->
        <div class="col-md-8">
            <div class="white-box" style="border: 1px solid #ddd; border-radius: 5px; padding: 10px;">
                <div class="card p-0">
                    <div class="card-body">
                        <h3 class="box-title mb-0">Announcements</h3>
                    </div>
                    <div style="height:500px; overflow-y: scroll;">
                        <!-- Existing Announcements -->
                        <asp:Repeater ID="AnnouncementsRepeater" runat="server">
                            <ItemTemplate>
                                <div class="d-flex flex-row comment-row p-3 mt-0" style="border-bottom: 1px solid #ddd;">
                                    <div class="p-2">
                                        <%# GetIcon(Container.DataItem("type")) %>
                                    </div>
                                    <div class="comment-text ps-2 ps-md-3 w-100">
                                        <h5 class="font-medium"><%# Eval("title") %></h5>
                                        <!-- <span class="mb-3 d-block">%# Eval("sentby") </span> -->
                                        <span class="mb-3 d-block"><%# Eval("text") %></span>
                                        <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><%# Eval("datetime", "{0:MMM dd, yyyy}") %></div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>