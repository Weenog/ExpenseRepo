
using ExpenseApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseApp.Database

{
  
    public interface IExpenseDatabase
    {
        Expense Insert(Expense Expense);
        IEnumerable<Expense> GetExpenses();
        Expense GetExpenses(int id);
        void Delete(int id);
        void Update(int id, Expense Expense);
    }



    public class ExpenseDatabase : IExpenseDatabase
    {
        private int _counter;
        private readonly List<Expense> _Expense;


        public ExpenseDatabase()
        {
            if (_Expense == null)
            {
                _Expense = new List<Expense>();
            }
        }



        public Expense GetExpenses(int id)
        {
            return _Expense.FirstOrDefault(x => x.Id == id);
        }



        public IEnumerable<Expense> GetExpenses()

        {

            return _Expense;

        }



        public Expense Insert(Expense Expense)

        {

            _counter++;

            Expense.Id = _counter;

            _Expense.Add(Expense);

            return Expense;

        }



        public void Delete(int id)

        {

            var Expense = _Expense.SingleOrDefault(x => x.Id == id);

            if (Expense != null)

            {

                _Expense.Remove(Expense);

            }

        }



        public void Update(int id, Expense updatedExpense)

        {

            var Expense = _Expense.SingleOrDefault(x => x.Id == id);

            if (Expense != null)

            {

                Expense.Amount = updatedExpense.Amount;

                Expense.Date = updatedExpense.Date;

                Expense.Description = updatedExpense.Description;

            }

        }

    }

}