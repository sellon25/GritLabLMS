<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="addkingsmen.aspx.vb" Inherits="LMSApp.addkingsmen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    ADD EMPLOYEE
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="card">
        <div class="card-body">
            <form class="form-horizontal form-material">
            
                <div class="form-group mb-4">
                    <label for="example-email" class="col-md-12 p-0">Email</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="email" placeholder="Type here..." class="form-control p-0 border-0" name="example-email" id="example-email">
                    </div>
                </div>
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">Name and Surname</label>
               
                    <div class="col-md-12 border-bottom p-0">
                        <input type="email" placeholder="Type here..." class="form-control p-0 border-0" name="example-email" id="name_surname">
                    </div>
                </div>
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">GL-CODE</label>
   
                    <div class="col-md-12 border-bottom p-0">
                        <input type="email" placeholder="Type here..." class="form-control p-0 border-0" name="example-email" id="GL-Code">
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
                <div class="form-group mb-4">
                    <div class="col-sm-12">
                        <button class="btn btn-orange">Submit</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
