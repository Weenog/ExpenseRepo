
using ExpenseApp.Domain;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;



namespace ExpenseApp.Database
{
    public class ExpenseDbContext : IdentityDbContext<ExpenseAppIdentity>
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Household"
                },

                new Category()
                {
                    Id = 2,
                    Name = "Car"
                },

                new Category()
                {
                    Id = 3,
                    Name = "Food"
                },

                new Category()
                {
                    Id = 4,
                    Name = "Gift"
                },

                new Category()
                {
                    Id = 5,
                    Name = "Hobbies"
                },

                new Category()
                {
                    Id = 6,
                    Name = "Holiday"
                },

                new Category()
                {
                    Id = 7,
                    Name = "Utility"
                },

                 new Category()
                 {
                     Id = 8,
                     Name = "Secret"
                 }


                );
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}


