using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealApp.Models;
using MealApp.Models.Models;
using MealApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealApp.Pages.Diets
{
    public class EditDietModel : PageModel
    {
        private readonly IDayDietRepository dayDietRepository;
        private readonly IDietRepository dietRepository;
        private readonly IMapper mapper;

        [BindProperty]
        public DietDTO Diet { get; set; }

        public EditDietModel(
            IDayDietRepository dayDietRepository,
            IDietRepository dietRepository,
            IMapper mapper)
        {
            this.dayDietRepository = dayDietRepository;
            this.dietRepository = dietRepository;
            this.mapper = mapper;
        }
        public IActionResult OnGet(int id)
        {
            var diet = dietRepository.GetDiet(id);
            Diet = mapper.Map<DietDTO>(diet);
            return Page();
        }

        public IActionResult OnPostDeleteDay(int id)
        {
            dayDietRepository.DeleteDayDiet(id);
            return RedirectToPage(Diet.Id);
        }
    }
}
