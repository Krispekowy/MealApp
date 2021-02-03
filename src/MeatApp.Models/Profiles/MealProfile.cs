using AutoMapper;
using MealApp.Models.Models;
using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class MealProfile : Profile
    {
        public MealProfile()
        {
            CreateMap<MealDTO, Meal>()
                .ForMember(dto=>dto.TypeOfMeal, opt=>opt.Ignore())
                .ForMember(dto=>dto.DayDietMeals, opt=>opt.Ignore());
        }
    }
}
