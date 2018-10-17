using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Xml;
using RedemptionData;
using ApplicationServices;

namespace RedemptionAdmin
{
    /// <summary>
    /// Summary description for EmailManager
    /// </summary>
    public class EmailManager
    {

        public EmailManager()
        {

        }
        public static Dictionary<int, Dictionary<string, string>> ClientEmailConfig = new Dictionary<int, Dictionary<string, string>>();

        //  public static Dictionary<string, string> emailconfig = new Dictionary<string, string>();

        public static void LoadClientEmailValues(HttpResponse httpResponse)
        {

            List<Client> clientlist = ClientManager.getAllClients();
            foreach (Client c in clientlist)
            {
                try
                {
                    EmailManager.ClientEmailConfig.Remove(c.clientid);
                    Dictionary<string, string> emailconfig = new Dictionary<string, string>();
                    EmailManager.ClientEmailConfig.Add(c.clientid, emailconfig);

                    emailconfig.Clear();
                    int el = 0;

                    string path = ConfigurationManager.AppSettings["PhysicalClientRootPath"]
                        + c.emailphysicalpath + "\\email\\config.xml";

                   // httpResponse.Write(path + "<br/><br/>");
                    // Read a document
                    XmlTextReader textReader = new XmlTextReader(path);
                    //XmlTextReader textReader = new XmlTextReader("C:\\Data\\Edwin Solutions\\Letrain Site\\source\\VSSolution2010\\Redemption\\Email\\config.xml");
                    // Read until end of file
                    while (textReader.Read())
                    {
                        XmlNodeType nType = textReader.NodeType;
                        // if node type is an element
                        if (nType == XmlNodeType.Element)
                        {
                            Console.WriteLine("Element:" + textReader.Name.ToString());
                            if (textReader.Name.Equals("add"))
                            {
                                string key = textReader.GetAttribute("key");
                                string value = textReader.GetAttribute("value");

                                emailconfig.Add(key, value);
                            }
                            el = el + 1;
                        }

                    }
                    textReader.Close();
                    // Write the summary
                   httpResponse.Write("Total Elements:" + el.ToString() + "<br/><br/>");
                    Console.WriteLine("Total Elements:" + el.ToString());

                }
                catch (Exception eee)
                {
                    //httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");

                    Logger.Log(eee, typeof(EmailManager));
                }
            }

         //   httpResponse.Write("Count" + ClientEmailConfig.Count);
        }

        #region Client Emails  All need to change to retrieve html,txt , subject from DB or xml file

        #region SendClientResetPasswordMail
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendClientResetPasswordMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }
                Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];

                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailPasswordResetSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailPasswordResetTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailPasswordResetHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }
        #endregion

        #region Claim point approval email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendClaimPointApprovalMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }

                Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];

                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailClaimPointApprovalSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailClaimPointApprovalTxt"]);
       
                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion
         
                #region build Html text view

                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailClaimPointApprovalHtml"]);
                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
         
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                // httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");

                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }

        #endregion
        #region Claim point Ack email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendClaimPointAckMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                 if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                } Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
              
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailClaimPointAckSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailClaimPointAckTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view

                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailClaimPointAckHtml"]);
                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                //httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }

        #endregion
        #region  RedemptionByProducts Delivery email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendRedemptionByProductsDeliveryMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                } Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
               
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByProductsDeliverySubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format
                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailRedemptionByProductsDeliveryTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailRedemptionByProductsDeliveryHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                // httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static string getRedemptionByProductsDeliveryMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            string output = "NA";
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                 if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                } Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
              
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByProductsDeliverySubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format
                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailRedemptionByProductsDeliveryTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailRedemptionByProductsDeliveryHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                //SmtpClient smtp = new SmtpClient();
                //smtp.Send(Mail);
                output = mailHtml;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                // httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return output;
        }

        #endregion

        #region  RedemptionByProducts SelfCollect email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendRedemptionByProductsSelfCollectMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }
                Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
              
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByProductsSelfCollectSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailRedemptionByProductsSelfCollectTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailRedemptionByProductsSelfCollectHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                // httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static string getRedemptionByProductsSelfCollectMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
           // httpResponse.Write("x0");
            string output = "NA";
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = ""; //httpResponse.Write("x0.2");
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                   // httpResponse.Write("x0.1");
                }
                Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
              //  httpResponse.Write("EmailManager.ClientEmailConfig.Count" + EmailManager.ClientEmailConfig.Count); 
                
              

              //  httpResponse.Write("x1");
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByProductsSelfCollectSubject"];
                httpResponse.Write("x2");
                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailRedemptionByProductsSelfCollectTxt"]);
              //  httpResponse.Write("x3");
                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion
               // httpResponse.Write("x4");
                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailRedemptionByProductsSelfCollectHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
              //  httpResponse.Write("x5");
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                //SmtpClient smtp = new SmtpClient();
                //smtp.Send(Mail);
                output = mailHtml;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                // httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return output;
        }
        #endregion

        #region  RedemptionByPoints Delivery email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendRedemptionByPointsDeliveryMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                } Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
               
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByPointsDeliverySubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailRedemptionByPointsDeliveryTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailRedemptionByPointsDeliveryHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                // httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }


        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static string getRedemptionByPointsDeliveryMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            string output = "NA";
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                } Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
              
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByPointsDeliverySubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailRedemptionByPointsDeliveryTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                        + emailconfig["EmailRedemptionByPointsDeliveryHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                //SmtpClient smtp = new SmtpClient();
                //smtp.Send(Mail);
                output = mailHtml;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                // httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return output;
        }
        #endregion

        #region  RedemptionByPoints SelfCollect email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendRedemptionByPointsSelfCollectMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                } Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
              
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByPointsSelfCollectSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailRedemptionByPointsSelfCollectTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view
                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                                       + emailconfig["EmailRedemptionByPointsSelfCollectHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                //httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }


        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static string getRedemptionByPointsSelfCollectMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, int clientid, HttpResponse httpResponse)
        {
            string output = "NA";
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.ClientEmailConfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                } Dictionary<string, string> emailconfig = EmailManager.ClientEmailConfig[clientid];
             
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByPointsSelfCollectSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                       + emailconfig["EmailRedemptionByPointsSelfCollectTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view
                mailHtml = System.IO.File.ReadAllText(emailconfig["EmailPath"]
                                       + emailconfig["EmailRedemptionByPointsSelfCollectHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                //SmtpClient smtp = new SmtpClient();
                //smtp.Send(Mail);
                //success = true;
                output = mailHtml;
            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");
                //httpResponse.Write("inner:" + eee.InnerException.ToString() + "<br/><br/>");
                Logger.Log(eee, typeof(EmailManager));
            }
          //  return success;
            return output;
        }
        #endregion

        #endregion

        /*
        #region Claim point ack email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendClaimPointAckMail(string toEmail, string toDisplayname, Hashtable replaceValues)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                //setup email
                Mail.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = ConfigurationManager.AppSettings["EmailClaimPointAckSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + ConfigurationManager.AppSettings["EmailFolder"]
                       + ConfigurationManager.AppSettings["EmailClaimPointAckTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + ConfigurationManager.AppSettings["EmailFolder"]
                        + ConfigurationManager.AppSettings["EmailClaimPointAckHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }

        #endregion

        #region Claim product ack email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendClaimProductAckMail(string toEmail, string toDisplayname, Hashtable replaceValues)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                //setup email
                Mail.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = ConfigurationManager.AppSettings["EmailClaimProductAckSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + ConfigurationManager.AppSettings["EmailFolder"]
                       + ConfigurationManager.AppSettings["EmailClaimProductAckTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + ConfigurationManager.AppSettings["EmailFolder"]
                        + ConfigurationManager.AppSettings["EmailClaimProductAckHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }

        #endregion
        */

        #region Web Portalemails
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendResetPasswordMailWeb(string toEmail, string toDisplayname, Hashtable replaceValues)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                //setup email
                Mail.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = ConfigurationManager.AppSettings["EmailPasswordResetSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + ConfigurationManager.AppSettings["EmailFolder"]
                       + ConfigurationManager.AppSettings["EmailPasswordResetTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + ConfigurationManager.AppSettings["EmailFolder"]
                        + ConfigurationManager.AppSettings["EmailPasswordResetHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }

        /// <summary>
        /// Send Password set Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SetPasswordMailWeb(string toEmail, string toDisplayname, Hashtable replaceValues)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                //setup email
                Mail.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = ConfigurationManager.AppSettings["EmailSetPasswordSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + ConfigurationManager.AppSettings["EmailFolder"]
                        + ConfigurationManager.AppSettings["EmailSetPasswordTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + ConfigurationManager.AppSettings["EmailFolder"]
                        + ConfigurationManager.AppSettings["EmailSetPasswordHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion

                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }
        #endregion



        #region helper

        public static bool SendMail(String toName, String toMailAddress, String subject, String body)
        {
            bool success = false;
            try
            {
                MailMessage Mail = new MailMessage();
                Mail.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromName"]);
                Mail.To.Add(new MailAddress(toMailAddress, toName));
                Mail.Subject = subject;
                Mail.Body = body;

                //send the message
                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }
        public static bool SendMail(string FromName, string fromMailAddress, String toName, String toMailAddress, String subject, String body)
        {
            bool success = false;
            try
            {
                MailMessage Mail = new MailMessage();
                Mail.From = new MailAddress(fromMailAddress, FromName);
                Mail.To.Add(new MailAddress(toMailAddress, toName));
                Mail.Subject = subject;
                Mail.Body = body;

                //send the message
                SmtpClient smtp = new SmtpClient();
                smtp.Send(Mail);
                success = true;
            }
            catch (Exception eee)
            {
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }

        #endregion



    }
}