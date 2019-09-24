using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementApp.BLL;
using StockManagementApp.DAL.Models;
using StockManagementApp.DAL.Models.ViewModel;

namespace StockManagementApp.UI
{
    public partial class StockOutUI : System.Web.UI.Page
    {

        StockOutManager stockOutManager = new StockOutManager();
        CompanykManager companykManager = new CompanykManager();
        ItemManager itemManager = new ItemManager();
        List<ItemViewModel> ItemViewModels = new List<ItemViewModel>();
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


                }


            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {



            if (ItemsDownList.SelectedValue != "---No Items Available---") // First Condition  
            {
                if (ItemsDownList.SelectedValue != "0") // Second Condition for itemDropDownList 
                {
                    // Text Field Check Condition
                    if (StockOutQTextBox.Text.Trim() != "" && Convert.ToInt32(StockAvailableQTextBox.Text) < Convert.ToInt32(StockOutQTextBox.Text))
                    {
                        outputlabel.InnerHtml = "Available Quantity is Less";
                    }
                    else if (StockOutQTextBox.Text.Trim() == "")
                    {
                        outputlabel.InnerHtml = "Please Input Stock Out Quantity";
                    }
                    else
                    {

                        ItemViewModel itemViewModel = new ItemViewModel();
                        itemViewModel.ItemId = Convert.ToInt32(ItemsDownList.SelectedValue);
                        itemViewModel.ItemName = ItemsDownList.SelectedItem.ToString();
                        itemViewModel.CompanyName = companyDropDownList.SelectedItem.ToString();
                        itemViewModel.StockAQQuantity = Convert.ToInt32(StockAvailableQTextBox.Text);
                        itemViewModel.Quantity = Convert.ToInt32(StockOutQTextBox.Text.Trim());

                        if (ViewState["itemVS"] == null)
                        {
                            ItemViewModels.Add(itemViewModel);
                            ViewState["itemVS"] = ItemViewModels;
                            outputlabel.InnerHtml = "Item Added to Card Successfully";
                        }
                        else
                        {

                            ItemViewModels = (List<ItemViewModel>)ViewState["itemVS"];
                            foreach (ItemViewModel item in ItemViewModels.ToList())
                            {
                                try
                                {
                                    if (item.ItemId == itemViewModel.ItemId)
                                    {
                                        var existItem = ItemViewModels.Find(x => x.ItemId == itemViewModel.ItemId);
                                        if (existItem != null)
                                        {
                                            // Avobe code are corretly working
                                            int quantity = Convert.ToInt32(item.Quantity + itemViewModel.Quantity);
                                            if (quantity <= Convert.ToInt32(itemViewModel.StockAQQuantity))
                                            {
                                                item.Quantity += itemViewModel.Quantity;
                                                outputlabel.InnerHtml = "Stock Out Qunatity Increased";
                                            }
                                            else
                                            {
                                                outputlabel.InnerHtml = "Available Quantity is Less";
                                            }

                                        }
                                    }

                                    else if (item.ItemId != itemViewModel.ItemId)
                                    {
                                        var existsItem = ItemViewModels.Find(x => x.ItemId == itemViewModel.ItemId);
                                        if (existsItem == null)
                                        {

                                            ItemViewModels.Add(itemViewModel);
                                            ViewState["itemVS"] = ItemViewModels;
                                            outputlabel.InnerHtml = "Item Added to Card Successfully";
                                        }
                                    }

                                }
                                catch (Exception a)
                                {
                                    System.Diagnostics.Debug.WriteLine("Sorry! Your Operation Did not Complete" + a.Message);
                                }
                            }
                        } // Third Condition End here

                        stockOutGridView.DataSource = ItemViewModels;
                        stockOutGridView.DataBind();
                        ClearValue();
                    }
                }
            }
        }

        // Acion Code Start here here


        protected void sellButton_Click(object sender, EventArgs e)
        {

            outputlabel.InnerHtml = StockOutByType("SELL");
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            ClearValue();
          
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {

            outputlabel.InnerHtml = StockOutByType("DAMAGE");
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            ClearValue();
          
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {

            outputlabel.InnerHtml = StockOutByType("LOST");
            stockOutGridView.DataSource = null;
            stockOutGridView.DataBind();
            ClearValue();
          
        }



        // Action code goes here
        private string StockOutByType(string Type)
        {
            if (ViewState["itemVS"] == null)
            {
                return "Please Add Items To Card.";
            }
            else
            {
                ItemViewModels = (List<ItemViewModel>)ViewState["itemVS"];

                foreach (ItemViewModel itemView in ItemViewModels)
                {
                    StockOutModel stockOut = new StockOutModel();
                    stockOut.ItemId = itemView.ItemId;
                    stockOut.Quantity = itemView.Quantity;
                    stockOut.Type = Type;
                    stockOut.Date = DateTime.Today;

                    stockOutManager.StockOut(stockOut);
                    itemManager.Update(stockOut.ItemId, stockOut.Quantity);

                }
                buttonBlock();
                return "Stock Out Successfully by : " + Type;
                
            }


        }

        private void buttonBlock()
        {
            sellButton.Enabled = false;
            damageButton.Enabled = false;
            lostButton.Enabled = false;
            addButton.Enabled = false;
        }
        private void ClearValue()
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
            StockOutQTextBox.Text = String.Empty;

        }
    }
}





