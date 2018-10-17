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

namespace Redemption
{
    /// <summary>
    /// Summary description for EmailManager
    /// </summary>
    public class EmailManager
    {

        public EmailManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static Dictionary<string, string> emailconfig = new Dictionary<string, string>();

        public static void LoadClientEmailValues(HttpResponse httpResponse)
        {

            //List<Client> clientlist = ClientManager.getAllClients();
            //foreach (Client c in clientlist)
            //{
            //  Client c = 
            try
            {
                EmailManager.emailconfig.Clear();
                Dictionary<string, string> emailconfig = EmailManager.emailconfig;
                //  EmailManager.ClientEmailConfig.Add(c.clientid, emailconfig);

                emailconfig.Clear();
                int el = 0;

                string path = ConfigurationManager.AppSettings["RootPhysicalFolderPath"]
                    + "\\email\\config.xml";

              //  httpResponse.Write(path + "<br/><br/>");
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
              //  httpResponse.Write("Total Elements:" + el.ToString() + "<br/><br/>");
                Console.WriteLine("Total Elements:" + el.ToString());

            }
            catch (Exception eee)
            {
                httpResponse.Write("Exceptions:" + eee.ToString() + "<br/><br/>");

                Logger.Log(eee, typeof(EmailManager));
            }
            // }

            // httpResponse.Write("Count" + ClientEmailConfig.Count);
        }
        #region Signup ack email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendSignUpMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.emailconfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }
                Dictionary<string, string> emailconfig = EmailManager.emailconfig;
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailSignUpSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + emailconfig["EmailFolder"]
                       + emailconfig["EmailSignUpTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + emailconfig["EmailFolder"]
                        + emailconfig["EmailSignUpHtml"]);

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

        #region Claim point ack email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendClaimPointAckMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
              //  httpResponse.Write("1");
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";// httpResponse.Write("2");
                if (EmailManager.emailconfig.Count == 0)
                {
                   // httpResponse.Write("3");
                    EmailManager.LoadClientEmailValues(httpResponse);
                } //httpResponse.Write("4");
                Dictionary<string, string> emailconfig = EmailManager.emailconfig;
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));
               // httpResponse.Write("5");
                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailClaimPointAckSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;
               // httpResponse.Write("6");
                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + emailconfig["EmailFolder"]
                       + emailconfig["EmailClaimPointAckTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                } //httpResponse.Write("7");
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + emailconfig["EmailFolder"]
                        + emailconfig["EmailClaimPointAckHtml"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailHtml = mailHtml.Replace(Key.ToString(), replaceValues[Key].ToString());
                }

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailHtml, null, "text/html");
                Mail.AlternateViews.Add(htmlView);
                Mail.IsBodyHtml = true;
                #endregion
               // httpResponse.Write("8");
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
        public static bool SendClaimProductAckMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.emailconfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }
                Dictionary<string, string> emailconfig = EmailManager.emailconfig;
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailClaimProductAckSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + emailconfig["EmailFolder"]
                       + emailconfig["EmailClaimProductAckTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + emailconfig["EmailFolder"]
                        + emailconfig["EmailClaimProductAckHtml"]);

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

        #region  RedemptionByPoints Delivery email
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendRedemptionByPointsDeliveryMail(string toEmail, string toDisplayname,
            Hashtable replaceValues, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.emailconfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }
                Dictionary<string, string> emailconfig = EmailManager.emailconfig;
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByPointsDeliverySubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + emailconfig["EmailFolder"]
                       + emailconfig["EmailRedemptionByPointsDeliveryTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + emailconfig["EmailFolder"]
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
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
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
            Hashtable replaceValues, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.emailconfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }
                Dictionary<string, string> emailconfig = EmailManager.emailconfig;
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailRedemptionByPointsSelfCollectSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + emailconfig["EmailFolder"]
                       + emailconfig["EmailRedemptionByPointsSelfCollectTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + emailconfig["EmailFolder"]
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
                Logger.Log(eee, typeof(EmailManager));
            }
            return success;
        }

        #endregion

        #region Web Portalemails
        /// <summary>
        /// Send  Password Reset Email 
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="toDisplayname"></param>
        /// <param name="replaceValues"></param>
        /// <returns></returns>
        public static bool SendResetPasswordMailWeb(string toEmail, string toDisplayname,
            Hashtable replaceValues, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.emailconfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }
                Dictionary<string, string> emailconfig = EmailManager.emailconfig;
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["EmailPasswordResetSubject"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                       + emailconfig["EmailFolder"]
                       + emailconfig["EmailPasswordResetTxt"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + emailconfig["EmailFolder"]
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
        public static bool SetPasswordMailWeb(string toEmail, string toDisplayname,
            Hashtable replaceValues, HttpResponse httpResponse)
        {
            bool success = false;
            try
            {
                //Setting the mail, from email and to email
                MailMessage Mail = new MailMessage();
                string mailTxt = "";
                string mailHtml = "";
                if (EmailManager.emailconfig.Count == 0)
                {
                    EmailManager.LoadClientEmailValues(httpResponse);
                }
                Dictionary<string, string> emailconfig = EmailManager.emailconfig;
                //setup email
                Mail.From = new MailAddress(emailconfig["FromEmail"], emailconfig["FromName"]);
                Mail.To.Add(new MailAddress(toEmail, toDisplayname));

                //Get Reset password email setting
                Mail.Subject = emailconfig["SetPasswordSubjectWeb"];

                ICollection replaceValuesKeys = replaceValues.Keys;

                #region build text view format

                mailTxt = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + emailconfig["EmailFolder"]
                        + emailconfig["SetPasswordTxtWeb"]);

                foreach (object Key in replaceValuesKeys)
                {
                    mailTxt = mailTxt.Replace(Key.ToString(), replaceValues[Key].ToString());
                }
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailTxt, null, "text/plain");
                Mail.AlternateViews.Add(plainView);
                #endregion

                #region build Html text view


                mailHtml = System.IO.File.ReadAllText(System.AppDomain.CurrentDomain.BaseDirectory
                        + emailconfig["EmailFolder"]
                        + emailconfig["SetPasswordHtmlWeb"]);

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