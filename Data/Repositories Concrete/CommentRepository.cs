using Core.Models;
using Core.Repositories_Abstract;
using Data.Context;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories_Concrete
{
    public class CommentRepository:Repository<Comment>, ICommentRepository
    {
        protected HRDbContext _context;
        public CommentRepository(HRDbContext context):base(context)
        {
            _context = context;
        }
        
        public async Task<Comment> UpdateCommenntAsync(int id, Comment comment)
        {
            var commentToBeUpdated = await _context.Comments.FindAsync(id);
            if (commentToBeUpdated != null)
            {
                commentToBeUpdated.CommentText = comment.CommentText;
                commentToBeUpdated.CommentTitle = comment.CommentTitle;
                await _context.SaveChangesAsync();
            }
            return comment;
        }
    }
}
