using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Models
{
    public class DietDayMealsDTO
    {
        public int DietDayId { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int TypeOfMeal { get; set; }
    }
}
