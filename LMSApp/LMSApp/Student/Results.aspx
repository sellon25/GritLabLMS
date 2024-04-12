<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoard.Master" CodeBehind="Results.aspx.vb" Inherits="LMSApp.Results" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Results 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Results
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    
                   <a class="col-md-12 text-black" href="CourseResults.aspx">
                        <div class="box-flex white-box boxShadow">
                            <h3 class="box-title">CHEM1101</h3>
                             <div class="description">
                             <span class="box-result results-good">82<span>/100</span></span>               
                            </div>
                        </div>
                    </a>
                     <a class="col-md-12 text-black" href="CourseResults.aspx">
                        <div class="box-flex white-box boxShadow">
                            <h3 class="box-title">FSA2109</h3>
                             <div class="description">
                             <span class="box-result results-good">78<span>/100</span></span>               
                            </div>
                        </div>
                    </a><a class="col-md-12 text-black" href="CourseResults.aspx">
                        <div class="box-flex white-box boxShadow">
                            <h3 class="box-title">CSC2101</h3>
                             <div class="description">
                             <span class="box-result results-warning">52<span>/100</span></span>               
                            </div>
                        </div>
                    </a><a class="col-md-12 text-black" href="CourseResults.aspx">
                        <div class="box-flex white-box boxShadow">
                            <h3 class="box-title">CALC121</h3>
                             <div class="description">
                             <span class="box-result results-bad">23<span>/100</span></span>               
                            </div>
                        </div>
                    </a>
                    
                
</asp:Content>
