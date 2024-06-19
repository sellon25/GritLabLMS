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
        <div class="col-md-4">
            <div class="white-box">
                <h3 class="box-title">Send Email</h3>
                <div class="form-group">
                    <label for="email">Email</label>
                    <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="type">Type</label>
                    <asp:TextBox ID="type" runat="server" CssClass="form-control" placeholder="Enter Email Type"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="body">Body</label>
                    <asp:TextBox ID="body" TextMode="MultiLine" runat="server" CssClass="form-control" placeholder="Enter message"></asp:TextBox>
                </div>
                <asp:Button ID="btnSend" runat="server" Text="SEND" CssClass="btn btn-primary"/>
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
                                    <th> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="KingsmanProjects.aspx" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                </tr>
                                <!-- Add other rows as needed -->
                                <tr>
                                    <td class="txt-oflo text-black">Tim Jacob</td>
                                    <td class="text-black">VR Courtroom</td>
                                    <td class="text-black">222800393</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="KingsmanProjects.aspx" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                    </tr>
                                <tr>
                                    <td class="txt-oflo text-black">Jerry Martha</td>
                                    <td class="text-black">Mini Banking App</td>
                                    <td class="text-black">224892921</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="KingsmanProjects.aspx" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                </tr>
                                <tr>
                                    <td class="txt-oflo text-black">Carol Nyathi</td>
                                    <td class="text-black">Fish Feeding 3D</td>
                                    <td class="text-black">224322254</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="KingsmanProjects.aspx" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                          
                                </tr>
                                <tr>
                                    <td class="txt-oflo text-black">Majola Wendy</td>
                                    <td class="text-black">Fish Feeding 3D</td>
                                    <td class="text-black">223893937</td>
                                    <td class="text-black"> student@uj.ac.za </td>
                                    <th> <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="KingsmanProjects.aspx" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                </tr>
                                    <tr>
                                        <td class="txt-oflo text-black"> Wendy Prudence</td>
                                        <td class="text-black">Mini Banking App</td>
                                        <td class="text-black">224008006</td>
                                        <td class="text-black"> student@uj.ac.za </td>
                                        <th> <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="KingsmanProjects.aspx" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                    </tr>
                                    <tr>
                                        <td class="txt-oflo text-black"> Logan Rooney</td>
                                        <td class="text-black">VR Courtroom</td>
                                        <td class="text-black">224030033</td>
                                        <td class="text-black"> student@uj.ac.za </td>
                                        <th> <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="KingsmanProjects.aspx" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                    </tr>
                                    <tr>
                                        <td class="txt-oflo text-black"> Mbali Ndlovu</td>
                                        <td class="text-black">VR Courtroom</td>
                                        <td class="text-black">223923224</td>
                                        <td class="text-black"> student@uj.ac.za </td>
                                        <th> <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="KingsmanProjects.aspx" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                    </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

 </div>

</asp:Content>
