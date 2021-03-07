using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MunicipalityTaxesManager.DataLayer
{
    public class SerializeProvider
    {
        public static string FolderPath = Path.Combine(Environment.CurrentDirectory, "Data");

        public static void SerializeXml(object serializationObject, string fileName)
        {
            System.Xml.Serialization.XmlSerializer serializer = null;
            CreateFolderIfNotExist();
            try
            {
                serializer = new System.Xml.Serialization.XmlSerializer(serializationObject.GetType());
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                return;
            }

            var filePath = Path.Combine(FolderPath, fileName);

            SerializeXMLToFile(serializationObject, filePath, serializer);
        }

        public static void SerializeXMLToFile(object serializationObject, string filePath, System.Xml.Serialization.XmlSerializer serializer)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, serializationObject);
            }
        }

        public static void CreateFolderIfNotExist()
        {
            try
            {
               
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                
            }
            catch
            {

            }
        }

        public static void DeleteFolderIfExist()
        {
            try
            {
                if (!Directory.Exists(FolderPath))
                {
                    return;
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(FolderPath);

                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                {
                    dir.Delete(true);
                }

                Directory.Delete(FolderPath);
            }
            catch
            {
            }
        }

        public static object DeserializeXml(Type oSerializationClass, string fileName)
        {
            object result = null;

            try
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(oSerializationClass);
                var filePath = Path.Combine(FolderPath, fileName);

                if (!File.Exists(filePath))
                {
                    return null;
                }

                using (System.Xml.XmlTextReader xtr = new System.Xml.XmlTextReader(new StreamReader(filePath)))
                {
                    result = serializer.Deserialize(xtr);
                }
            }
            catch (Exception ex)
            {
                ExeptionLogProvider.DoLog(ex);
            }

            return result;
        }
    }
}
