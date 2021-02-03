using MeatApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MealApp.Models.Models
{
    public class MealDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole typ posiłku jest wymagane")]
        public int TypeOfMealId { get; set; }
        [Required(ErrorMessage = "Pole nazwa posiłku jest wymagane")]
        public string MealName { get; set; }
        public string Description { get; set; }
        public int Kcal { get; set; } = 0;
        public List<MealProduct> MealProducts { get; set; }
    }
}
