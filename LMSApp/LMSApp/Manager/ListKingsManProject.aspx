<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardManager.Master" CodeBehind="ListKingsManProject.aspx.vb" Inherits="LMSApp.ListKingsManProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">

    Kingsman List

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">

    Kingsman List

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server"><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../Manager/KingsmanProjects.aspx" Text="Back" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink>


    <center>

    <h1>Project Name</h1>

    </center>

    <div class="row">


    <div class="col-md-4">

<!-- Send Feedback Section -->
        <div class="white-box">
            <h3 class="box-title">Send Feedback</h3>
            <form>
                <div class="form-group">
                    <label for="feedbackEmail">Email</label>
                    <input type="email" class="form-control" id="feedbackEmail" placeholder="Enter your email">
                </div>
                <div class="form-group">
                    <label for="feedbackSubject">Subject</label>
                    <input type="text" class="form-control" id="feedbackSubject" placeholder="Enter subject">
                </div>
                <div class="form-group">
                    <label for="feedbackMessage">Message</label>
                    <textarea class="form-control" id="feedbackMessage" rows="3" placeholder="Enter your feedback"></textarea>
                </div>
                <button type="submit" class="btn btn-primary" style="background-color:#000000">Send Feedback</button>
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
                            <th class="border-top-0" style="font-weight: bold;">ID Number</th>
                            <th class="border-top-0" style="font-weight: bold;">Contact Number</th>
                            <th class="border-top-0" style="font-weight: bold;">Email</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="txt-oflo text-black">Manqoba Siyabonga</td>
                            <td class="text-black">222800393</td>
                            <td class="text-black">0685696542</td>
                            <td class="text-black"> student@uj.ac.za </td>
                        </tr>
                        <!-- Add other rows as needed -->
                        <tr>
                            <td class="txt-oflo text-black">Tim Jacob</td>
                            <td class="text-black">222800393</td>
                            <td class="text-black">0759654789</td>
                            <td class="text-black"> student@uj.ac.za </td>
                            </tr>
                        <tr>
                            <td class="txt-oflo text-black">Jerry Martha</td>
                            <td class="text-black">224892921</td>
                            <td class="text-black">0761545636</td>
                            <td class="text-black"> student@uj.ac.za </td>

                        </tr>
                        <tr>
                            <td class="txt-oflo text-black">Carol Nyathi</td>
                            <td class="text-black">224322254</td>
                            <td class="text-black">0654589641</td>
                            <td class="text-black"> student@uj.ac.za </td>
                  
                        </tr>
                        <tr>
                            <td class="txt-oflo text-black">Majola Wendy</td>
                            <td class="text-black">223893937</td>
                            <td class="text-black">0759636547</td>
                            <td class="text-black"> student@uj.ac.za </td>
                        </tr>
                            <tr>
                                <td class="txt-oflo text-black"> Wendy Prudence</td>
                                <td class="text-black">224008006</td>
                                <td class="text-black">0675963864</td>
                                <td class="text-black"> student@uj.ac.za </td>

                            </tr>
                            <tr>
                                <td class="txt-oflo text-black"> Logan Rooney</td>
                                <td class="text-black">224030033</td>
                                <td class="text-black">0761564596</td>
                                <td class="text-black"> student@uj.ac.za </td>

                            </tr>
                            <tr>
                                <td class="txt-oflo text-black"> Mbali Ndlovu</td>
                                <td class="text-black">223923224</td>
                                <td class="text-black">0636756389</td>
                                <td class="text-black"> student@uj.ac.za </td>

                            </tr>
                    </tbody>
                </table>
            </div>
        </div>
        </div>
        </div>
    </div> 


</asp:Content>
