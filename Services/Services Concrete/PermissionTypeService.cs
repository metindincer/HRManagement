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
   public class PermissionTypeService : IPermissionTypeService
    {
        private readonly IPermissionTypeRepository permissionTypeRepository;
        public PermissionTypeService(IPermissionTypeRepository permissionTypeRepository)
        {
            this.permissionTypeRepository = permissionTypeRepository;
        }
        public async Task<PermissionType> CreatePermissionType(PermissionType permissionType)
        {
            await permissionTypeRepository.AddAsync(permissionType);
            return permissionType;
        }

        public async Task DeletePermissionType(PermissionType permissionType)
        {
            await permissionTypeRepository.RemoveAsync(permissionType);
            
        }

        public async Task<IEnumerable<PermissionType>> GetAllPermissionTypes()
        {
            return await permissionTypeRepository.GetAllAsync();
        }

        public async Task<PermissionType> GetPermissionTypeById(int id)
        {
            return await permissionTypeRepository.GetByIdAsync(id);
        }

        public async Task UpdatePermissionType(int id, PermissionType permissionType)
        {
            await permissionTypeRepository.UpdatePermissionTypeAsync(id, permissionType);
        }
    }
}
