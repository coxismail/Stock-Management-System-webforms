<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockInUI.aspx.cs" Inherits="StockManagementApp.UI.StockInUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../css/maincss.css" rel="stylesheet" />
    <link href="../css/menucss3.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">

    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <nav class="nav">
            <ul>
                <li><a href="IndexUI.aspx" runat="server"><i class="fas fa-home"></i>Home</a></li>
                <li><a href="CatagoryUI.aspx" runat="server" >Catagory</a></li>
                <li><a href="CompanyUI.aspx" runat="server">Company</a></li>
                <li><a href="ItemUI.aspx" runat="server"><i class="fas fa-sitemap"></i> Items</a></li>
                <li><a href="StockInUI.aspx" runat="server">Stock In</a></li>
                <li><a href="SearchAndView.aspx" runat="server"><i class="fab fa-superpowers"></i> Search</a></li>
                <li><a href="StockOutUI.aspx" runat="server">Stock Out</a></li>
                <li><a href="SaleSummaryUI.aspx" runat="server">Summary</a></li>
                <li><a href="#"><i class="fas fa-users" title="Who Done This Project"></i> Team</a>
                    <ul>
                        <li><a>Mohammad Ismail</a></li>
                        <li><a>Akash Shusil</a></li>
                        <li><a>Nipa Akter</a> </li>
                    </ul>
                </li>
              
            </ul>
        </nav>

        <div class="main_area">
            <h2 class="sub_header">Stock In  </h2>
            <table class="usertable">
                <tr>
                    <td>Company :&nbsp; </td>
                    <td class="right_clumn">
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="178px" OnSelectedIndexChanged="catagoryDropDownListIndexChanged" AutoPostBack="True" Style="height: 25px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Items :&nbsp; </td>
                    <td>
                        <asp:DropDownList ID="ItemsDownList" runat="server" Width="178px" AutoPostBack="True" OnSelectedIndexChanged="ItemsDownList_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Reorder :</td>
                    <td>
                        <asp:TextBox ID="reorderLabelTextBox" runat="server" Width="178px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Available Quantity :</td>
                    <td>
                        <asp:TextBox ID="StockAvailableQTextBox" runat="server" Width="178px" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Stock In Quantity :</td>
                    <td>
                        <asp:TextBox ID="StockInQTextBox" runat="server" Width="178px"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator class="error" ValidationExpression="[0-9]+" runat="server" ErrorMessage="* Only Number is Allowed" ControlToValidate="StockInQTextBox" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label class="error" ID="stockinError" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="StockInButton" runat="server" Text="Stock In" Width="50px" BackColor="blue" Font-Bold="True" Font-Size="Small" ForeColor="White" OnClick="StockInButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h4 class="error" id="outputlabel" runat="server"></h4>
                    </td>
                </tr>
            </table>
        </div>
        <div class="footer_area">
            <p>Developed By: <a href="http://www.facebook.com/coxismail.bd">Mohammad Ismail</a> </p>

        </div>

    </form>
</body>
</html>
