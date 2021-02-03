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
    public class IndexModel : PageModel
    {
        private readonly IMealRepository mealRepository;
        private readonly IMapper mapper;

        [BindProperty]
        public IEnumerable<MealDTO> MealsDTO { get; set; }
        public IndexModel(
            IMealRepository mealRepository,
            IMapper mapper)
        {
            this.mealRepository = mealRepository;
            this.mapper = mapper;
        }
        public IActionResult OnGet()
        {
            var meals = mealRepository.GetAllMeals();
            MealsDTO = mapper.Map<IEnumerable<MealDTO>>(meals);
            return Page();
        }
    }
}
