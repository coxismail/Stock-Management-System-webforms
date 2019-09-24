using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using StockManagementApp.BLL;
using System.Web.UI.WebControls;

namespace StockManagementApp.UI
{
    public partial class SearchAndView : System.Web.UI.Page
    {
        SearchViewModelManager SearchViewModelManager = new SearchViewModelManager();
      
        CompanykManager companykManager = new CompanykManager();
        CatagoryManager catagoryManager =new CatagoryManager();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                companyDropDownList.DataSource = companykManager.GetAllCompany();
                companyDropDownList.DataTextField = "Company";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("---Company---", "0"));

                catagoryDropDownList.DataSource = catagoryManager.GetAllCatagory();
                catagoryDropDownList.DataTextField = "Catagory";
                catagoryDropDownList.DataValueField = "Id";
                catagoryDropDownList.DataBind();
                catagoryDropDownList.Items.Insert(0, new ListItem("---Catagory---", "0"));
                catagoryDropDownList.SelectedIndex = 0;


            }
        }

        protected void searchViewButton_Click(object sender, EventArgs e)
        {



            if (companyDropDownList.SelectedItem.ToString() == "---Company---" && catagoryDropDownList.SelectedItem.ToString() != "---Catagory---")
            {

                int categoryID = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                searchGridView.DataSource = SearchViewModelManager.GetRsultsByCategoryID(categoryID);
                searchGridView.DataBind();
             
            }
            else if (companyDropDownList.SelectedItem.ToString() != "---Company---" && catagoryDropDownList.SelectedItem.ToString() == "---Catagory---")
            {
                int companyID = Convert.ToInt32(companyDropDownList.SelectedValue);
                searchGridView.DataSource = SearchViewModelManager.GetResultsByCompanyID(companyID);
                searchGridView.DataBind();
              
            }
            else if (companyDropDownList.SelectedItem.ToString() == "---Company---" && catagoryDropDownList.SelectedItem.ToString() == "---Catagory---")
            {
                searchGridView.DataSource = SearchViewModelManager.GetTotalItemsWithoutCondition();
                searchGridView.DataBind();
             
            }
            else
            {
                int companyID = Convert.ToInt32(companyDropDownList.SelectedValue);
                int categoryID = Convert.ToInt32(catagoryDropDownList.SelectedValue);
                searchGridView.DataSource = SearchViewModelManager.GetAllSearchResult(companyID, categoryID);
                searchGridView.DataBind();
         
            }

        }


      
    }
}