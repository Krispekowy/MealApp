using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealApp.Models.Models;
using MealApp.Services;
using MeatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealApp.Pages.Types
{
    public class AddModel : PageModel
    {
        private readonly ITypeOfMealRepository typeOfMealRepository;
        private readonly IMapper mapper;

        public AddModel(
            ITypeOfMealRepository typeOfMealRepository,
            IMapper mapper)
        {
            this.typeOfMealRepository = typeOfMealRepository;
            this.mapper = mapper;
        }
        [BindProperty]
        public TypeOfMealDTO TypeOfMealDTO { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var typeOfMeal = mapper.Map<TypeOfMeal>(TypeOfMealDTO);
            typeOfMealRepository.AddType(typeOfMeal);
            return RedirectToPage("Index");
        }
    }
}
