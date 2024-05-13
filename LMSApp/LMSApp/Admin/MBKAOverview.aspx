<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="MBKAOverview.aspx.vb" Inherits="LMSApp.MBKAOverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    Mini Banking App Overview
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
    Description:<br />
    The Mini Banking App is a web application developed using ASP.NET Web Forms and a backend database.
    The application simulates basic banking functionalities, allowing users to manage customers, accounts, and transactions. 
    It provides a user-friendly interface for performing CRUD (Create, Read, Update, Delete) operations on customer information, account details, and transaction records.
    <br /><br />
    Key Features:<br /><br />

    • Customer Management:<br />

    View a list of customers with basic information (name, ID, etc.).
    Add new customers to the system with relevant details.
    Edit existing customer information, such as name and contact details.
    Delete customers from the database.<br /><br />
    • Account Management:<br />

      Display a list of accounts associated with each customer.
    Create new accounts for existing customers, specifying account types (savings, checking, etc.).
    Update account details, such as balance and account type.
    Remove accounts from the system.<br /><br />
    • Transaction History:<br />

    View a transaction history for each account.
    Perform transactions such as deposits and withdrawals, updating account balances.
    Display transaction details, including date, amount, and transaction type.
    </asp:Content>
