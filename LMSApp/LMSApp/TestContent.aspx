<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoard.Master" CodeBehind="TestContent.aspx.vb" Inherits="LMSApp.TestContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
    Test 1
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Take Test : Test 1
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
  <div class="card">
                            <div class="card-body">
                                <form class="form-horizontal form-material">
                                    <div class="form-group mb-4">
                                        <label class="col-md-12 p-0">What is covalent bond?</label>
                                        <div class="col-md-12 border-bottom p-0">
                                            <input type="text" placeholder="Type here..." class="form-control p-0 border-0"> </div>
                                    </div>
                                    <div class="form-group mb-4">
                                        <label for="example-email" class="col-md-12 p-0">Write the name for CHOCOCOOH</label>
                                        <div class="col-md-12 border-bottom p-0">
                                            <input type="email" placeholder="Type here..." class="form-control p-0 border-0" name="example-email" id="example-email">
                                        </div>
                                    </div>
                                    <div class="form-group mb-4">
                                        <label class="col-md-12 p-0">Which functional group does CHOOH belong to?</label>
                                        <div class="col-md-12 border-bottom p-0">
                                          <input type="radio" id="Alkanes" name="fav_language" value="Alkanes">
                                            <label for="Alkanes">Alkanes</label><br>
                                            <input type="radio" id="Alkenes" name="fav_language" value="Alkenes">
                                            <label for="Alkenes">Alkenes</label><br>
                                            <input type="radio" id="Alcohols" name="fav_language" value="Alcohols">
                                           <label for="Alcohols">Alcohols</label>                                            
                                        </div>
                                    </div>
                                    <div class="form-group mb-4">
                                        <label class="col-md-12 p-0">Define the term 'lipids'</label>
                                        <div class="col-md-12 border-bottom p-0">
                                            <input type="text" placeholder="Type here..." class="form-control p-0 border-0">
                                        </div>
                                    </div>
                                    <div class="form-group mb-4">
                                        <label class="col-md-12 p-0">With your knowledge of chemical compounds, differentiate fully between Proteins and Nucleic acids. </label>
                                        <div class="col-md-12 border-bottom p-0">
                                            <textarea rows="5" placeholder="Type here..." class="form-control p-0 border-0"></textarea>
                                        </div>
                                    </div>
                                    <div class="form-group mb-4">
                                        <label class="col-sm-12">The law describes the inversely proportional relationship between the absolute pressure and volume of a gas, if the temperature is kept constant within a closed system was discovered by:</label>

                                        <div class="col-sm-12 border-bottom">
                                            <select class="form-select shadow-none p-0 border-0 form-control-line">
                                                <option>Robert Boyle</option>
                                                <option>Georg Stahl</option>
                                                <option>Antoine Lavoisier</option>
                                                <option>John Dalton</option>
                                                <option>Carl Wilhelm Scheele</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="form-group mb-4">
                                        <div class="col-sm-12">
                                            <button class="btn btn-orange">Submit</button>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
</asp:Content>
