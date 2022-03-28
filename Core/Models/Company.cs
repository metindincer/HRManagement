using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Company
    {
        public Company()
        {
            MembershipApplications = new Collection<MembershipApplication>();
            Users = new Collection<User>();
            Shifts = new Collection<Shift>();
        }
        public int CompanyId { get; set; }

       
        public string CompanyName { get; set; }
        
        public string LogoPath { get; set; }
        
        public DateTime? MembershipEndDate { get; set; }
        
        public DateTime? MembershipValidity { get; set; }
       
        public ICollection<MembershipApplication> MembershipApplications { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Shift> Shifts { get; set; }
    }
}
