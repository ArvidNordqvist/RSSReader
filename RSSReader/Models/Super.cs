using System;
using System.Xml.Serialization;

namespace Models
{
    [XmlInclude(typeof(Categories))]
    [XmlInclude(typeof(Episode))]
    [XmlInclude(typeof(Feed))]
    public abstract class Super
    {
        public string Name { get; set; }

        public Super(string name)
        {
            Name = name;

        }
        public Super()
        {

        }
        public abstract string Display();
    }
}

