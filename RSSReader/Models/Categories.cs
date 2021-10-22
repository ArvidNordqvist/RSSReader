using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    [XmlInclude(typeof(Categories))]
    public class Categories
    {

        public string Name { get; set; }
        public Categories(string name)
        {
            Name = name;
        }
    }
}
