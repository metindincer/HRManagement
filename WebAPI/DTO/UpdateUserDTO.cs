using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class UpdateUserDTO
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JobStartDate { get; set; }
        public bool? IsActive { get; set; }
        public string About { get; set; }
        public string Photopath { get; set; }
        public string JobTitle { get; set; }
        public int Salary { get; set; }
        public int Bonus { get; set; }
        public string PhoneNumber { get; set; }
    }
}
