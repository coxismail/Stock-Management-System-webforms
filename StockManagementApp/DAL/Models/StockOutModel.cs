using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementApp.DAL.Models
{
    public class StockOutModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Company { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}