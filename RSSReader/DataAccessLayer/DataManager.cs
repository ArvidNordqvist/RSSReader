using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DataAccessLayer
{
    internal class DataManager
    {
        public void Serialize(List<Categories> poddList)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Categories>));
                using (FileStream outFile = new FileStream("Categories.xml", FileMode.Create,
                    FileAccess.Write))
                {
                    xmlSerializer.Serialize(outFile, poddList);
                }
            }
            catch (Exception e)
            {
                throw new SerializerException("Categories.xml", "Could not serialize to the file");
            }
        }

        public List<Categories> Deserialize()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Categories>));
                using (FileStream inFile = new FileStream("Categories.xml", FileMode.Open,
                    FileAccess.Read))
                {
                    return (List<Categories>)xmlSerializer.Deserialize(inFile);
                }
            }
            catch (Exception e)
            {
                throw new SerializerException("Categories.xml", "Could not deserialize the file.");
            }

        }
    }
}

