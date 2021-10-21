using DataAccessLayer.Exceptions;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    internal class DataManager<T>
    {
        public void Serialize(List<T> list)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                using FileStream outFile = new FileStream("Data.xml", FileMode.Create,
                    FileAccess.Write);
                xmlSerializer.Serialize(outFile, list);
            }
            catch (Exception e)
            {
                throw new SerializerException("Data.xml", "Could not serialize to the xml-file");
            }
        }

        public List<T> Deserialize()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                using FileStream inFile = new FileStream("Data.xml", FileMode.Open,
                    FileAccess.Read);
                return (List<T>)xmlSerializer.Deserialize(inFile);
            }
            catch (Exception e)
            {
                throw new SerializerException("Data.xml", "Could not deserialize the xml-file.");
            }

        }
    }
}

