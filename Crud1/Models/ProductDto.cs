using System.ComponentModel.DataAnnotations;

namespace Crud1.Models
{
    public class ProductDto
    {
        [Required]
        public string pro_name { get; set; }
        [Required]
        public double pro_price { get; set; }
        [Required]
        public string pro_description { get; set; }
    }
}
