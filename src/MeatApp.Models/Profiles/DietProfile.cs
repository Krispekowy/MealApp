using AutoMapper;
using MealApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class DietProfile:Profile
    {
        public DietProfile()
        {
            CreateMap<DietDTO, Diet>();
        }
    }
}
