using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                 .HasMany(c => c.Ingredients);
            modelBuilder.Entity<Recipe>()
                .HasMany(c => c.Instructions);
            modelBuilder.Entity<Recipe>()
                .HasOne(c => c.NutritionalInfo);

            modelBuilder.Entity<Recipe>()
                .HasIndex(u => u.Slug)
                .IsUnique();
            modelBuilder.Entity<Comment>()
                .HasOne<Recipe>();
        }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<NutritionalInfo> NutritionalInfos {get; set;}

        public DbSet<Method> Instructions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
    }
}
