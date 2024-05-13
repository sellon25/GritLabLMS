   <%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="setlab.aspx.vb" Inherits="LMSApp.setlab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="card">
    <div class="card-body">
        <form class="form-horizontal form-material">
            
            
            <div class="form-group mb-4">
                <label class="col-md-12 p-0">Question 1</label>
                <div class="col-md-12 border-bottom p-0">
                    
                    
                        <label><input type="radio" id="Q1-1" name="A1" placeholder=Answer 1">Answer 1</label><br>
                        <label><input type="radio" id="Q1-2" name="A2" placeholder="Answer 2">Answer 2</label><br>
                        -<label><input type="radio" id="Q1-3" name="A3" placeholder="Answer 3">Answer 3</label><br>
                        <!-- Add more answer choices as needed -->
                    
                </div>
            </div>
            <div class="form-group mb-4">
                <label class="col-md-12 p-0">Question 2</label>
                <div class="col-md-12 border-bottom p-0">
        
        
                        <label><input type="radio" id="Q2-1" name="A1" placeholder=Answer 1">Answer 1</label><br>
                        <label><input type="radio" id="Q2-2" name="A2" placeholder="Answer 2">Answer 2</label><br>
                        <label><input type="radio" id="Q2-3" name="A3" placeholder="Answer 3">Answer 3</label><br>
                        <!-- Add more answer choices as needed -->
        
                </div>
            </div>
            <div class="form-group mb-4">
                <label class="col-md-12 p-0">Question 3</label>
                <div class="col-md-12 border-bottom p-0">
        
        
                        <label><input type="radio" id="Q3-1" name="A1" placeholder=Answer 1">Answer 1</label><br>
                        <label><input type="radio" id="Q3-2" name="A2" placeholder="Answer 2">Answer 2</label><br>
                        <label><input type="radio" id="Q3-3" name="A3" placeholder="Answer 3">Answer 3</label><br>
                        <!-- Add more answer choices as needed -->
        
                </div>
            </div>
            <div class="form-group mb-4">
    <label class="col-md-12 p-0">Question 4</label>
    <div class="col-md-12 border-bottom p-0">
        
        
            <label><input type="radio" id="Q4-1" name="A1" placeholder=Answer 1">Answer 1</label><br>
            <label><input type="radio" id="Q4-2" name="A2" placeholder="Answer 2">Answer 2</label><br>
            <label><input type="radio" id="Q4-3" name="A3" placeholder="Answer 3">Answer 3</label><br>
            <!-- Add more answer choices as needed -->
        
    </div>
</div>
            <div class="form-group mb-4">
    <label class="col-md-12 p-0">Question 4</label>
    <div class="col-md-12 border-bottom p-0">
        
        
            <label><input type="radio" id="Answer 1" name="Q1" placeholder=Answer 1">Answer 1</label><br>
            <label><input type="radio" id="Answer 2" name="Q2" placeholder="Answer 2">Answer 2</label><br>
            <label><input type="radio" id="Answer 3" name="Q3" placeholder="Answer 3">Answer 3</label><br>
            <!-- Add more answer choices as needed -->
        
    </div>
</div>
            <div class="form-group mb-4">
    <label class="col-md-12 p-0">Question 1</label>
    <div class="col-md-12 border-bottom p-0">
        
        
            <label><input type="radio" id="Answer 1" name="Q1" placeholder=Answer 1">Answer 1</label><br>
            <label><input type="radio" id="Answer 2" name="Q2" placeholder="Answer 2">Answer 2</label><br>
            <label><input type="radio" id="Answer 3" name="Q3" placeholder="Answer 3">Answer 3</label><br>
            <!-- Add more answer choices as needed -->
        
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
