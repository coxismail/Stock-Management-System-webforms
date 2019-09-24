using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementApp.DAL.Gateway;
using StockManagementApp.DAL.Models.ViewModel;

namespace StockManagementApp.BLL
{
    public class SearchViewModelManager
    {


        SearchViewGateway searchViewGateway = new SearchViewGateway();


        public List<SearchViewModel> GetAllSearchResult(int companyID, int categoryID)
        {
            return searchViewGateway.GetTotalItems(companyID, categoryID);
        }


        public List<SearchViewModel> GetResultsByCompanyID(int companyID)
        {
            return searchViewGateway.SearchViewByCompanyID(companyID);
        }

        public List<SearchViewModel> GetRsultsByCategoryID(int categoryID)
        {
            return searchViewGateway.SearchViewByCategoryID(categoryID);
        }
        // Code for search without conditon
        public List<SearchViewModel> GetTotalItemsWithoutCondition()
        {
            return searchViewGateway.GetTotalItemsWithoutCondition();
        }

        //Search by Two date
        public List<SearchViewModel> SearchViewByTwoDate(DateTime FromDate, DateTime ToDate)
        {
            return searchViewGateway.SearchViewBytwoDate(FromDate, ToDate);
        }



    }
}