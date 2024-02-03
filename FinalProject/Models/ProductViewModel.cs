using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
