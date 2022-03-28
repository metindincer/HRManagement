using Core.Models;
using Core.Repositories_Abstract;
using Data.Context;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories_Concrete
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {        
        public PermissionRepository(HRDbContext db):base(db)
        {
            
        }

        private HRDbContext dbContext
        {
            get { return dbContext as HRDbContext; }
        }

        public async Task UpdateAsync(int id,Permission permission)
        {
            var toBeUpdated = await dbContext.Permissions.FindAsync(id);
            toBeUpdated.PermissionName = permission.PermissionName;
            toBeUpdated.PermissionStartDate = permission.PermissionStartDate;
            toBeUpdated.PermissionEndDate = permission.PermissionEndDate;
            toBeUpdated.PermissionTypeId = permission.PermissionTypeId;
            toBeUpdated.PermissionType = permission.PermissionType;

            await dbContext.SaveChangesAsync();
        }

        //confirm methodu.
    }
}
