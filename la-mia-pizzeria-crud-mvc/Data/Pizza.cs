using la_mia_pizzeria_crud_mvc.Models;
using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Data
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [MinWords(5)]
        public string Description { get; set; }

        [Range(0.01, 100000, ErrorMessage ="Il valore deve essere maggiore di 0")]  
        public decimal Price { get; set; }

        public string? Image { get; set; }

        public Pizza () { }
        public Pizza(string name, string description, decimal price) {
            
            Name = name; 
            Description = description;
            Price = price;
        
        }
    }
}
