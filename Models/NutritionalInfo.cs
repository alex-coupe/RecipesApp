using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class NutritionalInfo
    {
        public int Id { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [Required]
        public string Kcal { get; set; }

        [Required]
        public string Fat { get; set; }
        
        [Required]
        public string Carbs { get; set; }

        [Required]
        public string Fibre { get; set; }
        
        [Required]
        public string Protein { get; set; }
        [Required]
        public string Salt { get; set; }
    }
}
