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
    public class EditModel : PageModel
    {
        private readonly ITypeOfMealRepository typeOfMealRepository;
        private readonly IMapper mapper;

        public EditModel(
            ITypeOfMealRepository typeOfMealRepository,
            IMapper mapper)
        {
            this.typeOfMealRepository = typeOfMealRepository;
            this.mapper = mapper;
        }

        [BindProperty]
        public TypeOfMealDTO TypeOfMealDTO { get; set; }
        public IActionResult OnGet(int id)
        {
            var typeOfMeal = typeOfMealRepository.GetType(id);
            TypeOfMealDTO = mapper.Map<TypeOfMealDTO>(typeOfMeal);
            return Page();
        }

        public IActionResult OnPost()
        {
            var typeOfMeal = mapper.Map<TypeOfMeal>(TypeOfMealDTO);
            typeOfMealRepository.UpdateType(typeOfMeal);
            return RedirectToPage("Index");
        }
    }
}
