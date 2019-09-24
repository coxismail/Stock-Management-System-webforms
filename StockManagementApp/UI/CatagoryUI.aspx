<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatagoryUI.aspx.cs" Inherits="StockManagementApp.UI.CatagoryUI" %>

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
            <div>
                <h2 class="sub_header">Catagory Setup</h2>
                <table class="usertable">
                    <tr>
                        <td>
                            <asp:Label runat="server" Text="Catagory Name :" />
                        </td>
                        <td>
                            <asp:TextBox ID="catagotyTextBox" runat="server" Width="304px" />
                        </td>
                        <td>
                            <asp:Button ID="catagroySavebutton" runat="server" OnClick="catagroySavebutton_Click" Text="Save" Width="54px" Height="24px" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="2">
                            <asp:RegularExpressionValidator class="error" runat="server" ValidationExpression="[A-Z a-z]+" ControlToValidate="catagotyTextBox" ErrorMessage="* Only Letter is Allowed" EnableClientScript="True" Display="Dynamic" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <h4 class="error" id="outputlabel" runat="server"></h4>
                        </td>
                    </tr>
                </table>



            </div>
            <!--input end-->
            <br />
            <asp:GridView class="gridviewFull" ID="CatagoryListGridVew" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">

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
                    <asp:TemplateField HeaderText=" Catagory">
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hiddenfieldID" Value='<% #Eval("Id")%>' />
                            <asp:Label runat="server" Text='<% #Eval("Catagory")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Action">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" OnClick="LinkButton_Click"> Update</asp:LinkButton>
                            <asp:LinkButton runat="server" OnClick="DeleteAction_Click"> Delete</asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

        </div>

        <div class="footer_area">
            <p>Developed By: <a href="http://www.facebook.com/coxismail.bd">Mohammad Ismail</a> </p>

        </div>


    </form>

</body>
</html>
