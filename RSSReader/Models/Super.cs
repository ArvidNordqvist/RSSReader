using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Models
{
    [XmlInclude(typeof(Categories))]
    [XmlInclude(typeof(Episode))]
    [XmlInclude(typeof(Feed))]
    public abstract class Super
    {
        public string Name { get; set; }
        public string DataType { get; set; }

        public Super(string name, string dataType)
        {
            Name = name;
            DataType = dataType;

        }
        public Super()
        {

        }
        public virtual string Display()
        {
            return "";
        }

        public virtual List<string> Value()
        {
            List<string> list = new List<string>();
            return list;


        }
    }
}

