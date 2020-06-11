using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseApp.Controllers
{
    public class ExpenseController : Controller
    {
        private object contactFromDb;
        private IExpenseDatabase _contactDatabase;

        public IActionResult Index()
        {
            return View();
        }

        public ExpenseController(IExpenseDatabase expenses)
        {
            _contactDatabase = expenses;
        }


        public IActionResult Detail(int id)
        {
            var expensefromdb = _expensedatabase.getexpense(id);

            var expense = new ExpenseDetailViewModel()
            {

               

                Description = contactFromDb.Description,

                Date = contactFromDb.Date,

                Amount = contactFromDb.Amount,

            };

            return View(expense);

        }
    }
}
