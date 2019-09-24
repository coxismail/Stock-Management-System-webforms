using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementApp.BLL;
using StockManagementApp.DAL.Model;


namespace StockManagementApp.UI
{
    public partial class CompanyUI : System.Web.UI.Page
    {
       private CompanykManager CompanyManager = new CompanykManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CompanyListGridVew.DataSource = CompanyManager.GetAllCompany();
            CompanyListGridVew.DataBind();
        }

        protected void companySavebutton_Click(object sender, EventArgs e)
        {
            if (companyTextBox.Text.Trim() == "")
            {
                outputlabel.InnerHtml = "Please Provide a Company Name";
            }
            else
            {
                CompanyModel companyRelator = new CompanyModel();
                companyRelator.Company = companyTextBox.Text;
                String message = CompanyManager.companySave(companyRelator);
                outputlabel.InnerHtml = message;
                CompanyListGridVew.DataSource = CompanyManager.GetAllCompany();
                CompanyListGridVew.DataBind();
            }
            

        }
    }
}