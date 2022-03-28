using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BreakAndShift
    {
       

        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        public int BreakId { get; set; }
        public Break Break { get; set; }


    }
}
