using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Text { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int RecipeId { get; set; }

        public string? Author { get; set; }
    }
}
