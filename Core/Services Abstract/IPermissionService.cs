using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services_Abstract
{
    public interface IPermissionService
    {
        Task<Permission> GetPermissionById(int id);
        Task<Permission> CreatePermission(Permission permission);
        Task DeletePermission(Permission permission);
        Task<IEnumerable<Permission>> GetAllPermission();
        Task UpdatePermission(int id, Permission permission);
    }
}
