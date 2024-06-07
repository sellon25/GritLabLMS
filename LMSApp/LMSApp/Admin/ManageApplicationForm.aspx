<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="ManageApplicationForm.aspx.vb" Inherits="LMSApp.ManageApplicationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Manage Application form
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Application form
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="d-flex flex-wrap">
    <div class="card m-0 mb-3 col-4 h-100" style="min-width:40vh; margin-right:1vh">
        <div class="card-body">
             <div class="form-end form-group mb-4">
                 <label class="col-md-12 p-0 pb-2 fw-bold w-100">Create a Question</label>
                  <div class="form-group p-2 mb-4" style="background-color:#f0f8ff">                    
                   
                    <div class="col-md-12 p-0">
                        <input type="radio" id="radiox" name="radio" value="radio">
                        <label for="radiox"> Radio </label><br>
                        <input type="radio" id="checkbox" name="checkbox" value="checkbox">
                        <label for="checkbox"> Checkbox </label><br>
                        <input type="radio" id="textx" name="textx" value="text">
                        <label for="gamedev">Text</label><br>
                        <input type="radio" id="longtextx" name="longtextx" value="textarea">
                        <label for="gamedev"> Long Text</label><br>
                        <input type="radio" id="dropList" name="dropList" value="dropList">
                        <label for="gamedev">Droplist</label><br>
                        <input type="radio" id="numberx" name="numberx" value="number">
                        <label for="gamedev">Number</label><br>
                        <!--<input type="radio" id="Alcohols" name="fav_language" value="Alcohols">
                        <label for="Alcohols">Alcohols</label> -->                                           
                    </div>
                             
                    <div class="col-md-12  border-bottom p-0">
                        <input type="text" required placeholder="Type Question text here..." class="form-control p-0 border-0">
                        <button type="button"  class="btn mb-2 btn-primary" style="background-color:#3e3d75">Add Question</button>
                    </div>
                    
                  </div>
                    <div class="col-sm-12">
                        <button class="btn btn-orange">Submit</button>
                    </div>
                </div>
           </div>
       </div>
    <div class="col-1"></div>
    <div class="card col-7" style="min-width:50vh">
            <div class="card-body">
                <form class="form-horizontal form-material">
                <div id="CreatedQuestions" class="mb-4 border-bottom">
                    <h4 class="mb-4 fw-bold ">Application Form</h4>
                
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
                
                </div>            
                
               
               
            </form>
        </div>
    </div>

    </div>
</asp:Content>
