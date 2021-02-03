using AutoMapper;
using MealApp.Models.Models;
using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class ProductDTOProfile:Profile
    {
        public ProductDTOProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dto=>dto.CategoryId, opt=>opt.MapFrom(src=>src.CategoryId));
        }
    }
}
