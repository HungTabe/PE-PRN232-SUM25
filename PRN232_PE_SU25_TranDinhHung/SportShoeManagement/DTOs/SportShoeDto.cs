using System.ComponentModel.DataAnnotations;

namespace SportShoeManagement.DTOs
{
    public class SportShoeDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price Must Be Positive")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
