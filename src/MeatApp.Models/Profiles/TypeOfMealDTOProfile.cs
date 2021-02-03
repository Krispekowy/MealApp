using AutoMapper;
using MealApp.Models.Models;
using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class TypeOfMealDTOProfile:Profile
    {
        public TypeOfMealDTOProfile()
        {
            CreateMap<TypeOfMeal, TypeOfMealDTO>();
        }
    }
}
