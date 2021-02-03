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

namespace MealApp.Pages.DayDiet
{
    public class IndexModel : PageModel
    {
        private readonly IDayDietRepository dayDietRepository;
        private readonly IMapper mapper;

        [BindProperty]
        public IEnumerable<DietDayDTO> Days { get; set; }
        public IndexModel(
            IDayDietRepository dayDietRepository,
            IMapper mapper)
        {
            this.dayDietRepository = dayDietRepository;
            this.mapper = mapper;
        }
        public void OnGet()
        {
            var days = dayDietRepository.GetAllDays();
            Days = mapper.Map<IEnumerable<DietDayDTO>>(days);
        }
    }
}
