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
                        <h1 class="app_pageTitle"><span>Tranquility <br />and <br />Harmony awaits</span></h1>
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
            <div class="page-wrapper">
                <div class="row">
                    <div class="col col-text">
                    <h2 class="typography-heading"><span>Experience</span></h2>
                    <p class="typography-regular" style="max-width: 800px;">Elevate Your Experience: Immerse yourself in the breathtaking beauty of our hotel, 
                        where panoramic views captivate your senses and create an enchanting backdrop for your stay. Indulge in luxurious accommodations, 
                        exceptional service, and an array of amenities designed to exceed your expectations. 
                        Discover a haven where every moment is curated to deliver an unforgettable experience, 
                        leaving you with cherished memories that will last a lifetime.</p>
                    </div>
                    <div class="col col-img-right">
                        <img src="Assets/Images/kempinski-residence.jpg" />
                    </div>
                </div>
            </div>
            <div class="page-wrapper" style="background-color: #f4f4f2;">
                <div class="grid-container-center">
                    <h1 class="typography-heading"><span>Stay with Us</span></h1>
                    <p class="typography-regular" style="max-width: 800px;">Indulge in 4 (boarding house yarn) comfortable and well-appointed rooms, 
                        offering modern amenities and serene ambiance for your ultimate relaxation and comfort.</p>
                                <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="false">
              <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
                  <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="3" aria-label="Slide 4"></button>
              </div>
              <div class="carousel-inner">
                <div class="carousel-item active">
                  <img src="Assets/Images/nautica-modern-suite.jpg" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h3>Modern Suite</h3>
                  </div>
                </div>
                <div class="carousel-item">
                  <img src="Assets/Images/nautica-grand-suite.jpg" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h3>Grand Suite</h3>
                  </div>
                </div>
                <div class="carousel-item">
                  <img src="Assets/Images/nautica-superior-suite.jpg" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h3>Superior Suite</h3>
                  </div>
                </div>
                <div class="carousel-item">
                  <img src="Assets/Images/nautica-executive-suite.jpg" class="d-block w-100" alt="...">
                  <div class="carousel-caption d-none d-md-block">
                    <h3>Executive Suite</h3>
                  </div>
                </div>
                  </div>
                      <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                      </button>
                      <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                      </button>
                    </div>
                </div>
            </div>
            <div class="page-wrapper">
                <div class="grid-container-center show">
                    <h2 class="app_heading1">Reserve Your Exclusive Stay</h2>
                </div>
            </div>
        </div>
        <script>
            window.addEventListener('scroll', function () {
                var row = document.querySelector('.row');
                var rowPosition = row.getBoundingClientRect();
                var windowHeight = window.innerHeight;

                if (rowPosition.top < windowHeight / 2 && rowPosition.bottom > windowHeight / 2) {
                    row.classList.add('fade-in');
                }
            });


            window.addEventListener('scroll', function () {
                var gridContainerCenter = document.querySelector('.grid-container-center');
                var gridContainerCenterPosition = gridContainerCenter.getBoundingClientRect();
                var windowHeight = window.innerHeight;
                var centerOffset = windowHeight / 2;

                if (
                    gridContainerCenterPosition.top < centerOffset &&
                    gridContainerCenterPosition.bottom > centerOffset
                ) {
                    gridContainerCenter.classList.add('fade-in');
                }
            });

            window.addEventListener('scroll', function () {
                var pageWrapper = document.querySelector('.page-wrapper');
                var leftHalf = document.querySelector('.grid-left-half');
                var rightHalf = document.querySelector('.grid-right-half');
                var pageWrapperPosition = pageWrapper.getBoundingClientRect();
                var windowHeight = window.innerHeight;
                var centerOffset = windowHeight / 1.2;

                if (
                    pageWrapperPosition.top < centerOffset &&
                    pageWrapperPosition.bottom > centerOffset
                ) {
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
