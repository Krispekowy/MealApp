using MeatApp.Models;
using System;
using System.Collections.Generic;

namespace MealApp.Services
{
    public interface IMealRepository
    {
        IEnumerable<Meal> Search(string searchTerm);
        IEnumerable<Meal> GetAllMeals();
        Meal GetMeal(int id);
        Meal DeleteMeal(int id);
        Meal UpdateMeal(Meal meal);
        Meal AddMeal(Meal meal);
        IEnumerable<Meal> MealByType(int typeId);
    }
}
