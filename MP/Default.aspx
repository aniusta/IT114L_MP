<%@ Page Title="Harmony Heights" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MP._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <link rel="stylesheet" href="styles.css">
        <div class="home-top-container">
            <div class="navbar-container">
                <nav class="trans-nav">
                    <div class="main-logo">
                        <p><span class="app_heading1">HARMONY HEIGHTS</span></p>
                        <img src="Assets/Images/main-logo.png" />
                    </div>
                    <a class="pseudo-text-effect book-button" href="/Bookings" data-after="Book Now">
                    <span>Book Now</span>
                    </a>
                </nav>
                <nav class="solid-nav">
                    <div class="main-logo">
                        <p><span class="app_heading1">HARMONY HEIGHTS</span></p>
                        <img src="Assets/Images/main-logo.png" />
                    </div>
                    <a class="pseudo-text-effect book-button" href="/Bookings" data-after="Book Now">
                    <span>Book Now</span>
                    </a>
                </nav>
            </div>
            <div class="hero-header-image" 
            style="background-image: url(/Assets/Images/IMG_3047.jpg); ">
                <div class="main-header-text">
                    <h1 class="app_pageTitle"><span>Harmony Heights</span></h1>
                    <p><span>Your Escape to Tranquility</span></p>
                </div>
            </div>
            <div class="page-wrapper" style="background-color: #f4f4f2;">
                <div class="grid-container">
                    <div class="grid-left-half">
                        <small>WELCOME</small>
                        <h1 class="app_pageTitle eqweqwe"><span>Tranquility <br />and <br />Harmony awaits</span></h1>
                        <p class="app_pSen"> Immerse yourself in the magic of this place, where time slows down, and the burdens of life dissolve. 
                            Indulge in exquisite cuisine, surrender to luxurious wellness experiences, and breathe in the beauty of nature. 
                            At Harmony Heights, you enter a realm where dreams become reality—a sanctuary where serenity reigns supreme. 
                            Enjoy a truly exceptional stay at our hotel, where every moment is designed to envelop you in harmony and elevate your experience.</p>
                    </div>
                    <div class="grid-right-half">
                        <img src="Assets/Images/Cashel-Palace-Hotel-Bishops--Buttery-Fireplace-Web.jpg">
                    </div>

                </div>
            </div>
        </div>
        <script>
            window.addEventListener('scroll', function () {
                var pageWrapper = document.querySelector('.page-wrapper');
                var leftHalf = document.querySelector('.grid-left-half');
                var rightHalf = document.querySelector('.grid-right-half');
                var pageWrapperPosition = pageWrapper.getBoundingClientRect();

                if (pageWrapperPosition.top < window.innerHeight) {
                    leftHalf.classList.add('fade-in');
                    rightHalf.classList.add('fade-in');
                }
            });

            window.addEventListener('scroll', function () {
                var nav = document.querySelector('.solid-nav');
                var navHeight = nav.offsetHeight;
                var scrollTop = window.pageYOffset || document.documentElement.scrollTop;

                if (scrollTop >= navHeight) {
                    nav.classList.add('fixed-nav');
                } else {
                    nav.classList.remove('fixed-nav');
                }
            });

        </script>
    </main>

</asp:Content>
