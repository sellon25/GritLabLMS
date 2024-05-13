<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/LMSBoardAdmin.Master" CodeBehind="SQDGOverview.aspx.vb" Inherits="LMSApp.SQDGOverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Type_pageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Change_Breadcrumb_PageTitle" runat="server">
    SQUIDGAME Overview
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main_ContentPlaceHolder" runat="server">
     <div>
        1 What is Squid Game’s “Red Light, Green Light”? <br/><br />
        This is a game that is played as follows:
        1 456 players will start the game, on a start line. <br/><br />
        2 Players are allowed to move towards the finish line from the
        start line, only when the light is GREEN. Players that are
        caught moving when the light is RED, will be eliminated. <br/><br />
        3 Players that have not reached the finish line when the time
        runs out, will be eliminated. Develop a Python Program that
        simulates the “Squid Game” as follows: <br/>
        Your Program should use import time to get a period of five seconds. After five seconds, it should be green light. After five seconds
        it should tick again, and it should be red light. This cycle should
        continue until 30 seconds (after six rounds). After 30 seconds the
        game should halt. <br/><br />
        For every GREEN light, use random numbers to determine the players that move forward. If a player moved forward two times out of
        the three times when there was green light, the player wins. Use random numbers to determine the players that will not move. When
        using random numbers, make sure 80% of the players are moving,
        while 20% will not. <br/><br />
        For every RED light, use random numbers to determine players that
        moved. This should be 5% of all players (selected randomly). These
        players should be eliminated. <br/><br />
        Stop this game after 30 seconds. <br/><br />
        For every round of the timer, make use of a list to show: which
        light it is, players that have moved, players that have not moved,
        and players that are eliminated (if any). <br/><br />
     
        • This should look like this (for two timer ticks of green and red): <br/><br />
        • Green Light <br/>
        Moved: 372, 13, 46, 459, 1, 89, 45 <br/>
        Static: 203, 7, 65, 88 <br/>
        Eliminated: None. <br/><br />
        • Red Light <br/>
        Moved: 372, 13 <br/>
        Static: 46, 459, 1, 89, 45, 203, 7, 65, 88 <br/>
        Eliminated: 372, 13. <br/><br/>
        Hints:<br/>
        • Use methods to keep your code clean.<br/>
        • You will get marks for aspects of the code that makes logical
        sense.<br/>
        • Wherever it seems like you need more information, please improvise.<br/>
        • Import Time to keep track of ticks<br/>
    </div>
</asp:Content>
