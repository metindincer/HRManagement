using Core.Models;
using Core.Repositories_Abstract;
using Core.Services_Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository ur)
        {
            userRepository = ur;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await userRepository.GetUserByEmailAsync(email);
        }

        public async Task<User> GetUserById(string id)
        {
            return await userRepository.GetById(id);
        }

        public async Task<User> UpdateUser(string id,User updateUser)
        {
            return await userRepository.UpdateSelectedUser(id,updateUser);
        }
    }
}
