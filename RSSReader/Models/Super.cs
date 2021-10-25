using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    [XmlInclude(typeof(Categories))]
    [XmlInclude(typeof(Episode))]
    [XmlInclude(typeof(Feed))]
    public abstract class Super
    {
        public string name { get; set; }

        public Super(string name){
            this.name = name;

        }
    }
}
