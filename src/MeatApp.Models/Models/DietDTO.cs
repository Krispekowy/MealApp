using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MealApp.Models.Models
{
    public class DietDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole nazwa diety jest wymagane")]
        [MinLength(3, ErrorMessage = "Nazwa diety musi składać się z minimum 3 znaków")]
        [MaxLength(50, ErrorMessage = "Nazwa diety nie może być dłuższa niż 50 znaków")]
        public string DietName { get; set; }
        [MaxLength(500, ErrorMessage = "Opis diety nie może być dłuższy niż 500 znaków")]
        public string Description { get; set; }
        public IEnumerable<DietDayDTO> Days { get; set; }
    }
}
