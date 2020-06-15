﻿
using ExpenseApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExpenseApp.Models
{
    public class StatisticsIndexViewModel

    {

        public Expense HighestExpense { get; set; }
        public GroupedExpenses HighestDayExpense { get; set; }
        public IEnumerable<GroupedExpenses> MonthlyExpenses { get; set; }
        public Expense LowestExpense { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public GroupedExpenses MostExpensive { get; set; }
        public GroupedExpenses LeastExpensive { get; set; }


    }

}