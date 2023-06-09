<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_Page.aspx.cs" Inherits="MP.Report_Page" %>

<!DOCTYPE html>

<html lang="en" class="grid-container" style="width:100%;height:70%;align-items:center;padding:0px;">
<head runat="server">
    <title></title>
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
    <link rel="stylesheet" href="stylesR.css"/>
</head>
<body class="grid-container" style="height:90%;align-items:center">
    <form id="form1" runat="server" style="width:100%;height:100%">
        <div class="col-md-12" style="text-align:center;width:100%">
                    <asp:Label ID="title" runat="server" class="app_pageTitle inpt_border" style="padding:5px"><span>Hotel Reports</span></asp:Label>
        </div>
        <div class="col-md-12" style="text-align:center">
                <asp:Button ID="booked_rooms_btn" class="btn button_primary" runat="server" Text="Booked Rooms" style="width:15%;height:30px" OnClick="booked_rooms_btn_Click"/>
                <asp:Button ID="Button1" class="btn button_primary" runat="server" Text="Something" style="width:15%;height:30px" OnClick="something"/>
                <asp:Button ID="Button2" class="btn button_primary" runat="server" Text="Admin Login" style="width:15%;height:30px" PostBackUrl="~/Admin_Login.aspx"/>
        </div>
        <div class="col-md-12" style="display:flex;justify-content:center">
            <asp:GridView runat="server" ID="booked_rooms_tbl" EmptyDataText="NO INFO" class="typography-regular col-md-12" style="font-size:15px;border-collapse:collapse;width:1200px">
            </asp:GridView>
        </div>
        
    </form>
</body>
</html>
