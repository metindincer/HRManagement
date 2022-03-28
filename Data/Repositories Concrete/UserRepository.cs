using Core.Models;
using Core.Repositories_Abstract;
using Data.Context;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories_Concrete
{
    public class UserRepository : IUserRepository
    {
        HRDbContext dbContext;

        public UserRepository(HRDbContext db)
        {
            dbContext = db;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await dbContext.Users.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<User> UpdateSelectedUser(string id, User updateUser)
        {
            User _user = dbContext.Users.Where(a => a.Id == id).SingleOrDefault();
            if (_user != null)
            {
                _user.CompanyId = updateUser.CompanyId ?? _user.CompanyId;
                _user.Name = updateUser.Name ?? _user.Name;
                _user.Surname = updateUser.Surname ?? _user.Surname;
                _user.DateOfBirth = updateUser.DateOfBirth ?? _user.DateOfBirth;
                _user.JobStartDate = updateUser.JobStartDate ?? _user.JobStartDate;
                _user.IsActive = updateUser.IsActive ?? _user.IsActive;
                _user.About = updateUser.About ?? _user.About;
                _user.Photopath = updateUser.Photopath ?? _user.Photopath;
                _user.JobTitle = updateUser.JobTitle ?? _user.JobTitle;
                _user.Salary = updateUser.Salary ?? _user.Salary;
                _user.Bonus = updateUser.Bonus ?? _user.Bonus;
                _user.PhoneNumber = updateUser.PhoneNumber ?? _user.PhoneNumber;

                await dbContext.SaveChangesAsync();
            }
            return updateUser;
        }

        public async Task<User> GetById(string id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }
    }
}
