using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Crud1.Models
{
    public class Product
    {
        [Key]
        public int Pro_id {  get; set; }
        public string pro_name { get; set; }
        public double pro_price { get; set; }
        public string pro_description { get; set; }
    }
}
