<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="AnnouncementsPage.aspx.vb" Inherits="LMSApp.AnnouncementsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Announcements
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="row">
            <!-- Add Announcement Section -->
            <div class="col-md-4">
                <div class="white-box">
                    <h3 class="box-title">Add Announcement</h3>
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
                                            <span class="mb-3 d-block"><%# Eval("text") %></span>
                                            <div class="text-muted fs-2 ms-auto mt-2 mt-md-0"><%# Eval("datetime", "{0:MMM dd, yyyy}") %></div>
                                            
                                        </div>
                                        <asp:Button ID="EditButton" runat="server" Text="Edit" style="height: min-content; color:antiquewhite" CssClass="btn btn-secondary" OnClick="EditButton_Click" CommandArgument='<%# Eval("id") %>' />

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Edit Announcement Modal -->
        <div class="modal fade" id="editAnnouncementModal" tabindex="-1" role="dialog" aria-labelledby="editAnnouncementModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="editAnnouncementModalLabel">Edit Announcement</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="editAnnouncementTitle">Title</label>
                            <input type="text" class="form-control" id="editAnnouncementTitle" placeholder="Enter title" runat="server">
                        </div>
                        <div class="form-group">
                            <label for="editAnnouncementType">Type</label>
                            <select class="form-control" id="editAnnouncementType" runat="server">
                                <option value="0">--Select--</option>
                                <option value="0">Information</option>
                                <option value="1">Query</option>
                                <option value="2">Alert</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="editAnnouncementBody">Body</label>
                            <textarea class="form-control" id="editAnnouncementBody" rows="3" runat="server"></textarea>
                        </div>
                        <asp:Button ID="SaveChangesButton" runat="server" Text="Save Changes" CssClass="btn btn-primary" OnClick="SaveChangesButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>

        <script type="text/javascript">
            // Function to open the modal and load announcement content
            function openEditModal(announcementId) {
                // Manually trigger the modal display using JavaScript
                $('#editAnnouncementModal').modal('show');

                // Load announcement content based on announcementId
                loadAnnouncementContent(announcementId);
            }

            // Function to load announcement content
            function loadAnnouncementContent(announcementId) {
                var xhttp = new XMLHttpRequest();
                xhttp.onreadystatechange = function () {
                    if (this.readyState == 4 && this.status == 200) {
                        var announcementData = JSON.parse(this.responseText);
                        document.getElementById("editAnnouncementTitle").value = announcementData.title;
                        document.getElementById("editAnnouncementType").value = announcementData.type;
                        document.getElementById("editAnnouncementBody").value = announcementData.body;
                    }
                };
                // Assuming the endpoint to fetch announcement content is 'getAnnouncementContent.aspx'
                xhttp.open("GET", "getAnnouncementContent.aspx?id=" + announcementId, true);
                xhttp.send();
            }
        </script>






</asp:Content>
