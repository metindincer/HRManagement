using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class CreatePermissionDTO
    {
        public string PermissionName { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }


        public bool Confirm { get; set; }
        public DateTime PermissionStartDate { get; set; }
        public DateTime PermissionEndDate { get; set; }


        public string DirectorId { get; set; }


        public DateTime? ConfirmOrRejectDate { get; set; }

        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}

