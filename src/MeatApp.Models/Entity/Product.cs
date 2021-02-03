using MealApp.Models;
using MealApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeatApp.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Kcal { get; set; }
        public int QuantityUnit { get; set; }
        public string Unit { get; set; }
        [NotMapped]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual List<MealProduct> MealProducts { get; set; }
    }
}
