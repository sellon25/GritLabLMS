<%@ Page Title="Course Content" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="CourseContent.aspx.vb" Inherits="LMSApp.CourseContent1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Course Content
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Course Content
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container-fluid mt-4">
        <div class="row">
            <!-- Left Column: Add New Content -->
            <div class="col-lg-4">
                <div class="mb-3">
                    <h4>Add New Content Item</h4>
                    <!-- Form to add new content item -->
                    <div id="newContentForm">
                        <div class="form-group">
                            <label for="newContentTitle">Title:</label>
                            <asp:TextBox ID="newContentTitle" runat="server" CssClass="form-control" placeholder="Title" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="newContentDescription">Description:</label>
                            <asp:TextBox ID="newContentDescription" runat="server" CssClass="form-control" placeholder="Description" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="newContentThumbnail">Thumbnail Image:</label>
                            <asp:FileUpload ID="newContentThumbnail" runat="server" CssClass="form-control-file" />
                        </div>
                        <div class="form-group">
                            <label for="newContentDocument">Upload Document:</label>
                            <asp:FileUpload ID="newContentDocument" runat="server" CssClass="form-control-file" Accept=".pdf,.doc,.docx" />
                        </div>
                        <asp:Button ID="btnAddContent" runat="server" Text="Add Content" CssClass="btn btn-primary mt-2" OnClick="btnAddContent_Click" />

                    </div>
                </div>
            </div>
            
            <!-- Right Column: Display Existing Content -->
            <div class="col-lg-8">
                <h4>Course Content Items</h4>
                <!-- List of existing content items -->
                <div class="list-group">
                    <!-- Example content item (replace with data binding from database) -->
                    <div id="ContentContainer" runat="server" ></div>
                    
                    <!-- Repeat the above structure for each content item from database -->
                </div>


                    



            </div>
        </div>
    </div>

    <style>
    .content-item {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 10px;
        margin-bottom: 10px;
    }

    .content-link {
        display: flex;
        align-items: center;
        text-decoration: none;
        color: inherit;
        flex-grow: 1;
    }

    .textboookarea {
        display: flex;
        align-items: center;
    }

    .content-thumbnail {
        width: 50px;
        height: 50px;
        margin-right: 10px;
    }

    .btn-danger {
        height: fit-content;
    }
</style>

</asp:Content>
