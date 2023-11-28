using Project_Pronia.Models;

namespace Project_Pronia.Areas.ViewModels
{
    public class CreateProductVM
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public int? ImageId { get; set; }
        public int CategoryId { get; set; }
        public List<int> TagIds { get; set; }

        public ProductImages? Images { get; set; }
        public List<ProductTags>? ProductTags { get; set; }
        public Categories? Categories { get; set; }
    }
}
