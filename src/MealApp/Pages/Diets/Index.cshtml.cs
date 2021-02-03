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

namespace MealApp.Pages.Diet
{
    public class IndexModel : PageModel
    {
        private readonly IDietRepository dietRepository;
        private readonly IMapper mapper;

        public List<DietDTO> Diets { get; set; }

        public IndexModel(
            IDietRepository dietRepository,
            IMapper mapper)
        {
            this.dietRepository = dietRepository;
            this.mapper = mapper;
        }

        public IActionResult OnGet()
        {
            var diets = dietRepository.GetAllDiets();
            Diets = mapper.Map<List<DietDTO>>(diets);
            return Page();
        }
    }
}
