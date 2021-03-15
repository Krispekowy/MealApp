
using AutoMapper;
using MealApp.Models;
using MealApp.Models.Models;
using MealApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace MealApp.Pages.DayDiet
{
    public class AddDayModel : PageModel
    {
        private readonly IDayDietRepository dayDietRepository;
        private readonly IMealRepository mealRepository;
        private readonly IMapper mapper;

        public AddDayModel(
            IDayDietRepository dayDietRepository,
            IMealRepository mealRepository,
            IMapper mapper)
        {
            this.dayDietRepository = dayDietRepository;
            this.mealRepository = mealRepository;
            this.mapper = mapper;
        }

        [BindProperty]
        public DietDayDTO Day { get; set; }

        //Types of meals properties
        public SelectList Breakfast { get; set; }
        public SelectList Brunch { get; set; }
        public SelectList Lunch { get; set; }
        public SelectList Tea { get; set; }
        public SelectList Dinner { get; set; }
        public IActionResult OnGet(int dietId)
        {
            Day = new DietDayDTO()
            {
                DietId = dietId
            };
            GetMealsByType();
            return Page();
        }

        private void GetMealsByType()
        {
            Breakfast = new SelectList(mealRepository.MealByType(6).ToList(), "Id", "MealName");
            Brunch = new SelectList(mealRepository.MealByType(7).ToList(), "Id", "MealName");
            Lunch = new SelectList(mealRepository.MealByType(8).ToList(), "Id", "MealName");
            Tea = new SelectList(mealRepository.MealByType(4).ToList(), "Id", "MealName");
            Dinner = new SelectList(mealRepository.MealByType(9).ToList(), "Id", "MealName");
        }

        public IActionResult OnPost()
        {
            BuildDietDayMealsDTO();
            CalculateKcal();
            if (ModelState.IsValid)
            {
                var day = mapper.Map<DietDay>(Day);
                dayDietRepository.AddDayDiet(day);
                return RedirectToPage("/Diets/Edit", new { Id = Day.DietId });
            }
            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToPage("/Error");
            }
            
        }

        private void CalculateKcal()
        {
            foreach (var meal in Day.DayDietMeals)
            {
                Day.Kcal += mealRepository.GetMeal(meal.MealId).Kcal;
            }
        }

        private void BuildDietDayMealsDTO()
        {
            Day.DayDietMeals = new List<DietDayMealsDTO>();
            Day.DayDietMeals.AddRange(new List<DietDayMealsDTO>()
            {
                new DietDayMealsDTO()
                {
                    DietDayId = Day.Id,
                    MealId = Day.Breakfast,
                    TypeOfMeal = 6
                },
                new DietDayMealsDTO()
                {
                    DietDayId = Day.Id,
                    MealId = Day.Brunch,
                    TypeOfMeal = 7
                },
                new DietDayMealsDTO()
                {
                    DietDayId = Day.Id,
                    MealId = Day.Lunch,
                    TypeOfMeal = 8
                },
                new DietDayMealsDTO()
                {
                    DietDayId = Day.Id,
                    MealId = Day.Tea,
                    TypeOfMeal = 4
                },
                new DietDayMealsDTO()
                {
                    DietDayId = Day.Id,
                    MealId = Day.Dinner,
                    TypeOfMeal = 9
                },
            }); //Create object List<DietDayMealsDTO
        }
    }

}
