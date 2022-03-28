using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services_Abstract
{
    public interface IUserService
    {
        Task<User> GetUserByEmail(string email);
        Task<User> UpdateUser(string id, User updateUser);

        Task<User> GetUserById(string id);

        Task<IEnumerable<User>> GetAllAsync();
    }
}
