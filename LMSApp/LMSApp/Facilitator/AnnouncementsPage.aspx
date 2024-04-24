<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="AnnouncementsPage.aspx.vb" Inherits="LMSApp.AnnouncementsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    AnnouncementsPage
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row">
        <!-- Add Announcement Section -->
        <div class="col-md-4">
            <div class="white-box">
                <h3 class="box-title">Add Announcement</h3>
                <form>
                    <div class="form-group">
                        <label for="announcementTitle">Title</label>
                        <input type="text" class="form-control" id="announcementTitle" placeholder="Enter title">
                    </div>
                    <div class="form-group">
                        <label for="announcementType">Type</label>
                        <input type="text" class="form-control" id="announcementType" placeholder="Enter type">
                    </div>
                    <div class="form-group">
                        <label for="announcementBody">Body</label>
                        <textarea class="form-control" id="announcementBody" rows="3"></textarea>
                    </div>
                    <button type="button" class="btn btn-primary" >Add Announcement</button>
                </form>
            </div>
        </div>
        <!-- Existing Announcements Section -->
        <div class="col-md-8">
            <div class="white-box">
                <div class="card p-0">
                    <div class="card-body">
                        <h3 class="box-title mb-0">Announcements</h3>
                    </div>
                    <div style="height:500px; overflow-y: scroll;">
                        <!-- Existing Announcements -->
                        <div class="d-flex flex-row comment-row p-3 mt-0">
                            <div class="p-2"><i class="far fa-file-alt" style="font-size: 26px;"></i></div>
                            <div class="comment-text ps-2 ps-md-3 w-100">
                                <h5 class="font-medium">Rogue Santa</h5>
                                <span class="mb-3 d-block">Project Update</span>
                                <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                            </div>
                        </div>
                        <!-- Comment Row -->
                        <div class="d-flex flex-row comment-row p-3 mt-0">
                            <div class="p-2"><i class="far fa-question-circle" style="font-size: 26px;"></i></div>
                            <div class="comment-text ps-2 ps-md-3 w-100">
                                <h5 class="font-medium">GritLab LMS</h5>
                                <span class="mb-3 d-block">Project Query</span>
                                <span class="mb-3 d-block">Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                </div>
                            </div>
                               
                        <!-- Comment Row -->
                        <div class="d-flex flex-row comment-row p-3 mt-0">
                            <div class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                            <div class="comment-text ps-2 ps-md-3 w-100">
                                <h5 class="font-medium">Assignment 1</h5>
                                <span class="mb-3 d-block">Deadline passed</span>
                                <span class="mb-3 d-block">Student Solutions now ready Lorem Ipsum is simply dummy text of the printing and type setting industry.It has survived not only </span>
                                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
