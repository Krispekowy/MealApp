using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MealApp.Models.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Kcal { get; set; }
        public int QuantityUnit { get; set; }
        public string Unit { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IFormFile Photo { get; set; }
    }
}
