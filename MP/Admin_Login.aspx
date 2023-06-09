<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Login.aspx.cs" Inherits="MP.Admin_Login" %>

<!DOCTYPE html>
<html lang="en" class="grid-container" style="width:100%;height:70%;align-items:center;padding:0px;">
    <head runat="server">
        <title>Admin Login</title>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <style>
            .inpt_border {
                border: none;
                border-bottom: 2px solid black;
                outline: none;
                border-bottom-color: rgba(73,57,75,1);
            }

            .inpt_border:focus {
                border-bottom-color: rgba(73,57,75,1);
            }
            .button_primary{
                background: white;
                border: 1px solid black;
                color:white;    
            }
            .button_primary:hover{
                background: white;
                border: 1px solid black;
                color:black;    
            }

        </style>
        <link rel="stylesheet" href="stylesR.css">
    </head>
    <body runat="server" class="grid-container" style="height:90%;align-items:center">
        <form runat="server">
            <div class="col-md-12" style="width:40%;text-align:center">
                    <h1 class="app_pageTitle inpt_border" style="padding:5px"><span>Login</span></h1>
            </div>
            <div class="col-md-12" style="width:250px;text-align:center" >
                <asp:TextBox ID="username_tb" runat="server" placeholder="Username" class="inpt_border typography-regular" style="width:100%;padding-top:20px;text-align:left;margin-bottom:0px"></asp:TextBox>
            </div>
            <div class="col-md-12" style="width:250px;text-align:center" >
                <asp:TextBox ID="password_tb" runat="server" placeholder="Password" class="inpt_border typography-regular" style="width:100%;text-align:left;margin-bottom:10px" TextMode="Password"></asp:TextBox>
                <p id="errmsg" runat="server" style="color:#e83333;font-size:13px">username and/or password not found</p>
            </div>
            <div class="col-md-12" style="width:250px;text-align:center" >
                <asp:Button ID="login_button" class="btn button_primary" runat="server" Text="Login" style="width:100%;height:35px" OnClick="login_button_Click"/>
            </div>
            
        </form>
        
        
    </body>
    
</html>
