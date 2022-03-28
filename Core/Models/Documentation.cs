using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Documentation
    {
        
        public int DocumentationId { get; set; }

        
        public string DocumentationName { get; set; }

        public string DocumentationPath { get; set; }
       
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
