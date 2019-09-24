using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementApp.DAL.Models.ViewModel
{
    public class SearchViewModel
    {
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public int Reorder { get; set; }
        public int Quantity { get; set; }
    }
}