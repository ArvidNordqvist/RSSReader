using DataAccessLayer.Exceptions;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    internal class DataManager
    {
        public void Serialize(List<Super> list)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Super>));
                using FileStream outFile = new FileStream("Super.xml", FileMode.OpenOrCreate,
                    FileAccess.Write);
                xmlSerializer.Serialize(outFile, list);
            }
            catch (Exception e)
            {
                throw new SerializerException("Super.xml", "Could not serialize to the xml-file");
            }
        }

        public List<Super> Deserialize()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Super>));
                using FileStream inFile = new FileStream("Super.xml", FileMode.Open,
                    FileAccess.Read);
                return (List<Super>)xmlSerializer.Deserialize(inFile);
            }
            catch (Exception e)
            {
                throw new SerializerException("Super.xml", "Could not deserialize the xml-file.");
            }

        }
    }
}

