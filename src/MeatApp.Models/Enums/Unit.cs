using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MealApp.Models.Enums
{
    public enum Unit
    {
        [Display(Name = "-")]
        brak = 0,
        [Display(Name = "g")]
        gram = 1,
        [Display(Name = "ml")]
        mililitr = 2,
        [Display(Name = "szt")]
        sztuka = 3
    }
}
