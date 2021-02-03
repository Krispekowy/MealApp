using AutoMapper;
using MealApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class DietDayMealsDTOProfile:Profile
    {
        public DietDayMealsDTOProfile()
        {
            CreateMap<DietDayMeals, DietDayMealsDTO>();
        }
    }
}
