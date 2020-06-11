using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    public class ExpenseController : Controller
    {
       
        private IExpenseDatabase _expenseDatabase;
        private object _expensedatabase;

        public ExpenseController(ExpenseDatabase expenseDatabase)
        {
            _expenseDatabase = expenseDatabase;
        }


     

        public IActionResult Index(int id)
        {
            var expensefromdb = _expensedatabase.getexpense(id);

            var expense = new ExpenseDetailViewModel()
            {

               

                Description = expenseFromDb.Description,

                Date = expenseFromDb.Date,

                Amount = expenseFromDb.Amount,

            };

            return View(expense);

        }
    }
}
