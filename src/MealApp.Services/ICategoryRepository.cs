using MealApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategory(int id);
    }
}
