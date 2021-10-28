using System;
using System.Collections.Generic;

namespace Models
{
    public class Feed : Super
    {
        public string frekvens { get; set; }
        public string URL { get; set; }
        public string category { get; set; }

        public Feed(string name, string frekvens, string URL, string Category) :
                  base(name, "Feed")
        {
            this.frekvens = frekvens;
            this.URL = URL;
            category = Category;
        }
        private Feed()
        {
        }
        public override string Display()
        {
            return "This is a podcast called " + Name + "!";
        }

        public override List<string> Value()
        {
            List<string> list = new List<string>();
            list.Add(Name);
            list.Add(frekvens);
            list.Add(URL);
            list.Add(category);
            return list;
        }


    }
}
