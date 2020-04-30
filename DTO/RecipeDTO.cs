using Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO
{
    public class RecipeDTO : Recipe
    {
        [Required]
        public virtual List<Ingredient> Ingredients { get; set; }
    }
}
