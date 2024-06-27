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
            <label for="assessmentName">Submission Title:</label>
            <input type="text" class="form-control" id="submissionTitle" name="submissionTitle" placeholder="Enter submission title">
        </div>
        <div class="form-row">
            <div class="col">
                <label for="openDateTime">Open Date and Time:</label>
                <input type="datetime-local" class="form-control" id="openDateTime" name="openDateTime">
            </div>
            <div class="col">
                <label for="closeDateTime">Close Date and Time:</label>
                <input type="datetime-local" class="form-control" id="closeDateTime" name="closeDateTime">
            </div>
        </div>
        <div class="mt-4">
        </div>
        <button type="submit" class="btn btn-success mt-4" onclick="AddNewSubmissionLink" runat="server">Add Submission Link</button>
    </div>
</div>
</asp:Content>
