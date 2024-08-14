<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="kingsmenmanagement.aspx.vb" Inherits="LMSApp.kingsmenmanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    EMPLOYEE MANAGEMENT
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <script>
    function resetFilter() {
        document.getElementById('txtSearch').value = '';
        applyFilter();
    }
</script>

<div class="row">
    <div class="col-md-12 col-lg-12 col-sm-12">
        <div class="white-box bg-transparent">
            <div class="d-md-flex mb-3">
                <h3 class="box-title mb-0">EMPLOYEE TRACKER</h3>
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
                    <option value="id">Email</option>
                    <option value="dob">Project</option>
                </select>
            </div>
            <div class="col-md-4">
                <label>&nbsp;</label><br>
                <button type="button" class="btn btn-primary" onclick="applyFilter()">Apply Filter</button>
                <button type="button" class="btn btn-secondary" onclick="resetFilter()">Reset</button>
            </div>
        </div>
            <%--<div class="table-responsive">--%>
                <table class="table no-wrap">
                    <thead>
                        <tr>
                            
                            <th class="border-top-0" style="font-weight: bold;">Project Leader</th>
                            <th class="border-top-0" style="font-weight: bold;">Project Name</th>
                            <th class="border-top-0" style="font-weight:bold;">Email</th>
                            <th class="border-top-0" style="font-weight:bold;">Status</th>
                            <th class="border-top-0" style="font-weight: bold;">Track Progress</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            
                            <td class="txt-oflo text-black"> Manqoba Siyabonga </td>
                            <td class="text-black"> VR COURT ROOM </td>
                            <td class="text-black"> student@uj.ac.za </td>
                            <td class="text-warning"> Assigned </td>
                            <th> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                        
                        </tr>
                        <tr>
                            
                            <td class="txt-oflo text-black">Tim Jacob</td>
                            <td class="text-black">Teaching Evalution</td>
                            
                            <td class="text-black"> student@uj.ac.za </td>
                            <td class="text-warning"> Assigned </td>
                            <th> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                        </tr>
                        <tr>
                            
                            <td class="txt-oflo text-black">Jerry Martha</td>
                            <td class="text-black">CHATBot</td>
                            
                            <td class="text-black"> student@uj.ac.za </td>
                            <td class="text-success"> Completed </td>
                             <th> <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                        </tr>
                        <tr>
                           
                            <td class="txt-oflo text-black">Carol Nyathi</td>
                            <td class="text-black">SANTA GAME</td>
                            <td class="text-black"> student@uj.ac.za </td>
                            <td class="text-success"> Completed </td>
                             <th> <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                        </tr>
                        <tr>
                           
                            <td class="txt-oflo text-black">Majola Wendy</td>
                            <td class="text-black">Fish-Feeding</td>
                            <td class="text-black"> student@uj.ac.za </td>
                            <td class="text-warning"> Assigned </td>
                             <th> <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                        </tr>
                         <tr>
                             
                             <td class="txt-oflo text-black"> Wendy Prudence</td>
                             <td class="text-black">SACNASP</td>
                            
                             <td class="text-black"> student@uj.ac.za </td>
                             <td class="text-danger"> Pending </td>
                              <th> <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                         </tr>
                         <tr>
                       
                             <td class="txt-oflo text-black"> Logan Rooney</td>
                             <td class="text-black">FOOD APP</td>
                             
                             <td class="text-black"> student@uj.ac.za </td>
                             <td class="text-warning"> Assigned </td>
                              <th> <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                         </tr>
                         <tr>
                           
                             <td class="txt-oflo text-black"> Mbali Ndlovu</td>
                             <td class="text-black">SSME</td>
                             
                             <td class="text-black"> student@uj.ac.za </td>
                             <td class="text-danger"> Pending </td>
                              <th> <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                         </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
