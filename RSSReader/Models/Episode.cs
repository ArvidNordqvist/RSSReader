using System;
namespace Models
{
    public class Episode : Super
    {
        public string pod;
        public string description;
        public Episode(string name, string description, string pod) :
            base(name, "Episode")
        {
            this.description = description;
            this.pod = pod;
        }
        private Episode()
        {
        }
        public override string Display()
        {
            return "This is an episode called " + Name + " and belong to the pod " + pod;
        }


    }
}
