<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="ProjectPage.aspx.vb" Inherits="LMSApp.ProjectPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    ELMS
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="row" style="padding-top:10px;">
                    <a class="col-md-12 text-black" href="Announcements.aspx">
                        <div class="white-box boxShadow">
                            <h3 class="box-title" >Anouncements</h3>
                        </div> 
                    </a>

                    <a class="col-md-12 text-black" href="Tests.aspx">
                        <div class="white-box boxShadow">
                            <h3 class="box-title">Progress and Feedback</h3>
                        </div>
                    </a>
                    <a class="col-md-12 text-black" href="CourseContent.aspx">
                        <div class="white-box boxShadow">
                            <h3 class="box-title">Project Participants</h3>
                        </div>
                    </a>
                    

                </div>
</asp:Content>
