using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    public interface IRecipeRepository : IDisposable
    {
        Task<Recipe> GetRecipeAsync(string slug);
        Task<IEnumerable<Recipe>> GetRecipesAsync(string search);
        void AddRecipe(Recipe recipe);

        void AddIngredient(Ingredient ingredient);
        void AddInstruction(Method instruction);
        void AddNutritionalInfo(NutritionalInfo info);
        void DeleteRecipe(int id);
        void EditRecipe(Recipe recipe);
        Task<int> SaveChangesAsync();
        void SaveChanges();
    }
}
