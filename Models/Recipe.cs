using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Recipe
    {
        public int Id { get; set; }
              

        [DefaultValue(0)]
        public int Likes { get; set; }

        public string PrepTime { get; set; }

        public int Serves { get; set; }

        public string Difficulty { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public string Name { get; set; }
        

        [DefaultValue(0)]
        public int Favourites { get; set; }

        [Required]
        public string Slug { get; set; }
        
        [Required]
        public string ImageURL { get; set; }

        [Required]
        public virtual List<Ingredient> Ingredients { get; set; }

        [Required]
        public virtual List<Method> Instructions { get; set; }

        public string Tags { get; set; }
        [Required]
        public virtual NutritionalInfo NutritionalInfo { get; set; }

       
    }
}
