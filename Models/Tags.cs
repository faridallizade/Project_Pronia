namespace Project_Pronia.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductTags> ProductTags { get; set; }
        
    }
}
