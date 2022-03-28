using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Expense
    {
        
        public int ExpenseId { get; set; }

     
        public string ExpenseName { get; set; }

        
        public string UserId { get; set; }
        public User User { get; set; }


        public int Amount { get; set; }
        public string Confirm { get; set; }
        public string DocumentPathAboutSpending { get; set; }
    }
}
