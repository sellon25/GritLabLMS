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
            applyFilter();
        }
    </script>

    <div class="row">

        <div class="row">

        <div Class="col-md-4">
            <div Class="white-box">
                <h3 Class="box-title">Send Feedback</h3>
                <form>
                 <div Class="form-group">
                        <Label for="announcementTitle">Email</label>
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

        <div class="col-md-8">
         <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col">
                    <center>
                        <h3> Kingmans List </h3>
                    </center>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-4">
                    <label for="txtSearch">Search:</label>
                    <input type="text" id="txtSearch" class="form-control" placeholder="Enter" onselect="applyFilter()">
                </div>
                <div class="col-md-4">
                    <label for="ddlFilter">Filter by:</label>
                    <select id="ddlFilter" class="form-control" onselect="applyFilter()">
                        <option value="name">Name</option>
                        <option value="id">ID Number</option>
                        <option value="dob">Date of Birth</option>
                    </select>
                </div>
                <div class="col-md-4">
                    <label>&nbsp;</label><br>
                    <button type="button" class="btn btn-primary" onclick="applyFilter()">Apply Filter</button>
                    <button type="button" class="btn btn-secondary" onclick="resetFilter()">Reset</button>
                </div>
            </div>
                <div class="table-responsive">
                    <table class="table no-wrap">
                        <thead>
                            <tr>
                                <th class="border-top-0" style="font-weight: bold;">JBS-GL#</th>
                                <th class="border-top-0" style="font-weight: bold;">Name and Surname</th>
                                <th class="border-top-0" style="font-weight: bold;">Faculty</th>
                                <th class="border-top-0" style="font-weight: bold;">Student Number</th>
                                <th class="border-top-0" style="font-weight: bold;">Average</th>
                                <th class="border-top-0" style="font-weight: bold;">Total Attendance</th>
                                <th class="border-top-0" style="font-weight: bold;">Email</th>
                                <th class="border-top-0" style="font-weight: bold;">Track Progress</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>556</td>
                                <td class="txt-oflo text-black">Manqoba Siyabonga</td>
                                <td class="text-black">Faculty of Science</td>
                                <td class="text-black">222800393</td>
                                <td class="txt-oflo text-black">78</td>
                                <td class="text-black">76</td>
                                <td class="text-black"> student@uj.ac.za </td>
                                <th> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                            
                            </tr>
                            <tr>
                                <td>766</td>
                                <td class="txt-oflo text-black">Tim Jacob</td>
                                <td class="text-black">Faculty of Humanities</td>
                                <td class="text-black">222800393</td>
                                <td class="txt-oflo text-black">75</td>
                                <td class="text-black">80</td>
                                <td class="text-black"> student@uj.ac.za </td>
                                <th> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                             </tr>
                            <tr>
                                <td>512</td>
                                <td class="txt-oflo text-black">Jerry Martha</td>
                                <td class="text-black">Faculty of College of Business and Economics</td>
                                <td class="text-black">224892921</td>
                                <td class="txt-oflo text-black">65</td>
                                <td class="text-black">52</td>
                                <td class="text-black"> student@uj.ac.za </td>
                                <th> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                            </tr>
                            <tr>
                                <td>757</td>
                                <td class="txt-oflo text-black">Carol Nyathi</td>
                                <td class="text-black"> Faculty of Art, Design and Architecture</td>
                                <td class="text-black">224322254</td>
                                <td class="txt-oflo text-black">47</td>
                                <td class="text-black">23</td>
                                <td class="text-black"> student@uj.ac.za </td>
                                <th> <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                                      
                            </tr>
                            <tr>
                                <td>875</td>
                                <td class="txt-oflo text-black">Majola Wendy</td>
                                <td class="text-black">Faculty of Engineering & the Built Environment</td>
                                <td class="text-black">223893937</td>
                                <td class="txt-oflo text-black">66</td>
                                <td class="text-black">60</td>
                                <td class="text-black"> student@uj.ac.za </td>
                                <th> <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        



   <%-- <div Class="row">
    <!-- Send Feedback Section -->

            <script>
                function resetFilter() {
                    document.getElementById('txtSearch1').value = '';
                    applyFilter();
                }
            </script>


<div class="col-md-6">
    <div class="white-box">
        <h3 class="box-title">Send Feedback</h3>
        <form>
            <div class="row mb-3">
                <div class="col-md-4">
                    <label for="ddlFilter1">Filter by:</label>
                    <select id="ddlFilter1" class="form-control" onchange="applyFilter()">
                        <option value="name">Name</option>
                        <option value="id">Student Number</option>
                    </select>
                </div>
                <div class="col-md-8">
                    <label for="txtSearch1">Search:</label>
                    <div class="input-group">
                        <input type="text" id="txtSearch1" class="form-control" placeholder="Enter" oninput="applyFilter()">
                        <button class="btn btn-primary" type="button">Search</button>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label for="sendfeedbackTitle">Title</label>
                <input type="text" class="form-control" id="sendfeedbackTitle" placeholder="Enter title">
            </div>
            <div class="form-group">
                <label for="sendfeedbackType">Type</label>
                <input type="text" class="form-control" id="sendfeedbackType" placeholder="Enter type">
            </div>
            <div class="form-group">
                <label for="sendfeedbackBody">Body</label>
                <textarea class="form-control" id="sendfeedbackBody" rows="3"></textarea>
            </div>
            <button type="button" class="btn btn-primary" style="background-color:#93761E">Send Feedback</button>
        </form>
    </div>
</div> --%>





</asp:Content>
