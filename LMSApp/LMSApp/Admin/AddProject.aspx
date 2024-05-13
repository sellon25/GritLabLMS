     <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="AddProject.aspx.vb" Inherits="LMSApp.AddProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    ADD PROJECTS
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="card">
        <div class="card-body">
            <form class="form-horizontal form-material">
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">Project Name</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="text" placeholder="Type here..." class="form-control p-0 border-0"> </div>
                </div>
                <div class="form-group mb-4">
                    <label for="example-email" class="col-md-12 p-0">Enter Team Leader</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="email" placeholder="Type here..." class="form-control p-0 border-0" name="example-email" id="example-email">
                    </div>
                </div>
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">Group Members</label>
                    <div class="col-md-12 border-bottom p-0">
                        
                        
                            <label><input type="radio" id="Member 1" name="M1" placeholder=Member 1">Member 1</label><br>
                            <label><input type="radio" id="Member 2" name="M2" placeholder="Member 2">Member 2</label><br>
                            <label><input type="radio" id="Member 3" name="M3" placeholder="Member 3">Member 3</label><br>
                            <!-- Add more answer choices as needed -->
                        
                    </div>
                   <button class="btn btn-primary" style="background-color:#3C1B50">Add Member</button>
                </div>
                <div class="form-group mb-4">
                    <label class="col-md-12 p-0">Type of Project Name</label>
                    <div class="col-md-12 border-bottom p-0">
                        <input type="radio" id="webdev" name="fav_language" value="WebDevelopment">
                        <label for="webdev"> Web Development </label><br>
                        <input type="radio" id="gamedev" name="" value="GameDevelopment">
                        <label for="gamedev"> Game Development </label><br>
                        <!--<input type="radio" id="Alcohols" name="fav_language" value="Alcohols">
                        <label for="Alcohols">Alcohols</label> -->                                           
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
