using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealApp.Models;
using MealApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MealApp.Pages.Diet
{
    public class AddDietModel : PageModel
    {
        private readonly IDietRepository dietRepository;
        private readonly IMapper mapper;

        [BindProperty]
        public Models.Models.DietDTO Diet { get; set; }
        public AddDietModel(
            IDietRepository dietRepository,
            IMapper mapper)
        {
            this.dietRepository = dietRepository;
            this.mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var diet = mapper.Map<Models.Diet>(Diet);
                dietRepository.AddDiet(diet);
            }
            return RedirectToPage("Index");
        }
    }
}
