<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="ManageAdmins.aspx.vb" Inherits="LMSApp.ManageAdmins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Manage Admins
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Admins
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">

 <form id="form1" runat="server">
        <br />
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Admin Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100" src="Manager%20Files/imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>ID Number</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ID" MaxLength="10"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-secondary mr-1 btn-outline-dark" ID="btn_Go" runat="server">Go</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Full Name"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <!DOCTYPE html>
                        <html>
                            <head>
                                <title>Country Code Selector</title>
                            </head>
                            <body>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Surname</label>
                                            <div class="input-group">
                                                <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" MaxLength="20" placeholder="Surname"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Date Of Birth</label>
                                            <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Date Of Birth" TextMode="Date" type="date" max="2006-12-31" oninput="checkYear(this)"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-md-4">
                                        <div class="form-group">
                                            <label>Email ID</label>
                                            <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Email ID"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <script>
                                    // Function to remove non-numeric characters from input
                                    function validateNumericInput(input) {
                                        input.value = input.value.replace(/[^0-9]/g, '');
                                    }
                                </script>
                            </body>
                        </html>

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Country</label>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="South Africa" Value="South Africa" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Contact No</label>
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Contact No" pattern="[0-9]*" oninput="validateNumericInput(this)" MaxLength="12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Gender</label>
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Male" Value="Male" />
                                        <asp:ListItem Text="Female" Value="Female" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4 mx-auto">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-secondary btn-block btn-outline-dark text-white" ID="DeleteButton" OnClick="DeleteButton_Click" runat="server" Text="Remove" />
                                </div>
                            </div>
                            <div class="col-4 mx-auto">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-secondary btn-block btn-outline-dark text-white" ID="btn_update" runat="server" Text="Update" />
                                </div>
                            </div>
                            <div class="col-4 mx-auto">
                                <div class="form-group">
                                    <asp:Button CssClass="btn btn-secondary btn-block btn-outline-dark text-white" ID="btn_AddNewAdmin" runat="server" Text="Add" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
            </div>

                <script>
                    function resetFilter() {
                        document.getElementById('txtSearch').value = '';
                        applyFilter();
                    }
                </script>

                <div class="col-md-8">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <center>
                                        <h3> Admins List </h3>
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
                                            <th class="border-top-0" style="font-weight: bold;">Faculty</th>
                                            <th class="border-top-0" style="font-weight: bold;">Student Number</th>
                                            <th class="border-top-0" style="font-weight: bold;">Email</th>
                                            <th class="border-top-0" style="font-weight: bold;">Track Progress</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="txt-oflo text-black">Manqoba Siyabonga</td>
                                            <td class="text-black">Faculty of Science</td>
                                            <td class="text-black">222800393</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                            <th> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                        </tr>
                                        <!-- Add other rows as needed -->
                                        <tr>
                                            <td class="txt-oflo text-black">Tim Jacob</td>
                                            <td class="text-black">Faculty of Humanities</td>
                                            <td class="text-black">222800393</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                            <th> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                         </tr>
                                        <tr>
                                            <td class="txt-oflo text-black">Jerry Martha</td>
                                            <td class="text-black">Faculty of College of Business and Economics</td>
                                            <td class="text-black">224892921</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                            <th> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                        </tr>
                                        <tr>
                                            <td class="txt-oflo text-black">Carol Nyathi</td>
                                            <td class="text-black"> Faculty of Art, Design and Architecture</td>
                                            <td class="text-black">224322254</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                            <th> <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                          
                                        </tr>
                                        <tr>
                                            <td class="txt-oflo text-black">Majola Wendy</td>
                                            <td class="text-black">Faculty of Engineering & the Built Environment</td>
                                            <td class="text-black">223893937</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                            <th> <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                        </tr>
                                         <tr>
                                             <td class="txt-oflo text-black"> Wendy Prudence</td>
                                             <td class="text-black">Faculty of Health Sciences</td>
                                             <td class="text-black">224008006</td>
                                             <td class="text-black"> student@uj.ac.za </td>
                                             <th> <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                         </tr>
                                         <tr>
                                             <td class="txt-oflo text-black"> Logan Rooney</td>
                                             <td class="text-black">Faculty of Education</td>
                                             <td class="text-black">224030033</td>
                                             <td class="text-black"> student@uj.ac.za </td>
                                             <th> <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>

                                         </tr>
                                         <tr>
                                             <td class="txt-oflo text-black"> Mbali Ndlovu</td>
                                             <td class="text-black">Faculty of Law</td>
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
        </div>
    </form>
</asp:Content>
