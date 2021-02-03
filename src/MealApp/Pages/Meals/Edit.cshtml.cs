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
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IMealRepository mealRepository;
        private readonly IProductRepository productRepository;
        private readonly ITypeOfMealRepository typeOfMealRepository;
        private readonly IMapper mapper;

        public MealDTO MealDTO { get; set; }
        public IEnumerable<ProductDTO> ProductsDTO { get; set; }
        public IEnumerable<TypeOfMealDTO> TypeOfMealsDTO { get; set; }
        public EditModel(IMealRepository mealRepository,
            IProductRepository productRepository,
            ITypeOfMealRepository typeOfMealRepository,
            IMapper mapper)
        {
            this.mealRepository = mealRepository;
            this.productRepository = productRepository;
            this.typeOfMealRepository = typeOfMealRepository;
            this.mapper = mapper;
        }

        public IActionResult OnGet(int Id)
        {
            var types = typeOfMealRepository.GetAllTypes();
            TypeOfMealsDTO = mapper.Map<IEnumerable<TypeOfMealDTO>>(types);
            var products = productRepository.GetAllProducts();
            ProductsDTO = mapper.Map<IEnumerable<ProductDTO>>(products);
            var meal = mealRepository.GetMeal(Id);
            MealDTO = mapper.Map<MealDTO>(meal);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                MealDTO = CalculateKcal(MealDTO);
                var meal = mapper.Map<Meal>(MealDTO);
                mealRepository.UpdateMeal(meal);
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("Error");
            }
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
