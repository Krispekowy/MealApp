using AutoMapper;
using MealApp.Models.Models;
using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Models.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dto => dto.MealProducts, opt=>opt.Ignore())
                .ForMember(dto => dto.Category, opt => opt.Ignore())
                .ForMember(dto => dto.PhotoPath, opt => opt.Ignore());
        }
    }
}
