<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="NewSubmissionLink.aspx.vb" Inherits="LMSApp.NewSubmissionLink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Create Submission Link
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
    <div>
        <div class="form-group">
            <label for="submissionTitle">Submission Title:</label>
            <input type="text" runat="server" class="form-control" id="submissionTitle" name="submissionTitle" placeholder="Enter submission title">
        </div>

        <div class="form-group">
            <label for="submissionText">Submission Text:</label>
            <input type="text" runat="server" class="form-control" id="submissionText" name="submissionText" placeholder="Enter submission Text">
        </div>

        <div class="form-row">
            <div class="col">
                <label for="openDateTime">Open Date and Time:</label>
                <input type="datetime-local" runat="server" class="form-control" id="openDateTime" name="openDateTime">
            </div>
            <div class="col">
                <label for="closeDateTime">Close Date and Time:</label>
                <input type="datetime-local" runat="server" class="form-control" id="closeDateTime" name="closeDateTime">
            </div>
        </div>
        <div class="form-group">
            <label for="newSubmissionFile">New Submission File:</label>
            <asp:FileUpload ID="newSubmissionFile" runat="server" CssClass="form-control-file" />
        </div>

        <div class="mt-4">
        </div>
        <asp:Button ID="btnAddNewSubmission" runat="server" type="button" class="btn btn-success mt-4" OnClick="AddNewSubmissionLink" Text="Add Submission Link" />
    </div>
</div>
</asp:Content>
