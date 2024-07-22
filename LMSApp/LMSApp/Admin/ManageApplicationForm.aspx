﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="ManageApplicationForm.aspx.vb" Inherits="LMSApp.ManageApplicationForm" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Manage Application form
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Manage Application form
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
     <div class="d-flex flex-wrap">
        <div class="card m-0 mb-3 col-4 h-100" style="min-width:40vh; margin-right:1vh">
            <div id="addquestionForm" class="card-body">
                <div class="form-end form-group mb-4">
                    <label class="col-md-12 p-0 pb-2 fw-bold w-100">Create a Question</label>
                    <div class="form-group p-2 mb-4" style="background-color:#f0f8ff">
                        <asp:RadioButtonList ID="questionTypeList" runat="server" class="col-md-12 p-0" AutoPostBack="True" OnSelectedIndexChanged="questionTypeList_SelectedIndexChanged">
                            <asp:ListItem Text="Text" Selected Value="text"></asp:ListItem>
                            <asp:ListItem Text="Radio" Value="radio"></asp:ListItem>
                            <asp:ListItem Text="Checkbox" Value="checkbox"></asp:ListItem>
                            <asp:ListItem Text="Long Text" Value="textarea"></asp:ListItem>
                            <asp:ListItem Text="Droplist" Value="dropList"></asp:ListItem>
                            <asp:ListItem Text="Number" Value="number"></asp:ListItem>
                        </asp:RadioButtonList>
                        
                        <asp:Panel ID="pnlAdditionalOptions" runat="server" CssClass="border-top border-bottom col-md-12 p-0 pt-2 pb-2" Visible="False">
                            <asp:TextBox ID="txtOption" runat="server" CssClass="form-control p-0 border-0" Placeholder="Type option here..."></asp:TextBox>
                            <asp:Button ID="btnAddOption" runat="server" OnClick="AddOption_Click" CssClass="btn btn-primary mb-2" Text="Add Option" />
                            <asp:PlaceHolder ID="phOptions" runat="server"></asp:PlaceHolder>
                        </asp:Panel>

                        <div class="col-md-12 border-bottom p-0">
                            <input id="inputQuestionNum" runat="server" type="number" placeholder="Question number" class="form-control p-0 border-0">
                            <p class="small text-muted mt-0 mb-2 ml-2">Optional</p>
                            <input id="inputQuestionText" runat="server" type="text" placeholder="Type Question text here..." class="form-control p-0 border-0">
                            <asp:Button ID="addQuestionButton" runat="server" OnClick="AddQuestionButton_Click" type="button" class="btn mb-2 btn-primary" style="background-color:#3e3d75" Text="Add Question" />
                        </div>

                       
                    </div>
                    <div class="col-sm-12">
                        <button class="btn btn-orange">Update Application Form</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-1"></div>
        <div class="card col-7" style="min-width:50vh">
            <div class="card-body">
                <div class="form-horizontal form-material">
                    <div id="CreatedQuestions"  runat="server" class="mb-4 border-bottom">
                        <h4 class="mb-4 fw-bold ">Application Form</h4>
                
           
                    </div> 
                </div>
            </div>
        </div>

            <asp:Panel ID="confirmationBox" CssClass="confirmation-box" runat="server" Visible="false">
                <asp:HiddenField ID="hdnQuestionId" runat="server" />
                <asp:HiddenField ID="hdnConfirmDelete" runat="server" />
            <h3 class="p-1">Confirm</h3>
            <p>Are you sure you want to delete this question?</p>
            <p style="font-size:0.7rem">
                <span>
                    <i class="fas fa-exclamation-triangle" style="font-size: 0.7rem;"></i>
                </span>
                This option will delete the question and all student answers related to the question from the records.
            </p>
            <asp:Button ID="btnConfirmYes" runat="server" Text="Yes" OnClick="ConfirmDelete" />
            <asp:Button ID="btnConfirmNo" runat="server" Text="No" OnClick="CancelDelete" />
            </asp:Panel>



    </div>
</asp:Content>
