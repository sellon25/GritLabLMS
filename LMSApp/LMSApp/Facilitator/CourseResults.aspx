<%@ Page Title="Course Results" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="CourseResults.aspx.vb" Inherits="LMSApp.CourseResults1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Course Results
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Course Results
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
        <h2>Course Assessment Results</h2>
        <table class="table table-bordered">
            <thead>
                <tr>
                    <th>Student Number</th>
                    <th>Assessment 1</th>
                    <th>Assessment 2</th>
                    <th>Assessment 3</th>
                    <!-- Add more assessments as needed -->
                    <th>Total</th>
                    <th>Average</th>
                </tr>
            </thead>
            <tbody>
                <%-- Sample Data --%>
                <tr>
                    <td>JBS-GL101</td>
                    <td>85</td>
                    <td>90</td>
                    <td>88</td>
                    <!-- Add more assessments scores as needed -->
                    <td>263</td>
                    <td>87.67</td>
                </tr>

                <tr>
                    <td>JBS-GL102</td>
                    <td>85</td>
                    <td>90</td>
                    <td>88</td>
                    <!-- Add more assessments scores as needed -->
                    <td>263</td>
                    <td>87.67</td>
                </tr>
                <%-- Repeat for each student --%>
            </tbody>
            <tfoot>
                <tr>
                    <th>Average Score</th>
                    <th>88.5</th>
                    <th>85.0</th>
                    <th>90.2</th>
                    <!-- Add more assessments averages as needed -->
                    <th></th>
                    <th>87.9</th>
                </tr>
            </tfoot>
        </table>
    </div>
</asp:Content>
