﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MealApp.Models
{
    public class Diet
    {
        public int Id { get; set; }
        public string DietName { get; set; }
        public string Description { get; set; }
        public IEnumerable<DietDay> Days { get; set; }
    }
}
