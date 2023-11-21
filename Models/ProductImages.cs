namespace Project_Pronia.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public List<Products> products { get; set; }
    }
}
