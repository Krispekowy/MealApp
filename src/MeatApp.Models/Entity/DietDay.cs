using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models
{
    public class DietDay
    {
        public int Id { get; set; }
        public string DayName { get; set; }
        public int DietId { get; set; }
        public Diet Diet { get; set; }
        public virtual List<DietDayMeals> DayDietMeals { get; set; }
        
        public int Kcal { get; set; }
    }
}
