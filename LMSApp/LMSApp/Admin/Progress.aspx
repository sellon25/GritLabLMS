<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="Progress.aspx.vb" Inherits="LMSApp.Progress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    <a class="col-md-12 text-black" href="CourseResults.aspx">
                <div class="box-flex white-box boxShadow">
                    <h3 class="box-title">GL-887
                    </h3>
                        <div class="description">
                        <span class="box-result results-good">82<span>/100</span></span>               
                    </div>
                </div>
            </a>
                <a class="col-md-12 text-black" href="#">
                <div class="box-flex white-box boxShadow">
                    <h3 class="box-title">GL-635</h3>
                        <div class="description">
                        <span class="box-result results-good">78<span>/100</span></span>               
                    </div>
                </div>
            </a><a class="col-md-12 text-black">
                <div class="box-flex white-box boxShadow">
                    <h3 class="box-title">GL-535</h3>
                        <div class="description">
                        <span class="box-result results-warning">52<span>/100</span></span>               
                    </div>
                </div>
            </a><a class="col-md-12 text-black">
                <div class="box-flex white-box boxShadow">
                    <h3 class="box-title">GL-735</h3>
                        <div class="description">
                        <span class="box-result results-bad">23<span>/100</span></span>               
                    </div>
                </div>
            </a>
</asp:Content>
