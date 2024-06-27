<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="StudentsProgress.aspx.vb" Inherits="LMSApp.StudentsProgress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Gritters Progress
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Gritters Progress
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <script>
        function resetFilter() {
            document.getElementById('txtSearch').value = '';
            document.getElementById('<%= btnApplyFilter.ClientID %>').click();
        }
    </script> <div class="row">
        <div class="row">
            <div Class="col-md-4">
                <div Class="white-box">
                    <h3 Class="box-title">Send Feedback</h3>
                    <div Class="form-group">
                        <Label for="SendToEmail">Email</label>
                        <input type="text" Class="form-control" id="SendToEmail" runat="server" placeholder="Enter Email">
                    </div>
                    <div Class="form-group">
                        <Label for="Subject">Subject</label>
                        <input type="text" Class="form-control" id="Subjects" runat="server" placeholder="Enter Subject">
                    </div>
                    <div Class="form-group">
                        <Label for="EmailBody">Body</label>
                        <input Class="form-control" id="EmailBody" runat="server" rows="3" type="text" placeholder="Type......">
                    </div>
                    <asp:Button ID="btnSendEmail" runat="server" Text="SEND" CssClass="btn btn-primary"/>
                </div>
            </div>
            <div class="col-md-8">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Kingmans List</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label for="txtSearch">Search:</label>
                                <input type="text" runat="server" id="txtSearch" class="form-control" placeholder="Enter" />
                            </div>
                            <div class="col-md-4">
                                <label for="ddlFilter">Filter by:</label>
                                <select id="ddlFilter" runat="server" class="form-control">
                                    <option value="name">Name and Surname</option>
                                    <option value="userId">User ID</option>
                                </select>
                            </div>
                            <div class="col-md-4">
                                <label>&nbsp;</label><br>
                                <asp:Button ID="btnApplyFilter" type="button" runat="server" class="btn btn-primary" OnClick="ApplyFilter_Click" Text="Apply Filter"/>
                                <asp:Button ID="btnResetFilter" type="button" runat="server" class="btn btn-secondary" OnClick="Resert_Click" Text="Reset"/>
                            </div>
                        </div>
                        <div class="table-responsive">
                            <table class="table no-wrap" id="StudentsTable">
                                <thead>
                                    <tr>
                                        <th class="border-top-0" style="font-weight: bold;">JBS-GL#</th>
                                        <th class="border-top-0" style="font-weight: bold;">User ID</th>
                                        <th class="border-top-0" style="font-weight: bold;">Faculty</th>
                                        <th class="border-top-0" style="font-weight: bold;">Student Number</th>
                                        <th class="border-top-0" style="font-weight: bold;">Average</th>
                                        <th class="border-top-0" style="font-weight: bold;">Total Attendance</th>
                                        <th class="border-top-0" style="font-weight: bold;">Email</th>
                                        <th class="border-top-0" style="font-weight: bold;">Track Progress</th>
                                    </tr>
                                </thead>
                                <tbody id="StudentsTableBody" runat="server">
                                    <!-- Rows will be dynamically populated here -->
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>