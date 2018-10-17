using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

using log4net;

namespace Redemption
{
    /// <summary>
    /// Log4net wrapper
    /// Threshold
    /// 
    /// DEBUG - entries for debugging purposes (no action
    /// INFO - entries for monthly review/maintanence of db data with what happened in the server
    /// WARN - Exceptions are recorded here ( to be fixed in the next release)
    /// ERROR - Functions did not work but site is still alive (To be fixed within 1 day) 
    /// FATAL - Major site functions not working e.g. loading of application settings failed (Requires immediate fix)
    /// </summary>
    public class Logger
    {
        public static void LoadConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Log ERROR
        /// File location is specified in the app config
        /// Logging the exception typeof(Logger)
        /// </summary>
        /// <param name="eec"></param>
        public static void Log(Exception ex, Type aType)
        {
            ILog log = LogManager.GetLogger(aType);
            string message = "";
            try
            {
                ////log the details of the exception and page state to the
                message = "\r\nMESSAGE: " + ex.Message +
                   "\r\nTARGETSITE: " + ex.TargetSite +
                   "\r\nSTACKTRACE: " + ex.StackTrace +
                   "\r\nError Time(Server Time):" + DateTime.UtcNow.ToString();

                log.Error("Error:\r\n" + message + "\r\n", ex);
            }
            catch (Exception Logee)
            {
                try
                {
                    EmailLog(message, Logee);
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// Log a text to the file 
        /// File location is specified in the app config
        /// Logging the exception
        /// </summary>
        /// <param name="eec"></param>
        public static void Log(string ErrorMessge, Type aType)
        {
            ILog log = LogManager.GetLogger(aType);
            string message = ErrorMessge;
            try
            {
                ////log the details of the exception and page state to the
                message = message +
                   "\r\nError Time(Server Time):" + DateTime.UtcNow.ToString();
                log.Error("Error:\r\n" + message + "\r\n");
            }
            catch (Exception Logee)
            {
                try
                {
                    EmailLog(message, Logee);
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// Log a text to the file 
        /// File location is specified in the app config
        /// Logging information
        /// </summary>
        /// <param name="eec"></param>
        public static void LogInfo(string message, Type aType)
        {
            ILog log = LogManager.GetLogger(aType);
            try
            {

                log4net.Config.XmlConfigurator.Configure();
                log.Info(message);
            }
            catch (Exception Logee)
            {
                try
                {
                    EmailLog(message, Logee);
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Log a text to the file 
        /// File location is specified in the app config
        /// Logging the exception
        /// </summary>
        /// <param name="eec"></param>
        public static void LogDebug(string message, Type aType)
        {
            ILog log = LogManager.GetLogger(aType);
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Debug(message);
            }
            catch (Exception Logee)
            {
                try
                {
                    EmailLog(message, Logee);
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// Log a text to the file 
        /// File location is specified in the app config
        /// Logging information
        /// </summary>
        /// <param name="eec"></param>
        public static void LogWarn(string message, Type aType)
        {
            ILog log = LogManager.GetLogger(aType);
            try
            {

                log4net.Config.XmlConfigurator.Configure();
                log.Warn(message);
            }
            catch (Exception Logee)
            {
                try
                {
                    EmailLog(message, Logee);
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// Log a text to the file 
        /// File location is specified in the app config
        /// Logging information
        /// </summary>
        /// <param name="eec"></param>
        public static void LogFatal(string message, Type aType)
        {
            ILog log = LogManager.GetLogger(aType);
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Fatal(message);
            }
            catch (Exception Logee)
            {
                try
                {
                    EmailLog(message, Logee);
                }
                catch
                {

                }
            }
        }
        private static void EmailLog(string message, Exception Logee)
        {
            //string ee = "";
            string ErrorMsg = "Log Error Msg = " +
                "\r\nMESSAGE: " + Logee.Message +
               "\r\nTARGETSITE: " + Logee.TargetSite +
               "\r\nSTACKTRACE: " + Logee.StackTrace +
               "\r\nError Time(Server Time):" + DateTime.UtcNow.ToString() +
               "\r\n \r\n Original Debug Msg = " + message;
            //EmailManager.SendMail("Eventsnap App", "eventsnap@gmail.com", "Debug Logging Failure", ErrorMsg);
        }

    }
}