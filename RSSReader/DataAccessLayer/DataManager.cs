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
        public void Serialize(List<Categories> list)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Categories>));
                using FileStream outFile = new FileStream("Category.xml", FileMode.OpenOrCreate,
                    FileAccess.Write);
                xmlSerializer.Serialize(outFile, list);
            }
            catch (Exception e)
            {
                throw new SerializerException("Category.xml", "Could not serialize to the xml-file");
            }
        }

        public List<Categories> Deserialize()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Categories>));
                using FileStream inFile = new FileStream("Category.xml", FileMode.Open,
                    FileAccess.Read);
                return (List<Categories>)xmlSerializer.Deserialize(inFile);
            }
            catch (Exception e)
            {
                throw new SerializerException("Category.xml", "Could not deserialize the xml-file.");
            }

        }
    }
}

