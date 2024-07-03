<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="ApproveCourses.aspx.vb" Inherits="LMSApp.ApproveCourses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
     Approve Courses
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Manager/ApproveProjectsCourses.aspx" Text="Back" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink>

    <div class="row courses-container" id="CoursesContainer" runat="server">
        <!-- Courses will be dynamically populated here -->
    </div>

    <!-- Additional Features -->
<%--    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <label for="searchInput">Search Courses:</label>
                <input type="text" id="searchInput" runat="server" class="form-control" placeholder="Enter keywords">
            </div>
        </div>
    </div>--%>

    <div class="row">
        <div class="col-md-12">
            <nav aria-label="Page navigation">
                <ul class="pagination justify-content-center">
                    <li class="page-item disabled">
                        <a class="page-link" href="#" tabindex="-1" aria-disabled="true">Previous</a>
                    </li>
                    <li class="page-item"><a class="page-link" href="#">1</a></li>
                    <li class="page-item"><a class="page-link" href="#">2</a></li>
                    <li class="page-item">
                        <a class="page-link" href="#">Next</a>
                    </li>
                </ul>
            </nav>
        </div>
    </div>
    
<%--    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <label for="bulkActions">Action</label>
                <select ID="bulkActions" name="bulkActions" class="form-control"> 
                    <option value="Approve">Approve</option>
                    <option value="Reject">Reject</option>
                </select>
                <asp:Button class="btn btn-primary" style="background-color:#93761E" onclick="AcceptReject_Click" ID="AcceptReject" runat="server" Text="Apply" />
            </div>
        </div>
    </div>--%>

    <div class="modal fade" id="courseDetailsModal" tabindex="-1" aria-labelledby="courseDetailsModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="courseDetailsModalLabel">Course Details</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" id="courseDetailsModalBody">
                    <!-- Course details will be dynamically populated here -->
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

<%--    <script>
        // JavaScript function to set the value of the search input
        function setSearchInput(courseName) {
            var searchInput = document.getElementById('<%= searchInput.ClientID %>');
            searchInput.value = decodeURIComponent(courseName).replace(/\+/g, ' ');
        }
    </script>--%>

    <style>
        .course-thumbnail {
            width: 100%;
            height: auto;
        }
    </style>

</asp:Content>
