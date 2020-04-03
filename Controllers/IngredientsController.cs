using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipePWA.Models;

namespace RecipePWA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly RecipeContext _context;
        public IngredientsController(RecipeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            var Ingredients = await _context.Ingredients.AsNoTracking().ToListAsync();
            return Ingredients;
        }

        [HttpGet]
        public async Task<Ingredient> GetIngredient(int id)
        {
            var Ingredient = await _context.Ingredients.AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == id);

            return Ingredient;
        }
    }
}