using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseApp.Database;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    public class ExpenseController : Controller
    {
       
        private IExpenseDatabase _expenseDatabase;
      

        public ExpenseController(IExpenseDatabase ExpenseDatabase)
        {
            _expenseDatabase = ExpenseDatabase;
        }


        public IActionResult Index(int id)
        {
            var expensefromDb = _expenseDatabase.GetExpenses(id);
            var expense = new ExpenseDetailViewModel()
            foreach (var exp in expensefromDb)
            {
                Description = exp.Description;
                Date = exp.Date;
                Amount = exp.Amount;
            };

            return View(expense);

        }
    }
}
