using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MealApp.Models.Entity;
using MealApp.Models.Models;
using MealApp.Services;
using MeatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MealApp.Pages.Products
{
    public class AddModel : PageModel
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public AddModel(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }
        [BindProperty]
        public ProductDTO ProductDTO { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IActionResult OnGet()
        {
            var categories = categoryRepository.GetAllCategories();
            Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return Page();
        }
        public IActionResult OnPost()
        {
            var product = mapper.Map<Product>(ProductDTO);
            productRepository.AddProduct(product);
            return RedirectToPage("Index");
        }
    }
}
