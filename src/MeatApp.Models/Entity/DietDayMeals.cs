using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models
{
    public class DietDayMeals
    {
        public int DietDayId { get; set; }
        public DietDay DayDiet { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int TypeOfMeal { get; set; }
    }
}
