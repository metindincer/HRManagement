using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class PermissionType
    {
        
        public int PermissionTypeId { get; set; }

      
        public string PermissionName { get; set; }
        public ICollection<Permission>Permissions { get; set; }
    }
}
