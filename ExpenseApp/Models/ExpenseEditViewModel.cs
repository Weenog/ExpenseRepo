using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseApp.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseApp.Models
{
    public class ExpenseEditViewModel
    {
       
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public List<SelectListItem> Category { get; set; } = new List<SelectListItem>();
    }

    
}