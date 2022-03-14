using System;

namespace BaseProject.Model
{
    public class Product : BaseEntity
    {
        public Product()
        {
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public static string KeyName { get; set; } = "PRODUCT";
    }
}
