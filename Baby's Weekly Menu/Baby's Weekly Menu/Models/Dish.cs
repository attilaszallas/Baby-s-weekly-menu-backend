﻿using System.ComponentModel.DataAnnotations;

namespace BabysWeeklyMenu.API.Models
{
    public class Dish
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int MealId { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Recipe { get; set; }
        public virtual ICollection<Ingredient>? Ingredients { get; set; }
    }
}
