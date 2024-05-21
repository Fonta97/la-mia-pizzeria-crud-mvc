﻿using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_crud_mvc.Data
{
    public class Pizza
    {
        [Key] public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }

        public string? Image { get; set; }

        public Pizza() { }
    }
}