using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Debit
    {
        
        public int DebitId { get; set; }

        
        public string DebitName { get; set; }

        
        
        public string UserId { get; set; }
        public User User { get; set; } 



        public bool IsConfirm { get; set; } //IsActive'den mi yönetilecek ?
        public string Note { get; set; }

    
        public string DirectorId { get; set; }
    }
}
