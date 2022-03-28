using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Break
    {
        
        public int BreakId { get; set; }

        
        public string BreakName { get; set; }
       
        public DateTime StartTime { get; set; }
        
        public DateTime StopTime { get; set; }
        public ICollection<BreakAndShift> BreakAndShifts { get; set; }

    }
}
