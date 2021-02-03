using MealApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Services
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext dbContext;

        public SQLCategoryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return dbContext.ProductCategories;
        }

        public Category GetCategory(int id)
        {
            return dbContext.ProductCategories.Find(id);
        }
    }
}
