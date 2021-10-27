using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Models;
using DataAccesLayer.Exceptions;

namespace DataAccessLayer
{
    internal class DataManager
    {
        public void Serialize(List<Super> inputList)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Super>));
                using (FileStream outFile = new FileStream("oain.xml", FileMode.Create,
                    FileAccess.Write))
                {
                    xmlSerializer.Serialize(outFile, inputList);
                }
            }
            catch (Exception e)
            {
                throw new SerializerException("oain.xml", "Could not serialize to the file");
            }
        }

        public List<Super> Deserialize()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Super>));
                using (FileStream inFile = new FileStream("oain.xml", FileMode.Open,
                    FileAccess.Read))
                {
                    return (List<Super>)xmlSerializer.Deserialize(inFile);
                }
            }
            catch (Exception e)
            {
                throw new SerializerException("oain.xml", "Could not deserialize the file.");
            }

        }

        public List<Feed> FeedDeserialize()
        {
            
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Feed>));
                using (FileStream inFile = new FileStream("oain.xml", FileMode.Open,
                    FileAccess.Read))
                {
                    return (List<Feed>)xmlSerializer.Deserialize(inFile);
                }
            }
            catch (Exception e)
            {
                throw new SerializerException("oain.xml", "Could not deserialize the file.");
            }
        }
    }
}