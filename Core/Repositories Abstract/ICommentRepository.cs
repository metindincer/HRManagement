using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories_Abstract
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment> UpdateCommenntAsync(int id, Comment comment);
    }
}
