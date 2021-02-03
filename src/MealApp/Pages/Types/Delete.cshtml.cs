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
    public class DeleteModel : PageModel
    {
        private readonly ITypeOfMealRepository typeOfMealRepository;
        private readonly IMapper mapper;

        public DeleteModel(
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
            if (TypeOfMealDTO == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            TypeOfMeal typeOfMeal = typeOfMealRepository.DeleteType(TypeOfMealDTO.Id);
            if (typeOfMeal==null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/Types/Index");
        }
    }
}
