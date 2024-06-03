<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="Announcements.aspx.vb" Inherits="LMSApp.Announcements1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">

    Announcements 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">

        <%--         <th Class="border-top-0">Announcements</th>
                <th class="border-top-0">Status</th>
                <th class="border-top-0">Viewers</th>
            </tr>
        </thead>
        <tbody>
                        <tr>
                        <td>This is a Test Announcement</td>
                <td class="txt-oflo text-black">Posted</td>
                <td class="text-black">2/5</td>
                <th>
                                <button class="btn btn-sm" type="button" data-toggle="collapse" data-target="#announcement1" aria-expanded="false" aria-controls="announcement1">
                        <span class="fas fa-ellipsis-v"></span>
                    </button>
                </th>
            </tr>
        <tr> --%>



<h3> Module Announcements</h3>
<div Class="row">
    <!-- Add Announcement Section -->
    <div Class="col-md-4">
        <div Class="white-box">
            <h3 Class="box-title">Add Announcement</h3>
            <form>
             <div Class="form-group">
                    <Label for="announcementTitle">Title</label>
                    <input type = "text" Class="form-control" id="announcementTitle" placeholder="Enter title">
                </div>
                <div Class="form-group">
                    <Label for="announcementType">Type</label>
                    <input type = "text" Class="form-control" id="announcementType" placeholder="Enter type">
                </div>
                <div Class="form-group">
                    <Label for="announcementBody">Body</label>
                    <textarea Class="form-control" id="announcementBody" rows="3"></textarea>
                </div>
                <Button type = "button" Class="btn btn-primary" style="background-color:#93761E">Add Announcement</button>
            </form>
        </div>
    </div>
    <!-- Existing Announcements Section -->
    <div Class="col-md-8">
        <div Class="white-box">
            <div Class="card p-0">
                <div Class="card-body">
                    <h3 Class="box-title mb-0">Announcements</h3>
                </div>
                <div style = "height:500px; overflow-y: scroll;" >
                    <!-- Existing Announcements -->
                    <div class="d-flex flex-row comment-row p-3 mt-0">
                    <div class="comment-text ps-2 ps-md-3 w-100">
                        <h5 class="font-medium">Rogue Santa</h5>
                        <span class="mb-3 d-block">Project Update</span>
                        <span class="mb-3 d-block">Lorem Ipsum Is simply dummy text of the printing And type setting industry.It has survived Not only </span>
                        <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                    </div>
                    <div class="dropdown ml-auto">
                        <button class="btn btn-sm dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <span class="fas fa-ellipsis-v"></span>
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <a class="dropdown-item" href="#">Edit</a>
                            <a class="dropdown-item" href="#">Delete</a>
                            <a class="dropdown-item" href="#">View</a>
                        </div>
                    </div>
                </div>
                    <!-- Comment Row -->
                    <div Class="d-flex flex-row comment-row p-3 mt-0">
                        <div class="p-2"><i class="far fa-question-circle" style="font-size: 26px;"></i></div>
                        <div Class="comment-text ps-2 ps-md-3 w-100">
                            <h5 Class="font-medium">GritLab LMS</h5>
                            <span Class="mb-3 d-block">Project Query</span>
                            <span Class="mb-3 d-block">Lorem Ipsum Is simply dummy text of the printing And type setting industry.It has survived Not only </span>
                                <div Class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                            </div>
                        </div>
                           
                    <!-- Comment Row -->
                    <div Class="d-flex flex-row comment-row p-3 mt-0">
                        <div Class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                        <div Class="comment-text ps-2 ps-md-3 w-100">
                            <h5 Class="font-medium">Assignment 1</h5>
                            <span Class="mb-3 d-block">Deadline passed</span>
                            <span Class="mb-3 d-block">Student Solutions now ready Lorem Ipsum Is simply dummy text of the printing And type setting industry.It has survived Not only </span>
                                <div Class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

