using ExpenseApp.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExpenseApp.Services
{
    public interface IPhotoService
    {
        string UploadPicture(IFormFile photo);
        void DeletePicture(string url);
        void AssignPicToExpense(Expense expense);
    }
}

