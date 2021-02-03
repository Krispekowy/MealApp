using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeatApp.Models
{
    public class TypeOfMeal
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int Order { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
