using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementApp.BLL;
using StockManagementApp.DAL.Models;

namespace StockManagementApp.UI
{
    public partial class StockInUI : System.Web.UI.Page
    {
        CatagoryManager catagoryManager = new CatagoryManager();
        CompanykManager companykManager = new CompanykManager();
        ItemManager itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.DataSource = companykManager.GetAllCompany();
                companyDropDownList.DataTextField = "Company";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("---Catagory---", "0"));

                ItemsDownList.Items.Insert(0, "---No Items Available---");
            }

        }



        protected void catagoryDropDownListIndexChanged(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(companyDropDownList.SelectedValue);
            if (Id != 0)
            {
                ItemsDownList.DataSource = itemManager.GetItemById(Id); ;
                ItemsDownList.DataTextField = "Name";
                ItemsDownList.DataValueField = "Id";
                ItemsDownList.DataBind();
                ItemsDownList.Items.Insert(0, new ListItem("---Items---", "0"));
                ItemsDownList.SelectedIndex = 0;
                outputlabel.InnerHtml = "";
            }
            else
            {
                ItemsDownList.Items.Insert(0, "---No Items Available---");
            }


        }

        protected void ItemsDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemsDownList.SelectedValue != "---No Items Available---")
            {
                int Id = Convert.ToInt32(ItemsDownList.SelectedValue);
                if (Id != 0)
                {
                    ItemModel ItemRelator = itemManager.GetAllItemsByID(Id);

                    reorderLabelTextBox.Text = ItemRelator.Reorder.ToString();
                    StockAvailableQTextBox.Text = ItemRelator.StockAQ.ToString();
                    outputlabel.InnerHtml = "";

                }
               }
        }

        protected void StockInButton_Click(object sender, EventArgs e)
        {

          

            if (ItemsDownList.SelectedValue != "---No Items Available---")
            {

                if (ItemsDownList.SelectedValue != "0")
                {
                
                    if (StockInQTextBox.Text.Trim() == "")
                    {
                       
                        stockinError.Text = "* Please Input Stock In Quantity";
                    }
                    else
                    {
                        ItemModel itemStockIn = new ItemModel();
                        itemStockIn.Id = Convert.ToInt32(ItemsDownList.SelectedValue);
                        
                        itemStockIn.StockAQ = Convert.ToInt32(StockInQTextBox.Text);
                        String message = itemManager.StockIn(itemStockIn);
                        outputlabel.InnerHtml = message;
                        if (message.Contains("Stock In successfull"))
                        {
                           companyDropDownList.Items.Clear();
                           ItemsDownList.Items.Clear();
                            companyDropDownList.DataSource = companykManager.GetAllCompany();
                            companyDropDownList.DataTextField = "Company";
                            companyDropDownList.DataValueField = "Id";
                            companyDropDownList.DataBind();
                            companyDropDownList.Items.Insert(0, new ListItem("---Catagory---", "0"));
                            ItemsDownList.Items.Insert(0, "---No Items Available---");
                            reorderLabelTextBox.Text = String.Empty;
                            StockAvailableQTextBox.Text = String.Empty;
                            StockInQTextBox.Text = String.Empty;
                            stockinError.Text = "";

                        }
                    }
                }


            }


        }














    }
}