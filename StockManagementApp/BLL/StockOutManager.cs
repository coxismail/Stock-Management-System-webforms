using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using StockManagementApp.DAL.Gateway;
using StockManagementApp.DAL.Models;
using StockManagementApp.DAL.Models.ViewModel;

namespace StockManagementApp.BLL
{
    public class StockOutManager
    {


        StockOutGateway stockOutGateway = new StockOutGateway();
        ItemGateway itemGateway = new ItemGateway();
        public string StockOut(StockOutModel stockout)
        {

            int rowAffect = stockOutGateway.StockOut(stockout);


            if (rowAffect > 0)
            {
                return "Save Successful";
            }
            else
            {
                return "Save Failed";
            }

        }







    }
}