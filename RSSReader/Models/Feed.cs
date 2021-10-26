using System;
namespace Models
{
    public class Feed : Super
    {
        public String frekvens { get; set; }
        public String description { get; set; }
        public Feed(string name, string frekvens, string description) :
                  base(name)
        {
            this.frekvens = frekvens;
            this.description = description;
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
