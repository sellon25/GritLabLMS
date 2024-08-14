<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Set_Announcements.aspx.vb" Inherits="LMSApp.Set_Announcements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
      <div class="card">
        <div class="card-body">
            <form class="form-horizontal form-material">
                <!--<div class="form-group mb-4">
                    <label class="col-md-12 p-0">What is covalent bond?</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="text" placeholder="Type here..." class="form-control p-0 border-0"> </div>
                </div>-->
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0"> Write Announcement </label>
                    <div class="col-md-12 border-bottom p-0">
                        <textarea rows="5" placeholder="Type here..." class="form-control p-0 border-0"></textarea>
                    </div>
                </div>
                <div class="form-float mb-4">
                    <label class="col-md-6 p-0">To:</label>
                    
                        <select class="form-select shadow-none row border-top">
                                <option>All</option>
                                <option>Students</option>
                                <option>Employee</option>
                                <!-- <option>Mega</option>
                                <option>In A Year</option>
                                <option>July 2023</option>-->
                        </select>       
                    
                </div>
                <!--<div class="form-group mb-4">
                    <label class="col-md-12 p-0">Define the term 'lipids'</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="text" placeholder="Type here..." class="form-control p-0 border-0">
                    </div>
                </div>
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">With your knowledge of chemical compounds, differentiate fully between Proteins and Nucleic acids. </label>
                    <div class="col-md-12 border-bottom p-0">
                        <textarea rows="5" placeholder="Type here..." class="form-control p-0 border-0"></textarea>
                    </div>
                </div>
                <div class="form-group mb-4">
                    <label class="col-sm-12">The law describes the inversely proportional relationship between the absolute pressure and volume of a gas, if the temperature is kept constant within a closed system was discovered by:</label>

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
                <div class="form-float mb-4">
                    <div class="col-sm-12">
                        <button class="btn btn-orange">Submit</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

