using AutoMapper;
using MealApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class DietDayProfile:Profile
    {
        public DietDayProfile()
        {
            CreateMap<DietDayDTO, DietDay>()
                .ForMember(dto => dto.DayName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dto => dto.Diet, opt => opt.Ignore())
                .ForMember(dto => dto.Kcal, opt => opt.MapFrom(src => src.Kcal));
        }
    }
}
