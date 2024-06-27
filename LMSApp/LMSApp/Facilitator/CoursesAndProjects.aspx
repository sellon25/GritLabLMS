<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="CoursesAndProjects.aspx.vb" Inherits="LMSApp.CoursesAndProjects" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Courses And Projects
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-12 white-box">
            <div class="card p-0">
                <div class="card-body">
                    <h3 class="box-title mb-0">Courses</h3>
                </div>
                <div style="overflow-y: scroll; height: 250px;">
                    <div class="row courses-container" style="width: 95%">
                        <div id="CoursesContainer" runat="server" class="col-md-3"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12 white-box">
            <div class="card p-0">
                <div class="card-body">
                    <h3 class="box-title mb-0">Projects</h3>
                </div>
                <div style="overflow-y: scroll; height: 250px;">
                    <div class="row courses-container" style="width: 95%">
                        <div id="ProjectsContainer" runat="server"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
