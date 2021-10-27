using System;
namespace Models
{
    public class Feed : Super
    {
        public string frekvens { get; set; }
        public string URL { get; set; }
        public string category { get; set; }
        public Feed(string name, string frekvens, string URL, string Category) :
                  base(name)
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
    }
}
