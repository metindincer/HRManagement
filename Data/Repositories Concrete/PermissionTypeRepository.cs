using Core.Models;
using Core.Repositories_Abstract;
using Data.Context;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories_Concrete
{
   public class PermissionTypeRepository : Repository<PermissionType>, IPermissionTypeRepository
    {
        protected HRDbContext _context;
       

        public PermissionTypeRepository(HRDbContext context) :base(context)
        {
            _context = context;
        }


        public async Task UpdatePermissionTypeAsync(int id, PermissionType permissionType)
        {
            PermissionType _permissionType = await _context.PermissionTypes.FindAsync(id);
            if(_permissionType!=null)
            {
                _permissionType.PermissionName = permissionType.PermissionName;

                
            }

            await _context.SaveChangesAsync();
        }
    }
}
