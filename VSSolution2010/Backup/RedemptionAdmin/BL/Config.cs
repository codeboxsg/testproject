using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace RedemptionAdmin
{
    public class Config
    {
        public static string MainSiteRootUrl
        {
            get { return ConfigurationManager.AppSettings.Get("MainSiteRootUrl"); }
        }
        public static string AdminSiteRootUrl
        {
            get { return ConfigurationManager.AppSettings.Get("AdminSiteRootUrl"); }
        }
        public static string PhysicalClientRootPath
        {
            get { return ConfigurationManager.AppSettings.Get("PhysicalClientRootPath"); }
        }
        
        //public static string xxEmailLogoUrl
        //{
        //    get { return ConfigurationManager.AppSettings.Get("EmailLogoUrl"); }
        //}
        public static string UploadInvoiceRelativePath
        {
            get { return ConfigurationManager.AppSettings.Get("UploadInvoiceRelativePath"); }
        }

        public static string UploadInvoiceVirtualPath
        {
            get { return ConfigurationManager.AppSettings.Get("UploadInvoiceVirtualPath"); }
        }
        public static string UploadPromoVirtualPath
        {
            get { return ConfigurationManager.AppSettings.Get("UploadPromoVirtualPath"); }
        }
        public static string UploadRewardVirtualPath
        {
            get { return ConfigurationManager.AppSettings.Get("UploadRewardVirtualPath"); }
        }
        public static string UploadEventVirtualPath
        {
            get { return ConfigurationManager.AppSettings.Get("UploadEventVirtualPath"); }
        }
        public static string RootPhysicalFolderPath
        {
            get { return ConfigurationManager.AppSettings.Get("RootPhysicalFolderPath"); }
        }
        public static string RewardRelativePath
        {
            get { return ConfigurationManager.AppSettings.Get("RewardRelativePath"); }
        }
        
        
    }
}