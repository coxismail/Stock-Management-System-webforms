using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementApp.BLL;
using StockManagementApp.DAL.Model;
using StockManagementApp.DAL.Models;

namespace StockManagementApp.UI
{
    public partial class CatagoryUpdate : System.Web.UI.Page
    {
        CatagoryManager catagoryManager = new CatagoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            int Id = Convert.ToInt32(Request.QueryString["Id"]);
            //Response.Write(Id);
            CatagoryModel catagoryRelator = catagoryManager.GetCatagoryByID(Id);

                if (catagoryRelator != null)
                {
                    hiddenFieldID.Value = Convert.ToString(catagoryRelator.Id);
                    catagotyTextBox.Text = catagoryRelator.Catagory;
                    hiddenFieldID.Value = catagoryRelator.Id.ToString();
                }


            }
         

        }

        protected void catagroyUpdateButton_Click(object sender, EventArgs e)
        {
            if (catagotyTextBox.Text.Trim() == "")
            {
                outputlabel.InnerHtml = "Please Provide a vailed Catagory";
            }
            else
            {
                CatagoryModel catagoryRelator = new CatagoryModel();
                catagoryRelator.Id = Convert.ToInt32(hiddenFieldID.Value);
                catagoryRelator.Catagory = catagotyTextBox.Text;
                string message = catagoryManager.catagoryUpdate(catagoryRelator);
                outputlabel.InnerHtml = message;
                if (outputlabel.InnerHtml.Contains("Catagory Update Seccesfull"))
                {
                    Response.Redirect("CatagoryUI.aspx");
                }
            }
        }








    }
}