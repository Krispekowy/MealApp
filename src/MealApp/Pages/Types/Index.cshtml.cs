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
    public class IndexModel : PageModel
    {
        private readonly ITypeOfMealRepository typeOfMealRepository;
        private readonly IMapper mapper;

        public IndexModel(
            ITypeOfMealRepository typeOfMealRepository,
            IMapper mapper)
        {
            this.typeOfMealRepository = typeOfMealRepository;
            this.mapper = mapper;
        }
        [BindProperty]
        public IEnumerable<TypeOfMealDTO> TypesOfMealDTO { get; set; }
        public IActionResult OnGet()
        {
            var typeOfMeals = typeOfMealRepository.GetAllTypes();
            TypesOfMealDTO = mapper.Map<IEnumerable<TypeOfMealDTO>>(typeOfMeals);
            return Page();
        }
    }
}
