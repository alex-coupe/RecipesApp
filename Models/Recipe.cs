using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecipePWA.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public virtual List<Ingredient> Ingredients { get; set; }

        [DefaultValue(0)]
        public int Likes { get; set; }
        
        [DefaultValue(0)]
        public int Comments { get; set; }

        [DefaultValue(0)]
        public int Favourites { get; set; }

        [Required]
        public string Slug { get; set; }
        
        [Required]
        public string ImageURL { get; set; }
    }
}
