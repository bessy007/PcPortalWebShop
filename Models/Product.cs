using System.ComponentModel.DataAnnotations;

namespace PCPortal.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string manufacturer { get; set; }
        public double price { get; set; }
        public double? salePrice { get; set; }
        public string ImgName()
        {
            return title + ".jpg";
        }
        public string? Description { get; set; }
    }
    
}
