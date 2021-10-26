using System;
namespace Models
{
    public class Episode : Super
    {
        public String pod;
        public String description;
        public Episode(string name, string description, String pod) :
            base(name)
        {
            this.description = description;
            this.pod = pod;
        }
        private Episode()
        {
        }
        public override string Display()
        {
            return "This is an episode called " + Name + " and i belong to the pod " + pod;
        }


    }
}
