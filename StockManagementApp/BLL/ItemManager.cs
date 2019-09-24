using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementApp.DAL.Gateway;
using StockManagementApp.DAL.Models;

namespace StockManagementApp.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway = new ItemGateway();
        public string Save(ItemModel itemRelator)
        {

            if (itemGateway.IsExists(itemRelator))
            {
                return "Item is Already Exist";
            }
            else
            {
                int rowAffect = itemGateway.Save(itemRelator);
                if (rowAffect > 0)
                {
                    return "Item Setup successfull";
                }
                else
                {
                    return "Item Did not setup successfully";
                }
   
            }

        }

        public List<ItemModel> GetItemById(int id)
        {
            return itemGateway.GetItemsByID(id);
        }

        public ItemModel GetAllItemsByID(int Id)
        {
            return itemGateway.GetAllItemsByID(Id);
        }


        public String StockIn(ItemModel stockIn)
        {
            int rowAffect = itemGateway.StockIn(stockIn);
            if (rowAffect > 0)
            {
                return "Stock In successfull";
            }
            else
            {
                return "Stock In Not successfully, Try Again";
            }
        }

        // for stock out update
        public string Update(int itemId, int quantity)
        {
            int availablequantity = itemGateway.GetStockAQById(itemId);
            availablequantity -= quantity;
            ItemModel stockIn = new ItemModel();
            stockIn.Id = itemId;
            stockIn.StockAQ = availablequantity;

            int rowAffect = itemGateway.Update(stockIn);
            if (rowAffect > 0)
            {
                return "Update Successful";
            }
            else
            {
                return "Update Failed";
            }
        }
    }
}