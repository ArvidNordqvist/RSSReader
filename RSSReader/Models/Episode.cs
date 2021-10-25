using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Episode : Super
    {
        //description of the episode.
        public string description { get; set; }
        //Which podcast an episode belongs to.
        public string podcast { get; set; }
        public Episode(string name, string description, string podcast) 
            : base(name)
        {
            this.description = description;
            this.podcast = podcast;
        }
    }
}
