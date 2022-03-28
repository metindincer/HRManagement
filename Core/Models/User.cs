using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    //Identity entegre edilecek User'a
    public class User : IdentityUser
    {
        public  int? CompanyId { get; set; }
        public Company  Company { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JobStartDate { get; set; }

        public bool? IsActive { get; set; }

       

        public string About { get; set; }
        public string Photopath { get; set; }
        public string JobTitle { get; set; }
        public int? Salary { get; set; }
        public int? Bonus { get; set; }

        //public int ShiftId { get; set; }
        //public Shift Shift { get; set; }
        public ICollection<Shift> Shifts { get; set; }

        public ICollection<Permission> Permissions { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Debit> Debits { get; set; }
        public ICollection<Documentation> Documentations { get; set; }
        public ICollection<Expense> Expenses { get; set; }













    }
}
