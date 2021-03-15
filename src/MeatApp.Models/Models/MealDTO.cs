using MealApp.Models.Enums;
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
        public TypesOfMeal TypeOfMeal { get; set; }
        [Required(ErrorMessage = "Pole nazwa posiłku jest wymagane")]
        [MinLength(5, ErrorMessage = "Nazwa posiłku musi składać się z minimum 5 znaków")]
        [MaxLength(50, ErrorMessage = "Nazwa posiłku może składać się z maksimum 50 znaków")]
        public string MealName { get; set; }
        [MaxLength(1000, ErrorMessage = "Maksymalna długość opisu to 1000 znaków")]
        public string Description { get; set; }
        public int Kcal { get; set; } = 0;
        public List<MealProduct> MealProducts { get; set; }
    }
}
