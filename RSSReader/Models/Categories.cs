using System;
namespace Models
{
    public class Categories : Super
    {

        public Categories(String kategori) : base(kategori, "Category")
        {

        }
        private Categories()
        {
        }
        public override string Display()
        {
            return "This is a category named: " + Name;
        }
    }
}
