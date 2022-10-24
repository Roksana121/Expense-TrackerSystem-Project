using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense_Tracker_application.Models
{
    public class UserVM
    {
        public int UserId { get; set; }
       
        public string UserName { get; set; }
        
        public int CategoryId { get; set; }

        public DateTime ExpenseDate { get; set; } = DateTime.Now;
       
        public decimal Amount { get; set; }
       
        public string CategoryName { get; set; }
     
    }
}
