<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemUI.aspx.cs" Inherits="StockManagementApp.UI.ItemUI" %>

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
            <h2 class="sub_header">Item Setup</h2>
            <table class="usertable">
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Catagory :"></asp:Label></td>
                    <td class="right_clumn">
                        <asp:DropDownList ID="catagoryDropDownList" runat="server" Width="220px" AutoPostBack="True"></asp:DropDownList>
                    </td>
                </tr>
                                <tr>
                    <td></td>
                    <td><asp:Label class="error" ID="catagoryError" runat="server"></asp:Label> </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label runat="server" Text="Company :"></asp:Label></td>
                    <td>
                      <asp:DropDownList ID="companyDropDownList" runat="server" Width="220px" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    </tr>
                <%--Error code--%>
                <tr>
                    <td></td>
                    <td><asp:Label class="error" ID="companyError" runat="server"></asp:Label> </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" Text="Item Name :"></asp:Label>
                    </td>
                    <td>
                         <asp:TextBox ID="ItemNameTextBox" runat="server" Width="220px"></asp:TextBox> <br/>
                  <asp:RegularExpressionValidator runat="server" ValidationExpression="[A-Z a-z]+" ControlToValidate="ItemNameTextBox" ErrorMessage="* Only Letter is Allowed" EnableClientScript="True" Display="Dynamic" />

                    </td>
                </tr>
                 <%--Error code--%>
                <tr>
                    <td></td>
                    <td><asp:Label class="error" ID="itemError" runat="server"></asp:Label> </td>
                </tr>


                <tr>
                    <td>
                         <asp:Label runat="server" Text="Reorder Label :"></asp:Label> 
                    </td>
                    <td>
                        <asp:TextBox ID="reorderLabelTextBox" runat="server" Text="0" Width="220px"></asp:TextBox> <br/>
         <asp:RegularExpressionValidator runat="server" ValidationExpression="[0-9]+" ControlToValidate="reorderLabelTextBox" ErrorMessage="* Only Number is Allowed" EnableClientScript="True" Display="Dynamic" />

                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="ItemSaveButton" runat="server" Text="Save" OnClick="ItemSaveButton_Click" Width="50px" BackColor="blue" Font-Bold="True" Font-Size="Small" ForeColor="White"/>  </td>
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
