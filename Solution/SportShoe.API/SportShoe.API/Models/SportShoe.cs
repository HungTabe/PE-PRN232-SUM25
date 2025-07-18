using System.ComponentModel.DataAnnotations;

namespace SportShoeManagement.API.Models
{
    public class SportShoe
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public bool IsDeleted { get; set; }
    }
}
