using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductAppWeb.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string? Name { get; set; }

        [MaxLength(200)]
        [Required]
        public string? Description { get; set; }

        [Range(1, 200, ErrorMessage = "Price has to be between 1$ and 200$.")]
        public int Price { get; set; }

        [DisplayName("Created")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [DisplayName("Last Updated")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
