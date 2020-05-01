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

        [HttpGet("{id}")]

        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipes = await _repository.GetRecipeAsync(id);
            return Ok(recipes);
        }

    }
}