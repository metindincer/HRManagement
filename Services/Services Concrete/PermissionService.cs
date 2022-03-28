using Core.Models;
using Core.Repositories_Abstract;
using Core.Services_Abstract;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services_Concrete
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository permissionRepository;
        public PermissionService(IPermissionRepository pr, HRDbContext context)
        {
            permissionRepository = pr;
        }

        public async Task<Permission> GetPermissionById(int id)
        {
            return await permissionRepository.GetByIdAsync(id);
        }
        public async Task<Permission> CreatePermission(Permission permission)
        {
            await permissionRepository.AddAsync(permission);
            return permission;
        }
        public async Task DeletePermission(Permission permission)
        {
            await permissionRepository.RemoveAsync(permission);
        }
        public async Task<IEnumerable<Permission>> GetAllPermission()
        {
            return await permissionRepository.GetAllAsync();
        }

        public async Task UpdatePermission(int id, Permission permission)
        {
            await permissionRepository.UpdateAsync(id, permission);
        }

    }
}
