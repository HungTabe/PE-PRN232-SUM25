﻿namespace SportShoeManagement.Models
{
    public class SportShoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public bool IsDeleted { get; set; }
    }
}
