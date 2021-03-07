using System;
using System.IO;

namespace MunicipalityTaxesManager.DataLayer
{
    public class ExeptionLogProvider
    {
        private static string folderPath = Path.Combine(Environment.CurrentDirectory, "Log");
        private static string filePath = Path.Combine(folderPath, "ErrorLog.txt");

        public static void DoLog(Exception exeption)
        {
            CreateFolderIfNotExist();
            CreateFileIfNotExist();

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

                while (exeption != null)
                {
                    writer.WriteLine(exeption.GetType().FullName);
                    writer.WriteLine("Message : " + exeption.Message);
                    writer.WriteLine("StackTrace : " + exeption.StackTrace);

                    exeption = exeption.InnerException;
                }
            }
        }

        public static void CreateFolderIfNotExist()
        {
            try
            {

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
            }
            catch
            {

            }
        }

        public static bool IsFileExist()
        {
            return File.Exists(filePath);
        }

        public static void CreateFileIfNotExist()
        {
            try
            {
                if (!IsFileExist())
                {
                    File.Create(filePath).Dispose();
                }
            }
            catch
            {

            }
        }
    }
}
