using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipePWA.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ingredient>()
                .Property(prop => prop.Price).HasColumnType("money");
        }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
