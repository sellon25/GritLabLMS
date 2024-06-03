<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="Announcements.aspx.vb" Inherits="LMSApp.Announcements1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">

    Announcements 

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">


    <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Announcements</title>
            <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
            <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        </head>
        <body>

        <h3>Announcements</h3>
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
                        <Button type = "button" Class="btn btn-primary" style="background-color:#000000">Add Announcement</button>
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
                                <div class="comment-text ps-2 ps-md-3 w-100">
                                    <h5 class="font-medium">Rogue Santa</h5>
                                    <span class="mb-3 d-block">Project Update</span>
                                    <span class="mb-3 d-block">Lorem Ipsum Is simply dummy text of the printing And type setting industry. It has survived Not only </span>
                                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                </div>
                                <div class="dropdown ml-auto">
                                    <button class="btn btn-sm dropdown-toggle" type="button" id="dropdownMenuButton1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <span class="fas fa-ellipsis-v"></span>
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                                        <a class="dropdown-item" href="#">Edit</a>
                                        <a class="dropdown-item delete-announcement" href="#">Delete</a>
                                        <a class="dropdown-item view-announcement" href="#">View</a>
                                    </div>
                                </div>
                            </div>
                            <!-- Additional announcements can be added here -->
                
                            <!-- Comment Row -->
                            <div class="d-flex flex-row comment-row p-3 mt-0">
                                <div class="p-2"><i class="far fa-question-circle" style="font-size: 26px;"></i></div>
                                <div class="comment-text ps-2 ps-md-3 w-100">
                                    <h5 class="font-medium">GritLab LMS</h5>
                                    <span class="mb-3 d-block">Project Query</span>
                                    <span class="mb-3 d-block">Lorem Ipsum Is simply dummy text of the printing And type setting industry.It has survived Not only </span>
                                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                </div>
                                <div class="dropdown ml-auto">
                                    <button class="btn btn-sm dropdown-toggle" type="button" id="dropdownMenuButton2" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <span class="fas fa-ellipsis-v"></span>
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton2">
                                        <a class="dropdown-item" href="#">Edit</a>
                                        <a class="dropdown-item delete-announcement" href="#">Delete</a>
                                        <a class="dropdown-item view-announcement" href="#">View</a>
                                    </div>
                                </div>
                            </div>
                
                            <!-- Comment Row -->
                            <div class="d-flex flex-row comment-row p-3 mt-0">
                                <div class="p-2"><i class="far fa-bell" style="font-size: 26px;"></i></div>
                                <div class="comment-text ps-2 ps-md-3 w-100">
                                    <h5 class="font-medium">Assignment 1</h5>
                                    <span class="mb-3 d-block">Deadline passed</span>
                                    <span class="mb-3 d-block">Student Solutions now ready Lorem Ipsum Is simply dummy text of the printing And type setting industry.It has survived Not only </span>
                                    <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">April 14, 2021</div>
                                </div>
                                <div class="dropdown ml-auto">
                                    <button class="btn btn-sm dropdown-toggle" type="button" id="dropdownMenuButton3" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <span class="fas fa-ellipsis-v"></span>
                                    </button>
                                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton3">
                                        <a class="dropdown-item" href="#">Edit</a>
                                        <a class="dropdown-item delete-announcement" href="#">Delete</a>
                                        <a class="dropdown-item view-announcement" href="#">View</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


    <%-- <script>
        $(document).ready(function () {
            // Add Announcement Button Click
            $('#addAnnouncementBtn').on('click', function () {
                $('#addAnnouncementModal').modal('show');
            });

            // Add Announcement Form Submission
            $('#addAnnouncementForm').on('submit', function (e) {
                e.preventDefault();

                // Get form values
                var title = $('#announcementTitle').val();
                var type = $('#announcementType').val();
                var message = $('#announcementMessage').val();
                var date = $('#announcementDate').val();

                // Create new announcement element
                var newAnnouncement = `<div class="d-flex flex-row comment-row p-3 mt-0">
                    <div class="comment-text ps-2 ps-md-3 w-100">
                        <h5 class="font-medium">${title}</h5>
                        <span class="mb-3 d-block">${type}</span>
                        <span class="mb-3 d-block">${message}</span>
                        <div class="text-muted fs-2 ms-auto mt-2 mt-md-0">${date}</div>
                    </div>
                    <div class="dropdown ml-auto">
                        <button class="btn btn-sm dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <span class="fas fa-ellipsis-v"></span>
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <a class="dropdown-item" href="#">Edit</a>
                            <a class="dropdown-item delete-announcement" href="#">Delete</a>
                            <a class="dropdown-item view-announcement" href="#">View</a>
                        </div>
                    </div>
                </div>`;

                // Append to the container
                $('#announcementsContainer').append(newAnnouncement);

                // Clear form and hide modal
                $('#addAnnouncementForm')[0].reset();
                $('#addAnnouncementModal').modal('hide');
            });

            // View Announcement
            $(document).on('click', '.view-announcement', function () {
                var title = $(this).closest('.comment-row').find('.font-medium').text();
                var type = $(this).closest('.comment-row').find('.mb-3').eq(0).text();
                var message = $(this).closest('.comment-row').find('.mb-3').eq(1).text();
                var date = $(this).closest('.comment-row').find('.text-muted').text();

                var announcementContent = `<h5>${title}</h5>
                    <p><strong>Type:</strong> ${type}</p>
                    <p><strong>Message:</strong> ${message}</p>
                    <p><strong>Date:</strong> ${date}</p>`;

                $('#viewAnnouncementContent').html(announcementContent);
                $('#viewAnnouncementModal').modal('show');
            });

            // Delete Announcement
            $(document).on('click', '.delete-announcement', function () {
                $(this).closest('.comment-row').remove();
            });
        });
    </script>--%>

    </body>
    </html>


</asp:Content>

