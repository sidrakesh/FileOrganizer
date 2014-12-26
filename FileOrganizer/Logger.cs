using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Log
{
    class Logger
    {
        public void SuccessLog(string toLog)
        {
            checkLogFileAndFolder();

            string timeString = getTimeString();

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(timeString + " [SUCCESS]  " + toLog);
            }
        }

        public void ErrorLog(Exception e)
        {
            checkLogFileAndFolder();

            string timeString = getTimeString();

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(timeString + " [ERROR]  " + e.ToString());
            }
        }

        public void FailureLog(string toLog)
        {
            checkLogFileAndFolder();

            string timeString = getTimeString();

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(timeString + " [FAILURE]  " + toLog);
            }
        }

        public void InfoLog(string toLog)
        {
            checkLogFileAndFolder();

            string timeString = getTimeString();

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(timeString + " [INFO]  " + toLog);
            }
        }

        private string getTimeString()
        {
            DateTime currTime = DateTime.Now;
            string currString = "[" + currTime.ToShortDateString() + "  " + currTime.ToShortTimeString() + "]";
            return currString;
        }

        private string logFileDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "File Organizer Log");
        private string logFilePath = System.IO.Path.Combine(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
            "File Organizer Log"), "FileOrganizer.log");

        public void initializeLogger()
        {
            DateTime currTime = DateTime.Now;
            logFilePath = "Log\\"+string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}",DateTime.Now)+".log";
            checkLogFileAndFolder();
        }

        private void checkLogFileAndFolder()
        {
            if (!(System.IO.Directory.Exists(logFileDir)))
            {
                System.IO.Directory.CreateDirectory(logFileDir);
            }

            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath);
            }
        }
    }
}