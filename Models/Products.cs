using System.Reflection.Metadata.Ecma335;

namespace Project_Pronia.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int ImageId { get; set; }
        public ProductImages Images { get; set; }
        public string SKU {  get; set; }
        public List<ProductTags>  ProductTags { get; set; }
        public int CategoryId { get; set; }
        public Categories Categories { get; set; }

    }
}
