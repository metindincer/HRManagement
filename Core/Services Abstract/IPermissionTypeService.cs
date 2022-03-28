using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services_Abstract
{
   public interface IPermissionTypeService
    {
        Task<PermissionType> CreatePermissionType(PermissionType permissionType);
        Task DeletePermissionType(PermissionType permissionType);
        Task<IEnumerable<PermissionType>> GetAllPermissionTypes();
        Task UpdatePermissionType(int id, PermissionType permissionType);
        Task<PermissionType> GetPermissionTypeById(int id);
    }
}
