<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardFacilitator.Master" CodeBehind="AssessmentStudentList.aspx.vb" Inherits="LMSApp.AssessmentStudentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Assessment Student List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h4 class="card-title">Student Assessments</h4>
                    </div>
                    <div class="card-body">
                        <table class="table table-bordered">
                            <thead>
                                <tr>
                                    <th>Student Number</th>
                                    <th>Marks</th>
                                    <th>Status</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                               
                                <tr>
                                    <td>JBS-GL101</td>
                                    <td>85</td>
                                    <td>Marked</td>
                                    <td><button class="btn btn-primary" onclick="location.href='MarkAssessment.aspx'">Mark Assessment</button></td>
                                </tr>
                                <tr>
                                    <td>JBS-GL102</td>
                                    <td>-</td>
                                    <td>-</td>
                                    <td><button class="btn btn-primary" onclick="location.href='MarkAssessment.aspx'">Mark Assessment</button></td>
                                </tr>
                                <tr>
                                    <td>JBS-GL103</td>
                                    <td>-</td>
                                    <td>-</td>
                                    <td><button class="btn btn-primary" onclick="location.href='MarkAssessment.aspx'">Mark Assessment</button></td>
                                </tr>
                                <tr>
                                    <td>JBS-GL104</td>
                                    <td>92</td>
                                    <td>Marked</td>
                                    <td><button class="btn btn-primary" onclick="location.href='MarkAssessment.aspx'">Mark Assessment</button></td>
                                </tr>
                                <tr>
                                    <td>JBS-GL105</td>
                                    <td>-</td>
                                    <td>-</td>
                                    <td><button class="btn btn-primary" onclick="location.href='MarkAssessment.aspx'">Mark Assessment</button></td>
                                </tr>
                                
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
