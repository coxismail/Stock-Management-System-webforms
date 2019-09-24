using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementApp.DAL.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public int CatagoryID { get; set; }
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public int Reorder { get; set; }
        public int StockAQ { get; set; }
    }
}