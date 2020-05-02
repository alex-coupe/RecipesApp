using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DataAccess;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        public CommentsController(ICommentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments(string slug)
        {
            var comments = await _repository.GetCommentsAsync(slug);
            return Ok(comments);
        }
    }
}