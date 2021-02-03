using MealApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Services
{
    public interface IDayDietRepository
    {
        DietDay AddDayDiet(DietDay dayDiet);
        DietDay DeleteDayDiet(int id);
        DietDay GetDayDiet(int id);
        IEnumerable<DietDay> GetAllDays();
        IEnumerable<DietDay> GetAllDietDays(int id);
    }
}
