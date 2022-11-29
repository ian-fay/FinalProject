using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Northwind.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        [Range(1000, 9999, ErrorMessage = "Please enter a 4 digit number")]
        [Required]
        public int? Code { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        [Required]
        public int? ProductId { get; set; }
        [Required]
        [Column(TypeName = "decimal(4,4)")]
        [Range(0.0, 1.0,  ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal? DiscountPercent { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public Product Product { get; set; }
    }
}
