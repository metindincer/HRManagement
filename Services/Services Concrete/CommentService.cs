using Core.Models;
using Core.Repositories_Abstract;
using Core.Services_Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services_Concrete
{
    public class CommentService : ICommentSerivce
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<Comment> CreateComment(Comment company)
        {
            await _commentRepository.AddAsync(company);
            return company;
        }
        public async Task DeleteComment(Comment comment)
        {
            await _commentRepository.RemoveAsync(comment);
        }
        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _commentRepository.GetAllAsync();
        }
        public async Task UpdateComment(int id,Comment comment)
        {
            await _commentRepository.UpdateCommenntAsync(id, comment);
        }
        public async Task<Comment> GetCommentById(int id)
        {
            return await _commentRepository.GetByIdAsync(id);
        }
    }
}
