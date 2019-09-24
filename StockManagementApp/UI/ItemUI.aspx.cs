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
    public partial class ItemUI : System.Web.UI.Page
    {
        ItemManager itemManager = new ItemManager();
        CatagoryManager catagoryManager = new CatagoryManager();
        CompanykManager companykManager = new CompanykManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                catagoryDropDownList.DataSource = catagoryManager.GetAllCatagory();
                catagoryDropDownList.DataTextField = "Catagory";
                catagoryDropDownList.DataValueField = "Id";
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0, new ListItem("---Catagory---", "0"));
                catagoryDropDownList.SelectedIndex = 0;



                companyDropDownList.DataSource = companykManager.GetAllCompany();
                companyDropDownList.DataTextField = "Company";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("---Company--", "0"));
                companyDropDownList.SelectedIndex = 0;
            }



        }


        protected void ItemSaveButton_Click(object sender, EventArgs e)
        {



            if (catagoryDropDownList.SelectedItem.ToString() == "---Catagory---" &&
                companyDropDownList.SelectedItem.ToString() != "---Company--")
            {
                catagoryError.Text = "* Choice Catagory";
            }

            else if (catagoryDropDownList.SelectedItem.ToString() != "---Catagory---" &&
                companyDropDownList.SelectedItem.ToString() == "---Company--")
            {
                companyError.Text = "* Choice Company";
            }
            else if (catagoryDropDownList.SelectedItem.ToString() == "---Catagory---" &&
                 companyDropDownList.SelectedItem.ToString() == "---Company--")
            {
                outputlabel.InnerHtml = "* Catagory, Company and Item Name?";
            }
            else if (catagoryDropDownList.SelectedItem.ToString() != "---Catagory---" &&
                companyDropDownList.SelectedItem.ToString() != "---Company--" &&
                ItemNameTextBox.Text.Trim() == "")
            {
                itemError.Text = "* Input A vaild Item Name";
            }


            else
            {
                ItemModel itemRelator = new ItemModel();

                int reorder = 0;
                itemRelator.CatagoryID = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                itemRelator.CompanyID = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemRelator.Name = ItemNameTextBox.Text;
                if (reorderLabelTextBox.Text.Trim() =="")
                {
                    itemRelator.Reorder = Convert.ToInt32(reorder);  
                }
                else
                {
                    itemRelator.Reorder = Convert.ToInt32(reorderLabelTextBox.Text.Trim());
                }
                
                string message = itemManager.Save(itemRelator);
                outputlabel.InnerHtml = message;
                if (message.Contains("Item Setup successfull"))
                {
                    companyDropDownList.Items.Clear();
                    companyDropDownList.DataSource = companykManager.GetAllCompany();
                    companyDropDownList.DataTextField = "Company";
                    companyDropDownList.DataValueField = "Id";
                    companyDropDownList.DataBind();
                    companyDropDownList.Items.Insert(0, new ListItem("---Company--", "0"));
                    companyDropDownList.SelectedIndex = 0;
             
                    catagoryDropDownList.Items.Clear();
                    catagoryDropDownList.DataSource = catagoryManager.GetAllCatagory();
                    catagoryDropDownList.DataTextField = "Catagory";
                    catagoryDropDownList.DataValueField = "Id";
                    catagoryDropDownList.DataBind();
                    catagoryDropDownList.Items.Insert(0, new ListItem("---Catagory---", "0"));
                    catagoryDropDownList.SelectedIndex = 0;
                }
            }
        }
















    }
}