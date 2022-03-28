using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Permission
    {
        
        public int PermissionId { get; set; }

       
        public string PermissionName { get; set; }

        
        public string UserId { get; set; }
        public User User { get; set; }
        
        
        public bool Confirm { get; set; }
        public DateTime? PermissionStartDate { get; set; }
        public DateTime? PermissionEndDate { get; set; }

        
        public string DirectorId { get; set; }
       

        public DateTime? ConfirmOrRejectDate { get; set; }

        public int? PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }

    }
}
