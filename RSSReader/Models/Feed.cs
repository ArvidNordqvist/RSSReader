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
            Update();
        }
        private Feed()
        {
        }
        public override string Display()
        {
            return "This is a podcast called " + Name + "!";
        }


        public bool NeedsUpdate
        {
            get
            {
                return NextUppdate <= DateTime.Now;
            }
        }

        public void Update()
        {
            NextUppdate = DateTime.Now.AddMilliseconds(frekvens);
            
        }

    }
}
