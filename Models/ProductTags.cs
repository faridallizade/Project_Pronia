namespace Project_Pronia.Models
{
    public class ProductTags
    {
        public int Id { get; set; }    
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public Products Products { get; set; }
        public Tags Tags { get; set; }
    }
}
