using System;

namespace ExpenseApp.Controllers
{
    public class ExpenseDetailViewModel
    {
       
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }

    
}