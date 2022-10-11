using System;

namespace ProductsAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string Cost { get; set; }
        public string Quantity { get; set; }
        public string CompanyName { get; set; }
    }
}
