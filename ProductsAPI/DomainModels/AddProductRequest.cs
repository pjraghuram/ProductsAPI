namespace ProductsAPI.DomainModels
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public string Cost { get; set; }
        public string Quantity { get; set; }
        public string CompanyName { get; set; }
    }
}
