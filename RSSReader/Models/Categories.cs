using System;
namespace Models
{
    public class Categories : Super
    {

        public Categories(String kategori) : base(kategori)
        {

        }
        private Categories()
        {
        }
        public override string Display()
        {
            return "I am an Employee. My name is " + Name + " and I live in ";
        }
    }
}
