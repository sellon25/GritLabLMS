<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="ManageUsers.aspx.vb" Inherits="LMSApp.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    ADD GRITER TO Project
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row">
        <div class ="col-md-3">
                <div class="card">
                    <div class="card-body">
                        <form class="form-horizontal form-material">
                             <div class="form-group mb-4">
                                 <div>SQUID GAME / MINI-BANKING APP</div>
                             </div>
                            <div class="form-group mb-4">
                                <label for="example-email" class="col-md-12 p-0">Email</label>
                                <div class="col-md-12 border-bottom p-0">
                                    <input type="email" placeholder="Type here..." class="form-control p-0 border-0" name="example-email" id="example-email">
                                </div>
                            </div>
                            <div class="form-group mb-4">
                                <label class="col-md-12 p-0">GL-CODE</label>
   
                                <div class="col-md-12 border-bottom p-0">
                                    <input type="email" placeholder="Type here..." class="form-control p-0 border-0" name="example-email" id="GL-Code">
                                </div>
                            </div>
                            <div class="form-group mb-4">
                                <div class="col-sm-12">
                                    <button class="btn btn-orange">Submit</button>
                                </div>
                            </div>
                           <!-- <div class="form-group mb-4">
                                <label class="col-md-12 p-0"></label>
                                <div class="col-md-12 border-bottom p-0">
                                    <input type="text" placeholder="Type here..." class="form-control p-0 border-0">
                                </div>
                            </div>
                            <div class="form-group mb-4">
                                <label class="col-md-12 p-0"> </label>
                                <div class="col-md-12 border-bottom p-0">
                                    <textarea rows="5" placeholder="Type here..." class="form-control p-0 border-0"></textarea>
                                </div>
                            </div>-->
                            <!--<div class="form-group mb-4">
                                <label class="col-sm-12"></label>

                                <div class="col-sm-12 border-bottom">
                                    <select class="form-select shadow-none p-0 border-0 form-control-line">
                                        <option>Robert Boyle</option>
                                        <option>Georg Stahl</option>
                                        <option>Antoine Lavoisier</option>
                                        <option>John Dalton</option>
                                        <option>Carl Wilhelm Scheele</option>
                                    </select>
                                </div>
                            </div>-->
                            
                        </form>

                    </div>

                </div>

        </div>
        <div class="col-md-8">
            <div class="white-box">
                <div class="card p-0">
                    <div class="card-body">
                        <h3 class="box-title mb-0">Top Achievers For Grit-lab YEAR</h3>
                    </div>
                    <div class="row">
                    <div class="col-md-12 col-lg-12 col-sm-12">
                        <div class="white-box bg-transparent">
    
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label for="txtSearch">Search:</label>
                                <input type="text" id="txtSearch" class="form-control" placeholder="Enter" onselect="applyFilter()">
                            </div>
                            <div class="col-md-4">
                                <label for="ddlFilter">Filter by:</label>
                                <select id="ddlFilter" class="form-control" onselect="applyFilter()">
                                    
                                    <option value="SN">Student Number</option>
                                    <option value="GL">GL-CODE</option>
                                    <option value="GL">Ave Lab</option>

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
                                            <th class="border-top-0" style="font-weight: bold;">GL-CODE</th>
                                            <th class="border-top-0" style="font-weight: bold;">Average</th>
                                            <th class="border-top-0" style="font-weight: bold;">Student Number</th>
                                            <th class="border-top-0" style="font-weight: bold;">Email</th>
                                            <!--<th class="border-top-0" style="font-weight: bold;"></th>-->
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="txt-oflo text-black">678</td>
                                            <td class="text-black">90</td>
                                            <td class="text-black">222800393</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                            <!--<th> <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>-->
                                        </tr>
                                        <tr>
                                            <td class="txt-oflo text-black">899</td>
                                            <td class="text-black">88</td>
                                            <td class="text-black">222900434</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                           <!-- <th> <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="#" Text="Track Progress" CssClass="breadcrumb-link" Font-Bold="True"></asp:HyperLink></th>
                                       --> </tr>
                                        <tr>
                                            <td class="txt-oflo text-black">764</td>
                                            <td class="text-black">92</td>
                                            <td class="text-black">224892921</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                        </tr>
                                        <tr>
                                            <td class="txt-oflo text-black">900</td>
                                            <td class="text-black">85</td>
                                            <td class="text-black">224322254</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                        </tr>
                                        <tr>
                                            <td class="txt-oflo text-black">833</td>
                                            <td class="text-black">79</td>
                                            <td class="text-black">223893937</td>
                                            <td class="text-black"> student@uj.ac.za </td>
                                        </tr>
                                         <tr>
                   
                                             <td class="txt-oflo text-black"> 645</td>
                                             <td class="text-black">86</td>
                                             <td class="text-black">224008006</td>
                                             <td class="text-black"> student@uj.ac.za </td>
                                         </tr>
                                         <tr>
                                             <td class="txt-oflo text-black"> 876</td>
                                             <td class="text-black">87</td>
                                             <td class="text-black">224333439</td>
                                             <td class="text-black"> student@uj.ac.za </td>
                                         </tr>
                                         <tr>
                                             <td class="txt-oflo text-black"> 978</td>
                                             <td class="text-black">96</td>
                                             <td class="text-black">223923224</td>
                                             <td class="text-black"> student@uj.ac.za </td>
                                         </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
