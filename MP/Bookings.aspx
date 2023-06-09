<%@ Page Title="" Language="C#" MasterPageFile="~/Reservation.Master" AutoEventWireup="true" CodeBehind="Bookings.aspx.cs" Inherits="MP.WebForm2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="app-container">
        <link rel="stylesheet" href="stylesR.css">
        <div id="hero-image">
            <div class="hero-image_image" 
                style="background-image: url(/Assets/Images/booking-topimage.jpg); 
                height: 491px; 
                transform: translateY(0);">
                        <div class="hero-image-description">
            <p class="app_heading1">Harmony Heights Hotel</p>
        </div>
            </div>
        </div>

        <div class="app_page-background">
            <div class="profile-container">
                <div class="app_row">
                    <div class="col-sm-12 col-md-12 col-lg-8" runat="server">
                        <div class="search_container">
                            <div class="search-button-container">
                                <span>Guests</span>
                                <asp:DropDownList ID="GuestCount" class="dropdown" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="search-button-container">
                                <p><span>Check In</span></p>
                                <asp:TextBox ID="checkindate" CssClass="calendar-control" TextMode="Date" runat="server" OnTextChanged="checkindate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="search-button-container">
                                <p><span>Check Out</span></p>
                                <asp:TextBox ID="checkoutdate" CssClass="calendar-control" TextMode="Date" runat="server" OnTextChanged="checkoutdate_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="header-title">
                            <h1 class="app_pageTitle">Select a Room</h1>
                        </div>
<!--        CARD CONTAINER               
                        <div class="card-container" style="border: 1px black solid;">
                            <div class="col-lg-4 container-padding">
                                <img src="Assets/Images/nautica-executive-suite.jpg" class="card-img"/>
                            </div>
                            <div class="col-lg-5 container-padding">
                                <p class="app_heading1">{roomType}</p>
                                <small>Sleeps 3 | 1 King</small>
                                <p class="typography-regular">{roomDescription}</p>
                            </div>
                            <div class="col-lg-3 container-padding rightmost-card">
                                <strong>$ {roomPrice}</strong><br />
                                <small>Per Night</small><br />
                                <small class="text-muted">Including Taxes and Fees</small><br />
                                <asp:Button ID="bookbtn" class="btn button_primary" runat="server" Text="Button" />
                            </div>
                        </div>
-->
                        <div class="card-container-wrapper">
                            <asp:Panel ID="cardContainer" runat="server"></asp:Panel>
                        </div>
                    </div>

                    <aside class="col-sm-12 col-md-12 col-lg-4 reservation-cart-container">
                        <div class="reservation-cart info_container sticky-top">
                            <h2 class="app_heading1">Your Booking Summary</h2>
                            <div class="row g-2">
                                <div class="col">
                                    <b><span>Check-in</span></b><br />
                                    <span>After 3:00 PM</span>
                                </div>
                                <div class="col-7">
                                    <b><span>Check-in</span></b><br />
                                    <span>Before 12:00 PM</span>
                                </div>
                            </div>
                        <asp:Panel ID="bookingContainer" runat="server"></asp:Panel>
                        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                            <!-- <div class="row">
                                <div class="col-8">
                                    {roomType} <br />
                                    Bed & Breakfast <br />
                                    <small><b>{Number}nights</b></small><br /><br />
                                    {add remove button here}
                                </div>
                               <div class="col">
                                   <b>{roomPrice}</b>
                               </div>
                            </div>
                            <hr />
                            <div class="booking-total">
                                <h5><b>Total: </b></h5>
                                <h5><b>{TOTAL} </b></h5>
                            </div> -->
                            <asp:Button ID="bookingbtn" class="btn button_primary btn-booking" runat="server" Text="Complete Booking" OnClick="bookingbtn_Click"/>
                        </div>
                    </aside>
                </div>
            </div>
        </div>
        <script>

            window.addEventListener('scroll', function () {
                var scrollPosition = window.pageYOffset;
                var parallaxElements = document.querySelectorAll('.hero-image_image');

                for (var i = 0; i < parallaxElements.length; i++) {
                    var parallaxElement = parallaxElements[i];
                    var parallaxSpeed = parallaxElement.dataset.parallaxSpeed || 0.5;
                    var translateY = scrollPosition * parallaxSpeed;

                    parallaxElement.style.transform = 'translate3d(0, ' + translateY + 'px, 0)';
                }
            });

        </script>
    </main>

</asp:Content>