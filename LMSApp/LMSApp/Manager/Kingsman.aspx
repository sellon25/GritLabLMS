<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="Kingsman.aspx.vb" Inherits="LMSApp.Kingsman" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    
    Kingsman

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">

    Kingsman

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">

    <script>
    function resetFilter() {
        document.getElementById('txtSearch').value = '';
        applyFilter();
    }
    </script>

    <div class="row">

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
                    <div class="row">
                        <div class="col">
                            <hr />
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
                            <option value="student">Student Number</option>
                        </select>
                    </div>
                    <div class="col-md-4">
                        <label>&nbsp;</label><br>
                        <button type="button" class="btn btn-primary btn-outline-dark text-white" onclick="applyFilter()">Apply Filter</button>
                        <button type="button" class="btn btn-secondary btn-outline-dark text-white" onclick="resetFilter()">Reset</button>
                    </div>
                </div>
                    <div class="table-responsive">
                        <table class="table no-wrap">
                            <thead>
                                <tr>
                                    <th class="border-top-0" style="font-weight: bold;">Name and Surname</th>
                                    <th class="border-top-0" style="font-weight: bold;">Project</th>
                                    <th class="border-top-0" style="font-weight: bold;">Student Number</th>
                                    <th class="border-top-0" style="font-weight: bold;">Email</th>
                                    <th class="border-top-0" style="font-weight: bold;">Track Progress</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="txt-oflo text-black">Manqoba Siyabonga</td>
                                    <td class="text-black">Mini Banking App</td>
                                    <td class="text-black">222800393</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                </tr>
                                <!-- Add other rows as needed -->
                                <tr>
                                    <td class="txt-oflo text-black">Tim Jacob</td>
                                    <td class="text-black">VR Courtroom</td>
                                    <td class="text-black">222800393</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                    </tr>
                                <tr>
                                    <td class="txt-oflo text-black">Jerry Martha</td>
                                    <td class="text-black">Mini Banking App</td>
                                    <td class="text-black">224892921</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                </tr>
                                <tr>
                                    <td class="txt-oflo text-black">Carol Nyathi</td>
                                    <td class="text-black">Fish Feeding 3D</td>
                                    <td class="text-black">224322254</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                          
                                </tr>
                                <tr>
                                    <td class="txt-oflo text-black">Majola Wendy</td>
                                    <td class="text-black">Fish Feeding 3D</td>
                                    <td class="text-black">223893937</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                </tr>
                                    <tr>
                                        <td class="txt-oflo text-black"> Wendy Prudence</td>
                                        <td class="text-black">Mini Banking App</td>
                                        <td class="text-black">224008006</td>
                                        <td class="text-black"> student@uj.ac.za </td>
                                        <th> <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                    </tr>
                                    <tr>
                                        <td class="txt-oflo text-black"> Logan Rooney</td>
                                        <td class="text-black">VR Courtroom</td>
                                        <td class="text-black">224030033</td>
                                        <td class="text-black"> student@uj.ac.za </td>
                                        <th> <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                    </tr>
                                    <tr>
                                        <td class="txt-oflo text-black"> Mbali Ndlovu</td>
                                        <td class="text-black">VR Courtroom</td>
                                        <td class="text-black">223923224</td>
                                        <td class="text-black"> student@uj.ac.za </td>
                                        <th> <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                    </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

 </div>

</asp:Content>
