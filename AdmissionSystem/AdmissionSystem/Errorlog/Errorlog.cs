using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdmissionSystem
{
    public class Errorlog
    {
        private static readonly string logFilePath = "D:\\AdmissionSystem\\AdmissionSystem\\Errorlog";

        public static void LogError(Exception ex)
        {
            string logMessage = $"Timestamp: {DateTime.Now} - Error: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";
            File.AppendAllText(logFilePath, logMessage);
        }
    }
}
