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
                    <div class="col-sm-12 col-md-12 col-lg-8">
                        <div class="search_container">
                            <div class="search-button-container">
                                <span>Guests</span>
                                <asp:DropDownList ID="GuestCount" runat="server"></asp:DropDownList>
                            </div>
                            <div class="search-button-container">
                                <p><span>Check In</span></p>
                                <asp:TextBox ID="TextBox1" CssClass="calendar-control" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                            <div class="search-button-container">
                                <p><span>Check Out</span></p>
                                <asp:TextBox ID="TextBox2" CssClass="calendar-control" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <aside class="col-sm-12 col-md-12 col-lg-4 reservation-cart-container">
                        <div class="reservation-cart info_container sticky-top">
                            <h2 class="app_heading1">Your Booking Summary</h2>
                        </div>
                    </aside>
                </div>
            </div>
        </div>

          <a class="pseudo-text-effect" href="#" data-after="Link">
            <span>Link</span>
          </a>
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