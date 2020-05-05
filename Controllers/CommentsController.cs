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

        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _repository.AddComment(comment);
                await _repository.SaveChangesAsync();

                return CreatedAtAction("PostComment", new { id = comment.Id }, comment);
            }
            return BadRequest(ModelState);
        }
    }
}