namespace FoodApp.Models
{
    using System;
    using System.Configuration;

    public class BaseDTO
    {
        public int CompanyIdentifier 
        {
            get
            {
                return ConfigurationManager.AppSettings["CompanyIdentifier"] != null ?
                    Convert.ToInt32(ConfigurationManager.AppSettings["CompanyIdentifier"]) :
                    default(int);
            }
        }
    }
}
