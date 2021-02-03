using MealApp.Models;
using MealApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeatApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext dbContext;
        private readonly IShoppingListRepository shoppingList;

        public IndexModel(
            ILogger<IndexModel> logger,
            AppDbContext dbContext,
            IShoppingListRepository shoppingList)
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.shoppingList = shoppingList;
        }
        [BindProperty(SupportsGet = true)]
        public string FirstName { get; set; }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            //var diets = dbContext.Diets;
            //var ids = dbContext.Diets.Select(a=>a.Id).ToList();
            //var names = dbContext.Diets.Select(a => a.DietName).ToList();
            //var diet = new Diet()
            //{
            //    Id = ids.Aggregate((sum, id) => sum + id),
            //    DietName = names.Aggregate((sum, name) => sum + name)
            //};
            //var idki = diets.Select(a => a.Id).Aggregate((sum, id) => sum + id);
        }
    }
}
