using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipePWA.Models
{
    public class Recipe
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public List<Ingredient> Ingredients { get; set; }

        public int Rating { get; set; }

        public bool Favourite { get; set; }
    }
}
