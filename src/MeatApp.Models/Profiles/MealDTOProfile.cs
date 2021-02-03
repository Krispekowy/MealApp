using AutoMapper;
using MealApp.Models.Models;
using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class MealDTOProfile: Profile
    {
        public MealDTOProfile()
        {
            CreateMap<Meal, MealDTO>();
                //.ForMember(dto => dto.Products.Select(a => a.Id), opt => opt.MapFrom(src => src.MealProducts.Select(a => a.ProductId)))
                //.ForMember(dto => dto.Products.Select(a => a.Name), opt => opt.MapFrom(src => src.MealProducts.Select(a => a.Product.ProductName)))
                //.ForMember(dto => dto.Products.Select(a => a.Quantity), opt => opt.MapFrom(src => src.MealProducts.Select(a => a.Quantity)));
        }
    }
}
