﻿namespace BabysWeeklyMenu.API.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public List<Allergy> Allergies { get; set; }
    }
}
