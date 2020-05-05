using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsAsync(string slug);
        Task<int> SaveChangesAsync();
        void AddComment(Comment comment);
    }
}