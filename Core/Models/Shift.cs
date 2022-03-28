using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Shift
    {
        
        public int ShiftId { get; set; }

        
        public string ShiftName { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

       
        
        public int CompanyId { get; set; }
        public Company Company { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }

        //public ICollection<User> Users { get; set; }
        public ICollection<BreakAndShift> BreakAndShifts { get; set; }


    }
}
