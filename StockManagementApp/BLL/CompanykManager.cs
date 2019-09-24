using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using StockManagementApp.DAL.Gateway;
using StockManagementApp.DAL.Model;

namespace StockManagementApp.BLL
{

    public class CompanykManager
    {

      


        // Company Code start from here
       private CompanyGateway companyGateway = new CompanyGateway();
       public String companySave(CompanyModel companyRelator)
        {
            if (companyGateway.IsExists(companyRelator.Company))
            {
                return "* Company Name Alredy Exist";
            }
            else
            {
                int rowAffect1 = companyGateway.save(companyRelator);
                if (rowAffect1 > 0)
                {
                    return "Company Setup seccesfull";
                }
                else
                {
                    return "Data Not Saved Try again";
                }
            }

           
        }
        // Query to show in Gried view
       public List<CompanyModel> GetAllCompany()
        {
            return companyGateway.GetAllCompany();
        }

      

    }
}