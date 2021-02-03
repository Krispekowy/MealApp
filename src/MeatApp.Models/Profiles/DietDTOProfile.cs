using AutoMapper;
using MealApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class DietDTOProfile:Profile
    {
        public DietDTOProfile()
        {
            CreateMap<Diet, DietDTO>();
        }
    }
}
