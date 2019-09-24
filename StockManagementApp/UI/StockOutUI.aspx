<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementApp.UI.StockOutUI" %>

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
                <li><a href="CatagoryUI.aspx" runat="server">Catagory</a></li>
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
            <h2 class="sub_header">Stock Out  </h2>
            <table class="usertable">
                <tr>
                    <td>Company :&nbsp; </td>
                    <td>
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
                    <td>Stock Out Quantity :</td>
                    <td>
                        <asp:TextBox ID="StockOutQTextBox" runat="server" Width="178px"></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ValidationExpression="[0-9]+" runat="server" ErrorMessage="* Only Number is Allowed" ControlToValidate="StockOutQTextBox" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="addButton" runat="server" Text="Add" Width="50px" BackColor="blue" Font-Bold="True" Font-Size="Small" ForeColor="White" OnClick="addButton_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h4 class="error" id="outputlabel" runat="server"></h4>
                    </td>
                </tr>
            </table>





            <%-- Grid View Code here--%>

            <asp:GridView class="gridviewFull" ID="stockOutGridView" runat="server" AutoGenerateColumns="False" CellPadding="2" ForeColor="#333333" GridLines="None">
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
                    <asp:TemplateField HeaderText="Company">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
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
            <br />
            <div class="buttonArea">
                &nbsp;<asp:Button ID="sellButton" runat="server" Text="Sell" OnClick="sellButton_Click" Font-Bold="True" BackColor="#339966" Width="70px" />
                &nbsp;
        <asp:Button ID="damageButton" runat="server" Text="Damage" OnClick="damageButton_Click" Font-Bold="True" BackColor="#66CCFF" Width="100px" />
                &nbsp;
        <asp:Button ID="lostButton" runat="server" Text="Lost" OnClick="lostButton_Click" Font-Bold="True" BackColor="#CCCCFF" Width="70px" />

            </div>

        </div>
        <div class="footer_area">
            <p>Developed By: <a href="http://www.facebook.com/coxismail.bd">Mohammad Ismail</a> </p>

        </div>

    </form>
</body>
</html>
