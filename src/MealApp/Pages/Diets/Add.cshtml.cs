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
        private List<string> errorMsg = new List<string>();
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
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var diet = mapper.Map<Models.Diet>(Diet);
            dietRepository.AddDiet(diet);
            return RedirectToPage("Index");
        }

        private List<string> isModelIsValid()
        {
            if (Diet.DietName.Length <= 5)
            {
                errorMsg.Add("Nazwa diety musi mie� minimum 5 znak�w");
                ModelState.AddModelError("DietNameMin5", "Nazwa diety musi mie� minimum 5 znak�w");
            }

            if (Diet.DietName.Length >30)
            {
                errorMsg.Add("Nazwa diety mo�e mie� maksymalnie 30 znak�w");
                ModelState.AddModelError("DietNameMax30", "Nazwa diety mo�e mie� maksymalnie 30 znak�w");
            }
                return errorMsg;
        }
    }
}
