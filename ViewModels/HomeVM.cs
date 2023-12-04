using Project_Pronia.Models;

namespace Project_Pronia.ViewModels
{
    public class HomeVM   {
        public List<Categories> categories {  get; set; }
        public List<ProductImages> productImages { get; set; }
        public List<Products> products { get; set; }
        public List<ProductTags> productTags { get; set; }
        public List<Slider> sliders {  get; set; }
        public List<Tags> tags { get; set; }
        public List<Setting> settings { get; set; }
    }
}
