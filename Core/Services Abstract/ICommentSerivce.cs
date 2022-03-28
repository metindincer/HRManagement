using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services_Abstract
{
    public interface ICommentSerivce
    {
        Task<Comment> CreateComment(Comment company);
        Task DeleteComment(Comment comment);
        Task<IEnumerable<Comment>> GetAllComments();
        Task UpdateComment(int id, Comment comment);
        Task<Comment> GetCommentById(int id);
    }
}
