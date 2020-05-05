using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    public class RecipeRepository: IRecipeRepository, IDisposable
    {
        private RecipeContext _context;

        public RecipeRepository(RecipeContext context)
        {
            _context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(string search)
        {
            IQueryable<Recipe> filtered = null;
            var recipes = _context.Recipes.AsNoTracking()
                .Include(i => i.NutritionalInfo)
                .Include(i => i.Instructions)
                .Include(i => i.Ingredients)
                .Include(i => i.Comments);
            if (search != null)
            {
                filtered = recipes.Where(x => x.Tags.Contains(search));
                return await filtered.ToListAsync();
            }

            return await recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeAsync(string slug)
        {
            var recipe = await _context.Recipes.AsNoTracking()
                .Include(i => i.NutritionalInfo)
                .Include(i => i.Instructions)
                .Include(i => i.Ingredients)
                .Include(i => i.Comments)
                .SingleOrDefaultAsync(x => x.Slug == slug);

            return recipe;    
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
        }

        public void EditRecipe(Recipe recipe)
        {
            _context.Entry(recipe).State = EntityState.Modified;
        }

        public void DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.Find(id);
            _context.Recipes.Remove(recipe);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
