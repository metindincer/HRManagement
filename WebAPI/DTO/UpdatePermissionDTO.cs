using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class UpdatePermissionDTO
    {
        public string PermissionName { get; set; }
        public DateTime PermissionStartDate { get; set; }
        public DateTime PermissionEndDate { get; set; }
        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
