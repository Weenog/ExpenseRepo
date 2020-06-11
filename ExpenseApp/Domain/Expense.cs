using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApp.Domain
{
    public class Expense
    {
        public int Id { get; internal set; }
        public object Amount { get; internal set; }
        public object Description { get; internal set; }
        public object Date { get; internal set; }
    }
}
