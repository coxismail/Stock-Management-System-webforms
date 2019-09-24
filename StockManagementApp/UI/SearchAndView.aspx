<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchAndView.aspx.cs" Inherits="StockManagementApp.UI.SearchAndView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/maincss.css" rel="stylesheet" />
    <link href="../css/menucss3.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">


</head>
<body>
    <form id="form2" runat="server">
        <nav class="nav">
            <ul>
                <li><a href="IndexUI.aspx" runat="server"><i class="fas fa-home"></i>Home</a></li>
                <li><a href="CatagoryUI.aspx" runat="server">Catagory</a></li>
                <li><a href="CompanyUI.aspx" runat="server">Company</a></li>
                <li><a href="ItemUI.aspx" runat="server"><i class="fas fa-sitemap"></i>Items</a></li>
                <li><a href="StockInUI.aspx" runat="server">Stock In</a></li>
                <li><a href="SearchAndView.aspx" runat="server"><i class="fab fa-superpowers"></i>Search</a></li>
                <li><a href="StockOutUI.aspx" runat="server">Stock Out</a></li>
                <li><a href="SaleSummaryUI.aspx" runat="server">Summary</a></li>
                <li><a href="#"><i class="fas fa-users" title="Who Done This Project"></i>Team</a>
                    <ul>
                        <li><a>Mohammad Ismail</a></li>
                        <li><a>Akash Shusil</a></li>
                        <li><a>Nipa Akter</a> </li>
                    </ul>
                </li>

            </ul>
        </nav>

        <div class="main_area">
            <h2 class="sub_header">View Item Summary</h2>
            <table class="usertable">
                <tr>
                    <td>Company  :
                    </td>
                    <td>
                        <asp:DropDownList ID="companyDropDownList" runat="server" Width="180px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Catagory  :
                    </td>
                    <td>
                        <asp:DropDownList ID="catagoryDropDownList" runat="server" Width="180px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="searchViewButton" runat="server" Text="Search" OnClick="searchViewButton_Click" Font-Bold="True" />
                      
                         </td>
                </tr>
            </table>
            <asp:Label ID="outputLabel" runat="server" Text=""></asp:Label>


            <asp:GridView class="gridviewFull" ID="searchGridView" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Available Quantity">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reorder Level">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Reorder")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>



                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

        </div>
        <div class="footer_area">
            <p>Developed By: <a href="http://www.facebook.com/coxismail.bd">Mohammad Ismail</a> </p>

        </div>

    </form>
</body>
</html>
