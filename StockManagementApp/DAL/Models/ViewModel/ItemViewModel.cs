using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementApp.DAL.Models.ViewModel
{
[Serializable]
    public class ItemViewModel
    {
        
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int Reorder { get; set; }
    public int StockAQQuantity { get; set; }
        public DateTime StockOutDate { get; set; }
    
    }
}