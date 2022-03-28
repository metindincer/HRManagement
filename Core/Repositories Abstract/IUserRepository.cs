using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories_Abstract
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> UpdateSelectedUser(string id,User updateUser);
        Task<User> GetById(string id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
