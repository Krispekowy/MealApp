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
    public class DeleteDayModel : PageModel
    {
        private readonly IDayDietRepository dayDietRepository;
        private readonly IMapper mapper;

        public DeleteDayModel(
            IDayDietRepository dayDietRepository,
            IMapper mapper)
        {
            this.dayDietRepository = dayDietRepository;
            this.mapper = mapper;
        }
        [BindProperty]
        public DietDayDTO Day { get; set; }
        public IActionResult OnGet(int id)
        {
            var day = dayDietRepository.GetDayDiet(id);
            if(day == null)
            {
                return RedirectToPage("/NotFound");
            }
            Day = mapper.Map<DietDayDTO>(day);
            return Page();
        }
        public IActionResult OnPost()
        {
            DietDay deletedDay = dayDietRepository.DeleteDayDiet(Day.Id);
            if (deletedDay == null)
            {
                return RedirectToPage("/NotFound");
            }
            return RedirectToPage("/Diets/Edit", new { Id = deletedDay.DietId });
        }
    }
}
