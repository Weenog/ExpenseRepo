using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Domain
{
    public class Expense
    {
        public int Id { get; set; }
        public object Amount { get; set; }
        public object Description { get; set; }
        public object Date { get; set; }
        public Category Category {get; set;} 
    }
}
