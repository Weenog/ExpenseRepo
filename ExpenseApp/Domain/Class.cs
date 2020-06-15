using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExpenseApp.Domain
{
    public class GroupedExpenses

    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Category Category { get; set; }
    }

}