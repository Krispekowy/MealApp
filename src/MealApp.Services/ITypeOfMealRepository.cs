using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Services
{
    public interface ITypeOfMealRepository
    {
        IEnumerable<TypeOfMeal> GetAllTypes();
        TypeOfMeal AddType(TypeOfMeal typeOfMeal);
        TypeOfMeal GetType(int id);
        TypeOfMeal UpdateType(TypeOfMeal typeOfMeal);
        TypeOfMeal DeleteType(int id);
    }
}
