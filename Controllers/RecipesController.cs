using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.DataAccess;


namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _repository;
        public RecipesController(IRecipeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes([FromQuery]string search)
        {
            var recipes = await _repository.GetRecipesAsync(search);
            return Ok(recipes);
        }

        [HttpGet("{slug}")]

        public async Task<ActionResult<Recipe>> GetRecipe(string slug)
        {
            var recipes = await _repository.GetRecipeAsync(slug);
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _repository.AddRecipe(recipe);
              

                foreach(var ingredient in recipe.Ingredients)
                {
                    ingredient.RecipeId = recipe.Id;
                    _repository.AddIngredient(ingredient);
                }

                foreach(var instruction in recipe.Instructions)
                {
                    instruction.RecipeId = recipe.Id;
                    _repository.AddInstruction(instruction);
                }
                await _repository.SaveChangesAsync();
                return CreatedAtAction("PostRecipe", new { id = recipe.Id }, recipe);
            }
            return BadRequest(ModelState);
        }

    }
}