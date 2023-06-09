<%@ Page Title="" Language="C#" MasterPageFile="~/Reservation.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MP.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="app-container">
        <link rel="stylesheet" href="stylesR.css">
        <div class="profile-container">
            <div class="app_row">
                <div class="col-sm-12 col-md-12 col-lg-8">
                    <h1 class="app_pageTitle"><span>Your Profile</span></h1>
                    <div class="info_container">
                        <fieldset>
                            <div class="legendContent">
                            <h2 class="app_heading1"><span>Profile Information</span></h2>
                            <span class="required-field-indicator">* Required</span>
                            </div>

                            <div class="row g-2">
                                <div class="col-6">
                                    <div class="form-floating">
                                        <asp:TextBox ID="firstname_textbox" class="form-control custom-height" runat="server" placeholder="First Name"></asp:TextBox>
                                        <label for="firstname_textbox">First Name *</label>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-floating">
                                        <asp:TextBox ID="lastname_textbox" class="form-control" runat="server" placeholder="Last Name"></asp:TextBox>
                                        <label for="lastname_textbox">Last Name *</label>
                                    </div>
                                </div>
                            </div>
                                <div class="col-6">
                                   <div class="form-floating">
                                        <asp:TextBox ID="phone_textbox" class="form-control custom-height" runat="server" placeholder="Phone"></asp:TextBox>
                                        <label for="phone_textbox">Phone</label>
                                    </div>
                                </div>

                            <div class="row g-2">
                                <div class="col-6">
                                    <div class="form-floating">
                                        <asp:TextBox ID="email_textbox" class="form-control custom-height" runat="server" placeholder="Email"></asp:TextBox>
                                        <label for="email_textbox">Email Address*</label>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="form-floating">
                                        <asp:TextBox ID="emailconfirm_textbox" class="form-control custom-height" runat="server" placeholder="Confirm Email"></asp:TextBox>
                                        <label for="emailconfirm_textbox">Confirm Email Address *</label>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div class="info_container">
                        <div class="legendContent">
                            <h2 class="app_heading1"><span>Password</span></h2>
                        </div>
                        <div class="row g-2">
                            <div class="col-6">
                                <div class="form-floating">
                                    <asp:TextBox ID="password" class="form-control custom-height" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <label for="password">Create Password *</label>
                                    <small id="pwHelp" class="form-text text-muted">At least 8 characters long, case sensitive, can contain !$#%, no spaces, not the same as previous password or login</small>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="form-floating">
                                    <asp:TextBox ID="passwordconfirm" class="form-control custom-height" runat="server" placeholder="Confirm password" TextMode="Password"></asp:TextBox>
                                    <label for="passwordconfirm">Confirm Password *</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="info_container">
                        <div class="legendContent">
                            <h2 class="app_heading1"><span>Acknowledgment</span></h2>
                        </div>
                        <div class="checkbox-container">
                            <asp:CheckBox ID="privacy_checkbox" runat="server" /><label for="privacy_checkbox"> * I agree with the Privacy Terms.</label>
                            <asp:CheckBox ID="acknowledgement_checkbox" runat="server" /><label for="acknowledgement_checkbox"> * I would like to create an account.</label>
                        </div>
                    </div>
                <div class="button_group">
                    <asp:Button ID="cancel_button" class="btn button_primary" runat="server" Text="CANCEL" OnClick="cancel_button_Click"/>
                    <asp:Button ID="create_button" class="btn button_primary" runat="server" Text="CREATE" />
                </div>
                </div>
            </div>
        </div>
            <div style="max-width: 990px; margin: 0 auto; padding: 30px;">
            <p><b>Looking for tailored solutions for your stay? </b><br>
            For any inquiries, You can contact us directly. We will then offer you the best solution for your stay.</p>
            </div>
    </main>

</asp:Content>