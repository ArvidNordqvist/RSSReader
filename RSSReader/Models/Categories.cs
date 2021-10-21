using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    [XmlInclude(typeof(Categories))]
    public class Categories
    {

        public string name { get; set; }
        public Categories(string name)
        {
            this.name = name;
        }
    }
}
