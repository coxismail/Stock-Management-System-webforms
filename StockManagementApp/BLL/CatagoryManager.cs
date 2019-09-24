using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementApp.DAL.Gateway;
using StockManagementApp.DAL.Model;
using StockManagementApp.DAL.Models;

namespace StockManagementApp.BLL
{
    public class CatagoryManager
    {
        //Catagory Code goes grom here
        private catagoryGateway catagoryGateway = new catagoryGateway();
        public string catagorySave(CatagoryModel catagoryRelator)
        {

            if (catagoryGateway.IsExists(catagoryRelator.Catagory))
            {
                return "* Catagroy Name Alredy Exist";
            }
            else
            {
                int rowAffect = catagoryGateway.save(catagoryRelator);
                if (rowAffect > 0)
                {
                    return "Catagory setup Seccesfull";
                }
                else
                {
                    return "*Data Not Saved Try Again";
                }
            }


        }
        public string catagoryUpdate(CatagoryModel catagoryRelator)
        {

            if (catagoryGateway.IsExists(catagoryRelator.Catagory))
            {
                return "* Catagroy Name Alredy Exist Try Different Name";
            }
            else
            {
                int rowAffect = catagoryGateway.Update(catagoryRelator);
                if (rowAffect > 0)
                {
                    return "Catagory Update Seccesfull";
                }
                else
                {
                    return "*Catagory Does Not Updated";
                }
            }


        }



        public CatagoryModel DeleteCatagoryByID(int Id)
        {
            return catagoryGateway.DeleteCatagoryByID(Id);
        }

        public CatagoryModel GetCatagoryByID(int Id)
        {
            return catagoryGateway.GetCatagoryByID(Id);
        }
        // Query to show in Gried view
        public List<CatagoryModel> GetAllCatagory()
        {
            return catagoryGateway.GetAllCatagory();

        }

        //Catagory page completed here

    }
}