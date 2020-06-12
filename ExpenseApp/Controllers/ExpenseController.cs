using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseApp.Database;
using ExpenseApp.Domain;
using ExpenseApp.Models;
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

        [HttpGet]
        public IActionResult Index(int id)
        {

            List<ExpenseListViewModel> XpList = new List<ExpenseListViewModel>();
            IEnumerable<Expense> expenses = _expenseDatabase.GetExpenses().OrderBy(x =>x.Date);
            var expense = new ExpenseDetailViewModel();
            foreach (var thing in expenses)
            {
                ExpenseListViewModel Xp = new ExpenseListViewModel() {
                    Id = thing.Id,
                    Description = (string)thing.Description,
                    Date = (DateTime)thing.Date,
                    Amount = (decimal)thing.Amount
                };
                XpList.Add(Xp);
            }

            return View(XpList);

        }
    }
}
