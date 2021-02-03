using AutoMapper;
using MealApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class DietDayDTOProfile:Profile
    {
        public DietDayDTOProfile()
        {
            CreateMap<DietDay, DietDayDTO>()
                .ForMember(dto=>dto.Name, opt=>opt.MapFrom(src=>src.DayName))
                .ForMember(dto=>dto.DayDietMeals, opt=>opt.MapFrom(src=>src.DayDietMeals))
                .ForMember(dto=>dto.Id, opt=>opt.MapFrom(src=>src.Id))
                .ForMember(dto=>dto.Kcal, opt=>opt.MapFrom(src=>src.Kcal))
                .ForAllOtherMembers(opt=>opt.Ignore());
        }
    }
}
