using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Feed : Super
    {
        //link to the podcastfeed
        public string link { get; set; }
        //which category the podcast belongs to
        public string category { get; set; }
        public Feed(string name, string link, string category) 
            : base(name)
        {
            this.link = link;
            this.category = category;
        }
    }
}
