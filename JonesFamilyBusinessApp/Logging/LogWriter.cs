using System;
using System.IO;

namespace JonesFamilyBusinessApp.Logging
{
    /// <summary>
    /// Manages the logging. When something failed, the error must be logged using this class
    /// </summary>
    public class LogWriter
    {
        // Log Path: must be set in Web.config
        private string logPath
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings.Get("logpath");
            }
        }

        #region Singleton
        private static LogWriter _instance { get; set; }
        private LogWriter() { }

        public static LogWriter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LogWriter();
                }
                return _instance;
            }
        }
        #endregion

        // Public method to write log. Create file if not exists
        public void LogWrite(string logMessage)
        {
            try
            {
                using (StreamWriter w = File.AppendText(logPath))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        //Writes text in textwriter with mark time
        private void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}