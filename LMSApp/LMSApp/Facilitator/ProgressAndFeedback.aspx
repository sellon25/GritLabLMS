<%@ Page Title="Progress and Feedback" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="ProgressAndFeedback.aspx.vb" Inherits="LMSApp.ProgressAndFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Project Milestones and Communication
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Progress and Feedback
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
        <div class="row">
            <!-- Milestones Column -->
            <div class="col-md-6">
                <h2>Project Milestones</h2>
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Milestone</th>
                            <th>Status</th>
                            <th>Due Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Design Phase Complete</td>
                            <td><span class="badge bg-success">Completed</span></td>
                            <td>2021-04-20</td>
                        </tr>
                        <tr>
                            <td>Initial Code Review</td>
                            <td><span class="badge bg-warning">Pending</span></td>
                            <td>2021-05-15</td>
                        </tr>
                        <!-- More milestones can be dynamically added here -->
                    </tbody>
                </table>
                <div class="card">
                    <div class="card-header">Add New Milestone</div>
                    <div class="card-body">
                        <form method="post" action="AddMilestoneHandler.aspx">
                            <div class="mb-3">
                                <label for="milestoneName" class="form-label">Milestone Name</label>
                                <input type="text" class="form-control" id="milestoneName" name="milestoneName" required>
                            </div>
                            <div class="mb-3">
                                <label for="milestoneDueDate" class="form-label">Due Date</label>
                                <input type="date" class="form-control" id="milestoneDueDate" name="milestoneDueDate" required>
                            </div>
                            <button type="submit" class="btn btn-primary">Add Milestone</button>
                        </form>
                    </div>
                </div>
            </div>

            <!-- Chat Column -->
            <div class="col-md-6">
                <h2>Participant Queries</h2>
                <div class="card">
                    <div class="card-body" style="height: 400px; overflow-y: auto;">
                        <ul class="list-unstyled">
                            <li class="media">
                                <div class="media-body">
                                    <h5 class="mt-0 mb-1">John Doe</h5>
                                    Which language are we supposed to use for the backend?
                                </div>
                            </li>
                            <!-- More messages can be dynamically added here -->
                        </ul>
                    </div>
                    <div class="card-footer">
                        <form>
                            <div class="input-group">
                                <input type="text" class="form-control" placeholder="Type message...">
                                <div class="input-group-append">
                                    <button class="btn btn-outline-secondary" type="button">Send</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
