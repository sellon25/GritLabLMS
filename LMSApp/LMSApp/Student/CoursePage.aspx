<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoard.Master" CodeBehind="CoursePage.aspx.vb" Inherits="LMSApp.CoursePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Course
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
  Introduction to Chemistry 1101
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
                            <h3 class="box-title">Tests and Assessments</h3>
                        </div>
                    </a>
                    <a class="col-md-12 text-black" href="CourseContent.aspx">
                        <div class="white-box boxShadow">
                            <h3 class="box-title">Course content</h3>
                        </div>
                    </a>
                    <a class="col-md-12 text-black" href="SubmisssionLinks.aspx">
                        <div class="white-box boxShadow">
                            <h3 class="box-title">Submission links</h3>
                        </div>
                    </a>
                      <a class="col-md-12 text-black" href="CourseResults.aspx">
                        <div class="white-box boxShadow">
                            <h3 class="box-title">Results</h3>
                        </div>
                    </a>

                </div>
</asp:Content>
