using MealApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MealApp.Services
{
    public class SQLDayDietRepository : IDayDietRepository
    {
        private readonly AppDbContext dbContext;

        public SQLDayDietRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public DietDay AddDayDiet(DietDay dayDiet)
        {
            dbContext.Add(dayDiet);
            dbContext.SaveChanges();
            return dayDiet;
        }

        public DietDay DeleteDayDiet(int id)
        {
            var dayDiet = dbContext.DayDiets.Find(id);
            if (dayDiet != null)
            {
                dbContext.Remove(dayDiet);
                dbContext.SaveChanges();
            }
            return dayDiet;
        }

        public IEnumerable<DietDay> GetAllDays()
        {
            return dbContext.DayDiets.Include(x => x.DayDietMeals);
        }

        public IEnumerable<DietDay> GetAllDietDays(int id)
        {
            return dbContext.DayDiets.Where(diet => diet.Id == id);
        }

        public DietDay GetDayDiet(int id)
        {
            return dbContext.DayDiets
                .Include(x => x.DayDietMeals)
                .Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
