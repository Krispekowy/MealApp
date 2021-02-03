using MealApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Services
{
    public interface IDietRepository
    {
        Diet AddDiet (Diet diet);
        Diet DeleteDiet(int id);
        Diet GetDiet(int id);
        List<Diet> GetAllDiets();
    }
}
