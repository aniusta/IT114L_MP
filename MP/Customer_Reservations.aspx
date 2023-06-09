<%@ Page Title="" Language="C#" MasterPageFile="~/Reservation.Master" AutoEventWireup="true" CodeBehind="Customer_Reservations.aspx.cs" Inherits="MP.Customer_Reservations"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="app-container" style="background-color:white">
        <link rel="stylesheet" href="stylesR.css" >
        <div style="height:150px">
            <div class="col-md-12" style="text-align:center;width:100%;margin-top:30px;margin-bottom:30px">
                    <asp:Label ID="title" runat="server" class="app_pageTitle inpt_border" style="padding:200px"></asp:Label>
            </div>
            <div class="col-md-12" style="display:flex;justify-content:center">
                <asp:GridView runat="server" ID="booked_rooms_tbl" EmptyDataText="NO INFO" class="typography-regular col-md-12" 
                    style="font-size:15px;border-collapse:collapse;width:1200px" AllowPaging="true" PageSize="10" 
                    OnPageIndexChanging="booking_tbl_PageIndexChanged" BackColor="#fff7eb" GridLines="Both">
                    <HeaderStyle BackColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <PagerStyle HorizontalAlign="Center" Font-Size="15px"/>
                </asp:GridView>
            </div>
        </div>
        
    </main>
</asp:Content>