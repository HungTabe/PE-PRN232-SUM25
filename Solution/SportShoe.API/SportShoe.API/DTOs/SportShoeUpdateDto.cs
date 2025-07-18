using System.ComponentModel.DataAnnotations;

namespace SportShoeManagement.API.DTOs
{
    public class SportShoeUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; }
    }
} 