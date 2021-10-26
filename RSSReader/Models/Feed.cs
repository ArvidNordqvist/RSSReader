using System;
namespace Models
{
    public class Feed : Super
    {
        public String frekvens { get; set; }
        public String URL { get; set; }
        public String category { get; set; }
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
            return "I am a Student. My name is " + Name + " and I live in ";
        }
    }
}
