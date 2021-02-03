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
    public class DeleteModel : PageModel
    {
        private readonly IDietRepository dietRepository;
        private readonly IMapper mapper;

        public DeleteModel(
            IDietRepository dietRepository,
            IMapper mapper)
        {
            this.dietRepository = dietRepository;
            this.mapper = mapper;
        }

        [BindProperty]
        public DietDTO Diet { get; set; }
        public IActionResult OnGet(int id)
        {
            var diet = dietRepository.GetDiet(id);
            if (diet == null)
            {
                return RedirectToPage("/NotFound");
            }
            Diet = mapper.Map<DietDTO>(diet);
            return Page();
        }

        public IActionResult OnPost()
        {
            Models.Diet diet = dietRepository.DeleteDiet(Diet.Id);
            if (diet == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/Diets/Index");
        }
    }
}
