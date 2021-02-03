using AutoMapper;
using MealApp.Models.Models;
using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class TypeOfMealProfile : Profile
    {
        public TypeOfMealProfile()
        {
            CreateMap<TypeOfMealDTO, TypeOfMeal>()
                .ForMember(dto => dto.Meals, opt => opt.Ignore())
                .ForMember(dto => dto.Order, opt => opt.Ignore());
        }
    }
}