<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="StockManagementApp.UI.IndexUI" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/maincss.css" rel="stylesheet" />
    <link href="../css/menucss3.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">
    <title>Stock Management System </title>
</head>
<body>
    <form id="form1" runat="server">

        <nav class="nav">
            <ul>
                <li><a href="IndexUI.aspx" runat="server"><i class="fas fa-home"></i>Home</a></li>
                <li><a href="CatagoryUI.aspx" runat="server">Catagory</a></li>
                <li><a href="CompanyUI.aspx" runat="server">Company</a></li>
                <li><a href="ItemUI.aspx" runat="server"><i class="fas fa-sitemap"></i> Items</a></li>
                <li><a href="StockInUI.aspx" runat="server">Stock In</a></li>
                <li><a href="SearchAndView.aspx" runat="server"><i class="fab fa-superpowers"></i> Search</a></li>
                <li><a href="StockOutUI.aspx" runat="server">Stock Out</a></li>
                <li><a href="SaleSummaryUI.aspx" runat="server">Summary</a></li>
                <li><a href="#"><i class="fas fa-users" title="Who Done This Project"></i> Team</a>
                    <ul>
                        <li><a>Mohammad Ismail   </a></li>
                        <li><a>Akash Shusil     </a></li>
                        <li><a>Nipa Akter      </a> </li>
                    </ul>
                </li>
              
            </ul>
        </nav>

        <div class="main_area">
            <br/><br/><br/>
            <h1 class="project_header">Welcome To Stock Management System</h1>
            <p class="direction">Get Started With Menu</p>
        <br/><br/><br/><br/><br/><br/><br/>
        </div>

        <div class="footer_area">
            <p>Developed By: <a href="http://www.facebook.com/coxismail.bd">Mohammad Ismail</a> </p>

        </div>


    </form>





</body>
</html>
