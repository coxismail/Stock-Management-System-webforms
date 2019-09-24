using System;
using System.Web.UI.WebControls;
using StockManagementApp.BLL;
using StockManagementApp.DAL.Model;
using StockManagementApp.DAL.Models;


namespace StockManagementApp.UI
{
   
    public partial class CatagoryUI : System.Web.UI.Page 
    {
        private CatagoryManager CatagoryManager = new CatagoryManager();      
        protected void Page_Load(object sender, EventArgs e)
        {
            CatagoryListGridVew.DataSource = CatagoryManager.GetAllCatagory();
            CatagoryListGridVew.DataBind();
        }

        protected void catagroySavebutton_Click(object sender, EventArgs e)
        {
            if (catagotyTextBox.Text.Trim() == "")
            {
                outputlabel.InnerHtml = "Please Provide a vailed Catagory";
            }
            else
            {
                CatagoryModel catagoryRelator = new CatagoryModel();
             
                catagoryRelator.Catagory = catagotyTextBox.Text;
                string message = CatagoryManager.catagorySave(catagoryRelator);
                outputlabel.InnerHtml = message;
                CatagoryListGridVew.DataSource = CatagoryManager.GetAllCatagory();
                CatagoryListGridVew.DataBind();
            }

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            DataControlFieldCell cell = linkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField hiddenField = row.FindControl("hiddenfieldID") as HiddenField;
            int id = Convert.ToInt32(hiddenField.Value);
            Response.Redirect("CatagoryUpdate.aspx?Id="+hiddenField.Value);
            //Response.Write(hiddenField.Value);

        }


        protected void DeleteAction_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            DataControlFieldCell cell = linkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField hiddenField = row.FindControl("hiddenfieldID") as HiddenField;
            int id = Convert.ToInt32(hiddenField.Value);
            CatagoryManager.DeleteCatagoryByID(id);
            //Response.Redirect("CatagoryUpdate.aspx?Id=" + hiddenField.Value);
            CatagoryListGridVew.DataSource = CatagoryManager.GetAllCatagory();
            CatagoryListGridVew.DataBind();
            //Response.Write(hiddenField.Value);
        }
    }
}