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
        public string DietName { get; set; }
        public string Description { get; set; }
        public IEnumerable<DietDayDTO> Days { get; set; }
    }
}
