using AutoMapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealApp.Models.Profiles;
using System.Diagnostics;

namespace MealApp
{
    public class AutoMapperConfig
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg=> {
                cfg.AddProfile<ProductDTOProfile>();
                cfg.AddProfile<ProductProfile>();
                cfg.AddProfile<TypeOfMealDTOProfile>();
                cfg.AddProfile<TypeOfMealProfile>();
                cfg.AddProfile<MealProfile>();
                cfg.AddProfile<MealDTOProfile>();
                cfg.AddProfile<DietDayProfile>();
                cfg.AddProfile<DietDayDTOProfile>();
                cfg.AddProfile<DietDayMealsProfile>();
                cfg.AddProfile<DietDayMealsDTOProfile>();
                cfg.AddProfile<DietProfile>();
                cfg.AddProfile<DietDTOProfile>();
            });

            AssertConfigurationInDebug(config);
            var mapper = config.CreateMapper();
            return mapper;
        }

        [Conditional("DEBUG")]
        private static void AssertConfigurationInDebug(IConfigurationProvider config)
        {
            config.AssertConfigurationIsValid();
        }
    }
}
