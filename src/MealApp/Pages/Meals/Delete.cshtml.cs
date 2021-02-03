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

namespace MealApp.Pages.Meals
{
    public class DeleteModel : PageModel
    {
        private readonly IMealRepository mealRepository;
        private readonly IMapper mapper;

        public DeleteModel(
            IMealRepository mealRepository,
            IMapper mapper)
        {
            this.mealRepository = mealRepository;
            this.mapper = mapper;
        }

        [BindProperty]
        public MealDTO MealDTO { get; set; }
        public IActionResult OnGet(int id)
        {
            var meal = mealRepository.GetMeal(id);
            MealDTO = mapper.Map<MealDTO>(meal);
            if (MealDTO == null)
            {
                return RedirectToPage("/NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Meal meal = mealRepository.DeleteMeal(MealDTO.Id);
            if (meal == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/Meals/Index");
        }
    }
}
