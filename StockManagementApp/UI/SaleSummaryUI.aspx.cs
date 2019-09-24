using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementApp.BLL;
using StockManagementApp.DAL.Models.ViewModel;

namespace StockManagementApp.UI
{
    public partial class SaleSummaryUI : System.Web.UI.Page
    {
        SearchViewModelManager SearchViewModelManager = new SearchViewModelManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchByDate_Click(object sender, EventArgs e)
        {
            if (fromDateTextBox.Value == "")
            {
                ErrorLabelFrom.Text = "Please Select Date";
            }
            else if (toDateTextBox.Value == "")
            {
                ErrorLabelTo.Text = "Please Select Date";
            }
            else if (Convert.ToDateTime(fromDateTextBox.Value)>Convert.ToDateTime(toDateTextBox.Value))
            {
                ErrorLabelFrom.Text = "Select Previus Date";
            }
            else
            {
                DateTime Fromdate = Convert.ToDateTime(fromDateTextBox.Value);
                DateTime ToDate = Convert.ToDateTime(toDateTextBox.Value);
                searchByDateGridView.DataSource = SearchViewModelManager.SearchViewByTwoDate(Fromdate, ToDate);
                searchByDateGridView.DataBind();
            }
          

        }
    }
}