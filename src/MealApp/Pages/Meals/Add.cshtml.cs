using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealApp.Models;
using MealApp.Models.Models;
using MealApp.Services;
using MeatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace MealApp.Pages.Meals
{
    public class AddModel : PageModel
    {
        private readonly IMealRepository mealRepository;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        [BindProperty]
        public MealDTO MealDTO { get; set; }
        [BindProperty]
        public IEnumerable<ProductDTO> ProductsDTO { get; set; }
        public AddModel(IMealRepository mealRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            this.mealRepository = mealRepository;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        public IActionResult OnGet()
        {
            var products = productRepository.GetAllProducts();
            ProductsDTO = mapper.Map<IEnumerable<ProductDTO>>(products);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["ErrorMessage"] = ModelState.Select(x => x.Value.Errors)
                    .Where(y => y.Count > 0)
                    .ToList();
                return RedirectToPage("Error");
            }
            MealDTO = CalculateKcal(MealDTO);
            var meal = mapper.Map<Meal>(MealDTO);
            mealRepository.AddMeal(meal);
            return RedirectToPage("Index");
        }

        private MealDTO CalculateKcal(MealDTO mealDTO)
        {
            var mealProducts = new List<MealProduct>();
            foreach (var mealProduct in mealDTO.MealProducts)
            {
                if (mealProduct.ProductId != null & mealProduct.Quantity != null)
                {
                    var product = productRepository.GetProduct((int)mealProduct.ProductId);
                    mealDTO.Kcal = (int)(mealDTO.Kcal + (mealProduct.Quantity * product.Kcal / product.QuantityUnit));
                    mealProducts.Add(mealProduct);
                }
            }
            MealDTO.MealProducts = mealProducts;
            return MealDTO;
        }


    }
}
