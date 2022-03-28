using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MembershipApplication
    {
        
        public int ApplicationId { get; set; }

  
        public string ApplicationType { get; set; }

        
        public int CompanyId { get; set; }
        public Company Company { get; set; }



        public string Confirm { get; set; }
    }
}
