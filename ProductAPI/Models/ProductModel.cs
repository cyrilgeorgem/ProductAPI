namespace ProductAPI.Models
{
    public class ProductModel
    {
        public ProductModel()
        {
            Name = "";
            Description = "";
        }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
