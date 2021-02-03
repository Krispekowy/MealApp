using AutoMapper;
using MealApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class DietDayMealsProfile:Profile
    {
        public DietDayMealsProfile()
        {
            CreateMap<DietDayMealsDTO, DietDayMeals>()
                .ForMember(dto => dto.DayDiet, opt => opt.Ignore()) ;
        }
    }
}
