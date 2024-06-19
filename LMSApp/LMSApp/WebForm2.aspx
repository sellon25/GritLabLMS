<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="WebForm2.aspx.vb" Inherits="LMSApp.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
         <div class="form-group mb-4">
                        <i class="delete fas fa-trash-alt"></i>

                    <label class="col-md-12 p-0">Give us a small description about yourself, hobbies, values and aspirations</label>
                    <div class="col-md-12 border-bottom p-0">
                        <textarea cols="1" rows="4" type="text" placeholder="Type here..." class="form-control p-0 border-0"></textarea> 
                    </div>
                </div>
                <div class="form-group mb-4">
                     <i class="delete fas fa-trash-alt"></i>
                    <label class="col-md-12 p-0">What are most interested in?</label>
                    <div class="col-md-12 p-0">
                        <input type="radio" id="webdev" name="fav_language" value="WebDevelopment">
                        <label for="webdev"> Web Development </label><br>
                        <input type="radio" id="gamedev" name="" value="GameDevelopment">
                        <label for="gamedev"> Game Development </label><br>
                        <!--<input type="radio" id="Alcohols" name="fav_language" value="Alcohols">
                        <label for="Alcohols">Alcohols</label> -->                                           
                    </div>
                                       
                    <div class="col-md-12  border-bottom p-0">
                        <input type="text" required placeholder="Type here..." class="form-control p-0 border-0">
                        <button class="btn mb-2 btn-primary" style="background-color:#3C1B50">Add</button>
                    </div>
                    
                </div>
                <div class="form-group mb-4">
                        <i class="delete fas fa-trash-alt"></i>
                        <label class="col-md-12 p-0">Rate yourself out of 10 in the above selected skill</label>
                        <div class="col-md-12 border-bottom p-0">
                            <input type="number" min="0" max="10" required placeholder="Type here..." class="form-control p-0 border-0"> </div>
                </div>
                <div class="form-group mb-4">
                        <i class="delete fas fa-trash-alt"></i>
                    <label class="col-md-12 p-0">Give us a small description about yourself, hobbies, values and aspirations</label>
                    <div class="col-md-12 border-bottom p-0">
                        <textarea cols="1" rows="4" type="text" placeholder="Type here..." class="form-control p-0 border-0"></textarea> 
                    </div>
                </div>
                 <div class="form-group mb-4">
                        <i class="delete fas fa-trash-alt"></i>
                    <label class="col-sm-12">Choose a character</label>

                    <div class="col-sm-12 border-bottom">
                        <select class="form-select shadow-none p-0 border-0 form-control-line">
                            <option>Nerd</option>
                            <option>Soldier</option>
                            <option>Pilot</option>
                            <option>Clown</option>
                            <option>Supporter</option>
                        </select>
                    </div>
                     <div class="col-md-12  border-bottom p-0">
                        <input type="text" required placeholder="Type here..." class="form-control p-0 border-0">
                        <button class="btn mb-2 btn-primary" style="background-color:#3C1B50">Add</button>
                    </div>
                </div>
                
</asp:Content>
