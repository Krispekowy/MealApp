using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MealApp.Models.Models
{
    public class DietDayDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole nazwa dnia jest wymagane")]
        [DisplayName("Nazwa dnia")]
        public string Name { get; set; }
        public int DietId { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na I śniadanie")]
        public int Breakfast { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na II śniadanie")]
        public int Brunch { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na obiad")]
        public int Lunch { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na podwieczorek")]
        public int Tea { get; set; }
        [Required(ErrorMessage = "Wybierz posiłek na kolację")]
        public int Dinner { get; set; }
        public int Kcal { get; set; }
        public List<DietDayMealsDTO> DayDietMeals { get; set; }
    }
}
