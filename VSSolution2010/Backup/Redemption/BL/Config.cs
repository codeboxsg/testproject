using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Redemption
{
    public class Config
    {
        public static int ClientId
        {
            get { return int.Parse(ConfigurationManager.AppSettings.Get("ClientId")); }
        }

        public static string SiteRootUrl
        {
            get { return ConfigurationManager.AppSettings.Get("SiteRootUrl"); }
        }public static string UploadInvoiceRelativePath
        {
            get { return ConfigurationManager.AppSettings.Get("UploadInvoiceRelativePath"); }
        }

        public static string loginUrl
        {
            get { return ConfigurationManager.AppSettings.Get("loginUrl"); }
        }
        //public static string EmailLogoUrl
        //{
        //    get { return ConfigurationManager.AppSettings.Get("EmailLogoUrl"); }
        //}
        public static string UploadInvoiceVirtualPath
        {
            get { return ConfigurationManager.AppSettings.Get("UploadInvoiceVirtualPath"); }
        }
        public static string EventRelativePath
        {
            get { return ConfigurationManager.AppSettings.Get("EventRelativePath"); }
        }
        public static string PromoRelativePath
        {
            get { return ConfigurationManager.AppSettings.Get("PromoRelativePath"); }
        }
        public static string InvoiceRelativePath
        {
            get { return ConfigurationManager.AppSettings.Get("InvoiceRelativePath"); }
        }

        public static string RewardRelativePath
        {
            get { return ConfigurationManager.AppSettings.Get("RewardRelativePath"); }
        }
        public static string RootRelativePath
        {
            get { return ConfigurationManager.AppSettings.Get("RootRelativePath"); }
        }


    }
}