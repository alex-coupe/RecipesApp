using Backend.Controllers;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    public class CommentRepository : ICommentRepository
    {
        private RecipeContext _context;

        public CommentRepository(RecipeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> GetCommentsAsync(string slug)
        {
            var comments = await _context.Comments.AsNoTracking()
                .Where(x => x.RecipeSlug == slug)
                .ToListAsync();

            return comments;
        }
    }
}
