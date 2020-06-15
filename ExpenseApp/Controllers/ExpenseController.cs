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
        //private readonly IPhotoService _photoService;


        public ExpenseController(IExpenseDatabase ExpenseDatabase)
        {
            _expenseDatabase = ExpenseDatabase;
            //_photoService = photoService;
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
                    Category = thing.Category,
                    Description = (string)thing.Description,
                    Date = (DateTime)thing.Date,
                    Amount = (decimal)thing.Amount
                    //PhotoUrl = expense.PhotoUrl
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
                Category = cvm.Category,
                Description = cvm.Description,
                Date = cvm.Date
            };
            //_photoService.AssignPicToExpense(newExpense);
            _expenseDatabase.Insert(newExpense);
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpGet]
        public IActionResult Edit(int id)
        {

            Expense expenseToEdit = _expenseDatabase.GetExpenses(id);
            ExpenseEditViewModel evm = new ExpenseEditViewModel()
            {
                Amount = (decimal)expenseToEdit.Amount,
                Category = expenseToEdit.Category,
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
                Category = vm.Category,
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
                Amount = (decimal)expenseToDelete.Amount,
                Description = (string)expenseToDelete.Description,
                Date = (DateTime)expenseToDelete.Date
            };

            return View(dvm);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _expenseDatabase.Delete(id);
            return (RedirectToAction("Index"));
        }
    }
}


   



