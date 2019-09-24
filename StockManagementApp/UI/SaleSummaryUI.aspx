<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleSummaryUI.aspx.cs" Inherits="StockManagementApp.UI.SaleSummaryUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/maincss.css" rel="stylesheet" />
    <link href="../css/menucss3.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>

    <script type="text/javascript">
        $(function () {
            $("#fromDateTextBox").datepicker({
                dateFormat: "yy-mm-dd",
                changeMonth: true,
                changeYear: true
            });
            $("#toDateTextBox").datepicker({
                dateFormat: "yy-mm-dd",
                changeMonth: true,
                changeYear: true
            });
        });

    </script>
</head>
<body>


    <form id="form2" runat="server">
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
            <h2 class="sub_header">View Sales Summary</h2>
            <table class="usertable">
                <tr>
                    <td>From Date :
                    </td>
                    <td class="right_clumn">
                        <input type="text" class="dateTextBox" id="fromDateTextBox" runat="server" placeholder="YYYY-MM-DD" readonly="" width="230px"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label class="error" ID="ErrorLabelFrom" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>To Date :
                    </td>
                    <td>
                        <input type="text" class="dateTextBox" ID="toDateTextBox" runat="server" placeholder="YYYY-MM-DD"  width="230px" ReadOnly="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        </td>
                        <td>
                            <asp:Label class="error" ID="ErrorLabelTo" runat="server" Text=""></asp:Label>
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="searchByDate" runat="server" Text="Search" Font-Bold="True" OnClick="searchByDate_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label class="error" ID="outputLabel" runat="server" Text=""></asp:Label>



            <asp:GridView class="searchByDateGridView" ID="searchByDateGridView" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None" Width="100%">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            SL
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LabelSerial" runat="server" Text='<%#Container.DataItemIndex+1 %>'>'</asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Item">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("ItemName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
<%--                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="SaleQuantity">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
        </div>
        
                <div class="footer_area">
            <p>Developed By: <a href="http://www.facebook.com/coxismail.bd">Mohammad Ismail</a> </p>

        </div>

    </form>
</body>
</html>
