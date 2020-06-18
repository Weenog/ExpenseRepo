﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseApp.Domain;

namespace ExpenseApp.Models
{
    public class ExpenseListViewModel
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string PhotoUrl { get; set; }
       

    }
}
