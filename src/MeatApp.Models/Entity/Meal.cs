using MealApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeatApp.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public int? TypeOfMealId { get; set; }
        public TypeOfMeal TypeOfMeal { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }

        public int Kcal { get; set; }
        [ForeignKey("MealId")]
        public virtual List<MealProduct> MealProducts { get; set; }
        public virtual List<DietDayMeals> DayDietMeals { get; set; }
    }
}
