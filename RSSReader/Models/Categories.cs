using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    public class Categories : Super
    {

        
        public Categories(string name) 
            : base(name)
        {
            
        }
    }
}
