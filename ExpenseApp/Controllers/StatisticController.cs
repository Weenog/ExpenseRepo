﻿
using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseApp.Database;
using System.Threading.Tasks;
using ExpenseApp.Domain;
using ExpenseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Controllers
{
    public class StatisticsController : Controller
    {
       
        //private readonly IEnumerable<Expense> _expenses;
        private readonly ExpenseDbContext _expenseDatabase;

        public StatisticsController(ExpenseDbContext expenseDatabase)
        {
            _expenseDatabase = expenseDatabase;
            //_expenses = _expenseDatabase.GetExpenses();
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            IEnumerable<Expense> _expenses = await _expenseDatabase.Expenses.ToListAsync();
            StatisticsIndexViewModel vm = new StatisticsIndexViewModel()
            {
              Expenses = _expenses,
              HighestExpense = _expenses.OrderByDescending(x => x.Amount).First(),
              LowestExpense = _expenses.OrderBy(x => x.Amount).First(),
              MonthlyExpenses = _expenses.GroupBy(x => new { x.Date.Date.Month, x.Date.Year }).Select(g => new GroupedExpenses { Date = new DateTime(g.Key.Year, g.Key.Month, 01), Amount = g.Sum(m => m.Amount) }).OrderBy(x => x.Date),
              HighestDayExpense = _expenses.GroupBy(x => x.Date.Date).Select(x => new GroupedExpenses { Date = x.Key, Amount = x.Sum(m => m.Amount) }).OrderByDescending(x => x.Amount).First(),
              MostExpensive = _expenses.GroupBy(x => x.Category).Select(g => new GroupedExpenses { Category = g.Key, Amount = g.Sum(m => (decimal)m.Amount) }).OrderByDescending(x => x.Amount).First(),
              LeastExpensive = _expenses.GroupBy(x => x.Category).Select(g => new GroupedExpenses { Category = g.Key, Amount = g.Sum(m => (decimal)m.Amount) }).OrderBy(x => x.Amount).First()
            };
            return View(vm);
        }
    }
}