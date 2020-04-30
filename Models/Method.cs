using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Method
    {
        public int Id { get; set; }
        [Required]
        public int Step { get; set; }
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public string Instruction { get; set;}
    }
}
