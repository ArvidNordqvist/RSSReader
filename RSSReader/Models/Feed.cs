using System;
using System.Collections.Generic;

namespace Models
{
    public class Feed : Super
    {
        public DateTime NextUppdate { get; set; }

        public double frekvens;
        public string URL { get; set; }
        public string category { get; set; }

        public Feed(string name, double frekvens, string URL, string Category) :
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

        //public override List<string> Value()
        //{
        //    List<string> list = new List<string>();
        //    list.Add(Name);
        //    list.Add(frekvens);
        //    list.Add(URL);
        //    list.Add(category);
        //    return list;
        //}

        public bool NeedsUpdate
        {
            get
            {
                return NextUppdate <= DateTime.Now;
            }
        }

        public string Update()
        {
            NextUppdate = DateTime.Now.AddMilliseconds(frekvens);
            return Name + " " + NextUppdate;
        }

    }
}
