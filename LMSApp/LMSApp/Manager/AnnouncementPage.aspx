<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="AnnouncementPage.aspx.vb" Inherits="LMSApp.AnnouncementPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">

    Announcement

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">

            <%--<th Class="border-top-0">Announcements</th>
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
    <div class="col-md-4">
        <div class="white-box">
            <h3 class="box-title">Add Announcement</h3>
            <form id="addAnnouncementForm">
                <div class="form-group">
                    <label for="announcementTitle">Title</label>
                    <input type="text" class="form-control" id="announcementTitle" runat="server" placeholder="Enter title">
                </div>
                <div class="form-group">
                    <label for="announcementType">Type</label>
                    <input type="text" class="form-control" id="announcementType" runat="server" placeholder="Enter type">
                </div>
                <div class="form-group">
                    <label for="announcementLink">Link</label>
                    <input type="text" class="form-control" id="announcementLink" runat="server" placeholder="Enter link">
                </div>
                <%--<div class="form-group">
                    <label for="announcementDateTime">Datetime</label>
                    <input type="datetime-local" min="2024-06-06" oninput="checkYear(this)" class="form-control" id="announcementDateTime">
                    --<script>
                        function checkYear(input) {
                            var enteredDate = new Date(input.value);
                            var maxDate = new Date("2024-06-01");

                            if (enteredDate < maxDate) {
                                enteredDate.setFullYear(2005); // Set the year to 2020
                                var formattedDate = enteredDate.toISOString().slice(0, 10);
                                input.value = formattedDate;
                            }
                        }

                        function updateDateTime() {
                            var now = new Date();
                            var year = now.getFullYear();
                            var month = ('0' + (now.getMonth() + 1)).slice(-2);
                            var day = ('0' + now.getDate()).slice(-2);
                            var hours = ('0' + now.getHours()).slice(-2);
                            var minutes = ('0' + now.getMinutes()).slice(-2);
                            var seconds = ('0' + now.getSeconds()).slice(-2);
                            var formattedDateTime = `${year}-${month}-${day}T${hours}:${minutes}:${seconds}`;
                            document.getElementById('announcementDateTime').value = formattedDateTime;
                        }

                        setInterval(updateDateTime, 1000); // Update every second
                 </script>

                </div>--%>
               <div class="form-group">
                    <label for="announcementBody">Text</label>
                    <textarea class="form-control" id="announcementText" runat="server" rows="3"></textarea>
                </div>
                <%--<div class="form-group">
                    <label for="announcementStatus">Status</label>
                    <select class="form-control" id="announcementStatus">
                        <option value="draft">Draft</option>
                        <option value="published">Published</option>
                    </select>
                </div>--%>
                <div class="form-group">
                    <label for="announcementSentBy">Sent By</label>
                    <input type="text" class="form-control" id="announcementSentBy" runat="server" placeholder="Enter sender">
                </div>
                <div class="form-group">
                    <asp:Button class="btn btn-primary" style="background-color:#93761E" OnClick="addAnnouncement_Click" ID="addAnnouncement" runat="server" Text="Add Announcement" />
                </div>
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
                        <div class="dropdown ml-auto">
                            <button class="btn btn-sm dropdown-toggle" type="button" id="dropdownMenuButton1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="fas fa-ellipsis-v"></span>
                            </button>
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                <a class="dropdown-item" href="#">Edit</a>
                                <a class="dropdown-item" href="#">Delete</a>
                                <a class="dropdown-item" href="#">View</a>
                            </div>
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
                        <div class="dropdown ml-auto">
                            <button class="btn btn-sm dropdown-toggle" type="button" id="dropdownMenuButton2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <span class="fas fa-ellipsis-v"></span>
                            </button>
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton2">
                                <a class="dropdown-item" href="#">Edit</a>
                                <a class="dropdown-item" href="#">Delete</a>
                                <a class="dropdown-item" href="#">View</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
