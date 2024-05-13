<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="SQWID.aspx.vb" Inherits="LMSApp.SQWID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Manager/ApproveProjects.aspx" Text="Back" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink>


<center><h3>Squid Game</h3></center>

<a class="col-md-3" href="ProjectsPage.aspx">
    <div class="white-box boxShadow coursebox">
    <div class="description">
    <label class="box-title">Squid Game</label>
    <p class="text-muted">SQWID</p>
    </div>
</div>
</a>

  <div class="row">
      <div class="col-md-12">
          <div class="form-group">
              <label for="searchInput">Search Courses:</label>
              <input type="text" id="searchInput" class="form-control" placeholder="Enter keywords">
          </div>
      </div>
  </div>

  <%-- Pagination --%>
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

  <%-- Bulk Actions --%>
  <div class="row">
      <div class="col-md-12">
          <div class="form-group">
              <label for="bulkActions">Action</label>
              <select id="bulkActions" class="form-control">
                  <option value="approve">Approve Selected</option>
                  <option value="reject">Reject Selected</option>
              </select>
              <button type="button" class="btn btn-primary mt-2">Apply</button>
          </div>
      </div>
  </div>

  <%-- Course Details Modal --%>
  <div class="modal fade" id="courseDetailsModal" tabindex="-1" aria-labelledby="courseDetailsModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
          <div class="modal-content">
              <div class="modal-header">
                  <h5 class="modal-title" id="courseDetailsModalLabel">Course Details</h5>
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                  </button>
              </div>
              <div class="modal-body">
                  <!-- Course details will be dynamically populated here -->
                  <!-- Example: -->
                  <p>Course Name: <span id="courseName"></span></p>
                  <p>Course Code: <span id="courseCode"></span></p>
                  <p>Description: <span id="courseDescription"></span></p>
                  <!-- Add more details as needed -->
              </div>
              <div class="modal-footer">
                  <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                  <!-- Additional buttons or actions if necessary -->
              </div>
          </div>
      </div>
  </div>
</asp:Content>
