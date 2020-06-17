using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseApp.Database;
using ExpenseApp.Domain;
using ExpenseApp.Models;
using ExpenseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Controllers
{
    public class ExpenseController : Controller
    {

        private readonly ExpenseDbContext _dbContext;
        private readonly IPhotoService _photoService;


        public ExpenseController(IPhotoService photoService, ExpenseDbContext dbContext)
        {
            _photoService = photoService;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(int id)
        {

            List<ExpenseListViewModel> XpList = new List<ExpenseListViewModel>();


            IEnumerable<Expense> expenses = await _dbContext.Expenses.ToListAsync();
            IEnumerable<Expense> sortedExpenses = expenses.OrderBy(x => x.Date);
            var expense = new ExpenseEditViewModel();
            foreach (var thing in sortedExpenses)
            {
                ExpenseListViewModel Xp = new ExpenseListViewModel()
                {
                    Id = thing.Id,
                    Category = thing.Category,
                    Description = (string)thing.Description,
                    Date = (DateTime)thing.Date,
                    Amount = (decimal)thing.Amount,
                    PhotoUrl = thing.PhotoUrl
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

        public  async Task<IActionResult> Create(ExpenseCreateViewModel cvm)
        {
            Expense newExpense = new Expense()
            {
                Amount = cvm.Amount,
                Category = cvm.Category,
                Description = cvm.Description,
                Date = cvm.Date,
                PhotoUrl= cvm.PhotoUrl
            };
            if (String.IsNullOrEmpty(newExpense.PhotoUrl))
            {
                _photoService.AssignPicToExpense(newExpense);
            }
            
            _dbContext.Add(newExpense);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Expense expenseToEdit = await _dbContext.Expenses.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            var categories = await _dbContext.Categories.ToListAsync();
            ExpenseEditViewModel evm = new ExpenseEditViewModel();

            foreach (Category category in categories)
            {
                evm.Category.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()

                {

                    Value = category.Id.ToString(),

                    Text = category.Name

                });

            }

            evm.Amount = (decimal)expenseToEdit.Amount;
            evm.CategoryId = expenseToEdit.Category.Id;
            evm.Description = (string)expenseToEdit.Description;
            evm.Date = (DateTime)expenseToEdit.Date;
            
            return View(evm);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public async Task<IActionResult> Edit(int id, ExpenseEditViewModel vm)
        {

            Expense changedExpense = await _dbContext.Expenses.FindAsync(id);
            changedExpense.Amount = vm.Amount;
            changedExpense.CategoryId = vm.CategoryId;
            changedExpense.Description = vm.Description;
            changedExpense.Date = vm.Date;

            _dbContext.Expenses.Update(changedExpense);
            await _dbContext.SaveChangesAsync();
            return (RedirectToAction("Index"));
        }

            [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Expense expenseToDelete = await _dbContext.Expenses.FindAsync(id);
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
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            _dbContext.Expenses.Remove(_dbContext.Expenses.Find(id));
            await _dbContext.SaveChangesAsync();
            return (RedirectToAction("Index"));
        }
    }
}


   



