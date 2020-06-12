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
            IEnumerable<Expense> expenses = _expenseDatabase.GetExpenses().OrderBy(x => x.Date);
            var expense = new ExpenseEditViewModel();
            foreach (var thing in expenses)
            {
                ExpenseListViewModel Xp = new ExpenseListViewModel()
                {
                    Id = thing.Id,
                    Description = (string)thing.Description,
                    Date = (DateTime)thing.Date,
                    Amount = (decimal)thing.Amount
                };
                XpList.Add(Xp);
            }

            return View(XpList);
        }



        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public IActionResult Create(ExpenseCreateViewModel cvm)
        {
            Expense newExpense = new Expense()
            {
                Amount = cvm.Amount,
                Description = cvm.Description,
                Date = cvm.Date
            };

            _expenseDatabase.Insert(newExpense);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            Expense expenseToEdit = _expenseDatabase.GetExpenses(id);

            ExpenseEditViewModel evm = new ExpenseEditViewModel()

            {
                Amount = (decimal)expenseToEdit.Amount,
                Description = (string)expenseToEdit.Description,
                Date = (DateTime)expenseToEdit.Date
            };

            return View(evm);

        }

        [ValidateAntiForgeryToken]

        [HttpPost]

        public IActionResult Edit(ExpenseEditViewModel vm)

        {

            Expense newExpense = new Expense()
            {
                Amount = vm.Amount,
                Description = vm.Description,
                Date = vm.Date
            };
            _expenseDatabase.Update(vm.Id, newExpense);
            return (RedirectToAction("Index"));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Expense expenseToDelete = _expenseDatabase.GetExpenses(id);
            ExpenseDeleteViewModel dvm = new ExpenseDeleteViewModel()
            {
                Id = expenseToDelete.Id,
                Amount = expenseToDelete.Id,
                Description = expenseToDelete.Description,
                DateTime = expenseToDelete.Date
            };
        
        
        }


    }
}


