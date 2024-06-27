<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="AnnouncementsPage.aspx.vb" Inherits="LMSApp.AnnouncementsPage" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Manage Announcements
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Announcements
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="d-flex flex-wrap">
        <div class="card m-0 mb-3 col-4 h-100" style="min-width:40vh; margin-right:1vh">
            <div id="addAnnouncementForm" class="card-body">
                <div class="form-end form-group mb-4">
                    <label class="col-md-12 p-0 pb-2 fw-bold w-100">Create an Announcement</label>
                    <div class="form-group p-2 mb-4" style="background-color:#f0f8ff"> 
                        <asp:DropDownList ID="announcementType" runat="server" class="col-md-12 p-0">
                            <asp:ListItem Text="Information" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Question" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Alert" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                       
                        <div class="col-md-12 border-bottom p-0">
                            <input id="announcementTitle" runat="server" type="text" placeholder="Title" class="form-control p-0 border-0">
                            <input id="announcementBody" runat="server" type="text" placeholder="Body" class="form-control p-0 border-0">
                            <asp:Button ID="addAnnouncementButton" runat="server" OnClick="AddAnnouncement_Click" type="button" class="btn mb-2 btn-primary" style="background-color:#3e3d75" Text="Add Announcement" />
                        </div>                    
                    </div>
                    <div class="col-sm-12">
                        <button class="btn btn-orange">Update Announcements</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-1"></div>
        <div class="card col-7" style="min-width:50vh">
            <div class="card-body">
                <div class="form-horizontal form-material">
                    <div id="CreatedAnnouncements" runat="server" class="mb-4 border-bottom">
                        <h4 class="mb-4 fw-bold ">Announcements</h4>
                    </div> 
                </div>
            </div>
        </div>
    </div>
</asp:Content>
